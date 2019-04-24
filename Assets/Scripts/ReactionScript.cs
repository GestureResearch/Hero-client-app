using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.EventSystems;

public class ReactionScript : MonoBehaviour
{
    public Text[] textArray;
    
    DatabaseReference reactions_reference;

    
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://hero-firebase-access.firebaseio.com/");
        reactions_reference = FirebaseDatabase.DefaultInstance.GetReference("live reactions");
    }

    private void Update()
    {
        reactions_reference.ValueChanged +=  HandleValueChanged;
        foreach (var text in textArray)
        {
            text.fontSize += 1;
            text.fontSize -= 1;
        }
    }
    
    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        reactions_reference.OrderByValue().EqualTo(1).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
                Debug.Log("Offline");
            else
            {
                DataSnapshot snapshot = task.Result;
                int i = 0;
                foreach (var childSnapshot in snapshot.Children)
                {
                    var childValue = childSnapshot.Value.ToString ();
                    textArray[i].text = childValue;
                    i++;
                }
            }
        });
    }

    public void incrementReaction()
    {
        if (EventSystem.current.currentSelectedGameObject.name.Equals("Button 1"))
        {
            IncrementReaction(1);
        }
        else if (EventSystem.current.currentSelectedGameObject.name.Equals("Button 2"))
        {
            IncrementReaction(2);
        }
        else if (EventSystem.current.currentSelectedGameObject.name.Equals("Button 3"))
        {
            IncrementReaction(3);
        }
    }

    void IncrementReaction(int choice)
    {
        switch (choice)
        {
            case 1:
                reactions_reference.Child("reaction1").SetValueAsync(1);
                break;
            case 2:
                reactions_reference.Child("reaction2").SetValueAsync(1);
                break;
            case 3:
                reactions_reference.Child("reaction3").SetValueAsync(1);
                break;
        }
    }
}
