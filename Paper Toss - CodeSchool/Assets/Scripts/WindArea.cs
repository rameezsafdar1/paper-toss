using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    // Variables

    // force of wind to be applied
    public float windforce;
    // direction of the wind flow
    public Vector3 direction;

    //Ontriggerstay is called every frame when there is a collision detected
    private void OnTriggerStay(Collider other)
    {
        // We are checking if we collide with ball
        if (other.tag == "Ball")
        {
            // Getting rigidbody of the ball which is main component of physics and adding force to it to simulate wind effect
            other.GetComponent<Rigidbody>().AddForce(direction * windforce);
        }
    }

}
