using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachableLimb : DraggableObject {
    
    [Header("Settings"), SerializeField]
    private float distanceToReattach = 0.25f;
    [SerializeField]
    private Outline rootParentOutline;

    [field: Header("Runtime Data"), SerializeField]
    public bool IsAttached { get; private set; } = true;
    [SerializeField]
    private Transform originalParent;
    private Transform attachPoint;

    // -----------------------------------------------------

    #region Unity Functions

    private void Awake() {
        OnValidate();
        attachPoint = Instantiate(new GameObject()).transform;
        attachPoint.parent = transform.parent;
        attachPoint.SetPositionAndRotation(transform.position, transform.rotation);
        attachPoint.gameObject.name = $"AttachPoint_{gameObject.name}";
    }

    private void OnValidate() {
        originalParent = transform.parent;
    }

    #endregion

    // -----------------------------------------------------

    #region Draggable Object

    public override void OnDragStart() {
        base.OnDragStart();
        if(IsAttached)
            Detach();
    }

    public override void OnDragEnd() {
        base.OnDragEnd();
        if(IsInReattachDistance())
            Reattach();
    }

    #endregion

    // -----------------------------------------------------

    #region Internal Functions

    private void Detach() {
        IsAttached = false;
        transform.parent = null;
        RefreshParentOutline();
    }

    private void Reattach() {
        IsAttached = true;
        transform.parent = originalParent;
        transform.SetPositionAndRotation(attachPoint.position, attachPoint.rotation);
        RefreshParentOutline();
    }

    private bool IsInReattachDistance() {
        return (attachPoint.position - transform.position).magnitude < distanceToReattach;
    }

    private void RefreshParentOutline() {
        if(rootParentOutline) {
            rootParentOutline.RecacheRenderers();
        }
    }

    #endregion

}
