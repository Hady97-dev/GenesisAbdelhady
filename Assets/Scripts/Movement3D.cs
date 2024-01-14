using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Movement3D : MonoBehaviour
{
    public float mainSpeed = 1.0f; //regular speed
    public float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    public float maxShift = 1000.0f; //Maximum speed when holdin gshift
    public float camSens = 0.25f; //How sensitive it with mouse
    public bool invertY = true;

    public float scrollWheelSens = 1f;

    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;
    public Animator anim;

    public GameObject BedInterface;
    public GameObject ATMInterface;
    public GameObject FirstShopKpsInterface;
    public GameObject SecondShopKpsInterface;
    

    public Canvas canvas;
    public GameManager gameManager;
    


    void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("IsWalking", false);
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            var mouseMoveY = invertY ? -1 * Input.GetAxis("Mouse Y") : Input.GetAxis("Mouse Y");
            var mouseMoveX = Input.GetAxis("Mouse X");

            var mouseMove = new Vector3(mouseMoveY, mouseMoveX, 0) * camSens;
            transform.eulerAngles = transform.eulerAngles + mouseMove;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals ("Bed") == true)
        {
            BedInterface.SetActive(true);
           
        }
        
        
        if (collision.collider.tag.Equals("ATM") == true)
        {
            ATMInterface.SetActive(true);

        }
        
        
        if (collision.collider.tag.Equals("Table") == true)
        {
            FirstShopKpsInterface.SetActive(true);


        }
        
        
        if (collision.collider.tag.Equals("Table2") == true)
        {
            SecondShopKpsInterface.SetActive(true);

        }
        
        

    }
    public void OnCollisionExit(Collision collision)
    {
         if (collision.collider.tag.Equals("Bed")== true)
        {
            BedInterface.SetActive(false);
        }

         if (collision.collider.tag.Equals("ATM") == true)
        {
            ATMInterface.SetActive(false);
        }

         if (collision.collider.tag.Equals("Table") == true)
        {
            FirstShopKpsInterface.SetActive(false);
        }

         if (collision.collider.tag.Equals("Table2") == true)
        {
            SecondShopKpsInterface.SetActive(false);
        }
    }

    
    public void SleepButoon()
    {
        anim.SetBool("IsLaying", true);
        
        gameObject.transform.position = new Vector3(12.5f, 0.8f, 2.25f);
        gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, 180);
        BedInterface.SetActive(false);
        canvas.gameObject.SetActive(false);
        gameManager.FadeInImage.SetActive(true);
        gameManager.WakeUpButton.SetActive(true);


    }




    //Mouse  camera angle done.  

    /* //Keyboard commands
     float f = 0.0f;
     Vector3 p = GetBaseInput();
     if (p.sqrMagnitude > 0)
     { // only move while a direction key is pressed
         if (Input.GetKey(KeyCode.LeftShift))
         {
             totalRun += Time.deltaTime;
             p = p * totalRun * shiftAdd;
             p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
             p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
             p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
         }
         else
         {
             totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
             p = p * mainSpeed;
         }

         p = p * Time.deltaTime;
         Vector3 newPosition = transform.position;
         if (Input.GetKey(KeyCode.Space))
         { //If player wants to move on X and Z axis only
             transform.Translate(p);
             newPosition.x = transform.position.x;
             newPosition.z = transform.position.z;
             transform.position = newPosition;
         }
         else
         {
             transform.Translate(p);
         }
     }

     var scroll = Input.GetAxis("Mouse ScrollWheel");
     mainSpeed += scroll * scrollWheelSens;








     }*/

    /*private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
         if (Input.GetKey(KeyCode.W))
            {
            p_Velocity += new Vector3(0, 0, 1);
                anim.SetBool("IsWalking", true);

            }
            else
            {
                anim.SetBool("IsWalking", false);
            }

         if (Input.GetKey(KeyCode.S))
           {
            p_Velocity += new Vector3(0, 0, -1);
                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }

          if (Input.GetKey(KeyCode.A))
            {
            p_Velocity += new Vector3(-1, 0, 0);
                anim.SetBool("IsWalking", true);
            }

            else
            {
                anim.SetBool("IsWalking", false);
            }

          if (Input.GetKey(KeyCode.D))
            {
            p_Velocity += new Vector3(1, 0, 0);
                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }


            return p_Velocity;
    } */



}
 