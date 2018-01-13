using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDone : MonoBehaviour {

    Game Script;
    public GameObject Camera;

    void Awake()
    {
        Script = Camera.GetComponent<Game>();
    }

    void OnMouseDown()
    {
        Script.reset();
    }
}
