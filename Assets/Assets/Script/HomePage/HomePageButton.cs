using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Assets.Script.HomePage
{
    public class MainMenu : MonoBehaviour
    {
        // Assigne l'index ou le nom de ta scène de jeu
        [SerializeField] private string gameSceneName = "GameScene";
        public static bool gameIsPaused = false;
        public GameObject pauseMenuUi;


        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Paused();
                }
            }
        }

        void Paused()
        {
            pauseMenuUi.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    
        public void Resume()
        {
            pauseMenuUi.SetActive(false);
            Time.timeScale = 1;
            gameIsPaused = false;
        }
    
        public void OnPlayClicked()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        public void OnQuitClicked()
        {
            Application.Quit();
        }

        public void OnRestartClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            pauseMenuUi.SetActive(false);
            Time.timeScale = 1;
            gameIsPaused = false;
        }
    }
}