using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bingo_codes : MonoBehaviour
{
    List<int> luckyNumbers = new List<int>(35);
    List<int> numberShowOnTable = new List<int>(24);
    public List<int> getValues = new List<int>(24);
    public List<Text> txts;
    public List<Sprite> ballSprites;
    public List<Image> ballImages;
    public GameObject[] ballClickCircles;
    public Button play;
    public Animator ballAnimate, bingoWin;
    float time = 1f;
    bool isTrue;
    public List<int> row1 = new List<int>(5);
    public List<int> row2 = new List<int>(5);
    public List<int> row3 = new List<int>(4);
    public List<int> row4 = new List<int>(5);
    public List<int> row5 = new List<int>(5);
    public List<int> linesRule = new List<int>(4);
    public Text lose, bingo;
    public int tags;
    public GameObject[] text;

    void Update()
    {
        startGame();
    }

    void startGame()
    {
        if (isTrue)
        {
            time -= Time.deltaTime;
        }

        if(time<=0 && isTrue)
        {
            isTrue = false;
            time = 0;
            luckyNumbers.Clear();
            numberShowOnTable.Clear();
            StartCoroutine(gameUpdate());
        }
    }

    public void playButton()
    {
        FindAnyObjectByType<controllUtils>().playToggle("tap", 2);
        play.enabled = false;
        isTrue = true;
        time = 1f;
        play.image.color = Color.gray;
    }

    IEnumerator gameUpdate()
    {
        findLuckyBalls();
        tableChoiseNumbers();
        yield return new WaitForSecondsRealtime(0.5f);
        ballAnimate.Play("round");
        yield return new WaitForSecondsRealtime(96f);
        ballAnimate.Play("idle");
        yield return new WaitForSecondsRealtime(2f);

        resultGame();
        yield return new WaitForSecondsRealtime(2f);

        clareItems();
        play.enabled = true;
        play.image.color = new Color(255, 255, 255, 255);
    }

    void findLuckyBalls()
    {
        for(int i = 0; i< 35; i++)
        {
            int rand = Random.Range(1, 45);
            while (luckyNumbers.Contains(rand)) rand = Random.Range(1, 45);
            luckyNumbers.Add(rand);
        }
        compareBallWithImageBall();

    }

    void tableChoiseNumbers()
    {
        for (int i = 0; i < 24; i++)
        {
            int rand = Random.Range(1, 45);
            while (numberShowOnTable.Contains(rand)) rand = Random.Range(1, 45);
            numberShowOnTable.Add(rand);
        }
        getTextNumberOnTable();
    }

    void getTextNumberOnTable()
    {
        for(int i = 0; i<numberShowOnTable.Count; i++)
        {
            for(int j= 0; j<txts.Count; j++)
            {
                if(i==j)
                txts[j].text = numberShowOnTable[i].ToString();
            }
        }
    }

    void compareBallWithImageBall()
    {
        for (int ball = 0; ball < luckyNumbers.Count; ball++)
        {
            for(int sprit = 0; sprit<FindAnyObjectByType<detects>().balls.Count; sprit++)
            {
                if(luckyNumbers[ball] == FindAnyObjectByType<detects>().balls[sprit].value)
                {
                    ballImages[ball].sprite = FindAnyObjectByType<detects>().balls[sprit].ball;
                    tags = FindAnyObjectByType<detects>().balls[sprit].value;
                    string t = tags.ToString();
                    ballImages[ball].tag = t;
                    // ballImages[ball].sprite = ballSprites[sprit-1];
                   // print("value: " + FindAnyObjectByType<detects>().balls[sprit].value);
                   // print("nun: " + luckyNumbers[ball]+" ,tags: "+t);
                   // print("luckyNumber: " + luckyNumbers[ball]);
                }
            }
        }
    }

    public void compareValueOfBalls(int value, int index)
    {
        //print("valueOf: " + value);
        //print("ball1: " + FindAnyObjectByType<d1>().ball1);
        if (value == FindAnyObjectByType<d1>().ball1) ballClickCircles[index].SetActive(true);
        else if (value == FindAnyObjectByType<d2>().ball2) ballClickCircles[index].SetActive(true);
        else if (value == FindAnyObjectByType<d3>().ball3) ballClickCircles[index].SetActive(true);
        else if (value == FindAnyObjectByType<d4>().ball4) ballClickCircles[index].SetActive(true);
        else if (value == FindAnyObjectByType<d5>().ball5) ballClickCircles[index].SetActive(true);

    }
    
    public void swictButtonAndGetValues()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (name)
        {
            case "r1_c (0)":
                FindAnyObjectByType<controllUtils>().playToggle("button", 2);
                getValues[0] = numberShowOnTable[0];
                compareValueOfBalls(getValues[0], 0);
                row1[0] = 1;
                linesRule[0] = 10;
                break;
            case "r1_c (1)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[1] = numberShowOnTable[1];
                compareValueOfBalls(getValues[1], 1);
                row1[1] = 1;
                break;
            case "r1_c (2)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[2] = numberShowOnTable[2];
                compareValueOfBalls(getValues[2], 2);
                row1[2] = 1;
                break;
            case "r1_c (3)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[3] = numberShowOnTable[3];
                compareValueOfBalls(getValues[3], 3);
                row1[3] = 1;
                break;
            case "r1_c (4)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[4] = numberShowOnTable[4];
                compareValueOfBalls(getValues[4], 4);
                row1[4] = 1;
                break;
            case "r1_c (5)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[5] = numberShowOnTable[5];
                compareValueOfBalls(getValues[5], 5);
                row2[0] = 2;
                break;
            case "r1_c (6)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[6] = numberShowOnTable[6];
                compareValueOfBalls(getValues[6], 6);
                linesRule[1] = 10;
                row2[1] = 2;
                break;
            case "r1_c (7)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[7] = numberShowOnTable[7];
                compareValueOfBalls(getValues[7], 7);
                row2[2] = 2;
                break;
            case "r1_c (8)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[8] = numberShowOnTable[8];
                compareValueOfBalls(getValues[8], 8);
                row2[3] = 2;
                break;
            case "r1_c (9)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[9] = numberShowOnTable[9];
                compareValueOfBalls(getValues[9], 9);
                row2[4] = 2;
                break;
            case "r1_c (10)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[10] = numberShowOnTable[10];
                compareValueOfBalls(getValues[10], 10);
                row3[0] = 3;
                break;
            case "r1_c (11)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[11] = numberShowOnTable[11];
                compareValueOfBalls(getValues[11], 11);
                row3[1] = 3;
                break;

            case "r1_c (13)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[12] = numberShowOnTable[12];
                compareValueOfBalls(getValues[12], 12);
                row3[2] = 3;
                break;
            case "r1_c (14)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[13] = numberShowOnTable[13];
                compareValueOfBalls(getValues[13], 13);
                row3[3] = 3;
                break;
            case "r1_c (15)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[14] = numberShowOnTable[14];
                compareValueOfBalls(getValues[14], 14);
                row4[1] = 4;
                break;
            case "r1_c (16)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[15] = numberShowOnTable[15];
                compareValueOfBalls(getValues[15], 15);
                row4[1] = 4;
                break;
            case "r1_c (17)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[16] = numberShowOnTable[16];
                compareValueOfBalls(getValues[16], 16);
                row4[2] = 4;
                break;
            case "r1_c (18)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[17] = numberShowOnTable[17];
                compareValueOfBalls(getValues[17], 17);
                linesRule[2] = 10;
                row4[3] = 4;
                break;
            case "r1_c (19)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[18] = numberShowOnTable[18];
                compareValueOfBalls(getValues[18], 18);
                row4[4] = 4;
                break;
            case "r1_c (20)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[19] = numberShowOnTable[19];
                compareValueOfBalls(getValues[19], 19);
                row5[1] = 5;
                break;
            case "r1_c (21)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[20] = numberShowOnTable[20];
                compareValueOfBalls(getValues[20], 20);
                row5[1] = 5;
                break;
            case "r1_c (22)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[21] = numberShowOnTable[21];
                compareValueOfBalls(getValues[21], 21);
                row5[2] = 5;
                break;
            case "r1_c (23)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[22] = numberShowOnTable[22];
                compareValueOfBalls(getValues[22], 22);
                row5[3] = 5;
                break;
            case "r1_c (24)":
                FindAnyObjectByType<controllUtils>().playToggle("button",2);
                getValues[23] = numberShowOnTable[23];
                compareValueOfBalls(getValues[23], 23);
                linesRule[3] = 10;
                row5[4] = 5;
                break;
        }
    }

    void clareItems()
    {
        for(int i =0; i<ballClickCircles.Length; i++)
        {
            ballClickCircles[i].SetActive(false);
            txts[i].text = "?";
        }
        for (int c = 0; c < row1.Count; c++) row1[c] = row2[c] = row4[c] = row5[c] = 0;
        for (int i = 0; i < row3.Count; i++) row3[i] = linesRule[i]  = 0;
        text[0].SetActive(false);
        text[1].SetActive(false);
        bingoWin.Play("idle");
        isGingo = false;
    }
    bool isGingo;
    void resultGame()
    {
        
        if(row1[0] == 1 && row1[1] == 1 && row1[2]== 1 &&row1[3] ==1 && row1[4] == 1)
        {
            print("BINGO1 !!");
            isGingo = true;
        }
        if (row2[0] == 2 && row2[1] ==2 && row2[2] == 2 && row2[3] ==2 && row2[4] == 2)
        {
            print("BINGO2 !!");
            isGingo = true;
        }
        if (row3[0] == 3 && row3[1] == 3 && row3[2]== 3 && row3[3] == 3)
        {
            print("BINGO3 !!");
            isGingo = true;
        }        
        
        if(row4[0] == 4 && row4[1] == 4 && row4[2]== 4 && row4[3]==4 && row4[4] == 4)
        {
            print("BINGO4 !!");
            isGingo = true;
        }
        if (row5[0] == 5 && row5[1] ==5 && row5[2] == 5 && row5[3]==5 && row5[4] == 5)
        {
            print("BINGO5 !!");
            isGingo = true;
        }
        if (linesRule[0] ==10 && linesRule[1] == 10 && linesRule[2] == 10 && linesRule[3] == 10  )
        {
            print("BINGO6 !!");
            isGingo = true;
        }


        if (row1[0] == 1 && row2[0] == 2 && row3[0] == 3 && row4[0] == 4 && row5[0] == 5)
        {
            print("BINGO7 !!");
            isGingo = true;
        }
        if (row1[1] == 1 && row2[1] == 2 && row3[1] == 3 && row4[1] == 4 && row5[1] == 5)
        {
            print("BINGO8 !!");
            isGingo = true;
        }if (row1[2] == 1 && row2[2] == 2 && row4[2] == 4 && row5[2] == 5)
        {
            print("BINGO9 !!");
            isGingo = true;
        }
        if (row1[3] == 1 && row2[3] == 2 && row3[2] == 3 && row4[3] == 4 && row5[3] == 5)
        {
            print("BINGO10 !!");
            isGingo = true;
        }        if (row1[4] == 1 && row2[4] == 2 && row3[3] == 3 && row4[4] == 4 && row5[4] == 5)
        {
            print("BINGO11 !!");
            isGingo = true;
        }

        if (isGingo)
        {
            FindAnyObjectByType<controllUtils>().playToggle("win", 2);
            text[0].SetActive(true);
            bingoWin.Play("bingoWin");
           // bingo.text = "BINGO";
        }
        else
        {
            FindAnyObjectByType<controllUtils>().playToggle("again", 2);
            text[1].SetActive(true);
           // lose.text = "Try Again";
        }

    }

    public void homeScene()
    {
        SceneManager.LoadScene("Bingo Home");
    }

}
