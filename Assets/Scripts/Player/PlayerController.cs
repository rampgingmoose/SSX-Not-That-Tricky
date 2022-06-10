using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    SurfaceEffector2D surfaceEffector;

    [SerializeField] float torqueAmount = 1.0f;
    [SerializeField] float defaultSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;

    private bool canMove = true;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            HandleFlipInput();
            SpeedBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void HandleFlipInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddTorque(-torqueAmount);
        }
    }
    private void SpeedBoost()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            surfaceEffector.speed = boostSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            surfaceEffector.speed = defaultSpeed;
        }
    }
}
