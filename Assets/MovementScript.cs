using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D Rb;

    [Header ("Walk Settings")]
    public float walkSpeed;
    public float sprintSpeed;
    private float actualSpeed;

    [Header ("Dash Settings")]
    public float dashForce;
    public float deshDelay;
    private bool canDash;
    private float deshDelayCurrent;
    // Start is called before the first frame update

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GetInputDash();
    }

    public static Vector2 GetInputDirection()
    {
        float x;
        float y;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(x, y);

        return direction;
    }

    public void Move()
    {
        if(Input.GetKey(KeyCode.LeftShift))
            actualSpeed = sprintSpeed;
        else
            actualSpeed = walkSpeed;
            
        Rb.AddForce(GetInputDirection() * actualSpeed, ForceMode2D.Force);
    }

    public void GetInputDash()
    {
        deshDelayCurrent -= Time.deltaTime;

        if(deshDelayCurrent <= 0)
        {
            canDash = true;
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(canDash)
            {
                Dash();
                canDash = false;
                deshDelayCurrent = deshDelay;
            }
        }
    }

    public void Dash()
    {
        Rb.AddForce(GetInputDirection() * dashForce, ForceMode2D.Impulse);
    }

}
