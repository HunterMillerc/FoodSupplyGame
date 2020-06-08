using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float tumblingDuration = 0.2f;

    void FixedUpdate()
    {
        var dir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            dir = new Vector3(0, 0, 3);

        if (Input.GetKey(KeyCode.DownArrow))
            dir = new Vector3(0, 0, -3);

        if (Input.GetKey(KeyCode.LeftArrow))
            dir = new Vector3(-3, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow))
            dir = new Vector3(3, 0, 0);

        if (dir != Vector3.zero && !isTumbling)
        {
            StartCoroutine(Tumble(dir));
        }
    }

    bool isTumbling = false;
    IEnumerator Tumble(Vector3 direction)
    {
        isTumbling = true;

        var rotAxis = Vector3.Cross(Vector3.up, direction);
        var pivot = (transform.position + Vector3.down * 0.5f) + direction * 0.5f;

        var startRotation = transform.rotation;
        var endRotation = Quaternion.AngleAxis(90.0f, rotAxis) * startRotation;

        var startPosition = transform.position;
        var endPosition = transform.position + direction;

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
                transform.position = endPosition;
            }
        }

        isTumbling = false;
    }
}