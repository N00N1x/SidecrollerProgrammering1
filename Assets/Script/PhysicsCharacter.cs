using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PhysicsCharacter : MonoBehaviour
{
    public int HP = 1;

    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;
    }

    public Rigidbody2D myRigidBody = null;

    public CharacterState JumpingState = CharacterState.Airborne;

    //Gravity
    public float GravityPerSecond = 10.0f; //Falling Speed
    public float GroundLevel = 0.0f; //Ground Value

    //Jump
    public float JumpSpeedFactor = 2.0f; // How much faster is 
    public float JumpHeightDelta = 0.0f;
    public float JumpMaxHeight = 4.0f;


    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed

    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0f;

     
        //Up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            Debug.Log("Should be jumping");
            JumpingState = CharacterState.Jumping; //Set character jumping
            JumpHeightDelta = 0.0f; //Restart Counting Jumpdistance
        }
        if (JumpingState == CharacterState.Jumping)
        {

            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y += totalJumpMovementThisFrame;
            JumpHeightDelta += totalJumpMovementThisFrame;

            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
                characterVelocity.y = 0f;
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
            characterVelocity.x -= MovementSpeedPerSecond;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        myRigidBody.velocity = characterVelocity;
    }
}

// Vector3 characterPosition = transform.position; //Copy Character Position
// characterPosition.y += MovementSpeedPerSecond * Time.deltaTime; //Add Movementspeed * Time for Frame
// transform.position = characterPosition; //Assign New position
// IsMoving = true; // Setting this to true means no gravity