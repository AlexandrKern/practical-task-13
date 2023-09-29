using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_system_prototype
{
    public class User : Client<string, string, string>
    {
        public static event Action<string> evenеtRecording;
        int a = 0;

        public User(ulong deposit = 0, ulong nonDeposit = 0)
        {
            depositAccount = deposit;
            nonDepositAccount = nonDeposit;
        }
        public User(string lastName, ulong deposit = 0, ulong deposit1 = 0, ulong nonDeposit = 0, int sum = 0, bool close = false)
        {
            if (deposit != 0 && nonDeposit == 0) evenеtRecording($"Пользователь {lastName} открыл депозитный счет {deposit}");
            if (deposit == 0 && nonDeposit != 0) evenеtRecording($"Пользователь {lastName} открыл недепозитный счет {nonDeposit}");
            if ((deposit != 0 || nonDeposit != 0) && sum != 0)
            {
                if (deposit != 0) evenеtRecording($"Пользователь {lastName} пополнил счет {deposit} на {sum}");
                else evenеtRecording($"Пользователь {lastName} пополнил счет {nonDeposit} на {sum}");
            }
            if (deposit != 0 && deposit1 != 0) evenеtRecording($"Пользователь {lastName} перевел с {deposit} на {deposit1} сумму {sum}");
            if (close) evenеtRecording($"Пользователь {lastName} закрыл счет");
        }
        /// <summary>
        /// Открывает счет
        /// </summary>
        /// <returns></returns>
        public ulong OpenAnAccount()
        {
            var r = new Random();                   /*генерируем случайное число типа ulong*/
            var b = new byte[sizeof(ulong)];
            r.NextBytes(b);
            var res = BitConverter.ToUInt64(b, 0);
            return res;
        }
        /// <summary>
        /// Создает клиентов
        /// </summary>
        /// <returns></returns>
        public List<Client<string, string, string>> AddClients()
        {
            Client<string, string, string> client;
            List<Client<string, string, string>> clients = new List<Client<string, string, string>>();
            for (int i = 1; i < 11; i++)
            {
                client = new Client<string, string, string>($"Фамилия_{i}",
                    $"Имя_{i}",
                    $"Отчество_{i}");
                clients.Add(client);
            }
            return clients;
        }
    }
}
