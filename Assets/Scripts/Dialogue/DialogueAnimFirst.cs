using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimFirst : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManagerFirst dialogueManager;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnim.SetBool("StartOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        startAnim.SetBool("StartOpen", false);
        dialogueManager.EndDialogue();
    }
}
