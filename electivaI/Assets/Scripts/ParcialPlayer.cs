using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcialPlayer : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject obj1;
    private GameObject obj2;
    
    private List<GameObject> cubes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cubes.Count!=0){
            rotate(cubes[0]);
            if(cubes.Count==2){
                rotate(cubes[1]);
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Trap")){
            Debug.Log("trampa");
            if(cubes.Count<=2){
                cubes.Add(other.gameObject);
                Debug.Log(cubes.Count);
            }
            cubes.Add(other.gameObject);
            this.rotate(other.gameObject);
        }else if(other.gameObject.CompareTag("Recollectable")){
            Debug.Log("recolectado");
            other.gameObject.SetActive(false);
        }else if(other.gameObject.CompareTag("RecollectableBad")){
            Debug.Log("cuidado abajo!!!");
            other.attachedRigidbody.useGravity = true;
            other.attachedRigidbody.isKinematic = false;
        }
    }

    void rotate(GameObject alfa){
        obj1=alfa;
        obj1.transform.Rotate(new Vector3(60,60,60)*Time.deltaTime);
    }
}
