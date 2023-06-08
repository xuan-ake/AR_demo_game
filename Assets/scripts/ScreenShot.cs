using System.Collections;
using System.Collections.Generic;
using System.IO;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScreenShotClick()
    {
        System.DateTime now = System.DateTime.Now;
        string time = now.ToString();
        time = time.Trim();//去掉了字符串前后的空格
        time = time.Replace("/", "-");//将字符串中的/替换成-
        string fileName = "ARScreenShot" + time + ".png";
        if (Application.platform == RuntimePlatform.Android)
        {
            Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(0,0,Screen.width ,Screen .height ),0,0);
            texture.Apply();

            byte[] bytes = texture.EncodeToPNG();
            string destination = "/sdcard/DCIM/Screenshots";//打开
            if (!Directory.Exists(destination))//如果相册文件夹没有创建的话
            {
                Directory.CreateDirectory(destination);
            }

            string pathSave = destination + "/" + fileName;
            File.WriteAllBytes(pathSave, bytes);//文件写入照片的字节

        }

    }
}
