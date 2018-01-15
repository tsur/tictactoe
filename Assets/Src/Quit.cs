using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            QuitGame();
        }
            
    }

    void OnMouseDown()
    {
        QuitGame();
    }

    void QuitGame()
    {
        // @todo provide some save game state logic here ...

        // Quit the app
        Application.Quit();
    }
}
