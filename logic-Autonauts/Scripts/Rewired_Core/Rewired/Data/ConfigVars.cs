using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Attributes;

namespace Rewired.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class ConfigVars
	{
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

		private class AcGFvEkvpoQsDgoXwsttVTGKmVl
		{
			public Func<PlatformVars> WUoTfFaevFhECpvbeQZZpZbjvRW;

			public string kJiARionznWuSLXmTDnsyGjUhvTD;

			public AcGFvEkvpoQsDgoXwsttVTGKmVl(Func<PlatformVars> getDelegate, string dataPath)
			{
				WUoTfFaevFhECpvbeQZZpZbjvRW = getDelegate;
				kJiARionznWuSLXmTDnsyGjUhvTD = dataPath;
			}
		}

		private class HhLtdajfVYczPEHUuoIEJfXZbvC
		{
			public Func<Platform, object> WUoTfFaevFhECpvbeQZZpZbjvRW;

			public Action<Platform, object> EVHAcPCCyXjNdLeltTIIybzjJHO;

			public HhLtdajfVYczPEHUuoIEJfXZbvC(Func<Platform, object> getDelegate, Action<Platform, object> setDelegate)
			{
				WUoTfFaevFhECpvbeQZZpZbjvRW = getDelegate;
				EVHAcPCCyXjNdLeltTIIybzjJHO = setDelegate;
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

		public PS4PrimaryInputSource ps4_primaryInputSource;

		public WebGLPrimaryInputSource webGL_primaryInputSource;

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

		public PlatformVars platformVars_psVita;

		public PlatformVars platformVars_xbox360;

		public PlatformVars platformVars_xboxOne;

		public PlatformVars platformVars_wii;

		public PlatformVars platformVars_wiiu;

		public PlatformVars platformVars_switch;

		public PlatformVars platformVars_webGL;

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

		private Dictionary<int, AcGFvEkvpoQsDgoXwsttVTGKmVl> __platformVarsDict;

		private Dictionary<int, HhLtdajfVYczPEHUuoIEJfXZbvC> __getSetPlatformVariableDict;

		private Dictionary<int, AcGFvEkvpoQsDgoXwsttVTGKmVl> platformVarsDict
		{
			get
			{
				return __platformVarsDict ?? (__platformVarsDict = new Dictionary<int, AcGFvEkvpoQsDgoXwsttVTGKmVl>
				{
					{
						1,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_windowsStandalone), "platformVars_windowsStandalone")
					},
					{
						2,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_windows8Store), "platformVars_windows8Store")
					},
					{
						3,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_windows8Store), "platformVars_windows8Store")
					},
					{
						29,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_windowsUWP), "platformVars_windowsUWP")
					},
					{
						6,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_linuxStandalone), "platformVars_linuxStandalone")
					},
					{
						4,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_osxStandalone), "platformVars_osxStandalone")
					},
					{
						5,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_iOS), "platformVars_iOS")
					},
					{
						28,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_tvOS), "platformVars_tvOS")
					},
					{
						12,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_ps3), "platformVars_ps3")
					},
					{
						13,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_ps4), "platformVars_ps4")
					},
					{
						15,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_psVita), "platformVars_psVita")
					},
					{
						14,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_psVita), "platformVars_psVita")
					},
					{
						16,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_wii), "platformVars_wii")
					},
					{
						18,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_wiiu), "platformVars_wiiu")
					},
					{
						32,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_switch), "platformVars_switch")
					},
					{
						10,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_xbox360), "platformVars_xbox360")
					},
					{
						11,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_xboxOne), "platformVars_xboxOne")
					},
					{
						19,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_webGL), "platformVars_webGL")
					},
					{
						7,
						new AcGFvEkvpoQsDgoXwsttVTGKmVl(() => GetOrCreatePlatformVars(ref platformVars_android), "platformVars_android")
					}
				});
			}
		}

		private Dictionary<int, HhLtdajfVYczPEHUuoIEJfXZbvC> getSetPlatformVariableDict
		{
			get
			{
				return __getSetPlatformVariableDict ?? (__getSetPlatformVariableDict = new Dictionary<int, HhLtdajfVYczPEHUuoIEJfXZbvC>
				{
					{
						0,
						new HhLtdajfVYczPEHUuoIEJfXZbvC((Platform p) => GetPlatformVars(p).disableKeyboard, delegate(Platform platform, object value)
						{
							GetPlatformVars(platform).disableKeyboard = (bool)value;
						})
					},
					{
						1,
						new HhLtdajfVYczPEHUuoIEJfXZbvC((Platform platform) => GetPlatformVars(platform).ignoreInputWhenAppNotInFocus, delegate(Platform platform, object value)
						{
							GetPlatformVars(platform).ignoreInputWhenAppNotInFocus = (bool)value;
						})
					}
				});
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
			if (!isEditor)
			{
				goto IL_000d;
			}
			goto IL_0053;
			IL_0053:
			Platform platform2 = platform;
			int num;
			if (platform2 <= Platform.Linux)
			{
				switch (platform2)
				{
				case Platform.Windows:
					goto IL_00aa;
				case Platform.OSX:
					return osx_primaryInputSource == OSXStandalonePrimaryInputSource.Unity;
				case Platform.Linux:
					return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.Unity;
				case Platform.iOS:
					goto IL_00f7;
				}
				num = 1964680198;
				goto IL_0012;
			}
			goto IL_0086;
			IL_000d:
			num = 1964680192;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x751AA404)
				{
				case 0:
					break;
				case 4:
					goto IL_003b;
				case 1:
					return true;
				case 3:
					if (platform2 != Platform.WindowsUWP)
					{
						goto IL_00f7;
					}
					return windowsUWP_primaryInputSource == WindowsUWPPrimaryInputSource.Unity;
				case 6:
					goto IL_0086;
				default:
					goto IL_00aa;
				case 2:
					goto IL_00f7;
				}
				break;
				IL_003b:
				if (webplayerPlatform != WebplayerPlatform.None)
				{
					num = 1964680197;
					continue;
				}
				goto IL_0053;
			}
			goto IL_000d;
			IL_00f7:
			return false;
			IL_0086:
			switch (platform2)
			{
			case Platform.WebGL:
				return webGL_primaryInputSource == WebGLPrimaryInputSource.Unity;
			case Platform.XboxOne:
				return xboxOne_primaryInputSource == XboxOnePrimaryInputSource.Unity;
			case Platform.PS4:
				return ps4_primaryInputSource == PS4PrimaryInputSource.Unity;
			case Platform.PS3:
				goto IL_00f7;
			}
			num = 1964680199;
			goto IL_0012;
			IL_00aa:
			return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.Unity;
		}

		internal bool DoesPlatformUseSDL2(Platform platform, WebplayerPlatform webplayerPlatform, bool isEditor)
		{
			if (alwaysUseUnityInput)
			{
				return false;
			}
			if (!isEditor && webplayerPlatform != WebplayerPlatform.None)
			{
				return false;
			}
			while (true)
			{
				int num = 436552016;
				while (true)
				{
					switch (num ^ 0x1A054151)
					{
					case 0:
						break;
					case 1:
					{
						int num2;
						if (platform == Platform.Windows)
						{
							num = 436552018;
							num2 = num;
						}
						else
						{
							num = 436552019;
							num2 = num;
						}
						continue;
					}
					case 2:
						switch (platform)
						{
						case Platform.OSX:
							return osx_primaryInputSource == OSXStandalonePrimaryInputSource.SDL2;
						case Platform.Linux:
							return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.SDL2;
						default:
							return false;
						}
					default:
						return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2;
					}
					break;
				}
			}
		}

		internal string GetDebugConfigSettings()
		{
			string text = "";
			Platform platform = UnityTools.platform;
			if (platform <= Platform.Linux)
			{
				switch (platform)
				{
				case Platform.OSX:
					break;
				case Platform.Windows:
					goto IL_0271;
				case Platform.Linux:
					goto IL_02e5;
				default:
					goto IL_031b;
				}
				goto IL_0165;
			}
			goto IL_03eb;
			IL_02e5:
			object obj = text;
			object[] array = new object[4] { obj, "Primary input source: ", null, null };
			int num = -540373146;
			goto IL_0038;
			IL_031b:
			object obj2 = text;
			object[] array2 = new object[4] { obj2, "Native mouse handling: ", null, null };
			num = -540373133;
			goto IL_0038;
			IL_0038:
			object[] array5 = default(object[]);
			object[] array6 = default(object[]);
			object[] array3 = default(object[]);
			object obj7 = default(object);
			object[] array7 = default(object[]);
			object obj4 = default(object);
			object obj5 = default(object);
			object[] array8 = default(object[]);
			object[] array10 = default(object[]);
			object[] array9 = default(object[]);
			object[] array4 = default(object[]);
			object obj6 = default(object);
			while (true)
			{
				switch (num ^ -540373131)
				{
				case 4:
					num = -540373140;
					continue;
				case 2:
				{
					object obj3 = text;
					array5 = new object[4] { obj3, "Primary input source: ", null, null };
					num = -540373122;
					continue;
				}
				case 11:
					array5[2] = windowsUWP_primaryInputSource;
					array5[3] = "\n";
					text = string.Concat(array5);
					num = -540373131;
					continue;
				case 3:
					break;
				case 22:
					array6 = new object[4];
					num = -540373141;
					continue;
				case 12:
					array3[0] = obj7;
					array3[1] = "Android: Support Unknown Gamepads: ";
					num = -540373139;
					continue;
				case 23:
					goto IL_0165;
				case 7:
					text = string.Concat(array7);
					if (UnityTools.isAndroidPlatform)
					{
						obj7 = text;
						num = -540373125;
						continue;
					}
					goto default;
				case 14:
					array3 = new object[4];
					num = -540373127;
					continue;
				case 20:
					goto IL_01b1;
				case 28:
					obj4 = text;
					num = -540373149;
					continue;
				case 1:
					array7[0] = obj5;
					num = -540373123;
					continue;
				case 6:
					array2[2] = GetPlatformVar_useNativeMouse();
					num = -540373142;
					continue;
				case 29:
					text = string.Concat(array8);
					num = -540373131;
					continue;
				case 5:
					array10[2] = xboxOne_primaryInputSource;
					array10[3] = "\n";
					text = string.Concat(array10);
					num = -540373131;
					continue;
				case 17:
					array9[3] = "\n";
					text = string.Concat(array9);
					num = -540373131;
					continue;
				case 26:
					goto IL_0271;
				case 27:
					array8[1] = "Primary input source: ";
					array8[2] = osx_primaryInputSource;
					array8[3] = "\n";
					num = -540373144;
					continue;
				case 9:
					text = string.Concat(array3);
					num = -540373121;
					continue;
				case 21:
					array4 = new object[4] { obj6, "Primary input source: ", windowsStandalonePrimaryInputSource, null };
					num = -540373128;
					continue;
				case 15:
					goto IL_02e5;
				case 18:
					text = string.Concat(array6);
					num = -540373131;
					continue;
				case 0:
					goto IL_031b;
				case 31:
					array2[3] = "\n";
					text = string.Concat(array2);
					obj5 = text;
					array7 = new object[4];
					num = -540373132;
					continue;
				case 19:
					array[2] = linux_primaryInputSource;
					array[3] = "\n";
					text = string.Concat(array);
					num = -540373131;
					continue;
				case 8:
					array7[1] = "Enhanced device support: ";
					array7[2] = useEnhancedDeviceSupport;
					array7[3] = "\n";
					num = -540373134;
					continue;
				case 30:
					array6[0] = obj4;
					array6[1] = "Use XInput: ";
					array6[2] = useXInput;
					array6[3] = "\n";
					num = -540373145;
					continue;
				case 25:
					goto IL_03eb;
				case 16:
					if (platform != Platform.WindowsUWP)
					{
						num = -540373131;
						continue;
					}
					goto case 2;
				case 13:
					array4[3] = "\n";
					text = string.Concat(array4);
					num = -540373143;
					continue;
				case 24:
					array3[2] = android_supportUnknownGamepads;
					array3[3] = "\n";
					num = -540373124;
					continue;
				default:
					return text;
				}
				break;
			}
			goto IL_0116;
			IL_01b1:
			object obj8 = text;
			array9 = new object[4] { obj8, "Primary input source: ", ps4_primaryInputSource, null };
			num = -540373148;
			goto IL_0038;
			IL_03eb:
			switch (platform)
			{
			case Platform.XboxOne:
				break;
			case Platform.PS4:
				goto IL_01b1;
			case Platform.PS3:
				goto IL_031b;
			default:
				goto IL_0400;
			}
			goto IL_0116;
			IL_0400:
			num = -540373147;
			goto IL_0038;
			IL_0271:
			obj6 = text;
			num = -540373152;
			goto IL_0038;
			IL_0116:
			object obj9 = text;
			array10 = new object[4] { obj9, "Primary input source: ", null, null };
			num = -540373136;
			goto IL_0038;
			IL_0165:
			object obj10 = text;
			array8 = new object[4] { obj10, null, null, null };
			num = -540373138;
			goto IL_0038;
		}

		[CustomObfuscation(rename = false)]
		internal string GetPlatformVarsRelPath(Platform platform)
		{
			if (platformVarsDict.ContainsKey((int)platform))
			{
				return platformVarsDict[(int)platform].kJiARionznWuSLXmTDnsyGjUhvTD;
			}
			throw new NotImplementedException();
		}

		[CustomObfuscation(rename = false)]
		internal PlatformVars GetPlatformVars(Platform platform)
		{
			PlatformVars platformVars;
			if (platformVarsDict.ContainsKey((int)platform))
			{
				platformVars = platformVarsDict[(int)platform].WUoTfFaevFhECpvbeQZZpZbjvRW();
				goto IL_0025;
			}
			goto IL_0062;
			IL_0062:
			platformVars = GetOrCreatePlatformVars(ref platformVars_unknown);
			int num = 1182761662;
			goto IL_002a;
			IL_0025:
			num = 1182761657;
			goto IL_002a;
			IL_002a:
			while (true)
			{
				switch (num ^ 0x467F82BD)
				{
				case 2:
					break;
				case 4:
					num = 1182761662;
					continue;
				case 3:
					if (platformVars == null)
					{
						platformVars = new PlatformVars();
						num = 1182761660;
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
			goto IL_0025;
		}

		[CustomObfuscation(rename = false)]
		internal T Editor_GetAllSerializedPlatformVar<T>(AllPlatformVar var)
		{
			Type typeFromHandle = typeof(T);
			while (true)
			{
				int num = 396265629;
				while (true)
				{
					switch (num ^ 0x179E889F)
					{
					case 0:
						break;
					case 2:
						if (object.ReferenceEquals(typeFromHandle, typeof(MultiBoolValue)))
						{
							goto IL_003b;
						}
						throw new NotImplementedException();
					default:
						return (T)(object)GetAllSerializedPlatformVar_multiBool(var);
					}
					break;
					IL_003b:
					num = 396265630;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal void Editor_SetAllSerializedPlatformVar(AllPlatformVar var, object value)
		{
			using (Dictionary<int, AcGFvEkvpoQsDgoXwsttVTGKmVl>.Enumerator enumerator = platformVarsDict.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						KeyValuePair<int, AcGFvEkvpoQsDgoXwsttVTGKmVl> current = enumerator.Current;
						int num;
						int num2;
						if (!getSetPlatformVariableDict.ContainsKey((int)var))
						{
							num = 1934350964;
							num2 = num;
						}
						else
						{
							num = 1934350965;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x734BDA77)
							{
							case 0:
								num = 1934350966;
								continue;
							case 1:
								break;
							case 2:
								getSetPlatformVariableDict[(int)var].EVHAcPCCyXjNdLeltTIIybzjJHO((Platform)current.Key, value);
								num = 1934350964;
								continue;
							default:
								goto end_IL_0030;
							}
							break;
						}
						continue;
						end_IL_0030:
						break;
					}
				}
			}
		}

		internal bool GetPlatformVar_disableKeyboard()
		{
			return GetPlatformVars().disableKeyboard;
		}

		internal bool GetPlatformVar_ignoreInputWhenAppNotInFocus()
		{
			return GetPlatformVars().ignoreInputWhenAppNotInFocus;
		}

		internal bool GetPlatformVar_useEnhancedDeviceSupport()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			Platform platform = effectivePlatform;
			if (platform != Platform.Windows)
			{
				while (true)
				{
					switch (-1848165226 ^ -1848165225)
					{
					case 2:
						continue;
					case 1:
						if (platform == Platform.OSX)
						{
							return osxStandalone_useEnhancedDeviceSupport;
						}
						return false;
					}
					break;
				}
			}
			return useEnhancedDeviceSupport;
		}

		internal bool GetPlatformVar_useNativeMouse()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			Platform platform = effectivePlatform;
			if (platform == Platform.Windows)
			{
				return useNativeMouse;
			}
			return false;
		}

		internal bool GetPlatformVar_useNativeKeyboard()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			Platform platform = effectivePlatform;
			if (platform == Platform.Windows)
			{
				if (!(platformVars is PlatformVars_WindowsStandalone))
				{
					return true;
				}
				return (platformVars as PlatformVars_WindowsStandalone).useNativeKeyboard;
			}
			return false;
		}

		internal int GetPlatformVar_joystickRefreshRate()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = default(PlatformVars);
			Platform platform = default(Platform);
			while (true)
			{
				int num = -1990057377;
				while (true)
				{
					switch (num ^ -1990057379)
					{
					case 4:
						break;
					case 1:
						return 2000;
					case 3:
						if (platformVars != null)
						{
							platform = effectivePlatform;
							num = -1990057379;
						}
						else
						{
							num = -1990057380;
						}
						continue;
					case 2:
						platformVars = GetPlatformVars(effectivePlatform);
						num = -1990057378;
						continue;
					default:
						if (platform == Platform.Windows)
						{
							if (!(platformVars is PlatformVars_WindowsStandalone))
							{
								return 2000;
							}
							return (platformVars as PlatformVars_WindowsStandalone).joystickRefreshRate;
						}
						return 2000;
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
			Platform platform = effectivePlatform;
			if (platform != Platform.Windows)
			{
				goto IL_000c;
			}
			goto IL_003b;
			IL_000c:
			int num = 92584465;
			goto IL_0011;
			IL_0011:
			switch (num ^ 0x584BA10)
			{
			case 2:
				break;
			case 1:
				goto IL_002e;
			case 3:
				goto IL_003b;
			default:
				return true;
			}
			goto IL_000c;
			IL_002e:
			if (platform == Platform.OSX)
			{
				if (osxStandalone_useEnhancedDeviceSupport == value)
				{
					return false;
				}
				osxStandalone_useEnhancedDeviceSupport = value;
				return true;
			}
			return false;
			IL_003b:
			if (useEnhancedDeviceSupport == value)
			{
				return false;
			}
			useEnhancedDeviceSupport = value;
			num = 92584464;
			goto IL_0011;
		}

		internal bool SetPlatformVar_useNativeMouse(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			Platform platform = effectivePlatform;
			if (platform == Platform.Windows)
			{
				if (useNativeMouse == value)
				{
					return false;
				}
				useNativeMouse = value;
				return true;
			}
			return false;
		}

		internal bool SetPlatformVar_useNativeKeyboard(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = default(PlatformVars);
			Platform platform = default(Platform);
			while (true)
			{
				int num = -1504579917;
				while (true)
				{
					switch (num ^ -1504579920)
					{
					case 2:
						break;
					case 3:
						platformVars = GetPlatformVars(effectivePlatform);
						if (platformVars == null)
						{
							num = -1504579920;
							continue;
						}
						platform = effectivePlatform;
						num = -1504579919;
						continue;
					case 1:
						if (platform == Platform.Windows)
						{
							if (platformVars is PlatformVars_WindowsStandalone)
							{
								(platformVars as PlatformVars_WindowsStandalone).useNativeKeyboard = value;
								num = -1504579916;
								continue;
							}
							goto default;
						}
						return false;
					case 0:
						return false;
					default:
						return true;
					}
					break;
				}
			}
		}

		internal bool SetPlatformVar_joystickRefreshRate(int value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			PlatformVars platformVars = default(PlatformVars);
			Platform platform = default(Platform);
			while (true)
			{
				int num = -951162075;
				while (true)
				{
					switch (num ^ -951162074)
					{
					case 5:
						break;
					case 1:
						(platformVars as PlatformVars_WindowsStandalone).joystickRefreshRate = value;
						num = -951162074;
						continue;
					case 2:
						if (platformVars == null)
						{
							return false;
						}
						platform = effectivePlatform;
						num = -951162078;
						continue;
					case 4:
						if (platform == Platform.Windows)
						{
							int num2;
							if (platformVars is PlatformVars_WindowsStandalone)
							{
								num = -951162073;
								num2 = num;
							}
							else
							{
								num = -951162074;
								num2 = num;
							}
							continue;
						}
						return false;
					case 3:
						platformVars = GetPlatformVars(effectivePlatform);
						num = -951162076;
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}

		private PlatformVars GetPlatformVars()
		{
			Platform platform = UnityTools.effectivePlatform;
			if (!UnityTools.isEditor && UnityTools.isAndroidPlatform)
			{
				platform = Platform.Android;
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
			using (Dictionary<int, AcGFvEkvpoQsDgoXwsttVTGKmVl>.Enumerator enumerator = platformVarsDict.GetEnumerator())
			{
				bool flag3 = default(bool);
				MultiBoolValue result = default(MultiBoolValue);
				while (enumerator.MoveNext())
				{
					while (true)
					{
						KeyValuePair<int, AcGFvEkvpoQsDgoXwsttVTGKmVl> current = enumerator.Current;
						if (!getSetPlatformVariableDict.ContainsKey((int)var))
						{
							break;
						}
						object obj = getSetPlatformVariableDict[(int)var].WUoTfFaevFhECpvbeQZZpZbjvRW((Platform)current.Key);
						if (obj == null)
						{
							break;
						}
						int num;
						if (!object.ReferenceEquals(obj.GetType(), typeof(bool)))
						{
							Logger.LogWarning("Incorrect type. Expecting bool, got " + obj.GetType().Name);
							num = -1244787202;
							goto IL_001b;
						}
						goto IL_00fd;
						IL_001b:
						while (true)
						{
							switch (num ^ -1244787202)
							{
							case 2:
								num = -1244787203;
								continue;
							case 3:
								break;
							case 4:
								num = -1244787202;
								continue;
							case 1:
								if (flag3 != flag)
								{
									result = MultiBoolValue.XnRNTxYHgqASLBCxTBHAPqljaEld;
									num = -1244787207;
									continue;
								}
								goto end_IL_004b;
							case 5:
								if (flag2)
								{
									flag = flag3;
									flag2 = false;
									num = -1244787206;
									continue;
								}
								goto case 1;
							case 6:
								goto IL_00fd;
							default:
								goto end_IL_004b;
							case 7:
								return result;
							}
							break;
						}
						continue;
						IL_00fd:
						flag3 = (bool)obj;
						num = -1244787205;
						goto IL_001b;
						continue;
						end_IL_004b:
						break;
					}
				}
			}
			if (!flag)
			{
				return MultiBoolValue.KkYHvIgKzOGVlCiSkUmwNYNguCtr;
			}
			return MultiBoolValue.LnGgshauIRruwnXutHKRlBuLqIy;
		}

		internal bool IsEditModeInputSupported(ControllerType controllerType, EditorPlatform editorPlatform)
		{
			if (alwaysUseUnityInput)
			{
				return false;
			}
			int num;
			if (controllerType != ControllerType.Keyboard)
			{
				if (controllerType == ControllerType.Mouse)
				{
					goto IL_0014;
				}
				if (controllerType == ControllerType.Joystick)
				{
					num = -197172739;
					goto IL_0019;
				}
				return false;
			}
			goto IL_0163;
			IL_0019:
			EditorPlatform editorPlatform2 = default(EditorPlatform);
			while (true)
			{
				switch (num ^ -197172747)
				{
				case 6:
					break;
				case 8:
					goto IL_0059;
				case 5:
					goto IL_0076;
				case 7:
					return false;
				case 11:
					return osx_primaryInputSource == OSXStandalonePrimaryInputSource.SDL2;
				case 10:
					goto IL_00cf;
				case 2:
					goto IL_00f1;
				case 4:
					goto IL_011b;
				case 3:
					goto IL_0139;
				case 1:
					goto IL_0163;
				default:
					goto IL_016f;
				case 9:
					return false;
				}
				break;
				IL_016f:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.XInput)
				{
					return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2;
				}
				goto IL_018c;
				IL_00cf:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.XInput)
				{
					return false;
				}
				num = -197172752;
				continue;
				IL_00ae:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput)
				{
					num = -197172747;
					continue;
				}
				goto IL_018c;
				IL_011b:
				switch (editorPlatform2)
				{
				case EditorPlatform.OSX:
				case EditorPlatform.Linux:
					break;
				case EditorPlatform.Windows:
					goto IL_00f3;
				default:
					goto IL_012f;
				}
				goto IL_00f1;
				IL_012f:
				num = -197172750;
				continue;
				IL_00f3:
				if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput)
				{
					int num2;
					if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
					{
						num = -197172737;
						num2 = num;
					}
					else
					{
						num = -197172752;
						num2 = num;
					}
					continue;
				}
				goto IL_0076;
				IL_018c:
				return true;
				IL_0059:
				switch (editorPlatform)
				{
				case EditorPlatform.Windows:
					goto IL_00ae;
				case EditorPlatform.Linux:
					goto IL_0139;
				case EditorPlatform.OSX:
					goto IL_014e;
				}
				num = -197172740;
				continue;
				IL_014e:
				if (osx_primaryInputSource == OSXStandalonePrimaryInputSource.Native)
				{
					return true;
				}
				num = -197172738;
				continue;
				IL_00f1:
				return false;
			}
			goto IL_0014;
			IL_0163:
			editorPlatform2 = editorPlatform;
			num = -197172751;
			goto IL_0019;
			IL_0076:
			if (controllerType != ControllerType.Keyboard)
			{
				return useNativeMouse;
			}
			return platformVars_windowsStandalone.useNativeKeyboard;
			IL_0014:
			num = -197172748;
			goto IL_0019;
			IL_0139:
			if (linux_primaryInputSource != LinuxStandalonePrimaryInputSource.Native)
			{
				return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.SDL2;
			}
			return true;
		}
	}
}
