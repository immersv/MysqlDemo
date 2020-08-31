using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MysqlDataDemo : MonoBehaviour
{
    string url = "http://localhost/Login.php";
    string[] results;
    // Start is called before the first frame update
    [SerializeField]
    InputField userName;
    [SerializeField]
    InputField userPassword;
    //string uname,upassword;

    
    void Start()
    {
        //uname = userName.ToString();
        //upassword = userPassword.ToString();
       // StartCoroutine(Request(url));
    }

    public void ButtonClick()
    {
        
        StartCoroutine(Login(url));
    }


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


    }
    IEnumerator Login(string uri)
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
    }
}
