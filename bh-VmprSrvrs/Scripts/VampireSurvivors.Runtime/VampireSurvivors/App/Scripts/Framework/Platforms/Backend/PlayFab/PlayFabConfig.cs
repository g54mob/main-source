using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Core;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab
{
	public class PlayFabConfig : IPlatformConfiguration
	{
		private readonly string ENV;

		public PlayFabConfig(bool useProduction = false)
		{
		}

		public string GetEnvironment()
		{
			return null;
		}
	}
}
