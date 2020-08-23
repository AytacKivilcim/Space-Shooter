using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public GameObject bullet;
    GameObject createdBullet;
    public float playerSpeed;
    Rigidbody playerRigid;
    float horizontal, vertical, minX = -5.5f, maxX = 5.5f, minZ = -4.5f, maxZ = 12.5f, bulletDelay;
    Vector3 vec;
    gameControlScript mainScript;

    void Start()
    {
        playerRigid = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        bulletDelay += Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal, 0, vertical);
        playerRigid.velocity = vec * playerSpeed;
        //player boundries
        playerRigid.position = new Vector3
        (
            Mathf.Clamp(playerRigid.position.x, minX, maxX),
            0.0f,
            Mathf.Clamp(playerRigid.position.z, minZ, maxZ)
        );
        playerRigid.rotation = Quaternion.Euler(0, 0, -playerRigid.velocity.x * 10);

        if (Input.GetKey(KeyCode.Space) && bulletDelay > 0.3f)
        {
            createBullet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("asteroidTag"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }

    void createBullet()
    {
        bulletDelay = 0;
        Vector3 bulletPlace = new Vector3(0, 0, 1.1f) + gameObject.GetComponent<Transform>().position;
        createdBullet = Instantiate(bullet, bulletPlace, Quaternion.identity);
        createdBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
    }
}
