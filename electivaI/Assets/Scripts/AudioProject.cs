using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AudioProject : MonoBehaviour, IVirtualButtonEventHandler, ITrackableEventHandler
{

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    private GameObject repeat;
    private TrackableBehaviour mTrackableBehaviour;
    AudioClip lastClip;

    void Start()
    {
        audioSource.PlayOneShot(RandomClip());
        repeat = GameObject.Find("repetir");
        repeat.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this
);
        }
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

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }


    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren  <Renderer> (true);
        Collider[] colliderComponents = GetComponentsInChildren <Collider>  (true);
        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }
        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }
        Debug.Log("Trackable " +mTrackableBehaviour.TrackableName+ " found");
        if (mTrackableBehaviour.TrackableName == "manzana")
            {
            Debug.Log("Hello");
        }
        if (mTrackableBehaviour.TrackableName =="unitychan ")
            {
            //playSound(" sounds / audiosample ");
        }

    }

    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
        
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }
        Debug.Log("Trackable" + mTrackableBehaviour.TrackableName + "lost");

    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        audioSource.PlayOneShot(lastClip);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("liberado!!!!!");
    }
}