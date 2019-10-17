using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ControlBotones : MonoBehaviour, IVirtualButtonEventHandler
{
    private GameObject buttonObjectAm;
    private GameObject buttonObjectAz;
    private GameObject buttonObjectRo;
    private GameObject cubo;
    private Material materialCubo;


    // Start is called before the first frame update
    void Start()
    {
        cubo = GameObject.Find("Cube");
        materialCubo = cubo.GetComponent<Renderer>().material;

        buttonObjectAm = GameObject.Find("botonAmarillo");
        buttonObjectAz = GameObject.Find("botonAzul");
        buttonObjectRo = GameObject.Find("botonRojo");
        buttonObjectAm.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        buttonObjectAz.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        buttonObjectRo.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb){
        Debug.Log("Boton Presionado");

        switch (vb.VirtualButtonName)
        {
            case "botonAmarillo":
                Debug.Log("Amarillo");
                materialCubo.color = Color.yellow;
            break;

            case "botonAzul":
                Debug.Log("Azul");
                materialCubo.color = Color.blue;
            break;

            case "botonRojo":
                Debug.Log("Rojo");
                materialCubo.color = Color.red;
            break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb){
          Debug.Log("Boton Liberado");
           materialCubo.color = Color.white;
    }
}
