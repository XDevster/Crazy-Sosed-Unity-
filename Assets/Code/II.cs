using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterFollow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 0f;
    public float stoppingDistance = 0f;
    public string playerObjectName = "First Person Controller"; // Имя объекта игрока
    public string cubeToCheckName = "Cube (10)"; // Имя куба, за которым нужно следить

    private GameObject cubeToCheck;
    private bool cubeWasDestroyed = false;

    private void Start()
    {
        // Автопоиск игрока, если не установлен вручную
        if (player == null)
        {
            GameObject playerObj = GameObject.Find(playerObjectName);
            if (playerObj != null) player = playerObj.transform;
        }

        // Находим куб для проверки
        cubeToCheck = GameObject.Find(cubeToCheckName);
    }

    private void Update()
    {
        // Проверяем, был ли удалён куб
        if (!cubeWasDestroyed && cubeToCheck == null)
        {
            cubeWasDestroyed = true;
            moveSpeed = 6f;
            Debug.Log($"Cube {cubeToCheckName} was destroyed, moveSpeed set to {moveSpeed}");
        }

        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(direction);

            if (direction.magnitude > stoppingDistance)
                transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckForPlayerCollision(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckForPlayerCollision(collision.gameObject);
    }

    private void CheckForPlayerCollision(GameObject other)
    {
        // Проверка по имени объекта или родительского объекта
        if (other.name == playerObjectName ||
           (other.transform.parent != null && other.transform.parent.name == playerObjectName))
        {
            Debug.Log("Player detected! Loading scene 4...");

            // Разблокировка курсора перед загрузкой сцены
            UnlockCursor();

            SceneManager.LoadScene(4);
        }
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Разблокируем курсор
        Cursor.visible = true; // Делаем курсор видимым
        Debug.Log("Cursor unlocked and visible");
    }
}