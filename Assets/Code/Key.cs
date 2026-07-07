using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public int Key1 = 0; // Переменная для первого ключа

    void Update()
    {
        // Проверяем нажатие клавиши E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Создаем луч от камеры в направлении курсора
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем пересечение луча с коллайдером
            if (Physics.Raycast(ray, out hit))
            {
                // Если попали в объект с именем "Cube (18)"
                if (hit.collider.gameObject.name == "Cube (18)")
                {
                    // Уничтожаем объект
                    Destroy(hit.collider.gameObject);
                    // Присваиваем переменной Key1 значение 1
                    Key1 = 1;
                    Debug.Log("Получен ключ 1! Key1 = " + Key1);
                }
            }
        }
    }
}