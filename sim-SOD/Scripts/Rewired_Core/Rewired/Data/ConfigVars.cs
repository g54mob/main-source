using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Platforms;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class ConfigVars : IConfigVars_Internal
	{
		private static class RoKDgGMOodCsEYDvxHRasbiCUNY
		{
			public const string OtdyoVgHZlkVzcXpmFOkbCpToVK = "updateLoop";

			public const string DcGaxyoBaQzgmsmvGLKceJmMCqq = "alwaysUseUnityInput";

			public const string umZhCfRwRrwNveHmpNEnmIcTyvC = "windowsStandalonePrimaryInputSource";

			public const string xDHObZPSzfhsbKcipHHOIeUmpcza = "osx_primaryInputSource";

			public const string gEMWzmajuTziLGHauYdcBoOrFUj = "linux_primaryInputSource";

			public const string FKNqYBfauHbEBeUWDFeJGpoprSD = "windowsUWP_primaryInputSource";

			public const string KKSIizpxdghEydsgiRYqhneLBWc = "xboxOne_primaryInputSource";

			public const string zmcTFnQVcbGprAFChRvwQbwZxvA = "gameCoreXboxOne_primaryInputSource";

			public const string DuZULyLJIASxhdfPMVdyfQSybfr = "gameCoreScarlett_primaryInputSource";

			public const string ilEIzUEgacLCzWXVSMspuGZCTGi = "ps4_primaryInputSource";

			public const string iYzDndCODhshFlIVDNIOTgBjRixJ = "ps5_primaryInputSource";

			public const string bDSLiDxdRyFbFeNXDrMlnHAbrDKg = "webGL_primaryInputSource";

			public const string tvAqjFprvNeqNYOfJduoeffRlQY = "stadia_primaryInputSource";

			public const string VRmfqPJHnNhBQfXugwLApMCjxYtq = "useXInput";

			public const string iPAwFJiqurTeYcLtvCahxtZvXLG = "windowsStandalone_useSteamRawInputControllerWorkaround";

			public const string BIAVfMtDnCPnDTDmeEfNeUyfFsB = "osxStandalone_useEnhancedDeviceSupport";

			public const string fgHghTkoOPdfmkzzczgPquoLxrIn = "android_supportUnknownGamepads";

			public const string VLrFvJEkzWDWwEUVYFgEenlKovxK = "ps4_assignJoysticksByPS4JoyId";

			public const string nYLJfdQSRkJdwftYsuefdBdHrvO = "useSteamControllerSupport";

			public const string LMktmTycZcboybCaPZyzACFGBXT = "logToScreen";

			public const string siXqhenFVfGAPLvvIvSoFEzdnFb = "runInEditMode";

			public const string jMZBxhhTsDtQKpRAdbBCFCkwqDbU = "allowInputInEditorSceneView";

			public const string GbRwdtacCLikdVmsafgmzlOkgZY = "maxJoysticksPerPlayer";

			public const string MTIUgbHhUJRGCnwTJEldaqkSIWD = "autoAssignJoysticks";

			public const string SoLMgyLJeSbtFEjNmUHPNVRoQbAl = "assignJoysticksToPlayingPlayersOnly";

			public const string xvjigHCZhebSKyeNudWvxRvSpKM = "distributeJoysticksEvenly";

			public const string iTDVtEIRLYBUeFmPeeeEGhHilpXh = "reassignJoystickToPreviousOwnerOnReconnect";

			public const string CTmchxaofFdjNMQejSjHAZAWZJf = "defaultJoystickAxis2DDeadZoneType";

			public const string ZCXGSEMhAKyxDSQpTHzXXHEcPsp = "defaultJoystickAxis2DSensitivityType";

			public const string jnjkvRIosidWrnoStDaqrfdpDAGj = "defaultAxisSensitivityType";

			public const string GtqdOJkyyqgAzlBCmUsbMcirSdua = "force4WayHats";

			public const string AOFFhZRUKXTeWBKoXIoabILDxOfv = "throttleCalibrationMode";

			public const string IncZwpbKyzuDfdpHVwhzIKvfIfj = "activateActionButtonsOnNegativeValue";

			public const string OlfhQmixHpspBeTQgHwuwbDMqnz = "deferControllerConnectedEventsOnStart";

			public const string ebYkpBarwMngBLCuhHXIaWYIXSp = "logLevel";

			public const string nzfymwssbHsIBUdgJGAeJezfoWM = "disableKeyboard";

			public const string xwMFtUfdgykHBfiwhSHTcZXRzrMK = "ignoreInputWhenAppNotInFocus";

			public const string uubHYmuqreJRsGbLHgmhwVVHohK = "useEnhancedDeviceSupport";

			public const string efcsblhgLNLnbVHghzVeTamAvEi = "useNativeMouse";

			public const string LGCdTjgBbAjYkpzwcUgwWxSLlSNG = "useNativeKeyboard";

			public const string HfedWqbokMwbpjYwLXykMXaRgNE = "joystickRefreshRate";

			public const string juKOAQkileHaedQYasVZchvxioll = "assignJoysticksBySystemId";
		}

		[Serializable]
		public class PlatformVars
		{
			public bool disableKeyboard;

			public bool ignoreInputWhenAppNotInFocus;
		}

		[Serializable]
		public class PlatformVars_WindowsStandalone : PlatformVars
		{
			public bool useNativeKeyboard;

			public int joystickRefreshRate;
		}

		[Serializable]
		public class PlatformVars_OSXStandalone : PlatformVars
		{
		}

		[Serializable]
		public class PlatformVars_WindowsUWP : PlatformVars
		{
			public bool useGamepadAPI;

			public bool useHIDAPI;
		}

		[Serializable]
		public class PlatformVars_Stadia : PlatformVars
		{
			public bool useNativeKeyboard;

			public bool useNativeMouse;
		}

		[Serializable]
		public class PlatformVars_GameCoreXboxOne : PlatformVars
		{
			public bool assignJoysticksByUserId;
		}

		[Serializable]
		public class PlatformVars_GameCoreScarlett : PlatformVars
		{
			public bool assignJoysticksByUserId;
		}

		[Serializable]
		public sealed class EditorVars
		{
			public bool exportConsts_useParentClass;

			public string exportConsts_parentClassName;

			public bool exportConsts_useNamespace;

			public string exportConsts_namespace;

			public bool exportConsts_actions;

			public string exportConsts_actionsClassName;

			public bool exportConsts_actionsIncludeActionCategory;

			public bool exportConsts_actionsCreateClassesForActionCategories;

			public bool exportConsts_mapCategories;

			public string exportConsts_mapCategoriesClassName;

			public bool exportConsts_layouts;

			public string exportConsts_layoutsClassName;

			public bool exportConsts_players;

			public string exportConsts_playersClassName;

			public bool exportConsts_inputBehaviors;

			public string exportConsts_inputBehaviorsClassName;

			public bool exportConsts_customControllers;

			public string exportConsts_customControllersClassName;

			public string exportConsts_customControllersAxesClassName;

			public string exportConsts_customControllersButtonsClassName;

			public bool exportConsts_layoutManagerRuleSets;

			public string exportConsts_layoutManagerRuleSetsClassName;

			public bool exportConsts_mapEnablerRuleSets;

			public string exportConsts_mapEnablerRuleSetsClassName;

			public bool exportConsts_allCapsConstantNames;
		}

		private class FdDvvlcbxPRQlMGrvLWrBztanee
		{
			public Func<PlatformVars> BivbVkmneucomDSaznsRrSbFgRV;

			public string rudplJurbEtyqzlAYOPkyNNqgbE;

			public FdDvvlcbxPRQlMGrvLWrBztanee(Func<PlatformVars> getDelegate, string dataPath)
			{
			}
		}

		private class KuSXiNbBBhHrtabPnoDOTBzbycD
		{
			public Func<Platform, object> BivbVkmneucomDSaznsRrSbFgRV;

			public Action<Platform, object> VHAQLgIHwuCaZlGuqitMayTJOTH;

			public KuSXiNbBBhHrtabPnoDOTBzbycD(Func<Platform, object> getDelegate, Action<Platform, object> setDelegate)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal enum AllPlatformVar
		{
			[CustomObfuscation(rename = false)]
			DisableKeyboard = 0,
			[CustomObfuscation(rename = false)]
			IgnoreInputWhenAppNotInFocus = 1
		}

		public UpdateLoopSetting updateLoop;

		public bool alwaysUseUnityInput;

		public WindowsStandalonePrimaryInputSource windowsStandalonePrimaryInputSource;

		public OSXStandalonePrimaryInputSource osx_primaryInputSource;

		public LinuxStandalonePrimaryInputSource linux_primaryInputSource;

		public WindowsUWPPrimaryInputSource windowsUWP_primaryInputSource;

		public XboxOnePrimaryInputSource xboxOne_primaryInputSource;

		public GameCoreXboxOnePrimaryInputSource gameCoreXboxOne_primaryInputSource;

		public GameCoreScarlettPrimaryInputSource gameCoreScarlett_primaryInputSource;

		public PS4PrimaryInputSource ps4_primaryInputSource;

		public PS5PrimaryInputSource ps5_primaryInputSource;

		public WebGLPrimaryInputSource webGL_primaryInputSource;

		public StadiaPrimaryInputSource stadia_primaryInputSource;

		public bool useXInput;

		public bool useNativeMouse;

		public bool useEnhancedDeviceSupport;

		public bool windowsStandalone_useSteamRawInputControllerWorkaround;

		public bool osxStandalone_useEnhancedDeviceSupport;

		public bool android_supportUnknownGamepads;

		public bool ps4_assignJoysticksByPS4JoyId;

		public bool useSteamControllerSupport;

		public bool logToScreen;

		public bool runInEditMode;

		public bool allowInputInEditorSceneView;

		public PlatformVars_WindowsStandalone platformVars_windowsStandalone;

		public PlatformVars platformVars_linuxStandalone;

		public PlatformVars_OSXStandalone platformVars_osxStandalone;

		public PlatformVars platformVars_windows8Store;

		public PlatformVars_WindowsUWP platformVars_windowsUWP;

		public PlatformVars platformVars_iOS;

		public PlatformVars platformVars_tvOS;

		public PlatformVars platformVars_android;

		public PlatformVars platformVars_ps3;

		public PlatformVars platformVars_ps4;

		public PlatformVars platformVars_ps5;

		public PlatformVars platformVars_psVita;

		public PlatformVars platformVars_xbox360;

		public PlatformVars platformVars_xboxOne;

		public PlatformVars_GameCoreXboxOne platformVars_gameCoreXboxOne;

		public PlatformVars_GameCoreScarlett platformVars_gameCoreScarlett;

		public PlatformVars platformVars_wii;

		public PlatformVars platformVars_wiiu;

		public PlatformVars platformVars_switch;

		public PlatformVars platformVars_webGL;

		public PlatformVars_Stadia platformVars_stadia;

		[NonSerialized]
		private PlatformVars platformVars_unknown;

		public int maxJoysticksPerPlayer;

		public bool autoAssignJoysticks;

		public bool assignJoysticksToPlayingPlayersOnly;

		public bool distributeJoysticksEvenly;

		public bool reassignJoystickToPreviousOwnerOnReconnect;

		public DeadZone2DType defaultJoystickAxis2DDeadZoneType;

		public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType;

		public AxisSensitivityType defaultAxisSensitivityType;

		public bool force4WayHats;

		public ThrottleCalibrationMode throttleCalibrationMode;

		public bool activateActionButtonsOnNegativeValue;

		public bool deferControllerConnectedEventsOnStart;

		public LogLevelFlags logLevel;

		public EditorVars editorSettings;

		private Dictionary<int, FdDvvlcbxPRQlMGrvLWrBztanee> __platformVarsDict;

		private Dictionary<int, KuSXiNbBBhHrtabPnoDOTBzbycD> __getSetPlatformVariableDict;

		private KeyedGetSetValueStore<string> __configVarsValues;

		private Dictionary<string, object> __valueDelegates;

		private Dictionary<int, FdDvvlcbxPRQlMGrvLWrBztanee> platformVarsDict => null;

		private Dictionary<int, KuSXiNbBBhHrtabPnoDOTBzbycD> getSetPlatformVariableDict => null;

		KeyedGetSetValueStore<string> IConfigVars_Internal.values => null;

		private Dictionary<string, object> valueDelegates => null;

		[Preserve]
		public ConfigVars()
		{
		}

		internal bool DoesPlatformUseFallback(Platform platform, WebplayerPlatform webplayerPlatform, bool isEditor)
		{
			return false;
		}

		internal bool DoesPlatformUseSDL2(Platform platform, WebplayerPlatform webplayerPlatform, bool isEditor)
		{
			return false;
		}

		internal string GetDebugConfigSettings()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal string GetPlatformVarsRelPath(Platform platform)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal PlatformVars GetPlatformVars(Platform platform)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal T Editor_GetAllSerializedPlatformVar<T>(AllPlatformVar var)
		{
			return default(T);
		}

		[CustomObfuscation(rename = false)]
		internal void Editor_SetAllSerializedPlatformVar(AllPlatformVar var, object value)
		{
		}

		internal bool GetPlatformVar_disableKeyboard()
		{
			return false;
		}

		internal bool SetPlatformVar_disableKeyboard(bool value)
		{
			return false;
		}

		internal bool GetPlatformVar_ignoreInputWhenAppNotInFocus()
		{
			return false;
		}

		internal bool GetPlatformVar_useEnhancedDeviceSupport()
		{
			return false;
		}

		internal bool GetPlatformVar_useNativeMouse()
		{
			return false;
		}

		internal bool GetPlatformVar_useNativeKeyboard()
		{
			return false;
		}

		internal int GetPlatformVar_joystickRefreshRate()
		{
			return 0;
		}

		internal bool GetPlatformVar_assignJoysticksBySystemId()
		{
			return false;
		}

		internal bool SetPlatformVar_ignoreInputWhenAppNotInFocus(bool value)
		{
			return false;
		}

		internal bool SetPlatformVar_useEnhancedDeviceSupport(bool value)
		{
			return false;
		}

		internal bool SetPlatformVar_useNativeMouse(bool value)
		{
			return false;
		}

		internal bool SetPlatformVar_useNativeKeyboard(bool value)
		{
			return false;
		}

		internal bool SetPlatformVar_joystickRefreshRate(int value)
		{
			return false;
		}

		internal bool SetPlatformVar_assignJoysticksBySystemId(bool value)
		{
			return false;
		}

		private PlatformVars GetPlatformVars()
		{
			return null;
		}

		private T GetOrCreatePlatformVars<T>(ref T var) where T : PlatformVars, new()
		{
			return null;
		}

		private MultiBoolValue GetAllSerializedPlatformVar_multiBool(AllPlatformVar var)
		{
			return default(MultiBoolValue);
		}

		internal bool IsEditModeInputSupported(ControllerType controllerType, EditorPlatform editorPlatform)
		{
			return false;
		}
	}
}
