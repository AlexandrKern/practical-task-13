using practical_task_13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Сreating_an_account;

namespace banking_system_prototype
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user;
        List<User> users;
        ulong[] arrayDeposit;
        ulong[] arrayNonDeposit;
        int count;
        bool d;
        bool n;
        int[] moneyD;
        int[] moneyN;
        List<Client<string, string, string>> listName;
        public MainWindow()
        {
            InitializeComponent();
            new UserEventInfo();
            moneyD = new int[10];
            moneyN = new int[10];
            listName = new List<Client<string, string, string>>();
            user = new User();
            users = new List<User>();
            arrayDeposit = new ulong[10];
            arrayNonDeposit = new ulong[10];
            dataGridClients.Columns[0].IsReadOnly = true;
            dataGridClients.Columns[1].IsReadOnly = true;
            dataGridClients.Columns[2].IsReadOnly = true;
            dataGridClients.CanUserSortColumns = false;
            dataGridClients.CanUserAddRows = false;
            dataGridDeposit.Columns[0].IsReadOnly = true;
            dataGridDeposit.Columns[1].IsReadOnly = true;
            dataGridDeposit.CanUserAddRows = false;
            dataGridNonDeposit.Columns[0].IsReadOnly = true;
            dataGridNonDeposit.Columns[1].IsReadOnly = true;
            dataGridNonDeposit.CanUserAddRows = false;
            bn.Visibility = Visibility.Collapsed;
            bd.Visibility = Visibility.Collapsed;
            textBoxDeposit.Visibility = Visibility.Collapsed;
            textBoxNonDeposit.Visibility = Visibility.Collapsed;
            textBoxTranslation.Visibility = Visibility.Collapsed;
            sum.Visibility = Visibility.Collapsed;
            ok.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Создает клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGridClients.ItemsSource = user.AddClients();
            listName = user.AddClients();
        }
        /// <summary>
        /// Открывает депозитный счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGridClients.SelectedIndex == -1)
            {
                MessageBox.Show("Выберете клиента!");
                return;
            }
            users.Clear();
            dataGridDeposit.ItemsSource = null;
            try
            {
                user.Account = UserAccount.OpenAnAccount();
                users.Add(new User(user.Account));
                if (arrayDeposit[count] == 0)
                {
                    arrayDeposit[count] = users[0].depositAccount;
                    dataGridDeposit.ItemsSource = users;
                }
                else
                {
                    users[0].depositAccount = arrayDeposit[count];
                    dataGridDeposit.ItemsSource = users;
                }
                new User(listName[count].lastName, users[0].depositAccount);
                textBlock.Text = UserEventInfo.info;
            }
            catch (AccountException msg)
            {
                MessageBox.Show(msg.Message);
            }
        }
        private void dataGridClients_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            users.Clear();
            count = dataGridClients.SelectedIndex;
            if (count == -1)
                return;
            dataGridDeposit.ItemsSource = null;
            dataGridNonDeposit.ItemsSource = null;
            users.Add(new User());
            users[0].depositAccount = arrayDeposit[count];
            users[0].nonDepositAccount = arrayNonDeposit[count];
            users[0].moneyDeposit = moneyD[count];
            users[0].moneyNonDeposit = moneyN[count];
            dataGridDeposit.ItemsSource = users;
            dataGridNonDeposit.ItemsSource = users;
            bn.Visibility = Visibility.Collapsed;
            bd.Visibility = Visibility.Collapsed;
            textBoxDeposit.Visibility = Visibility.Collapsed;
            textBoxNonDeposit.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Открывает недепозитный счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dataGridClients.SelectedIndex == -1)
            {
                MessageBox.Show("Выберете клиента!");
                return;
            }
            users.Clear();
            dataGridNonDeposit.ItemsSource = null;
            try
            {
                user.Account = UserAccount.OpenAnAccount();
                users.Add(new User(0,user.Account));
                if (arrayNonDeposit[count] == 0)
                {
                    arrayNonDeposit[count] = users[0].nonDepositAccount;
                    dataGridNonDeposit.ItemsSource = users;
                }
                else
                {
                    users[0].nonDepositAccount = arrayNonDeposit[count];
                    dataGridNonDeposit.ItemsSource = users;
                }
                new User(listName[count].lastName, 0, 0, users[0].nonDepositAccount);
                textBlock.Text = UserEventInfo.info;
            }
            catch (AccountException msg)
            {
                MessageBox.Show(msg.Message);
            }
        }
        /// <summary>
        /// Закрывает счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            textBoxTranslation.Visibility = Visibility.Collapsed;
            sum.Visibility = Visibility.Collapsed;
            ok.Visibility = Visibility.Collapsed;
            if (dataGridClients.SelectedIndex == -1)
            {
                MessageBox.Show("Выберете клиента!");
                return;
            }
            if (dataGridDeposit.SelectedIndex == -1 && dataGridNonDeposit.SelectedIndex == -1)
            {
                MessageBox.Show("Выберете счет");
                return;
            }
            if (d)
            {
                moneyD[count] = 0;
                arrayDeposit[count] = 0;
                users.Clear();
                users.Add(new User());
                dataGridDeposit.ItemsSource = null;
                users[0].depositAccount = arrayDeposit[count];
                dataGridDeposit.ItemsSource = users;
            }
            if (n)
            {
                moneyN[count] = 0;
                arrayNonDeposit[count] = 0;
                users.Clear();
                users.Add(new User());
                dataGridNonDeposit.ItemsSource = null;
                users[0].nonDepositAccount = arrayNonDeposit[count];
                dataGridNonDeposit.ItemsSource = users;
            }
            new User(listName[count].lastName, 0, 0, 0, 0, true);
            textBlock.Text = UserEventInfo.info;
        }
        private void dataGridDeposit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            d = true;
            n = false;
        }
        private void dataGridNonDeposit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            n = true;
            d = false;
        }
        /// <summary>
        /// Пополнить счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            textBoxTranslation.Visibility = Visibility.Collapsed;
            sum.Visibility = Visibility.Collapsed;
            ok.Visibility = Visibility.Collapsed;
            if (dataGridClients.SelectedIndex == -1)
            {
                MessageBox.Show("Выберете клиента!");
                return;
            }
            bn.Visibility = Visibility.Visible;
            bd.Visibility = Visibility.Visible;
            textBoxDeposit.Visibility = Visibility.Visible;
            textBoxNonDeposit.Visibility = Visibility.Visible;

        }
        private void bd_Click(object sender, RoutedEventArgs e)
        {
           
            if (arrayDeposit[count] == 0)
            {
                MessageBox.Show("Откройте счет");
                return;
            }
            int moneyAddDeposit;
            int.TryParse(textBoxDeposit.Text, out moneyAddDeposit);
            moneyD[count] += moneyAddDeposit;
            users.Clear();
            textBoxDeposit.Text = null;
            users.Add(new User());
            dataGridDeposit.ItemsSource = null;
            users[0].depositAccount = arrayDeposit[count];
            users[0].moneyDeposit = moneyD[count];
            dataGridDeposit.ItemsSource = users;
            new User(listName[count].lastName, users[0].depositAccount, 0, 0, moneyAddDeposit);
            textBlock.Text = UserEventInfo.info;
        }
        private void bn_Click(object sender, RoutedEventArgs e)
        {
            if (arrayNonDeposit[count] == 0)
            {
                MessageBox.Show("Откройте счет");
                return;
            }
            int moneyNonAddDeposit;
            try
            {
                moneyNonAddDeposit = int.Parse(textBoxNonDeposit.Text);
            }
            catch 
            {
                moneyNonAddDeposit = 0;
            }
            moneyN[count] += moneyNonAddDeposit;
            users.Clear();
            textBoxNonDeposit.Text = null;
            users.Add(new User());
            dataGridNonDeposit.ItemsSource = null;
            users[0].nonDepositAccount = arrayNonDeposit[count];
            users[0].moneyNonDeposit = moneyN[count];
            dataGridNonDeposit.ItemsSource = users;
            new User(listName[count].lastName, users[0].nonDepositAccount, 0, 0, moneyNonAddDeposit);
            textBlock.Text = UserEventInfo.info;
        }
        /// <summary>
        /// Перевести другому клиенту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (dataGridClients.SelectedIndex == -1)
            {
                MessageBox.Show("Выберете клиента!");
                return;
            }
            bn.Visibility = Visibility.Collapsed;
            textBoxNonDeposit.Visibility = Visibility.Collapsed;
            bd.Visibility = Visibility.Collapsed;
            textBoxDeposit.Visibility = Visibility.Collapsed;
            textBoxTranslation.Visibility = Visibility.Visible;
            sum.Visibility = Visibility.Visible;
            ok.Visibility = Visibility.Visible;
        }
        private void textBoxTranslation_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= textBoxTranslation_GotFocus;
        }
        private void sum_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;                        /*Удаляет текст после нажатия на текстовое поле*/
            tb.GotFocus -= sum_GotFocus;
        }
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (arrayDeposit[count] == 0)
            {
                MessageBox.Show("Откройте счет");
                return;
            }
            bool w = true;
            ulong translation;
            ulong.TryParse(textBoxTranslation.Text,out translation);
            int sum1;
            int.TryParse(sum.Text,out sum1);
            if (moneyD[count] < sum1)
            {
                MessageBox.Show("Недостаточно Средств");
                return;
            }
            for (int i = 0; i < arrayDeposit.Length; i++)
            {
                if (translation == arrayDeposit[i])
                {
                    moneyD[count] -= sum1;
                    moneyD[i] += sum1;
                    w = false;
                }
            }
            if (w)
            {
                MessageBox.Show("Счет не найден");
                return;
            }
            users.Clear();
            textBoxTranslation.Text = null;
            sum.Text = null;
            users.Add(new User());
            dataGridDeposit.ItemsSource = null;
            users[0].depositAccount = arrayDeposit[count];
            users[0].moneyDeposit = moneyD[count];
            dataGridDeposit.ItemsSource = users;
            new User(listName[count].lastName, users[0].depositAccount, translation, 0, sum1);
            textBlock.Text = UserEventInfo.info;
        }
    }
}

