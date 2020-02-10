using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
    }
}