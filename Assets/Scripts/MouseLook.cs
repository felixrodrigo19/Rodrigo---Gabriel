using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;
    public Texture2D cursorTexture;
    Vector2 hotSpot = Vector2.zero;

    float horizontalRotation = 0f;
    public Camera player;
    CursorMode cursorMode = CursorMode.Auto;
    public bool cursorLook;

    void Start()
    {

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);


    }

    void FixedUpdate()
    {
        var mouse = Input.mousePresent;

        if (!mouse) Debug.LogWarning("Mouse não conectado");
    }
    void Update()
    {
        if (!cursorLook) { Cursor.lockState = CursorLockMode.Locked; }
        else { Cursor.lockState = CursorLockMode.Confined; }

        float mouseHorizontal = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseVertical = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        horizontalRotation -= mouseVertical;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -90f, 90f);

        player.transform.localRotation = Quaternion.Euler(horizontalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseHorizontal);
    }
}
