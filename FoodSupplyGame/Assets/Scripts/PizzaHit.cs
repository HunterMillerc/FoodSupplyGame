using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaHit : MonoBehaviour
{
    public BoxCollider FoodCollider;
    public GameObject Pizza;

    private void Start()
    {
        FoodCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
        Pizza = GameObject.FindGameObjectWithTag("FoodTag");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == FoodCollider)
        {
            Destroy(Pizza);
        }
    }
}
