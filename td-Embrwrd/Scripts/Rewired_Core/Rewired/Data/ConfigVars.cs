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
		private static class trUbaFyFBrjwryIGsYyXZtWgRiuJ
		{
			public const string YVODiExRZdNckwJNEMriNSKGVpOo = "updateLoop";

			public const string sYipvMXWKLkzGZDzKqgKcYjZoqlx = "alwaysUseUnityInput";

			public const string LGxUOYnUgdsfpEfZrKSSoMLsUxCm = "windowsStandalonePrimaryInputSource";

			public const string yafjeDaaSWzpwwhnPCDCcVNSNcCDb = "osx_primaryInputSource";

			public const string fGgZCKPnRJBJAvjWhjsOihADxCCF = "linux_primaryInputSource";

			public const string bCTGCVAIMsVbGEeNceBLGqOBLVGVB = "windowsUWP_primaryInputSource";

			public const string iPiQExhvQoCSRkdwjbyRvYSWnfJJ = "xboxOne_primaryInputSource";

			public const string hbkLvgYAxFGFZbCdeKozHoSuBXRtA = "gameCoreXboxOne_primaryInputSource";

			public const string HUrySALpJMdwcdqsmtIawxSjWVro = "gameCoreScarlett_primaryInputSource";

			public const string prBBebWJSZrhmUFKgFQKBNRZWmCn = "ps4_primaryInputSource";

			public const string gwAvEiNrSHvrriBmCEwqecqPpauX = "ps5_primaryInputSource";

			public const string nJzGrWBonKGcXeEtkCjmNepMGgdMb = "webGL_primaryInputSource";

			public const string sfmlepoByqsDudqXpBfALiFhGhBkA = "useXInput";

			public const string PlgDFebfwikGtyiYHbTWGEddIkJMB = "windowsStandalone_useSteamRawInputControllerWorkaround";

			public const string uyeJAxtcIVBBJFuNUpzWTkdjBGwe = "osxStandalone_useEnhancedDeviceSupport";

			public const string sgWbORMZeSkSPAmXqABlxHKPsBrO = "android_supportUnknownGamepads";

			public const string bqeKUueeuONWbBovViyjdgQCxhfF = "ps4_assignJoysticksByPS4JoyId";

			public const string oxhfUrlFyfQAmrMSTCQmarjkLIHs = "useSteamControllerSupport";

			public const string PHdvixeiTTNUnnaJIBVBFLZrHTtbb = "logToScreen";

			public const string WIHSIDRnSivGpeWyuZWpctqPbwOE = "runInEditMode";

			public const string XwsvWhbthtOhNgRpNKSZePgRommU = "allowInputInEditorSceneView";

			public const string uqHhdJTClfBfOaOtDpJqYfsnalEHb = "maxJoysticksPerPlayer";

			public const string ifxdxBLrOGDdOYqgrHotBSWvbcHC = "autoAssignJoysticks";

			public const string coBWdNAyFvOqvNXSbqARVPqmBLGs = "assignJoysticksToPlayingPlayersOnly";

			public const string vQRyvPGauZbitkXXGFToPHRkGaDL = "distributeJoysticksEvenly";

			public const string ghqZNzKJmzCSTRwGSvLdrvaeJxxt = "reassignJoystickToPreviousOwnerOnReconnect";

			public const string yZtFWrCThtwaWNoBwCNpHpozTalGb = "defaultJoystickAxis2DDeadZoneType";

			public const string ySMAkGJndQOirdyBDQDOGFzmsAQeb = "defaultJoystickAxis2DSensitivityType";

			public const string CPcMlhzLxDBNZDrPygCbnCQtnkQlA = "defaultAxisSensitivityType";

			public const string SoOEKMZNEXmbWGqmyGkYnKRJGRjC = "force4WayHats";

			public const string VSRsdvUikVjLPhipVHCWrQGEnldwA = "throttleCalibrationMode";

			public const string YINaBkGfxSsuObihgtThErAUcQqyA = "activateActionButtonsOnNegativeValue";

			public const string DtwrWCaPCovrIIaEBmQbqZlCcfYd = "deferControllerConnectedEventsOnStart";

			public const string ZwpQFOXaXXyhkBKmNSWuniODaJmw = "logLevel";

			public const string FSAYBHTnaJNYbQSVCrPZRMMInGMI = "disableKeyboard";

			public const string BCvurrJILZeTjUWVWiZRpDUDNXVi = "disableMouse";

			public const string InhtHaegfUBqNjbLIwluLHZEDdDBA = "ignoreInputWhenAppNotInFocus";

			public const string qfkesZozjaJmXHaITyGaOPlukhCk = "useEnhancedDeviceSupport";

			public const string SSbwVXnEgRdXngInBMQejmFOrbhhA = "useNativeMouse";

			public const string vaUQIlFySYIiediWGCrrThbDxFCX = "useNativeKeyboard";

			public const string SSRPcDGqHUhyCnGykTiBMRLfEeUiA = "joystickRefreshRate";

			public const string mQLpCfqfMTJADBTkFTatRtaceVwe = "assignJoysticksBySystemId";
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

			public bool useWindowsGamingInput;

			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes;
		}

		[Serializable]
		public class PlatformVars_OSXStandalone : PlatformVars
		{
			public bool useAppleGameController;

			public bool assignJoysticksByUserId;

			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes;
		}

		[Serializable]
		public class PlatformVars_LinuxStandalone : PlatformVars
		{
			public bool useEnhancedDeviceSupport;

			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes;
		}

		[Serializable]
		public class PlatformVars_WindowsUWP : PlatformVars
		{
			public bool useGamepadAPI;

			public bool useHIDAPI;
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

		private class dbBWfgMIOHtRUcwSssOUaDHAJxMS
		{
			public Func<PlatformVars> cXOErSdXnhdCsmzcmOaaHIjNdHPm;

			public string wvJumUzJGqNfTvBouJvsnEEOolOO;

			public dbBWfgMIOHtRUcwSssOUaDHAJxMS(Func<PlatformVars> P_0, string P_1)
			{
			}
		}

		private class oLGoZGPwkzTbOQaoeeuxiIPFwojQ
		{
			public Func<Platform, object> CtWRGQOYUjZLciPtGLdqVzRsCdEJ;

			public Action<Platform, object> YLgIFdbkGGIOuKQPQnKfpYZsgpJk;

			public oLGoZGPwkzTbOQaoeeuxiIPFwojQ(Func<Platform, object> P_0, Action<Platform, object> P_1)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal enum AllPlatformVar
		{
			[CustomObfuscation(rename = false)]
			DisableKeyboard = 0,
			[CustomObfuscation(rename = false)]
			IgnoreInputWhenAppNotInFocus = 1,
			[CustomObfuscation(rename = false)]
			DisableMouse = 2
		}

		public UpdateMode updateMode;

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

		public bool useXInput;

		public bool useNativeMouse;

		public bool useEnhancedDeviceSupport;

		public bool osxStandalone_useEnhancedDeviceSupport;

		public bool android_supportUnknownGamepads;

		public bool ps4_assignJoysticksByPS4JoyId;

		public bool useSteamControllerSupport;

		public bool logToScreen;

		public bool runInEditMode;

		public bool allowInputInEditorSceneView;

		public bool unityUsePhysicalKeys;

		public KeyCombinationOverrideMode keyCombinationOverrideMode;

		public bool generateKeyEventsOnKeyCombinationOverride;

		public PlatformVars_WindowsStandalone platformVars_windowsStandalone;

		public PlatformVars_LinuxStandalone platformVars_linuxStandalone;

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

		public PlatformVars platformVars_switch2;

		public PlatformVars platformVars_webGL;

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

		public bool disableAxis2dClamping;

		public EditorVars editorSettings;

		private Dictionary<int, dbBWfgMIOHtRUcwSssOUaDHAJxMS> __platformVarsDict;

		private Dictionary<int, oLGoZGPwkzTbOQaoeeuxiIPFwojQ> __getSetPlatformVariableDict;

		private KeyedGetSetValueStore<string> __configVarsValues;

		private Dictionary<string, object> __valueDelegates;

		private Dictionary<int, dbBWfgMIOHtRUcwSssOUaDHAJxMS> platformVarsDict => null;

		private Dictionary<int, oLGoZGPwkzTbOQaoeeuxiIPFwojQ> getSetPlatformVariableDict => null;

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

		internal bool GetPlatformVar_useWindowsGamingInput()
		{
			return false;
		}

		internal IList<EnhancedDeviceSupportDeviceType> GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes()
		{
			return null;
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

		internal bool SetPlatformVar_useWindowsGamingInput(bool value)
		{
			return false;
		}

		internal bool SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(IList<EnhancedDeviceSupportDeviceType> value)
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

		private static bool IsNativeKeyboardAllowed(Platform platform, bool unityUsePhysicalKeys)
		{
			return false;
		}
	}
}
