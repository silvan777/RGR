using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;
	//ф-я яка відровідає за відображення меню
    void Start()
    {
        PauseUI.SetActive(false);
    }
	//ф-я яка відповідає за кнопки меню
    void Update()
    {
        if (Input.GetButtonDown("Pause")) //якщо натиснути на кнопку пауза
        {
            paused = !paused; //вкл. пауза
        }
        if (paused) //якщо пауза вкл.
        {
            PauseUI.SetActive(true); //відкривається меню
            Time.timeScale = 0; //час зупиняється
        }

        if (!paused) //якщо пауза викл.
        {
            PauseUI.SetActive(false); //меню закривається
            Time.timeScale = 1; //час відновлюється
        }
    }

    public void Resume() //ф-я продовження гри
    {
        paused = false;
    }
    public void Restart() //ф-я перезапуску рівня
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void MainManu() //ф-я переходу на головне меню
    {
        Application.LoadLevel(0);
    }
    public void Quit() //ф-я виходу
    {
        Application.Quit();
    }
}
