using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace banking_system_prototype
{
    public class Client<T1, T2, T3>
    {
        /// <summary>
        /// Имя
        /// </summary>
        public T1 name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public T2 lastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public T3 patronymic { get; set; }
        /// <summary>
        /// Депозитный счет
        /// </summary>
        public ulong depositAccount { get; set; }
        /// <summary>
        /// Недепозитный счет
        /// </summary>
        public ulong nonDepositAccount { get; set; }
        /// <summary>
        /// Средства на депозитном счету
        /// </summary>
        public int moneyDeposit { get; set; }
        /// <summary>
        /// Средства на недепозитном счету
        /// </summary>
        public int moneyNonDeposit { get; set; }
        public Client(T2 lastName, T1 name, T3 patronymic)
        {
            this.lastName = lastName;
            this.name = name;
            this.patronymic = patronymic;
        }
        public Client()
        {

        }
    }
}
