﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualPlayerMotor : MonoBehaviour
{
    public GameObject player1, player2;
    float p1_velocity, p2_velocity;

    [SerializeField]
    float bonusGravity;
    [SerializeField]
    bool isP1Grounded, isP2Grounded;

    [SerializeField]
    LayerMask layers;

    Rigidbody2D p1_rb, p2_rb;
    // Start is called before the first frame update
    void Start()
    {
        p1_rb = player1.GetComponent<Rigidbody2D>();
        p2_rb = player2.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // player's has collided in the left side and it's p1_velocity is negative
        float common_x_velocity = 0.0f; 
        if ((p1_rb.velocity.x == 0 && p1_velocity != 0) || (p2_rb.velocity.x == 0 && p2_velocity != 0)) {
            common_x_velocity = 0.0f;
        } else if (p1_velocity != p2_velocity) {
            Debug.LogError("P1 and P2  X velocities are different: " + p1_velocity + " , " + p2_velocity);
        } else {
            common_x_velocity = p1_velocity;
        }
        p1_rb.velocity = new Vector2(common_x_velocity, p1_rb.velocity.y);
        p2_rb.velocity = new Vector2(common_x_velocity, p2_rb.velocity.y);
        // p1_rb.velocity = new Vector2(p1_velocity, p1_rb.velocity.y);
        // p2_rb.velocity = new Vector2(p2_velocity, p2_rb.velocity.y);

        RaycastHit2D p1_hit = Physics2D.Raycast(player1.transform.position, -Vector2.up, 5000, layers);
        if (p1_hit.distance < 0.9f && p1_hit.collider != null)
        {
            // print("We hit: "+hit.collider.gameObject.name+" distance: "+hit.distance);
            isP1Grounded = true;
        }
        else
        {
            isP1Grounded = false;
        }

        RaycastHit2D p2_hit = Physics2D.Raycast(player2.transform.position, -Vector2.up, 5000, layers);
        if (p2_hit.distance < 0.9f && p2_hit.collider != null)
        {
            // print("We hit: "+hit.collider.gameObject.name+" distance: "+hit.distance);
            isP2Grounded = true;
        }
        else
        {
            isP2Grounded = false;
        }

        if (!isP1Grounded)
        {
            Vector3 p1_vel = p1_rb.velocity;
            p1_vel.y -= bonusGravity * Time.deltaTime;
            p1_rb.velocity = p1_vel;
        }

        if (!isP2Grounded)
        {
            Vector3 p2_vel = p2_rb.velocity;
            p2_vel.y -= bonusGravity * Time.deltaTime;
            p2_rb.velocity = p2_vel;
        }
    }

    public void MoveBody(int _id, float _velocity)
    {
        if (_id == 1) {
            p1_velocity = _velocity;
        } else {
            p2_velocity = _velocity;
        }
    }

    public void jump(int _id, float jumpForce)
    {
        if (_id == 1) {
            if (isP1Grounded)
            {
                if (p1_rb.bodyType == RigidbodyType2D.Kinematic)
                    p1_rb.bodyType = RigidbodyType2D.Dynamic;
                p1_rb.velocity = new Vector2(p1_rb.velocity.x, jumpForce);
                //rb.AddForce(new Vector2(0f, jumpForce * 100));
            }
        }
        else {
            if (isP2Grounded)
            {
                if (p2_rb.bodyType == RigidbodyType2D.Kinematic)
                    p2_rb.bodyType = RigidbodyType2D.Dynamic;
                p2_rb.velocity = new Vector2(p2_rb.velocity.x, jumpForce);
                //rb.AddForce(new Vector2(0f, jumpForce * 100));
            }
        }
    }
}
