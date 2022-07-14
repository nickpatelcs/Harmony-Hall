using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject art;
    public AudioClip sound;
    private AudioSource audiosource;

    //play sound when mouse clicks object
    public void OnMouseDown()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = sound;
        audiosource.Play();
        StartCoroutine(WaitForSound(sound));

        IEnumerator WaitForSound(AudioClip sound)
        {
            yield return new WaitUntil(()=> audiosource.isPlaying == false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
