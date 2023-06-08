using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class Roate : MonoBehaviour
{
    public float xSpeed = 150.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //判断点击
        if (Input.GetMouseButton(0))
        {
            //判断是否滑动屏幕
            if (Input.GetTouch( 0).phase ==TouchPhase.Moved)
            {
                transform.Rotate(Vector3.up *Input .GetAxis("Mouse X")*-xSpeed*Time.deltaTime,Space.World);//xSpeed前加负号，让旋转同步
            }
        }
           
    }
}
