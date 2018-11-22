using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRotate : MonoBehaviour
{
    public Vector3 rotation;
    // Use this for initialization


    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(rotation * Time.deltaTime);
       

    }
}
