using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "QuestionObjects/Question")]
public class Question : ScriptableObject
{
   
    public string question = "";

    public Sprite imageTexture;

    public List<String> fullAnswers = new List<String>();
    
    public List<String> halfAnswers = new List<String>();
   
    public List<String> noneAnswers = new List<String>();

}