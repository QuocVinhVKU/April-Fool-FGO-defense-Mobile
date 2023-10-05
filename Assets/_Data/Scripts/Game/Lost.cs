using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost : MonoBehaviour
{
    public void RePlay()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }
    public void ReturnHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ChooseLevel");
    }
    public void NextScene(string nameScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nameScene);
    }
}
