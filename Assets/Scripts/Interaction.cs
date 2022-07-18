using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audiosource;

    //play sound when mouse clicks object
    public void playSound()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = sound;
        audiosource.Play();
        StartCoroutine(WaitForSound(sound));

        //wait for sound to finish playing and then reset
        IEnumerator WaitForSound(AudioClip sound)
        {
            yield return new WaitUntil(()=> audiosource.isPlaying == false);
        }
    }
}
