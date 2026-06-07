using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

namespace VampireSurvivors.UI
{
	public class LoginPanel : BaseAccountPagePanel
	{
		private readonly RememberEmailService _rememberEmailService;

		public LoginPanel(AccountPage accountPage)
			: base(null)
		{
		}

		public override void Build()
		{
		}

		private bool IsValidEmail(string email)
		{
			return false;
		}

		private bool IsPasswordValid(string password)
		{
			return false;
		}
	}
}
