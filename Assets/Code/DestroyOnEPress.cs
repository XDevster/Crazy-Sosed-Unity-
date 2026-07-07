using UnityEngine;

public class DestroyDoorOnClick : MonoBehaviour
{
    public string doorName = "Cube (10)"; // Название объекта двери
    public float maxDistance = 5f; // Максимальная дистанция луча

    private void Update()
    {
        // Если нажата клавиша E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Создаём луч из камеры в направлении курсора
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, попал ли луч в объект
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                // Если попал в объект с нужным именем
                if (hit.collider.gameObject.name == doorName)
                {
                    Destroy(hit.collider.gameObject); // Уничтожаем дверь
                    Debug.Log("Дверь уничтожена!");
                }
            }
        }
    }
}