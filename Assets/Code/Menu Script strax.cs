using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Загрузка сцены под номером 2 (нумерация начинается с 0)
        // В Build Settings убедитесь, что ваша игровая сцена имеет индекс 2
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        // Выход из игры (работает только в собранной версии, не в редакторе)
        Application.Quit();
    } // This closing brace was missing

    public void GoMenu()
    {
        // Загрузка сцены под номером 2 (нумерация начинается с 0)
        // В Build Settings убедитесь, что ваша игровая сцена имеет индекс 2
        SceneManager.LoadScene(1);
    }
}