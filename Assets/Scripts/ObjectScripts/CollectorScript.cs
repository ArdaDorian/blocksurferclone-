using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectorScript : MonoBehaviour
{
    GameManager gameManager;
    public GameObject mainCube;
    int height, prevHeight;
    float angle;

    private void Update()
    {
        MainCubePositionChanger();
        CollectorPosition();
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void CollectorPosition()
    {
        this.transform.localPosition = new Vector3(0, -height, 0);
    }

    private void MainCubePositionChanger()
    {
        if(prevHeight<height)
            mainCube.transform.position = new Vector3(mainCube.transform.position.x, height + 1, mainCube.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectible") && !other.GetComponent<CollectibleScript>().IsCollected())
        {
            prevHeight = height;
            height++;
            other.GetComponent<CollectibleScript>().Collected();
            other.GetComponent<CollectibleScript>().AdjustIndex(height);
            other.transform.parent = mainCube.transform;
        }

        else if (other.CompareTag("diamond"))
        {
            LevelManager.instance.diamondCount++;
            UIManager.instance.IncreaseDiamond();
            other.gameObject.SetActive(false);
        }

        else if (other.CompareTag("finish"))
        {
            gameManager.GameOver(true);
        }

        else if (other.CompareTag("corner"))
        {
            float prevRotation = mainCube.transform.rotation.y;
            
            if (other.GetComponent<CornerManager>().turnRight)
            {
                StartCoroutine(ChracterRotaterRoutine(prevRotation,90));
                LevelManager.instance.movementStatues=1;
            }
            else
            {
                StartCoroutine(ChracterRotaterRoutine(prevRotation, - 90));
                LevelManager.instance.movementStatues = 0;
            }
        }
    }

    private IEnumerator ChracterRotaterRoutine(float prevRotation,int rotation)
    {
        yield return new WaitForSeconds(.2f);
        mainCube.GetComponent<Transform>().DORotate(new Vector3(mainCube.transform.rotation.x, prevRotation + rotation, mainCube.transform.rotation.z), .7f, RotateMode.FastBeyond360);
    }

    public void DecreaseHeight()
    {
        prevHeight = height;
        height--;
    }
}
