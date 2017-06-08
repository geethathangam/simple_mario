using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithBorderColliders : MonoBehaviour {
    public GameObject anotherBackground;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        GameObject parentBackground = transform.parent.gameObject;
        if (tag.Equals("LeftCollider") && parentBackground.transform.position.x < anotherBackground.transform.position.x)
        {
            Renderer renderer = parentBackground.GetComponent<Renderer>();
            float xOffset = renderer.bounds.size.x;
            anotherBackground.transform.position = new Vector3(parentBackground.transform.position.x - xOffset, parentBackground.transform.position.y, parentBackground.transform.position.z);
        }
        else if (tag.Equals("RightCollider") && transform.position.x > anotherBackground.transform.position.x)
        {
            Renderer renderer = parentBackground.GetComponent<Renderer>();
            float xOffset = renderer.bounds.size.x;
            anotherBackground.transform.position = new Vector3(parentBackground.transform.position.x + xOffset, parentBackground.transform.position.y, parentBackground.transform.position.z);
        }
    }
}
