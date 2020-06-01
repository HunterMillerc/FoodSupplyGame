using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;

    Vector3 forward, right;

    private void Start()
    {
        forward = Camera.main.transform.forward;
    }
}
