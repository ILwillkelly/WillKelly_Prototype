using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualCubeTouchDetector : MonoBehaviour
{
    public GameObject textToShow; // Reference to the text GameObject you want to display

    private bool blackCubeTouched = false;
    private bool redCubeTouched = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter: " + other.tag);
        if (other.CompareTag("BlackCube"))
        {
            blackCubeTouched = true;
        }
        else if (other.CompareTag("RedCube"))
        {
            redCubeTouched = true;
        }

        CheckTouch();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit: " + other.tag);
        if (other.CompareTag("BlackCube"))
        {
            blackCubeTouched = false;
        }
        else if (other.CompareTag("RedCube"))
        {
            redCubeTouched = false;
        }

        CheckTouch();
    }

    private void CheckTouch()
    {
        // Check if both cubes have been touched
        if (blackCubeTouched && redCubeTouched)
        {
            // Display the text or perform any other actions
            if (textToShow != null)
            {
                textToShow.SetActive(true);
            }
        }
        else
        {
            // Hide the text or reset any other actions
            if (textToShow != null)
            {
                textToShow.SetActive(false);
            }
        }
    }
}