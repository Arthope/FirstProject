using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindow;

    public MonoBehaviour[] ComponentsToDisable;

    public void OpenMenuWindow() 
    {
        _menuButton.SetActive(false);
        _menuWindow.SetActive(true);

        for (int i = 0; i < ComponentsToDisable.Length; i++)
        {
            ComponentsToDisable[i].enabled = false;
        }
        Time.timeScale = 0.01f;
    }

    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(false);

        for (int i = 0; i < ComponentsToDisable.Length; i++)
        {
            ComponentsToDisable[i].enabled = false;
        }
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
