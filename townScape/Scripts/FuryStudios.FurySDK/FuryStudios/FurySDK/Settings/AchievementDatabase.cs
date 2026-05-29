using System.Collections.Generic;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[CreateAssetMenu]
	public class AchievementDatabase : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField]
		internal AchievementInfo[] achievements;

		private Dictionary<AchievementID, AchievementInfo> database;

		public IReadOnlyCollection<AchievementID> Keys => null;

		public string GetSteamAchivementID(AchievementID key)
		{
			return null;
		}

		public SteamAchievementInfo GetSteamAchivementInfo(AchievementID key)
		{
			return default(SteamAchievementInfo);
		}

		public string GetGOGAchievementID(AchievementID key)
		{
			return null;
		}

		public int GetPS4AchievementID(AchievementID key)
		{
			return 0;
		}

		public string GetGDKAchievementID(AchievementID key)
		{
			return null;
		}

		public string GetiOSAchievementID(AchievementID key)
		{
			return null;
		}

		public string GetAndroidAchivementID(AchievementID key)
		{
			return null;
		}

		public string GetEpicAchivementID(AchievementID key)
		{
			return null;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
