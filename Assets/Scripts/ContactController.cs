using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactController : MonoBehaviour {
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find GameController component");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("Asteroid"))
        {
            AudioSource audio = collision.gameObject.GetComponent<AudioSource>();
            audio.Play();
            BlinkPlayer();
            gameController.DecrementLife();
        }
        else if (collision.gameObject.CompareTag("Life"))
        {
            Destroy(collision.gameObject);
            gameController.IncrementLife();
        }
    }

    private void BlinkPlayer()
    {
        StartCoroutine(DoBlinks(5, 0.1f));
    }

    private IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        Renderer renderer = GetComponent<Renderer>();
        for (int i = 0; i < numBlinks * 2; i++)
        {
            //toggle renderer
            renderer.enabled = !renderer.enabled;

            //wait for a bit
            yield return new WaitForSeconds(seconds);
        }

        //make sure renderer is enabled when we exit
        renderer.enabled = true;
    }
}
