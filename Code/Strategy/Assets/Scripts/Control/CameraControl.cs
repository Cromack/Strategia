using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    private float xAxis;
    private float yAxis;
    private Camera cam;
    public float zAxis;

    //The speed at which the camera moves
    public float moveSpeed = 5;
    public float scrollSpeed = 2;
    public float minZoom = 1;
    public float maxZoom = 15;
    private Vector3Int gridPosition;

    public GameObject UnitUI;
    //Do this better later (dynamically?)
    public Tilemap map;
    public GameObject[] PlayerUnits; //Move to a better place later? (Some kind of game logic script?)

    void Start()
    {
        cam = Camera.main;
        PlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

    }

    void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        gridPosition = map.WorldToCell(point);

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.Label("Grid position: " + gridPosition.ToString("F3"));
        GUILayout.EndArea();
    }

    void Update()
    {
        mouseClicks();
    }

    void mouseClicks()
    {
        if (Input.GetMouseButton(0))
        {
            foreach (var unit in PlayerUnits)
            {
                if (map.WorldToCell(unit.transform.position) == gridPosition)
                {
                    Debug.Log(unit);
                    UnitUI.GetComponent<Image>().color = Color.red;
                    UnitUI.GetComponentInChildren<Text>().text = unit.name;
                    break;
                }
            }
        }
    }
    // The camera movement is done with the input manager (WASD and arrow keys by default)
    void LateUpdate()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        zAxis = Input.GetAxis("Mouse ScrollWheel");
        transform.position += new Vector3(xAxis, yAxis, 0) * Time.deltaTime * moveSpeed;


        Camera.main.orthographicSize -= zAxis * scrollSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
    }
}
