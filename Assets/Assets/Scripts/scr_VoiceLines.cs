using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    [Header("Random Settings")]
    public float delay = 2.0f;
    private bool isPlaying = false;
    private int index = 0;

    public Transform womanPosition;
    public Transform playerPosition;

    public AudioClip[] voiceLines;

    private List<bool> isPlayerSpeaking = new List<bool>() {false, true, false, false, true, false, true, false, true};

    public void Update()
    {
        if (!isPlaying && index < isPlayerSpeaking.Count)
        {
            StartCoroutine(playVoiceLine(delay, voiceLines, isPlayerSpeaking[index] ? playerPosition.position : womanPosition.position));
        }
        print(index);
    }

    public IEnumerator playVoiceLine(float delay, AudioClip[] voices, Vector3 position)
    {
        isPlaying = true;


        if (voices.Length > 0)
        {
            AudioSource.PlayClipAtPoint(voices[index], position);
        }

        yield return new WaitForSeconds(delay + voices[index].length);
        index++;

        isPlaying = false;
    }
}
