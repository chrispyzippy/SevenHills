using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovemnets : MonoBehaviour
{
    public float speed;
   private Rigidbody rb;
   public float jumpForce;
   public LayerMask groundLayers;
   public SphereCollider col;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        col = GetComponent<SphereCollider>();  
    }

    // Update is called once per frame
    void Update()
    {
         if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * jumpForce;
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal") * Time.deltaTime * speed;
        float moveVertical = Input.GetAxisRaw ("Vertical") * Time.deltaTime * speed;

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
       
       rb.AddForce (movement * speed);

        
     }
     private bool isGrounded()
    {
       return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
           col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }


}

