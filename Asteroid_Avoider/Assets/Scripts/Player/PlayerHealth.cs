using UnityEngine;

public class PlayerHealth : MonoBehaviour
{


    [SerializeField] private GameOverClass gameOver;

    public void Crash()
    {
        gameOver.GameOverDisplay();
        // We set if off and not destroy because later we'll add RV and respawn the player
        gameObject.SetActive(false);
    }
}
