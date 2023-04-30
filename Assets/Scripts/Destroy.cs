using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Untagged")||other.gameObject.CompareTag("Player")||other.gameObject.CompareTag("Obstacles"))
            Destroy(other.gameObject);
    }
}
