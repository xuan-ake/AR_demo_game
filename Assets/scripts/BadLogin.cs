using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BadLogin : MonoBehaviour
{
    public InputField username;

    public InputField password;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginButton()
    {
        string Username = username.text.Trim();
        string Password = password.text.Trim();
        if (Username.Equals("xzx") && Password.Equals("123"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
