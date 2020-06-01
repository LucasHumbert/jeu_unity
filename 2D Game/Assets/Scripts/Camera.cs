using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector2 velocity;
    private Transform target;
    private float distanceSupp;

    public float smoothTimeX;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void FixedUpdate() {
        /*
        if (target.GetComponent<Rigidbody2D>().velocity.x == 0) {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }

        if (target.GetComponent<Rigidbody2D>().velocity.x > 0) {
            distanceSupp = 0.3f;
        }

        if (target.GetComponent<Rigidbody2D>().velocity.x < 0) {
            distanceSupp = -0.3f;
        }

        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x + distanceSupp, ref velocity.x, smoothTimeX);
        */
        transform.position = new Vector3(target.position.x + 0.8f, target.position.y, transform.position.z);

    }
}
