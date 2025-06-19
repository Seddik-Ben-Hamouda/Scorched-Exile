using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public AudioClip levelCompleteSound; // Sound effect for level complete
    private AudioSource audioSource;
    private bool hasPlayedSound = false; // Flag to track if the sound has been played
    public TextMeshProUGUI hintText;
     

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hintText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered is the character
        if (other.CompareTag("Player") && !hasPlayedSound) // Check if the sound has not been played yet
        {
            
            StartCoroutine(loadNextLevelAfterDelay(2f));
            audioSource.PlayOneShot(levelCompleteSound);
            hasPlayedSound = true; 
            hintText.gameObject.SetActive(true);
            
        }
    }

    IEnumerator loadNextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // You can use SceneManager to load the next scene in the build order
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if there's a next scene available
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            
        }
        else
        {
            Debug.LogWarning("No next scene available.");
        }
    }
}
