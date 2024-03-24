using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int energy, happiness, condition;
    public int energyTickRate, happinessTickRate, conditionTickRate;

    public void Initialize(int energy, int happiness,int condition) 
    {     
        this.energy = energy;
        this.happiness = happiness;
        this.condition = condition;  
    }

    private void Update()
    {
        if(TimingManager.gameHourTimer < 0) 
        {
            ChangeEnergy(-energyTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeCondition(-conditionTickRate);
        }
    }


    public void ChangeEnergy(int amount)
    {
        energy += amount;
        if (energy < 0)
        {
            print("Die");
        }
        else if (energy > 100) energy = 100;
        
    }

    public void ChangeHappiness(int amount)
    {
        happiness += amount;
        if (happiness < 0)
        {
            print("Die");
        }
        else if (happiness > 100) happiness = 100;
    }
    
    public void ChangeCondition(int amount)
    {
        condition += amount;
        if (condition < 0)
        {
            print("Die");
        }
        else if (condition > 100) condition = 100;
    }

}
