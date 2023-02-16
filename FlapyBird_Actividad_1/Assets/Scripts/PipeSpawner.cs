using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [Space, SerializeField, Range(-1.5f, .8f)] private float minHeigh, maxHeigh;
    [SerializeField] private float spawnTime;
    [SerializeField] GameObject backGround;
    private DayCicles dayTime;

    private void Awake()
    {
        if (backGround != null)
        {
            this.dayTime = backGround.GetComponent<DayCicles>();
        }
    }

    private void Start()
    {
       if (dayTime.dia)
        {
            StartCoroutine(SpawnPoolPipes());
        }
       else if (dayTime.noche)
        {
            StartCoroutine(SpawnPoolPipesNight());
        }
    }

    private Vector3 GetSpawn()
    {
        return new Vector3(spawnPoint.position.x, Random.Range(minHeigh, maxHeigh), spawnPoint.position.z);
    }

    private IEnumerator SpawnPoolPipes()
    {
        do
        {
            yield return new WaitForSeconds(spawnTime);
            GameObject pipe = PoolPipe.SharedInstance.PoolPipes();
            if (pipe != null)
            {
                pipe.transform.position = GetSpawn();
                pipe.SetActive(true);
            }

        } while (true);
    }

    public void StopPool()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnPoolPipesNight()
    {
        do
        {
            yield return new WaitForSeconds(spawnTime);
            GameObject pipe = PoolPipeNight.SharedInstance.PoolPipes();
            if (pipe != null)
            {
                pipe.transform.position = GetSpawn();
                pipe.SetActive(true);
            }

        } while (true);
    }
}
