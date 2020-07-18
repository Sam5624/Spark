using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float moveSpeed = 10f;
    public Transform movePoint;
    public Transform movePointGhost;
    public LayerMask tilemapWater;
    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        movePointGhost.parent = null;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        {
            if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = right;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = left;
            }

            if (transform.position.x - movePoint.position.x < .05f && transform.position.x - movePoint.position.x > -.05f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, tilemapWater))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
                movePointGhost.position = movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            if (Input.GetAxisRaw("Vertical") == 1f)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = up;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = down;
            }

            if (transform.position.y - movePoint.position.y < .05f && transform.position.y - movePoint.position.y > -.05f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, tilemapWater))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
                movePointGhost.position = movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }
    }
}