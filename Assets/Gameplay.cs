//////////////////////////////////////////////
//Assignment/Lab/Project: Car Class
//Name: Malcolm Donaldson
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/13/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
    //Variables for player input field
    [SerializeField] List<TextMeshProUGUI> playerInputField = new List<TextMeshProUGUI>(3);
    [SerializeField] GameObject submitButton;
    [SerializeField] GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Input field method
    private GameObject CarInstantiate() 
    {
        return GameObject.Instantiate(car);
    }
}
