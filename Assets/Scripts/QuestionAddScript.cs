using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class QuestionAddScript : MonoBehaviour
{
    DatabaseReference questions_reference;

    public InputField input;
    
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://hero-firebase-access.firebaseio.com/");
        questions_reference = FirebaseDatabase.DefaultInstance.GetReference("messages");
    }

    public void AddQuestion()
    {
        questions_reference.Child(input.text).SetValueAsync(0);
    }
}
