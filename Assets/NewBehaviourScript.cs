using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Upload());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Upload()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("apikey = rwTOUyXt226v50MPFDU1tAQrAFQrvESAUu8QwS4UAjpc"));
        formData.Add(new MultipartFormFileSection("images_file", "/var/mobile/Containers/Data/app sandbox/Documents/screenshot.jpg"));
        UnityWebRequest www = UnityWebRequest.Post("https://gateway.watsonplatform.net/visual-recognition/api", formData);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
