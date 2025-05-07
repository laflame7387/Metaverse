using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Player : MonoBehaviour
{
    public Transform target;
    float offsetX;
    float offsetY;

    private void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;

    }

    private void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;
        
        transform.position = pos;
    }
}
