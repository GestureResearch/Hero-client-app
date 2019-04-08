using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerScript : MonoBehaviour {

    public TextMeshProUGUI text;
    public float scrollSpeed = 10.0f;
    public Text liveText;

    private TextMeshProUGUI cloneText;
    private RectTransform textRectTransform;
    private string sourceText;
    private string tempText;
    private RectTransform cloneRectTransform;

    // Use this for initialization
    void Awake () {
        textRectTransform = text.GetComponent<RectTransform>();
        
        cloneText = Instantiate(text) as TextMeshProUGUI;
        cloneRectTransform = cloneText.GetComponent<RectTransform>();
        cloneRectTransform.SetParent(textRectTransform);
        cloneRectTransform.anchorMin = new Vector2(1, 0.5f);
        cloneRectTransform.localScale = new Vector3(1, 1, 1);
        cloneText.text = text.text;  

    }

    private IEnumerator Start()
    {
        Vector3 startPosition = textRectTransform.localPosition;

        float scrollPosition = 0;

        while (true)
        {
            var text1 = liveText.text;
            text.text = text1;
            cloneText.text = text1;
            var width = text.preferredWidth + 30;
            textRectTransform.localPosition = new Vector3((-scrollPosition % width) - (text.preferredWidth + 30), startPosition.y, startPosition.z);
            cloneRectTransform.localPosition = new Vector3(text.preferredWidth + 30, 0, cloneRectTransform.position.z);
            scrollPosition += scrollSpeed * 20 * Time.deltaTime;         
            yield return null;
        }      
    }
}﻿