using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] Transform playerTransform;

    //Desplazamiento
    [SerializeField] float offsetZ;
    [SerializeField] float offsetY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offsetZ = -40f;
        offsetY = 9f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector de desplazamiento
        Vector3 offset = new Vector3(0f, offsetY, offsetZ);
        //Lo sumo a la posición 
        transform.position = playerTransform.position + offset;

        //transform.rotation = playerTransform.rotation;
    }
}
