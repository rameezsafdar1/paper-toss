using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotator;

    private void Update()
    {
        transform.Rotate(rotator.x, rotator.y, rotator.z);
    }
}
