using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Transform particles;
    private ParticleSystem particlesSystem;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        particlesSystem = particles.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Recollectable"))
        {
            other.gameObject.SetActive(false);
        }
        else
        {

        }
    }
}
