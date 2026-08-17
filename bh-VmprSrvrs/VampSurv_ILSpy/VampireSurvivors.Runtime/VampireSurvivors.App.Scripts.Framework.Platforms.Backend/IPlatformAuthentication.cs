using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend;

public interface IPlatformAuthentication
{
	Task<ILoginResult> LoginOrRegister();

	Task<ILoginResult> Login();

	Task<ILinkResult> LinkAccount(bool force);

	Task<bool> UnlinkAccount();
}
