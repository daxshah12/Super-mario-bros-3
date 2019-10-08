using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Audio;

public class Playermovement : MonoBehaviour
{

    public int playerspeed = 10;
    private bool facingRight = false;
    public int playerjumpPower = 750;
    private float moveX;
    public Playermovement player;

    public Animator animator;

    AudioSource jumpsound;

    AudioManager Coins;

    RaycastHit2D hitRay;
    private bool isTouchingGround;

    //private bool walk, walk_left, walk_right, jump;
    //public enum PlayerState
    //{

    //    jumping,
    //    idle,
    //    walking
    //}

    //private bool grounded = false;
    //private PlayerState playerstate = PlayerState.idle;


    public Vector3 startposition;

    bool jump = false;
    bool crouch = false;
    //  public GameManager theGameManager;

    // public Animator animator;

 

    



    // Start is called before the first frame update
    void Start()
    {
        jumpsound = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Playermove();

        animator.SetFloat("Speed", Mathf.Abs(moveX));

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("HI");
            jump = true;
            animator.SetBool("isJumping", true);
        }

       

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "killbox")
    //    {
    //        theGameManager.RestartGame();
    //    }
    //}
  

    void Playermove()
    {
       // FindObjectOfType<AudioManager>().Play("level Theme Song");

        if (player.transform.position.y  < 7.0)
        {
            print("HI");
            this.transform.position = startposition;
        }
        //controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
           
        }
        //Animations
        //player Direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
       // transform.position = startposition;

    }

   
  

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    //void UpdateAnimation()
    //{ 
    //    if(grounded && walk )
    //    {
    //        GetComponent<Animator>().SetBool("isJumping", false);
    //        GetComponent<Animator>().SetBool("isRunning", false);
    //    }

    //    if(grounded && walk)
    //    {
    //        GetComponent<Animator>().SetBool("isJumping", false);
    //        GetComponent<Animator>().SetBool("isRunning", false);
    //    }

    //    if(playerstate == PlayerState.jumping)
    //    {
    //        GetComponent<Animator>().SetBool("isJumping", true);
    //        GetComponent<Animator>().SetBool("isRunning", false);
    //    }
    //}

    void Jump()
    {

        jumpsound.Play();
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerjumpPower);

        
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
           
            other.gameObject.SetActive(false);
            ScoreCounter.scoreValue += 1;
            Coins.Play("Coins");
        }

        if(other.gameObject.CompareTag("Block"))
        {
            other.gameObject.SetActive(false);
            Coins.Play("Coins");
        }

        //if(other.gameObject.CompareTag("killbox"))
        //{
        //    print("HI");
        //    startposition = transform.position;
        //}
    }

           
        

}


    //private Vector3 CheckCeilingRays(Vector3 pos)
    // {
    //     RaycastHit2D ceilLeft = Physics2D.Raycast(original, Vecotr2.up, Velocity)

    //     RaycastHit2D hitRay = ceilLeft;
    // }



