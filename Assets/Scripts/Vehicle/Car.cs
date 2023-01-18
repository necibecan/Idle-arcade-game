using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Movement
{
    [SerializeField] private WheelRotation wheelRot;
    [SerializeField] private float wheelSpeed;

    public override void MovementUpdate()
    {
        base.MovementUpdate();
        Vector3 movementVector = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        wheelRot.SetSpeed((movementVector * wheelSpeed).magnitude);
    }
}