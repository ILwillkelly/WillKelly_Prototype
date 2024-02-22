using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DirectScript : MonoBehaviour
{
    public GameObject currentStep;
    public GameObject nextStep;
    public GameObject objectToDisappear;
    public TextMeshPro textMesh;
    public float delayBeforeDisappear = 5f; // Set the delay time in seconds

    void Start()
    {
        // Ensure the initial setup is correct
        if (currentStep != null)
        {
            currentStep.SetActive(true);
        }

        if (nextStep != null)
        {
            nextStep.SetActive(false);
        }

        if (textMesh != null)
        {
            textMesh.gameObject.SetActive(false);
        }
    }

    // Call this method to transition to the next step
    public void TransitionToNextStep(int someParameter)
    {
        if (currentStep != null)
        {
            currentStep.SetActive(false);
        }

        if (nextStep != null)
        {
            nextStep.SetActive(true);
        }

        if (textMesh != null)
        {
            textMesh.gameObject.SetActive(true);
            Invoke("DisappearObject", delayBeforeDisappear);
        }

        // Optionally, you can perform additional logic or actions after the transition
    }

    // Method to make the object disappear
    private void DisappearObject(int someParameter)
    {
        if (objectToDisappear != null)
        {
            objectToDisappear.SetActive(false);
            Debug.Log("Object disappeared");
        }
    }
}