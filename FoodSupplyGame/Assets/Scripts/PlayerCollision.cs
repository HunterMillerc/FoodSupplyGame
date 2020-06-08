using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public MyPlayerMovement playerMovement;
    public GameManager gameManager;
    bool isFoodPicked;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FoodTag")
        {
            isFoodPicked = true;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Finish")
        {
            if(isFoodPicked == true)
            {
                gameManager.CompleteLevel();
            }
            else
            {
                Debug.Log("need to get food");
            }
        }
    }
}
