using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    private Vector3 startPosition;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.time

        float newZPosition = Mathf.Repeat(Time.time * this.speed, 150);
        transform.position = startPosition + Vector3.back * newZPosition;
    }
}