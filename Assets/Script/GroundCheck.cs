using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PhysicsCharacter myCharacterController = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myCharacterController.JumpingState = CharacterState.Grounded;
    }
}
