using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPipeNight : MonoBehaviour
{
    public static PoolPipeNight SharedInstance;
    public List<GameObject> pipesList;
    public GameObject prefabPipe;
    public int amountPool;
    // Start is called before the first frame update
    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        pipesList = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < amountPool; i++)
        {
            temp = Instantiate(prefabPipe);
            temp.SetActive(false);
            pipesList.Add(temp);
        }
    }

    public GameObject PoolPipes()
    {
        for (int i = 0; i < amountPool; i++)
        {
            if (!pipesList[i].activeInHierarchy)
            {
                return pipesList[i];
            }
        }

        return null;
    }
}
