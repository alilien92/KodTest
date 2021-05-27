using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HiQKodTest.Models;

namespace HiQKodTest.Helpers
{
    public class RCUserHelper
    {
        ValidationHelper validation = new ValidationHelper();
        //START OF SET-METHODS***
        //Set size of room in model
        public RCUserModel SetRoomSize(RCUserModel model, string[] sizes) {
            
            model.room.height = Convert.ToInt32(sizes[0]);
            model.room.width = Convert.ToInt32(sizes[1]);
            return model;
        }

        public RCUserModel SetCarPosition(RCUserModel model, string[] values) {
            model.car.positionY = Convert.ToInt32(values[0]);
            model.car.positionX = Convert.ToInt32(values[1]);
            model.car.heading = values[2];
            return model;
        }
        //Sets model result depending on model status
        public string SetResult(RCUserModel model) {
            if (validation.CheckModelStatus(model)) {
                model.result = "Success! The car is at " + model.car.positionY + " " + model.car.positionX + " heading " + model.car.heading + "!";
                return model.result;
            }
            model.result = "The Car Drove into a wall at " + model.car.positionY + " " + model.car.positionX;
            return model.result;
        }

        //END OF SET METHODS***

        //START OF CAR MOVE METHODS
        //Runs all directional inputs from program
        public RCUserModel RunDirectionalInputs(RCUserModel model, char[] inputs) {
            for (int i = 0; i < inputs.Length; i++) {
                if (validation.CheckDirectionalInputs(inputs[i].ToString())) {
                    model = MoveCar(model, inputs[i].ToString()); ;
                    if (!validation.CheckModelStatus(model)) {
                        break;
                    }
                }
            }
            return model;
        }
        //Determines heading of the car has and moves it accordingly
        public RCUserModel MoveCar(RCUserModel model, string input) {

            if (validation.CheckModelStatus(model)) {
                if (model.car.heading == "N") {
                    MoveCarNorth(model, input);
                    model.result = SetResult(model);
                    return model;
                }
                if (model.car.heading == "W") {
                    MoveCarWest(model, input);
                    model.result = SetResult(model);
                    return model;
                }
                //Check S Heading
                if (model.car.heading == "S") {
                    MoveCarSouth(model, input);
                    model.result = SetResult(model);
                    return model;
                }
                if (model.car.heading == "E") {
                    MoveCarEast(model, input);
                    model.result = SetResult(model);

                    return model;
                }
            }
            model.result = SetResult(model);
            return model;
        }

        public RCUserModel MoveCarNorth(RCUserModel model, string input) {

            if (input == "F") {
                model.car.positionY = model.car.positionY + 1;
            }
            if (input == "B") {
                model.car.positionY = model.car.positionY - 1;
            }
            if (input == "L") {
                model.car.heading = "W";
            }
            if (input == "R") {
                model.car.heading = "E";
            }
            return model;
        }

        public RCUserModel MoveCarSouth(RCUserModel model, string input) {
            if (input == "F") {
                model.car.positionY = model.car.positionY - 1;
            }
            if (input == "B") {
                model.car.positionY = model.car.positionY + 1;
            }
            if (input == "L") {
                model.car.heading = "E";
            }
            if (input == "R") {
                model.car.heading = "W";
            }
            return model;
        }
        public RCUserModel MoveCarEast(RCUserModel model, string input) {

            if (input == "F") {
                model.car.positionX = model.car.positionX + 1;
            }
            if (input == "B") {
                model.car.positionX = model.car.positionX - 1;
            }
            if (input == "L") {
                model.car.heading = "N";
            }
            if (input == "R") {
                model.car.heading = "S";
            }
            return model;
        }

        public RCUserModel MoveCarWest(RCUserModel model, string input) {

            if (input == "F") {
                model.car.positionX = model.car.positionX - 1;
            }
            if (input == "B") {
                model.car.positionX = model.car.positionX + 1;
            }
            if (input == "L") {
                model.car.heading = "N";
            }
            if (input == "R") {
                model.car.heading = "S";
            }
            return model;
        }
        //END OF CAR MOVE METHODS

        

    }
}
