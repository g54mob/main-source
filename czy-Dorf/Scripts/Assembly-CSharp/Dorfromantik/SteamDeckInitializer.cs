using Steamworks;
using UnityEngine;

namespace Dorfromantik
{
	public class SteamDeckInitializer : MonoBehaviour
	{
		[SerializeField]
		private SettingsRouter settingsRouter;

		private void Start()
		{
			if (SteamManager.Initialized)
			{
				InitializeUiScale();
			}
		}

		private void InitializeUiScale()
		{
			if (SteamUtils.IsSteamRunningOnSteamDeck() && PlayerPrefs.GetInt(Constants.Settings.IsSteamDeckUiInitialized, 0) == 0)
			{
				settingsRouter.SetUiScale(1);
				PlayerPrefs.SetInt(Constants.Settings.IsSteamDeckUiInitialized, 1);
			}
		}
	}
}
