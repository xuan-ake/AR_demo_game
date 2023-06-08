using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontrol : MonoBehaviour
{
    private Transform  Player;
    private Animator action;
    private float speed =10f;

    private int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        action = GetComponent<Animator>();
        Player = GetComponent<Transform>();
    }

    // Update is called once per frame
    //关于点击人物触发面部表情，类似于汤姆猫，以下是手指触摸屏幕的操作
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(a>5)
            {
                action.SetBool("Walk", false);
                a = 0;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics .Raycast( ray,out hitInfo))
            {
                if (Input.touchCount == 1)
                {
                    //Touch touch = Input.GetTouch(0);这个是获取触摸状态
                    Playdoing(a);
                    a++;
                }
            }
        }
    }

    public void GoStraight()
    {
        action.speed = 1f;
        action .Play("Run");
        Player.Translate(Vector3.forward*speed*Time.deltaTime );
    }


    private void Playdoing(int a)
    {
        /*
        switch (a)
        {
            case 0:
                action.Play("Angry");
                break;
            case 1:
                action .Play("Joy");
                break;
            case 2:
                action.Play("Fun");
                break;
            case 3:
                action.Play("Surprised");
                break;
            case 4:
                action.Play("Sorrow");
                break;
            case 5:
                action.Play("Blink");
                break;
        }
        */
        switch (a)
        {
            case 0:
                action.SetBool("Run",true);
                action.speed = 0.5f;
                //StartCoroutine(timeout());
                //action.SetBool("Run", false);
                break;
            case 1:
                action.SetBool("Run", false);
                action.SetBool("Angry", true);
                action.speed = 0.5f;
                //StartCoroutine(timeout());
                //action.SetBool("Angry", false);
                break;
            case 2:
                action.SetBool("Angry", false);
                action.SetBool("Bow", true);
                action.speed = 0.5f;
                //StartCoroutine(timeout());
                //action.SetBool("Bow", false);
                break;
            case 3:
                action.SetBool("Bow", false);
                action.SetBool("Blink", true);
                action.speed = 0.5f;
                //StartCoroutine(timeout());
                //action.SetBool("Blink", false);
                break;
            case 4:
                action.SetBool("Blink", false);
                action.SetBool("Joy", true);
                action.speed = 0.5f;
                //StartCoroutine(timeout());
                //action.SetBool("Joy", false);
                break;
            case 5:
                action.SetBool("Joy", false);
                action.SetBool("Walk", true);
                action.speed = 0.5f;
                //StartCoroutine(timeout());
                //action.SetBool("Walk", false);
                break;
        }
        {
            
        }
    }
   

   

    public void Startgame()
    {
        SceneManager.LoadScene(3);
    }
    //开协程用于动画播放时间的控制
    IEnumerator timeout()
    {
        yield return new WaitForSeconds(5f);//暂停5秒
    }
}
