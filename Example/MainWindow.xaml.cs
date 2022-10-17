using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Example
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			AppData.Data.Connect("Server=10.14.206.27;Port=5432;User Id=postgres;Password=*sJ#44dm;Database=student_manager");
			AppData.Data.Load();

		
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AppFrame.Navigate(new EmployeePage());
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			AppFrame.Navigate(new TestPage());
		}
	}
}
