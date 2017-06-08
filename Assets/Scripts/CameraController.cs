using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private float xOffset;

    private void Start()
    {
        if (player != null)
        {
            xOffset = transform.position.x - player.transform.position.x;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x + xOffset,
                                        transform.position.y, transform.position.z);
        }
    }
}
