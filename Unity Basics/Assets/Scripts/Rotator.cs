using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    public Vector3 rotationVec;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVec);
    }
}
