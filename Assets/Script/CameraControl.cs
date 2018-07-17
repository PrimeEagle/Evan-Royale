using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform GameCamera;
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;
    public GameObject player;
    public Transform lookAt;
    public Transform camTransform;
    public float distance = 10.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        player.transform.rotation = GameCamera.transform.rotation;
        if (currentY > 1)
        {
            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");
        }
        if(currentY < 1)
        {
            currentY += 20;
        }

        

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
