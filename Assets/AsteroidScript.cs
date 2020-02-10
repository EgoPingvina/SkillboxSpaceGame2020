using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float angularSpeed,
        minSpeed,
        maxSpeed;

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    public void Explode()
    {
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);

        Destroy(gameObject);        // уничтожаем текущий объект
    }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid          = GetComponent<Rigidbody>();
        asteroid.angularVelocity    = Random.insideUnitSphere * angularSpeed;
        asteroid.velocity           = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    // Текущий объект (астероид) столкнулся с другим коллайдером (other)
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Asteroid")
            return;

        if (other.tag == "Player")
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        else
            GameControllerScript.Instance.IncreaseScore(10);

        this.Explode();
        
        Destroy(other.gameObject);  // уничтожаем второй объект
    }
}