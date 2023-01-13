using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] float forwardSpeed, horizontalSpeed;
    float horizontal;

    [SerializeField] float axisXmin, axisXmax, axisZmin, axisZmax;

    Vector3 mousePos;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(gameManager.isMoving)
            PlayerMovement();
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.CompareTag("obstacle"))
        {
            gameManager.GameOver(false);
        }
    }

    private void PlayerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            horizontal = (Input.mousePosition.x - mousePos.x) / Screen.width * 1.5f;
            mousePos = Input.mousePosition;
        }

        switch (LevelManager.instance.movementStatues)
        {
            case 0: ChracterDirection(1, 0, 1,0, 1 * Time.deltaTime*forwardSpeed); MovementLimit(Mathf.Clamp(transform.position.x,axisXmin,axisXmax),transform.position.z); break;

            case 1: ChracterDirection(0, 1, -1,1 * forwardSpeed * Time.deltaTime, 0); MovementLimit(transform.position.x,Mathf.Clamp(transform.position.z,axisZmin,axisZmax)); break;

        }
    }

    void ChracterDirection(float horizontalX,float horizontalZ,float horizontalDirection, float forwardX, float forwardZ)
    {
        transform.position += new Vector3(horizontalX, 0, horizontalZ) * horizontal * horizontalSpeed*horizontalDirection;
        transform.position += new Vector3(forwardX, 0, forwardZ);
    }

    void MovementLimit(float xAxis,float zAxis)
    {
        transform.position = new Vector3(xAxis, transform.position.y, zAxis);
    }
}
