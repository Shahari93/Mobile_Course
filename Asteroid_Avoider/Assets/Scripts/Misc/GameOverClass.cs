using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverClass : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button returnToMainMenuButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject player;
    //[SerializeField] private Button playAgain;


    void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        returnToMainMenuButton.onClick.AddListener(ReturnToMenu);
        continueButton.onClick.AddListener(ContinueButton);
    }

    // Start the scene with score equals to 0
    private void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    // Goes back to the main menu scene
    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // RV button
    private void ContinueButton()
    {
        AdManager.adManagerInstance.ShowAd(this);

        continueButton.interactable = false;
    }

    public void GameOverDisplay()
    {
        gameOverScreen.SetActive(true);
        scoreManager.CountScore();

        // when not enabled, the update method will not be called and it will stop spawning asteroids
        asteroidSpawner.enabled = false;
    }

    // Continue the game after watching RV
    public void ContinueGame()
    {
        scoreManager.StartTimer();
        player.transform.position = Vector3.zero;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.SetActive(true);
        asteroidSpawner.enabled = true;
        gameOverScreen.SetActive(false);
    }
}
