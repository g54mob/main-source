using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Loxodon.Framework.Commands;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Prefs;
using Loxodon.Framework.ViewModels;
using Loxodon.Log;

namespace Loxodon.Framework.Examples
{
	public class LoginViewModel : ViewModelBase
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ViewModelBase));

		private const string LAST_USERNAME_KEY = "LAST_USERNAME";

		private ObservableDictionary<string, string> errors = new ObservableDictionary<string, string>();

		private string username;

		private string password;

		private SimpleCommand loginCommand;

		private SimpleCommand cancelCommand;

		private Account account;

		private Preferences globalPreferences;

		private IAccountService accountService;

		private Localization localization;

		private InteractionRequest interactionFinished;

		private InteractionRequest<ToastNotification> toastRequest;

		public IInteractionRequest InteractionFinished => interactionFinished;

		public IInteractionRequest ToastRequest => toastRequest;

		public ObservableDictionary<string, string> Errors => errors;

		public string Username
		{
			get
			{
				return username;
			}
			set
			{
				if (Set(ref username, value, "Username"))
				{
					ValidateUsername();
				}
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
				if (Set(ref password, value, "Password"))
				{
					ValidatePassword();
				}
			}
		}

		public ICommand LoginCommand => loginCommand;

		public ICommand CancelCommand => cancelCommand;

		public Account Account => account;

		public LoginViewModel(IAccountService accountService, Localization localization, Preferences globalPreferences)
		{
			this.localization = localization;
			this.accountService = accountService;
			this.globalPreferences = globalPreferences;
			interactionFinished = new InteractionRequest(this);
			toastRequest = new InteractionRequest<ToastNotification>(this);
			if (username == null)
			{
				username = globalPreferences.GetString("LAST_USERNAME", "");
			}
			loginCommand = new SimpleCommand(Login);
			cancelCommand = new SimpleCommand(delegate
			{
				interactionFinished.Raise();
			});
		}

		private bool ValidateUsername()
		{
			if (string.IsNullOrEmpty(username) || !Regex.IsMatch(username, "^[a-zA-Z0-9_-]{4,12}$"))
			{
				errors["username"] = localization.GetText("login.validation.username.error", "Please enter a valid username.");
				return false;
			}
			errors.Remove("username");
			return true;
		}

		private bool ValidatePassword()
		{
			if (string.IsNullOrEmpty(password) || !Regex.IsMatch(password, "^[a-zA-Z0-9_-]{4,12}$"))
			{
				errors["password"] = localization.GetText("login.validation.password.error", "Please enter a valid password.");
				return false;
			}
			errors.Remove("password");
			return true;
		}

		public async void Login()
		{
			try
			{
				if (log.IsDebugEnabled)
				{
					log.DebugFormat("login start. username:{0} password:{1}", username, password);
				}
				this.account = null;
				loginCommand.Enabled = false;
				if (ValidateUsername() && ValidatePassword())
				{
					Account account = await accountService.Login(username, password);
					if (account != null)
					{
						globalPreferences.SetString("LAST_USERNAME", username);
						globalPreferences.Save();
						this.account = account;
						interactionFinished.Raise();
					}
					else
					{
						string text = localization.GetText("login.failure.tip", "Login failure.");
						toastRequest.Raise(new ToastNotification(text, 2f));
					}
				}
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
				{
					log.ErrorFormat("Exception:{0}", ex);
				}
				string text2 = localization.GetText("login.exception.tip", "Login exception.");
				toastRequest.Raise(new ToastNotification(text2, 2f));
			}
			finally
			{
				loginCommand.Enabled = true;
			}
		}

		public Task<Account> GetAccount()
		{
			return accountService.GetAccount(Username);
		}
	}
}
