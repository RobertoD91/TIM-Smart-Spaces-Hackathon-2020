using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class urlRobot : MonoBehaviour
{
    public Text testoStato;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        if(testoStato != null)
        {
            getAPIeTesto();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // funziona!!!!!!!!!!!
    public void testAPI2wrapper()
    {
        Debug.Log("testAPI2wrapper");

        StartCoroutine(testAPI2());
    }

    public void testAPI3wrapper()
    {
        Debug.Log("testAPI3wrapper");

        StartCoroutine(testAPI3());
    }

    public void testAPI4wrapper()
    {
        Debug.Log("testAPI4wrapper");

        StartCoroutine(testAPI4());
    }

    public void getAPIeTesto()
    {
        StartCoroutine(getAPIeTesto_int());
    }

    public void sendAPIeTesto()
    {
        StartCoroutine(invioComandi());
    }


    // ok
    [Obsolete]
    IEnumerator testAPI2()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("apikey", "RIMOSSO_COME_RICHIESTO");
        headers.Add("Content-Type", "application/json");
        string json = "{    \"command\": {        \"code\": 0,   \"parameters\": { \"velocity\": {  \"linear\": 0.0, \"angular\": 0.5, \"duration\": 2.0}}}}";
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        WWW www = new WWW("https://hackathon.tim.it/CRI1/command", postData, headers);
        Debug.Log("pio");
        Debug.Log(www.text);
        yield return www;
        Debug.Log(www.text);
    }

    [Obsolete]
    IEnumerator getAPIeTesto_int()
    {
        Debug.Log("getAPIeTesto_int");
        using (UnityWebRequest www = UnityWebRequest.Get("https://hackathon.tim.it/CRI1/status"))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "text/json");
            www.SetRequestHeader("apikey", "RIMOSSO_COME_RICHIESTO");

            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                testoStato.text = www.downloadHandler.text;
            }
        }
        yield return null;
    }

    [Obsolete]
    IEnumerator invioComandi(double linear = 0.5, double angular = 0.5, double duration = 1.9)
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("apikey", "RIMOSSO_COME_DA_REGOLAMENTO")
        Debug.Log("ATTENTINZIONE: REINSERIRE API NEL FILE URLROBOT.CS IN ASSERS/MIO/SCRIPT");
        headers.Add("Content-Type", "application/json");
        string json = "{    \"command\": {     \"code\": 0,   \"parameters\": { \"velocity\": {  \"linear\": "+linear+", \"angular\": "+angular+", \"duration\": "+duration+"}}}}";
        Debug.Log(json);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        WWW www = new WWW("https://hackathon.tim.it/CRI1/command", postData, headers);
        Debug.Log("pio");
        Debug.Log(www.text);
        yield return www;
        Debug.Log(www.text);
        if(testoStato != null)
        {
            testoStato.text = www.text;
        }
        
    }

    [Obsolete]
    IEnumerator testAPI3()
    {
        Debug.Log("testAPI3");
        string postData = @"{
		    'hello':'world', 
		    'foo':'bar', 
		    'count':25
	    }"; 
        //string postData = "{....post data json...}";
        //byte[] rawData = System.Text.Encoding.UTF8.GetBytes(postData);
        using (UnityWebRequest www = UnityWebRequest.Post("https://hackathon.tim.it/CRI1/command", ""))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "text/json");
            www.SetRequestHeader("apikey", "RIMOSSO_COME_RICHIESTO");

            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
        yield return null;
    }

    [Obsolete]
    IEnumerator testAPI4()
    {
        Debug.Log("testAPI3");
        string postData = "{\"command\": { \"code\": 0,\"parameters\": { \"velocity\": { \"linear\": 0.0, \"angular\": 0.5, \"duration\": 2.0}}}}";

        //string postData = "{....post data json...}";
        //byte[] rawData = System.Text.Encoding.UTF8.GetBytes(postData);
        using (UnityWebRequest www = UnityWebRequest.Get("https://hackathon.tim.it/CRI1/status"))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "text/json");
            www.SetRequestHeader("apikey", "RIMOSSO_COME_RICHIESTO");

            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
        yield return null;
    }
}
