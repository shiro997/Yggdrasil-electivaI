using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Transform particles;
    private ParticleSystem particlesSystem;
    private Vector3 position;
    private int cubes = 12;
    private AudioSource recollectionAudio;
    private float count = 0;
    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        particlesSystem = particles.GetComponent<ParticleSystem>();
        particlesSystem.Stop();
        recollectionAudio = GetComponent<AudioSource>();
        Debug.Log("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        if(cubes == 0)
        {
            position = new Vector3(0.0f,0.2f,0.0f);
            this.transform.position = position;
            particlesSystem.Stop();
            cubes = 12;
            SceneManager.LoadScene(1);
             Debug.Log("Final Score Is: " +  score);
        }
        
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
            recollectionAudio.Play();
            cubes-=1;
            other.gameObject.SetActive(false);
            count++;
            score = score + 25;
            Debug.Log("Score: " + score);
        }
        else if(other.gameObject.CompareTag("RecollectableBad")) {
            position = other.gameObject.transform.position;
             score = score - 25;
              Debug.Log("Score: " + score);
        }
        {

        }
    }
}
