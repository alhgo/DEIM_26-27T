using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Variable para crear un contador de segundos
    float timeElapsed;

    //Variables serializadas para poder cambiarlas en Unity
    [SerializeField] int ciclos = 10;
    [SerializeField] int lives;

    //Joystick EjeX
    float moveX;
    float limits = 10f; //Límite de desplazamiento por la derecha

    //El método Awake se ejecuta antes que el Start
    private void Awake()
    {
        //Por si hemos cambiado el número de vidas en Unity
        lives = 3;
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EjecutarBucle();
    }

    void EjecutarBucle()
    {
        int n = 0;
        while (n < 10)
        {
            n++;
            //print(n);
        }

        for (int i = 0; i < ciclos; i++)
        {
            print(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Contador de tiempo
        Contador();

        //Si estoy dentro del límite, me muevo
        bool estoyEnElLimite = CheckLimits();
        if(estoyEnElLimite == true)
        {
            MovePlayer();
        }
        // El siguiente código hace lo mismo pero con menos código
        if(CheckLimits())
        {
            MovePlayer();
        }
    }
    //Ejemplo de método que retorna un valor booleano en este caso
    bool CheckLimits()
    {
        //Booleana que retornaré
        bool inLimits;
        //Mo posición en X
        float posX = transform.position.x;
        //Comprobación
        if (posX > limits && moveX > 0)
        {
            //transform.position = new Vector3(limitR, 0f, 0f);
            inLimits = false;

        }
        else if (posX < -limits && moveX < 0)
        {
            //transform.position = new Vector3(-limits, 0f, 0f);
            inLimits = false;
        }
        else
        {
            inLimits = true;
        }

        return inLimits;

        //Un ejemplo de cómo hacerlo con menos código
        /*
        if (posX > limitR && moveX > 0 || posX < limitL && moveX < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        */
    }

    void MovePlayer()
    {
        //Aquí irá el movimiento
    }

    void Contador()
    {
        timeElapsed = Time.time;
        float timeRounded = Mathf.Round((timeElapsed * 100)) / 100;
        print("Tiempo transcurrido: " + timeRounded);
    }
}
