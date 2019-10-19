using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
      rb= GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Recollectable"))
      {
        other.gameObject.SetActive(false);
        other.attachedRigidbody.useGravity = true;
      }
    }
}