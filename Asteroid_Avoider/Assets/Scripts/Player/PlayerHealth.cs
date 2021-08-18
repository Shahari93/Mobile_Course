using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void Crash()
    {
        // We set if off and not destroy because later we'll add RV and respawn the player
        gameObject.SetActive(false);
    }
}
