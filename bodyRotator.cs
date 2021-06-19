using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyRotator : MonoBehaviour
{
    //child the legs to the body and attach this script to the body
    [SerializeField] LayerMask layerMask;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, layerMask))
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
            transform.rotation = Quaternion.LookRotation(transform.transform.forward, hit.normal);
        }
    }
}
