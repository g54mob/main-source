using System.Text.RegularExpressions;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class AccountViewModel : ViewModelBase
	{
		private Account account;

		private bool remember;

		private string username;

		private string email;

		private ObservableDictionary<string, string> errors = new ObservableDictionary<string, string>();

		public Account Account
		{
			get
			{
				return account;
			}
			set
			{
				Set(ref account, value, "Account");
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

		public bool Remember
		{
			get
			{
				return remember;
			}
			set
			{
				Set(ref remember, value, "Remember");
			}
		}

		public ObservableDictionary<string, string> Errors
		{
			get
			{
				return errors;
			}
			set
			{
				Set(ref errors, value, "Errors");
			}
		}

		public void OnUsernameValueChanged(string value)
		{
			Debug.LogFormat("Username ValueChanged:{0}", value);
		}

		public void OnEmailValueChanged(string value)
		{
			Debug.LogFormat("Email ValueChanged:{0}", value);
		}

		public void OnSubmit()
		{
			if (string.IsNullOrEmpty(Username) || !Regex.IsMatch(Username, "^[a-zA-Z0-9_-]{4,12}$"))
			{
				errors["errorMessage"] = "Please enter a valid username.";
				return;
			}
			if (string.IsNullOrEmpty(Email) || !Regex.IsMatch(Email, "^\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$"))
			{
				errors["errorMessage"] = "Please enter a valid email.";
				return;
			}
			errors.Clear();
			Account.Username = Username;
			Account.Email = Email;
		}
	}
}
