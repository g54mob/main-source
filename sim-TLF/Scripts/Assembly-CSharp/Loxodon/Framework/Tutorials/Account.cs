using System;
using Loxodon.Framework.Observables;

namespace Loxodon.Framework.Tutorials
{
	public class Account : ObservableObject
	{
		private int id;

		private string username;

		private string password;

		private string email;

		private DateTime birthday;

		private readonly ObservableProperty<string> address = new ObservableProperty<string>();

		public int ID
		{
			get
			{
				return id;
			}
			set
			{
				Set(ref id, value, "ID");
			}
		}

		public string Username
		{
			get
			{
				return username;
			}
			set
			{
				Set(ref username, value, "Username");
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				Set(ref password, value, "Password");
			}
		}

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				Set(ref email, value, "Email");
			}
		}

		public DateTime Birthday
		{
			get
			{
				return birthday;
			}
			set
			{
				Set(ref birthday, value, "Birthday");
			}
		}

		public ObservableProperty<string> Address => address;
	}
}
