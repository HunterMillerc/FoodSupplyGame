using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaHit : MonoBehaviour
{
    public BoxCollider FoodCollider;
    public GameObject Pizza;

    public bool foodPickedUp = false;
    public GameObject PizzaNotCollected;
    public GameObject PizzaCollected;

    private void Start()
    {
        FoodCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
        Pizza = GameObject.FindGameObjectWithTag("FoodTag");
        PizzaNotCollected.SetActive(true);
        PizzaCollected.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == FoodCollider)
        {
            foodPickedUp = true;
            Destroy(Pizza);
            PizzaNotCollected.SetActive(false);
            PizzaCollected.SetActive(true);
        }
    }
}
