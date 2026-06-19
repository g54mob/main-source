using System.Collections.Generic;
using Steamworks;

namespace TH20
{
	public class SteamRichPresence : MustCallDestroy
	{
		public static class SteamRichPresenceUtils
		{
			private static SteamRichPresence _richPresence;

			public static void Initialise(SteamRichPresence richPresence)
			{
				_richPresence = richPresence;
			}

			public static void Uninitialise()
			{
				_richPresence = null;
			}

			public static Dictionary<CSteamID, SteamRichPresenceData> GetFriendsDataPlayingLevel(string levelID)
			{
				Dictionary<CSteamID, SteamRichPresenceData> dictionary = new Dictionary<CSteamID, SteamRichPresenceData>();
				if (_richPresence == null)
				{
					return dictionary;
				}
				_richPresence.Gather();
				foreach (KeyValuePair<CSteamID, SteamRichPresenceData> item in _richPresence._richPresenceDictionary)
				{
					SteamRichPresenceData value = item.Value;
					if (value.CurrentLevelID != null && value.CurrentLevelID.Equals(levelID))
					{
						dictionary.Add(item.Key, item.Value);
					}
				}
				return dictionary;
			}

			public static string GetRichPresenceValueForSteamID(CSteamID steamID, string key)
			{
				if (!OnlineManager.IsInitializedAndLoggedOn())
				{
					return string.Empty;
				}
				return SteamFriends.GetFriendRichPresence(steamID, key);
			}

			public static List<string> GetAllRichPresenceValuesForSteamID(CSteamID steamID)
			{
				List<string> list = new List<string>();
				if (!OnlineManager.IsInitializedAndLoggedOn())
				{
					return list;
				}
				int friendRichPresenceKeyCount = SteamFriends.GetFriendRichPresenceKeyCount(steamID);
				for (int i = 0; i < friendRichPresenceKeyCount; i++)
				{
					string friendRichPresenceKeyByIndex = SteamFriends.GetFriendRichPresenceKeyByIndex(steamID, i);
					list.Add("Key = " + friendRichPresenceKeyByIndex + " Value = " + SteamFriends.GetFriendRichPresence(steamID, friendRichPresenceKeyByIndex));
				}
				return list;
			}
		}

		private readonly Dictionary<CSteamID, SteamRichPresenceData> _richPresenceDictionary = new Dictionary<CSteamID, SteamRichPresenceData>();

		private const string Key = "data";

		public SteamRichPresenceData RichPresenceData { get; private set; }

		public SteamRichPresence()
		{
			SteamRichPresenceUtils.Initialise(this);
			RichPresenceData = new SteamRichPresenceData();
		}

		public override void Destroy()
		{
			SteamRichPresenceUtils.Uninitialise();
			base.Destroy();
		}

		public void UploadRichPresenceData(in RichPresenceLevelData richPresenceLevelData)
		{
			RichPresenceData.CurrentLevelID = richPresenceLevelData.CurrentLevelID;
			RichPresenceData.CurrentMoneyInLevel = richPresenceLevelData.CurrentMoneyInLevel;
			RichPresenceData.CurrentReputationInLevel = richPresenceLevelData.CurrentReputationInLevel;
			RichPresenceData.CurrentStaffMoraleInLevel = richPresenceLevelData.CurrentStaffMoraleInLevel;
			string pchValue = SteamHelpers.Serialize(RichPresenceData);
			SteamFriends.SetRichPresence("data", pchValue);
		}

		public SteamRichPresenceData GetRichPresenceData(CSteamID steamID)
		{
			_richPresenceDictionary.TryGetValue(steamID, out var value);
			return value;
		}

		public void Gather()
		{
			foreach (OnlinePlayerID knownPlayerID in OnlineManager.GetKnownPlayerIDs())
			{
				SteamRichPresenceData richPresenceData = GetRichPresenceData(knownPlayerID);
				string friendRichPresence = SteamFriends.GetFriendRichPresence(knownPlayerID, "data");
				SteamRichPresenceData obj;
				if (friendRichPresence == string.Empty)
				{
					if (richPresenceData == null)
					{
						_richPresenceDictionary.Remove(knownPlayerID);
					}
				}
				else if (SteamHelpers.Deserialize<SteamRichPresenceData>(friendRichPresence, out obj) == EOnlineResult.EOnlineResultOk)
				{
					_richPresenceDictionary[knownPlayerID] = obj;
				}
			}
		}

		public void ClearPlayerRichPresence()
		{
			try
			{
				SteamFriends.ClearRichPresence();
			}
			catch
			{
			}
		}
	}
}
