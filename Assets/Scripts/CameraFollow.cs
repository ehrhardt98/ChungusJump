using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    //public float smoothSpeed = .3f;

    void LateUpdate() {
        if (target)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = newPos;

            //if (target.position.y > transform.position.y)
            //{
            //    Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            //    transform.position = newPos;
            //    transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
            //}
        }
    }
}
