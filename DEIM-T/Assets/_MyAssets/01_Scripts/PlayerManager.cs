using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float timeElapsed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time;
        float timeRounded = Mathf.Round((timeElapsed * 100)) / 100;
        print("Tiempo transcurrido: " + timeRounded);
    }
}
