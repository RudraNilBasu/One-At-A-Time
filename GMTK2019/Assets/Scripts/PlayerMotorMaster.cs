using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotorMaster : MonoBehaviour
{
    Rigidbody2D rb;
    float velocity;

    [SerializeField]
    float bonusGravity;
    [SerializeField]
    bool isGrounded;

    [SerializeField]
    LayerMask layers;

    [SerializeField]
    GameObject p1, p2;

    // Use this for initialization
    void Start()
    {
        // There will always be a Rigidbody2D
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + velocity*Time.fixedDeltaTime);
        rb.velocity = new Vector2(velocity, rb.velocity.y);

        RaycastHit2D p1_hit = Physics2D.Raycast(p1.transform.position, -Vector2.up, 5000, layers);
        RaycastHit2D p2_hit = Physics2D.Raycast(p2.transform.position, -Vector2.up, 5000, layers);
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 5000, layers);
        if ((p1_hit.distance < 0.9f && p1_hit.collider != null) || (p2_hit.distance < 0.9f && p2_hit.collider != null))
        {
            // print("We hit: "+hit.collider.gameObject.name+" distance: "+hit.distance);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (!isGrounded)
        {
            Vector3 vel = rb.velocity;
            vel.y -= bonusGravity * Time.deltaTime;
            rb.velocity = vel;
        }
    }

    public void MoveBody(float _velocity)
    {
        velocity = _velocity;
    }

    public void jump(float jumpForce)
    {
        if (isGrounded)
        {
            if (rb.bodyType == RigidbodyType2D.Kinematic)
                rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.AddForce(new Vector2(0f, jumpForce * 100));
        }
    }

    public bool CheckGrounded()
    {
        return isGrounded;
    }
}
