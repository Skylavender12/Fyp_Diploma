using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(GetRegister());
    }
    private IEnumerator GetRegister()
    {

        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/project/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("User Created Successfully!");
            }
        }

        //solve this bullshit problem Deven like god this line annoying me
        /*public static void VerifyInputs()
        {
            submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
        }*/
    }
}