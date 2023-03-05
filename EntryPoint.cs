
using Rage;
using Rage.Attributes;
using Rage.Native;
using System;
using System.Drawing;

[assembly: Plugin("Debugg Fuel", Description = "Fuel system for vehicles", Author = "Debugg")]
namespace Debugg_Fuel
{
    //Add new vehicles to array + fuel level (use RandomFuelLevel)
    //If player enters a vehicle that already exists in the array then fetch fuel level
    //Once fuel hits 0, disable vehicle;
    //Push vehicles?
    //Fueling stations (tba)
    //Basic UI
    public static class EntryPoint
    {
        public static System.Object N = NativeFunction.Natives;
        public static void Main()
        {
            //Entry point

            //Only display if in a vehicle
            DisplayScreenText(new PointF(0.0f, 0.0f), 12f, "Hello", Color.White);


        }

        #region Fuel Functions
        public static float MaxFuel(Vehicle vehicle)
        {
            return vehicle.HandlingData.PetrolTankVolume;
        }

        public static float RandomFuelLevel(float maxFuel)
        {
            Random rnd = new Random();
            float min = maxFuel / 3f; // 1/3 of max capacity
            float max = maxFuel - (maxFuel / 4); // 3/4 of max capacity ex: (65 - (65/4) = 49 (75% of 65)) 
            
            return (float) rnd.NextDouble() * (max - min) + min;
        }
        #endregion

        #region UI Functions

        public static void DisplayScreenText(PointF pos, float scale, string text, Color color)
        {
            Rage.Graphics.DrawText(text, "Arial", scale, pos, color); //CS0120  An object reference is required for the non-static field, method, or property 'Graphics.DrawText(string, string, float, PointF, Color)'

        }

        #endregion
    }
}
