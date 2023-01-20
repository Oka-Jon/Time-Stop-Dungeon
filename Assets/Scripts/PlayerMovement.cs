using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform movePoint;
    public LayerMask WallCollide;
    public Animator anim;
    public bool FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        

        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {
            if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                if (FacingRight) { }

                else
                {
                    FlipFacing();
                    FacingRight = true;
                }

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.3f, WallCollide))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * 1.47f, 0f, 0f);
                    anim.Play("Adv_Move");
                  
                }

            }

            else if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                if (FacingRight)
                {
                    FlipFacing();
                    FacingRight = false;
                }

                else { }
                
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.3f, WallCollide))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * 1.47f, 0f, 0f);
                    anim.Play("Adv_Move");

                }

            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.3f, WallCollide))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * 2.1f, 0f);
                    anim.Play("Adv_Move");
                   
                }
            }
            anim.Play("Adv_Idle");
        }
       
        
    }
    void FlipFacing()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1.0f;
        transform.localScale = tempScale;
    }
}
