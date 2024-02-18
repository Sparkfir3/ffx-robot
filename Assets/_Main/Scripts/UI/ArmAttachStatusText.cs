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
    private TextMeshProUGUI textBox;

    private bool leftArmAttached = true;
    private bool rightArmAttached = true;

    // -----------------------------------------------------

    public void SetLeftArmAttached(bool attached) {
        leftArmAttached = attached;
        UpdateText();
    }

    public void SetRightArmAttached(bool attached) {
        rightArmAttached = attached;
        UpdateText();
    }

    private void UpdateText() {
        textBox.text = leftArmAttached && rightArmAttached ? textAttached : textDetached;
    }

}
