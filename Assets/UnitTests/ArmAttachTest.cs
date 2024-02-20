using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class ArmAttachTest {

    private const string AttachedString = "Attached";
    private const string DetachedString = "Detached";

    [Test]
    public void TestStatusText_BothArmAttach() {
        InitializeTestVariables(out RobotStatus robotStatus, out ArmAttachStatusText statusText);
        
        robotStatus.SetLeftArmAttached(true);
        robotStatus.SetRightArmAttached(true);
        Assert.AreEqual(AttachedString, statusText.CurrentText);
    }

    [Test]
    public void TestStatusText_BothArmDetach() {
        InitializeTestVariables(out RobotStatus robotStatus, out ArmAttachStatusText statusText);

        robotStatus.SetLeftArmAttached(false);
        robotStatus.SetRightArmAttached(false);
        Assert.AreEqual(DetachedString, statusText.CurrentText);
    }

    [Test]
    public void TestStatusText_LeftArmDetach() {
        InitializeTestVariables(out RobotStatus robotStatus, out ArmAttachStatusText statusText);

        robotStatus.SetLeftArmAttached(false);
        robotStatus.SetRightArmAttached(true);
        Assert.AreEqual(DetachedString, statusText.CurrentText);
    }

    [Test]
    public void TestStatusText_RightArmDetach() {
        InitializeTestVariables(out RobotStatus robotStatus, out ArmAttachStatusText statusText);

        robotStatus.SetLeftArmAttached(true);
        robotStatus.SetRightArmAttached(false);
        Assert.AreEqual(DetachedString, statusText.CurrentText);
    }

    // --------------------------------------------------------------------

    private void InitializeTestVariables(out RobotStatus robotStatus, out ArmAttachStatusText statusText) {
        robotStatus = Object.FindObjectOfType<RobotStatus>();
        statusText = Object.FindObjectOfType<ArmAttachStatusText>();
        Assert.IsNotNull(robotStatus, "RobotStatus component does not exist in scene.");
        Assert.IsNotNull(statusText, "ArmAttachStatusText component does not exist in scene.");
        // technically you should idiot-proof the test by making sure exactly 1 instance exists instead of just any existing, but we're okay for now

        statusText.Initialize();

        // Alternative initialization for testing a fresh scene instead of existing scene
        //robotStatus = new GameObject().AddComponent<RobotStatus>();
        //statusText = new GameObject().AddComponent<ArmAttachStatusText>();
        //TextMeshProUGUI textbox = new GameObject().AddComponent<TextMeshProUGUI>();

        //textbox.transform.SetParent(statusText.transform, false);
        //statusText.AssignRobot(robotStatus);
        //statusText.Initialize();
    }
}
