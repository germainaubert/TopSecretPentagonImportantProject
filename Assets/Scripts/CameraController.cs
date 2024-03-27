using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float smoothTime = 10f;
    [SerializeField] private Transform target; // the player
    
    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
