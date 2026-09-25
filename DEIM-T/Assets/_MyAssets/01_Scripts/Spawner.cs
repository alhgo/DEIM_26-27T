using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    float interval = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(SpawnEnemy());
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float posX = Random.Range(-100f, 100f);
            float posY = Random.Range(1f, 20f);
            Vector3 pos = new Vector3(posX, posY, transform.position.z);
            Instantiate(enemy, pos, Quaternion.identity);
            yield return new WaitForSeconds(interval); ;
        }
    }
}
