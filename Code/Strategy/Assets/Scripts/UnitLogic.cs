using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLogic : MonoBehaviour
{
    //Yksikköjen logiikka
    //Hipat, liikkuminen voima yms, voidaan hakea jossain vaiheessa databasesta

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnMouseDown()
    {
        Debug.Log("Unit");
        //Ilmoitetaan battlelogikille mitä gameobjectia on klikattu (ja millä napilla)
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}