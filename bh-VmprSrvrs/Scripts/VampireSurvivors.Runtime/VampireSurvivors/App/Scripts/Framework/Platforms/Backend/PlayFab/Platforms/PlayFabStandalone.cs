using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Core;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms
{
	public class PlayFabStandalone : IPlatform, IPlatformAuthentication
	{
		public PlatformType GetPlatformName()
		{
			return default(PlatformType);
		}

		public Task<ILoginResult> LoginOrRegister()
		{
			return null;
		}

		public Task<ILoginResult> Login()
		{
			return null;
		}

		public Task<ILinkResult> LinkAccount(bool force)
		{
			return null;
		}

		public Task<bool> UnlinkAccount()
		{
			return null;
		}
	}
}
