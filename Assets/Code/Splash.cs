using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 15f;
    public bool useSceneIndex = false; // Загружать по номеру?
    public int sceneIndex = 0; // Номер сцены (0 = первая)
    public string sceneName = "Main Menu"; // Или по имени

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            LoadTargetScene();
        }
    }

    void LoadTargetScene()
    {
        if (useSceneIndex)
        {
            if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Debug.LogError($"Нет сцены с индексом {sceneIndex}! Проверь Build Settings.");
            }
        }
        else
        {
            if (Application.CanStreamedLevelBeLoaded(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError($"Сцена '{sceneName}' не найдена! Добавь её в Build Settings.");
            }
        }
    }
}