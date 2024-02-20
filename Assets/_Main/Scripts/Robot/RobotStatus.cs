using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStatus : MonoBehaviour
{
    public Action<bool> OnUpdateRobotStatus;

    [field: SerializeField]
    public bool LeftArmAttached { get; private set; } = true;
    [field: SerializeField]
    public bool RightArmAttached { get; private set; } = true;

    // -----------------------------------------------------

    public void SetLeftArmAttached(bool attached) {
        LeftArmAttached = attached;
        UpdateStatus();
    }

    public void SetRightArmAttached(bool attached) {
        RightArmAttached = attached;
        UpdateStatus();
    }

    private void UpdateStatus() {
        OnUpdateRobotStatus?.Invoke(LeftArmAttached && RightArmAttached);
    }
}
