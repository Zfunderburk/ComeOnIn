using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

//	public Text dialogueTrigger;
	public Text nameText;
	public Text dialogueText;

    public KeyCode dialogueKey = KeyCode.Space;

	public Animator anim;

	private Queue<string> sentences;

	void Start () 
    {
		sentences = new Queue<string>();
	}

    public void StartDialogue (Dialogue dialogue)
	{
        anim.SetBool("isOpen", true);

        nameText.text = dialogue.name;                          //Sets namespace to that of curren NPC

        sentences.Clear();                                      //Clears current dialogue sentence 

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);                        //Queue up next sentence in component
        }

        if (Input.GetKey(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

	public void DisplayNextSentence()							//Function to display next sentence in queue
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

        string sentence = sentences.Dequeue();                  //Removes current sentence from queue //Currently not moving to next sentence

        //dialogueText.text = sentence;
        StopAllCoroutines();									//Ends any running coroutines
		StartCoroutine(TypeSentence(sentence));					//Begins TypeSentence coroutine
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())			//Sets Sentence string to a character array
		{
			dialogueText.text += letter;						//Pulls each letter in sequence from Dialogue Text
			yield return null;									//Time between letter appearence
		}
	}

	public void EndDialogue ()
	{
		anim.SetBool("isOpen", false);
	}
	

}
