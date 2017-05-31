using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace NewsApplication
{
    class ProfileValidationAttribute:ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            try
            {
                RegistrationUser login = value as RegistrationUser;
                using (NewsApplicationEntities db = new NewsApplicationEntities())
                {
                    var profile = db.Profiles;
                    foreach (Profile item in profile)
                    {
                        if (item.Login == login.Login)
                        {
                            this.ErrorMessage = "Такой логин уже существует!";
                            return false;
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter("ErrorReport.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(ex.ToString());
                }
                return false;
            }
        }
    }
}
