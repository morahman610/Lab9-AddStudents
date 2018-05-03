using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gradebook
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(Welcome());

            List<string> names = new List<string>();
            List<string> hometown = new List<string>();
            List<string> food = new List<string>();
            List<string> activity = new List<string>();

            while (true)
            {

                names.Add("Mohammed");
                names.Add("Diana");
                names.Add("Rebekah");
                names.Add("Nadim");
                names.Add("Mubin");

                hometown.Add("Detroit");
                hometown.Add("Hamtramck");
                hometown.Add("New York");
                hometown.Add("The Bronx");
                hometown.Add("Canton");

                food.Add("Chicken 65");
                food.Add("Shrimp Fried Rice");
                food.Add("Chicken Noodle Soup");
                food.Add("Biryani");
                food.Add("Butter Chicken");

                activity.Add("basketball");
                activity.Add("watching TV");
                activity.Add("bowling");
                activity.Add("reading");
                activity.Add("sleeping");

                Console.WriteLine("Would you like to add information for a student? If so then enter 'y', else enter any key to continue.");
                string StudentAdded = Console.ReadLine();
                if (StudentAdded.ToLower() == "y")
                {
                    Console.WriteLine("What is the name of the student you want to add?");
                    //string NewStudentName = Console.ReadLine();
                    names.Add(ValidateAddedStudent());

                    Console.WriteLine("What is the hometown of the student you want to add?");
                    //string NewStudentHometown = Console.ReadLine();
                    hometown.Add(ValidateAddedStudent());

                    Console.WriteLine("What is this students favorite food?");
                    //string NewStudentFood = Console.ReadLine();
                    food.Add(ValidateAddedStudent());

                    Console.WriteLine("What is this students favorite leisure activity?");
                    //string NewStudentActivity = Console.ReadLine();
                    activity.Add(ValidateAddedStudent());
                }

                int student = AskForUserInput(names.Count());


                TakeResponses(names[student], hometown[student], food[student], activity[student]);




                Console.WriteLine("Would you like to learn about another student? Press Y to continue or press any other key to quit");
                string DoAgain = Console.ReadLine();
                if (!(DoAgain.ToLower() == "y"))
                {
                    return;

                }

                continue;
            }
        }

        static string ValidateAddedStudent()
        {
            while(true)
            {
                Console.WriteLine("Please enter a valid input.");
                string NewInfo = Console.ReadLine();
                if (Regex.IsMatch(NewInfo, @"^([A-Za-z]){1,30}$") == true)
                {
                    return NewInfo;
                }
            }
        }

        static void AddStudent (string name, string hometown, string food, string activity)
        {

        }


        static void TakeResponses(string name, string hometown, string food, string activity)
        {
            Console.WriteLine($"You've entered: {name}.");
            while (true)
            {
                Console.WriteLine($"What would you like to konw about {name}? (enter 'hometown', 'favorite food', or 'favorite activity'. Enter Q to quit.)");
                string hometownOrFood = Console.ReadLine().ToLower();

                if (hometownOrFood == "favorite food")
                {
                    Console.WriteLine($"{name}'s favorite food is {food}.\n");

                }

                else if (hometownOrFood == "favorite activity")
                {
                    Console.WriteLine($"{name}'s favorite food is {activity} \n");
                    
                }

                else if (hometownOrFood == "hometown")
                {
                    Console.WriteLine($"{name}'s favorite food is {hometown}. \n");
                }
                else if (hometownOrFood == "q")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Please try again by pressing any key or learn about another student by entering 'q'. \n");
                    string TryAgain = Console.ReadLine();
                    if (TryAgain.ToLower() == "q")
                    {
                        return;
                    }

                }
            }
        }

        static string Welcome()
        {
            string welcome = "Welcome to  the C# Meridian Bootcamp. Which student would you like to learn more about? \n";
            return welcome;
        }

        static int AskForUserInput(int length)
        {

            while (true)
            {
                Console.WriteLine($"Enter a integer between 1-{length} to represent a student you want to look up");

                string UserInput = Console.ReadLine();

                if (!(int.TryParse(UserInput, out int student)) || student < 1 || student > length + 1)
                {
                    Console.WriteLine("Invalid Input. You did not enter an integer between 1-5");
                }

                else
                {
                    student = student - 1;
                    return student;
                }
            }

        }
    }
}