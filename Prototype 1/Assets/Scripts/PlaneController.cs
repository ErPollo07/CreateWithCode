using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("Plane settings")]
    public float forwardSpeed;
    public float turningSpeed;

    [Header("Plane settings")]
    public GameObject propellor;
    public float propellorSpeed;

    void Start() { }

    void Update()
    {
        MovePlane();
        MovePropellor();
    }

    public void MovePlane()
    {
        float turnInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * turningSpeed * -turnInput * Time.deltaTime);
    }

    public void MovePropellor()
    {
        propellor.transform.Rotate(Vector3.forward * propellorSpeed * Time.deltaTime);
    }
}
