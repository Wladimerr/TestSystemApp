using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestSystemApp.Classes
{
    public static class Validator
    {

        public static bool IsValidatePass(string password)
        {
            string pattern = @"(?=^.{6,}$)((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$)";
            if (!Regex.IsMatch(password, pattern))
            {
                //MessageBox.Show("Пароль должен содержать больше 6 символов, цифры, заглавные и строчные латинские буквы");
                return false;
            }
            else return true;
        }

        public static bool IsEqualPass(string pass, string repeatPass)
        {
            if (pass == repeatPass)
            {
                return true;
            }
            else
            {
                // MessageBox.Show("Пароли не совпадают!");
                return false;
            }
        }

        public static string[] SeparateFIO(string fio)
        {
            string[] res = fio.Split(new char[] { ' ' });
            return res;
        }
    }
}
