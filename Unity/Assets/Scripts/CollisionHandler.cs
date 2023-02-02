using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] float levelLoadDelay = 2f;
    public bool isTransitioning;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning) { return; }


        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<PlayerController>().enabled = false;
        audioSource.PlayOneShot(success);
        Invoke("LoadNextLevel", levelLoadDelay);
    }


    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop(); 
        GetComponent<PlayerController>().enabled = false;
        audioSource.PlayOneShot(crash);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);  
    }

}
