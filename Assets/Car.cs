//////////////////////////////////////////////
//Assignment/Lab/Project: Car Class
//Name: Malcolm Donaldson
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 2/13/2024
/////////////////////////////////////////////

public class Car
{
    private int yearOfCar = 2024;
    private string makeOfCar = "Honda";
    private int maxSpeedInMPH = 100;
    private int currentSpeedInMPH;

    public int YearOfCar 
    {
        get 
        {
            return yearOfCar;        
        }
        set
        {            
            yearOfCar = value;
        }
    }

    public string MakeOfCar 
    {
        get 
        {
            return makeOfCar;
        }
        set 
        {
            makeOfCar = value;
        }
    }

    public void AccelerateCar() 
    {
        if(currentSpeedInMPH <= maxSpeedInMPH) 
        {
            currentSpeedInMPH++;
        }        
    }

    public void DecelerateCar() 
    {
        if(currentSpeedInMPH > 0) 
        {
            currentSpeedInMPH--;
            if(currentSpeedInMPH == 0) 
            {
                currentSpeedInMPH = 0;
            }
        }
    }
}