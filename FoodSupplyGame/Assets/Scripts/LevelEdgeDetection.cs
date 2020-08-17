using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEdgeDetection : MonoBehaviour
{
    public MyPlayerMovement playerMovement;
    public GameObject player;
    private Rigidbody playerRb;
    public BoxCollider playerCollider;
    public GameManager GameManager;
    public BoxCollider verticalFinishCollider;

    private void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("PlayerOutsideGroundTag").GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
        verticalFinishCollider = GameObject.FindGameObjectWithTag("VerticalFinishColliderTag").GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == playerCollider)
        {
            playerRb.isKinematic = false;
            playerRb.useGravity = true;
            playerMovement.enabled = false;
            player.transform.position = Vector3.Lerp(player.transform.position, transform.position, Time.deltaTime * 12.0f);
            Destroy(verticalFinishCollider);
            GameManager.FailedLevel();
        }
    }
}
