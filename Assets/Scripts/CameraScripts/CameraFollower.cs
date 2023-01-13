using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] internal Vector3 distance;

    private void Update()
    {
        transform.position = playerPos.position + distance;
    }
}
