using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypaddoorMechanics : MonoBehaviour, IInteractable
{
    private Animator tuerAnim;
    private bool tueroffen = false;

    public bool isLocked = true;


    [Header("Audio")]
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip doorLocked;
    
    private void Start(){
        tuerAnim = transform.parent.GetComponent<Animator>();

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
                Debug.Log("Now locking door");
                isLocked = true;
                Debug.Log("Door locked");
                
            }
        }
        else
        {
            Debug.Log("doorisLocked");
            AudioSource.PlayClipAtPoint(doorLocked, transform.position);
        }

    }
}
