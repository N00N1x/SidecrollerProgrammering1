using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int AddHealth = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacter>();

        if (PlayerScript != null )
        {  
            PlayerScript.HP += AddHealth; 
            AddHealth = 0;
            GameObject.Destroy(gameObject);
        }
    }
}
