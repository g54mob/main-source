namespace DarkTonic.MasterAudio
{
	public class MasterAudioSettings : SingletonScriptable<MasterAudioSettings>
	{
		public const string AssetName = "MasterAudioSettings.asset";

		public const string AssetFolder = "Assets/Resources/MasterAudio";

		public const string ResourcePath = "MasterAudio/MasterAudioSettings";

		public bool UseDbScale;

		public bool RemoveUnplayedDueToProbabilityVariation;

		public bool UseCentsPitch;

		public bool HideLogoNav;

		public bool EditMAFolder;

		public string InstallationFolderPath;

		public MasterAudio.MixerWidthMode MixerWidthSetting;

		public bool BusesShownInNarrow;

		public bool ShowWelcomeWindowOnStart;

		static MasterAudioSettings()
		{
		}
	}
}
