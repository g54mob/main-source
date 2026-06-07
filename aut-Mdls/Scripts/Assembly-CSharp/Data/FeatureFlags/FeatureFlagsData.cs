using UnityEngine;

namespace Data.FeatureFlags
{
	[CreateAssetMenu(fileName = "FeatureFlagsData", menuName = "FeatureFlags/FeatureFlagsData", order = 0)]
	public class FeatureFlagsData : ScriptableObject
	{
		public enum EOperatorDatabase
		{
			Default = 0,
			Demo = 1
		}

		[Header("Game features")]
		[SerializeField]
		private bool _canUndoRedo = true;

		[SerializeField]
		private bool _techTree = true;

		[SerializeField]
		private bool _techTreeFilters = true;

		[SerializeField]
		private bool _progressionPage = true;

		[SerializeField]
		private bool _challenges = true;

		[SerializeField]
		private bool _showRank = true;

		[SerializeField]
		private bool _productionGraph = true;

		[SerializeField]
		private bool _freighters = true;

		[SerializeField]
		private bool _useDataShards = true;

		[SerializeField]
		private bool _useCraneLimits = true;

		[SerializeField]
		private bool _heatmap = true;

		[SerializeField]
		private bool _blueprints = true;

		[SerializeField]
		private bool _unlockableZones = true;

		[SerializeField]
		private bool _isDevelopment = true;

		[SerializeField]
		private bool _creativeMode = true;

		[SerializeField]
		private bool _useStories = true;

		[Header("Social features")]
		[SerializeField]
		private bool _discordSocialFeatures = true;

		[SerializeField]
		private bool _steamSocialFeatures = true;

		[Header("Release features")]
		[SerializeField]
		private bool _demoFeatures;

		[SerializeField]
		private bool _kioskFeatures;

		[SerializeField]
		private bool _hasSurvey;

		[SerializeField]
		private bool _playtest;

		[SerializeField]
		private bool _gameTesterLogin;

		[Header("Dev features")]
		[SerializeField]
		private bool _levelEditor;

		[SerializeField]
		private bool _SRDebugger = true;

		[SerializeField]
		private bool _useTestGATitle;

		[SerializeField]
		private bool _gameCaptureShortcuts = true;

		[SerializeField]
		private bool _windParticles = true;

		[SerializeField]
		private bool _cullingJobManager = true;

		[SerializeField]
		private bool _dayNightCycle = true;

		[SerializeField]
		private bool _minimap = true;

		[SerializeField]
		[Tooltip("Specify the operator database you want to use.")]
		private EOperatorDatabase _operatorsDatabase;

		public bool CanUndoRedo => _canUndoRedo;

		public bool TechTree => _techTree;

		public bool TechTreeFilters => _techTreeFilters;

		public bool ProgressionPage => _progressionPage;

		public bool Challenges => _challenges;

		public bool ShowRank => _showRank;

		public bool ProductionGraph => _productionGraph;

		public bool Freighters => _freighters;

		public bool UseDataShards => _useDataShards;

		public bool UseCraneLimits => _useCraneLimits;

		public bool Heatmap => _heatmap;

		public bool Blueprints => _blueprints;

		public bool UnlockableZones => _unlockableZones;

		public bool IsDevelopment => _isDevelopment;

		public bool CreativeMode => _creativeMode;

		public bool UseStories => _useStories;

		public bool DiscordSocialFeatures => _discordSocialFeatures;

		public bool SteamSocialFeatures => _steamSocialFeatures;

		public bool DemoFeatures => _demoFeatures;

		public bool KioskFeatures => _kioskFeatures;

		public bool HasSurvey => _hasSurvey;

		public bool Playtest => _playtest;

		public bool GameTesterLogin => _gameTesterLogin;

		public bool LevelEditor => _levelEditor;

		public bool SRDebugger => _SRDebugger;

		public bool UseTestGATitle => _useTestGATitle;

		public bool GameCaptureShortcuts => _gameCaptureShortcuts;

		public bool WindParticles => _windParticles;

		public bool CullingJobManager => _cullingJobManager;

		public bool DayNightCycle => _dayNightCycle;

		public bool Minimap => _minimap;

		public EOperatorDatabase OperatorsDatabase
		{
			get
			{
				return _operatorsDatabase;
			}
			set
			{
				_operatorsDatabase = value;
			}
		}

		public override string ToString()
		{
			return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Empty + "FeatureFlags: " + base.name + " | ", string.Format("{0}: {1} | ", "CanUndoRedo", CanUndoRedo)), string.Format("{0}: {1} | ", "TechTree", TechTree)), string.Format("{0}: {1} | ", "TechTreeFilters", TechTreeFilters)), string.Format("{0}: {1} | ", "Challenges", Challenges)), string.Format("{0}: {1} | ", "ProgressionPage", ProgressionPage)), string.Format("{0}: {1} | ", "ShowRank", ShowRank)), string.Format("{0}: {1} | ", "ProductionGraph", ProductionGraph)), string.Format("{0}: {1} | ", "Freighters", Freighters)), string.Format("{0}: {1} | ", "UseDataShards", UseDataShards)), string.Format("{0}: {1} | ", "UseCraneLimits", UseCraneLimits)), string.Format("{0}: {1} | ", "Heatmap", Heatmap)), string.Format("{0}: {1} | ", "Blueprints", Blueprints)), string.Format("{0}: {1} | ", "UnlockableZones", UnlockableZones)), string.Format("{0}: {1} | ", "IsDevelopment", IsDevelopment)), string.Format("{0}: {1} | ", "CreativeMode", CreativeMode)), string.Format("{0}: {1} | ", "UseStories", UseStories)), string.Format("{0}: {1} | ", "KioskFeatures", KioskFeatures)), string.Format("{0}: {1} | ", "HasSurvey", HasSurvey)), string.Format("{0}: {1} | ", "Playtest", Playtest)), string.Format("{0}: {1} | ", "GameTesterLogin", GameTesterLogin)), string.Format("{0}: {1} | ", "LevelEditor", LevelEditor)), string.Format("{0}: {1} | ", "SRDebugger", SRDebugger)), string.Format("{0}: {1} | ", "GameCaptureShortcuts", GameCaptureShortcuts)), string.Format("{0}: {1} | ", "WindParticles", WindParticles)), string.Format("{0}: {1} | ", "Minimap", Minimap)), string.Format("{0}: {1}", "OperatorsDatabase", OperatorsDatabase)), string.Format("{0}: {1} | ", "CullingJobManager", CullingJobManager)), string.Format("{0}: {1} | ", "DayNightCycle", DayNightCycle)), string.Format("{0}: {1} | ", "DiscordSocialFeatures", DiscordSocialFeatures)), string.Format("{0}: {1} | ", "SteamSocialFeatures", SteamSocialFeatures));
		}
	}
}
