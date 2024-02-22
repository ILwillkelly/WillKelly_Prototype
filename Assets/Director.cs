using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Director : MonoBehaviour
{
    public GameObject currentStep;
    public GameObject nextStep;
    public GameObject objectToDisappear;
    public GameObject objectToAppear; // New object to appear
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

        if (objectToAppear != null)
        {
            objectToAppear.SetActive(false);
        }

        if (textMesh != null)
        {
            textMesh.gameObject.SetActive(false);
        }
    }

    // Call this method to transition to the next step
    public void TransitionToNextStep()
    {
        Debug.Log("I already entered the");
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
            StartCoroutine(DisappearObject());
        }
    }

    // Call this method to make an object appear
    public void AppearObject()
    {
        if (objectToAppear != null)
        {
            objectToAppear.SetActive(true);
        }
    }
    public void DisappearObjectHelper()
{
    StartCoroutine(DisappearObject());
}

    // Method to make the object disappear
    IEnumerator DisappearObject()
    {
        yield return new WaitForSeconds(delayBeforeDisappear);

        if (objectToDisappear != null)
        {
            objectToDisappear.SetActive(false);
            Debug.Log("Object disappeared");
        }

        // Call AppearObject method after the delay to make the new object appear
        AppearObject();
    }
}