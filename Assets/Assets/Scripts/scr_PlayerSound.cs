using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerSound : MonoBehaviour
{
    // Public
    public AudioClip[] stepSoundsWood;
    public AudioClip[] stepSoundsConcrete;
    public AudioClip[] stepSoundsOutside;
    public scr_PlayerMovement scr_PlayerMovement;
    
    // Private
    private AudioSource stepSource;
    private RaycastHit hit;

    void Start()
    {
        stepSource = GetComponent<AudioSource>();
    }

    public void PlayFootstep()
    {
        // Add checker that check if the tag of the ground is "inside" or "outside" and play the corresponding sound
        Physics.Raycast(transform.position - Vector3.down * (scr_PlayerMovement.playerHeight/2 - 0.3f), Vector3.down, out hit, scr_PlayerMovement.playerHeight / 2 - 0.03f);
        
        if(hit.collider.tag == "inside")
        {
            PlayFootstepHelp(stepSoundsWood);
        }
        else if(hit.collider.tag == "outside")
        {
            PlayFootstepHelp(stepSoundsOutside);
        }
        else if (hit.collider.tag == "concrete")
        {
            PlayFootstepHelp(stepSoundsConcrete);
        }
    }

    private void PlayFootstepHelp(AudioClip[] stepSounds)
    {
        AudioClip stepClip = stepSounds[UnityEngine.Random.Range(0, stepSounds.Length)];
        stepSource.clip = stepClip;
        stepSource.volume = UnityEngine.Random.Range(0.4f, 0.45f);
        stepSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        stepSource.Play();
        Debug.Log(stepClip.name);
    }
}
