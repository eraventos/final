using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QueueExample : MonoBehaviour
{
    private Queue<string> fishQueue = new Queue<string>();

    public Text timerText;
    public Text wordText;
    public Text finalMessageText;
   
    public AudioSource musicSource;
    
    

    private float timer = 0;
    private float timePerTurn = 5;

    private void Start()
    {
        // Start the music when the game begins
        musicSource.Play();
    }

    private void Update()
    {
        // If you press space, reload the scene.  This makes it easy to restart!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // If a move takes more than 5 seconds, continue.
        if (timer > timePerTurn) return;
        
        // Increase the timer.
        timer += Time.deltaTime;

        // If you press any letter, push that move into the queue.
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            fishQueue.Enqueue("sky");
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            fishQueue.Enqueue("remember");
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            fishQueue.Enqueue("soft");
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            fishQueue.Enqueue("again");
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            fishQueue.Enqueue("where?");
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            fishQueue.Enqueue("I was");
        }
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            fishQueue.Enqueue("listen");
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            fishQueue.Enqueue("then");
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            fishQueue.Enqueue("ashes");
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            fishQueue.Enqueue("rise");
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            fishQueue.Enqueue("beaneath");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            fishQueue.Enqueue("you are");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            fishQueue.Enqueue("drift");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            fishQueue.Enqueue("echoes");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            fishQueue.Enqueue("open");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            fishQueue.Enqueue("touch");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            fishQueue.Enqueue("gone");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            fishQueue.Enqueue("hold me");
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            fishQueue.Enqueue("still");
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            fishQueue.Enqueue("nothing");
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            fishQueue.Enqueue("maybe");
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            fishQueue.Enqueue("until");
        }
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            fishQueue.Enqueue("falling");
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            fishQueue.Enqueue("why not");
        }
        
        if (Input.GetKeyDown(KeyCode.N))
        {
            fishQueue.Enqueue("between");
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            fishQueue.Enqueue("who knew?");
        }
        

        // If the time is up, say that time is up and show the effects.
        if (timer >= timePerTurn)
        {
            //Stop music 

            if (musicSource.isPlaying)
            {
                musicSource.Stop();
            }
            // Hides the timer text
            timerText.text = ""; 
            finalMessageText.text = "Your Dance Poem:\n";
            ShowQueueEffects();
        }
        else
        {
            // Display the timer
            timerText.text = "Dance on the grass: " + (timePerTurn - timer).ToString("F2");
        }
    }

    private void ShowQueueEffects()
    {
        
        // While there are effects in the queue, dequeue them out and show them.
        while (fishQueue.Count > 0)
            wordText.text += " " + fishQueue.Dequeue();
    }
}
