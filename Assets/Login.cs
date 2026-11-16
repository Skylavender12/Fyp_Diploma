using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(GetLogin());
    }
    private IEnumerator GetLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/project/login.php", form))
        {
            yield return www.SendWebRequest();
            
            if (www.downloadHandler.text[0] == '0')
            {
                DBManager.username = nameField.text;
                DBManager.score = int.Parse(www.downloadHandler.text.Split('\t')[1]);
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);   
            }
            else
            {
                Debug.Log("User Error: " + www.downloadHandler.text);
            }
        }

    }
}
