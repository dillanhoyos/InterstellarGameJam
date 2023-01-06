using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RobotLogic : MonoBehaviour
{

    public SelectButton[] myButtons;
    public List<int> colorList;
    public float showtime = 0.5f;
    public float pausetime = 0.5f;
    //public AK.Wwise.Event Win; 
   // public AK.Wwise.Event Loose; 

    public Text gameOverText;
    public Text ScoreText;
 
    private int score; 

    public int level = 2;
    private int playerlevel = 0;
    bool robot = false;
    public bool Player = false; 

    private int myrandom;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < myButtons.Length; i++)
        {
            myButtons[i].onClick += ButtonClicked;
            myButtons[i].myNumber = i; 
        }
    }

    void ButtonClicked(int _number)
    {
        if(Player)
        {
            if(_number == colorList[playerlevel])
            {
                playerlevel += 1;
                score += 1;
                ScoreText.text = score.ToString();
            }

            else
            {
                GameOver();
            }
            if(playerlevel == level){
                level += 1;
                playerlevel = 0;
              //  Win.Post(gameObject);
                Player = false;
                robot = true; 

            }
        }

    }
    // Update is called once per frame
    private void Update()
    {
        if(robot){
            robot = false;
             StartCoroutine(Robot());
        }
    }

    private IEnumerator Robot()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < level; i++)
        {
            if(colorList.Count < level){
            myrandom = Random.Range(0, myButtons.Length);
            colorList.Add(myrandom);
            }
            myButtons[colorList[i]].ClickedColor();
            yield return new WaitForSeconds(showtime);
            myButtons[colorList[i]].UnClickedColor();
            yield return new WaitForSeconds(pausetime);

    
        }
        Player = true;

    }

    public void StartGame()
    {
       robot = true; 
       score = 0;
       playerlevel = 0;
       level = 2;
       gameOverText.text = "";
       ScoreText.text = score.ToString();
      // Startbutton.interactable = false;


    }

    void GameOver()
    {
        gameOverText.text = "Game Over";
     //   Startbutton.interactable = true;
        Player = false;
      //  Loose.Post(gameObject);
    }
}
