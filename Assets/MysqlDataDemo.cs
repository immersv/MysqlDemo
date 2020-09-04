using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MysqlDataDemo : MonoBehaviour
{
    string uri = "http://localhost/Register.php";
    //string[] results;
    // Start is called before the first frame update
    [SerializeField]
    InputField registerName;
    [SerializeField]
    InputField registerPassword;
    [SerializeField]
    InputField registerEmail;
    public void RegisterButtonClick()
    {
        StartCoroutine(Registor(uri, registerName.text,registerPassword.text,registerEmail.text));
        
    }
    IEnumerator Registor(string url, string rName, string rPassword, string rEmail)
    {
           WWWForm form = new WWWForm();
            form.AddField("phpUsername", rName);
            form.AddField("phpUserpassword", rPassword);
            form.AddField("phpUserEmail", rEmail);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("Form upload complete!");
                    Debug.Log("Received: " + www.downloadHandler.text);
            }
            }
        
    }





/*
    IEnumerator Request(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string databaseText = webRequest.downloadHandler.text;
            
            string[] results = databaseText.Split('/');
              
            for (int i = 0; i < results.Length-1; i++)
            {
                Debug.Log("Results :" + results[i]);
            }
        }


    }*/
    /*IEnumerator Login(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("usname",userName.text);
        form.AddField("uspwd", userPassword.text);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri,form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log( ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log( ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }*/
}
