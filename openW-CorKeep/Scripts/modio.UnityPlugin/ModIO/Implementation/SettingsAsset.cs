using UnityEngine;

namespace ModIO.Implementation
{
	internal class SettingsAsset : ScriptableObject
	{
		public BuildSettings androidConfiguration;

		public BuildSettings standaloneConfiguration;

		public BuildSettings iosConfiguration;

		public const string FilePath = "mod.io/config";

		[HideInInspector]
		public ServerSettings serverSettings;

		public BuildSettings editorConfiguration;

		public bool autoInitializePlugin = true;

		public BuildSettings GetBuildSettings()
		{
			return standaloneConfiguration;
		}

		public static Result TryLoad(out ServerSettings serverSettings, out BuildSettings buildSettings)
		{
			SettingsAsset settingsAsset = Resources.Load<SettingsAsset>("mod.io/config");
			if (settingsAsset == null)
			{
				serverSettings = default(ServerSettings);
				buildSettings = new BuildSettings();
				return ResultBuilder.Create(20010u);
			}
			serverSettings = settingsAsset.serverSettings;
			buildSettings = settingsAsset.GetBuildSettings();
			Resources.UnloadAsset(settingsAsset);
			return ResultBuilder.Success;
		}

		public static Result TryLoad(out bool autoInitializePlugin)
		{
			SettingsAsset settingsAsset = Resources.Load<SettingsAsset>("mod.io/config");
			if (settingsAsset == null)
			{
				autoInitializePlugin = false;
				return ResultBuilder.Create(20010u);
			}
			autoInitializePlugin = settingsAsset.autoInitializePlugin;
			Resources.UnloadAsset(settingsAsset);
			return ResultBuilder.Success;
		}
	}
}
