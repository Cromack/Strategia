using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLogic : MonoBehaviour
{

    public BattleLogic Logic;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.Find("Main Camera").GetComponent<BattleLogic>();
    }


    private void OnMouseDown()
    {
        Debug.Log("Unit");
        Logic.UnitClicked(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
