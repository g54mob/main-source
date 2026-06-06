using UnityEngine;

namespace Brewery.Config
{
	[CreateAssetMenu(fileName = "DevSettings", menuName = "Config/Dev Settings")]
	public class DevSettings : ScriptableObject
	{
		private static DevSettings _instance;

		[Header("Dev Features")]
		[Tooltip("Enable dev buttons in Trading UI (Max NPC Rep, Max Global Rep, etc.)")]
		public bool enableDevButtons;

		[Tooltip("Enable dev features in builds (not just Editor). Set false for release.")]
		public bool enableInBuilds;

		[Header("Debug Logging")]
		[Tooltip("Enable verbose debug logging (detailed init, state changes, etc.)")]
		public bool verboseLogging;

		[Tooltip("Suppress ALL info-level logs (only show warnings/errors)")]
		public bool quietMode;

		[Tooltip("Categories to always show verbose logs for (comma-separated, e.g. 'SAVE,NETWORK')")]
		public string verboseCategories;

		public static DevSettings Instance => null;

		public bool AreDevFeaturesEnabled => false;

		public static bool DevFeaturesActive => false;

		public bool IsVerboseForCategory(string category)
		{
			return false;
		}
	}
}
