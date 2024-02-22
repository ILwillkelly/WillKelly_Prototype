using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YourScript : MonoBehaviour
{
    public bool trigger1Entered = false;
    public bool trigger2Entered = false;

    public TextMeshPro displayText; // Reference to the TextMeshPro Text component

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger1"))
        {
            trigger1Entered = true;
        }
        else if (other.CompareTag("Trigger2"))
        {
            trigger2Entered = true;
        }

        CheckIfBothTriggersEntered();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trigger1"))
        {
            trigger1Entered = false;
        }
        else if (other.CompareTag("Trigger2"))
        {
            trigger2Entered = false;
        }
    }

    private void CheckIfBothTriggersEntered()
    {
        if (trigger1Entered && trigger2Entered)
        {
            // Both triggers are entered, perform your action here
            Debug.Log("Both triggers entered!");

            if (displayText != null)
            {
                displayText.gameObject.SetActive(true);
            }
        }
    }
}