using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControlScript : MonoBehaviour
{
    GameObject createdAsteroid;
    public GameObject[] asteroids;
    float asteroidDelay;
    public bool isAlive = true;

    void FixedUpdate()
    {
        asteroidDelay += Time.deltaTime;
        if (asteroidDelay > 1f && isAlive)
        {
            createAsteroid();
        }
    }

    void createAsteroid()
    {
        asteroidDelay = 0;
        int asteroidIndex = Random.Range(0, asteroids.Length);
        Vector3 asteroidPlace = new Vector3(Random.Range(-5, 5), 0, 15);
        createdAsteroid = Instantiate(asteroids[asteroidIndex], asteroidPlace, Quaternion.identity);
        createdAsteroid.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -2);
        createdAsteroid.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere;
    }
}
