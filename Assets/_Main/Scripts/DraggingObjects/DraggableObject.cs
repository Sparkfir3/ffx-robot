using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DraggableObject : MonoBehaviour {

    public UnityEvent OnDragStartEvent;
    public UnityEvent OnDragEndEvent;
    
    public virtual void OnDragStart() {
        OnDragStartEvent?.Invoke();
    }

    public virtual void OnDragEnd() {
        OnDragEndEvent?.Invoke();
    }

}
