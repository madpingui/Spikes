using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeactivator : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
            collision.gameObject.SetActive(false);
    }
}
