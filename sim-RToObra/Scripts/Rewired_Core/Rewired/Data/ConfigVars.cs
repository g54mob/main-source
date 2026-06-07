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

		private class nCQERGUrzcrcyKjDMmlzeJjQfyN
		{
			public Func<PlatformVars> pekIqGKewZQlfVvmIEPZUQHzyKP;

			public string HskGFjQUrrVkhvDfnvNgTepSgyQ;

			public nCQERGUrzcrcyKjDMmlzeJjQfyN(Func<PlatformVars> getDelegate, string dataPath)
			{
				pekIqGKewZQlfVvmIEPZUQHzyKP = getDelegate;
				HskGFjQUrrVkhvDfnvNgTepSgyQ = dataPath;
			}
		}

		private class sPUadDDBOnDoEeXIZkMHqFZyoRC
		{
			public Func<Platform, object> pekIqGKewZQlfVvmIEPZUQHzyKP;

			public Action<Platform, object> pLJrcGqhmHayIxGgHvEIFaxfmKD;

			public sPUadDDBOnDoEeXIZkMHqFZyoRC(Func<Platform, object> getDelegate, Action<Platform, object> setDelegate)
			{
				pekIqGKewZQlfVvmIEPZUQHzyKP = getDelegate;
				pLJrcGqhmHayIxGgHvEIFaxfmKD = setDelegate;
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

		private Dictionary<int, nCQERGUrzcrcyKjDMmlzeJjQfyN> __platformVarsDict;

		private Dictionary<int, sPUadDDBOnDoEeXIZkMHqFZyoRC> __getSetPlatformVariableDict;

		private Dictionary<int, nCQERGUrzcrcyKjDMmlzeJjQfyN> platformVarsDict
		{
			get
			{
				return __platformVarsDict ?? (__platformVarsDict = new Dictionary<int, nCQERGUrzcrcyKjDMmlzeJjQfyN>
				{
					{
						1,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_windowsStandalone), "platformVars_windowsStandalone")
					},
					{
						2,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_windows8Store), "platformVars_windows8Store")
					},
					{
						3,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_windows8Store), "platformVars_windows8Store")
					},
					{
						29,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_windowsUWP), "platformVars_windowsUWP")
					},
					{
						6,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_linuxStandalone), "platformVars_linuxStandalone")
					},
					{
						4,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_osxStandalone), "platformVars_osxStandalone")
					},
					{
						5,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_iOS), "platformVars_iOS")
					},
					{
						28,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_tvOS), "platformVars_tvOS")
					},
					{
						12,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_ps3), "platformVars_ps3")
					},
					{
						13,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_ps4), "platformVars_ps4")
					},
					{
						15,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_psVita), "platformVars_psVita")
					},
					{
						14,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_psVita), "platformVars_psVita")
					},
					{
						16,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_wii), "platformVars_wii")
					},
					{
						18,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_wiiu), "platformVars_wiiu")
					},
					{
						32,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_switch), "platformVars_switch")
					},
					{
						10,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_xbox360), "platformVars_xbox360")
					},
					{
						11,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_xboxOne), "platformVars_xboxOne")
					},
					{
						19,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_webGL), "platformVars_webGL")
					},
					{
						7,
						new nCQERGUrzcrcyKjDMmlzeJjQfyN(() => GetOrCreatePlatformVars(ref platformVars_android), "platformVars_android")
					}
				});
			}
		}

		private Dictionary<int, sPUadDDBOnDoEeXIZkMHqFZyoRC> getSetPlatformVariableDict
		{
			get
			{
				return __getSetPlatformVariableDict ?? (__getSetPlatformVariableDict = new Dictionary<int, sPUadDDBOnDoEeXIZkMHqFZyoRC>
				{
					{
						0,
						new sPUadDDBOnDoEeXIZkMHqFZyoRC((Platform p) => GetPlatformVars(p).disableKeyboard, delegate(Platform platform, object value)
						{
							GetPlatformVars(platform).disableKeyboard = (bool)value;
						})
					},
					{
						1,
						new sPUadDDBOnDoEeXIZkMHqFZyoRC((Platform platform) => GetPlatformVars(platform).ignoreInputWhenAppNotInFocus, delegate(Platform platform, object value)
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
			if (!isEditor && webplayerPlatform != WebplayerPlatform.None)
			{
				goto IL_0016;
			}
			Platform platform2 = platform;
			int num;
			int num2;
			if (platform2 <= Platform.Linux)
			{
				num = 45315419;
				num2 = num;
			}
			else
			{
				num = 45315421;
				num2 = num;
			}
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ 0x2B37559)
				{
				case 3:
					break;
				case 4:
					switch (platform2)
					{
					default:
						num = 45315423;
						continue;
					case Platform.XboxOne:
						return xboxOne_primaryInputSource == XboxOnePrimaryInputSource.Unity;
					case Platform.PS4:
						return ps4_primaryInputSource == PS4PrimaryInputSource.Unity;
					case Platform.PS3:
						break;
					}
					goto IL_010a;
				case 2:
					switch (platform2)
					{
					case Platform.Windows:
						goto IL_00bd;
					case Platform.OSX:
						return osx_primaryInputSource == OSXStandalonePrimaryInputSource.Unity;
					case Platform.Linux:
						return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.Unity;
					case Platform.iOS:
						goto IL_010a;
					}
					num = 45315420;
					continue;
				case 6:
					switch (platform2)
					{
					case Platform.WindowsUWP:
						return windowsUWP_primaryInputSource == WindowsUWPPrimaryInputSource.Unity;
					case Platform.WebGL:
						return webGL_primaryInputSource == WebGLPrimaryInputSource.Unity;
					}
					goto IL_010a;
				case 1:
					return true;
				default:
					goto IL_00bd;
				case 5:
					goto IL_010a;
					IL_00bd:
					return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.Unity;
					IL_010a:
					return false;
				}
				break;
			}
			goto IL_0016;
			IL_0016:
			num = 45315416;
			goto IL_001b;
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
				int num = 978981046;
				while (true)
				{
					switch (num ^ 0x3A5A10B7)
					{
					case 3:
						break;
					case 1:
						switch (platform)
						{
						case Platform.Windows:
							goto IL_005e;
						case Platform.OSX:
							return osx_primaryInputSource == OSXStandalonePrimaryInputSource.SDL2;
						case Platform.Linux:
							return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.SDL2;
						case Platform.iOS:
							goto IL_007f;
						}
						goto IL_004e;
					default:
						goto IL_005e;
					case 2:
						goto IL_007f;
						IL_007f:
						return false;
						IL_005e:
						return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2;
					}
					break;
					IL_004e:
					num = 978981045;
				}
			}
		}

		internal string GetDebugConfigSettings()
		{
			string text = "";
			object[] array9 = default(object[]);
			object[] array = default(object[]);
			object[] array2 = default(object[]);
			Platform platform = default(Platform);
			object[] array10 = default(object[]);
			object obj8 = default(object);
			object[] array6 = default(object[]);
			object[] array4 = default(object[]);
			object obj3 = default(object);
			object[] array7 = default(object[]);
			object[] array3 = default(object[]);
			object[] array8 = default(object[]);
			object obj2 = default(object);
			object[] array5 = default(object[]);
			while (true)
			{
				int num = 314123979;
				while (true)
				{
					int num2;
					object obj5;
					object obj6;
					object obj9;
					object obj10;
					switch (num ^ 0x12B926D8)
					{
					case 3:
						break;
					case 0:
						array9[1] = "Primary input source: ";
						array9[2] = osx_primaryInputSource;
						num = 314123997;
						continue;
					case 9:
						num = 314123987;
						continue;
					case 7:
					{
						array[3] = "\n";
						text = string.Concat(array);
						object obj = text;
						array2 = new object[4] { obj, null, null, null };
						num = 314123986;
						continue;
					}
					case 15:
						switch (platform)
						{
						case Platform.WindowsUWP:
							break;
						default:
							goto IL_0111;
						case Platform.PS4:
							goto IL_0183;
						case Platform.PS3:
							goto IL_0231;
						case Platform.XboxOne:
							goto IL_0335;
						}
						num = 314123973;
						num2 = num;
						continue;
					case 14:
						array10[0] = obj8;
						array10[1] = "Primary input source: ";
						array10[2] = xboxOne_primaryInputSource;
						array10[3] = "\n";
						text = string.Concat(array10);
						num = 314123987;
						continue;
					case 13:
					{
						object obj7 = text;
						array6 = new object[4] { obj7, "Primary input source: ", windowsStandalonePrimaryInputSource, null };
						num = 314123974;
						continue;
					}
					case 28:
						goto IL_0183;
					case 17:
						goto IL_019e;
					case 27:
						array4[0] = obj3;
						num = 314123981;
						continue;
					case 6:
						array7[2] = useXInput;
						num = 314123994;
						continue;
					case 20:
						array2[3] = "\n";
						num = 314123982;
						continue;
					case 26:
						goto IL_01f5;
					case 11:
						goto IL_0231;
					case 2:
						array7[3] = "\n";
						text = string.Concat(array7);
						num = 314123987;
						continue;
					case 5:
						array9[3] = "\n";
						text = string.Concat(array9);
						num = 314123987;
						continue;
					case 18:
						array3[2] = windowsUWP_primaryInputSource;
						num = 314123969;
						continue;
					case 4:
						text = string.Concat(array8);
						num = 314123993;
						continue;
					case 10:
						array2[1] = "Enhanced device support: ";
						array2[2] = useEnhancedDeviceSupport;
						num = 314123980;
						continue;
					case 30:
					{
						array6[3] = "\n";
						text = string.Concat(array6);
						object obj4 = text;
						array7 = new object[4] { obj4, "Use XInput: ", null, null };
						num = 314123998;
						continue;
					}
					case 21:
						array4[1] = "Android: Support Unknown Gamepads: ";
						array4[2] = android_supportUnknownGamepads;
						array4[3] = "\n";
						text = string.Concat(array4);
						num = 314123983;
						continue;
					case 12:
						goto IL_0335;
					case 1:
						num = 314123987;
						continue;
					case 24:
						array3[0] = obj2;
						array3[1] = "Primary input source: ";
						num = 314123978;
						continue;
					case 16:
						array5[1] = "Primary input source: ";
						array5[2] = ps4_primaryInputSource;
						array5[3] = "\n";
						text = string.Concat(array5);
						num = 314123987;
						continue;
					case 8:
						array[1] = "Native mouse handling: ";
						array[2] = GetPlatformVar_useNativeMouse();
						num = 314123999;
						continue;
					case 22:
						text = string.Concat(array2);
						if (UnityTools.isAndroidPlatform)
						{
							obj3 = text;
							array4 = new object[4];
							num = 314123971;
							continue;
						}
						goto default;
					case 25:
						array3[3] = "\n";
						text = string.Concat(array3);
						num = 314123987;
						continue;
					case 29:
						obj2 = text;
						array3 = new object[4];
						num = 314123968;
						continue;
					case 19:
						platform = UnityTools.platform;
						if (platform > Platform.Linux)
						{
							goto case 15;
						}
						switch (platform)
						{
						case Platform.Windows:
							break;
						case Platform.OSX:
							goto IL_019e;
						case Platform.Linux:
							goto IL_01f5;
						case Platform.iOS:
							goto IL_0231;
						default:
							goto IL_043e;
						}
						goto case 13;
					default:
						{
							return text;
						}
						IL_043e:
						num = 314123987;
						continue;
						IL_01f5:
						obj5 = text;
						array8 = new object[4] { obj5, "Primary input source: ", linux_primaryInputSource, "\n" };
						num = 314123996;
						continue;
						IL_019e:
						obj6 = text;
						array9 = new object[4] { obj6, null, null, null };
						num = 314123992;
						continue;
						IL_0335:
						obj8 = text;
						array10 = new object[4];
						num = 314123990;
						continue;
						IL_0231:
						obj9 = text;
						array = new object[4] { obj9, null, null, null };
						num = 314123984;
						continue;
						IL_0183:
						obj10 = text;
						array5 = new object[4] { obj10, null, null, null };
						num = 314123976;
						continue;
						IL_0111:
						num = 314123985;
						num2 = num;
						continue;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string GetPlatformVarsRelPath(Platform platform)
		{
			if (platformVarsDict.ContainsKey((int)platform))
			{
				return platformVarsDict[(int)platform].HskGFjQUrrVkhvDfnvNgTepSgyQ;
			}
			throw new NotImplementedException();
		}

		[CustomObfuscation(rename = false)]
		internal PlatformVars GetPlatformVars(Platform platform)
		{
			if (!platformVarsDict.ContainsKey((int)platform))
			{
				goto IL_0049;
			}
			PlatformVars platformVars = platformVarsDict[(int)platform].pekIqGKewZQlfVvmIEPZUQHzyKP();
			goto IL_005d;
			IL_006d:
			return platformVars;
			IL_005d:
			int num;
			if (platformVars == null)
			{
				platformVars = new PlatformVars();
				num = -1002717284;
				goto IL_002c;
			}
			goto IL_006d;
			IL_0049:
			platformVars = GetOrCreatePlatformVars(ref platformVars_unknown);
			num = -1002717281;
			goto IL_002c;
			IL_002c:
			while (true)
			{
				switch (num ^ -1002717283)
				{
				case 0:
					num = -1002717282;
					continue;
				case 3:
					break;
				case 2:
					goto IL_005d;
				default:
					goto IL_006d;
				}
				break;
			}
			goto IL_0049;
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
			using (Dictionary<int, nCQERGUrzcrcyKjDMmlzeJjQfyN>.Enumerator enumerator = platformVarsDict.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						KeyValuePair<int, nCQERGUrzcrcyKjDMmlzeJjQfyN> current = enumerator.Current;
						if (!getSetPlatformVariableDict.ContainsKey((int)var))
						{
							break;
						}
						getSetPlatformVariableDict[(int)var].pLJrcGqhmHayIxGgHvEIFaxfmKD((Platform)current.Key, value);
						int num = 1106499409;
						while (true)
						{
							switch (num ^ 0x41F3D751)
							{
							case 2:
								num = 1106499408;
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

		internal bool GetPlatformVar_ignoreInputWhenAppNotInFocus()
		{
			return GetPlatformVars().ignoreInputWhenAppNotInFocus;
		}

		internal bool GetPlatformVar_useEnhancedDeviceSupport()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			Platform platform = default(Platform);
			while (true)
			{
				int num = -84291606;
				while (true)
				{
					switch (num ^ -84291605)
					{
					case 2:
						break;
					case 1:
					{
						platform = effectivePlatform;
						int num2;
						if (platform == Platform.Windows)
						{
							num = -84291605;
							num2 = num;
						}
						else
						{
							num = -84291608;
							num2 = num;
						}
						continue;
					}
					case 3:
						if (platform == Platform.OSX)
						{
							return osxStandalone_useEnhancedDeviceSupport;
						}
						return false;
					default:
						return useEnhancedDeviceSupport;
					}
					break;
				}
			}
		}

		internal bool GetPlatformVar_useNativeMouse()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			while (true)
			{
				int num = 2046163417;
				while (true)
				{
					switch (num ^ 0x79F5F9D8)
					{
					case 2:
						break;
					case 1:
					{
						Platform platform = effectivePlatform;
						if (platform == Platform.Windows)
						{
							goto IL_002a;
						}
						return false;
					}
					default:
						return useNativeMouse;
					}
					break;
					IL_002a:
					num = 2046163416;
				}
			}
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
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return 2000;
			}
			Platform platform = effectivePlatform;
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
				int num = 1783269967;
				while (true)
				{
					switch (num ^ 0x6A4A8A4D)
					{
					case 0:
						break;
					case 2:
						switch (effectivePlatform)
						{
						case Platform.Windows:
							break;
						case Platform.OSX:
							if (osxStandalone_useEnhancedDeviceSupport == value)
							{
								return false;
							}
							osxStandalone_useEnhancedDeviceSupport = value;
							return true;
						default:
							return false;
						}
						goto case 1;
					case 1:
						if (useEnhancedDeviceSupport == value)
						{
							goto IL_0044;
						}
						useEnhancedDeviceSupport = value;
						return true;
					default:
						return false;
					}
					break;
					IL_0044:
					num = 1783269966;
				}
			}
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
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			Platform platform = effectivePlatform;
			while (true)
			{
				int num = 103461437;
				while (true)
				{
					switch (num ^ 0x62AB23C)
					{
					case 2:
						break;
					case 1:
						if (platform == Platform.Windows)
						{
							int num2;
							if (!(platformVars is PlatformVars_WindowsStandalone))
							{
								num = 103461436;
								num2 = num;
							}
							else
							{
								num = 103461439;
								num2 = num;
							}
							continue;
						}
						return false;
					case 3:
						(platformVars as PlatformVars_WindowsStandalone).useNativeKeyboard = value;
						num = 103461436;
						continue;
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
			PlatformVars platformVars = GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			Platform platform = effectivePlatform;
			while (true)
			{
				int num = 1342530240;
				while (true)
				{
					switch (num ^ 0x500562C1)
					{
					case 2:
						break;
					case 1:
						if (platform == Platform.Windows)
						{
							if (platformVars is PlatformVars_WindowsStandalone)
							{
								goto IL_003f;
							}
							goto default;
						}
						return false;
					default:
						return true;
					}
					break;
					IL_003f:
					(platformVars as PlatformVars_WindowsStandalone).joystickRefreshRate = value;
					num = 1342530241;
				}
			}
		}

		private PlatformVars GetPlatformVars()
		{
			Platform platform = UnityTools.effectivePlatform;
			while (true)
			{
				int num = -2032996145;
				while (true)
				{
					switch (num ^ -2032996146)
					{
					case 2:
						break;
					case 1:
						if (!UnityTools.isEditor && UnityTools.isAndroidPlatform)
						{
							goto IL_0032;
						}
						goto default;
					default:
						return GetPlatformVars(platform);
					}
					break;
					IL_0032:
					platform = Platform.Android;
					num = -2032996146;
				}
			}
		}

		private T GetOrCreatePlatformVars<T>(ref T var) where T : PlatformVars, new()
		{
			if (var == null)
			{
				while (true)
				{
					int num = -960629210;
					while (true)
					{
						switch (num ^ -960629209)
						{
						case 0:
							break;
						case 1:
							var = new T();
							num = -960629211;
							continue;
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
			return var;
		}

		private MultiBoolValue GetAllSerializedPlatformVar_multiBool(AllPlatformVar var)
		{
			bool flag = false;
			bool flag2 = true;
			using (Dictionary<int, nCQERGUrzcrcyKjDMmlzeJjQfyN>.Enumerator enumerator = platformVarsDict.GetEnumerator())
			{
				bool flag3 = default(bool);
				object obj = default(object);
				KeyValuePair<int, nCQERGUrzcrcyKjDMmlzeJjQfyN> current = default(KeyValuePair<int, nCQERGUrzcrcyKjDMmlzeJjQfyN>);
				while (true)
				{
					IL_013a:
					int num;
					int num2;
					if (!enumerator.MoveNext())
					{
						num = 944967218;
						num2 = num;
					}
					else
					{
						num = 944967219;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x38530E3A)
						{
						case 0:
							num = 944967219;
							continue;
						default:
							goto end_IL_001b;
						case 3:
						{
							int num4;
							if (flag3 != flag)
							{
								num = 944967229;
								num4 = num;
							}
							else
							{
								num = 944967227;
								num4 = num;
							}
							continue;
						}
						case 4:
							num = 944967227;
							continue;
						case 7:
							return MultiBoolValue.mqBeQauQasdvgbqwpzLOmEtlaJug;
						case 5:
							if (obj == null)
							{
								break;
							}
							if (!object.ReferenceEquals(obj.GetType(), typeof(bool)))
							{
								Logger.LogWarning("Incorrect type. Expecting bool, got " + obj.GetType().Name);
								num = 944967227;
								continue;
							}
							goto case 10;
						case 10:
						{
							flag3 = (bool)obj;
							int num3;
							if (flag2)
							{
								num = 944967228;
								num3 = num;
							}
							else
							{
								num = 944967225;
								num3 = num;
							}
							continue;
						}
						case 6:
							flag = flag3;
							flag2 = false;
							num = 944967230;
							continue;
						case 9:
							current = enumerator.Current;
							num = 944967224;
							continue;
						case 2:
							if (getSetPlatformVariableDict.ContainsKey((int)var))
							{
								obj = getSetPlatformVariableDict[(int)var].pekIqGKewZQlfVvmIEPZUQHzyKP((Platform)current.Key);
								num = 944967231;
								continue;
							}
							break;
						case 1:
							break;
						case 8:
							goto end_IL_001b;
						}
						goto IL_013a;
						continue;
						end_IL_001b:
						break;
					}
					break;
				}
			}
			if (!flag)
			{
				return MultiBoolValue.ztWMoVOElQhqQdOXUUkwdpRgLNcE;
			}
			return MultiBoolValue.urElrcGQURaMVXYdJRHXARJLPhf;
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
					goto IL_0017;
				}
				if (controllerType == ControllerType.Joystick)
				{
					num = 210088262;
					goto IL_001c;
				}
				return false;
			}
			goto IL_00d8;
			IL_008c:
			if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
			{
				if (windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
				{
					num = 210088263;
					goto IL_001c;
				}
				return false;
			}
			goto IL_0080;
			IL_00ee:
			num = 210088258;
			goto IL_001c;
			IL_0080:
			if (controllerType != ControllerType.Keyboard)
			{
				num = 210088256;
				goto IL_001c;
			}
			return platformVars_windowsStandalone.useNativeKeyboard;
			IL_008a:
			return false;
			IL_0050:
			if (linux_primaryInputSource != LinuxStandalonePrimaryInputSource.Native)
			{
				return linux_primaryInputSource == LinuxStandalonePrimaryInputSource.SDL2;
			}
			return true;
			IL_0017:
			num = 210088257;
			goto IL_001c;
			IL_001c:
			while (true)
			{
				switch (num ^ 0xC85B140)
				{
				case 4:
					break;
				case 5:
					goto IL_0050;
				case 7:
					goto IL_0080;
				case 3:
					goto IL_008a;
				case 0:
					return useNativeMouse;
				case 2:
					return false;
				case 1:
					goto IL_00d8;
				case 6:
					goto IL_00f8;
				default:
					return osx_primaryInputSource == OSXStandalonePrimaryInputSource.SDL2;
				}
				break;
				IL_00f8:
				switch (editorPlatform)
				{
				case EditorPlatform.Linux:
					break;
				case EditorPlatform.OSX:
					if (osx_primaryInputSource != OSXStandalonePrimaryInputSource.Native)
					{
						goto IL_0070;
					}
					return true;
				case EditorPlatform.Windows:
					if (windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.XInput)
					{
						return windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2;
					}
					return true;
				default:
					return false;
				}
				goto IL_0050;
				IL_0070:
				num = 210088264;
			}
			goto IL_0017;
			IL_00d8:
			switch (editorPlatform)
			{
			case EditorPlatform.OSX:
			case EditorPlatform.Linux:
				break;
			case EditorPlatform.Windows:
				goto IL_008c;
			default:
				goto IL_00ee;
			}
			goto IL_008a;
		}
	}
}
