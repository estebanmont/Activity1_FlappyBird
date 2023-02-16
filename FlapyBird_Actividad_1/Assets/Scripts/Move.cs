using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]private float speed;
    private void Update()
    {
        transform.position += (Vector3.left * Time.deltaTime * speed);

        StartCoroutine(DestroyPipes());
    }

    IEnumerator DestroyPipes ()
    {
        yield return new WaitForSeconds (2.5f);
        gameObject.SetActive(false);

    }


}
