using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab
{
	public class PlayFabCoreAuthentication : ICoreAuthentication
	{
		public void Logout()
		{
		}

		public bool IsLoggedIn()
		{
			return false;
		}

		public string GetAccountId()
		{
			return null;
		}

		public Task<AccountDetails> GetAccountDetails()
		{
			return null;
		}

		public Task RequestPasswordReset(string emailAddress)
		{
			return null;
		}

		public Task<bool> AddBasicCredentials(string email, string password)
		{
			return null;
		}

		public Task<ILoginResult> Login(string email, string password)
		{
			return null;
		}

		public Task<bool> Register(string email, string password)
		{
			return null;
		}

		public Task<bool> AddOrUpdateContactEmail(string email)
		{
			return null;
		}

		public Task<bool> ResendVerificationEmail()
		{
			return null;
		}

		public Task<bool> RemoveContactEmail()
		{
			return null;
		}

		public Task<IPlayerProfile> GetPlayerProfile()
		{
			return null;
		}

		public Task<bool> LinkCustomID(string id)
		{
			return null;
		}

		public Task<bool> UnlinkCustomID(string id)
		{
			return null;
		}

		public Task<ILoginResult> LoginWithCustomID(string id, bool forceCreate = false)
		{
			return null;
		}

		public static void AssertPlayFabSettings()
		{
		}

		private string GenerateUsername()
		{
			return null;
		}
	}
}
