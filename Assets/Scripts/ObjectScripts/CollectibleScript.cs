using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    CollectorScript collectorScript;

    private bool isCollected;
    private int index;

    private void Awake()
    {
        collectorScript = FindObjectOfType<CollectorScript>();
    }

    private void Update()
    {
        if (transform.parent != null && isCollected)
        {
            LocalPosChanger();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            collectorScript.DecreaseHeight();
            this.transform.parent = null;
            //GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void LocalPosChanger()
    {
        this.transform.localPosition = new Vector3(0, -index, 0);
    }

    public bool IsCollected()
    {
        return isCollected;
    }

    public void Collected()
    {
        isCollected = true;
    }

    public void AdjustIndex(int height)
    {
        this.index = height;
    }
}
