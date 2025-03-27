using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMechanics : MonoBehaviour, IInteractable
{
    private Animator tuerAnim;
    private bool tueroffen = false;

    public bool isLocked = true;
    public bool showOutline = true;


    [Header("Audio")]
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip doorLocked;

    public scr_PlayerMovement playerScript;
    
    private void Start()
    {
        tuerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!showOutline && GetComponent<cakeslice.Outline>() != null)
        {
            GetComponent<cakeslice.Outline>().eraseRenderer = true;
        }
        else if (showOutline && GetComponent<cakeslice.Outline>() != null)
        {
            GetComponent<cakeslice.Outline>().eraseRenderer = false;
        }
    }

    public void Interact()
    {
        if (!isLocked)
        {
            if (!tueroffen && tuerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !tuerAnim.IsInTransition(0))
            {

                tuerAnim.Play("tueranimation", 0, 0.0f);
                tueroffen = true;
                AudioSource.PlayClipAtPoint(doorOpen, transform.position);
            }
            else if (tueroffen && tuerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !tuerAnim.IsInTransition(0))
            {
                tuerAnim.Play("tuerSchliessenAnimation", 0, 0.0f);
                tueroffen = false;
                AudioSource.PlayClipAtPoint(doorClose, transform.position);
            }
        }
        else
        {
            Debug.Log("doorisLocked");
            AudioSource.PlayClipAtPoint(doorLocked, transform.position);
        }

    }
}
