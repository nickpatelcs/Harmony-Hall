using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TxtScript : MonoBehaviour
{
    public TextMeshProUGUI txt;
    string Current = "Welcome to your Mueseum! As a curator, your first job is to design each exhibit. To do this, you will need to connect each art piece with emotions and how they make you feel.\n(Press Space to show/hide)";
    public GameObject player;
    bool isActive = false;
    
    void Start()
    {
        txt.text = Current;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(txt.text == "")
            {
                txt.text = Current;
            }
            else
            {
                txt.text = "";
            }
        }
        if(player.transform.position.x < -5 && !isActive)
        {
            Current = "Click the paintings to hear their music! Think about how the colors and sounds make you feel. Then you will label this section of the museum with the emotion that best represents these art pieces.";
            txt.text = Current;
            isActive = false;
        }
    }
}
