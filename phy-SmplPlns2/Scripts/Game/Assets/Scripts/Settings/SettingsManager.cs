using Assets.Scripts.Storage;

namespace Assets.Scripts.Settings
{
	public class SettingsManager
	{
		private ApplicationSettings _app;

		private CloudSettings _cloud;

		private GameSettings _gameplay;

		private ModSettings _mods;

		private GameQualitySettings _quality;

		public static string PathForAppSettings => GameData.GetPath("AppSettings.xml");

		public static string PathForCharacterSettings => GameData.GetPath("CharacterSettings.xml");

		public static string PathForCloudSettings => GameData.GetPath("CloudSettings.xml");

		public static string PathForControlSettings => GameData.GetPath("ControlInputData.xml");

		public static string PathForGameplaySettings => GameData.GetPath("GameplaySettings.xml");

		public static string PathForModSettings => GameData.GetPath("ModSettings.xml");

		public static string PathForQualitySettings => GameData.GetPath("QualitySettings.xml");

		public ApplicationSettings App => _app;

		public CloudSettings Cloud => _cloud;

		public IGameSettings Gameplay => _gameplay;

		public IModSettings Mods => _mods;

		public IGameQualitySettings Quality => _quality;

		private SettingsManager()
		{
		}

		public static SettingsManager Create()
		{
			SettingsManager settingsManager = new SettingsManager();
			settingsManager.Initialize();
			return settingsManager;
		}

		public void SaveIfNecessary()
		{
			_app.SaveIfNecessary();
			_gameplay.SaveIfNecessary();
			_quality.SaveIfNecessary();
			_mods.SaveIfNecessary();
			_cloud.SaveIfNecessary();
		}

		private void Initialize()
		{
			_app = ApplicationSettings.Create(PathForAppSettings);
			_gameplay = GameSettings.Create(PathForGameplaySettings);
			_quality = GameQualitySettings.Create(PathForQualitySettings);
			_mods = ModSettings.Create(PathForModSettings);
			_cloud = CloudSettings.Create(PathForCloudSettings);
		}
	}
}
