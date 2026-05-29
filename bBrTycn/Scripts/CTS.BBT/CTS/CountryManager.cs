using System.Collections.Generic;
using Steamworks;
using UnityEngine;

namespace CTS
{
	public static class CountryManager
	{
		public static List<string> TwitchRestrictedCountry = new List<string> { "CN", "HK", "KR", "KP" };

		public static List<string> DiscordRestrictedCountry = new List<string> { "CN", "HK" };

		public static List<string> QQAutorizededCountry = new List<string> { "CN", "HK" };

		public static string GetPlayerCountry()
		{
			if (!SteamManager.Initialized)
			{
				Debug.LogError("Steamworks n'est pas initialisé!");
				return null;
			}
			return SteamUtils.GetIPCountry();
		}
	}
}
