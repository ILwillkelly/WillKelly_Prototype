using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeInteraction : MonoBehaviour
{
    public GameObject redCube1;
    public GameObject redCube2;
    public GameObject blackCube1;
    public GameObject blackCube2;
    public GameObject greyCube1;
    public GameObject greyCube2;
    public GameObject greyCube3;
    public TextMeshPro textMeshRedBlack;
    public TextMeshPro textMeshRed;
    public TextMeshPro textMeshBlack;
    public TextMeshPro textMeshGrey;
    public AudioSource audioSource;
    public Director director;
    public TextMeshPro textFinish;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        //audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        CheckInteractionRedBlack();
        CheckInteractionRed();
        CheckInteractionBlack();
        CheckInteractionGrey();
    }

    void CheckInteractionRedBlack()
    {
        bool redCubesAreTouching = CubesAreTouching(redCube1, redCube2);
        bool blackCubesAreTouching = CubesAreTouching(blackCube1, blackCube2);

        if (redCubesAreTouching && blackCubesAreTouching)
        {
            DisplayText(textMeshRedBlack);
            PlayAudio();

        }
        else
        {
            HideText(textMeshRedBlack);
        }
    }

    void CheckInteractionRed()
    {
        bool isRedCube1Touching = CubesAreTouching(redCube1, blackCube1) || CubesAreTouching(redCube1, blackCube2) || CubesAreTouching(redCube1, greyCube1) || CubesAreTouching(redCube1, greyCube2) || CubesAreTouching(redCube1, greyCube3);
        bool isRedCube2Touching = CubesAreTouching(redCube2, blackCube1) || CubesAreTouching(redCube2, blackCube2) || CubesAreTouching(redCube2, greyCube1) || CubesAreTouching(redCube2, greyCube2) || CubesAreTouching(redCube2, greyCube3);

        if (isRedCube1Touching || isRedCube2Touching)
        {
            DisplayText(textMeshRed);
            PlayAudio();
        }
        else
        {
            HideText(textMeshRed);
        }
    }

    void CheckInteractionBlack()
    {
        bool isBlackCube1Touching = CubesAreTouching(blackCube1, redCube1) || CubesAreTouching(blackCube1, redCube2) || CubesAreTouching(blackCube1, greyCube1) || CubesAreTouching(blackCube1, greyCube2) || CubesAreTouching(blackCube1, greyCube3);
        bool isBlackCube2Touching = CubesAreTouching(blackCube2, redCube1) || CubesAreTouching(blackCube2, redCube2) || CubesAreTouching(blackCube2, greyCube1) || CubesAreTouching(blackCube2, greyCube2) || CubesAreTouching(blackCube2, greyCube3);

        if (isBlackCube1Touching || isBlackCube2Touching)
        {
            DisplayText(textMeshBlack);
            PlayAudio();
        }
        else
        {
            HideText(textMeshBlack);
        }
    }

void CheckInteractionGrey()
{
    bool isGreyCubeTouchingRed = (CubesAreTouching(greyCube1, redCube1) || CubesAreTouching(greyCube1, redCube2) || CubesAreTouching(greyCube2, redCube1) || CubesAreTouching(greyCube2, redCube2)) && !CubesAreTouching(greyCube1, greyCube3) && !CubesAreTouching(greyCube2, greyCube3) && !CubesAreTouching(greyCube1, blackCube1) && !CubesAreTouching(greyCube1, blackCube2) && !CubesAreTouching(greyCube2, blackCube1) && !CubesAreTouching(greyCube2, blackCube2);
    
    bool isGreyCubeTouchingBlack = (CubesAreTouching(greyCube3, blackCube1) || CubesAreTouching(greyCube3, blackCube2)) && !CubesAreTouching(greyCube1, greyCube3) && !CubesAreTouching(greyCube2, greyCube3) && !CubesAreTouching(greyCube3, redCube1) && !CubesAreTouching(greyCube3, redCube2);

    if (isGreyCubeTouchingRed || isGreyCubeTouchingBlack)
    {
        DisplayText(textMeshGrey);
        PlayAudio();
    }
    else
    {
        HideText(textMeshGrey);
    }
}

    bool CubesAreTouching(GameObject cube1, GameObject cube2)
    {
        Collider collider1 = cube1.GetComponent<Collider>();
        Collider collider2 = cube2.GetComponent<Collider>();

        if (collider1 != null && collider2 != null)
        {
            return collider1.bounds.Intersects(collider2.bounds);
        }

        return false;
    }

void DisplayText(TextMeshPro textMesh)
{
    if (!textMesh.gameObject.activeSelf)
    {
        if (!IsGreyCubeTouched())
        {
            Debug.Log("You did it right!");
            textMesh.gameObject.SetActive(true);
            director.DisappearObjectHelper(); // You can decide whether to keep this line or remove it based on your needs
        }
        else
        {
            Debug.Log("Grey cube touched!");
            textMesh.gameObject.SetActive(true);
            // Do not call the disappear effect for grey cubes
        }
    }
}
    bool IsGreyCubeTouched()
{
    return CubesAreTouching(greyCube1, redCube1) || CubesAreTouching(greyCube1, redCube2) ||
           CubesAreTouching(greyCube2, redCube1) || CubesAreTouching(greyCube2, redCube2) ||
           CubesAreTouching(greyCube3, blackCube1) || CubesAreTouching(greyCube3, blackCube2);
}

    void HideText(TextMeshPro textMesh)
    {
        textMesh.gameObject.SetActive(false);
    }

    void PlayAudio()
    {
        // Check if the AudioSource is assigned and the audio clip is set
        if (audioSource != null && audioSource.clip != null)
        {
            // Play the audio clip
            if(audioSource){
                audioSource.Play();
                Debug.Log("Audio played.");
            }
            else
            {
                Debug.LogError("We are missing an audiosource");
            }
 
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is not set.");
        }
    }
}