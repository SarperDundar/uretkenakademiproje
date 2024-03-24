using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject happinessText;
    public GameObject hungerText;
    public GameObject energyText;
    public GameObject scoreText;


    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;

    public GameObject robot;
    public GameObject robotPanel;
    public GameObject[] robotList;

    public GameObject homePanel;
    public Sprite[] homeTileSprites;
    public GameObject[] homeTiles;

    public GameObject background;
    public Sprite[] backgroundOptions;

    public GameObject foodPanel;
    public Sprite[] foodIcons;

    public GameObject gamePanel;
    public Sprite[] gameIcons;

    public GameObject mainPanel;

    public GameObject multipPanel;


    public GameObject happinessprey;
    public GameObject hungerprey;
    public GameObject energyprey;

    public static int totalScore = 100;


    void Start()
    {
        if (!PlayerPrefs.HasKey("looks"))
        {
            PlayerPrefs.SetInt("looks", 0);
        }
        //createRobot(PlayerPrefs.GetInt("looks"));

        if (!PlayerPrefs.HasKey("tiles"))
        {
            PlayerPrefs.SetInt("tiles", 1);
        }
        changeTiles(PlayerPrefs.GetInt("tiles"));


        if (!PlayerPrefs.HasKey("background"))
        {
            PlayerPrefs.SetInt("background", 0);
        }
        changeBackground(PlayerPrefs.GetInt("background"));
    }



    // Update is called once per frame
    void Update()
    {
       happinessText.GetComponent<Text>().text ="" + robot.GetComponent<Robot>().happiness;
        hungerText.GetComponent<Text>().text ="" + robot.GetComponent<Robot>().hunger;
        energyText.GetComponent<Text>().text = "" + robot.GetComponent<Robot>().energy;
        nameText.GetComponent<Text>().text = robot.GetComponent<Robot>().name;
        scoreText.GetComponent<Text>().text = totalScore.ToString();

    }


    public void triggerNamePanel (bool b)
    {
        namePanel.SetActive(!namePanel.activeInHierarchy);

        if (b)
        {
            robot.GetComponent<Robot>().name = nameInput.GetComponent<InputField>().text;
            PlayerPrefs.SetString("name", robot.GetComponent<Robot>().name);
        }

        

    }


    public void buttonBehavior(int i)
    {
        switch (i)
        {
            case (0):
            default:
                robotPanel.SetActive(!robotPanel.activeInHierarchy);
                break;
            case (1):
                homePanel.SetActive(!homePanel.activeInHierarchy);
                break;
            case (2):
                foodPanel.SetActive(!foodPanel.activeInHierarchy);
                break;
            case (3):
                gamePanel.SetActive(!gamePanel.activeInHierarchy);
                break;
            case (4):
                robot.GetComponent<Robot>().saveRobot();
                Application.Quit();
                break;
            case (5):
                mainPanel.SetActive(!mainPanel.activeInHierarchy);
                break;
            case (6):
                multipPanel.SetActive(!multipPanel.activeInHierarchy);
                break;


        }

    }

     /* public  void createRobot(int i)
    {
        if (robot)
        {
            Destroy(robot);
            robot = Instantiate(robotList[i], Vector3.zero, Quaternion.identity) as GameObject;
        }
        if (robotPanel.activeInHierarchy)
        {
            robotPanel.SetActive(false);
        }
        PlayerPrefs.SetInt("looks", i);
    }*/

    public void changeTiles(int t)
    {
        for (int i = 0; i < homeTiles.Length; i++)
        {
            homeTiles[i].GetComponent<SpriteRenderer>().sprite = homeTileSprites[t];
        }

        if (homePanel.activeInHierarchy)
        {
            homePanel.SetActive(false);
        }

        PlayerPrefs.SetInt("tiles", t);
    }

    public void changeBackground(int i)
    {
        background.GetComponent<SpriteRenderer>().sprite = backgroundOptions[i];

        if (homePanel.activeInHierarchy)
        {
            homePanel.SetActive(false);
        }

        PlayerPrefs.SetInt("background", i);
    }

    public void selectFood(int i)
    {
     
        toggle(foodPanel);
    }
    
    public void toggle(GameObject g)
    {
        if (g.activeInHierarchy)
        {
            g.SetActive(false);
        }
    }
    public void happines(int i)
    {
      totalScore -= i;
      robot.GetComponent<Robot>().updateHappiness(i);
      Vector3 randomSpawnPoisition = new Vector3(UnityEngine.Random.Range(508,522), 5, UnityEngine.Random.Range(47,49));
      Instantiate(happinessprey, randomSpawnPoisition, Quaternion.identity);
            
            /*string result;
        int happpie = Convert.ToInt32(happinessText);
        happpie += i;
        result = Convert.ToString(happpie);
        result*/
    }
    public void hunger(int i)
    {
       
        robot.GetComponent<Robot>().updateHunger(i);
        Vector3 randomSpawnPoisition = new Vector3(UnityEngine.Random.Range(508, 522), 5, UnityEngine.Random.Range(47, 49));
        Instantiate(hungerprey, randomSpawnPoisition, Quaternion.identity);
        totalScore -= i;
    }

    public void energy(int i)
    {
        totalScore -= i;
        robot.GetComponent<Robot>().updateEnergy(i);
        Vector3 randomSpawnPoisition = new Vector3(UnityEngine.Random.Range(508, 522), 5, UnityEngine.Random.Range(47, 49));
        Instantiate(energyprey, randomSpawnPoisition, Quaternion.identity);

    }


}
