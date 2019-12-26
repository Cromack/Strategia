using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLogic : MonoBehaviour
{

    public BattleLogic battleLogic;
    
    // Start is called before the first frame update
    void Start()
    {
        battleLogic = GameObject.Find("Main Camera").GetComponent<BattleLogic>();
    }

 

    public void OnMouseOver()
    {
        //Which button is used to press the map
        if (Input.GetButtonDown("LeftClick"))
        {
            Vector3 point = Input.mousePosition;
            battleLogic.mapClicked(point, "left");
        }
        else if (Input.GetButtonDown("RightClick"))
        {
            Vector3 point = Input.mousePosition;
            battleLogic.mapClicked(point, "right");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
