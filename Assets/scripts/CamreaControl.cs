using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamreaControl : MonoBehaviour
{
    private bool viewpointSwitch = false;//标记是否做了视角切换
    private float  moveSpeed = 10;//设置镜头移动速度,将速度调慢，让摄像机到达指定位置出现时延达到类似原神的效果
    public Transform player;
    public Transform cameraFollow;//摄像机注视的点
    public Transform cameraStay;//摄像机待的位置
    private Vector3 deviation;
    // Start is called before the first frame update
    void Start()
    {
        deviation = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (viewpointSwitch)
        {
            
            transform.LookAt(cameraFollow);
            
            transform.position =Vector3.MoveTowards(transform .position ,cameraStay.position,Time.deltaTime*moveSpeed );//从现在的位置到达指定位置
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position + deviation, Time.deltaTime * moveSpeed);
        }
    }


    public void OnButtonAngle()
    {
        //transform.position = player.position+new Vector3(0,1.35f,0);
        transform.position = cameraStay.position;
        //transform.rotation = player.rotation;
        transform .LookAt(cameraFollow);
        deviation = transform.position - player.position;
        viewpointSwitch = true;
        moveSpeed = 1f; //将速度调慢，让摄像机到达指定位置出现时延达到类似原神的效果
    }
}
