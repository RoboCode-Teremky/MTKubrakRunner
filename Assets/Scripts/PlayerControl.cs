using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    MyInput myInput;
    [SerializeField] Transform leftEdge, rightEdge;
    private float relativePosition = 0.5f;
    private float relativeDirection = 0.0f;
    [SerializeField] private float sensitivity = 0.1f;
    float xRot = 0f;
    float XMovementVector = 0;
    private void OnEnable()
    {
        myInput.Enable();
    }
    private void OnDisable()
    {
        myInput.Disable();
    }

    private void Awake()
    {
        myInput = new MyInput();
    }
    void Start()
    {
        myInput.PlayerControl.KeyboardMovement.started += ChangeDirection;
        myInput.PlayerControl.KeyboardMovement.canceled += ChangeDirection;
    }

    void Update()
    {
        relativePosition = Mathf.Clamp(relativePosition += sensitivity*relativeDirection*Time.deltaTime, 0.0f, 1.0f);
        transform.position = Vector3.Lerp(leftEdge.position, rightEdge.position, relativePosition);


        if (XMovementVector == -1)
        {
            xRot = Mathf.Lerp(xRot,-30f,Time.fixedDeltaTime * 3);
        }
        else if (XMovementVector == 1)
        {
            xRot = Mathf.Lerp(xRot,30f,Time.fixedDeltaTime * 3);
        }
        else if(XMovementVector == 0)
        {
            xRot = Mathf.Lerp(xRot,0f,Time.fixedDeltaTime * 3);
        }
        transform.rotation = Quaternion.Euler(xRot,90,0);
    }

    private void ChangeDirection(InputAction.CallbackContext context)
    {
        relativeDirection = context.ReadValue<Vector2>().x;
        XMovementVector = context.ReadValue<Vector2>().x;
        Debug.Log(XMovementVector);
    }
}
