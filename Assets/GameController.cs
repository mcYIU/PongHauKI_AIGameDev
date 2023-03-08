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

    char[] state = new char[5] ;    //generate the state of positions in a char array

    Dictionary<char, Color> posColor = new Dictionary<char, Color>()    //define pawns A to D from the colors of the positions 
    {
        { 'A', Color.red },
        { 'B', Color.magenta },    //player's pawns: 'A', 'B'
        { 'C', Color.cyan },
        { 'D', Color.blue },      //computer's pawns: 'C','D'
        { 'O', Color.white },     //empty space
    };

    public int maxMove = 8;  //the total no. of moves in a play 

    float stateWeight;

    public bool playerTurn;

    bool IsPlayerWin = false;
    bool IsCompWin = false;


    void Start()
    {
        DrawState(state);
    }


    void Update()
    {
        for(int i=0; i<maxMove; i++)
        {
            if (IsPlayerWin || IsCompWin) return;

            if (playerTurn)
            {
                PlayerMove(state);
            }
            else
            {
                CompMove(state);
            }

            DrawState(state);
            print(state);
            print(stateWeight);
        }   
    }


    void PlayerMove(char[] compState)
    {
        SpriteRenderer pos1_Renderer = pos1.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos2_Renderer = pos2.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos3_Renderer = pos3.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos4_Renderer = pos4.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos5_Renderer = pos5.transform.GetComponent<SpriteRenderer>();

        compState = new char[5];

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit)
            {
                string clickedPos = hit.transform.name;
                Color hitColor = hit.transform.GetComponent<SpriteRenderer>().color;    //get the color of the clicked position to know the pawn

                if(hitColor == Color.red || hitColor == Color.magenta)
                {
                    switch (clickedPos)
                    {
                        case "Pos1":                                           
                            if (pos3_Renderer.color == Color.white)     //A/B moves from pos1 to pos3
                            {
                                pos1_Renderer.color = Color.white;
                                pos3_Renderer.color = hitColor;
                            }
                            else if (pos4_Renderer.color == Color.white)       //A/B moves from pos1 to pos4
                            {
                                pos1_Renderer.color = Color.white;
                                pos4_Renderer.color = hitColor;
                            }
                            break;
                        case "Pos2":
                            if (pos3_Renderer.color == Color.white)     //A/B moves from pos2 to pos3
                            {
                                pos2_Renderer.color = Color.white;
                                pos3_Renderer.color = hitColor;
                            }
                            else if (pos5_Renderer.color == Color.white)       //A/B moves from pos2 to pos5
                            {
                                pos2_Renderer.color = Color.white;
                                pos5_Renderer.color = hitColor;
                            }
                            break;
                        case "Pos3":
                            if (pos1_Renderer.color == Color.white)       //A/B moves from pos3 to pos1
                            {
                                pos3_Renderer.color = Color.white;
                                pos1_Renderer.color = hitColor;
                            }
                            else if (pos2_Renderer.color == Color.white)      //A/B moves from pos3 to pos2
                            {
                                pos3_Renderer.color = Color.white;
                                pos2_Renderer.color = hitColor;
                            }
                            else if (pos4_Renderer.color == Color.white)       //A/B moves from pos3 to pos4
                            {
                                pos3_Renderer.color = Color.white;
                                pos4_Renderer.color = hitColor;
                            }
                            else if (pos5_Renderer.color == Color.white)        //A/B moves from pos3 to pos5
                            {
                                pos3_Renderer.color = Color.white;
                                pos5_Renderer.color = hitColor;
                            }
                            break;
                        case "Pos4":
                            if (pos3_Renderer.color == Color.white)        //A/B moves from pos4 to pos3
                            {
                                pos4_Renderer.color = Color.white;
                                pos3_Renderer.color = hitColor;
                            }
                            else if (pos1_Renderer.color == Color.white)       //A/B moves from pos4 to pos1
                            {
                                pos4_Renderer.color = Color.white;
                                pos1_Renderer.color = hitColor;
                            }
                            else if (pos5_Renderer.color == Color.white)         //A/B moves from pos4 to pos5
                            {
                                pos4_Renderer.color = Color.white;
                                pos5_Renderer.color = hitColor;
                            }
                            break;
                        case "Pos5":
                            if (pos3_Renderer.color == Color.white)         //A/B moves from pos5 to pos3
                            {
                                pos5_Renderer.color = Color.white;
                                pos3_Renderer.color = hitColor;
                            }
                            else if (pos2_Renderer.color == Color.white)        //A/B moves from pos5 to pos2
                            {
                                pos5_Renderer.color = Color.white;
                                pos2_Renderer.color = hitColor;
                            }
                            else if (pos4_Renderer.color == Color.white)        //A/B moves from pos5 to pos4
                            {
                                pos5_Renderer.color = Color.white;
                                pos4_Renderer.color = hitColor;
                            }
                            break;
                    }
                }
                else
                {
                    print("Invalid Move");
                    clickedPos = "invalid";
                }

                if(clickedPos != "invalid")
                {
                    playerTurn = false;
                }
            }
        }
    }

    void CompMove(char[] playerState)
    {
        SpriteRenderer pos1_Renderer = pos1.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos2_Renderer = pos2.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos3_Renderer = pos3.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos4_Renderer = pos4.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer pos5_Renderer = pos5.transform.GetComponent<SpriteRenderer>();

        playerState = new char[5];


        for (int i = 0; i < playerState.Length; i++)
        {
            if (playerState[0] == 'O')        //if pos1 is empty
            {
                switch (playerState[2])      //if pos3 is C/D
                {
                    case 'C':
                        pos3_Renderer.color = Color.white;
                        pos1_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos3_Renderer.color = Color.white;
                        pos1_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
                switch (playerState[3])      //if pos4 is C/D
                {
                    case 'C':
                        pos4_Renderer.color = Color.white;
                        pos1_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos4_Renderer.color = Color.white;
                        pos1_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
            }
            else if (playerState[1] == 'O')       //if pos2 is empty
            {
                switch (playerState[2])       //if pos3 is C/D
                {
                    case 'C':
                        pos3_Renderer.color = Color.white;
                        pos2_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos3_Renderer.color = Color.white;
                        pos2_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
                switch (playerState[4])      //if pos4 is C/D
                {
                    case 'C':
                        pos5_Renderer.color = Color.white;
                        pos2_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos5_Renderer.color = Color.white;
                        pos2_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
            }
            else if (playerState[2] == 'O')       //if pos3 is empty
            {
                switch (playerState[0])      //if pos1 is C/D
                {
                    case 'C':
                        pos1_Renderer.color = Color.white;
                        pos3_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos1_Renderer.color = Color.white;
                        pos3_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
                switch (playerState[1])      //if pos2 is C/D
                {
                    case 'C':
                        pos2_Renderer.color = Color.white;
                        pos3_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos2_Renderer.color = Color.white;
                        pos3_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
                switch (playerState[3])      //if pos4 is C/D
                {
                    case 'C':
                        pos4_Renderer.color = Color.white;
                        pos3_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos4_Renderer.color = Color.white;
                        pos3_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
                switch (playerState[4])      //if pos5 is C/D
                {
                    case 'C':
                        pos5_Renderer.color = Color.white;
                        pos3_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos5_Renderer.color = Color.white;
                        pos3_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
            }
            else if (playerState[3] == 'O')       //if pos4 is empty
            {
                switch (playerState[0])      //if pos1 is C/D
                {
                    case 'C':
                        pos1_Renderer.color = Color.white;
                        pos4_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos1_Renderer.color = Color.white;
                        pos4_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
                switch (playerState[2])      //if pos3 is C/D
                {
                    case 'C':
                        pos3_Renderer.color = Color.white;
                        pos4_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos3_Renderer.color = Color.white;
                        pos4_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
                switch (playerState[4])      //if pos5 is C/D
                {
                    case 'C':
                        pos5_Renderer.color = Color.white;
                        pos4_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos5_Renderer.color = Color.white;
                        pos4_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
            }
            else if (playerState[4] == 'O')       //if pos5 is empty
            {
                switch (playerState[1])      //if pos2 is C/D
                {
                    case 'C':
                        pos2_Renderer.color = Color.white;
                        pos5_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos2_Renderer.color = Color.white;
                        pos5_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
                switch (playerState[2])      //if pos3 is C/D
                {
                    case 'C':
                        pos3_Renderer.color = Color.white;
                        pos5_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos3_Renderer.color = Color.white;
                        pos5_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
                switch (playerState[3])      //if pos4 is C/D
                {
                    case 'C':
                        pos4_Renderer.color = Color.white;
                        pos5_Renderer.color = Color.cyan;
                        break;
                    case 'D':
                        pos4_Renderer.color = Color.white;
                        pos5_Renderer.color = Color.blue;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                IsPlayerWin = true;
            }
        }
        if (!IsPlayerWin)
        {
            playerTurn = true;
        }      
    }


    void DrawState(char[] currentState)
    { 
        for (int i = 0; i < state.Length; i++)
        {
            posColor[state[i]] = posRenderer[i].color;     //generate state in char from the colors of all positions
            state = currentState;
        }
        string stateString = new string (currentState);
        switch (stateString)
        {
            case "COBDA":
                IsPlayerWin = true;
                stateWeight += 1;
                break;
            case "ODABC":
                IsPlayerWin = true;
                stateWeight += 1;
                break;
            case "OBDCA":
                IsCompWin = true;
                stateWeight -= 1;
                break;
            case "AOCBD":
                IsCompWin = true;
                stateWeight -= 1;
                break;
            default:
                IsPlayerWin = false;
                IsCompWin = false;
                break;
        }

    }

}
