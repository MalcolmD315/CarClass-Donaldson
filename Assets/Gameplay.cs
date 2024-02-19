//////////////////////////////////////////////
//Assignment/Lab/Project: Car Class
//Name: Malcolm Donaldson
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/13/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;

public class Gameplay : MonoBehaviour
{
    //Variables for player input field
    [SerializeField] TextMeshProUGUI makeInput;
    [SerializeField] TextMeshProUGUI yearInput;
    [SerializeField] List<TextMeshProUGUI> feedbackText = new List<TextMeshProUGUI>(5);
    [SerializeField] GameObject submitButton; 
    private List<string> listOfMakes = new List<string>();
    private Car inputCar;

    // Start is called before the first frame update
    void Start()
    {
        TurnOffFeedback(feedbackText);
        CarModels(listOfMakes);        
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
            CarCreating(feedback, inputCar, make, year);               
        }
        else 
        {
            feedback[4].SetText($"Invalid Input!\r\nDouble check car Make spelling.\r\nYear has to be after 1886.");
        }
    }  
    
    //Method to check and give the car models info
    private string MakeInput(TextMeshProUGUI make, Car car, List<string> listofMakes) 
    {        
        string playerInput = make.text; 
        playerInput = playerInput.Remove(playerInput.Length - 1);
        foreach(string makeList in listOfMakes) 
        {
            if(playerInput == makeList) 
            {
                Debug.Log(playerInput);                
                return playerInput;
            }
        }
        return "Error";
    }

    //Making List of car makes
    private void CarModels(List<string> makes) 
    {        
        StreamReader listOfCarMakes = File.OpenText(Application.streamingAssetsPath + "/CarList.txt");
        while (!listOfCarMakes.EndOfStream) 
        {
            string carMakes = listOfCarMakes.ReadLine();
            makes.Add(carMakes);
        }        
    }

    //Method to check year
    private int CarYear(TextMeshProUGUI year, Car car)
    {
        string input = year.text;
        input = input.Remove(input.Length - 1);
        int carYear = 0;        
        if (int.TryParse(input, out carYear)) 
        {
            if (carYear >= 1886 && carYear <= 2024)
            {                                
                return carYear;
            }
        }                
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
        CarInstantiate(MakeInput(makeInput, inputCar, listOfMakes), CarYear(yearInput, inputCar), feedbackText);
    }

    //Creating the car in ui
    private void CarCreating(List<TextMeshProUGUI> feedback, Car car, string make, int year) 
    {
        Car playerCar = new Car();
        playerCar.MakeOfCar = make;
        playerCar.YearOfCar = year;
        feedback[3].SetText($"Current Speed:");
        feedback[2].SetText($"Year: {playerCar.YearOfCar}");
        feedback[1].SetText($"Make: {playerCar.MakeOfCar}");
        feedback[0].SetText($"{playerCar.CurrentSpeed} MPH");
    }
}
