using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHit : MonoBehaviour {

    Game Script;
    public GameObject Camera;
    public int id;

    void Awake()
    {
        Script = Camera.GetComponent<Game>();
    }

    void OnMouseDown()
    {
        Script.drawCell(gameObject, id);
    }
}
