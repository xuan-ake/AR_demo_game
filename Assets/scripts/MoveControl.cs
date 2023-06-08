using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private Animator ain;

    private CharacterController cc;

    public float moveSpeed = 5;

    private float horizontalMove, verticalMove;

    private Vector3 dir;

    public Joystick joystick;//引用摇杆

    // Start is called before the first frame update
    void Start()
    {
        ain = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (dir != Vector3.zero)
        {
            ain.SetBool("Run",true);
            transform .rotation=Quaternion.LookRotation(dir);
            cc.Move(dir * Time.deltaTime);
        }
        else
        {
            cc.Move(dir);
            ain.SetBool("Run",false );
        }
    }
}
