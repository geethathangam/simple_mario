using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public float width = 23.18945f;
    public float height = 0f;
    public int obstacleCount;
    public GameObject obstacle;

    private Vector3 backPos;
    private float x;
    private float y;
    private ArrayList obstacleList;

    private void Start()
    {
        obstacleList = new ArrayList();
    }

    private void OnBecameInvisible()
    {
        backPos = gameObject.transform.position;
        x = backPos.x + width * 2;
        y = backPos.y + height * 2;
        gameObject.transform.position = new Vector3(x, y, 0f);

        GenerateObstacles();
    }

    public void GenerateObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            float randomXRange = Random.Range(gameObject.transform.position.x, gameObject.transform.position.x + width);
            Vector3 spawnPosition = new Vector3(randomXRange, obstacle.transform.position.y, obstacle.transform.position.z);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject obstacleInstance = Instantiate(obstacle, spawnPosition, spawnRotation);
            obstacleList.Add(obstacleInstance);
            Destroy(obstacleInstance, 10);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("obstacle list size: {0}" + obstacleList.Count);
        foreach(GameObject obstacle in obstacleList)
        {
            DestroyImmediate(obstacle);
        }
    }
}
