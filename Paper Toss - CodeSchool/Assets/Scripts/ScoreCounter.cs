using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    // Variables
    public TextMeshProUGUI scoretext;
    public int currentscore;

    // Ontriggerenter is called once as soon as a collision is detected
    private void OnTriggerEnter(Collider other)
    {
        // We are checking if we are colliding with a ball
        if (other.tag == "Ball")
        {
            // In case we actually collided with a ball, we increase the score
            currentscore++;
            // Displaying the score on UI
            scoretext.text = "Score: " + currentscore.ToString();
        }
    }
}
