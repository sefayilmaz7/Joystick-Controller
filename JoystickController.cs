using System;
using UnityEngine;


public class JoystickController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public DynamicJoystick dynamicJoystick;
    [SerializeField] private CharacterController characterController;
    private Quaternion _direction;
    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        characterController.Move(direction * speed * Time.deltaTime);
        if (direction != Vector3.zero)
        {
            _direction = Quaternion.LookRotation(direction);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, _direction, rotationSpeed * Time.deltaTime);

        /*if (direction == Vector3.zero)
        {
            playerAnimations.BackToIdleAnim();
        }
        else
        {
            playerAnimations.SwitchToRunAnim();
        }*/
    }
    
}