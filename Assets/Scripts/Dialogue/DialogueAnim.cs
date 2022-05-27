using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnim : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dialogueManager;
    public Animator endAnim;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnim.SetBool("StartOpen", true);
        endAnim.SetBool("endOp", false);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!dialogueManager.flag)
        {
            dialogueManager.EndDialogue();
            startAnim.SetBool("StartOpen", false);
            endAnim.SetBool("endOp", true);
        }
        dialogueManager.flag = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        dialogueManager.Exit();
        startAnim.SetBool("StartOpen", false);
        endAnim.SetBool("endOp", false);
    }
}
