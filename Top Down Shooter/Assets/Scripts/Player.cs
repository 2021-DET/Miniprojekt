using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float speed = 10f;
   
   public float rotSpeed = 2f;

   public float jumpPush = 5f;

   public float extraGravity = -10f;

   private Vector3 moveVector;

   private Vector3 rotVector;

   private Rigidbody rd;

   private Animator anim;

   //private bool onGround = false;

    void Start()
    {

        rd = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Vertical") != 0)
        {
            anim.SetInteger("Anim" , 1);
        }
        else
        {
            anim.SetInteger("Anim" , 0);
        }


        float xDir = Input.GetAxis("Vertical") * speed * Time.deltaTime ;
        float yDir = Input.GetAxis("Horizontal") * rotSpeed  ;

        //anim.SetFloat("forwar", xDir);

        moveVector = new Vector3 ( 0 , 0 , xDir );
        rotVector   = new Vector3(0 , yDir , 0);

        transform.Rotate(rotVector);
        transform.Translate(moveVector);

        // Springen 

        //RaycastHit hitInfo;
        
        //onGround = Physics.Raycast(transform.position + (Vector3.up * 0.1f) , Vector3.down , out hitInfo , 0.1f);
        if(Input.GetAxis("Jump") > 0f  )
        {
            Vector3 power = rd.velocity;
            power.y = jumpPush;
            rd.velocity = power;
        }
        rd.AddForce (new Vector3 ( 0f , extraGravity , 0f ));


    }
}
