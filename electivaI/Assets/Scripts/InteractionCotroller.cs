using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCotroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Debug.Log("se ha detectado un toque!");
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit impactedObject;
            if(Physics.Raycast(ray,out impactedObject))
            {
                Debug.Log("objeto impactado"+impactedObject.transform.name);
                if(impactedObject.transform.gameObject.CompareTag("Impactable"))
                impactedObject.transform.gameObject.SetActive(false);
            }
        }
    }
}
