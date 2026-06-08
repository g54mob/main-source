using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	public class DefaultSettings : ScriptableObject
	{
		public int qualityLevel;

		public int meshQualityLevel;

		public int postProcessingEnabled = 1;

		public int antiAliasingLevel = 1;

		public int translucentUiEnabled = 1;

		public int vsyncLevel;

		public int dynamicBackgroundEnabled = 1;

		public int decorationEnabled = 1;

		[FormerlySerializedAs("disableAntiAliasingWhileMovingCam")]
		public int disableAAWhileMovingCam;

		public UiScalingLevelId uiScalingLevelId;

		public float masterVolume = 1f;

		public float musicVolume = 1f;

		public float fxVolume = 1f;

		public int placingTilesWithClick = 1;

		public int cameraSpeedLevel = 5;

		public int cameraZoomSpeedLevel = 4;

		public int cameraRotationSpeedLevel = 6;

		public int tooltipLevel;

		public int runInBackground = 1;

		public int highlightMatchingEdges = 1;

		public int maxZoomOutDistance = -18;

		public float maxZoomInDistance = 5f;

		public int defaultVisibleTileStackHeight = 15;

		public bool setupScreenshotsOnAwake;

		public bool pinChallengesEnabled = true;

		public bool leaderboardsEnabled = true;

		public bool saveChallengesAndRewardsWhenUpdated = true;

		public bool validateServerTimeInMonthlyMode = true;

		public bool validateSeasonInMonthlyMode;

		public bool setupSessionQuestIngameDisplay = true;

		public MainMenuScreenType defaultStartupScreen = MainMenuScreenType.NavigationBar;

		public Language defaultLanguage;

		public bool isSteamChinaVersion;
	}
}
