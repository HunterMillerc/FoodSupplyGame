using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public MyPlayerMovement playerMovement;
    private string objectHit;

    void OnTriggerEnter(Collider collider)
    {
        objectHit = collider.gameObject.tag;
        if(objectHit == "GroundTag")
        {
            playerMovement.isPlayerVertical = false;
        }
    }
}
