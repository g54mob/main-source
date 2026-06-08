using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class ConfigVars : IConfigVars_Internal
	{
		private static class rNRVOiwGLUxOzBgBbiTvuTuxYPu
		{
			public const string cmiDdQAFcgEckBbjnNTFEbMKLqrn = "updateLoop";

			public const string vgBWhUCuJzuzFxPXYTjzcvylMQM = "alwaysUseUnityInput";

			public const string MTWieTtgRMmsIpZxfVkisyoyyuy = "windowsStandalonePrimaryInputSource";

			public const string XfCwMxhGKSurMLILfTJPuKMNgYP = "osx_primaryInputSource";

			public const string WuNDFZUZEoMpBLOhwHSaRxcEMNu = "linux_primaryInputSource";

			public const string zsKMdxLLRorzqfCcLdLWIdrOwnp = "windowsUWP_primaryInputSource";

			public const string wvNlTZZIJZKTryGkiWrllaAkWUJ = "xboxOne_primaryInputSource";

			public const string ZVxYvLyeJSbqABsoxlvvGCoqrWc = "gameCoreXboxOne_primaryInputSource";

			public const string pJURPAdqebbYYgcNQPNxdRCPPfF = "gameCoreScarlett_primaryInputSource";

			public const string SKegBRqYLBbFdXwnXjOpzAWeIHu = "ps4_primaryInputSource";

			public const string EmaBkVmPmGnjwJohRrWVgVTGlwR = "ps5_primaryInputSource";

			public const string PYPhblVyxXzsUMzfZEeMNIECNim = "webGL_primaryInputSource";

			public const string BgDqqpPHKqubuZlZTaYxohnwWAi = "stadia_primaryInputSource";

			public const string jhphfkpWgsTdEKEFyZZfSKGCOcX = "useXInput";

			public const string YmXWUhGiBWanhfKLzyumjRWGXIi = "windowsStandalone_useSteamRawInputControllerWorkaround";

			public const string dUBLMcRTWfmRqIDWcefYDigUKmhI = "osxStandalone_useEnhancedDeviceSupport";

			public const string NUsqzKlNuhrLwDScuFUkaoadck = "android_supportUnknownGamepads";

			public const string xcdmvxsUlXINPThSsyLKnvnEhHh = "ps4_assignJoysticksByPS4JoyId";

			public const string DDEkAXcsxVnpNuozesqqrnycrKy = "useSteamControllerSupport";

			public const string zQhCqnFOyDcwTfgEcBqeyGPOxBfJ = "logToScreen";

			public const string ItUFzLNykMWppQPBYjJPVtEKtGh = "runInEditMode";

			public const string PZSojZbWZsYXfqwXnZKZEyXBXJo = "allowInputInEditorSceneView";

			public const string ibKMrXWlPghyGHAMqLdnCvrfJcgI = "maxJoysticksPerPlayer";

			public const string egRIVTpkIeAVjkQCRIUibwgnuKja = "autoAssignJoysticks";

			public const string mmMnXOrJnbbcuqHjcZrQVKRTpfa = "assignJoysticksToPlayingPlayersOnly";

			public const string LKcDhfeWSXxbhvWdkQMgjifbIOgc = "distributeJoysticksEvenly";

			public const string AsCocgyeofDUPzKlkHoPgdDWKrpC = "reassignJoystickToPreviousOwnerOnReconnect";

			public const string krdCqFODMwZhaDIQhqbMLGOxSTB = "defaultJoystickAxis2DDeadZoneType";

			public const string vyEQXqaDbfrssLeDXRPQHIQHCFH = "defaultJoystickAxis2DSensitivityType";

			public const string ZSokdTgPfXGWNgmkpoxOvvKOIwE = "defaultAxisSensitivityType";

			public const string gRrdPnWQVHHYMWcykkgumzcECbY = "force4WayHats";

			public const string anGwlYlbhecfDKSRZclYALKoELw = "throttleCalibrationMode";

			public const string aYjtlBVoFUPhSyatLhsiWolCjKX = "activateActionButtonsOnNegativeValue";

			public const string qtetcCSaaQfmgDpsyLVhpkFfHmXu = "deferControllerConnectedEventsOnStart";

			public const string OaVSxrYmIpqxkYACbjBJBeUjnXFw = "logLevel";

			public const string FAkJrMKyFiDkuBYVZFIxTOlIcsk = "disableKeyboard";

			public const string BiPdecVDFRtFyblGYGREJXDYXjwV = "ignoreInputWhenAppNotInFocus";

			public const string YKgzWGOhKDVTJBrxDbggkRZeRwa = "useEnhancedDeviceSupport";

			public const string MYxooLNfqybnGQdUjNVhZDcjeGI = "useNativeMouse";

			public const string pdHWoTbcSlHIFiLSgCylbjIiUGb = "useNativeKeyboard";

			public const string tEzZPOGBRrkpCXeALYmnCvooXxi = "joystickRefreshRate";

			public const string BNDDJaIbOXoRBXDwoBcYvxtSoWH = "assignJoysticksBySystemId";
		}

		[Serializable]
		public class PlatformVars
		{
			public bool disableKeyboard;

			public bool ignoreInputWhenAppNotInFocus = true;
		}

		[Serializable]
		public class PlatformVars_WindowsStandalone : PlatformVars
		{
			public bool useNativeKeyboard = true;

			public int joystickRefreshRate = 240;
		}

		[Serializable]
		public class PlatformVars_WindowsUWP : PlatformVars
		{
			public bool useGamepadAPI = true;

			public bool useHIDAPI = true;
		}

		[Serializable]
		public class PlatformVars_Stadia : PlatformVars
		{
			public bool useNativeKeyboard = true;

			public bool useNativeMouse = true;
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

			public string exportConsts_parentClassName = "RewiredConsts";

			public bool exportConsts_useNamespace = true;

			public string exportConsts_namespace = "RewiredConsts";

			public bool exportConsts_actions = true;

			public string exportConsts_actionsClassName = "Action";

			public bool exportConsts_actionsIncludeActionCategory;

			public bool exportConsts_actionsCreateClassesForActionCategories;

			public bool exportConsts_mapCategories = true;

			public string exportConsts_mapCategoriesClassName = "Category";

			public bool exportConsts_layouts = true;

			public string exportConsts_layoutsClassName = "Layout";

			public bool exportConsts_players = true;

			public string exportConsts_playersClassName = "Player";

			public bool exportConsts_inputBehaviors;

			public string exportConsts_inputBehaviorsClassName = "InputBehavior";

			public bool exportConsts_customControllers = true;

			public string exportConsts_customControllersClassName = "CustomController";

			public string exportConsts_customControllersAxesClassName = "Axis";

			public string exportConsts_customControllersButtonsClassName = "Button";

			public bool exportConsts_layoutManagerRuleSets = true;

			public string exportConsts_layoutManagerRuleSetsClassName = "LayoutManagerRuleSet";

			public bool exportConsts_mapEnablerRuleSets = true;

			public string exportConsts_mapEnablerRuleSetsClassName = "MapEnablerRuleSet";

			public bool exportConsts_allCapsConstantNames;
		}

		private class tjABoXOQAyjBYeZNxsBenZrHedOF
		{
			public Func<PlatformVars> txqzmCYXXBQyPUZQzhoGrLngkLv;

			public string NIgOofEOGdZhLyuZEiQpkkLZNku;

			public tjABoXOQAyjBYeZNxsBenZrHedOF(Func<PlatformVars> getDelegate, string dataPath)
			{
				txqzmCYXXBQyPUZQzhoGrLngkLv = getDelegate;
				NIgOofEOGdZhLyuZEiQpkkLZNku = dataPath;
			}
		}

		private class yjNeEvDPuGMbGbjvroXFgZhQdejq
		{
			public Func<Platform, object> txqzmCYXXBQyPUZQzhoGrLngkLv;

			public Action<Platform, object> pZJOBKkDHPLOaaQEqjtZmsFwGSd;

			public yjNeEvDPuGMbGbjvroXFgZhQdejq(Func<Platform, object> getDelegate, Action<Platform, object> setDelegate)
			{
				txqzmCYXXBQyPUZQzhoGrLngkLv = getDelegate;
				pZJOBKkDHPLOaaQEqjtZmsFwGSd = setDelegate;
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

		public UpdateLoopSetting updateLoop = UpdateLoopSetting.Update;

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

		public bool useXInput = true;

		public bool useNativeMouse = true;

		public bool useEnhancedDeviceSupport = true;

		public bool windowsStandalone_useSteamRawInputControllerWorkaround;

		public bool osxStandalone_useEnhancedDeviceSupport = true;

		public bool android_supportUnknownGamepads = true;

		public bool ps4_assignJoysticksByPS4JoyId = true;

		public bool useSteamControllerSupport = true;

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

		public int maxJoysticksPerPlayer = 1;

		public bool autoAssignJoysticks = true;

		public bool assignJoysticksToPlayingPlayersOnly;

		public bool distributeJoysticksEvenly = true;

		public bool reassignJoystickToPreviousOwnerOnReconnect = true;

		public DeadZone2DType defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;

		public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType;

		public AxisSensitivityType defaultAxisSensitivityType;

		public bool force4WayHats;

		public ThrottleCalibrationMode throttleCalibrationMode;

		public bool activateActionButtonsOnNegativeValue;

		public bool deferControllerConnectedEventsOnStart;

		public LogLevelFlags logLevel = LogLevelFlags.Info | LogLevelFlags.Warning | LogLevelFlags.Error;

		public EditorVars editorSettings;

		private Dictionary<int, tjABoXOQAyjBYeZNxsBenZrHedOF> __platformVarsDict;

		private Dictionary<int, yjNeEvDPuGMbGbjvroXFgZhQdejq> __getSetPlatformVariableDict;

		private KeyedGetSetValueStore<string> __configVarsValues;

		private Dictionary<string, object> __valueDelegates;

		private Dictionary<int, tjABoXOQAyjBYeZNxsBenZrHedOF> platformVarsDict => __platformVarsDict ?? (__platformVarsDict = new Dictionary<int, tjABoXOQAyjBYeZNxsBenZrHedOF>
		{
			{
				1,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_windowsStandalone), "platformVars_windowsStandalone")
			},
			{
				2,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_windows8Store), "platformVars_windows8Store")
			},
			{
				3,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_windows8Store), "platformVars_windows8Store")
			},
			{
				29,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_windowsUWP), "platformVars_windowsUWP")
			},
			{
				6,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_linuxStandalone), "platformVars_linuxStandalone")
			},
			{
				4,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_osxStandalone), "platformVars_osxStandalone")
			},
			{
				5,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_iOS), "platformVars_iOS")
			},
			{
				28,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_tvOS), "platformVars_tvOS")
			},
			{
				12,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_ps3), "platformVars_ps3")
			},
			{
				13,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_ps4), "platformVars_ps4")
			},
			{
				106,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_ps5), "platformVars_ps5")
			},
			{
				15,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_psVita), "platformVars_psVita")
			},
			{
				14,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_psVita), "platformVars_psVita")
			},
			{
				16,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_wii), "platformVars_wii")
			},
			{
				18,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_wiiu), "platformVars_wiiu")
			},
			{
				32,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_switch), "platformVars_switch")
			},
			{
				10,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_xbox360), "platformVars_xbox360")
			},
			{
				11,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_xboxOne), "platformVars_xboxOne")
			},
			{
				104,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_gameCoreXboxOne), "platformVars_gameCoreXboxOne")
			},
			{
				105,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_gameCoreScarlett), "platformVars_gameCoreScarlett")
			},
			{
				19,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_webGL), "platformVars_webGL")
			},
			{
				103,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_stadia), "platformVars_stadia")
			},
			{
				7,
				new tjABoXOQAyjBYeZNxsBenZrHedOF(() => GetOrCreatePlatformVars(ref platformVars_android), "platformVars_android")
			}
		});

		private Dictionary<int, yjNeEvDPuGMbGbjvroXFgZhQdejq> getSetPlatformVariableDict => __getSetPlatformVariableDict ?? (__getSetPlatformVariableDict = new Dictionary<int, yjNeEvDPuGMbGbjvroXFgZhQdejq>
		{
			{
				0,
				new yjNeEvDPuGMbGbjvroXFgZhQdejq((Platform p) => GetPlatformVars(p).disableKeyboard, delegate(Platform platform, object value)
				{
					GetPlatformVars(platform).disableKeyboard = (bool)value;
				})
			},
			{
				1,
				new yjNeEvDPuGMbGbjvroXFgZhQdejq((Platform platform) => GetPlatformVars(platform).ignoreInputWhenAppNotInFocus, delegate(Platform platform, object value)
				{
					GetPlatformVars(platform).ignoreInputWhenAppNotInFocus = (bool)value;
				})
			}
		});

		KeyedGetSetValueStore<string> IConfigVars_Internal.values
		{
			get
			{
				if (__configVarsValues == null)
				{
					__configVarsValues = new KeyedGetSetValueStore<string>(valueDelegates, isReadOnlyCollection: true);
				}
				return __configVarsValues;
			}
		}

		private Dictionary<string, object> valueDelegates
		{
			get
			{
				Func<bool> func34 = default(Func<bool>);
				Action<bool> action35 = default(Action<bool>);
				Func<WindowsStandalonePrimaryInputSource> func35 = default(Func<WindowsStandalonePrimaryInputSource>);
				Action<WindowsStandalonePrimaryInputSource> action36 = default(Action<WindowsStandalonePrimaryInputSource>);
				Func<OSXStandalonePrimaryInputSource> func36 = default(Func<OSXStandalonePrimaryInputSource>);
				Action<OSXStandalonePrimaryInputSource> action16 = default(Action<OSXStandalonePrimaryInputSource>);
				Func<LinuxStandalonePrimaryInputSource> func14 = default(Func<LinuxStandalonePrimaryInputSource>);
				Action<LinuxStandalonePrimaryInputSource> action15 = default(Action<LinuxStandalonePrimaryInputSource>);
				Func<WindowsUWPPrimaryInputSource> func20 = default(Func<WindowsUWPPrimaryInputSource>);
				Action<WindowsUWPPrimaryInputSource> action24 = default(Action<WindowsUWPPrimaryInputSource>);
				Func<XboxOnePrimaryInputSource> func21 = default(Func<XboxOnePrimaryInputSource>);
				Action<XboxOnePrimaryInputSource> action25 = default(Action<XboxOnePrimaryInputSource>);
				Func<GameCoreXboxOnePrimaryInputSource> func22 = default(Func<GameCoreXboxOnePrimaryInputSource>);
				Action<GameCoreXboxOnePrimaryInputSource> action19 = default(Action<GameCoreXboxOnePrimaryInputSource>);
				Func<GameCoreScarlettPrimaryInputSource> func17 = default(Func<GameCoreScarlettPrimaryInputSource>);
				Action<GameCoreScarlettPrimaryInputSource> action20 = default(Action<GameCoreScarlettPrimaryInputSource>);
				Func<PS4PrimaryInputSource> func39 = default(Func<PS4PrimaryInputSource>);
				Action<PS4PrimaryInputSource> action38 = default(Action<PS4PrimaryInputSource>);
				Func<PS5PrimaryInputSource> func27 = default(Func<PS5PrimaryInputSource>);
				Action<PS5PrimaryInputSource> action29 = default(Action<PS5PrimaryInputSource>);
				Func<WebGLPrimaryInputSource> func28 = default(Func<WebGLPrimaryInputSource>);
				Action<WebGLPrimaryInputSource> action30 = default(Action<WebGLPrimaryInputSource>);
				Func<StadiaPrimaryInputSource> func29 = default(Func<StadiaPrimaryInputSource>);
				Action<StadiaPrimaryInputSource> action31 = default(Action<StadiaPrimaryInputSource>);
				Func<bool> func30 = default(Func<bool>);
				Action<bool> action32 = default(Action<bool>);
				Func<bool> func31 = default(Func<bool>);
				Action<bool> action33 = default(Action<bool>);
				Func<bool> func32 = default(Func<bool>);
				Action<bool> action34 = default(Action<bool>);
				Func<bool> func33 = default(Func<bool>);
				Action<bool> action26 = default(Action<bool>);
				Func<bool> func7 = default(Func<bool>);
				Action<bool> action22 = default(Action<bool>);
				Func<bool> func19 = default(Func<bool>);
				Action<bool> action23 = default(Action<bool>);
				Func<bool> func23 = default(Func<bool>);
				Action<bool> action14 = default(Action<bool>);
				Func<bool> func3 = default(Func<bool>);
				Action<bool> action3 = default(Action<bool>);
				Func<bool> func4 = default(Func<bool>);
				Action<bool> action4 = default(Action<bool>);
				Func<int> func5 = default(Func<int>);
				Action<int> action5 = default(Action<int>);
				Func<bool> func6 = default(Func<bool>);
				Action<bool> action6 = default(Action<bool>);
				Func<bool> func24 = default(Func<bool>);
				Action<bool> action27 = default(Action<bool>);
				Func<bool> func25 = default(Func<bool>);
				Action<bool> action28 = default(Action<bool>);
				Func<bool> func26 = default(Func<bool>);
				Action<bool> action11 = default(Action<bool>);
				Func<DeadZone2DType> func12 = default(Func<DeadZone2DType>);
				Action<DeadZone2DType> action12 = default(Action<DeadZone2DType>);
				Func<AxisSensitivity2DType> func13 = default(Func<AxisSensitivity2DType>);
				Action<AxisSensitivity2DType> action13 = default(Action<AxisSensitivity2DType>);
				Func<AxisSensitivityType> func = default(Func<AxisSensitivityType>);
				Action<AxisSensitivityType> action = default(Action<AxisSensitivityType>);
				Func<bool> func2 = default(Func<bool>);
				Action<bool> action2 = default(Action<bool>);
				Func<ThrottleCalibrationMode> func37 = default(Func<ThrottleCalibrationMode>);
				Action<ThrottleCalibrationMode> action37 = default(Action<ThrottleCalibrationMode>);
				Func<bool> func38 = default(Func<bool>);
				Action<bool> action17 = default(Action<bool>);
				Func<bool> func15 = default(Func<bool>);
				Action<bool> action18 = default(Action<bool>);
				Func<LogLevelFlags> func16 = default(Func<LogLevelFlags>);
				Action<LogLevelFlags> action21 = default(Action<LogLevelFlags>);
				Func<bool> func18 = default(Func<bool>);
				Action<bool> action7 = default(Action<bool>);
				Func<bool> func8 = default(Func<bool>);
				Action<bool> action8 = default(Action<bool>);
				Func<bool> func9 = default(Func<bool>);
				Action<bool> action9 = default(Action<bool>);
				Func<bool> func10 = default(Func<bool>);
				Action<bool> action10 = default(Action<bool>);
				Func<bool> func11 = default(Func<bool>);
				while (true)
				{
					int num = 16524690;
					while (true)
					{
						switch (num ^ 0xFC2594)
						{
						case 23:
							break;
						case 14:
							if (__valueDelegates == null)
							{
								Dictionary<string, object> dictionary = new Dictionary<string, object> { 
								{
									"updateLoop",
									new GetSetValue<UpdateLoopSetting>(() => updateLoop, delegate(UpdateLoopSetting x)
									{
										updateLoop = x;
									})
								} };
								if (func34 == null)
								{
									func34 = () => alwaysUseUnityInput;
								}
								Func<bool> getValueDelegate = func34;
								if (action35 == null)
								{
									action35 = delegate(bool x)
									{
										alwaysUseUnityInput = x;
									};
								}
								dictionary.Add("alwaysUseUnityInput", new GetSetValue<bool>(getValueDelegate, action35));
								if (func35 == null)
								{
									func35 = () => windowsStandalonePrimaryInputSource;
								}
								Func<WindowsStandalonePrimaryInputSource> getValueDelegate2 = func35;
								if (action36 == null)
								{
									action36 = delegate(WindowsStandalonePrimaryInputSource x)
									{
										windowsStandalonePrimaryInputSource = x;
									};
								}
								dictionary.Add("windowsStandalonePrimaryInputSource", new GetSetValue<WindowsStandalonePrimaryInputSource>(getValueDelegate2, action36));
								if (func36 == null)
								{
									func36 = () => osx_primaryInputSource;
								}
								Func<OSXStandalonePrimaryInputSource> getValueDelegate3 = func36;
								if (action16 == null)
								{
									action16 = delegate(OSXStandalonePrimaryInputSource x)
									{
										osx_primaryInputSource = x;
									};
								}
								dictionary.Add("osx_primaryInputSource", new GetSetValue<OSXStandalonePrimaryInputSource>(getValueDelegate3, action16));
								if (func14 == null)
								{
									func14 = () => linux_primaryInputSource;
								}
								Func<LinuxStandalonePrimaryInputSource> getValueDelegate4 = func14;
								if (action15 == null)
								{
									action15 = delegate(LinuxStandalonePrimaryInputSource x)
									{
										linux_primaryInputSource = x;
									};
								}
								dictionary.Add("linux_primaryInputSource", new GetSetValue<LinuxStandalonePrimaryInputSource>(getValueDelegate4, action15));
								if (func20 == null)
								{
									func20 = () => windowsUWP_primaryInputSource;
								}
								Func<WindowsUWPPrimaryInputSource> getValueDelegate5 = func20;
								if (action24 == null)
								{
									action24 = delegate(WindowsUWPPrimaryInputSource x)
									{
										windowsUWP_primaryInputSource = x;
									};
								}
								dictionary.Add("windowsUWP_primaryInputSource", new GetSetValue<WindowsUWPPrimaryInputSource>(getValueDelegate5, action24));
								if (func21 == null)
								{
									func21 = () => xboxOne_primaryInputSource;
								}
								Func<XboxOnePrimaryInputSource> getValueDelegate6 = func21;
								if (action25 == null)
								{
									action25 = delegate(XboxOnePrimaryInputSource x)
									{
										xboxOne_primaryInputSource = x;
									};
								}
								dictionary.Add("xboxOne_primaryInputSource", new GetSetValue<XboxOnePrimaryInputSource>(getValueDelegate6, action25));
								if (func22 == null)
								{
									func22 = () => gameCoreXboxOne_primaryInputSource;
								}
								Func<GameCoreXboxOnePrimaryInputSource> getValueDelegate7 = func22;
								if (action19 == null)
								{
									action19 = delegate(GameCoreXboxOnePrimaryInputSource x)
									{
										gameCoreXboxOne_primaryInputSource = x;
									};
								}
								dictionary.Add("gameCoreXboxOne_primaryInputSource", new GetSetValue<GameCoreXboxOnePrimaryInputSource>(getValueDelegate7, action19));
								if (func17 == null)
								{
									func17 = () => gameCoreScarlett_primaryInputSource;
								}
								Func<GameCoreScarlettPrimaryInputSource> getValueDelegate8 = func17;
								if (action20 == null)
								{
									action20 = delegate(GameCoreScarlettPrimaryInputSource x)
									{
										gameCoreScarlett_primaryInputSource = x;
									};
								}
								dictionary.Add("gameCoreScarlett_primaryInputSource", new GetSetValue<GameCoreScarlettPrimaryInputSource>(getValueDelegate8, action20));
								if (func39 == null)
								{
									func39 = () => ps4_primaryInputSource;
								}
								Func<PS4PrimaryInputSource> getValueDelegate9 = func39;
								if (action38 == null)
								{
									action38 = delegate(PS4PrimaryInputSource x)
									{
										ps4_primaryInputSource = x;
									};
								}
								dictionary.Add("ps4_primaryInputSource", new GetSetValue<PS4PrimaryInputSource>(getValueDelegate9, action38));
								if (func27 == null)
								{
									func27 = () => ps5_primaryInputSource;
								}
								Func<PS5PrimaryInputSource> getValueDelegate10 = func27;
								if (action29 == null)
								{
									action29 = delegate(PS5PrimaryInputSource x)
									{
										ps5_primaryInputSource = x;
									};
								}
								dictionary.Add("ps5_primaryInputSource", new GetSetValue<PS5PrimaryInputSource>(getValueDelegate10, action29));
								if (func28 == null)
								{
									func28 = () => webGL_primaryInputSource;
								}
								Func<WebGLPrimaryInputSource> getValueDelegate11 = func28;
								if (action30 == null)
								{
									action30 = delegate(WebGLPrimaryInputSource x)
									{
										webGL_primaryInputSource = x;
									};
								}
								dictionary.Add("webGL_primaryInputSource", new GetSetValue<WebGLPrimaryInputSource>(getValueDelegate11, action30));
								if (func29 == null)
								{
									func29 = () => stadia_primaryInputSource;
								}
								Func<StadiaPrimaryInputSource> getValueDelegate12 = func29;
								if (action31 == null)
								{
									action31 = delegate(StadiaPrimaryInputSource x)
									{
										stadia_primaryInputSource = x;
									};
								}
								dictionary.Add("stadia_primaryInputSource", new GetSetValue<StadiaPrimaryInputSource>(getValueDelegate12, action31));
								if (func30 == null)
								{
									func30 = () => useXInput;
								}
								Func<bool> getValueDelegate13 = func30;
								if (action32 == null)
								{
									action32 = delegate(bool x)
									{
										useXInput = x;
									};
								}
								dictionary.Add("useXInput", new GetSetValue<bool>(getValueDelegate13, action32));
								if (func31 == null)
								{
									func31 = () => windowsStandalone_useSteamRawInputControllerWorkaround;
								}
								Func<bool> getValueDelegate14 = func31;
								if (action33 == null)
								{
									action33 = delegate(bool x)
									{
										windowsStandalone_useSteamRawInputControllerWorkaround = x;
									};
								}
								dictionary.Add("windowsStandalone_useSteamRawInputControllerWorkaround", new GetSetValue<bool>(getValueDelegate14, action33));
								if (func32 == null)
								{
									func32 = () => osxStandalone_useEnhancedDeviceSupport;
								}
								Func<bool> getValueDelegate15 = func32;
								if (action34 == null)
								{
									action34 = delegate(bool x)
									{
										osxStandalone_useEnhancedDeviceSupport = x;
									};
								}
								dictionary.Add("osxStandalone_useEnhancedDeviceSupport", new GetSetValue<bool>(getValueDelegate15, action34));
								if (func33 == null)
								{
									func33 = () => android_supportUnknownGamepads;
								}
								Func<bool> getValueDelegate16 = func33;
								if (action26 == null)
								{
									action26 = delegate(bool x)
									{
										android_supportUnknownGamepads = x;
									};
								}
								dictionary.Add("android_supportUnknownGamepads", new GetSetValue<bool>(getValueDelegate16, action26));
								if (func7 == null)
								{
									func7 = () => ps4_assignJoysticksByPS4JoyId;
								}
								Func<bool> getValueDelegate17 = func7;
								if (action22 == null)
								{
									action22 = delegate(bool x)
									{
										ps4_assignJoysticksByPS4JoyId = x;
									};
								}
								dictionary.Add("ps4_assignJoysticksByPS4JoyId", new GetSetValue<bool>(getValueDelegate17, action22));
								if (func19 == null)
								{
									func19 = () => useSteamControllerSupport;
								}
								Func<bool> getValueDelegate18 = func19;
								if (action23 == null)
								{
									action23 = delegate(bool x)
									{
										useSteamControllerSupport = x;
									};
								}
								dictionary.Add("useSteamControllerSupport", new GetSetValue<bool>(getValueDelegate18, action23));
								if (func23 == null)
								{
									func23 = () => logToScreen;
								}
								Func<bool> getValueDelegate19 = func23;
								if (action14 == null)
								{
									action14 = delegate(bool x)
									{
										logToScreen = x;
									};
								}
								dictionary.Add("logToScreen", new GetSetValue<bool>(getValueDelegate19, action14));
								if (func3 == null)
								{
									func3 = () => runInEditMode;
								}
								Func<bool> getValueDelegate20 = func3;
								if (action3 == null)
								{
									action3 = delegate(bool x)
									{
										runInEditMode = x;
									};
								}
								dictionary.Add("runInEditMode", new GetSetValue<bool>(getValueDelegate20, action3));
								if (func4 == null)
								{
									func4 = () => allowInputInEditorSceneView;
								}
								Func<bool> getValueDelegate21 = func4;
								if (action4 == null)
								{
									action4 = delegate(bool x)
									{
										allowInputInEditorSceneView = x;
									};
								}
								dictionary.Add("allowInputInEditorSceneView", new GetSetValue<bool>(getValueDelegate21, action4));
								if (func5 == null)
								{
									func5 = () => maxJoysticksPerPlayer;
								}
								Func<int> getValueDelegate22 = func5;
								if (action5 == null)
								{
									action5 = delegate(int x)
									{
										maxJoysticksPerPlayer = x;
									};
								}
								dictionary.Add("maxJoysticksPerPlayer", new GetSetValue<int>(getValueDelegate22, action5));
								if (func6 == null)
								{
									func6 = () => autoAssignJoysticks;
								}
								Func<bool> getValueDelegate23 = func6;
								if (action6 == null)
								{
									action6 = delegate(bool x)
									{
										autoAssignJoysticks = x;
									};
								}
								dictionary.Add("autoAssignJoysticks", new GetSetValue<bool>(getValueDelegate23, action6));
								if (func24 == null)
								{
									func24 = () => assignJoysticksToPlayingPlayersOnly;
								}
								Func<bool> getValueDelegate24 = func24;
								if (action27 == null)
								{
									action27 = delegate(bool x)
									{
										assignJoysticksToPlayingPlayersOnly = x;
									};
								}
								dictionary.Add("assignJoysticksToPlayingPlayersOnly", new GetSetValue<bool>(getValueDelegate24, action27));
								if (func25 == null)
								{
									func25 = () => distributeJoysticksEvenly;
								}
								Func<bool> getValueDelegate25 = func25;
								if (action28 == null)
								{
									action28 = delegate(bool x)
									{
										distributeJoysticksEvenly = x;
									};
								}
								dictionary.Add("distributeJoysticksEvenly", new GetSetValue<bool>(getValueDelegate25, action28));
								if (func26 == null)
								{
									func26 = () => reassignJoystickToPreviousOwnerOnReconnect;
								}
								Func<bool> getValueDelegate26 = func26;
								if (action11 == null)
								{
									action11 = delegate(bool x)
									{
										reassignJoystickToPreviousOwnerOnReconnect = x;
									};
								}
								dictionary.Add("reassignJoystickToPreviousOwnerOnReconnect", new GetSetValue<bool>(getValueDelegate26, action11));
								if (func12 == null)
								{
									func12 = () => defaultJoystickAxis2DDeadZoneType;
								}
								Func<DeadZone2DType> getValueDelegate27 = func12;
								if (action12 == null)
								{
									action12 = delegate(DeadZone2DType x)
									{
										defaultJoystickAxis2DDeadZoneType = x;
									};
								}
								dictionary.Add("defaultJoystickAxis2DDeadZoneType", new GetSetValue<DeadZone2DType>(getValueDelegate27, action12));
								if (func13 == null)
								{
									func13 = () => defaultJoystickAxis2DSensitivityType;
								}
								Func<AxisSensitivity2DType> getValueDelegate28 = func13;
								if (action13 == null)
								{
									action13 = delegate(AxisSensitivity2DType x)
									{
										defaultJoystickAxis2DSensitivityType = x;
									};
								}
								dictionary.Add("defaultJoystickAxis2DSensitivityType", new GetSetValue<AxisSensitivity2DType>(getValueDelegate28, action13));
								if (func == null)
								{
									func = () => defaultAxisSensitivityType;
								}
								Func<AxisSensitivityType> getValueDelegate29 = func;
								if (action == null)
								{
									action = delegate(AxisSensitivityType x)
									{
										defaultAxisSensitivityType = x;
									};
								}
								dictionary.Add("defaultAxisSensitivityType", new GetSetValue<AxisSensitivityType>(getValueDelegate29, action));
								if (func2 == null)
								{
									func2 = () => force4WayHats;
								}
								Func<bool> getValueDelegate30 = func2;
								if (action2 == null)
								{
									action2 = delegate(bool x)
									{
										force4WayHats = x;
									};
								}
								dictionary.Add("force4WayHats", new GetSetValue<bool>(getValueDelegate30, action2));
								if (func37 == null)
								{
									func37 = () => throttleCalibrationMode;
								}
								Func<ThrottleCalibrationMode> getValueDelegate31 = func37;
								if (action37 == null)
								{
									action37 = delegate(ThrottleCalibrationMode x)
									{
										throttleCalibrationMode = x;
									};
								}
								dictionary.Add("throttleCalibrationMode", new GetSetValue<ThrottleCalibrationMode>(getValueDelegate31, action37));
								if (func38 == null)
								{
									func38 = () => activateActionButtonsOnNegativeValue;
								}
								Func<bool> getValueDelegate32 = func38;
								if (action17 == null)
								{
									action17 = delegate(bool x)
									{
										activateActionButtonsOnNegativeValue = x;
									};
								}
								dictionary.Add("activateActionButtonsOnNegativeValue", new GetSetValue<bool>(getValueDelegate32, action17));
								if (func15 == null)
								{
									func15 = () => deferControllerConnectedEventsOnStart;
								}
								Func<bool> getValueDelegate33 = func15;
								if (action18 == null)
								{
									action18 = delegate(bool x)
									{
										deferControllerConnectedEventsOnStart = x;
									};
								}
								dictionary.Add("deferControllerConnectedEventsOnStart", new GetSetValue<bool>(getValueDelegate33, action18));
								if (func16 == null)
								{
									func16 = () => logLevel;
								}
								Func<LogLevelFlags> getValueDelegate34 = func16;
								if (action21 == null)
								{
									action21 = delegate(LogLevelFlags x)
									{
										logLevel = x;
									};
								}
								dictionary.Add("logLevel", new GetSetValue<LogLevelFlags>(getValueDelegate34, action21));
								if (func18 == null)
								{
									func18 = () => GetPlatformVar_disableKeyboard();
								}
								Func<bool> getValueDelegate35 = func18;
								if (action7 == null)
								{
									action7 = delegate(bool x)
									{
										SetPlatformVar_disableKeyboard(x);
									};
								}
								dictionary.Add("disableKeyboard", new GetSetValue<bool>(getValueDelegate35, action7));
								if (func8 == null)
								{
									func8 = () => GetPlatformVar_ignoreInputWhenAppNotInFocus();
								}
								Func<bool> getValueDelegate36 = func8;
								if (action8 == null)
								{
									action8 = delegate(bool x)
									{
										SetPlatformVar_ignoreInputWhenAppNotInFocus(x);
									};
								}
								dictionary.Add("ignoreInputWhenAppNotInFocus", new GetSetValue<bool>(getValueDelegate36, action8));
								if (func9 == null)
								{
									func9 = () => GetPlatformVar_useEnhancedDeviceSupport();
								}
								Func<bool> getValueDelegate37 = func9;
								if (action9 == null)
								{
									action9 = delegate(bool x)
									{
										SetPlatformVar_useEnhancedDeviceSupport(x);
									};
								}
								dictionary.Add("useEnhancedDeviceSupport", new GetSetValue<bool>(getValueDelegate37, action9));
								if (func10 == null)
								{
									func10 = () => GetPlatformVar_useNativeMouse();
								}
								Func<bool> getValueDelegate38 = func10;
								if (action10 == null)
								{
									action10 = delegate(bool x)
									{
										SetPlatformVar_useNativeMouse(x);
									};
								}
								dictionary.Add("useNativeMouse", new GetSetValue<bool>(getValueDelegate38, action10));
								if (func11 == null)
								{
									func11 = () => GetPlatformVar_useNativeKeyboard();
								}
								dictionary.Add("useNativeKeyboard", new GetSetValue<bool>(func11, delegate(bool x)
								{
									SetPlatformVar_useNativeKeyboard(x);
								}));
								dictionary.Add("joystickRefreshRate", new GetSetValue<int>(() => GetPlatformVar_joystickRefreshRate(), delegate(int x)
								{
									SetPlatformVar_joystickRefreshRate(x);
								}));
								dictionary.Add("assignJoysticksBySystemId", new GetSetValue<bool>(() => GetPlatformVar_assignJoysticksBySystemId(), delegate(bool x)
								{
									SetPlatformVar_assignJoysticksBySystemId(x);
								}));
								__valueDelegates = dictionary;
								num = 16524674;
								continue;
							}
							goto default;
						case 4:
							func39 = null;
							action38 = null;
							num = 16524696;
							continue;
						case 1:
							func37 = null;
							action37 = null;
							func38 = null;
							num = 16524691;
							continue;
						case 6:
							func34 = null;
							action35 = null;
							func35 = null;
							action36 = null;
							func36 = null;
							num = 16524694;
							continue;
						case 12:
							func27 = null;
							action29 = null;
							func28 = null;
							action30 = null;
							func29 = null;
							action31 = null;
							func30 = null;
							action32 = null;
							func31 = null;
							action33 = null;
							func32 = null;
							action34 = null;
							func33 = null;
							num = 16524695;
							continue;
						case 20:
							func24 = null;
							action27 = null;
							func25 = null;
							action28 = null;
							func26 = null;
							num = 16524701;
							continue;
						case 15:
							func23 = null;
							num = 16524677;
							continue;
						case 3:
							action26 = null;
							num = 16524678;
							continue;
						case 8:
							func20 = null;
							action24 = null;
							func21 = null;
							action25 = null;
							func22 = null;
							num = 16524697;
							continue;
						case 10:
							action22 = null;
							func19 = null;
							action23 = null;
							num = 16524699;
							continue;
						case 0:
							action21 = null;
							func18 = null;
							num = 16524679;
							continue;
						case 13:
							action19 = null;
							func17 = null;
							action20 = null;
							num = 16524688;
							continue;
						case 7:
							action17 = null;
							func15 = null;
							action18 = null;
							func16 = null;
							num = 16524692;
							continue;
						case 2:
							action16 = null;
							func14 = null;
							num = 16524689;
							continue;
						case 5:
							action15 = null;
							num = 16524700;
							continue;
						case 17:
							action14 = null;
							num = 16524703;
							continue;
						case 9:
							action11 = null;
							func12 = null;
							action12 = null;
							func13 = null;
							action13 = null;
							num = 16524676;
							continue;
						case 19:
							action7 = null;
							func8 = null;
							action8 = null;
							func9 = null;
							action9 = null;
							func10 = null;
							action10 = null;
							func11 = null;
							num = 16524698;
							continue;
						case 18:
							func7 = null;
							num = 16524702;
							continue;
						case 11:
							func3 = null;
							action3 = null;
							func4 = null;
							action4 = null;
							func5 = null;
							action5 = null;
							func6 = null;
							action6 = null;
							num = 16524672;
							continue;
						case 21:
							action2 = null;
							num = 16524693;
							continue;
						case 16:
							func = null;
							action = null;
							func2 = null;
							num = 16524673;
							continue;
						default:
							return __valueDelegates;
						}
						break;
					}
				}
			}
		}

		[Preserve]
		public ConfigVars()
		{
		}

		internal bool DoesPlatformUseFallback(Platform platform, WebplayerPlatform webplayerPlatform, bool isEditor)
		{
			if (alwaysUseUnityInput)
			{
				return true;
			}
			if (!isEditor && webplayerPlatform != WebplayerPlatform.None)
			{
				return true;
			}
			while (true)
			{
				switch (-668470878 ^ -668470877)
				{
				case 3:
					continue;
				case 1:
					if (platform > Platform.Linux)
					{
						goto case 0;
					}
					switch (platform)
					{
					case Platform.Windows:
						break;
					case Platform.OSX:
						return osx_primaryInputSource == OSXStandalonePrimaryInputSource.Unity;
					case Platform.Linux:
						return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.Unity;
					default:
						goto end_IL_001f;
					}
					goto default;
				case 0:
					switch (platform)
					{
					case Platform.WindowsUWP:
						return windowsUWP_primaryInputSource == WindowsUWPPrimaryInputSource.Unity;
					case Platform.WebGL:
						return webGL_primaryInputSource == WebGLPrimaryInputSource.Unity;
					case Platform.XboxOne:
						return xboxOne_primaryInputSource == XboxOnePrimaryInputSource.Unity;
					case Platform.PS4:
						return ps4_primaryInputSource == PS4PrimaryInputSource.Unity;
					}
					break;
				default:
					{
						return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.Unity;
					}
					end_IL_001f:
					break;
				}
				break;
			}
			return false;
		}

		internal bool DoesPlatformUseSDL2(Platform platform, WebplayerPlatform webplayerPlatform, bool isEditor)
		{
			if (alwaysUseUnityInput)
			{
				return false;
			}
			if (!isEditor && webplayerPlatform != WebplayerPlatform.None)
			{
				goto IL_0010;
			}
			Platform platform2 = platform;
			int num;
			int num2;
			if (platform2 != Platform.Windows)
			{
				num = -1660099899;
				num2 = num;
			}
			else
			{
				num = -1660099898;
				num2 = num;
			}
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -1660099897)
				{
				case 3:
					break;
				case 4:
					return false;
				case 2:
					switch (platform2)
					{
					default:
						goto IL_006c;
					case Platform.OSX:
						return osx_primaryInputSource == OSXStandalonePrimaryInputSource.SDL2;
					case Platform.Linux:
						return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.SDL2;
					case Platform.iOS:
						break;
					}
					goto case 0;
				default:
					return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2;
				case 0:
					return false;
				}
				break;
				IL_006c:
				num = -1660099897;
			}
			goto IL_0010;
			IL_0010:
			num = -1660099901;
			goto IL_0015;
		}

		internal string GetDebugConfigSettings()
		{
			string text = "";
			Platform platform = UnityTools.platform;
			if (platform <= Platform.PS4)
			{
				goto IL_0014;
			}
			goto IL_018d;
			IL_0014:
			int num = 1452615642;
			goto IL_0019;
			IL_0019:
			object[] array12 = default(object[]);
			object obj9 = default(object);
			object[] array11 = default(object[]);
			object obj4 = default(object);
			object[] array10 = default(object[]);
			object obj5 = default(object);
			object[] array3 = default(object[]);
			object obj10 = default(object);
			object[] array = default(object[]);
			object[] array6 = default(object[]);
			object obj6 = default(object);
			object[] array13 = default(object[]);
			object[] array2 = default(object[]);
			object[] array4 = default(object[]);
			object[] array7 = default(object[]);
			object[] array5 = default(object[]);
			object obj = default(object);
			object obj2 = default(object);
			object[] array9 = default(object[]);
			object[] array8 = default(object[]);
			while (true)
			{
				object obj7;
				object obj8;
				switch (num ^ 0x569527D5)
				{
				case 30:
					break;
				case 24:
					array12[0] = obj9;
					num = 1452615643;
					continue;
				case 38:
					array11[2] = linux_primaryInputSource;
					array11[3] = "\n";
					text = string.Concat(array11);
					num = 1452615673;
					continue;
				case 3:
					text = string.Concat(obj4, "Android: Support Unknown Gamepads: ", android_supportUnknownGamepads, "\n");
					num = 1452615644;
					continue;
				case 32:
					array10 = new object[4] { obj5, "Enhanced device support: ", null, null };
					num = 1452615665;
					continue;
				case 33:
					goto IL_018d;
				case 15:
					goto IL_01c0;
				case 49:
					array3 = new object[4] { obj10, "Primary input source: ", stadia_primaryInputSource, "\n" };
					num = 1452615672;
					continue;
				case 21:
					array = new object[4];
					num = 1452615675;
					continue;
				case 1:
					array6[1] = "Use XInput: ";
					array6[2] = useXInput;
					array6[3] = "\n";
					num = 1452615678;
					continue;
				case 35:
					switch (platform)
					{
					case Platform.OSX:
						goto IL_02ec;
					case Platform.XboxOne:
						goto IL_0405;
					case Platform.PS4:
						goto IL_047f;
					case Platform.Linux:
						goto IL_04b2;
					case Platform.iOS:
					case Platform.PS3:
						goto IL_0576;
					}
					num = 1452615631;
					continue;
				case 46:
					array[0] = obj6;
					num = 1452615626;
					continue;
				case 6:
					array13[2] = ps5_primaryInputSource;
					array13[3] = "\n";
					text = string.Concat(array13);
					num = 1452615631;
					continue;
				case 42:
					text = string.Concat(array2);
					num = 1452615621;
					continue;
				case 41:
					text = string.Concat(array4);
					num = 1452615631;
					continue;
				case 16:
					obj5 = text;
					num = 1452615669;
					continue;
				case 8:
					goto IL_02ec;
				case 13:
					goto IL_02f9;
				case 10:
					goto IL_033d;
				case 47:
					num = 1452615631;
					continue;
				case 14:
					array12[1] = "Primary input source: ";
					array12[2] = xboxOne_primaryInputSource;
					array12[3] = "\n";
					text = string.Concat(array12);
					num = 1452615628;
					continue;
				case 18:
					array4[1] = "Primary input source: ";
					array4[2] = gameCoreXboxOne_primaryInputSource;
					num = 1452615619;
					continue;
				case 5:
					array7[3] = "\n";
					text = string.Concat(array7);
					num = 1452615674;
					continue;
				case 7:
					array5 = new object[4] { obj, "Primary input source: ", windowsStandalonePrimaryInputSource, "\n" };
					num = 1452615646;
					continue;
				case 23:
					goto IL_0405;
				case 36:
					array10[2] = GetPlatformVar_useEnhancedDeviceSupport();
					array10[3] = "\n";
					text = string.Concat(array10);
					if (UnityTools.isAndroidPlatform)
					{
						obj4 = text;
						num = 1452615638;
						continue;
					}
					goto default;
				case 4:
				{
					object obj3 = text;
					array6 = new object[4] { obj3, null, null, null };
					num = 1452615636;
					continue;
				}
				case 27:
					array2[3] = "\n";
					num = 1452615679;
					continue;
				case 0:
					goto IL_047f;
				case 40:
					goto IL_04b2;
				case 20:
					array2[0] = obj2;
					num = 1452615671;
					continue;
				case 17:
					array9[3] = "\n";
					text = string.Concat(array9);
					num = 1452615631;
					continue;
				case 2:
					array8[1] = "Primary input source: ";
					array8[2] = webGL_primaryInputSource;
					array8[3] = "\n";
					text = string.Concat(array8);
					num = 1452615631;
					continue;
				case 48:
					array7[2] = windowsUWP_primaryInputSource;
					num = 1452615632;
					continue;
				case 44:
					num = 1452615631;
					continue;
				case 43:
					text = string.Concat(array6);
					num = 1452615631;
					continue;
				case 28:
					goto IL_0569;
				case 26:
					goto IL_0576;
				case 25:
					num = 1452615631;
					continue;
				case 12:
					goto IL_0595;
				case 31:
					array[1] = "Primary input source: ";
					array[2] = osx_primaryInputSource;
					num = 1452615624;
					continue;
				case 11:
					text = string.Concat(array5);
					num = 1452615633;
					continue;
				case 22:
					array4[3] = "\n";
					num = 1452615676;
					continue;
				case 39:
					obj = text;
					num = 1452615634;
					continue;
				case 37:
					goto IL_0602;
				case 45:
					text = string.Concat(array3);
					num = 1452615631;
					continue;
				case 19:
					goto IL_0638;
				case 34:
					array2[1] = "Native mouse handling: ";
					array2[2] = GetPlatformVar_useNativeMouse();
					num = 1452615630;
					continue;
				case 29:
					array[3] = "\n";
					text = string.Concat(array);
					num = 1452615631;
					continue;
				default:
					{
						return text;
					}
					IL_0576:
					obj2 = text;
					array2 = new object[4];
					num = 1452615617;
					continue;
					IL_04b2:
					obj7 = text;
					array11 = new object[4] { obj7, "Primary input source: ", null, null };
					num = 1452615667;
					continue;
					IL_047f:
					obj8 = text;
					array9 = new object[4] { obj8, "Primary input source: ", ps4_primaryInputSource, null };
					num = 1452615620;
					continue;
					IL_0405:
					obj9 = text;
					array12 = new object[4];
					num = 1452615629;
					continue;
					IL_02ec:
					obj6 = text;
					num = 1452615616;
					continue;
				}
				break;
				IL_01c0:
				int num2;
				if (platform != Platform.Windows)
				{
					num = 1452615670;
					num2 = num;
				}
				else
				{
					num = 1452615666;
					num2 = num;
				}
			}
			goto IL_0014;
			IL_0595:
			object obj11 = text;
			array8 = new object[4] { obj11, null, null, null };
			num = 1452615639;
			goto IL_0019;
			IL_02f9:
			object obj12 = text;
			text = string.Concat(obj12, "Primary input source: ", gameCoreScarlett_primaryInputSource, "\n");
			num = 1452615631;
			goto IL_0019;
			IL_0638:
			object obj13 = text;
			array13 = new object[4] { obj13, "Primary input source: ", null, null };
			num = 1452615635;
			goto IL_0019;
			IL_0602:
			object obj14 = text;
			array7 = new object[4] { obj14, "Primary input source: ", null, null };
			num = 1452615653;
			goto IL_0019;
			IL_033d:
			object obj15 = text;
			array4 = new object[4] { obj15, null, null, null };
			num = 1452615623;
			goto IL_0019;
			IL_0569:
			obj10 = text;
			num = 1452615652;
			goto IL_0019;
			IL_018d:
			switch (platform)
			{
			case Platform.GameCoreScarlett:
				goto IL_02f9;
			case Platform.GameCoreXboxOne:
				goto IL_033d;
			case Platform.Stadia:
				goto IL_0569;
			case Platform.WebGL:
				goto IL_0595;
			case Platform.WindowsUWP:
				goto IL_0602;
			case Platform.PS5:
				goto IL_0638;
			}
			num = 1452615631;
			goto IL_0019;
		}

		[CustomObfuscation(rename = false)]
		internal string GetPlatformVarsRelPath(Platform platform)
		{
			if (platformVarsDict.ContainsKey((int)platform))
			{
				return platformVarsDict[(int)platform].NIgOofEOGdZhLyuZEiQpkkLZNku;
			}
			throw new NotImplementedException();
		}

		[CustomObfuscation(rename = false)]
		internal PlatformVars GetPlatformVars(Platform platform)
		{
			if (platformVarsDict.ContainsKey((int)platform))
			{
				goto IL_000e;
			}
			goto IL_0062;
			IL_000e:
			int num = 1716441470;
			goto IL_0013;
			IL_0013:
			PlatformVars platformVars = default(PlatformVars);
			while (true)
			{
				switch (num ^ 0x664ED17A)
				{
				case 3:
					break;
				case 4:
					platformVars = platformVarsDict[(int)platform].txqzmCYXXBQyPUZQzhoGrLngkLv();
					num = 1716441464;
					continue;
				case 2:
					if (platformVars == null)
					{
						platformVars = new PlatformVars();
						num = 1716441467;
						continue;
					}
					goto default;
				case 0:
					goto IL_0062;
				default:
					return platformVars;
				}
				break;
			}
			goto IL_000e;
			IL_0062:
			platformVars = GetOrCreatePlatformVars(ref platformVars_unknown);
			num = 1716441464;
			goto IL_0013;
		}

		[CustomObfuscation(rename = false)]
		internal T Editor_GetAllSerializedPlatformVar<T>(AllPlatformVar var)
		{
			Type typeFromHandle = typeof(T);
			if (object.ReferenceEquals(typeFromHandle, typeof(MultiBoolValue)))
			{
				return (T)(object)GetAllSerializedPlatformVar_multiBool(var);
			}
			throw new NotImplementedException();
		}

		[CustomObfuscation(rename = false)]
		internal void Editor_SetAllSerializedPlatformVar(AllPlatformVar var, object value)
		{
			using (Dictionary<int, tjABoXOQAyjBYeZNxsBenZrHedOF>.Enumerator enumerator = platformVarsDict.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						KeyValuePair<int, tjABoXOQAyjBYeZNxsBenZrHedOF> current = enumerator.Current;
						if (!getSetPlatformVariableDict.ContainsKey((int)var))
						{
							break;
						}
						getSetPlatformVariableDict[(int)var].pZJOBKkDHPLOaaQEqjtZmsFwGSd((Platform)current.Key, value);
						int num = -434499111;
						while (true)
						{
							switch (num ^ -434499109)
							{
							case 0:
								num = -434499110;
								continue;
							case 1:
								break;
							default:
								goto end_IL_002c;
							}
							break;
						}
						continue;
						end_IL_002c:
						break;
					}
				}
			}
		}

		internal bool GetPlatformVar_disableKeyboard()
		{
			return GetPlatformVars().disableKeyboard;
		}

		internal bool SetPlatformVar_disableKeyboard(bool value)
		{
			return GetPlatformVars().disableKeyboard = value;
		}

		internal bool GetPlatformVar_ignoreInputWhenAppNotInFocus()
		{
			return GetPlatformVars().ignoreInputWhenAppNotInFocus;
		}

		internal bool GetPlatformVar_useEnhancedDeviceSupport()
		{
			switch (UnityTools.effectivePlatform)
			{
			case Platform.Windows:
				return useEnhancedDeviceSupport;
			case Platform.OSX:
				return osxStandalone_useEnhancedDeviceSupport;
			default:
				return false;
			}
		}

		internal bool GetPlatformVar_useNativeMouse()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			Platform platform = effectivePlatform;
			while (true)
			{
				int num = 1697967621;
				while (true)
				{
					switch (num ^ 0x6534EE01)
					{
					case 0:
						break;
					case 2:
						return useNativeMouse;
					case 3:
						if (platform == Platform.Stadia)
						{
							if (!(platformVars is PlatformVars_Stadia))
							{
								num = 1697967616;
								continue;
							}
							return (platformVars as PlatformVars_Stadia).useNativeMouse;
						}
						return false;
					case 4:
					{
						int num2;
						if (platform != Platform.Windows)
						{
							num = 1697967618;
							num2 = num;
						}
						else
						{
							num = 1697967619;
							num2 = num;
						}
						continue;
					}
					default:
						return true;
					}
					break;
				}
			}
		}

		internal bool GetPlatformVar_useNativeKeyboard()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				goto IL_0011;
			}
			Platform platform = effectivePlatform;
			int num;
			if (platform != Platform.Windows)
			{
				if (platform == Platform.Stadia)
				{
					if (!(platformVars is PlatformVars_Stadia))
					{
						num = -874115842;
						goto IL_0016;
					}
					return (platformVars as PlatformVars_Stadia).useNativeKeyboard;
				}
				return false;
			}
			goto IL_0049;
			IL_0049:
			if (!(platformVars is PlatformVars_WindowsStandalone))
			{
				return true;
			}
			return (platformVars as PlatformVars_WindowsStandalone).useNativeKeyboard;
			IL_0016:
			switch (num ^ -874115843)
			{
			case 0:
				break;
			case 2:
				return false;
			case 1:
				goto IL_0049;
			default:
				return true;
			}
			goto IL_0011;
			IL_0011:
			num = -874115841;
			goto IL_0016;
		}

		internal int GetPlatformVar_joystickRefreshRate()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return 240;
			}
			Platform platform = effectivePlatform;
			if (platform == Platform.Windows)
			{
				if (!(platformVars is PlatformVars_WindowsStandalone))
				{
					return 240;
				}
				return (platformVars as PlatformVars_WindowsStandalone).joystickRefreshRate;
			}
			return 240;
		}

		internal bool GetPlatformVar_assignJoysticksBySystemId()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = default(PlatformVars);
			Platform platform = default(Platform);
			while (true)
			{
				int num = -1670845722;
				while (true)
				{
					switch (num ^ -1670845721)
					{
					case 4:
						break;
					case 1:
						platformVars = GetPlatformVars(effectivePlatform);
						if (platformVars == null)
						{
							num = -1670845721;
							continue;
						}
						platform = effectivePlatform;
						num = -1670845726;
						continue;
					case 0:
						return false;
					case 2:
						switch (platform)
						{
						case Platform.GameCoreXboxOne:
							if (!(platformVars is PlatformVars_GameCoreXboxOne))
							{
								return false;
							}
							return (platformVars as PlatformVars_GameCoreXboxOne).assignJoysticksByUserId;
						case Platform.GameCoreScarlett:
							if (!(platformVars is PlatformVars_GameCoreScarlett))
							{
								return false;
							}
							return (platformVars as PlatformVars_GameCoreScarlett).assignJoysticksByUserId;
						default:
							return false;
						}
					case 5:
					{
						int num2;
						if (platform != Platform.PS4)
						{
							num = -1670845723;
							num2 = num;
						}
						else
						{
							num = -1670845724;
							num2 = num;
						}
						continue;
					}
					default:
						return ps4_assignJoysticksByPS4JoyId;
					}
					break;
				}
			}
		}

		internal bool SetPlatformVar_ignoreInputWhenAppNotInFocus(bool value)
		{
			if (GetPlatformVars().ignoreInputWhenAppNotInFocus == value)
			{
				return false;
			}
			GetPlatformVars().ignoreInputWhenAppNotInFocus = value;
			return true;
		}

		internal bool SetPlatformVar_useEnhancedDeviceSupport(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			while (true)
			{
				int num = 62396933;
				while (true)
				{
					switch (num ^ 0x3B81A06)
					{
					case 2:
						break;
					case 3:
						switch (effectivePlatform)
						{
						case Platform.Windows:
							break;
						case Platform.OSX:
							if (osxStandalone_useEnhancedDeviceSupport == value)
							{
								goto IL_0058;
							}
							osxStandalone_useEnhancedDeviceSupport = value;
							return true;
						default:
							return false;
						}
						goto case 0;
					case 0:
						if (useEnhancedDeviceSupport == value)
						{
							return false;
						}
						useEnhancedDeviceSupport = value;
						return true;
					default:
						return false;
					}
					break;
					IL_0058:
					num = 62396935;
				}
			}
		}

		internal bool SetPlatformVar_useNativeMouse(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			Platform platform = effectivePlatform;
			while (true)
			{
				int num = 1625392667;
				while (true)
				{
					switch (num ^ 0x60E18619)
					{
					case 0:
						break;
					case 2:
						if (platform == Platform.Windows)
						{
							if (useNativeMouse != value)
							{
								goto IL_0035;
							}
							return false;
						}
						return false;
					default:
						return true;
					}
					break;
					IL_0035:
					useNativeMouse = value;
					num = 1625392664;
				}
			}
		}

		internal bool SetPlatformVar_useNativeKeyboard(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				goto IL_0014;
			}
			Platform platform = effectivePlatform;
			int num;
			if (platform != Platform.Windows)
			{
				if (platform == Platform.Stadia)
				{
					if (!(platformVars is PlatformVars_Stadia))
					{
						goto IL_00ab;
					}
					(platformVars as PlatformVars_Stadia).useNativeKeyboard = value;
					num = -1241546632;
				}
				else
				{
					num = -1241546627;
				}
				goto IL_0019;
			}
			goto IL_0042;
			IL_0019:
			while (true)
			{
				switch (num ^ -1241546626)
				{
				case 4:
					break;
				case 0:
					goto IL_0042;
				case 5:
					return true;
				case 2:
					(platformVars as PlatformVars_WindowsStandalone).useNativeKeyboard = value;
					num = -1241546629;
					continue;
				case 1:
					return false;
				default:
					goto IL_00ab;
				case 3:
					return false;
				}
				break;
			}
			goto IL_0014;
			IL_0014:
			num = -1241546625;
			goto IL_0019;
			IL_0042:
			int num2;
			if (!(platformVars is PlatformVars_WindowsStandalone))
			{
				num = -1241546629;
				num2 = num;
			}
			else
			{
				num = -1241546628;
				num2 = num;
			}
			goto IL_0019;
			IL_00ab:
			return true;
		}

		internal bool SetPlatformVar_joystickRefreshRate(int value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			while (true)
			{
				int num = -1177102217;
				while (true)
				{
					switch (num ^ -1177102219)
					{
					case 3:
						break;
					case 2:
					{
						if (platformVars == null)
						{
							return false;
						}
						Platform platform = effectivePlatform;
						if (platform == Platform.Windows)
						{
							int num2;
							if (platformVars is PlatformVars_WindowsStandalone)
							{
								num = -1177102220;
								num2 = num;
							}
							else
							{
								num = -1177102219;
								num2 = num;
							}
							continue;
						}
						return false;
					}
					case 1:
						(platformVars as PlatformVars_WindowsStandalone).joystickRefreshRate = value;
						num = -1177102219;
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}

		internal bool SetPlatformVar_assignJoysticksBySystemId(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			Platform platform = effectivePlatform;
			while (true)
			{
				int num = -705426947;
				while (true)
				{
					switch (num ^ -705426948)
					{
					case 5:
						break;
					case 1:
						switch (platform)
						{
						default:
							num = -705426945;
							continue;
						case Platform.PS4:
							break;
						case Platform.GameCoreXboxOne:
						{
							int num3;
							if (platformVars is PlatformVars_GameCoreXboxOne)
							{
								num = -705426949;
								num3 = num;
							}
							else
							{
								num = -705426952;
								num3 = num;
							}
							continue;
						}
						case Platform.GameCoreScarlett:
						{
							int num2;
							if (!(platformVars is PlatformVars_GameCoreScarlett))
							{
								num = -705426950;
								num2 = num;
							}
							else
							{
								num = -705426946;
								num2 = num;
							}
							continue;
						}
						}
						goto case 0;
					case 0:
						ps4_assignJoysticksByPS4JoyId = value;
						return true;
					case 4:
						return false;
					case 7:
						(platformVars as PlatformVars_GameCoreXboxOne).assignJoysticksByUserId = value;
						num = -705426952;
						continue;
					case 2:
						(platformVars as PlatformVars_GameCoreScarlett).assignJoysticksByUserId = value;
						num = -705426950;
						continue;
					default:
						return true;
					case 3:
						return false;
					}
					break;
				}
			}
		}

		private PlatformVars GetPlatformVars()
		{
			Platform platform = UnityTools.effectivePlatform;
			if (!UnityTools.isEditor)
			{
				while (true)
				{
					int num = 1838694999;
					while (true)
					{
						switch (num ^ 0x6D984255)
						{
						case 0:
							break;
						case 2:
							if (UnityTools.isAndroidPlatform)
							{
								platform = Platform.Android;
								num = 1838694996;
								continue;
							}
							goto end_IL_000d;
						default:
							goto end_IL_000d;
						}
						break;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			return GetPlatformVars(platform);
		}

		private T GetOrCreatePlatformVars<T>(ref T var) where T : PlatformVars, new()
		{
			if (var == null)
			{
				var = new T();
			}
			return var;
		}

		private MultiBoolValue GetAllSerializedPlatformVar_multiBool(AllPlatformVar var)
		{
			bool flag = false;
			bool flag2 = true;
			using (Dictionary<int, tjABoXOQAyjBYeZNxsBenZrHedOF>.Enumerator enumerator = platformVarsDict.GetEnumerator())
			{
				bool flag3 = default(bool);
				while (enumerator.MoveNext())
				{
					while (true)
					{
						KeyValuePair<int, tjABoXOQAyjBYeZNxsBenZrHedOF> current = enumerator.Current;
						if (!getSetPlatformVariableDict.ContainsKey((int)var))
						{
							break;
						}
						object obj = getSetPlatformVariableDict[(int)var].txqzmCYXXBQyPUZQzhoGrLngkLv((Platform)current.Key);
						if (obj == null)
						{
							break;
						}
						int num;
						int num2;
						if (!object.ReferenceEquals(obj.GetType(), typeof(bool)))
						{
							num = -1827330294;
							num2 = num;
						}
						else
						{
							num = -1827330297;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1827330289)
							{
							case 2:
								num = -1827330292;
								continue;
							case 4:
								if (flag2)
								{
									flag = flag3;
									flag2 = false;
									num = -1827330295;
									continue;
								}
								goto case 0;
							case 0:
								if (flag3 != flag)
								{
									return MultiBoolValue.moPyVkmBZcBICgbWMakXTnRkvTC;
								}
								goto end_IL_008b;
							case 8:
								flag3 = (bool)obj;
								num = -1827330293;
								continue;
							case 1:
								num = -1827330296;
								continue;
							case 3:
								break;
							case 6:
								num = -1827330296;
								continue;
							case 5:
								Logger.LogWarning("Incorrect type. Expecting bool, got " + obj.GetType().Name);
								num = -1827330290;
								continue;
							default:
								goto end_IL_008b;
							}
							break;
						}
						continue;
						end_IL_008b:
						break;
					}
				}
			}
			if (!flag)
			{
				return MultiBoolValue.fgKYpZIlWQCcuLZlzZrhMbbdBDO;
			}
			return MultiBoolValue.ioEDlyORdXqorMJDekPMrPtWpCR;
		}

		internal bool IsEditModeInputSupported(ControllerType controllerType, EditorPlatform editorPlatform)
		{
			if (alwaysUseUnityInput)
			{
				return false;
			}
			EditorPlatform editorPlatform2 = default(EditorPlatform);
			int num;
			if (controllerType != ControllerType.Keyboard)
			{
				if (controllerType == ControllerType.Mouse)
				{
					goto IL_0017;
				}
				if (controllerType == ControllerType.Joystick)
				{
					editorPlatform2 = editorPlatform;
					num = -1491476823;
					goto IL_001c;
				}
				return false;
			}
			goto IL_00b3;
			IL_001c:
			EditorPlatform editorPlatform3 = default(EditorPlatform);
			while (true)
			{
				switch (num ^ -1491476818)
				{
				case 8:
					break;
				case 2:
					goto IL_0058;
				case 4:
					goto IL_0094;
				case 1:
					goto IL_00b3;
				case 6:
					goto IL_00bf;
				case 9:
					goto IL_00df;
				case 0:
					goto IL_00fd;
				case 7:
					goto IL_010a;
				case 3:
					goto IL_012a;
				case 10:
					return useNativeMouse;
				default:
					goto IL_0164;
				}
				break;
				IL_0164:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.XInput)
				{
					return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2;
				}
				goto IL_0178;
				IL_00df:
				return false;
				IL_012a:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
				{
					num = -1491476821;
					continue;
				}
				goto IL_0178;
				IL_0094:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
				{
					if (windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						num = -1491476818;
						continue;
					}
					return false;
				}
				goto IL_00fd;
				IL_010a:
				switch (editorPlatform2)
				{
				case EditorPlatform.Linux:
					break;
				case EditorPlatform.OSX:
					goto IL_006d;
				case EditorPlatform.Windows:
					goto IL_0082;
				default:
					return false;
				}
				goto IL_0058;
				IL_0082:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput)
				{
					num = -1491476819;
					continue;
				}
				goto IL_0178;
				IL_00fd:
				if (controllerType != ControllerType.Keyboard)
				{
					num = -1491476828;
					continue;
				}
				return platformVars_windowsStandalone.useNativeKeyboard;
				IL_0178:
				return true;
				IL_00bf:
				switch (editorPlatform3)
				{
				case EditorPlatform.OSX:
				case EditorPlatform.Linux:
					break;
				case EditorPlatform.Windows:
				{
					int num2;
					if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput)
					{
						num = -1491476822;
						num2 = num;
					}
					else
					{
						num = -1491476818;
						num2 = num;
					}
					continue;
				}
				default:
					return false;
				}
				goto IL_00df;
			}
			goto IL_0017;
			IL_00b3:
			editorPlatform3 = editorPlatform;
			num = -1491476824;
			goto IL_001c;
			IL_006d:
			if (osx_primaryInputSource != OSXStandalonePrimaryInputSource.Native)
			{
				return osx_primaryInputSource == OSXStandalonePrimaryInputSource.SDL2;
			}
			return true;
			IL_0017:
			num = -1491476817;
			goto IL_001c;
			IL_0058:
			if (linux_primaryInputSource != LinuxStandalonePrimaryInputSource.Native)
			{
				return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.SDL2;
			}
			return true;
		}
	}
}
