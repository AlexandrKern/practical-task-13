using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_task_13
{
    public class AccountException : Exception
    {  
       
        public AccountException():base("Количество цифр в счете меньше 16, создайте новый счет!")
        {
            
        }

    }
}
