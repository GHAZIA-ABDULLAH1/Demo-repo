using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target; // The game object to orbit around
    public float rotationSpeed = 2.0f; // Rotation speed in degrees per second

    private Vector3 offset; // The offset between the camera and the target

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned to CameraOrbit script.");
            enabled = false; // Disable the script if the target is not assigned
            return;
        }

        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
    }

    void Update()
    {
        // Calculate the desired rotation angle based on time and rotation speed
        float angle = Time.time * rotationSpeed;

        // Calculate the new position of the camera based on the rotation angle
        Vector3 newPosition = target.position + Quaternion.Euler(0, angle, 0) * offset;

        // Update the camera's position
        transform.position = newPosition;

        // Make the camera always look at the target
        transform.LookAt(target);
    }
}
