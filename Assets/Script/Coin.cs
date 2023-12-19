using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public PlayerData Savefile = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacter>();
        if (PlayerScript != null)
        {
            Savefile.PlayerPoints += 1;
            GameObject.Destroy(gameObject);
        }
    }
}