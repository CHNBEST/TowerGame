using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    public float scaleSpeed;
    // Use this for initialization

    // Update is called once per frame
    void Update ()
    {
        transform.localScale += (new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime);
    }

}
