using System;
using UnityEngine;
using UnityEngine.Serialization;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class GameServicesUnitySettings : SettingsPropertyGroup
	{
		[Serializable]
		public class AndroidPlatformProperties
		{
			[SerializeField]
			[Tooltip("Your application id in Google Play services.")]
			private string m_playServicesApplicationId;

			[Header("External Server Control")]
			[SerializeField]
			[Tooltip("Your Server Client Id for getting external authentication credentials (Make sure its from a web app)")]
			private string m_serverClientId;

			[SerializeField]
			[Tooltip("If enabled, allows the use of refresh tokens to obtain long-lived access to Google Play Services.")]
			private bool m_forceRefreshToken;

			[Tooltip("Text formats used to derive completed achievement description. Note: Achievement title will be inserted in place of token '#'.")]
			private string[] m_achievedDescriptionFormats;

			[Header("Extra Settings")]
			[SerializeField]
			[Tooltip("If enabled, alert dialog is shown automatically on error(for ex: signin failure).")]
			private bool m_showErrorDialogs;

			[SerializeField]
			[Tooltip("If enabled, auto-initialization of play games services happens on app start(But still to sign-in you need to call Authenticate). If disabled, initialization happens once you call Authenticate method. This is useful when you handling GDPR handling based on age gating.")]
			private bool m_enableAutoInitialization;

			public string PlayServicesApplicationId => null;

			public string ServerClientId => null;

			public string[] AchievedDescriptionFormats => null;

			public bool ShowErrorDialogs => false;

			public bool ForceRefreshToken => false;

			public bool EnableAutoInitialization => false;

			public AndroidPlatformProperties(string playServicesApplicationId = null, string serverClientId = null, string[] achievedDescriptionFormats = null, bool showErrorDialogs = true, bool forceRefreshToken = true, bool enableAutoInitialization = true)
			{
			}
		}

		[SerializeField]
		[FormerlySerializedAs("m_leaderboardMetaArray")]
		[Tooltip("Array contains information of the leaderboards used within the game.")]
		public LeaderboardDefinition[] m_leaderboards;

		[SerializeField]
		[Tooltip("Array contains information of the achievements used within the game.")]
		public AchievementDefinition[] m_achievements;

		[SerializeField]
		[Tooltip("If enabled, a banner is displayed when an achievement is completed (iOS).")]
		private bool m_showAchievementCompletionBanner;

		[SerializeField]
		[Tooltip("If enabled, required permissions for accessing friends will be added.")]
		private bool m_allowFriendsAccess;

		[SerializeField]
		[Tooltip("Android specific settings.")]
		private AndroidPlatformProperties m_androidProperties;

		public LeaderboardDefinition[] Leaderboards => null;

		public AchievementDefinition[] Achievements => null;

		public bool ShowAchievementCompletionBanner => false;

		public bool AllowFriendsAccess => false;

		public AndroidPlatformProperties AndroidProperties => null;

		public GameServicesUnitySettings(bool isEnabled = true, bool initializeOnStart = true, LeaderboardDefinition[] leaderboards = null, AchievementDefinition[] achievements = null, bool showAchievementCompletionBanner = true, bool allowFriendsAccess = true, AndroidPlatformProperties androidProperties = null)
			: base(null, isEnabled: false)
		{
		}
	}
}
