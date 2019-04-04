using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {



        StartCoroutine("SetNetworkParam");
        InvokeRepeating("UpdateUI", 7, 7);

    }
	

    void UpdateUI()
    {
        StartCoroutine("SetNetworkParam");

    }
    // Update is called once per frame
    void Update () {
		
	}

    WWW url_get;
    string[] ScURL;
    string[] urls;
    public Image[] Banners;
    public Button[] Buttons;
    public Text TimeLeft, Message;

    void HideAll()
    {
        foreach(Image i in Banners)
        {
            i.gameObject.SetActive(false);
        }
        foreach (Button i in Buttons)
        {
            i.gameObject.SetActive(false);
        }

    }

    IEnumerator SetNetworkParam()
    {


        url_get = new WWW("https://thecampusentrepreneur.com/files/VR/fetch.php");
        yield return url_get;
        Debug.Log(url_get.text);

        if (url_get.error != null)
        {
            Debug.Log("No Data");
        }
        else
        {
            urls = url_get.text.Split('\n');
            ScURL = urls[5].Split('$');
            HideAll();
            Banners[int.Parse(ScURL[1].ToString())].gameObject.SetActive(true);
            Buttons[int.Parse(ScURL[2].ToString())].gameObject.SetActive(true);
            TimeLeft.text = ScURL[3].ToString();
            Message.text = ScURL[4].ToString();


            //Debug.Log(ScURL[2].ToString());

        }
        

    }
}
