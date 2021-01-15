using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 15.0f;
    [SerializeField]
    private float mouseSensitivity = 3.0f;

    private PlayerMotor playerMotor;

    // Start is called before the first frame update
    void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate movement velocity
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = xMov * transform.right;
        Vector3 movVertical = zMov * transform.forward;
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;
        playerMotor.Move(velocity);

        // Calculate Rotation - player
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0.0f, yRot, 0.0f) * mouseSensitivity;
        playerMotor.Rotate(rotation);

        // Calculate Rotation - camera
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRot, 0.0f, 0.0f);
        playerMotor.RotateCamera(cameraRotation);
    }
}
