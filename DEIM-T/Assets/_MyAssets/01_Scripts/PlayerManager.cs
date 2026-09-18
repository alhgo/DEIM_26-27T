using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float desplSpeed;

    //Input System
    MyInputActions inputActions;

    //Movimiento en X
    float moveX;

    private void Awake()
    {
        inputActions = new MyInputActions();

        inputActions.Player.Fire.started += _ => Shoot();

        inputActions.Player.Movex.performed += ctx => moveX = ctx.ReadValue<float>();
        inputActions.Player.Movex.canceled += _ => moveX = 0f;


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

        transform.Translate(Vector3.right * desplSpeed *  Time.deltaTime * moveX);
    }
}
