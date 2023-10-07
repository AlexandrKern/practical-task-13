using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сreating_an_account
{
    public class UserAccount
    {
        /// <summary>
        /// Открывает счет
        /// </summary>
        /// <returns></returns>
        public static ulong OpenAnAccount()
        {
            var r = new Random();                   /*генерируем случайное число типа ulong*/
            var b = new byte[sizeof(ulong)];
            r.NextBytes(b);
            var res = BitConverter.ToUInt64(b, 0);
            return res;
        }
    }
}
