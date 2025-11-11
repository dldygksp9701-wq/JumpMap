using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{

    [Header("movment")]
    private Vector2 curTransform;//현제 위치
    public Rigidbody _rigidbody;
    public Transform cameraContainer;
    public Transform target;
    public Transform camera;
    private Vector2 mouseDelta;
    public LayerMask groundLayerMask;

    [Header("Option")]
    public float speed;
    public float minXLook;
    public float maxXLook;
    private float curXCamera;
    public float lookSensitivity;
    public float JumpPower;
    public bool isJump = false;

    public event Action onJumped;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    private void Move()
    {
        Vector3 dir = -transform.forward * curTransform.y + -transform.right * curTransform.x;
        dir *= speed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        
        curXCamera += mouseDelta.y * lookSensitivity;
        curXCamera = Mathf.Clamp(curXCamera,minXLook,maxXLook);
        cameraContainer.localEulerAngles = new Vector3(curXCamera,0,0);
        transform.eulerAngles += new Vector3(0,mouseDelta.x * lookSensitivity,0);
        
        //target의 중심으로 마우스를 x축으로 돌렸을 때 x의 회전값 만큼 돌아간다.
        //카메라를 마우스 타겟으로 한다. 화면 정중앙으로 한다.
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curTransform = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curTransform = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGround())
        {
            _rigidbody.AddForce(Vector2.up * JumpPower, ForceMode.Impulse);
            onJumped?.Invoke();
        }
    }

    bool IsGround()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up *0.01f),Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f),Vector3.down),
            new Ray(transform.position + (transform.right *0.2f) + (transform.up * 0.01f),Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f),Vector3.down)
        };

        for(int i = 0; i < rays.Length; i++)
        {
            if(Physics.Raycast(rays[i],0.1f,groundLayerMask))
            {
                return true;
            }

        }
        return false;

    }


    
}
