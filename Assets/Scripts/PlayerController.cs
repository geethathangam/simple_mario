using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Animator anim;
    private bool onGround;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            if (onGround)
            {
                SetWalkingAnimate(true);
                SetJumpingAnimate(false);
            } else
            {
                SetWalkingAnimate(false);
                SetJumpingAnimate(true);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            if (onGround)
            {
                SetWalkingAnimate(true);
                SetJumpingAnimate(false);
            }
            else
            {
                SetWalkingAnimate(false);
                SetJumpingAnimate(true);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            onGround = false;
            transform.position += Vector3.up * 2 * speed * Time.deltaTime;
            SetWalkingAnimate(false);
            SetJumpingAnimate(true);
        }
        if (!Input.GetKey(KeyCode.LeftArrow) &&
            !Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.UpArrow))
        {
            SetJumpingAnimate(false);
            SetWalkingAnimate(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            onGround = true;
        }
    }

    private void SetWalkingAnimate(bool isWalking)
    {
        anim.SetBool("IsWalking", isWalking);
    }

    private void SetJumpingAnimate(bool isJumping)
    {
        anim.SetBool("IsJumping", isJumping);
    }
}
