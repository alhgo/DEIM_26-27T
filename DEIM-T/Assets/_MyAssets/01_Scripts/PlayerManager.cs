using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float desplSpeed;

    //Input System
    MyInputActions inputActions;

    //Movimiento en X
    float moveX;
    float moveY;


    //RS para la rotación
    float rotation;
    //Velocidad de rotación en vueltas por segundo
    float rotationSpeed = 2f;

    //Rotación suavizada
    float maxRotation = 65f;
    [SerializeField] float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    Vector3 currentRot;

    private void Awake()
    {
        inputActions = new MyInputActions();

        inputActions.Player.Fire.started += _ => Shoot();

        //LS Eje X para mover
        inputActions.Player.Movex.performed += ctx => moveX = ctx.ReadValue<float>();
        inputActions.Player.Movex.canceled += _ => moveX = 0f;

        //LS Eje Y para mover
        inputActions.Player.MoveY.performed += ctx => moveY = ctx.ReadValue<float>();
        inputActions.Player.MoveY.canceled += _ => moveY = 0f;

        //RS Eje X para la rotación
        inputActions.Player.Rotar.performed += ctx => rotation = ctx.ReadValue<float>();
        inputActions.Player.Rotar.canceled += _ => rotation = 0f;

        //Mi velocidad de desplazamiento en el AWAKE para que esté desde el inicio
        moveSpeed = 30f;

    }

    private void Start()
    {
        desplSpeed = 25f;

    }
    private void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        if(CheckLimitsX() == true)
        {
            //Movimiento izquierda derecha
            Vector3 desplX = Vector3.right * desplSpeed * Time.deltaTime * moveX;
            transform.Translate(desplX,Space.World);

        }

        Vector3 desplY = Vector3.up * desplSpeed * Time.deltaTime * moveY;
        transform.Translate(desplY, Space.World);
    }

    void RotatePlayer()
    {
        //Rotación
        //transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * rotation * -360f);

        //Sumo el vector de rotacion en Z mas el de rotacion en X para bascular
        Vector3 vectorRotZ = Vector3.forward * -60f * moveX;
        Vector3 vectorRotX = Vector3.right * -30f * moveY;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;

    }

    bool CheckLimitsX()
    {
        bool inLimit = true;

        return inLimit;
    }

    void Shoot()
    {
        print("POOOM");
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }


}
