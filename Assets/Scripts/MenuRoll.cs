using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRoll : MonoBehaviour
{
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _rollButton;

    public MonoBehaviour[] ComponentsToDisable;

    private void Start()
    {
        OpenMenuRoll();
    }

    public void OpenMenuRoll()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(true);

        for (int i = 0; i < ComponentsToDisable.Length; i++)
        {
            ComponentsToDisable[i].enabled = false;
        }
        Time.timeScale = 0f;
    }

    public void CloseMenuRoll()
    {
        _menuButton.SetActive(false);
        _menuWindow.SetActive(false);

        for (int i = 0; i < ComponentsToDisable.Length; i++)
        {
            ComponentsToDisable[i].enabled = false;
        }
        Time.timeScale = 1f;
    }

    public void PlayButton()
    {
        _rollButton.SetActive(true);
        _menuButton.SetActive(false);
    }
}
