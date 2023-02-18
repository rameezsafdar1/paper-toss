using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Public method which is called by BallThrower.cs when this ball is thrown
    public void TurnMeOff()
    {
        // This method actually refers to a coroutine which is basically a mathod called after some delay
        StartCoroutine(off());
    }

    private IEnumerator off()
    {
        // So we wait for 5 seconds 
        yield return new WaitForSeconds(5f);

        // After we seconds, this code runs which basically turns the ball off so it can be reused later on
        gameObject.SetActive(false);
    }

}
