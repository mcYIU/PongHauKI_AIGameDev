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

    public SpriteRenderer[] posRenderer;

    char[] state = new char[] {' ', ' ', ' ', ' ', ' '}; 

    Dictionary<char, Color> posColor = new Dictionary<char, Color>()    //define pawns A to D in colors
    {
        { 'A', Color.red },
        { 'B', Color.yellow },
        { 'C', Color.cyan },
        { 'D', Color.blue },
        { 'O', Color.white },
    };

    bool gameOver = false;
    public bool playerTurn;

    void Start()
    {
        DrawState();
    }


    void Update()
    {
       if (gameOver) return;

        if (playerTurn)
        {
            PlayerMove();
            DrawState();
        }
        else
        {
            CompMove();
            DrawState();
        }

    }


    void PlayerMove()
    {
        SpriteRenderer pos1_Renderer = pos1.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos2_Renderer = pos2.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos3_Renderer = pos3.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos4_Renderer = pos4.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos5_Renderer = pos5.transform.GetComponent<SpriteRenderer>();
 
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit)
            {
                string clickedPos = hit.transform.name;
                //Debug.Log(clickedPos);
                Color hitColor = hit.transform.GetComponent<SpriteRenderer>().color;
                //Debug.Log(hitColor);

                switch (clickedPos)
                {
                    case "Pos1":
                        if(pos3_Renderer.color == Color.white)
                        {
                            pos1_Renderer.color = Color.white;
                            pos3_Renderer.color = hitColor;

                        }else if(pos4_Renderer.color == Color.white)
                        {
                            pos1_Renderer.color = Color.white;
                            pos4_Renderer.color = hitColor;
                        }else
                        {
                            print("No move is done.");
                            clickedPos = "invalid";
                        }
                        break;

                    case "Pos2":
                        if (pos3_Renderer.color == Color.white)
                        {
                            pos2_Renderer.color = Color.white;
                            pos3_Renderer.color = hitColor;

                        }
                        else if (pos5_Renderer.color == Color.white)
                        {
                            pos2_Renderer.color = Color.white;
                            pos5_Renderer.color = hitColor;
                        }
                        else
                        {
                            print("No move is done.");
                            clickedPos = "invalid";
                        }
                        break;

                    case "Pos3":
                        if (pos1_Renderer.color == Color.white)
                        {
                            pos3_Renderer.color = Color.white;
                            pos1_Renderer.color = hitColor;

                        }
                        else if (pos2_Renderer.color == Color.white)
                        {
                            pos3_Renderer.color = Color.white;
                            pos2_Renderer.color = hitColor;
                        }
                        else if (pos4_Renderer.color == Color.white)
                        {
                            pos3_Renderer.color = Color.white;
                            pos4_Renderer.color = hitColor;
                        }
                        else if (pos5_Renderer.color == Color.white)
                        {
                            pos3_Renderer.color = Color.white;
                            pos5_Renderer.color = hitColor;
                        }else
                        {
                            print("No move is done.");
                            clickedPos = "invalid";
                        }
                        break;

                    case "Pos4":
                        if (pos3_Renderer.color == Color.white)
                        {
                            pos4_Renderer.color = Color.white;
                            pos3_Renderer.color = hitColor;

                        }
                        else if (pos1_Renderer.color == Color.white)
                        {
                            pos4_Renderer.color = Color.white;
                            pos1_Renderer.color = hitColor;
                        }
                        else if (pos5_Renderer.color == Color.white)
                        {
                            pos4_Renderer.color = Color.white;
                            pos5_Renderer.color = hitColor;
                        }
                        else
                        {
                            print("No move is done.");
                            clickedPos = "invalid";
                        }
                        break;

                    case "Pos5":
                        if (pos3_Renderer.color == Color.white)
                        {
                            pos5_Renderer.color = Color.white;
                            pos3_Renderer.color = hitColor;

                        }
                        else if (pos2_Renderer.color == Color.white)
                        {
                            pos5_Renderer.color = Color.white;
                            pos2_Renderer.color = hitColor;
                        }
                        else if (pos4_Renderer.color == Color.white)
                        {
                            pos5_Renderer.color = Color.white;
                            pos4_Renderer.color = hitColor;
                        }
                        else
                        {
                            print("No move is done.");
                            clickedPos = "invalid";
                        }
                        break;
                }

                if(clickedPos != "invalid")
                {
                    playerTurn = false;
                }
            }
        }
    }

    void CompMove()
    {


    }


    void DrawState()
    {
        for (int i = 0; i < state.Length; i++)
            posRenderer[i].color = posColor[state[i]];
    }

}
