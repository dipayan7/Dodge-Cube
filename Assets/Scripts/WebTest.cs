using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW request = new WWW("https://localhost/sqlconnect/webtest.php");
        yield return request;

        Debug.Log(request.text);
            
    }

    // Update is called once per frame
    
}
