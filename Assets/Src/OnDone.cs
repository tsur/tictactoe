using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDone : MonoBehaviour {

    Game gameScript;
    public GameObject Camera;

    void Awake()
    {
        // Get a reference to the main Game Script 
        gameScript = Camera.GetComponent<Game>();
    }

    void OnMouseDown()
    {
        gameScript.reset();
    }
}
