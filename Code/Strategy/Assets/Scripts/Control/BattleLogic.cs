using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BattleLogic : MonoBehaviour
{

    /*Script for the turn based battle logic
     TODO:
     -Unit selection
     -Movement
     -UI updating
     -Pathfinding?
     -List of player and enemy units?
     other potential stuff
    */

    private GameObject selectedUnit = null;
    public GameObject UnitUI;
    public Tilemap map;

    private Dictionary<Vector3Int, GameObject> UnitPositions;
    // Start is called before the first frame update
    void Start()
    {
        UnitPositions = new Dictionary<Vector3Int, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftMouseClick(Vector3 clickedGrid)
    {
            
    }
    void UpdateSelectionInfo(Vector3 Grid)
    {

    }

    public void UnitClicked(GameObject clickedUnit)
    {
        //Parempi hakea sijainnin perusteella dictistä? Onko suurta väliä, Dictistä haku takaa "oikean" tiedon
        Debug.Log(clickedUnit.name);
        if(clickedUnit.tag == "PlayerUnit")
        {
            selectedUnit = clickedUnit;
            updateUnitUI();//vai ifhäkkyrän ulkopuolelle/aina kun selectedUnit vaihtuu
        }
    }

    public void unitPosition(Vector3 position, GameObject unit)
    {
        //Add and update unit positions
        Vector3Int gridPosition = map.WorldToCell(position);
        UnitPositions.Add(gridPosition, unit);
        Debug.Log(gridPosition);

    }

    void updateUnitUI()
    {
        UnitUI.GetComponent<Image>().sprite = selectedUnit.GetComponent<SpriteRenderer>().sprite;
        Color tempColor = UnitUI.GetComponent<Image>().color;
        tempColor.a = 1f;
        UnitUI.GetComponent<Image>().color = tempColor;
        UnitUI.GetComponentInChildren<Text>().text = selectedUnit.name;
    }
    void RemoveUnitSelection()
    {
        selectedUnit = null;
        UnitUI.GetComponent<Image>().sprite = null;
        Color tempColor = UnitUI.GetComponent<Image>().color;
        tempColor.a = 0f;
        UnitUI.GetComponent<Image>().color = tempColor;
        UnitUI.GetComponentInChildren<Text>().text = "";
    }

    public void mapClicked(Vector3 clickedLocation, string button)
    {

        Vector3Int clickedGrid = map.WorldToCell(Camera.main.ScreenToWorldPoint(clickedLocation));
        if (selectedUnit != null)
        {
            switch (button)
            {
                case "left":
                    RemoveUnitSelection();
                    break;
                case "right":
                    //TODO: Add movement code
                    Debug.Log("Liiku tänne:" + clickedGrid);
                    UnitMovement(clickedGrid);
                    break;
            }
        }
    }

    void UnitMovement(Vector3Int finalPosition)
    {
        //Todo: Check if finallocation is empty, A* algorithm for movement etc

        selectedUnit.transform.position = map.CellToWorld(finalPosition);

    }
}
