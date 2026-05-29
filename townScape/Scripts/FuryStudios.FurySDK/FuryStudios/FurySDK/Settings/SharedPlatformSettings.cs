using System;
using FuryStudios.FurySDK.Utils;
using FuryStudios.FurySDK.Utils.Attributes;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class SharedPlatformSettings
	{
		[SerializeField]
		private AchievementDatabase achievements;

		[SerializeField]
		private RichPresenceDatabase richPresence;

		[SerializeField]
		private LeaderboardsDatabase leaderboards;

		[SerializeField]
		private DlcDatabase dlcs;

		[SerializeField]
		[ClassImplements]
		private ClassTypeReference localisationServiceType;

		[SerializeField]
		private PlatformSystemMessengerBase systemMessengerPrefab;

		public AchievementDatabase Achievements => null;

		public RichPresenceDatabase RichPresence => null;

		public LeaderboardsDatabase Leaderboards => null;

		public DlcDatabase DLCs => null;

		public ClassTypeReference LocalisationServiceType => null;

		public PlatformSystemMessengerBase SystemMessengerPrefab => null;
	}
}
