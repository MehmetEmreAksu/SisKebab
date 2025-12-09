using UnityEngine;

public class Falling : MonoBehaviour
{

    [SerializeField] private float minSpeed = 6.0f;
    [SerializeField] private float maxSpeed = 12.0f;
    private float speed;

    //rotation speed
    [SerializeField] private float minRotSpeed = -180.0f;
    [SerializeField] private float maxRotSpeed = 180.0f;
    private float rotSpeed;

    [SerializeField] private GameObject particle;
    [SerializeField] private Color particleColor = Color.white;


    private bool isStuck = false;
    private void Start(){
        speed = Random.Range(minSpeed, maxSpeed);
        rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);
    }
    void Update()
    {
        if (!isStuck)
        {

            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);


            transform.Rotate(new Vector3(0, 0, rotSpeed*Time.deltaTime));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isStuck)
        {
            return;
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            StickToBar(collision.gameObject.transform);
        }
    }

    //private void StickToBar(Transform stickTransform)
    //{
    //    isStuck = true;
    //    transform.SetPositionAndRotation(stickTransform.transform.position, stickTransform.rotation);
    //    transform.SetParent(stickTransform,transform);
    //    float number = Random.Range(-1.0f, 1.0f);
    //    transform.position += new Vector3(number, 0, 0);
    //}

    private void StickToBar(Transform stickTransform)
    {
        GameObject efekt = Instantiate(particle, transform.position, Quaternion.identity);
        ParticleSystem ps = efekt.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = particleColor;

        isStuck = true;

        transform.SetParent(stickTransform);

        float number = Random.Range(-3.0f, -0.5f);

        transform.localPosition = new Vector3(transform.localPosition.x+number, 0, 0);

        //Yamukluk verme:
        transform.localRotation = Quaternion.Euler(0,0,Random.Range(-90f,90f));
    }
}


