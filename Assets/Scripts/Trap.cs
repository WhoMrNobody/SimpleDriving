using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(Vector3.right * 2);
    }
}
