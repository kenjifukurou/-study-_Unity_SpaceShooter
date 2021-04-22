using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public int movementSpeed;
    Rigidbody rb;

    [SerializeField]
    bool changeDirection;

    [SerializeField]
    float changeTimer = 2;

    public float timerMin;
    public float timerMax;

    // Start is called before the first frame update
    void Start()
    {
        changeDirection = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        changesDirectionToggle();

    }

    void movement() {
        float movementValueH = Time.deltaTime - movementSpeed * 2;
        float movementValueV = Time.deltaTime - movementSpeed;
        if (!changeDirection) {
            rb.velocity = new Vector3(movementValueH, 0, movementValueV);
        } else {
            rb.velocity = new Vector3(-movementValueH, 0, movementValueV);
        }
    }

    void changesDirectionToggle() {

        changeTimer -= Time.deltaTime;
        if (changeTimer < 0) {
            if (!changeDirection) {
                changeDirection = true;
            } else {
                changeDirection = false;
            }
            float randomNumber = Random.Range(timerMin, timerMax);
            changeTimer = randomNumber;
        }
    }


}
