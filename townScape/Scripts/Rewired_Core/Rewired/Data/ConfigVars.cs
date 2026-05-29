using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Platforms;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation]
	public sealed class ConfigVars : IConfigVars_Internal
	{
		private static class IXtQbnafCDrBOSolzZeIQRPzWJK
		{
			public const string JUMcETAAxlprBByLFvikeVngOqaP = "updateLoop";

			public const string QldRWDUGEgwgyeMlSioKScPtOGc = "alwaysUseUnityInput";

			public const string rKecNSinMXlblDaTCngRlULhaqGP = "windowsStandalonePrimaryInputSource";

			public const string gvwXFqnPTHzGdGwwpkCuANfVcxn = "osx_primaryInputSource";

			public const string jDpEsKBYXrJwkJOPmTvRRtNWRNUL = "linux_primaryInputSource";

			public const string IiczMyBzQlUqPqnQBkirikAAddP = "windowsUWP_primaryInputSource";

			public const string JCzAMOJgNWALoxicmylGHlZuUIi = "xboxOne_primaryInputSource";

			public const string iPBlJGyfOBgrnKeMlWlOqhHmDzS = "gameCoreXboxOne_primaryInputSource";

			public const string KQqukXtjfgbJrBtzIscIJZdXcbjx = "gameCoreScarlett_primaryInputSource";

			public const string rdKhmUJySEJSCPWXVibYKHfkCLOD = "ps4_primaryInputSource";

			public const string pWVDWZotNymHoALZIpieOqiEwdd = "ps5_primaryInputSource";

			public const string uvbOsyHYhSsTVBBDXniZrqlCRWU = "webGL_primaryInputSource";

			public const string kLdTAwFlHpvRTAHzRNSSAqOgGwQ = "stadia_primaryInputSource";

			public const string UyXbKajpXhbUQAXuuecasybCwEfj = "useXInput";

			public const string dFbdKgKcQBfWIovXtFaLDigCHeU = "windowsStandalone_useSteamRawInputControllerWorkaround";

			public const string WFpXltFTVobIZDEgazOdESFCKaJ = "osxStandalone_useEnhancedDeviceSupport";

			public const string gzeaVgKJgdZaubdbqxHjIxTelzO = "android_supportUnknownGamepads";

			public const string EsMcHukpJqXFqKgBMoNsHzAhJdt = "ps4_assignJoysticksByPS4JoyId";

			public const string wQsZeScZdOuHczpKoXuPNhAepBC = "useSteamControllerSupport";

			public const string SuZIRcCwhIhvszNsNGTPAqwnHJPd = "logToScreen";

			public const string rhwGSGiRrJeTIgPhdWKqRtnhEvND = "runInEditMode";

			public const string moeBFQxKflLAMfdYdqXsurRBTMp = "allowInputInEditorSceneView";

			public const string LMyDAOcKQpBlfVDamjMAMPYVmmGG = "maxJoysticksPerPlayer";

			public const string NsbawUxxXnvIKdvqBddJEcTdlKN = "autoAssignJoysticks";

			public const string RtgUWZbISeaWTjlHgoCptauVEjY = "assignJoysticksToPlayingPlayersOnly";

			public const string ydSmEieNTSAkCFqHeDhXTTKvlQOg = "distributeJoysticksEvenly";

			public const string jwoBUjehMuZpouXgyVmmJgmErUX = "reassignJoystickToPreviousOwnerOnReconnect";

			public const string XZVZCjUPbUqNdQifjUvmznlsBtM = "defaultJoystickAxis2DDeadZoneType";

			public const string QnyvghkwoknhFAknVTglrnvLsLb = "defaultJoystickAxis2DSensitivityType";

			public const string gfANhegjISjDnpIUrKTABlWQYYK = "defaultAxisSensitivityType";

			public const string NNWgmvEEObFjABQauZPuYDTUvww = "force4WayHats";

			public const string BvkBJkbcsjXzQZPuFNDAsRqgWsj = "throttleCalibrationMode";

			public const string DcTIOMDGCRIaxzGJXWlRsuEOtUb = "activateActionButtonsOnNegativeValue";

			public const string ZhIQBTEMlHvhDmEQwGuCWvqhYsx = "deferControllerConnectedEventsOnStart";

			public const string bLrvMeOBZwSkFNjmxbuiCWvpaRns = "logLevel";

			public const string qXYAQZfSGpWxVcIbLVhSNtGWngMS = "disableKeyboard";

			public const string avzPtXkIQUSPaJsEwazzCqKCbGD = "ignoreInputWhenAppNotInFocus";

			public const string nPOMhRGsDUSEuKlPPEPLSMumdmM = "useEnhancedDeviceSupport";

			public const string tjRZKEFqflaDbPemlDkCvVJlgWg = "useNativeMouse";

			public const string QUvnMdlHbcXIgrqlyBGCJihoWoX = "useNativeKeyboard";

			public const string QtRoLKOObeyhdWeqHHjWyFVsZWt = "joystickRefreshRate";

			public const string gydoXrCHJWpomKrEqoNzXTAYgix = "assignJoysticksBySystemId";
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

		private class QXoHNMWPJdgMfCEdrqkDOzCHXtk
		{
			public Func<PlatformVars> UQAPDPYOQIvrqJqwdAYdJQSeAyT;

			public string kfYAZeSuZmYyshjzICbKMMoJdwYg;

			public QXoHNMWPJdgMfCEdrqkDOzCHXtk(Func<PlatformVars> getDelegate, string dataPath)
			{
			}
		}

		private class NcdnjqJdpJXklevTthogfpUSjgX
		{
			public Func<Platform, object> UQAPDPYOQIvrqJqwdAYdJQSeAyT;

			public Action<Platform, object> SEdToHmiAKaZVrkkcaAkEWsaMCZ;

			public NcdnjqJdpJXklevTthogfpUSjgX(Func<Platform, object> getDelegate, Action<Platform, object> setDelegate)
			{
			}
		}

		[CustomObfuscation]
		internal enum AllPlatformVar
		{
			[CustomObfuscation]
			DisableKeyboard = 0,
			[CustomObfuscation]
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

		public PlatformVars platformVars_osxStandalone;

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

		private Dictionary<int, QXoHNMWPJdgMfCEdrqkDOzCHXtk> __platformVarsDict;

		private Dictionary<int, NcdnjqJdpJXklevTthogfpUSjgX> __getSetPlatformVariableDict;

		private KeyedGetSetValueStore<string> __configVarsValues;

		private Dictionary<string, object> __valueDelegates;

		private Dictionary<int, QXoHNMWPJdgMfCEdrqkDOzCHXtk> platformVarsDict => null;

		private Dictionary<int, NcdnjqJdpJXklevTthogfpUSjgX> getSetPlatformVariableDict => null;

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

		[CustomObfuscation]
		internal string GetPlatformVarsRelPath(Platform platform)
		{
			return null;
		}

		[CustomObfuscation]
		internal PlatformVars GetPlatformVars(Platform platform)
		{
			return null;
		}

		[CustomObfuscation]
		internal T Editor_GetAllSerializedPlatformVar<T>(AllPlatformVar var)
		{
			return default(T);
		}

		[CustomObfuscation]
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
