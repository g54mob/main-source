using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using TH20.Analytics;
using TH20.ExtContent;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AppConfig
	{
		public string LevelCommonSceneName = "LevelCommon";

		public string MetagameSceneName = "Metagame";

		public string SandboxSceneName = "Sandbox";

		public SharedInstance<InputManager.Config> InputManagerConfig;

		public SharedInstance<LoggerConfig> LoggingConfig;

		public SharedInstance<DebugFlyCameraConfig> DebugFlyCameraConfig;

		public SharedInstance<CollaborativeProjectList> CollaborativeProjectList;

		public SharedInstance<SuperBugConfig> SuperBugConfig;

		public SharedInstance<OnlineManager.Config> OnlineManagerConfig;

		public SharedInstance<ExtContentManager.ExtContentManagerConfig> ExtContentManagerConfig;

		public SharedInstance<AudioManagerConfig> AudioManagerConfig;

		public SharedInstance<Metagame.Config> MetagameConfig;

		public SharedInstance<GameAlgorithmsConfig> GameAlgorithmsConfig;

		public SharedInstance<SandboxSettingsConfig> SandboxSettingsConfig;

		public SharedInstance<DLCManager.Config> DLCConfig;

		public SharedInstance<DynamicPlaylistManagerConfig> DynamicPlaylistManagerConfig;

		public SharedInstance<PrefabPoolManager.Config> PrefabPoolManagerConfig;

		public SharedInstance<StatsAsAchievementsData> StatsAsAchievementsData;

		public AnalyticsManagerConfig AnalyticsManagerConfig;

		public PlatformFeatureSupport PlatformFeatureSupportConfig;

		public AppAudioMixerManagerConfig AppAudioMixerManagerConfig;

		public float LevelLoadFadeTime = 1f;

		public TextAsset DefaultDevConfig;

		public GameObject PreferencesScreenPrefab;

		public GameObject GraphyPrefab;

		public GameObject SaveOverlayPrefab;

		public GameObject PlayfabTrackerUIPrefab;

		public List<Object> AdditionalAssetReferences;

		[InspectorMargin(8)]
		[InspectorHeader("Global Rendering Resources")]
		public Texture2D NoiseTexture;
	}
}
