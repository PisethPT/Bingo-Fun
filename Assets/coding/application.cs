using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class application : MonoBehaviour
{
    public AudioSource home;
    private void Start()
    {
        home.Play();
    }
    public void startGamePlay()
    {
        SceneManager.LoadScene("Bingo");
    }

    public void qiutGame()
    {
        Application.Quit();
    }

}
