using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO Optional: Rename to CollsionScript
public class Block : MonoBehaviour
{
    //x = Width , y = Height
    public Vector2 Dimensions = new Vector2(16.0f, 16.0f);
    //Position of the lower Left corner of the object
    public Vector2 LowerLeftCorner = new Vector2();
    void Update()
    {
        //Update the position of the lower left corner every frame
        LowerLeftCorner = new Vector2(transform.position.x - (Dimensions.x * 0.5f),
            transform.position.y - (Dimensions.y * 0.5f));
    }
    public static bool CheckCollision(Block aObject1, Block aObject2)
    {
        //Is Object1 left corner smaller than Object 2 right corner?
        if (aObject1.LowerLeftCorner.x < aObject2.LowerLeftCorner.x + aObject2.Dimensions.x &&
            //Is Object1 Right corner Bigger than Object 2 Left corner?
            aObject1.LowerLeftCorner.x + aObject1.Dimensions.x > aObject2.LowerLeftCorner.x &&
            //Is Object1 bottom less tall than Object 2 top?
            aObject1.LowerLeftCorner.y < aObject2.LowerLeftCorner.y + aObject2.Dimensions.y &&
            //Is Object1 top taller than Object 2 bottom?
            aObject1.LowerLeftCorner.y + aObject2.Dimensions.y > aObject2.LowerLeftCorner.y)
        {
            return true;
        }
        return false;
    }


}