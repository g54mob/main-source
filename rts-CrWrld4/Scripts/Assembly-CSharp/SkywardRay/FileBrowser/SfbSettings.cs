namespace SkywardRay.FileBrowser
{
	public class SfbSettings
	{
		private string _settingsSaveFolder;

		private float _hiddenOpacity;

		public bool AllTypesShowOnlySetExtensions { get; set; }

		public bool AllowFolderAsOutput { get; set; }

		public bool AllowFileAsOutput { get; set; }

		public uint DoubleClickTime { get; set; }

		public bool KeepBrowserInMemoryWhenClosed { get; set; }

		public uint MaxRecentEntries { get; set; }

		public bool RemoveLocationOnDelete { get; set; }

		public bool RemoveLocationWhenMissing { get; set; }

		public bool RestrictOutputToOneFile { get; set; }

		public bool RequireFileExtensionInSaveMode { get; set; }

		public bool SaveSettingsToPlayerPrefs { get; set; }

		public bool SaveSettingsToDisk { get; set; }

		public string SettingsSaveFileName { get; set; }

		public bool ShowHiddenFiles { get; set; }

		public uint TooltipDelay { get; set; }

		public string SettingsSaveFolder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float HiddenOpacity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}
	}
}
