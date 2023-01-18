using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] private Transform[] Wheels;

    private Vector3 axis = Vector3.right; 

    private float _movementSpeed = 1f;
    public void SetSpeed(float movementSpeed)
    {
        _movementSpeed = movementSpeed; 
    } 
    void Update()
    {
        foreach (var item in Wheels)
        {
            item.Rotate(Time.deltaTime * _movementSpeed * axis);
        }
    }
}
