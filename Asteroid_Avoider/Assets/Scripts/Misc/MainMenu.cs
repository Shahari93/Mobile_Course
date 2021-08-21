using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    private void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}