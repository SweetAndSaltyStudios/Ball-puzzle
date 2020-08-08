using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : Singelton<GameMaster>
{
    private readonly AsyncOperation asyncOperation;
    private GameObject gameBall;

    private void Awake()
    {
        gameBall = Resources.Load<GameObject>("Prefabs/Game/Ball");
    }

    private void Start()
    {
        Instantiate(gameBall);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadLevelAsync(sceneName));         
    }

    public string GetCurrentScene()
    {
        string currentScene;
        currentScene = SceneManager.GetActiveScene().name;
        return currentScene;
    }

    public string NextSceneIndex()
    {
        int currentScene;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene = currentScene + 1;
        return "Level" + currentScene.ToString();
    }

    private IEnumerator LoadLevelAsync(string sceneName)
    {
        yield return new WaitForSecondsRealtime(/*fadeDuration*/1);
        //asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        //asyncOperation.allowSceneActivation = false;

        //while (!asyncOperation.isDone)
        //{
        //    if (asyncOperation.progress >= 0.9f)
        //    {
        //        asyncOperation.allowSceneActivation = true;
        //    }
        //    yield return null;
        //}
    }
}
