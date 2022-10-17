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
	public partial class EmployeePage : Page
	{
		public EmployeePage()
		{
			InitializeComponent();

			Binding binding = new Binding();
			binding.Source = AppData.Data.Employees;

			Binding bindingRole = new Binding();
			bindingRole.Source = AppData.Data.Roles;

			lvEmployee.SetBinding(
				ItemsControl.ItemsSourceProperty,
				binding);

			cbRole.SetBinding(
				ItemsControl.ItemsSourceProperty,
				bindingRole);
		}
	}
}
