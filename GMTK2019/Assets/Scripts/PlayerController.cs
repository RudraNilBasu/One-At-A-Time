﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    float moveSpeed, jumpSpeed;

    [SerializeField]
    int player_id;

    [SerializeField]
    DualPlayerMotor motor;
    // PlayerMotor motor;

    private Vector2 touchOrigin = -Vector2.one;

    private bool btn_left_pressed, btn_right_pressed;

    // Use this for initialization
    void Start()
    {
        btn_left_pressed = false;
        btn_right_pressed = false;
        if (motor == null) {
            Debug.LogError("Dual Player motor not found");
        }
        // motor = gameObject.GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedX = 0.0f;
        // these were necessary for webgl build
        // speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;// * Time.deltaTime;
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
            // motor.jump(jumpSpeed);
        // }
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;// * Time.deltaTime;
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        /*
        if (Input.touchCount == 1) {
            Touch touchInput = Input.touches[0];
            if (touchInput.position.x < Screen.width / 2) {
                speedX = -1 * moveSpeed;
            } else {
                speedX = 1 * moveSpeed;
            }
        }
        */
        if (!(btn_left_pressed && btn_right_pressed)) {
            if (btn_left_pressed) {
                speedX = -1;
            } else if (btn_right_pressed) {
                speedX = 1;
            } else {
                speedX = 0;
            }
        }
        speedX *= moveSpeed;
#endif

        motor.MoveBody(player_id, speedX);
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetKeyDown(KeyCode.Space))
        {
            motor.jump(player_id, jumpSpeed);
        }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        /*
        if (Input.touchCount == 2) {
            motor.jump(jumpSpeed);
        }
        */
        if (btn_left_pressed && btn_right_pressed) {
            motor.jump(player_id, jumpSpeed);
        }
#endif
    }

    public void btn_left_press_down()
    {
        btn_left_pressed = true;
    }

    public void btn_left_press_up()
    {
        btn_left_pressed = false;
    }

    public void btn_right_press_down()
    {
        btn_right_pressed = true;
    }

    public void btn_right_press_up()
    {
        btn_right_pressed = false;
    }

}
