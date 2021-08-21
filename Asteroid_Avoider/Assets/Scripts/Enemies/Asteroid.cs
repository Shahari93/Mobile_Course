using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if(playerHealth == null)
        {
            return;
        }
        else
        {
            playerHealth.Crash();
        }
    }

    // When the game object goes behind the scene it will be destroied
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}