using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputManagers;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.XboxOne;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired
{
	public static class ReInput
	{
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class LocalizationHelper : CodeHelper
		{
			private static LocalizationHelper kcjfdeNsQavhKEvPqfezWhwCqEzW;

			internal static LocalizationHelper RaOKdggSpezUHRbHLFjFysmKfXXcA => kcjfdeNsQavhKEvPqfezWhwCqEzW ?? (kcjfdeNsQavhKEvPqfezWhwCqEzW = new LocalizationHelper());

			public ILocalizedStringProvider localizedStringProvider
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return LocalizationManager.localizedStringProvider;
				}
				set
				{
					if (CheckInitialized())
					{
						LocalizationManager.localizedStringProvider = value;
					}
				}
			}

			public bool prefetch
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return LocalizationManager.autoPrefetch;
				}
				set
				{
					if (CheckInitialized())
					{
						LocalizationManager.autoPrefetch = value;
					}
				}
			}

			private LocalizationHelper()
			{
			}

			internal static void rZBUVCfrIEcVzzpTyVupkAhKFpoC()
			{
				kcjfdeNsQavhKEvPqfezWhwCqEzW = null;
			}

			public void Reload()
			{
				if (CheckInitialized())
				{
					LocalizationManager.Reload();
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class GlyphHelper : CodeHelper
		{
			private static GlyphHelper gozfNtcQCstiypzPRzwGQwYwPJCv;

			internal static GlyphHelper ZkOVjyrdIntYibtsakrmtlRYpuOE => gozfNtcQCstiypzPRzwGQwYwPJCv ?? (gozfNtcQCstiypzPRzwGQwYwPJCv = new GlyphHelper());

			public IGlyphProvider glyphProvider
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return GlyphManager.glyphProvider;
				}
				set
				{
					if (CheckInitialized())
					{
						GlyphManager.glyphProvider = value;
					}
				}
			}

			public bool prefetch
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return GlyphManager.autoPrefetch;
				}
				set
				{
					if (CheckInitialized())
					{
						GlyphManager.autoPrefetch = value;
					}
				}
			}

			private GlyphHelper()
			{
			}

			internal static void BnutHAbnGiDvzByQQVjlGQVdDwWRA()
			{
				gozfNtcQCstiypzPRzwGQwYwPJCv = null;
			}

			public void Reload()
			{
				if (CheckInitialized())
				{
					GlyphManager.Reload();
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper wiHWkYLzhwHMxCxXnsGCmnOcJhDp;

			private float DcQeceajGgkqLEDhhYMgrAHGwQvV = 0.7f;

			private float DmyZbLSUUMRlZuWgGShVCheBYdwQ = 100f;

			internal static ConfigHelper JzRhjhFNqXeaQeZlnrIEtiRNfrkg => wiHWkYLzhwHMxCxXnsGCmnOcJhDp ?? (wiHWkYLzhwHMxCxXnsGCmnOcJhDp = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.useXInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						windowsUWPSupportGamepads = value;
					}
					else
					{
						if (MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.useXInput == value)
						{
							return;
						}
						if (value)
						{
							if (MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								Logger.LogWarning("XInput cannot be enabled with the current primary input source: " + MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("XInput cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.useXInput = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public bool useWindowsGamingInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_useWindowsGamingInput();
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						windowsUWPSupportGamepads = value;
					}
					else
					{
						if (MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_useWindowsGamingInput() == value)
						{
							return;
						}
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.SetPlatformVar_useWindowsGamingInput(value);
						if (value)
						{
							if (MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
							{
								Logger.LogWarning("Windows Gaming Input cannot be enabled with the current primary input source: " + MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("Windows Gaming Input cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public UpdateMode updateMode
			{
				get
				{
					if (!CheckInitialized())
					{
						return UpdateMode.Automatic;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.updateMode;
				}
				set
				{
					if (CheckInitialized() && value != MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.updateMode)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.updateMode = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public UpdateLoopSetting updateLoop
			{
				get
				{
					if (!CheckInitialized())
					{
						return UpdateLoopSetting.Update;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.updateLoop = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public WindowsStandalonePrimaryInputSource windowsStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WindowsStandalonePrimaryInputSource.RawInput;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.effectivePlatform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.useXInput = true;
						}
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public OSXStandalonePrimaryInputSource osxStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return OSXStandalonePrimaryInputSource.Native;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.osx_primaryInputSource != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.osx_primaryInputSource = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public LinuxStandalonePrimaryInputSource linuxStandalonePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return LinuxStandalonePrimaryInputSource.Native;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.linux_primaryInputSource != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.linux_primaryInputSource = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public WindowsUWPPrimaryInputSource windowsUWPPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WindowsUWPPrimaryInputSource.Native;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.windowsUWP_primaryInputSource = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public bool windowsUWPSupportHIDDevices
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return (MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public bool windowsUWPSupportGamepads
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return (MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useGamepadAPI != value)
					{
						platformVars_WindowsUWP.useGamepadAPI = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public bool useAppleGameControllerFramework
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.OSX && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.osx_primaryInputSource == OSXStandalonePrimaryInputSource.GameController)
					{
						return true;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_useAppleGameController();
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_useAppleGameController() != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.SetPlatformVar_useAppleGameController(value);
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public XboxOnePrimaryInputSource xboxOnePrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return XboxOnePrimaryInputSource.Native;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.xboxOne_primaryInputSource != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.xboxOne_primaryInputSource = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public PS4PrimaryInputSource ps4PrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return PS4PrimaryInputSource.PS4Input;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.ps4_primaryInputSource != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.ps4_primaryInputSource = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public WebGLPrimaryInputSource webGLPrimaryInputSource
			{
				get
				{
					if (!CheckInitialized())
					{
						return WebGLPrimaryInputSource.Native;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.webGL_primaryInputSource != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.webGL_primaryInputSource = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public bool alwaysUseUnityInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.alwaysUseUnityInput != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.alwaysUseUnityInput = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public bool disableNativeInput
			{
				get
				{
					return alwaysUseUnityInput;
				}
				set
				{
					alwaysUseUnityInput = value;
				}
			}

			public bool nativeMouseSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.SetPlatformVar_useNativeMouse(value) && KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
					{
						KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
					}
				}
			}

			public bool nativeKeyboardSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
					{
						KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
					}
				}
			}

			public bool enhancedDeviceSupport
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
					{
						KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
					}
				}
			}

			public int joystickRefreshRate
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_joystickRefreshRate();
				}
				set
				{
					if (CheckInitialized())
					{
						value = MathTools.Clamp(value, 0, 2000);
						if (value == 0)
						{
							value = 240;
						}
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
					}
				}
			}

			public bool ignoreInputWhenAppNotInFocus
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						OaypaBirBVUgrVVjLMIxBDfRWHnX();
					}
				}
			}

			public bool android_supportUnknownGamepads
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.android_supportUnknownGamepads != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.android_supportUnknownGamepads = value;
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			public DeadZone2DType defaultJoystickAxis2DDeadZoneType
			{
				get
				{
					if (!CheckInitialized())
					{
						return DeadZone2DType.Radial;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
					}
				}
			}

			public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType
			{
				get
				{
					if (!CheckInitialized())
					{
						return AxisSensitivity2DType.Radial;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
					}
				}
			}

			public AxisSensitivityType defaultAxisSensitivityType
			{
				get
				{
					if (!CheckInitialized())
					{
						return AxisSensitivityType.Multiplier;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.defaultAxisSensitivityType != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.defaultAxisSensitivityType = value;
					}
				}
			}

			public bool force4WayHats
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.force4WayHats != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.force4WayHats = value;
					}
				}
			}

			public float defaultAbsoluteAxisPollingDeadZone
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0.7f;
					}
					return DcQeceajGgkqLEDhhYMgrAHGwQvV;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (DcQeceajGgkqLEDhhYMgrAHGwQvV != value)
						{
							DcQeceajGgkqLEDhhYMgrAHGwQvV = value;
						}
					}
				}
			}

			public float defaultRelativeAxisPollingDeadZone
			{
				get
				{
					if (!CheckInitialized())
					{
						return 100f;
					}
					return DmyZbLSUUMRlZuWgGShVCheBYdwQ;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (DmyZbLSUUMRlZuWgGShVCheBYdwQ != value)
						{
							DmyZbLSUUMRlZuWgGShVCheBYdwQ = value;
						}
					}
				}
			}

			public bool activateActionButtonsOnNegativeValue
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.activateActionButtonsOnNegativeValue = value;
					}
				}
			}

			public ThrottleCalibrationMode throttleCalibrationMode
			{
				get
				{
					if (!CheckInitialized())
					{
						return ThrottleCalibrationMode.ZeroToOne;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.throttleCalibrationMode != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.throttleCalibrationMode = value;
						zEtuNvknIQbzOpsTCdeQeEswlwDw.NaVlNYHFiohEAIeTAvHsQMkEwmZUA(value);
					}
				}
			}

			public bool deferControllerConnectedEventsOnStart
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.deferControllerConnectedEventsOnStart = value;
					}
				}
			}

			public KeyCombinationOverrideMode keyCombinationOverrideMode
			{
				get
				{
					if (!CheckInitialized())
					{
						return KeyCombinationOverrideMode.Cancel;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.keyCombinationOverrideMode;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.keyCombinationOverrideMode != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.keyCombinationOverrideMode = value;
					}
				}
			}

			public bool generateKeyEventsOnKeyCombinationOverride
			{
				get
				{
					if (!CheckInitialized())
					{
						return true;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.generateKeyEventsOnKeyCombinationOverride;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.generateKeyEventsOnKeyCombinationOverride != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.generateKeyEventsOnKeyCombinationOverride = value;
					}
				}
			}

			public bool autoAssignJoysticks
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.autoAssignJoysticks != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.autoAssignJoysticks = value;
					}
				}
			}

			public int maxJoysticksPerPlayer
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.maxJoysticksPerPlayer != value)
						{
							MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.maxJoysticksPerPlayer = value;
						}
					}
				}
			}

			public bool distributeJoysticksEvenly
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.distributeJoysticksEvenly != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.distributeJoysticksEvenly = value;
					}
				}
			}

			public bool assignJoysticksToPlayingPlayersOnly
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
					}
				}
			}

			public bool reassignJoystickToPreviousOwnerOnReconnect
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
					}
				}
			}

			public LogLevelFlags logLevel
			{
				get
				{
					if (!CheckInitialized())
					{
						return LogLevelFlags.Off;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.logLevel != value)
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.logLevel = value;
					}
				}
			}

			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes
			{
				get
				{
					if (!CheckInitialized())
					{
						return new List<EnhancedDeviceSupportDeviceType>();
					}
					return new List<EnhancedDeviceSupportDeviceType>(MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes());
				}
				set
				{
					if (CheckInitialized())
					{
						MxboHOxlsDLTuNkINIYZaIjEdbFxA.ConfigVars.SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(value);
						if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
						{
							KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
						}
					}
				}
			}

			private ConfigHelper()
			{
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class ControllerHelper : CodeHelper
		{
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class lmyssPfgJPfavIteDsVZmDBogyGAb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int UWsVQFmCPBOOUOQpdwQnKQdYKGwq;

					private ControllerPollingInfo cRbCoSkVqyCcHZkYjNZPPgcbboES;

					private int UsXVaaDXXLoMQedJRAIsbKqhFguf;

					public PollingHelper POjQlOqQdtjzwGvkqrMAOxJcCfsJ;

					private IEnumerator<ControllerPollingInfo> jcMPtMrJghAhwNvetMiXTWPiKuax;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return cRbCoSkVqyCcHZkYjNZPPgcbboES;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return cRbCoSkVqyCcHZkYjNZPPgcbboES;
						}
					}

					[DebuggerHidden]
					public lmyssPfgJPfavIteDsVZmDBogyGAb(int P_0)
					{
						UWsVQFmCPBOOUOQpdwQnKQdYKGwq = P_0;
						UsXVaaDXXLoMQedJRAIsbKqhFguf = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (UWsVQFmCPBOOUOQpdwQnKQdYKGwq)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								ioDuuiMzPmFbPhIBRfSxpqFmgqVJA();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								UMfAIUitEVlyQHNJUgQcAFtBMuOcb();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								DbhWdJzPwKtuzCOcfaSVExzvTRSt();
							}
						case -2:
						case -1:
						case 0:
							break;
						}
					}

					private bool MoveNext()
					{
						try
						{
							int uWsVQFmCPBOOUOQpdwQnKQdYKGwq = UWsVQFmCPBOOUOQpdwQnKQdYKGwq;
							PollingHelper pOjQlOqQdtjzwGvkqrMAOxJcCfsJ = POjQlOqQdtjzwGvkqrMAOxJcCfsJ;
							switch (uWsVQFmCPBOOUOQpdwQnKQdYKGwq)
							{
							default:
								return false;
							case 0:
								UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								jcMPtMrJghAhwNvetMiXTWPiKuax = pOjQlOqQdtjzwGvkqrMAOxJcCfsJ.peBRgicahMCGbDnqGbTnOpTblIDN().GetEnumerator();
								UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -3;
								goto IL_0084;
							case 1:
								UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -3;
								goto IL_0084;
							case 2:
								UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -4;
								goto IL_00e4;
							case 3:
								{
									UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -5;
									break;
								}
								IL_00e4:
								if (jcMPtMrJghAhwNvetMiXTWPiKuax.MoveNext())
								{
									ControllerPollingInfo current = jcMPtMrJghAhwNvetMiXTWPiKuax.Current;
									cRbCoSkVqyCcHZkYjNZPPgcbboES = current;
									UWsVQFmCPBOOUOQpdwQnKQdYKGwq = 2;
									return true;
								}
								UMfAIUitEVlyQHNJUgQcAFtBMuOcb();
								jcMPtMrJghAhwNvetMiXTWPiKuax = null;
								jcMPtMrJghAhwNvetMiXTWPiKuax = pOjQlOqQdtjzwGvkqrMAOxJcCfsJ.bOgqPlHGPshmgaKACaGQvAmEodEl().GetEnumerator();
								UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -5;
								break;
								IL_0084:
								if (jcMPtMrJghAhwNvetMiXTWPiKuax.MoveNext())
								{
									ControllerPollingInfo current2 = jcMPtMrJghAhwNvetMiXTWPiKuax.Current;
									cRbCoSkVqyCcHZkYjNZPPgcbboES = current2;
									UWsVQFmCPBOOUOQpdwQnKQdYKGwq = 1;
									return true;
								}
								ioDuuiMzPmFbPhIBRfSxpqFmgqVJA();
								jcMPtMrJghAhwNvetMiXTWPiKuax = null;
								jcMPtMrJghAhwNvetMiXTWPiKuax = pOjQlOqQdtjzwGvkqrMAOxJcCfsJ.dlYdYUFddiqtVkTarROIzJPNnFNC().GetEnumerator();
								UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -4;
								goto IL_00e4;
							}
							if (jcMPtMrJghAhwNvetMiXTWPiKuax.MoveNext())
							{
								ControllerPollingInfo current3 = jcMPtMrJghAhwNvetMiXTWPiKuax.Current;
								cRbCoSkVqyCcHZkYjNZPPgcbboES = current3;
								UWsVQFmCPBOOUOQpdwQnKQdYKGwq = 3;
								return true;
							}
							DbhWdJzPwKtuzCOcfaSVExzvTRSt();
							jcMPtMrJghAhwNvetMiXTWPiKuax = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ioDuuiMzPmFbPhIBRfSxpqFmgqVJA()
					{
						UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -1;
						if (jcMPtMrJghAhwNvetMiXTWPiKuax != null)
						{
							jcMPtMrJghAhwNvetMiXTWPiKuax.Dispose();
						}
					}

					private void UMfAIUitEVlyQHNJUgQcAFtBMuOcb()
					{
						UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -1;
						if (jcMPtMrJghAhwNvetMiXTWPiKuax != null)
						{
							jcMPtMrJghAhwNvetMiXTWPiKuax.Dispose();
						}
					}

					private void DbhWdJzPwKtuzCOcfaSVExzvTRSt()
					{
						UWsVQFmCPBOOUOQpdwQnKQdYKGwq = -1;
						if (jcMPtMrJghAhwNvetMiXTWPiKuax != null)
						{
							jcMPtMrJghAhwNvetMiXTWPiKuax.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						lmyssPfgJPfavIteDsVZmDBogyGAb lmyssPfgJPfavIteDsVZmDBogyGAb2;
						if (UWsVQFmCPBOOUOQpdwQnKQdYKGwq == -2 && UsXVaaDXXLoMQedJRAIsbKqhFguf == Environment.CurrentManagedThreadId)
						{
							UWsVQFmCPBOOUOQpdwQnKQdYKGwq = 0;
							lmyssPfgJPfavIteDsVZmDBogyGAb2 = this;
						}
						else
						{
							lmyssPfgJPfavIteDsVZmDBogyGAb2 = new lmyssPfgJPfavIteDsVZmDBogyGAb(0);
							lmyssPfgJPfavIteDsVZmDBogyGAb2.POjQlOqQdtjzwGvkqrMAOxJcCfsJ = POjQlOqQdtjzwGvkqrMAOxJcCfsJ;
						}
						return lmyssPfgJPfavIteDsVZmDBogyGAb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class JcBofUKjAOcDUFjVUneIFgtnNJhy : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int HvxGJdbBcpBoVAGGOkiqqgkhvykcA;

					private ControllerPollingInfo WdDAstbwMmRndbJeErZvenJVimkEA;

					private int LNRBvVpEPhRCwfZfCPfAZWjncLKw;

					public PollingHelper UBJDxHdMlrmfrSjyTrcRbOQdOEPsA;

					private IEnumerator<ControllerPollingInfo> jzBbCWcjsoWbucDWQOaoVKWHBWEZ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WdDAstbwMmRndbJeErZvenJVimkEA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WdDAstbwMmRndbJeErZvenJVimkEA;
						}
					}

					[DebuggerHidden]
					public JcBofUKjAOcDUFjVUneIFgtnNJhy(int P_0)
					{
						HvxGJdbBcpBoVAGGOkiqqgkhvykcA = P_0;
						LNRBvVpEPhRCwfZfCPfAZWjncLKw = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (HvxGJdbBcpBoVAGGOkiqqgkhvykcA)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								yZxxlsFEFkDNyDKhnYIPeUougQDDA();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								GicgzFcKgwuEAtdJiHIjkUkBkBeP();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								DwXeyiveChKFywHObTWCCCASlivi();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								ZnccruANNvUJEUefIACbKTPzNMdy();
							}
						case -2:
						case -1:
						case 0:
							break;
						}
					}

					private bool MoveNext()
					{
						try
						{
							int hvxGJdbBcpBoVAGGOkiqqgkhvykcA = HvxGJdbBcpBoVAGGOkiqqgkhvykcA;
							PollingHelper uBJDxHdMlrmfrSjyTrcRbOQdOEPsA = UBJDxHdMlrmfrSjyTrcRbOQdOEPsA;
							switch (hvxGJdbBcpBoVAGGOkiqqgkhvykcA)
							{
							default:
								return false;
							case 0:
								HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								jzBbCWcjsoWbucDWQOaoVKWHBWEZ = uBJDxHdMlrmfrSjyTrcRbOQdOEPsA.LBWmmyVFOTZHLxLQYZaMkxUpPhYG().GetEnumerator();
								HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -3;
								goto IL_0088;
							case 1:
								HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -3;
								goto IL_0088;
							case 2:
								HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -4;
								goto IL_00e8;
							case 3:
								HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -5;
								goto IL_0148;
							case 4:
								{
									HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -6;
									break;
								}
								IL_00e8:
								if (jzBbCWcjsoWbucDWQOaoVKWHBWEZ.MoveNext())
								{
									ControllerPollingInfo current = jzBbCWcjsoWbucDWQOaoVKWHBWEZ.Current;
									WdDAstbwMmRndbJeErZvenJVimkEA = current;
									HvxGJdbBcpBoVAGGOkiqqgkhvykcA = 2;
									return true;
								}
								GicgzFcKgwuEAtdJiHIjkUkBkBeP();
								jzBbCWcjsoWbucDWQOaoVKWHBWEZ = null;
								jzBbCWcjsoWbucDWQOaoVKWHBWEZ = uBJDxHdMlrmfrSjyTrcRbOQdOEPsA.QKnENIYfMsHldhNrxQIuJGCyUxgQA().GetEnumerator();
								HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -5;
								goto IL_0148;
								IL_0088:
								if (jzBbCWcjsoWbucDWQOaoVKWHBWEZ.MoveNext())
								{
									ControllerPollingInfo current2 = jzBbCWcjsoWbucDWQOaoVKWHBWEZ.Current;
									WdDAstbwMmRndbJeErZvenJVimkEA = current2;
									HvxGJdbBcpBoVAGGOkiqqgkhvykcA = 1;
									return true;
								}
								yZxxlsFEFkDNyDKhnYIPeUougQDDA();
								jzBbCWcjsoWbucDWQOaoVKWHBWEZ = null;
								jzBbCWcjsoWbucDWQOaoVKWHBWEZ = uBJDxHdMlrmfrSjyTrcRbOQdOEPsA.cwrYXfBTckFFSzJCtBjHgvXCqLUBb().GetEnumerator();
								HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -4;
								goto IL_00e8;
								IL_0148:
								if (jzBbCWcjsoWbucDWQOaoVKWHBWEZ.MoveNext())
								{
									ControllerPollingInfo current3 = jzBbCWcjsoWbucDWQOaoVKWHBWEZ.Current;
									WdDAstbwMmRndbJeErZvenJVimkEA = current3;
									HvxGJdbBcpBoVAGGOkiqqgkhvykcA = 3;
									return true;
								}
								DwXeyiveChKFywHObTWCCCASlivi();
								jzBbCWcjsoWbucDWQOaoVKWHBWEZ = null;
								jzBbCWcjsoWbucDWQOaoVKWHBWEZ = uBJDxHdMlrmfrSjyTrcRbOQdOEPsA.PDxhcMFNZRgyLnulfhjhSatuIaEbb().GetEnumerator();
								HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -6;
								break;
							}
							if (jzBbCWcjsoWbucDWQOaoVKWHBWEZ.MoveNext())
							{
								ControllerPollingInfo current4 = jzBbCWcjsoWbucDWQOaoVKWHBWEZ.Current;
								WdDAstbwMmRndbJeErZvenJVimkEA = current4;
								HvxGJdbBcpBoVAGGOkiqqgkhvykcA = 4;
								return true;
							}
							ZnccruANNvUJEUefIACbKTPzNMdy();
							jzBbCWcjsoWbucDWQOaoVKWHBWEZ = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void yZxxlsFEFkDNyDKhnYIPeUougQDDA()
					{
						HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -1;
						if (jzBbCWcjsoWbucDWQOaoVKWHBWEZ != null)
						{
							jzBbCWcjsoWbucDWQOaoVKWHBWEZ.Dispose();
						}
					}

					private void GicgzFcKgwuEAtdJiHIjkUkBkBeP()
					{
						HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -1;
						if (jzBbCWcjsoWbucDWQOaoVKWHBWEZ != null)
						{
							jzBbCWcjsoWbucDWQOaoVKWHBWEZ.Dispose();
						}
					}

					private void DwXeyiveChKFywHObTWCCCASlivi()
					{
						HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -1;
						if (jzBbCWcjsoWbucDWQOaoVKWHBWEZ != null)
						{
							jzBbCWcjsoWbucDWQOaoVKWHBWEZ.Dispose();
						}
					}

					private void ZnccruANNvUJEUefIACbKTPzNMdy()
					{
						HvxGJdbBcpBoVAGGOkiqqgkhvykcA = -1;
						if (jzBbCWcjsoWbucDWQOaoVKWHBWEZ != null)
						{
							jzBbCWcjsoWbucDWQOaoVKWHBWEZ.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						JcBofUKjAOcDUFjVUneIFgtnNJhy jcBofUKjAOcDUFjVUneIFgtnNJhy;
						if (HvxGJdbBcpBoVAGGOkiqqgkhvykcA == -2 && LNRBvVpEPhRCwfZfCPfAZWjncLKw == Environment.CurrentManagedThreadId)
						{
							HvxGJdbBcpBoVAGGOkiqqgkhvykcA = 0;
							jcBofUKjAOcDUFjVUneIFgtnNJhy = this;
						}
						else
						{
							jcBofUKjAOcDUFjVUneIFgtnNJhy = new JcBofUKjAOcDUFjVUneIFgtnNJhy(0);
							jcBofUKjAOcDUFjVUneIFgtnNJhy.UBJDxHdMlrmfrSjyTrcRbOQdOEPsA = UBJDxHdMlrmfrSjyTrcRbOQdOEPsA;
						}
						return jcBofUKjAOcDUFjVUneIFgtnNJhy;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class TkuqNQYowBRuNABxEkVHzyyqDUsL : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int LtuCdrcSxKRBHyoUOhtBlbfxKnxp;

					private ControllerPollingInfo KiraYNhVqGxKDVxPdecESSfbYRlaA;

					private int GhCBMtJIzeRNPPUPCWOWkWtzkZNJA;

					public PollingHelper wQyvDCFfmxVYHiFgmXEWOvNQXYbD;

					private IEnumerator<ControllerPollingInfo> qvZYLKdqzBEZoiQdSYYFSvkpJwFcb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return KiraYNhVqGxKDVxPdecESSfbYRlaA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KiraYNhVqGxKDVxPdecESSfbYRlaA;
						}
					}

					[DebuggerHidden]
					public TkuqNQYowBRuNABxEkVHzyyqDUsL(int P_0)
					{
						LtuCdrcSxKRBHyoUOhtBlbfxKnxp = P_0;
						GhCBMtJIzeRNPPUPCWOWkWtzkZNJA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (LtuCdrcSxKRBHyoUOhtBlbfxKnxp)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								KShetQAYTwPFKQApmHLJFgFGvlmnb();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								dcNRbzwklIdbhTgLnFXRXeYVILID();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								nheJGdeiSpcRLOkrlEDOxIEfpDwW();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								feVVCrqqBWfEnXMujpbkarpeFTfe();
							}
						case -2:
						case -1:
						case 0:
							break;
						}
					}

					private bool MoveNext()
					{
						try
						{
							int ltuCdrcSxKRBHyoUOhtBlbfxKnxp = LtuCdrcSxKRBHyoUOhtBlbfxKnxp;
							PollingHelper pollingHelper = wQyvDCFfmxVYHiFgmXEWOvNQXYbD;
							switch (ltuCdrcSxKRBHyoUOhtBlbfxKnxp)
							{
							default:
								return false;
							case 0:
								LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								qvZYLKdqzBEZoiQdSYYFSvkpJwFcb = pollingHelper.QtiDmKPRQYfRrpxGVXOuJCpfuSXU().GetEnumerator();
								LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -3;
								goto IL_0088;
							case 1:
								LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -3;
								goto IL_0088;
							case 2:
								LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -4;
								goto IL_00e8;
							case 3:
								LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -5;
								goto IL_0148;
							case 4:
								{
									LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -6;
									break;
								}
								IL_00e8:
								if (qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.MoveNext())
								{
									ControllerPollingInfo current = qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.Current;
									KiraYNhVqGxKDVxPdecESSfbYRlaA = current;
									LtuCdrcSxKRBHyoUOhtBlbfxKnxp = 2;
									return true;
								}
								dcNRbzwklIdbhTgLnFXRXeYVILID();
								qvZYLKdqzBEZoiQdSYYFSvkpJwFcb = null;
								qvZYLKdqzBEZoiQdSYYFSvkpJwFcb = pollingHelper.iiuHutBddjajuhNYrZdOjPnuYdviA().GetEnumerator();
								LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -5;
								goto IL_0148;
								IL_0088:
								if (qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.MoveNext())
								{
									ControllerPollingInfo current2 = qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.Current;
									KiraYNhVqGxKDVxPdecESSfbYRlaA = current2;
									LtuCdrcSxKRBHyoUOhtBlbfxKnxp = 1;
									return true;
								}
								KShetQAYTwPFKQApmHLJFgFGvlmnb();
								qvZYLKdqzBEZoiQdSYYFSvkpJwFcb = null;
								qvZYLKdqzBEZoiQdSYYFSvkpJwFcb = pollingHelper.XoIKsnNBOyzxArmlrdIrKVZwSRyG().GetEnumerator();
								LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -4;
								goto IL_00e8;
								IL_0148:
								if (qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.MoveNext())
								{
									ControllerPollingInfo current3 = qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.Current;
									KiraYNhVqGxKDVxPdecESSfbYRlaA = current3;
									LtuCdrcSxKRBHyoUOhtBlbfxKnxp = 3;
									return true;
								}
								nheJGdeiSpcRLOkrlEDOxIEfpDwW();
								qvZYLKdqzBEZoiQdSYYFSvkpJwFcb = null;
								qvZYLKdqzBEZoiQdSYYFSvkpJwFcb = pollingHelper.NmJTRLEUErCJmMCSTQVEzBLJzgNN().GetEnumerator();
								LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -6;
								break;
							}
							if (qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.MoveNext())
							{
								ControllerPollingInfo current4 = qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.Current;
								KiraYNhVqGxKDVxPdecESSfbYRlaA = current4;
								LtuCdrcSxKRBHyoUOhtBlbfxKnxp = 4;
								return true;
							}
							feVVCrqqBWfEnXMujpbkarpeFTfe();
							qvZYLKdqzBEZoiQdSYYFSvkpJwFcb = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void KShetQAYTwPFKQApmHLJFgFGvlmnb()
					{
						LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -1;
						if (qvZYLKdqzBEZoiQdSYYFSvkpJwFcb != null)
						{
							qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.Dispose();
						}
					}

					private void dcNRbzwklIdbhTgLnFXRXeYVILID()
					{
						LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -1;
						if (qvZYLKdqzBEZoiQdSYYFSvkpJwFcb != null)
						{
							qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.Dispose();
						}
					}

					private void nheJGdeiSpcRLOkrlEDOxIEfpDwW()
					{
						LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -1;
						if (qvZYLKdqzBEZoiQdSYYFSvkpJwFcb != null)
						{
							qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.Dispose();
						}
					}

					private void feVVCrqqBWfEnXMujpbkarpeFTfe()
					{
						LtuCdrcSxKRBHyoUOhtBlbfxKnxp = -1;
						if (qvZYLKdqzBEZoiQdSYYFSvkpJwFcb != null)
						{
							qvZYLKdqzBEZoiQdSYYFSvkpJwFcb.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						TkuqNQYowBRuNABxEkVHzyyqDUsL tkuqNQYowBRuNABxEkVHzyyqDUsL;
						if (LtuCdrcSxKRBHyoUOhtBlbfxKnxp == -2 && GhCBMtJIzeRNPPUPCWOWkWtzkZNJA == Environment.CurrentManagedThreadId)
						{
							LtuCdrcSxKRBHyoUOhtBlbfxKnxp = 0;
							tkuqNQYowBRuNABxEkVHzyyqDUsL = this;
						}
						else
						{
							tkuqNQYowBRuNABxEkVHzyyqDUsL = new TkuqNQYowBRuNABxEkVHzyyqDUsL(0);
							tkuqNQYowBRuNABxEkVHzyyqDUsL.wQyvDCFfmxVYHiFgmXEWOvNQXYbD = wQyvDCFfmxVYHiFgmXEWOvNQXYbD;
						}
						return tkuqNQYowBRuNABxEkVHzyyqDUsL;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class WCzOAwDHWQqAArdZZbEgrraubrzH : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int YQDUEpiUzGRdRqNvcSzTiLmXuTCL;

					private ControllerPollingInfo fkKJgQufMmhxtiVRrtuVJyGQxDoMA;

					private int FishVzhorSEydekPMGhJfVWBIfwEB;

					public PollingHelper AhoKFLTBWGZDdbOutLqAMOCgsaUO;

					private IEnumerator<ControllerPollingInfo> gCuDDhjFPULNLUVzOHcJxbkUZDDW;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return fkKJgQufMmhxtiVRrtuVJyGQxDoMA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return fkKJgQufMmhxtiVRrtuVJyGQxDoMA;
						}
					}

					[DebuggerHidden]
					public WCzOAwDHWQqAArdZZbEgrraubrzH(int P_0)
					{
						YQDUEpiUzGRdRqNvcSzTiLmXuTCL = P_0;
						FishVzhorSEydekPMGhJfVWBIfwEB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (YQDUEpiUzGRdRqNvcSzTiLmXuTCL)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								QkwaTfghaQxUWgBPbuUNsNpYBnKl();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								JhmYhoVwNKUYIrKwzaKyQZqGNhjV();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								YwIxfMqdzmoCWjjDyGVkdgMxwANP();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								aUeUcwVBLbWsqYcxiiTEIDEHRIDr();
							}
						case -2:
						case -1:
						case 0:
							break;
						}
					}

					private bool MoveNext()
					{
						try
						{
							int yQDUEpiUzGRdRqNvcSzTiLmXuTCL = YQDUEpiUzGRdRqNvcSzTiLmXuTCL;
							PollingHelper ahoKFLTBWGZDdbOutLqAMOCgsaUO = AhoKFLTBWGZDdbOutLqAMOCgsaUO;
							switch (yQDUEpiUzGRdRqNvcSzTiLmXuTCL)
							{
							default:
								return false;
							case 0:
								YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								gCuDDhjFPULNLUVzOHcJxbkUZDDW = ahoKFLTBWGZDdbOutLqAMOCgsaUO.WijetqDBXTquftMOloOiGDQEurvlB().GetEnumerator();
								YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -3;
								goto IL_0088;
							case 1:
								YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -3;
								goto IL_0088;
							case 2:
								YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -4;
								goto IL_00e8;
							case 3:
								YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -5;
								goto IL_0148;
							case 4:
								{
									YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -6;
									break;
								}
								IL_00e8:
								if (gCuDDhjFPULNLUVzOHcJxbkUZDDW.MoveNext())
								{
									ControllerPollingInfo current = gCuDDhjFPULNLUVzOHcJxbkUZDDW.Current;
									fkKJgQufMmhxtiVRrtuVJyGQxDoMA = current;
									YQDUEpiUzGRdRqNvcSzTiLmXuTCL = 2;
									return true;
								}
								JhmYhoVwNKUYIrKwzaKyQZqGNhjV();
								gCuDDhjFPULNLUVzOHcJxbkUZDDW = null;
								gCuDDhjFPULNLUVzOHcJxbkUZDDW = ahoKFLTBWGZDdbOutLqAMOCgsaUO.gPnFCMzEsgzGDKNeDZQeVvYnEOoF().GetEnumerator();
								YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -5;
								goto IL_0148;
								IL_0088:
								if (gCuDDhjFPULNLUVzOHcJxbkUZDDW.MoveNext())
								{
									ControllerPollingInfo current2 = gCuDDhjFPULNLUVzOHcJxbkUZDDW.Current;
									fkKJgQufMmhxtiVRrtuVJyGQxDoMA = current2;
									YQDUEpiUzGRdRqNvcSzTiLmXuTCL = 1;
									return true;
								}
								QkwaTfghaQxUWgBPbuUNsNpYBnKl();
								gCuDDhjFPULNLUVzOHcJxbkUZDDW = null;
								gCuDDhjFPULNLUVzOHcJxbkUZDDW = ahoKFLTBWGZDdbOutLqAMOCgsaUO.cwrYXfBTckFFSzJCtBjHgvXCqLUBb().GetEnumerator();
								YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -4;
								goto IL_00e8;
								IL_0148:
								if (gCuDDhjFPULNLUVzOHcJxbkUZDDW.MoveNext())
								{
									ControllerPollingInfo current3 = gCuDDhjFPULNLUVzOHcJxbkUZDDW.Current;
									fkKJgQufMmhxtiVRrtuVJyGQxDoMA = current3;
									YQDUEpiUzGRdRqNvcSzTiLmXuTCL = 3;
									return true;
								}
								YwIxfMqdzmoCWjjDyGVkdgMxwANP();
								gCuDDhjFPULNLUVzOHcJxbkUZDDW = null;
								gCuDDhjFPULNLUVzOHcJxbkUZDDW = ahoKFLTBWGZDdbOutLqAMOCgsaUO.yFRDiMHeihamVFnfQDZHhaIojumi().GetEnumerator();
								YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -6;
								break;
							}
							if (gCuDDhjFPULNLUVzOHcJxbkUZDDW.MoveNext())
							{
								ControllerPollingInfo current4 = gCuDDhjFPULNLUVzOHcJxbkUZDDW.Current;
								fkKJgQufMmhxtiVRrtuVJyGQxDoMA = current4;
								YQDUEpiUzGRdRqNvcSzTiLmXuTCL = 4;
								return true;
							}
							aUeUcwVBLbWsqYcxiiTEIDEHRIDr();
							gCuDDhjFPULNLUVzOHcJxbkUZDDW = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void QkwaTfghaQxUWgBPbuUNsNpYBnKl()
					{
						YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -1;
						if (gCuDDhjFPULNLUVzOHcJxbkUZDDW != null)
						{
							gCuDDhjFPULNLUVzOHcJxbkUZDDW.Dispose();
						}
					}

					private void JhmYhoVwNKUYIrKwzaKyQZqGNhjV()
					{
						YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -1;
						if (gCuDDhjFPULNLUVzOHcJxbkUZDDW != null)
						{
							gCuDDhjFPULNLUVzOHcJxbkUZDDW.Dispose();
						}
					}

					private void YwIxfMqdzmoCWjjDyGVkdgMxwANP()
					{
						YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -1;
						if (gCuDDhjFPULNLUVzOHcJxbkUZDDW != null)
						{
							gCuDDhjFPULNLUVzOHcJxbkUZDDW.Dispose();
						}
					}

					private void aUeUcwVBLbWsqYcxiiTEIDEHRIDr()
					{
						YQDUEpiUzGRdRqNvcSzTiLmXuTCL = -1;
						if (gCuDDhjFPULNLUVzOHcJxbkUZDDW != null)
						{
							gCuDDhjFPULNLUVzOHcJxbkUZDDW.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						WCzOAwDHWQqAArdZZbEgrraubrzH wCzOAwDHWQqAArdZZbEgrraubrzH;
						if (YQDUEpiUzGRdRqNvcSzTiLmXuTCL == -2 && FishVzhorSEydekPMGhJfVWBIfwEB == Environment.CurrentManagedThreadId)
						{
							YQDUEpiUzGRdRqNvcSzTiLmXuTCL = 0;
							wCzOAwDHWQqAArdZZbEgrraubrzH = this;
						}
						else
						{
							wCzOAwDHWQqAArdZZbEgrraubrzH = new WCzOAwDHWQqAArdZZbEgrraubrzH(0);
							wCzOAwDHWQqAArdZZbEgrraubrzH.AhoKFLTBWGZDdbOutLqAMOCgsaUO = AhoKFLTBWGZDdbOutLqAMOCgsaUO;
						}
						return wCzOAwDHWQqAArdZZbEgrraubrzH;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class mDiYayNmQpKQbXJtlfLqFSziljshA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int nZdFRugsrSvAUgRXmEEqazaBhGKVA;

					private ControllerPollingInfo dDILbCVCJevkqPOfVnjRQWfEqtSs;

					private int PKumYchSXDcDtoRpQlCjYVrAFFLH;

					public PollingHelper ttPplasJaLsyaMyvnqTrJuwDDhZU;

					private IEnumerator<ControllerPollingInfo> ExRWaWRugMNRVxuuwXrcfAUBtuvB;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return dDILbCVCJevkqPOfVnjRQWfEqtSs;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dDILbCVCJevkqPOfVnjRQWfEqtSs;
						}
					}

					[DebuggerHidden]
					public mDiYayNmQpKQbXJtlfLqFSziljshA(int P_0)
					{
						nZdFRugsrSvAUgRXmEEqazaBhGKVA = P_0;
						PKumYchSXDcDtoRpQlCjYVrAFFLH = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (nZdFRugsrSvAUgRXmEEqazaBhGKVA)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								uShdmKSmZMznlfWUUfTrJPexITGu();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								hvfKewpgLnBkidgybGPlMazLozEE();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								enoQoLANyjPXIMlWxunqrTxhDTQH();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								nsHlSejHoghvYrIeeLgCKDcdlnhS();
							}
						case -2:
						case -1:
						case 0:
							break;
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = nZdFRugsrSvAUgRXmEEqazaBhGKVA;
							PollingHelper pollingHelper = ttPplasJaLsyaMyvnqTrJuwDDhZU;
							switch (num)
							{
							default:
								return false;
							case 0:
								nZdFRugsrSvAUgRXmEEqazaBhGKVA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								ExRWaWRugMNRVxuuwXrcfAUBtuvB = pollingHelper.APRCcbmutxeBsaCvGFlAOelFXCQWA().GetEnumerator();
								nZdFRugsrSvAUgRXmEEqazaBhGKVA = -3;
								goto IL_0088;
							case 1:
								nZdFRugsrSvAUgRXmEEqazaBhGKVA = -3;
								goto IL_0088;
							case 2:
								nZdFRugsrSvAUgRXmEEqazaBhGKVA = -4;
								goto IL_00e8;
							case 3:
								nZdFRugsrSvAUgRXmEEqazaBhGKVA = -5;
								goto IL_0148;
							case 4:
								{
									nZdFRugsrSvAUgRXmEEqazaBhGKVA = -6;
									break;
								}
								IL_00e8:
								if (ExRWaWRugMNRVxuuwXrcfAUBtuvB.MoveNext())
								{
									ControllerPollingInfo current = ExRWaWRugMNRVxuuwXrcfAUBtuvB.Current;
									dDILbCVCJevkqPOfVnjRQWfEqtSs = current;
									nZdFRugsrSvAUgRXmEEqazaBhGKVA = 2;
									return true;
								}
								hvfKewpgLnBkidgybGPlMazLozEE();
								ExRWaWRugMNRVxuuwXrcfAUBtuvB = null;
								ExRWaWRugMNRVxuuwXrcfAUBtuvB = pollingHelper.mdxhbVDNWGnFkXSSsSTDUrXooyNiA().GetEnumerator();
								nZdFRugsrSvAUgRXmEEqazaBhGKVA = -5;
								goto IL_0148;
								IL_0088:
								if (ExRWaWRugMNRVxuuwXrcfAUBtuvB.MoveNext())
								{
									ControllerPollingInfo current2 = ExRWaWRugMNRVxuuwXrcfAUBtuvB.Current;
									dDILbCVCJevkqPOfVnjRQWfEqtSs = current2;
									nZdFRugsrSvAUgRXmEEqazaBhGKVA = 1;
									return true;
								}
								uShdmKSmZMznlfWUUfTrJPexITGu();
								ExRWaWRugMNRVxuuwXrcfAUBtuvB = null;
								ExRWaWRugMNRVxuuwXrcfAUBtuvB = pollingHelper.XoIKsnNBOyzxArmlrdIrKVZwSRyG().GetEnumerator();
								nZdFRugsrSvAUgRXmEEqazaBhGKVA = -4;
								goto IL_00e8;
								IL_0148:
								if (ExRWaWRugMNRVxuuwXrcfAUBtuvB.MoveNext())
								{
									ControllerPollingInfo current3 = ExRWaWRugMNRVxuuwXrcfAUBtuvB.Current;
									dDILbCVCJevkqPOfVnjRQWfEqtSs = current3;
									nZdFRugsrSvAUgRXmEEqazaBhGKVA = 3;
									return true;
								}
								enoQoLANyjPXIMlWxunqrTxhDTQH();
								ExRWaWRugMNRVxuuwXrcfAUBtuvB = null;
								ExRWaWRugMNRVxuuwXrcfAUBtuvB = pollingHelper.uZCbVYGzbufaYtlBKyikMrLyMpNYA().GetEnumerator();
								nZdFRugsrSvAUgRXmEEqazaBhGKVA = -6;
								break;
							}
							if (ExRWaWRugMNRVxuuwXrcfAUBtuvB.MoveNext())
							{
								ControllerPollingInfo current4 = ExRWaWRugMNRVxuuwXrcfAUBtuvB.Current;
								dDILbCVCJevkqPOfVnjRQWfEqtSs = current4;
								nZdFRugsrSvAUgRXmEEqazaBhGKVA = 4;
								return true;
							}
							nsHlSejHoghvYrIeeLgCKDcdlnhS();
							ExRWaWRugMNRVxuuwXrcfAUBtuvB = null;
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void uShdmKSmZMznlfWUUfTrJPexITGu()
					{
						nZdFRugsrSvAUgRXmEEqazaBhGKVA = -1;
						if (ExRWaWRugMNRVxuuwXrcfAUBtuvB != null)
						{
							ExRWaWRugMNRVxuuwXrcfAUBtuvB.Dispose();
						}
					}

					private void hvfKewpgLnBkidgybGPlMazLozEE()
					{
						nZdFRugsrSvAUgRXmEEqazaBhGKVA = -1;
						if (ExRWaWRugMNRVxuuwXrcfAUBtuvB != null)
						{
							ExRWaWRugMNRVxuuwXrcfAUBtuvB.Dispose();
						}
					}

					private void enoQoLANyjPXIMlWxunqrTxhDTQH()
					{
						nZdFRugsrSvAUgRXmEEqazaBhGKVA = -1;
						if (ExRWaWRugMNRVxuuwXrcfAUBtuvB != null)
						{
							ExRWaWRugMNRVxuuwXrcfAUBtuvB.Dispose();
						}
					}

					private void nsHlSejHoghvYrIeeLgCKDcdlnhS()
					{
						nZdFRugsrSvAUgRXmEEqazaBhGKVA = -1;
						if (ExRWaWRugMNRVxuuwXrcfAUBtuvB != null)
						{
							ExRWaWRugMNRVxuuwXrcfAUBtuvB.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						mDiYayNmQpKQbXJtlfLqFSziljshA mDiYayNmQpKQbXJtlfLqFSziljshA2;
						if (nZdFRugsrSvAUgRXmEEqazaBhGKVA == -2 && PKumYchSXDcDtoRpQlCjYVrAFFLH == Environment.CurrentManagedThreadId)
						{
							nZdFRugsrSvAUgRXmEEqazaBhGKVA = 0;
							mDiYayNmQpKQbXJtlfLqFSziljshA2 = this;
						}
						else
						{
							mDiYayNmQpKQbXJtlfLqFSziljshA2 = new mDiYayNmQpKQbXJtlfLqFSziljshA(0);
							mDiYayNmQpKQbXJtlfLqFSziljshA2.ttPplasJaLsyaMyvnqTrJuwDDhZU = ttPplasJaLsyaMyvnqTrJuwDDhZU;
						}
						return mDiYayNmQpKQbXJtlfLqFSziljshA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class uljnsMxanxvWvPubzIaFHovcQyRj : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int XZNalGGmAmaUWNEllkLlPWGbTxJiA;

					private ControllerPollingInfo tdpeRkeyzsBnMPgJMJnnrLZuEXpFb;

					private int dRUdYEhdUQanatcvgIctxrpWPmth;

					private IList<CustomController> eQQSkzpHMTwdtdTOAoDLagHPOwRM;

					private int sMvJVHPeKBwksPVxqiIHyPWmptUf;

					private IEnumerator<ControllerPollingInfo> rfIzMEKEWEOQljDUqySgMotqRoET;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return tdpeRkeyzsBnMPgJMJnnrLZuEXpFb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return tdpeRkeyzsBnMPgJMJnnrLZuEXpFb;
						}
					}

					[DebuggerHidden]
					public uljnsMxanxvWvPubzIaFHovcQyRj(int P_0)
					{
						XZNalGGmAmaUWNEllkLlPWGbTxJiA = P_0;
						dRUdYEhdUQanatcvgIctxrpWPmth = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int xZNalGGmAmaUWNEllkLlPWGbTxJiA = XZNalGGmAmaUWNEllkLlPWGbTxJiA;
						if (xZNalGGmAmaUWNEllkLlPWGbTxJiA == -3 || xZNalGGmAmaUWNEllkLlPWGbTxJiA == 1)
						{
							try
							{
							}
							finally
							{
								MezfKMvWHKbcZKDsFtItouxnQZch();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int xZNalGGmAmaUWNEllkLlPWGbTxJiA = XZNalGGmAmaUWNEllkLlPWGbTxJiA;
							if (xZNalGGmAmaUWNEllkLlPWGbTxJiA != 0)
							{
								if (xZNalGGmAmaUWNEllkLlPWGbTxJiA != 1)
								{
									return false;
								}
								XZNalGGmAmaUWNEllkLlPWGbTxJiA = -3;
								goto IL_0086;
							}
							XZNalGGmAmaUWNEllkLlPWGbTxJiA = -1;
							eQQSkzpHMTwdtdTOAoDLagHPOwRM = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
							sMvJVHPeKBwksPVxqiIHyPWmptUf = 0;
							goto IL_00b0;
							IL_0086:
							if (rfIzMEKEWEOQljDUqySgMotqRoET.MoveNext())
							{
								ControllerPollingInfo current = rfIzMEKEWEOQljDUqySgMotqRoET.Current;
								tdpeRkeyzsBnMPgJMJnnrLZuEXpFb = current;
								XZNalGGmAmaUWNEllkLlPWGbTxJiA = 1;
								return true;
							}
							MezfKMvWHKbcZKDsFtItouxnQZch();
							rfIzMEKEWEOQljDUqySgMotqRoET = null;
							sMvJVHPeKBwksPVxqiIHyPWmptUf++;
							goto IL_00b0;
							IL_00b0:
							if (sMvJVHPeKBwksPVxqiIHyPWmptUf < eQQSkzpHMTwdtdTOAoDLagHPOwRM.Count)
							{
								rfIzMEKEWEOQljDUqySgMotqRoET = eQQSkzpHMTwdtdTOAoDLagHPOwRM[sMvJVHPeKBwksPVxqiIHyPWmptUf].PollForAllAxes().GetEnumerator();
								XZNalGGmAmaUWNEllkLlPWGbTxJiA = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void MezfKMvWHKbcZKDsFtItouxnQZch()
					{
						XZNalGGmAmaUWNEllkLlPWGbTxJiA = -1;
						if (rfIzMEKEWEOQljDUqySgMotqRoET != null)
						{
							rfIzMEKEWEOQljDUqySgMotqRoET.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (XZNalGGmAmaUWNEllkLlPWGbTxJiA == -2 && dRUdYEhdUQanatcvgIctxrpWPmth == Environment.CurrentManagedThreadId)
						{
							XZNalGGmAmaUWNEllkLlPWGbTxJiA = 0;
							return this;
						}
						return new uljnsMxanxvWvPubzIaFHovcQyRj(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class IJilhHzPDYiJpGqKLRyqiapAqcIhb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int OxVDgPnQPYgHmbmlBoJHeOhRxQmw;

					private ControllerPollingInfo PuKWzDaWwgIJoPQpHHdkMTEoAhBM;

					private int OgTjeUPqAdyDVuXndepxZOQJzqRS;

					private IList<CustomController> HuBQAKAtoLCbmepJkIocTQSHNKrh;

					private int pkytuoGVtMuFsfrtWjJeblUGDcei;

					private IEnumerator<ControllerPollingInfo> ajgRrUDReUchRPlTBkynyZyeQBNB;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PuKWzDaWwgIJoPQpHHdkMTEoAhBM;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PuKWzDaWwgIJoPQpHHdkMTEoAhBM;
						}
					}

					[DebuggerHidden]
					public IJilhHzPDYiJpGqKLRyqiapAqcIhb(int P_0)
					{
						OxVDgPnQPYgHmbmlBoJHeOhRxQmw = P_0;
						OgTjeUPqAdyDVuXndepxZOQJzqRS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int oxVDgPnQPYgHmbmlBoJHeOhRxQmw = OxVDgPnQPYgHmbmlBoJHeOhRxQmw;
						if (oxVDgPnQPYgHmbmlBoJHeOhRxQmw == -3 || oxVDgPnQPYgHmbmlBoJHeOhRxQmw == 1)
						{
							try
							{
							}
							finally
							{
								ysSKjQqWVFawMkFSIGOzkIhQHVxQ();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int oxVDgPnQPYgHmbmlBoJHeOhRxQmw = OxVDgPnQPYgHmbmlBoJHeOhRxQmw;
							if (oxVDgPnQPYgHmbmlBoJHeOhRxQmw != 0)
							{
								if (oxVDgPnQPYgHmbmlBoJHeOhRxQmw != 1)
								{
									return false;
								}
								OxVDgPnQPYgHmbmlBoJHeOhRxQmw = -3;
								goto IL_0086;
							}
							OxVDgPnQPYgHmbmlBoJHeOhRxQmw = -1;
							HuBQAKAtoLCbmepJkIocTQSHNKrh = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
							pkytuoGVtMuFsfrtWjJeblUGDcei = 0;
							goto IL_00b0;
							IL_0086:
							if (ajgRrUDReUchRPlTBkynyZyeQBNB.MoveNext())
							{
								ControllerPollingInfo current = ajgRrUDReUchRPlTBkynyZyeQBNB.Current;
								PuKWzDaWwgIJoPQpHHdkMTEoAhBM = current;
								OxVDgPnQPYgHmbmlBoJHeOhRxQmw = 1;
								return true;
							}
							ysSKjQqWVFawMkFSIGOzkIhQHVxQ();
							ajgRrUDReUchRPlTBkynyZyeQBNB = null;
							pkytuoGVtMuFsfrtWjJeblUGDcei++;
							goto IL_00b0;
							IL_00b0:
							if (pkytuoGVtMuFsfrtWjJeblUGDcei < HuBQAKAtoLCbmepJkIocTQSHNKrh.Count)
							{
								ajgRrUDReUchRPlTBkynyZyeQBNB = HuBQAKAtoLCbmepJkIocTQSHNKrh[pkytuoGVtMuFsfrtWjJeblUGDcei].PollForAllButtons().GetEnumerator();
								OxVDgPnQPYgHmbmlBoJHeOhRxQmw = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ysSKjQqWVFawMkFSIGOzkIhQHVxQ()
					{
						OxVDgPnQPYgHmbmlBoJHeOhRxQmw = -1;
						if (ajgRrUDReUchRPlTBkynyZyeQBNB != null)
						{
							ajgRrUDReUchRPlTBkynyZyeQBNB.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (OxVDgPnQPYgHmbmlBoJHeOhRxQmw == -2 && OgTjeUPqAdyDVuXndepxZOQJzqRS == Environment.CurrentManagedThreadId)
						{
							OxVDgPnQPYgHmbmlBoJHeOhRxQmw = 0;
							return this;
						}
						return new IJilhHzPDYiJpGqKLRyqiapAqcIhb(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ZxHbLFLSQxJShqbNDgkyFIwSqVIVA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int vsSIzYqQarptcBYJfSSdDDfkiwIhA;

					private ControllerPollingInfo PEvSqJwCwzKnwkhOObKSjPszjoat;

					private int nyTDIeimqjlVztifmDLUqiscTRjeA;

					private IList<CustomController> hGgwKJYrpYGlwvlxpkdttljHpoRw;

					private int AfnSltENHdIzTDgAkwHqskFOFrgBA;

					private IEnumerator<ControllerPollingInfo> FxJnaaaAZSBzlLynPrBJrOKOinVp;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PEvSqJwCwzKnwkhOObKSjPszjoat;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PEvSqJwCwzKnwkhOObKSjPszjoat;
						}
					}

					[DebuggerHidden]
					public ZxHbLFLSQxJShqbNDgkyFIwSqVIVA(int P_0)
					{
						vsSIzYqQarptcBYJfSSdDDfkiwIhA = P_0;
						nyTDIeimqjlVztifmDLUqiscTRjeA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = vsSIzYqQarptcBYJfSSdDDfkiwIhA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								RTlIFGJgXiOsHCIeTwSLyfEpEBaE();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = vsSIzYqQarptcBYJfSSdDDfkiwIhA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								vsSIzYqQarptcBYJfSSdDDfkiwIhA = -3;
								goto IL_0086;
							}
							vsSIzYqQarptcBYJfSSdDDfkiwIhA = -1;
							hGgwKJYrpYGlwvlxpkdttljHpoRw = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
							AfnSltENHdIzTDgAkwHqskFOFrgBA = 0;
							goto IL_00b0;
							IL_0086:
							if (FxJnaaaAZSBzlLynPrBJrOKOinVp.MoveNext())
							{
								ControllerPollingInfo current = FxJnaaaAZSBzlLynPrBJrOKOinVp.Current;
								PEvSqJwCwzKnwkhOObKSjPszjoat = current;
								vsSIzYqQarptcBYJfSSdDDfkiwIhA = 1;
								return true;
							}
							RTlIFGJgXiOsHCIeTwSLyfEpEBaE();
							FxJnaaaAZSBzlLynPrBJrOKOinVp = null;
							AfnSltENHdIzTDgAkwHqskFOFrgBA++;
							goto IL_00b0;
							IL_00b0:
							if (AfnSltENHdIzTDgAkwHqskFOFrgBA < hGgwKJYrpYGlwvlxpkdttljHpoRw.Count)
							{
								FxJnaaaAZSBzlLynPrBJrOKOinVp = hGgwKJYrpYGlwvlxpkdttljHpoRw[AfnSltENHdIzTDgAkwHqskFOFrgBA].PollForAllButtonsDown().GetEnumerator();
								vsSIzYqQarptcBYJfSSdDDfkiwIhA = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void RTlIFGJgXiOsHCIeTwSLyfEpEBaE()
					{
						vsSIzYqQarptcBYJfSSdDDfkiwIhA = -1;
						if (FxJnaaaAZSBzlLynPrBJrOKOinVp != null)
						{
							FxJnaaaAZSBzlLynPrBJrOKOinVp.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (vsSIzYqQarptcBYJfSSdDDfkiwIhA == -2 && nyTDIeimqjlVztifmDLUqiscTRjeA == Environment.CurrentManagedThreadId)
						{
							vsSIzYqQarptcBYJfSSdDDfkiwIhA = 0;
							return this;
						}
						return new ZxHbLFLSQxJShqbNDgkyFIwSqVIVA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ofQYdCBnYImRmBhBMcamIBXpDfunA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int yGCiMTOaYLBRBbVXdHdWkawIEwyab;

					private ControllerPollingInfo DYnWFgISwQKmwHiCPIvIZAldBRpi;

					private int DIyDDHrGdfqLEJkCnlnjnUAIABgX;

					private IList<CustomController> YjJGigQmQLjjouYNxczZaKofyyag;

					private int pEhfgbHTQHyuOiRQgJGEPvYOCBpG;

					private IEnumerator<ControllerPollingInfo> hSqMPmRtFFWBSaOgDvKrTJUnIvhj;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DYnWFgISwQKmwHiCPIvIZAldBRpi;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DYnWFgISwQKmwHiCPIvIZAldBRpi;
						}
					}

					[DebuggerHidden]
					public ofQYdCBnYImRmBhBMcamIBXpDfunA(int P_0)
					{
						yGCiMTOaYLBRBbVXdHdWkawIEwyab = P_0;
						DIyDDHrGdfqLEJkCnlnjnUAIABgX = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = yGCiMTOaYLBRBbVXdHdWkawIEwyab;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								jybppJQKtpvZAzuoeJMcJvrhnqIF();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = yGCiMTOaYLBRBbVXdHdWkawIEwyab;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								yGCiMTOaYLBRBbVXdHdWkawIEwyab = -3;
								goto IL_0086;
							}
							yGCiMTOaYLBRBbVXdHdWkawIEwyab = -1;
							YjJGigQmQLjjouYNxczZaKofyyag = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
							pEhfgbHTQHyuOiRQgJGEPvYOCBpG = 0;
							goto IL_00b0;
							IL_0086:
							if (hSqMPmRtFFWBSaOgDvKrTJUnIvhj.MoveNext())
							{
								ControllerPollingInfo current = hSqMPmRtFFWBSaOgDvKrTJUnIvhj.Current;
								DYnWFgISwQKmwHiCPIvIZAldBRpi = current;
								yGCiMTOaYLBRBbVXdHdWkawIEwyab = 1;
								return true;
							}
							jybppJQKtpvZAzuoeJMcJvrhnqIF();
							hSqMPmRtFFWBSaOgDvKrTJUnIvhj = null;
							pEhfgbHTQHyuOiRQgJGEPvYOCBpG++;
							goto IL_00b0;
							IL_00b0:
							if (pEhfgbHTQHyuOiRQgJGEPvYOCBpG < YjJGigQmQLjjouYNxczZaKofyyag.Count)
							{
								hSqMPmRtFFWBSaOgDvKrTJUnIvhj = YjJGigQmQLjjouYNxczZaKofyyag[pEhfgbHTQHyuOiRQgJGEPvYOCBpG].PollForAllElements().GetEnumerator();
								yGCiMTOaYLBRBbVXdHdWkawIEwyab = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void jybppJQKtpvZAzuoeJMcJvrhnqIF()
					{
						yGCiMTOaYLBRBbVXdHdWkawIEwyab = -1;
						if (hSqMPmRtFFWBSaOgDvKrTJUnIvhj != null)
						{
							hSqMPmRtFFWBSaOgDvKrTJUnIvhj.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (yGCiMTOaYLBRBbVXdHdWkawIEwyab == -2 && DIyDDHrGdfqLEJkCnlnjnUAIABgX == Environment.CurrentManagedThreadId)
						{
							yGCiMTOaYLBRBbVXdHdWkawIEwyab = 0;
							return this;
						}
						return new ofQYdCBnYImRmBhBMcamIBXpDfunA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ItMESKSwVMfxJyvMQhapBWSNBUmXA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int yeJczTvQIRLosLxNFusVlJMkCcCE;

					private ControllerPollingInfo FNEnKeOBBKFVSvnhoGkPDVxobSHM;

					private int IuhiCoxscwvLHgXjHDgtmNXBTSEI;

					private IList<CustomController> RQeXgqbeeUTVWNMrkzTxYwrGukUm;

					private int ZqDDlNqXvxVVzgstOvRiWJJfzeHE;

					private IEnumerator<ControllerPollingInfo> gaHPJuWPCMGFLgyAIJqGpHXLAnroA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return FNEnKeOBBKFVSvnhoGkPDVxobSHM;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return FNEnKeOBBKFVSvnhoGkPDVxobSHM;
						}
					}

					[DebuggerHidden]
					public ItMESKSwVMfxJyvMQhapBWSNBUmXA(int P_0)
					{
						yeJczTvQIRLosLxNFusVlJMkCcCE = P_0;
						IuhiCoxscwvLHgXjHDgtmNXBTSEI = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = yeJczTvQIRLosLxNFusVlJMkCcCE;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								swPOPwbQHLsiaNqSTfyGMmJzwCGl();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = yeJczTvQIRLosLxNFusVlJMkCcCE;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								yeJczTvQIRLosLxNFusVlJMkCcCE = -3;
								goto IL_0086;
							}
							yeJczTvQIRLosLxNFusVlJMkCcCE = -1;
							RQeXgqbeeUTVWNMrkzTxYwrGukUm = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
							ZqDDlNqXvxVVzgstOvRiWJJfzeHE = 0;
							goto IL_00b0;
							IL_0086:
							if (gaHPJuWPCMGFLgyAIJqGpHXLAnroA.MoveNext())
							{
								ControllerPollingInfo current = gaHPJuWPCMGFLgyAIJqGpHXLAnroA.Current;
								FNEnKeOBBKFVSvnhoGkPDVxobSHM = current;
								yeJczTvQIRLosLxNFusVlJMkCcCE = 1;
								return true;
							}
							swPOPwbQHLsiaNqSTfyGMmJzwCGl();
							gaHPJuWPCMGFLgyAIJqGpHXLAnroA = null;
							ZqDDlNqXvxVVzgstOvRiWJJfzeHE++;
							goto IL_00b0;
							IL_00b0:
							if (ZqDDlNqXvxVVzgstOvRiWJJfzeHE < RQeXgqbeeUTVWNMrkzTxYwrGukUm.Count)
							{
								gaHPJuWPCMGFLgyAIJqGpHXLAnroA = RQeXgqbeeUTVWNMrkzTxYwrGukUm[ZqDDlNqXvxVVzgstOvRiWJJfzeHE].PollForAllElementsDown().GetEnumerator();
								yeJczTvQIRLosLxNFusVlJMkCcCE = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void swPOPwbQHLsiaNqSTfyGMmJzwCGl()
					{
						yeJczTvQIRLosLxNFusVlJMkCcCE = -1;
						if (gaHPJuWPCMGFLgyAIJqGpHXLAnroA != null)
						{
							gaHPJuWPCMGFLgyAIJqGpHXLAnroA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (yeJczTvQIRLosLxNFusVlJMkCcCE == -2 && IuhiCoxscwvLHgXjHDgtmNXBTSEI == Environment.CurrentManagedThreadId)
						{
							yeJczTvQIRLosLxNFusVlJMkCcCE = 0;
							return this;
						}
						return new ItMESKSwVMfxJyvMQhapBWSNBUmXA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class WyGPUcmxzadBsNCGqOMDadegLPgW : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int vcoJZkXvoYPuLkouJlXdlWkEAwGH;

					private ControllerPollingInfo iqQnJavBqeMFYyGyBQXmPdvcMHiH;

					private int uKeCakNyfgbSytMYZKivFabZAvpbA;

					private IList<Joystick> KLvfCdHjmbeWmaMeizBAMkcEgsRLA;

					private int jSdCnkGWftgWJwrwHfgGEpEAGXtOB;

					private IEnumerator<ControllerPollingInfo> kduCLgOiVRatdfQegNXESiatUrclA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return iqQnJavBqeMFYyGyBQXmPdvcMHiH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return iqQnJavBqeMFYyGyBQXmPdvcMHiH;
						}
					}

					[DebuggerHidden]
					public WyGPUcmxzadBsNCGqOMDadegLPgW(int P_0)
					{
						vcoJZkXvoYPuLkouJlXdlWkEAwGH = P_0;
						uKeCakNyfgbSytMYZKivFabZAvpbA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = vcoJZkXvoYPuLkouJlXdlWkEAwGH;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								xAzPVBULNdAcaWGMsXkjxGpkYzdL();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = vcoJZkXvoYPuLkouJlXdlWkEAwGH;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								vcoJZkXvoYPuLkouJlXdlWkEAwGH = -3;
								goto IL_0086;
							}
							vcoJZkXvoYPuLkouJlXdlWkEAwGH = -1;
							KLvfCdHjmbeWmaMeizBAMkcEgsRLA = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
							jSdCnkGWftgWJwrwHfgGEpEAGXtOB = 0;
							goto IL_00b0;
							IL_0086:
							if (kduCLgOiVRatdfQegNXESiatUrclA.MoveNext())
							{
								ControllerPollingInfo current = kduCLgOiVRatdfQegNXESiatUrclA.Current;
								iqQnJavBqeMFYyGyBQXmPdvcMHiH = current;
								vcoJZkXvoYPuLkouJlXdlWkEAwGH = 1;
								return true;
							}
							xAzPVBULNdAcaWGMsXkjxGpkYzdL();
							kduCLgOiVRatdfQegNXESiatUrclA = null;
							jSdCnkGWftgWJwrwHfgGEpEAGXtOB++;
							goto IL_00b0;
							IL_00b0:
							if (jSdCnkGWftgWJwrwHfgGEpEAGXtOB < KLvfCdHjmbeWmaMeizBAMkcEgsRLA.Count)
							{
								kduCLgOiVRatdfQegNXESiatUrclA = KLvfCdHjmbeWmaMeizBAMkcEgsRLA[jSdCnkGWftgWJwrwHfgGEpEAGXtOB].PollForAllAxes().GetEnumerator();
								vcoJZkXvoYPuLkouJlXdlWkEAwGH = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void xAzPVBULNdAcaWGMsXkjxGpkYzdL()
					{
						vcoJZkXvoYPuLkouJlXdlWkEAwGH = -1;
						if (kduCLgOiVRatdfQegNXESiatUrclA != null)
						{
							kduCLgOiVRatdfQegNXESiatUrclA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (vcoJZkXvoYPuLkouJlXdlWkEAwGH == -2 && uKeCakNyfgbSytMYZKivFabZAvpbA == Environment.CurrentManagedThreadId)
						{
							vcoJZkXvoYPuLkouJlXdlWkEAwGH = 0;
							return this;
						}
						return new WyGPUcmxzadBsNCGqOMDadegLPgW(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class cbsPaXSTbUGtmKWEkwdbDcoScitO : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int BKaZmylAESpOXLsDCiurLWTnWaV;

					private ControllerPollingInfo HIeagBhbRUwCSdZXknGLoFGjNjBZA;

					private int SAMgsCUmoRBusxCXygeZjFkkQsDb;

					private IList<Joystick> ilUkBTaHvoEsiRfdNAGHKKZLNvkA;

					private int DTslbFCrlDzGEBPQWgstDxxGfisN;

					private IEnumerator<ControllerPollingInfo> HKJaZwXlMmjPmhPjOhinmgNzcaBoA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return HIeagBhbRUwCSdZXknGLoFGjNjBZA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HIeagBhbRUwCSdZXknGLoFGjNjBZA;
						}
					}

					[DebuggerHidden]
					public cbsPaXSTbUGtmKWEkwdbDcoScitO(int P_0)
					{
						BKaZmylAESpOXLsDCiurLWTnWaV = P_0;
						SAMgsCUmoRBusxCXygeZjFkkQsDb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int bKaZmylAESpOXLsDCiurLWTnWaV = BKaZmylAESpOXLsDCiurLWTnWaV;
						if (bKaZmylAESpOXLsDCiurLWTnWaV == -3 || bKaZmylAESpOXLsDCiurLWTnWaV == 1)
						{
							try
							{
							}
							finally
							{
								SchgNEeZUKHaqdTnZvJQsrBgXXIEA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int bKaZmylAESpOXLsDCiurLWTnWaV = BKaZmylAESpOXLsDCiurLWTnWaV;
							if (bKaZmylAESpOXLsDCiurLWTnWaV != 0)
							{
								if (bKaZmylAESpOXLsDCiurLWTnWaV != 1)
								{
									return false;
								}
								BKaZmylAESpOXLsDCiurLWTnWaV = -3;
								goto IL_0086;
							}
							BKaZmylAESpOXLsDCiurLWTnWaV = -1;
							ilUkBTaHvoEsiRfdNAGHKKZLNvkA = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
							DTslbFCrlDzGEBPQWgstDxxGfisN = 0;
							goto IL_00b0;
							IL_0086:
							if (HKJaZwXlMmjPmhPjOhinmgNzcaBoA.MoveNext())
							{
								ControllerPollingInfo current = HKJaZwXlMmjPmhPjOhinmgNzcaBoA.Current;
								HIeagBhbRUwCSdZXknGLoFGjNjBZA = current;
								BKaZmylAESpOXLsDCiurLWTnWaV = 1;
								return true;
							}
							SchgNEeZUKHaqdTnZvJQsrBgXXIEA();
							HKJaZwXlMmjPmhPjOhinmgNzcaBoA = null;
							DTslbFCrlDzGEBPQWgstDxxGfisN++;
							goto IL_00b0;
							IL_00b0:
							if (DTslbFCrlDzGEBPQWgstDxxGfisN < ilUkBTaHvoEsiRfdNAGHKKZLNvkA.Count)
							{
								HKJaZwXlMmjPmhPjOhinmgNzcaBoA = ilUkBTaHvoEsiRfdNAGHKKZLNvkA[DTslbFCrlDzGEBPQWgstDxxGfisN].PollForAllButtons().GetEnumerator();
								BKaZmylAESpOXLsDCiurLWTnWaV = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void SchgNEeZUKHaqdTnZvJQsrBgXXIEA()
					{
						BKaZmylAESpOXLsDCiurLWTnWaV = -1;
						if (HKJaZwXlMmjPmhPjOhinmgNzcaBoA != null)
						{
							HKJaZwXlMmjPmhPjOhinmgNzcaBoA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (BKaZmylAESpOXLsDCiurLWTnWaV == -2 && SAMgsCUmoRBusxCXygeZjFkkQsDb == Environment.CurrentManagedThreadId)
						{
							BKaZmylAESpOXLsDCiurLWTnWaV = 0;
							return this;
						}
						return new cbsPaXSTbUGtmKWEkwdbDcoScitO(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class JPurJxusHEtgPReebXSNkJcWKzsj : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int JAyPCyXzoBohjhnYsdgSdejsiWjFA;

					private ControllerPollingInfo BaKjuwXmeqbjuzfbeMTYLAbvShEE;

					private int zPocYFFnAqdkqOVuwBHYEAlfywaVA;

					private IList<Joystick> fAOepYbUAlrXIfZMTZgjISKhHauo;

					private int PyVwksOkNyJasWVVwclkdAayBGyHA;

					private IEnumerator<ControllerPollingInfo> KOJQMxlWBjDbkkWoxSUYAaGfbbEiA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return BaKjuwXmeqbjuzfbeMTYLAbvShEE;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return BaKjuwXmeqbjuzfbeMTYLAbvShEE;
						}
					}

					[DebuggerHidden]
					public JPurJxusHEtgPReebXSNkJcWKzsj(int P_0)
					{
						JAyPCyXzoBohjhnYsdgSdejsiWjFA = P_0;
						zPocYFFnAqdkqOVuwBHYEAlfywaVA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int jAyPCyXzoBohjhnYsdgSdejsiWjFA = JAyPCyXzoBohjhnYsdgSdejsiWjFA;
						if (jAyPCyXzoBohjhnYsdgSdejsiWjFA == -3 || jAyPCyXzoBohjhnYsdgSdejsiWjFA == 1)
						{
							try
							{
							}
							finally
							{
								IShFbXgYTKJFqEYoiykmElSkbUAl();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int jAyPCyXzoBohjhnYsdgSdejsiWjFA = JAyPCyXzoBohjhnYsdgSdejsiWjFA;
							if (jAyPCyXzoBohjhnYsdgSdejsiWjFA != 0)
							{
								if (jAyPCyXzoBohjhnYsdgSdejsiWjFA != 1)
								{
									return false;
								}
								JAyPCyXzoBohjhnYsdgSdejsiWjFA = -3;
								goto IL_0086;
							}
							JAyPCyXzoBohjhnYsdgSdejsiWjFA = -1;
							fAOepYbUAlrXIfZMTZgjISKhHauo = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
							PyVwksOkNyJasWVVwclkdAayBGyHA = 0;
							goto IL_00b0;
							IL_0086:
							if (KOJQMxlWBjDbkkWoxSUYAaGfbbEiA.MoveNext())
							{
								ControllerPollingInfo current = KOJQMxlWBjDbkkWoxSUYAaGfbbEiA.Current;
								BaKjuwXmeqbjuzfbeMTYLAbvShEE = current;
								JAyPCyXzoBohjhnYsdgSdejsiWjFA = 1;
								return true;
							}
							IShFbXgYTKJFqEYoiykmElSkbUAl();
							KOJQMxlWBjDbkkWoxSUYAaGfbbEiA = null;
							PyVwksOkNyJasWVVwclkdAayBGyHA++;
							goto IL_00b0;
							IL_00b0:
							if (PyVwksOkNyJasWVVwclkdAayBGyHA < fAOepYbUAlrXIfZMTZgjISKhHauo.Count)
							{
								KOJQMxlWBjDbkkWoxSUYAaGfbbEiA = fAOepYbUAlrXIfZMTZgjISKhHauo[PyVwksOkNyJasWVVwclkdAayBGyHA].PollForAllButtonsDown().GetEnumerator();
								JAyPCyXzoBohjhnYsdgSdejsiWjFA = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void IShFbXgYTKJFqEYoiykmElSkbUAl()
					{
						JAyPCyXzoBohjhnYsdgSdejsiWjFA = -1;
						if (KOJQMxlWBjDbkkWoxSUYAaGfbbEiA != null)
						{
							KOJQMxlWBjDbkkWoxSUYAaGfbbEiA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (JAyPCyXzoBohjhnYsdgSdejsiWjFA == -2 && zPocYFFnAqdkqOVuwBHYEAlfywaVA == Environment.CurrentManagedThreadId)
						{
							JAyPCyXzoBohjhnYsdgSdejsiWjFA = 0;
							return this;
						}
						return new JPurJxusHEtgPReebXSNkJcWKzsj(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class dhcDyUNbwecFNFPcwlXZVSxdxTUEA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int qVJesoCVRNRBlScwkNNwbJCocaDlA;

					private ControllerPollingInfo agZCjPeumlIvHAJvpJFWHeEzoCLYA;

					private int GNaQqxhimLThykBnpfLiGOZGCBVX;

					private IList<Joystick> WBkkMtGtPmYhVtGEuJvopNVVYLtu;

					private int oTnGLRpnacEXriIgCgvhndjTnBKE;

					private IEnumerator<ControllerPollingInfo> OmjSyMwNrLcRvhskcAARrbobnhdE;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return agZCjPeumlIvHAJvpJFWHeEzoCLYA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return agZCjPeumlIvHAJvpJFWHeEzoCLYA;
						}
					}

					[DebuggerHidden]
					public dhcDyUNbwecFNFPcwlXZVSxdxTUEA(int P_0)
					{
						qVJesoCVRNRBlScwkNNwbJCocaDlA = P_0;
						GNaQqxhimLThykBnpfLiGOZGCBVX = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = qVJesoCVRNRBlScwkNNwbJCocaDlA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								WEsAUpFyvITpNfgBogtOZvHxOhRPA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = qVJesoCVRNRBlScwkNNwbJCocaDlA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								qVJesoCVRNRBlScwkNNwbJCocaDlA = -3;
								goto IL_0086;
							}
							qVJesoCVRNRBlScwkNNwbJCocaDlA = -1;
							WBkkMtGtPmYhVtGEuJvopNVVYLtu = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
							oTnGLRpnacEXriIgCgvhndjTnBKE = 0;
							goto IL_00b0;
							IL_0086:
							if (OmjSyMwNrLcRvhskcAARrbobnhdE.MoveNext())
							{
								ControllerPollingInfo current = OmjSyMwNrLcRvhskcAARrbobnhdE.Current;
								agZCjPeumlIvHAJvpJFWHeEzoCLYA = current;
								qVJesoCVRNRBlScwkNNwbJCocaDlA = 1;
								return true;
							}
							WEsAUpFyvITpNfgBogtOZvHxOhRPA();
							OmjSyMwNrLcRvhskcAARrbobnhdE = null;
							oTnGLRpnacEXriIgCgvhndjTnBKE++;
							goto IL_00b0;
							IL_00b0:
							if (oTnGLRpnacEXriIgCgvhndjTnBKE < WBkkMtGtPmYhVtGEuJvopNVVYLtu.Count)
							{
								OmjSyMwNrLcRvhskcAARrbobnhdE = WBkkMtGtPmYhVtGEuJvopNVVYLtu[oTnGLRpnacEXriIgCgvhndjTnBKE].PollForAllElements().GetEnumerator();
								qVJesoCVRNRBlScwkNNwbJCocaDlA = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void WEsAUpFyvITpNfgBogtOZvHxOhRPA()
					{
						qVJesoCVRNRBlScwkNNwbJCocaDlA = -1;
						if (OmjSyMwNrLcRvhskcAARrbobnhdE != null)
						{
							OmjSyMwNrLcRvhskcAARrbobnhdE.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (qVJesoCVRNRBlScwkNNwbJCocaDlA == -2 && GNaQqxhimLThykBnpfLiGOZGCBVX == Environment.CurrentManagedThreadId)
						{
							qVJesoCVRNRBlScwkNNwbJCocaDlA = 0;
							return this;
						}
						return new dhcDyUNbwecFNFPcwlXZVSxdxTUEA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class vnlJFAbuhOBuvMJUJHWyAfYsywRg : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int koeBOheoQaZPAqOTnfWdDiEAThyob;

					private ControllerPollingInfo rYXHSjnAnGCkAzwRMzHmihOzfyMd;

					private int gderNlYbAyHAJfiuRnSZNyqeCBzbb;

					private IList<Joystick> vdzsiEMasBZUjnRWKUzQLUdmRnJI;

					private int nCDQYXHWgGfWdzEbFRRqouFhtaMP;

					private IEnumerator<ControllerPollingInfo> ZkpTFidwSriDNBHcbzJCELfTTavj;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rYXHSjnAnGCkAzwRMzHmihOzfyMd;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rYXHSjnAnGCkAzwRMzHmihOzfyMd;
						}
					}

					[DebuggerHidden]
					public vnlJFAbuhOBuvMJUJHWyAfYsywRg(int P_0)
					{
						koeBOheoQaZPAqOTnfWdDiEAThyob = P_0;
						gderNlYbAyHAJfiuRnSZNyqeCBzbb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = koeBOheoQaZPAqOTnfWdDiEAThyob;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								HZxfqrhGfMrNeKnfVghgdpwsxCcp();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = koeBOheoQaZPAqOTnfWdDiEAThyob;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								koeBOheoQaZPAqOTnfWdDiEAThyob = -3;
								goto IL_0086;
							}
							koeBOheoQaZPAqOTnfWdDiEAThyob = -1;
							vdzsiEMasBZUjnRWKUzQLUdmRnJI = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
							nCDQYXHWgGfWdzEbFRRqouFhtaMP = 0;
							goto IL_00b0;
							IL_0086:
							if (ZkpTFidwSriDNBHcbzJCELfTTavj.MoveNext())
							{
								ControllerPollingInfo current = ZkpTFidwSriDNBHcbzJCELfTTavj.Current;
								rYXHSjnAnGCkAzwRMzHmihOzfyMd = current;
								koeBOheoQaZPAqOTnfWdDiEAThyob = 1;
								return true;
							}
							HZxfqrhGfMrNeKnfVghgdpwsxCcp();
							ZkpTFidwSriDNBHcbzJCELfTTavj = null;
							nCDQYXHWgGfWdzEbFRRqouFhtaMP++;
							goto IL_00b0;
							IL_00b0:
							if (nCDQYXHWgGfWdzEbFRRqouFhtaMP < vdzsiEMasBZUjnRWKUzQLUdmRnJI.Count)
							{
								ZkpTFidwSriDNBHcbzJCELfTTavj = vdzsiEMasBZUjnRWKUzQLUdmRnJI[nCDQYXHWgGfWdzEbFRRqouFhtaMP].PollForAllElementsDown().GetEnumerator();
								koeBOheoQaZPAqOTnfWdDiEAThyob = -3;
								goto IL_0086;
							}
							return false;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void HZxfqrhGfMrNeKnfVghgdpwsxCcp()
					{
						koeBOheoQaZPAqOTnfWdDiEAThyob = -1;
						if (ZkpTFidwSriDNBHcbzJCELfTTavj != null)
						{
							ZkpTFidwSriDNBHcbzJCELfTTavj.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						if (koeBOheoQaZPAqOTnfWdDiEAThyob == -2 && gderNlYbAyHAJfiuRnSZNyqeCBzbb == Environment.CurrentManagedThreadId)
						{
							koeBOheoQaZPAqOTnfWdDiEAThyob = 0;
							return this;
						}
						return new vnlJFAbuhOBuvMJUJHWyAfYsywRg(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private static PollingHelper TTQLMBHMFXbCuDvvcWIzpNQKfunuA;

				internal static PollingHelper OZqcRXGjWOquzHKogvhdiPmBbgdJA => TTQLMBHMFXbCuDvvcWIzpNQKfunuA ?? (TTQLMBHMFXbCuDvvcWIzpNQKfunuA = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = gKSIPAuEmgdBrHQNcyaLHeESMSAF();
					if (result.success)
					{
						return result;
					}
					result = IxqpslkIVXTXfIuhcMGafqUxrYHQ();
					if (result.success)
					{
						return result;
					}
					result = GdVDtAMhVkBWotFDapWZWDNgdKxbA();
					if (result.success)
					{
						return result;
					}
					result = VSrGWLCiviqRySAiZhOAuDoXslATA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = KXdTNAJgISxlPAXatIePfinrHxkB();
					if (result.success)
					{
						return result;
					}
					result = iQdGfVDFreRAuWeKVpMPdcxpuiyCA();
					if (result.success)
					{
						return result;
					}
					result = STDoYSKYvhMeBJFjMDHrJKBWsqddA();
					if (result.success)
					{
						return result;
					}
					result = JMNrklTtpFuqxUMDJfGyBZTowIpv();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = lGQAlnsLDeAIGegQJQsrPuogvOQt();
					if (result.success)
					{
						return result;
					}
					result = IxqpslkIVXTXfIuhcMGafqUxrYHQ();
					if (result.success)
					{
						return result;
					}
					result = vtHFIQJaqeHnoFRDtfiESSYTQChHA();
					if (result.success)
					{
						return result;
					}
					result = QZzfJUcGqxXjYOhXIQuHkjROzsiKA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = UITtmsAoIyVmVeEXlXlPGQMKIMFx();
					if (result.success)
					{
						return result;
					}
					result = iQdGfVDFreRAuWeKVpMPdcxpuiyCA();
					if (result.success)
					{
						return result;
					}
					result = UcUcUyPNNpbsxTXLIdHDApTpidnJA();
					if (result.success)
					{
						return result;
					}
					result = ybWPadvnCYBUQgIlJxyqfeNwKKBib();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					ControllerPollingInfo result = LcJrvSsEyibfUcrpsUVAeULHQQZhA();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					if (result.success)
					{
						return result;
					}
					result = qLIgScftZaDgLxmXgCnxPXrkOFgp();
					if (result.success)
					{
						return result;
					}
					result = OJbYoeLTXdtchskDrMnuGfFIXEOR();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => gKSIPAuEmgdBrHQNcyaLHeESMSAF(), 
						ControllerType.Keyboard => IxqpslkIVXTXfIuhcMGafqUxrYHQ(), 
						ControllerType.Mouse => GdVDtAMhVkBWotFDapWZWDNgdKxbA(), 
						ControllerType.Custom => VSrGWLCiviqRySAiZhOAuDoXslATA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => KXdTNAJgISxlPAXatIePfinrHxkB(), 
						ControllerType.Keyboard => iQdGfVDFreRAuWeKVpMPdcxpuiyCA(), 
						ControllerType.Mouse => STDoYSKYvhMeBJFjMDHrJKBWsqddA(), 
						ControllerType.Custom => JMNrklTtpFuqxUMDJfGyBZTowIpv(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => lGQAlnsLDeAIGegQJQsrPuogvOQt(), 
						ControllerType.Keyboard => IxqpslkIVXTXfIuhcMGafqUxrYHQ(), 
						ControllerType.Mouse => vtHFIQJaqeHnoFRDtfiESSYTQChHA(), 
						ControllerType.Custom => QZzfJUcGqxXjYOhXIQuHkjROzsiKA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => UITtmsAoIyVmVeEXlXlPGQMKIMFx(), 
						ControllerType.Keyboard => iQdGfVDFreRAuWeKVpMPdcxpuiyCA(), 
						ControllerType.Mouse => UcUcUyPNNpbsxTXLIdHDApTpidnJA(), 
						ControllerType.Custom => ybWPadvnCYBUQgIlJxyqfeNwKKBib(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => LcJrvSsEyibfUcrpsUVAeULHQQZhA(), 
						ControllerType.Keyboard => ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA(), 
						ControllerType.Mouse => qLIgScftZaDgLxmXgCnxPXrkOFgp(), 
						ControllerType.Custom => OJbYoeLTXdtchskDrMnuGfFIXEOR(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => korXsOpAzcalrKNmqkIiCYOvHNdtA(controllerId), 
						ControllerType.Keyboard => IxqpslkIVXTXfIuhcMGafqUxrYHQ(), 
						ControllerType.Mouse => GdVDtAMhVkBWotFDapWZWDNgdKxbA(), 
						ControllerType.Custom => HOjpmdUteZFnrfMayLmFbHfTuhVG(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => vFoUUCfusJeSADSEFkMOTEAIsQQr(controllerId), 
						ControllerType.Keyboard => iQdGfVDFreRAuWeKVpMPdcxpuiyCA(), 
						ControllerType.Mouse => STDoYSKYvhMeBJFjMDHrJKBWsqddA(), 
						ControllerType.Custom => BdBXHZIWZQkdbpNfrtnDcgvMjvfy(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => YNPBprFxHAGjFahMAPErNOQnikeYb(controllerId), 
						ControllerType.Keyboard => IxqpslkIVXTXfIuhcMGafqUxrYHQ(), 
						ControllerType.Mouse => vtHFIQJaqeHnoFRDtfiESSYTQChHA(), 
						ControllerType.Custom => dzZbhDAnfBPoQJarOGMYkHtPIgluA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => ggPLDCTNxEunFkgVVFVdNzPBWVlF(controllerId), 
						ControllerType.Keyboard => iQdGfVDFreRAuWeKVpMPdcxpuiyCA(), 
						ControllerType.Mouse => UcUcUyPNNpbsxTXLIdHDApTpidnJA(), 
						ControllerType.Custom => zEAjHWkzKRyAiQDtwJPjIFeEFyJlB(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => oSHwXCoxeDaZRyezZHcqbxbzsSbw(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA(), 
						ControllerType.Mouse => qLIgScftZaDgLxmXgCnxPXrkOFgp(), 
						ControllerType.Custom => wykAcXQZIYfbZBzefwpenJLNnAOp(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				[IteratorStateMachine(typeof(WCzOAwDHWQqAArdZZbEgrraubrzH))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return new WCzOAwDHWQqAArdZZbEgrraubrzH(-2)
					{
						AhoKFLTBWGZDdbOutLqAMOCgsaUO = this
					};
				}

				[IteratorStateMachine(typeof(mDiYayNmQpKQbXJtlfLqFSziljshA))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return new mDiYayNmQpKQbXJtlfLqFSziljshA(-2)
					{
						ttPplasJaLsyaMyvnqTrJuwDDhZU = this
					};
				}

				[IteratorStateMachine(typeof(JcBofUKjAOcDUFjVUneIFgtnNJhy))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return new JcBofUKjAOcDUFjVUneIFgtnNJhy(-2)
					{
						UBJDxHdMlrmfrSjyTrcRbOQdOEPsA = this
					};
				}

				[IteratorStateMachine(typeof(TkuqNQYowBRuNABxEkVHzyyqDUsL))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return new TkuqNQYowBRuNABxEkVHzyyqDUsL(-2)
					{
						wQyvDCFfmxVYHiFgmXEWOvNQXYbD = this
					};
				}

				[IteratorStateMachine(typeof(lmyssPfgJPfavIteDsVZmDBogyGAb))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return new lmyssPfgJPfavIteDsVZmDBogyGAb(-2)
					{
						POjQlOqQdtjzwGvkqrMAOxJcCfsJ = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => cjmAVUTChBlZeOvHLRvGrJHEpddM(controllerId), 
						ControllerType.Keyboard => cwrYXfBTckFFSzJCtBjHgvXCqLUBb(), 
						ControllerType.Mouse => gPnFCMzEsgzGDKNeDZQeVvYnEOoF(), 
						ControllerType.Custom => IKDMUNCcXGmTKlbLkXAtGDXFmpUs(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => QhNoFWDQmzOZFvFwPVPcLmQQwYGw(controllerId), 
						ControllerType.Keyboard => XoIKsnNBOyzxArmlrdIrKVZwSRyG(), 
						ControllerType.Mouse => mdxhbVDNWGnFkXSSsSTDUrXooyNiA(), 
						ControllerType.Custom => tdRixJhcsDRVPOUlbNtJsWfHIsIKA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => aiestfLdcEDQFCDnMAexTHjTfBHYA(controllerId), 
						ControllerType.Keyboard => cwrYXfBTckFFSzJCtBjHgvXCqLUBb(), 
						ControllerType.Mouse => QKnENIYfMsHldhNrxQIuJGCyUxgQA(), 
						ControllerType.Custom => itvCgOCgXozqxhXlrdyugZnDitlvA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => illfQzwgEJLQnaDeOIQoFgqBpctbb(controllerId), 
						ControllerType.Keyboard => XoIKsnNBOyzxArmlrdIrKVZwSRyG(), 
						ControllerType.Mouse => iiuHutBddjajuhNYrZdOjPnuYdviA(), 
						ControllerType.Custom => iYoYDgJRtBRzpgJvdNqgIEWPgftKA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => mpdoMZglaJHrQrYRWsFPYvkOnaSU(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => dlYdYUFddiqtVkTarROIzJPNnFNC(), 
						ControllerType.Custom => bpxHPHOSchWqvzvPBkadnHlEfNlF(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo gKSIPAuEmgdBrHQNcyaLHeESMSAF()
				{
					IList<Joystick> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo KXdTNAJgISxlPAXatIePfinrHxkB()
				{
					IList<Joystick> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo lGQAlnsLDeAIGegQJQsrPuogvOQt()
				{
					IList<Joystick> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo UITtmsAoIyVmVeEXlXlPGQMKIMFx()
				{
					IList<Joystick> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo LcJrvSsEyibfUcrpsUVAeULHQQZhA()
				{
					IList<Joystick> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo korXsOpAzcalrKNmqkIiCYOvHNdtA(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo vFoUUCfusJeSADSEFkMOTEAIsQQr(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo YNPBprFxHAGjFahMAPErNOQnikeYb(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo ggPLDCTNxEunFkgVVFVdNzPBWVlF(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo oSHwXCoxeDaZRyezZHcqbxbzsSbw(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo IxqpslkIVXTXfIuhcMGafqUxrYHQ()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo iQdGfVDFreRAuWeKVpMPdcxpuiyCA()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo GdVDtAMhVkBWotFDapWZWDNgdKxbA()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo STDoYSKYvhMeBJFjMDHrJKBWsqddA()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo vtHFIQJaqeHnoFRDtfiESSYTQChHA()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo UcUcUyPNNpbsxTXLIdHDApTpidnJA()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo qLIgScftZaDgLxmXgCnxPXrkOFgp()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo VSrGWLCiviqRySAiZhOAuDoXslATA()
				{
					IList<CustomController> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo JMNrklTtpFuqxUMDJfGyBZTowIpv()
				{
					IList<CustomController> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo QZzfJUcGqxXjYOhXIQuHkjROzsiKA()
				{
					IList<CustomController> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo ybWPadvnCYBUQgIlJxyqfeNwKKBib()
				{
					IList<CustomController> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo OJbYoeLTXdtchskDrMnuGfFIXEOR()
				{
					IList<CustomController> list = zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo HOjpmdUteZFnrfMayLmFbHfTuhVG(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo BdBXHZIWZQkdbpNfrtnDcgvMjvfy(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo dzZbhDAnfBPoQJarOGMYkHtPIgluA(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo zEAjHWkzKRyAiQDtwJPjIFeEFyJlB(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				private ControllerPollingInfo wykAcXQZIYfbZBzefwpenJLNnAOp(int P_0)
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
				}

				[IteratorStateMachine(typeof(dhcDyUNbwecFNFPcwlXZVSxdxTUEA))]
				private IEnumerable<ControllerPollingInfo> WijetqDBXTquftMOloOiGDQEurvlB()
				{
					return new dhcDyUNbwecFNFPcwlXZVSxdxTUEA(-2);
				}

				[IteratorStateMachine(typeof(vnlJFAbuhOBuvMJUJHWyAfYsywRg))]
				private IEnumerable<ControllerPollingInfo> APRCcbmutxeBsaCvGFlAOelFXCQWA()
				{
					return new vnlJFAbuhOBuvMJUJHWyAfYsywRg(-2);
				}

				[IteratorStateMachine(typeof(cbsPaXSTbUGtmKWEkwdbDcoScitO))]
				private IEnumerable<ControllerPollingInfo> LBWmmyVFOTZHLxLQYZaMkxUpPhYG()
				{
					return new cbsPaXSTbUGtmKWEkwdbDcoScitO(-2);
				}

				[IteratorStateMachine(typeof(JPurJxusHEtgPReebXSNkJcWKzsj))]
				private IEnumerable<ControllerPollingInfo> QtiDmKPRQYfRrpxGVXOuJCpfuSXU()
				{
					return new JPurJxusHEtgPReebXSNkJcWKzsj(-2);
				}

				[IteratorStateMachine(typeof(WyGPUcmxzadBsNCGqOMDadegLPgW))]
				private IEnumerable<ControllerPollingInfo> peBRgicahMCGbDnqGbTnOpTblIDN()
				{
					return new WyGPUcmxzadBsNCGqOMDadegLPgW(-2);
				}

				private IEnumerable<ControllerPollingInfo> cjmAVUTChBlZeOvHLRvGrJHEpddM(int P_0)
				{
					Joystick joystick = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> QhNoFWDQmzOZFvFwPVPcLmQQwYGw(int P_0)
				{
					Joystick joystick = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> aiestfLdcEDQFCDnMAexTHjTfBHYA(int P_0)
				{
					Joystick joystick = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> illfQzwgEJLQnaDeOIQoFgqBpctbb(int P_0)
				{
					Joystick joystick = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> mpdoMZglaJHrQrYRWsFPYvkOnaSU(int P_0)
				{
					Joystick joystick = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> cwrYXfBTckFFSzJCtBjHgvXCqLUBb()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> XoIKsnNBOyzxArmlrdIrKVZwSRyG()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> gPnFCMzEsgzGDKNeDZQeVvYnEOoF()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> mdxhbVDNWGnFkXSSsSTDUrXooyNiA()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> QKnENIYfMsHldhNrxQIuJGCyUxgQA()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> iiuHutBddjajuhNYrZdOjPnuYdviA()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> dlYdYUFddiqtVkTarROIzJPNnFNC()
				{
					return zaUMUBCFRABoiglmiIrrAHgUrbsy.Mouse.PollForAllAxes();
				}

				[IteratorStateMachine(typeof(ofQYdCBnYImRmBhBMcamIBXpDfunA))]
				private IEnumerable<ControllerPollingInfo> yFRDiMHeihamVFnfQDZHhaIojumi()
				{
					return new ofQYdCBnYImRmBhBMcamIBXpDfunA(-2);
				}

				[IteratorStateMachine(typeof(ItMESKSwVMfxJyvMQhapBWSNBUmXA))]
				private IEnumerable<ControllerPollingInfo> uZCbVYGzbufaYtlBKyikMrLyMpNYA()
				{
					return new ItMESKSwVMfxJyvMQhapBWSNBUmXA(-2);
				}

				[IteratorStateMachine(typeof(IJilhHzPDYiJpGqKLRyqiapAqcIhb))]
				private IEnumerable<ControllerPollingInfo> PDxhcMFNZRgyLnulfhjhSatuIaEbb()
				{
					return new IJilhHzPDYiJpGqKLRyqiapAqcIhb(-2);
				}

				[IteratorStateMachine(typeof(ZxHbLFLSQxJShqbNDgkyFIwSqVIVA))]
				private IEnumerable<ControllerPollingInfo> NmJTRLEUErCJmMCSTQVEzBLJzgNN()
				{
					return new ZxHbLFLSQxJShqbNDgkyFIwSqVIVA(-2);
				}

				[IteratorStateMachine(typeof(uljnsMxanxvWvPubzIaFHovcQyRj))]
				private IEnumerable<ControllerPollingInfo> bOgqPlHGPshmgaKACaGQvAmEodEl()
				{
					return new uljnsMxanxvWvPubzIaFHovcQyRj(-2);
				}

				private IEnumerable<ControllerPollingInfo> IKDMUNCcXGmTKlbLkXAtGDXFmpUs(int P_0)
				{
					CustomController customController = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> tdRixJhcsDRVPOUlbNtJsWfHIsIKA(int P_0)
				{
					CustomController customController = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> itvCgOCgXozqxhXlrdyugZnDitlvA(int P_0)
				{
					CustomController customController = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> iYoYDgJRtBRzpgJvdNqgIEWPgftKA(int P_0)
				{
					CustomController customController = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> bpxHPHOSchWqvzvPBkadnHlEfNlF(int P_0)
				{
					CustomController customController = zaUMUBCFRABoiglmiIrrAHgUrbsy.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllAxes();
				}
			}

			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class IFlcBDZupEfXERqtKJyUJaicHlIs : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int AOEluYpBvTofzDvclKOAUFFHzjaO;

					private ElementAssignmentConflictInfo ekLIuRoKgPCRzrbKJDMSZHoTuPSs;

					private int YhhTkvbhyMVjKsdhEgBhrWTJgdtS;

					private int SRnNQeHQHapNbSFTTCRdEJtaONUaA;

					public int YeLakfbIiDPemwHsjMMqiXAFbBlQb;

					private ActionElementMap NsXeYxPEAZNdUrajxgIsgLTbRMkPA;

					public ActionElementMap bHyExYNoDVcFQdSHLULwMOeJtursA;

					private bool eRFhmXFHLkkNHkFcuEhsjpKabWmDb;

					public bool QXNENePbZQIcGiEtEPshfuKROhzG;

					private int zoXMAyVyvJblVfGPnABpYfhGjFoP;

					public int rVGKQnvRotGpkQbAhHXWcSaOAmRL;

					private CustomControllerMap ieJhsXAqVAstrlwbsfTOafkexEWmA;

					public CustomControllerMap XIqNXgHxMQdDszGmJldAUfCNVYyg;

					private bool VnQaddAujOjSHYtkJnlantlzkrBkA;

					public bool WRZGVAldZLFamJGpUoinkcmgiddEA;

					private bool YJFkrvPYSNuvULqlbrNLtBfOfhKdA;

					public bool rwqsTkyegElnjTioNgDHJhdSSpCEA;

					private IList<Player> OmNbPCXFoSHXSQnWgMoursIIhURX;

					private int ayKfWZHagSrGYgizHNlCHIZuqQBZA;

					private IEnumerator<ElementAssignmentConflictInfo> vGrcsxJcOaLpHhYKBLeNHEZAJzVnc;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ekLIuRoKgPCRzrbKJDMSZHoTuPSs;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ekLIuRoKgPCRzrbKJDMSZHoTuPSs;
						}
					}

					[DebuggerHidden]
					public IFlcBDZupEfXERqtKJyUJaicHlIs(int P_0)
					{
						AOEluYpBvTofzDvclKOAUFFHzjaO = P_0;
						YhhTkvbhyMVjKsdhEgBhrWTJgdtS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int aOEluYpBvTofzDvclKOAUFFHzjaO = AOEluYpBvTofzDvclKOAUFFHzjaO;
						if (aOEluYpBvTofzDvclKOAUFFHzjaO == -3 || aOEluYpBvTofzDvclKOAUFFHzjaO == 1)
						{
							try
							{
							}
							finally
							{
								PGGDidZBdLBDBtjljfwBJWfRjBwf();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int aOEluYpBvTofzDvclKOAUFFHzjaO = AOEluYpBvTofzDvclKOAUFFHzjaO;
							if (aOEluYpBvTofzDvclKOAUFFHzjaO != 0)
							{
								if (aOEluYpBvTofzDvclKOAUFFHzjaO != 1)
								{
									return false;
								}
								AOEluYpBvTofzDvclKOAUFFHzjaO = -3;
								goto IL_00e2;
							}
							AOEluYpBvTofzDvclKOAUFFHzjaO = -1;
							if (SRnNQeHQHapNbSFTTCRdEJtaONUaA < 0 || NsXeYxPEAZNdUrajxgIsgLTbRMkPA == null)
							{
								return false;
							}
							OmNbPCXFoSHXSQnWgMoursIIhURX = (eRFhmXFHLkkNHkFcuEhsjpKabWmDb ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
							ayKfWZHagSrGYgizHNlCHIZuqQBZA = 0;
							goto IL_010c;
							IL_010c:
							if (ayKfWZHagSrGYgizHNlCHIZuqQBZA < OmNbPCXFoSHXSQnWgMoursIIhURX.Count)
							{
								vGrcsxJcOaLpHhYKBLeNHEZAJzVnc = OmNbPCXFoSHXSQnWgMoursIIhURX[ayKfWZHagSrGYgizHNlCHIZuqQBZA].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, zoXMAyVyvJblVfGPnABpYfhGjFoP, ieJhsXAqVAstrlwbsfTOafkexEWmA, NsXeYxPEAZNdUrajxgIsgLTbRMkPA, VnQaddAujOjSHYtkJnlantlzkrBkA, YJFkrvPYSNuvULqlbrNLtBfOfhKdA).GetEnumerator();
								AOEluYpBvTofzDvclKOAUFFHzjaO = -3;
								goto IL_00e2;
							}
							return false;
							IL_00e2:
							if (vGrcsxJcOaLpHhYKBLeNHEZAJzVnc.MoveNext())
							{
								ElementAssignmentConflictInfo current = vGrcsxJcOaLpHhYKBLeNHEZAJzVnc.Current;
								ekLIuRoKgPCRzrbKJDMSZHoTuPSs = current;
								AOEluYpBvTofzDvclKOAUFFHzjaO = 1;
								return true;
							}
							PGGDidZBdLBDBtjljfwBJWfRjBwf();
							vGrcsxJcOaLpHhYKBLeNHEZAJzVnc = null;
							ayKfWZHagSrGYgizHNlCHIZuqQBZA++;
							goto IL_010c;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void PGGDidZBdLBDBtjljfwBJWfRjBwf()
					{
						AOEluYpBvTofzDvclKOAUFFHzjaO = -1;
						if (vGrcsxJcOaLpHhYKBLeNHEZAJzVnc != null)
						{
							vGrcsxJcOaLpHhYKBLeNHEZAJzVnc.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						IFlcBDZupEfXERqtKJyUJaicHlIs flcBDZupEfXERqtKJyUJaicHlIs;
						if (AOEluYpBvTofzDvclKOAUFFHzjaO == -2 && YhhTkvbhyMVjKsdhEgBhrWTJgdtS == Environment.CurrentManagedThreadId)
						{
							AOEluYpBvTofzDvclKOAUFFHzjaO = 0;
							flcBDZupEfXERqtKJyUJaicHlIs = this;
						}
						else
						{
							flcBDZupEfXERqtKJyUJaicHlIs = new IFlcBDZupEfXERqtKJyUJaicHlIs(0);
						}
						flcBDZupEfXERqtKJyUJaicHlIs.SRnNQeHQHapNbSFTTCRdEJtaONUaA = YeLakfbIiDPemwHsjMMqiXAFbBlQb;
						flcBDZupEfXERqtKJyUJaicHlIs.zoXMAyVyvJblVfGPnABpYfhGjFoP = rVGKQnvRotGpkQbAhHXWcSaOAmRL;
						flcBDZupEfXERqtKJyUJaicHlIs.ieJhsXAqVAstrlwbsfTOafkexEWmA = XIqNXgHxMQdDszGmJldAUfCNVYyg;
						flcBDZupEfXERqtKJyUJaicHlIs.NsXeYxPEAZNdUrajxgIsgLTbRMkPA = bHyExYNoDVcFQdSHLULwMOeJtursA;
						flcBDZupEfXERqtKJyUJaicHlIs.VnQaddAujOjSHYtkJnlantlzkrBkA = WRZGVAldZLFamJGpUoinkcmgiddEA;
						flcBDZupEfXERqtKJyUJaicHlIs.YJFkrvPYSNuvULqlbrNLtBfOfhKdA = rwqsTkyegElnjTioNgDHJhdSSpCEA;
						flcBDZupEfXERqtKJyUJaicHlIs.eRFhmXFHLkkNHkFcuEhsjpKabWmDb = QXNENePbZQIcGiEtEPshfuKROhzG;
						return flcBDZupEfXERqtKJyUJaicHlIs;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class dxXdfZwwavhBGcSxmKGPTmWMSxsn : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int UldCEfCrtGfNqWbrJPVXyaMKRYukA;

					private ElementAssignmentConflictInfo CGBOlxxvoaLedZtCBoPWumlPeAAM;

					private int pGdvMXrLJhcOYHvcIlxCYbQCXpuK;

					private ElementAssignmentConflictCheck VEtReRhuvENzudHISRhqMeaFYFbV;

					public ElementAssignmentConflictCheck ngWYwNHZbjEJyTEOoXgfnEWpGbAEA;

					private bool atSRJPklENXwnXpBFigDUbwDTQfv;

					public bool RTwsSEMetAbFEiPCvPaTgodcECEnc;

					private bool WkhmjkjeVClWVVMnJjpSrMxfalljA;

					public bool YvefnAKQbJKejFxCiRXKgxLcHBjdE;

					private bool AlSZgcNjkitDeludwKcqFQjwUnAo;

					public bool KAyaqRfSWiloLxHtVqwPxojPuneJ;

					private IList<Player> vWiIZaGNjAeUfrgPoTOLlPmNNCGQ;

					private int sTyTKKTZSkcLKanlVXeLEnULLTgV;

					private IEnumerator<ElementAssignmentConflictInfo> bfIicRDwnrkvfIQuVpEfqAHkZPX;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return CGBOlxxvoaLedZtCBoPWumlPeAAM;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return CGBOlxxvoaLedZtCBoPWumlPeAAM;
						}
					}

					[DebuggerHidden]
					public dxXdfZwwavhBGcSxmKGPTmWMSxsn(int P_0)
					{
						UldCEfCrtGfNqWbrJPVXyaMKRYukA = P_0;
						pGdvMXrLJhcOYHvcIlxCYbQCXpuK = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int uldCEfCrtGfNqWbrJPVXyaMKRYukA = UldCEfCrtGfNqWbrJPVXyaMKRYukA;
						if (uldCEfCrtGfNqWbrJPVXyaMKRYukA == -3 || uldCEfCrtGfNqWbrJPVXyaMKRYukA == 1)
						{
							try
							{
							}
							finally
							{
								YFgXaVttRbLVnFrooHiptSSSGOmG();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int uldCEfCrtGfNqWbrJPVXyaMKRYukA = UldCEfCrtGfNqWbrJPVXyaMKRYukA;
							if (uldCEfCrtGfNqWbrJPVXyaMKRYukA != 0)
							{
								if (uldCEfCrtGfNqWbrJPVXyaMKRYukA != 1)
								{
									return false;
								}
								UldCEfCrtGfNqWbrJPVXyaMKRYukA = -3;
								goto IL_00df;
							}
							UldCEfCrtGfNqWbrJPVXyaMKRYukA = -1;
							if (VEtReRhuvENzudHISRhqMeaFYFbV.playerId < 0 || VEtReRhuvENzudHISRhqMeaFYFbV.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							vWiIZaGNjAeUfrgPoTOLlPmNNCGQ = (atSRJPklENXwnXpBFigDUbwDTQfv ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
							sTyTKKTZSkcLKanlVXeLEnULLTgV = 0;
							goto IL_0109;
							IL_0109:
							if (sTyTKKTZSkcLKanlVXeLEnULLTgV < vWiIZaGNjAeUfrgPoTOLlPmNNCGQ.Count)
							{
								bfIicRDwnrkvfIQuVpEfqAHkZPX = vWiIZaGNjAeUfrgPoTOLlPmNNCGQ[sTyTKKTZSkcLKanlVXeLEnULLTgV].controllers.conflictChecking.ElementAssignmentConflicts(VEtReRhuvENzudHISRhqMeaFYFbV, WkhmjkjeVClWVVMnJjpSrMxfalljA, AlSZgcNjkitDeludwKcqFQjwUnAo).GetEnumerator();
								UldCEfCrtGfNqWbrJPVXyaMKRYukA = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (bfIicRDwnrkvfIQuVpEfqAHkZPX.MoveNext())
							{
								ElementAssignmentConflictInfo current = bfIicRDwnrkvfIQuVpEfqAHkZPX.Current;
								CGBOlxxvoaLedZtCBoPWumlPeAAM = current;
								UldCEfCrtGfNqWbrJPVXyaMKRYukA = 1;
								return true;
							}
							YFgXaVttRbLVnFrooHiptSSSGOmG();
							bfIicRDwnrkvfIQuVpEfqAHkZPX = null;
							sTyTKKTZSkcLKanlVXeLEnULLTgV++;
							goto IL_0109;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void YFgXaVttRbLVnFrooHiptSSSGOmG()
					{
						UldCEfCrtGfNqWbrJPVXyaMKRYukA = -1;
						if (bfIicRDwnrkvfIQuVpEfqAHkZPX != null)
						{
							bfIicRDwnrkvfIQuVpEfqAHkZPX.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						dxXdfZwwavhBGcSxmKGPTmWMSxsn dxXdfZwwavhBGcSxmKGPTmWMSxsn2;
						if (UldCEfCrtGfNqWbrJPVXyaMKRYukA == -2 && pGdvMXrLJhcOYHvcIlxCYbQCXpuK == Environment.CurrentManagedThreadId)
						{
							UldCEfCrtGfNqWbrJPVXyaMKRYukA = 0;
							dxXdfZwwavhBGcSxmKGPTmWMSxsn2 = this;
						}
						else
						{
							dxXdfZwwavhBGcSxmKGPTmWMSxsn2 = new dxXdfZwwavhBGcSxmKGPTmWMSxsn(0);
						}
						dxXdfZwwavhBGcSxmKGPTmWMSxsn2.VEtReRhuvENzudHISRhqMeaFYFbV = ngWYwNHZbjEJyTEOoXgfnEWpGbAEA;
						dxXdfZwwavhBGcSxmKGPTmWMSxsn2.WkhmjkjeVClWVVMnJjpSrMxfalljA = YvefnAKQbJKejFxCiRXKgxLcHBjdE;
						dxXdfZwwavhBGcSxmKGPTmWMSxsn2.AlSZgcNjkitDeludwKcqFQjwUnAo = KAyaqRfSWiloLxHtVqwPxojPuneJ;
						dxXdfZwwavhBGcSxmKGPTmWMSxsn2.atSRJPklENXwnXpBFigDUbwDTQfv = RTwsSEMetAbFEiPCvPaTgodcECEnc;
						return dxXdfZwwavhBGcSxmKGPTmWMSxsn2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class NBpRSBKidUqyDNfSrkAFRHVgBrHEA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ubNASHHKBzeHYAcwcqWTjDTYpZLHb;

					private ElementAssignmentConflictInfo KbyrBmouEXBbmfcUdSfPcYotqWbj;

					private int BPTwnbKSSbaytDBDNmiMxcfzIVueb;

					private int KCfGbBCRLRAjqweNwBPshWNzTGmEb;

					public int sYMPlxrHsyjsqurrDPdvgHAtrTSd;

					private ActionElementMap ZDHtkkeahJDkpJOuWjAxRlbbigBe;

					public ActionElementMap btAsbMJSgoVbkHopgfWgBYPMGAAeA;

					private bool CIzNvGnZKxvkgeFExpljNLYSfrIV;

					public bool gnRBWouHZpanKsRKuUwBDgaLNSdV;

					private int iPwBCpmWdZnWnEOielMyOBvIcfBkA;

					public int kAVUekuWSRfHdpSsNIKJaVNnPOD;

					private JoystickMap MmObfjTvJIBpaHFNSAmnBGEHyinib;

					public JoystickMap fXEAJsOlZWGGdTfSIXhjZvRaGYew;

					private bool rkATmFpclBgiEEqVANmhEqCOpodjA;

					public bool wLLXJVaoiUGOWXAjMipMeynvFGHW;

					private bool sAJfroEwHZYDuJNVoCKELyvYVdhH;

					public bool vAsDIyaupsmnCHpYxckFJEpzYrUpA;

					private IList<Player> blbYnGHwIlyJDuIlkdBvugUwJqYE;

					private int bhZtSNGHQNttZgaQRQKLYTwgqQXe;

					private IEnumerator<ElementAssignmentConflictInfo> cIQeVSgovXGYsjuYfJTyCOfEckby;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return KbyrBmouEXBbmfcUdSfPcYotqWbj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KbyrBmouEXBbmfcUdSfPcYotqWbj;
						}
					}

					[DebuggerHidden]
					public NBpRSBKidUqyDNfSrkAFRHVgBrHEA(int P_0)
					{
						ubNASHHKBzeHYAcwcqWTjDTYpZLHb = P_0;
						BPTwnbKSSbaytDBDNmiMxcfzIVueb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ubNASHHKBzeHYAcwcqWTjDTYpZLHb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								jvDDLdNJUFfuovjJpEwmIGZVcddY();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = ubNASHHKBzeHYAcwcqWTjDTYpZLHb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								ubNASHHKBzeHYAcwcqWTjDTYpZLHb = -3;
								goto IL_00e1;
							}
							ubNASHHKBzeHYAcwcqWTjDTYpZLHb = -1;
							if (KCfGbBCRLRAjqweNwBPshWNzTGmEb < 0 || ZDHtkkeahJDkpJOuWjAxRlbbigBe == null)
							{
								return false;
							}
							blbYnGHwIlyJDuIlkdBvugUwJqYE = (CIzNvGnZKxvkgeFExpljNLYSfrIV ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
							bhZtSNGHQNttZgaQRQKLYTwgqQXe = 0;
							goto IL_010b;
							IL_010b:
							if (bhZtSNGHQNttZgaQRQKLYTwgqQXe < blbYnGHwIlyJDuIlkdBvugUwJqYE.Count)
							{
								cIQeVSgovXGYsjuYfJTyCOfEckby = blbYnGHwIlyJDuIlkdBvugUwJqYE[bhZtSNGHQNttZgaQRQKLYTwgqQXe].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, iPwBCpmWdZnWnEOielMyOBvIcfBkA, MmObfjTvJIBpaHFNSAmnBGEHyinib, ZDHtkkeahJDkpJOuWjAxRlbbigBe, rkATmFpclBgiEEqVANmhEqCOpodjA, sAJfroEwHZYDuJNVoCKELyvYVdhH).GetEnumerator();
								ubNASHHKBzeHYAcwcqWTjDTYpZLHb = -3;
								goto IL_00e1;
							}
							return false;
							IL_00e1:
							if (cIQeVSgovXGYsjuYfJTyCOfEckby.MoveNext())
							{
								ElementAssignmentConflictInfo current = cIQeVSgovXGYsjuYfJTyCOfEckby.Current;
								KbyrBmouEXBbmfcUdSfPcYotqWbj = current;
								ubNASHHKBzeHYAcwcqWTjDTYpZLHb = 1;
								return true;
							}
							jvDDLdNJUFfuovjJpEwmIGZVcddY();
							cIQeVSgovXGYsjuYfJTyCOfEckby = null;
							bhZtSNGHQNttZgaQRQKLYTwgqQXe++;
							goto IL_010b;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void jvDDLdNJUFfuovjJpEwmIGZVcddY()
					{
						ubNASHHKBzeHYAcwcqWTjDTYpZLHb = -1;
						if (cIQeVSgovXGYsjuYfJTyCOfEckby != null)
						{
							cIQeVSgovXGYsjuYfJTyCOfEckby.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						NBpRSBKidUqyDNfSrkAFRHVgBrHEA nBpRSBKidUqyDNfSrkAFRHVgBrHEA;
						if (ubNASHHKBzeHYAcwcqWTjDTYpZLHb == -2 && BPTwnbKSSbaytDBDNmiMxcfzIVueb == Environment.CurrentManagedThreadId)
						{
							ubNASHHKBzeHYAcwcqWTjDTYpZLHb = 0;
							nBpRSBKidUqyDNfSrkAFRHVgBrHEA = this;
						}
						else
						{
							nBpRSBKidUqyDNfSrkAFRHVgBrHEA = new NBpRSBKidUqyDNfSrkAFRHVgBrHEA(0);
						}
						nBpRSBKidUqyDNfSrkAFRHVgBrHEA.KCfGbBCRLRAjqweNwBPshWNzTGmEb = sYMPlxrHsyjsqurrDPdvgHAtrTSd;
						nBpRSBKidUqyDNfSrkAFRHVgBrHEA.iPwBCpmWdZnWnEOielMyOBvIcfBkA = kAVUekuWSRfHdpSsNIKJaVNnPOD;
						nBpRSBKidUqyDNfSrkAFRHVgBrHEA.MmObfjTvJIBpaHFNSAmnBGEHyinib = fXEAJsOlZWGGdTfSIXhjZvRaGYew;
						nBpRSBKidUqyDNfSrkAFRHVgBrHEA.ZDHtkkeahJDkpJOuWjAxRlbbigBe = btAsbMJSgoVbkHopgfWgBYPMGAAeA;
						nBpRSBKidUqyDNfSrkAFRHVgBrHEA.rkATmFpclBgiEEqVANmhEqCOpodjA = wLLXJVaoiUGOWXAjMipMeynvFGHW;
						nBpRSBKidUqyDNfSrkAFRHVgBrHEA.sAJfroEwHZYDuJNVoCKELyvYVdhH = vAsDIyaupsmnCHpYxckFJEpzYrUpA;
						nBpRSBKidUqyDNfSrkAFRHVgBrHEA.CIzNvGnZKxvkgeFExpljNLYSfrIV = gnRBWouHZpanKsRKuUwBDgaLNSdV;
						return nBpRSBKidUqyDNfSrkAFRHVgBrHEA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class uTNlEcFnqpNVzJCgMsGqPBeOumBE : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ciFtwUZeSfhgAMUESBarlkmvayeX;

					private ElementAssignmentConflictInfo otPtMvtnBKbbetncILWRvcmWHNhV;

					private int qiwagHeFxUdOlbyfcgfTNGQAyfGrE;

					private ElementAssignmentConflictCheck EblbvCEvIgVmzqEfGqKHrpvbFlgfb;

					public ElementAssignmentConflictCheck eYVNNKZqCfMizYDLJEeBJmKqcOOMA;

					private bool wAkyTBWPMyNijggLnjIKIEIuAdMCA;

					public bool CnGcnJZioCWrmnIdQyTyquqPIPEw;

					private bool fgcVjchgMAHAHiSpUaQlrHnjFhnf;

					public bool cEHwFZiwphfHmFXgbKuOdSGRuomW;

					private bool hptInVrzwjIPjiryQnBbtDZsxLxn;

					public bool FqrZeHkyGwPiCkcHAROPIOIkegMS;

					private IList<Player> SfLlBlOZrOjLRIepdIqfanMHpmQAb;

					private int RNcCfQIbeDQYFSEQGdFMCAeJfmJCB;

					private IEnumerator<ElementAssignmentConflictInfo> MkYHxyunRHnepTVEdCYuKcBWiBei;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return otPtMvtnBKbbetncILWRvcmWHNhV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return otPtMvtnBKbbetncILWRvcmWHNhV;
						}
					}

					[DebuggerHidden]
					public uTNlEcFnqpNVzJCgMsGqPBeOumBE(int P_0)
					{
						ciFtwUZeSfhgAMUESBarlkmvayeX = P_0;
						qiwagHeFxUdOlbyfcgfTNGQAyfGrE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ciFtwUZeSfhgAMUESBarlkmvayeX;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								dfGSFMEToxOvRlbdrGWYrNosIalI();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = ciFtwUZeSfhgAMUESBarlkmvayeX;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								ciFtwUZeSfhgAMUESBarlkmvayeX = -3;
								goto IL_00df;
							}
							ciFtwUZeSfhgAMUESBarlkmvayeX = -1;
							if (EblbvCEvIgVmzqEfGqKHrpvbFlgfb.playerId < 0 || EblbvCEvIgVmzqEfGqKHrpvbFlgfb.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							SfLlBlOZrOjLRIepdIqfanMHpmQAb = (wAkyTBWPMyNijggLnjIKIEIuAdMCA ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
							RNcCfQIbeDQYFSEQGdFMCAeJfmJCB = 0;
							goto IL_0109;
							IL_0109:
							if (RNcCfQIbeDQYFSEQGdFMCAeJfmJCB < SfLlBlOZrOjLRIepdIqfanMHpmQAb.Count)
							{
								MkYHxyunRHnepTVEdCYuKcBWiBei = SfLlBlOZrOjLRIepdIqfanMHpmQAb[RNcCfQIbeDQYFSEQGdFMCAeJfmJCB].controllers.conflictChecking.ElementAssignmentConflicts(EblbvCEvIgVmzqEfGqKHrpvbFlgfb, fgcVjchgMAHAHiSpUaQlrHnjFhnf, hptInVrzwjIPjiryQnBbtDZsxLxn).GetEnumerator();
								ciFtwUZeSfhgAMUESBarlkmvayeX = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (MkYHxyunRHnepTVEdCYuKcBWiBei.MoveNext())
							{
								ElementAssignmentConflictInfo current = MkYHxyunRHnepTVEdCYuKcBWiBei.Current;
								otPtMvtnBKbbetncILWRvcmWHNhV = current;
								ciFtwUZeSfhgAMUESBarlkmvayeX = 1;
								return true;
							}
							dfGSFMEToxOvRlbdrGWYrNosIalI();
							MkYHxyunRHnepTVEdCYuKcBWiBei = null;
							RNcCfQIbeDQYFSEQGdFMCAeJfmJCB++;
							goto IL_0109;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void dfGSFMEToxOvRlbdrGWYrNosIalI()
					{
						ciFtwUZeSfhgAMUESBarlkmvayeX = -1;
						if (MkYHxyunRHnepTVEdCYuKcBWiBei != null)
						{
							MkYHxyunRHnepTVEdCYuKcBWiBei.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						uTNlEcFnqpNVzJCgMsGqPBeOumBE uTNlEcFnqpNVzJCgMsGqPBeOumBE2;
						if (ciFtwUZeSfhgAMUESBarlkmvayeX == -2 && qiwagHeFxUdOlbyfcgfTNGQAyfGrE == Environment.CurrentManagedThreadId)
						{
							ciFtwUZeSfhgAMUESBarlkmvayeX = 0;
							uTNlEcFnqpNVzJCgMsGqPBeOumBE2 = this;
						}
						else
						{
							uTNlEcFnqpNVzJCgMsGqPBeOumBE2 = new uTNlEcFnqpNVzJCgMsGqPBeOumBE(0);
						}
						uTNlEcFnqpNVzJCgMsGqPBeOumBE2.EblbvCEvIgVmzqEfGqKHrpvbFlgfb = eYVNNKZqCfMizYDLJEeBJmKqcOOMA;
						uTNlEcFnqpNVzJCgMsGqPBeOumBE2.fgcVjchgMAHAHiSpUaQlrHnjFhnf = cEHwFZiwphfHmFXgbKuOdSGRuomW;
						uTNlEcFnqpNVzJCgMsGqPBeOumBE2.hptInVrzwjIPjiryQnBbtDZsxLxn = FqrZeHkyGwPiCkcHAROPIOIkegMS;
						uTNlEcFnqpNVzJCgMsGqPBeOumBE2.wAkyTBWPMyNijggLnjIKIEIuAdMCA = CnGcnJZioCWrmnIdQyTyquqPIPEw;
						return uTNlEcFnqpNVzJCgMsGqPBeOumBE2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class hMFeFLuLNvdPqlAdRQrliMDqPpYf : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int IKNoCjqYzqcJkkfnOtLTVfJDxEtT;

					private ElementAssignmentConflictInfo NEaaOicydVSGyRFdOqDqvecOMbqDA;

					private int jLVdifGPHqKuEIkJCVhotsdVqEreb;

					private int OiqpMZSNGdbneVLKTQPcPFqgUjkm;

					public int aYMRQgGQrNjlfglktFuvrkfQZAyp;

					private ActionElementMap YhGFGaCQwZMnmujWxIUXFxvPxMLh;

					public ActionElementMap JYyePFOiapBilJXVDWwtemyVmdYf;

					private bool fsrXhkHEqgBigfBsKmZpJMPrEsPRA;

					public bool TlKQofiTboCXZswJyetrujIVFjKcA;

					private KeyboardMap XsidDmMGCthhWaxfLVeZaCdNvohvA;

					public KeyboardMap tZPLfsULBwDHEbDcWwRzmHuFtYHr;

					private bool mmcEMALPLHqSDKPqdrMxABeNhlhW;

					public bool aHMdmtgPhwkifgZCchRIpgSEnrsMc;

					private bool VyPowSEpBErXydLIXlguTRBvvKPD;

					public bool yWpYyQELCcAniMqWugcOElAUuemjA;

					private IList<Player> kfucJteKGQAklAenXsyXFCuhtjkdA;

					private int IosMoLBHLZsLYmosnkgLaYQqttLk;

					private IEnumerator<ElementAssignmentConflictInfo> ttptdTYdKHWAgOcZUaoFmBJyDgwP;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return NEaaOicydVSGyRFdOqDqvecOMbqDA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NEaaOicydVSGyRFdOqDqvecOMbqDA;
						}
					}

					[DebuggerHidden]
					public hMFeFLuLNvdPqlAdRQrliMDqPpYf(int P_0)
					{
						IKNoCjqYzqcJkkfnOtLTVfJDxEtT = P_0;
						jLVdifGPHqKuEIkJCVhotsdVqEreb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int iKNoCjqYzqcJkkfnOtLTVfJDxEtT = IKNoCjqYzqcJkkfnOtLTVfJDxEtT;
						if (iKNoCjqYzqcJkkfnOtLTVfJDxEtT == -3 || iKNoCjqYzqcJkkfnOtLTVfJDxEtT == 1)
						{
							try
							{
							}
							finally
							{
								ZpxEqVJyiIauNjkeyFbuQjOKCOpo();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int iKNoCjqYzqcJkkfnOtLTVfJDxEtT = IKNoCjqYzqcJkkfnOtLTVfJDxEtT;
							if (iKNoCjqYzqcJkkfnOtLTVfJDxEtT != 0)
							{
								if (iKNoCjqYzqcJkkfnOtLTVfJDxEtT != 1)
								{
									return false;
								}
								IKNoCjqYzqcJkkfnOtLTVfJDxEtT = -3;
								goto IL_00dc;
							}
							IKNoCjqYzqcJkkfnOtLTVfJDxEtT = -1;
							if (OiqpMZSNGdbneVLKTQPcPFqgUjkm < 0 || YhGFGaCQwZMnmujWxIUXFxvPxMLh == null)
							{
								return false;
							}
							kfucJteKGQAklAenXsyXFCuhtjkdA = (fsrXhkHEqgBigfBsKmZpJMPrEsPRA ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
							IosMoLBHLZsLYmosnkgLaYQqttLk = 0;
							goto IL_0106;
							IL_0106:
							if (IosMoLBHLZsLYmosnkgLaYQqttLk < kfucJteKGQAklAenXsyXFCuhtjkdA.Count)
							{
								ttptdTYdKHWAgOcZUaoFmBJyDgwP = kfucJteKGQAklAenXsyXFCuhtjkdA[IosMoLBHLZsLYmosnkgLaYQqttLk].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, XsidDmMGCthhWaxfLVeZaCdNvohvA, YhGFGaCQwZMnmujWxIUXFxvPxMLh, mmcEMALPLHqSDKPqdrMxABeNhlhW, VyPowSEpBErXydLIXlguTRBvvKPD).GetEnumerator();
								IKNoCjqYzqcJkkfnOtLTVfJDxEtT = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (ttptdTYdKHWAgOcZUaoFmBJyDgwP.MoveNext())
							{
								ElementAssignmentConflictInfo current = ttptdTYdKHWAgOcZUaoFmBJyDgwP.Current;
								NEaaOicydVSGyRFdOqDqvecOMbqDA = current;
								IKNoCjqYzqcJkkfnOtLTVfJDxEtT = 1;
								return true;
							}
							ZpxEqVJyiIauNjkeyFbuQjOKCOpo();
							ttptdTYdKHWAgOcZUaoFmBJyDgwP = null;
							IosMoLBHLZsLYmosnkgLaYQqttLk++;
							goto IL_0106;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void ZpxEqVJyiIauNjkeyFbuQjOKCOpo()
					{
						IKNoCjqYzqcJkkfnOtLTVfJDxEtT = -1;
						if (ttptdTYdKHWAgOcZUaoFmBJyDgwP != null)
						{
							ttptdTYdKHWAgOcZUaoFmBJyDgwP.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						hMFeFLuLNvdPqlAdRQrliMDqPpYf hMFeFLuLNvdPqlAdRQrliMDqPpYf2;
						if (IKNoCjqYzqcJkkfnOtLTVfJDxEtT == -2 && jLVdifGPHqKuEIkJCVhotsdVqEreb == Environment.CurrentManagedThreadId)
						{
							IKNoCjqYzqcJkkfnOtLTVfJDxEtT = 0;
							hMFeFLuLNvdPqlAdRQrliMDqPpYf2 = this;
						}
						else
						{
							hMFeFLuLNvdPqlAdRQrliMDqPpYf2 = new hMFeFLuLNvdPqlAdRQrliMDqPpYf(0);
						}
						hMFeFLuLNvdPqlAdRQrliMDqPpYf2.OiqpMZSNGdbneVLKTQPcPFqgUjkm = aYMRQgGQrNjlfglktFuvrkfQZAyp;
						hMFeFLuLNvdPqlAdRQrliMDqPpYf2.XsidDmMGCthhWaxfLVeZaCdNvohvA = tZPLfsULBwDHEbDcWwRzmHuFtYHr;
						hMFeFLuLNvdPqlAdRQrliMDqPpYf2.YhGFGaCQwZMnmujWxIUXFxvPxMLh = JYyePFOiapBilJXVDWwtemyVmdYf;
						hMFeFLuLNvdPqlAdRQrliMDqPpYf2.mmcEMALPLHqSDKPqdrMxABeNhlhW = aHMdmtgPhwkifgZCchRIpgSEnrsMc;
						hMFeFLuLNvdPqlAdRQrliMDqPpYf2.VyPowSEpBErXydLIXlguTRBvvKPD = yWpYyQELCcAniMqWugcOElAUuemjA;
						hMFeFLuLNvdPqlAdRQrliMDqPpYf2.fsrXhkHEqgBigfBsKmZpJMPrEsPRA = TlKQofiTboCXZswJyetrujIVFjKcA;
						return hMFeFLuLNvdPqlAdRQrliMDqPpYf2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class QssdHbLnhAwyGIOTFHBOXtkjqFJf : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int QCwBYkkGTwjvvGuhDuucDDtuZTzP;

					private ElementAssignmentConflictInfo EgSfhsInzRSKzQJEgWneRLxpzUBs;

					private int citmmeCejEwqemMcWkYFzBgSethj;

					private ElementAssignmentConflictCheck lNwQLMUGcuNiMgsFWTBnQTAXwPGB;

					public ElementAssignmentConflictCheck ZHzfVDHLmfCnnUapVzatOJASlXfIA;

					private bool WBsfxBHdEoTQFOeUdPOPhqriYOQyB;

					public bool TEildggpyJRHlsDjnTvCFhjtajrE;

					private bool BAeptitYqdBPAnDOEgQObnEaoLygA;

					public bool DHWevBXOcKbcqdBpMJhXOIqFWzgoA;

					private bool GbFmvLStJKxkhKAsWVHgFQiSXOzq;

					public bool heZOaAyxSWEigEvqEQVUcQuDPUzc;

					private IList<Player> tzfapZmJotgKOoqbHfsHygeounsT;

					private int QghgvPaPsvzDPNUAsDyMeQgHQxzob;

					private IEnumerator<ElementAssignmentConflictInfo> wTDQICoYVhbLrQwGgYjDhwXjMPIj;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return EgSfhsInzRSKzQJEgWneRLxpzUBs;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return EgSfhsInzRSKzQJEgWneRLxpzUBs;
						}
					}

					[DebuggerHidden]
					public QssdHbLnhAwyGIOTFHBOXtkjqFJf(int P_0)
					{
						QCwBYkkGTwjvvGuhDuucDDtuZTzP = P_0;
						citmmeCejEwqemMcWkYFzBgSethj = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int qCwBYkkGTwjvvGuhDuucDDtuZTzP = QCwBYkkGTwjvvGuhDuucDDtuZTzP;
						if (qCwBYkkGTwjvvGuhDuucDDtuZTzP == -3 || qCwBYkkGTwjvvGuhDuucDDtuZTzP == 1)
						{
							try
							{
							}
							finally
							{
								HawLZPkfuHyyEbVwuQyKhWrGakJl();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int qCwBYkkGTwjvvGuhDuucDDtuZTzP = QCwBYkkGTwjvvGuhDuucDDtuZTzP;
							if (qCwBYkkGTwjvvGuhDuucDDtuZTzP != 0)
							{
								if (qCwBYkkGTwjvvGuhDuucDDtuZTzP != 1)
								{
									return false;
								}
								QCwBYkkGTwjvvGuhDuucDDtuZTzP = -3;
								goto IL_00df;
							}
							QCwBYkkGTwjvvGuhDuucDDtuZTzP = -1;
							if (lNwQLMUGcuNiMgsFWTBnQTAXwPGB.playerId < 0 || lNwQLMUGcuNiMgsFWTBnQTAXwPGB.elementAssignmentType != ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							tzfapZmJotgKOoqbHfsHygeounsT = (WBsfxBHdEoTQFOeUdPOPhqriYOQyB ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
							QghgvPaPsvzDPNUAsDyMeQgHQxzob = 0;
							goto IL_0109;
							IL_0109:
							if (QghgvPaPsvzDPNUAsDyMeQgHQxzob < tzfapZmJotgKOoqbHfsHygeounsT.Count)
							{
								wTDQICoYVhbLrQwGgYjDhwXjMPIj = tzfapZmJotgKOoqbHfsHygeounsT[QghgvPaPsvzDPNUAsDyMeQgHQxzob].controllers.conflictChecking.ElementAssignmentConflicts(lNwQLMUGcuNiMgsFWTBnQTAXwPGB, BAeptitYqdBPAnDOEgQObnEaoLygA, GbFmvLStJKxkhKAsWVHgFQiSXOzq).GetEnumerator();
								QCwBYkkGTwjvvGuhDuucDDtuZTzP = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (wTDQICoYVhbLrQwGgYjDhwXjMPIj.MoveNext())
							{
								ElementAssignmentConflictInfo current = wTDQICoYVhbLrQwGgYjDhwXjMPIj.Current;
								EgSfhsInzRSKzQJEgWneRLxpzUBs = current;
								QCwBYkkGTwjvvGuhDuucDDtuZTzP = 1;
								return true;
							}
							HawLZPkfuHyyEbVwuQyKhWrGakJl();
							wTDQICoYVhbLrQwGgYjDhwXjMPIj = null;
							QghgvPaPsvzDPNUAsDyMeQgHQxzob++;
							goto IL_0109;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void HawLZPkfuHyyEbVwuQyKhWrGakJl()
					{
						QCwBYkkGTwjvvGuhDuucDDtuZTzP = -1;
						if (wTDQICoYVhbLrQwGgYjDhwXjMPIj != null)
						{
							wTDQICoYVhbLrQwGgYjDhwXjMPIj.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						QssdHbLnhAwyGIOTFHBOXtkjqFJf qssdHbLnhAwyGIOTFHBOXtkjqFJf;
						if (QCwBYkkGTwjvvGuhDuucDDtuZTzP == -2 && citmmeCejEwqemMcWkYFzBgSethj == Environment.CurrentManagedThreadId)
						{
							QCwBYkkGTwjvvGuhDuucDDtuZTzP = 0;
							qssdHbLnhAwyGIOTFHBOXtkjqFJf = this;
						}
						else
						{
							qssdHbLnhAwyGIOTFHBOXtkjqFJf = new QssdHbLnhAwyGIOTFHBOXtkjqFJf(0);
						}
						qssdHbLnhAwyGIOTFHBOXtkjqFJf.lNwQLMUGcuNiMgsFWTBnQTAXwPGB = ZHzfVDHLmfCnnUapVzatOJASlXfIA;
						qssdHbLnhAwyGIOTFHBOXtkjqFJf.BAeptitYqdBPAnDOEgQObnEaoLygA = DHWevBXOcKbcqdBpMJhXOIqFWzgoA;
						qssdHbLnhAwyGIOTFHBOXtkjqFJf.GbFmvLStJKxkhKAsWVHgFQiSXOzq = heZOaAyxSWEigEvqEQVUcQuDPUzc;
						qssdHbLnhAwyGIOTFHBOXtkjqFJf.WBsfxBHdEoTQFOeUdPOPhqriYOQyB = TEildggpyJRHlsDjnTvCFhjtajrE;
						return qssdHbLnhAwyGIOTFHBOXtkjqFJf;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class HLgqQpeigbTYWNVgQqgcvTaMdKun : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int uiCTdexoepfeysUfqWmSfWZzgLrV;

					private ElementAssignmentConflictInfo BuRfLnHBRrhDdWImGGMtfvAiOLidc;

					private int JAKDNazQIeUtVKbuSKOsZGbAEfsv;

					private int vcMALhjsFAGUyoyotHGMnMVrSwMC;

					public int PCPBwfnbBsrnBZHvwiTCNVAhGPMB;

					private ActionElementMap mpEjhafBZjpXiwYfDvbFBxRrOiEA;

					public ActionElementMap qrNgKiXkszHQLXrVpgGvSpmByrvk;

					private bool CyMUCTmAqdevCgIfVFJyeJTIlQtzA;

					public bool UpdKOprPowbPlolwhFVnZfyAfmHIA;

					private MouseMap TiLpKJyHbiFgwkGDpQyPQdhXrVvoA;

					public MouseMap qWzfJfDShaBSSEBwQgAsqedwQrhaA;

					private bool BLpVifZEVrLtxyrOAwBvwwJHEdph;

					public bool RotZajSyzFApsVAXnXdNeIAwfgmHA;

					private bool WDaStywfLAmSBEmvJaRdEQtBbSAI;

					public bool jxPpbaLaDJyLxodFXOqLQERrTnoq;

					private IList<Player> RyVWhOUqbFwPaEtiFhzsYnWjEoVE;

					private int fBQulrREFcxWHNEhBeamGDlQWWYf;

					private IEnumerator<ElementAssignmentConflictInfo> uSwgrtLztfDsOIPTXeVydOZmRaLm;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return BuRfLnHBRrhDdWImGGMtfvAiOLidc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return BuRfLnHBRrhDdWImGGMtfvAiOLidc;
						}
					}

					[DebuggerHidden]
					public HLgqQpeigbTYWNVgQqgcvTaMdKun(int P_0)
					{
						uiCTdexoepfeysUfqWmSfWZzgLrV = P_0;
						JAKDNazQIeUtVKbuSKOsZGbAEfsv = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = uiCTdexoepfeysUfqWmSfWZzgLrV;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								sPRGaYAoTcfRtuplLvLoBxlRjYFkA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = uiCTdexoepfeysUfqWmSfWZzgLrV;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								uiCTdexoepfeysUfqWmSfWZzgLrV = -3;
								goto IL_00dc;
							}
							uiCTdexoepfeysUfqWmSfWZzgLrV = -1;
							if (vcMALhjsFAGUyoyotHGMnMVrSwMC < 0 || mpEjhafBZjpXiwYfDvbFBxRrOiEA == null)
							{
								return false;
							}
							RyVWhOUqbFwPaEtiFhzsYnWjEoVE = (CyMUCTmAqdevCgIfVFJyeJTIlQtzA ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
							fBQulrREFcxWHNEhBeamGDlQWWYf = 0;
							goto IL_0106;
							IL_0106:
							if (fBQulrREFcxWHNEhBeamGDlQWWYf < RyVWhOUqbFwPaEtiFhzsYnWjEoVE.Count)
							{
								uSwgrtLztfDsOIPTXeVydOZmRaLm = RyVWhOUqbFwPaEtiFhzsYnWjEoVE[fBQulrREFcxWHNEhBeamGDlQWWYf].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, TiLpKJyHbiFgwkGDpQyPQdhXrVvoA, mpEjhafBZjpXiwYfDvbFBxRrOiEA, BLpVifZEVrLtxyrOAwBvwwJHEdph, WDaStywfLAmSBEmvJaRdEQtBbSAI).GetEnumerator();
								uiCTdexoepfeysUfqWmSfWZzgLrV = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (uSwgrtLztfDsOIPTXeVydOZmRaLm.MoveNext())
							{
								ElementAssignmentConflictInfo current = uSwgrtLztfDsOIPTXeVydOZmRaLm.Current;
								BuRfLnHBRrhDdWImGGMtfvAiOLidc = current;
								uiCTdexoepfeysUfqWmSfWZzgLrV = 1;
								return true;
							}
							sPRGaYAoTcfRtuplLvLoBxlRjYFkA();
							uSwgrtLztfDsOIPTXeVydOZmRaLm = null;
							fBQulrREFcxWHNEhBeamGDlQWWYf++;
							goto IL_0106;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void sPRGaYAoTcfRtuplLvLoBxlRjYFkA()
					{
						uiCTdexoepfeysUfqWmSfWZzgLrV = -1;
						if (uSwgrtLztfDsOIPTXeVydOZmRaLm != null)
						{
							uSwgrtLztfDsOIPTXeVydOZmRaLm.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						HLgqQpeigbTYWNVgQqgcvTaMdKun hLgqQpeigbTYWNVgQqgcvTaMdKun;
						if (uiCTdexoepfeysUfqWmSfWZzgLrV == -2 && JAKDNazQIeUtVKbuSKOsZGbAEfsv == Environment.CurrentManagedThreadId)
						{
							uiCTdexoepfeysUfqWmSfWZzgLrV = 0;
							hLgqQpeigbTYWNVgQqgcvTaMdKun = this;
						}
						else
						{
							hLgqQpeigbTYWNVgQqgcvTaMdKun = new HLgqQpeigbTYWNVgQqgcvTaMdKun(0);
						}
						hLgqQpeigbTYWNVgQqgcvTaMdKun.vcMALhjsFAGUyoyotHGMnMVrSwMC = PCPBwfnbBsrnBZHvwiTCNVAhGPMB;
						hLgqQpeigbTYWNVgQqgcvTaMdKun.TiLpKJyHbiFgwkGDpQyPQdhXrVvoA = qWzfJfDShaBSSEBwQgAsqedwQrhaA;
						hLgqQpeigbTYWNVgQqgcvTaMdKun.mpEjhafBZjpXiwYfDvbFBxRrOiEA = qrNgKiXkszHQLXrVpgGvSpmByrvk;
						hLgqQpeigbTYWNVgQqgcvTaMdKun.BLpVifZEVrLtxyrOAwBvwwJHEdph = RotZajSyzFApsVAXnXdNeIAwfgmHA;
						hLgqQpeigbTYWNVgQqgcvTaMdKun.WDaStywfLAmSBEmvJaRdEQtBbSAI = jxPpbaLaDJyLxodFXOqLQERrTnoq;
						hLgqQpeigbTYWNVgQqgcvTaMdKun.CyMUCTmAqdevCgIfVFJyeJTIlQtzA = UpdKOprPowbPlolwhFVnZfyAfmHIA;
						return hLgqQpeigbTYWNVgQqgcvTaMdKun;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class uWGDRgQaOBwiJwzaEfViignfWNVn : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int kocCBxyVddWKMkwzOAieDobDehSB;

					private ElementAssignmentConflictInfo aizciQgQBMKGjEIgJDSjZKRoHCagA;

					private int gMrXTydPrHBdjmgMGcsEYnQjtNXA;

					private ElementAssignmentConflictCheck HsAzQctPuvWhnylzJnhYUfDxHnUh;

					public ElementAssignmentConflictCheck WWrRFqEWySMeZBlXCvDhWTdPAsWk;

					private bool GuyqojLYkoAnqXxNIVgThmDbAZj;

					public bool aRndlupwbZgFRzsOUupnqeifIWmE;

					private bool GSrXqyvMocGEqpeuSyNUJxVDpbEl;

					public bool UPYWIQUpuQnttkyCroNxwoQNvumB;

					private bool eaiNxtIrvpsJEqRYqbzPDrQdLHAb;

					public bool wyZCZohWYjeSIYytDXLgAtOOLktF;

					private IList<Player> vzuoRgSzkOQivBhHJlFIhRIHhJyr;

					private int IravTJftWLctIZDIWNezQBsbvJfD;

					private IEnumerator<ElementAssignmentConflictInfo> dNJZOdpFLtHdwbiyaCvYcpsdmMYkA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aizciQgQBMKGjEIgJDSjZKRoHCagA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aizciQgQBMKGjEIgJDSjZKRoHCagA;
						}
					}

					[DebuggerHidden]
					public uWGDRgQaOBwiJwzaEfViignfWNVn(int P_0)
					{
						kocCBxyVddWKMkwzOAieDobDehSB = P_0;
						gMrXTydPrHBdjmgMGcsEYnQjtNXA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = kocCBxyVddWKMkwzOAieDobDehSB;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								hakbGIiSANvKRPGEhcBJoVfzinNXA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = kocCBxyVddWKMkwzOAieDobDehSB;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								kocCBxyVddWKMkwzOAieDobDehSB = -3;
								goto IL_00df;
							}
							kocCBxyVddWKMkwzOAieDobDehSB = -1;
							if (HsAzQctPuvWhnylzJnhYUfDxHnUh.playerId < 0 || HsAzQctPuvWhnylzJnhYUfDxHnUh.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							vzuoRgSzkOQivBhHJlFIhRIHhJyr = (GuyqojLYkoAnqXxNIVgThmDbAZj ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
							IravTJftWLctIZDIWNezQBsbvJfD = 0;
							goto IL_0109;
							IL_0109:
							if (IravTJftWLctIZDIWNezQBsbvJfD < vzuoRgSzkOQivBhHJlFIhRIHhJyr.Count)
							{
								dNJZOdpFLtHdwbiyaCvYcpsdmMYkA = vzuoRgSzkOQivBhHJlFIhRIHhJyr[IravTJftWLctIZDIWNezQBsbvJfD].controllers.conflictChecking.ElementAssignmentConflicts(HsAzQctPuvWhnylzJnhYUfDxHnUh, GSrXqyvMocGEqpeuSyNUJxVDpbEl, eaiNxtIrvpsJEqRYqbzPDrQdLHAb).GetEnumerator();
								kocCBxyVddWKMkwzOAieDobDehSB = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (dNJZOdpFLtHdwbiyaCvYcpsdmMYkA.MoveNext())
							{
								ElementAssignmentConflictInfo current = dNJZOdpFLtHdwbiyaCvYcpsdmMYkA.Current;
								aizciQgQBMKGjEIgJDSjZKRoHCagA = current;
								kocCBxyVddWKMkwzOAieDobDehSB = 1;
								return true;
							}
							hakbGIiSANvKRPGEhcBJoVfzinNXA();
							dNJZOdpFLtHdwbiyaCvYcpsdmMYkA = null;
							IravTJftWLctIZDIWNezQBsbvJfD++;
							goto IL_0109;
						}
						catch
						{
							//try-fault
							((IDisposable)this).Dispose();
							throw;
						}
					}

					bool IEnumerator.MoveNext()
					{
						//ILSpy generated this explicit interface implementation from .override directive in MoveNext
						return this.MoveNext();
					}

					private void hakbGIiSANvKRPGEhcBJoVfzinNXA()
					{
						kocCBxyVddWKMkwzOAieDobDehSB = -1;
						if (dNJZOdpFLtHdwbiyaCvYcpsdmMYkA != null)
						{
							dNJZOdpFLtHdwbiyaCvYcpsdmMYkA.Dispose();
						}
					}

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						uWGDRgQaOBwiJwzaEfViignfWNVn uWGDRgQaOBwiJwzaEfViignfWNVn2;
						if (kocCBxyVddWKMkwzOAieDobDehSB == -2 && gMrXTydPrHBdjmgMGcsEYnQjtNXA == Environment.CurrentManagedThreadId)
						{
							kocCBxyVddWKMkwzOAieDobDehSB = 0;
							uWGDRgQaOBwiJwzaEfViignfWNVn2 = this;
						}
						else
						{
							uWGDRgQaOBwiJwzaEfViignfWNVn2 = new uWGDRgQaOBwiJwzaEfViignfWNVn(0);
						}
						uWGDRgQaOBwiJwzaEfViignfWNVn2.HsAzQctPuvWhnylzJnhYUfDxHnUh = WWrRFqEWySMeZBlXCvDhWTdPAsWk;
						uWGDRgQaOBwiJwzaEfViignfWNVn2.GSrXqyvMocGEqpeuSyNUJxVDpbEl = UPYWIQUpuQnttkyCroNxwoQNvumB;
						uWGDRgQaOBwiJwzaEfViignfWNVn2.eaiNxtIrvpsJEqRYqbzPDrQdLHAb = wyZCZohWYjeSIYytDXLgAtOOLktF;
						uWGDRgQaOBwiJwzaEfViignfWNVn2.GuyqojLYkoAnqXxNIVgThmDbAZj = aRndlupwbZgFRzsOUupnqeifIWmE;
						return uWGDRgQaOBwiJwzaEfViignfWNVn2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private static ConflictCheckingHelper khNLqPUSbboxzKpxTJmfrMKcbUZk;

				internal static ConflictCheckingHelper aZfldMOLdNFInkVrMouoBtHkBrJOc => khNLqPUSbboxzKpxTJmfrMKcbUZk ?? (khNLqPUSbboxzKpxTJmfrMKcbUZk = new ConflictCheckingHelper());

				private ConflictCheckingHelper()
				{
				}

				public bool DoesAnyElementAssignmentConflict()
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps)
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesAnyElementAssignmentConflict(skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public bool DoesAnyElementAssignmentConflict(bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return false;
					}
					IList<Player> list = (includeSystemPlayer ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						Player player = list[i];
						int num = (forceCheckAllCategories ? i : 0);
						IList<Joystick> joysticks = player.controllers.Joysticks;
						for (int j = 0; j < joysticks.Count; j++)
						{
							Joystick joystick = joysticks[j];
							IList<JoystickMap> maps = player.controllers.maps.GetMaps<JoystickMap>(joystick.id);
							if (maps == null)
							{
								continue;
							}
							int count2 = maps.Count;
							for (int k = num; k < count; k++)
							{
								Player player2 = list[k];
								for (int l = 0; l < count2; l++)
								{
									if (player2.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, joystick.id, maps[l], skipDisabledMaps, forceCheckAllCategories))
									{
										return true;
									}
								}
							}
						}
						IList<KeyboardMap> maps2 = player.controllers.maps.GetMaps<KeyboardMap>(0);
						for (int m = 0; m < maps2.Count; m++)
						{
							for (int n = num; n < count; n++)
							{
								if (list[n].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, maps2[m], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
							}
						}
						IList<MouseMap> maps3 = player.controllers.maps.GetMaps<MouseMap>(0);
						for (int num2 = 0; num2 < maps3.Count; num2++)
						{
							for (int num3 = num; num3 < count; num3++)
							{
								if (list[num3].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, maps3[num2], skipDisabledMaps, forceCheckAllCategories))
								{
									return true;
								}
							}
						}
						IList<CustomController> customControllers = player.controllers.CustomControllers;
						for (int num4 = 0; num4 < customControllers.Count; num4++)
						{
							CustomController customController = customControllers[num4];
							IList<CustomControllerMap> maps4 = player.controllers.maps.GetMaps<CustomControllerMap>(customController.id);
							if (maps4 == null)
							{
								continue;
							}
							int count3 = maps4.Count;
							for (int num5 = num; num5 < count; num5++)
							{
								Player player3 = list[num5];
								for (int num6 = 0; num6 < count3; num6++)
								{
									if (player3.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, customController.id, maps4[num6], skipDisabledMaps, forceCheckAllCategories))
									{
										return true;
									}
								}
							}
						}
					}
					return false;
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesElementAssignmentConflict(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (playerId < 0 || elementMap == null)
					{
						return false;
					}
					return controllerType switch
					{
						ControllerType.Joystick => jUGFBAqhnwKpHzoLBFhthZBnBPvj(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => pAJECCVORspKLKhIduKNEBZrMXIT(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => kMzwoRYTFlFwjBJYtHJVhcAAQUli(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => GRecxXyLcgljSvoIstxdvXAhJYHw(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						_ => throw new NotImplementedException(), 
					};
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (conflictCheck.playerId < 0)
					{
						return false;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return IBGuHZwuxoVKLPCiskTvencwEGBz(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ndzfhZnKBnLAvPeBuebvgeDZACph(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return sIKoAhJBxnCJSALTbCPxFjFULANA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return soQOYaMeFxIMsBBhSOSaoHgOTPcN(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool jUGFBAqhnwKpHzoLBFhthZBnBPvj(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool IBGuHZwuxoVKLPCiskTvencwEGBz(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool pAJECCVORspKLKhIduKNEBZrMXIT(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool ndzfhZnKBnLAvPeBuebvgeDZACph(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool kMzwoRYTFlFwjBJYtHJVhcAAQUli(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool sIKoAhJBxnCJSALTbCPxFjFULANA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool GRecxXyLcgljSvoIstxdvXAhJYHw(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool soQOYaMeFxIMsBBhSOSaoHgOTPcN(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return ElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (playerId < 0 || elementMap == null)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					return controllerType switch
					{
						ControllerType.Joystick => UiQaHrmoExUPoGvTzCxsUXurqZSt(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => cspNhktbIEIwVAeJCVcqWqEnndeF(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => MIAeUJrAgcqOgyYpbGbWNCunxUYs(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => pxyNWKBehaDKoEPWKLfBDpfHFXydb(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ElementAssignmentConflictInfo>.EmptyReadOnlyIListT;
					}
					if (conflictCheck.playerId < 0)
					{
						return new List<ElementAssignmentConflictInfo>();
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return DkOZzrdZuGRzXYtbreFHqFiCouwA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return lrtDpKILrzqNQvHNDHCQCBvybuFo(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return ymmZekIafytdaBEDlKtRwECDAwgEA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return iTBpesoPlvdcSHygLfDFMFfWfCKn(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				[IteratorStateMachine(typeof(NBpRSBKidUqyDNfSrkAFRHVgBrHEA))]
				private IEnumerable<ElementAssignmentConflictInfo> UiQaHrmoExUPoGvTzCxsUXurqZSt(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new NBpRSBKidUqyDNfSrkAFRHVgBrHEA(-2)
					{
						sYMPlxrHsyjsqurrDPdvgHAtrTSd = P_0,
						kAVUekuWSRfHdpSsNIKJaVNnPOD = P_1,
						fXEAJsOlZWGGdTfSIXhjZvRaGYew = P_2,
						btAsbMJSgoVbkHopgfWgBYPMGAAeA = P_3,
						wLLXJVaoiUGOWXAjMipMeynvFGHW = P_4,
						vAsDIyaupsmnCHpYxckFJEpzYrUpA = P_5,
						gnRBWouHZpanKsRKuUwBDgaLNSdV = P_6
					};
				}

				[IteratorStateMachine(typeof(uTNlEcFnqpNVzJCgMsGqPBeOumBE))]
				private IEnumerable<ElementAssignmentConflictInfo> DkOZzrdZuGRzXYtbreFHqFiCouwA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new uTNlEcFnqpNVzJCgMsGqPBeOumBE(-2)
					{
						eYVNNKZqCfMizYDLJEeBJmKqcOOMA = P_0,
						cEHwFZiwphfHmFXgbKuOdSGRuomW = P_1,
						FqrZeHkyGwPiCkcHAROPIOIkegMS = P_2,
						CnGcnJZioCWrmnIdQyTyquqPIPEw = P_3
					};
				}

				[IteratorStateMachine(typeof(hMFeFLuLNvdPqlAdRQrliMDqPpYf))]
				private IEnumerable<ElementAssignmentConflictInfo> cspNhktbIEIwVAeJCVcqWqEnndeF(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new hMFeFLuLNvdPqlAdRQrliMDqPpYf(-2)
					{
						aYMRQgGQrNjlfglktFuvrkfQZAyp = P_0,
						tZPLfsULBwDHEbDcWwRzmHuFtYHr = P_1,
						JYyePFOiapBilJXVDWwtemyVmdYf = P_2,
						aHMdmtgPhwkifgZCchRIpgSEnrsMc = P_3,
						yWpYyQELCcAniMqWugcOElAUuemjA = P_4,
						TlKQofiTboCXZswJyetrujIVFjKcA = P_5
					};
				}

				[IteratorStateMachine(typeof(QssdHbLnhAwyGIOTFHBOXtkjqFJf))]
				private IEnumerable<ElementAssignmentConflictInfo> lrtDpKILrzqNQvHNDHCQCBvybuFo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new QssdHbLnhAwyGIOTFHBOXtkjqFJf(-2)
					{
						ZHzfVDHLmfCnnUapVzatOJASlXfIA = P_0,
						DHWevBXOcKbcqdBpMJhXOIqFWzgoA = P_1,
						heZOaAyxSWEigEvqEQVUcQuDPUzc = P_2,
						TEildggpyJRHlsDjnTvCFhjtajrE = P_3
					};
				}

				[IteratorStateMachine(typeof(HLgqQpeigbTYWNVgQqgcvTaMdKun))]
				private IEnumerable<ElementAssignmentConflictInfo> MIAeUJrAgcqOgyYpbGbWNCunxUYs(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new HLgqQpeigbTYWNVgQqgcvTaMdKun(-2)
					{
						PCPBwfnbBsrnBZHvwiTCNVAhGPMB = P_0,
						qWzfJfDShaBSSEBwQgAsqedwQrhaA = P_1,
						qrNgKiXkszHQLXrVpgGvSpmByrvk = P_2,
						RotZajSyzFApsVAXnXdNeIAwfgmHA = P_3,
						jxPpbaLaDJyLxodFXOqLQERrTnoq = P_4,
						UpdKOprPowbPlolwhFVnZfyAfmHIA = P_5
					};
				}

				[IteratorStateMachine(typeof(uWGDRgQaOBwiJwzaEfViignfWNVn))]
				private IEnumerable<ElementAssignmentConflictInfo> ymmZekIafytdaBEDlKtRwECDAwgEA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new uWGDRgQaOBwiJwzaEfViignfWNVn(-2)
					{
						WWrRFqEWySMeZBlXCvDhWTdPAsWk = P_0,
						UPYWIQUpuQnttkyCroNxwoQNvumB = P_1,
						wyZCZohWYjeSIYytDXLgAtOOLktF = P_2,
						aRndlupwbZgFRzsOUupnqeifIWmE = P_3
					};
				}

				[IteratorStateMachine(typeof(IFlcBDZupEfXERqtKJyUJaicHlIs))]
				private IEnumerable<ElementAssignmentConflictInfo> pxyNWKBehaDKoEPWKLfBDpfHFXydb(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new IFlcBDZupEfXERqtKJyUJaicHlIs(-2)
					{
						YeLakfbIiDPemwHsjMMqiXAFbBlQb = P_0,
						rVGKQnvRotGpkQbAhHXWcSaOAmRL = P_1,
						XIqNXgHxMQdDszGmJldAUfCNVYyg = P_2,
						bHyExYNoDVcFQdSHLULwMOeJtursA = P_3,
						WRZGVAldZLFamJGpUoinkcmgiddEA = P_4,
						rwqsTkyegElnjTioNgDHJhdSSpCEA = P_5,
						QXNENePbZQIcGiEtEPshfuKROhzG = P_6
					};
				}

				[IteratorStateMachine(typeof(dxXdfZwwavhBGcSxmKGPTmWMSxsn))]
				private IEnumerable<ElementAssignmentConflictInfo> iTBpesoPlvdcSHygLfDFMFfWfCKn(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new dxXdfZwwavhBGcSxmKGPTmWMSxsn(-2)
					{
						ngWYwNHZbjEJyTEOoXgfnEWpGbAEA = P_0,
						YvefnAKQbJKejFxCiRXKgxLcHBjdE = P_1,
						KAyaqRfSWiloLxHtVqwPxojPuneJ = P_2,
						RTwsSEMetAbFEiPCvPaTgodcECEnc = P_3
					};
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return RemoveElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (playerId < 0 || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => NfktRcwYqHEEQkjgPDxJDBueuxufA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => ZxhccokGAGnmHGVYQhVupEQnuNJT(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => vzEMxsXqIadhPKnrlNfaIFcqCJOt(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => ixnNmqFNVWHEqsrDYuYRQiQABJmm(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (conflictCheck.playerId < 0)
					{
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return siAbOjcknYIJSduiCknKxhSjTpUvA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return UxjRnjNtYVCuxWFgZRUluVHNWaYU(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return FfZfvAHXfbxLtvklmTSrPTRJwUGjA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return TQYCBdhRnyKyMrrQAiRFtmPYkAuv(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int NfktRcwYqHEEQkjgPDxJDBueuxufA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int siAbOjcknYIJSduiCknKxhSjTpUvA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int ZxhccokGAGnmHGVYQhVupEQnuNJT(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int UxjRnjNtYVCuxWFgZRUluVHNWaYU(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int vzEMxsXqIadhPKnrlNfaIFcqCJOt(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int FfZfvAHXfbxLtvklmTSrPTRJwUGjA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int ixnNmqFNVWHEqsrDYuYRQiQABJmm(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int TQYCBdhRnyKyMrrQAiRFtmPYkAuv(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DisableElementAssignmentConflicts(playerId, controllerType, controllerId, controllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(int playerId, ControllerType controllerType, int controllerId, ControllerMap controllerMap, ActionElementMap elementMap, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (playerId < 0 || elementMap == null)
					{
						return 0;
					}
					return controllerType switch
					{
						ControllerType.Joystick => MKDYDhIQkxkmXlABCwzUZZEjNQLf(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => rqUkaiwpxdaGbJNtiLSNROwgkxPDA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => HJUFDXdkvyESnrNNJDMWIMPcdqfbb(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => fxsNOapuunuMEQBFzFCDflALcMKc(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						_ => throw new NotImplementedException(), 
					};
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories: false, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories)
				{
					return DisableElementAssignmentConflicts(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer: true);
				}

				public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps, bool forceCheckAllCategories, bool includeSystemPlayer)
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					if (conflictCheck.playerId < 0)
					{
						return 0;
					}
					if (conflictCheck.controllerType == ControllerType.Joystick)
					{
						return mqwTinBBSEbSOTlNkhhsJVspsbCMA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return DWmvZojORdGZqMfAsnbSdDWuflWk(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return jcJBEYYnGyBugjmPRsgsugTHyIrV(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return wnjWpmraFFDvDoQllfdXIqyuRUEz(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int MKDYDhIQkxkmXlABCwzUZZEjNQLf(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int mqwTinBBSEbSOTlNkhhsJVspsbCMA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int rqUkaiwpxdaGbJNtiLSNROwgkxPDA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int DWmvZojORdGZqMfAsnbSdDWuflWk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int HJUFDXdkvyESnrNNJDMWIMPcdqfbb(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int jcJBEYYnGyBugjmPRsgsugTHyIrV(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int fxsNOapuunuMEQBFzFCDflALcMKc(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int wnjWpmraFFDvDoQllfdXIqyuRUEz(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg : yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper RvDzRianbKGzlAojPLBhqSdlxezDA;

			public readonly PollingHelper polling = PollingHelper.OZqcRXGjWOquzHKogvhdiPmBbgdJA;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.aZfldMOLdNFInkVrMouoBtHkBrJOc;

			internal static ControllerHelper zaUMUBCFRABoiglmiIrrAHgUrbsy => RvDzRianbKGzlAojPLBhqSdlxezDA ?? (RvDzRianbKGzlAojPLBhqSdlxezDA = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.KTiqjXjbzvvrOFfZTCqwCsiLFRVbb;
				}
			}

			public IList<Controller> Controllers
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Controller>.EmptyReadOnlyIListT;
					}
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.CcJUbpcfyeOqdwnSTYsToekkEJiKA;
				}
			}

			public Mouse Mouse
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.vdLMjGufKFZFbdHWwGFoTfIgNRfT;
				}
			}

			public Keyboard Keyboard
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.drgNjPBDklMoqhfwuCfPMsCoXTQl;
				}
			}

			[Obsolete("Deprecated: Use Controller.enabled instead. For example, to disable keyboard input: ReInput.controllers.Keyboard.enabled = false.")]
			public bool keyboardEnabled
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return Keyboard.enabled;
				}
				set
				{
					if (CheckInitialized())
					{
						Keyboard.enabled = value;
					}
				}
			}

			public int joystickCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.LkbCNXDBSBeJusZHNRPbRWQxbsRl;
				}
			}

			public IList<Joystick> Joysticks
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Joystick>.EmptyReadOnlyIListT;
					}
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE;
				}
			}

			public int customControllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.efRWqpQqHUtuuAjtPTclDqttaDJfA;
				}
			}

			public IList<CustomController> CustomControllers
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
					}
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.rofnZiogmyQlxMWTOPOraCjgRvVT;
				}
			}

			private ControllerHelper()
			{
			}

			public T GetController<T>(int controllerId) where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controllerId < 0)
				{
					return null;
				}
				Type typeFromHandle = typeof(T);
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
				{
					return GetJoystick(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
				{
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.drgNjPBDklMoqhfwuCfPMsCoXTQl as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return zEtuNvknIQbzOpsTCdeQeEswlwDw.vdLMjGufKFZFbdHWwGFoTfIgNRfT as T;
				}
				throw new NotImplementedException();
			}

			public int GetControllerCount(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				return controllerType switch
				{
					ControllerType.Joystick => joystickCount, 
					ControllerType.Keyboard => 1, 
					ControllerType.Mouse => 1, 
					ControllerType.Custom => customControllerCount, 
					_ => throw new NotImplementedException(), 
				};
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.mIEmXinDLSYEQVEphxqMuRdgYjDG(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.iWKDuUmuGfUgHbDyxkQQwLEfoSAA(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.VQdsidmgyvDLqJgWZglylOukVfLy(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.VApgfmbMndFcfTpCLoICQqJDJpQj(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.KxuEPrXbjuEtUSSaSIptqdDOyPaN(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.zCaqhUPpVHQNkLTwRLccxRSyaWaB(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.yoLvGOZPVRITkJbKJWuwOmJFWKAy(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yLMToaDqIzfOcDAFApituELqzLeNA.fsuaJVPefFPHXvtkrVXQtYHMWFuc(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yLMToaDqIzfOcDAFApituELqzLeNA.ttcJMadqVCXBBCzetRgaxsDyyaqU(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.OxrgsiKBGdmiKjOdZinhwnxwTyjnA(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.UPGEeOdRDNSgZRhYrklrsIWcepCVA();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.TVmcEHtBdCnDFIrCARaoDkhhWQfi();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.MpcSODiXNcVYOJMDzPCxzfPuinuw(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.ysrOLAOKAnzAYcgfeJwqaZpkHYAu(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.toEJXPQGQzieUlLoREVESfJeAige(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yLMToaDqIzfOcDAFApituELqzLeNA.agVBiCnsTfgnmxgdFBuUVCEiFmKH(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yLMToaDqIzfOcDAFApituELqzLeNA.ejAFEvBRnZnNwxIHjomscMoGsnmtb(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!imlEcTwzTpoJbudKKzRpjSUmOZhw)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				AgRzXgdvqwZvRNpjOmPrHDpDKjpN();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (baATMRtCSdLODYONHhaSVHugHBgk.OYfVaXuhoosbybbIVAgcCRtuTahDA(i, j))
						{
							return i + 1;
						}
					}
				}
				return -1;
			}

			public int GetUnityJoystickIdFromAnyButtonOrAxisPress(float axisThreshold, bool positiveAxesOnly)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!imlEcTwzTpoJbudKKzRpjSUmOZhw)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				AgRzXgdvqwZvRNpjOmPrHDpDKjpN();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (baATMRtCSdLODYONHhaSVHugHBgk.OYfVaXuhoosbybbIVAgcCRtuTahDA(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (baATMRtCSdLODYONHhaSVHugHBgk.gPAogUgrMGsVcPWyjRNTLtNceMqx(i, k, positiveAxesOnly))
						{
							return i + 1;
						}
					}
				}
				return -1;
			}

			public void SetUnityJoystickId(int joystickId, int unityJoystickId)
			{
				if (CheckInitialized())
				{
					if (!imlEcTwzTpoJbudKKzRpjSUmOZhw)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						DHXBfYFYgbOleOssuzSOMABxpJKZA.SetUnityJoystickId(joystickId, unityJoystickId);
					}
				}
			}

			public bool SetUnityJoystickIdFromAnyButtonPress(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				int unityJoystickIdFromAnyButtonPress = GetUnityJoystickIdFromAnyButtonPress();
				if (unityJoystickIdFromAnyButtonPress < 1)
				{
					return false;
				}
				SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonPress);
				return true;
			}

			public bool SetUnityJoystickIdFromAnyButtonOrAxisPress(int joystickId, float axisThreshold, bool positiveAxesOnly)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				int unityJoystickIdFromAnyButtonOrAxisPress = GetUnityJoystickIdFromAnyButtonOrAxisPress(axisThreshold, positiveAxesOnly);
				if (unityJoystickIdFromAnyButtonOrAxisPress < 1)
				{
					return false;
				}
				SetUnityJoystickId(joystickId, unityJoystickIdFromAnyButtonOrAxisPress);
				return true;
			}

			public CustomController GetCustomController(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.isoqtKYJECuhecyRiMjBXSMSGjSO(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.zLcCpYjSOohkyznYQcVVtXyloMhE();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.EwpbOsgZAtbiSaObABCqbusVkRDnc();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.UxKhsCINcJXXFXdmTqhTvPwNEkyEA(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.SrNfOacNoYRkAmikMuFATcccHPHuA(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.GkMMUPSePWpOXVpWtAiBcpKBaqny(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yLMToaDqIzfOcDAFApituELqzLeNA.ZmVYlbDVzFIqecotWDAawCbpuiuj(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yLMToaDqIzfOcDAFApituELqzLeNA.RNRBnwfyiFqyhKeEkiKVIfhAkhByb(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.eCVKPANUKkNwYdDVztQrzDjKaPIm(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = zEtuNvknIQbzOpsTCdeQeEswlwDw.eCVKPANUKkNwYdDVztQrzDjKaPIm(sourceControllerId);
				if (customController == null)
				{
					return null;
				}
				customController.tag = tag;
				return customController;
			}

			public bool DestroyCustomController(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (customController == null)
				{
					return false;
				}
				RemoveCustomControllerFromAllPlayers(customController);
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.JDtcOknBrwYabvehllYYUtlakYyP(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.TnvKWGIBTrKENppmGptWClkBKQjj(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.yKdeepKkoYPwBDUeiFgTmcRgagsmB(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.UewXmASMtKWuOjDSarewXUOagbVm(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.LNXWnfJxELSAbdselugnHVeAHofD(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.guJgbpBeTuCjxLCAMgAEMsCSjNUC<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.eghgYIIfxlmMwsWwLQdbJveNtrDn();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.QTRaFFAypvqLfdEbnpEKAgiDBIEtB(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.eghgYIIfxlmMwsWwLQdbJveNtrDn<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.GxjQHufSWpHiwukpxvFKjOItykSy();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					zEtuNvknIQbzOpsTCdeQeEswlwDw.UBxOapVNUgZqGnoUobzTsQcbmcts(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					zEtuNvknIQbzOpsTCdeQeEswlwDw.kQSETnNMgcFBLYgnahPJNtTqWunJ(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					zEtuNvknIQbzOpsTCdeQeEswlwDw.rhGHaOTESuBEmeyDyMIsIgMvSXqm(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					zEtuNvknIQbzOpsTCdeQeEswlwDw.mNehsUJnFHstxmfPLgPEbcJyGMOO(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					zEtuNvknIQbzOpsTCdeQeEswlwDw.OKdXFgjbBEHwAQxHuaNdxzNINvuk();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.daBiopFQwPbWEeRwYaTDhGdfikM();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.YZJmXVcjDoMOSmRzwhhEGPPoOETn(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.ERlLtRNOXKlAttLgeCJOaSJRpuDab();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.DsYGQsSJFScUXHIGsDsvvPsbEJZD(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.tENzToUPiywsIGkKyDToKmKPmmQs();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.HpkaTDQcZYmGprMRWYJuZhQNDAsV(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.mjvHXnUNiDIJsjNGEhuQUuSzHFwt();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.xtPgtlKHBSJNzjWTiGsPyhkABbsRB(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.BTVKjFYXGBNMlcWzNLlgvVsFcBNu();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.SPhHvGJXANUguWDmWqhyasoHimJH(controllerType);
			}

			public bool AutoAssignJoystick(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				if (joystick == null)
				{
					return false;
				}
				if (IsJoystickAssigned(joystick))
				{
					return true;
				}
				yLMToaDqIzfOcDAFApituELqzLeNA.UoYJLxwtzmfoxZrWlNxARAWQNlDC(joystick);
				return IsJoystickAssigned(joystick);
			}

			public void AutoAssignJoysticks()
			{
				if (CheckInitialized())
				{
					int num = joystickCount;
					IList<Joystick> joysticks = Joysticks;
					for (int i = 0; i < num; i++)
					{
						AutoAssignJoystick(joysticks[i]);
					}
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class MappingHelper : CodeHelper
		{
			private static MappingHelper hIPCndQocagHKUzAJauqTgjoJcIp;

			internal static MappingHelper cBuDlPdBdORENafRTzuWAXBVkgEG => hIPCndQocagHKUzAJauqTgjoJcIp ?? (hIPCndQocagHKUzAJauqTgjoJcIp = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.NxuxafxxwliOaTVRCgiRaVrGoyEu;
				}
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.FeraMggrsVkahvZDNdZeGWnBIBJHA;
				}
			}

			public IList<InputCategory> ActionCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.cuPsxhDltymVGUamqqSVtzlIUBb;
				}
			}

			public IEnumerable<InputCategory> UserAssignableActionCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.vNSFWYdxmTpFGBDoFMLlOKRnoCmX;
				}
			}

			public IList<InputLayout> JoystickLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.TXYIMRrJNjbCUjHirYdQkslVqaww;
				}
			}

			public IList<InputLayout> KeyboardLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.hbEABXzvlZXaiHHwRCIUofldgDw;
				}
			}

			public IList<InputLayout> MouseLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.yQxalfFLIGnvlPjMbfbNovXiCXxqA;
				}
			}

			public IList<InputLayout> CustomControllerLayouts
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.zxcakKiPDnhIfyHPyrXypQZHiIjib;
				}
			}

			public IList<InputAction> Actions
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
					}
					return AwFNwGchWvDBRvqVRzmYbEJcoaxe.GpGjcLJqOjgpHpNgraZJfJTtxhEz;
				}
			}

			public IEnumerable<InputAction> UserAssignableActions
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
					}
					return MxboHOxlsDLTuNkINIYZaIjEdbFxA.jvdraIlmaqDvujVnfhCSRSvqoMFU;
				}
			}

			private MappingHelper()
			{
			}

			public InputMapCategory GetMapCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.XCkSbMuYCtSSOiCYYFYDbDVabBNoA(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GmeFAauFxCLVdbDIeINuSbwUQbDg(tag);
			}

			public bool IsMapCategoryUserAssignable(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GetMapCategory(mapCategoryId)?.userAssignable ?? false;
			}

			public InputCategory GetActionCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.uQEslXDgmiqQKkYQTMDKmNJLxFfn(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GNvQkJfLONnufFSfpgIqAHsAHGkMA(tag);
			}

			public bool IsActionCategoryUserAssignable(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return GetActionCategory(mapCategoryId)?.userAssignable ?? false;
			}

			public InputLayout GetLayout(ControllerType controllerType, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return controllerType switch
				{
					ControllerType.Joystick => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetCustomControllerLayoutById(layoutId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetLayout(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return controllerType switch
				{
					ControllerType.Joystick => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetJoystickLayout(name), 
					ControllerType.Keyboard => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetKeyboardLayout(name), 
					ControllerType.Mouse => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetMouseLayout(name), 
					ControllerType.Custom => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetCustomControllerLayout(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public int GetLayoutId(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return controllerType switch
				{
					ControllerType.Joystick => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetMouseLayoutId(name), 
					ControllerType.Custom => MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetCustomControllerLayoutId(name);
			}

			public IList<InputLayout> MapLayouts(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				return controllerType switch
				{
					ControllerType.Joystick => JoystickLayouts, 
					ControllerType.Keyboard => KeyboardLayouts, 
					ControllerType.Mouse => MouseLayouts, 
					ControllerType.Custom => CustomControllerLayouts, 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputAction GetAction(int actionId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.sgzcgrMTvmiASaQIZcXCAbyzZDiT(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.sgzcgrMTvmiASaQIZcXCAbyzZDiT(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.CmbuedyqBQaVZgSrEeojeltbWSMr(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.CmbuedyqBQaVZgSrEeojeltbWSMr(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.XPDNnJDpnTzsECIQqBzHDIADsygMA(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.fVVpcAFGNXnIvCbjkGfiDNTbcgMib(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.fVVpcAFGNXnIvCbjkGfiDNTbcgMib(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ITVAvgbScviYgNcKkCbuYEZFCnPZ(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.ITVAvgbScviYgNcKkCbuYEZFCnPZ(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.yxlcXWJyivSECaVXCcPaGrFzeWGN(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.yxlcXWJyivSECaVXCcPaGrFzeWGN(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.mcSowgfWkICbLviMcwKVuFBXwNmK(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zEtuNvknIQbzOpsTCdeQeEswlwDw.nuatKlntTuiBBKKYpVnEkwckMurb(playerId, behaviorName);
			}

			public InputBehavior GetSystemPlayerInputBehavior(int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetInputBehavior(9999999, behaviorId);
			}

			public InputBehavior GetSystemPlayerInputBehavior(string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetInputBehavior(9999999, behaviorName);
			}

			public int GetInputBehaviorId(string behaviorName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior oobeFUCKgXohzRwOJumsbVieMgHHb(int P_0)
			{
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetInputBehaviorById(P_0);
			}

			internal InputBehavior hPaEsPCtigqeoePwORJmDReOcdjhb(string P_0)
			{
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetInputBehavior(P_0);
			}

			public ControllerMap GetControllerMap(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = players.AllPlayers;
				for (int i = 0; i < allPlayers.Count; i++)
				{
					ControllerMap map = allPlayers[i].controllers.maps.GetMap(id);
					if (map != null)
					{
						return map;
					}
				}
				return null;
			}

			public ActionElementMap GetActionElementMap(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				IList<Player> allPlayers = players.AllPlayers;
				for (int i = 0; i < allPlayers.Count; i++)
				{
					foreach (ControllerMap allMap in allPlayers[i].controllers.maps.GetAllMaps())
					{
						if (allMap != null)
						{
							ActionElementMap elementMap = allMap.GetElementMap(id);
							if (elementMap != null)
							{
								return elementMap;
							}
						}
					}
				}
				return null;
			}

			public ControllerMap GetControllerMapInstance(Controller controller, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				return controller.type switch
				{
					ControllerType.Joystick => GetJoystickMapInstance((Joystick)controller, mapCategoryId, layoutId), 
					ControllerType.Keyboard => GetKeyboardMapInstance(mapCategoryId, layoutId), 
					ControllerType.Mouse => GetMouseMapInstance(mapCategoryId, layoutId), 
					ControllerType.Custom => GetCustomControllerMapInstance((CustomController)controller, mapCategoryId, layoutId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerMap GetControllerMapInstance(Controller controller, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controller.type, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstance(controller, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controllerIdentifier.controllerType, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller controller = zEtuNvknIQbzOpsTCdeQeEswlwDw.iWKDuUmuGfUgHbDyxkQQwLEfoSAA(controllerIdentifier);
				if (controller != null)
				{
					return GetControllerMapInstance(controller, mapCategoryId, layoutId);
				}
				return controllerIdentifier.controllerType switch
				{
					ControllerType.Joystick => GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId), 
					ControllerType.Custom => GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId), 
					ControllerType.Keyboard => GetKeyboardMapInstance(mapCategoryId, layoutId), 
					ControllerType.Mouse => GetMouseMapInstance(mapCategoryId, layoutId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystick == null)
				{
					return null;
				}
				JoystickMap joystickMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.HOUfLSHZDFkgOKHPGTiFhpwlDNfDA(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.jqLSrLTCddLEpzgJvILfPrtjvnhn(joystickMap);
				}
				return joystickMap;
			}

			public JoystickMap GetJoystickMapInstance(Joystick joystick, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					return null;
				}
				InputSource inputSourceType = DHXBfYFYgbOleOssuzSOMABxpJKZA.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = jIADwwDowsEdZMpnQUYZDTdMedJDb.JZrLJldcHgZaaqAkYOuvBECmOmao(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.vjxSDCeleuFaRjvAIINMqbVeGDKXA(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.IpuMrUspCleGhAmArBBpchmgWFBbc(joystickMap, hardwareControllerMap_Game);
					}
				}
				return joystickMap;
			}

			public JoystickMap GetJoystickMapInstance(Guid joystickTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystickTypeGuid == Guid.Empty)
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstance(joystickTypeGuid, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controllerIdentifier.controllerType != ControllerType.Joystick)
				{
					return null;
				}
				if (zEtuNvknIQbzOpsTCdeQeEswlwDw.iWKDuUmuGfUgHbDyxkQQwLEfoSAA(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstance(joystick, mapCategoryId, layoutId);
				}
				return GetJoystickMapInstance(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			public KeyboardMap GetKeyboardMapInstance(int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				KeyboardMap keyboardMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.jqLSrLTCddLEpzgJvILfPrtjvnhn(keyboardMap);
				}
				return keyboardMap;
			}

			public KeyboardMap GetKeyboardMapInstance(string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Keyboard, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetKeyboardMapInstance(mapCategoryId, layoutId);
			}

			public MouseMap GetMouseMapInstance(int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				MouseMap mouseMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.jqLSrLTCddLEpzgJvILfPrtjvnhn(mouseMap);
				}
				return mouseMap;
			}

			public MouseMap GetMouseMapInstance(string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetMouseMapInstance(mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomControllerMap customControllerMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.yfDgYQQnkvFLLsPwIrQTpTtJiskJ(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.jqLSrLTCddLEpzgJvILfPrtjvnhn(customControllerMap);
				}
				return customControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstance(CustomController customController, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controllerIdentifier.controllerType != ControllerType.Custom)
				{
					return null;
				}
				if (zEtuNvknIQbzOpsTCdeQeEswlwDw.iWKDuUmuGfUgHbDyxkQQwLEfoSAA(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.xzZXlosCixAPUxJWWZonNclMzMcH(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.CreateGameHardwareMap();
					if (hardwareControllerMap_Game == null)
					{
						Logger.LogError("No hardware map found.");
						return null;
					}
					foreach (ActionElementMap allMap in customControllerMap.AllMaps)
					{
						allMap.IpuMrUspCleGhAmArBBpchmgWFBbc(customControllerMap, hardwareControllerMap_Game);
					}
				}
				return customControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstance(ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				ControllerMap controllerMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					controllerMap = controllerMapStore.LoadControllerMap(playerId, controller.identifier, mapCategoryId, layoutId);
				}
				if (controllerMap == null)
				{
					controllerMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.OeYxQTPxhjuQLWoMvQabxOxprQcK(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.hgwfRdRoPADdcEgrryWFCEolgFdeA(controller, controllerMap);
					}
					else
					{
						controller.jqLSrLTCddLEpzgJvILfPrtjvnhn(controllerMap);
					}
				}
				return controllerMap;
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, Controller controller, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (controller == null)
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controller.type, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstanceSavedOrDefault(playerId, controller, mapCategoryId, layoutId);
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return controllerIdentifier.controllerType switch
				{
					ControllerType.Joystick => GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId), 
					ControllerType.Custom => GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId), 
					ControllerType.Keyboard => GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId), 
					ControllerType.Mouse => GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId), 
					_ => throw new NotImplementedException(), 
				};
			}

			public ControllerMap GetControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(controllerIdentifier.controllerType, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return GetControllerMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId) as JoystickMap;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, Joystick joystick, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (zEtuNvknIQbzOpsTCdeQeEswlwDw.iWKDuUmuGfUgHbDyxkQQwLEfoSAA(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = DHXBfYFYgbOleOssuzSOMABxpJKZA.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = jIADwwDowsEdZMpnQUYZDTdMedJDb.JZrLJldcHgZaaqAkYOuvBECmOmao(controllerIdentifier.hardwareTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					joystickMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as JoystickMap;
				}
				if (joystickMap == null)
				{
					joystickMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.vjxSDCeleuFaRjvAIINMqbVeGDKXA(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				}
				if (joystickMap != null)
				{
					if (players.GetPlayer(playerId) != null)
					{
						joystickMap.playerId = playerId;
					}
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.IpuMrUspCleGhAmArBBpchmgWFBbc(joystickMap, hardwareControllerMap_Game);
					}
				}
				return joystickMap;
			}

			public JoystickMap GetJoystickMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Joystick, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, int mapCategoryId, int layoutId)
			{
				return GetControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId) as CustomControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, CustomController customController, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (zEtuNvknIQbzOpsTCdeQeEswlwDw.iWKDuUmuGfUgHbDyxkQQwLEfoSAA(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					customControllerMap = controllerMapStore.LoadControllerMap(playerId, controllerIdentifier, mapCategoryId, layoutId) as CustomControllerMap;
				}
				if (customControllerMap == null)
				{
					customControllerMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.xzZXlosCixAPUxJWWZonNclMzMcH(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				}
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.CreateGameHardwareMap();
					if (hardwareControllerMap_Game == null)
					{
						Logger.LogError("No hardware map found.");
						return null;
					}
					if (players.GetPlayer(playerId) != null)
					{
						customControllerMap.playerId = playerId;
					}
					foreach (ActionElementMap allMap in customControllerMap.AllMaps)
					{
						allMap.IpuMrUspCleGhAmArBBpchmgWFBbc(customControllerMap, hardwareControllerMap_Game);
					}
				}
				return customControllerMap;
			}

			public CustomControllerMap GetCustomControllerMapInstanceSavedOrDefault(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
			}

			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller keyboard = controllers.Keyboard;
				KeyboardMap keyboardMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					keyboardMap = controllerMapStore.LoadControllerMap(playerId, keyboard.identifier, mapCategoryId, layoutId) as KeyboardMap;
				}
				if (keyboardMap == null)
				{
					keyboardMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.hgwfRdRoPADdcEgrryWFCEolgFdeA(keyboard, keyboardMap);
					}
					else
					{
						keyboard.jqLSrLTCddLEpzgJvILfPrtjvnhn(keyboardMap);
					}
				}
				return keyboardMap;
			}

			public KeyboardMap GetKeyboardMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Keyboard, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
			}

			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				Controller mouse = controllers.Mouse;
				MouseMap mouseMap = null;
				if (userDataStore is IControllerMapStore controllerMapStore)
				{
					mouseMap = controllerMapStore.LoadControllerMap(playerId, mouse.identifier, mapCategoryId, layoutId) as MouseMap;
				}
				if (mouseMap == null)
				{
					mouseMap = MxboHOxlsDLTuNkINIYZaIjEdbFxA.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.hgwfRdRoPADdcEgrryWFCEolgFdeA(mouse, mouseMap);
					}
					else
					{
						mouse.jqLSrLTCddLEpzgJvILfPrtjvnhn(mouseMap);
					}
				}
				return mouseMap;
			}

			public MouseMap GetMouseMapInstanceSavedOrDefault(int playerId, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Mouse, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
			}

			[Obsolete("This method has been deprecated. Use the Controller Template system instead.", false)]
			public ControllerElementIdentifier GetFirstJoystickTemplateElementIdentifier(Joystick joystick, int joystickElementIdentifierId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				if (joystick == null)
				{
					return null;
				}
				return GVVfsrFKHOBPHYlfwKLqWRdUXRvJ(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier GVVfsrFKHOBPHYlfwKLqWRdUXRvJ(Guid P_0, int P_1)
			{
				HardwareJoystickMap hardwareControllerMap;
				return jIADwwDowsEdZMpnQUYZDTdMedJDb.HLFyBOdjBIFFFrTlJLCAXVyMGFbW(P_0, P_1, out hardwareControllerMap)?.ToControllerElementIdentifier(hardwareControllerMap);
			}

			internal int kaPPSxAEByaCLOqxlhEfUDKNqcjS(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.FEhsPJDpJWJwcwxoKFKKvWvFgmlN> P_3)
			{
				return jIADwwDowsEdZMpnQUYZDTdMedJDb.RdLEUSHgbDOWAhtSAKwlEPbqtaaEc(P_0, P_1, P_2, P_3);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.pBaFIWjhVSKbtjFHiVzeydUqMjYsA(templateTypeGuid, mapCategoryId, layoutId);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, string mapCategoryName, string layoutName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int mapCategoryId = GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = GetLayoutId(ControllerType.Custom, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				return GetControllerTemplateMapInstance(templateTypeGuid, mapCategoryId, layoutId);
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetControllerMapLayoutManagerRuleSetId(name);
				if (controllerMapLayoutManagerRuleSetId < 0)
				{
					return null;
				}
				return GetControllerMapLayoutManagerRuleSetInstance(controllerMapLayoutManagerRuleSetId);
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(int id)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetControllerMapEnablerRuleSetId(name);
				if (controllerMapEnablerRuleSetId < 0)
				{
					return null;
				}
				return GetControllerMapEnablerRuleSetInstance(controllerMapEnablerRuleSetId);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class PlayerHelper : CodeHelper
		{
			private static PlayerHelper LrTEzrcOqUDPZQHBnmvJsNYWpIZ;

			internal static PlayerHelper JWkfaXbAzUdNAZdlLItKxncsMAUUA => LrTEzrcOqUDPZQHBnmvJsNYWpIZ ?? (LrTEzrcOqUDPZQHBnmvJsNYWpIZ = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return yLMToaDqIzfOcDAFApituELqzLeNA.bYsHspPdAWKVmRlbOyRDnMcSXMgu;
				}
			}

			public int allPlayerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return yLMToaDqIzfOcDAFApituELqzLeNA.RLCTJiQobFDVIysJUUNRPShrRMxT;
				}
			}

			public IList<Player> Players
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Player>.EmptyReadOnlyIListT;
					}
					return yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX;
				}
			}

			public IList<Player> AllPlayers
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<Player>.EmptyReadOnlyIListT;
					}
					return yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg;
				}
			}

			public Player SystemPlayer
			{
				get
				{
					if (!CheckInitialized())
					{
						return null;
					}
					return yLMToaDqIzfOcDAFApituELqzLeNA.kkFtAnKzLXLJZjMeUjNJMYwsjPoy();
				}
			}

			private PlayerHelper()
			{
			}

			public IList<Player> GetPlayers(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Player>.EmptyReadOnlyIListT;
				}
				if (!includeSystemPlayer)
				{
					return yLMToaDqIzfOcDAFApituELqzLeNA.XKQWYjVbbhoomGBuCSuHeIXeXvbX;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.ssTAZyhzyjeuEmsFYTerbvGpsIhg;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.brhNoQGyqbXIjYOSldNMHSkKJjCd(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.JdzicVIeOZJFTgoEefXxXXEHTqPIc(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.kkFtAnKzLXLJZjMeUjNJMYwsjPoy();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.oZrEHHUHGVdIWcRyejxjcJTAlwzPA(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.clhsSQXTqEunSZPtLrJTviATwEiw(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.JgneAvJUXaQGcanuivzDbFhyrImVb(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return yLMToaDqIzfOcDAFApituELqzLeNA.hCIwQVvZzLiiofQNUbPZHvEAqjBU(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper wLCHEzIhjEepXrFQDXoErrsMBgey;

			internal static TimeHelper IXySMYnMNgiWTANhnlBBqaidsEHpA => wLCHEzIhjEepXrFQDXoErrsMBgey ?? (wLCHEzIhjEepXrFQDXoErrsMBgey = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)NGkIVJKOwNSfZYAiSfxNmibNDsOfA.kXkSpSdPjlGggDbibShWUHIiPMiib;
				}
			}

			public double unscaledTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0.0;
					}
					return NGkIVJKOwNSfZYAiSfxNmibNDsOfA.vFfSMxirfpwJjwOfoCaigMfAuoptA;
				}
			}

			public uint currentFrame
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0u;
					}
					return NGkIVJKOwNSfZYAiSfxNmibNDsOfA.cEozTajOnmfJGFQKIaDoDFLJPtNEA;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class rRqHpKyIhXUtNYpwggzJbYUQGGbo
		{
			private class wizNuJxCYKHKyXNmwvDhPUEBTUxo
			{
				public readonly UpdateLoopType tVGBDwumtAzmLqzkgFhWvEuiAZwCA;

				private double aARvmsaJRIORMXJwdFmJaMPAANOgA;

				private double kBZRcnjaSNIErqajsrEAGzPOxZP;

				private double hFdCVjuSDvWrOFwXsOAvhmbnghpi;

				private double wmSjqFsLlIOVewIWOFUThuVdCvQV;

				private uint ytSUPBjiBUaYedPLPRSIqgVwuerF;

				private uint VmlxpXTFukdVcEYpPuXzYPFLWLpP;

				private float QSvBhpYfhKDLpFpOruoFlSlQFPyfA;

				private float XjUeuUNjueJqkAuLkKUwHfOpcQXD;

				public double IcWHnKiOkGfrtvIQiCgQhvIwHBb => aARvmsaJRIORMXJwdFmJaMPAANOgA;

				public double qcguAtCnkDdqtFTUTLWbCFuCEPinB => kBZRcnjaSNIErqajsrEAGzPOxZP;

				public double RafNOefHxmijGKuMhTFAdaAcZqAO => hFdCVjuSDvWrOFwXsOAvhmbnghpi;

				public uint wHREbPUnqTjBaDHLJSSzNuVnzzei => ytSUPBjiBUaYedPLPRSIqgVwuerF;

				public uint MSxlegsApNAmLEqrQlKVjdMgvYNA => VmlxpXTFukdVcEYpPuXzYPFLWLpP;

				public float AQXAChrtoYXTozqUEtGECOuNzCBy => QSvBhpYfhKDLpFpOruoFlSlQFPyfA;

				public float kSAyjrUvLjVLXdinbhbjuWHamXNv => XjUeuUNjueJqkAuLkKUwHfOpcQXD;

				public wizNuJxCYKHKyXNmwvDhPUEBTUxo(UpdateLoopType P_0)
				{
					tVGBDwumtAzmLqzkgFhWvEuiAZwCA = P_0;
					wmSjqFsLlIOVewIWOFUThuVdCvQV = Time.realtimeSinceStartup;
					ytSUPBjiBUaYedPLPRSIqgVwuerF = 0u;
				}

				public void UpRiXrioxsmUpxFPBYjmzhNnKYou()
				{
					kBZRcnjaSNIErqajsrEAGzPOxZP = aARvmsaJRIORMXJwdFmJaMPAANOgA;
					aARvmsaJRIORMXJwdFmJaMPAANOgA = realTime;
					if (wmSjqFsLlIOVewIWOFUThuVdCvQV > aARvmsaJRIORMXJwdFmJaMPAANOgA)
					{
						wmSjqFsLlIOVewIWOFUThuVdCvQV = 0.0;
					}
					hFdCVjuSDvWrOFwXsOAvhmbnghpi = aARvmsaJRIORMXJwdFmJaMPAANOgA - wmSjqFsLlIOVewIWOFUThuVdCvQV;
					wmSjqFsLlIOVewIWOFUThuVdCvQV = aARvmsaJRIORMXJwdFmJaMPAANOgA;
					VmlxpXTFukdVcEYpPuXzYPFLWLpP = ytSUPBjiBUaYedPLPRSIqgVwuerF;
					ytSUPBjiBUaYedPLPRSIqgVwuerF = MiscTools.Tick(ytSUPBjiBUaYedPLPRSIqgVwuerF);
					XjUeuUNjueJqkAuLkKUwHfOpcQXD = QSvBhpYfhKDLpFpOruoFlSlQFPyfA;
					QSvBhpYfhKDLpFpOruoFlSlQFPyfA = KTmmVZcAazRmKtOIPIgdujYOFheIA();
					previousFrame = VmlxpXTFukdVcEYpPuXzYPFLWLpP;
					currentFrame = ytSUPBjiBUaYedPLPRSIqgVwuerF;
					unscaledTime = aARvmsaJRIORMXJwdFmJaMPAANOgA;
					unscaledTimePrev = kBZRcnjaSNIErqajsrEAGzPOxZP;
					unscaledDeltaTime = hFdCVjuSDvWrOFwXsOAvhmbnghpi;
				}
			}

			private static class LEwvqKgAOIiaxRtKmDWjAAQYNDAYA
			{
				public static StopwatchBase LAaRbojcGCbqUdJlfIPixsJdDfZH
				{
					get
					{
						if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
						{
							return UnityStopwatch.Global;
						}
						return Rewired.Utils.Classes.Utility.Stopwatch.Global;
					}
				}

				public static StopwatchBase CjPKqvLiyibbQzbuCnvrWEjaWNMJ()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase DYerzjUFweoBzcicqcqVsXIgCcqN()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase vteCXUERUAEclaOZhqXQJVOTClTic;

			private double XxYGDVLXANCthNTwaLFAiSnVofQs;

			private wizNuJxCYKHKyXNmwvDhPUEBTUxo dpxojnGUsPQkWXmjDQzblUUCptPF;

			private ADictionary<int, wizNuJxCYKHKyXNmwvDhPUEBTUxo> EsmDQzoCvMEKxqHaNqCxGLjiDzeU;

			private uint ojtxXqGzarMHkQkHSeytbtejCdJZ;

			public double vFfSMxirfpwJjwOfoCaigMfAuoptA => dpxojnGUsPQkWXmjDQzblUUCptPF.IcWHnKiOkGfrtvIQiCgQhvIwHBb;

			public double vNHabHTdwNwIEeQHmPabpTsQjjoo => dpxojnGUsPQkWXmjDQzblUUCptPF.qcguAtCnkDdqtFTUTLWbCFuCEPinB;

			public double kXkSpSdPjlGggDbibShWUHIiPMiib => dpxojnGUsPQkWXmjDQzblUUCptPF.RafNOefHxmijGKuMhTFAdaAcZqAO;

			public float xXVFNAglAZJOExqGfjsfXvpfKSUAA => dpxojnGUsPQkWXmjDQzblUUCptPF.AQXAChrtoYXTozqUEtGECOuNzCBy;

			public float qnrFBEJnDhFfuyirNIBZsIwHmOhGA => dpxojnGUsPQkWXmjDQzblUUCptPF.kSAyjrUvLjVLXdinbhbjuWHamXNv;

			internal double hEodQEooqWYAYMEbsSiUeDCRGlr => vteCXUERUAEclaOZhqXQJVOTClTic.elapsedSeconds + XxYGDVLXANCthNTwaLFAiSnVofQs;

			public uint cEozTajOnmfJGFQKIaDoDFLJPtNEA => dpxojnGUsPQkWXmjDQzblUUCptPF.wHREbPUnqTjBaDHLJSSzNuVnzzei;

			public uint klRbEMmeNoDADsWDtUIePnYKaiaJA => dpxojnGUsPQkWXmjDQzblUUCptPF.MSxlegsApNAmLEqrQlKVjdMgvYNA;

			public uint IBOCWsyLMhdxLbQxraheBzdHRArsc => ojtxXqGzarMHkQkHSeytbtejCdJZ;

			public rRqHpKyIhXUtNYpwggzJbYUQGGbo()
			{
				vteCXUERUAEclaOZhqXQJVOTClTic = LEwvqKgAOIiaxRtKmDWjAAQYNDAYA.LAaRbojcGCbqUdJlfIPixsJdDfZH;
				XltXTLFxahhcPJdCPxPmrZFAcGAS();
			}

			public void AlvbRVwUBzkuHGxeyLBHglPLHmWf()
			{
				XxYGDVLXANCthNTwaLFAiSnVofQs = Time.realtimeSinceStartup;
			}

			public void XltXTLFxahhcPJdCPxPmrZFAcGAS()
			{
				dpxojnGUsPQkWXmjDQzblUUCptPF = null;
				EsmDQzoCvMEKxqHaNqCxGLjiDzeU = new ADictionary<int, wizNuJxCYKHKyXNmwvDhPUEBTUxo>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)(-1), list);
				for (int i = 0; i < list.Count; i++)
				{
					wizNuJxCYKHKyXNmwvDhPUEBTUxo value = new wizNuJxCYKHKyXNmwvDhPUEBTUxo(list[i]);
					EsmDQzoCvMEKxqHaNqCxGLjiDzeU.Add((int)list[i], value);
					if (dpxojnGUsPQkWXmjDQzblUUCptPF == null)
					{
						dpxojnGUsPQkWXmjDQzblUUCptPF = value;
					}
				}
			}

			public void JdYLERJewxLHSqOTFtGbDoGPGnbhA(UpdateLoopType P_0)
			{
				if (dpxojnGUsPQkWXmjDQzblUUCptPF.tVGBDwumtAzmLqzkgFhWvEuiAZwCA != P_0)
				{
					dpxojnGUsPQkWXmjDQzblUUCptPF = EsmDQzoCvMEKxqHaNqCxGLjiDzeU[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					dpxojnGUsPQkWXmjDQzblUUCptPF.UpRiXrioxsmUpxFPBYjmzhNnKYou();
					ojtxXqGzarMHkQkHSeytbtejCdJZ = MiscTools.Tick(ojtxXqGzarMHkQkHSeytbtejCdJZ);
					absFrame = ojtxXqGzarMHkQkHSeytbtejCdJZ;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch RXxvnwJhniWCoaPAvnqFdXVzriPe;

			internal static UnityTouch rHEzfTToEhjVkamAeWcyKKozzmrQ => RXxvnwJhniWCoaPAvnqFdXVzriPe ?? (RXxvnwJhniWCoaPAvnqFdXVzriPe = new UnityTouch());

			public int touchCount => Input.touchCount;

			public Touch[] touches => Input.touches;

			public bool simulateMouseWithTouches
			{
				get
				{
					return Input.simulateMouseWithTouches;
				}
				set
				{
					Input.simulateMouseWithTouches = value;
				}
			}

			public bool multiTouchEnabled
			{
				get
				{
					return Input.multiTouchEnabled;
				}
				set
				{
					Input.multiTouchEnabled = value;
				}
			}

			private UnityTouch()
			{
			}

			public Touch GetTouch(int index)
			{
				return Input.GetTouch(index);
			}
		}

		internal class KhjaqffJDNcLNVmJDbSbGbMBdSTZ
		{
			[Serializable]
			private sealed class ZWhRhpVPAkVhMUehoUYAyZfgpOjO
			{
				public static readonly ZWhRhpVPAkVhMUehoUYAyZfgpOjO _003C_003E9 = new ZWhRhpVPAkVhMUehoUYAyZfgpOjO();

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool XAuayRFdlURkvPMSGdxTHvBVswhk()
				{
					return Screen.fullScreen;
				}

				internal bool cQJYNYejaWUWCSdkJHuCpIiZgYhO()
				{
					return Application.runInBackground;
				}

				internal int HVLqnjHHNxpXPMjyfKnEANdWQtbH()
				{
					return (int)Screen.fullScreenMode;
				}

				internal float TdmkxaPaZGphozfWZckmJwVukUqY()
				{
					return Time.unscaledDeltaTime;
				}

				internal bool IDxJLrkGuBOcZIKmDaQOepMzfEisA()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				internal string nXlGUNeupqBZbMuwJwHEPyVmqRun()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}
			}

			public readonly ValueWatcher<bool> FWAtXlgoKMlNhuNiUkVbLnhbFcqC;

			public readonly ValueWatcher<bool> RRytHTbjlRkbVgAPdppCluOQUayi;

			public readonly ValueWatcher<bool> dIyEpbfJQrNgpJFSQqlXYPFlJwrsA;

			public readonly ValueWatcher<bool> NzJyDdibHwIDYLcAWoxfGaqYYgz;

			public readonly ValueWatcher<int> VxvAXjiyBhSxxVtCtYhROXwZlKbM;

			public readonly ValueWatcher<float> yfUHvUPuNnDCaQXfWiUlfzadtQYvA;

			public readonly ValueWatcher<string> kqJTuHZrUdRKrERJmjvtlWnbWKfx;

			public readonly ValueWatcher<bool> fPgIhhbKodJzDtmWBMVqpqElJmHJ;

			private int UmoMJkAqZnqdXmjBLlWNfhjrhbFW;

			private readonly ValueWatcher[] rjtQAcmGXTzHCaqcWiofFiGGBiRj;

			public int bAdLpaarrcYiDVkxmMrhGcJRujcs => UmoMJkAqZnqdXmjBLlWNfhjrhbFW;

			public KhjaqffJDNcLNVmJDbSbGbMBdSTZ()
			{
				bool flag = UnityTools.isEditor || Application.isFocused;
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(FWAtXlgoKMlNhuNiUkVbLnhbFcqC = new ValueWatcher<bool>(flag, false)),
					(RRytHTbjlRkbVgAPdppCluOQUayi = new ValueWatcher<bool>(false, false)),
					(dIyEpbfJQrNgpJFSQqlXYPFlJwrsA = new ValueWatcher<bool>(Screen.fullScreen, ZWhRhpVPAkVhMUehoUYAyZfgpOjO._003C_003E9.XAuayRFdlURkvPMSGdxTHvBVswhk, false)),
					(NzJyDdibHwIDYLcAWoxfGaqYYgz = new ValueWatcher<bool>(Application.runInBackground, ZWhRhpVPAkVhMUehoUYAyZfgpOjO._003C_003E9.cQJYNYejaWUWCSdkJHuCpIiZgYhO, false)),
					(VxvAXjiyBhSxxVtCtYhROXwZlKbM = new ValueWatcher<int>((int)Screen.fullScreenMode, ZWhRhpVPAkVhMUehoUYAyZfgpOjO._003C_003E9.HVLqnjHHNxpXPMjyfKnEANdWQtbH, false)),
					(yfUHvUPuNnDCaQXfWiUlfzadtQYvA = new ValueWatcher<float>(Time.unscaledDeltaTime, ZWhRhpVPAkVhMUehoUYAyZfgpOjO._003C_003E9.TdmkxaPaZGphozfWZckmJwVukUqY, false)),
					(fPgIhhbKodJzDtmWBMVqpqElJmHJ = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), ZWhRhpVPAkVhMUehoUYAyZfgpOjO._003C_003E9.IDxJLrkGuBOcZIKmDaQOepMzfEisA, MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(kqJTuHZrUdRKrERJmjvtlWnbWKfx = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), ZWhRhpVPAkVhMUehoUYAyZfgpOjO._003C_003E9.nXlGUNeupqBZbMuwJwHEPyVmqRun, false));
				}
				rjtQAcmGXTzHCaqcWiofFiGGBiRj = list.ToArray();
				DBsAQnDOvLnEoKkYEqStFHaQuIJi();
			}

			public void DBsAQnDOvLnEoKkYEqStFHaQuIJi()
			{
				for (int i = 0; i < rjtQAcmGXTzHCaqcWiofFiGGBiRj.Length; i++)
				{
					rjtQAcmGXTzHCaqcWiofFiGGBiRj[i].Update();
				}
				UmoMJkAqZnqdXmjBLlWNfhjrhbFW = Time.frameCount;
			}

			public void iDpUANuUonwpQFnyoWdZXKShDiHk()
			{
				for (int i = 0; i < rjtQAcmGXTzHCaqcWiofFiGGBiRj.Length; i++)
				{
					rjtQAcmGXTzHCaqcWiofFiGGBiRj[i].TriggerEvent();
				}
			}
		}

		[Serializable]
		private sealed class epjQvzCxevCODFqbSBTTeKgIuMZx
		{
			public static readonly epjQvzCxevCODFqbSBTTeKgIuMZx _003C_003E9 = new epjQvzCxevCODFqbSBTTeKgIuMZx();

			public static Func<bool> _003C_003E9__235_0;

			internal void GGdMUdtUDxGbXbDfoMJDWMJddBqh(Exception P_0)
			{
				HandleCallbackException("", P_0);
			}

			internal void GwIcSEmNncbtenLQudxNBTnoSQUW(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			}

			internal void hAuxZOSSPcmDkFWOCoFtjzEpVUTc(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			}

			internal void FQIRcFQvbaRYcOAOZcEMoSlOpJBK(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			}

			internal void gQseiHIELUJkqxAelSBsgEmwMTiP(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			}

			internal void YFWEeAkMTLvCGPWfMXjroTFyUiOv(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			}

			internal void bHxLqUnMSBiCscyxktJiZqAsciadA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			}

			internal void vwiMjGFECcbYCjJpzQblgXOIdTDd(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			}

			internal void LISiwybAvYyMbXefbYrXKRqwUKGx(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			}

			internal bool OtuWZCrkTaEtasyyJMtvjQPcPKIE()
			{
				if (isUnityEditorFocused)
				{
					return isAllowedEditorWindowFocused;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 58;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 0;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2022";

		private static InputManager_Base KtIEGhdcGylhgzYJlUuLYApnKRDI;

		private static PlatformInputManager DHXBfYFYgbOleOssuzSOMABxpJKZA;

		internal static lUtCsqIAgfBFkZGlgbTnkPuYJNRDA AwFNwGchWvDBRvqVRzmYbEJcoaxe;

		internal static rvADANidBCTaBLMwFOZPaxTGMMzTB zEtuNvknIQbzOpsTCdeQeEswlwDw;

		internal static HDJfIqxdWXZdIaCSTaUnYnqTqCtx yLMToaDqIzfOcDAFApituELqzLeNA;

		private static ControllerDataFiles jIADwwDowsEdZMpnQUYZDTdMedJDb;

		private static UserData MxboHOxlsDLTuNkINIYZaIjEdbFxA;

		private static bool CgjzkiJPPLUEabkmnyjNrBEwjIUH;

		private static ConfigVars gwuzgsGJfJdbnOQAWmjgZujjhYdd;

		private static UpdateLoopType FPmqRyZUoFrLdPFIrCxKWlhBOZXn;

		private static bool imlEcTwzTpoJbudKKzRpjSUmOZhw;

		private static Platform uAlhaUCazsdBIZSPYIeKXOPJuzZV;

		private static WebplayerPlatform HQLLLGrGMAjynibIGsgfCmWYYbuQ;

		private static EditorPlatform rKihFWPYrfndLNBEyuVdpHuuWhWW;

		private static bool thOEKgKaPESzlOCZxKMfvWFfdLlV;

		private static TimerAbs AmHOrVBvSjmKpFpJmVdLyPcPahhd;

		private static rRqHpKyIhXUtNYpwggzJbYUQGGbo NGkIVJKOwNSfZYAiSfxNmibNDsOfA;

		private static string mYdehugJwBTwFUCWvNBzSJCamAPEb;

		private static bool cNKkeAYvbVetzqsVaaVCntyHFTvi;

		private static bool PsAjBMmJFdEqIGtUnZTMVPGRbFWe;

		private static bool NQzygpxQguWiYiWQjIODIFHPDQyV;

		private static int WGRgGRNVpVuRKTKkkOZrAYfFyJIg;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int iiVPkANRXXGrzfnuwBGaqYZeLRTdA;

		private static int PKYxtjOMKhKyQIJGlOXdJooFjVNE;

		private static bool QwReYYHidYWlVrIkFzkYOxZJCksj;

		private static readonly UnityTouch kZRenkLUFCRLjxHJdwhLSPHBFEwM;

		private static readonly PlayerHelper bZwgWmMYRdTnFUSSxjcYCJxbzimr;

		private static readonly ControllerHelper KLDeOKMMHObItGJEHCstDEiikAOy;

		private static readonly MappingHelper nkdimNuziiCXbsUCLiFDwompGBtX;

		private static readonly TimeHelper vHSHMmeivzXdVzdeIhknAMLYDRchA;

		private static readonly ConfigHelper lEitEaXJcOmnelprBBVvXMSPVLLb;

		private static readonly LocalizationHelper XaFyseYeUdleCtfpWhRDQblOBNXkA;

		private static readonly GlyphHelper MDZqVfvnaXBORHmYygACgZiiXLFjb;

		private static CKzrLWnyJZLZbfvmmNZunMSZGHsh CEgcesYobIALhVmFtkerGVZOcXqk;

		private static UserDataStore iHWAKUwNjfrcKeiQdSsOOcAMenbc;

		private static IControllerAssigner nzyZerqEbthhKJJbWAcItTLHusGKA;

		private static KhjaqffJDNcLNVmJDbSbGbMBdSTZ eUWbKhdpTwNmKDfXmzcdHuElGwkr;

		private static SafeAction<ControllerStatusChangedEventArgs> eFgkSUXFmhQblVOndqCzBfmPCzlp;

		private static SafeAction<ControllerStatusChangedEventArgs> DvYwCwIpRuGglKhaDkTxgfbrIQpF;

		private static SafeAction<ControllerStatusChangedEventArgs> aUIFOBMdgSaxAPTYpAQvLEzUIXCR;

		private static SafeAction btMIkUQZUkIpWUmoRHefmWYcgBGH;

		private static SafeAction HwiLTpgjTiKnNcLdAWzTMuvhicRg;

		private static SafeAction JnYzxAYUKsjojaCFiCgPHVNZqfwIA;

		private static SafeAction ThARXhGsnLoTQLokCOKOLplZQZOM;

		private static SafeAction RJmCHkXraqQTQHZrAUMsQTJCbhUh;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action VtyrbaAOtkKNXwcQTPKrJFrZvqW;

		private static Action<UpdateLoopType> LwXGuglRYWFrxOIdDtQkUbjphrD;

		private static Action<UpdateLoopType> jCboBaaZgkAYRIbXUPMbkXCwaQIr;

		private static Action<UpdateLoopType> GPuAmhjmAEUsJoFdbZEWmJztGehZA;

		private static Action bcYvMuHYODUPQctMMJGsnejMBaMH;

		private static Action<bool> tEgqvfOhRVWpOCJvTtzwreqPFqlM;

		private static Action<bool> YAXyxBLwZXkmcNvWPEJmpWihYDFh;

		private static Action<bool> qBlQneCHQRVRJujPHhqyILgTTDfD;

		private static Action<FullScreenMode> eqHirhNUQpSczBNnboqRHhTDFKhq;

		private static Action rTNvomjDZnNKCgAecwirYJucMmue;

		private static Action<bool> JNhjgcoKtFEAUAdXRKjEMHqHzolPA;

		[CustomObfuscation(rename = false)]
		internal static double unscaledDeltaTime;

		[CustomObfuscation(rename = false)]
		internal static double unscaledTime;

		[CustomObfuscation(rename = false)]
		internal static double unscaledTimePrev;

		[CustomObfuscation(rename = false)]
		internal static uint currentFrame;

		[CustomObfuscation(rename = false)]
		internal static uint previousFrame;

		[CustomObfuscation(rename = false)]
		internal static uint absFrame;

		private static CKzrLWnyJZLZbfvmmNZunMSZGHsh baATMRtCSdLODYONHhaSVHugHBgk => CEgcesYobIALhVmFtkerGVZOcXqk ?? (CEgcesYobIALhVmFtkerGVZOcXqk = new CKzrLWnyJZLZbfvmmNZunMSZGHsh(gwuzgsGJfJdbnOQAWmjgZujjhYdd.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return bZwgWmMYRdTnFUSSxjcYCJxbzimr;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return KLDeOKMMHObItGJEHCstDEiikAOy;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return nkdimNuziiCXbsUCLiFDwompGBtX;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return kZRenkLUFCRLjxHJdwhLSPHBFEwM;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return vHSHMmeivzXdVzdeIhknAMLYDRchA;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return iHWAKUwNjfrcKeiQdSsOOcAMenbc;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return lEitEaXJcOmnelprBBVvXMSPVLLb;
			}
		}

		public static LocalizationHelper localization
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return XaFyseYeUdleCtfpWhRDQblOBNXkA;
			}
		}

		public static GlyphHelper glyphs
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return MDZqVfvnaXBORHmYygACgZiiXLFjb;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 58 + "." + 0 + ".U2022";

		public static bool usingUnityInput => imlEcTwzTpoJbudKKzRpjSUmOZhw;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return false;
				}
				if (isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
				{
					return true;
				}
				return false;
			}
		}

		public static bool isReady => CgjzkiJPPLUEabkmnyjNrBEwjIUH;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => CgjzkiJPPLUEabkmnyjNrBEwjIUH;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => FPmqRyZUoFrLdPFIrCxKWlhBOZXn;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => gwuzgsGJfJdbnOQAWmjgZujjhYdd;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => gwuzgsGJfJdbnOQAWmjgZujjhYdd;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => MxboHOxlsDLTuNkINIYZaIjEdbFxA;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => uAlhaUCazsdBIZSPYIeKXOPJuzZV;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => HQLLLGrGMAjynibIGsgfCmWYYbuQ;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => rKihFWPYrfndLNBEyuVdpHuuWhWW;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.Linux && imlEcTwzTpoJbudKKzRpjSUmOZhw)
				{
					return true;
				}
				if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.OSX && (imlEcTwzTpoJbudKKzRpjSUmOZhw || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && imlEcTwzTpoJbudKKzRpjSUmOZhw)
				{
					return true;
				}
				if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.Webplayer && HQLLLGrGMAjynibIGsgfCmWYYbuQ == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => rKihFWPYrfndLNBEyuVdpHuuWhWW != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return Guid.Empty;
				}
				return jIADwwDowsEdZMpnQUYZDTdMedJDb.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => PsAjBMmJFdEqIGtUnZTMVPGRbFWe;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => NGkIVJKOwNSfZYAiSfxNmibNDsOfA.xXVFNAglAZJOExqGfjsfXvpfKSUAA;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => NGkIVJKOwNSfZYAiSfxNmibNDsOfA.qnrFBEJnDhFfuyirNIBZsIwHmOhGA;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return 0.0;
				}
				return NGkIVJKOwNSfZYAiSfxNmibNDsOfA.hEodQEooqWYAYMEbsSiUeDCRGlr;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return 0;
				}
				return eUWbKhdpTwNmKDfXmzcdHuElGwkr.bAdLpaarrcYiDVkxmMrhGcJRujcs;
			}
		}

		private static bool msvIyBugJJetyIYMppWUSQhUgRJb
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return mYdehugJwBTwFUCWvNBzSJCamAPEb == "Game";
				}
				return mYdehugJwBTwFUCWvNBzSJCamAPEb == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (gwuzgsGJfJdbnOQAWmjgZujjhYdd.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!NQzygpxQguWiYiWQjIODIFHPDQyV)
				{
					return msvIyBugJJetyIYMppWUSQhUgRJb;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (DHXBfYFYgbOleOssuzSOMABxpJKZA is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return NQzygpxQguWiYiWQjIODIFHPDQyV;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return false;
				}
				if (!imlEcTwzTpoJbudKKzRpjSUmOZhw)
				{
					return false;
				}
				if (uAlhaUCazsdBIZSPYIeKXOPJuzZV != Platform.Windows && (uAlhaUCazsdBIZSPYIeKXOPJuzZV != Platform.Webplayer || HQLLLGrGMAjynibIGsgfCmWYYbuQ != WebplayerPlatform.Windows))
				{
					return rKihFWPYrfndLNBEyuVdpHuuWhWW == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool UyffeZwQcqOjVdSQXudHvkMceQmZ
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return false;
				}
				if (!eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.value)
				{
					if (QwReYYHidYWlVrIkFzkYOxZJCksj)
					{
						return false;
					}
					if ((!isEditor || !isUnityEditorFocused) && !eUWbKhdpTwNmKDfXmzcdHuElGwkr.NzJyDdibHwIDYLcAWoxfGaqYYgz.value)
					{
						return false;
					}
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFocused
		{
			get
			{
				if (CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsPaused
		{
			get
			{
				if (CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return eUWbKhdpTwNmKDfXmzcdHuElGwkr.RRytHTbjlRkbVgAPdppCluOQUayi.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return eUWbKhdpTwNmKDfXmzcdHuElGwkr.dIyEpbfJQrNgpJFSQqlXYPFlJwrsA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return eUWbKhdpTwNmKDfXmzcdHuElGwkr.NzJyDdibHwIDYLcAWoxfGaqYYgz.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					return eUWbKhdpTwNmKDfXmzcdHuElGwkr.fPgIhhbKodJzDtmWBMVqpqElJmHJ.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => KtIEGhdcGylhgzYJlUuLYApnKRDI;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
				{
					UFZnagsBNAbpJghymLSkaYksnmTFb();
					return null;
				}
				return DHXBfYFYgbOleOssuzSOMABxpJKZA.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return nzyZerqEbthhKJJbWAcItTLHusGKA;
			}
			set
			{
				nzyZerqEbthhKJJbWAcItTLHusGKA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => PKYxtjOMKhKyQIJGlOXdJooFjVNE;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				eFgkSUXFmhQblVOndqCzBfmPCzlp += value;
			}
			remove
			{
				eFgkSUXFmhQblVOndqCzBfmPCzlp -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				DvYwCwIpRuGglKhaDkTxgfbrIQpF += value;
			}
			remove
			{
				DvYwCwIpRuGglKhaDkTxgfbrIQpF -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				aUIFOBMdgSaxAPTYpAQvLEzUIXCR += value;
			}
			remove
			{
				aUIFOBMdgSaxAPTYpAQvLEzUIXCR -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				btMIkUQZUkIpWUmoRHefmWYcgBGH += value;
			}
			remove
			{
				btMIkUQZUkIpWUmoRHefmWYcgBGH -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				HwiLTpgjTiKnNcLdAWzTMuvhicRg += value;
			}
			remove
			{
				HwiLTpgjTiKnNcLdAWzTMuvhicRg -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				JnYzxAYUKsjojaCFiCgPHVNZqfwIA += value;
			}
			remove
			{
				JnYzxAYUKsjojaCFiCgPHVNZqfwIA -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				ThARXhGsnLoTQLokCOKOLplZQZOM += value;
			}
			remove
			{
				ThARXhGsnLoTQLokCOKOLplZQZOM -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				RJmCHkXraqQTQHZrAUMsQTJCbhUh += value;
			}
			remove
			{
				RJmCHkXraqQTQHZrAUMsQTJCbhUh -= value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationFocusChangedEvent
		{
			add
			{
				_ApplicationFocusChangedEvent = (Action<bool>)Delegate.Combine(_ApplicationFocusChangedEvent, value);
			}
			remove
			{
				_ApplicationFocusChangedEvent = (Action<bool>)Delegate.Remove(_ApplicationFocusChangedEvent, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationPauseChangedEvent
		{
			add
			{
				_ApplicationPauseChangedEvent = (Action<bool>)Delegate.Combine(_ApplicationPauseChangedEvent, value);
			}
			remove
			{
				_ApplicationPauseChangedEvent = (Action<bool>)Delegate.Remove(_ApplicationPauseChangedEvent, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action EarlyUpdateEvent
		{
			add
			{
				VtyrbaAOtkKNXwcQTPKrJFrZvqW = (Action)Delegate.Combine(VtyrbaAOtkKNXwcQTPKrJFrZvqW, value);
			}
			remove
			{
				VtyrbaAOtkKNXwcQTPKrJFrZvqW = (Action)Delegate.Remove(VtyrbaAOtkKNXwcQTPKrJFrZvqW, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				LwXGuglRYWFrxOIdDtQkUbjphrD = (Action<UpdateLoopType>)Delegate.Combine(LwXGuglRYWFrxOIdDtQkUbjphrD, value);
			}
			remove
			{
				LwXGuglRYWFrxOIdDtQkUbjphrD = (Action<UpdateLoopType>)Delegate.Remove(LwXGuglRYWFrxOIdDtQkUbjphrD, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				jCboBaaZgkAYRIbXUPMbkXCwaQIr = (Action<UpdateLoopType>)Delegate.Combine(jCboBaaZgkAYRIbXUPMbkXCwaQIr, value);
			}
			remove
			{
				jCboBaaZgkAYRIbXUPMbkXCwaQIr = (Action<UpdateLoopType>)Delegate.Remove(jCboBaaZgkAYRIbXUPMbkXCwaQIr, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				GPuAmhjmAEUsJoFdbZEWmJztGehZA = (Action<UpdateLoopType>)Delegate.Combine(GPuAmhjmAEUsJoFdbZEWmJztGehZA, value);
			}
			remove
			{
				GPuAmhjmAEUsJoFdbZEWmJztGehZA = (Action<UpdateLoopType>)Delegate.Remove(GPuAmhjmAEUsJoFdbZEWmJztGehZA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				bcYvMuHYODUPQctMMJGsnejMBaMH = (Action)Delegate.Combine(bcYvMuHYODUPQctMMJGsnejMBaMH, value);
			}
			remove
			{
				bcYvMuHYODUPQctMMJGsnejMBaMH = (Action)Delegate.Remove(bcYvMuHYODUPQctMMJGsnejMBaMH, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				tEgqvfOhRVWpOCJvTtzwreqPFqlM = (Action<bool>)Delegate.Combine(tEgqvfOhRVWpOCJvTtzwreqPFqlM, value);
			}
			remove
			{
				tEgqvfOhRVWpOCJvTtzwreqPFqlM = (Action<bool>)Delegate.Remove(tEgqvfOhRVWpOCJvTtzwreqPFqlM, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				YAXyxBLwZXkmcNvWPEJmpWihYDFh = (Action<bool>)Delegate.Combine(YAXyxBLwZXkmcNvWPEJmpWihYDFh, value);
			}
			remove
			{
				YAXyxBLwZXkmcNvWPEJmpWihYDFh = (Action<bool>)Delegate.Remove(YAXyxBLwZXkmcNvWPEJmpWihYDFh, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				qBlQneCHQRVRJujPHhqyILgTTDfD = (Action<bool>)Delegate.Combine(qBlQneCHQRVRJujPHhqyILgTTDfD, value);
			}
			remove
			{
				qBlQneCHQRVRJujPHhqyILgTTDfD = (Action<bool>)Delegate.Remove(qBlQneCHQRVRJujPHhqyILgTTDfD, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				eqHirhNUQpSczBNnboqRHhTDFKhq = (Action<FullScreenMode>)Delegate.Combine(eqHirhNUQpSczBNnboqRHhTDFKhq, value);
			}
			remove
			{
				eqHirhNUQpSczBNnboqRHhTDFKhq = (Action<FullScreenMode>)Delegate.Remove(eqHirhNUQpSczBNnboqRHhTDFKhq, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				rTNvomjDZnNKCgAecwirYJucMmue = (Action)Delegate.Combine(rTNvomjDZnNKCgAecwirYJucMmue, value);
			}
			remove
			{
				rTNvomjDZnNKCgAecwirYJucMmue = (Action)Delegate.Remove(rTNvomjDZnNKCgAecwirYJucMmue, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				JNhjgcoKtFEAUAdXRKjEMHqHzolPA = (Action<bool>)Delegate.Combine(JNhjgcoKtFEAUAdXRKjEMHqHzolPA, value);
			}
			remove
			{
				JNhjgcoKtFEAUAdXRKjEMHqHzolPA = (Action<bool>)Delegate.Remove(JNhjgcoKtFEAUAdXRKjEMHqHzolPA, value);
			}
		}

		static ReInput()
		{
			NQzygpxQguWiYiWQjIODIFHPDQyV = true;
			WGRgGRNVpVuRKTKkkOZrAYfFyJIg = -1;
			_id = -1;
			iiVPkANRXXGrzfnuwBGaqYZeLRTdA = 0;
			kZRenkLUFCRLjxHJdwhLSPHBFEwM = UnityTouch.rHEzfTToEhjVkamAeWcyKKozzmrQ;
			bZwgWmMYRdTnFUSSxjcYCJxbzimr = PlayerHelper.JWkfaXbAzUdNAZdlLItKxncsMAUUA;
			KLDeOKMMHObItGJEHCstDEiikAOy = ControllerHelper.zaUMUBCFRABoiglmiIrrAHgUrbsy;
			nkdimNuziiCXbsUCLiFDwompGBtX = MappingHelper.cBuDlPdBdORENafRTzuWAXBVkgEG;
			vHSHMmeivzXdVzdeIhknAMLYDRchA = TimeHelper.IXySMYnMNgiWTANhnlBBqaidsEHpA;
			lEitEaXJcOmnelprBBVvXMSPVLLb = ConfigHelper.JzRhjhFNqXeaQeZlnrIEtiRNfrkg;
			XaFyseYeUdleCtfpWhRDQblOBNXkA = LocalizationHelper.RaOKdggSpezUHRbHLFjFysmKfXXcA;
			MDZqVfvnaXBORHmYygACgZiiXLFjb = GlyphHelper.ZkOVjyrdIntYibtsakrmtlRYpuOE;
			eFgkSUXFmhQblVOndqCzBfmPCzlp = new SafeAction<ControllerStatusChangedEventArgs>(epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.GwIcSEmNncbtenLQudxNBTnoSQUW);
			DvYwCwIpRuGglKhaDkTxgfbrIQpF = new SafeAction<ControllerStatusChangedEventArgs>(epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.hAuxZOSSPcmDkFWOCoFtjzEpVUTc);
			aUIFOBMdgSaxAPTYpAQvLEzUIXCR = new SafeAction<ControllerStatusChangedEventArgs>(epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.FQIRcFQvbaRYcOAOZcEMoSlOpJBK);
			btMIkUQZUkIpWUmoRHefmWYcgBGH = new SafeAction(epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.gQseiHIELUJkqxAelSBsgEmwMTiP);
			HwiLTpgjTiKnNcLdAWzTMuvhicRg = new SafeAction(epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.YFWEeAkMTLvCGPWfMXjroTFyUiOv);
			JnYzxAYUKsjojaCFiCgPHVNZqfwIA = new SafeAction(epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.bHxLqUnMSBiCscyxktJiZqAsciadA);
			ThARXhGsnLoTQLokCOKOLplZQZOM = new SafeAction(epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.vwiMjGFECcbYCjJpzQblgXOIdTDd);
			RJmCHkXraqQTQHZrAUMsQTJCbhUh = new SafeAction(epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.LISiwybAvYyMbXefbYrXKRqwUKGx);
			SafeDelegate.S_ExceptionHandler = epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.GGdMUdtUDxGbXbDfoMJDWMJddBqh;
		}

		public static void Update()
		{
			if (CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				if (gwuzgsGJfJdbnOQAWmjgZujjhYdd.updateMode != UpdateMode.Manual)
				{
					Logger.LogError("Rewired cannot be updated manually unless Update Mode is set to Manual.");
				}
				else
				{
					KtIEGhdcGylhgzYJlUuLYApnKRDI.DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
				}
			}
		}

		public static void Reset()
		{
			if (CgjzkiJPPLUEabkmnyjNrBEwjIUH && !(KtIEGhdcGylhgzYJlUuLYApnKRDI == null))
			{
				KtIEGhdcGylhgzYJlUuLYApnKRDI.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!UyffeZwQcqOjVdSQXudHvkMceQmZ)
			{
				return false;
			}
			if (rKihFWPYrfndLNBEyuVdpHuuWhWW != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (QwReYYHidYWlVrIkFzkYOxZJCksj)
				{
					if (!eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.value)
					{
						return false;
					}
				}
				else if (!isAllowedEditorWindowFocused)
				{
					return false;
				}
			}
			return true;
		}

		private static void hkiJYMNMGtNTeJaFbTJVVWzTvqbi()
		{
			uAlhaUCazsdBIZSPYIeKXOPJuzZV = UnityTools.platform;
			HQLLLGrGMAjynibIGsgfCmWYYbuQ = UnityTools.webplayerPlatform;
			rKihFWPYrfndLNBEyuVdpHuuWhWW = UnityTools.editorPlatform;
		}

		internal static void dssmoswSSXXfGqrywuweJDuoTcbl(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, UnityTools.amJDSPAsoSsFGKpTfETGMJsMbYUx P_5, Action<Platform> P_6)
		{
			try
			{
				UnityTools.BEZAPDgZfPEHjYqsofsLFjGWikIAA(P_5);
				_id = iiVPkANRXXGrzfnuwBGaqYZeLRTdA;
				iiVPkANRXXGrzfnuwBGaqYZeLRTdA++;
				CgjzkiJPPLUEabkmnyjNrBEwjIUH = true;
				cNKkeAYvbVetzqsVaaVCntyHFTvi = true;
				PsAjBMmJFdEqIGtUnZTMVPGRbFWe = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				KtIEGhdcGylhgzYJlUuLYApnKRDI = P_0;
				gwuzgsGJfJdbnOQAWmjgZujjhYdd = P_2;
				hkiJYMNMGtNTeJaFbTJVVWzTvqbi();
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += tfRoqVROcnlSeVpWTJSZevxDNreU;
				jIADwwDowsEdZMpnQUYZDTdMedJDb = P_3;
				MxboHOxlsDLTuNkINIYZaIjEdbFxA = P_4;
				AmHOrVBvSjmKpFpJmVdLyPcPahhd = new TimerAbs(1.0);
				NGkIVJKOwNSfZYAiSfxNmibNDsOfA = new rRqHpKyIhXUtNYpwggzJbYUQGGbo();
				LocalizationManager.Initialize();
				GlyphManager.Initialize();
				P_4.ConlhwNdIwTcpOXGdDxKiLtjTVhb();
				ThreadSafeUnityInput.Initialize();
				eUWbKhdpTwNmKDfXmzcdHuElGwkr = new KhjaqffJDNcLNVmJDbSbGbMBdSTZ();
				if (!UnityTools.isEditor)
				{
					NQzygpxQguWiYiWQjIODIFHPDQyV = Application.isFocused;
				}
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.Set(NQzygpxQguWiYiWQjIODIFHPDQyV);
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.Use();
				if (rKihFWPYrfndLNBEyuVdpHuuWhWW != EditorPlatform.None)
				{
					eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.getValueDelegate = epjQvzCxevCODFqbSBTTeKgIuMZx._003C_003E9.OtuWZCrkTaEtasyyJMtvjQPcPKIE;
					if (PsAjBMmJFdEqIGtUnZTMVPGRbFWe)
					{
						NQzygpxQguWiYiWQjIODIFHPDQyV = msvIyBugJJetyIYMppWUSQhUgRJb;
					}
					eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				tJpnUFhtidHtgSvWygIgEupMaFWU();
				uVdJZSeCFZsKseCYgtjsueKlblbj(P_1, P_5, P_6);
				AwFNwGchWvDBRvqVRzmYbEJcoaxe = new lUtCsqIAgfBFkZGlgbTnkPuYJNRDA(P_4.GetActions_Copy());
				zEtuNvknIQbzOpsTCdeQeEswlwDw = new rvADANidBCTaBLMwFOZPaxTGMMzTB(P_2, DHXBfYFYgbOleOssuzSOMABxpJKZA);
				yLMToaDqIzfOcDAFApituELqzLeNA = new HDJfIqxdWXZdIaCSTaUnYnqTqCtx(P_2);
				DHXBfYFYgbOleOssuzSOMABxpJKZA.DeviceConnectedEvent += hsucYkOLYCCbkDjmhMZaATszeKAF;
				DHXBfYFYgbOleOssuzSOMABxpJKZA.DeviceDisconnectedEvent += yCMNpqBCfKfTtEyoSIEGmVezSfsN;
				DHXBfYFYgbOleOssuzSOMABxpJKZA.UpdateControllerInfoEvent += yKNDepgEsTYNufXkoIsoaCEcNuPb;
				zEtuNvknIQbzOpsTCdeQeEswlwDw.TRTBvOLkgojePeyYLPZtPxyOWXvTA += sldaACBGfjibKPDbzJHwDxKeRfNhA;
				zEtuNvknIQbzOpsTCdeQeEswlwDw.nDoOzSNQExaMLQhpCopXHmvtBcSJA += yLMToaDqIzfOcDAFApituELqzLeNA.dDnZgevEYuejaexoiZuYFnKIjvArA;
				ThreadSafeUnityInput.PostInitialize();
				sYuFMTmawmVleipYJfkpFQrDDkDO();
				ThreadSafeUnityInput.PostInitialize2();
				iHWAKUwNjfrcKeiQdSsOOcAMenbc = UnityTools.GetComponent<UserDataStore>(KtIEGhdcGylhgzYJlUuLYApnKRDI);
				if (iHWAKUwNjfrcKeiQdSsOOcAMenbc != null)
				{
					iHWAKUwNjfrcKeiQdSsOOcAMenbc.Initialize();
				}
				eSKdBujHqoYUQLRVvUsEJRMeAtPfA();
				cNKkeAYvbVetzqsVaaVCntyHFTvi = false;
				if (PsAjBMmJFdEqIGtUnZTMVPGRbFWe)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (RJmCHkXraqQTQHZrAUMsQTJCbhUh != null)
				{
					RJmCHkXraqQTQHZrAUMsQTJCbhUh.Invoke();
				}
			}
			catch (Exception)
			{
				CgjzkiJPPLUEabkmnyjNrBEwjIUH = false;
				cNKkeAYvbVetzqsVaaVCntyHFTvi = false;
				throw;
			}
		}

		internal static void tbFbwsEDVlNtPBYbXlzrrStSJABP()
		{
			if (NGkIVJKOwNSfZYAiSfxNmibNDsOfA != null)
			{
				NGkIVJKOwNSfZYAiSfxNmibNDsOfA.AlvbRVwUBzkuHGxeyLBHglPLHmWf();
			}
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < zEtuNvknIQbzOpsTCdeQeEswlwDw.LkbCNXDBSBeJusZHNRPbRWQxbsRl; i++)
				{
					Joystick joystick = zEtuNvknIQbzOpsTCdeQeEswlwDw.PWbnnHEjRpDetJqMBgOLbJodoqfE[i];
					wrAtHiMPhnfqwFZsnJYLDzRfzkZY(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		internal static void TFngseMrhJgIIJntLiTkvjRkyEZaA(UpdateLoopType P_0)
		{
			if (CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				dVbYlGdsLeePmHkPsEelxxjQEkiw(P_0);
				if ((uint)P_0 <= 1u)
				{
					OtXHVAUVOBqSOSSeWZHEVZayuvTE();
				}
			}
		}

		private static void dVbYlGdsLeePmHkPsEelxxjQEkiw(UpdateLoopType P_0)
		{
			if (eUWbKhdpTwNmKDfXmzcdHuElGwkr != null)
			{
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.DBsAQnDOvLnEoKkYEqStFHaQuIJi();
			}
			Action<UpdateLoopType> lwXGuglRYWFrxOIdDtQkUbjphrD = LwXGuglRYWFrxOIdDtQkUbjphrD;
			if (lwXGuglRYWFrxOIdDtQkUbjphrD != null)
			{
				try
				{
					lwXGuglRYWFrxOIdDtQkUbjphrD(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.BeforeTimeManagerUpdateEvent", exception);
				}
			}
			NGkIVJKOwNSfZYAiSfxNmibNDsOfA.JdYLERJewxLHSqOTFtGbDoGPGnbhA(P_0);
		}

		private static void OtXHVAUVOBqSOSSeWZHEVZayuvTE()
		{
			int frameCount = Time.frameCount;
			if (WGRgGRNVpVuRKTKkkOZrAYfFyJIg == frameCount)
			{
				return;
			}
			WGRgGRNVpVuRKTKkkOZrAYfFyJIg = frameCount;
			ThreadSafeUnityInput.Update();
			Action vtyrbaAOtkKNXwcQTPKrJFrZvqW = VtyrbaAOtkKNXwcQTPKrJFrZvqW;
			if (vtyrbaAOtkKNXwcQTPKrJFrZvqW == null)
			{
				return;
			}
			try
			{
				vtyrbaAOtkKNXwcQTPKrJFrZvqW();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.EarlyUpdateEvent", exception);
			}
		}

		internal static void FhWOZsggaFCRaZsidilrDcytCTmMA(UpdateLoopType P_0)
		{
			if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				return;
			}
			if (FPmqRyZUoFrLdPFIrCxKWlhBOZXn != P_0)
			{
				FPmqRyZUoFrLdPFIrCxKWlhBOZXn = P_0;
			}
			if (editorPlatform != EditorPlatform.None)
			{
				mYdehugJwBTwFUCWvNBzSJCamAPEb = eUWbKhdpTwNmKDfXmzcdHuElGwkr.kqJTuHZrUdRKrERJmjvtlWnbWKfx.value;
			}
			if (thOEKgKaPESzlOCZxKMfvWFfdLlV)
			{
				if (AmHOrVBvSjmKpFpJmVdLyPcPahhd.Update())
				{
					thOEKgKaPESzlOCZxKMfvWFfdLlV = false;
					AmHOrVBvSjmKpFpJmVdLyPcPahhd.Clear();
				}
				else
				{
					baATMRtCSdLODYONHhaSVHugHBgk.LDpwVlWbVjKAeIRJWypwqGFEBOWk(P_0);
				}
			}
			eUWbKhdpTwNmKDfXmzcdHuElGwkr.iDpUANuUonwpQFnyoWdZXKShDiHk();
			Action<UpdateLoopType> action = jCboBaaZgkAYRIbXUPMbkXCwaQIr;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.UpdateStartedEvent", exception);
				}
			}
			DHXBfYFYgbOleOssuzSOMABxpJKZA.Update(P_0);
			if (btMIkUQZUkIpWUmoRHefmWYcgBGH != null)
			{
				btMIkUQZUkIpWUmoRHefmWYcgBGH.Invoke();
			}
			zEtuNvknIQbzOpsTCdeQeEswlwDw.cATzubNdIyFPDPSctiuQhaiENxvm(P_0);
			Action<UpdateLoopType> gPuAmhjmAEUsJoFdbZEWmJztGehZA = GPuAmhjmAEUsJoFdbZEWmJztGehZA;
			if (gPuAmhjmAEUsJoFdbZEWmJztGehZA == null)
			{
				return;
			}
			try
			{
				gPuAmhjmAEUsJoFdbZEWmJztGehZA(P_0);
			}
			catch (Exception exception2)
			{
				HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
			}
		}

		internal static void rZBPDYNFwpVkSTbVTZpXDJejCsJW()
		{
			Action action = bcYvMuHYODUPQctMMJGsnejMBaMH;
			if (action != null)
			{
				try
				{
					action();
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.LateUpdateEvent", exception);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
			if (CgjzkiJPPLUEabkmnyjNrBEwjIUH && PsAjBMmJFdEqIGtUnZTMVPGRbFWe)
			{
				TFngseMrhJgIIJntLiTkvjRkyEZaA(UpdateLoopType.Update);
				FhWOZsggaFCRaZsidilrDcytCTmMA(UpdateLoopType.Update);
				rZBPDYNFwpVkSTbVTZpXDJejCsJW();
			}
		}

		internal static void TBgXUfbmBYODdNHdOSveXjyCBSLo()
		{
			if (JnYzxAYUKsjojaCFiCgPHVNZqfwIA != null)
			{
				JnYzxAYUKsjojaCFiCgPHVNZqfwIA.Invoke();
			}
			if (DHXBfYFYgbOleOssuzSOMABxpJKZA != null)
			{
				DHXBfYFYgbOleOssuzSOMABxpJKZA.OnDestroy();
			}
			pUYoZcOLSeJQVcWAbhwgWDyPwvnH();
			if (ThARXhGsnLoTQLokCOKOLplZQZOM != null)
			{
				ThARXhGsnLoTQLokCOKOLplZQZOM.Invoke();
				ThARXhGsnLoTQLokCOKOLplZQZOM = null;
			}
		}

		internal static void jBLTJZRGATWGsqKLdEGwsHkDqsqG()
		{
			if (HwiLTpgjTiKnNcLdAWzTMuvhicRg != null)
			{
				HwiLTpgjTiKnNcLdAWzTMuvhicRg.Invoke();
			}
		}

		internal static void AxiDcWUBWsAafeGKYNyNRegxhJVGb(bool P_0)
		{
			NQzygpxQguWiYiWQjIODIFHPDQyV = P_0;
			if (rKihFWPYrfndLNBEyuVdpHuuWhWW == EditorPlatform.None && CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.Set(P_0);
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.TriggerEvent();
			}
		}

		internal static void eUpNJxBTnrHDvfuvwTSuYlafNbkq(bool P_0)
		{
			if (CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.RRytHTbjlRkbVgAPdppCluOQUayi.Set(P_0);
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.RRytHTbjlRkbVgAPdppCluOQUayi.TriggerEvent();
			}
		}

		internal static void ltHxLukkbhePSbKkCkrXTjSCMYDXA()
		{
			if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				return;
			}
			Action action = rTNvomjDZnNKCgAecwirYJucMmue;
			if (action == null)
			{
				return;
			}
			try
			{
				action();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.SceneLoadedEvent", exception);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return jIADwwDowsEdZMpnQUYZDTdMedJDb.RsZhfHLkrSfOaCHswjERhSpfpzeG(bridgedController);
		}

		internal static HardwareJoystickMap GZYjWVUdmdkTMPFsQxRGwNaiqIti(Guid P_0)
		{
			return jIADwwDowsEdZMpnQUYZDTdMedJDb.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap CNgRtkFCcAwxwwHdhaQFCMvyjprj(Guid P_0)
		{
			return jIADwwDowsEdZMpnQUYZDTdMedJDb.GetJoystickTemplate(P_0);
		}

		internal static aeTKcrzfQkODTQybGHqaOyCSCntK DytaXyfbAbvOuJTDkhfxSrywpOvW(Guid P_0)
		{
			return jIADwwDowsEdZMpnQUYZDTdMedJDb.RdHErwqZumdNWglnFCBLeTfvNNngA(P_0);
		}

		internal static IHardwareControllerTemplateMap fYDhXpHpALIwclUYhoVvbOfaEXYbA(Guid P_0)
		{
			return jIADwwDowsEdZMpnQUYZDTdMedJDb.GetControllerTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap wbpftmQsWwIyecJDDGooJHMdNqnC(Guid P_0)
		{
			return jIADwwDowsEdZMpnQUYZDTdMedJDb.IUzmZIFMyTBnJcguSDJIbzJjDAQGA(P_0);
		}

		internal static IList<aeTKcrzfQkODTQybGHqaOyCSCntK> felssdrBYeMGPKlPWlzZWPgzaqeV(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = jIADwwDowsEdZMpnQUYZDTdMedJDb.GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap == null)
			{
				return EmptyObjects<aeTKcrzfQkODTQybGHqaOyCSCntK>.EmptyReadOnlyIListT;
			}
			string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
			if (templateGuidsOrig == null || templateGuidsOrig.Length == 0)
			{
				return EmptyObjects<aeTKcrzfQkODTQybGHqaOyCSCntK>.EmptyReadOnlyIListT;
			}
			List<aeTKcrzfQkODTQybGHqaOyCSCntK> list = null;
			for (int i = 0; i < templateGuidsOrig.Length; i++)
			{
				Guid guid;
				try
				{
					guid = new Guid(templateGuidsOrig[i]);
				}
				catch
				{
					Logger.LogWarning("Controller Template GUID is invalid: " + templateGuidsOrig[i]);
					continue;
				}
				aeTKcrzfQkODTQybGHqaOyCSCntK aeTKcrzfQkODTQybGHqaOyCSCntK2 = DytaXyfbAbvOuJTDkhfxSrywpOvW(guid);
				if (aeTKcrzfQkODTQybGHqaOyCSCntK2 == null)
				{
					Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
					continue;
				}
				if (list == null)
				{
					list = new List<aeTKcrzfQkODTQybGHqaOyCSCntK>();
				}
				ListTools.AddIfUnique(list, aeTKcrzfQkODTQybGHqaOyCSCntK2);
			}
			if (list == null)
			{
				return EmptyObjects<aeTKcrzfQkODTQybGHqaOyCSCntK>.EmptyReadOnlyIListT;
			}
			return list;
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return zEtuNvknIQbzOpsTCdeQeEswlwDw.gEDdzpLkBWiuJgkOGISNpNPMikp();
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleCallbackException(string source, Exception exception)
		{
			string msg = "An exception occurred inside an event handler or callback.\nSource: " + source + "\n\nThis happens if your event handler/callback code throws an exception. This means the error is in your code, not Rewired. Read the exception message and the stack trace carefully to find the source of the exception being thrown by your code.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed. Make sure you unsubscribe to events in OnDisable or OnDestroy. Rewired will attempt to continue running.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception);
			Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, msg, requiredThreadSafety: true);
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternException(string source, Exception exception)
		{
			Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, string.Empty, requiredThreadSafety: true);
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternalInterfaceException(string source, Exception exception)
		{
			string msg = "An exception occurred inside an external function call.\nSource: " + source + "\n\nThis happens if the external function throws an exception. This could indicate the error is in your code if Rewired is calling a function in an interface implementation you created. Read the exception message and the stack trace carefully to find the source of the exception being thrown.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception);
			Logger.LogException((exception.InnerException != null) ? exception.InnerException : exception, msg, requiredThreadSafety: true);
		}

		internal static void OaypaBirBVUgrVVjLMIxBDfRWHnX()
		{
			if (CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				eSKdBujHqoYUQLRVvUsEJRMeAtPfA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2022 != UnityTools.unityVersionObj.major)
			{
				oNwvhxPnLFqXUpUSGPUvOIrXEOrp();
			}
		}

		internal static float KTmmVZcAazRmKtOIPIgdujYOFheIA()
		{
			return eUWbKhdpTwNmKDfXmzcdHuElGwkr.yfUHvUPuNnDCaQXfWiUlfzadtQYvA.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				Logger.LogError("Rewired is not initialized. You must have an active and enabled Rewired Input Manager in the scene before calling any part of the Rewired API.");
				return false;
			}
			return true;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized(int reInputId)
		{
			if (!CheckInitialized())
			{
				return false;
			}
			if (_id != reInputId)
			{
				Logger.LogError("You are attemping to access an object that was created by a previous session or different instance of Rewired and is no longer valid. When Rewired is reset or the Rewired Input Manager is disabled or destroyed, all old object references become invalid and can no longer be used. If you deinitialize Rewired, you cannot use locally stored Rewired objects obtained prior to deinitialization and you must get new objects from the Rewired API.");
				return false;
			}
			return true;
		}

		private static void sYuFMTmawmVleipYJfkpFQrDDkDO()
		{
			yLMToaDqIzfOcDAFApituELqzLeNA.BOFhvxzqbxSctgIWuUWExnJjuUSJ();
			zEtuNvknIQbzOpsTCdeQeEswlwDw.WjuvJAnKsiKatPxSDLkAvcmdzEMU(DHXBfYFYgbOleOssuzSOMABxpJKZA.GetInputDataUpdateDelegate(), MxboHOxlsDLTuNkINIYZaIjEdbFxA.GetInputBehaviors_Copy());
			DHXBfYFYgbOleOssuzSOMABxpJKZA.Initialize();
		}

		private static void pUYoZcOLSeJQVcWAbhwgWDyPwvnH()
		{
			if (KtIEGhdcGylhgzYJlUuLYApnKRDI != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(KtIEGhdcGylhgzYJlUuLYApnKRDI);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			KtIEGhdcGylhgzYJlUuLYApnKRDI = null;
			DHXBfYFYgbOleOssuzSOMABxpJKZA = null;
			AwFNwGchWvDBRvqVRzmYbEJcoaxe = null;
			if (zEtuNvknIQbzOpsTCdeQeEswlwDw != null)
			{
				zEtuNvknIQbzOpsTCdeQeEswlwDw.Dispose();
			}
			zEtuNvknIQbzOpsTCdeQeEswlwDw = null;
			yLMToaDqIzfOcDAFApituELqzLeNA = null;
			jIADwwDowsEdZMpnQUYZDTdMedJDb = null;
			if (MxboHOxlsDLTuNkINIYZaIjEdbFxA != null)
			{
				MxboHOxlsDLTuNkINIYZaIjEdbFxA.zOarXVqOHXEMjKLFSBRILkeVfrwR();
			}
			MxboHOxlsDLTuNkINIYZaIjEdbFxA = null;
			LocalizationHelper.rZBUVCfrIEcVzzpTyVupkAhKFpoC();
			GlyphHelper.BnutHAbnGiDvzByQQVjlGQVdDwWRA();
			LocalizationManager.Deinitialize();
			GlyphManager.Deinitialize();
			nzyZerqEbthhKJJbWAcItTLHusGKA = null;
			CgjzkiJPPLUEabkmnyjNrBEwjIUH = false;
			gwuzgsGJfJdbnOQAWmjgZujjhYdd = null;
			FPmqRyZUoFrLdPFIrCxKWlhBOZXn = UpdateLoopType.Update;
			imlEcTwzTpoJbudKKzRpjSUmOZhw = false;
			uAlhaUCazsdBIZSPYIeKXOPJuzZV = Platform.Windows;
			HQLLLGrGMAjynibIGsgfCmWYYbuQ = WebplayerPlatform.None;
			rKihFWPYrfndLNBEyuVdpHuuWhWW = EditorPlatform.None;
			thOEKgKaPESzlOCZxKMfvWFfdLlV = false;
			AmHOrVBvSjmKpFpJmVdLyPcPahhd = null;
			NGkIVJKOwNSfZYAiSfxNmibNDsOfA = null;
			mYdehugJwBTwFUCWvNBzSJCamAPEb = null;
			QwReYYHidYWlVrIkFzkYOxZJCksj = false;
			PsAjBMmJFdEqIGtUnZTMVPGRbFWe = false;
			NQzygpxQguWiYiWQjIODIFHPDQyV = true;
			WGRgGRNVpVuRKTKkkOZrAYfFyJIg = -1;
			_id = -1;
			PKYxtjOMKhKyQIJGlOXdJooFjVNE = 0;
			unscaledDeltaTime = 0.0;
			unscaledTime = 0.0;
			unscaledTimePrev = 0.0;
			currentFrame = 0u;
			previousFrame = 0u;
			absFrame = 0u;
			eFgkSUXFmhQblVOndqCzBfmPCzlp.Clear();
			DvYwCwIpRuGglKhaDkTxgfbrIQpF.Clear();
			aUIFOBMdgSaxAPTYpAQvLEzUIXCR.Clear();
			btMIkUQZUkIpWUmoRHefmWYcgBGH.Clear();
			HwiLTpgjTiKnNcLdAWzTMuvhicRg.Clear();
			_ApplicationFocusChangedEvent = null;
			_ApplicationPauseChangedEvent = null;
			tEgqvfOhRVWpOCJvTtzwreqPFqlM = null;
			YAXyxBLwZXkmcNvWPEJmpWihYDFh = null;
			eqHirhNUQpSczBNnboqRHhTDFKhq = null;
			qBlQneCHQRVRJujPHhqyILgTTDfD = null;
			VtyrbaAOtkKNXwcQTPKrJFrZvqW = null;
			jCboBaaZgkAYRIbXUPMbkXCwaQIr = null;
			GPuAmhjmAEUsJoFdbZEWmJztGehZA = null;
			bcYvMuHYODUPQctMMJGsnejMBaMH = null;
			JnYzxAYUKsjojaCFiCgPHVNZqfwIA = null;
			rTNvomjDZnNKCgAecwirYJucMmue = null;
			JNhjgcoKtFEAUAdXRKjEMHqHzolPA = null;
			suMOOvJoUswkZXcItStuLqKpFVZw();
			eUWbKhdpTwNmKDfXmzcdHuElGwkr = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= tfRoqVROcnlSeVpWTJSZevxDNreU;
			}
			if (NaCVyIMwuDhgdNZldvvjhuHYfOGS.gWMFbUBERbzpcApqKNWTmCSqQImmA)
			{
				NaCVyIMwuDhgdNZldvvjhuHYfOGS.XPlvqLUQYNcpUqjFjekMhKyLBQWU();
			}
		}

		private static void xWIBJtaulLNKhCmRSYPmOeJBzTHqA(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void AgRzXgdvqwZvRNpjOmPrHDpDKjpN()
		{
			if (!thOEKgKaPESzlOCZxKMfvWFfdLlV)
			{
				thOEKgKaPESzlOCZxKMfvWFfdLlV = true;
				baATMRtCSdLODYONHhaSVHugHBgk.ZvljicoTwzRMdciHGONoWZZAKwFF();
				baATMRtCSdLODYONHhaSVHugHBgk.pQOvzBMALFerIgHviJPpCsMuRHYBb();
			}
			AmHOrVBvSjmKpFpJmVdLyPcPahhd.Start();
		}

		private static void UFZnagsBNAbpJghymLSkaYksnmTFb()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void hsucYkOLYCCbkDjmhMZaATszeKAF(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			zEtuNvknIQbzOpsTCdeQeEswlwDw.CcJGgTPbioYNwYtiFfhhBcRQwAzM(P_0);
			Joystick joystick = zEtuNvknIQbzOpsTCdeQeEswlwDw.OxrgsiKBGdmiKjOdZinhwnxwTyjnA(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				yLMToaDqIzfOcDAFApituELqzLeNA.bRktJgjfATCZDAwQEOsgRtPJkBsT(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !cNKkeAYvbVetzqsVaaVCntyHFTvi)
				{
					wrAtHiMPhnfqwFZsnJYLDzRfzkZY(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void yCMNpqBCfKfTtEyoSIEGmVezSfsN(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = zEtuNvknIQbzOpsTCdeQeEswlwDw.OxrgsiKBGdmiKjOdZinhwnxwTyjnA(P_0.rewiredId);
				if (joystick != null)
				{
					zEtuNvknIQbzOpsTCdeQeEswlwDw.PtjHyheWFBGtQuReuvBvkOJSzNEh(P_0.rewiredId);
					HFsgdOxTdNgNmkLOuPYDdcclwsRt(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void wrAtHiMPhnfqwFZsnJYLDzRfzkZY(ControllerStatusChangedEventArgs P_0)
		{
			if (eFgkSUXFmhQblVOndqCzBfmPCzlp != null)
			{
				eFgkSUXFmhQblVOndqCzBfmPCzlp.Invoke(P_0);
			}
		}

		private static void sldaACBGfjibKPDbzJHwDxKeRfNhA(ControllerStatusChangedEventArgs P_0)
		{
			if (DvYwCwIpRuGglKhaDkTxgfbrIQpF != null)
			{
				DvYwCwIpRuGglKhaDkTxgfbrIQpF.Invoke(P_0);
			}
		}

		private static void HFsgdOxTdNgNmkLOuPYDdcclwsRt(ControllerStatusChangedEventArgs P_0)
		{
			if (aUIFOBMdgSaxAPTYpAQvLEzUIXCR != null)
			{
				aUIFOBMdgSaxAPTYpAQvLEzUIXCR.Invoke(P_0);
			}
		}

		private static void yKNDepgEsTYNufXkoIsoaCEcNuPb(UpdateControllerInfoEventArgs P_0)
		{
			zEtuNvknIQbzOpsTCdeQeEswlwDw.olUGwnkOpYtjBzBtxvmTuLEhXbeK(P_0);
		}

		private static void tRTnmwezadQzDHgtlOtegzFjDelT(bool P_0)
		{
			if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				return;
			}
			Action<bool> applicationFocusChangedEvent = _ApplicationFocusChangedEvent;
			if (applicationFocusChangedEvent == null)
			{
				return;
			}
			try
			{
				applicationFocusChangedEvent(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.ApplicationFocusChangedEvent", exception);
			}
		}

		private static void vETuQNCqTIjWAsqKIiUbVnkJgTTt(bool P_0)
		{
			if (!CgjzkiJPPLUEabkmnyjNrBEwjIUH)
			{
				return;
			}
			Action<bool> applicationPauseChangedEvent = _ApplicationPauseChangedEvent;
			if (applicationPauseChangedEvent == null)
			{
				return;
			}
			try
			{
				applicationPauseChangedEvent(P_0);
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.ApplicationPauseChangedEvent", exception);
			}
		}

		private static void fOrlVqwpGFFiPoiiTCAfiTRLdwHw(bool P_0)
		{
			Action<bool> action = tEgqvfOhRVWpOCJvTtzwreqPFqlM;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void wOCARSqAHwTXKlhdQofkhMwkJdFM(int P_0)
		{
			if (eqHirhNUQpSczBNnboqRHhTDFKhq != null)
			{
				try
				{
					eqHirhNUQpSczBNnboqRHhTDFKhq((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void TorCpkwXlwGvsLiVZmzxMGxzZobJ(bool P_0)
		{
			Action<bool> yAXyxBLwZXkmcNvWPEJmpWihYDFh = YAXyxBLwZXkmcNvWPEJmpWihYDFh;
			if (yAXyxBLwZXkmcNvWPEJmpWihYDFh != null)
			{
				try
				{
					yAXyxBLwZXkmcNvWPEJmpWihYDFh(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationRunInBackgroundChangedEvent", exception);
				}
			}
		}

		private static void XHVnNVivueMgvsHiZHeYwDZBhZtAA(bool P_0)
		{
			PKYxtjOMKhKyQIJGlOXdJooFjVNE++;
			Action<bool> action = qBlQneCHQRVRJujPHhqyILgTTDfD;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void tJpnUFhtidHtgSvWygIgEupMaFWU()
		{
			if (eUWbKhdpTwNmKDfXmzcdHuElGwkr != null)
			{
				suMOOvJoUswkZXcItStuLqKpFVZw();
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.ChangedEvent += tRTnmwezadQzDHgtlOtegzFjDelT;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.RRytHTbjlRkbVgAPdppCluOQUayi.ChangedEvent += vETuQNCqTIjWAsqKIiUbVnkJgTTt;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.dIyEpbfJQrNgpJFSQqlXYPFlJwrsA.ChangedEvent += fOrlVqwpGFFiPoiiTCAfiTRLdwHw;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.NzJyDdibHwIDYLcAWoxfGaqYYgz.ChangedEvent += TorCpkwXlwGvsLiVZmzxMGxzZobJ;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.VxvAXjiyBhSxxVtCtYhROXwZlKbM.ChangedEvent += wOCARSqAHwTXKlhdQofkhMwkJdFM;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.fPgIhhbKodJzDtmWBMVqpqElJmHJ.ChangedEvent += XHVnNVivueMgvsHiZHeYwDZBhZtAA;
			}
		}

		private static void suMOOvJoUswkZXcItStuLqKpFVZw()
		{
			if (eUWbKhdpTwNmKDfXmzcdHuElGwkr != null)
			{
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.FWAtXlgoKMlNhuNiUkVbLnhbFcqC.ChangedEvent -= tRTnmwezadQzDHgtlOtegzFjDelT;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.RRytHTbjlRkbVgAPdppCluOQUayi.ChangedEvent -= vETuQNCqTIjWAsqKIiUbVnkJgTTt;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.dIyEpbfJQrNgpJFSQqlXYPFlJwrsA.ChangedEvent -= fOrlVqwpGFFiPoiiTCAfiTRLdwHw;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.NzJyDdibHwIDYLcAWoxfGaqYYgz.ChangedEvent -= TorCpkwXlwGvsLiVZmzxMGxzZobJ;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.VxvAXjiyBhSxxVtCtYhROXwZlKbM.ChangedEvent -= wOCARSqAHwTXKlhdQofkhMwkJdFM;
				eUWbKhdpTwNmKDfXmzcdHuElGwkr.fPgIhhbKodJzDtmWBMVqpqElJmHJ.ChangedEvent -= XHVnNVivueMgvsHiZHeYwDZBhZtAA;
			}
		}

		private static void tfRoqVROcnlSeVpWTJSZevxDNreU(bool P_0)
		{
			Action<bool> jNhjgcoKtFEAUAdXRKjEMHqHzolPA = JNhjgcoKtFEAUAdXRKjEMHqHzolPA;
			if (jNhjgcoKtFEAUAdXRKjEMHqHzolPA != null)
			{
				try
				{
					jNhjgcoKtFEAUAdXRKjEMHqHzolPA(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.EditorPauseChangedEvent", exception);
				}
			}
		}

		private static void uVdJZSeCFZsKseCYgtjsueKlblbj(Func<ConfigVars, object> P_0, UnityTools.amJDSPAsoSsFGKpTfETGMJsMbYUx P_1, Action<Platform> P_2)
		{
			bool flag = false;
			if (P_1.hXikvhrgLYyqQzWzHRKvCsZVMYHT != P_1.HmfYsdTKnbYRlUQZnnozMmgaHnTHA)
			{
				UnityTools.amJDSPAsoSsFGKpTfETGMJsMbYUx amJDSPAsoSsFGKpTfETGMJsMbYUx = P_1;
				amJDSPAsoSsFGKpTfETGMJsMbYUx.hXikvhrgLYyqQzWzHRKvCsZVMYHT = P_1.HmfYsdTKnbYRlUQZnnozMmgaHnTHA;
				UnityTools.BEZAPDgZfPEHjYqsofsLFjGWikIAA(amJDSPAsoSsFGKpTfETGMJsMbYUx);
				P_2(amJDSPAsoSsFGKpTfETGMJsMbYUx.HmfYsdTKnbYRlUQZnnozMmgaHnTHA);
				hkiJYMNMGtNTeJaFbTJVVWzTvqbi();
				flag = true;
			}
			if (!configVars.DoesPlatformUseFallback(P_1.HmfYsdTKnbYRlUQZnnozMmgaHnTHA, P_1.UVzLeanWmLAGrqmxnJAMbnhpuOVi, isEditor) && !configVars.DoesPlatformUseFallback(P_1.hXikvhrgLYyqQzWzHRKvCsZVMYHT, P_1.UVzLeanWmLAGrqmxnJAMbnhpuOVi, isEditor))
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(KtIEGhdcGylhgzYJlUuLYApnKRDI);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(P_1.HmfYsdTKnbYRlUQZnnozMmgaHnTHA, gwuzgsGJfJdbnOQAWmjgZujjhYdd) is PlatformInputManager dHXBfYFYgbOleOssuzSOMABxpJKZA)
					{
						DHXBfYFYgbOleOssuzSOMABxpJKZA = dHXBfYFYgbOleOssuzSOMABxpJKZA;
						return;
					}
				}
			}
			if (flag)
			{
				UnityTools.BEZAPDgZfPEHjYqsofsLFjGWikIAA(P_1);
				P_2(P_1.HmfYsdTKnbYRlUQZnnozMmgaHnTHA);
				hkiJYMNMGtNTeJaFbTJVVWzTvqbi();
				flag = false;
			}
			if (configVars.DoesPlatformUseFallback(uAlhaUCazsdBIZSPYIeKXOPJuzZV, HQLLLGrGMAjynibIGsgfCmWYYbuQ, isEditor))
			{
				imlEcTwzTpoJbudKKzRpjSUmOZhw = true;
				DHXBfYFYgbOleOssuzSOMABxpJKZA = new PwSDtUEHBaQxyausXPsLUMTynwDGA(gwuzgsGJfJdbnOQAWmjgZujjhYdd.updateLoop);
			}
			else if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.Windows || uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.WindowsAppStore || uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.WindowsUWP || uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.OSX || uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.Linux)
			{
				DHXBfYFYgbOleOssuzSOMABxpJKZA = P_0(gwuzgsGJfJdbnOQAWmjgZujjhYdd) as PlatformInputManager;
			}
			else if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.WebGL && !isEditor)
			{
				try
				{
					DHXBfYFYgbOleOssuzSOMABxpJKZA = P_0(gwuzgsGJfJdbnOQAWmjgZujjhYdd) as PlatformInputManager;
					if (DHXBfYFYgbOleOssuzSOMABxpJKZA == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					DHXBfYFYgbOleOssuzSOMABxpJKZA = null;
				}
			}
			else if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.XboxOne && !isEditor)
			{
				try
				{
					DHXBfYFYgbOleOssuzSOMABxpJKZA = new CustomInputManager(new XboxOneInputSource(), gwuzgsGJfJdbnOQAWmjgZujjhYdd.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (DHXBfYFYgbOleOssuzSOMABxpJKZA == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					DHXBfYFYgbOleOssuzSOMABxpJKZA = null;
				}
			}
			else if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.PS4 && !isEditor)
			{
				try
				{
					DHXBfYFYgbOleOssuzSOMABxpJKZA = P_0(gwuzgsGJfJdbnOQAWmjgZujjhYdd) as PlatformInputManager;
					if (DHXBfYFYgbOleOssuzSOMABxpJKZA == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
					Logger.LogError(msg);
					DHXBfYFYgbOleOssuzSOMABxpJKZA = null;
				}
			}
			else if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.PS5 && !isEditor)
			{
				try
				{
					DHXBfYFYgbOleOssuzSOMABxpJKZA = P_0(gwuzgsGJfJdbnOQAWmjgZujjhYdd) as PlatformInputManager;
					if (DHXBfYFYgbOleOssuzSOMABxpJKZA == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
					Logger.LogError(msg2);
					DHXBfYFYgbOleOssuzSOMABxpJKZA = null;
				}
			}
			else if ((uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.GameCoreXboxOne || uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					DHXBfYFYgbOleOssuzSOMABxpJKZA = P_0(gwuzgsGJfJdbnOQAWmjgZujjhYdd) as PlatformInputManager;
					if (DHXBfYFYgbOleOssuzSOMABxpJKZA == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg3)
				{
					string text = ((uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg3);
					DHXBfYFYgbOleOssuzSOMABxpJKZA = null;
				}
			}
			else if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.Ouya && !isEditor)
			{
				Logger.LogError("Ouya is no longer supported.");
				DHXBfYFYgbOleOssuzSOMABxpJKZA = null;
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.RddtjxiMwGqXwmDyXwJZYBQUTDqg = P_0(gwuzgsGJfJdbnOQAWmjgZujjhYdd) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg4)
				{
					Logger.LogError(msg4);
				}
			}
			else if (uAlhaUCazsdBIZSPYIeKXOPJuzZV == Platform.Custom)
			{
				try
				{
					DHXBfYFYgbOleOssuzSOMABxpJKZA = new CustomInputManager(NaCVyIMwuDhgdNZldvvjhuHYfOGS.wFianIaqXxOUiTKvbzZlHnJJMgwUA(), gwuzgsGJfJdbnOQAWmjgZujjhYdd.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (DHXBfYFYgbOleOssuzSOMABxpJKZA == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Custom platform could not be initialized due to an exception!");
					DHXBfYFYgbOleOssuzSOMABxpJKZA = null;
					throw;
				}
			}
			if (DHXBfYFYgbOleOssuzSOMABxpJKZA == null)
			{
				imlEcTwzTpoJbudKKzRpjSUmOZhw = true;
				DHXBfYFYgbOleOssuzSOMABxpJKZA = new PwSDtUEHBaQxyausXPsLUMTynwDGA(gwuzgsGJfJdbnOQAWmjgZujjhYdd.updateLoop);
			}
		}

		private static void eSKdBujHqoYUQLRVvUsEJRMeAtPfA()
		{
			if (QwReYYHidYWlVrIkFzkYOxZJCksj != gwuzgsGJfJdbnOQAWmjgZujjhYdd.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				QwReYYHidYWlVrIkFzkYOxZJCksj = !QwReYYHidYWlVrIkFzkYOxZJCksj;
			}
		}

		private static void oNwvhxPnLFqXUpUSGPUvOIrXEOrp()
		{
			if (!(UnityTools.unityVersionObj == null))
			{
				string[] obj = new string[7] { "The version of Rewired installed (", programVersion, ") was not designed for Unity ", null, null, null, null };
				int major = UnityTools.unityVersionObj.major;
				obj[3] = major.ToString();
				obj[4] = ". Please install Rewired for Unity ";
				major = UnityTools.unityVersionObj.major;
				obj[5] = major.ToString();
				obj[6] = ".\n\nThis warning does not mean that Rewired will not function, but it may not function optimally.\n\nSome different major versions of Unity download Asset Store assets to the same folder location on disk, so if you download an asset in one version of the Unity editor, then open another version of the Unity editor and install the asset without re-downloading it, the wrong asset version will be installed. To fix this, manually re-download Rewired in the Unity Asset Store panel in this version of the Unity Editor, then install it.\n\nIf you are using a beta version of a new major version of Unity, you will have to wait until the release of the final version before a compatible version of Rewired can be uploaded to the Asset Store. When the new version is ready, it will be available through the Unity Asset Store for download as usual.";
				Logger.LogWarning(string.Concat(obj));
			}
		}
	}
}
