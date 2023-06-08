using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happyfind : MonoBehaviour
{
    public Transform instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug .Log(instance.position);
    }
}
