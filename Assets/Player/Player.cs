using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    public Rigidbody2D myRigidBody;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed = 5f;
    public float speedRun = 10f;
    public float jumpForce = 10f;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .5f;
    public float duration = .3f;
    public Ease ease = Ease.OutBack;

    private float _currentSpeed;
    private void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {

        // if (Input.GetKey(KeyCode.LeftShift))
        //     _currentSpeed = speedRun;
        // else
        //     _currentSpeed = speed;

        _currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speedRun : speed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
        }

        if (myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity -= friction;
        }
        else if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * jumpForce;
            myRigidBody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, duration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody.transform.DOScaleX(jumpScaleX, duration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
