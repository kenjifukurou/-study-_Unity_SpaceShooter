using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float movingSpeed;

    public MapLimit mapLimit;

    public GameObject playerBullet;
    public Transform GunCenter;
    public Transform GunLeft;
    public Transform GunRight;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private int power = 1;

    //public AudioClip shotSound;
    AudioSource audioSource;

    public int healthPoint;
    public ParticleSystem playerShipExplodePS;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ShootNormal();

    }

    void Movement() {

        if (Input.GetKey(KeyCode.A)) {
            //move left
            transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            //move right
            transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W)) {
            //move forward
            transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            // move backward
            transform.Translate(Vector3.back * movingSpeed * Time.deltaTime);
        }

        MovementLimit();

    }

    void MovementLimit() {
        transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, mapLimit.minimumX, mapLimit.maximumX),
                0.0f,
                Mathf.Clamp(transform.position.z, mapLimit.minimumZ, mapLimit.maximumZ)
            );
    }

    void ShootNormal() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // play sound
            audioSource.Play();
            //shoot bullet base on power level
            switch (power) {
                case 1:
                    // 1 bullet
                    GameObject bullet1 = Instantiate(playerBullet, GunCenter.position, GunCenter.rotation);
                    bullet1.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
                    break;
                case 2:
                    // 2 bullet
                    GameObject bullet2A = Instantiate(playerBullet, GunLeft.position, GunCenter.rotation);
                    GameObject bullet2B = Instantiate(playerBullet, GunRight.position, GunCenter.rotation);
                    bullet2A.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
                    bullet2B.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
                    break;
                case 3:
                    // 3 bullet
                    GameObject bullet3A = Instantiate(playerBullet, GunCenter.position, GunCenter.rotation);
                    GameObject bullet3B = Instantiate(playerBullet, GunLeft.position, GunCenter.rotation);
                    GameObject bullet3C = Instantiate(playerBullet, GunRight.position, GunCenter.rotation);
                    bullet3A.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
                    bullet3B.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
                    bullet3C.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
                    break;
                default:
                    // 1 bullet;
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        //Debug.Log("collision happen");
        if (other.gameObject.tag == "PowerUp") {
            if (power < 3) {
                power++;
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "PowerDown") {
            if (power > 1) {
                power--;
                Destroy(other.gameObject);
            }
        }
    }

    public void TakeDamage(int amount) {

        healthPoint -= amount;    
        if (healthPoint <= 0) {
            Instantiate(playerShipExplodePS, transform.position, transform.rotation);
            Destroy(gameObject);
            GameOver();
        }
    }

    void GameOver() {
        Debug.Log("Game Over");
    }
}
