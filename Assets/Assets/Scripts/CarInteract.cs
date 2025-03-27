using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarInteract : MonoBehaviour, IInteractable
{
    private Animator doorAnim;
    private bool isCarDoorOpen = false;
    private bool isTrunkDoorOpen = false;


    [Header("Audio")]

    public AudioSource carDoorOpen;
    public AudioSource carDoorClose;

    public Image fadePanel;

    private void Start()
    {
        doorAnim = gameObject.GetComponent<Animator>();

    }

    public void Interact()
    {
        if (transform.name == "tuer_l")
        {

            Debug.Log("interact!");

            if (!isCarDoorOpen && doorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !doorAnim.IsInTransition(0))
            {

                doorAnim.Play("OpenCarDoor", 0, 0.0f);
                isCarDoorOpen = true;
                carDoorOpen.PlayDelayed(0f);
            }

            else if (isCarDoorOpen && doorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !doorAnim.IsInTransition(0))
            {
                doorAnim.Play("CloseCarDoor", 0, 0.0f);
                isCarDoorOpen = false;
                carDoorClose.PlayDelayed(0.85f);

            }
        }

        else if (transform.name == "kofferraum")
        {

            Debug.Log("interact!");

            if (!isTrunkDoorOpen && doorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !doorAnim.IsInTransition(0))
            {

                doorAnim.Play("OpenCarTrunk", 0, 0.0f);
                isTrunkDoorOpen = true;
                carDoorOpen.PlayDelayed(0f);

                // Fade
                SwitchScene();
            }

            else if (isTrunkDoorOpen && doorAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !doorAnim.IsInTransition(0))
            {
                doorAnim.Play("CloseCarTrunk", 0, 0.0f);
                isTrunkDoorOpen = false;
                carDoorClose.PlayDelayed(0.85f);
            }
        }
    }

    private void SwitchScene()
    {
        // Fade
        StartCoroutine(FadeToBlack(1.8f));
    }

    private IEnumerator FadeToBlack(float duration)
    {
        Color startColor = fadePanel.color;
        float time = 0f;
        
        // Ensure starting alpha is 0.
        startColor.a = 0f;
        fadePanel.color = startColor;
        
        // Lerp alpha to 1 over duration.
        while (time < duration)
        {
            time += Time.deltaTime;
            Color newColor = fadePanel.color;
            newColor.a = Mathf.Lerp(0f, 1f, time / duration);
            fadePanel.color = newColor;
            yield return null;
        }
        
        // Guarantee final alpha is 1.
        Color finalColor = fadePanel.color;
        finalColor.a = 1f;
        fadePanel.color = finalColor;

        UnityEngine.SceneManagement.SceneManager.LoadScene("House");

    }
}
