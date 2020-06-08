using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    public float tumblingDuration = 0.2f;

    public void Start()
    {
        sideAxises = GameObject.FindGameObjectsWithTag("SideAxisTag");
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;
        horizontalKeyMove = Input.GetAxis("HorizontalKey");
        verticalKeyMove = Input.GetAxis("VerticalKey");

        if (isPlayerVertical)
        {
            if (horizontalKeyMove == 1)
            {
                direction = new Vector3(3, 0, 0);
            }
            if(horizontalKeyMove == -1)
            {
                direction = new Vector3(-3, 0, 0);
            }
            if(verticalKeyMove == 1)
            {
                direction = new Vector3(0, 0, 3);
            }
            if(verticalKeyMove == -1)
            {
                direction = new Vector3(0, 0, -3);
            }
        }

        if (!isPlayerVertical)
        {
            if (horizontalKeyMove == 1) 
            {
                direction = new Vector3(2f, 0, 0);
            }
            if (horizontalKeyMove == -1)
            {
                direction = new Vector3(-2f, 0, 0);
            }
            if (verticalKeyMove == 1)
            {
                direction = new Vector3(0, 0, 2f);
            }
            if (verticalKeyMove == -1)
            {
                direction = new Vector3(0, 0, -2f);
            }
        }

        if (direction != Vector3.zero && !isTumbling)
        {
            StartCoroutine(Tumble(direction));
        }
    }
    float horizontalKeyMove;
    float verticalKeyMove;

    public bool isPlayerVertical;
    Collision collision;

    bool isTumbling = false;
    bool sideTumble = false;

    //Use these to check if game object is being rolled on its long side
    public GameObject[] sideAxises;

    IEnumerator Tumble(Vector3 direction)
    {
        isTumbling = true;

        var rotAxis = Vector3.Cross(Vector3.up, direction);
        var pivot = (transform.position + Vector3.down * 0.5f) + direction * 0.5f;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        var startPosition = transform.position;

        sideTumble = isRollingSideways(pivot);
        Debug.Log(pivot);

        var rotSpeed = 90.0f / tumblingDuration;
        var t = 0.0f;

        while (t < tumblingDuration)
        {
            t += Time.deltaTime;
            if (t < tumblingDuration)
            {
                transform.RotateAround(pivot, rotAxis, rotSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                transform.rotation = endRotation;
                if (sideTumble && !isPlayerVertical)
                {
                    Debug.Log(sideTumble);
                    transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z) + direction;
                }
                if (sideTumble && isPlayerVertical)
                {
                    Debug.Log(sideTumble);
                    transform.position += direction;
                }
                else if (!sideTumble && !isPlayerVertical)
                {
                    Debug.Log(sideTumble);
                    transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z) + direction;
                }
                else if (!sideTumble && isPlayerVertical)
                {
                    Debug.Log(sideTumble);
                    transform.position = new Vector3(startPosition.x, startPosition.y - 1, startPosition.z) + direction;
                }
            }
        }

        isTumbling = false;
    }

    bool isRollingSideways(Vector3 pivotPoint)
    {
        foreach (GameObject sideAxis in sideAxises)
        {
            if (pivotPoint == sideAxis.transform.position)
            {
                return true;
            }
        }
        return false;
    }
}
