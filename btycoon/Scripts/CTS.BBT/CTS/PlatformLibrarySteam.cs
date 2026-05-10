using CTS.Core;
using Steamworks;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Platforms/Steam/Library")]
	public class PlatformLibrarySteam : ScriptableObject, IPlatformLibrary
	{
		[SerializeField]
		private AppId_t _authenticateId;

		[SerializeField]
		private SerializableDictionary<StringKey, AppId_t> _apps = new SerializableDictionary<StringKey, AppId_t>();

		public bool IsDLCInstalled(StringKey dlcName)
		{
			if (!_apps.TryGetValue(dlcName, out var value))
			{
				return false;
			}
			return SteamApps.BIsDlcInstalled(value);
		}

		public bool TryAuthenticateGame()
		{
			if (SteamUtils.GetAppID() != _authenticateId)
			{
				return false;
			}
			return SteamApps.BIsSubscribedApp(_authenticateId);
		}
	}
}
