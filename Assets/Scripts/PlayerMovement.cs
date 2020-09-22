using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";

    [SerializeField] private float moveSpeed;

    private CharacterController2D characterControllerOnPlayer;
    private Animator animatorOnPlayer;
    private float horizontalMove;
    private bool isJump, isCrouch;

    private void Start()
    {
        characterControllerOnPlayer = GetComponent<CharacterController2D>();
        animatorOnPlayer = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw(HORIZONTAL_AXIS) * moveSpeed;
        Debug.Log(horizontalMove);
        animatorOnPlayer.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
            SetJumpBool(true);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            isCrouch = false;
        }
    }

    public void OnLanding()
    {
        SetJumpBool(false);
    }

    private void SetJumpBool(bool value)
    {
        animatorOnPlayer.SetBool("isJumping", value);
    }

    private void FixedUpdate()
    {
        characterControllerOnPlayer.Move(horizontalMove * Time.deltaTime, isCrouch, isJump);
        isJump = false;
    }
}
