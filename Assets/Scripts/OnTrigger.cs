using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour {

    public Dialogue dialogue;

            private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Stay");


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");

        FindObjectOfType<DialogueManager>().EndDialogue();
    }


}
