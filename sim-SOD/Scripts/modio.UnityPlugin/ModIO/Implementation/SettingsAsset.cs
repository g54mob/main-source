using UnityEngine;

namespace ModIO.Implementation
{
	internal class SettingsAsset : ScriptableObject
	{
		public BuildSettings androidConfiguration;

		public BuildSettings iosConfiguration;

		public BuildSettings standaloneConfiguration;

		public const string FilePath = "mod.io/config";

		[HideInInspector]
		public ServerSettings serverSettings;

		public BuildSettings editorConfiguration;

		public bool autoInitializePlugin;

		public BuildSettings GetBuildSettings()
		{
			return null;
		}

		public static Result TryLoad(out ServerSettings serverSettings, out BuildSettings buildSettings)
		{
			serverSettings = default(ServerSettings);
			buildSettings = null;
			return default(Result);
		}

		public static Result TryLoad(out bool autoInitializePlugin)
		{
			autoInitializePlugin = default(bool);
			return default(Result);
		}
	}
}
