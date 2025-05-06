using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // the static instance that holds the sole object of this Singleton
    public static AudioManager audioInstance;

    public AudioSource twinkleSource;
    public AudioClip twinkleClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // check to see if someone has set the instance
        if (audioInstance == null)
        {
            // if they haven't, this is the instance
            audioInstance = this;

            // check if we are in a scene where AudioManager should NOT persist
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "MainMenu" || currentScene == "Queue Example")
            {
                Destroy(gameObject); // destroy AudioManager if in an excluded scene
                return;
            }

            // and keep it around in other scenes
            DontDestroyOnLoad(this);

            // listen for scene changes in case we load into MainMenu or Queue Example later
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else // otherwise, if there is an existing instance
        {
            // destroy the new instance that was just created
            Destroy(gameObject);
        }
    }

    // if a new scene is loaded, check if AudioManager should be destroyed
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu" || scene.name == "Queue Example")
        {
            Destroy(gameObject);
        }
    }

    //  plays the twinkle sound when the boat hits a lily
    public static void PlayTwinkle()
    {
        audioInstance.twinkleSource.PlayOneShot(audioInstance.twinkleClip);
    }
}

