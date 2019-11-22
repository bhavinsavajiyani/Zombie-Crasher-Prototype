using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 6.3f; // Distance of camera from player, which is from z-axis
    public float height = 3.5f;

    public float height_Damping = 3.25f;
    public float rotation_Damping = 0.27f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        // Rotation angle and height of target (Player)
        float wanted_Rotation_Angle = target.eulerAngles.y;
        float wanted_Height = target.position.y + height;

        // Rotation Angle and height of Camera
        float current_Rotation_Angle = transform.eulerAngles.y;
        float current_Height = transform.position.y;

        current_Rotation_Angle = Mathf.LerpAngle(current_Rotation_Angle, wanted_Rotation_Angle,
            rotation_Damping * Time.deltaTime);

        current_Height = Mathf.Lerp(current_Height, wanted_Height, height_Damping * Time.deltaTime);

        // Convert rotation angle to Quaternion (Rotation over Y axis only)
        Quaternion current_Rotation = Quaternion.Euler(0f, current_Rotation_Angle, 0f);

        // Set position of camera to target's (Player's) position.
        transform.position = target.position;

        // Set distance away from target position.
        transform.position -= current_Rotation * Vector3.forward * distance;

        // Set camera to be above player using "current_height" (changing Y-axis only)
        transform.position = new Vector3(transform.position.x, current_Height, transform.position.z);
    }
}
