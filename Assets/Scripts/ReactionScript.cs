using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.EventSystems;

public class ReactionScript : MonoBehaviour
{
    public string playerName;
    
    DatabaseReference reactions_reference;
    
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://hero-firebase-access.firebaseio.com/");
        reactions_reference = FirebaseDatabase.DefaultInstance.GetReference("live reactions");
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
                reactions_reference.Child("reaction1/player").SetValueAsync(1);
                break;
            case 2:
                reactions_reference.Child("reaction2/player").SetValueAsync(1);
                break;
            case 3:
                reactions_reference.Child("reaction3/player").SetValueAsync(1);
                break;
        }
    }
}
