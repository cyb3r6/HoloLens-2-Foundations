using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager instance;

    
    void Awake()
    {
        instance = this;
    }

    public void ChoseAnimal(Animal animal)
    {
        


    }

    private void OnTriggerEnter(Collider other)
    {
        Animal animal = other.GetComponent<Animal>();

    }
}
