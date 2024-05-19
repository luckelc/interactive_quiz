using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField]
    List<Question> questions = new List<Question>();

    [SerializeField]
    TextMeshProUGUI questionText;

    [SerializeField]
    Image questionImage;

    [SerializeField]
    TextMeshProUGUI pointsText;

    int points;

    public int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            pointsText.text = points.ToString(); // Update the UI Text when the variable is set
        }
    }


    [SerializeField]
    Transform answerGrid;

    private void Start()
    {
        ChangeToNextQuestion();
        Points = 0;
    }

    void ChangeToNextQuestion()
    {

        if (questions.Count > 0)
        {
            questionText.text = questions[0].question;

            if(questions[0].imageTexture){
                questionImage.gameObject.SetActive(true);
                questionImage.sprite = questions[0].imageTexture;
            }else{
                questionImage.gameObject.SetActive(false);
            }

            // Get the AnswerManager components of the children
            AnswerManager[] answerManagers = answerGrid.GetComponentsInChildren<AnswerManager>();

            // Check if there are enough answers and slots
            if (questions[0].noneAnswers.Count >= 2 && questions[0].halfAnswers.Count >= 1 && questions[0].fullAnswers.Count >= 1 && answerManagers.Length >= 4)
            {
                // Assign noneAnswers
                answerManagers[0].AnswerText = questions[0].noneAnswers[0];
                answerManagers[0].answerPoints = 0;
                answerManagers[1].AnswerText = questions[0].noneAnswers[1];
                answerManagers[1].answerPoints = 0;

                // Assign halfAnswer
                answerManagers[2].AnswerText = questions[0].halfAnswers[0];
                answerManagers[2].answerPoints = 1;

                // Assign fullAnswer
                answerManagers[3].AnswerText = questions[0].fullAnswers[0];
                answerManagers[3].answerPoints = 2;
            }

            RandomizeChildren();
            questions.RemoveAt(0);
        }
        else
        {
            print("You have cleared all questions");
        }
    }
    public void QuestionAnswered()
    {
        ChangeToNextQuestion();
    }

    void RandomizeChildren()
    {
        // Create a list to hold all the child objects
        List<Transform> children = new List<Transform>();

        // Add all the child objects to the list
        foreach (Transform child in answerGrid)
        {
            children.Add(child);
        }

        // Detach all the child objects
        children.ForEach(child => child.SetParent(null, false));

        // While there are still objects in the list
        while (children.Count > 0)
        {
            // Pick a random index
            int index = Random.Range(0, children.Count);

            // Set the parent of the selected child to this transform
            children[index].SetParent(answerGrid, false);

            // Remove the selected child from the list
            children.RemoveAt(index);
        }
    }
}
