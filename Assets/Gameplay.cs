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
using System.IO;

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
    
    //Method to check and give the car models info
    private string MakeInput(List<string> playerInput) 
    {
        List<string> carModelCheck = CarModels();
        for(int index = 0; index < carModelCheck.Count; index++) 
        {
            if(playerInput[0] == carModelCheck[index]) 
            {
                return playerInput[index];
            }
        }
        return "Error";
    }

    //Making List of car makes
    private List<string> CarModels() 
    {
        List<string> models = new List<string>();
        StreamReader listOfCarModels = File.OpenText(Application.streamingAssetsPath + "/words.txt");
        while (!listOfCarModels.EndOfStream) 
        {
            string carModel = listOfCarModels.ReadLine();
            models.Add(carModel);
        }
        listOfCarModels.Close();
        return models;
    }

    
}
