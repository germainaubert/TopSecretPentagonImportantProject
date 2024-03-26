using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float smoothTime;
    [SerializeField] private Transform target; // the player
    
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        
        if(target.transform.localScale.x > 0f)
        {
            targetPosition = new Vector3(targetPosition.x + offset, targetPosition.y, targetPosition.z);    
        } else
        {
            targetPosition = new Vector3(targetPosition.x - offset, targetPosition.y, targetPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);
    }
}
