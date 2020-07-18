using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public Transform movePointGhost;
    public Text message;
    public LayerMask tilemapWater;

    // Start is called before the first frame update
    void Start()
    {
        message.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(movePointGhost.position, .2f, tilemapWater))//if the tile in front of the player is water
        {
            if (Input.GetKeyDown("space"))
            {
                message.text = "You caught a fish";
                message.enabled = true;
            }
        }
        else
        {
            message.enabled = false;
        }
    }
}
