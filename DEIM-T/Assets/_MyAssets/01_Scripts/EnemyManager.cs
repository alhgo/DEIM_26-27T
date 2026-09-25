using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float speed;
    [SerializeField] float mySpeed = 40f;

    //Instancia del Player Manager que tiene la velocidad del jugador
    PlayerManager playerManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerManager = playerGO.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerManager.moveSpeed + mySpeed;
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }


}
