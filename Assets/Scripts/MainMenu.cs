using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad;

    public GameObject settingsWindow;
    public GameObject creditsWindow;
    public GameObject CreditsButton;
    public GameObject QuitGameButton;

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void Options()
    {
        settingsWindow.SetActive(true);
        CreditsButton.SetActive(false);
        QuitGameButton.SetActive(false);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
        CreditsButton.SetActive(true);
        QuitGameButton.SetActive(true);
    }
    public void Credits()
    {
        creditsWindow.SetActive(true);
        CreditsButton.SetActive(false);
        QuitGameButton.SetActive(false);
    }

    public void CloseCreditsWindow()
    {
        creditsWindow.SetActive(false);
        CreditsButton.SetActive(true);
        QuitGameButton.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
