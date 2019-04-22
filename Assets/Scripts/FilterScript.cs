using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class FilterScript : MonoBehaviour
{
    
    DatabaseReference questions_reference;

    public GameObject contentPrefab;

    public Transform container;
    
    private int count;

    private List<GameObject> contentObjects;

    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://hero-firebase-access.firebaseio.com/");
        questions_reference = FirebaseDatabase.DefaultInstance.GetReference("messages");
        InstantiateContent();
    }

    void Update()
    {
        //questions_reference.ValueChanged += HandleValueChanged;
    }

    void InstantiateContent()
    {
        questions_reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
                Debug.Log("Offline");
            else
            {
                DataSnapshot snapshot = task.Result;
                foreach(var rules in snapshot.Children)
                {
                    GameObject _object = Instantiate(contentPrefab, container);
                    _object.transform.GetChild(0).GetComponent<Text>().text = rules.Key;
                    _object.transform.GetChild(1).GetComponent<Toggle>().isOn = int.Parse(rules.Value.ToString()) != 0;
                    contentObjects.Add(_object);
                }
            }
        });
    }
    /*

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        questions_reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
                Debug.Log("Offline");
            else
            {
                DataSnapshot snapshot = task.Result;
                foreach(var rules in snapshot.Children)
                {
                    text.text = rules.Key;
                    toggle.isOn = int.Parse(rules.Value.ToString()) != 0;
                } 
            }
        });
    }
    */
}
