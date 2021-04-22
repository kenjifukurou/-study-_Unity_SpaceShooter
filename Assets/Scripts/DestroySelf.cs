using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float timer;
    public ParticleSystem explodeParticle;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0) {
            if (explodeParticle) {
                Instantiate(explodeParticle, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
