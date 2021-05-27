using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HiQKodTest.Models;

namespace HiQKodTest.Helpers
{
    public class ValidationHelper
    {
        //Validation Methods
        public bool CheckDirectionalInputs(string input) {

            return Regex.IsMatch(input, @"[FLRB]");
        }
        public bool CheckHeadingInput(string input) {

            return Regex.IsMatch(input, @"[NSWE]");
        }

        public bool CheckModelStatus(RCUserModel model) {
            if (CheckMaxPosition(model) & CheckMinPosition(model)) {
                return true;
            }
            return false;
        }

        public bool CheckMinSpace(RCUserModel model) {

            if (model.room.height < 0 || model.room.width < 0) {

                return false;
            }
            return true;
        }

        public bool CheckMaxPosition(RCUserModel model) {
            if (model.car.positionY > model.room.height || model.car.positionX > model.room.width) {
                return false;
            }
            return true;
        }

        public bool CheckMinPosition(RCUserModel model) {
            if (model.car.positionY < 0 || model.car.positionX < 0) {
                return false;
            }
            return true;
        }
    }
}
