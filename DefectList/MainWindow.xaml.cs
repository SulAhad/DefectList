
using System.Linq;
using System.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace DefectList
{
    public partial class MainWindow : Window
    {
        readonly OrdersContext ordersContext = new();
        public MainWindow()
        {
            InitializeComponent();
            ListOrder.ItemsSource = ordersContext.Orders.ToList();
        }
        public void AddList()
        {

        }
        private void AddDefect(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            if (InputArea.Text == "")
            {
                DownTray.Content = "Не ввели участок!";
                DownTray.Background = Brushes.LightCoral;
                flag = false;
            }
            if (InputDepartment.Text == "")
            {
                DownTray.Content = "Не ввели отдел!";
                DownTray.Background = Brushes.LightCoral;
                flag = false;
            }
            if (InputDefect.Text == "")
            {
                DownTray.Content = "Не ввели описание дефекта!";
                DownTray.Background = Brushes.LightCoral;
                flag = false;
            }
            if (InputLastName.Text == "")
            {
                DownTray.Content = "Не ввели фамилию!";
                DownTray.Background = Brushes.LightCoral;
                flag = false;
            }
            if(flag)
            {
                OrdersContext db = new();
                Order tim = new()
                {
                    Area = InputArea.Text,
                    Department = InputDepartment.Text,
                    Defect = InputDefect.Text,
                    LastName = InputLastName.Text,
                    Date = System.DateTime.Now.ToString()
                };
                db.Orders.Add(tim);
                db.SaveChanges();
                ListOrder.ItemsSource = ordersContext.Orders.ToList();
                InputArea.Text = "";
                InputDepartment.Text = "";
                InputDefect.Text = "";
                InputLastName.Text = "";
                DownTray.Content = "Добавлено";
                DownTray.Background = Brushes.LightGreen;
            }
        }
    }
}
