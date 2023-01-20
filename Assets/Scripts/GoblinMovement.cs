using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GoblinMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform movePoint;
    public LayerMask WallCollide;
    public Animator anim;
    public float horizontalMove = 1.47f;
    public float mRight;
    public bool moveRight = true; //enemies begin moving towards the right
    public bool faceRight = true;
    private LivesCount lives;
    Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        if (!faceRight)
            FlipFacing();
        lives = GameObject.Find("LivesCount").GetComponent<LivesCount>();
        lifeText = GameObject.Find("LivesText").GetComponent<Text>();
        lifeText.text = "Lives: " + lives.lifeCount;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (moveRight)
                    mRight = 1;
                else //move left, want to check for walls on left side for code below
                    mRight = -1;

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(mRight * horizontalMove, 0f, 0f), 0.2f, WallCollide))
                {
                    if (moveRight)
                    {
                        movePoint.position += new Vector3(1 * horizontalMove, 0f, 0f);
                        anim.Play("Gob_Move");
                        
                    }
                    else
                    {
                        movePoint.position += new Vector3(1 * -horizontalMove, 0f, 0f);
                        anim.Play("Gob_Move");
                        
                    }


                }
                else
                {
                    FlipFacing();
                    faceRight = !faceRight;
                    moveRight = !moveRight;
                    mRight *= -1;
                    movePoint.position += new Vector3(mRight * horizontalMove, 0f, 0f);
                    anim.Play("Gob_Move");
                   
                }

            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (moveRight)
                    mRight = 1;
                else
                    mRight = -1;

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(mRight * horizontalMove, 0f, 0f), 0.2f, WallCollide))
                {
                    if (moveRight)
                    {
                        movePoint.position += new Vector3(1 * horizontalMove, 0f, 0f);
                        anim.Play("Gob_Move");
                        
                    }
                    else
                    {
                        movePoint.position += new Vector3(1 * -horizontalMove, 0f, 0f);
                        anim.Play("Gob_Move");
                       
                    }


                }
                else
                {
                    FlipFacing();
                    moveRight = !moveRight;
                    mRight *= -1;
                    movePoint.position += new Vector3(mRight * horizontalMove, 0f, 0f);
                    anim.Play("Gob_Move");
                    
                }

            }
            anim.Play("Gob_Idle");
        }


    }

    void FlipFacing()
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1.0f;
        transform.localScale = tempScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            lives.lifeCount -= 1;
            lifeText.text = "Lives: " + lives.lifeCount;
            print("Dead");
            if(lives.lifeCount == 0)
            {
                SceneManager.LoadScene("StartScreen");
                print("out of lives");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
        
    }
}
