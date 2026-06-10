using System;
using System.Collections.Generic;
using FMOD;
using UnityEngine;

namespace FMODUnity
{
	public class Settings : ScriptableObject
	{
		public enum SharedLibraryUpdateStages
		{
			Start = 0,
			DisableExistingLibraries = 1,
			RestartUnity = 2,
			CopyNewLibraries = 3
		}

		public struct PlatformTemplate
		{
			public string Identifier;

			public Func<Platform> CreateInstance;
		}

		public const string SettingsAssetName = "FMODStudioSettings";

		private static Settings instance;

		private static IEditorSettings editorSettings;

		private static bool isInitializing;

		[SerializeField]
		public bool HasSourceProject;

		[SerializeField]
		public bool HasPlatforms;

		[SerializeField]
		private string sourceProjectPath;

		[SerializeField]
		private string sourceBankPath;

		[SerializeField]
		public string SourceBankPathUnformatted;

		[SerializeField]
		public int BankRefreshCooldown;

		[SerializeField]
		public bool ShowBankRefreshWindow;

		public const int BankRefreshPrompt = -1;

		public const int BankRefreshManual = -2;

		[SerializeField]
		public bool AutomaticEventLoading;

		[SerializeField]
		public BankLoadType BankLoadType;

		[SerializeField]
		public bool AutomaticSampleLoading;

		[SerializeField]
		public string EncryptionKey;

		[SerializeField]
		public ImportType ImportType;

		[SerializeField]
		public string TargetAssetPath;

		[SerializeField]
		public string TargetBankFolder;

		[SerializeField]
		public EventLinkage EventLinkage;

		[SerializeField]
		public DEBUG_FLAGS LoggingLevel;

		[SerializeField]
		public List<Legacy.PlatformIntSetting> SpeakerModeSettings;

		[SerializeField]
		public List<Legacy.PlatformIntSetting> SampleRateSettings;

		[SerializeField]
		public List<Legacy.PlatformBoolSetting> LiveUpdateSettings;

		[SerializeField]
		public List<Legacy.PlatformBoolSetting> OverlaySettings;

		[SerializeField]
		public List<Legacy.PlatformBoolSetting> LoggingSettings;

		[SerializeField]
		public List<Legacy.PlatformStringSetting> BankDirectorySettings;

		[SerializeField]
		public List<Legacy.PlatformIntSetting> VirtualChannelSettings;

		[SerializeField]
		public List<Legacy.PlatformIntSetting> RealChannelSettings;

		[SerializeField]
		public List<string> Plugins;

		[SerializeField]
		public List<string> MasterBanks;

		[SerializeField]
		public List<string> Banks;

		[SerializeField]
		public List<string> BanksToLoad;

		[SerializeField]
		public ushort LiveUpdatePort;

		[SerializeField]
		public bool EnableMemoryTracking;

		[SerializeField]
		public bool AndroidUseOBB;

		[SerializeField]
		public MeterChannelOrderingType MeterChannelOrdering;

		[SerializeField]
		public bool StopEventsOutsideMaxDistance;

		[SerializeField]
		public bool BoltUnitOptionsBuildPending;

		[SerializeField]
		public bool EnableErrorCallback;

		[SerializeField]
		public SharedLibraryUpdateStages SharedLibraryUpdateStage;

		[SerializeField]
		public double SharedLibraryTimeSinceStart;

		[SerializeField]
		public int CurrentVersion;

		[SerializeField]
		public bool HideSetupWizard;

		[SerializeField]
		public int LastEventReferenceScanVersion;

		[SerializeField]
		public List<Platform> Platforms;

		public Dictionary<RuntimePlatform, List<Platform>> PlatformForRuntimePlatform;

		[NonSerialized]
		public Platform DefaultPlatform;

		[NonSerialized]
		public Platform PlayInEditorPlatform;

		public static List<PlatformTemplate> PlatformTemplates;

		[NonSerialized]
		private bool hasLoaded;

		public static Settings Instance => null;

		public static IEditorSettings EditorSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SourceProjectPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SourceBankPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TargetPath => null;

		public string TargetSubFolder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static void Initialize()
		{
		}

		public Platform FindPlatform(string identifier)
		{
			return null;
		}

		public bool PlatformExists(string identifier)
		{
			return false;
		}

		public void ForEachPlatform(Action<Platform> action)
		{
		}

		public IEnumerable<Platform> EnumeratePlatforms()
		{
			return null;
		}

		public void AddPlatform(Platform platform)
		{
		}

		public void RemovePlatform(string identifier)
		{
		}

		public void LinkPlatform(Platform platform)
		{
		}

		public void DeclareRuntimePlatform(RuntimePlatform runtimePlatform, Platform platform)
		{
		}

		private void LinkPlatformToParent(Platform platform)
		{
		}

		public Platform FindCurrentPlatform()
		{
			return null;
		}

		public SPEAKERMODE GetEditorSpeakerMode()
		{
			return default(SPEAKERMODE);
		}

		private Settings()
		{
		}

		public void AddPlatformProperties(Platform platform)
		{
		}

		public void SetPlatformParent(Platform platform, Platform newParent)
		{
		}

		public static void AddPlatformTemplate<T>(string identifier) where T : Platform
		{
		}

		private static Platform CreatePlatformInstance<T>(string identifier) where T : Platform
		{
			return null;
		}

		public void OnEnable()
		{
		}

		private void PopulatePlatformsFromAsset()
		{
		}
	}
}
