using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchtype : MonoBehaviour
{
    public GameObject flower;
    public GameObject flowereffect;

    private float touchtime;

    private bool newTouch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//获取点击的坐标
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (Input.touchCount==1)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase==TouchPhase.Began)//第一次按
                    {
                        newTouch = true;
                        touchtime = Time.time;
                    }else if (touch.phase == TouchPhase.Stationary)
                    {
                        if (newTouch == true && Time.time - touchtime > 1f)
                        {
                            newTouch = false;
                            Destroy(hitInfo.collider.gameObject);
                            Instantiate(flowereffect, hitInfo.transform.position, Quaternion.identity);
                            
                            Instantiate(flower, hitInfo.transform.position, Quaternion.identity);//生成预制体在长按的地方
                            
                            
                            //Destroy(flowereffect);
                            
                            //Destroy(flower);
                            
                        }
                    }
                }
               
            }
        }
    }

    IEnumerator Create()
    {
        yield return new WaitForSeconds(8f);
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(20f);
    }
}
