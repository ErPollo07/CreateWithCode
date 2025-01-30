using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CameraController : MonoBehaviour
{
    public GameObject cam;

    private float movmentSpeed;
    public float normalSpeed;
    public float fastSpeed;
    
    public float movmentTime;
    public float rotationAmount;
    private Vector3 zoomAmount;

    private Vector3 newPosition;
    private Quaternion newRotation;
    private Vector3 newZoom;
    

    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cam.transform.localPosition;
    }

    void Update()
    {
        HandleMovment();
    }

    void HandleMovment()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movmentSpeed = fastSpeed;
        }
        else
        {
            movmentSpeed = normalSpeed;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += Vector3.forward * movmentSpeed;
        } 
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += Vector3.forward * -movmentSpeed;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += Vector3.right * -movmentSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += Vector3.right * movmentSpeed;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }

        transform.position = newPosition;
        transform.rotation = newRotation;
    }
}
