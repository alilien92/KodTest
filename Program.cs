using System;
using HiQKodTest.Helpers;
using HiQKodTest.Models;

namespace HiQKodTest
{
    class Program
    {

        static void Main(string[] args) {

            RCUserModel model = new RCUserModel();
            RCUserHelper userHelper = new RCUserHelper();
            ValidationHelper validation = new ValidationHelper();
            Console.WriteLine("The RC Control App");

            Console.WriteLine("What Height/Width is the Room? Type two numbers seperated with a space!");
            bool correctSizeInput = false;
            while (!correctSizeInput) {
                try {
                    var sizes = Console.ReadLine().Split(" ");
                    model = userHelper.SetRoomSize(model, sizes);
                    correctSizeInput = validation.CheckMinSpace(model);
                } catch {
                    Console.WriteLine("Please follow the intructions for the inputs!");
                }
            }

            Console.WriteLine("Please give the starting position of the car! Type two numbers & heading of the car seperated with a space!");
            Console.WriteLine("The car's starting position can not be outside of the room size!");
            Console.WriteLine("Acceptable Heading Operators are N(North), W(West), E(East), S(South)");
            Console.WriteLine("");

            bool correctPostitionInput = false;
            while (!correctPostitionInput) {

                try {
                    var values = Console.ReadLine().Split(" ");
                    model = userHelper.SetCarPosition(model, values);
                    if (validation.CheckModelStatus(model)) {
                        if (validation.CheckHeadingInput(values[2])) {
                            correctPostitionInput = true;
                        }
                    }
                } catch {
                    Console.WriteLine("Please write the numbers and heading as previously instructed!");
                }
            }
            Console.WriteLine("Please type directional commands! Available commands are F, B, L, R");
            bool correctDirectionalInput = false;
            while (!correctDirectionalInput) {
                try {
                    var inputs = Console.ReadLine().ToCharArray();
                    model = userHelper.RunDirectionalInputs(model, inputs);
                    correctDirectionalInput = true;
                    Console.WriteLine(model.result);
                } catch {
                    Console.WriteLine("Please type directional commands as previously instructed!");
                }

            }
            Console.ReadLine();
        }

    }
}

