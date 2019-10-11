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
    private GameObject[] PlayerUnits;
    public Tilemap map;
    public Tilemap units;
    private TileBase gridSelectedUnit = null;
    // Start is called before the first frame update
    void Start()
    {
        PlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftMouseClick(Vector3 clickedGrid)
    {
        if (gridSelectedUnit == null)
        {
            UpdateSelectionInfo(Vector3Int.FloorToInt(clickedGrid));
        }

        else
        {
            RemoveUnitSelection();
        }
            
    }
    void UpdateSelectionInfo(Vector3Int grid)
    {
        /*Find a bette way to do this (Unit selection from grid)
         * MapToWorld might be unnecessary
         * List of units cumbersome? Just chek if the tile has object (SOmekind of struct for tile that holds pointer to occupying unit?)
        */
        //foreach (var unit in PlayerUnits)
        //{
        //    if (map.WorldToCell(unit.transform.position) == grid)
        //    {
        //        Debug.Log(unit);
        //        selectedUnit = unit;
        //        UnitUI.GetComponent<Image>().sprite = unit.GetComponent<SpriteRenderer>().sprite;
        //        Color tempColor = UnitUI.GetComponent<Image>().color;
        //        tempColor.a = 1f;
        //        UnitUI.GetComponent<Image>().color = tempColor;
        //        UnitUI.GetComponentInChildren<Text>().text = unit.name;
        //        break;
        //    }
        //}
        if (units.GetTile(Vector3Int.FloorToInt(grid)) != null)
        {
            gridSelectedUnit = units.GetTile(grid);
            UnitUI.GetComponent<Image>().sprite = units.GetSprite(grid);
            Color tempColor = UnitUI.GetComponent<Image>().color;
            tempColor.a = 1f;
            UnitUI.GetComponent<Image>().color = tempColor;
            UnitUI.GetComponentInChildren<Text>().text = units.GetTile(Vector3Int.FloorToInt(grid)).name;
        }

    }
    void RemoveUnitSelection()
    {
        gridSelectedUnit = null;
        UnitUI.GetComponent<Image>().sprite = null;
        Color tempColor = UnitUI.GetComponent<Image>().color;
        tempColor.a = 0f;
        UnitUI.GetComponent<Image>().color = tempColor;
        UnitUI.GetComponentInChildren<Text>().text = "";
    }
}
