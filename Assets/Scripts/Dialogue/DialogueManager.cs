using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    public Text textDialogue;
    public Text textName;

    public Animator dialogueAnim;
    public Animator startAnim;
    public Animator inputFieldOpen;
    public Animator endAnim;

    private Queue<string> sentences;
    private Queue<string> names;

    internal int count = 0;

    internal bool flag = true;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueAnim.SetBool("dialogueOpen", true);
        inputFieldOpen.SetBool("fopen", false);
        names.Clear();
        sentences.Clear();
        foreach (var name in dialogue.name)
            names.Enqueue(name);
        foreach (var sentence in dialogue.sentences)
            sentences.Enqueue(sentence);
        DisplayNextSentence();
        count++;
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            if (count % 2 == 1)
            {
                dialogueAnim.SetBool("dialogueOpen", false);
                inputFieldOpen.SetBool("fopen", true);
            }
            else Exit();
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
        inputFieldOpen.SetBool("fopen", false);
        startAnim.SetBool("StartOpen", false);
    }

    public void Exit()
    {
        inputFieldOpen.SetBool("fopen", false);
        dialogueAnim.SetBool("dialogueOpen", false);
        startAnim.SetBool("StartOpen", false);
    }

    public void ContinueDialogue()
    {
        if (inputField.text == "Азазелло" || inputField.text == "Мастер и Маргарита" || inputField.text == "Воланд и Фагот" 
            || inputField.text == "Фагот и Воланд" 
            || inputField.text == "Маргарита и Мастер" || inputField.text == "Воланд и Коровьев" 
            || inputField.text == "Коровьев и Воланд")
        {
            inputField.text = "";
            flag = false;
        }
    }
}