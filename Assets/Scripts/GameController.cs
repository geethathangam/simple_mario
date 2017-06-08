using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text lostText;
    public Text lifeText;
    public Text restartText;
    public int lifeCount;

    public GameObject life;
    public float lifeInterval;

    public int asteroidCount;
    public GameObject asteroid;
    public GameObject player;

    public float asteroidStartInterval;
    public float asteroidSpawnInterval;
    public float asteroidWaitInterval;

	// Use this for initialization
	void Start () {
        lostText.text = "";
        restartText.text = "";
        UpdateLife();
        StartCoroutine(SpawnWaves());
        StartCoroutine(GenerateLife());
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(asteroidStartInterval);
        while (true)
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                if (player == null)
                {
                    yield break;
                }
                Vector3 spawnPosition = new Vector3(Random.Range(player.transform.position.x, player.transform.position.x + 23.5f), 6.5f, 0f);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject asteroidObject = Instantiate(asteroid, spawnPosition, spawnRotation);
                Destroy(asteroidObject, 10);
                yield return new WaitForSeconds(asteroidSpawnInterval);
            }
            yield return new WaitForSeconds(asteroidWaitInterval);
        }
    }

    private IEnumerator GenerateLife()
    {
        yield return new WaitForSeconds(asteroidStartInterval);
        while (true)
        {
            if (player == null)
            {
                yield break;
            }
            Vector3 spawnPosition = new Vector3(Random.Range(player.transform.position.x + 20f, player.transform.position.x + 40f), life.transform.position.y, 0f);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject lifeObject = Instantiate(life, spawnPosition, spawnRotation);
            float timeToDestroy = Random.Range(5, 10);
            Destroy(lifeObject, timeToDestroy);
            yield return new WaitForSeconds(lifeInterval);
        }
    }

    public void IncrementLife()
    {
        lifeCount++;
        UpdateLife();
    }

    public void DecrementLife()
    {
        lifeCount--;
        UpdateLife();
        if (lifeCount <= 0)
        {
            GameOver();
        }
    }

    private void UpdateLife()
    {
        lifeText.text = " * " + lifeCount.ToString();
    }

    private void GameOver()
    {
        Destroy(player);
        lostText.text = "You Lost!";
        restartText.text = "Press 'R' to Restart";
    }
}
