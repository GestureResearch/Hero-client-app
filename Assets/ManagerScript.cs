using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerScript : MonoBehaviour {

    public GameObject image;

    public TextMeshProUGUI text;
    public float scrollSpeed = 10.0f;

    public Text liveText;

    private RectTransform text1RectTransform, text2RectTransform;

    float startPosition;

    TextMeshProUGUI text1, text2, text3;

    // Use this for initialization
    void Awake ()
    {
        text1 = Instantiate(text) as TextMeshProUGUI;
        text1RectTransform = text1.GetComponent<RectTransform>();
        text1RectTransform.SetParent(image.transform);
        text1RectTransform.localPosition = Vector3.zero;
    }

    private void Update()
    {
        text1.text = liveText.text;
        text1RectTransform.localPosition = new Vector3(text1RectTransform.localPosition.x - scrollSpeed, text1RectTransform.localPosition.y, text1RectTransform.localPosition.z);
        if (text1RectTransform.localPosition.x < -1200)
        {
            text2 = text1;
            text1 = Instantiate(text2, Vector3.left * 1200,Quaternion.identity,text2.transform) as TextMeshProUGUI;
        }
        if (text1RectTransform.localPosition.x + 1200 < -text.preferredWidth)
        {

            Destroy(text2);
        }
    }
}