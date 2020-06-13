using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCubeCheck : MonoBehaviour
{
    public PizzaHit pizzaScript;
    public BoxCollider VerticalFinishCollider;
    public MyPlayerMovement playerMovement;
    public GameManager gameManager;

    private void Start()
    {
        VerticalFinishCollider = GameObject.FindGameObjectWithTag("VerticalFinishColliderTag").GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == VerticalFinishCollider)
        {
            if(pizzaScript.foodPickedUp == false)
            {
                Debug.Log("Need to pick up food buddy");
            }
            else
            {
                gameManager.CompleteLevel();
                playerMovement.enabled = false;
            }
        }
    }
}
