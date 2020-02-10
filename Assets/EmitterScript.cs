using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;

    public float minDelay, maxDelay;

    private float nextLaunch; // время следующего запуска

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.Instance.IsStarted)   // если игра ещё не начата
            return;

        if (Time.time > this.nextLaunch)
        {
            // время запускать астероид
            this.nextLaunch = Time.time + Random.Range(this.minDelay, this.maxDelay);

            float xSize     = transform.localScale.x;   // Размер по оси X
            float xPosition = Random.Range(-xSize / 2, xSize / 2);
            float zPosition = transform.position.z;

            Instantiate(this.asteroid, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
        }
    }
}