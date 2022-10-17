using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Example.AppData
{
	public class Data
	{
		private static NpgsqlConnection connection;

		public static ObservableCollection<Role> Roles { get; set; }
		public static ObservableCollection<Employee> Employees { get; set; }

		public static void Connect(string cs)
		{
			if (connection == null)
			{
				connection = new NpgsqlConnection(cs);
			}
			else
			{
				if (connection.State != ConnectionState.Closed)
				{
					connection.Close();
				}
			}
			connection.Open();
		}

		public static void Load()
		{
			if (Roles == null)
			{
				Roles = new ObservableCollection<Role>();
			}
			if (Employees == null)
			{
				Employees = new ObservableCollection<Employee>();
			}

			loadRoles();
			loadEmployees();
		}

		private static void loadRoles()
		{
			Roles.Clear();
			var cmd = GetCommand("SELECT caption FROM user_role ORDER BY caption");
			var reader = cmd.ExecuteReader();
			if (reader == null) return;

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Roles.Add(new Role()
					{
						Name = reader.GetString(0)
					});
				}
			}
			reader.Close();
		}

		private static void loadEmployees()
		{
			Employees.Clear();
			var cmd = GetCommand("SELECT phone, pass, first_name, last_name, user_role, photo FROM employee ORDER BY first_name, last_name");
			var reader = cmd.ExecuteReader();
			if (reader == null) return;

			if (reader.HasRows)
			{
				while (reader.Read())
				{
					var roleName = reader.GetString(4);
					var role = Roles.Where(x => x.Name == roleName).First();

					Employees.Add(new Employee()
					{
						Login = reader.GetString(0),
						Password = reader.GetString(1),
						FirstName = reader.GetString(2),
						LastName = reader.GetString(3),
						Photo = reader.GetString(5),
						Role = role
					});
				}
			}
			reader.Close();
		}

		public static NpgsqlCommand GetCommand(string sql)
		{
			NpgsqlCommand cmd = new NpgsqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = sql;
			return cmd;
		}
	}
}
