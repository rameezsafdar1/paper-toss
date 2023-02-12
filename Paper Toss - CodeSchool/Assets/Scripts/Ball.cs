using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public void TurnMeOff()
    {
        StartCoroutine(off());
    }

    private IEnumerator off()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }

}
