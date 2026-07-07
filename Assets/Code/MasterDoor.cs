using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    void Update()
    {
        // Если нажали E и курсор на двери
        if (Input.GetKeyDown(KeyCode.E) && IsCursorOnDoor())
        {
            // Проверяем, уничтожены ли оба куба (если нет — ключи не собраны)
            bool isCube18Destroyed = GameObject.Find("Cube (18)") == null;
            bool isCube19Destroyed = GameObject.Find("Cube (19)") == null;

            Debug.Log($"Cube (18) уничтожен: {isCube18Destroyed}, Cube (19) уничтожен: {isCube19Destroyed}");

            // Если оба куба уничтожены — загружаем сцену
            if (isCube18Destroyed && isCube19Destroyed)
            {
                // Разблокируем курсор перед загрузкой сцены
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                SceneManager.LoadScene(3); // "Cube (20)"
            }
            else
            {
                Debug.Log("Нужно собрать оба ключа!");
            }
        }
    }

    // Проверка наведения курсора на дверь
    private bool IsCursorOnDoor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject == gameObject;
        }
        return false;
    }
}