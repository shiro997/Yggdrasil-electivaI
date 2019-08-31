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
        particlesSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            position = other.gameObject.transform.position;
            particles.position = position;
            particlesSystem = particles.GetComponent<ParticleSystem>();
            particlesSystem.Play();
            other.gameObject.SetActive(false);
        }
        else
        {

        }
    }
}
