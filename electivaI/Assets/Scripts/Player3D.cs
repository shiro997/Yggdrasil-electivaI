using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 position;
    private float count = 0;
    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
      rb= GetComponent<Rigidbody>();
      Debug.Log("Score: " + score);
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
      //position = other.gameObject.transform.position;
      if(other.gameObject.CompareTag("Recollectable"))
      {
        other.gameObject.SetActive(false);
        count++;
        score = score + 25;
        Debug.Log("Score: " + score);
      }
    }
}
