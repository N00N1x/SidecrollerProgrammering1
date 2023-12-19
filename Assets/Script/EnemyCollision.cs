using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GoombaEnemy myEnemyScript = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Copy Enemy Scale
        Vector3 enemyScale = myEnemyScript.transform.localScale;
        //Multiply X-scale by -1;
        enemyScale.x = -enemyScale.x;
        //Write scale back into transfrom
        myEnemyScript.transform.localScale = enemyScale;
        //Multiply enemy movement Direction by -1 so -1 = 1/1 = -1
        myEnemyScript.MovementSign *= -1;
    }
}