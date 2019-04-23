using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class ManagerScript : MonoBehaviour
{
    public Text text;

    DatabaseReference questions_reference;

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://hero-firebase-access.firebaseio.com/");
        questions_reference = FirebaseDatabase.DefaultInstance.GetReference("messages");
    }

    void Update()
    {
        questions_reference.ValueChanged += HandleValueChanged;
        text.fontSize += 1;
        text.fontSize -= 1;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        questions_reference.OrderByValue().EqualTo(1).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
                Debug.Log("Offline");
            else
            {
                DataSnapshot snapshot = task.Result;
                string stringData = "";
                foreach (var childSnapshot in snapshot.Children)
                {
                    var childName = childSnapshot.Key.ToString ();
                    stringData += childName.ToString();
                }

                text.text = stringData;
            }
        });
    }
}