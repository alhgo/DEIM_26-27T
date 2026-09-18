using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float desplSpeed;

    //Input System
    MyInputActions inputActions;

    //Movimiento en X
    float moveX;

    //RS para la rotación
    float rotation;
    //Velocidad de rotación en vueltas por segundo
    float rotationSpeed = 2f;

    private void Awake()
    {
        inputActions = new MyInputActions();

        inputActions.Player.Fire.started += _ => Shoot();

        //LS Eje X para mover
        inputActions.Player.Movex.performed += ctx => moveX = ctx.ReadValue<float>();
        inputActions.Player.Movex.canceled += _ => moveX = 0f;

        //RS Eje X para la rotación
        inputActions.Player.Rotar.performed += ctx => rotation = ctx.ReadValue<float>();
        inputActions.Player.Rotar.canceled += _ => rotation = 0f;


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

    private void Start()
    {
        moveSpeed = 30f;
        desplSpeed = 5f;
  
    }
    private void Update()
    {
        //Movimiento izquierda derecha
        transform.Translate(Vector3.right * desplSpeed *  Time.deltaTime * moveX);
        //Rotación
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * rotation * -360f);
    }
}
