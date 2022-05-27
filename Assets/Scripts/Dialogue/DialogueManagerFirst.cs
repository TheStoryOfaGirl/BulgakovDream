using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerFirst : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public Text textDialogue;
    public Text textName;

    public Animator dialogueAnim;
    public Animator startAnim;

    private Queue<string> sentences;
    private Queue<string> names;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueAnim.SetBool("endDiOpen", true);
        startAnim.SetBool("StartOpen", false);
        names.Clear();
        sentences.Clear();
        var index = dialogueManager.count < 6 ? 0 : 12;
        for (var i = index; i < dialogue.name.Length; i++)
            names.Enqueue(dialogue.name[i]);
        for (var j = index; j < dialogue.sentences.Length; j++)
            sentences.Enqueue(dialogue.sentences[j]);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 6 && dialogueManager.count < 6)
        {
            EndDialogue();
            return;
        }
        else if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, name));
    }

    IEnumerator TypeSentence(string sentence, string name)
    {
        textDialogue.text = "";
        textName.text = name;
        foreach (char letter in sentence.ToCharArray())
        {
            textDialogue.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueAnim.SetBool("endDiOpen", false);
    }
}
