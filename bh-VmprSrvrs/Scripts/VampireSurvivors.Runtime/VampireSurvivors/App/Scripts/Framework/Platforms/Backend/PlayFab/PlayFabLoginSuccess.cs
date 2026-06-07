using PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab
{
	public class PlayFabLoginSuccess : ILoginResult
	{
		public PlayFabAuthenticationContext AuthenticationContext;
	}
}
