using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform character;
    private float yRot;
    public float sensitivity = 100;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yRot -= mouseY;
        yRot = Mathf.Clamp(yRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRot, 0, 0);
        character.Rotate(Vector3.up * mouseX);
    }
}
