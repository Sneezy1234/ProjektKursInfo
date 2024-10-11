using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AnimationController : MonoBehaviour
{
    public Animator animator;  // Der Animator des Spielers
    public scr_PlayerMovement playMovement;
    public scr_DamageAndHealthSystem DmgHthSystem;

    public Rigidbody rb;

    private float speed;
    private float previusSpeed = 0;
    private float AnimationSpeed;

    void Update()
    {
        speed = Mathf.Round(rb.velocity.magnitude * 1f) / 1f;
        
        if(speed != previusSpeed)
        {
            animator.SetFloat("Speed", speed);
            Debug.Log(speed + " " + previusSpeed);
        }

        previusSpeed = speed;

        if (Input.GetKeyDown(playMovement.crouchKey)) animator.SetBool("crouching", true);
        if (Input.GetKeyUp(playMovement.crouchKey)) animator.SetBool("crouching", false);

        float AnimationSpeed = Mathf.Clamp(speed, 0.1f, 1f);

        animator.SetFloat("AnimationSpeed", AnimationSpeed);

        float staminaInfluence = ((playMovement.maxStamina - playMovement.currentStamina) / 12) + 1.2f;
        animator.SetFloat("StaminaInfluence", Mathf.Clamp(staminaInfluence, 1f, 3.5f));

        if(DmgHthSystem.playerIsDead) animator.SetBool("isDead", true);
    }
}
