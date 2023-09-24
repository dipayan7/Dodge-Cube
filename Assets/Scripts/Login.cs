using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Text resultText; // Assign this in the Inspector

    public Button submitButton;
    private string phpScriptURL = "http://localhost/sqlconnect/login.php";

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        UnityWebRequest www = UnityWebRequest.Post(phpScriptURL, form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string responseText = www.downloadHandler.text; // Use the actual server response text

            if (responseText.StartsWith("0"))
            {
                DBManager.username = nameField.text;
                string[] parts = responseText.Split('\t');
                if (parts.Length >= 2)
                {
                    DBManager.score = int.Parse(parts[1]);
                    if (resultText != null)
                    {
                        resultText.text = "Login Successful!";
                    }
                    else
                    {
                        Debug.LogWarning("resultText is not assigned.");
                    }
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }
                else
                {
                    Debug.LogError("Invalid response format: " + responseText);
                }
            }
            else
            {
                if (resultText != null)
                {
                    resultText.text = "Login Failed: " + responseText;
                }
                else
                {
                    Debug.LogWarning("resultText is not assigned.");
                }
            }
        }
        else
        {
            if (resultText != null)
            {
                resultText.text = "Network Error: " + www.error;
            }
            else
            {
                Debug.LogWarning("resultText is not assigned.");
            }
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
