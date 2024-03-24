using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public static float gameHourTimer;
    public float hourLenght;

    private void Update()
    {
        if(gameHourTimer <= 0)
        {
            gameHourTimer = hourLenght;
        }
        else
        {
            gameHourTimer -= Time.deltaTime;
        }
    }
}
