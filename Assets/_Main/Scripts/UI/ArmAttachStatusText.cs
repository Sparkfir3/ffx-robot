using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ArmAttachStatusText : MonoBehaviour
{
    [SerializeField]
    private string textAttached = "Attached";
    [SerializeField]
    private string textDetached = "Detached";
    [SerializeField]
    private TextMeshProUGUI textbox;
    [SerializeField]
    private RobotStatus robotStatus;

    public string CurrentText => textbox ? textbox.text : "";

    // -----------------------------------------------------

    private void Start() {
        Initialize();
    }

    private void OnDestroy() {
        if(robotStatus) {
            robotStatus.OnUpdateRobotStatus -= UpdateText;
        }
    }

    private void OnValidate() {
        if(!textbox) {
            textbox = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    // -----------------------------------------------------

    public void Initialize() {
        OnValidate();
        if(!robotStatus) {
            Debug.LogWarning($"ArmAttachStatusText {gameObject.name} did not have an assigned RobotStatus, having to use FindObjectOfType instead...");
            AssignRobot(FindObjectOfType<RobotStatus>());
        }
        if(robotStatus) {
            robotStatus.OnUpdateRobotStatus += UpdateText;
        }
    }

    public void AssignRobot(RobotStatus robotStatus) {
        this.robotStatus = robotStatus;
    }

    private void UpdateText(bool attached) {
        if(textbox) {
            textbox.text = attached ? textAttached : textDetached;
        }
    }

}
