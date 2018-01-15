using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHit : MonoBehaviour {

    Game gameScript;
    public GameObject Camera;
    public int id;

    void Awake()
    {
        // Get a reference to the main Game Script 
        gameScript = Camera.GetComponent<Game>();
    }

    void OnMouseDown()
    {
        // Draw it
        gameScript.drawCell(gameObject, id);
    }
}
