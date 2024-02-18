using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOutlineController : MonoBehaviour {

    [Header("Raycast Settings"), SerializeField]
    private float raycastDistance = 100f;
    [SerializeField]
    private LayerMask raycastLayers = ~0;

    // -----------------------------------------------------

    [Header("Runtime Data"), SerializeField]
    private OutlineableObject _targetOutline;
    public OutlineableObject TargetOutline {
        get {
            return _targetOutline;
        }
        private set {
            if(value != _targetOutline) {
                if(_targetOutline) {
                    _targetOutline.SetOutlineActive(false);
                }
                _targetOutline = value;
                if(_targetOutline) {
                    _targetOutline.SetOutlineActive(true);
                }
            }
        }
    }

    private Ray RayFromCamera => Camera.main.ScreenPointToRay(Input.mousePosition);

    // -----------------------------------------------------

    private void LateUpdate() {
        if(Physics.Raycast(RayFromCamera, out RaycastHit hit, raycastDistance, raycastLayers)) {
            TargetOutline = hit.collider.GetComponentInParent<OutlineableObject>();
        } else {
            TargetOutline = null;
        }
    }

}
