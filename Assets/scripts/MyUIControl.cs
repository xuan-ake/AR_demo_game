using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyUIControl : MonoBehaviour
{
    public Image ARimage;
    public Text text;
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {

        ARimage.enabled = false;
        text.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBottonDetail()
    {
        //switch (x)
        //{
        //    case 0:

        //        ARimage.enabled = true;
        //        x++;
        //        break;
        //    case 1:
        //        ARimage.enabled = false;
        //        x--;
        //        break;
        //}
        
            ARimage.enabled = !ARimage.enabled;//控制图片的开关
            text.enabled = !text.enabled;

    }
    //场景跳换
    public void OnMoreButton()
    {
        SceneManager.LoadScene("information");
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("happy");
    }
}
