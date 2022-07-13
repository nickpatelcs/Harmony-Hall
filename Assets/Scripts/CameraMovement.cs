using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 3f;
    // vertical rotation speed
    public float verticalSpeed = 10f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;
    
 
    void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;
    }
 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;
 
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
 
        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        gameObject.transform.eulerAngles = new Vector3(0.0f, yRotation, 0.0f);
        
    }
}
