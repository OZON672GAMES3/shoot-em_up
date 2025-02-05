using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private const int IndexMainMenuScene = 0;
    private const int IndexLevelOneScene = 1;
    
    [SerializeField] private Image _menu;
    [SerializeField] private Image _pauseMenu;

    private bool _isGamePaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (_isGamePaused)
                ResumeGame();
            else
                PauseGame();
    }
    
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void StartButtonLevelOne()
    {
        SceneManager.LoadScene(IndexLevelOneScene);
    }

    public void SettingsButton()
    {
        _menu.gameObject.SetActive(true);
    }

    public void ReturnButton()
    {
        _menu.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        _pauseMenu.gameObject.SetActive(true);    // Включаем меню паузы
        Time.timeScale = 0f;          // Ставим игру на паузу
        _isGamePaused = true;
    }

    public void ResumeGame()
    {
        _pauseMenu.gameObject.SetActive(false);  // Отключаем меню паузы
        Time.timeScale = 1f;          // Возобновляем игру
        _isGamePaused = false;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;          // Сбрасываем время перед выходом
        SceneManager.LoadScene(IndexMainMenuScene);
    }
}