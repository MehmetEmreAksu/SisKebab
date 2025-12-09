using UnityEngine;

public class Falling : MonoBehaviour
{

    [SerializeField] private float speed = 5.0f;


    private void Start(){

    }
    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }
}


