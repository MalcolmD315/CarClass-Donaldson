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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Input field method
    private void CarInstantiate(string make, string model, int year) 
    {
        if(make != "Error" && year != 0) 
        {
            
        }        
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

    //Method to check year
    private int CarYear(List<string> playerInput)
    {
        int carYear = int.Parse(playerInput[2]);
        if (carYear >= 1886 && carYear <= 2024) 
        {
            return carYear;
        }
        carYear = 0;
        return carYear;
    }
}
