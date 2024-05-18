using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textElement;

    [SerializeField]
    private PointManager pointMan;

    [SerializeField]
    QuestionManager questionManager;

    public int answerPoints;

    private string answerText;
    public string AnswerText
    {
        get
        {
            return answerText;
        }
        set
        {
            answerText = value;
            textElement.text = answerText; // Update the UI Text when the variable is set
        }
    }

    public void OnAnswerPress()
    {
        questionManager.Points += answerPoints;
        pointMan.AddPoints(answerPoints);
        questionManager.QuestionAnswered();
    }

}