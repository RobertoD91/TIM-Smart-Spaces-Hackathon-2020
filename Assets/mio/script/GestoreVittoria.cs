using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreVittoria : MonoBehaviour
{
    public GameObject fuochi;
    public AudioSource musicaVittoria;
    public AperturaScrigni myAperturaScrigno;

    public bool status_vittoria = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            Debug.Log("r premuto");
            reset();
        }
        if (Input.GetKey("v"))  // per debug
        {
            Debug.Log("v premuto");
            haiVinto();
        }
    }

    public void haiVinto()
    {
        /*
         todo:
         - chiama api tim per invio sms codice sconto (in realtà lo fa il backend ma simuliamo da qui)
         - apri il forziere
         - avvia fuochi d'artificio
         - avvia musica
         - registrazione api tim con otp
         */
        status_vittoria = true;
        Debug.Log("haiVinto");
        myAperturaScrigno.apriScrigno();
        if (!musicaVittoria.isPlaying)
        {
            musicaVittoria.Play();
        }
        fuochi.SetActive(true);

        // todo: chiama reset dopo n secondi
        api_tim_invio_sms_vittoria_wrapper();
    }

    public void reset()
    {
        Debug.Log("reset");
        //myAperturaScrigno.apriScrigno();
        musicaVittoria.Stop();
        fuochi.SetActive(false);
    }

    public void api_tim_invio_sms_vittoria_wrapper()
    {
        StartCoroutine(api_tim_invio_sms_vittoria());
    }

    IEnumerator api_tim_invio_sms_vittoria()
    {
        if (status_vittoria)
        {
            yield return null;
        }
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("apikey", "RIMOSSO_COME_DA_REGOLAMENTO"); //todo: da nascondere
        Debug.Log("ATTENTINZIONE: REINSERIRE API NEL FILE GESTOREVITTORIA.CS IN ASSERS/MIO/SCRIPT");
        headers.Add("Content-Type", "application/json");
        headers.Add("accept", "application/json");
        string json = "{\"address\":\"tel:+393350000000\",\"message\":\"Hai vinto un codice sconto! [testing hackathon]\"}";
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        WWW www = new WWW("https://hackathon.tim.it/sms/mt", postData, headers);
        Debug.Log("pio");
        //Debug.Log(www.text);
        yield return www;
        Debug.Log(www.text);

        //curl - X POST "https://hackathon.tim.it/sms/mt"
        // - H "accept: */*" - H "apikey: RIMOSSO_COME_RICHIESTO"
        // - H "Content-Type: application/json"
        // - d "{\"address\":\"tel:+393351111111\",\"message\":\"Hello there\"}"
    }
}
