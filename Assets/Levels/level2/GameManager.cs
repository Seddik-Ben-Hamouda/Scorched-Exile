using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform respawnPoint; // Set this to the initial position where you want the character to respawn

    void Update()
    {
        // Check if the character falls below a certain y-position (fall out of the map)
        if (transform.position.y < -7) // Adjust the value according to your map's dimensions
        {
            // Reset the game
            ResetGame();
        }
    }

    void ResetGame()
    {
        // You may want to perform additional reset tasks here if needed

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
