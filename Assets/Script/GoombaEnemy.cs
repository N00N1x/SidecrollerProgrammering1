using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaEnemy : MonoBehaviour
{
    public int HP = 0;
    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;

        if (HP < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    //Reference to the physics system component
    public Rigidbody2D myRigidBody = null;

    public float MovementSpeedPerSecond = 10.0f;
    public float MovementSign = 1.0f;



    void FixedUpdate()
    {
        //Copy Character Velocity From rigidbody
        Vector3 characterVelocity = myRigidBody.velocity;
        //Set Character XVelocity to zero
        characterVelocity.x = 0;

        //Add velocity in character right direction
        characterVelocity += MovementSign * MovementSpeedPerSecond * transform.right.normalized;

        //Copy modified velocity back onto rigidbody
        myRigidBody.velocity = characterVelocity;


    }
}