using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AnimationController : MonoBehaviour
{
    public Animator animator;  // Der Animator des Spielers
    public scr_PlayerMovement playMovement;


    private float speed;
    private float previusSpeed = 0; 
    private float AnimationSpeed;

    void Update()
    {
        speed = Mathf.Round(playMovement.rb.velocity.magnitude * 100f) / 100f;
        if(speed != previusSpeed)
        {
            animator.SetFloat("Speed", speed);
        }

        previusSpeed = speed;

        if (Input.GetKeyDown(Keybinds.crouchKey)) animator.SetBool("crouching", true);
        if (Input.GetKeyUp(Keybinds.crouchKey)) animator.SetBool("crouching", false);

        AnimationSpeed = Mathf.Clamp(Mathf.Pow(speed, 0.5f) * 1f, 0.1f, 1f);

        animator.SetFloat("AnimationSpeed", AnimationSpeed);

        float staminaInfluence = ((playMovement.maxStamina - playMovement.currentStamina) / 12) + 1.2f;
        animator.SetFloat("StaminaInfluence", Mathf.Clamp(staminaInfluence, 1f, 3.5f));




        // Handle direction
        animator.SetFloat("direction", Mathf.Rad2Deg * Mathf.Atan2(playMovement.localMoveDirection.z, playMovement.localMoveDirection.x) + 91f);
                
       /*  if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0)  && animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|Getting Up"))
        {
            playMovement.SetMovementState(scr_PlayerMovement.MovementState.freeze);
        } */
    }
}