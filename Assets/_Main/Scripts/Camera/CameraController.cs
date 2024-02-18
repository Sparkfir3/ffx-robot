using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float rotateSpeed = 120;

    // -----------------------------------------------------

    private void Update() {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical")).normalized * moveSpeed * Time.deltaTime;
        Vector3 rotateVector = Input.GetButton("Turn Camera") ? new Vector3(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X")).normalized * rotateSpeed * Time.deltaTime
            : Vector3.zero;
        transform.SetPositionAndRotation(transform.position + transform.TransformVector(moveVector), Quaternion.Euler(transform.eulerAngles + rotateVector));
    }
}
