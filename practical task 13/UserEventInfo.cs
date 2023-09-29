using banking_system_prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace banking_system_prototype
{
    class UserEventInfo
    {
        public static string info { get; set; }

        public UserEventInfo()
        {
            User.evenеtRecording += User_EvenеtRecording;
        }
        private void User_EvenеtRecording(string a)
        {
            info = a;
        }

    }
}