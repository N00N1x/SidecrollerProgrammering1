using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    public bool IsPlayer = false;

    public int DamageValue = -1;
    public bool DealtDamageLastFrame = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DealtDamageLastFrame == true)
        {
            DealtDamageLastFrame = false;
            return;
        }
        if (IsPlayer)
        {
            var enemyScript = collision.gameObject.GetComponent<GoombaEnemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(DamageValue);
                DealtDamageLastFrame = true;
            }
        }
        else
        {
            var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacter>();
            if (PlayerScript != null)
            {
                PlayerScript.TakeDamage(DamageValue);
                DealtDamageLastFrame = true;

            }

        }
    }
}