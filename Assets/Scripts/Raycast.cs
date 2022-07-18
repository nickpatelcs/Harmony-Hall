using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    Ray RayOrigin;
    RaycastHit HitInfo;
    public GameObject painting;
    public GameObject GameObjectHit;
    private GameObject[] art;

    // Start is called before the first frame update
    void Start()
    {
        art = GameObject.FindGameObjectsWithTag("painting");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObjectHit = hit.transform.gameObject;
            if(GameObjectHit.tag == "painting")
            {
                GameObjectHit.GetComponent<Outline>().enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    GameObjectHit.GetComponent<Interaction>().playSound();
                }
            }
            else
            {
                foreach (GameObject piece in art)
                {
                    piece.GetComponent<Outline>().enabled = false;
                }
            }
        }
        else
        {
            GameObjectHit = null;
        } 
    }
}
