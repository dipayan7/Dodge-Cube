using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Text resultText;

    public Button submitButton;
    private string phpScriptURL = "http://localhost/sqlconnect/register1.php";

    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        UnityWebRequest www = UnityWebRequest.Post(phpScriptURL, form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("HTTP request error: " + www.error);
        }
        else
        {
            //string responseText = "done";
            //resultText.text = responseText;

            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }

    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}





//using System.Collections;
//using UnityEngine;
//using UnityEngine.Networking;
//using UnityEngine.UI;

//public class DatabaseLogin : MonoBehaviour
//{
//    public InputField nameInputField;
//    public InputField passwordInputField;
//    public Text resultText;

//    private string phpScriptURL = "https://yourwebsite.com/path/to/database.php";

//    public void AttemptLogin()
//    {
//        StartCoroutine(SendRequest());
//    }

//    IEnumerator SendRequest()
//    {
//        // Create a form for POST data
//        WWWForm form = new WWWForm();
//        form.AddField("name", nameInputField.text);
//        form.AddField("password", passwordInputField.text);

//        // Create a UnityWebRequest with the POST method
//        UnityWebRequest www = UnityWebRequest.Post(phpScriptURL, form);

//        yield return www.SendWebRequest();

//        if (www.result != UnityWebRequest.Result.Success)
//        {
//            Debug.LogError("HTTP request error: " + www.error);
//        }
//        else
//        {
//            string responseText = www.downloadHandler.text;
//            resultText.text = responseText;

//            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
//        }
//    }
//}
