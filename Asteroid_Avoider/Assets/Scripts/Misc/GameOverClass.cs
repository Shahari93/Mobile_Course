using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverClass : MonoBehaviour
{
    [SerializeField] private Button playAgain;
    [SerializeField] private Button returnToMainMenu;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private ScoreManager scoreManager;
    //[SerializeField] private Button playAgain;


    void Start()
    {
        playAgain.onClick.AddListener(PlayAgain);
        returnToMainMenu.onClick.AddListener(ReturnToMenu);
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOverDisplay()
    {
        gameOverScreen.SetActive(true);

        // when not enabled, the update method will not be called and it will stop spawning asteroids
        scoreManager.CountScore();
        asteroidSpawner.enabled = false;
    }
}
