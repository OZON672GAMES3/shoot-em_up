using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image _menu;
    [SerializeField] private Image _settingsMenu;
    [SerializeField] private Image _pauseMenu;

    private bool _isGamePaused = true;

    private void Start()
    {
        Time.timeScale = 0f;
        // _menu.gameObject.SetActive(true);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void StartButton()
    {
        Time.timeScale = 1f;
        _isGamePaused = false;
        _menu.gameObject.SetActive(false);
    }

    public void SettingsButton()
    {
        _settingsMenu.gameObject.SetActive(true);
    }

    public void ReturnButton()
    {
        _settingsMenu.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        _pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        _isGamePaused = true;
    }

    public void ResumeGame()
    {
        _pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        _isGamePaused = false;
    }

    public void PauseMenuReturn()
    {
        Time.timeScale = 0f;
        _menu.gameObject.SetActive(true);
        _settingsMenu.gameObject.SetActive(false);
        _pauseMenu.gameObject.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}