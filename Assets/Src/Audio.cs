using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
    
	void Awake () {

        // Audio is by default destroyed once the GameObject loads
        // It prevents that behaviour so it can play in a loop
        DontDestroyOnLoad(transform.gameObject);
	}
}
