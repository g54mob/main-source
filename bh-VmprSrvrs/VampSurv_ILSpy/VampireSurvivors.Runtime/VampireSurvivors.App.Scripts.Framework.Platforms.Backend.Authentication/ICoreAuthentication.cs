using System.Threading.Tasks;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

public interface ICoreAuthentication
{
	bool IsLoggedIn();

	void Logout();

	Task<ILoginResult> Login(string email, string password);

	Task<bool> Register(string email, string password);

	Task<bool> LinkCustomID(string id);

	Task<bool> UnlinkCustomID(string id);

	Task<ILoginResult> LoginWithCustomID(string id, bool forceCreate);

	Task<bool> AddBasicCredentials(string email, string password);

	Task<AccountDetails> GetAccountDetails();

	Task RequestPasswordReset(string emailAddress);

	string GetAccountId();

	Task<bool> AddOrUpdateContactEmail(string email);

	Task<bool> ResendVerificationEmail();

	Task<bool> RemoveContactEmail();

	Task<IPlayerProfile> GetPlayerProfile();
}
