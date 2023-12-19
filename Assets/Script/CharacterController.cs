using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public enum CharacterState // A enumerated list of character states
{
    Grounded = 0, //Is on the ground
    Airborne = 1, // Is in the air
    Jumping = 2, // Is when jumping
    Total
}

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D myRigidbody = null;

    public CharacterState JumpingState = CharacterState.Airborne;

    //Gravity
    public float GravityPerSecond = 160.0f; //Falling Speed
    public float GroundLevel = 0.0f; //Ground Value

    //Jump
    public float JumpSpeedFactor = 3.0f; // How much faster is 
    public float JumpHeightDelta = 0.0f;
    public float JumpMaxHeight = 100.0f;


    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed

    void Update()
    {
        bool IsMoving = false; // Tells us if character is moving
        //Gravity 

        
        if (transform.position.y <= GroundLevel) //Check if character is lower than or equal to ground
            {
                Vector3 characterPosition = transform.position;
                characterPosition.y = GroundLevel;
                transform.position = characterPosition;
            JumpingState = CharacterState.Grounded;
            }

        //Up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping; //Set character jumping
            JumpHeightDelta = 0.0f; //Restart Counting Jumpdistance
        }
        if (JumpingState == CharacterState.Jumping)
        {
            Vector3 characterPosition = transform.position;
            float totalJumpMovementThisFrame = MovementSpeedPerSecond* JumpSpeedFactor* Time.deltaTime;
            characterPosition.y += totalJumpMovementThisFrame;
            transform.position = characterPosition;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if(JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }
        }

        //Down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }

        if (JumpingState == CharacterState.Airborne)
        {
            Vector3 gravityPosition = transform.position; //Copy Character Pos
            gravityPosition.y -= GravityPerSecond * Time.deltaTime; //Subtract Gravity*Deltatime

            if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; } //Set Character To ground level

            transform.position = gravityPosition; //Assign New Pos to transform
        }
    }
}

// Vector3 characterPosition = transform.position; //Copy Character Position
// characterPosition.y += MovementSpeedPerSecond * Time.deltaTime; //Add Movementspeed * Time for Frame
// transform.position = characterPosition; //Assign New position
// IsMoving = true; // Setting this to true means no gravity