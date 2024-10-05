using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public Vector2 atackDirection;
    public GameObject atackObj;
    public GameObject[] atackObjDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetFaceDirection();
    }

    public void SetFaceDirection()
    {
        atackDirection.x = MovementScript.GetInputDirection().x;
        atackDirection.y = MovementScript.GetInputDirection().y;

        atackDirection = atackDirection.normalized;

        if(atackDirection.y > 0 && atackDirection.x < 0)
            atackObj.transform.position = atackObjDirection[4].transform.position;
        else if(atackDirection.y < 0 && atackDirection.x > 0)
            atackObj.transform.position = atackObjDirection[5].transform.position;
        
        else if(atackDirection.y > 0 && atackDirection.x > 0)
            atackObj.transform.position = atackObjDirection[6].transform.position;
        else if(atackDirection.y < 0 && atackDirection.x < 0)
            atackObj.transform.position = atackObjDirection[7].transform.position;

        else if(atackDirection.y > 0)
            atackObj.transform.position = atackObjDirection[0].transform.position;
        else if(atackDirection.y < 0)
            atackObj.transform.position = atackObjDirection[1].transform.position;

        else if(atackDirection.x > 0)
            atackObj.transform.position = atackObjDirection[2].transform.position;
        else if(atackDirection.x < 0)
            atackObj.transform.position = atackObjDirection[3].transform.position;       
    }
}
