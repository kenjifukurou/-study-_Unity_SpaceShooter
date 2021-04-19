using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float movingSpeed;

    public MapLimit mapLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
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
}
