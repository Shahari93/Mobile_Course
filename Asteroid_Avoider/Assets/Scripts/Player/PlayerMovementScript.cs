using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float maxForceToAdd;
    [SerializeField] private float force;

    private Vector3 movement;

    private Rigidbody playerRB;
    private Camera mainCamera;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        ProcessInput();
        KeepPlayerInsideScreen();
    }

    private void FixedUpdate()
    {
        if (movement == Vector3.zero)
        {
            return;
        }

        playerRB.AddForce(movement * force, ForceMode.Force);

        // Clamping the magnitude so we don't fly faster when we hold down the finger
        playerRB.velocity = Vector3.ClampMagnitude(playerRB.velocity, maxForceToAdd);

        //Vector3 clampedMagnitude = Vector3.ClampMagnitude(movement, maxForceToAdd);
        //playerRB.velocity = clampedMagnitude;
    }

    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {

            Vector2 screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 touchPos = mainCamera.ScreenToWorldPoint(screenPos);

            //movement = transform.position - touchPos;
            movement = transform.position - touchPos;
            movement.z = 0;

            // Magnitute will always be one unit
            movement.Normalize();
        }

        else
        {
            movement = Vector3.zero;
        }
    }

    private void KeepPlayerInsideScreen()
    {
        throw new NotImplementedException();
    }
}