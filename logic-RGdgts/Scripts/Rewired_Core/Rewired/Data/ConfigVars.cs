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
		private static class VbSANHYkyTCCaCgFsvVxogPVqHJk
		{
			public const string KKlbldiDPbDuxfifcGjVGpjaqJEqB = "updateLoop";

			public const string HpEzgrkgyovMUuIBNlclyCNDBxlS = "alwaysUseUnityInput";

			public const string ecDbkwLsaJuRXcfzgenqsbBARJFy = "windowsStandalonePrimaryInputSource";

			public const string dSVxoUZVnHlgLEOEiRnPszxvRFiS = "osx_primaryInputSource";

			public const string cTObTkoztjLtCOsbjYmkFpXufqHdA = "linux_primaryInputSource";

			public const string BZZjZCbuixfujumgUlkOWYYmEmIG = "windowsUWP_primaryInputSource";

			public const string EaWDngKvdExEYlpQlSuxNpVEVbliA = "xboxOne_primaryInputSource";

			public const string dZcNKaYymJolZYOkqHTnFKPClABzA = "gameCoreXboxOne_primaryInputSource";

			public const string JGPPqdPtZwKNXjZvVrDvdCrpOhei = "gameCoreScarlett_primaryInputSource";

			public const string uFjbPeEFwCmXkUojWNibdjtGUqVw = "ps4_primaryInputSource";

			public const string aIzDmgQITPVdlSwlQMiFgOmqjZuGA = "ps5_primaryInputSource";

			public const string jRYebGxXXYzxzFSvUogcVrliTqJs = "webGL_primaryInputSource";

			public const string ljAwgSjtvrNwxWoRMSCbwCOMOxVP = "stadia_primaryInputSource";

			public const string TiwEjQdZxvVXkBAMzfbBbWvaHtisA = "useXInput";

			public const string cdYsWGkxkRnigwXJyvQqhbgcNqVo = "windowsStandalone_useSteamRawInputControllerWorkaround";

			public const string HxOKWLhmniHTpJbApNpEuGLmXjSL = "osxStandalone_useEnhancedDeviceSupport";

			public const string rvHgoQBqMzyrECzTpTCIJkLCIAJXA = "android_supportUnknownGamepads";

			public const string DcrFeWCAjgoMGEQjJnMHhxSHGAaAA = "ps4_assignJoysticksByPS4JoyId";

			public const string lnRciogWRUHhALvanxIandKYiCPnA = "useSteamControllerSupport";

			public const string NywmUTgZfWmGHrKWUCgLUgVXaKgc = "logToScreen";

			public const string oxXdbehTZBqUuHRVJgLTBvlsPYSs = "runInEditMode";

			public const string zWLhyuTemlMUibkqytvDMpLxFscR = "allowInputInEditorSceneView";

			public const string AQXjnicaapJeNZkYxFHjhGApETBw = "maxJoysticksPerPlayer";

			public const string WjYBsaPgbdFLudlAWBiucgPNJpKVA = "autoAssignJoysticks";

			public const string CcHXrfVWmwHtbfmjnihYNNqvDWPo = "assignJoysticksToPlayingPlayersOnly";

			public const string dgrlEKSdZSbreudWxskipIcTbBFG = "distributeJoysticksEvenly";

			public const string ogPMeFOYDqhQGutntbKJfnouCGOEA = "reassignJoystickToPreviousOwnerOnReconnect";

			public const string EdafguesdprbjUASsXHAFbbNMeus = "defaultJoystickAxis2DDeadZoneType";

			public const string HrBVyZOWOycwtORfIxPKZzQpoOkE = "defaultJoystickAxis2DSensitivityType";

			public const string dCzcsUfOeKbKVClqbaYtJdKacrALD = "defaultAxisSensitivityType";

			public const string KeoFLAkXiQIIZNsadUAeusLoQWbN = "force4WayHats";

			public const string YEPfgAbHYhkqwODSQYEjfScOJpaUA = "throttleCalibrationMode";

			public const string YzsLpkfqqVBXZpdvYBRqOrGkCGsw = "activateActionButtonsOnNegativeValue";

			public const string IYfwNriCPHqqnwqajpOtoxaRLwkf = "deferControllerConnectedEventsOnStart";

			public const string aoSlyYcDbmfZhFlGkzALmTjLuMei = "logLevel";

			public const string lNtdwbeHqrcudCTXYmcjPWUuEXLv = "disableKeyboard";

			public const string peBAEAsgXVkeLVFvsgRUgqEGzneIA = "disableMouse";

			public const string bHKiuRpnsMFBxkhINazCFFmcDAVaA = "ignoreInputWhenAppNotInFocus";

			public const string oFnKEpefXYXGEUCvOSNcapaWDIFI = "useEnhancedDeviceSupport";

			public const string mtwtkclLVpSnPTvQaedrNVNRHjvO = "useNativeMouse";

			public const string NsWkCaBqjsvWIvaKdhIlHhvEmpOJA = "useNativeKeyboard";

			public const string XpoKZvyzaaVxTEaEKuYbIQLMJoNN = "joystickRefreshRate";

			public const string biCSBBwTxMjkEATwjObGfeAkMJuo = "assignJoysticksBySystemId";
		}

		[Serializable]
		public class PlatformVars
		{
			public bool disableKeyboard;

			public bool disableMouse;

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
			public bool useAppleGameController;

			public bool assignJoysticksByUserId;
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
		public class PlatformVars_PS5 : PlatformVars
		{
			public bool assignJoysticksByPS5JoyId;
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

		private class LNNkGoidqzRbHWjDopxqTOIzUHlG
		{
			public Func<PlatformVars> VtzsupusoQuuILGmeNHUnDQOLoQG;

			public string lHxwyGknbynaEnRFBiOjqTyfJrHI;

			public LNNkGoidqzRbHWjDopxqTOIzUHlG(Func<PlatformVars> P_0, string P_1)
			{
			}
		}

		private class QEAIIQrZORrGJefzspBJZcAyAXUt
		{
			public Func<Platform, object> VtzsupusoQuuILGmeNHUnDQOLoQG;

			public Action<Platform, object> DwCFBhMncQGFplVErVtTwCwOvBQI;

			public QEAIIQrZORrGJefzspBJZcAyAXUt(Func<Platform, object> P_0, Action<Platform, object> P_1)
			{
			}
		}

		[CustomObfuscation]
		internal enum AllPlatformVar
		{
			[CustomObfuscation]
			DisableKeyboard = 0,
			[CustomObfuscation]
			IgnoreInputWhenAppNotInFocus = 1,
			[CustomObfuscation]
			DisableMouse = 2
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

		public PlatformVars_WindowsUWP platformVars_windowsUWP;

		public PlatformVars platformVars_iOS;

		public PlatformVars platformVars_tvOS;

		public PlatformVars platformVars_android;

		public PlatformVars platformVars_ps4;

		public PlatformVars_PS5 platformVars_ps5;

		public PlatformVars platformVars_psVita;

		public PlatformVars platformVars_xboxOne;

		public PlatformVars_GameCoreXboxOne platformVars_gameCoreXboxOne;

		public PlatformVars_GameCoreScarlett platformVars_gameCoreScarlett;

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

		private Dictionary<int, LNNkGoidqzRbHWjDopxqTOIzUHlG> __platformVarsDict;

		private Dictionary<int, QEAIIQrZORrGJefzspBJZcAyAXUt> __getSetPlatformVariableDict;

		private KeyedGetSetValueStore<string> __configVarsValues;

		private Dictionary<string, object> __valueDelegates;

		private Dictionary<int, LNNkGoidqzRbHWjDopxqTOIzUHlG> platformVarsDict => null;

		private Dictionary<int, QEAIIQrZORrGJefzspBJZcAyAXUt> getSetPlatformVariableDict => null;

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

		internal bool GetPlatformVar_disableMouse()
		{
			return false;
		}

		internal bool SetPlatformVar_disableMouse(bool value)
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

		internal bool GetPlatformVar_useAppleGameController()
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

		internal bool SetPlatformVar_useAppleGameController(bool value)
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
