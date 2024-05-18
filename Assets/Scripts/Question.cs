using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "QuestionObjects/Question")]
public class Question : ScriptableObject
{
   
    public string question = "";

    public Sprite imageTexture;

    public List<Answer> fullAnswers = new List<Answer>();
    
    public List<Answer> halfAnswers = new List<Answer>();
   
    public List<Answer> noneAnswers = new List<Answer>();

}