using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkeletonMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform movePoint;
    public LayerMask WallCollide;
    public Animator anim;
    public float verticalMove = 2.1f;
    public float mUp;
    public bool moveUp = true; //enemies begin moving up
    public bool faceUp = true;
    private LivesCount lives;
    Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        if (!faceUp)
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
                if (moveUp)
                    mUp = 1;
                else //move left, want to check for walls on left side for code below
                    mUp = -1;

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, mUp * verticalMove, 0f), 0.2f, WallCollide))
                {
                    if (moveUp)
                    {
                        movePoint.position += new Vector3(0f, 1 * verticalMove, 0f);
                        anim.Play("Ske_Move");
                        print("up");
                    }
                    else
                    {
                        movePoint.position += new Vector3(0f, 1 * -verticalMove, 0f);
                        anim.Play("Ske_Move");
                        print("down");
                    }


                }
                else
                {
                    FlipFacing();
                    faceUp = !faceUp;
                    moveUp = !moveUp;
                    mUp *= -1;
                    movePoint.position += new Vector3(0f, mUp * verticalMove, 0f);
                    anim.Play("Ske_Move");
                    print("colission");

                }

            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (moveUp)
                    mUp = 1;
                else
                    mUp = -1;

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, mUp * verticalMove, 0f), 0.2f, WallCollide))
                {
                    if (moveUp)
                    {
                        movePoint.position += new Vector3(0f, 1 * verticalMove, 0f);
                        anim.Play("Ske_Move");

                    }
                    else
                    {
                        movePoint.position += new Vector3(0f, 1 * -verticalMove, 0f);
                        anim.Play("Ske_Move");

                    }


                }
                else
                {
                    FlipFacing();
                    moveUp = !moveUp;
                    mUp *= -1;
                    movePoint.position += new Vector3(0f, mUp * verticalMove, 0f);
                    anim.Play("Ske_Move");

                }

            }
            anim.Play("Ske_Idle");
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
            if (lives.lifeCount == 0)
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
