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
using Rewired.Platforms.Custom;
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
			private static LocalizationHelper PPXKPMVFTmayDziWEtCWMURaaCys;

			internal static LocalizationHelper iNmHCAgmkqigUcaGxVFsisVcINYfb => PPXKPMVFTmayDziWEtCWMURaaCys ?? (PPXKPMVFTmayDziWEtCWMURaaCys = new LocalizationHelper());

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

			internal static void YqrnDctCuCnMyQJgGjiMeBxiXolm()
			{
				PPXKPMVFTmayDziWEtCWMURaaCys = null;
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
			private static GlyphHelper VlZZmZMnLaLfjKFYjaKvDSfGiHFyA;

			internal static GlyphHelper uYgwEWlAyngbzCriMYONdsYinzPf => VlZZmZMnLaLfjKFYjaKvDSfGiHFyA ?? (VlZZmZMnLaLfjKFYjaKvDSfGiHFyA = new GlyphHelper());

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

			internal static void uPMXwghrNaBkwHLNuZVOKHiPbcNY()
			{
				VlZZmZMnLaLfjKFYjaKvDSfGiHFyA = null;
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
			private static ConfigHelper HIbYZyBkqcOZibNQHIqxgXhUFlEy;

			private float oNkBpYgtZepkAzorBucLheusWuuf = 0.7f;

			private float ynYfAfDKXEVwMmBbwTBySQLzordeA = 100f;

			internal static ConfigHelper epqSTDLQPnhDVvCPETdkxshajvfb => HIbYZyBkqcOZibNQHIqxgXhUFlEy ?? (HIbYZyBkqcOZibNQHIqxgXhUFlEy = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.useXInput;
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
						if (lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.useXInput == value)
						{
							return;
						}
						if (value)
						{
							if (lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								Logger.LogWarning("XInput cannot be enabled with the current primary input source: " + lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("XInput cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.useXInput = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					if (UnityTools.effectivePlatform == Platform.Windows && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_useWindowsGamingInput();
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
						if (lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_useWindowsGamingInput() == value)
						{
							return;
						}
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.SetPlatformVar_useWindowsGamingInput(value);
						if (value)
						{
							if (lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
							{
								Logger.LogWarning("Windows Gaming Input cannot be enabled with the current primary input source: " + lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("Windows Gaming Input cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.updateMode;
				}
				set
				{
					if (CheckInitialized() && value != lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.updateMode)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.updateMode = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.updateLoop = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.effectivePlatform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.useXInput = true;
						}
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.osx_primaryInputSource != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.osx_primaryInputSource = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.linux_primaryInputSource != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.linux_primaryInputSource = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.windowsUWP_primaryInputSource = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return (lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return (lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useGamepadAPI != value)
					{
						platformVars_WindowsUWP.useGamepadAPI = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					if (UnityTools.effectivePlatform == Platform.OSX && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.osx_primaryInputSource == OSXStandalonePrimaryInputSource.GameController)
					{
						return true;
					}
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_useAppleGameController();
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_useAppleGameController() != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.SetPlatformVar_useAppleGameController(value);
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.xboxOne_primaryInputSource != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.xboxOne_primaryInputSource = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.ps4_primaryInputSource != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.ps4_primaryInputSource = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.webGL_primaryInputSource != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.webGL_primaryInputSource = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.alwaysUseUnityInput != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.alwaysUseUnityInput = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.SetPlatformVar_useNativeMouse(value) && zwodvHhZseqwtCKvDmliOWQNQBGe != null)
					{
						zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && zwodvHhZseqwtCKvDmliOWQNQBGe != null)
					{
						zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && zwodvHhZseqwtCKvDmliOWQNQBGe != null)
					{
						zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_joystickRefreshRate();
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
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						zaSrPbuZANMpoaOetByEXhYtBLsP();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.android_supportUnknownGamepads != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.android_supportUnknownGamepads = value;
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.defaultAxisSensitivityType != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.defaultAxisSensitivityType = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.force4WayHats != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.force4WayHats = value;
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
					return oNkBpYgtZepkAzorBucLheusWuuf;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (oNkBpYgtZepkAzorBucLheusWuuf != value)
						{
							oNkBpYgtZepkAzorBucLheusWuuf = value;
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
					return ynYfAfDKXEVwMmBbwTBySQLzordeA;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (ynYfAfDKXEVwMmBbwTBySQLzordeA != value)
						{
							ynYfAfDKXEVwMmBbwTBySQLzordeA = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.activateActionButtonsOnNegativeValue = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.throttleCalibrationMode != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.throttleCalibrationMode = value;
						AtHYwRgWVYrmVOsWolCxiSLKHuEp.mNjEcwFTnkaBTFqIwMvHIyLmSqGQ(value);
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.keyCombinationOverrideMode;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.keyCombinationOverrideMode != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.keyCombinationOverrideMode = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.generateKeyEventsOnKeyCombinationOverride;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.generateKeyEventsOnKeyCombinationOverride != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.generateKeyEventsOnKeyCombinationOverride = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.autoAssignJoysticks != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.autoAssignJoysticks = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.maxJoysticksPerPlayer != value)
						{
							lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.maxJoysticksPerPlayer = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.distributeJoysticksEvenly != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.distributeJoysticksEvenly = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.logLevel != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.logLevel = value;
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
					return new List<EnhancedDeviceSupportDeviceType>(lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes());
				}
				set
				{
					if (CheckInitialized())
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(value);
						if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
						{
							zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
						}
					}
				}
			}

			public bool disableAxis2dClamping
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					return lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.disableAxis2dClamping;
				}
				set
				{
					if (CheckInitialized() && lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.disableAxis2dClamping != value)
					{
						lzZKeetYdFxEfanBzSciGQGcmdER.ConfigVars.disableAxis2dClamping = value;
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
				private sealed class EqCyTvvJYXdpgKFdfUjsFOcCQcVX : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int bgOvpbqqMNRBTlJyFEsOYcQudIhJA;

					private ControllerPollingInfo HgJXpuoyrsdnKkVTJfuoXhNXyKNi;

					private int xxWwYcTYPAfHcPuehcRortjDPdyb;

					public PollingHelper yLFlUquaydxqnprfYSDbWwyKKXvL;

					private IEnumerator<ControllerPollingInfo> KzepSwdFndFmdaqxPUUkjNyMzkxcA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return HgJXpuoyrsdnKkVTJfuoXhNXyKNi;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HgJXpuoyrsdnKkVTJfuoXhNXyKNi;
						}
					}

					[DebuggerHidden]
					public EqCyTvvJYXdpgKFdfUjsFOcCQcVX(int P_0)
					{
						bgOvpbqqMNRBTlJyFEsOYcQudIhJA = P_0;
						xxWwYcTYPAfHcPuehcRortjDPdyb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (bgOvpbqqMNRBTlJyFEsOYcQudIhJA)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								RDfcRWGuYmbCGQwQvoUCpjaABoUp();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								xQTEvadlJXCjPdoOdmkJaFQvzqFuB();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								mbBYAfbgvCxbqvylZoqsAlILNPVm();
							}
							break;
						}
						KzepSwdFndFmdaqxPUUkjNyMzkxcA = null;
						bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = bgOvpbqqMNRBTlJyFEsOYcQudIhJA;
							PollingHelper pollingHelper = yLFlUquaydxqnprfYSDbWwyKKXvL;
							switch (num)
							{
							default:
								return false;
							case 0:
								bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								KzepSwdFndFmdaqxPUUkjNyMzkxcA = pollingHelper.MhzenSipwAJJoosbezvSIFmDIbIK().GetEnumerator();
								bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -3;
								goto IL_0084;
							case 1:
								bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -3;
								goto IL_0084;
							case 2:
								bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -4;
								goto IL_00e4;
							case 3:
								{
									bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -5;
									break;
								}
								IL_00e4:
								if (KzepSwdFndFmdaqxPUUkjNyMzkxcA.MoveNext())
								{
									ControllerPollingInfo current = KzepSwdFndFmdaqxPUUkjNyMzkxcA.Current;
									HgJXpuoyrsdnKkVTJfuoXhNXyKNi = current;
									bgOvpbqqMNRBTlJyFEsOYcQudIhJA = 2;
									return true;
								}
								xQTEvadlJXCjPdoOdmkJaFQvzqFuB();
								KzepSwdFndFmdaqxPUUkjNyMzkxcA = null;
								KzepSwdFndFmdaqxPUUkjNyMzkxcA = pollingHelper.OZUBHHTGDucLzXZZcOylzMXwekNF().GetEnumerator();
								bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -5;
								break;
								IL_0084:
								if (KzepSwdFndFmdaqxPUUkjNyMzkxcA.MoveNext())
								{
									ControllerPollingInfo current2 = KzepSwdFndFmdaqxPUUkjNyMzkxcA.Current;
									HgJXpuoyrsdnKkVTJfuoXhNXyKNi = current2;
									bgOvpbqqMNRBTlJyFEsOYcQudIhJA = 1;
									return true;
								}
								RDfcRWGuYmbCGQwQvoUCpjaABoUp();
								KzepSwdFndFmdaqxPUUkjNyMzkxcA = null;
								KzepSwdFndFmdaqxPUUkjNyMzkxcA = pollingHelper.WYuGVmZyTarAMBIFJpeldaqpbfOL().GetEnumerator();
								bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -4;
								goto IL_00e4;
							}
							if (KzepSwdFndFmdaqxPUUkjNyMzkxcA.MoveNext())
							{
								ControllerPollingInfo current3 = KzepSwdFndFmdaqxPUUkjNyMzkxcA.Current;
								HgJXpuoyrsdnKkVTJfuoXhNXyKNi = current3;
								bgOvpbqqMNRBTlJyFEsOYcQudIhJA = 3;
								return true;
							}
							mbBYAfbgvCxbqvylZoqsAlILNPVm();
							KzepSwdFndFmdaqxPUUkjNyMzkxcA = null;
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

					private void RDfcRWGuYmbCGQwQvoUCpjaABoUp()
					{
						bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -1;
						if (KzepSwdFndFmdaqxPUUkjNyMzkxcA != null)
						{
							KzepSwdFndFmdaqxPUUkjNyMzkxcA.Dispose();
						}
					}

					private void xQTEvadlJXCjPdoOdmkJaFQvzqFuB()
					{
						bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -1;
						if (KzepSwdFndFmdaqxPUUkjNyMzkxcA != null)
						{
							KzepSwdFndFmdaqxPUUkjNyMzkxcA.Dispose();
						}
					}

					private void mbBYAfbgvCxbqvylZoqsAlILNPVm()
					{
						bgOvpbqqMNRBTlJyFEsOYcQudIhJA = -1;
						if (KzepSwdFndFmdaqxPUUkjNyMzkxcA != null)
						{
							KzepSwdFndFmdaqxPUUkjNyMzkxcA.Dispose();
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
						EqCyTvvJYXdpgKFdfUjsFOcCQcVX eqCyTvvJYXdpgKFdfUjsFOcCQcVX;
						if (bgOvpbqqMNRBTlJyFEsOYcQudIhJA == -2 && xxWwYcTYPAfHcPuehcRortjDPdyb == Environment.CurrentManagedThreadId)
						{
							bgOvpbqqMNRBTlJyFEsOYcQudIhJA = 0;
							eqCyTvvJYXdpgKFdfUjsFOcCQcVX = this;
						}
						else
						{
							eqCyTvvJYXdpgKFdfUjsFOcCQcVX = new EqCyTvvJYXdpgKFdfUjsFOcCQcVX(0);
							eqCyTvvJYXdpgKFdfUjsFOcCQcVX.yLFlUquaydxqnprfYSDbWwyKKXvL = yLFlUquaydxqnprfYSDbWwyKKXvL;
						}
						return eqCyTvvJYXdpgKFdfUjsFOcCQcVX;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class kzxnEkUhHCjSZJoGajWfxHEXUHqbA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int kETguFtDttQfKlWZuNWNsUZTNqnv;

					private ControllerPollingInfo jtfSJHgwHgngcmVdixlEsEczPqzN;

					private int yJnAghjHCjbTtOnekLQbZXSHZETL;

					public PollingHelper dClGKliKcxQasdMbxrYgIIhNUUKSA;

					private IEnumerator<ControllerPollingInfo> AYzpLooAxwGknLTVgmYXDmpbVWXS;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return jtfSJHgwHgngcmVdixlEsEczPqzN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return jtfSJHgwHgngcmVdixlEsEczPqzN;
						}
					}

					[DebuggerHidden]
					public kzxnEkUhHCjSZJoGajWfxHEXUHqbA(int P_0)
					{
						kETguFtDttQfKlWZuNWNsUZTNqnv = P_0;
						yJnAghjHCjbTtOnekLQbZXSHZETL = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (kETguFtDttQfKlWZuNWNsUZTNqnv)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								BwFtAGFxKmbAjbVwDwOeobDIBCQQ();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								lJUPtvySxyjqZQFMQiHOoIVxbVzs();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								izdJrKvhmzVKfJHmNpIjQzCoxToe();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								yCEDfKEbAdBVDfyeyNaYCEwFuEwO();
							}
							break;
						}
						AYzpLooAxwGknLTVgmYXDmpbVWXS = null;
						kETguFtDttQfKlWZuNWNsUZTNqnv = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = kETguFtDttQfKlWZuNWNsUZTNqnv;
							PollingHelper pollingHelper = dClGKliKcxQasdMbxrYgIIhNUUKSA;
							switch (num)
							{
							default:
								return false;
							case 0:
								kETguFtDttQfKlWZuNWNsUZTNqnv = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								AYzpLooAxwGknLTVgmYXDmpbVWXS = pollingHelper.eMqJzSNXMHQuSUIasvcriQrBXDXE().GetEnumerator();
								kETguFtDttQfKlWZuNWNsUZTNqnv = -3;
								goto IL_0088;
							case 1:
								kETguFtDttQfKlWZuNWNsUZTNqnv = -3;
								goto IL_0088;
							case 2:
								kETguFtDttQfKlWZuNWNsUZTNqnv = -4;
								goto IL_00e8;
							case 3:
								kETguFtDttQfKlWZuNWNsUZTNqnv = -5;
								goto IL_0148;
							case 4:
								{
									kETguFtDttQfKlWZuNWNsUZTNqnv = -6;
									break;
								}
								IL_00e8:
								if (AYzpLooAxwGknLTVgmYXDmpbVWXS.MoveNext())
								{
									ControllerPollingInfo current = AYzpLooAxwGknLTVgmYXDmpbVWXS.Current;
									jtfSJHgwHgngcmVdixlEsEczPqzN = current;
									kETguFtDttQfKlWZuNWNsUZTNqnv = 2;
									return true;
								}
								lJUPtvySxyjqZQFMQiHOoIVxbVzs();
								AYzpLooAxwGknLTVgmYXDmpbVWXS = null;
								AYzpLooAxwGknLTVgmYXDmpbVWXS = pollingHelper.bpBjcmCyRoAycosmPFaLQAbQgdvZ().GetEnumerator();
								kETguFtDttQfKlWZuNWNsUZTNqnv = -5;
								goto IL_0148;
								IL_0088:
								if (AYzpLooAxwGknLTVgmYXDmpbVWXS.MoveNext())
								{
									ControllerPollingInfo current2 = AYzpLooAxwGknLTVgmYXDmpbVWXS.Current;
									jtfSJHgwHgngcmVdixlEsEczPqzN = current2;
									kETguFtDttQfKlWZuNWNsUZTNqnv = 1;
									return true;
								}
								BwFtAGFxKmbAjbVwDwOeobDIBCQQ();
								AYzpLooAxwGknLTVgmYXDmpbVWXS = null;
								AYzpLooAxwGknLTVgmYXDmpbVWXS = pollingHelper.HVZugPDPxwCKJCERVePghryGeHJgB().GetEnumerator();
								kETguFtDttQfKlWZuNWNsUZTNqnv = -4;
								goto IL_00e8;
								IL_0148:
								if (AYzpLooAxwGknLTVgmYXDmpbVWXS.MoveNext())
								{
									ControllerPollingInfo current3 = AYzpLooAxwGknLTVgmYXDmpbVWXS.Current;
									jtfSJHgwHgngcmVdixlEsEczPqzN = current3;
									kETguFtDttQfKlWZuNWNsUZTNqnv = 3;
									return true;
								}
								izdJrKvhmzVKfJHmNpIjQzCoxToe();
								AYzpLooAxwGknLTVgmYXDmpbVWXS = null;
								AYzpLooAxwGknLTVgmYXDmpbVWXS = pollingHelper.mTHABciLMNthAGPmTMJYhkQkQaTgB().GetEnumerator();
								kETguFtDttQfKlWZuNWNsUZTNqnv = -6;
								break;
							}
							if (AYzpLooAxwGknLTVgmYXDmpbVWXS.MoveNext())
							{
								ControllerPollingInfo current4 = AYzpLooAxwGknLTVgmYXDmpbVWXS.Current;
								jtfSJHgwHgngcmVdixlEsEczPqzN = current4;
								kETguFtDttQfKlWZuNWNsUZTNqnv = 4;
								return true;
							}
							yCEDfKEbAdBVDfyeyNaYCEwFuEwO();
							AYzpLooAxwGknLTVgmYXDmpbVWXS = null;
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

					private void BwFtAGFxKmbAjbVwDwOeobDIBCQQ()
					{
						kETguFtDttQfKlWZuNWNsUZTNqnv = -1;
						if (AYzpLooAxwGknLTVgmYXDmpbVWXS != null)
						{
							AYzpLooAxwGknLTVgmYXDmpbVWXS.Dispose();
						}
					}

					private void lJUPtvySxyjqZQFMQiHOoIVxbVzs()
					{
						kETguFtDttQfKlWZuNWNsUZTNqnv = -1;
						if (AYzpLooAxwGknLTVgmYXDmpbVWXS != null)
						{
							AYzpLooAxwGknLTVgmYXDmpbVWXS.Dispose();
						}
					}

					private void izdJrKvhmzVKfJHmNpIjQzCoxToe()
					{
						kETguFtDttQfKlWZuNWNsUZTNqnv = -1;
						if (AYzpLooAxwGknLTVgmYXDmpbVWXS != null)
						{
							AYzpLooAxwGknLTVgmYXDmpbVWXS.Dispose();
						}
					}

					private void yCEDfKEbAdBVDfyeyNaYCEwFuEwO()
					{
						kETguFtDttQfKlWZuNWNsUZTNqnv = -1;
						if (AYzpLooAxwGknLTVgmYXDmpbVWXS != null)
						{
							AYzpLooAxwGknLTVgmYXDmpbVWXS.Dispose();
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
						kzxnEkUhHCjSZJoGajWfxHEXUHqbA kzxnEkUhHCjSZJoGajWfxHEXUHqbA2;
						if (kETguFtDttQfKlWZuNWNsUZTNqnv == -2 && yJnAghjHCjbTtOnekLQbZXSHZETL == Environment.CurrentManagedThreadId)
						{
							kETguFtDttQfKlWZuNWNsUZTNqnv = 0;
							kzxnEkUhHCjSZJoGajWfxHEXUHqbA2 = this;
						}
						else
						{
							kzxnEkUhHCjSZJoGajWfxHEXUHqbA2 = new kzxnEkUhHCjSZJoGajWfxHEXUHqbA(0);
							kzxnEkUhHCjSZJoGajWfxHEXUHqbA2.dClGKliKcxQasdMbxrYgIIhNUUKSA = dClGKliKcxQasdMbxrYgIIhNUUKSA;
						}
						return kzxnEkUhHCjSZJoGajWfxHEXUHqbA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ekEOokUAzJNnOvImqaruztDEGXjY : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int efCMRXqYcQWLIPOVoRKkdqYBbPoI;

					private ControllerPollingInfo nwJEztBMxMDHSEQYDlCphUKdTBioB;

					private int vsuFnJaGkmHUWEnAJaanDUEeDHfMd;

					public PollingHelper VWfMaxDknUMIZuAAHxjbSOsmJkMA;

					private IEnumerator<ControllerPollingInfo> FHhUayfecBQQphWwykFchzJZqNOk;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return nwJEztBMxMDHSEQYDlCphUKdTBioB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return nwJEztBMxMDHSEQYDlCphUKdTBioB;
						}
					}

					[DebuggerHidden]
					public ekEOokUAzJNnOvImqaruztDEGXjY(int P_0)
					{
						efCMRXqYcQWLIPOVoRKkdqYBbPoI = P_0;
						vsuFnJaGkmHUWEnAJaanDUEeDHfMd = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (efCMRXqYcQWLIPOVoRKkdqYBbPoI)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								xfXFSaKYYmwOVvJeEYpkwLgXTpzW();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								QlhmZQcjJEoyxirwRnsYJJSjSZdc();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								KjCuPXiUJjYdIljsVhbntWpBGFbS();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								MDfkqPovUUymsiDDDFNykMtYLmKb();
							}
							break;
						}
						FHhUayfecBQQphWwykFchzJZqNOk = null;
						efCMRXqYcQWLIPOVoRKkdqYBbPoI = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = efCMRXqYcQWLIPOVoRKkdqYBbPoI;
							PollingHelper vWfMaxDknUMIZuAAHxjbSOsmJkMA = VWfMaxDknUMIZuAAHxjbSOsmJkMA;
							switch (num)
							{
							default:
								return false;
							case 0:
								efCMRXqYcQWLIPOVoRKkdqYBbPoI = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								FHhUayfecBQQphWwykFchzJZqNOk = vWfMaxDknUMIZuAAHxjbSOsmJkMA.lgMeNajJXCGWmDOPnUgPYVUThSAAb().GetEnumerator();
								efCMRXqYcQWLIPOVoRKkdqYBbPoI = -3;
								goto IL_0088;
							case 1:
								efCMRXqYcQWLIPOVoRKkdqYBbPoI = -3;
								goto IL_0088;
							case 2:
								efCMRXqYcQWLIPOVoRKkdqYBbPoI = -4;
								goto IL_00e8;
							case 3:
								efCMRXqYcQWLIPOVoRKkdqYBbPoI = -5;
								goto IL_0148;
							case 4:
								{
									efCMRXqYcQWLIPOVoRKkdqYBbPoI = -6;
									break;
								}
								IL_00e8:
								if (FHhUayfecBQQphWwykFchzJZqNOk.MoveNext())
								{
									ControllerPollingInfo current = FHhUayfecBQQphWwykFchzJZqNOk.Current;
									nwJEztBMxMDHSEQYDlCphUKdTBioB = current;
									efCMRXqYcQWLIPOVoRKkdqYBbPoI = 2;
									return true;
								}
								QlhmZQcjJEoyxirwRnsYJJSjSZdc();
								FHhUayfecBQQphWwykFchzJZqNOk = null;
								FHhUayfecBQQphWwykFchzJZqNOk = vWfMaxDknUMIZuAAHxjbSOsmJkMA.XgKJLRHtupEazkXPNZWnNAKMkbmM().GetEnumerator();
								efCMRXqYcQWLIPOVoRKkdqYBbPoI = -5;
								goto IL_0148;
								IL_0088:
								if (FHhUayfecBQQphWwykFchzJZqNOk.MoveNext())
								{
									ControllerPollingInfo current2 = FHhUayfecBQQphWwykFchzJZqNOk.Current;
									nwJEztBMxMDHSEQYDlCphUKdTBioB = current2;
									efCMRXqYcQWLIPOVoRKkdqYBbPoI = 1;
									return true;
								}
								xfXFSaKYYmwOVvJeEYpkwLgXTpzW();
								FHhUayfecBQQphWwykFchzJZqNOk = null;
								FHhUayfecBQQphWwykFchzJZqNOk = vWfMaxDknUMIZuAAHxjbSOsmJkMA.sBijQXTPeuiMBIugVDFOQjoCUYvh().GetEnumerator();
								efCMRXqYcQWLIPOVoRKkdqYBbPoI = -4;
								goto IL_00e8;
								IL_0148:
								if (FHhUayfecBQQphWwykFchzJZqNOk.MoveNext())
								{
									ControllerPollingInfo current3 = FHhUayfecBQQphWwykFchzJZqNOk.Current;
									nwJEztBMxMDHSEQYDlCphUKdTBioB = current3;
									efCMRXqYcQWLIPOVoRKkdqYBbPoI = 3;
									return true;
								}
								KjCuPXiUJjYdIljsVhbntWpBGFbS();
								FHhUayfecBQQphWwykFchzJZqNOk = null;
								FHhUayfecBQQphWwykFchzJZqNOk = vWfMaxDknUMIZuAAHxjbSOsmJkMA.cqjzqfQqPlcQhGtHzehrRzylpmGGA().GetEnumerator();
								efCMRXqYcQWLIPOVoRKkdqYBbPoI = -6;
								break;
							}
							if (FHhUayfecBQQphWwykFchzJZqNOk.MoveNext())
							{
								ControllerPollingInfo current4 = FHhUayfecBQQphWwykFchzJZqNOk.Current;
								nwJEztBMxMDHSEQYDlCphUKdTBioB = current4;
								efCMRXqYcQWLIPOVoRKkdqYBbPoI = 4;
								return true;
							}
							MDfkqPovUUymsiDDDFNykMtYLmKb();
							FHhUayfecBQQphWwykFchzJZqNOk = null;
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

					private void xfXFSaKYYmwOVvJeEYpkwLgXTpzW()
					{
						efCMRXqYcQWLIPOVoRKkdqYBbPoI = -1;
						if (FHhUayfecBQQphWwykFchzJZqNOk != null)
						{
							FHhUayfecBQQphWwykFchzJZqNOk.Dispose();
						}
					}

					private void QlhmZQcjJEoyxirwRnsYJJSjSZdc()
					{
						efCMRXqYcQWLIPOVoRKkdqYBbPoI = -1;
						if (FHhUayfecBQQphWwykFchzJZqNOk != null)
						{
							FHhUayfecBQQphWwykFchzJZqNOk.Dispose();
						}
					}

					private void KjCuPXiUJjYdIljsVhbntWpBGFbS()
					{
						efCMRXqYcQWLIPOVoRKkdqYBbPoI = -1;
						if (FHhUayfecBQQphWwykFchzJZqNOk != null)
						{
							FHhUayfecBQQphWwykFchzJZqNOk.Dispose();
						}
					}

					private void MDfkqPovUUymsiDDDFNykMtYLmKb()
					{
						efCMRXqYcQWLIPOVoRKkdqYBbPoI = -1;
						if (FHhUayfecBQQphWwykFchzJZqNOk != null)
						{
							FHhUayfecBQQphWwykFchzJZqNOk.Dispose();
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
						ekEOokUAzJNnOvImqaruztDEGXjY ekEOokUAzJNnOvImqaruztDEGXjY2;
						if (efCMRXqYcQWLIPOVoRKkdqYBbPoI == -2 && vsuFnJaGkmHUWEnAJaanDUEeDHfMd == Environment.CurrentManagedThreadId)
						{
							efCMRXqYcQWLIPOVoRKkdqYBbPoI = 0;
							ekEOokUAzJNnOvImqaruztDEGXjY2 = this;
						}
						else
						{
							ekEOokUAzJNnOvImqaruztDEGXjY2 = new ekEOokUAzJNnOvImqaruztDEGXjY(0);
							ekEOokUAzJNnOvImqaruztDEGXjY2.VWfMaxDknUMIZuAAHxjbSOsmJkMA = VWfMaxDknUMIZuAAHxjbSOsmJkMA;
						}
						return ekEOokUAzJNnOvImqaruztDEGXjY2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class psRpYANWUYviJQKJzNWPpPpSvNkE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int bftbfJDosKKqYVFyCLDgCgFkzePfc;

					private ControllerPollingInfo WjuHXgqLRiaskkWMBcIoadhwwPvT;

					private int uFUkuJvpkMaveDUMobPgJHteGffZ;

					public PollingHelper fHMHgvDrJYvUwQGvBbQthUdAtqXRA;

					private IEnumerator<ControllerPollingInfo> NOEaLJbiQAKEAdskwCKsJnJcPZGcb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WjuHXgqLRiaskkWMBcIoadhwwPvT;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WjuHXgqLRiaskkWMBcIoadhwwPvT;
						}
					}

					[DebuggerHidden]
					public psRpYANWUYviJQKJzNWPpPpSvNkE(int P_0)
					{
						bftbfJDosKKqYVFyCLDgCgFkzePfc = P_0;
						uFUkuJvpkMaveDUMobPgJHteGffZ = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (bftbfJDosKKqYVFyCLDgCgFkzePfc)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								rLADzVeslUgmDNgGVkWcuyEeeRJn();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								aKSWISBGCGLNHAEvFasJkIDuUxuw();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								rFeWSiwtwesNPMqKGwtJjThXDUWS();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								JvOnuQLODdTNfzecYjIlUtuzGnAd();
							}
							break;
						}
						NOEaLJbiQAKEAdskwCKsJnJcPZGcb = null;
						bftbfJDosKKqYVFyCLDgCgFkzePfc = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = bftbfJDosKKqYVFyCLDgCgFkzePfc;
							PollingHelper pollingHelper = fHMHgvDrJYvUwQGvBbQthUdAtqXRA;
							switch (num)
							{
							default:
								return false;
							case 0:
								bftbfJDosKKqYVFyCLDgCgFkzePfc = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								NOEaLJbiQAKEAdskwCKsJnJcPZGcb = pollingHelper.vvFDEABPIZInabhRENuTlFrZGxksb().GetEnumerator();
								bftbfJDosKKqYVFyCLDgCgFkzePfc = -3;
								goto IL_0088;
							case 1:
								bftbfJDosKKqYVFyCLDgCgFkzePfc = -3;
								goto IL_0088;
							case 2:
								bftbfJDosKKqYVFyCLDgCgFkzePfc = -4;
								goto IL_00e8;
							case 3:
								bftbfJDosKKqYVFyCLDgCgFkzePfc = -5;
								goto IL_0148;
							case 4:
								{
									bftbfJDosKKqYVFyCLDgCgFkzePfc = -6;
									break;
								}
								IL_00e8:
								if (NOEaLJbiQAKEAdskwCKsJnJcPZGcb.MoveNext())
								{
									ControllerPollingInfo current = NOEaLJbiQAKEAdskwCKsJnJcPZGcb.Current;
									WjuHXgqLRiaskkWMBcIoadhwwPvT = current;
									bftbfJDosKKqYVFyCLDgCgFkzePfc = 2;
									return true;
								}
								aKSWISBGCGLNHAEvFasJkIDuUxuw();
								NOEaLJbiQAKEAdskwCKsJnJcPZGcb = null;
								NOEaLJbiQAKEAdskwCKsJnJcPZGcb = pollingHelper.DaVchkfgrumiUdRvhhoLHJpTCTnI().GetEnumerator();
								bftbfJDosKKqYVFyCLDgCgFkzePfc = -5;
								goto IL_0148;
								IL_0088:
								if (NOEaLJbiQAKEAdskwCKsJnJcPZGcb.MoveNext())
								{
									ControllerPollingInfo current2 = NOEaLJbiQAKEAdskwCKsJnJcPZGcb.Current;
									WjuHXgqLRiaskkWMBcIoadhwwPvT = current2;
									bftbfJDosKKqYVFyCLDgCgFkzePfc = 1;
									return true;
								}
								rLADzVeslUgmDNgGVkWcuyEeeRJn();
								NOEaLJbiQAKEAdskwCKsJnJcPZGcb = null;
								NOEaLJbiQAKEAdskwCKsJnJcPZGcb = pollingHelper.HVZugPDPxwCKJCERVePghryGeHJgB().GetEnumerator();
								bftbfJDosKKqYVFyCLDgCgFkzePfc = -4;
								goto IL_00e8;
								IL_0148:
								if (NOEaLJbiQAKEAdskwCKsJnJcPZGcb.MoveNext())
								{
									ControllerPollingInfo current3 = NOEaLJbiQAKEAdskwCKsJnJcPZGcb.Current;
									WjuHXgqLRiaskkWMBcIoadhwwPvT = current3;
									bftbfJDosKKqYVFyCLDgCgFkzePfc = 3;
									return true;
								}
								rFeWSiwtwesNPMqKGwtJjThXDUWS();
								NOEaLJbiQAKEAdskwCKsJnJcPZGcb = null;
								NOEaLJbiQAKEAdskwCKsJnJcPZGcb = pollingHelper.XIbwbkDHhzhcGiiiuzxgrYbGbBnI().GetEnumerator();
								bftbfJDosKKqYVFyCLDgCgFkzePfc = -6;
								break;
							}
							if (NOEaLJbiQAKEAdskwCKsJnJcPZGcb.MoveNext())
							{
								ControllerPollingInfo current4 = NOEaLJbiQAKEAdskwCKsJnJcPZGcb.Current;
								WjuHXgqLRiaskkWMBcIoadhwwPvT = current4;
								bftbfJDosKKqYVFyCLDgCgFkzePfc = 4;
								return true;
							}
							JvOnuQLODdTNfzecYjIlUtuzGnAd();
							NOEaLJbiQAKEAdskwCKsJnJcPZGcb = null;
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

					private void rLADzVeslUgmDNgGVkWcuyEeeRJn()
					{
						bftbfJDosKKqYVFyCLDgCgFkzePfc = -1;
						if (NOEaLJbiQAKEAdskwCKsJnJcPZGcb != null)
						{
							NOEaLJbiQAKEAdskwCKsJnJcPZGcb.Dispose();
						}
					}

					private void aKSWISBGCGLNHAEvFasJkIDuUxuw()
					{
						bftbfJDosKKqYVFyCLDgCgFkzePfc = -1;
						if (NOEaLJbiQAKEAdskwCKsJnJcPZGcb != null)
						{
							NOEaLJbiQAKEAdskwCKsJnJcPZGcb.Dispose();
						}
					}

					private void rFeWSiwtwesNPMqKGwtJjThXDUWS()
					{
						bftbfJDosKKqYVFyCLDgCgFkzePfc = -1;
						if (NOEaLJbiQAKEAdskwCKsJnJcPZGcb != null)
						{
							NOEaLJbiQAKEAdskwCKsJnJcPZGcb.Dispose();
						}
					}

					private void JvOnuQLODdTNfzecYjIlUtuzGnAd()
					{
						bftbfJDosKKqYVFyCLDgCgFkzePfc = -1;
						if (NOEaLJbiQAKEAdskwCKsJnJcPZGcb != null)
						{
							NOEaLJbiQAKEAdskwCKsJnJcPZGcb.Dispose();
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
						psRpYANWUYviJQKJzNWPpPpSvNkE psRpYANWUYviJQKJzNWPpPpSvNkE2;
						if (bftbfJDosKKqYVFyCLDgCgFkzePfc == -2 && uFUkuJvpkMaveDUMobPgJHteGffZ == Environment.CurrentManagedThreadId)
						{
							bftbfJDosKKqYVFyCLDgCgFkzePfc = 0;
							psRpYANWUYviJQKJzNWPpPpSvNkE2 = this;
						}
						else
						{
							psRpYANWUYviJQKJzNWPpPpSvNkE2 = new psRpYANWUYviJQKJzNWPpPpSvNkE(0);
							psRpYANWUYviJQKJzNWPpPpSvNkE2.fHMHgvDrJYvUwQGvBbQthUdAtqXRA = fHMHgvDrJYvUwQGvBbQthUdAtqXRA;
						}
						return psRpYANWUYviJQKJzNWPpPpSvNkE2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class RnOWBSDiNtXHykMkVRxVAcQCfjzz : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int UyDagSysuQFLXfTUWlkZblBcfYPlb;

					private ControllerPollingInfo YPgDKuRmWgYfboOetATsMIKeIbHCA;

					private int chQVWWtfKPjTaNoeaNnGGjYiRvMJ;

					public PollingHelper YchOMKowbJGthbboJujWFiHvdVGK;

					private IEnumerator<ControllerPollingInfo> fdhpOdPzdCCMRErcQxIrlvQrdhvb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return YPgDKuRmWgYfboOetATsMIKeIbHCA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return YPgDKuRmWgYfboOetATsMIKeIbHCA;
						}
					}

					[DebuggerHidden]
					public RnOWBSDiNtXHykMkVRxVAcQCfjzz(int P_0)
					{
						UyDagSysuQFLXfTUWlkZblBcfYPlb = P_0;
						chQVWWtfKPjTaNoeaNnGGjYiRvMJ = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (UyDagSysuQFLXfTUWlkZblBcfYPlb)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								PEDPmmMeQYeeaMSLaftACHPDaVPPA();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								CUPtsGvIltYDzACbJcNEQmOpmoZh();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								NCUhCrEbxlKqNrgPTGYHrECHmFLO();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								WfpItWjgfaAkNAQjMCEbArVTEtyM();
							}
							break;
						}
						fdhpOdPzdCCMRErcQxIrlvQrdhvb = null;
						UyDagSysuQFLXfTUWlkZblBcfYPlb = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int uyDagSysuQFLXfTUWlkZblBcfYPlb = UyDagSysuQFLXfTUWlkZblBcfYPlb;
							PollingHelper ychOMKowbJGthbboJujWFiHvdVGK = YchOMKowbJGthbboJujWFiHvdVGK;
							switch (uyDagSysuQFLXfTUWlkZblBcfYPlb)
							{
							default:
								return false;
							case 0:
								UyDagSysuQFLXfTUWlkZblBcfYPlb = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								fdhpOdPzdCCMRErcQxIrlvQrdhvb = ychOMKowbJGthbboJujWFiHvdVGK.lDhEDLIiujHGldfohgFnKqKFrWZuB().GetEnumerator();
								UyDagSysuQFLXfTUWlkZblBcfYPlb = -3;
								goto IL_0088;
							case 1:
								UyDagSysuQFLXfTUWlkZblBcfYPlb = -3;
								goto IL_0088;
							case 2:
								UyDagSysuQFLXfTUWlkZblBcfYPlb = -4;
								goto IL_00e8;
							case 3:
								UyDagSysuQFLXfTUWlkZblBcfYPlb = -5;
								goto IL_0148;
							case 4:
								{
									UyDagSysuQFLXfTUWlkZblBcfYPlb = -6;
									break;
								}
								IL_00e8:
								if (fdhpOdPzdCCMRErcQxIrlvQrdhvb.MoveNext())
								{
									ControllerPollingInfo current = fdhpOdPzdCCMRErcQxIrlvQrdhvb.Current;
									YPgDKuRmWgYfboOetATsMIKeIbHCA = current;
									UyDagSysuQFLXfTUWlkZblBcfYPlb = 2;
									return true;
								}
								CUPtsGvIltYDzACbJcNEQmOpmoZh();
								fdhpOdPzdCCMRErcQxIrlvQrdhvb = null;
								fdhpOdPzdCCMRErcQxIrlvQrdhvb = ychOMKowbJGthbboJujWFiHvdVGK.TpHAYnDDNYKQfspZCXlkFnmUueGeA().GetEnumerator();
								UyDagSysuQFLXfTUWlkZblBcfYPlb = -5;
								goto IL_0148;
								IL_0088:
								if (fdhpOdPzdCCMRErcQxIrlvQrdhvb.MoveNext())
								{
									ControllerPollingInfo current2 = fdhpOdPzdCCMRErcQxIrlvQrdhvb.Current;
									YPgDKuRmWgYfboOetATsMIKeIbHCA = current2;
									UyDagSysuQFLXfTUWlkZblBcfYPlb = 1;
									return true;
								}
								PEDPmmMeQYeeaMSLaftACHPDaVPPA();
								fdhpOdPzdCCMRErcQxIrlvQrdhvb = null;
								fdhpOdPzdCCMRErcQxIrlvQrdhvb = ychOMKowbJGthbboJujWFiHvdVGK.sBijQXTPeuiMBIugVDFOQjoCUYvh().GetEnumerator();
								UyDagSysuQFLXfTUWlkZblBcfYPlb = -4;
								goto IL_00e8;
								IL_0148:
								if (fdhpOdPzdCCMRErcQxIrlvQrdhvb.MoveNext())
								{
									ControllerPollingInfo current3 = fdhpOdPzdCCMRErcQxIrlvQrdhvb.Current;
									YPgDKuRmWgYfboOetATsMIKeIbHCA = current3;
									UyDagSysuQFLXfTUWlkZblBcfYPlb = 3;
									return true;
								}
								NCUhCrEbxlKqNrgPTGYHrECHmFLO();
								fdhpOdPzdCCMRErcQxIrlvQrdhvb = null;
								fdhpOdPzdCCMRErcQxIrlvQrdhvb = ychOMKowbJGthbboJujWFiHvdVGK.BzeekwxvqyapJaQWgiMPCxeYuhCQA().GetEnumerator();
								UyDagSysuQFLXfTUWlkZblBcfYPlb = -6;
								break;
							}
							if (fdhpOdPzdCCMRErcQxIrlvQrdhvb.MoveNext())
							{
								ControllerPollingInfo current4 = fdhpOdPzdCCMRErcQxIrlvQrdhvb.Current;
								YPgDKuRmWgYfboOetATsMIKeIbHCA = current4;
								UyDagSysuQFLXfTUWlkZblBcfYPlb = 4;
								return true;
							}
							WfpItWjgfaAkNAQjMCEbArVTEtyM();
							fdhpOdPzdCCMRErcQxIrlvQrdhvb = null;
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

					private void PEDPmmMeQYeeaMSLaftACHPDaVPPA()
					{
						UyDagSysuQFLXfTUWlkZblBcfYPlb = -1;
						if (fdhpOdPzdCCMRErcQxIrlvQrdhvb != null)
						{
							fdhpOdPzdCCMRErcQxIrlvQrdhvb.Dispose();
						}
					}

					private void CUPtsGvIltYDzACbJcNEQmOpmoZh()
					{
						UyDagSysuQFLXfTUWlkZblBcfYPlb = -1;
						if (fdhpOdPzdCCMRErcQxIrlvQrdhvb != null)
						{
							fdhpOdPzdCCMRErcQxIrlvQrdhvb.Dispose();
						}
					}

					private void NCUhCrEbxlKqNrgPTGYHrECHmFLO()
					{
						UyDagSysuQFLXfTUWlkZblBcfYPlb = -1;
						if (fdhpOdPzdCCMRErcQxIrlvQrdhvb != null)
						{
							fdhpOdPzdCCMRErcQxIrlvQrdhvb.Dispose();
						}
					}

					private void WfpItWjgfaAkNAQjMCEbArVTEtyM()
					{
						UyDagSysuQFLXfTUWlkZblBcfYPlb = -1;
						if (fdhpOdPzdCCMRErcQxIrlvQrdhvb != null)
						{
							fdhpOdPzdCCMRErcQxIrlvQrdhvb.Dispose();
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
						RnOWBSDiNtXHykMkVRxVAcQCfjzz rnOWBSDiNtXHykMkVRxVAcQCfjzz;
						if (UyDagSysuQFLXfTUWlkZblBcfYPlb == -2 && chQVWWtfKPjTaNoeaNnGGjYiRvMJ == Environment.CurrentManagedThreadId)
						{
							UyDagSysuQFLXfTUWlkZblBcfYPlb = 0;
							rnOWBSDiNtXHykMkVRxVAcQCfjzz = this;
						}
						else
						{
							rnOWBSDiNtXHykMkVRxVAcQCfjzz = new RnOWBSDiNtXHykMkVRxVAcQCfjzz(0);
							rnOWBSDiNtXHykMkVRxVAcQCfjzz.YchOMKowbJGthbboJujWFiHvdVGK = YchOMKowbJGthbboJujWFiHvdVGK;
						}
						return rnOWBSDiNtXHykMkVRxVAcQCfjzz;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class RJJKQghcKtcJckwMTsEeVWYCCjMC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int yYtdWicwLcADNjhyjDdMyApTWdICb;

					private ControllerPollingInfo EbFgcKcqeeluDfJEJkJKEVwTMReYB;

					private int StiUwadQVMtqdOhyEgXMjDCqiJeu;

					private IList<CustomController> ZaoALZbhHDwqcAWTkIduFkkhrwKFA;

					private int DyVcvhVpBBbizkUqMCdiiClMGrZQ;

					private IEnumerator<ControllerPollingInfo> OrgwleGnLOuLsQTTCCcHQmAWXqHM;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return EbFgcKcqeeluDfJEJkJKEVwTMReYB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return EbFgcKcqeeluDfJEJkJKEVwTMReYB;
						}
					}

					[DebuggerHidden]
					public RJJKQghcKtcJckwMTsEeVWYCCjMC(int P_0)
					{
						yYtdWicwLcADNjhyjDdMyApTWdICb = P_0;
						StiUwadQVMtqdOhyEgXMjDCqiJeu = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = yYtdWicwLcADNjhyjDdMyApTWdICb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								zQDGmczkFWcdAvdtzHZMyGKHKWvm();
							}
						}
						ZaoALZbhHDwqcAWTkIduFkkhrwKFA = null;
						OrgwleGnLOuLsQTTCCcHQmAWXqHM = null;
						yYtdWicwLcADNjhyjDdMyApTWdICb = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = yYtdWicwLcADNjhyjDdMyApTWdICb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								yYtdWicwLcADNjhyjDdMyApTWdICb = -3;
								goto IL_0086;
							}
							yYtdWicwLcADNjhyjDdMyApTWdICb = -1;
							ZaoALZbhHDwqcAWTkIduFkkhrwKFA = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
							DyVcvhVpBBbizkUqMCdiiClMGrZQ = 0;
							goto IL_00b0;
							IL_0086:
							if (OrgwleGnLOuLsQTTCCcHQmAWXqHM.MoveNext())
							{
								ControllerPollingInfo current = OrgwleGnLOuLsQTTCCcHQmAWXqHM.Current;
								EbFgcKcqeeluDfJEJkJKEVwTMReYB = current;
								yYtdWicwLcADNjhyjDdMyApTWdICb = 1;
								return true;
							}
							zQDGmczkFWcdAvdtzHZMyGKHKWvm();
							OrgwleGnLOuLsQTTCCcHQmAWXqHM = null;
							DyVcvhVpBBbizkUqMCdiiClMGrZQ++;
							goto IL_00b0;
							IL_00b0:
							if (DyVcvhVpBBbizkUqMCdiiClMGrZQ < ZaoALZbhHDwqcAWTkIduFkkhrwKFA.Count)
							{
								OrgwleGnLOuLsQTTCCcHQmAWXqHM = ZaoALZbhHDwqcAWTkIduFkkhrwKFA[DyVcvhVpBBbizkUqMCdiiClMGrZQ].PollForAllAxes().GetEnumerator();
								yYtdWicwLcADNjhyjDdMyApTWdICb = -3;
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

					private void zQDGmczkFWcdAvdtzHZMyGKHKWvm()
					{
						yYtdWicwLcADNjhyjDdMyApTWdICb = -1;
						if (OrgwleGnLOuLsQTTCCcHQmAWXqHM != null)
						{
							OrgwleGnLOuLsQTTCCcHQmAWXqHM.Dispose();
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
						if (yYtdWicwLcADNjhyjDdMyApTWdICb == -2 && StiUwadQVMtqdOhyEgXMjDCqiJeu == Environment.CurrentManagedThreadId)
						{
							yYtdWicwLcADNjhyjDdMyApTWdICb = 0;
							return this;
						}
						return new RJJKQghcKtcJckwMTsEeVWYCCjMC(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class jmMQWnlTWWIriVDXrfYHouKcoiVQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int hXxGRrzaAYyQtKLyvwheccObDOldA;

					private ControllerPollingInfo kDgwYdwXbkInziywtPILCvxKxmMj;

					private int ringFuDRPliIIDasNGLKiBbpqkAmA;

					private IList<CustomController> kVfvDkKelVDTzXKMAmaTFzzhfZgu;

					private int CHGIYSUHeYncbCNumXbHlXlmLEtl;

					private IEnumerator<ControllerPollingInfo> XzYuLgJKJQpcJmaddAVhcwPOMKGc;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return kDgwYdwXbkInziywtPILCvxKxmMj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kDgwYdwXbkInziywtPILCvxKxmMj;
						}
					}

					[DebuggerHidden]
					public jmMQWnlTWWIriVDXrfYHouKcoiVQ(int P_0)
					{
						hXxGRrzaAYyQtKLyvwheccObDOldA = P_0;
						ringFuDRPliIIDasNGLKiBbpqkAmA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hXxGRrzaAYyQtKLyvwheccObDOldA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								ThsfWqeiCRWpZJuPaRyAmxYiDvsk();
							}
						}
						kVfvDkKelVDTzXKMAmaTFzzhfZgu = null;
						XzYuLgJKJQpcJmaddAVhcwPOMKGc = null;
						hXxGRrzaAYyQtKLyvwheccObDOldA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = hXxGRrzaAYyQtKLyvwheccObDOldA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hXxGRrzaAYyQtKLyvwheccObDOldA = -3;
								goto IL_0086;
							}
							hXxGRrzaAYyQtKLyvwheccObDOldA = -1;
							kVfvDkKelVDTzXKMAmaTFzzhfZgu = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
							CHGIYSUHeYncbCNumXbHlXlmLEtl = 0;
							goto IL_00b0;
							IL_0086:
							if (XzYuLgJKJQpcJmaddAVhcwPOMKGc.MoveNext())
							{
								ControllerPollingInfo current = XzYuLgJKJQpcJmaddAVhcwPOMKGc.Current;
								kDgwYdwXbkInziywtPILCvxKxmMj = current;
								hXxGRrzaAYyQtKLyvwheccObDOldA = 1;
								return true;
							}
							ThsfWqeiCRWpZJuPaRyAmxYiDvsk();
							XzYuLgJKJQpcJmaddAVhcwPOMKGc = null;
							CHGIYSUHeYncbCNumXbHlXlmLEtl++;
							goto IL_00b0;
							IL_00b0:
							if (CHGIYSUHeYncbCNumXbHlXlmLEtl < kVfvDkKelVDTzXKMAmaTFzzhfZgu.Count)
							{
								XzYuLgJKJQpcJmaddAVhcwPOMKGc = kVfvDkKelVDTzXKMAmaTFzzhfZgu[CHGIYSUHeYncbCNumXbHlXlmLEtl].PollForAllButtons().GetEnumerator();
								hXxGRrzaAYyQtKLyvwheccObDOldA = -3;
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

					private void ThsfWqeiCRWpZJuPaRyAmxYiDvsk()
					{
						hXxGRrzaAYyQtKLyvwheccObDOldA = -1;
						if (XzYuLgJKJQpcJmaddAVhcwPOMKGc != null)
						{
							XzYuLgJKJQpcJmaddAVhcwPOMKGc.Dispose();
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
						if (hXxGRrzaAYyQtKLyvwheccObDOldA == -2 && ringFuDRPliIIDasNGLKiBbpqkAmA == Environment.CurrentManagedThreadId)
						{
							hXxGRrzaAYyQtKLyvwheccObDOldA = 0;
							return this;
						}
						return new jmMQWnlTWWIriVDXrfYHouKcoiVQ(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class aUpkIjBCRbPTeDAWnEWDWgRgADRhA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int QGeEKsydpbribobCHxqITQQKPiVS;

					private ControllerPollingInfo eSVyPpoohbWspDrVuKmvxbBHsqtn;

					private int ObbEvQdktpPQgCDsOqlffaPEUReJB;

					private IList<CustomController> OwKWvbUFaOzevQqqVBBYxzAxIsIQ;

					private int zSNyUFYxUlMgSiSLMEfPiXysnpxy;

					private IEnumerator<ControllerPollingInfo> stvCEAoROSmCcqEylhlcdbtwLvEX;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return eSVyPpoohbWspDrVuKmvxbBHsqtn;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return eSVyPpoohbWspDrVuKmvxbBHsqtn;
						}
					}

					[DebuggerHidden]
					public aUpkIjBCRbPTeDAWnEWDWgRgADRhA(int P_0)
					{
						QGeEKsydpbribobCHxqITQQKPiVS = P_0;
						ObbEvQdktpPQgCDsOqlffaPEUReJB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int qGeEKsydpbribobCHxqITQQKPiVS = QGeEKsydpbribobCHxqITQQKPiVS;
						if (qGeEKsydpbribobCHxqITQQKPiVS == -3 || qGeEKsydpbribobCHxqITQQKPiVS == 1)
						{
							try
							{
							}
							finally
							{
								cApnVfZjoLLtWdRhfWAlkEPDWJzc();
							}
						}
						OwKWvbUFaOzevQqqVBBYxzAxIsIQ = null;
						stvCEAoROSmCcqEylhlcdbtwLvEX = null;
						QGeEKsydpbribobCHxqITQQKPiVS = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int qGeEKsydpbribobCHxqITQQKPiVS = QGeEKsydpbribobCHxqITQQKPiVS;
							if (qGeEKsydpbribobCHxqITQQKPiVS != 0)
							{
								if (qGeEKsydpbribobCHxqITQQKPiVS != 1)
								{
									return false;
								}
								QGeEKsydpbribobCHxqITQQKPiVS = -3;
								goto IL_0086;
							}
							QGeEKsydpbribobCHxqITQQKPiVS = -1;
							OwKWvbUFaOzevQqqVBBYxzAxIsIQ = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
							zSNyUFYxUlMgSiSLMEfPiXysnpxy = 0;
							goto IL_00b0;
							IL_0086:
							if (stvCEAoROSmCcqEylhlcdbtwLvEX.MoveNext())
							{
								ControllerPollingInfo current = stvCEAoROSmCcqEylhlcdbtwLvEX.Current;
								eSVyPpoohbWspDrVuKmvxbBHsqtn = current;
								QGeEKsydpbribobCHxqITQQKPiVS = 1;
								return true;
							}
							cApnVfZjoLLtWdRhfWAlkEPDWJzc();
							stvCEAoROSmCcqEylhlcdbtwLvEX = null;
							zSNyUFYxUlMgSiSLMEfPiXysnpxy++;
							goto IL_00b0;
							IL_00b0:
							if (zSNyUFYxUlMgSiSLMEfPiXysnpxy < OwKWvbUFaOzevQqqVBBYxzAxIsIQ.Count)
							{
								stvCEAoROSmCcqEylhlcdbtwLvEX = OwKWvbUFaOzevQqqVBBYxzAxIsIQ[zSNyUFYxUlMgSiSLMEfPiXysnpxy].PollForAllButtonsDown().GetEnumerator();
								QGeEKsydpbribobCHxqITQQKPiVS = -3;
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

					private void cApnVfZjoLLtWdRhfWAlkEPDWJzc()
					{
						QGeEKsydpbribobCHxqITQQKPiVS = -1;
						if (stvCEAoROSmCcqEylhlcdbtwLvEX != null)
						{
							stvCEAoROSmCcqEylhlcdbtwLvEX.Dispose();
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
						if (QGeEKsydpbribobCHxqITQQKPiVS == -2 && ObbEvQdktpPQgCDsOqlffaPEUReJB == Environment.CurrentManagedThreadId)
						{
							QGeEKsydpbribobCHxqITQQKPiVS = 0;
							return this;
						}
						return new aUpkIjBCRbPTeDAWnEWDWgRgADRhA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class RrwWAiVXJMvGxsQKenSXLFuLpjly : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int HHsJzpGCZPQCAowKZpVhqRRurexx;

					private ControllerPollingInfo kyXpXKQfhMHPxaVXbaidVMCTZkmg;

					private int smYjmdvqypDCDbeZPXNADlxkXDfQA;

					private IList<CustomController> pnbpcMSxRHePpDjGJIKscxFJyPxl;

					private int SrVOBRTcFHarXFIVMIvfBTnmFAwr;

					private IEnumerator<ControllerPollingInfo> ADMzOKHxSPBKLBUjfFHKVwfFWfqi;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return kyXpXKQfhMHPxaVXbaidVMCTZkmg;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kyXpXKQfhMHPxaVXbaidVMCTZkmg;
						}
					}

					[DebuggerHidden]
					public RrwWAiVXJMvGxsQKenSXLFuLpjly(int P_0)
					{
						HHsJzpGCZPQCAowKZpVhqRRurexx = P_0;
						smYjmdvqypDCDbeZPXNADlxkXDfQA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hHsJzpGCZPQCAowKZpVhqRRurexx = HHsJzpGCZPQCAowKZpVhqRRurexx;
						if (hHsJzpGCZPQCAowKZpVhqRRurexx == -3 || hHsJzpGCZPQCAowKZpVhqRRurexx == 1)
						{
							try
							{
							}
							finally
							{
								QLXKmdIwjdazDQhMErTLRYFZzUXD();
							}
						}
						pnbpcMSxRHePpDjGJIKscxFJyPxl = null;
						ADMzOKHxSPBKLBUjfFHKVwfFWfqi = null;
						HHsJzpGCZPQCAowKZpVhqRRurexx = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int hHsJzpGCZPQCAowKZpVhqRRurexx = HHsJzpGCZPQCAowKZpVhqRRurexx;
							if (hHsJzpGCZPQCAowKZpVhqRRurexx != 0)
							{
								if (hHsJzpGCZPQCAowKZpVhqRRurexx != 1)
								{
									return false;
								}
								HHsJzpGCZPQCAowKZpVhqRRurexx = -3;
								goto IL_0086;
							}
							HHsJzpGCZPQCAowKZpVhqRRurexx = -1;
							pnbpcMSxRHePpDjGJIKscxFJyPxl = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
							SrVOBRTcFHarXFIVMIvfBTnmFAwr = 0;
							goto IL_00b0;
							IL_0086:
							if (ADMzOKHxSPBKLBUjfFHKVwfFWfqi.MoveNext())
							{
								ControllerPollingInfo current = ADMzOKHxSPBKLBUjfFHKVwfFWfqi.Current;
								kyXpXKQfhMHPxaVXbaidVMCTZkmg = current;
								HHsJzpGCZPQCAowKZpVhqRRurexx = 1;
								return true;
							}
							QLXKmdIwjdazDQhMErTLRYFZzUXD();
							ADMzOKHxSPBKLBUjfFHKVwfFWfqi = null;
							SrVOBRTcFHarXFIVMIvfBTnmFAwr++;
							goto IL_00b0;
							IL_00b0:
							if (SrVOBRTcFHarXFIVMIvfBTnmFAwr < pnbpcMSxRHePpDjGJIKscxFJyPxl.Count)
							{
								ADMzOKHxSPBKLBUjfFHKVwfFWfqi = pnbpcMSxRHePpDjGJIKscxFJyPxl[SrVOBRTcFHarXFIVMIvfBTnmFAwr].PollForAllElements().GetEnumerator();
								HHsJzpGCZPQCAowKZpVhqRRurexx = -3;
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

					private void QLXKmdIwjdazDQhMErTLRYFZzUXD()
					{
						HHsJzpGCZPQCAowKZpVhqRRurexx = -1;
						if (ADMzOKHxSPBKLBUjfFHKVwfFWfqi != null)
						{
							ADMzOKHxSPBKLBUjfFHKVwfFWfqi.Dispose();
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
						if (HHsJzpGCZPQCAowKZpVhqRRurexx == -2 && smYjmdvqypDCDbeZPXNADlxkXDfQA == Environment.CurrentManagedThreadId)
						{
							HHsJzpGCZPQCAowKZpVhqRRurexx = 0;
							return this;
						}
						return new RrwWAiVXJMvGxsQKenSXLFuLpjly(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class tguatejUMQuiYuZRedAYqQbtHOreb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int VEpDnzhFVNGRfynylQaofaXUCGDf;

					private ControllerPollingInfo sYwbKYYYYQeAXUzgCWAuJjESJMET;

					private int jVHDcKzibkesMVgevjRUyZgrToDG;

					private IList<CustomController> cGMtVWbRrENCJcnuMNrUUkAwNkRV;

					private int gepgohsOrlUigPtacTrNYonTxkYC;

					private IEnumerator<ControllerPollingInfo> HAbRyUOrTGcOODrFkcShHsmjJruX;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return sYwbKYYYYQeAXUzgCWAuJjESJMET;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sYwbKYYYYQeAXUzgCWAuJjESJMET;
						}
					}

					[DebuggerHidden]
					public tguatejUMQuiYuZRedAYqQbtHOreb(int P_0)
					{
						VEpDnzhFVNGRfynylQaofaXUCGDf = P_0;
						jVHDcKzibkesMVgevjRUyZgrToDG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int vEpDnzhFVNGRfynylQaofaXUCGDf = VEpDnzhFVNGRfynylQaofaXUCGDf;
						if (vEpDnzhFVNGRfynylQaofaXUCGDf == -3 || vEpDnzhFVNGRfynylQaofaXUCGDf == 1)
						{
							try
							{
							}
							finally
							{
								PZjlCOxREXvydeuZhDNdGMaPwaJi();
							}
						}
						cGMtVWbRrENCJcnuMNrUUkAwNkRV = null;
						HAbRyUOrTGcOODrFkcShHsmjJruX = null;
						VEpDnzhFVNGRfynylQaofaXUCGDf = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int vEpDnzhFVNGRfynylQaofaXUCGDf = VEpDnzhFVNGRfynylQaofaXUCGDf;
							if (vEpDnzhFVNGRfynylQaofaXUCGDf != 0)
							{
								if (vEpDnzhFVNGRfynylQaofaXUCGDf != 1)
								{
									return false;
								}
								VEpDnzhFVNGRfynylQaofaXUCGDf = -3;
								goto IL_0086;
							}
							VEpDnzhFVNGRfynylQaofaXUCGDf = -1;
							cGMtVWbRrENCJcnuMNrUUkAwNkRV = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
							gepgohsOrlUigPtacTrNYonTxkYC = 0;
							goto IL_00b0;
							IL_0086:
							if (HAbRyUOrTGcOODrFkcShHsmjJruX.MoveNext())
							{
								ControllerPollingInfo current = HAbRyUOrTGcOODrFkcShHsmjJruX.Current;
								sYwbKYYYYQeAXUzgCWAuJjESJMET = current;
								VEpDnzhFVNGRfynylQaofaXUCGDf = 1;
								return true;
							}
							PZjlCOxREXvydeuZhDNdGMaPwaJi();
							HAbRyUOrTGcOODrFkcShHsmjJruX = null;
							gepgohsOrlUigPtacTrNYonTxkYC++;
							goto IL_00b0;
							IL_00b0:
							if (gepgohsOrlUigPtacTrNYonTxkYC < cGMtVWbRrENCJcnuMNrUUkAwNkRV.Count)
							{
								HAbRyUOrTGcOODrFkcShHsmjJruX = cGMtVWbRrENCJcnuMNrUUkAwNkRV[gepgohsOrlUigPtacTrNYonTxkYC].PollForAllElementsDown().GetEnumerator();
								VEpDnzhFVNGRfynylQaofaXUCGDf = -3;
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

					private void PZjlCOxREXvydeuZhDNdGMaPwaJi()
					{
						VEpDnzhFVNGRfynylQaofaXUCGDf = -1;
						if (HAbRyUOrTGcOODrFkcShHsmjJruX != null)
						{
							HAbRyUOrTGcOODrFkcShHsmjJruX.Dispose();
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
						if (VEpDnzhFVNGRfynylQaofaXUCGDf == -2 && jVHDcKzibkesMVgevjRUyZgrToDG == Environment.CurrentManagedThreadId)
						{
							VEpDnzhFVNGRfynylQaofaXUCGDf = 0;
							return this;
						}
						return new tguatejUMQuiYuZRedAYqQbtHOreb(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class byeMjGeUkytKvqXFGmkiyqXAFTzQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int CoUaRMVubUAoMNRtfRnGfxDwUATj;

					private ControllerPollingInfo BcSqEvVGsZjDZAxhiURLdKIUkpL;

					private int THMVqGLyuyTnnCOXdEiIVtWlxTmj;

					private IList<Joystick> bNNJdDDKdjcNprxxYihxuBTcpyCS;

					private int YfJFYMcMirWLMeWxjXMdInzyLLiZ;

					private IEnumerator<ControllerPollingInfo> POAbaOUtMRikyrJzAizxahBZTlrt;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return BcSqEvVGsZjDZAxhiURLdKIUkpL;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return BcSqEvVGsZjDZAxhiURLdKIUkpL;
						}
					}

					[DebuggerHidden]
					public byeMjGeUkytKvqXFGmkiyqXAFTzQ(int P_0)
					{
						CoUaRMVubUAoMNRtfRnGfxDwUATj = P_0;
						THMVqGLyuyTnnCOXdEiIVtWlxTmj = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int coUaRMVubUAoMNRtfRnGfxDwUATj = CoUaRMVubUAoMNRtfRnGfxDwUATj;
						if (coUaRMVubUAoMNRtfRnGfxDwUATj == -3 || coUaRMVubUAoMNRtfRnGfxDwUATj == 1)
						{
							try
							{
							}
							finally
							{
								WaFoubOHIninbDlRMmWWqtUMOfyGA();
							}
						}
						bNNJdDDKdjcNprxxYihxuBTcpyCS = null;
						POAbaOUtMRikyrJzAizxahBZTlrt = null;
						CoUaRMVubUAoMNRtfRnGfxDwUATj = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int coUaRMVubUAoMNRtfRnGfxDwUATj = CoUaRMVubUAoMNRtfRnGfxDwUATj;
							if (coUaRMVubUAoMNRtfRnGfxDwUATj != 0)
							{
								if (coUaRMVubUAoMNRtfRnGfxDwUATj != 1)
								{
									return false;
								}
								CoUaRMVubUAoMNRtfRnGfxDwUATj = -3;
								goto IL_0086;
							}
							CoUaRMVubUAoMNRtfRnGfxDwUATj = -1;
							bNNJdDDKdjcNprxxYihxuBTcpyCS = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
							YfJFYMcMirWLMeWxjXMdInzyLLiZ = 0;
							goto IL_00b0;
							IL_0086:
							if (POAbaOUtMRikyrJzAizxahBZTlrt.MoveNext())
							{
								ControllerPollingInfo current = POAbaOUtMRikyrJzAizxahBZTlrt.Current;
								BcSqEvVGsZjDZAxhiURLdKIUkpL = current;
								CoUaRMVubUAoMNRtfRnGfxDwUATj = 1;
								return true;
							}
							WaFoubOHIninbDlRMmWWqtUMOfyGA();
							POAbaOUtMRikyrJzAizxahBZTlrt = null;
							YfJFYMcMirWLMeWxjXMdInzyLLiZ++;
							goto IL_00b0;
							IL_00b0:
							if (YfJFYMcMirWLMeWxjXMdInzyLLiZ < bNNJdDDKdjcNprxxYihxuBTcpyCS.Count)
							{
								POAbaOUtMRikyrJzAizxahBZTlrt = bNNJdDDKdjcNprxxYihxuBTcpyCS[YfJFYMcMirWLMeWxjXMdInzyLLiZ].PollForAllAxes().GetEnumerator();
								CoUaRMVubUAoMNRtfRnGfxDwUATj = -3;
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

					private void WaFoubOHIninbDlRMmWWqtUMOfyGA()
					{
						CoUaRMVubUAoMNRtfRnGfxDwUATj = -1;
						if (POAbaOUtMRikyrJzAizxahBZTlrt != null)
						{
							POAbaOUtMRikyrJzAizxahBZTlrt.Dispose();
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
						if (CoUaRMVubUAoMNRtfRnGfxDwUATj == -2 && THMVqGLyuyTnnCOXdEiIVtWlxTmj == Environment.CurrentManagedThreadId)
						{
							CoUaRMVubUAoMNRtfRnGfxDwUATj = 0;
							return this;
						}
						return new byeMjGeUkytKvqXFGmkiyqXAFTzQ(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class NnUkljMsHWDEtzVvUAZKNNfuiKeE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int gjekjQiVeCyTLipJxKaBlejtSXvi;

					private ControllerPollingInfo kvIFTxBdWIdRHfcSAIkkfDnhHxcAd;

					private int vNiLMoOpJHWnzEJhKYLjzsGEYIxd;

					private IList<Joystick> FUTRdzuQEjFpwiegJcnhKzmhHuKB;

					private int eWSQApGSoFIZHcnVmRIQLkGwuszK;

					private IEnumerator<ControllerPollingInfo> uOnFyMHHHwIGnosmgaIWAgkDZeQUb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return kvIFTxBdWIdRHfcSAIkkfDnhHxcAd;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kvIFTxBdWIdRHfcSAIkkfDnhHxcAd;
						}
					}

					[DebuggerHidden]
					public NnUkljMsHWDEtzVvUAZKNNfuiKeE(int P_0)
					{
						gjekjQiVeCyTLipJxKaBlejtSXvi = P_0;
						vNiLMoOpJHWnzEJhKYLjzsGEYIxd = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = gjekjQiVeCyTLipJxKaBlejtSXvi;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								fcNeoibFPIedffmacldfsroOCNVxb();
							}
						}
						FUTRdzuQEjFpwiegJcnhKzmhHuKB = null;
						uOnFyMHHHwIGnosmgaIWAgkDZeQUb = null;
						gjekjQiVeCyTLipJxKaBlejtSXvi = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = gjekjQiVeCyTLipJxKaBlejtSXvi;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								gjekjQiVeCyTLipJxKaBlejtSXvi = -3;
								goto IL_0086;
							}
							gjekjQiVeCyTLipJxKaBlejtSXvi = -1;
							FUTRdzuQEjFpwiegJcnhKzmhHuKB = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
							eWSQApGSoFIZHcnVmRIQLkGwuszK = 0;
							goto IL_00b0;
							IL_0086:
							if (uOnFyMHHHwIGnosmgaIWAgkDZeQUb.MoveNext())
							{
								ControllerPollingInfo current = uOnFyMHHHwIGnosmgaIWAgkDZeQUb.Current;
								kvIFTxBdWIdRHfcSAIkkfDnhHxcAd = current;
								gjekjQiVeCyTLipJxKaBlejtSXvi = 1;
								return true;
							}
							fcNeoibFPIedffmacldfsroOCNVxb();
							uOnFyMHHHwIGnosmgaIWAgkDZeQUb = null;
							eWSQApGSoFIZHcnVmRIQLkGwuszK++;
							goto IL_00b0;
							IL_00b0:
							if (eWSQApGSoFIZHcnVmRIQLkGwuszK < FUTRdzuQEjFpwiegJcnhKzmhHuKB.Count)
							{
								uOnFyMHHHwIGnosmgaIWAgkDZeQUb = FUTRdzuQEjFpwiegJcnhKzmhHuKB[eWSQApGSoFIZHcnVmRIQLkGwuszK].PollForAllButtons().GetEnumerator();
								gjekjQiVeCyTLipJxKaBlejtSXvi = -3;
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

					private void fcNeoibFPIedffmacldfsroOCNVxb()
					{
						gjekjQiVeCyTLipJxKaBlejtSXvi = -1;
						if (uOnFyMHHHwIGnosmgaIWAgkDZeQUb != null)
						{
							uOnFyMHHHwIGnosmgaIWAgkDZeQUb.Dispose();
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
						if (gjekjQiVeCyTLipJxKaBlejtSXvi == -2 && vNiLMoOpJHWnzEJhKYLjzsGEYIxd == Environment.CurrentManagedThreadId)
						{
							gjekjQiVeCyTLipJxKaBlejtSXvi = 0;
							return this;
						}
						return new NnUkljMsHWDEtzVvUAZKNNfuiKeE(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class cFCQRXqzsYkEHkxfPdCswHmuUvlC : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int eaEofCDOnJsyyQMVYKIvpqAIcUkY;

					private ControllerPollingInfo snqEMeXbliabfKemQurdRvnJEXVb;

					private int GCQfbnFxJkYzdtqfUfllvIGGxazhA;

					private IList<Joystick> QygDMoDIHfYCBmsPfiMQpQlFIaxsA;

					private int ezfUVOAuKsllvrdWKyVFrmRGFKtY;

					private IEnumerator<ControllerPollingInfo> dmfllTbMWjRufDUxJfkxMozBSdXm;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return snqEMeXbliabfKemQurdRvnJEXVb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return snqEMeXbliabfKemQurdRvnJEXVb;
						}
					}

					[DebuggerHidden]
					public cFCQRXqzsYkEHkxfPdCswHmuUvlC(int P_0)
					{
						eaEofCDOnJsyyQMVYKIvpqAIcUkY = P_0;
						GCQfbnFxJkYzdtqfUfllvIGGxazhA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = eaEofCDOnJsyyQMVYKIvpqAIcUkY;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								ngHaCrDEWUdKzHrjEOAZKSxrMnHwB();
							}
						}
						QygDMoDIHfYCBmsPfiMQpQlFIaxsA = null;
						dmfllTbMWjRufDUxJfkxMozBSdXm = null;
						eaEofCDOnJsyyQMVYKIvpqAIcUkY = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = eaEofCDOnJsyyQMVYKIvpqAIcUkY;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								eaEofCDOnJsyyQMVYKIvpqAIcUkY = -3;
								goto IL_0086;
							}
							eaEofCDOnJsyyQMVYKIvpqAIcUkY = -1;
							QygDMoDIHfYCBmsPfiMQpQlFIaxsA = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
							ezfUVOAuKsllvrdWKyVFrmRGFKtY = 0;
							goto IL_00b0;
							IL_0086:
							if (dmfllTbMWjRufDUxJfkxMozBSdXm.MoveNext())
							{
								ControllerPollingInfo current = dmfllTbMWjRufDUxJfkxMozBSdXm.Current;
								snqEMeXbliabfKemQurdRvnJEXVb = current;
								eaEofCDOnJsyyQMVYKIvpqAIcUkY = 1;
								return true;
							}
							ngHaCrDEWUdKzHrjEOAZKSxrMnHwB();
							dmfllTbMWjRufDUxJfkxMozBSdXm = null;
							ezfUVOAuKsllvrdWKyVFrmRGFKtY++;
							goto IL_00b0;
							IL_00b0:
							if (ezfUVOAuKsllvrdWKyVFrmRGFKtY < QygDMoDIHfYCBmsPfiMQpQlFIaxsA.Count)
							{
								dmfllTbMWjRufDUxJfkxMozBSdXm = QygDMoDIHfYCBmsPfiMQpQlFIaxsA[ezfUVOAuKsllvrdWKyVFrmRGFKtY].PollForAllButtonsDown().GetEnumerator();
								eaEofCDOnJsyyQMVYKIvpqAIcUkY = -3;
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

					private void ngHaCrDEWUdKzHrjEOAZKSxrMnHwB()
					{
						eaEofCDOnJsyyQMVYKIvpqAIcUkY = -1;
						if (dmfllTbMWjRufDUxJfkxMozBSdXm != null)
						{
							dmfllTbMWjRufDUxJfkxMozBSdXm.Dispose();
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
						if (eaEofCDOnJsyyQMVYKIvpqAIcUkY == -2 && GCQfbnFxJkYzdtqfUfllvIGGxazhA == Environment.CurrentManagedThreadId)
						{
							eaEofCDOnJsyyQMVYKIvpqAIcUkY = 0;
							return this;
						}
						return new cFCQRXqzsYkEHkxfPdCswHmuUvlC(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class IsGjZeDdzmeQMkHvUUfuOzUViBHP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int HIfDHMhDUVHOwAXjAjjTlDtWFwWRA;

					private ControllerPollingInfo VSrcShhqdbhiKEkaEPtbqclHBOHKd;

					private int dcWflHpthJSDfHGyFlXJMqiaXHOK;

					private IList<Joystick> vPCNiRKWOiTqCORxCVDZlFifLUoI;

					private int TRvxronskYVKnRBymEMerSjWhTvA;

					private IEnumerator<ControllerPollingInfo> hCPfNiihURxwoIkfAmUsvWTJjXeC;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return VSrcShhqdbhiKEkaEPtbqclHBOHKd;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VSrcShhqdbhiKEkaEPtbqclHBOHKd;
						}
					}

					[DebuggerHidden]
					public IsGjZeDdzmeQMkHvUUfuOzUViBHP(int P_0)
					{
						HIfDHMhDUVHOwAXjAjjTlDtWFwWRA = P_0;
						dcWflHpthJSDfHGyFlXJMqiaXHOK = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hIfDHMhDUVHOwAXjAjjTlDtWFwWRA = HIfDHMhDUVHOwAXjAjjTlDtWFwWRA;
						if (hIfDHMhDUVHOwAXjAjjTlDtWFwWRA == -3 || hIfDHMhDUVHOwAXjAjjTlDtWFwWRA == 1)
						{
							try
							{
							}
							finally
							{
								drUSjTeFaWwySPaCSgPrnIiPnvMk();
							}
						}
						vPCNiRKWOiTqCORxCVDZlFifLUoI = null;
						hCPfNiihURxwoIkfAmUsvWTJjXeC = null;
						HIfDHMhDUVHOwAXjAjjTlDtWFwWRA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int hIfDHMhDUVHOwAXjAjjTlDtWFwWRA = HIfDHMhDUVHOwAXjAjjTlDtWFwWRA;
							if (hIfDHMhDUVHOwAXjAjjTlDtWFwWRA != 0)
							{
								if (hIfDHMhDUVHOwAXjAjjTlDtWFwWRA != 1)
								{
									return false;
								}
								HIfDHMhDUVHOwAXjAjjTlDtWFwWRA = -3;
								goto IL_0086;
							}
							HIfDHMhDUVHOwAXjAjjTlDtWFwWRA = -1;
							vPCNiRKWOiTqCORxCVDZlFifLUoI = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
							TRvxronskYVKnRBymEMerSjWhTvA = 0;
							goto IL_00b0;
							IL_0086:
							if (hCPfNiihURxwoIkfAmUsvWTJjXeC.MoveNext())
							{
								ControllerPollingInfo current = hCPfNiihURxwoIkfAmUsvWTJjXeC.Current;
								VSrcShhqdbhiKEkaEPtbqclHBOHKd = current;
								HIfDHMhDUVHOwAXjAjjTlDtWFwWRA = 1;
								return true;
							}
							drUSjTeFaWwySPaCSgPrnIiPnvMk();
							hCPfNiihURxwoIkfAmUsvWTJjXeC = null;
							TRvxronskYVKnRBymEMerSjWhTvA++;
							goto IL_00b0;
							IL_00b0:
							if (TRvxronskYVKnRBymEMerSjWhTvA < vPCNiRKWOiTqCORxCVDZlFifLUoI.Count)
							{
								hCPfNiihURxwoIkfAmUsvWTJjXeC = vPCNiRKWOiTqCORxCVDZlFifLUoI[TRvxronskYVKnRBymEMerSjWhTvA].PollForAllElements().GetEnumerator();
								HIfDHMhDUVHOwAXjAjjTlDtWFwWRA = -3;
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

					private void drUSjTeFaWwySPaCSgPrnIiPnvMk()
					{
						HIfDHMhDUVHOwAXjAjjTlDtWFwWRA = -1;
						if (hCPfNiihURxwoIkfAmUsvWTJjXeC != null)
						{
							hCPfNiihURxwoIkfAmUsvWTJjXeC.Dispose();
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
						if (HIfDHMhDUVHOwAXjAjjTlDtWFwWRA == -2 && dcWflHpthJSDfHGyFlXJMqiaXHOK == Environment.CurrentManagedThreadId)
						{
							HIfDHMhDUVHOwAXjAjjTlDtWFwWRA = 0;
							return this;
						}
						return new IsGjZeDdzmeQMkHvUUfuOzUViBHP(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class AXDqZspqiAWqybSBhzdBSThWyNAK : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int HPSFrLboZqNKDAvAHZkWJozllpjAA;

					private ControllerPollingInfo OVnyePdbNARxBSVxgPnHkKMFleHl;

					private int VmOpyXWbTknVMBLlvjsgqvJGBJaJA;

					private IList<Joystick> EGJBAmGptNWDqUBVsqlnJuSUDgGK;

					private int UnbNnrVYdASLeEJohypPmHwXMuXS;

					private IEnumerator<ControllerPollingInfo> kNuoSvRnbntQqZtJNVjQYxlNiyE;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return OVnyePdbNARxBSVxgPnHkKMFleHl;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return OVnyePdbNARxBSVxgPnHkKMFleHl;
						}
					}

					[DebuggerHidden]
					public AXDqZspqiAWqybSBhzdBSThWyNAK(int P_0)
					{
						HPSFrLboZqNKDAvAHZkWJozllpjAA = P_0;
						VmOpyXWbTknVMBLlvjsgqvJGBJaJA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hPSFrLboZqNKDAvAHZkWJozllpjAA = HPSFrLboZqNKDAvAHZkWJozllpjAA;
						if (hPSFrLboZqNKDAvAHZkWJozllpjAA == -3 || hPSFrLboZqNKDAvAHZkWJozllpjAA == 1)
						{
							try
							{
							}
							finally
							{
								kaLJTRpyeQgSdtpmhWFFrCFWFQzfA();
							}
						}
						EGJBAmGptNWDqUBVsqlnJuSUDgGK = null;
						kNuoSvRnbntQqZtJNVjQYxlNiyE = null;
						HPSFrLboZqNKDAvAHZkWJozllpjAA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int hPSFrLboZqNKDAvAHZkWJozllpjAA = HPSFrLboZqNKDAvAHZkWJozllpjAA;
							if (hPSFrLboZqNKDAvAHZkWJozllpjAA != 0)
							{
								if (hPSFrLboZqNKDAvAHZkWJozllpjAA != 1)
								{
									return false;
								}
								HPSFrLboZqNKDAvAHZkWJozllpjAA = -3;
								goto IL_0086;
							}
							HPSFrLboZqNKDAvAHZkWJozllpjAA = -1;
							EGJBAmGptNWDqUBVsqlnJuSUDgGK = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
							UnbNnrVYdASLeEJohypPmHwXMuXS = 0;
							goto IL_00b0;
							IL_0086:
							if (kNuoSvRnbntQqZtJNVjQYxlNiyE.MoveNext())
							{
								ControllerPollingInfo current = kNuoSvRnbntQqZtJNVjQYxlNiyE.Current;
								OVnyePdbNARxBSVxgPnHkKMFleHl = current;
								HPSFrLboZqNKDAvAHZkWJozllpjAA = 1;
								return true;
							}
							kaLJTRpyeQgSdtpmhWFFrCFWFQzfA();
							kNuoSvRnbntQqZtJNVjQYxlNiyE = null;
							UnbNnrVYdASLeEJohypPmHwXMuXS++;
							goto IL_00b0;
							IL_00b0:
							if (UnbNnrVYdASLeEJohypPmHwXMuXS < EGJBAmGptNWDqUBVsqlnJuSUDgGK.Count)
							{
								kNuoSvRnbntQqZtJNVjQYxlNiyE = EGJBAmGptNWDqUBVsqlnJuSUDgGK[UnbNnrVYdASLeEJohypPmHwXMuXS].PollForAllElementsDown().GetEnumerator();
								HPSFrLboZqNKDAvAHZkWJozllpjAA = -3;
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

					private void kaLJTRpyeQgSdtpmhWFFrCFWFQzfA()
					{
						HPSFrLboZqNKDAvAHZkWJozllpjAA = -1;
						if (kNuoSvRnbntQqZtJNVjQYxlNiyE != null)
						{
							kNuoSvRnbntQqZtJNVjQYxlNiyE.Dispose();
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
						if (HPSFrLboZqNKDAvAHZkWJozllpjAA == -2 && VmOpyXWbTknVMBLlvjsgqvJGBJaJA == Environment.CurrentManagedThreadId)
						{
							HPSFrLboZqNKDAvAHZkWJozllpjAA = 0;
							return this;
						}
						return new AXDqZspqiAWqybSBhzdBSThWyNAK(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private static PollingHelper iVeqdfJFUVPTfYraKXkQXRroBiaR;

				internal static PollingHelper pnCcpbCEBCfliunzAFFIwdVnEgiCA => iVeqdfJFUVPTfYraKXkQXRroBiaR ?? (iVeqdfJFUVPTfYraKXkQXRroBiaR = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = NYghkwuADcwsoqxNOQnmVPnaOKHJ();
					if (result.success)
					{
						return result;
					}
					result = pzOmFPyUWVAEoryeUqwHbgjHWlGf();
					if (result.success)
					{
						return result;
					}
					result = nqzaTsYFIqiJxIsKMsucMjiOAUyy();
					if (result.success)
					{
						return result;
					}
					result = agNblzhggejAlbddHngdCVFrftHTB();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = xshwfMZdBUuDqnYCDerFnZkBVewc();
					if (result.success)
					{
						return result;
					}
					result = PNDbClgLmofHnZZJtQiknaODQehIA();
					if (result.success)
					{
						return result;
					}
					result = vGvnzcCagzirKqJwmGhYMxwilouw();
					if (result.success)
					{
						return result;
					}
					result = oJzMXNBwgLpRozBIzkyJNamODMun();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = MFgCUZctAyVTHNwThuQONHZWOQXm();
					if (result.success)
					{
						return result;
					}
					result = pzOmFPyUWVAEoryeUqwHbgjHWlGf();
					if (result.success)
					{
						return result;
					}
					result = AFhazwawnqQwxIuSTcIphEzrRUyVA();
					if (result.success)
					{
						return result;
					}
					result = ryZZyaAqzxReTYlIggGiCdwkRitNA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = buhXPMKdZuMvGFESZpNiSCdsrEAQ();
					if (result.success)
					{
						return result;
					}
					result = PNDbClgLmofHnZZJtQiknaODQehIA();
					if (result.success)
					{
						return result;
					}
					result = fPeAvIHpOnDbyuvWcTtgzdmNsdas();
					if (result.success)
					{
						return result;
					}
					result = JOgoBTvOVWeFJpHapQKTuNmEHOQCA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					ControllerPollingInfo result = wNtpUiglbuguZUwmYoznIUgvLYAP();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					if (result.success)
					{
						return result;
					}
					result = JcojtWxkIsfxQEOIIvLEwVAQFJfxA();
					if (result.success)
					{
						return result;
					}
					result = rMHWRIJDWvKvyPpCHaBJgAgkOYFUA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => NYghkwuADcwsoqxNOQnmVPnaOKHJ(), 
						ControllerType.Keyboard => pzOmFPyUWVAEoryeUqwHbgjHWlGf(), 
						ControllerType.Mouse => nqzaTsYFIqiJxIsKMsucMjiOAUyy(), 
						ControllerType.Custom => agNblzhggejAlbddHngdCVFrftHTB(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => xshwfMZdBUuDqnYCDerFnZkBVewc(), 
						ControllerType.Keyboard => PNDbClgLmofHnZZJtQiknaODQehIA(), 
						ControllerType.Mouse => vGvnzcCagzirKqJwmGhYMxwilouw(), 
						ControllerType.Custom => oJzMXNBwgLpRozBIzkyJNamODMun(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => MFgCUZctAyVTHNwThuQONHZWOQXm(), 
						ControllerType.Keyboard => pzOmFPyUWVAEoryeUqwHbgjHWlGf(), 
						ControllerType.Mouse => AFhazwawnqQwxIuSTcIphEzrRUyVA(), 
						ControllerType.Custom => ryZZyaAqzxReTYlIggGiCdwkRitNA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => buhXPMKdZuMvGFESZpNiSCdsrEAQ(), 
						ControllerType.Keyboard => PNDbClgLmofHnZZJtQiknaODQehIA(), 
						ControllerType.Mouse => fPeAvIHpOnDbyuvWcTtgzdmNsdas(), 
						ControllerType.Custom => JOgoBTvOVWeFJpHapQKTuNmEHOQCA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => wNtpUiglbuguZUwmYoznIUgvLYAP(), 
						ControllerType.Keyboard => ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA(), 
						ControllerType.Mouse => JcojtWxkIsfxQEOIIvLEwVAQFJfxA(), 
						ControllerType.Custom => rMHWRIJDWvKvyPpCHaBJgAgkOYFUA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => FoZtJmfOawhukkxdQfaZCqpZeBkS(controllerId), 
						ControllerType.Keyboard => pzOmFPyUWVAEoryeUqwHbgjHWlGf(), 
						ControllerType.Mouse => nqzaTsYFIqiJxIsKMsucMjiOAUyy(), 
						ControllerType.Custom => qBDIVVGsdNStmSvtIjByxrMzyLGH(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => UwWvvmlqbBcBBhaDtDgbnTjgtKDnA(controllerId), 
						ControllerType.Keyboard => PNDbClgLmofHnZZJtQiknaODQehIA(), 
						ControllerType.Mouse => vGvnzcCagzirKqJwmGhYMxwilouw(), 
						ControllerType.Custom => iOhVijOLYUtucQleRiJqAmGaQlsbA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => zqhgQLdnKIWaOKMBbooYSGvYNuxHA(controllerId), 
						ControllerType.Keyboard => pzOmFPyUWVAEoryeUqwHbgjHWlGf(), 
						ControllerType.Mouse => AFhazwawnqQwxIuSTcIphEzrRUyVA(), 
						ControllerType.Custom => UnlSKrIAuFExVsNsgDmpZcObGioY(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => RqhqcsHksYEbGcZQdnjSbLojPWwdb(controllerId), 
						ControllerType.Keyboard => PNDbClgLmofHnZZJtQiknaODQehIA(), 
						ControllerType.Mouse => fPeAvIHpOnDbyuvWcTtgzdmNsdas(), 
						ControllerType.Custom => CScbwcblDDDPhwigUxjIHFZdFqKnA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
					}
					return controllerType switch
					{
						ControllerType.Joystick => FElWkgcUnJSQSFjmlqMTlJIJYYgp(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA(), 
						ControllerType.Mouse => JcojtWxkIsfxQEOIIvLEwVAQFJfxA(), 
						ControllerType.Custom => NzIZNdKZNWmYQoBpHPYRxmerSyDJ(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				[IteratorStateMachine(typeof(psRpYANWUYviJQKJzNWPpPpSvNkE))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return new psRpYANWUYviJQKJzNWPpPpSvNkE(-2)
					{
						fHMHgvDrJYvUwQGvBbQthUdAtqXRA = this
					};
				}

				[IteratorStateMachine(typeof(RnOWBSDiNtXHykMkVRxVAcQCfjzz))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return new RnOWBSDiNtXHykMkVRxVAcQCfjzz(-2)
					{
						YchOMKowbJGthbboJujWFiHvdVGK = this
					};
				}

				[IteratorStateMachine(typeof(kzxnEkUhHCjSZJoGajWfxHEXUHqbA))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return new kzxnEkUhHCjSZJoGajWfxHEXUHqbA(-2)
					{
						dClGKliKcxQasdMbxrYgIIhNUUKSA = this
					};
				}

				[IteratorStateMachine(typeof(ekEOokUAzJNnOvImqaruztDEGXjY))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return new ekEOokUAzJNnOvImqaruztDEGXjY(-2)
					{
						VWfMaxDknUMIZuAAHxjbSOsmJkMA = this
					};
				}

				[IteratorStateMachine(typeof(EqCyTvvJYXdpgKFdfUjsFOcCQcVX))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return new EqCyTvvJYXdpgKFdfUjsFOcCQcVX(-2)
					{
						yLFlUquaydxqnprfYSDbWwyKKXvL = this
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
						ControllerType.Joystick => RiCCiiDaoVgQvdtOncZxEtwfyvwqb(controllerId), 
						ControllerType.Keyboard => HVZugPDPxwCKJCERVePghryGeHJgB(), 
						ControllerType.Mouse => DaVchkfgrumiUdRvhhoLHJpTCTnI(), 
						ControllerType.Custom => jlhsjrGZGMWIXOwGGFcMKPenUrZN(controllerId), 
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
						ControllerType.Joystick => dujNcmLejtcQUbYfnnpVGZtyKENqA(controllerId), 
						ControllerType.Keyboard => sBijQXTPeuiMBIugVDFOQjoCUYvh(), 
						ControllerType.Mouse => TpHAYnDDNYKQfspZCXlkFnmUueGeA(), 
						ControllerType.Custom => MpfBWtcjzLVISfIuVVXmaaQnNmNp(controllerId), 
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
						ControllerType.Joystick => BHCpIJDTfSgZSgwyglSKPNIveNIGA(controllerId), 
						ControllerType.Keyboard => HVZugPDPxwCKJCERVePghryGeHJgB(), 
						ControllerType.Mouse => bpBjcmCyRoAycosmPFaLQAbQgdvZ(), 
						ControllerType.Custom => TgNcVoEcOmNdwaqucDIPOZIMzbahb(controllerId), 
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
						ControllerType.Joystick => DoLKtJsXRXiLuZThsGcRmqTrBggJA(controllerId), 
						ControllerType.Keyboard => sBijQXTPeuiMBIugVDFOQjoCUYvh(), 
						ControllerType.Mouse => XgKJLRHtupEazkXPNZWnNAKMkbmM(), 
						ControllerType.Custom => RxAUaCXEcZZgyBruBbOFOsjpNlkp(controllerId), 
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
						ControllerType.Joystick => RFTPxryxbHqkXEBOcshiCHZmdcPaA(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => WYuGVmZyTarAMBIFJpeldaqpbfOL(), 
						ControllerType.Custom => OzLekdCDFlTJmSLmrUMUbDQeFdeN(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo NYghkwuADcwsoqxNOQnmVPnaOKHJ()
				{
					IList<Joystick> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo xshwfMZdBUuDqnYCDerFnZkBVewc()
				{
					IList<Joystick> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo MFgCUZctAyVTHNwThuQONHZWOQXm()
				{
					IList<Joystick> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo buhXPMKdZuMvGFESZpNiSCdsrEAQ()
				{
					IList<Joystick> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo wNtpUiglbuguZUwmYoznIUgvLYAP()
				{
					IList<Joystick> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo FoZtJmfOawhukkxdQfaZCqpZeBkS(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo UwWvvmlqbBcBBhaDtDgbnTjgtKDnA(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo zqhgQLdnKIWaOKMBbooYSGvYNuxHA(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo RqhqcsHksYEbGcZQdnjSbLojPWwdb(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo FElWkgcUnJSQSFjmlqMTlJIJYYgp(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo pzOmFPyUWVAEoryeUqwHbgjHWlGf()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo PNDbClgLmofHnZZJtQiknaODQehIA()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo nqzaTsYFIqiJxIsKMsucMjiOAUyy()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo vGvnzcCagzirKqJwmGhYMxwilouw()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo AFhazwawnqQwxIuSTcIphEzrRUyVA()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo fPeAvIHpOnDbyuvWcTtgzdmNsdas()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo JcojtWxkIsfxQEOIIvLEwVAQFJfxA()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo agNblzhggejAlbddHngdCVFrftHTB()
				{
					IList<CustomController> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo oJzMXNBwgLpRozBIzkyJNamODMun()
				{
					IList<CustomController> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo ryZZyaAqzxReTYlIggGiCdwkRitNA()
				{
					IList<CustomController> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo JOgoBTvOVWeFJpHapQKTuNmEHOQCA()
				{
					IList<CustomController> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo rMHWRIJDWvKvyPpCHaBJgAgkOYFUA()
				{
					IList<CustomController> list = AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo qBDIVVGsdNStmSvtIjByxrMzyLGH(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo iOhVijOLYUtucQleRiJqAmGaQlsbA(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo UnlSKrIAuFExVsNsgDmpZcObGioY(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo CScbwcblDDDPhwigUxjIHFZdFqKnA(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				private ControllerPollingInfo NzIZNdKZNWmYQoBpHPYRxmerSyDJ(int P_0)
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
				}

				[IteratorStateMachine(typeof(IsGjZeDdzmeQMkHvUUfuOzUViBHP))]
				private IEnumerable<ControllerPollingInfo> vvFDEABPIZInabhRENuTlFrZGxksb()
				{
					return new IsGjZeDdzmeQMkHvUUfuOzUViBHP(-2);
				}

				[IteratorStateMachine(typeof(AXDqZspqiAWqybSBhzdBSThWyNAK))]
				private IEnumerable<ControllerPollingInfo> lDhEDLIiujHGldfohgFnKqKFrWZuB()
				{
					return new AXDqZspqiAWqybSBhzdBSThWyNAK(-2);
				}

				[IteratorStateMachine(typeof(NnUkljMsHWDEtzVvUAZKNNfuiKeE))]
				private IEnumerable<ControllerPollingInfo> eMqJzSNXMHQuSUIasvcriQrBXDXE()
				{
					return new NnUkljMsHWDEtzVvUAZKNNfuiKeE(-2);
				}

				[IteratorStateMachine(typeof(cFCQRXqzsYkEHkxfPdCswHmuUvlC))]
				private IEnumerable<ControllerPollingInfo> lgMeNajJXCGWmDOPnUgPYVUThSAAb()
				{
					return new cFCQRXqzsYkEHkxfPdCswHmuUvlC(-2);
				}

				[IteratorStateMachine(typeof(byeMjGeUkytKvqXFGmkiyqXAFTzQ))]
				private IEnumerable<ControllerPollingInfo> MhzenSipwAJJoosbezvSIFmDIbIK()
				{
					return new byeMjGeUkytKvqXFGmkiyqXAFTzQ(-2);
				}

				private IEnumerable<ControllerPollingInfo> RiCCiiDaoVgQvdtOncZxEtwfyvwqb(int P_0)
				{
					Joystick joystick = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> dujNcmLejtcQUbYfnnpVGZtyKENqA(int P_0)
				{
					Joystick joystick = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> BHCpIJDTfSgZSgwyglSKPNIveNIGA(int P_0)
				{
					Joystick joystick = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> DoLKtJsXRXiLuZThsGcRmqTrBggJA(int P_0)
				{
					Joystick joystick = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> RFTPxryxbHqkXEBOcshiCHZmdcPaA(int P_0)
				{
					Joystick joystick = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> HVZugPDPxwCKJCERVePghryGeHJgB()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> sBijQXTPeuiMBIugVDFOQjoCUYvh()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> DaVchkfgrumiUdRvhhoLHJpTCTnI()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> TpHAYnDDNYKQfspZCXlkFnmUueGeA()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> bpBjcmCyRoAycosmPFaLQAbQgdvZ()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> XgKJLRHtupEazkXPNZWnNAKMkbmM()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> WYuGVmZyTarAMBIFJpeldaqpbfOL()
				{
					return KxqrRtEEOCfhhREzEERAgMRcgdrqA.Mouse.PollForAllAxes();
				}

				[IteratorStateMachine(typeof(RrwWAiVXJMvGxsQKenSXLFuLpjly))]
				private IEnumerable<ControllerPollingInfo> XIbwbkDHhzhcGiiiuzxgrYbGbBnI()
				{
					return new RrwWAiVXJMvGxsQKenSXLFuLpjly(-2);
				}

				[IteratorStateMachine(typeof(tguatejUMQuiYuZRedAYqQbtHOreb))]
				private IEnumerable<ControllerPollingInfo> BzeekwxvqyapJaQWgiMPCxeYuhCQA()
				{
					return new tguatejUMQuiYuZRedAYqQbtHOreb(-2);
				}

				[IteratorStateMachine(typeof(jmMQWnlTWWIriVDXrfYHouKcoiVQ))]
				private IEnumerable<ControllerPollingInfo> mTHABciLMNthAGPmTMJYhkQkQaTgB()
				{
					return new jmMQWnlTWWIriVDXrfYHouKcoiVQ(-2);
				}

				[IteratorStateMachine(typeof(aUpkIjBCRbPTeDAWnEWDWgRgADRhA))]
				private IEnumerable<ControllerPollingInfo> cqjzqfQqPlcQhGtHzehrRzylpmGGA()
				{
					return new aUpkIjBCRbPTeDAWnEWDWgRgADRhA(-2);
				}

				[IteratorStateMachine(typeof(RJJKQghcKtcJckwMTsEeVWYCCjMC))]
				private IEnumerable<ControllerPollingInfo> OZUBHHTGDucLzXZZcOylzMXwekNF()
				{
					return new RJJKQghcKtcJckwMTsEeVWYCCjMC(-2);
				}

				private IEnumerable<ControllerPollingInfo> jlhsjrGZGMWIXOwGGFcMKPenUrZN(int P_0)
				{
					CustomController customController = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> MpfBWtcjzLVISfIuVVXmaaQnNmNp(int P_0)
				{
					CustomController customController = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> TgNcVoEcOmNdwaqucDIPOZIMzbahb(int P_0)
				{
					CustomController customController = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> RxAUaCXEcZZgyBruBbOFOsjpNlkp(int P_0)
				{
					CustomController customController = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> OzLekdCDFlTJmSLmrUMUbDQeFdeN(int P_0)
				{
					CustomController customController = KxqrRtEEOCfhhREzEERAgMRcgdrqA.GetCustomController(P_0);
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
				private sealed class vhFgvxVGqMbOFkXysQInVyBWbvDo : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int bbgtJwpziTuwiwchJcotKYglNjpSA;

					private ElementAssignmentConflictInfo XjvGVleEnJgLgkAVxfstsBVdHLPYA;

					private int plVbcVrCvYgWTeNuqqxGarkBvtmQB;

					private int zDRotEZHUeqYkbkQdHdEJJMYyRPs;

					public int hsvtLLQkhHMzvwWjRJiBZAbXAXeGA;

					private ActionElementMap swlInLXcNBDqHSXcVHsVINaHXMhvA;

					public ActionElementMap GQEdWsHVULOQPSpUhAvZpIVtzeuRA;

					private bool RdbGXpFwYyKYIDJjQKHBlyfSlCvn;

					public bool jmndmEDEpOPmDVoDgdyOxryjGRyc;

					private int SdffGYFPuFuLCUYITkiKCFYwCNzX;

					public int UvavcLbtprNgjzdRPJzzwERaBQYr;

					private CustomControllerMap ZTxaTrkmOSTwwrAaKsrpbrLFUANqB;

					public CustomControllerMap yFWkoMDAiAqVlSlFjZKdMsltNdzK;

					private bool wqiECTKucYEJAtYlpGXFdhSJQnKcA;

					public bool xbdAdsfjWZafdKqkcFMKjkLOXxwgb;

					private bool dJpiGDVMLPoVVozyFlBwjfAwCjNw;

					public bool OaSaoWFmnYsssdylfptgEtUoknXaA;

					private IList<Player> jadfSaZAdAmIVrnTWBYPtEzsnMWP;

					private int LvsAxfesvKbBRdNcpILvwEqOkSKCb;

					private IEnumerator<ElementAssignmentConflictInfo> CXZCTNagTiByAPvNliWeQSavpfEZ;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return XjvGVleEnJgLgkAVxfstsBVdHLPYA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return XjvGVleEnJgLgkAVxfstsBVdHLPYA;
						}
					}

					[DebuggerHidden]
					public vhFgvxVGqMbOFkXysQInVyBWbvDo(int P_0)
					{
						bbgtJwpziTuwiwchJcotKYglNjpSA = P_0;
						plVbcVrCvYgWTeNuqqxGarkBvtmQB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = bbgtJwpziTuwiwchJcotKYglNjpSA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								yFigIMLOVDSVKUoCVHWeLljbbifh();
							}
						}
						jadfSaZAdAmIVrnTWBYPtEzsnMWP = null;
						CXZCTNagTiByAPvNliWeQSavpfEZ = null;
						bbgtJwpziTuwiwchJcotKYglNjpSA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = bbgtJwpziTuwiwchJcotKYglNjpSA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								bbgtJwpziTuwiwchJcotKYglNjpSA = -3;
								goto IL_00e2;
							}
							bbgtJwpziTuwiwchJcotKYglNjpSA = -1;
							if (zDRotEZHUeqYkbkQdHdEJJMYyRPs < 0 || swlInLXcNBDqHSXcVHsVINaHXMhvA == null)
							{
								return false;
							}
							jadfSaZAdAmIVrnTWBYPtEzsnMWP = (RdbGXpFwYyKYIDJjQKHBlyfSlCvn ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
							LvsAxfesvKbBRdNcpILvwEqOkSKCb = 0;
							goto IL_010c;
							IL_010c:
							if (LvsAxfesvKbBRdNcpILvwEqOkSKCb < jadfSaZAdAmIVrnTWBYPtEzsnMWP.Count)
							{
								CXZCTNagTiByAPvNliWeQSavpfEZ = jadfSaZAdAmIVrnTWBYPtEzsnMWP[LvsAxfesvKbBRdNcpILvwEqOkSKCb].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, SdffGYFPuFuLCUYITkiKCFYwCNzX, ZTxaTrkmOSTwwrAaKsrpbrLFUANqB, swlInLXcNBDqHSXcVHsVINaHXMhvA, wqiECTKucYEJAtYlpGXFdhSJQnKcA, dJpiGDVMLPoVVozyFlBwjfAwCjNw).GetEnumerator();
								bbgtJwpziTuwiwchJcotKYglNjpSA = -3;
								goto IL_00e2;
							}
							return false;
							IL_00e2:
							if (CXZCTNagTiByAPvNliWeQSavpfEZ.MoveNext())
							{
								ElementAssignmentConflictInfo current = CXZCTNagTiByAPvNliWeQSavpfEZ.Current;
								XjvGVleEnJgLgkAVxfstsBVdHLPYA = current;
								bbgtJwpziTuwiwchJcotKYglNjpSA = 1;
								return true;
							}
							yFigIMLOVDSVKUoCVHWeLljbbifh();
							CXZCTNagTiByAPvNliWeQSavpfEZ = null;
							LvsAxfesvKbBRdNcpILvwEqOkSKCb++;
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

					private void yFigIMLOVDSVKUoCVHWeLljbbifh()
					{
						bbgtJwpziTuwiwchJcotKYglNjpSA = -1;
						if (CXZCTNagTiByAPvNliWeQSavpfEZ != null)
						{
							CXZCTNagTiByAPvNliWeQSavpfEZ.Dispose();
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
						vhFgvxVGqMbOFkXysQInVyBWbvDo vhFgvxVGqMbOFkXysQInVyBWbvDo2;
						if (bbgtJwpziTuwiwchJcotKYglNjpSA == -2 && plVbcVrCvYgWTeNuqqxGarkBvtmQB == Environment.CurrentManagedThreadId)
						{
							bbgtJwpziTuwiwchJcotKYglNjpSA = 0;
							vhFgvxVGqMbOFkXysQInVyBWbvDo2 = this;
						}
						else
						{
							vhFgvxVGqMbOFkXysQInVyBWbvDo2 = new vhFgvxVGqMbOFkXysQInVyBWbvDo(0);
						}
						vhFgvxVGqMbOFkXysQInVyBWbvDo2.zDRotEZHUeqYkbkQdHdEJJMYyRPs = hsvtLLQkhHMzvwWjRJiBZAbXAXeGA;
						vhFgvxVGqMbOFkXysQInVyBWbvDo2.SdffGYFPuFuLCUYITkiKCFYwCNzX = UvavcLbtprNgjzdRPJzzwERaBQYr;
						vhFgvxVGqMbOFkXysQInVyBWbvDo2.ZTxaTrkmOSTwwrAaKsrpbrLFUANqB = yFWkoMDAiAqVlSlFjZKdMsltNdzK;
						vhFgvxVGqMbOFkXysQInVyBWbvDo2.swlInLXcNBDqHSXcVHsVINaHXMhvA = GQEdWsHVULOQPSpUhAvZpIVtzeuRA;
						vhFgvxVGqMbOFkXysQInVyBWbvDo2.wqiECTKucYEJAtYlpGXFdhSJQnKcA = xbdAdsfjWZafdKqkcFMKjkLOXxwgb;
						vhFgvxVGqMbOFkXysQInVyBWbvDo2.dJpiGDVMLPoVVozyFlBwjfAwCjNw = OaSaoWFmnYsssdylfptgEtUoknXaA;
						vhFgvxVGqMbOFkXysQInVyBWbvDo2.RdbGXpFwYyKYIDJjQKHBlyfSlCvn = jmndmEDEpOPmDVoDgdyOxryjGRyc;
						return vhFgvxVGqMbOFkXysQInVyBWbvDo2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class QutEnbkDdtDGZXFmMZwoTnrkCzbt : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int hmJFtLftoGtCzPGctezaOohozApgA;

					private ElementAssignmentConflictInfo rUtNWZlApgwtcsGHtYzzyyCdAEDV;

					private int METESzrkYbdqZmHxgHffCNjsDIjj;

					private ElementAssignmentConflictCheck cPROHrpIiUTgnKRDajJLAqRncZix;

					public ElementAssignmentConflictCheck MPgxLbHxwnRYjqhBSRIYtohJAdJkA;

					private bool NHsmyzqkTPhpwqWQnvEiGPRhbAuR;

					public bool sXWXjiSukCGORaiXXeIygMGwHANBA;

					private bool bmVqWGxuEEWPQsbylDLpHlIThbsOA;

					public bool zIQAMqAYeHbxiMEHdbltpzeboRyPA;

					private bool vNwfDIgNlylObHCmeKKPIJIASnfXd;

					public bool hrUNppbwHuipOCAwffOcxlMhvqlR;

					private IList<Player> GWQeiQMJgWALsIYKYakaGrHAbEFZB;

					private int RXYzzaLlFkuWXDYglfCiQbltuZdp;

					private IEnumerator<ElementAssignmentConflictInfo> MvXVBKJlnpxPkvTRKTkfybTjXTID;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rUtNWZlApgwtcsGHtYzzyyCdAEDV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rUtNWZlApgwtcsGHtYzzyyCdAEDV;
						}
					}

					[DebuggerHidden]
					public QutEnbkDdtDGZXFmMZwoTnrkCzbt(int P_0)
					{
						hmJFtLftoGtCzPGctezaOohozApgA = P_0;
						METESzrkYbdqZmHxgHffCNjsDIjj = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hmJFtLftoGtCzPGctezaOohozApgA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								jqYgsdfxGlEOmmbzYfDQhEzuDOlU();
							}
						}
						GWQeiQMJgWALsIYKYakaGrHAbEFZB = null;
						MvXVBKJlnpxPkvTRKTkfybTjXTID = null;
						hmJFtLftoGtCzPGctezaOohozApgA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = hmJFtLftoGtCzPGctezaOohozApgA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hmJFtLftoGtCzPGctezaOohozApgA = -3;
								goto IL_00df;
							}
							hmJFtLftoGtCzPGctezaOohozApgA = -1;
							if (cPROHrpIiUTgnKRDajJLAqRncZix.playerId < 0 || cPROHrpIiUTgnKRDajJLAqRncZix.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							GWQeiQMJgWALsIYKYakaGrHAbEFZB = (NHsmyzqkTPhpwqWQnvEiGPRhbAuR ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
							RXYzzaLlFkuWXDYglfCiQbltuZdp = 0;
							goto IL_0109;
							IL_0109:
							if (RXYzzaLlFkuWXDYglfCiQbltuZdp < GWQeiQMJgWALsIYKYakaGrHAbEFZB.Count)
							{
								MvXVBKJlnpxPkvTRKTkfybTjXTID = GWQeiQMJgWALsIYKYakaGrHAbEFZB[RXYzzaLlFkuWXDYglfCiQbltuZdp].controllers.conflictChecking.ElementAssignmentConflicts(cPROHrpIiUTgnKRDajJLAqRncZix, bmVqWGxuEEWPQsbylDLpHlIThbsOA, vNwfDIgNlylObHCmeKKPIJIASnfXd).GetEnumerator();
								hmJFtLftoGtCzPGctezaOohozApgA = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (MvXVBKJlnpxPkvTRKTkfybTjXTID.MoveNext())
							{
								ElementAssignmentConflictInfo current = MvXVBKJlnpxPkvTRKTkfybTjXTID.Current;
								rUtNWZlApgwtcsGHtYzzyyCdAEDV = current;
								hmJFtLftoGtCzPGctezaOohozApgA = 1;
								return true;
							}
							jqYgsdfxGlEOmmbzYfDQhEzuDOlU();
							MvXVBKJlnpxPkvTRKTkfybTjXTID = null;
							RXYzzaLlFkuWXDYglfCiQbltuZdp++;
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

					private void jqYgsdfxGlEOmmbzYfDQhEzuDOlU()
					{
						hmJFtLftoGtCzPGctezaOohozApgA = -1;
						if (MvXVBKJlnpxPkvTRKTkfybTjXTID != null)
						{
							MvXVBKJlnpxPkvTRKTkfybTjXTID.Dispose();
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
						QutEnbkDdtDGZXFmMZwoTnrkCzbt qutEnbkDdtDGZXFmMZwoTnrkCzbt;
						if (hmJFtLftoGtCzPGctezaOohozApgA == -2 && METESzrkYbdqZmHxgHffCNjsDIjj == Environment.CurrentManagedThreadId)
						{
							hmJFtLftoGtCzPGctezaOohozApgA = 0;
							qutEnbkDdtDGZXFmMZwoTnrkCzbt = this;
						}
						else
						{
							qutEnbkDdtDGZXFmMZwoTnrkCzbt = new QutEnbkDdtDGZXFmMZwoTnrkCzbt(0);
						}
						qutEnbkDdtDGZXFmMZwoTnrkCzbt.cPROHrpIiUTgnKRDajJLAqRncZix = MPgxLbHxwnRYjqhBSRIYtohJAdJkA;
						qutEnbkDdtDGZXFmMZwoTnrkCzbt.bmVqWGxuEEWPQsbylDLpHlIThbsOA = zIQAMqAYeHbxiMEHdbltpzeboRyPA;
						qutEnbkDdtDGZXFmMZwoTnrkCzbt.vNwfDIgNlylObHCmeKKPIJIASnfXd = hrUNppbwHuipOCAwffOcxlMhvqlR;
						qutEnbkDdtDGZXFmMZwoTnrkCzbt.NHsmyzqkTPhpwqWQnvEiGPRhbAuR = sXWXjiSukCGORaiXXeIygMGwHANBA;
						return qutEnbkDdtDGZXFmMZwoTnrkCzbt;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class oNNOflQxcQhrMgMZNqyeZIeAVdSq : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int PqlSlpSOMjaEDNlvUEucgVgHlNWhA;

					private ElementAssignmentConflictInfo dLSQEQqrFRMttOJwNiuJgBGRcgyB;

					private int icvzCJUDJlTvkcuSbiYtcVAXGFvM;

					private int vPZdKdkTSLwqdOBGWChBSEmBtGlAA;

					public int NVoccTtJEsaFpPHajfhKsXcDQxHN;

					private ActionElementMap yebIHOinwPYbsgPjyZErXeIHslCg;

					public ActionElementMap MHaMCmNkxanqxszqIFoPEkcwBETy;

					private bool fHBrKunqNzArxZSDBLNKZXrihuFk;

					public bool XZjqUQcGInIcBZkDKiUyLrTfHYyO;

					private int FdWxfZsVuBNPcbNhIaiFIuSelpCg;

					public int DnuiFCwvOMWlUCwVEnLpPLubhVTd;

					private JoystickMap jMoGOFgDAOogdoaIoGECnOjWjocpA;

					public JoystickMap KAwwxWIvAQNrscbBgVqQXWkYYBrH;

					private bool CnoXZhvhcNlfDJSQmUxAwcbgAqar;

					public bool ZYtgLnaPzIRNDigmiFEvmzYXWaGh;

					private bool TqfIoQASUDZmfiTCKmbbHyKeDlqL;

					public bool YqGjkOyXsakHHeZPBKscCDQNjxNT;

					private IList<Player> MBRtFXPfxpdNYBHYIBObarYUFDLb;

					private int IIrKQjSGAPezIBvrvaHkQtkQqvIf;

					private IEnumerator<ElementAssignmentConflictInfo> TmiIucsJgNzTlQeJVOvTMbSeUgyO;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return dLSQEQqrFRMttOJwNiuJgBGRcgyB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dLSQEQqrFRMttOJwNiuJgBGRcgyB;
						}
					}

					[DebuggerHidden]
					public oNNOflQxcQhrMgMZNqyeZIeAVdSq(int P_0)
					{
						PqlSlpSOMjaEDNlvUEucgVgHlNWhA = P_0;
						icvzCJUDJlTvkcuSbiYtcVAXGFvM = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int pqlSlpSOMjaEDNlvUEucgVgHlNWhA = PqlSlpSOMjaEDNlvUEucgVgHlNWhA;
						if (pqlSlpSOMjaEDNlvUEucgVgHlNWhA == -3 || pqlSlpSOMjaEDNlvUEucgVgHlNWhA == 1)
						{
							try
							{
							}
							finally
							{
								MXhjuFPVDBwibKHYHYcLQRevUfiR();
							}
						}
						MBRtFXPfxpdNYBHYIBObarYUFDLb = null;
						TmiIucsJgNzTlQeJVOvTMbSeUgyO = null;
						PqlSlpSOMjaEDNlvUEucgVgHlNWhA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int pqlSlpSOMjaEDNlvUEucgVgHlNWhA = PqlSlpSOMjaEDNlvUEucgVgHlNWhA;
							if (pqlSlpSOMjaEDNlvUEucgVgHlNWhA != 0)
							{
								if (pqlSlpSOMjaEDNlvUEucgVgHlNWhA != 1)
								{
									return false;
								}
								PqlSlpSOMjaEDNlvUEucgVgHlNWhA = -3;
								goto IL_00e1;
							}
							PqlSlpSOMjaEDNlvUEucgVgHlNWhA = -1;
							if (vPZdKdkTSLwqdOBGWChBSEmBtGlAA < 0 || yebIHOinwPYbsgPjyZErXeIHslCg == null)
							{
								return false;
							}
							MBRtFXPfxpdNYBHYIBObarYUFDLb = (fHBrKunqNzArxZSDBLNKZXrihuFk ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
							IIrKQjSGAPezIBvrvaHkQtkQqvIf = 0;
							goto IL_010b;
							IL_010b:
							if (IIrKQjSGAPezIBvrvaHkQtkQqvIf < MBRtFXPfxpdNYBHYIBObarYUFDLb.Count)
							{
								TmiIucsJgNzTlQeJVOvTMbSeUgyO = MBRtFXPfxpdNYBHYIBObarYUFDLb[IIrKQjSGAPezIBvrvaHkQtkQqvIf].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, FdWxfZsVuBNPcbNhIaiFIuSelpCg, jMoGOFgDAOogdoaIoGECnOjWjocpA, yebIHOinwPYbsgPjyZErXeIHslCg, CnoXZhvhcNlfDJSQmUxAwcbgAqar, TqfIoQASUDZmfiTCKmbbHyKeDlqL).GetEnumerator();
								PqlSlpSOMjaEDNlvUEucgVgHlNWhA = -3;
								goto IL_00e1;
							}
							return false;
							IL_00e1:
							if (TmiIucsJgNzTlQeJVOvTMbSeUgyO.MoveNext())
							{
								ElementAssignmentConflictInfo current = TmiIucsJgNzTlQeJVOvTMbSeUgyO.Current;
								dLSQEQqrFRMttOJwNiuJgBGRcgyB = current;
								PqlSlpSOMjaEDNlvUEucgVgHlNWhA = 1;
								return true;
							}
							MXhjuFPVDBwibKHYHYcLQRevUfiR();
							TmiIucsJgNzTlQeJVOvTMbSeUgyO = null;
							IIrKQjSGAPezIBvrvaHkQtkQqvIf++;
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

					private void MXhjuFPVDBwibKHYHYcLQRevUfiR()
					{
						PqlSlpSOMjaEDNlvUEucgVgHlNWhA = -1;
						if (TmiIucsJgNzTlQeJVOvTMbSeUgyO != null)
						{
							TmiIucsJgNzTlQeJVOvTMbSeUgyO.Dispose();
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
						oNNOflQxcQhrMgMZNqyeZIeAVdSq oNNOflQxcQhrMgMZNqyeZIeAVdSq2;
						if (PqlSlpSOMjaEDNlvUEucgVgHlNWhA == -2 && icvzCJUDJlTvkcuSbiYtcVAXGFvM == Environment.CurrentManagedThreadId)
						{
							PqlSlpSOMjaEDNlvUEucgVgHlNWhA = 0;
							oNNOflQxcQhrMgMZNqyeZIeAVdSq2 = this;
						}
						else
						{
							oNNOflQxcQhrMgMZNqyeZIeAVdSq2 = new oNNOflQxcQhrMgMZNqyeZIeAVdSq(0);
						}
						oNNOflQxcQhrMgMZNqyeZIeAVdSq2.vPZdKdkTSLwqdOBGWChBSEmBtGlAA = NVoccTtJEsaFpPHajfhKsXcDQxHN;
						oNNOflQxcQhrMgMZNqyeZIeAVdSq2.FdWxfZsVuBNPcbNhIaiFIuSelpCg = DnuiFCwvOMWlUCwVEnLpPLubhVTd;
						oNNOflQxcQhrMgMZNqyeZIeAVdSq2.jMoGOFgDAOogdoaIoGECnOjWjocpA = KAwwxWIvAQNrscbBgVqQXWkYYBrH;
						oNNOflQxcQhrMgMZNqyeZIeAVdSq2.yebIHOinwPYbsgPjyZErXeIHslCg = MHaMCmNkxanqxszqIFoPEkcwBETy;
						oNNOflQxcQhrMgMZNqyeZIeAVdSq2.CnoXZhvhcNlfDJSQmUxAwcbgAqar = ZYtgLnaPzIRNDigmiFEvmzYXWaGh;
						oNNOflQxcQhrMgMZNqyeZIeAVdSq2.TqfIoQASUDZmfiTCKmbbHyKeDlqL = YqGjkOyXsakHHeZPBKscCDQNjxNT;
						oNNOflQxcQhrMgMZNqyeZIeAVdSq2.fHBrKunqNzArxZSDBLNKZXrihuFk = XZjqUQcGInIcBZkDKiUyLrTfHYyO;
						return oNNOflQxcQhrMgMZNqyeZIeAVdSq2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class ZbRAWSTmzbGsWuPmREVRvwogwGY : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int BfvbMgHoHpMzRxiJkMYQbLXPueru;

					private ElementAssignmentConflictInfo RdbavHGhEKvmtEMhonvaapRokHuY;

					private int HwKEFhgZsKJLgjVgSGZsGWbDMjebB;

					private ElementAssignmentConflictCheck zPVuIghzFukzqteueFqcrbMDEzndA;

					public ElementAssignmentConflictCheck TXbmokHiNfSdofWUrFEiwXjOlMXr;

					private bool FKUXidQODyWdsBNKZcbzCvfCvSBl;

					public bool nlcEHhDztUmihSjkmzAJoLDrNnRH;

					private bool IGWwGNrlTMEYyXLkeSSHrgqFVwpB;

					public bool RSlWsvwmofNUxkcjLfIdDzxdysbr;

					private bool IfFEYbpzzfHAyHHvmblUxNoWFJcHA;

					public bool aCPHFrekFoNrVGBUeRwycUvWIyLGA;

					private IList<Player> zqlQkXQGmWzAQruaFhUIrCjdPoLX;

					private int qkIFUqxSbRzPIpDJuQvlGWRJWyYm;

					private IEnumerator<ElementAssignmentConflictInfo> fHggfAuOORqMkenLFkRZQBieoWvI;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return RdbavHGhEKvmtEMhonvaapRokHuY;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return RdbavHGhEKvmtEMhonvaapRokHuY;
						}
					}

					[DebuggerHidden]
					public ZbRAWSTmzbGsWuPmREVRvwogwGY(int P_0)
					{
						BfvbMgHoHpMzRxiJkMYQbLXPueru = P_0;
						HwKEFhgZsKJLgjVgSGZsGWbDMjebB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int bfvbMgHoHpMzRxiJkMYQbLXPueru = BfvbMgHoHpMzRxiJkMYQbLXPueru;
						if (bfvbMgHoHpMzRxiJkMYQbLXPueru == -3 || bfvbMgHoHpMzRxiJkMYQbLXPueru == 1)
						{
							try
							{
							}
							finally
							{
								KRunbiQhlffJCOcqVwethxBGxAgs();
							}
						}
						zqlQkXQGmWzAQruaFhUIrCjdPoLX = null;
						fHggfAuOORqMkenLFkRZQBieoWvI = null;
						BfvbMgHoHpMzRxiJkMYQbLXPueru = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int bfvbMgHoHpMzRxiJkMYQbLXPueru = BfvbMgHoHpMzRxiJkMYQbLXPueru;
							if (bfvbMgHoHpMzRxiJkMYQbLXPueru != 0)
							{
								if (bfvbMgHoHpMzRxiJkMYQbLXPueru != 1)
								{
									return false;
								}
								BfvbMgHoHpMzRxiJkMYQbLXPueru = -3;
								goto IL_00df;
							}
							BfvbMgHoHpMzRxiJkMYQbLXPueru = -1;
							if (zPVuIghzFukzqteueFqcrbMDEzndA.playerId < 0 || zPVuIghzFukzqteueFqcrbMDEzndA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							zqlQkXQGmWzAQruaFhUIrCjdPoLX = (FKUXidQODyWdsBNKZcbzCvfCvSBl ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
							qkIFUqxSbRzPIpDJuQvlGWRJWyYm = 0;
							goto IL_0109;
							IL_0109:
							if (qkIFUqxSbRzPIpDJuQvlGWRJWyYm < zqlQkXQGmWzAQruaFhUIrCjdPoLX.Count)
							{
								fHggfAuOORqMkenLFkRZQBieoWvI = zqlQkXQGmWzAQruaFhUIrCjdPoLX[qkIFUqxSbRzPIpDJuQvlGWRJWyYm].controllers.conflictChecking.ElementAssignmentConflicts(zPVuIghzFukzqteueFqcrbMDEzndA, IGWwGNrlTMEYyXLkeSSHrgqFVwpB, IfFEYbpzzfHAyHHvmblUxNoWFJcHA).GetEnumerator();
								BfvbMgHoHpMzRxiJkMYQbLXPueru = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (fHggfAuOORqMkenLFkRZQBieoWvI.MoveNext())
							{
								ElementAssignmentConflictInfo current = fHggfAuOORqMkenLFkRZQBieoWvI.Current;
								RdbavHGhEKvmtEMhonvaapRokHuY = current;
								BfvbMgHoHpMzRxiJkMYQbLXPueru = 1;
								return true;
							}
							KRunbiQhlffJCOcqVwethxBGxAgs();
							fHggfAuOORqMkenLFkRZQBieoWvI = null;
							qkIFUqxSbRzPIpDJuQvlGWRJWyYm++;
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

					private void KRunbiQhlffJCOcqVwethxBGxAgs()
					{
						BfvbMgHoHpMzRxiJkMYQbLXPueru = -1;
						if (fHggfAuOORqMkenLFkRZQBieoWvI != null)
						{
							fHggfAuOORqMkenLFkRZQBieoWvI.Dispose();
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
						ZbRAWSTmzbGsWuPmREVRvwogwGY zbRAWSTmzbGsWuPmREVRvwogwGY;
						if (BfvbMgHoHpMzRxiJkMYQbLXPueru == -2 && HwKEFhgZsKJLgjVgSGZsGWbDMjebB == Environment.CurrentManagedThreadId)
						{
							BfvbMgHoHpMzRxiJkMYQbLXPueru = 0;
							zbRAWSTmzbGsWuPmREVRvwogwGY = this;
						}
						else
						{
							zbRAWSTmzbGsWuPmREVRvwogwGY = new ZbRAWSTmzbGsWuPmREVRvwogwGY(0);
						}
						zbRAWSTmzbGsWuPmREVRvwogwGY.zPVuIghzFukzqteueFqcrbMDEzndA = TXbmokHiNfSdofWUrFEiwXjOlMXr;
						zbRAWSTmzbGsWuPmREVRvwogwGY.IGWwGNrlTMEYyXLkeSSHrgqFVwpB = RSlWsvwmofNUxkcjLfIdDzxdysbr;
						zbRAWSTmzbGsWuPmREVRvwogwGY.IfFEYbpzzfHAyHHvmblUxNoWFJcHA = aCPHFrekFoNrVGBUeRwycUvWIyLGA;
						zbRAWSTmzbGsWuPmREVRvwogwGY.FKUXidQODyWdsBNKZcbzCvfCvSBl = nlcEHhDztUmihSjkmzAJoLDrNnRH;
						return zbRAWSTmzbGsWuPmREVRvwogwGY;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class OyfJEbgZWvwulYvspsLQyoWEHZNE : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int pJhqnLsKiefQjgTmgcxykDgnkUiWA;

					private ElementAssignmentConflictInfo sROtpSiikLnFtojgckfJyUPsuffy;

					private int SLbGVLbJIcqpFFRQynTBJqWbVQwlA;

					private int dHKWUbCpFvyCryGDpBsVXYFAsObu;

					public int XVimrWUMmVzugDqbBvKAfaMwFSdfA;

					private ActionElementMap nRyJrWGvvXsVhZkZVCmiNgWrevCGA;

					public ActionElementMap kKGTwzQjKlUUuyEnruFYmVulszNE;

					private bool OfZtWQTljihfbuQtslTEIdoVbyEM;

					public bool elklPPupgehISJDOIdDKFqhftbHIb;

					private KeyboardMap sFIoLUIyZzwPVGCkxSSqQTGniCim;

					public KeyboardMap EWjNEMQfUgDSZGQbkqpYsmBplMWEb;

					private bool PzUzFyXoMZxXWzehTBXCGrRtnHgh;

					public bool XWiCZPbBycptcLuNJjvnfefbZpdvb;

					private bool kwjTfoEIsWiqbEJOlJHTLbgNJnIP;

					public bool FuBUJkAfZoFsjbjBCBYnmptooitcA;

					private IList<Player> NhEAyDimJWftmLhozQKyGOHHAfdIA;

					private int zBITNlTPWXOUPNozHQEqwmzAFjAw;

					private IEnumerator<ElementAssignmentConflictInfo> QwVYTnMPzPDzTtCdqSCgcoFAcUhe;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return sROtpSiikLnFtojgckfJyUPsuffy;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sROtpSiikLnFtojgckfJyUPsuffy;
						}
					}

					[DebuggerHidden]
					public OyfJEbgZWvwulYvspsLQyoWEHZNE(int P_0)
					{
						pJhqnLsKiefQjgTmgcxykDgnkUiWA = P_0;
						SLbGVLbJIcqpFFRQynTBJqWbVQwlA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pJhqnLsKiefQjgTmgcxykDgnkUiWA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								wdZMPrJLrYsbCQgjWxLPUvxwgQyr();
							}
						}
						NhEAyDimJWftmLhozQKyGOHHAfdIA = null;
						QwVYTnMPzPDzTtCdqSCgcoFAcUhe = null;
						pJhqnLsKiefQjgTmgcxykDgnkUiWA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pJhqnLsKiefQjgTmgcxykDgnkUiWA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pJhqnLsKiefQjgTmgcxykDgnkUiWA = -3;
								goto IL_00dc;
							}
							pJhqnLsKiefQjgTmgcxykDgnkUiWA = -1;
							if (dHKWUbCpFvyCryGDpBsVXYFAsObu < 0 || nRyJrWGvvXsVhZkZVCmiNgWrevCGA == null)
							{
								return false;
							}
							NhEAyDimJWftmLhozQKyGOHHAfdIA = (OfZtWQTljihfbuQtslTEIdoVbyEM ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
							zBITNlTPWXOUPNozHQEqwmzAFjAw = 0;
							goto IL_0106;
							IL_0106:
							if (zBITNlTPWXOUPNozHQEqwmzAFjAw < NhEAyDimJWftmLhozQKyGOHHAfdIA.Count)
							{
								QwVYTnMPzPDzTtCdqSCgcoFAcUhe = NhEAyDimJWftmLhozQKyGOHHAfdIA[zBITNlTPWXOUPNozHQEqwmzAFjAw].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, sFIoLUIyZzwPVGCkxSSqQTGniCim, nRyJrWGvvXsVhZkZVCmiNgWrevCGA, PzUzFyXoMZxXWzehTBXCGrRtnHgh, kwjTfoEIsWiqbEJOlJHTLbgNJnIP).GetEnumerator();
								pJhqnLsKiefQjgTmgcxykDgnkUiWA = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (QwVYTnMPzPDzTtCdqSCgcoFAcUhe.MoveNext())
							{
								ElementAssignmentConflictInfo current = QwVYTnMPzPDzTtCdqSCgcoFAcUhe.Current;
								sROtpSiikLnFtojgckfJyUPsuffy = current;
								pJhqnLsKiefQjgTmgcxykDgnkUiWA = 1;
								return true;
							}
							wdZMPrJLrYsbCQgjWxLPUvxwgQyr();
							QwVYTnMPzPDzTtCdqSCgcoFAcUhe = null;
							zBITNlTPWXOUPNozHQEqwmzAFjAw++;
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

					private void wdZMPrJLrYsbCQgjWxLPUvxwgQyr()
					{
						pJhqnLsKiefQjgTmgcxykDgnkUiWA = -1;
						if (QwVYTnMPzPDzTtCdqSCgcoFAcUhe != null)
						{
							QwVYTnMPzPDzTtCdqSCgcoFAcUhe.Dispose();
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
						OyfJEbgZWvwulYvspsLQyoWEHZNE oyfJEbgZWvwulYvspsLQyoWEHZNE;
						if (pJhqnLsKiefQjgTmgcxykDgnkUiWA == -2 && SLbGVLbJIcqpFFRQynTBJqWbVQwlA == Environment.CurrentManagedThreadId)
						{
							pJhqnLsKiefQjgTmgcxykDgnkUiWA = 0;
							oyfJEbgZWvwulYvspsLQyoWEHZNE = this;
						}
						else
						{
							oyfJEbgZWvwulYvspsLQyoWEHZNE = new OyfJEbgZWvwulYvspsLQyoWEHZNE(0);
						}
						oyfJEbgZWvwulYvspsLQyoWEHZNE.dHKWUbCpFvyCryGDpBsVXYFAsObu = XVimrWUMmVzugDqbBvKAfaMwFSdfA;
						oyfJEbgZWvwulYvspsLQyoWEHZNE.sFIoLUIyZzwPVGCkxSSqQTGniCim = EWjNEMQfUgDSZGQbkqpYsmBplMWEb;
						oyfJEbgZWvwulYvspsLQyoWEHZNE.nRyJrWGvvXsVhZkZVCmiNgWrevCGA = kKGTwzQjKlUUuyEnruFYmVulszNE;
						oyfJEbgZWvwulYvspsLQyoWEHZNE.PzUzFyXoMZxXWzehTBXCGrRtnHgh = XWiCZPbBycptcLuNJjvnfefbZpdvb;
						oyfJEbgZWvwulYvspsLQyoWEHZNE.kwjTfoEIsWiqbEJOlJHTLbgNJnIP = FuBUJkAfZoFsjbjBCBYnmptooitcA;
						oyfJEbgZWvwulYvspsLQyoWEHZNE.OfZtWQTljihfbuQtslTEIdoVbyEM = elklPPupgehISJDOIdDKFqhftbHIb;
						return oyfJEbgZWvwulYvspsLQyoWEHZNE;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class bIZANFDsUdjBjvJchprzLMUBoKfB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int dOUhSImHSiAgmzDijVKJTQCIwPoX;

					private ElementAssignmentConflictInfo nTsKEIQAwDwFmdpNUgDLVZGFtACq;

					private int HHPTMIUwcYvpxHxvoOQknJYsiFud;

					private ElementAssignmentConflictCheck CbEblQOFWyAbTJvwcbkHAiyneASb;

					public ElementAssignmentConflictCheck mlXckbaZvfUgmNXmhVAAaHtifBuuA;

					private bool bCMcWrzNLqxNMXmDPFioguQckYPfb;

					public bool yCYEFNywmZGRIPELJbpWPGeDoroC;

					private bool sAKsQOlmnfrWPQMRgEifvJbOjJbO;

					public bool iRkIUhTvvYDxjuWqgoBwOPTtGfhX;

					private bool znheKpKJAQBbadYpycfFNDZceQwjA;

					public bool KDjxglesPUFtZlebeidlsjhxXqCB;

					private IList<Player> WYPYqzabfdaVTFIojLImuuZQptnL;

					private int lrNeEzJPbjqSQirZODCpWUZsFvqWA;

					private IEnumerator<ElementAssignmentConflictInfo> DyhcbigkEtdycxULOMqwfDaZXMNU;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return nTsKEIQAwDwFmdpNUgDLVZGFtACq;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return nTsKEIQAwDwFmdpNUgDLVZGFtACq;
						}
					}

					[DebuggerHidden]
					public bIZANFDsUdjBjvJchprzLMUBoKfB(int P_0)
					{
						dOUhSImHSiAgmzDijVKJTQCIwPoX = P_0;
						HHPTMIUwcYvpxHxvoOQknJYsiFud = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = dOUhSImHSiAgmzDijVKJTQCIwPoX;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								oOYcLpilUVnSDUjEQwRtdQRaaJQF();
							}
						}
						WYPYqzabfdaVTFIojLImuuZQptnL = null;
						DyhcbigkEtdycxULOMqwfDaZXMNU = null;
						dOUhSImHSiAgmzDijVKJTQCIwPoX = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = dOUhSImHSiAgmzDijVKJTQCIwPoX;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								dOUhSImHSiAgmzDijVKJTQCIwPoX = -3;
								goto IL_00df;
							}
							dOUhSImHSiAgmzDijVKJTQCIwPoX = -1;
							if (CbEblQOFWyAbTJvwcbkHAiyneASb.playerId < 0 || CbEblQOFWyAbTJvwcbkHAiyneASb.elementAssignmentType != ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							WYPYqzabfdaVTFIojLImuuZQptnL = (bCMcWrzNLqxNMXmDPFioguQckYPfb ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
							lrNeEzJPbjqSQirZODCpWUZsFvqWA = 0;
							goto IL_0109;
							IL_0109:
							if (lrNeEzJPbjqSQirZODCpWUZsFvqWA < WYPYqzabfdaVTFIojLImuuZQptnL.Count)
							{
								DyhcbigkEtdycxULOMqwfDaZXMNU = WYPYqzabfdaVTFIojLImuuZQptnL[lrNeEzJPbjqSQirZODCpWUZsFvqWA].controllers.conflictChecking.ElementAssignmentConflicts(CbEblQOFWyAbTJvwcbkHAiyneASb, sAKsQOlmnfrWPQMRgEifvJbOjJbO, znheKpKJAQBbadYpycfFNDZceQwjA).GetEnumerator();
								dOUhSImHSiAgmzDijVKJTQCIwPoX = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (DyhcbigkEtdycxULOMqwfDaZXMNU.MoveNext())
							{
								ElementAssignmentConflictInfo current = DyhcbigkEtdycxULOMqwfDaZXMNU.Current;
								nTsKEIQAwDwFmdpNUgDLVZGFtACq = current;
								dOUhSImHSiAgmzDijVKJTQCIwPoX = 1;
								return true;
							}
							oOYcLpilUVnSDUjEQwRtdQRaaJQF();
							DyhcbigkEtdycxULOMqwfDaZXMNU = null;
							lrNeEzJPbjqSQirZODCpWUZsFvqWA++;
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

					private void oOYcLpilUVnSDUjEQwRtdQRaaJQF()
					{
						dOUhSImHSiAgmzDijVKJTQCIwPoX = -1;
						if (DyhcbigkEtdycxULOMqwfDaZXMNU != null)
						{
							DyhcbigkEtdycxULOMqwfDaZXMNU.Dispose();
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
						bIZANFDsUdjBjvJchprzLMUBoKfB bIZANFDsUdjBjvJchprzLMUBoKfB2;
						if (dOUhSImHSiAgmzDijVKJTQCIwPoX == -2 && HHPTMIUwcYvpxHxvoOQknJYsiFud == Environment.CurrentManagedThreadId)
						{
							dOUhSImHSiAgmzDijVKJTQCIwPoX = 0;
							bIZANFDsUdjBjvJchprzLMUBoKfB2 = this;
						}
						else
						{
							bIZANFDsUdjBjvJchprzLMUBoKfB2 = new bIZANFDsUdjBjvJchprzLMUBoKfB(0);
						}
						bIZANFDsUdjBjvJchprzLMUBoKfB2.CbEblQOFWyAbTJvwcbkHAiyneASb = mlXckbaZvfUgmNXmhVAAaHtifBuuA;
						bIZANFDsUdjBjvJchprzLMUBoKfB2.sAKsQOlmnfrWPQMRgEifvJbOjJbO = iRkIUhTvvYDxjuWqgoBwOPTtGfhX;
						bIZANFDsUdjBjvJchprzLMUBoKfB2.znheKpKJAQBbadYpycfFNDZceQwjA = KDjxglesPUFtZlebeidlsjhxXqCB;
						bIZANFDsUdjBjvJchprzLMUBoKfB2.bCMcWrzNLqxNMXmDPFioguQckYPfb = yCYEFNywmZGRIPELJbpWPGeDoroC;
						return bIZANFDsUdjBjvJchprzLMUBoKfB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class kkOLtPqWvddTLyAzuuQXtdHotKpv : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int VTgzCEjkzlcpxRxiKfIhlumXbJkY;

					private ElementAssignmentConflictInfo qJrZyDFdYdSAinLjgNqUbKnwNJhs;

					private int irskRChPTePyKrTdqetZPuSqlobl;

					private int UNmpoDbErWLtjTUrFxVhbgfZEmTG;

					public int yYwiaQneJJyzewWOHSHeBqWTOKYC;

					private ActionElementMap VHRWGXmQcDqbKFdPTNlMLfMnCOtN;

					public ActionElementMap PdvXOCXvhlGcKeBWZMcOCcVjcqwy;

					private bool tMifCnkPfdsBLDVmljlTRBokjYqr;

					public bool bFDfpPtLjeDEqiRlVrjAgFFyZqYCA;

					private MouseMap oHnsbrcVgiFzzhVGZjMixJEraRqHA;

					public MouseMap ZxThyPNRiiDLFwojkCcTswAScnwR;

					private bool cLmsPXqBjhYwXcckeEYAoDtBQwEb;

					public bool gqXfJBJWyNQsdmeOHoRcemfIkitLA;

					private bool dgKbHQueMIjaWdUwbMVYAOKrznZg;

					public bool OzjmCAZrORuQmVVChLGiWscRbvtW;

					private IList<Player> wnsfccYdTvljDpghGLHeWCcBSCOc;

					private int EoqJoXPBRecnYoaHvAoHQqSaYDHm;

					private IEnumerator<ElementAssignmentConflictInfo> PEENXVDVexIxLnEYrINDzqqGRXMf;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return qJrZyDFdYdSAinLjgNqUbKnwNJhs;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qJrZyDFdYdSAinLjgNqUbKnwNJhs;
						}
					}

					[DebuggerHidden]
					public kkOLtPqWvddTLyAzuuQXtdHotKpv(int P_0)
					{
						VTgzCEjkzlcpxRxiKfIhlumXbJkY = P_0;
						irskRChPTePyKrTdqetZPuSqlobl = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int vTgzCEjkzlcpxRxiKfIhlumXbJkY = VTgzCEjkzlcpxRxiKfIhlumXbJkY;
						if (vTgzCEjkzlcpxRxiKfIhlumXbJkY == -3 || vTgzCEjkzlcpxRxiKfIhlumXbJkY == 1)
						{
							try
							{
							}
							finally
							{
								FOnbBskuOgsCaNImlafTXbYrBWSdb();
							}
						}
						wnsfccYdTvljDpghGLHeWCcBSCOc = null;
						PEENXVDVexIxLnEYrINDzqqGRXMf = null;
						VTgzCEjkzlcpxRxiKfIhlumXbJkY = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int vTgzCEjkzlcpxRxiKfIhlumXbJkY = VTgzCEjkzlcpxRxiKfIhlumXbJkY;
							if (vTgzCEjkzlcpxRxiKfIhlumXbJkY != 0)
							{
								if (vTgzCEjkzlcpxRxiKfIhlumXbJkY != 1)
								{
									return false;
								}
								VTgzCEjkzlcpxRxiKfIhlumXbJkY = -3;
								goto IL_00dc;
							}
							VTgzCEjkzlcpxRxiKfIhlumXbJkY = -1;
							if (UNmpoDbErWLtjTUrFxVhbgfZEmTG < 0 || VHRWGXmQcDqbKFdPTNlMLfMnCOtN == null)
							{
								return false;
							}
							wnsfccYdTvljDpghGLHeWCcBSCOc = (tMifCnkPfdsBLDVmljlTRBokjYqr ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
							EoqJoXPBRecnYoaHvAoHQqSaYDHm = 0;
							goto IL_0106;
							IL_0106:
							if (EoqJoXPBRecnYoaHvAoHQqSaYDHm < wnsfccYdTvljDpghGLHeWCcBSCOc.Count)
							{
								PEENXVDVexIxLnEYrINDzqqGRXMf = wnsfccYdTvljDpghGLHeWCcBSCOc[EoqJoXPBRecnYoaHvAoHQqSaYDHm].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, oHnsbrcVgiFzzhVGZjMixJEraRqHA, VHRWGXmQcDqbKFdPTNlMLfMnCOtN, cLmsPXqBjhYwXcckeEYAoDtBQwEb, dgKbHQueMIjaWdUwbMVYAOKrznZg).GetEnumerator();
								VTgzCEjkzlcpxRxiKfIhlumXbJkY = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (PEENXVDVexIxLnEYrINDzqqGRXMf.MoveNext())
							{
								ElementAssignmentConflictInfo current = PEENXVDVexIxLnEYrINDzqqGRXMf.Current;
								qJrZyDFdYdSAinLjgNqUbKnwNJhs = current;
								VTgzCEjkzlcpxRxiKfIhlumXbJkY = 1;
								return true;
							}
							FOnbBskuOgsCaNImlafTXbYrBWSdb();
							PEENXVDVexIxLnEYrINDzqqGRXMf = null;
							EoqJoXPBRecnYoaHvAoHQqSaYDHm++;
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

					private void FOnbBskuOgsCaNImlafTXbYrBWSdb()
					{
						VTgzCEjkzlcpxRxiKfIhlumXbJkY = -1;
						if (PEENXVDVexIxLnEYrINDzqqGRXMf != null)
						{
							PEENXVDVexIxLnEYrINDzqqGRXMf.Dispose();
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
						kkOLtPqWvddTLyAzuuQXtdHotKpv kkOLtPqWvddTLyAzuuQXtdHotKpv2;
						if (VTgzCEjkzlcpxRxiKfIhlumXbJkY == -2 && irskRChPTePyKrTdqetZPuSqlobl == Environment.CurrentManagedThreadId)
						{
							VTgzCEjkzlcpxRxiKfIhlumXbJkY = 0;
							kkOLtPqWvddTLyAzuuQXtdHotKpv2 = this;
						}
						else
						{
							kkOLtPqWvddTLyAzuuQXtdHotKpv2 = new kkOLtPqWvddTLyAzuuQXtdHotKpv(0);
						}
						kkOLtPqWvddTLyAzuuQXtdHotKpv2.UNmpoDbErWLtjTUrFxVhbgfZEmTG = yYwiaQneJJyzewWOHSHeBqWTOKYC;
						kkOLtPqWvddTLyAzuuQXtdHotKpv2.oHnsbrcVgiFzzhVGZjMixJEraRqHA = ZxThyPNRiiDLFwojkCcTswAScnwR;
						kkOLtPqWvddTLyAzuuQXtdHotKpv2.VHRWGXmQcDqbKFdPTNlMLfMnCOtN = PdvXOCXvhlGcKeBWZMcOCcVjcqwy;
						kkOLtPqWvddTLyAzuuQXtdHotKpv2.cLmsPXqBjhYwXcckeEYAoDtBQwEb = gqXfJBJWyNQsdmeOHoRcemfIkitLA;
						kkOLtPqWvddTLyAzuuQXtdHotKpv2.dgKbHQueMIjaWdUwbMVYAOKrznZg = OzjmCAZrORuQmVVChLGiWscRbvtW;
						kkOLtPqWvddTLyAzuuQXtdHotKpv2.tMifCnkPfdsBLDVmljlTRBokjYqr = bFDfpPtLjeDEqiRlVrjAgFFyZqYCA;
						return kkOLtPqWvddTLyAzuuQXtdHotKpv2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class VxmGoMSlPVltYHzpgLtHytGFeJOv : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int HRAxIdaORnXbTNclBqcXPFXvFqkq;

					private ElementAssignmentConflictInfo XwHdVmbMEQDJmInbapyIAKmmWMduB;

					private int XkyogzkUUrEViDticGZHUWLobfGE;

					private ElementAssignmentConflictCheck aeiISEvOhrRbqVwqbLWdUisJViVL;

					public ElementAssignmentConflictCheck ltNmgQMljWVnCkYKwdfIKFIprCBr;

					private bool dqALHKrXQsvwSBgFhkaNXZbvrfCf;

					public bool XLeQXvvhVjjAAOpAkKWosBmVOtYb;

					private bool trZeSYxFowBvmYlgoICfJcRbhTwc;

					public bool jdcjwhEyZUuaINrTTSwJuPFzvjFb;

					private bool TrIigHEaBvdSGZMtkXqAROpkZAKe;

					public bool BovalUnWLvrmNnhsrHrBWCzuDJkkA;

					private IList<Player> SbQNgEWMpEdpeuoYdZhlreznnZjV;

					private int rSEAUjpfsXxIVmhQqxWYInsDpJul;

					private IEnumerator<ElementAssignmentConflictInfo> UYbCmZrMUzoofWAlMWVplOHLJSRO;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return XwHdVmbMEQDJmInbapyIAKmmWMduB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return XwHdVmbMEQDJmInbapyIAKmmWMduB;
						}
					}

					[DebuggerHidden]
					public VxmGoMSlPVltYHzpgLtHytGFeJOv(int P_0)
					{
						HRAxIdaORnXbTNclBqcXPFXvFqkq = P_0;
						XkyogzkUUrEViDticGZHUWLobfGE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hRAxIdaORnXbTNclBqcXPFXvFqkq = HRAxIdaORnXbTNclBqcXPFXvFqkq;
						if (hRAxIdaORnXbTNclBqcXPFXvFqkq == -3 || hRAxIdaORnXbTNclBqcXPFXvFqkq == 1)
						{
							try
							{
							}
							finally
							{
								SVUuvoEeLXWDArITFFbyZUWJClKFA();
							}
						}
						SbQNgEWMpEdpeuoYdZhlreznnZjV = null;
						UYbCmZrMUzoofWAlMWVplOHLJSRO = null;
						HRAxIdaORnXbTNclBqcXPFXvFqkq = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int hRAxIdaORnXbTNclBqcXPFXvFqkq = HRAxIdaORnXbTNclBqcXPFXvFqkq;
							if (hRAxIdaORnXbTNclBqcXPFXvFqkq != 0)
							{
								if (hRAxIdaORnXbTNclBqcXPFXvFqkq != 1)
								{
									return false;
								}
								HRAxIdaORnXbTNclBqcXPFXvFqkq = -3;
								goto IL_00df;
							}
							HRAxIdaORnXbTNclBqcXPFXvFqkq = -1;
							if (aeiISEvOhrRbqVwqbLWdUisJViVL.playerId < 0 || aeiISEvOhrRbqVwqbLWdUisJViVL.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							SbQNgEWMpEdpeuoYdZhlreznnZjV = (dqALHKrXQsvwSBgFhkaNXZbvrfCf ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
							rSEAUjpfsXxIVmhQqxWYInsDpJul = 0;
							goto IL_0109;
							IL_0109:
							if (rSEAUjpfsXxIVmhQqxWYInsDpJul < SbQNgEWMpEdpeuoYdZhlreznnZjV.Count)
							{
								UYbCmZrMUzoofWAlMWVplOHLJSRO = SbQNgEWMpEdpeuoYdZhlreznnZjV[rSEAUjpfsXxIVmhQqxWYInsDpJul].controllers.conflictChecking.ElementAssignmentConflicts(aeiISEvOhrRbqVwqbLWdUisJViVL, trZeSYxFowBvmYlgoICfJcRbhTwc, TrIigHEaBvdSGZMtkXqAROpkZAKe).GetEnumerator();
								HRAxIdaORnXbTNclBqcXPFXvFqkq = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (UYbCmZrMUzoofWAlMWVplOHLJSRO.MoveNext())
							{
								ElementAssignmentConflictInfo current = UYbCmZrMUzoofWAlMWVplOHLJSRO.Current;
								XwHdVmbMEQDJmInbapyIAKmmWMduB = current;
								HRAxIdaORnXbTNclBqcXPFXvFqkq = 1;
								return true;
							}
							SVUuvoEeLXWDArITFFbyZUWJClKFA();
							UYbCmZrMUzoofWAlMWVplOHLJSRO = null;
							rSEAUjpfsXxIVmhQqxWYInsDpJul++;
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

					private void SVUuvoEeLXWDArITFFbyZUWJClKFA()
					{
						HRAxIdaORnXbTNclBqcXPFXvFqkq = -1;
						if (UYbCmZrMUzoofWAlMWVplOHLJSRO != null)
						{
							UYbCmZrMUzoofWAlMWVplOHLJSRO.Dispose();
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
						VxmGoMSlPVltYHzpgLtHytGFeJOv vxmGoMSlPVltYHzpgLtHytGFeJOv;
						if (HRAxIdaORnXbTNclBqcXPFXvFqkq == -2 && XkyogzkUUrEViDticGZHUWLobfGE == Environment.CurrentManagedThreadId)
						{
							HRAxIdaORnXbTNclBqcXPFXvFqkq = 0;
							vxmGoMSlPVltYHzpgLtHytGFeJOv = this;
						}
						else
						{
							vxmGoMSlPVltYHzpgLtHytGFeJOv = new VxmGoMSlPVltYHzpgLtHytGFeJOv(0);
						}
						vxmGoMSlPVltYHzpgLtHytGFeJOv.aeiISEvOhrRbqVwqbLWdUisJViVL = ltNmgQMljWVnCkYKwdfIKFIprCBr;
						vxmGoMSlPVltYHzpgLtHytGFeJOv.trZeSYxFowBvmYlgoICfJcRbhTwc = jdcjwhEyZUuaINrTTSwJuPFzvjFb;
						vxmGoMSlPVltYHzpgLtHytGFeJOv.TrIigHEaBvdSGZMtkXqAROpkZAKe = BovalUnWLvrmNnhsrHrBWCzuDJkkA;
						vxmGoMSlPVltYHzpgLtHytGFeJOv.dqALHKrXQsvwSBgFhkaNXZbvrfCf = XLeQXvvhVjjAAOpAkKWosBmVOtYb;
						return vxmGoMSlPVltYHzpgLtHytGFeJOv;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private static ConflictCheckingHelper DTbqHtUlqtFisnMqncOGtztIfbKq;

				internal static ConflictCheckingHelper RwLoCmUPsZCXkszkiiQRrSovrTAm => DTbqHtUlqtFisnMqncOGtztIfbKq ?? (DTbqHtUlqtFisnMqncOGtztIfbKq = new ConflictCheckingHelper());

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
					IList<Player> list = (includeSystemPlayer ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
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
						ControllerType.Joystick => GVegluwaGuNjUUMrtrtChwfHLLaC(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => EQhrigXEGkhRCfUDJVakAPiHGZLM(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => HdBLfnCHQdfUkeKXVpfqhzrkaOys(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => dgEYhfsZrokBXWZHWJJCbZnLUGOH(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return tNqnufykukuOGaohWgjAydVQYMGw(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return KfTOdNnRstWNnkpwQWAkkTvvGoOb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return BAsFlqXCerJqUhIIlgyeLMqnXFDE(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return JbsRzUGvSjmFtslcqyiZetBsbRds(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool GVegluwaGuNjUUMrtrtChwfHLLaC(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool tNqnufykukuOGaohWgjAydVQYMGw(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool EQhrigXEGkhRCfUDJVakAPiHGZLM(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool KfTOdNnRstWNnkpwQWAkkTvvGoOb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool HdBLfnCHQdfUkeKXVpfqhzrkaOys(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool BAsFlqXCerJqUhIIlgyeLMqnXFDE(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool dgEYhfsZrokBXWZHWJJCbZnLUGOH(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool JbsRzUGvSjmFtslcqyiZetBsbRds(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
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
						ControllerType.Joystick => zIwdeHeBTpYCnbOUJXNRALFJMXVm(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => VDciEpfaWrHEZnhmmnNUQHHrdtJA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => dLeJjntAhobBlJBgRNFnjVPCNOZIB(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => IzEmnyHsmiBDjkNJkNQktiAjDDln(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return kuKeJXvWjkGuurwoDYWggwWAkojD(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return GABoscWMqfhOHCyGdbhvEcKGkkOs(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return RBSmrSKmumsZbiKyVJkkytNdwIde(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return JwbGgIiAuvBwByTnrvVyWmIkHARhA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				[IteratorStateMachine(typeof(oNNOflQxcQhrMgMZNqyeZIeAVdSq))]
				private IEnumerable<ElementAssignmentConflictInfo> zIwdeHeBTpYCnbOUJXNRALFJMXVm(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new oNNOflQxcQhrMgMZNqyeZIeAVdSq(-2)
					{
						NVoccTtJEsaFpPHajfhKsXcDQxHN = P_0,
						DnuiFCwvOMWlUCwVEnLpPLubhVTd = P_1,
						KAwwxWIvAQNrscbBgVqQXWkYYBrH = P_2,
						MHaMCmNkxanqxszqIFoPEkcwBETy = P_3,
						ZYtgLnaPzIRNDigmiFEvmzYXWaGh = P_4,
						YqGjkOyXsakHHeZPBKscCDQNjxNT = P_5,
						XZjqUQcGInIcBZkDKiUyLrTfHYyO = P_6
					};
				}

				[IteratorStateMachine(typeof(ZbRAWSTmzbGsWuPmREVRvwogwGY))]
				private IEnumerable<ElementAssignmentConflictInfo> kuKeJXvWjkGuurwoDYWggwWAkojD(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new ZbRAWSTmzbGsWuPmREVRvwogwGY(-2)
					{
						TXbmokHiNfSdofWUrFEiwXjOlMXr = P_0,
						RSlWsvwmofNUxkcjLfIdDzxdysbr = P_1,
						aCPHFrekFoNrVGBUeRwycUvWIyLGA = P_2,
						nlcEHhDztUmihSjkmzAJoLDrNnRH = P_3
					};
				}

				[IteratorStateMachine(typeof(OyfJEbgZWvwulYvspsLQyoWEHZNE))]
				private IEnumerable<ElementAssignmentConflictInfo> VDciEpfaWrHEZnhmmnNUQHHrdtJA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new OyfJEbgZWvwulYvspsLQyoWEHZNE(-2)
					{
						XVimrWUMmVzugDqbBvKAfaMwFSdfA = P_0,
						EWjNEMQfUgDSZGQbkqpYsmBplMWEb = P_1,
						kKGTwzQjKlUUuyEnruFYmVulszNE = P_2,
						XWiCZPbBycptcLuNJjvnfefbZpdvb = P_3,
						FuBUJkAfZoFsjbjBCBYnmptooitcA = P_4,
						elklPPupgehISJDOIdDKFqhftbHIb = P_5
					};
				}

				[IteratorStateMachine(typeof(bIZANFDsUdjBjvJchprzLMUBoKfB))]
				private IEnumerable<ElementAssignmentConflictInfo> GABoscWMqfhOHCyGdbhvEcKGkkOs(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new bIZANFDsUdjBjvJchprzLMUBoKfB(-2)
					{
						mlXckbaZvfUgmNXmhVAAaHtifBuuA = P_0,
						iRkIUhTvvYDxjuWqgoBwOPTtGfhX = P_1,
						KDjxglesPUFtZlebeidlsjhxXqCB = P_2,
						yCYEFNywmZGRIPELJbpWPGeDoroC = P_3
					};
				}

				[IteratorStateMachine(typeof(kkOLtPqWvddTLyAzuuQXtdHotKpv))]
				private IEnumerable<ElementAssignmentConflictInfo> dLeJjntAhobBlJBgRNFnjVPCNOZIB(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new kkOLtPqWvddTLyAzuuQXtdHotKpv(-2)
					{
						yYwiaQneJJyzewWOHSHeBqWTOKYC = P_0,
						ZxThyPNRiiDLFwojkCcTswAScnwR = P_1,
						PdvXOCXvhlGcKeBWZMcOCcVjcqwy = P_2,
						gqXfJBJWyNQsdmeOHoRcemfIkitLA = P_3,
						OzjmCAZrORuQmVVChLGiWscRbvtW = P_4,
						bFDfpPtLjeDEqiRlVrjAgFFyZqYCA = P_5
					};
				}

				[IteratorStateMachine(typeof(VxmGoMSlPVltYHzpgLtHytGFeJOv))]
				private IEnumerable<ElementAssignmentConflictInfo> RBSmrSKmumsZbiKyVJkkytNdwIde(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new VxmGoMSlPVltYHzpgLtHytGFeJOv(-2)
					{
						ltNmgQMljWVnCkYKwdfIKFIprCBr = P_0,
						jdcjwhEyZUuaINrTTSwJuPFzvjFb = P_1,
						BovalUnWLvrmNnhsrHrBWCzuDJkkA = P_2,
						XLeQXvvhVjjAAOpAkKWosBmVOtYb = P_3
					};
				}

				[IteratorStateMachine(typeof(vhFgvxVGqMbOFkXysQInVyBWbvDo))]
				private IEnumerable<ElementAssignmentConflictInfo> IzEmnyHsmiBDjkNJkNQktiAjDDln(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new vhFgvxVGqMbOFkXysQInVyBWbvDo(-2)
					{
						hsvtLLQkhHMzvwWjRJiBZAbXAXeGA = P_0,
						UvavcLbtprNgjzdRPJzzwERaBQYr = P_1,
						yFWkoMDAiAqVlSlFjZKdMsltNdzK = P_2,
						GQEdWsHVULOQPSpUhAvZpIVtzeuRA = P_3,
						xbdAdsfjWZafdKqkcFMKjkLOXxwgb = P_4,
						OaSaoWFmnYsssdylfptgEtUoknXaA = P_5,
						jmndmEDEpOPmDVoDgdyOxryjGRyc = P_6
					};
				}

				[IteratorStateMachine(typeof(QutEnbkDdtDGZXFmMZwoTnrkCzbt))]
				private IEnumerable<ElementAssignmentConflictInfo> JwbGgIiAuvBwByTnrvVyWmIkHARhA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new QutEnbkDdtDGZXFmMZwoTnrkCzbt(-2)
					{
						MPgxLbHxwnRYjqhBSRIYtohJAdJkA = P_0,
						zIQAMqAYeHbxiMEHdbltpzeboRyPA = P_1,
						hrUNppbwHuipOCAwffOcxlMhvqlR = P_2,
						sXWXjiSukCGORaiXXeIygMGwHANBA = P_3
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
						ControllerType.Joystick => gsYxoImMbNpNPRBbvvBkReHGevrY(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => aUDRiSeZFYjiMvyRiblXpTfBLYQf(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => ALajyCDHXegKKzVgZncXYCTYgZLT(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => ZYLaxKVcIYMUhBNWkUBsMujsNrrH(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return BjuCpJwNqMUxTPxfiZJnlwxHzIRI(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return dxRnWBTfJNEjeAprdqgWqgghXaLLA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return wsxcKoaNgdCEcsRiUMsYAVejOABgb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return qGuclLrCokknTOTVuqbevKeiQEpn(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int gsYxoImMbNpNPRBbvvBkReHGevrY(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int BjuCpJwNqMUxTPxfiZJnlwxHzIRI(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int aUDRiSeZFYjiMvyRiblXpTfBLYQf(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int dxRnWBTfJNEjeAprdqgWqgghXaLLA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int ALajyCDHXegKKzVgZncXYCTYgZLT(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int wsxcKoaNgdCEcsRiUMsYAVejOABgb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int ZYLaxKVcIYMUhBNWkUBsMujsNrrH(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int qGuclLrCokknTOTVuqbevKeiQEpn(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
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
						ControllerType.Joystick => nlnWcXSMxxyfKKMGkdHdcRfDODAdA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => YDuEBYiryzEZawdqKmyiEcPUgvEAA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => olikcntKccaDmEKKteitSKaAnqySA(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => OzBoKypfLurjBjMFFbjvxDMrgAFi(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return NBMDePXKFAuFVqNWCsHJLBRHDzNEA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return uTYWfWhNOvFPflNTQFippDnEDbZt(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return KppjXcMZXansjQqYzIrJenopGcwJ(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return BzBCpQxaADucCVjsVRVowiVCPYXt(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int nlnWcXSMxxyfKKMGkdHdcRfDODAdA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int NBMDePXKFAuFVqNWCsHJLBRHDzNEA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int YDuEBYiryzEZawdqKmyiEcPUgvEAA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int uTYWfWhNOvFPflNTQFippDnEDbZt(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int olikcntKccaDmEKKteitSKaAnqySA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int KppjXcMZXansjQqYzIrJenopGcwJ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int OzBoKypfLurjBjMFFbjvxDMrgAFi(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int BzBCpQxaADucCVjsVRVowiVCPYXt(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG : BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper eHlUqYiOgCEkkNswrmdYSuSHDacY;

			public readonly PollingHelper polling = PollingHelper.pnCcpbCEBCfliunzAFFIwdVnEgiCA;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.RwLoCmUPsZCXkszkiiQRrSovrTAm;

			internal static ControllerHelper KxqrRtEEOCfhhREzEERAgMRcgdrqA => eHlUqYiOgCEkkNswrmdYSuSHDacY ?? (eHlUqYiOgCEkkNswrmdYSuSHDacY = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.dhULUdhbafxgPurKrwINoSNnDVIU;
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
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.fohMKRyovgefmeRThMOoFsVQVDtNA;
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
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.QRdffiyBXZIwyIaPCjnZBUdIBmik;
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
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.IeYgCxBcbnFZhKaxGJMqKHnEVRHi;
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
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.eoBdhxXkFRcCpTZAvInYZHzHfdAP;
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
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC;
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
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.PsjwTZKfSMplrvqshESSZRCHWDSx;
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
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.KbVTmGudneBycajQqiiCMqSOgtMpA;
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
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.IeYgCxBcbnFZhKaxGJMqKHnEVRHi as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return AtHYwRgWVYrmVOsWolCxiSLKHuEp.QRdffiyBXZIwyIaPCjnZBUdIBmik as T;
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
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.DFkLoOraYKZxPsJxXLcjqacSAAGg(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.VleibMOfPIZqdSMNAKofMqlggTDd(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.ebFEFZglxpSIxigLxRBFreLSebCDA(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.aoRDqItoKxIasmFabCIdQcibDmNC(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.jwOahFLYkiBcLtShkRRUkPsuePjfA(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.EqIDBmRybTLHYoGchhiRbqTIwWDC(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.FCnyfuDDSDgWnGmRrZAVVUkjlCFNA(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.KwYTlvVhlFAMYYsuVdrtlhvwCEMG(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.YgCedEdGGIwUIlppJKUPtiwEDetN(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.xVDcTIAXBrOtROlyxNNOhlGQNowqA(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.dOsaTeFHGZLdISSDRxRMUftKBnTcA();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.qQnNcixYGlqMdriBgpXuVIsFSsxb();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.hcOExfsJUgPEFcgQRUtQtRgOcfnQ(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.VQZxNkKRkbgXBTsIWYDXwCWWQVXc(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.QbmgcfGFrblzLSQThujQSGwSAhPb(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.BFbmxetoSrdQrABkhbdtPntIKZJO(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.HkuctBEZuVyAzHfIRpYFSMRKrtnNA(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!JNDjFncOGfUCmPYHuDpMvGdSUJgR)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				bFlYJYdThmEVKoGokMWOVrIhvmgi();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (SkMixArZvRWYivDnqVxCVPWGBhBb.fYZsPduUbgounCMDdaYNFdIMfeoy(i, j))
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
				if (!JNDjFncOGfUCmPYHuDpMvGdSUJgR)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				bFlYJYdThmEVKoGokMWOVrIhvmgi();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (SkMixArZvRWYivDnqVxCVPWGBhBb.fYZsPduUbgounCMDdaYNFdIMfeoy(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (SkMixArZvRWYivDnqVxCVPWGBhBb.REuPFkucNEAEbDulBGlaPBiAgYvYA(i, k, positiveAxesOnly))
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
					if (!JNDjFncOGfUCmPYHuDpMvGdSUJgR)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						yRpgCyHYzfXcnBMlQjezfMsPGNHjb.SetUnityJoystickId(joystickId, unityJoystickId);
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
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.PeWLEoKTTGbofJQCWeTcZfvcnjPy(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.UxQpiyrLGaaabQqScYxqriUZuQyC();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.bWPGfQTrLvAbZJlkfamZgaZdANCGB();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.vWeeTsMprBHKGaKvnGDoirBxLodLA(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.fnnZpATKxKjhRLZnuntpojRSaXEcA(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.lLmsjtEeKGdFEhoLNjMqAyfvLkqZA(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.sdppVJNWiJThpXgjcChRwLGPkknT(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.gQfgOWdyfDYnoVIBCrowpZMQppMR(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.NprxOsPQZmIODMrEVTJSdqAawKNH(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = AtHYwRgWVYrmVOsWolCxiSLKHuEp.NprxOsPQZmIODMrEVTJSdqAawKNH(sourceControllerId);
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
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.qoZabUfocoUlmIzaNPofEkUWbSrv(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.cXNrtcUrQlRKGIQfqPgrMXDvELyF(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.HHTFVZaetQFpMLtbzCIslssQpklVA(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.fRUUDeWfuYtnNGgLAgATFsdYAdGiA(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.cpbpFtJcLBHHKKpkNKIzRoKsTudc(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.HjnXZsHhoQJsVuLwTSdQAZgWfLUA<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.HtLGncGfefHXdaZjvhJIvDPtklQrA();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.lDhhoxieuhVAsUlmNcwvjgDbdIZOA(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.HtLGncGfefHXdaZjvhJIvDPtklQrA<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.btFlqWrcTtUpdTMuRDtjFfxPQeDBA();
			}

			public bool SetLastActiveController(Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.UamZCAbGkJIHLNomaeJGYFVSPclP(controller);
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					AtHYwRgWVYrmVOsWolCxiSLKHuEp.tYFPBPHPJijfDCAXIZBksPRBEcakA(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					AtHYwRgWVYrmVOsWolCxiSLKHuEp.PtgppDVJLkEuShCeWVhcZfiUcMep(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					AtHYwRgWVYrmVOsWolCxiSLKHuEp.GjmcroDwJuLcfTGGIByTIhhTCZpt(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					AtHYwRgWVYrmVOsWolCxiSLKHuEp.FcUABuVVEPvfaBaCfGYtvwyEnULy(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					AtHYwRgWVYrmVOsWolCxiSLKHuEp.dhZwBQxnEWxHNvsKCdYOrBeaFChm();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.KNEyiQrUUmKSHvMcOwNcDbQFazvE();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.zwppiviaMutHRVTmCrXnUryKgAYv(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.tCBSElNbGWwRoCZdSkntGCmrPqAw();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.mwyjsYMBUAxpMyGDSzZOpAaLEoGF(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.MRlweYAfzwKdHzFZAGbXjYtjnoBMA();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.mcMdqzINIWUBqQMUmotPDTjbaErM(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.JJLJgXGHvBzWzINHmwSxSHdPBDhW();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.YfxBSLAJCUpAiqfWwcAksvFnohzY(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.kFrfUrGAVJRZeFuuvCBNhkJnKFEO();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.huZqQwFDCTHlbjpfeOSBkGXnooOL(controllerType);
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
				BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.xbeiDDqjgykocyFaNWjvXBpapRSt(joystick);
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
			private static MappingHelper SjzAWVYXdcRUZdBHlBQBARIMKoPsA;

			internal static MappingHelper HsMuVtdEwCSOuRyvVZdeKoEnsDUb => SjzAWVYXdcRUZdBHlBQBARIMKoPsA ?? (SjzAWVYXdcRUZdBHlBQBARIMKoPsA = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return lzZKeetYdFxEfanBzSciGQGcmdER.wuGtLRtEtfVDbcPSweQijoAgHePsA;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.aSTsbQripLQnkehMvmdPQlYdNDYn;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.LoOqAGbQBjtFnniPYMnBZCQLGLRk;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.KAiMncrsnNEWXstzdovMQxgVWErs;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.cvgExnntIhRPLMCdFQNlmESfWgjt;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.GSNhjDviRjWrcNOBUmtTKEGPebOC;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.NcJhMPdNZOlgsICFZmXcVrgYwDsAA;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.CaAiXgdBGntDcTkAAmlNzWqxBMobb;
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
					return puvsCcoEkpSrGAnbdVqxjXrCengH.jfcDDlHmBpYiSSIzFklkPMeTElLiA;
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
					return lzZKeetYdFxEfanBzSciGQGcmdER.YUZlBidKvqDkbKIwBribvBUMREMmA;
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
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.aRYLCgulFjrJPPvLaEceDskWmNAX(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.pCUwiCecgAWkqKdJSCiLCIGsGYKX(tag);
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
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.DFeMMhHXrycLZJbBjqbjyBsdOByU(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.hnRlNdlAPVvdecjiXvmDRgJuqKnU(tag);
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
					ControllerType.Joystick => lzZKeetYdFxEfanBzSciGQGcmdER.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => lzZKeetYdFxEfanBzSciGQGcmdER.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => lzZKeetYdFxEfanBzSciGQGcmdER.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => lzZKeetYdFxEfanBzSciGQGcmdER.GetCustomControllerLayoutById(layoutId), 
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
					ControllerType.Joystick => lzZKeetYdFxEfanBzSciGQGcmdER.GetJoystickLayout(name), 
					ControllerType.Keyboard => lzZKeetYdFxEfanBzSciGQGcmdER.GetKeyboardLayout(name), 
					ControllerType.Mouse => lzZKeetYdFxEfanBzSciGQGcmdER.GetMouseLayout(name), 
					ControllerType.Custom => lzZKeetYdFxEfanBzSciGQGcmdER.GetCustomControllerLayout(name), 
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
					ControllerType.Joystick => lzZKeetYdFxEfanBzSciGQGcmdER.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => lzZKeetYdFxEfanBzSciGQGcmdER.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => lzZKeetYdFxEfanBzSciGQGcmdER.GetMouseLayoutId(name), 
					ControllerType.Custom => lzZKeetYdFxEfanBzSciGQGcmdER.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetCustomControllerLayoutId(name);
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
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.FgJAVNWJioLPVPlFfmnbYoRNwFdW(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.FgJAVNWJioLPVPlFfmnbYoRNwFdW(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.nqFZFTwmWGEYEePmwSKWGsYLJWPzA(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.nqFZFTwmWGEYEePmwSKWGsYLJWPzA(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.gfjQCxFfoRVfFvsZWlLiYErxAqbEA(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.IfrONmBqIVDBecdyKDTZKLmDmaDpA(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.IfrONmBqIVDBecdyKDTZKLmDmaDpA(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.benaUAnmbtCPxewRQgVBqIcpJnARA(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.benaUAnmbtCPxewRQgVBqIcpJnARA(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.BUHchcVExxcLLVISomzDIDkZWYHs(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.BUHchcVExxcLLVISomzDIDkZWYHs(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.ZSaXaWxiHUTBOKAFUdCciNmpaevcA(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AtHYwRgWVYrmVOsWolCxiSLKHuEp.KSWKFupatZtHQrFKolbYiPjSGdhh(playerId, behaviorName);
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
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior XEVFsuEMxHkciZSLzbKRBSDQzeCr(int P_0)
			{
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetInputBehaviorById(P_0);
			}

			internal InputBehavior EDQgHnhlfkxnlwizgYrFSTVuidqBb(string P_0)
			{
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetInputBehavior(P_0);
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
				Controller controller = AtHYwRgWVYrmVOsWolCxiSLKHuEp.VleibMOfPIZqdSMNAKofMqlggTDd(controllerIdentifier);
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
				JoystickMap joystickMap = lzZKeetYdFxEfanBzSciGQGcmdER.yZmJysTiAJlrPpOSedEsHtLLwPgAA(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.CfhpsvHyWfICgEKNRdHQTCKBrgig(joystickMap);
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
				InputSource inputSourceType = yRpgCyHYzfXcnBMlQjezfMsPGNHjb.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = OVeeJQbujkUuYPIoeAewhTIjinMqB.iwHNuXdESatldTybiLSSNSvEgijU(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = lzZKeetYdFxEfanBzSciGQGcmdER.ATPxcsuMveBpAQADaPtbnWoSQNVV(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.taGTQuetFzGXqFgVBSxSviRmeDYP(joystickMap, hardwareControllerMap_Game);
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
				if (AtHYwRgWVYrmVOsWolCxiSLKHuEp.VleibMOfPIZqdSMNAKofMqlggTDd(controllerIdentifier) is Joystick joystick)
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
				KeyboardMap keyboardMap = lzZKeetYdFxEfanBzSciGQGcmdER.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.CfhpsvHyWfICgEKNRdHQTCKBrgig(keyboardMap);
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
				MouseMap mouseMap = lzZKeetYdFxEfanBzSciGQGcmdER.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.CfhpsvHyWfICgEKNRdHQTCKBrgig(mouseMap);
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
				CustomControllerMap customControllerMap = lzZKeetYdFxEfanBzSciGQGcmdER.DgbFjiULnlYfIPOraXwotTKzqNpf(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.CfhpsvHyWfICgEKNRdHQTCKBrgig(customControllerMap);
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
				if (AtHYwRgWVYrmVOsWolCxiSLKHuEp.VleibMOfPIZqdSMNAKofMqlggTDd(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = lzZKeetYdFxEfanBzSciGQGcmdER.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = lzZKeetYdFxEfanBzSciGQGcmdER.YpviIYgbXxNRlWPVezMWDIbmbhlc(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.taGTQuetFzGXqFgVBSxSviRmeDYP(customControllerMap, hardwareControllerMap_Game);
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
					controllerMap = lzZKeetYdFxEfanBzSciGQGcmdER.vniVhbPNujcZYbXBXYJYpZOHjbtl(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.KTKJqTPkIUCqdztsJbksFOXTJZiiA(controller, controllerMap);
					}
					else
					{
						controller.CfhpsvHyWfICgEKNRdHQTCKBrgig(controllerMap);
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
				if (AtHYwRgWVYrmVOsWolCxiSLKHuEp.VleibMOfPIZqdSMNAKofMqlggTDd(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = yRpgCyHYzfXcnBMlQjezfMsPGNHjb.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = OVeeJQbujkUuYPIoeAewhTIjinMqB.iwHNuXdESatldTybiLSSNSvEgijU(controllerIdentifier.hardwareTypeGuid, inputSourceType);
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
					joystickMap = lzZKeetYdFxEfanBzSciGQGcmdER.ATPxcsuMveBpAQADaPtbnWoSQNVV(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
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
						allMap.taGTQuetFzGXqFgVBSxSviRmeDYP(joystickMap, hardwareControllerMap_Game);
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
				if (AtHYwRgWVYrmVOsWolCxiSLKHuEp.VleibMOfPIZqdSMNAKofMqlggTDd(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = lzZKeetYdFxEfanBzSciGQGcmdER.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
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
					customControllerMap = lzZKeetYdFxEfanBzSciGQGcmdER.YpviIYgbXxNRlWPVezMWDIbmbhlc(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.taGTQuetFzGXqFgVBSxSviRmeDYP(customControllerMap, hardwareControllerMap_Game);
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
					keyboardMap = lzZKeetYdFxEfanBzSciGQGcmdER.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.KTKJqTPkIUCqdztsJbksFOXTJZiiA(keyboard, keyboardMap);
					}
					else
					{
						keyboard.CfhpsvHyWfICgEKNRdHQTCKBrgig(keyboardMap);
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
					mouseMap = lzZKeetYdFxEfanBzSciGQGcmdER.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.KTKJqTPkIUCqdztsJbksFOXTJZiiA(mouse, mouseMap);
					}
					else
					{
						mouse.CfhpsvHyWfICgEKNRdHQTCKBrgig(mouseMap);
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
				return pxnJTLHGQCEYWjleWBlJdMCmcNwMA(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier pxnJTLHGQCEYWjleWBlJdMCmcNwMA(Guid P_0, int P_1)
			{
				HardwareJoystickMap hardwareControllerMap;
				return OVeeJQbujkUuYPIoeAewhTIjinMqB.glbVCsftAMQzQSlgrkodVlTkRekJ(P_0, P_1, out hardwareControllerMap)?.ToControllerElementIdentifier(hardwareControllerMap);
			}

			internal int FyxcTPIdAcJNWfIkPrcCGsxrqNyk(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.yqBpozNnUGXldJOvkEybfHAdbgiGA> P_3)
			{
				return OVeeJQbujkUuYPIoeAewhTIjinMqB.opvClwAiuJhLLNOVyAYCDDYhFijaB(P_0, P_1, P_2, P_3);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lzZKeetYdFxEfanBzSciGQGcmdER.ICUczwpuGWZamujSGnDFlMnUjjLo(templateTypeGuid, mapCategoryId, layoutId);
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
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = lzZKeetYdFxEfanBzSciGQGcmdER.GetControllerMapLayoutManagerRuleSetId(name);
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
				return lzZKeetYdFxEfanBzSciGQGcmdER.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = lzZKeetYdFxEfanBzSciGQGcmdER.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper sBbnLKoPraKWSjGglACrsipozBlc;

			internal static PlayerHelper cWSALjICsAwABGIkhYHxdpRUCWPBb => sBbnLKoPraKWSjGglACrsipozBlc ?? (sBbnLKoPraKWSjGglACrsipozBlc = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.KAOhRVBrBYwCtoNeiOpilaTceGbbA;
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
					return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.imgzsKYXwFRKJFlIkipkRfWZvIoo;
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
					return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB;
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
					return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG;
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
					return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.JnxxdHKLKTWWOGpjgTpkAKLMeRjbA();
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
					return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.iLgYnNBBmfEbfjvbkBEifkofAzqvB;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.TCxpaUtqwtvVjZtIczZUxEFBsccG;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.SsVuigQhQtABwxcDHPRhTnSsVBJh(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.wpNBDvmrXFEYIRVPRbdGALfzHeGhb(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.JnxxdHKLKTWWOGpjgTpkAKLMeRjbA();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.DaRkwrQjNDBRBiYfWNPYJMsgkeuo(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.PKDMjuTkjKkQVeWqjxxelNpfWWzG(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.stJDbLaUSaWDvKUtPONckPSZsOvbA(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.IZqWpvlIwPjxtUIAsMraXklaIlSZ(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper JCiKfZMFgAbgWfERxNWpChDmvitbA;

			internal static TimeHelper xYMxdgfdOcnNIiUwFkdaiWDPEIEx => JCiKfZMFgAbgWfERxNWpChDmvitbA ?? (JCiKfZMFgAbgWfERxNWpChDmvitbA = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)mhUGgtObxZJqMbMhckJouxMpIaLP.PyOyOsdryfcpjEQxPeZpDDbYjIpbb;
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
					return mhUGgtObxZJqMbMhckJouxMpIaLP.YrFypRmDutlYsNvaEkMVGgCyCwoCA;
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
					return mhUGgtObxZJqMbMhckJouxMpIaLP.XrIwsUfikkZYZwuXmnOBNXklxTCG;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class YcUiQoqvyJacWtWlCsPgxmfedOiU
		{
			private class XITbeztbVOUFtwNfIHnABhvhZKqr
			{
				public readonly UpdateLoopType AVsqjIkegCIfWFozEfDlgbBCVPlgA;

				private double ZxzVPSyyGAGEDegnJfAwhaycRDTMA;

				private double NyduGGfpUITFLItrJPbtUEchdAEe;

				private double OfJjmLurAzJvLilCAazAnBIXoJil;

				private double ZioDRfqHqMGTbeNJmdowKfaPstZnA;

				private uint BQexvvxKLSlStQMlnpmhyPKMouuc;

				private uint caXEObZFhstGbtbulqzSCcuxaFokA;

				private float nuJbuFKgaIgCoiwTLCKsihSijJbXA;

				private float ilmZpqXJwoESpxCfYyiNPDGRqSEK;

				public double XoynibWnGURZqCiFaSnfOKSPkdMC => ZxzVPSyyGAGEDegnJfAwhaycRDTMA;

				public double HsQnbDGOrTdnkcKLtKmEZHTcZFxo => NyduGGfpUITFLItrJPbtUEchdAEe;

				public double gqHcdYxTykacNnBxPtBjnExSwLTH => OfJjmLurAzJvLilCAazAnBIXoJil;

				public uint LpDzdYCwTWezoYAjIgQNtcXbdlv => BQexvvxKLSlStQMlnpmhyPKMouuc;

				public uint ltaYjAuLurLJrxpQXJpztOzmvHLE => caXEObZFhstGbtbulqzSCcuxaFokA;

				public float fczIdBInjWuIdlOZalybeERapUAYb => nuJbuFKgaIgCoiwTLCKsihSijJbXA;

				public float JEaSUTMAKlnUOUReBwLKiImAETKcA => ilmZpqXJwoESpxCfYyiNPDGRqSEK;

				public XITbeztbVOUFtwNfIHnABhvhZKqr(UpdateLoopType P_0)
				{
					AVsqjIkegCIfWFozEfDlgbBCVPlgA = P_0;
					ZioDRfqHqMGTbeNJmdowKfaPstZnA = Time.realtimeSinceStartup;
					BQexvvxKLSlStQMlnpmhyPKMouuc = 0u;
				}

				public void rBnTxLcdkyvzkUoEviaJnheDEIzt()
				{
					NyduGGfpUITFLItrJPbtUEchdAEe = ZxzVPSyyGAGEDegnJfAwhaycRDTMA;
					ZxzVPSyyGAGEDegnJfAwhaycRDTMA = realTime;
					if (ZioDRfqHqMGTbeNJmdowKfaPstZnA > ZxzVPSyyGAGEDegnJfAwhaycRDTMA)
					{
						ZioDRfqHqMGTbeNJmdowKfaPstZnA = 0.0;
					}
					OfJjmLurAzJvLilCAazAnBIXoJil = ZxzVPSyyGAGEDegnJfAwhaycRDTMA - ZioDRfqHqMGTbeNJmdowKfaPstZnA;
					ZioDRfqHqMGTbeNJmdowKfaPstZnA = ZxzVPSyyGAGEDegnJfAwhaycRDTMA;
					caXEObZFhstGbtbulqzSCcuxaFokA = BQexvvxKLSlStQMlnpmhyPKMouuc;
					BQexvvxKLSlStQMlnpmhyPKMouuc = MiscTools.Tick(BQexvvxKLSlStQMlnpmhyPKMouuc);
					ilmZpqXJwoESpxCfYyiNPDGRqSEK = nuJbuFKgaIgCoiwTLCKsihSijJbXA;
					nuJbuFKgaIgCoiwTLCKsihSijJbXA = xwQRixeVzvQtXWJFnuEAqxlqPjtQ();
					previousFrame = caXEObZFhstGbtbulqzSCcuxaFokA;
					currentFrame = BQexvvxKLSlStQMlnpmhyPKMouuc;
					unscaledTime = ZxzVPSyyGAGEDegnJfAwhaycRDTMA;
					unscaledTimePrev = NyduGGfpUITFLItrJPbtUEchdAEe;
					unscaledDeltaTime = OfJjmLurAzJvLilCAazAnBIXoJil;
				}
			}

			private static class iSOUHymOTYaneuoXCtiSQRnwLNZu
			{
				public static StopwatchBase yOSwVYdRhAmMDQmqNuXJlqwZFlKE
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

				public static StopwatchBase nhbnVVRnlcghLQffmBhSYrQIIGJk()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase uVQMMHIdjahMyfRvQfAwXkdAOwtCb()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase AFIdiuCZLQEpeUnGKevdkLrkfpMdb;

			private double sWsDmnHkHThkwyQpMBbpdiMrRzVTA;

			private XITbeztbVOUFtwNfIHnABhvhZKqr IcTPhLQVfFRBDuUktunUbebygrGq;

			private ADictionary<int, XITbeztbVOUFtwNfIHnABhvhZKqr> zUECsPeQgCdFoJRtzaeYAyAWnWjl;

			private uint LMZvmYKKdfJAznpAuUCUdHZJkbYv;

			public double YrFypRmDutlYsNvaEkMVGgCyCwoCA => IcTPhLQVfFRBDuUktunUbebygrGq.XoynibWnGURZqCiFaSnfOKSPkdMC;

			public double YdjdChBszLSPVNGCAXKCtFByRnxT => IcTPhLQVfFRBDuUktunUbebygrGq.HsQnbDGOrTdnkcKLtKmEZHTcZFxo;

			public double PyOyOsdryfcpjEQxPeZpDDbYjIpbb => IcTPhLQVfFRBDuUktunUbebygrGq.gqHcdYxTykacNnBxPtBjnExSwLTH;

			public float OvdBycBnPDrDXDXPDYGYDjEJtIFeA => IcTPhLQVfFRBDuUktunUbebygrGq.fczIdBInjWuIdlOZalybeERapUAYb;

			public float FLNaaoxtKpXupTpsxphuMEPviYaCA => IcTPhLQVfFRBDuUktunUbebygrGq.JEaSUTMAKlnUOUReBwLKiImAETKcA;

			internal double WKcIauEvssDNPlZKZiIXQoWuInsC => AFIdiuCZLQEpeUnGKevdkLrkfpMdb.elapsedSeconds + sWsDmnHkHThkwyQpMBbpdiMrRzVTA;

			public uint XrIwsUfikkZYZwuXmnOBNXklxTCG => IcTPhLQVfFRBDuUktunUbebygrGq.LpDzdYCwTWezoYAjIgQNtcXbdlv;

			public uint ZmvBSmcaKqbTCbZCVfcRTZjkTcjpA => IcTPhLQVfFRBDuUktunUbebygrGq.ltaYjAuLurLJrxpQXJpztOzmvHLE;

			public uint jciExMhkTlkeQWncBhHVMnCtHKiAb => LMZvmYKKdfJAznpAuUCUdHZJkbYv;

			public YcUiQoqvyJacWtWlCsPgxmfedOiU()
			{
				AFIdiuCZLQEpeUnGKevdkLrkfpMdb = iSOUHymOTYaneuoXCtiSQRnwLNZu.yOSwVYdRhAmMDQmqNuXJlqwZFlKE;
				ilRUqbXibnRtQqhJtdnTfNukiAXW();
			}

			public void xbXBQnaJYdpzMrWjYztaiXepVdBm()
			{
				sWsDmnHkHThkwyQpMBbpdiMrRzVTA = Time.realtimeSinceStartup;
			}

			public void ilRUqbXibnRtQqhJtdnTfNukiAXW()
			{
				IcTPhLQVfFRBDuUktunUbebygrGq = null;
				zUECsPeQgCdFoJRtzaeYAyAWnWjl = new ADictionary<int, XITbeztbVOUFtwNfIHnABhvhZKqr>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)(-1), list);
				for (int i = 0; i < list.Count; i++)
				{
					XITbeztbVOUFtwNfIHnABhvhZKqr xITbeztbVOUFtwNfIHnABhvhZKqr = new XITbeztbVOUFtwNfIHnABhvhZKqr(list[i]);
					zUECsPeQgCdFoJRtzaeYAyAWnWjl.Add((int)list[i], xITbeztbVOUFtwNfIHnABhvhZKqr);
					if (IcTPhLQVfFRBDuUktunUbebygrGq == null)
					{
						IcTPhLQVfFRBDuUktunUbebygrGq = xITbeztbVOUFtwNfIHnABhvhZKqr;
					}
				}
			}

			public void sqwDtxZRhtWQNFJOxDcOhXjxvdmMA(UpdateLoopType P_0)
			{
				if (IcTPhLQVfFRBDuUktunUbebygrGq.AVsqjIkegCIfWFozEfDlgbBCVPlgA != P_0)
				{
					IcTPhLQVfFRBDuUktunUbebygrGq = zUECsPeQgCdFoJRtzaeYAyAWnWjl[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					IcTPhLQVfFRBDuUktunUbebygrGq.rBnTxLcdkyvzkUoEviaJnheDEIzt();
					LMZvmYKKdfJAznpAuUCUdHZJkbYv = MiscTools.Tick(LMZvmYKKdfJAznpAuUCUdHZJkbYv);
					absFrame = LMZvmYKKdfJAznpAuUCUdHZJkbYv;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch oWNMzYNkgsLjrVCGBPQihexLzBYd;

			internal static UnityTouch SJcwEdNkRfZKhXQLSeSZImZVQuiw => oWNMzYNkgsLjrVCGBPQihexLzBYd ?? (oWNMzYNkgsLjrVCGBPQihexLzBYd = new UnityTouch());

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

		internal class nfPdRFniMFeSQfmQjUmErQzrHGIQA
		{
			[Serializable]
			private sealed class itTnEVHDZoWuVnueCUwziKMOSQcR
			{
				public static readonly itTnEVHDZoWuVnueCUwziKMOSQcR _003C_003E9 = new itTnEVHDZoWuVnueCUwziKMOSQcR();

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool qRCbNfXakIAtifqNcvRwKRyhKokWA()
				{
					return Screen.fullScreen;
				}

				internal bool TmruwakvzSSZXxeffdrflUBrCWeR()
				{
					return Application.runInBackground;
				}

				internal int iShPLNNUjnwvUjrSVmBfOOwwUDcE()
				{
					return (int)Screen.fullScreenMode;
				}

				internal float iqWiKULXWUPapORRlWCDyzgWuYft()
				{
					return Time.unscaledDeltaTime;
				}

				internal bool npHimRkylVHpCtyzhmqbnAfHcYdu()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				internal string SULbfdJqsmMEwGjnjhxtqHaSGBzAc()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}
			}

			public readonly ValueWatcher<bool> mRmMdbahPAgJUFGYkYMcHGPHBGnh;

			public readonly ValueWatcher<bool> aIcCtMtwDudInFOJeDvTvpuqYpbb;

			public readonly ValueWatcher<bool> IKEdQLCPBjPviokFqdXipJsNZcuRA;

			public readonly ValueWatcher<bool> wwDZdnkuERVSNaxvgEQDCDeGWhhE;

			public readonly ValueWatcher<int> gaHHwJoPOlZmcebFRaHiJUZfCGiuA;

			public readonly ValueWatcher<float> JSsZGeVlYxxLbpoeotyOzARXBKFCA;

			public readonly ValueWatcher<string> ZbhBFxdPBryTgDbSYnFUCxKhXYolb;

			public readonly ValueWatcher<bool> EaYneZlGbzAQQSsVjaRVdqvRPoWk;

			private int zOGrgGYFYjbkEFDAfmTmnbSZVfWFA;

			private readonly ValueWatcher[] CaNhlUcFIFieXFrnoUcYBsxoRXIH;

			public int EoFDOKiSeajpCoRoAAFUOxqdyzxU => zOGrgGYFYjbkEFDAfmTmnbSZVfWFA;

			public nfPdRFniMFeSQfmQjUmErQzrHGIQA()
			{
				bool flag = UnityTools.isEditor || Application.isFocused;
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(mRmMdbahPAgJUFGYkYMcHGPHBGnh = new ValueWatcher<bool>(flag, false)),
					(aIcCtMtwDudInFOJeDvTvpuqYpbb = new ValueWatcher<bool>(false, false)),
					(IKEdQLCPBjPviokFqdXipJsNZcuRA = new ValueWatcher<bool>(Screen.fullScreen, itTnEVHDZoWuVnueCUwziKMOSQcR._003C_003E9.qRCbNfXakIAtifqNcvRwKRyhKokWA, false)),
					(wwDZdnkuERVSNaxvgEQDCDeGWhhE = new ValueWatcher<bool>(Application.runInBackground, itTnEVHDZoWuVnueCUwziKMOSQcR._003C_003E9.TmruwakvzSSZXxeffdrflUBrCWeR, false)),
					(gaHHwJoPOlZmcebFRaHiJUZfCGiuA = new ValueWatcher<int>((int)Screen.fullScreenMode, itTnEVHDZoWuVnueCUwziKMOSQcR._003C_003E9.iShPLNNUjnwvUjrSVmBfOOwwUDcE, false)),
					(JSsZGeVlYxxLbpoeotyOzARXBKFCA = new ValueWatcher<float>(Time.unscaledDeltaTime, itTnEVHDZoWuVnueCUwziKMOSQcR._003C_003E9.iqWiKULXWUPapORRlWCDyzgWuYft, false)),
					(EaYneZlGbzAQQSsVjaRVdqvRPoWk = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), itTnEVHDZoWuVnueCUwziKMOSQcR._003C_003E9.npHimRkylVHpCtyzhmqbnAfHcYdu, MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(ZbhBFxdPBryTgDbSYnFUCxKhXYolb = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), itTnEVHDZoWuVnueCUwziKMOSQcR._003C_003E9.SULbfdJqsmMEwGjnjhxtqHaSGBzAc, false));
				}
				CaNhlUcFIFieXFrnoUcYBsxoRXIH = list.ToArray();
				snChhFRaZVmntzJRgCbOBHJwsNGl();
			}

			public void snChhFRaZVmntzJRgCbOBHJwsNGl()
			{
				for (int i = 0; i < CaNhlUcFIFieXFrnoUcYBsxoRXIH.Length; i++)
				{
					CaNhlUcFIFieXFrnoUcYBsxoRXIH[i].Update();
				}
				zOGrgGYFYjbkEFDAfmTmnbSZVfWFA = Time.frameCount;
			}

			public void DNPzDnagpbBhFettYlsoVwbPfTMo()
			{
				for (int i = 0; i < CaNhlUcFIFieXFrnoUcYBsxoRXIH.Length; i++)
				{
					CaNhlUcFIFieXFrnoUcYBsxoRXIH[i].TriggerEvent();
				}
			}
		}

		[Serializable]
		private sealed class PmFlITEzrzPHCyxsipdsiIXuXEIP
		{
			public static readonly PmFlITEzrzPHCyxsipdsiIXuXEIP _003C_003E9 = new PmFlITEzrzPHCyxsipdsiIXuXEIP();

			public static Func<bool> _003C_003E9__240_0;

			internal void hgFbIsnJGjDsiUIKKeAyAjDRjFtf(Exception P_0)
			{
				HandleCallbackException("", P_0);
			}

			internal void tVijjoeamkjcfYCVAvNsPhEGpQNq(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			}

			internal void CpMIzgUJkqzhruBteUUcfGqZZFLD(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			}

			internal void qumwCvKgiuKMnxCZvUQhwBOactWEA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			}

			internal void NAIDRfMcYOlrtIyhHWdNirDGtPzx(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			}

			internal void dRgdVaaWOZBFTDemkvNGhieESaNjB(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			}

			internal void STPqRopIFJyTtJQoOfhPPDjYienIA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			}

			internal void CMIjcfRPscyZkMYTikUceucvrInA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			}

			internal void ofikNGlQiWIZkclcHcTyWDZGbEPCA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			}

			internal bool aLCrgtPHuAiRyPLZQuEluGCFkLgG()
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
		internal const int programVersion3 = 62;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 5;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U6000";

		private static InputManager_Base zwodvHhZseqwtCKvDmliOWQNQBGe;

		private static PlatformInputManager yRpgCyHYzfXcnBMlQjezfMsPGNHjb;

		internal static CyDvJIEcvrEMxaEuIJlUHZHwTRMo puvsCcoEkpSrGAnbdVqxjXrCengH;

		internal static AIeedhFnMWGfSehpftpyUhoWcUabB AtHYwRgWVYrmVOsWolCxiSLKHuEp;

		internal static eRfSfYfcNJSmLRCFhmMQAqNbCscG BmmzPGNuZrdZxdhYqgOOCPaOiRrkA;

		private static ControllerDataFiles OVeeJQbujkUuYPIoeAewhTIjinMqB;

		private static UserData lzZKeetYdFxEfanBzSciGQGcmdER;

		private static bool lGHKSsDOLZRlhKjLVCaFdzFWjDBc;

		private static ConfigVars LMFOGkQCBvasEfLooITAJJZAxyzA;

		private static UpdateLoopType ucOBHOPVlPlkmsMFRLZnYXOhUXOS;

		private static bool JNDjFncOGfUCmPYHuDpMvGdSUJgR;

		private static Platform BkRCroIpoeMyHeLGqWcnDEinBjOR;

		private static WebplayerPlatform mAnFyadAJCYjoDIZiECAHMdurthDA;

		private static EditorPlatform KICjgwZNqdViWqWHSUlAnvNKQlDq;

		private static bool YsskzMYlEEMiuvhQXBiAvTqXfJiY;

		private static TimerAbs tbjnKPLmWzfqVqgMWvkScyMbeBqg;

		private static YcUiQoqvyJacWtWlCsPgxmfedOiU mhUGgtObxZJqMbMhckJouxMpIaLP;

		private static string PAVdSQbVnTrpEBhVZPbQHDlICKUTB;

		private static bool ZXcHbgGjaHfviLFMEeOlarZfUBwaA;

		private static bool ubeErAeClrRvAbwCZbkRHeihdPVc;

		private static bool ebHTLXhsxmLTZRGHNiViGtqjMMvk;

		private static int jHxjjrTKeXLYJwFdCnwUCzMlqoLi;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int ZHboBiZfYFjmyWInSJuXGssEtPKW;

		private static int eYqCqZMiLxBdRrmGJwCARDPvjpKW;

		private static bool bVhHkeVvaIDWYCujbRbdOagnaYbp;

		private static readonly UnityTouch HajIYQJUEAgQaGVGTtRmUcmzvAhv;

		private static readonly PlayerHelper QaAhnKQmIfyuOfABThSzSKGVSynV;

		private static readonly ControllerHelper bNdJpkMlQMDVkFxXvkaKwRHWxCXPA;

		private static readonly MappingHelper OjTJLduMvcqOoDULvUhwmXXJAHks;

		private static readonly TimeHelper OHoqmQuuipONGYdioUrGMyWwXLne;

		private static readonly ConfigHelper YWwYgZNQwIpyiEkzjpqzLdkdFUZB;

		private static readonly LocalizationHelper cJpJiGADLvinXKdwwxLiIsYeRXGH;

		private static readonly GlyphHelper lQxnuVvOtVeLMBZFGDijLLDWHPGbA;

		private static hnZdEojGOPZGmKTdYvbRxjxprUhR vHALvMIDaWjUesOINSCWEjgwiixt;

		private static UserDataStore LFmtFsoKPrkHpFbTFkKPEJkaiBiC;

		private static IControllerAssigner IZAdDXmsqvYyHuaykUIxXGwhBkFBA;

		private static nfPdRFniMFeSQfmQjUmErQzrHGIQA TRebkVxCIqhvVsfSWNEWTenVMufu;

		private static int phjDiEmLgGbkqIQiHGNTNCLAjFWjb;

		private static SafeAction<ControllerStatusChangedEventArgs> LIMFicZGlrVJmyPgDKhUPEDzItew;

		private static SafeAction<ControllerStatusChangedEventArgs> gUiBwAOequNbudfGvYjUmWoHGLqD;

		private static SafeAction<ControllerStatusChangedEventArgs> ZxaCutCjnIEmFGmHBxcYMBWcYVPnA;

		private static SafeAction WteBjeQyDoNPXrdbbLjEmVfYiqHy;

		private static SafeAction isEgUToYckZyUJgpwmCoOLWTwwGd;

		private static SafeAction kkyTGkKOXaZxaFLAEKSsVLgdylzQ;

		private static SafeAction iigPiLGEkDsMBiQdaaurFBSfxXXt;

		private static SafeAction cJUaqKLIbsKRXsCuugaVHCcsClPzA;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action sjRVcFiVPbVqGcfLyzbvhbsBjanl;

		private static Action<UpdateLoopType> wnMyfmwyeONyGINoThMGmdMVbwTc;

		private static Action<UpdateLoopType> ItXnkSulngFHGJnEeGeUxsxOJKBHb;

		private static Action<UpdateLoopType> fDGHNNuVJUIjOJaqXforOFOBPecfb;

		private static Action INyOmAHgJNNsTHwQonYZrYmcDvPE;

		private static Action<bool> EPMoIDUcOPyaZxQmrEJXtCHzLoiT;

		private static Action<bool> rpbFerDDlZrjdgIwvkrDnipHOQSk;

		private static Action<bool> ZoPvmEUbADQvYXQopHzBUyVbFYae;

		private static Action<FullScreenMode> RCxJGFPKJtzXuaBwPMMwTvmhIooF;

		private static Action QfwSANpAdUMHOJPEpIWHQqWnOvY;

		private static Action<bool> imDDXSeMiRBNNQkMtnPtLcRlVoaW;

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

		private static hnZdEojGOPZGmKTdYvbRxjxprUhR SkMixArZvRWYivDnqVxCVPWGBhBb => vHALvMIDaWjUesOINSCWEjgwiixt ?? (vHALvMIDaWjUesOINSCWEjgwiixt = new hnZdEojGOPZGmKTdYvbRxjxprUhR(LMFOGkQCBvasEfLooITAJJZAxyzA.updateLoop));

		private static bool xwdnJakDBTDttpblTcXyRMGUSnnR => phjDiEmLgGbkqIQiHGNTNCLAjFWjb > 0;

		public static PlayerHelper players
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return QaAhnKQmIfyuOfABThSzSKGVSynV;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return bNdJpkMlQMDVkFxXvkaKwRHWxCXPA;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return OjTJLduMvcqOoDULvUhwmXXJAHks;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return HajIYQJUEAgQaGVGTtRmUcmzvAhv;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return OHoqmQuuipONGYdioUrGMyWwXLne;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return LFmtFsoKPrkHpFbTFkKPEJkaiBiC;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return YWwYgZNQwIpyiEkzjpqzLdkdFUZB;
			}
		}

		public static LocalizationHelper localization
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return cJpJiGADLvinXKdwwxLiIsYeRXGH;
			}
		}

		public static GlyphHelper glyphs
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return lQxnuVvOtVeLMBZFGDijLLDWHPGbA;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 62 + "." + 5 + ".U6000";

		public static bool usingUnityInput => JNDjFncOGfUCmPYHuDpMvGdSUJgR;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
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

		public static bool isReady => lGHKSsDOLZRlhKjLVCaFdzFWjDBc;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => lGHKSsDOLZRlhKjLVCaFdzFWjDBc;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => ucOBHOPVlPlkmsMFRLZnYXOhUXOS;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => LMFOGkQCBvasEfLooITAJJZAxyzA;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => LMFOGkQCBvasEfLooITAJJZAxyzA;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => lzZKeetYdFxEfanBzSciGQGcmdER;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => BkRCroIpoeMyHeLGqWcnDEinBjOR;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => mAnFyadAJCYjoDIZiECAHMdurthDA;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => KICjgwZNqdViWqWHSUlAnvNKQlDq;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.Linux && JNDjFncOGfUCmPYHuDpMvGdSUJgR)
				{
					return true;
				}
				if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.OSX && (JNDjFncOGfUCmPYHuDpMvGdSUJgR || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && JNDjFncOGfUCmPYHuDpMvGdSUJgR)
				{
					return true;
				}
				if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.Webplayer && mAnFyadAJCYjoDIZiECAHMdurthDA == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => KICjgwZNqdViWqWHSUlAnvNKQlDq != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return Guid.Empty;
				}
				return OVeeJQbujkUuYPIoeAewhTIjinMqB.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => ubeErAeClrRvAbwCZbkRHeihdPVc;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => mhUGgtObxZJqMbMhckJouxMpIaLP.OvdBycBnPDrDXDXPDYGYDjEJtIFeA;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => mhUGgtObxZJqMbMhckJouxMpIaLP.FLNaaoxtKpXupTpsxphuMEPviYaCA;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return 0.0;
				}
				return mhUGgtObxZJqMbMhckJouxMpIaLP.WKcIauEvssDNPlZKZiIXQoWuInsC;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return 0;
				}
				return TRebkVxCIqhvVsfSWNEWTenVMufu.EoFDOKiSeajpCoRoAAFUOxqdyzxU;
			}
		}

		private static bool XbRxOkwjfZtsfpVEPVfwKpUecQbc
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return PAVdSQbVnTrpEBhVZPbQHDlICKUTB == "Game";
				}
				return PAVdSQbVnTrpEBhVZPbQHDlICKUTB == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (LMFOGkQCBvasEfLooITAJJZAxyzA.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!ebHTLXhsxmLTZRGHNiViGtqjMMvk)
				{
					return XbRxOkwjfZtsfpVEPVfwKpUecQbc;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (yRpgCyHYzfXcnBMlQjezfMsPGNHjb is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return ebHTLXhsxmLTZRGHNiViGtqjMMvk;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return false;
				}
				if (!JNDjFncOGfUCmPYHuDpMvGdSUJgR)
				{
					return false;
				}
				if (BkRCroIpoeMyHeLGqWcnDEinBjOR != Platform.Windows && (BkRCroIpoeMyHeLGqWcnDEinBjOR != Platform.Webplayer || mAnFyadAJCYjoDIZiECAHMdurthDA != WebplayerPlatform.Windows))
				{
					return KICjgwZNqdViWqWHSUlAnvNKQlDq == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool bWLiDpyBpaCaCdEFvZPuQfbYwKffA
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return false;
				}
				if (!TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.value)
				{
					if (bVhHkeVvaIDWYCujbRbdOagnaYbp)
					{
						return false;
					}
					if ((!isEditor || !isUnityEditorFocused) && !TRebkVxCIqhvVsfSWNEWTenVMufu.wwDZdnkuERVSNaxvgEQDCDeGWhhE.value)
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
				if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsPaused
		{
			get
			{
				if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return TRebkVxCIqhvVsfSWNEWTenVMufu.aIcCtMtwDudInFOJeDvTvpuqYpbb.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return TRebkVxCIqhvVsfSWNEWTenVMufu.IKEdQLCPBjPviokFqdXipJsNZcuRA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return TRebkVxCIqhvVsfSWNEWTenVMufu.wwDZdnkuERVSNaxvgEQDCDeGWhhE.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					return TRebkVxCIqhvVsfSWNEWTenVMufu.EaYneZlGbzAQQSsVjaRVdqvRPoWk.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => zwodvHhZseqwtCKvDmliOWQNQBGe;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
				{
					zvhoDGaTMUqkKQefCxoVGkRAeuIK();
					return null;
				}
				return yRpgCyHYzfXcnBMlQjezfMsPGNHjb.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return IZAdDXmsqvYyHuaykUIxXGwhBkFBA;
			}
			set
			{
				IZAdDXmsqvYyHuaykUIxXGwhBkFBA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => eYqCqZMiLxBdRrmGJwCARDPvjpKW;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				LIMFicZGlrVJmyPgDKhUPEDzItew += value;
			}
			remove
			{
				LIMFicZGlrVJmyPgDKhUPEDzItew -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				gUiBwAOequNbudfGvYjUmWoHGLqD += value;
			}
			remove
			{
				gUiBwAOequNbudfGvYjUmWoHGLqD -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				ZxaCutCjnIEmFGmHBxcYMBWcYVPnA += value;
			}
			remove
			{
				ZxaCutCjnIEmFGmHBxcYMBWcYVPnA -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				WteBjeQyDoNPXrdbbLjEmVfYiqHy += value;
			}
			remove
			{
				WteBjeQyDoNPXrdbbLjEmVfYiqHy -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				isEgUToYckZyUJgpwmCoOLWTwwGd += value;
			}
			remove
			{
				isEgUToYckZyUJgpwmCoOLWTwwGd -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				kkyTGkKOXaZxaFLAEKSsVLgdylzQ += value;
			}
			remove
			{
				kkyTGkKOXaZxaFLAEKSsVLgdylzQ -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				iigPiLGEkDsMBiQdaaurFBSfxXXt += value;
			}
			remove
			{
				iigPiLGEkDsMBiQdaaurFBSfxXXt -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				cJUaqKLIbsKRXsCuugaVHCcsClPzA += value;
			}
			remove
			{
				cJUaqKLIbsKRXsCuugaVHCcsClPzA -= value;
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
				sjRVcFiVPbVqGcfLyzbvhbsBjanl = (Action)Delegate.Combine(sjRVcFiVPbVqGcfLyzbvhbsBjanl, value);
			}
			remove
			{
				sjRVcFiVPbVqGcfLyzbvhbsBjanl = (Action)Delegate.Remove(sjRVcFiVPbVqGcfLyzbvhbsBjanl, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				wnMyfmwyeONyGINoThMGmdMVbwTc = (Action<UpdateLoopType>)Delegate.Combine(wnMyfmwyeONyGINoThMGmdMVbwTc, value);
			}
			remove
			{
				wnMyfmwyeONyGINoThMGmdMVbwTc = (Action<UpdateLoopType>)Delegate.Remove(wnMyfmwyeONyGINoThMGmdMVbwTc, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				ItXnkSulngFHGJnEeGeUxsxOJKBHb = (Action<UpdateLoopType>)Delegate.Combine(ItXnkSulngFHGJnEeGeUxsxOJKBHb, value);
			}
			remove
			{
				ItXnkSulngFHGJnEeGeUxsxOJKBHb = (Action<UpdateLoopType>)Delegate.Remove(ItXnkSulngFHGJnEeGeUxsxOJKBHb, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				fDGHNNuVJUIjOJaqXforOFOBPecfb = (Action<UpdateLoopType>)Delegate.Combine(fDGHNNuVJUIjOJaqXforOFOBPecfb, value);
			}
			remove
			{
				fDGHNNuVJUIjOJaqXforOFOBPecfb = (Action<UpdateLoopType>)Delegate.Remove(fDGHNNuVJUIjOJaqXforOFOBPecfb, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				INyOmAHgJNNsTHwQonYZrYmcDvPE = (Action)Delegate.Combine(INyOmAHgJNNsTHwQonYZrYmcDvPE, value);
			}
			remove
			{
				INyOmAHgJNNsTHwQonYZrYmcDvPE = (Action)Delegate.Remove(INyOmAHgJNNsTHwQonYZrYmcDvPE, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				EPMoIDUcOPyaZxQmrEJXtCHzLoiT = (Action<bool>)Delegate.Combine(EPMoIDUcOPyaZxQmrEJXtCHzLoiT, value);
			}
			remove
			{
				EPMoIDUcOPyaZxQmrEJXtCHzLoiT = (Action<bool>)Delegate.Remove(EPMoIDUcOPyaZxQmrEJXtCHzLoiT, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				rpbFerDDlZrjdgIwvkrDnipHOQSk = (Action<bool>)Delegate.Combine(rpbFerDDlZrjdgIwvkrDnipHOQSk, value);
			}
			remove
			{
				rpbFerDDlZrjdgIwvkrDnipHOQSk = (Action<bool>)Delegate.Remove(rpbFerDDlZrjdgIwvkrDnipHOQSk, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				ZoPvmEUbADQvYXQopHzBUyVbFYae = (Action<bool>)Delegate.Combine(ZoPvmEUbADQvYXQopHzBUyVbFYae, value);
			}
			remove
			{
				ZoPvmEUbADQvYXQopHzBUyVbFYae = (Action<bool>)Delegate.Remove(ZoPvmEUbADQvYXQopHzBUyVbFYae, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				RCxJGFPKJtzXuaBwPMMwTvmhIooF = (Action<FullScreenMode>)Delegate.Combine(RCxJGFPKJtzXuaBwPMMwTvmhIooF, value);
			}
			remove
			{
				RCxJGFPKJtzXuaBwPMMwTvmhIooF = (Action<FullScreenMode>)Delegate.Remove(RCxJGFPKJtzXuaBwPMMwTvmhIooF, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				QfwSANpAdUMHOJPEpIWHQqWnOvY = (Action)Delegate.Combine(QfwSANpAdUMHOJPEpIWHQqWnOvY, value);
			}
			remove
			{
				QfwSANpAdUMHOJPEpIWHQqWnOvY = (Action)Delegate.Remove(QfwSANpAdUMHOJPEpIWHQqWnOvY, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				imDDXSeMiRBNNQkMtnPtLcRlVoaW = (Action<bool>)Delegate.Combine(imDDXSeMiRBNNQkMtnPtLcRlVoaW, value);
			}
			remove
			{
				imDDXSeMiRBNNQkMtnPtLcRlVoaW = (Action<bool>)Delegate.Remove(imDDXSeMiRBNNQkMtnPtLcRlVoaW, value);
			}
		}

		static ReInput()
		{
			ebHTLXhsxmLTZRGHNiViGtqjMMvk = true;
			jHxjjrTKeXLYJwFdCnwUCzMlqoLi = -1;
			_id = -1;
			ZHboBiZfYFjmyWInSJuXGssEtPKW = 0;
			HajIYQJUEAgQaGVGTtRmUcmzvAhv = UnityTouch.SJcwEdNkRfZKhXQLSeSZImZVQuiw;
			QaAhnKQmIfyuOfABThSzSKGVSynV = PlayerHelper.cWSALjICsAwABGIkhYHxdpRUCWPBb;
			bNdJpkMlQMDVkFxXvkaKwRHWxCXPA = ControllerHelper.KxqrRtEEOCfhhREzEERAgMRcgdrqA;
			OjTJLduMvcqOoDULvUhwmXXJAHks = MappingHelper.HsMuVtdEwCSOuRyvVZdeKoEnsDUb;
			OHoqmQuuipONGYdioUrGMyWwXLne = TimeHelper.xYMxdgfdOcnNIiUwFkdaiWDPEIEx;
			YWwYgZNQwIpyiEkzjpqzLdkdFUZB = ConfigHelper.epqSTDLQPnhDVvCPETdkxshajvfb;
			cJpJiGADLvinXKdwwxLiIsYeRXGH = LocalizationHelper.iNmHCAgmkqigUcaGxVFsisVcINYfb;
			lQxnuVvOtVeLMBZFGDijLLDWHPGbA = GlyphHelper.uYgwEWlAyngbzCriMYONdsYinzPf;
			LIMFicZGlrVJmyPgDKhUPEDzItew = new SafeAction<ControllerStatusChangedEventArgs>(PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.tVijjoeamkjcfYCVAvNsPhEGpQNq);
			gUiBwAOequNbudfGvYjUmWoHGLqD = new SafeAction<ControllerStatusChangedEventArgs>(PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.CpMIzgUJkqzhruBteUUcfGqZZFLD);
			ZxaCutCjnIEmFGmHBxcYMBWcYVPnA = new SafeAction<ControllerStatusChangedEventArgs>(PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.qumwCvKgiuKMnxCZvUQhwBOactWEA);
			WteBjeQyDoNPXrdbbLjEmVfYiqHy = new SafeAction(PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.NAIDRfMcYOlrtIyhHWdNirDGtPzx);
			isEgUToYckZyUJgpwmCoOLWTwwGd = new SafeAction(PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.dRgdVaaWOZBFTDemkvNGhieESaNjB);
			kkyTGkKOXaZxaFLAEKSsVLgdylzQ = new SafeAction(PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.STPqRopIFJyTtJQoOfhPPDjYienIA);
			iigPiLGEkDsMBiQdaaurFBSfxXXt = new SafeAction(PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.CMIjcfRPscyZkMYTikUceucvrInA);
			cJUaqKLIbsKRXsCuugaVHCcsClPzA = new SafeAction(PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.ofikNGlQiWIZkclcHcTyWDZGbEPCA);
			SafeDelegate.S_ExceptionHandler = PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.hgFbIsnJGjDsiUIKKeAyAjDRjFtf;
		}

		private static void qYHHheyzxoNshhjGKSriTmNDDchhA()
		{
			phjDiEmLgGbkqIQiHGNTNCLAjFWjb++;
		}

		private static void EXieoyaEgpzywKhbtgVVrgUublcQ()
		{
			phjDiEmLgGbkqIQiHGNTNCLAjFWjb--;
			if (phjDiEmLgGbkqIQiHGNTNCLAjFWjb < 0)
			{
				phjDiEmLgGbkqIQiHGNTNCLAjFWjb = 0;
			}
		}

		public static void Update()
		{
			if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
			{
				if (LMFOGkQCBvasEfLooITAJJZAxyzA.updateMode != UpdateMode.Manual)
				{
					Logger.LogError("Rewired cannot be updated manually unless Update Mode is set to Manual.");
				}
				else
				{
					zwodvHhZseqwtCKvDmliOWQNQBGe.DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
				}
			}
		}

		public static void Reset()
		{
			if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc && !(zwodvHhZseqwtCKvDmliOWQNQBGe == null))
			{
				if (xwdnJakDBTDttpblTcXyRMGUSnnR)
				{
					Logger.LogError("You are attempting to reset Rewired in the middle of its update routine, probably in an event callback. This is inherently unsafe and would lead to undefined behavior. Rewired will not be reset.");
				}
				else
				{
					zwodvHhZseqwtCKvDmliOWQNQBGe.ResetAll();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!bWLiDpyBpaCaCdEFvZPuQfbYwKffA)
			{
				return false;
			}
			if (KICjgwZNqdViWqWHSUlAnvNKQlDq != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (bVhHkeVvaIDWYCujbRbdOagnaYbp)
				{
					if (!TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.value)
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

		private static void EhEqWgXDshMgtygMXjnaHnIjtosg()
		{
			BkRCroIpoeMyHeLGqWcnDEinBjOR = UnityTools.platform;
			mAnFyadAJCYjoDIZiECAHMdurthDA = UnityTools.webplayerPlatform;
			KICjgwZNqdViWqWHSUlAnvNKQlDq = UnityTools.editorPlatform;
		}

		internal static void EqGnJgsauxIPABauZWIRtgtNlTXr(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.RNjjjtClhSaKBnMSFTjnCxDgvEBU> P_5, Action<Platform> P_6, Action<InputManager_Base.fJFRnfvsivOctcXRqtvnqVAgJpAw> P_7)
		{
			try
			{
				qYHHheyzxoNshhjGKSriTmNDDchhA();
				_id = ZHboBiZfYFjmyWInSJuXGssEtPKW;
				ZHboBiZfYFjmyWInSJuXGssEtPKW++;
				lGHKSsDOLZRlhKjLVCaFdzFWjDBc = true;
				ZXcHbgGjaHfviLFMEeOlarZfUBwaA = true;
				ubeErAeClrRvAbwCZbkRHeihdPVc = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				zwodvHhZseqwtCKvDmliOWQNQBGe = P_0;
				LMFOGkQCBvasEfLooITAJJZAxyzA = P_2;
				EhEqWgXDshMgtygMXjnaHnIjtosg();
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += AwnNTpJbnlTNhwMRncqeoLElwbdS;
				OVeeJQbujkUuYPIoeAewhTIjinMqB = P_3;
				lzZKeetYdFxEfanBzSciGQGcmdER = P_4;
				tbjnKPLmWzfqVqgMWvkScyMbeBqg = new TimerAbs(1.0);
				mhUGgtObxZJqMbMhckJouxMpIaLP = new YcUiQoqvyJacWtWlCsPgxmfedOiU();
				LocalizationManager.Initialize();
				GlyphManager.Initialize();
				P_4.faJMRTZidkItkjWNXbCIguRTTWpB();
				ThreadSafeUnityInput.Initialize();
				TRebkVxCIqhvVsfSWNEWTenVMufu = new nfPdRFniMFeSQfmQjUmErQzrHGIQA();
				if (!UnityTools.isEditor)
				{
					ebHTLXhsxmLTZRGHNiViGtqjMMvk = Application.isFocused;
				}
				TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.Set(ebHTLXhsxmLTZRGHNiViGtqjMMvk);
				TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.Use();
				if (KICjgwZNqdViWqWHSUlAnvNKQlDq != EditorPlatform.None)
				{
					TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.getValueDelegate = PmFlITEzrzPHCyxsipdsiIXuXEIP._003C_003E9.aLCrgtPHuAiRyPLZQuEluGCFkLgG;
					if (ubeErAeClrRvAbwCZbkRHeihdPVc)
					{
						ebHTLXhsxmLTZRGHNiViGtqjMMvk = XbRxOkwjfZtsfpVEPVfwKpUecQbc;
					}
					TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				EMDRvzvkrtZcftvLWRsJOGCmSBHn();
				List<ICustomPlatformInitializer> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<ICustomPlatformInitializer>(P_0.gameObject);
				if (componentsInSelfAndChildren != null)
				{
					for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
					{
						Behaviour behaviour = componentsInSelfAndChildren[i] as Behaviour;
						if (behaviour == null || !behaviour.enabled || !behaviour.gameObject.activeInHierarchy)
						{
							continue;
						}
						CustomPlatformInitOptions customPlatformInitOptions = componentsInSelfAndChildren[i].GetCustomPlatformInitOptions();
						if (customPlatformInitOptions != null)
						{
							gxyUNwMTjDnpgmNcTiXKrGmaVQZM.dFknvQbtiyoWVPOTjDbaCBHNJAxJ(customPlatformInitOptions);
							bool num = KICjgwZNqdViWqWHSUlAnvNKQlDq != EditorPlatform.None;
							P_7(new InputManager_Base.fJFRnfvsivOctcXRqtvnqVAgJpAw
							{
								xSHsbpvZYepyKuExlBitJQhzkeWG = Platform.Custom,
								gnWtJsnxrhiVVzBjUcVieEgJVfdAA = EditorPlatform.None,
								adqMeHhrTXDcAvxLRyVMHYjMkISg = WebplayerPlatform.None
							});
							EhEqWgXDshMgtygMXjnaHnIjtosg();
							mhUGgtObxZJqMbMhckJouxMpIaLP = new YcUiQoqvyJacWtWlCsPgxmfedOiU();
							if (num)
							{
								Logger.LogWarning("A custom platform is in use. All input will be managed by user-defined custom platform handling.");
							}
							break;
						}
					}
				}
				RvXeGiunEBjQhNEPGbDLqaxXWnws(P_1, P_5(), P_6);
				puvsCcoEkpSrGAnbdVqxjXrCengH = new CyDvJIEcvrEMxaEuIJlUHZHwTRMo(P_4.GetActions_Copy());
				AtHYwRgWVYrmVOsWolCxiSLKHuEp = new AIeedhFnMWGfSehpftpyUhoWcUabB(P_2, yRpgCyHYzfXcnBMlQjezfMsPGNHjb);
				BmmzPGNuZrdZxdhYqgOOCPaOiRrkA = new eRfSfYfcNJSmLRCFhmMQAqNbCscG(P_2);
				yRpgCyHYzfXcnBMlQjezfMsPGNHjb.DeviceConnectedEvent += AeQBxEAAZERetuYhTokVQCZVfqXV;
				yRpgCyHYzfXcnBMlQjezfMsPGNHjb.DeviceDisconnectedEvent += PPeCaQJbyWcWkihvwOchvoNRwxzQA;
				yRpgCyHYzfXcnBMlQjezfMsPGNHjb.UpdateControllerInfoEvent += PBpsGGwTEHDIIGEUIkPRyvhANmzk;
				AtHYwRgWVYrmVOsWolCxiSLKHuEp.wgtMEaFcbuBrERLDbhlCIrNopBmdb += JoDFlyiIarsqBfuoeTlPUzljQlQSB;
				AtHYwRgWVYrmVOsWolCxiSLKHuEp.EsWpIcPMLnEDQIbqcvLkHJATuaLeA += BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.WsXSJIfrDkQedMVvECXlvIloixZN;
				ThreadSafeUnityInput.PostInitialize();
				XvKHzpiCzsuuhLMPvvMIZCGlmkOu();
				ThreadSafeUnityInput.PostInitialize2();
				LFmtFsoKPrkHpFbTFkKPEJkaiBiC = UnityTools.GetComponent<UserDataStore>(zwodvHhZseqwtCKvDmliOWQNQBGe);
				if (LFmtFsoKPrkHpFbTFkKPEJkaiBiC != null)
				{
					LFmtFsoKPrkHpFbTFkKPEJkaiBiC.Initialize();
				}
				DFafaUJvjsFNZHgCXlCzGNhdClKHc();
				ZXcHbgGjaHfviLFMEeOlarZfUBwaA = false;
				if (ubeErAeClrRvAbwCZbkRHeihdPVc)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (cJUaqKLIbsKRXsCuugaVHCcsClPzA != null)
				{
					cJUaqKLIbsKRXsCuugaVHCcsClPzA.Invoke();
				}
			}
			catch (Exception)
			{
				lGHKSsDOLZRlhKjLVCaFdzFWjDBc = false;
				ZXcHbgGjaHfviLFMEeOlarZfUBwaA = false;
				throw;
			}
			finally
			{
				EXieoyaEgpzywKhbtgVVrgUublcQ();
			}
		}

		internal static void KLpRUESIKvhiUobkbPJQzRAcqUKS()
		{
			try
			{
				qYHHheyzxoNshhjGKSriTmNDDchhA();
				if (mhUGgtObxZJqMbMhckJouxMpIaLP != null)
				{
					mhUGgtObxZJqMbMhckJouxMpIaLP.xbXBQnaJYdpzMrWjYztaiXepVdBm();
				}
				if (configVars.deferControllerConnectedEventsOnStart)
				{
					for (int i = 0; i < AtHYwRgWVYrmVOsWolCxiSLKHuEp.eoBdhxXkFRcCpTZAvInYZHzHfdAP; i++)
					{
						Joystick joystick = AtHYwRgWVYrmVOsWolCxiSLKHuEp.aTDAanYgsxAziebHbMuodwRRawcC[i];
						JfqZwYYrwvdnhgltBDkuffcHjgQiA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
					}
				}
			}
			finally
			{
				EXieoyaEgpzywKhbtgVVrgUublcQ();
			}
		}

		internal static void yTVGTOCtwNbXTYBchmjHxWgEhOUT(UpdateLoopType P_0)
		{
			if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
			{
				return;
			}
			try
			{
				qYHHheyzxoNshhjGKSriTmNDDchhA();
				AVJuUchBIabEtigMOCWGvzQkFcxpA(P_0);
				if ((uint)P_0 <= 1u)
				{
					zlZozNQUNHvFbdXaadrcLmsOaWsB();
				}
			}
			finally
			{
				EXieoyaEgpzywKhbtgVVrgUublcQ();
			}
		}

		private static void AVJuUchBIabEtigMOCWGvzQkFcxpA(UpdateLoopType P_0)
		{
			if (TRebkVxCIqhvVsfSWNEWTenVMufu != null)
			{
				TRebkVxCIqhvVsfSWNEWTenVMufu.snChhFRaZVmntzJRgCbOBHJwsNGl();
			}
			Action<UpdateLoopType> action = wnMyfmwyeONyGINoThMGmdMVbwTc;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.BeforeTimeManagerUpdateEvent", exception);
				}
			}
			mhUGgtObxZJqMbMhckJouxMpIaLP.sqwDtxZRhtWQNFJOxDcOhXjxvdmMA(P_0);
		}

		private static void zlZozNQUNHvFbdXaadrcLmsOaWsB()
		{
			int frameCount = Time.frameCount;
			if (jHxjjrTKeXLYJwFdCnwUCzMlqoLi == frameCount)
			{
				return;
			}
			jHxjjrTKeXLYJwFdCnwUCzMlqoLi = frameCount;
			ThreadSafeUnityInput.Update();
			Action action = sjRVcFiVPbVqGcfLyzbvhbsBjanl;
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
				HandleCallbackException("ReInput.EarlyUpdateEvent", exception);
			}
		}

		internal static void ouePySsBhBHEzDmvHcTASaTXkXdEA(UpdateLoopType P_0)
		{
			if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
			{
				return;
			}
			try
			{
				qYHHheyzxoNshhjGKSriTmNDDchhA();
				if (ucOBHOPVlPlkmsMFRLZnYXOhUXOS != P_0)
				{
					ucOBHOPVlPlkmsMFRLZnYXOhUXOS = P_0;
				}
				if (editorPlatform != EditorPlatform.None)
				{
					PAVdSQbVnTrpEBhVZPbQHDlICKUTB = TRebkVxCIqhvVsfSWNEWTenVMufu.ZbhBFxdPBryTgDbSYnFUCxKhXYolb.value;
				}
				if (YsskzMYlEEMiuvhQXBiAvTqXfJiY)
				{
					if (tbjnKPLmWzfqVqgMWvkScyMbeBqg.Update())
					{
						YsskzMYlEEMiuvhQXBiAvTqXfJiY = false;
						tbjnKPLmWzfqVqgMWvkScyMbeBqg.Clear();
					}
					else
					{
						SkMixArZvRWYivDnqVxCVPWGBhBb.goPBzRIpIzZCxfCIkBOVyRmqBPZt(P_0);
					}
				}
				TRebkVxCIqhvVsfSWNEWTenVMufu.DNPzDnagpbBhFettYlsoVwbPfTMo();
				Action<UpdateLoopType> itXnkSulngFHGJnEeGeUxsxOJKBHb = ItXnkSulngFHGJnEeGeUxsxOJKBHb;
				if (itXnkSulngFHGJnEeGeUxsxOJKBHb != null)
				{
					try
					{
						itXnkSulngFHGJnEeGeUxsxOJKBHb(P_0);
					}
					catch (Exception exception)
					{
						HandleCallbackException("ReInput.UpdateStartedEvent", exception);
					}
				}
				yRpgCyHYzfXcnBMlQjezfMsPGNHjb.Update(P_0);
				if (WteBjeQyDoNPXrdbbLjEmVfYiqHy != null)
				{
					WteBjeQyDoNPXrdbbLjEmVfYiqHy.Invoke();
				}
				AtHYwRgWVYrmVOsWolCxiSLKHuEp.HxlMrDZBLqBGMkXlDvSppnBsJzst(P_0);
				Action<UpdateLoopType> action = fDGHNNuVJUIjOJaqXforOFOBPecfb;
				if (action != null)
				{
					try
					{
						action(P_0);
						return;
					}
					catch (Exception exception2)
					{
						HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
						return;
					}
				}
			}
			finally
			{
				EXieoyaEgpzywKhbtgVVrgUublcQ();
			}
		}

		internal static void CBtOcyJhbdKbVkzWbbZyVwVRgoWQ()
		{
			Action iNyOmAHgJNNsTHwQonYZrYmcDvPE = INyOmAHgJNNsTHwQonYZrYmcDvPE;
			if (iNyOmAHgJNNsTHwQonYZrYmcDvPE == null)
			{
				return;
			}
			try
			{
				qYHHheyzxoNshhjGKSriTmNDDchhA();
				iNyOmAHgJNNsTHwQonYZrYmcDvPE();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.LateUpdateEvent", exception);
			}
			finally
			{
				EXieoyaEgpzywKhbtgVVrgUublcQ();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void EditorUpdate()
		{
			if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc && ubeErAeClrRvAbwCZbkRHeihdPVc)
			{
				yTVGTOCtwNbXTYBchmjHxWgEhOUT(UpdateLoopType.Update);
				ouePySsBhBHEzDmvHcTASaTXkXdEA(UpdateLoopType.Update);
				CBtOcyJhbdKbVkzWbbZyVwVRgoWQ();
			}
		}

		internal static void yNMoMNlnCGPlyyMowscDNWJuYMAk()
		{
			if (xwdnJakDBTDttpblTcXyRMGUSnnR)
			{
				Logger.LogError("You are destroying or disabling the Rewired Input Manager while Rewired is in the middle of its update routine, probably in an event callback. This is inherently unsafe and will result in undefined behavior. You should never do this.");
			}
			if (kkyTGkKOXaZxaFLAEKSsVLgdylzQ != null)
			{
				kkyTGkKOXaZxaFLAEKSsVLgdylzQ.Invoke();
			}
			if (yRpgCyHYzfXcnBMlQjezfMsPGNHjb != null)
			{
				yRpgCyHYzfXcnBMlQjezfMsPGNHjb.OnDestroy();
			}
			MQkFiKQMTcQnCTIVFBGBAqRdifkJ();
			if (iigPiLGEkDsMBiQdaaurFBSfxXXt != null)
			{
				iigPiLGEkDsMBiQdaaurFBSfxXXt.Invoke();
				iigPiLGEkDsMBiQdaaurFBSfxXXt = null;
			}
		}

		internal static void ElfqxUPZwHBrsZPLRcTCoJwxulJb()
		{
			if (isEgUToYckZyUJgpwmCoOLWTwwGd == null)
			{
				return;
			}
			try
			{
				qYHHheyzxoNshhjGKSriTmNDDchhA();
				isEgUToYckZyUJgpwmCoOLWTwwGd.Invoke();
			}
			finally
			{
				EXieoyaEgpzywKhbtgVVrgUublcQ();
			}
		}

		internal static void pxKGFqArXoRvqvqLsgKwkiXDNBOXA(bool P_0)
		{
			ebHTLXhsxmLTZRGHNiViGtqjMMvk = P_0;
			if (KICjgwZNqdViWqWHSUlAnvNKQlDq == EditorPlatform.None && lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
			{
				TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.Set(P_0);
				TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.TriggerEvent();
			}
		}

		internal static void JgXowDDJwbNSoGRmIecNIkPBgtjeA(bool P_0)
		{
			if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
			{
				TRebkVxCIqhvVsfSWNEWTenVMufu.aIcCtMtwDudInFOJeDvTvpuqYpbb.Set(P_0);
				TRebkVxCIqhvVsfSWNEWTenVMufu.aIcCtMtwDudInFOJeDvTvpuqYpbb.TriggerEvent();
			}
		}

		internal static void OEzwaYidabTADrotgaJeffluIGWjb()
		{
			if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
			{
				return;
			}
			Action qfwSANpAdUMHOJPEpIWHQqWnOvY = QfwSANpAdUMHOJPEpIWHQqWnOvY;
			if (qfwSANpAdUMHOJPEpIWHQqWnOvY == null)
			{
				return;
			}
			try
			{
				qfwSANpAdUMHOJPEpIWHQqWnOvY();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.SceneLoadedEvent", exception);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return OVeeJQbujkUuYPIoeAewhTIjinMqB.uCrSezVgqQcFdhCzMXgktECZkvtU(bridgedController);
		}

		internal static HardwareJoystickMap bWsYGlWoxdfYJcOviJwdunJOwNcL(Guid P_0)
		{
			return OVeeJQbujkUuYPIoeAewhTIjinMqB.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap hcOivUPjVCvgdJumTCstMWcUnqVc(Guid P_0)
		{
			return OVeeJQbujkUuYPIoeAewhTIjinMqB.GetJoystickTemplate(P_0);
		}

		internal static LrxjGZteHmJMKhKqexjHMLnoIwmG maXAkWnYBdMDlaPIAIBSdMHOSOsOA(Guid P_0)
		{
			return OVeeJQbujkUuYPIoeAewhTIjinMqB.yQzIOWiihetUJHzsvHbaZyAFjHoo(P_0);
		}

		internal static IHardwareControllerTemplateMap GAvggPPNXVwflAhPBMlShcWSVTHw(Guid P_0)
		{
			return OVeeJQbujkUuYPIoeAewhTIjinMqB.GetControllerTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap ZnJGCEOArgDdtNqEvgnHLQqLZGqj(Guid P_0)
		{
			return OVeeJQbujkUuYPIoeAewhTIjinMqB.tUDsiiPKjPGsIdRlmuzjtEsBvCDN(P_0);
		}

		internal static IList<LrxjGZteHmJMKhKqexjHMLnoIwmG> YQFpRZvpJcvRUtnWqBHgfALDautZA(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = OVeeJQbujkUuYPIoeAewhTIjinMqB.GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap == null)
			{
				return EmptyObjects<LrxjGZteHmJMKhKqexjHMLnoIwmG>.EmptyReadOnlyIListT;
			}
			string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
			if (templateGuidsOrig == null || templateGuidsOrig.Length == 0)
			{
				return EmptyObjects<LrxjGZteHmJMKhKqexjHMLnoIwmG>.EmptyReadOnlyIListT;
			}
			List<LrxjGZteHmJMKhKqexjHMLnoIwmG> list = null;
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
				LrxjGZteHmJMKhKqexjHMLnoIwmG lrxjGZteHmJMKhKqexjHMLnoIwmG = maXAkWnYBdMDlaPIAIBSdMHOSOsOA(guid);
				if (lrxjGZteHmJMKhKqexjHMLnoIwmG == null)
				{
					Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
					continue;
				}
				if (list == null)
				{
					list = new List<LrxjGZteHmJMKhKqexjHMLnoIwmG>();
				}
				ListTools.AddIfUnique(list, lrxjGZteHmJMKhKqexjHMLnoIwmG);
			}
			if (list == null)
			{
				return EmptyObjects<LrxjGZteHmJMKhKqexjHMLnoIwmG>.EmptyReadOnlyIListT;
			}
			return list;
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return AtHYwRgWVYrmVOsWolCxiSLKHuEp.XPueGFlzrTTDfolLkaGbPaDbuBrh();
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

		internal static void zaSrPbuZANMpoaOetByEXhYtBLsP()
		{
			if (lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
			{
				DFafaUJvjsFNZHgCXlCzGNhdClKHc();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 6000 != UnityTools.unityVersionObj.major)
			{
				PdMxEXNyMBpEJYcZwKwOKUIrAtgm();
			}
		}

		internal static float xwQRixeVzvQtXWJFnuEAqxlqPjtQ()
		{
			return TRebkVxCIqhvVsfSWNEWTenVMufu.JSsZGeVlYxxLbpoeotyOzARXBKFCA.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
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

		private static void XvKHzpiCzsuuhLMPvvMIZCGlmkOu()
		{
			BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.afzIGRjFcjspiDBJEPgfpmoJRgTo();
			AtHYwRgWVYrmVOsWolCxiSLKHuEp.hHOxschWrmLvskqXlCUvlLVLCYXX(yRpgCyHYzfXcnBMlQjezfMsPGNHjb.GetInputDataUpdateDelegate(), lzZKeetYdFxEfanBzSciGQGcmdER.GetInputBehaviors_Copy());
			yRpgCyHYzfXcnBMlQjezfMsPGNHjb.Initialize();
		}

		private static void MQkFiKQMTcQnCTIVFBGBAqRdifkJ()
		{
			if (zwodvHhZseqwtCKvDmliOWQNQBGe != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(zwodvHhZseqwtCKvDmliOWQNQBGe);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			zwodvHhZseqwtCKvDmliOWQNQBGe = null;
			yRpgCyHYzfXcnBMlQjezfMsPGNHjb = null;
			puvsCcoEkpSrGAnbdVqxjXrCengH = null;
			if (AtHYwRgWVYrmVOsWolCxiSLKHuEp != null)
			{
				AtHYwRgWVYrmVOsWolCxiSLKHuEp.Dispose();
			}
			AtHYwRgWVYrmVOsWolCxiSLKHuEp = null;
			BmmzPGNuZrdZxdhYqgOOCPaOiRrkA = null;
			OVeeJQbujkUuYPIoeAewhTIjinMqB = null;
			if (lzZKeetYdFxEfanBzSciGQGcmdER != null)
			{
				lzZKeetYdFxEfanBzSciGQGcmdER.UmALgfynAXERyFdAwJxrNJDjSlxmA();
			}
			lzZKeetYdFxEfanBzSciGQGcmdER = null;
			LocalizationHelper.YqrnDctCuCnMyQJgGjiMeBxiXolm();
			GlyphHelper.uPMXwghrNaBkwHLNuZVOKHiPbcNY();
			LocalizationManager.Deinitialize();
			GlyphManager.Deinitialize();
			IZAdDXmsqvYyHuaykUIxXGwhBkFBA = null;
			lGHKSsDOLZRlhKjLVCaFdzFWjDBc = false;
			LMFOGkQCBvasEfLooITAJJZAxyzA = null;
			ucOBHOPVlPlkmsMFRLZnYXOhUXOS = UpdateLoopType.Update;
			JNDjFncOGfUCmPYHuDpMvGdSUJgR = false;
			BkRCroIpoeMyHeLGqWcnDEinBjOR = Platform.Windows;
			mAnFyadAJCYjoDIZiECAHMdurthDA = WebplayerPlatform.None;
			KICjgwZNqdViWqWHSUlAnvNKQlDq = EditorPlatform.None;
			YsskzMYlEEMiuvhQXBiAvTqXfJiY = false;
			tbjnKPLmWzfqVqgMWvkScyMbeBqg = null;
			mhUGgtObxZJqMbMhckJouxMpIaLP = null;
			PAVdSQbVnTrpEBhVZPbQHDlICKUTB = null;
			bVhHkeVvaIDWYCujbRbdOagnaYbp = false;
			ubeErAeClrRvAbwCZbkRHeihdPVc = false;
			ebHTLXhsxmLTZRGHNiViGtqjMMvk = true;
			jHxjjrTKeXLYJwFdCnwUCzMlqoLi = -1;
			_id = -1;
			eYqCqZMiLxBdRrmGJwCARDPvjpKW = 0;
			phjDiEmLgGbkqIQiHGNTNCLAjFWjb = 0;
			unscaledDeltaTime = 0.0;
			unscaledTime = 0.0;
			unscaledTimePrev = 0.0;
			currentFrame = 0u;
			previousFrame = 0u;
			absFrame = 0u;
			LIMFicZGlrVJmyPgDKhUPEDzItew.Clear();
			gUiBwAOequNbudfGvYjUmWoHGLqD.Clear();
			ZxaCutCjnIEmFGmHBxcYMBWcYVPnA.Clear();
			WteBjeQyDoNPXrdbbLjEmVfYiqHy.Clear();
			isEgUToYckZyUJgpwmCoOLWTwwGd.Clear();
			_ApplicationFocusChangedEvent = null;
			_ApplicationPauseChangedEvent = null;
			EPMoIDUcOPyaZxQmrEJXtCHzLoiT = null;
			rpbFerDDlZrjdgIwvkrDnipHOQSk = null;
			RCxJGFPKJtzXuaBwPMMwTvmhIooF = null;
			ZoPvmEUbADQvYXQopHzBUyVbFYae = null;
			sjRVcFiVPbVqGcfLyzbvhbsBjanl = null;
			ItXnkSulngFHGJnEeGeUxsxOJKBHb = null;
			fDGHNNuVJUIjOJaqXforOFOBPecfb = null;
			INyOmAHgJNNsTHwQonYZrYmcDvPE = null;
			kkyTGkKOXaZxaFLAEKSsVLgdylzQ = null;
			QfwSANpAdUMHOJPEpIWHQqWnOvY = null;
			imDDXSeMiRBNNQkMtnPtLcRlVoaW = null;
			VgqppVXsZkgrKaXDPWVXHcbZLNGr();
			TRebkVxCIqhvVsfSWNEWTenVMufu = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= AwnNTpJbnlTNhwMRncqeoLElwbdS;
			}
			gxyUNwMTjDnpgmNcTiXKrGmaVQZM.iGNyRlGMJDGeBiHCPJInNjZhfWLoA();
		}

		private static void KbuisPhicVzBwVTMsJhVwWgzHXCAA(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void bFlYJYdThmEVKoGokMWOVrIhvmgi()
		{
			if (!YsskzMYlEEMiuvhQXBiAvTqXfJiY)
			{
				YsskzMYlEEMiuvhQXBiAvTqXfJiY = true;
				SkMixArZvRWYivDnqVxCVPWGBhBb.swVQaUuPhfMqwTaKehsNWKcowOGS();
				SkMixArZvRWYivDnqVxCVPWGBhBb.KfqyYhOEQNciLqeyKufSyGhIcTBjA();
			}
			tbjnKPLmWzfqVqgMWvkScyMbeBqg.Start();
		}

		private static void zvhoDGaTMUqkKQefCxoVGkRAeuIK()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void AeQBxEAAZERetuYhTokVQCZVfqXV(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			AtHYwRgWVYrmVOsWolCxiSLKHuEp.tSbgJnXNlwUEfhPxrfDURxycaCuhA(P_0);
			Joystick joystick = AtHYwRgWVYrmVOsWolCxiSLKHuEp.xVDcTIAXBrOtROlyxNNOhlGQNowqA(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.CVYbSCjOJTUSKjgXsmUBFfetqFlo(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !ZXcHbgGjaHfviLFMEeOlarZfUBwaA)
				{
					JfqZwYYrwvdnhgltBDkuffcHjgQiA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void PPeCaQJbyWcWkihvwOchvoNRwxzQA(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = AtHYwRgWVYrmVOsWolCxiSLKHuEp.xVDcTIAXBrOtROlyxNNOhlGQNowqA(P_0.rewiredId);
				if (joystick != null)
				{
					AtHYwRgWVYrmVOsWolCxiSLKHuEp.gRFaXBoICFRzHDolWHkSoCyyzqVH(P_0.rewiredId);
					eTWGMgtiaPDAraHFWqieYpLFxyClA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void JfqZwYYrwvdnhgltBDkuffcHjgQiA(ControllerStatusChangedEventArgs P_0)
		{
			if (LIMFicZGlrVJmyPgDKhUPEDzItew != null)
			{
				LIMFicZGlrVJmyPgDKhUPEDzItew.Invoke(P_0);
			}
		}

		private static void JoDFlyiIarsqBfuoeTlPUzljQlQSB(ControllerStatusChangedEventArgs P_0)
		{
			if (gUiBwAOequNbudfGvYjUmWoHGLqD != null)
			{
				gUiBwAOequNbudfGvYjUmWoHGLqD.Invoke(P_0);
			}
		}

		private static void eTWGMgtiaPDAraHFWqieYpLFxyClA(ControllerStatusChangedEventArgs P_0)
		{
			if (ZxaCutCjnIEmFGmHBxcYMBWcYVPnA != null)
			{
				ZxaCutCjnIEmFGmHBxcYMBWcYVPnA.Invoke(P_0);
			}
		}

		private static void PBpsGGwTEHDIIGEUIkPRyvhANmzk(UpdateControllerInfoEventArgs P_0)
		{
			AtHYwRgWVYrmVOsWolCxiSLKHuEp.TKufUXoboKgMCCjsXhPkiHjVxHlS(P_0);
		}

		private static void KdfuZYyBznsiIeIwJyJLcnmPJaso(bool P_0)
		{
			if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
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

		private static void YshYrnMmOGZPPLaBihuKBFJvVZAlA(bool P_0)
		{
			if (!lGHKSsDOLZRlhKjLVCaFdzFWjDBc)
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

		private static void MdRIuKoBXRAOOVAjfmMGqIabikMk(bool P_0)
		{
			Action<bool> ePMoIDUcOPyaZxQmrEJXtCHzLoiT = EPMoIDUcOPyaZxQmrEJXtCHzLoiT;
			if (ePMoIDUcOPyaZxQmrEJXtCHzLoiT != null)
			{
				try
				{
					ePMoIDUcOPyaZxQmrEJXtCHzLoiT(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void DdwcoicOSgNKBUGgcYDRdANUPdGV(int P_0)
		{
			if (RCxJGFPKJtzXuaBwPMMwTvmhIooF != null)
			{
				try
				{
					RCxJGFPKJtzXuaBwPMMwTvmhIooF((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void kYJCrWmHuurBxaUYdaSUCsEFJTwJ(bool P_0)
		{
			Action<bool> action = rpbFerDDlZrjdgIwvkrDnipHOQSk;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationRunInBackgroundChangedEvent", exception);
				}
			}
		}

		private static void kibQyxsafcvzmVrjhvGtqqivATgeA(bool P_0)
		{
			eYqCqZMiLxBdRrmGJwCARDPvjpKW++;
			Action<bool> zoPvmEUbADQvYXQopHzBUyVbFYae = ZoPvmEUbADQvYXQopHzBUyVbFYae;
			if (zoPvmEUbADQvYXQopHzBUyVbFYae != null)
			{
				try
				{
					zoPvmEUbADQvYXQopHzBUyVbFYae(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void EMDRvzvkrtZcftvLWRsJOGCmSBHn()
		{
			if (TRebkVxCIqhvVsfSWNEWTenVMufu != null)
			{
				VgqppVXsZkgrKaXDPWVXHcbZLNGr();
				TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.ChangedEvent += KdfuZYyBznsiIeIwJyJLcnmPJaso;
				TRebkVxCIqhvVsfSWNEWTenVMufu.aIcCtMtwDudInFOJeDvTvpuqYpbb.ChangedEvent += YshYrnMmOGZPPLaBihuKBFJvVZAlA;
				TRebkVxCIqhvVsfSWNEWTenVMufu.IKEdQLCPBjPviokFqdXipJsNZcuRA.ChangedEvent += MdRIuKoBXRAOOVAjfmMGqIabikMk;
				TRebkVxCIqhvVsfSWNEWTenVMufu.wwDZdnkuERVSNaxvgEQDCDeGWhhE.ChangedEvent += kYJCrWmHuurBxaUYdaSUCsEFJTwJ;
				TRebkVxCIqhvVsfSWNEWTenVMufu.gaHHwJoPOlZmcebFRaHiJUZfCGiuA.ChangedEvent += DdwcoicOSgNKBUGgcYDRdANUPdGV;
				TRebkVxCIqhvVsfSWNEWTenVMufu.EaYneZlGbzAQQSsVjaRVdqvRPoWk.ChangedEvent += kibQyxsafcvzmVrjhvGtqqivATgeA;
			}
		}

		private static void VgqppVXsZkgrKaXDPWVXHcbZLNGr()
		{
			if (TRebkVxCIqhvVsfSWNEWTenVMufu != null)
			{
				TRebkVxCIqhvVsfSWNEWTenVMufu.mRmMdbahPAgJUFGYkYMcHGPHBGnh.ChangedEvent -= KdfuZYyBznsiIeIwJyJLcnmPJaso;
				TRebkVxCIqhvVsfSWNEWTenVMufu.aIcCtMtwDudInFOJeDvTvpuqYpbb.ChangedEvent -= YshYrnMmOGZPPLaBihuKBFJvVZAlA;
				TRebkVxCIqhvVsfSWNEWTenVMufu.IKEdQLCPBjPviokFqdXipJsNZcuRA.ChangedEvent -= MdRIuKoBXRAOOVAjfmMGqIabikMk;
				TRebkVxCIqhvVsfSWNEWTenVMufu.wwDZdnkuERVSNaxvgEQDCDeGWhhE.ChangedEvent -= kYJCrWmHuurBxaUYdaSUCsEFJTwJ;
				TRebkVxCIqhvVsfSWNEWTenVMufu.gaHHwJoPOlZmcebFRaHiJUZfCGiuA.ChangedEvent -= DdwcoicOSgNKBUGgcYDRdANUPdGV;
				TRebkVxCIqhvVsfSWNEWTenVMufu.EaYneZlGbzAQQSsVjaRVdqvRPoWk.ChangedEvent -= kibQyxsafcvzmVrjhvGtqqivATgeA;
			}
		}

		private static void AwnNTpJbnlTNhwMRncqeoLElwbdS(bool P_0)
		{
			Action<bool> action = imDDXSeMiRBNNQkMtnPtLcRlVoaW;
			if (action != null)
			{
				try
				{
					action(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.EditorPauseChangedEvent", exception);
				}
			}
		}

		private static void RvXeGiunEBjQhNEPGbDLqaxXWnws(Func<ConfigVars, object> P_0, UnityTools.RNjjjtClhSaKBnMSFTjnCxDgvEBU P_1, Action<Platform> P_2)
		{
			bool flag = false;
			if (P_1.UVUFKPjROWIlXKcqdVuWUEerfUCz != P_1.sLNuTTBMqzIYcbXWBGXIAgXUxAEH)
			{
				UnityTools.RNjjjtClhSaKBnMSFTjnCxDgvEBU rNjjjtClhSaKBnMSFTjnCxDgvEBU = P_1;
				rNjjjtClhSaKBnMSFTjnCxDgvEBU.UVUFKPjROWIlXKcqdVuWUEerfUCz = P_1.sLNuTTBMqzIYcbXWBGXIAgXUxAEH;
				UnityTools.oTramjqKaPSYcnltKtIiVwtyniLT(rNjjjtClhSaKBnMSFTjnCxDgvEBU);
				P_2(rNjjjtClhSaKBnMSFTjnCxDgvEBU.sLNuTTBMqzIYcbXWBGXIAgXUxAEH);
				EhEqWgXDshMgtygMXjnaHnIjtosg();
				flag = true;
			}
			if (!configVars.DoesPlatformUseFallback(P_1.sLNuTTBMqzIYcbXWBGXIAgXUxAEH, P_1.rvPqOIdVlZNkmPUcHfCrfnOBwGIL, isEditor) && !configVars.DoesPlatformUseFallback(P_1.UVUFKPjROWIlXKcqdVuWUEerfUCz, P_1.rvPqOIdVlZNkmPUcHfCrfnOBwGIL, isEditor))
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(zwodvHhZseqwtCKvDmliOWQNQBGe);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(P_1.sLNuTTBMqzIYcbXWBGXIAgXUxAEH, LMFOGkQCBvasEfLooITAJJZAxyzA) is PlatformInputManager platformInputManager)
					{
						yRpgCyHYzfXcnBMlQjezfMsPGNHjb = platformInputManager;
						return;
					}
				}
			}
			if (flag)
			{
				UnityTools.oTramjqKaPSYcnltKtIiVwtyniLT(P_1);
				P_2(P_1.sLNuTTBMqzIYcbXWBGXIAgXUxAEH);
				EhEqWgXDshMgtygMXjnaHnIjtosg();
				flag = false;
			}
			if (configVars.DoesPlatformUseFallback(BkRCroIpoeMyHeLGqWcnDEinBjOR, mAnFyadAJCYjoDIZiECAHMdurthDA, isEditor))
			{
				JNDjFncOGfUCmPYHuDpMvGdSUJgR = true;
				yRpgCyHYzfXcnBMlQjezfMsPGNHjb = new iiaEEuCRUcoidSBfrqKsFQaITgQFA(LMFOGkQCBvasEfLooITAJJZAxyzA.updateLoop);
			}
			else if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.Windows || BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.WindowsAppStore || BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.WindowsUWP || BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.OSX || BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.Linux)
			{
				yRpgCyHYzfXcnBMlQjezfMsPGNHjb = P_0(LMFOGkQCBvasEfLooITAJJZAxyzA) as PlatformInputManager;
			}
			else if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.WebGL && !isEditor)
			{
				try
				{
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = P_0(LMFOGkQCBvasEfLooITAJJZAxyzA) as PlatformInputManager;
					if (yRpgCyHYzfXcnBMlQjezfMsPGNHjb == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = null;
				}
			}
			else if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.XboxOne && !isEditor)
			{
				try
				{
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = new CustomInputManager(new XboxOneInputSource(), LMFOGkQCBvasEfLooITAJJZAxyzA.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (yRpgCyHYzfXcnBMlQjezfMsPGNHjb == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = null;
				}
			}
			else if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.PS4 && !isEditor)
			{
				try
				{
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = P_0(LMFOGkQCBvasEfLooITAJJZAxyzA) as PlatformInputManager;
					if (yRpgCyHYzfXcnBMlQjezfMsPGNHjb == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
					Logger.LogError(msg);
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = null;
				}
			}
			else if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.PS5 && !isEditor)
			{
				try
				{
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = P_0(LMFOGkQCBvasEfLooITAJJZAxyzA) as PlatformInputManager;
					if (yRpgCyHYzfXcnBMlQjezfMsPGNHjb == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
					Logger.LogError(msg2);
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = null;
				}
			}
			else if ((BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.GameCoreXboxOne || BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = P_0(LMFOGkQCBvasEfLooITAJJZAxyzA) as PlatformInputManager;
					if (yRpgCyHYzfXcnBMlQjezfMsPGNHjb == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg3)
				{
					string text = ((BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg3);
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = null;
				}
			}
			else if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.Ouya && !isEditor)
			{
				Logger.LogError("Ouya is no longer supported.");
				yRpgCyHYzfXcnBMlQjezfMsPGNHjb = null;
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.qSLOmZsIlGbabZAzlCUuQvguDNzM = P_0(LMFOGkQCBvasEfLooITAJJZAxyzA) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg4)
				{
					Logger.LogError(msg4);
				}
			}
			else if (BkRCroIpoeMyHeLGqWcnDEinBjOR == Platform.Custom)
			{
				try
				{
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = new CustomInputManager(gxyUNwMTjDnpgmNcTiXKrGmaVQZM.FTMFMsJgMfnRvBfeRitWDnminwnXb(), LMFOGkQCBvasEfLooITAJJZAxyzA.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (yRpgCyHYzfXcnBMlQjezfMsPGNHjb == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Custom platform could not be initialized due to an exception!");
					yRpgCyHYzfXcnBMlQjezfMsPGNHjb = null;
					throw;
				}
			}
			if (yRpgCyHYzfXcnBMlQjezfMsPGNHjb == null)
			{
				JNDjFncOGfUCmPYHuDpMvGdSUJgR = true;
				yRpgCyHYzfXcnBMlQjezfMsPGNHjb = new iiaEEuCRUcoidSBfrqKsFQaITgQFA(LMFOGkQCBvasEfLooITAJJZAxyzA.updateLoop);
			}
		}

		private static void DFafaUJvjsFNZHgCXlCzGNhdClKHc()
		{
			if (bVhHkeVvaIDWYCujbRbdOagnaYbp != LMFOGkQCBvasEfLooITAJJZAxyzA.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				bVhHkeVvaIDWYCujbRbdOagnaYbp = !bVhHkeVvaIDWYCujbRbdOagnaYbp;
			}
		}

		private static void PdMxEXNyMBpEJYcZwKwOKUIrAtgm()
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
