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
    [SerializeField] List<TextMeshProUGUI> playerInputField = new List<TextMeshProUGUI>(2);
    [SerializeField] List<TextMeshProUGUI> feedbackText = new List<TextMeshProUGUI>(5);
    [SerializeField] GameObject submitButton; 
    private Car inputCar;

    // Start is called before the first frame update
    void Start()
    {
        TurnOffFeedback(feedbackText);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Input field method
    private void CarInstantiate(string make, int year, List<TextMeshProUGUI> feedback) 
    {
        TurnOffFeedback(feedback);
        if (make != "Error" && year != 0) 
        {            
            inputCar.YearOfCar = year;
            inputCar.MakeOfCar = make;            
        }
        else 
        {
            feedback[4].SetText($"Invalid Input!\r\nDouble check car Make spelling.\r\nYear has to be after 1886.");
        }
    }  
    
    //Method to check and give the car models info
    private string MakeInput(List<TextMeshProUGUI> playerInput) 
    {
        List<string> carModelCheck = CarModels();
        string input = playerInput[0].ToString();
        for(int index = 0; index < carModelCheck.Count; index++) 
        {
            if(input == carModelCheck[index]) 
            {
                return input;
            }
        }
        return "Error";
    }

    //Making List of car makes
    private List<string> CarModels() 
    {
        List<string> models = new List<string>();
        StreamReader listOfCarModels = File.OpenText(Application.streamingAssetsPath + "/CarMakeList.docx");
        while (!listOfCarModels.EndOfStream) 
        {
            string carModel = listOfCarModels.ReadLine();
            models.Add(carModel);
        }
        listOfCarModels.Close();
        return models;
    }

    //Method to check year
    private int CarYear(List<TextMeshProUGUI> playerInput)
    {
        string input = playerInput[1].ToString();
        int carYear = 0; 
        int.TryParse(input, out carYear);
        if (carYear >= 1886 && carYear <= 2024) 
        {
            return carYear;
        }
        carYear = 0;
        return carYear;
    }

    //Feedback turn off method
    private void TurnOffFeedback(List<TextMeshProUGUI> feedbackText) 
    {
        for(int i = 0; i < feedbackText.Count; i++) 
        {
            feedbackText[i].SetText("");
        }
    }

    //Submit button method
    public void OnSubmitClick() 
    {        
        CarInstantiate(MakeInput(playerInputField), CarYear(playerInputField), feedbackText);
    }
}
