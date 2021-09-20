using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;

    private Vector2 direction;
    private Rigidbody2D rigB;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Implements();        
    }

    // Update is called once per frame
    void Update()
    {        
        Movement();
    }

    public void Movement()
    {
        float verticalMoviment = Input.GetAxis("Vertical");
        float horizontalMoviment = Input.GetAxis("Horizontal");

        direction = new Vector2(horizontalMoviment, verticalMoviment);

        rigB.MovePosition(rigB.position + direction * Speed * Time.deltaTime);

        if (direction != Vector2.zero)
        {
            anim.SetBool("Walking", true);

            if (Input.GetAxis("Horizontal") < 0f)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else if (Input.GetAxis("Horizontal") > 0f)
            {                
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    void Implements ()
    {
        rigB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
}
