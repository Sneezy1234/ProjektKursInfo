using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scr_LightswitchControl : MonoBehaviour, IInteractable
{
    public Light[] lights;
    public bool isOn = true;
    public AudioClip turnOnSound; 
    public AudioClip turnOffSound; 

    private Material lightSwitchMat;

    private void Start()
    {
        turnOnSound = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Assets/Sound/Environment/House/Lightswitch/Licht-an-Decke.mp3", typeof(AudioClip));
        turnOffSound = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Assets/Sound/Environment/House/Lightswitch/Licht-aus-Decke.mp3", typeof(AudioClip));
        
        lightSwitchMat = GetComponent<Renderer>().material;
        for (int lightIdx = 0; lightIdx < lights.Length; lightIdx++)
        {
            lights[lightIdx].enabled = true;
        }
    }
    public void Interact()
    {
        // Turn the light on or off
        for (int lightIdx = 0; lightIdx < lights.Length; lightIdx++)
        {
            lights[lightIdx].enabled = !lights[lightIdx].enabled;
        }
            isOn = !isOn;
            if (isOn)
            {
                lightSwitchMat.color = new Color(0f, 1f, 0f);
                AudioSource.PlayClipAtPoint(turnOnSound, transform.position);
            }
            else
            {
                lightSwitchMat.color = new Color(1f, 0f, 0f);
                AudioSource.PlayClipAtPoint(turnOffSound, transform.position);
            }
    }
}
