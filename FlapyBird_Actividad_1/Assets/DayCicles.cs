using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayCicles : MonoBehaviour
{
    [SerializeField] UnityEvent onDay, onNight;
    public bool dia, noche;
    private void Awake()
    {
        float temporal = Random.Range(0f, 1f);
        if(temporal< 0.5f)
        {
            onDay.Invoke();
            dia = true; 
            
        }
        else if(temporal > 0.5f)
        {
            onNight.Invoke();
            noche = true; 
        }
    }
}
