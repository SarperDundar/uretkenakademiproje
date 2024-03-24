using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    private int _hunger;
    [SerializeField]
    private int _happiness;
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _energy;


    private bool _serverTime;
    private int _clickCount;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("then", "24/04/2019 14:23:00");
        updateStatus();
        if (!PlayerPrefs.HasKey("name"))
        {
            PlayerPrefs.SetString("name", "Ark");
        }
        _name = PlayerPrefs.GetString("name");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
           
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {

                if (hit.transform.gameObject.tag == "robot")
                {
                    Debug.Log(_clickCount);
                    _clickCount++;
                
                    if (_clickCount == 3 || _clickCount == 6 || _clickCount == 9 || _clickCount == 12)
                    {
                        //_clickCount = 0;
                        updateHappiness(1);
                        
                    } if (_clickCount == 15)
                    {
                        _clickCount = 0;

                        Debug.Log("terminator");
                    }
                }


            }
        }
    }

    void updateStatus()
    {
        if (!PlayerPrefs.HasKey("_energy"))
        {
            _energy = 50;
            PlayerPrefs.SetInt("_energy", _energy);
        }
        else
        {
            _energy = 50;
            _hunger = PlayerPrefs.GetInt("_hunger");
        }
        if (!PlayerPrefs.HasKey("_hunger"))
        {
            _hunger = 50;
            PlayerPrefs.SetInt("_hunger", _hunger);
        }
        else
        {
            _hunger = 50;
            _hunger = PlayerPrefs.GetInt("_hunger");
        }

        if (!PlayerPrefs.HasKey("_happiness"))
        {
            _happiness = 50;
            PlayerPrefs.SetInt("_happiness", _happiness);
        }
        else
        {
            _happiness = 50;
            _happiness = PlayerPrefs.GetInt("_happiness");
        }

        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", getStringTime());
        }

        TimeSpan ts = getTimeSpan();

        //_hunger -=(int)(ts.TotalHours = 2);

        _hunger = _hunger ;// - (int)(ts.TotalHours / 2);
        if (_hunger < 0)
        {
            _hunger = 0;
        }

        // _happiness -=(int)(100 -_hunger)*(ts.TotalHours / 5);

        _happiness = _happiness; //- ((int)(100 - _hunger) + (int)(ts.TotalHours / 10));

        if (_happiness < 0)
        {
            _happiness = 0;
        }


        Debug.Log(getTimeSpan().ToString());
        Debug.Log(getTimeSpan().TotalHours);


        if (_serverTime)
        {
            updateServer();
        }
        else
        {
            InvokeRepeating("updateDevice", 0f, 5f);
        }

    }

    void updateServer()
    {

    }
    void updateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    TimeSpan getTimeSpan()
    {
        if (_serverTime)
        {
            return new TimeSpan();
        }
        else
        {
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }

    }



    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Day + "/" + now.Month + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    public int hunger
    {
        get { return _hunger; }
        set { _hunger = value; }
    }

    public string name
    {
        get { return _name; }
        set { _name = value; }

    }


    public int happiness
    {
        get { return _happiness; }
        set { _happiness = value; }
    }

    public int energy
    {
        get { return _energy; }
        set { _energy = value; }
    }



    public void saveRobot()
    {
        if (!_serverTime)
            updateDevice();
        PlayerPrefs.SetInt("_hunger", _hunger);
        PlayerPrefs.SetInt("_happiness", _happiness);
        PlayerPrefs.SetInt("_energy", _energy);

    }
   
    public void updateHappiness(int i)
    {
        happiness += i;
        if (happiness > 100)
        {
            happiness = 100;
        }
    }

    public void updateHunger(int i)
    {
        hunger += i;
        if (hunger > 100)
        {
            hunger = 100;
        }
    }

    public void updateEnergy(int i)
    {
        energy += i;

    }

    public void downEnergy(int i)
    {
        energy -= i;
    }

}
