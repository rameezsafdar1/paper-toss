using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public int currentscore;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            currentscore++;
            scoretext.text = "Score: " + currentscore.ToString();
        }
    }
}
