using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMover : MonoBehaviour
{
    //child the legs to the body and attach this script to the body
    LegPos[] legPos;
    LegPos[] legPosFront;
    LegPos[] legPosback;
    Vector3 centerPosSum, centerPos, bodyPos;
    Vector3 centerRotSum, centerRot, bodyRot;

    [SerializeField] float bodyYPosOffset;
    [SerializeField] Transform bodyParent;

    int frontLeftIndex, frontRightIndex, backLeftIndex, backRightIndex;
    bool allIndexFound = false;

    int i = 0;
    void Awake()
    {
        legPos = FindObjectsOfType<LegPos>(); //legpos script is attach to the end out each leg
    }
    private void Update()
    {
        for (int i = 0; i < legPos.Length; i++)
        {
            print(legPos[i] + i.ToString());
        }
        transform.position = RecalculateBodyTransform();
    }

    private Vector3 RecalculateBodyTransform()
    {
        centerPosSum = Vector3.zero;
        for (int i = 0; i < legPos.Length; i++)
        {
            centerPosSum += legPos[i].transform.position;
        }
        centerPos = centerPosSum / legPos.Length;
        bodyPos = new Vector3(bodyParent.position.x, centerPos.y + bodyYPosOffset, bodyParent.position.z);
        return bodyPos;
    }
    private void RecalculateBodyRotation()
    {
    }
}