using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Colorseasons : MonoBehaviour
{
    public ParticleSystem particle;//无用特效
    public GameObject  imageBall;
    public ParticleSystem peopleEffect;//跟随人物的特效
    public GameObject pointLight;
    public List<string> mylist;
    private Light Light_property;//定义变量获取灯光属性
    //UI图片
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    // Start is called before the first frame update
    void Start()
    {
        
        Light_property = pointLight.GetComponent<Light>();//获取灯光属性
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "Spot Light white":
                Light_property.color = new Color(255f, 255f, 255f);
                mylist.Add("ter");
                break;
            case "Spot Light green":
                Light_property.color = new Color(8f, 14f, 5f);
                mylist.Add("ter");
                ShowUIImage(blue);
                break;
            case "Spot Light orange":
                Light_property.color = new Color(220f, 70f, 50f);
                mylist.Add("ter");
                ShowUIImage(yellow);
                break;
            case "Spot Light purple":
                Light_property.color = new Color(26f, 5f, 26f);
                mylist.Add("ter");
                ShowUIImage(red);
                break;
            case "Plane1":
                particle .Play();
                imageBall .SetActive(true);
                Light_property.color = new Color(32f, 32f, 100f);
                peopleEffect.Play();
                break;
        }
        //Light_property.color = new Color(34f, 221f, 37f);
        //mylist.Add("ter");
        //Light_property.color = new Color(37, 221, 34);
        //mylist.Add("ter");
    }

    public void OnTriggerExit(Collider other)
    {
            particle .Stop();
            blue.SetActive(false);
            red.SetActive(false);
            yellow.SetActive(false);
            Light_property.color = new Color(0f, 0f, 0f);
            peopleEffect .Stop();
            mylist.Remove("ter");
    }

    private void ShowUIImage(GameObject one)
    {
        one.SetActive(true);
    }
    
}
