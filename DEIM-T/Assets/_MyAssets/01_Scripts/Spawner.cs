using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    float interval = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //ENEMIGOS INTERMEDIOS
    [SerializeField] float firstEenemyPositionZ = 200f; //Donde aparecerá el primero
    [SerializeField] float distanciaEntreEnemigos = 10f; //Distancia entre enemigos

    //PlayerManager
    [SerializeField] PlayerManager playerManager;
    void Start()
    {
        //StartCoroutine(SpawnEnemy());
        StartCoroutine("SpawnEnemy");
        //Eenmigos intermedios para colocar entre el spawner y yo
        InstanciarIntermedios();

    }

    void InstanciarIntermedios()
    {
        //A qué distancia del spawner debe aparecer el primer enemigo
        float firstEenemyOffset = transform.position.z - firstEenemyPositionZ;
        //Necesito saber cuántos enemigos saldrán, es decir, ciclos del bucle
        float n = firstEenemyOffset / distanciaEntreEnemigos;
        //Lo redondeo y lo paso a INT
        int ciclos = Mathf.FloorToInt(n);

        for (int i = 0; i < ciclos; i++) 
        {
          //En cada ciclo, saco un enemigo, pero cada vez más alejado (con menos offset en Z)
            SacarEnemigo(firstEenemyOffset);
            firstEenemyOffset -= distanciaEntreEnemigos;
        }
    }

    IEnumerator SpawnEnemy()
    {
        //El intervalo entre enemigos depende de la velocidad y la distancia entre enemigos
        while (true)
        {
            SacarEnemigo(0f);
            interval = distanciaEntreEnemigos / playerManager.moveSpeed;
            yield return new WaitForSeconds(interval); ;
        }
    }
    
    void SacarEnemigo(float offsetZ)
    {
        float posX = Random.Range(-100f, 100f);
        float posY = Random.Range(1f, 30f);
        Vector3 pos = new Vector3(posX, posY, transform.position.z - offsetZ);
        Instantiate(enemy, pos, Quaternion.identity);
    }
}
