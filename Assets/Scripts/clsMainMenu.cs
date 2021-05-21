using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clsMainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Instructions;

    void Start()
    {
        MainMenuButton();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayNowButton()
    {
        // Links Start Game button to the scene holding my game
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameLevel");
    }

    public void InstructionsButton()
    {
        // Show the Instructions Menu
        MainMenu.SetActive(false);
        Instructions.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show the Main Menu
        MainMenu.SetActive(true);
        Instructions.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit the Game
        Application.Quit();
    }
}