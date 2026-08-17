using PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Core;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;

public class PlayFabConfig : IPlatformConfiguration
{
	private readonly string ENV;

	public PlayFabConfig(bool useProduction = false)
	{
		PlayFabSettings.staticSettings.TitleId = "DC211";
		ENV = "production";
		PlayFabSharedSettings playFabSharedPrivate = PlayFabSettings.PlayFabSharedPrivate;
		playFabSharedPrivate.RequestType = WebRequestType.UnityWebRequest;
		PlayFabSharedSettings playFabSharedPrivate2 = PlayFabSettings.PlayFabSharedPrivate;
		playFabSharedPrivate2.RequestTimeout = 10;
	}

	public string GetEnvironment()
	{
		return ENV;
	}
}
