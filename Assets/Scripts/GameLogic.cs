using System.Threading;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private float spawnTime = 0.5f;
    [SerializeField] public GameObject[] objects;
    private Vector3 pos;


    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            SpawnRandomObject();
            spawnTime = 0.5f;
        }
    }

    private void SpawnRandomObject()
    {
        float offset = Random.Range(-2.0f , 2.0f);
        pos = transform.position;
        pos += new Vector3(offset, 0, 0); 
        int length = objects.Length; //will be used in random object generate
        int randomi = Random.Range(0, length); 
        Instantiate(objects[randomi], pos, Quaternion.identity);
    }
}
