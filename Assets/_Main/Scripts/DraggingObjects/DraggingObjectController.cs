using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingObjectController : MonoBehaviour {

    private const string DragButton = "Drag Object";

    [Header("Raycast Settings"), SerializeField]
    private float raycastDistance = 100f;
    [SerializeField]
    private LayerMask raycastLayers = ~0;

    [Header("Runtime Data"), SerializeField]
    private DraggableObject targetObject;
    private Transform targetTransform;
    [SerializeField]
    private Vector3 targetOffsetFromHit;

    // -----------------------------------------------------

    private Ray RayFromCamera => Camera.main.ScreenPointToRay(Input.mousePosition);

    // -----------------------------------------------------

    private void Update() {
        // Select object
        if(Input.GetButtonDown(DragButton)) {
            if(Physics.Raycast(RayFromCamera, out RaycastHit hit, raycastDistance, raycastLayers)) {
                targetObject = hit.collider.GetComponentInParent<DraggableObject>();
                if(targetObject) {
                    targetTransform = targetObject.transform;
                    targetOffsetFromHit = targetTransform.position - hit.point;
                    targetObject.OnDragStart();
                }
            }
        } else if(Input.GetButtonUp(DragButton)) {
            if(targetObject) {
                targetObject.OnDragEnd();
                targetObject = null;
            }
        }

        // Move object
        else if(Input.GetButton(DragButton) && targetObject) {
            // Movement only occurs in the XZ plane, because incorporating a 3rd axis when you can view from any angle is a logistical nightmare (movement arrows exist for a reason)
            // Math is derived using known start pos (camera), direction, and const y pos (XZ plane) to calculate distance n and subsequently the desired x and z positions
            //      Also we need to consider the offset from the object's position to where the mouse raycast initially hit
            Vector3 direction = RayFromCamera.direction;
            Vector3 cameraPosition = Camera.main.transform.position;
            float n = (targetTransform.position.y - targetOffsetFromHit.y - cameraPosition.y) / direction.y;
            float x = cameraPosition.x + (n * direction.x) + targetOffsetFromHit.x;
            float z = cameraPosition.z + (n * direction.z) + targetOffsetFromHit.z;
            targetTransform.position = new Vector3(x, targetTransform.position.y, z);

        }
    }
}
