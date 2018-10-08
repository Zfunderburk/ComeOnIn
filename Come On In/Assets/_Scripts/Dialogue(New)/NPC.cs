using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour 
{

    public Transform TextBG;
    public Transform NonPlayer;

    private DialogueSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] sentences;

	void Start () 
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
	}

	void Update () 
    {
        //		TextBG.position = Camera.main.worldToScreenPoint(NonPlayer.position + Vector3.up * 7f)
        Vector3 Pos = Camera.main.WorldToScreenPoint(NonPlayer.position);
        Pos.y += 10;
        TextBG.position = Pos;
	}

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}
