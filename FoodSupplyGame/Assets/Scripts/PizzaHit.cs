using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaHit : MonoBehaviour
{
    public BoxCollider FoodCollider;
    public GameObject Pizza;

    public bool foodPickedUp = false;

    private void Start()
    {
        FoodCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
        Pizza = GameObject.FindGameObjectWithTag("FoodTag");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == FoodCollider)
        {
            foodPickedUp = true;
            Destroy(Pizza);
        }
    }
}
