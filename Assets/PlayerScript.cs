using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody ship;

    public float tilt;
    public float speed; // PUBLIC!!!

    public float xMin, xMax, zMin, zMax;

    public GameObject LazerGun;     // откуда стреляем
    public GameObject LazerShot;    // выстрел
    public float shotDelay;         // задержка между выстрелами

    private float nextShot;         // врем, когда можно сделать следующий выстрел

    // Start is called before the first frame update
    void Start()
    {
        this.ship = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.Instance.IsStarted)   // если игра ещё не начата
            return;

        float moveHorizontal    = Input.GetAxis("Horizontal"); // [-1; 1]
        float moveVertical      = Input.GetAxis("Vertical"); // [-1; 1]

        /* наклоны при поворотах*/
        // X - влево/вправо
        // Z - вверх/вниз
        // Vector - x, y, z
        this.ship.velocity      = new Vector3(moveHorizontal, 0, moveVertical) * this.speed;

        this.ship.rotation      = Quaternion.Euler(
                                    this.ship.velocity.z * tilt,
                                    0,
                                    - this.ship.velocity.x * tilt);

        /* ограничение движения */
        float xPosition         = Mathf.Clamp(this.ship.position.x, xMin, xMax);
        float zPosition         = Mathf.Clamp(this.ship.position.z, zMin, zMax);
        this.ship.position      = new Vector3(xPosition, 0, zPosition);

        /* стрельба */
        if (Input.GetButton("Fire1") && Time.time > this.nextShot)
        {
            Instantiate(this.LazerShot, LazerGun.transform.position, Quaternion.identity);
            this.nextShot = Time.time + shotDelay;
        }

        if (Input.GetButton("Fire2"))
        {
            var asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

            foreach (var asteroid in asteroids)
                asteroid.GetComponent<AsteroidScript>().Explode();
        }
    }
}