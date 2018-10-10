using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeTrigger : MonoBehaviour {

    public Material baseMaterial;
    public Material fadeMaterial;

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Player has entered the trigger");

        if(other.gameObject.tag == "Player")
        {
            GetComponent<Renderer>().material = fadeMaterial;
        }
    }

    void OnTriggerExit (Collider other)
    {
        Debug.Log("Player has exited the trigger");

        if(other.gameObject.tag == "Player")
        {
            GetComponent<Renderer>().material = baseMaterial;
        }
    }

}
