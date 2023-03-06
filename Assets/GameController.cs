using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;

    public SpriteRenderer[] sprites;

    char[] state = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };    //I don't know how to use $ to fix the format in " A'',B'',C'',D'',''"

    Dictionary<char, Color> pawnColor = new Dictionary<char, Color>()    //define pawns in colors
    {
        { 'A', Color.red },
        { 'B', Color.yellow },
        { 'C', Color.cyan },
        { 'D', Color.blue },
    };

    void Start()
    {
        

    }


    void Update()
    {
        getPawn();
    }


    public void getPawn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit)
            {
                string clickedPos = hit.transform.name;
                //Debug.Log(clickedPos);
                Color color = hit.transform.GetComponent<SpriteRenderer>().color;
                Debug.Log(color.ToString());
    
            }

        }
    }

    public void movePawn(string clickedPos)
    {

       // switch (clickedPos)
       // {
       //     case "Pos1":

       // }

    }
}
