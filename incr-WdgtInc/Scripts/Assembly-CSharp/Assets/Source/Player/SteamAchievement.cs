using System.Collections.Generic;
using Steamworks;
using UnityEngine;

namespace Assets.Source.Player
{
	public class SteamAchievement
	{
		private static HashSet<string> _triggered = new HashSet<string>();

		public static void Trigger(string name)
		{
			if (!_triggered.Add(name))
			{
				return;
			}
			Debug.Log("Trigger Steam achievement: " + name);
			if (GamePlayer.Current != null && GamePlayer.Current.Integrity && SteamManager.Initialized)
			{
				SteamUserStats.GetAchievement(name, out var pbAchieved);
				if (!pbAchieved)
				{
					SteamUserStats.SetAchievement(name);
					SteamUserStats.StoreStats();
				}
			}
		}

		public static void Clear(string name = null)
		{
			if (SteamManager.Initialized)
			{
				if (name == null)
				{
					SteamUserStats.ResetAllStats(bAchievementsToo: true);
				}
				else
				{
					SteamUserStats.ClearAchievement(name);
				}
				SteamUserStats.StoreStats();
			}
		}
	}
}
