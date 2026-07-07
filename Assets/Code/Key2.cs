using UnityEngine;

public class KeyPickup2 : MonoBehaviour
{
    public int Key2 = 0; // Переменная для первого ключа

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
                if (hit.collider.gameObject.name == "Cube (19)")
                {
                    // Уничтожаем объект
                    Destroy(hit.collider.gameObject);
                    // Присваиваем переменной Key1 значение 1
                    Key2 = 1;
                    Debug.Log("Получен ключ 2! Key2 = " + Key2);
                }
            }
        }
    }
}