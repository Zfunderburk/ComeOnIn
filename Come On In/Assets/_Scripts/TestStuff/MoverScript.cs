using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverScript : MonoBehaviour {

    public GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("True");
        player.transform.position = new Vector3(Random.Range(-4f, 4f), 1.2f, Random.Range(-4f, 4f));
    }

}
