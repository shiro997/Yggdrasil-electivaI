using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AudioProject : MonoBehaviour, IVirtualButtonEventHandler
{

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    private GameObject repeat;
    AudioClip lastClip;

    void Start()
    {
        audioSource.PlayOneShot(RandomClip());
        repeat = GameObject.Find("repetir");
        repeat.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    AudioClip RandomClip()
    {
        int attempts = 3;
        AudioClip newClip = audioClipArray[Random.Range(0, audioClipArray.Length - 1)];

        while (newClip == lastClip && attempts > 0)
        {
            newClip = audioClipArray[Random.Range(0, audioClipArray.Length - 1)];
            attempts--;
        }

        lastClip = newClip;
        return newClip;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        audioSource.PlayOneShot(lastClip);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("liberado prro!!!!!");
    }
}