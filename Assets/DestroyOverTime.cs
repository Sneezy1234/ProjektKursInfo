using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public bool callOnStart;
        void Start()
    {
        if(callOnStart == true)
        {
              DestroyIn(15);
        }
    }

    public void DestroyIn(float timetodestroy ){
        StartCoroutine(CountDown(timetodestroy));

    }

    IEnumerator CountDown(float value )
    {
        float normalizedTime = 0;
        while (normalizedTime <= 1){
            normalizedTime += Time.deltaTime / value;
            yield return null;
        }
        Destroy(gameObject);
    }
}

