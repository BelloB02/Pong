using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public GUISkin layout;
    GameObject ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindGameObjectWithTag("Ball"); //sets ball to refer to the GameObject Ball
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Score(string wallID) //updates Player scores if the ball hits the left or right wall
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++; //increase Player 1's score by one if the ball hits the Right Wall
        } else
        {
            PlayerScore2++; //increases Player 2's score by one if the ball hits the Left Wall
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1); //displays Player 1's score
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2); //displays Player 2's score

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART")) //displays the Restart Button and invokes Restart function in BallMove
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            ball.SendMessage("Restart", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "P1 WINS"); //displays P1 wins message
            ball.SendMessage("Reset", null, SendMessageOptions.RequireReceiver); //triggers Reset function in BallMove
        } else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "P2 WINS"); //displays P2 wins message
            ball.SendMessage("Reset", null, SendMessageOptions.RequireReceiver); //triggers Reset function in BallMove
        }
    }
}
