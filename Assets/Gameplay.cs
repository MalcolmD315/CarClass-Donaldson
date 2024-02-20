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
    [SerializeField] GameObject quitButton;
    private Car inputCar;

    // Start is called before the first frame update
    void Start()
    {
        TurnOffFeedback(feedbackText);       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {           
            inputCar.AccelerateCar();
            feedbackText[0].SetText($"{inputCar.CurrentSpeed} MPH");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {           
            inputCar.DecelerateCar();
            feedbackText[0].SetText($"{inputCar.CurrentSpeed} MPH");
        }
    }

    //Input field method
    private Car CarInstantiate(string make, int year, List<TextMeshProUGUI> feedback, Car car) 
    {
        TurnOffFeedback(feedback);
        if (make != "Error" && year != 0) 
        {
            car = CarCreating(feedback, make, year);
            return car;
        }
        else 
        {
            feedback[4].SetText($"Invalid Input!\r\nDouble check car Make spelling.\r\nYear has to be after 1886.");
        }
        return null;
    }  
    
    //Method to check and give the car models info
    private string MakeInput(TextMeshProUGUI make) 
    {
        List<string> checkList = CarMakes();
        string playerInput = make.text; 
        playerInput = playerInput.Remove(playerInput.Length - 1);
        foreach(string makeList in checkList) 
        {
            if(playerInput == makeList) 
            {                                
                return playerInput;
            }
        }
        return "Error";
    }

    //Making List of car makes
    private List<string> CarMakes() 
    {
        List<string> makes = new List<string>();
        StreamReader listOfCarMakes = File.OpenText(Application.streamingAssetsPath + "/CarList.txt");
        while (!listOfCarMakes.EndOfStream) 
        {
            string carMakes = listOfCarMakes.ReadLine();
            makes.Add(carMakes);
        }
        return makes;
    }

    //Method to check year
    private int CarYear(TextMeshProUGUI year)
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
        inputCar = CarInstantiate(MakeInput(makeInput), CarYear(yearInput), feedbackText, inputCar);
    }

    //Quit button method
    public void OnQuitClick() 
    {
        Application.Quit();
    }

    //Creating the car in ui
    private Car CarCreating(List<TextMeshProUGUI> feedback, string make, int year) 
    {
        Car playerCar = new Car();
        playerCar.MakeOfCar = make;
        playerCar.YearOfCar = year;
        feedback[3].SetText($"Current Speed:");
        feedback[2].SetText($"Year: {playerCar.YearOfCar}");
        feedback[1].SetText($"Make: {playerCar.MakeOfCar}");
        feedback[0].SetText($"{playerCar.CurrentSpeed} MPH");

        return playerCar;        
    }
}
