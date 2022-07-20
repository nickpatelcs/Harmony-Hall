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
    int finished = 0;
    public TMP_InputField inputField;
    public GameObject inputFieldObj;
    List<string> myList = new List<string>();
    
    void Start()
    {
        txt.text = Current;
        inputFieldObj.SetActive(false);
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
            isActive = true;
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputFieldObj.SetActive(false);
            inputField.DeactivateInputField();
            myList.Add(inputField.text);
            Current = "Click the paintings to hear their music! Think about how the colors and sounds make you feel. Then you will label this section of the museum with the emotion that best represents these art pieces.";
            txt.text = "";
            finished=0;
            player.GetComponent<PlayerMovement>().enabled = true;
        }
        if(player.transform.position.z > 15)
        {
            txt.text = "Your museum is now ready! \n" + "Room 1: " + myList[0] + "\n" + "Room 2: " + myList[1] + "\n" + "Room 3: " + myList[2];
        }
    }

    public void Finished()
    {
        finished=finished+1;
        if(finished==3)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            Current = "Type the emotion that best fits with how these art pieces made you feel in the box below!";
            inputFieldObj.SetActive(true);
            inputField.ActivateInputField();
            txt.text = Current;
            Debug.Log(txt.text);
        }
    }
}
