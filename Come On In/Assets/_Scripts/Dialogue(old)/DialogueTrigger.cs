using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public Canvas dialogueTrig;
	public GameObject trigger;


	void Start () 
	{
		dialogueTrig.enabled = false;
	}

	public void OnTriggerEnter ()
	{
		dialogueTrig.enabled = true;
	}

	public void OnTriggerExit ()
	{
		dialogueTrig.enabled = false;
	}
		
	public void TriggerDialogue ()
	{
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);    //Finds StartDialogue function in DialogueManager script
        dialogueTrig.enabled = false;
    }
}
