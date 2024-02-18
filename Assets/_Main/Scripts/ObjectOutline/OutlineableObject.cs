using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineableObject : MonoBehaviour {

    [SerializeField]
    private Outline outline;

    // -----------------------------------------------------

    private void Awake() {
        SetOutlineActive(false);
    }

    public void SetOutlineActive(bool active) {
        if(!outline) {
            return;
        }
        outline.enabled = active;
    }

}
