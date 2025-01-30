using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject cam;
    public float normalSpeed;
    public float fastSpeed;
    private float movmentSpeed;
    public float movmentTime;
    public Vector3 cameraPosOffset;
    public Quaternion cameraRotOffset;

    void Start()
    {
        cam.transform.position = cameraPosOffset;
        cam.transform.rotation = cameraRotOffset;
    }

    void Update()
    {
        // Lock the mouse and set the 
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            #region Fix
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + mouseX, transform.rotation.z);
            cam.transform.rotation = Quaternion.Euler(cam.transform.rotation.x + mouseY, transform.rotation.y, transform.rotation.z);
            #endregion
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Adjust camera rotation
        cam.transform.rotation = new Quaternion(
            transform.rotation.x + cameraRotOffset.x,
            transform.rotation.y + cameraRotOffset.y,
            transform.rotation.z + cameraRotOffset.z,
            1
        );

        Move();
    }

    void Move()
    {
        Vector3 newPosition = transform.position;

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

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movmentTime);
    }
}
