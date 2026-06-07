using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
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
			private static LocalizationHelper ngWWJQOmNpFGXgzPCBggBNDROQLkA;

			internal static LocalizationHelper YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new LocalizationHelper());

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

			internal static void ugpHHKHDpNItaDxZMwcsRnLBirPS()
			{
				ngWWJQOmNpFGXgzPCBggBNDROQLkA = null;
			}

			public void Reload()
			{
				if (CheckInitialized())
				{
					LocalizationManager.Reload();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class GlyphHelper : CodeHelper
		{
			private static GlyphHelper ngWWJQOmNpFGXgzPCBggBNDROQLkA;

			internal static GlyphHelper YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new GlyphHelper());

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

			internal static void ugpHHKHDpNItaDxZMwcsRnLBirPS()
			{
				ngWWJQOmNpFGXgzPCBggBNDROQLkA = null;
			}

			public void Reload()
			{
				if (CheckInitialized())
				{
					GlyphManager.Reload();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper ngWWJQOmNpFGXgzPCBggBNDROQLkA;

			private float XZqXqtNfGWlpaXNciGPJCkLyNFbIb = 0.7f;

			private float wsPninVNxWtdFsfHFcWBdTKrvzOx = 100f;

			internal static ConfigHelper YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.useXInput;
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
						if (CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.useXInput == value)
						{
							return;
						}
						if (value)
						{
							if (CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								Logger.LogWarning("XInput cannot be enabled with the current primary input source: " + CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("XInput cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.useXInput = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					if (UnityTools.effectivePlatform == Platform.Windows && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_useWindowsGamingInput();
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
						if (CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_useWindowsGamingInput() == value)
						{
							return;
						}
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.SetPlatformVar_useWindowsGamingInput(value);
						if (value)
						{
							if (CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
							{
								Logger.LogWarning("Windows Gaming Input cannot be enabled with the current primary input source: " + CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("Windows Gaming Input cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.updateMode;
				}
				set
				{
					if (CheckInitialized() && value != CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.updateMode)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.updateMode = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.updateLoop = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.effectivePlatform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.useXInput = true;
						}
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.osx_primaryInputSource != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.osx_primaryInputSource = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.linux_primaryInputSource != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.linux_primaryInputSource = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.windowsUWP_primaryInputSource = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return (CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return (CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useGamepadAPI != value)
					{
						platformVars_WindowsUWP.useGamepadAPI = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					if (UnityTools.effectivePlatform == Platform.OSX && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.osx_primaryInputSource == OSXStandalonePrimaryInputSource.GameController)
					{
						return true;
					}
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_useAppleGameController();
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_useAppleGameController() != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.SetPlatformVar_useAppleGameController(value);
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.xboxOne_primaryInputSource != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.xboxOne_primaryInputSource = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.ps4_primaryInputSource != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.ps4_primaryInputSource = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.webGL_primaryInputSource != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.webGL_primaryInputSource = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.alwaysUseUnityInput != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.alwaysUseUnityInput = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.SetPlatformVar_useNativeMouse(value) && dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
					{
						dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
					{
						dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
					{
						dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_joystickRefreshRate();
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
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						WLkbIgMPyNsonEqvshyltLDpNawi();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.android_supportUnknownGamepads != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.android_supportUnknownGamepads = value;
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.defaultAxisSensitivityType != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.defaultAxisSensitivityType = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.force4WayHats != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.force4WayHats = value;
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
					return XZqXqtNfGWlpaXNciGPJCkLyNFbIb;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (XZqXqtNfGWlpaXNciGPJCkLyNFbIb != value)
						{
							XZqXqtNfGWlpaXNciGPJCkLyNFbIb = value;
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
					return wsPninVNxWtdFsfHFcWBdTKrvzOx;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (wsPninVNxWtdFsfHFcWBdTKrvzOx != value)
						{
							wsPninVNxWtdFsfHFcWBdTKrvzOx = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.activateActionButtonsOnNegativeValue = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.throttleCalibrationMode != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.throttleCalibrationMode = value;
						vnBcsWOiBrsweGQzTZwXEVWsKEyb.JHJrjaTuTPIAogiDzwUgNKpOouie(value);
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.keyCombinationOverrideMode;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.keyCombinationOverrideMode != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.keyCombinationOverrideMode = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.generateKeyEventsOnKeyCombinationOverride;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.generateKeyEventsOnKeyCombinationOverride != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.generateKeyEventsOnKeyCombinationOverride = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.autoAssignJoysticks != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.autoAssignJoysticks = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.maxJoysticksPerPlayer != value)
						{
							CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.maxJoysticksPerPlayer = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.distributeJoysticksEvenly != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.distributeJoysticksEvenly = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.logLevel != value)
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.logLevel = value;
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
					return new List<EnhancedDeviceSupportDeviceType>(CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes());
				}
				set
				{
					if (CheckInitialized())
					{
						CXDUyJahCSWooVERZIbeGddBeaKq.ConfigVars.SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(value);
						if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
						{
							dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
						}
					}
				}
			}

			private ConfigHelper()
			{
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ControllerHelper : CodeHelper
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class FgiOOWAPPrxOSPBeTUHnYnceGnSiA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public FgiOOWAPPrxOSPBeTUHnYnceGnSiA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (hMnbMujJvihgLcBmOvURwCGCKZDT)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								LzfMmaQXwDJZXLEaEeBKafrExXIj();
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
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.HDiIkLFAHWUCutohMeYaOcPMdSkFA().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0084;
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0084;
							case 2:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e4;
							case 3:
								{
									hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
									break;
								}
								IL_00e4:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
									return true;
								}
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.nSVfeBTisfOodDapRLInNDpZgGbR().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
								break;
								IL_0084:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current2 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current2;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
									return true;
								}
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.HQKEnqngVrHYwwXNURtjEUNpGPjm().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e4;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current3 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current3;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 3;
								return true;
							}
							LzfMmaQXwDJZXLEaEeBKafrExXIj();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void LzfMmaQXwDJZXLEaEeBKafrExXIj()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						FgiOOWAPPrxOSPBeTUHnYnceGnSiA fgiOOWAPPrxOSPBeTUHnYnceGnSiA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							fgiOOWAPPrxOSPBeTUHnYnceGnSiA = this;
						}
						else
						{
							fgiOOWAPPrxOSPBeTUHnYnceGnSiA = new FgiOOWAPPrxOSPBeTUHnYnceGnSiA(0);
							fgiOOWAPPrxOSPBeTUHnYnceGnSiA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return fgiOOWAPPrxOSPBeTUHnYnceGnSiA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class xiTuBDhVEygvhhPBOcsyFYIvJSzz : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public xiTuBDhVEygvhhPBOcsyFYIvJSzz(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (hMnbMujJvihgLcBmOvURwCGCKZDT)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								LzfMmaQXwDJZXLEaEeBKafrExXIj();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								LLnUNXvqdTyBoeFabQRkJcqgEoAS();
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
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.YJGzfywfcOfmLwaOriTkFlfZrBbrA().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0088;
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0088;
							case 2:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e8;
							case 3:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
								goto IL_0148;
							case 4:
								{
									hMnbMujJvihgLcBmOvURwCGCKZDT = -6;
									break;
								}
								IL_00e8:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
									return true;
								}
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.zpGBymewFWBWBgEBpYYhrXVAverw().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
								goto IL_0148;
								IL_0088:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current2 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current2;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
									return true;
								}
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.rvnaOLgaxuIAxIIEbkBLpUOjqDTlA().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e8;
								IL_0148:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current3 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current3;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 3;
									return true;
								}
								LzfMmaQXwDJZXLEaEeBKafrExXIj();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.ZsGecQDEgguHLNvTsoSBGZoNXHbSA().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -6;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current4 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current4;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 4;
								return true;
							}
							LLnUNXvqdTyBoeFabQRkJcqgEoAS();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void LzfMmaQXwDJZXLEaEeBKafrExXIj()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void LLnUNXvqdTyBoeFabQRkJcqgEoAS()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						xiTuBDhVEygvhhPBOcsyFYIvJSzz xiTuBDhVEygvhhPBOcsyFYIvJSzz2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							xiTuBDhVEygvhhPBOcsyFYIvJSzz2 = this;
						}
						else
						{
							xiTuBDhVEygvhhPBOcsyFYIvJSzz2 = new xiTuBDhVEygvhhPBOcsyFYIvJSzz(0);
							xiTuBDhVEygvhhPBOcsyFYIvJSzz2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return xiTuBDhVEygvhhPBOcsyFYIvJSzz2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class dEsbpLedihWIwUkvETHlteZkMKmBA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public dEsbpLedihWIwUkvETHlteZkMKmBA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (hMnbMujJvihgLcBmOvURwCGCKZDT)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								LzfMmaQXwDJZXLEaEeBKafrExXIj();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								LLnUNXvqdTyBoeFabQRkJcqgEoAS();
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
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.hVQtYAdUnYfGfhsyRyNshpENBZgx().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0088;
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0088;
							case 2:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e8;
							case 3:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
								goto IL_0148;
							case 4:
								{
									hMnbMujJvihgLcBmOvURwCGCKZDT = -6;
									break;
								}
								IL_00e8:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
									return true;
								}
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.LQRwQnXcKswcCvRcqnVrYlUoAOqb().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
								goto IL_0148;
								IL_0088:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current2 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current2;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
									return true;
								}
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.FIphJcbQIzbEoapGNLwdDVrxfnAEA().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e8;
								IL_0148:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current3 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current3;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 3;
									return true;
								}
								LzfMmaQXwDJZXLEaEeBKafrExXIj();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.phCZPrrsaebcpTnQmPfDsUctvTmj().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -6;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current4 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current4;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 4;
								return true;
							}
							LLnUNXvqdTyBoeFabQRkJcqgEoAS();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void LzfMmaQXwDJZXLEaEeBKafrExXIj()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void LLnUNXvqdTyBoeFabQRkJcqgEoAS()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						dEsbpLedihWIwUkvETHlteZkMKmBA dEsbpLedihWIwUkvETHlteZkMKmBA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							dEsbpLedihWIwUkvETHlteZkMKmBA2 = this;
						}
						else
						{
							dEsbpLedihWIwUkvETHlteZkMKmBA2 = new dEsbpLedihWIwUkvETHlteZkMKmBA(0);
							dEsbpLedihWIwUkvETHlteZkMKmBA2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return dEsbpLedihWIwUkvETHlteZkMKmBA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class kjxuexgtHcIjfPEFPFnCccRenmvq : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public kjxuexgtHcIjfPEFPFnCccRenmvq(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (hMnbMujJvihgLcBmOvURwCGCKZDT)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								LzfMmaQXwDJZXLEaEeBKafrExXIj();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								LLnUNXvqdTyBoeFabQRkJcqgEoAS();
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
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.DBhqvXxfHjgtvrMjptbrneoAgmkW().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0088;
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0088;
							case 2:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e8;
							case 3:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
								goto IL_0148;
							case 4:
								{
									hMnbMujJvihgLcBmOvURwCGCKZDT = -6;
									break;
								}
								IL_00e8:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
									return true;
								}
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.IjcPqNgsAItaNjmrDiSLuMLCgiID().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
								goto IL_0148;
								IL_0088:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current2 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current2;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
									return true;
								}
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.rvnaOLgaxuIAxIIEbkBLpUOjqDTlA().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e8;
								IL_0148:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current3 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current3;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 3;
									return true;
								}
								LzfMmaQXwDJZXLEaEeBKafrExXIj();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.elNBQONYQdWdwwYoyBVyXZOoDjcn().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -6;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current4 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current4;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 4;
								return true;
							}
							LLnUNXvqdTyBoeFabQRkJcqgEoAS();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void LzfMmaQXwDJZXLEaEeBKafrExXIj()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void LLnUNXvqdTyBoeFabQRkJcqgEoAS()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						kjxuexgtHcIjfPEFPFnCccRenmvq kjxuexgtHcIjfPEFPFnCccRenmvq2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							kjxuexgtHcIjfPEFPFnCccRenmvq2 = this;
						}
						else
						{
							kjxuexgtHcIjfPEFPFnCccRenmvq2 = new kjxuexgtHcIjfPEFPFnCccRenmvq(0);
							kjxuexgtHcIjfPEFPFnCccRenmvq2.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return kjxuexgtHcIjfPEFPFnCccRenmvq2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class UwsPEpuOWVCgMnrnpSNALgWekiyr : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					public PollingHelper zITtixdgVFWlEnpDnrTdnZsdTFkt;

					private IEnumerator<ControllerPollingInfo> XJDKKrLVzmqpRqpsWNhTQGvqEorq;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public UwsPEpuOWVCgMnrnpSNALgWekiyr(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (hMnbMujJvihgLcBmOvURwCGCKZDT)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								LzfMmaQXwDJZXLEaEeBKafrExXIj();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								LLnUNXvqdTyBoeFabQRkJcqgEoAS();
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
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							PollingHelper pollingHelper = zITtixdgVFWlEnpDnrTdnZsdTFkt;
							switch (num)
							{
							default:
								return false;
							case 0:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.szGOZwgcZoIuVIhwTCJTGlTiHoaQ().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0088;
							case 1:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0088;
							case 2:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e8;
							case 3:
								hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
								goto IL_0148;
							case 4:
								{
									hMnbMujJvihgLcBmOvURwCGCKZDT = -6;
									break;
								}
								IL_00e8:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 2;
									return true;
								}
								DZNbUKmveIqGkvckqgFZbMBdZwyW();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.COmnSQIbXFupBKNHIxuIhGhHfUfs().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -5;
								goto IL_0148;
								IL_0088:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current2 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current2;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
									return true;
								}
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.FIphJcbQIzbEoapGNLwdDVrxfnAEA().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -4;
								goto IL_00e8;
								IL_0148:
								if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
								{
									ControllerPollingInfo current3 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
									vjnbYLtrPMftzpjohNfommerCnGo = current3;
									hMnbMujJvihgLcBmOvURwCGCKZDT = 3;
									return true;
								}
								LzfMmaQXwDJZXLEaEeBKafrExXIj();
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
								XJDKKrLVzmqpRqpsWNhTQGvqEorq = pollingHelper.UNuaRNmbTJMkLuDfTGKlemfXVJBk().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -6;
								break;
							}
							if (XJDKKrLVzmqpRqpsWNhTQGvqEorq.MoveNext())
							{
								ControllerPollingInfo current4 = XJDKKrLVzmqpRqpsWNhTQGvqEorq.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current4;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 4;
								return true;
							}
							LLnUNXvqdTyBoeFabQRkJcqgEoAS();
							XJDKKrLVzmqpRqpsWNhTQGvqEorq = null;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void DZNbUKmveIqGkvckqgFZbMBdZwyW()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void LzfMmaQXwDJZXLEaEeBKafrExXIj()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
						}
					}

					private void LLnUNXvqdTyBoeFabQRkJcqgEoAS()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (XJDKKrLVzmqpRqpsWNhTQGvqEorq != null)
						{
							XJDKKrLVzmqpRqpsWNhTQGvqEorq.Dispose();
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
						UwsPEpuOWVCgMnrnpSNALgWekiyr uwsPEpuOWVCgMnrnpSNALgWekiyr;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							uwsPEpuOWVCgMnrnpSNALgWekiyr = this;
						}
						else
						{
							uwsPEpuOWVCgMnrnpSNALgWekiyr = new UwsPEpuOWVCgMnrnpSNALgWekiyr(0);
							uwsPEpuOWVCgMnrnpSNALgWekiyr.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
						}
						return uwsPEpuOWVCgMnrnpSNALgWekiyr;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class IRdTLNGTtRJiOfBtvKmjSBOeZlPi : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public IRdTLNGTtRJiOfBtvKmjSBOeZlPi(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < BJrakWAcuniYwCCjFGDLJNzTErjEc.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = BJrakWAcuniYwCCjFGDLJNzTErjEc[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllAxes().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new IRdTLNGTtRJiOfBtvKmjSBOeZlPi(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class kDgwLEEiZqBzKAEKDpsGxvKMbpMYA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public kDgwLEEiZqBzKAEKDpsGxvKMbpMYA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < BJrakWAcuniYwCCjFGDLJNzTErjEc.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = BJrakWAcuniYwCCjFGDLJNzTErjEc[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllButtons().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new kDgwLEEiZqBzKAEKDpsGxvKMbpMYA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class nBRlDQgOBXatMOFLVqeSDPsCCjSG : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public nBRlDQgOBXatMOFLVqeSDPsCCjSG(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < BJrakWAcuniYwCCjFGDLJNzTErjEc.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = BJrakWAcuniYwCCjFGDLJNzTErjEc[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllButtonsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new nBRlDQgOBXatMOFLVqeSDPsCCjSG(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class QxQqHZcpCouhZnpVWneCUJyfekiS : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public QxQqHZcpCouhZnpVWneCUJyfekiS(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < BJrakWAcuniYwCCjFGDLJNzTErjEc.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = BJrakWAcuniYwCCjFGDLJNzTErjEc[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllElements().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new QxQqHZcpCouhZnpVWneCUJyfekiS(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class wxYhqLvpFkbNuUzGYUkVPIhXjNakA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<CustomController> BJrakWAcuniYwCCjFGDLJNzTErjEc;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public wxYhqLvpFkbNuUzGYUkVPIhXjNakA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							BJrakWAcuniYwCCjFGDLJNzTErjEc = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < BJrakWAcuniYwCCjFGDLJNzTErjEc.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = BJrakWAcuniYwCCjFGDLJNzTErjEc[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllElementsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new wxYhqLvpFkbNuUzGYUkVPIhXjNakA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class sRWyylPhrCwlHzUOsOMzzMLeoAsq : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public sRWyylPhrCwlHzUOsOMzzMLeoAsq(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < dFvibRcRDVveDJeYGllnIcmjkeicA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = dFvibRcRDVveDJeYGllnIcmjkeicA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllAxes().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new sRWyylPhrCwlHzUOsOMzzMLeoAsq(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class KHunDSjYxiuoHaeMqwCZYzLElPxg : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public KHunDSjYxiuoHaeMqwCZYzLElPxg(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < dFvibRcRDVveDJeYGllnIcmjkeicA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = dFvibRcRDVveDJeYGllnIcmjkeicA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllButtons().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new KHunDSjYxiuoHaeMqwCZYzLElPxg(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class xWsPncXVgcJruvwmhZQpzJJUFJkK : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public xWsPncXVgcJruvwmhZQpzJJUFJkK(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < dFvibRcRDVveDJeYGllnIcmjkeicA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = dFvibRcRDVveDJeYGllnIcmjkeicA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllButtonsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new xWsPncXVgcJruvwmhZQpzJJUFJkK(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class TDeDANjqqUPlgibsqvZpFDGbjGSKB : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public TDeDANjqqUPlgibsqvZpFDGbjGSKB(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < dFvibRcRDVveDJeYGllnIcmjkeicA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = dFvibRcRDVveDJeYGllnIcmjkeicA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllElements().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new TDeDANjqqUPlgibsqvZpFDGbjGSKB(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class HgndcHScdwnWMmECFXjYHrtutKZE : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private IList<Joystick> dFvibRcRDVveDJeYGllnIcmjkeicA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ControllerPollingInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public HgndcHScdwnWMmECFXjYHrtutKZE(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_0086;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							dFvibRcRDVveDJeYGllnIcmjkeicA = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_00b0;
							IL_0086:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ControllerPollingInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
							goto IL_00b0;
							IL_00b0:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < dFvibRcRDVveDJeYGllnIcmjkeicA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = dFvibRcRDVveDJeYGllnIcmjkeicA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].PollForAllElementsDown().GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							return this;
						}
						return new HgndcHScdwnWMmECFXjYHrtutKZE(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private static PollingHelper ngWWJQOmNpFGXgzPCBggBNDROQLkA;

				internal static PollingHelper YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = ypMqnEYHLwirLNfYkgLEJCqBAZoR();
					if (result.success)
					{
						return result;
					}
					result = MQqpWWBmMNwtawUzwaIpBtWdCncr();
					if (result.success)
					{
						return result;
					}
					result = cXZtpKDQPOkhyrVtgHCQnELHyciM();
					if (result.success)
					{
						return result;
					}
					result = bUTuxCoEPXUMPFracgmKxBSgClvx();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = apShCnCKWQcmOORYuxnFjmchzrnf();
					if (result.success)
					{
						return result;
					}
					result = jaSBAmrHXAJkKXNerfnGasZMuqYmA();
					if (result.success)
					{
						return result;
					}
					result = nuSreGCzpEBxxicywpMubCTEltzc();
					if (result.success)
					{
						return result;
					}
					result = McJTuSgrPGdijixFotMaQjWaNvcc();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = WnjFweDJRngPJBkZEuLYROLCbNhwB();
					if (result.success)
					{
						return result;
					}
					result = MQqpWWBmMNwtawUzwaIpBtWdCncr();
					if (result.success)
					{
						return result;
					}
					result = zaagIdowssLQhSunvoZjUnmlPsMH();
					if (result.success)
					{
						return result;
					}
					result = qgtDCoIbnLQDRiUGKwqhGwVzVeChA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = KwkFCJLsMCEPwWHxRXnzdLdGGtJb();
					if (result.success)
					{
						return result;
					}
					result = jaSBAmrHXAJkKXNerfnGasZMuqYmA();
					if (result.success)
					{
						return result;
					}
					result = XgyGPKhNoljdhVjitvWvLjnXgePrA();
					if (result.success)
					{
						return result;
					}
					result = WvdxiMtZoIIglhTzqpCqhjkfCfcJ();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					ControllerPollingInfo result = ZnNJGuqKEZfLpqZURYMmNlmNKnag();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					if (result.success)
					{
						return result;
					}
					result = zSvEifalrfODDNoABFpRPGMyCfAc();
					if (result.success)
					{
						return result;
					}
					result = navsxKifmZkqqSOQGGBVxtgCYmlG();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return ypMqnEYHLwirLNfYkgLEJCqBAZoR();
					case ControllerType.Keyboard:
						return MQqpWWBmMNwtawUzwaIpBtWdCncr();
					case ControllerType.Mouse:
						return cXZtpKDQPOkhyrVtgHCQnELHyciM();
					case ControllerType.Custom:
						return bUTuxCoEPXUMPFracgmKxBSgClvx();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return apShCnCKWQcmOORYuxnFjmchzrnf();
					case ControllerType.Keyboard:
						return jaSBAmrHXAJkKXNerfnGasZMuqYmA();
					case ControllerType.Mouse:
						return nuSreGCzpEBxxicywpMubCTEltzc();
					case ControllerType.Custom:
						return McJTuSgrPGdijixFotMaQjWaNvcc();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return WnjFweDJRngPJBkZEuLYROLCbNhwB();
					case ControllerType.Keyboard:
						return MQqpWWBmMNwtawUzwaIpBtWdCncr();
					case ControllerType.Mouse:
						return zaagIdowssLQhSunvoZjUnmlPsMH();
					case ControllerType.Custom:
						return qgtDCoIbnLQDRiUGKwqhGwVzVeChA();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return KwkFCJLsMCEPwWHxRXnzdLdGGtJb();
					case ControllerType.Keyboard:
						return jaSBAmrHXAJkKXNerfnGasZMuqYmA();
					case ControllerType.Mouse:
						return XgyGPKhNoljdhVjitvWvLjnXgePrA();
					case ControllerType.Custom:
						return WvdxiMtZoIIglhTzqpCqhjkfCfcJ();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return ZnNJGuqKEZfLpqZURYMmNlmNKnag();
					case ControllerType.Keyboard:
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					case ControllerType.Mouse:
						return zSvEifalrfODDNoABFpRPGMyCfAc();
					case ControllerType.Custom:
						return navsxKifmZkqqSOQGGBVxtgCYmlG();
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return ejYPOOdmKNdgkStTLPEdEehziMPe(controllerId);
					case ControllerType.Keyboard:
						return MQqpWWBmMNwtawUzwaIpBtWdCncr();
					case ControllerType.Mouse:
						return cXZtpKDQPOkhyrVtgHCQnELHyciM();
					case ControllerType.Custom:
						return pcIWrJebwwbQtTtbLQBGMmHbKRNk(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return wjgagChGtVvfXsLPqPkmojQZvYot(controllerId);
					case ControllerType.Keyboard:
						return jaSBAmrHXAJkKXNerfnGasZMuqYmA();
					case ControllerType.Mouse:
						return nuSreGCzpEBxxicywpMubCTEltzc();
					case ControllerType.Custom:
						return VlmwmYmdHFjTAdmoWBzuooKKrtYI(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return QtbHNHvyUsymtObBvGbKbAwvotMs(controllerId);
					case ControllerType.Keyboard:
						return MQqpWWBmMNwtawUzwaIpBtWdCncr();
					case ControllerType.Mouse:
						return zaagIdowssLQhSunvoZjUnmlPsMH();
					case ControllerType.Custom:
						return WuTMFGBEyfuDrPFVvtdmAAlAbtzX(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return UYzfhPjkfANhXsiNxjrRNRCZCSvS(controllerId);
					case ControllerType.Keyboard:
						return jaSBAmrHXAJkKXNerfnGasZMuqYmA();
					case ControllerType.Mouse:
						return XgyGPKhNoljdhVjitvWvLjnXgePrA();
					case ControllerType.Custom:
						return PUiPdtWiaZgHfkqLAnzmqCjSEUemA(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return vGGfpHRXpyfrjfCYHWHBClQHSjxw(controllerId);
					case ControllerType.Keyboard:
						return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
					case ControllerType.Mouse:
						return zSvEifalrfODDNoABFpRPGMyCfAc();
					case ControllerType.Custom:
						return vGMNcClDtvYQoZbjbFcrXFYlAPrH(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return new kjxuexgtHcIjfPEFPFnCccRenmvq(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return new UwsPEpuOWVCgMnrnpSNALgWekiyr(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return new xiTuBDhVEygvhhPBOcsyFYIvJSzz(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return new dEsbpLedihWIwUkvETHlteZkMKmBA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return new FgiOOWAPPrxOSPBeTUHnYnceGnSiA(-2)
					{
						zITtixdgVFWlEnpDnrTdnZsdTFkt = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return OOizvKrkGiVWXuZbcCbkwaApPqTl(controllerId);
					case ControllerType.Keyboard:
						return rvnaOLgaxuIAxIIEbkBLpUOjqDTlA();
					case ControllerType.Mouse:
						return IjcPqNgsAItaNjmrDiSLuMLCgiID();
					case ControllerType.Custom:
						return zAapFwGrVVOlKsDdYBSOHHBullnn(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElementsDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return OlhEuGAcuZKqzlylgMuHUHYzSNlbA(controllerId);
					case ControllerType.Keyboard:
						return FIphJcbQIzbEoapGNLwdDVrxfnAEA();
					case ControllerType.Mouse:
						return COmnSQIbXFupBKNHIxuIhGhHfUfs();
					case ControllerType.Custom:
						return QQGCgJbWECVeNSoTJFWiQVgIGmDaA(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtons(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return wYPIvrDAtQElNWiMpRXhNEKPNKLV(controllerId);
					case ControllerType.Keyboard:
						return rvnaOLgaxuIAxIIEbkBLpUOjqDTlA();
					case ControllerType.Mouse:
						return zpGBymewFWBWBgEBpYYhrXVAverw();
					case ControllerType.Custom:
						return RMxPteBcefeLaBVGhREANIpFLCKv(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllButtonsDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return NsvEfTnPPlFSKbVxATgDNODWrFJxA(controllerId);
					case ControllerType.Keyboard:
						return FIphJcbQIzbEoapGNLwdDVrxfnAEA();
					case ControllerType.Mouse:
						return LQRwQnXcKswcCvRcqnVrYlUoAOqb();
					case ControllerType.Custom:
						return DGpfocvmQoPUZwAXowPlQvrQgfvD(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllAxes(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return NViOXQCFiQDgDArKDDqnjkaZTXUGA(controllerId);
					case ControllerType.Keyboard:
						return new List<ControllerPollingInfo>();
					case ControllerType.Mouse:
						return HQKEnqngVrHYwwXNURtjEUNpGPjm();
					case ControllerType.Custom:
						return AOQiAvLtdvAreSrKGTzeNrBUAMTB(controllerId);
					default:
						throw new NotImplementedException();
					}
				}

				private ControllerPollingInfo ypMqnEYHLwirLNfYkgLEJCqBAZoR()
				{
					IList<Joystick> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo apShCnCKWQcmOORYuxnFjmchzrnf()
				{
					IList<Joystick> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo WnjFweDJRngPJBkZEuLYROLCbNhwB()
				{
					IList<Joystick> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo KwkFCJLsMCEPwWHxRXnzdLdGGtJb()
				{
					IList<Joystick> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo ZnNJGuqKEZfLpqZURYMmNlmNKnag()
				{
					IList<Joystick> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo ejYPOOdmKNdgkStTLPEdEehziMPe(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo wjgagChGtVvfXsLPqPkmojQZvYot(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo QtbHNHvyUsymtObBvGbKbAwvotMs(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo UYzfhPjkfANhXsiNxjrRNRCZCSvS(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo vGGfpHRXpyfrjfCYHWHBClQHSjxw(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo MQqpWWBmMNwtawUzwaIpBtWdCncr()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo jaSBAmrHXAJkKXNerfnGasZMuqYmA()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo cXZtpKDQPOkhyrVtgHCQnELHyciM()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo nuSreGCzpEBxxicywpMubCTEltzc()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo zaagIdowssLQhSunvoZjUnmlPsMH()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo XgyGPKhNoljdhVjitvWvLjnXgePrA()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo zSvEifalrfODDNoABFpRPGMyCfAc()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo bUTuxCoEPXUMPFracgmKxBSgClvx()
				{
					IList<CustomController> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo McJTuSgrPGdijixFotMaQjWaNvcc()
				{
					IList<CustomController> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo qgtDCoIbnLQDRiUGKwqhGwVzVeChA()
				{
					IList<CustomController> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo WvdxiMtZoIIglhTzqpCqhjkfCfcJ()
				{
					IList<CustomController> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo navsxKifmZkqqSOQGGBVxtgCYmlG()
				{
					IList<CustomController> list = vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo pcIWrJebwwbQtTtbLQBGMmHbKRNk(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo VlmwmYmdHFjTAdmoWBzuooKKrtYI(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo WuTMFGBEyfuDrPFVvtdmAAlAbtzX(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo PUiPdtWiaZgHfkqLAnzmqCjSEUemA(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private ControllerPollingInfo vGMNcClDtvYQoZbjbFcrXFYlAPrH(int P_0)
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
				}

				private IEnumerable<ControllerPollingInfo> DBhqvXxfHjgtvrMjptbrneoAgmkW()
				{
					return new TDeDANjqqUPlgibsqvZpFDGbjGSKB(-2);
				}

				private IEnumerable<ControllerPollingInfo> szGOZwgcZoIuVIhwTCJTGlTiHoaQ()
				{
					return new HgndcHScdwnWMmECFXjYHrtutKZE(-2);
				}

				private IEnumerable<ControllerPollingInfo> YJGzfywfcOfmLwaOriTkFlfZrBbrA()
				{
					return new KHunDSjYxiuoHaeMqwCZYzLElPxg(-2);
				}

				private IEnumerable<ControllerPollingInfo> hVQtYAdUnYfGfhsyRyNshpENBZgx()
				{
					return new xWsPncXVgcJruvwmhZQpzJJUFJkK(-2);
				}

				private IEnumerable<ControllerPollingInfo> HDiIkLFAHWUCutohMeYaOcPMdSkFA()
				{
					return new sRWyylPhrCwlHzUOsOMzzMLeoAsq(-2);
				}

				private IEnumerable<ControllerPollingInfo> OOizvKrkGiVWXuZbcCbkwaApPqTl(int P_0)
				{
					Joystick joystick = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> OlhEuGAcuZKqzlylgMuHUHYzSNlbA(int P_0)
				{
					Joystick joystick = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> wYPIvrDAtQElNWiMpRXhNEKPNKLV(int P_0)
				{
					Joystick joystick = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> NsvEfTnPPlFSKbVxATgDNODWrFJxA(int P_0)
				{
					Joystick joystick = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> NViOXQCFiQDgDArKDDqnjkaZTXUGA(int P_0)
				{
					Joystick joystick = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> rvnaOLgaxuIAxIIEbkBLpUOjqDTlA()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> FIphJcbQIzbEoapGNLwdDVrxfnAEA()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> IjcPqNgsAItaNjmrDiSLuMLCgiID()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> COmnSQIbXFupBKNHIxuIhGhHfUfs()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> zpGBymewFWBWBgEBpYYhrXVAverw()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> LQRwQnXcKswcCvRcqnVrYlUoAOqb()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> HQKEnqngVrHYwwXNURtjEUNpGPjm()
				{
					return ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.Mouse.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> elNBQONYQdWdwwYoyBVyXZOoDjcn()
				{
					return new QxQqHZcpCouhZnpVWneCUJyfekiS(-2);
				}

				private IEnumerable<ControllerPollingInfo> UNuaRNmbTJMkLuDfTGKlemfXVJBk()
				{
					return new wxYhqLvpFkbNuUzGYUkVPIhXjNakA(-2);
				}

				private IEnumerable<ControllerPollingInfo> ZsGecQDEgguHLNvTsoSBGZoNXHbSA()
				{
					return new kDgwLEEiZqBzKAEKDpsGxvKMbpMYA(-2);
				}

				private IEnumerable<ControllerPollingInfo> phCZPrrsaebcpTnQmPfDsUctvTmj()
				{
					return new nBRlDQgOBXatMOFLVqeSDPsCCjSG(-2);
				}

				private IEnumerable<ControllerPollingInfo> nSVfeBTisfOodDapRLInNDpZgGbR()
				{
					return new IRdTLNGTtRJiOfBtvKmjSBOeZlPi(-2);
				}

				private IEnumerable<ControllerPollingInfo> zAapFwGrVVOlKsDdYBSOHHBullnn(int P_0)
				{
					CustomController customController = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> QQGCgJbWECVeNSoTJFWiQVgIGmDaA(int P_0)
				{
					CustomController customController = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> RMxPteBcefeLaBVGhREANIpFLCKv(int P_0)
				{
					CustomController customController = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> DGpfocvmQoPUZwAXowPlQvrQgfvD(int P_0)
				{
					CustomController customController = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> AOQiAvLtdvAreSrKGTzeNrBUAMTB(int P_0)
				{
					CustomController customController = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA.GetCustomController(P_0);
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
				private sealed class awffICyrJkpkftrLOeFyKLyymeQE : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int rOGYakJhiyazzgiwiEnxeHJcfiZrb;

					public int vwqbDnGSuidIWeMoguuPgcjXMmpaA;

					private ActionElementMap yChnYOSSLFUSaChNzFvrDutuRmpk;

					public ActionElementMap irfbfPdSapgmElNrHAavHgDhtrXec;

					private bool zHhtkRzCTRnxWXUubqRfdGGhGEUCA;

					public bool imaqOxAMTpGDRsORarKkbVchAkfT;

					private int JMclHNzguIWZrgtWkveVPuuQQUBf;

					public int IWzaGxCHKDwjdPAWTqffsANtqNC;

					private CustomControllerMap iMOTycYwgQJAOdjETFGjwKllT;

					public CustomControllerMap DajLgnbDjcVFpkPbeLaDtkbBtLmc;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private IList<Player> bvwnJyYDJBkYePyTNCdvqaDkFOGA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public awffICyrJkpkftrLOeFyKLyymeQE(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00e2;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (rOGYakJhiyazzgiwiEnxeHJcfiZrb < 0 || yChnYOSSLFUSaChNzFvrDutuRmpk == null)
							{
								return false;
							}
							bvwnJyYDJBkYePyTNCdvqaDkFOGA = (zHhtkRzCTRnxWXUubqRfdGGhGEUCA ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_010c;
							IL_010c:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < bvwnJyYDJBkYePyTNCdvqaDkFOGA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = bvwnJyYDJBkYePyTNCdvqaDkFOGA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, JMclHNzguIWZrgtWkveVPuuQQUBf, iMOTycYwgQJAOdjETFGjwKllT, yChnYOSSLFUSaChNzFvrDutuRmpk, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN).GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00e2;
							}
							return false;
							IL_00e2:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						awffICyrJkpkftrLOeFyKLyymeQE awffICyrJkpkftrLOeFyKLyymeQE2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							awffICyrJkpkftrLOeFyKLyymeQE2 = this;
						}
						else
						{
							awffICyrJkpkftrLOeFyKLyymeQE2 = new awffICyrJkpkftrLOeFyKLyymeQE(0);
						}
						awffICyrJkpkftrLOeFyKLyymeQE2.rOGYakJhiyazzgiwiEnxeHJcfiZrb = vwqbDnGSuidIWeMoguuPgcjXMmpaA;
						awffICyrJkpkftrLOeFyKLyymeQE2.JMclHNzguIWZrgtWkveVPuuQQUBf = IWzaGxCHKDwjdPAWTqffsANtqNC;
						awffICyrJkpkftrLOeFyKLyymeQE2.iMOTycYwgQJAOdjETFGjwKllT = DajLgnbDjcVFpkPbeLaDtkbBtLmc;
						awffICyrJkpkftrLOeFyKLyymeQE2.yChnYOSSLFUSaChNzFvrDutuRmpk = irfbfPdSapgmElNrHAavHgDhtrXec;
						awffICyrJkpkftrLOeFyKLyymeQE2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						awffICyrJkpkftrLOeFyKLyymeQE2.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						awffICyrJkpkftrLOeFyKLyymeQE2.zHhtkRzCTRnxWXUubqRfdGGhGEUCA = imaqOxAMTpGDRsORarKkbVchAkfT;
						return awffICyrJkpkftrLOeFyKLyymeQE2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class TBTPBEPaSBxWdEnPcWwzUlcQqnsE : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private ElementAssignmentConflictCheck xUNdiOEYYDhoZDkmZzHJeiDGhvmAA;

					public ElementAssignmentConflictCheck kFSVgsWFZyqOFXGOFRPLWNAXMqBB;

					private bool zHhtkRzCTRnxWXUubqRfdGGhGEUCA;

					public bool imaqOxAMTpGDRsORarKkbVchAkfT;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private IList<Player> bvwnJyYDJBkYePyTNCdvqaDkFOGA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public TBTPBEPaSBxWdEnPcWwzUlcQqnsE(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00df;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.playerId < 0 || xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							bvwnJyYDJBkYePyTNCdvqaDkFOGA = (zHhtkRzCTRnxWXUubqRfdGGhGEUCA ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0109;
							IL_0109:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < bvwnJyYDJBkYePyTNCdvqaDkFOGA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = bvwnJyYDJBkYePyTNCdvqaDkFOGA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].controllers.conflictChecking.ElementAssignmentConflicts(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN).GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						TBTPBEPaSBxWdEnPcWwzUlcQqnsE tBTPBEPaSBxWdEnPcWwzUlcQqnsE;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							tBTPBEPaSBxWdEnPcWwzUlcQqnsE = this;
						}
						else
						{
							tBTPBEPaSBxWdEnPcWwzUlcQqnsE = new TBTPBEPaSBxWdEnPcWwzUlcQqnsE(0);
						}
						tBTPBEPaSBxWdEnPcWwzUlcQqnsE.xUNdiOEYYDhoZDkmZzHJeiDGhvmAA = kFSVgsWFZyqOFXGOFRPLWNAXMqBB;
						tBTPBEPaSBxWdEnPcWwzUlcQqnsE.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						tBTPBEPaSBxWdEnPcWwzUlcQqnsE.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						tBTPBEPaSBxWdEnPcWwzUlcQqnsE.zHhtkRzCTRnxWXUubqRfdGGhGEUCA = imaqOxAMTpGDRsORarKkbVchAkfT;
						return tBTPBEPaSBxWdEnPcWwzUlcQqnsE;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class xVhywIzshuVQoxJInWYnQyumoRHh : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int rOGYakJhiyazzgiwiEnxeHJcfiZrb;

					public int vwqbDnGSuidIWeMoguuPgcjXMmpaA;

					private ActionElementMap yChnYOSSLFUSaChNzFvrDutuRmpk;

					public ActionElementMap irfbfPdSapgmElNrHAavHgDhtrXec;

					private bool zHhtkRzCTRnxWXUubqRfdGGhGEUCA;

					public bool imaqOxAMTpGDRsORarKkbVchAkfT;

					private int JMclHNzguIWZrgtWkveVPuuQQUBf;

					public int IWzaGxCHKDwjdPAWTqffsANtqNC;

					private JoystickMap iYPWnSOIZMhoRIrtffHSidvpgvvP;

					public JoystickMap nHQaDnBIpPavKeTDoaJgzRaNsBFpA;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private IList<Player> bvwnJyYDJBkYePyTNCdvqaDkFOGA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public xVhywIzshuVQoxJInWYnQyumoRHh(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00e1;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (rOGYakJhiyazzgiwiEnxeHJcfiZrb < 0 || yChnYOSSLFUSaChNzFvrDutuRmpk == null)
							{
								return false;
							}
							bvwnJyYDJBkYePyTNCdvqaDkFOGA = (zHhtkRzCTRnxWXUubqRfdGGhGEUCA ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_010b;
							IL_010b:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < bvwnJyYDJBkYePyTNCdvqaDkFOGA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = bvwnJyYDJBkYePyTNCdvqaDkFOGA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, JMclHNzguIWZrgtWkveVPuuQQUBf, iYPWnSOIZMhoRIrtffHSidvpgvvP, yChnYOSSLFUSaChNzFvrDutuRmpk, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN).GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00e1;
							}
							return false;
							IL_00e1:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						xVhywIzshuVQoxJInWYnQyumoRHh xVhywIzshuVQoxJInWYnQyumoRHh2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							xVhywIzshuVQoxJInWYnQyumoRHh2 = this;
						}
						else
						{
							xVhywIzshuVQoxJInWYnQyumoRHh2 = new xVhywIzshuVQoxJInWYnQyumoRHh(0);
						}
						xVhywIzshuVQoxJInWYnQyumoRHh2.rOGYakJhiyazzgiwiEnxeHJcfiZrb = vwqbDnGSuidIWeMoguuPgcjXMmpaA;
						xVhywIzshuVQoxJInWYnQyumoRHh2.JMclHNzguIWZrgtWkveVPuuQQUBf = IWzaGxCHKDwjdPAWTqffsANtqNC;
						xVhywIzshuVQoxJInWYnQyumoRHh2.iYPWnSOIZMhoRIrtffHSidvpgvvP = nHQaDnBIpPavKeTDoaJgzRaNsBFpA;
						xVhywIzshuVQoxJInWYnQyumoRHh2.yChnYOSSLFUSaChNzFvrDutuRmpk = irfbfPdSapgmElNrHAavHgDhtrXec;
						xVhywIzshuVQoxJInWYnQyumoRHh2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						xVhywIzshuVQoxJInWYnQyumoRHh2.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						xVhywIzshuVQoxJInWYnQyumoRHh2.zHhtkRzCTRnxWXUubqRfdGGhGEUCA = imaqOxAMTpGDRsORarKkbVchAkfT;
						return xVhywIzshuVQoxJInWYnQyumoRHh2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class SCTbDhwpzDulYvJGSDoWeWsUsjBoA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private ElementAssignmentConflictCheck xUNdiOEYYDhoZDkmZzHJeiDGhvmAA;

					public ElementAssignmentConflictCheck kFSVgsWFZyqOFXGOFRPLWNAXMqBB;

					private bool zHhtkRzCTRnxWXUubqRfdGGhGEUCA;

					public bool imaqOxAMTpGDRsORarKkbVchAkfT;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private IList<Player> bvwnJyYDJBkYePyTNCdvqaDkFOGA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public SCTbDhwpzDulYvJGSDoWeWsUsjBoA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00df;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.playerId < 0 || xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							bvwnJyYDJBkYePyTNCdvqaDkFOGA = (zHhtkRzCTRnxWXUubqRfdGGhGEUCA ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0109;
							IL_0109:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < bvwnJyYDJBkYePyTNCdvqaDkFOGA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = bvwnJyYDJBkYePyTNCdvqaDkFOGA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].controllers.conflictChecking.ElementAssignmentConflicts(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN).GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						SCTbDhwpzDulYvJGSDoWeWsUsjBoA sCTbDhwpzDulYvJGSDoWeWsUsjBoA;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							sCTbDhwpzDulYvJGSDoWeWsUsjBoA = this;
						}
						else
						{
							sCTbDhwpzDulYvJGSDoWeWsUsjBoA = new SCTbDhwpzDulYvJGSDoWeWsUsjBoA(0);
						}
						sCTbDhwpzDulYvJGSDoWeWsUsjBoA.xUNdiOEYYDhoZDkmZzHJeiDGhvmAA = kFSVgsWFZyqOFXGOFRPLWNAXMqBB;
						sCTbDhwpzDulYvJGSDoWeWsUsjBoA.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						sCTbDhwpzDulYvJGSDoWeWsUsjBoA.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						sCTbDhwpzDulYvJGSDoWeWsUsjBoA.zHhtkRzCTRnxWXUubqRfdGGhGEUCA = imaqOxAMTpGDRsORarKkbVchAkfT;
						return sCTbDhwpzDulYvJGSDoWeWsUsjBoA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class FGNIZQZRVHLxBBvvXStRxipwCfGe : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int rOGYakJhiyazzgiwiEnxeHJcfiZrb;

					public int vwqbDnGSuidIWeMoguuPgcjXMmpaA;

					private ActionElementMap yChnYOSSLFUSaChNzFvrDutuRmpk;

					public ActionElementMap irfbfPdSapgmElNrHAavHgDhtrXec;

					private bool zHhtkRzCTRnxWXUubqRfdGGhGEUCA;

					public bool imaqOxAMTpGDRsORarKkbVchAkfT;

					private KeyboardMap KFEffaBYYGCTXNnfdPMkYoSZhYif;

					public KeyboardMap RubNFUcoUOtDYcswjvhhJurRvfEI;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private IList<Player> bvwnJyYDJBkYePyTNCdvqaDkFOGA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public FGNIZQZRVHLxBBvvXStRxipwCfGe(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00dc;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (rOGYakJhiyazzgiwiEnxeHJcfiZrb < 0 || yChnYOSSLFUSaChNzFvrDutuRmpk == null)
							{
								return false;
							}
							bvwnJyYDJBkYePyTNCdvqaDkFOGA = (zHhtkRzCTRnxWXUubqRfdGGhGEUCA ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0106;
							IL_0106:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < bvwnJyYDJBkYePyTNCdvqaDkFOGA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = bvwnJyYDJBkYePyTNCdvqaDkFOGA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, KFEffaBYYGCTXNnfdPMkYoSZhYif, yChnYOSSLFUSaChNzFvrDutuRmpk, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN).GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						FGNIZQZRVHLxBBvvXStRxipwCfGe fGNIZQZRVHLxBBvvXStRxipwCfGe;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							fGNIZQZRVHLxBBvvXStRxipwCfGe = this;
						}
						else
						{
							fGNIZQZRVHLxBBvvXStRxipwCfGe = new FGNIZQZRVHLxBBvvXStRxipwCfGe(0);
						}
						fGNIZQZRVHLxBBvvXStRxipwCfGe.rOGYakJhiyazzgiwiEnxeHJcfiZrb = vwqbDnGSuidIWeMoguuPgcjXMmpaA;
						fGNIZQZRVHLxBBvvXStRxipwCfGe.KFEffaBYYGCTXNnfdPMkYoSZhYif = RubNFUcoUOtDYcswjvhhJurRvfEI;
						fGNIZQZRVHLxBBvvXStRxipwCfGe.yChnYOSSLFUSaChNzFvrDutuRmpk = irfbfPdSapgmElNrHAavHgDhtrXec;
						fGNIZQZRVHLxBBvvXStRxipwCfGe.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						fGNIZQZRVHLxBBvvXStRxipwCfGe.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						fGNIZQZRVHLxBBvvXStRxipwCfGe.zHhtkRzCTRnxWXUubqRfdGGhGEUCA = imaqOxAMTpGDRsORarKkbVchAkfT;
						return fGNIZQZRVHLxBBvvXStRxipwCfGe;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class yByBFkeUxmQOhqLUXXNaEsSdzlDv : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private ElementAssignmentConflictCheck xUNdiOEYYDhoZDkmZzHJeiDGhvmAA;

					public ElementAssignmentConflictCheck kFSVgsWFZyqOFXGOFRPLWNAXMqBB;

					private bool zHhtkRzCTRnxWXUubqRfdGGhGEUCA;

					public bool imaqOxAMTpGDRsORarKkbVchAkfT;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private IList<Player> bvwnJyYDJBkYePyTNCdvqaDkFOGA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public yByBFkeUxmQOhqLUXXNaEsSdzlDv(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00df;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.playerId < 0 || xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.elementAssignmentType != ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							bvwnJyYDJBkYePyTNCdvqaDkFOGA = (zHhtkRzCTRnxWXUubqRfdGGhGEUCA ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0109;
							IL_0109:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < bvwnJyYDJBkYePyTNCdvqaDkFOGA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = bvwnJyYDJBkYePyTNCdvqaDkFOGA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].controllers.conflictChecking.ElementAssignmentConflicts(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN).GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						yByBFkeUxmQOhqLUXXNaEsSdzlDv yByBFkeUxmQOhqLUXXNaEsSdzlDv2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							yByBFkeUxmQOhqLUXXNaEsSdzlDv2 = this;
						}
						else
						{
							yByBFkeUxmQOhqLUXXNaEsSdzlDv2 = new yByBFkeUxmQOhqLUXXNaEsSdzlDv(0);
						}
						yByBFkeUxmQOhqLUXXNaEsSdzlDv2.xUNdiOEYYDhoZDkmZzHJeiDGhvmAA = kFSVgsWFZyqOFXGOFRPLWNAXMqBB;
						yByBFkeUxmQOhqLUXXNaEsSdzlDv2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						yByBFkeUxmQOhqLUXXNaEsSdzlDv2.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						yByBFkeUxmQOhqLUXXNaEsSdzlDv2.zHhtkRzCTRnxWXUubqRfdGGhGEUCA = imaqOxAMTpGDRsORarKkbVchAkfT;
						return yByBFkeUxmQOhqLUXXNaEsSdzlDv2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class tsewmwBRmVlsjxeoWqsYmcDQeXkiA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private int rOGYakJhiyazzgiwiEnxeHJcfiZrb;

					public int vwqbDnGSuidIWeMoguuPgcjXMmpaA;

					private ActionElementMap yChnYOSSLFUSaChNzFvrDutuRmpk;

					public ActionElementMap irfbfPdSapgmElNrHAavHgDhtrXec;

					private bool zHhtkRzCTRnxWXUubqRfdGGhGEUCA;

					public bool imaqOxAMTpGDRsORarKkbVchAkfT;

					private MouseMap UjUfAveDkfTBDnmJdmZdtRCUgqEuA;

					public MouseMap kZgpIDaMMeixjZRCrsaULANYCcScA;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private IList<Player> bvwnJyYDJBkYePyTNCdvqaDkFOGA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public tsewmwBRmVlsjxeoWqsYmcDQeXkiA(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00dc;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (rOGYakJhiyazzgiwiEnxeHJcfiZrb < 0 || yChnYOSSLFUSaChNzFvrDutuRmpk == null)
							{
								return false;
							}
							bvwnJyYDJBkYePyTNCdvqaDkFOGA = (zHhtkRzCTRnxWXUubqRfdGGhGEUCA ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0106;
							IL_0106:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < bvwnJyYDJBkYePyTNCdvqaDkFOGA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = bvwnJyYDJBkYePyTNCdvqaDkFOGA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, UjUfAveDkfTBDnmJdmZdtRCUgqEuA, yChnYOSSLFUSaChNzFvrDutuRmpk, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN).GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						tsewmwBRmVlsjxeoWqsYmcDQeXkiA tsewmwBRmVlsjxeoWqsYmcDQeXkiA2;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							tsewmwBRmVlsjxeoWqsYmcDQeXkiA2 = this;
						}
						else
						{
							tsewmwBRmVlsjxeoWqsYmcDQeXkiA2 = new tsewmwBRmVlsjxeoWqsYmcDQeXkiA(0);
						}
						tsewmwBRmVlsjxeoWqsYmcDQeXkiA2.rOGYakJhiyazzgiwiEnxeHJcfiZrb = vwqbDnGSuidIWeMoguuPgcjXMmpaA;
						tsewmwBRmVlsjxeoWqsYmcDQeXkiA2.UjUfAveDkfTBDnmJdmZdtRCUgqEuA = kZgpIDaMMeixjZRCrsaULANYCcScA;
						tsewmwBRmVlsjxeoWqsYmcDQeXkiA2.yChnYOSSLFUSaChNzFvrDutuRmpk = irfbfPdSapgmElNrHAavHgDhtrXec;
						tsewmwBRmVlsjxeoWqsYmcDQeXkiA2.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						tsewmwBRmVlsjxeoWqsYmcDQeXkiA2.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						tsewmwBRmVlsjxeoWqsYmcDQeXkiA2.zHhtkRzCTRnxWXUubqRfdGGhGEUCA = imaqOxAMTpGDRsORarKkbVchAkfT;
						return tsewmwBRmVlsjxeoWqsYmcDQeXkiA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class QgKbltCjIllMiGOyeGXQBpYYpMDec : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int hMnbMujJvihgLcBmOvURwCGCKZDT;

					private ElementAssignmentConflictInfo vjnbYLtrPMftzpjohNfommerCnGo;

					private int AyagikQIJAatoHzFlyaifyWyaTktA;

					private ElementAssignmentConflictCheck xUNdiOEYYDhoZDkmZzHJeiDGhvmAA;

					public ElementAssignmentConflictCheck kFSVgsWFZyqOFXGOFRPLWNAXMqBB;

					private bool zHhtkRzCTRnxWXUubqRfdGGhGEUCA;

					public bool imaqOxAMTpGDRsORarKkbVchAkfT;

					private bool bbJFyfBYztkbqyDKwjcJJfiCvWSr;

					public bool sArRKCvKaVOofQinfjRFdePmZRhGA;

					private bool BdJzrReMTTznOknxLtXkjkYMDbiN;

					public bool gulvZjHrAMBmzINGmCvcajRlsSDW;

					private IList<Player> bvwnJyYDJBkYePyTNCdvqaDkFOGA;

					private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

					private IEnumerator<ElementAssignmentConflictInfo> BhdWnHwETjTwooLnNokUmKQRiiPK;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return vjnbYLtrPMftzpjohNfommerCnGo;
						}
					}

					[DebuggerHidden]
					public QgKbltCjIllMiGOyeGXQBpYYpMDec(int P_0)
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
						AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MoEEbuduDHenVCeJgyjQicJHJnqHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00df;
							}
							hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
							if (xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.playerId < 0 || xUNdiOEYYDhoZDkmZzHJeiDGhvmAA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							bvwnJyYDJBkYePyTNCdvqaDkFOGA = (zHhtkRzCTRnxWXUubqRfdGGhGEUCA ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
							PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
							goto IL_0109;
							IL_0109:
							if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < bvwnJyYDJBkYePyTNCdvqaDkFOGA.Count)
							{
								BhdWnHwETjTwooLnNokUmKQRiiPK = bvwnJyYDJBkYePyTNCdvqaDkFOGA[PrfhaiCANHhjwtWLxlpNIHvkLSmF].controllers.conflictChecking.ElementAssignmentConflicts(xUNdiOEYYDhoZDkmZzHJeiDGhvmAA, bbJFyfBYztkbqyDKwjcJJfiCvWSr, BdJzrReMTTznOknxLtXkjkYMDbiN).GetEnumerator();
								hMnbMujJvihgLcBmOvURwCGCKZDT = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (BhdWnHwETjTwooLnNokUmKQRiiPK.MoveNext())
							{
								ElementAssignmentConflictInfo current = BhdWnHwETjTwooLnNokUmKQRiiPK.Current;
								vjnbYLtrPMftzpjohNfommerCnGo = current;
								hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
								return true;
							}
							MoEEbuduDHenVCeJgyjQicJHJnqHb();
							BhdWnHwETjTwooLnNokUmKQRiiPK = null;
							PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
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

					private void MoEEbuduDHenVCeJgyjQicJHJnqHb()
					{
						hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
						if (BhdWnHwETjTwooLnNokUmKQRiiPK != null)
						{
							BhdWnHwETjTwooLnNokUmKQRiiPK.Dispose();
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
						QgKbltCjIllMiGOyeGXQBpYYpMDec qgKbltCjIllMiGOyeGXQBpYYpMDec;
						if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
						{
							hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
							qgKbltCjIllMiGOyeGXQBpYYpMDec = this;
						}
						else
						{
							qgKbltCjIllMiGOyeGXQBpYYpMDec = new QgKbltCjIllMiGOyeGXQBpYYpMDec(0);
						}
						qgKbltCjIllMiGOyeGXQBpYYpMDec.xUNdiOEYYDhoZDkmZzHJeiDGhvmAA = kFSVgsWFZyqOFXGOFRPLWNAXMqBB;
						qgKbltCjIllMiGOyeGXQBpYYpMDec.bbJFyfBYztkbqyDKwjcJJfiCvWSr = sArRKCvKaVOofQinfjRFdePmZRhGA;
						qgKbltCjIllMiGOyeGXQBpYYpMDec.BdJzrReMTTznOknxLtXkjkYMDbiN = gulvZjHrAMBmzINGmCvcajRlsSDW;
						qgKbltCjIllMiGOyeGXQBpYYpMDec.zHhtkRzCTRnxWXUubqRfdGGhGEUCA = imaqOxAMTpGDRsORarKkbVchAkfT;
						return qgKbltCjIllMiGOyeGXQBpYYpMDec;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private static ConflictCheckingHelper ngWWJQOmNpFGXgzPCBggBNDROQLkA;

				internal static ConflictCheckingHelper YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new ConflictCheckingHelper());

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
					IList<Player> list = (includeSystemPlayer ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
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
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return GZUMXBOuruiXsXAwYxYJtPuTVDKK(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Keyboard:
						return bPskePCryZiGJFbDproSCOExBAUi(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Mouse:
						return jgPbRXPhbfvUpBQFvglnVFxLGLhaA(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Custom:
						return AlndKHEExHYfXtsMMnLpJpUJPAfE(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					default:
						throw new NotImplementedException();
					}
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
						return GZUMXBOuruiXsXAwYxYJtPuTVDKK(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return bPskePCryZiGJFbDproSCOExBAUi(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return jgPbRXPhbfvUpBQFvglnVFxLGLhaA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return AlndKHEExHYfXtsMMnLpJpUJPAfE(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool GZUMXBOuruiXsXAwYxYJtPuTVDKK(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool GZUMXBOuruiXsXAwYxYJtPuTVDKK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool bPskePCryZiGJFbDproSCOExBAUi(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool bPskePCryZiGJFbDproSCOExBAUi(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool jgPbRXPhbfvUpBQFvglnVFxLGLhaA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool jgPbRXPhbfvUpBQFvglnVFxLGLhaA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool AlndKHEExHYfXtsMMnLpJpUJPAfE(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool AlndKHEExHYfXtsMMnLpJpUJPAfE(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
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
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return FpanjaLbBYGiaAzsgORMpIuvTFzcA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Keyboard:
						return guJaYQgCyemeVHcnadaAHspgtBAsC(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Mouse:
						return FSzAvRvrvzqRndtzvXAhbCloFeir(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Custom:
						return abphrPFTYxHWOFLGxqHoShTKIbGu(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					default:
						throw new NotImplementedException();
					}
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
						return FpanjaLbBYGiaAzsgORMpIuvTFzcA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return guJaYQgCyemeVHcnadaAHspgtBAsC(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return FSzAvRvrvzqRndtzvXAhbCloFeir(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return abphrPFTYxHWOFLGxqHoShTKIbGu(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private IEnumerable<ElementAssignmentConflictInfo> FpanjaLbBYGiaAzsgORMpIuvTFzcA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new xVhywIzshuVQoxJInWYnQyumoRHh(-2)
					{
						vwqbDnGSuidIWeMoguuPgcjXMmpaA = P_0,
						IWzaGxCHKDwjdPAWTqffsANtqNC = P_1,
						nHQaDnBIpPavKeTDoaJgzRaNsBFpA = P_2,
						irfbfPdSapgmElNrHAavHgDhtrXec = P_3,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_4,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_5,
						imaqOxAMTpGDRsORarKkbVchAkfT = P_6
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> FpanjaLbBYGiaAzsgORMpIuvTFzcA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new SCTbDhwpzDulYvJGSDoWeWsUsjBoA(-2)
					{
						kFSVgsWFZyqOFXGOFRPLWNAXMqBB = P_0,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_1,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_2,
						imaqOxAMTpGDRsORarKkbVchAkfT = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> guJaYQgCyemeVHcnadaAHspgtBAsC(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new FGNIZQZRVHLxBBvvXStRxipwCfGe(-2)
					{
						vwqbDnGSuidIWeMoguuPgcjXMmpaA = P_0,
						RubNFUcoUOtDYcswjvhhJurRvfEI = P_1,
						irfbfPdSapgmElNrHAavHgDhtrXec = P_2,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_3,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_4,
						imaqOxAMTpGDRsORarKkbVchAkfT = P_5
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> guJaYQgCyemeVHcnadaAHspgtBAsC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new yByBFkeUxmQOhqLUXXNaEsSdzlDv(-2)
					{
						kFSVgsWFZyqOFXGOFRPLWNAXMqBB = P_0,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_1,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_2,
						imaqOxAMTpGDRsORarKkbVchAkfT = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> FSzAvRvrvzqRndtzvXAhbCloFeir(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new tsewmwBRmVlsjxeoWqsYmcDQeXkiA(-2)
					{
						vwqbDnGSuidIWeMoguuPgcjXMmpaA = P_0,
						kZgpIDaMMeixjZRCrsaULANYCcScA = P_1,
						irfbfPdSapgmElNrHAavHgDhtrXec = P_2,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_3,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_4,
						imaqOxAMTpGDRsORarKkbVchAkfT = P_5
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> FSzAvRvrvzqRndtzvXAhbCloFeir(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new QgKbltCjIllMiGOyeGXQBpYYpMDec(-2)
					{
						kFSVgsWFZyqOFXGOFRPLWNAXMqBB = P_0,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_1,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_2,
						imaqOxAMTpGDRsORarKkbVchAkfT = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> abphrPFTYxHWOFLGxqHoShTKIbGu(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new awffICyrJkpkftrLOeFyKLyymeQE(-2)
					{
						vwqbDnGSuidIWeMoguuPgcjXMmpaA = P_0,
						IWzaGxCHKDwjdPAWTqffsANtqNC = P_1,
						DajLgnbDjcVFpkPbeLaDtkbBtLmc = P_2,
						irfbfPdSapgmElNrHAavHgDhtrXec = P_3,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_4,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_5,
						imaqOxAMTpGDRsORarKkbVchAkfT = P_6
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> abphrPFTYxHWOFLGxqHoShTKIbGu(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new TBTPBEPaSBxWdEnPcWwzUlcQqnsE(-2)
					{
						kFSVgsWFZyqOFXGOFRPLWNAXMqBB = P_0,
						sArRKCvKaVOofQinfjRFdePmZRhGA = P_1,
						gulvZjHrAMBmzINGmCvcajRlsSDW = P_2,
						imaqOxAMTpGDRsORarKkbVchAkfT = P_3
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
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Keyboard:
						return LHpfnweBUdMFysIpQplBdaTBIbuac(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Mouse:
						return xjHCDXJeDVzjktQrOGaujUydvtYfc(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Custom:
						return xDqRqSZmjSAvIEiGPkywOxwjlLsHA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					default:
						throw new NotImplementedException();
					}
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
						return cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return LHpfnweBUdMFysIpQplBdaTBIbuac(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return xjHCDXJeDVzjktQrOGaujUydvtYfc(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return xDqRqSZmjSAvIEiGPkywOxwjlLsHA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int cTcdwBeYGPFwEGvGUPEVbkcNVmEZA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int LHpfnweBUdMFysIpQplBdaTBIbuac(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int LHpfnweBUdMFysIpQplBdaTBIbuac(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int xjHCDXJeDVzjktQrOGaujUydvtYfc(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int xjHCDXJeDVzjktQrOGaujUydvtYfc(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int xDqRqSZmjSAvIEiGPkywOxwjlLsHA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int xDqRqSZmjSAvIEiGPkywOxwjlLsHA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
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
					switch (controllerType)
					{
					case ControllerType.Joystick:
						return SvkoWBXuCCOmzvopgZuGJNunUAxb(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Keyboard:
						return VtfrxlovDjJsBVJiMETYCvljTtjm(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Mouse:
						return ykvViJJjdkKOGrdnNxRuEQFEzuMF(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					case ControllerType.Custom:
						return txRzuAeODldVVhKnrHOHytvHLVjp(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					default:
						throw new NotImplementedException();
					}
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
						return SvkoWBXuCCOmzvopgZuGJNunUAxb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return VtfrxlovDjJsBVJiMETYCvljTtjm(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return ykvViJJjdkKOGrdnNxRuEQFEzuMF(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return txRzuAeODldVVhKnrHOHytvHLVjp(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int SvkoWBXuCCOmzvopgZuGJNunUAxb(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int SvkoWBXuCCOmzvopgZuGJNunUAxb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int VtfrxlovDjJsBVJiMETYCvljTtjm(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int VtfrxlovDjJsBVJiMETYCvljTtjm(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int ykvViJJjdkKOGrdnNxRuEQFEzuMF(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int ykvViJJjdkKOGrdnNxRuEQFEzuMF(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int txRzuAeODldVVhKnrHOHytvHLVjp(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int txRzuAeODldVVhKnrHOHytvHLVjp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi : LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper ngWWJQOmNpFGXgzPCBggBNDROQLkA;

			public readonly PollingHelper polling = PollingHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA;

			internal static ControllerHelper YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.bjUBfnMXpSPAKDJOeQJqyYUYNCXb;
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
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.dfNtogKfzQPVfHOqaceybelwlhei;
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
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.PFBHIEavSNmCtRpAbjOJnbVrdybGA;
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
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.ksIrgmIMxbskrWvzAPRFSsoyIedU;
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
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.wfXcGbTMFLTAwDvEytkMGYATlJxS;
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
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN;
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
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.wBbxrMLeCcnzzcTBhwMHzHnZVhfg;
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
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.nXskdlIEaHeWrNhncZFmhjuqgJCE;
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
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.ksIrgmIMxbskrWvzAPRFSsoyIedU as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return vnBcsWOiBrsweGQzTZwXEVWsKEyb.PFBHIEavSNmCtRpAbjOJnbVrdybGA as T;
				}
				throw new NotImplementedException();
			}

			public int GetControllerCount(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return 0;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					return joystickCount;
				case ControllerType.Keyboard:
					return 1;
				case ControllerType.Mouse:
					return 1;
				case ControllerType.Custom:
					return customControllerCount;
				default:
					throw new NotImplementedException();
				}
			}

			public Controller GetController(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.gAPABsuepoxQLaHJJhjKlywBeNAd(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.gAPABsuepoxQLaHJJhjKlywBeNAd(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.RdbrZaSeRjDaVJQGByOntZRScMlG(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.oLiHoScHhSofapBlXVSPeydcjsMy(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.fmTBCgEAQIZMRJZgfloQKZgrGjIVA(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.fmTBCgEAQIZMRJZgfloQKZgrGjIVA(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.AkAfZLHbVwotEGeNcRQmGJOwQqwKc(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					LmvhkTCrnWKGfgMggYILVjKvuRWf.dFUzutxeEjoEHoWONFDUTGeOVtqm(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					LmvhkTCrnWKGfgMggYILVjKvuRWf.dFUzutxeEjoEHoWONFDUTGeOVtqm(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.EPOGytyJCWylBVHKoFQXhUyQAprcb(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.rbBlhjrovprRnObkmkKQytErKEiN();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.ChiAoYAlHmAoqFwfKRSCgJmfFJPKA();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.DVbirfzaWgaTTGRXTgCeaotBMFlCA(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.DVbirfzaWgaTTGRXTgCeaotBMFlCA(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.zZGPkOEHSlYETjpDuIDVCHfGrctE(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					LmvhkTCrnWKGfgMggYILVjKvuRWf.tAOdQTZUCMxRxSLQvehqeJEyMHEx(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					LmvhkTCrnWKGfgMggYILVjKvuRWf.tAOdQTZUCMxRxSLQvehqeJEyMHEx(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!WkPFbmxAjGiQkapUnRbaNBukJiQNA)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				LEMmFIAltMiAQTrcghzxAsRTnUXR();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (gDCjUaccLpnQcuebaIEpiBtEAKxZ.XXPRSaFEksDfHHDrkEpnHUYPzOCfA(i, j))
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
				if (!WkPFbmxAjGiQkapUnRbaNBukJiQNA)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				LEMmFIAltMiAQTrcghzxAsRTnUXR();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (gDCjUaccLpnQcuebaIEpiBtEAKxZ.XXPRSaFEksDfHHDrkEpnHUYPzOCfA(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (gDCjUaccLpnQcuebaIEpiBtEAKxZ.hQvfzEgCbkmSdRdpIMixOaWVxzbV(i, k, positiveAxesOnly))
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
					if (!WkPFbmxAjGiQkapUnRbaNBukJiQNA)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						kIYEyNIDuUrPSNKcQjXwLeROpxSc.SetUnityJoystickId(joystickId, unityJoystickId);
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
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.ivkRKvvGYxrHvXDUIEhQMQamHUeC(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.JiVocbhbmNrpHMfMFXnEaiLHBunCA();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.VVPDliKZZldKAZTZFKJjHUkfbmeCc();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.AKXsKWmQTCjETHKbbJaLFtQtRLbEA(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.AKXsKWmQTCjETHKbbJaLFtQtRLbEA(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.FhvRHoZutIqnJUIHhcBMxRTuOlWj(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					LmvhkTCrnWKGfgMggYILVjKvuRWf.gNZuXyEeHYpuhhPwYboZmzyuMWLb(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					LmvhkTCrnWKGfgMggYILVjKvuRWf.gNZuXyEeHYpuhhPwYboZmzyuMWLb(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.REFjFzjqVfBzOqUbhgBnBtJFDRDQb(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = vnBcsWOiBrsweGQzTZwXEVWsKEyb.REFjFzjqVfBzOqUbhgBnBtJFDRDQb(sourceControllerId);
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
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.BWwCkvQolrBhAUEVnxBcpzwLMbpG(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.OfkJqbQgXtexMBtznwjseMqgxqbM(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.TGqzjJzOivrSagsCKEKvjIIrwvfJA(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.WscepHGvdSvomDaSfbHuVBaFDyGy(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.gkPTLDzKywBjLjvsYlUYXYaegPyq(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.QrDUPafwVxtEzHrVlDyAXKiCvaOt<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.XGXtEHrvpvOZguxwYxxfpdPmfXDv();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.XGXtEHrvpvOZguxwYxxfpdPmfXDv(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.XGXtEHrvpvOZguxwYxxfpdPmfXDv<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.XjqcOqHEhncFEkanEHcOMXYANZbOA();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					vnBcsWOiBrsweGQzTZwXEVWsKEyb.BvWzsmEDKXHJdamXSxHkvlEaBMPC(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					vnBcsWOiBrsweGQzTZwXEVWsKEyb.BvWzsmEDKXHJdamXSxHkvlEaBMPC(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					vnBcsWOiBrsweGQzTZwXEVWsKEyb.HdlHQrgKTRKuUNntUzSxdjLVFDaK(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					vnBcsWOiBrsweGQzTZwXEVWsKEyb.spPQKaELvVdlXntYRhNUlhWqieoL(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					vnBcsWOiBrsweGQzTZwXEVWsKEyb.uVdGGwwgzyMStSFKWTNiNKHqwfHD();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.bEjCYdHONuNmFNifoIjBdDLELqbUB();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.bEjCYdHONuNmFNifoIjBdDLELqbUB(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.xjuauQbieLHzeLjZSJxPDbVcfiWUA();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.xjuauQbieLHzeLjZSJxPDbVcfiWUA(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.LibGTMQwNuWAvjYUKltqGokLHoYN();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.LibGTMQwNuWAvjYUKltqGokLHoYN(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.INzAnNFORDuGjMBqYDhPMwqXDFIcA();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.INzAnNFORDuGjMBqYDhPMwqXDFIcA(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.LYjgMPcRTohNXetfcTxkFoUCGEDLE();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.LYjgMPcRTohNXetfcTxkFoUCGEDLE(controllerType);
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
				LmvhkTCrnWKGfgMggYILVjKvuRWf.kdhtvwuLfWpGpQsmdwQRdufkKFHB(joystick);
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
			private static MappingHelper ngWWJQOmNpFGXgzPCBggBNDROQLkA;

			internal static MappingHelper YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return CXDUyJahCSWooVERZIbeGddBeaKq.lruXsPcWAWjxGBlDUNNZnTEWBoyU;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.BodQcsUAJmdsPhNyMLsbCwDeQGcqA;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.qxyjMLNBYWZSwZzFSLKdrtbOBxEw;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.CFRVjkcSCfvtIhAEzQrUgQCitLJC;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.NlNaENDnIzgxZWSTCErASEuHhxEeA;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.ophacAZxHKjutYjRQtbxJHCwNyxm;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.hBAdSuJlJAlcuHhfCVrZSwpMnQII;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.PcpQfFqzcIJnvzCgAvPkYCfmJCtS;
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
					return oLBbvsaIpIbSBPWdHzABkcRnEFqPA.JztSgslzhagKBJhbGNArekIIiZlf;
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
					return CXDUyJahCSWooVERZIbeGddBeaKq.UlPDdjkpoBvQbNsLtJDuElsmuwvOA;
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
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.NmhYvbKLkDZZOXyxHChpARemeuIT(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.nyzktcyjHWFeLYGMggYfEuvPHbYHb(tag);
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
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.dQCVrIVQyNTLXlGWJhuBbVMblFff(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.LObdgfFOfdZvzEiKzEqMyQCneAElA(tag);
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
				switch (controllerType)
				{
				case ControllerType.Joystick:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetJoystickLayoutById(layoutId);
				case ControllerType.Keyboard:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetKeyboardLayoutById(layoutId);
				case ControllerType.Mouse:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetMouseLayoutById(layoutId);
				case ControllerType.Custom:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetCustomControllerLayoutById(layoutId);
				default:
					throw new NotImplementedException();
				}
			}

			public InputLayout GetLayout(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetJoystickLayout(name);
				case ControllerType.Keyboard:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetKeyboardLayout(name);
				case ControllerType.Mouse:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetMouseLayout(name);
				case ControllerType.Custom:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetCustomControllerLayout(name);
				default:
					throw new NotImplementedException();
				}
			}

			public int GetLayoutId(ControllerType controllerType, string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetJoystickLayoutId(name);
				case ControllerType.Keyboard:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetKeyboardLayoutId(name);
				case ControllerType.Mouse:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetMouseLayoutId(name);
				case ControllerType.Custom:
					return CXDUyJahCSWooVERZIbeGddBeaKq.GetCustomControllerLayoutId(name);
				default:
					throw new NotImplementedException();
				}
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetCustomControllerLayoutId(name);
			}

			public IList<InputLayout> MapLayouts(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputLayout>.EmptyReadOnlyIListT;
				}
				switch (controllerType)
				{
				case ControllerType.Joystick:
					return JoystickLayouts;
				case ControllerType.Keyboard:
					return KeyboardLayouts;
				case ControllerType.Mouse:
					return MouseLayouts;
				case ControllerType.Custom:
					return CustomControllerLayouts;
				default:
					throw new NotImplementedException();
				}
			}

			public InputAction GetAction(int actionId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.aGhijMhepwzAQVtDXCaFRBQdETMCA(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.aGhijMhepwzAQVtDXCaFRBQdETMCA(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.aGhijMhepwzAQVtDXCaFRBQdETMCA(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.aGhijMhepwzAQVtDXCaFRBQdETMCA(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.bgOUPOarCMFGtvkASappiSzoeXluA(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.BZREHtACTFaaCCmDzKPeWJyFEAF(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.BZREHtACTFaaCCmDzKPeWJyFEAF(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.BZREHtACTFaaCCmDzKPeWJyFEAF(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.BZREHtACTFaaCCmDzKPeWJyFEAF(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.BLmglDisFscRMEbYRzrZHWrhAOln(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.BLmglDisFscRMEbYRzrZHWrhAOln(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.SFJZdklJEKfUiGPbWOYRazmyxtQuA(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return vnBcsWOiBrsweGQzTZwXEVWsKEyb.SFJZdklJEKfUiGPbWOYRazmyxtQuA(playerId, behaviorName);
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
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior CKWdEEaYCOciRYXzWzDAiIAPSDMgb(int P_0)
			{
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetInputBehaviorById(P_0);
			}

			internal InputBehavior CKWdEEaYCOciRYXzWzDAiIAPSDMgb(string P_0)
			{
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetInputBehavior(P_0);
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
				switch (controller.type)
				{
				case ControllerType.Joystick:
					return GetJoystickMapInstance((Joystick)controller, mapCategoryId, layoutId);
				case ControllerType.Keyboard:
					return GetKeyboardMapInstance(mapCategoryId, layoutId);
				case ControllerType.Mouse:
					return GetMouseMapInstance(mapCategoryId, layoutId);
				case ControllerType.Custom:
					return GetCustomControllerMapInstance((CustomController)controller, mapCategoryId, layoutId);
				default:
					throw new NotImplementedException();
				}
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
				Controller controller = vnBcsWOiBrsweGQzTZwXEVWsKEyb.gAPABsuepoxQLaHJJhjKlywBeNAd(controllerIdentifier);
				if (controller != null)
				{
					return GetControllerMapInstance(controller, mapCategoryId, layoutId);
				}
				switch (controllerIdentifier.controllerType)
				{
				case ControllerType.Joystick:
					return GetJoystickMapInstance(controllerIdentifier, mapCategoryId, layoutId);
				case ControllerType.Custom:
					return GetCustomControllerMapInstance(controllerIdentifier, mapCategoryId, layoutId);
				case ControllerType.Keyboard:
					return GetKeyboardMapInstance(mapCategoryId, layoutId);
				case ControllerType.Mouse:
					return GetMouseMapInstance(mapCategoryId, layoutId);
				default:
					throw new NotImplementedException();
				}
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
				JoystickMap joystickMap = CXDUyJahCSWooVERZIbeGddBeaKq.gUxChVRBsjPPDWpUfylXVbZXrBYU(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.LJxUfrjqRngGjfLkARGJwZXpwXAOA(joystickMap);
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
				InputSource inputSourceType = kIYEyNIDuUrPSNKcQjXwLeROpxSc.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = TrUvNDsBpLBewgrhUcJYluTgENjsA.EwFoPSPjnAvtndVEetRlVERPrRzK(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = CXDUyJahCSWooVERZIbeGddBeaKq.ThFVCIAcQrTgApfKAhfPqPZibRvK(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.lupzNBkwMYPWmXbwcpveWSWjXxTV(joystickMap, hardwareControllerMap_Game);
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
				if (vnBcsWOiBrsweGQzTZwXEVWsKEyb.gAPABsuepoxQLaHJJhjKlywBeNAd(controllerIdentifier) is Joystick joystick)
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
				KeyboardMap keyboardMap = CXDUyJahCSWooVERZIbeGddBeaKq.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.LJxUfrjqRngGjfLkARGJwZXpwXAOA(keyboardMap);
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
				MouseMap mouseMap = CXDUyJahCSWooVERZIbeGddBeaKq.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.LJxUfrjqRngGjfLkARGJwZXpwXAOA(mouseMap);
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
				CustomControllerMap customControllerMap = CXDUyJahCSWooVERZIbeGddBeaKq.DSafZsvlKsnfESZPCZvSdrEpJHPB(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.LJxUfrjqRngGjfLkARGJwZXpwXAOA(customControllerMap);
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
				if (vnBcsWOiBrsweGQzTZwXEVWsKEyb.gAPABsuepoxQLaHJJhjKlywBeNAd(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = CXDUyJahCSWooVERZIbeGddBeaKq.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = CXDUyJahCSWooVERZIbeGddBeaKq.DSafZsvlKsnfESZPCZvSdrEpJHPB(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.lupzNBkwMYPWmXbwcpveWSWjXxTV(customControllerMap, hardwareControllerMap_Game);
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
					controllerMap = CXDUyJahCSWooVERZIbeGddBeaKq.XLaZeIAcluXGguEpDszvQZYdfxQf(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.LJxUfrjqRngGjfLkARGJwZXpwXAOA(controller, controllerMap);
					}
					else
					{
						controller.LJxUfrjqRngGjfLkARGJwZXpwXAOA(controllerMap);
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
				switch (controllerIdentifier.controllerType)
				{
				case ControllerType.Joystick:
					return GetJoystickMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
				case ControllerType.Custom:
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
				case ControllerType.Keyboard:
					return GetKeyboardMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
				case ControllerType.Mouse:
					return GetMouseMapInstanceSavedOrDefault(playerId, mapCategoryId, layoutId);
				default:
					throw new NotImplementedException();
				}
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
				if (vnBcsWOiBrsweGQzTZwXEVWsKEyb.gAPABsuepoxQLaHJJhjKlywBeNAd(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = kIYEyNIDuUrPSNKcQjXwLeROpxSc.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = TrUvNDsBpLBewgrhUcJYluTgENjsA.EwFoPSPjnAvtndVEetRlVERPrRzK(controllerIdentifier.hardwareTypeGuid, inputSourceType);
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
					joystickMap = CXDUyJahCSWooVERZIbeGddBeaKq.ThFVCIAcQrTgApfKAhfPqPZibRvK(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
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
						allMap.lupzNBkwMYPWmXbwcpveWSWjXxTV(joystickMap, hardwareControllerMap_Game);
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
				if (vnBcsWOiBrsweGQzTZwXEVWsKEyb.gAPABsuepoxQLaHJJhjKlywBeNAd(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = CXDUyJahCSWooVERZIbeGddBeaKq.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
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
					customControllerMap = CXDUyJahCSWooVERZIbeGddBeaKq.DSafZsvlKsnfESZPCZvSdrEpJHPB(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.lupzNBkwMYPWmXbwcpveWSWjXxTV(customControllerMap, hardwareControllerMap_Game);
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
					keyboardMap = CXDUyJahCSWooVERZIbeGddBeaKq.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.LJxUfrjqRngGjfLkARGJwZXpwXAOA(keyboard, keyboardMap);
					}
					else
					{
						keyboard.LJxUfrjqRngGjfLkARGJwZXpwXAOA(keyboardMap);
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
					mouseMap = CXDUyJahCSWooVERZIbeGddBeaKq.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.LJxUfrjqRngGjfLkARGJwZXpwXAOA(mouse, mouseMap);
					}
					else
					{
						mouse.LJxUfrjqRngGjfLkARGJwZXpwXAOA(mouseMap);
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
				return uRoQQxpMNnGQZMXBFMRWNpIiOAag(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier uRoQQxpMNnGQZMXBFMRWNpIiOAag(Guid P_0, int P_1)
			{
				HardwareJoystickMap hardwareControllerMap;
				return TrUvNDsBpLBewgrhUcJYluTgENjsA.weIIFtgJCYidyYiBEDuesKXwWhVc(P_0, P_1, out hardwareControllerMap)?.ToControllerElementIdentifier(hardwareControllerMap);
			}

			internal int yruuCzXJlLZnCJaByjXxlcRSHVKT(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.byvytSemFeFKFEMsWeUwDcEJnxtsA> P_3)
			{
				return TrUvNDsBpLBewgrhUcJYluTgENjsA.yruuCzXJlLZnCJaByjXxlcRSHVKT(P_0, P_1, P_2, P_3);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return CXDUyJahCSWooVERZIbeGddBeaKq.jcCaVuCDoTXbHtXjaiblxMqPhtkZA(templateTypeGuid, mapCategoryId, layoutId);
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
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = CXDUyJahCSWooVERZIbeGddBeaKq.GetControllerMapLayoutManagerRuleSetId(name);
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
				return CXDUyJahCSWooVERZIbeGddBeaKq.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = CXDUyJahCSWooVERZIbeGddBeaKq.GetControllerMapEnablerRuleSetId(name);
				if (controllerMapEnablerRuleSetId < 0)
				{
					return null;
				}
				return GetControllerMapEnablerRuleSetInstance(controllerMapEnablerRuleSetId);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class PlayerHelper : CodeHelper
		{
			private static PlayerHelper ngWWJQOmNpFGXgzPCBggBNDROQLkA;

			internal static PlayerHelper YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return LmvhkTCrnWKGfgMggYILVjKvuRWf.kLtKHYOKyHabTdaYNJSDSbiURQrCA;
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
					return LmvhkTCrnWKGfgMggYILVjKvuRWf.TmZgxqdxZNPOJEXaGaspgkRVmNTg;
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
					return LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA;
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
					return LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi;
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
					return LmvhkTCrnWKGfgMggYILVjKvuRWf.POqlaIweLUrFjDIOnEPRqRFLSGgs();
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
					return LmvhkTCrnWKGfgMggYILVjKvuRWf.yhcwtnieSsbrJKctPqNEcbZsdLgXA;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.qocjBrREVEKPmUknGfrCijxNqmDi;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.GMfdPhKaTGGvREtYKUxukZZFdgrwA(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.GMfdPhKaTGGvREtYKUxukZZFdgrwA(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.POqlaIweLUrFjDIOnEPRqRFLSGgs();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.ljBCLXLZvMpyQrsTGkOKKJMMeoOaA(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.wlgfVPGuuPhYVDNTFEmYdtNSKipBB(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.ubvURaEZsshLIcHfwxVhNBJbHyQP(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return LmvhkTCrnWKGfgMggYILVjKvuRWf.kNkBNvbiJxqLsbIwflCouZakIqsfc(includeSystemPlayer);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper ngWWJQOmNpFGXgzPCBggBNDROQLkA;

			internal static TimeHelper YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)cDkUjzCJdXHwpgMXoYVYqaYFhWtI.SQfOockOhvzbaqsrgOHkyrdcXBeC;
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
					return cDkUjzCJdXHwpgMXoYVYqaYFhWtI.lcPtsOrqNcMlmPyXpDbhgobrUOFq;
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
					return cDkUjzCJdXHwpgMXoYVYqaYFhWtI.xsfBoabwqLRrLvyBRBnSeNmHKaqkb;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class HOafJDFVxlzBogsecPljtcjOpBrIA
		{
			private class MzNbCEWWoycLhUcoHBXDCfVGFzvA
			{
				public readonly UpdateLoopType duvdeoIMbviHBoTTDYZbkoEpbLKZA;

				private double dHrGVwhVfjYHhcLVIBVVLowdGgZdA;

				private double janQjoQjsLdKZLYcGAuxxEzEkPId;

				private double IaucALJReQiveewXVUTAROPcadFZA;

				private double zUeDQiznPIgsZgcgbsowLNxBdVCNA;

				private uint fQxgerCCvFekJxgYvNsmLGUmIOrpA;

				private uint cBQaLAdwAwbHBAfTWvYJNIVCjNSUA;

				private float VaLgcPGcKlpKcupZLxqKiSOrRLfGA;

				private float wXvngttXAPmyiwDlHCQYfsgGbGHZ;

				public double lcPtsOrqNcMlmPyXpDbhgobrUOFq => dHrGVwhVfjYHhcLVIBVVLowdGgZdA;

				public double TXLArGCHKzAoNKXpLJgxFRxThWZvA => janQjoQjsLdKZLYcGAuxxEzEkPId;

				public double SQfOockOhvzbaqsrgOHkyrdcXBeC => IaucALJReQiveewXVUTAROPcadFZA;

				public uint xsfBoabwqLRrLvyBRBnSeNmHKaqkb => fQxgerCCvFekJxgYvNsmLGUmIOrpA;

				public uint BYEXipmXYIhBgIAPQCXWeMHtVlGT => cBQaLAdwAwbHBAfTWvYJNIVCjNSUA;

				public float gBbdTEyPLrmihDpWoCuKeotGbOYTA => VaLgcPGcKlpKcupZLxqKiSOrRLfGA;

				public float CAQHcvsVRnrpDcaVzIopCiQsYHnP => wXvngttXAPmyiwDlHCQYfsgGbGHZ;

				public MzNbCEWWoycLhUcoHBXDCfVGFzvA(UpdateLoopType P_0)
				{
					duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_0;
					zUeDQiznPIgsZgcgbsowLNxBdVCNA = Time.realtimeSinceStartup;
					fQxgerCCvFekJxgYvNsmLGUmIOrpA = 0u;
				}

				public void DsDuSUaDcVanpNAhDLIRqjKndMGi()
				{
					janQjoQjsLdKZLYcGAuxxEzEkPId = dHrGVwhVfjYHhcLVIBVVLowdGgZdA;
					dHrGVwhVfjYHhcLVIBVVLowdGgZdA = realTime;
					if (zUeDQiznPIgsZgcgbsowLNxBdVCNA > dHrGVwhVfjYHhcLVIBVVLowdGgZdA)
					{
						zUeDQiznPIgsZgcgbsowLNxBdVCNA = 0.0;
					}
					IaucALJReQiveewXVUTAROPcadFZA = dHrGVwhVfjYHhcLVIBVVLowdGgZdA - zUeDQiznPIgsZgcgbsowLNxBdVCNA;
					zUeDQiznPIgsZgcgbsowLNxBdVCNA = dHrGVwhVfjYHhcLVIBVVLowdGgZdA;
					cBQaLAdwAwbHBAfTWvYJNIVCjNSUA = fQxgerCCvFekJxgYvNsmLGUmIOrpA;
					fQxgerCCvFekJxgYvNsmLGUmIOrpA = MiscTools.Tick(fQxgerCCvFekJxgYvNsmLGUmIOrpA);
					wXvngttXAPmyiwDlHCQYfsgGbGHZ = VaLgcPGcKlpKcupZLxqKiSOrRLfGA;
					VaLgcPGcKlpKcupZLxqKiSOrRLfGA = hxwLWflxYsGCwXALQGMoKjUJzCYDA();
					previousFrame = cBQaLAdwAwbHBAfTWvYJNIVCjNSUA;
					currentFrame = fQxgerCCvFekJxgYvNsmLGUmIOrpA;
					unscaledTime = dHrGVwhVfjYHhcLVIBVVLowdGgZdA;
					unscaledTimePrev = janQjoQjsLdKZLYcGAuxxEzEkPId;
					unscaledDeltaTime = IaucALJReQiveewXVUTAROPcadFZA;
				}
			}

			private static class hlwMUVJYWyNMSlRUyrGJFqhSjCGIA
			{
				public static StopwatchBase NLYfmZNgTjTzFWHAKRhfnrYRnLQn
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

				public static StopwatchBase VxSNvmooWfTkIVcICGUZnqoUJPDW()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase fwYWlRQSODepmwNFGDkdaxUwXuAHA()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase ZzUfMbIODJAgSzxwYngvgeRFuQpy;

			private double AFvjpOqvkpsXzeCFggLAbrIlwnNwA;

			private MzNbCEWWoycLhUcoHBXDCfVGFzvA ydtyERSefgzOiXbyoFbZiuNyveOV;

			private ADictionary<int, MzNbCEWWoycLhUcoHBXDCfVGFzvA> TRcbHTUUDYFIFdqGylcaKyciTGGH;

			private uint qFRrAJVJDJCBBcXTOcltYzpTIrgxA;

			public double lcPtsOrqNcMlmPyXpDbhgobrUOFq => ydtyERSefgzOiXbyoFbZiuNyveOV.lcPtsOrqNcMlmPyXpDbhgobrUOFq;

			public double TXLArGCHKzAoNKXpLJgxFRxThWZvA => ydtyERSefgzOiXbyoFbZiuNyveOV.TXLArGCHKzAoNKXpLJgxFRxThWZvA;

			public double SQfOockOhvzbaqsrgOHkyrdcXBeC => ydtyERSefgzOiXbyoFbZiuNyveOV.SQfOockOhvzbaqsrgOHkyrdcXBeC;

			public float gBbdTEyPLrmihDpWoCuKeotGbOYTA => ydtyERSefgzOiXbyoFbZiuNyveOV.gBbdTEyPLrmihDpWoCuKeotGbOYTA;

			public float CAQHcvsVRnrpDcaVzIopCiQsYHnP => ydtyERSefgzOiXbyoFbZiuNyveOV.CAQHcvsVRnrpDcaVzIopCiQsYHnP;

			internal double QxBatzayheTKduGHxgiXgQaYWDll => ZzUfMbIODJAgSzxwYngvgeRFuQpy.elapsedSeconds + AFvjpOqvkpsXzeCFggLAbrIlwnNwA;

			public uint xsfBoabwqLRrLvyBRBnSeNmHKaqkb => ydtyERSefgzOiXbyoFbZiuNyveOV.xsfBoabwqLRrLvyBRBnSeNmHKaqkb;

			public uint BYEXipmXYIhBgIAPQCXWeMHtVlGT => ydtyERSefgzOiXbyoFbZiuNyveOV.BYEXipmXYIhBgIAPQCXWeMHtVlGT;

			public uint hQVICrUeQJEIbbeziKwtBMKIdBVsB => qFRrAJVJDJCBBcXTOcltYzpTIrgxA;

			public HOafJDFVxlzBogsecPljtcjOpBrIA()
			{
				ZzUfMbIODJAgSzxwYngvgeRFuQpy = hlwMUVJYWyNMSlRUyrGJFqhSjCGIA.NLYfmZNgTjTzFWHAKRhfnrYRnLQn;
				XKZIxwRUwDpNhkICJrLjGrsjhGsn();
			}

			public void VJZYLwnozSOjeSmKfhNhCbaWAtFjA()
			{
				AFvjpOqvkpsXzeCFggLAbrIlwnNwA = Time.realtimeSinceStartup;
			}

			public void XKZIxwRUwDpNhkICJrLjGrsjhGsn()
			{
				ydtyERSefgzOiXbyoFbZiuNyveOV = null;
				TRcbHTUUDYFIFdqGylcaKyciTGGH = new ADictionary<int, MzNbCEWWoycLhUcoHBXDCfVGFzvA>();
				using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
				{
					List<UpdateLoopType> list = tList.list;
					EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)(-1), list);
					for (int i = 0; i < list.Count; i++)
					{
						MzNbCEWWoycLhUcoHBXDCfVGFzvA value = new MzNbCEWWoycLhUcoHBXDCfVGFzvA(list[i]);
						TRcbHTUUDYFIFdqGylcaKyciTGGH.Add((int)list[i], value);
						if (ydtyERSefgzOiXbyoFbZiuNyveOV == null)
						{
							ydtyERSefgzOiXbyoFbZiuNyveOV = value;
						}
					}
				}
			}

			public void DsDuSUaDcVanpNAhDLIRqjKndMGi(UpdateLoopType P_0)
			{
				if (ydtyERSefgzOiXbyoFbZiuNyveOV.duvdeoIMbviHBoTTDYZbkoEpbLKZA != P_0)
				{
					ydtyERSefgzOiXbyoFbZiuNyveOV = TRcbHTUUDYFIFdqGylcaKyciTGGH[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					ydtyERSefgzOiXbyoFbZiuNyveOV.DsDuSUaDcVanpNAhDLIRqjKndMGi();
					qFRrAJVJDJCBBcXTOcltYzpTIrgxA = MiscTools.Tick(qFRrAJVJDJCBBcXTOcltYzpTIrgxA);
					absFrame = qFRrAJVJDJCBBcXTOcltYzpTIrgxA;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch ngWWJQOmNpFGXgzPCBggBNDROQLkA;

			internal static UnityTouch YkOfalMPfJJtRpqgraJAkfubjGMbA => ngWWJQOmNpFGXgzPCBggBNDROQLkA ?? (ngWWJQOmNpFGXgzPCBggBNDROQLkA = new UnityTouch());

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

		internal class afHScbWRxrtoFzPRuCPmFlLCDPhb
		{
			[Serializable]
			private sealed class BtyEoTFCoTmRZLMbdnSBTOoxeEuVA
			{
				public static readonly BtyEoTFCoTmRZLMbdnSBTOoxeEuVA _003C_003E9 = new BtyEoTFCoTmRZLMbdnSBTOoxeEuVA();

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool xstgkvJIHaJlZewNhmPYExtqjhbvA()
				{
					return Screen.fullScreen;
				}

				internal bool zhtautaPNRqGApNylpdvEWNnrKGsA()
				{
					return Application.runInBackground;
				}

				internal int yIpymKBxrYIuVqiTUHxzoVKCWNHl()
				{
					return (int)Screen.fullScreenMode;
				}

				internal float WomANTdcwWJWhDgUmmKgWxdwJVXr()
				{
					return Time.unscaledDeltaTime;
				}

				internal bool bqmgodcFlJEVYTykNsDpLYsVIfFp()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				internal string WRDDNASSocWxMEqFRIhSSpgdZgtG()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}
			}

			public readonly ValueWatcher<bool> wctCmdqGBFxjxSnPwpFfbwanRTpG;

			public readonly ValueWatcher<bool> DziKkOiMdRlShDNLUzPfUCjwhfZhA;

			public readonly ValueWatcher<bool> wKVRomDwDFlWZWlzeKAyYFGflyXf;

			public readonly ValueWatcher<bool> DxqrdfhVyQkdXVkbhGvnvmpiKwO;

			public readonly ValueWatcher<int> RDFSYbOhyAmilvRwlQxsRCjbiSiC;

			public readonly ValueWatcher<float> SQfOockOhvzbaqsrgOHkyrdcXBeC;

			public readonly ValueWatcher<string> sULhgzEJtPTVpuDtrvgYUNyiqAjG;

			public readonly ValueWatcher<bool> UejIvyDwmLGYAOfrbobyeSLhTDGPB;

			private int hmJjkTtANGsNYHooMWftlzqeBHsw;

			private readonly ValueWatcher[] chlkyCgJoBQDHiADDAgcUbTjLMYQ;

			public int YxXoYKlUcpWqMVZZfPOdNPiRfJKkA => hmJjkTtANGsNYHooMWftlzqeBHsw;

			public afHScbWRxrtoFzPRuCPmFlLCDPhb()
			{
				bool flag = UnityTools.isEditor || Application.isFocused;
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(wctCmdqGBFxjxSnPwpFfbwanRTpG = new ValueWatcher<bool>(flag, false)),
					(DziKkOiMdRlShDNLUzPfUCjwhfZhA = new ValueWatcher<bool>(false, false)),
					(wKVRomDwDFlWZWlzeKAyYFGflyXf = new ValueWatcher<bool>(Screen.fullScreen, BtyEoTFCoTmRZLMbdnSBTOoxeEuVA._003C_003E9.xstgkvJIHaJlZewNhmPYExtqjhbvA, false)),
					(DxqrdfhVyQkdXVkbhGvnvmpiKwO = new ValueWatcher<bool>(Application.runInBackground, BtyEoTFCoTmRZLMbdnSBTOoxeEuVA._003C_003E9.zhtautaPNRqGApNylpdvEWNnrKGsA, false)),
					(RDFSYbOhyAmilvRwlQxsRCjbiSiC = new ValueWatcher<int>((int)Screen.fullScreenMode, BtyEoTFCoTmRZLMbdnSBTOoxeEuVA._003C_003E9.yIpymKBxrYIuVqiTUHxzoVKCWNHl, false)),
					(SQfOockOhvzbaqsrgOHkyrdcXBeC = new ValueWatcher<float>(Time.unscaledDeltaTime, BtyEoTFCoTmRZLMbdnSBTOoxeEuVA._003C_003E9.WomANTdcwWJWhDgUmmKgWxdwJVXr, false)),
					(UejIvyDwmLGYAOfrbobyeSLhTDGPB = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), BtyEoTFCoTmRZLMbdnSBTOoxeEuVA._003C_003E9.bqmgodcFlJEVYTykNsDpLYsVIfFp, MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(sULhgzEJtPTVpuDtrvgYUNyiqAjG = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), BtyEoTFCoTmRZLMbdnSBTOoxeEuVA._003C_003E9.WRDDNASSocWxMEqFRIhSSpgdZgtG, false));
				}
				chlkyCgJoBQDHiADDAgcUbTjLMYQ = list.ToArray();
				DsDuSUaDcVanpNAhDLIRqjKndMGi();
			}

			public void DsDuSUaDcVanpNAhDLIRqjKndMGi()
			{
				for (int i = 0; i < chlkyCgJoBQDHiADDAgcUbTjLMYQ.Length; i++)
				{
					chlkyCgJoBQDHiADDAgcUbTjLMYQ[i].Update();
				}
				hmJjkTtANGsNYHooMWftlzqeBHsw = Time.frameCount;
			}

			public void QVPGsookfqdcHfetGjcrckBuNSOpA()
			{
				for (int i = 0; i < chlkyCgJoBQDHiADDAgcUbTjLMYQ.Length; i++)
				{
					chlkyCgJoBQDHiADDAgcUbTjLMYQ[i].TriggerEvent();
				}
			}
		}

		[Serializable]
		private sealed class EWhWZuzbwHUgopSrQLHxbyPQkRFM
		{
			public static readonly EWhWZuzbwHUgopSrQLHxbyPQkRFM _003C_003E9 = new EWhWZuzbwHUgopSrQLHxbyPQkRFM();

			public static Func<bool> _003C_003E9__235_0;

			internal void niaDxhoSHobJWKtndPenlAHSaTXeA(Exception P_0)
			{
				HandleCallbackException("", P_0);
			}

			internal void ruJNRMqOOyefDuqXVtoSNUuyLGyt(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			}

			internal void fjvzILYxMKByMFJBweLfOGMeQqeA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			}

			internal void sGJpcfyjNHWXKnxjaWAYtffkHyOCA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			}

			internal void EwNpBxYGaoTTnzFwWuQksIaAAUhHA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			}

			internal void OYlcqkdQosffUrJRMcaPUUBiBIeR(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			}

			internal void gWDsMNZvIIDHolaHkMvCKNXVGmDy(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			}

			internal void NmhVOaLORYEUZeOJFKfLTeDjnhCgb(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			}

			internal void iLYOjOJUQTvqcdewSiumYmhDQhhN(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			}

			internal bool xITryYskoQEcxKEyFzMlovgCoDge()
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
		internal const int programVersion4 = 4;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2019";

		private static InputManager_Base dfKlflIDjsZUNtKhPwoXXpnzfYxp;

		private static PlatformInputManager kIYEyNIDuUrPSNKcQjXwLeROpxSc;

		internal static ZMpcfnbkMDhQJzdCqDCNEGJIOILI oLBbvsaIpIbSBPWdHzABkcRnEFqPA;

		internal static FNKIgOISFgsKyonqFvBnwwgKMXdU vnBcsWOiBrsweGQzTZwXEVWsKEyb;

		internal static zKNNZnSHSthbvEKCDSDTTqBJXGfm LmvhkTCrnWKGfgMggYILVjKvuRWf;

		private static ControllerDataFiles TrUvNDsBpLBewgrhUcJYluTgENjsA;

		private static UserData CXDUyJahCSWooVERZIbeGddBeaKq;

		private static bool UKOJIKREswByZtkIQEUQJcfFaZxF;

		private static ConfigVars ukGbLXrYCSMpnnLxJInHsdxuZTKf;

		private static UpdateLoopType dkpNMCVdbZccWUJrkIExRlqmfJMFA;

		private static bool WkPFbmxAjGiQkapUnRbaNBukJiQNA;

		private static Platform YVQyBHMPmWUdKfZnrLVpGIsMzmis;

		private static WebplayerPlatform cgwcexEbFBmOaosKUOGelxwbxCEk;

		private static EditorPlatform IpnsmOoojBqmcUynedtldFXBCUzB;

		private static bool UmJzXUpcElTBhueAOdrwCmuZQuThA;

		private static TimerAbs doiDelyRudjTgCDTkkycLAZRRMTe;

		private static HOafJDFVxlzBogsecPljtcjOpBrIA cDkUjzCJdXHwpgMXoYVYqaYFhWtI;

		private static string OQhWfvHmjfydBnkYFdPCsKYnHpgN;

		private static bool ZxFQTvgLUMzMlqREfkibEbGmvMaY;

		private static bool aSVGvyjXXUKzfsuxyfNECRakidQKA;

		private static bool IBDbMqTWAEPliCbdLPhGGjwzZbEV;

		private static int ovaxTaERxGLLSvqHarEHWaYJCQobA;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int AeueeCznUWNuEJgjpHhggaUXVnim;

		private static int ugkIURROzXdyKzxPjCFHhacpPSIM;

		private static bool hpOCJoGMuToTdZAMJxbcKPzNKNBGA;

		private static readonly UnityTouch EqsZCqTmahIKqtHiLBLEKLjaexktA;

		private static readonly PlayerHelper aZJXDUvppYuHnlpTmMWbSCeyDRFp;

		private static readonly ControllerHelper quEDSttJGbNVVlwIZJpSSnPcmohT;

		private static readonly MappingHelper IDUSZHLelTdSqNfPmyiMoPbwCTzm;

		private static readonly TimeHelper IaYAGXBmPXqEmQIskostEfpJKtjYb;

		private static readonly ConfigHelper LgKNdGkrvEdAfkjYENnVJVwFexTS;

		private static readonly LocalizationHelper pBmjwVtPqFLnhBhDCIKTpbZTcJOS;

		private static readonly GlyphHelper UdkegPjpifPKYgGCKtdXbqgBwjiRc;

		private static eBtTLjQVbrrAMXmgeRiWszpFXAyd ExftKQdwvwdSGcaIGXArMUbBNVrr;

		private static UserDataStore nuUxOPyCGCQRGduJRkkPzwfwAwIS;

		private static IControllerAssigner kYXkpbVTExDecQKltcFEdqrdLuPV;

		private static afHScbWRxrtoFzPRuCPmFlLCDPhb mhQtDSHceHhtNDTyZaWojMmBnYul;

		private static SafeAction<ControllerStatusChangedEventArgs> WwtYipNhPDJxZIBTjvjQKoEnLBck;

		private static SafeAction<ControllerStatusChangedEventArgs> ttjViVPxTmpxrqMyiJBNhhyEmJSK;

		private static SafeAction<ControllerStatusChangedEventArgs> bByLslgojaVqOegynioeejtzBOOfA;

		private static SafeAction nbhdZVJncuHWMBGRRnAbDyNXqRGqA;

		private static SafeAction poreHOuvrHtzDEoEHbnyPyFRCbCy;

		private static SafeAction fFmCfXtNmGQlBatVOBYJtaMjbzBc;

		private static SafeAction jHQfjHIidRTQLRlsuQSpbEGqoOR;

		private static SafeAction NPdMhekwkTKdDFxSioGttVadxujt;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action wAcASZfydmAiIVjUHLLKavYDQrIe;

		private static Action<UpdateLoopType> pllNpOwKvCVetfQShkgWFhQMBZRHA;

		private static Action<UpdateLoopType> butSpgNIMHLweckpZWNXeDjbbTyX;

		private static Action<UpdateLoopType> hNtdHzCvQpnDlMCWxFEtsCfjjBGm;

		private static Action FXLunQzflijcdrptymxvHatiALkdA;

		private static Action<bool> KmQCgHeYOJCxiDBwaOcULBvKOhwqB;

		private static Action<bool> hkiDSocyXIuaQlPHxKsixDCekqlV;

		private static Action<bool> gecIXHFSUoPmLGPfTKwNHBywkppbA;

		private static Action<FullScreenMode> qViubJdMmQnAYuOFvgytOYqFDRRk;

		private static Action CJyVIJbzXbEMGeOsIBFbiBekYmmCA;

		private static Action<bool> tsCulWjUUuZbuOqvCOnhaaqcGTJG;

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

		private static eBtTLjQVbrrAMXmgeRiWszpFXAyd gDCjUaccLpnQcuebaIEpiBtEAKxZ => ExftKQdwvwdSGcaIGXArMUbBNVrr ?? (ExftKQdwvwdSGcaIGXArMUbBNVrr = new eBtTLjQVbrrAMXmgeRiWszpFXAyd(ukGbLXrYCSMpnnLxJInHsdxuZTKf.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return aZJXDUvppYuHnlpTmMWbSCeyDRFp;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return quEDSttJGbNVVlwIZJpSSnPcmohT;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return IDUSZHLelTdSqNfPmyiMoPbwCTzm;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return EqsZCqTmahIKqtHiLBLEKLjaexktA;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return IaYAGXBmPXqEmQIskostEfpJKtjYb;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return nuUxOPyCGCQRGduJRkkPzwfwAwIS;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return LgKNdGkrvEdAfkjYENnVJVwFexTS;
			}
		}

		public static LocalizationHelper localization
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return pBmjwVtPqFLnhBhDCIKTpbZTcJOS;
			}
		}

		public static GlyphHelper glyphs
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return UdkegPjpifPKYgGCKtdXbqgBwjiRc;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 58 + "." + 4 + ".U2019";

		public static bool usingUnityInput => WkPFbmxAjGiQkapUnRbaNBukJiQNA;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
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

		public static bool isReady => UKOJIKREswByZtkIQEUQJcfFaZxF;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => UKOJIKREswByZtkIQEUQJcfFaZxF;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => dkpNMCVdbZccWUJrkIExRlqmfJMFA;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => ukGbLXrYCSMpnnLxJInHsdxuZTKf;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => ukGbLXrYCSMpnnLxJInHsdxuZTKf;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => CXDUyJahCSWooVERZIbeGddBeaKq;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => YVQyBHMPmWUdKfZnrLVpGIsMzmis;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => cgwcexEbFBmOaosKUOGelxwbxCEk;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => IpnsmOoojBqmcUynedtldFXBCUzB;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.Linux && WkPFbmxAjGiQkapUnRbaNBukJiQNA)
				{
					return true;
				}
				if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.OSX && (WkPFbmxAjGiQkapUnRbaNBukJiQNA || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && WkPFbmxAjGiQkapUnRbaNBukJiQNA)
				{
					return true;
				}
				if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.Webplayer && cgwcexEbFBmOaosKUOGelxwbxCEk == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => IpnsmOoojBqmcUynedtldFXBCUzB != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return Guid.Empty;
				}
				return TrUvNDsBpLBewgrhUcJYluTgENjsA.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => aSVGvyjXXUKzfsuxyfNECRakidQKA;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => cDkUjzCJdXHwpgMXoYVYqaYFhWtI.gBbdTEyPLrmihDpWoCuKeotGbOYTA;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => cDkUjzCJdXHwpgMXoYVYqaYFhWtI.CAQHcvsVRnrpDcaVzIopCiQsYHnP;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return 0.0;
				}
				return cDkUjzCJdXHwpgMXoYVYqaYFhWtI.QxBatzayheTKduGHxgiXgQaYWDll;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return 0;
				}
				return mhQtDSHceHhtNDTyZaWojMmBnYul.YxXoYKlUcpWqMVZZfPOdNPiRfJKkA;
			}
		}

		private static bool BYTvUGscfFblGNcCfQJFOchddqYZ
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return OQhWfvHmjfydBnkYFdPCsKYnHpgN == "Game";
				}
				return OQhWfvHmjfydBnkYFdPCsKYnHpgN == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (ukGbLXrYCSMpnnLxJInHsdxuZTKf.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!IBDbMqTWAEPliCbdLPhGGjwzZbEV)
				{
					return BYTvUGscfFblGNcCfQJFOchddqYZ;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (kIYEyNIDuUrPSNKcQjXwLeROpxSc is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return IBDbMqTWAEPliCbdLPhGGjwzZbEV;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return false;
				}
				if (!WkPFbmxAjGiQkapUnRbaNBukJiQNA)
				{
					return false;
				}
				if (YVQyBHMPmWUdKfZnrLVpGIsMzmis != Platform.Windows && (YVQyBHMPmWUdKfZnrLVpGIsMzmis != Platform.Webplayer || cgwcexEbFBmOaosKUOGelxwbxCEk != WebplayerPlatform.Windows))
				{
					return IpnsmOoojBqmcUynedtldFXBCUzB == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool QxxTorUOmbycSULCAAXvYmAcfSaw
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return false;
				}
				if (!mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.value)
				{
					if (hpOCJoGMuToTdZAMJxbcKPzNKNBGA)
					{
						return false;
					}
					if ((!isEditor || !isUnityEditorFocused) && !mhQtDSHceHhtNDTyZaWojMmBnYul.DxqrdfhVyQkdXVkbhGvnvmpiKwO.value)
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
				if (UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsPaused
		{
			get
			{
				if (UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return mhQtDSHceHhtNDTyZaWojMmBnYul.DziKkOiMdRlShDNLUzPfUCjwhfZhA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return mhQtDSHceHhtNDTyZaWojMmBnYul.wKVRomDwDFlWZWlzeKAyYFGflyXf.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return mhQtDSHceHhtNDTyZaWojMmBnYul.DxqrdfhVyQkdXVkbhGvnvmpiKwO.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					return mhQtDSHceHhtNDTyZaWojMmBnYul.UejIvyDwmLGYAOfrbobyeSLhTDGPB.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => dfKlflIDjsZUNtKhPwoXXpnzfYxp;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
				{
					vqslpBZNltBQiAHQLHsMSIiUXpngA();
					return null;
				}
				return kIYEyNIDuUrPSNKcQjXwLeROpxSc.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return kYXkpbVTExDecQKltcFEdqrdLuPV;
			}
			set
			{
				kYXkpbVTExDecQKltcFEdqrdLuPV = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => ugkIURROzXdyKzxPjCFHhacpPSIM;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				WwtYipNhPDJxZIBTjvjQKoEnLBck += value;
			}
			remove
			{
				WwtYipNhPDJxZIBTjvjQKoEnLBck -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				ttjViVPxTmpxrqMyiJBNhhyEmJSK += value;
			}
			remove
			{
				ttjViVPxTmpxrqMyiJBNhhyEmJSK -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				bByLslgojaVqOegynioeejtzBOOfA += value;
			}
			remove
			{
				bByLslgojaVqOegynioeejtzBOOfA -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				nbhdZVJncuHWMBGRRnAbDyNXqRGqA += value;
			}
			remove
			{
				nbhdZVJncuHWMBGRRnAbDyNXqRGqA -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				poreHOuvrHtzDEoEHbnyPyFRCbCy += value;
			}
			remove
			{
				poreHOuvrHtzDEoEHbnyPyFRCbCy -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				fFmCfXtNmGQlBatVOBYJtaMjbzBc += value;
			}
			remove
			{
				fFmCfXtNmGQlBatVOBYJtaMjbzBc -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				jHQfjHIidRTQLRlsuQSpbEGqoOR += value;
			}
			remove
			{
				jHQfjHIidRTQLRlsuQSpbEGqoOR -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				NPdMhekwkTKdDFxSioGttVadxujt += value;
			}
			remove
			{
				NPdMhekwkTKdDFxSioGttVadxujt -= value;
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
				wAcASZfydmAiIVjUHLLKavYDQrIe = (Action)Delegate.Combine(wAcASZfydmAiIVjUHLLKavYDQrIe, value);
			}
			remove
			{
				wAcASZfydmAiIVjUHLLKavYDQrIe = (Action)Delegate.Remove(wAcASZfydmAiIVjUHLLKavYDQrIe, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				pllNpOwKvCVetfQShkgWFhQMBZRHA = (Action<UpdateLoopType>)Delegate.Combine(pllNpOwKvCVetfQShkgWFhQMBZRHA, value);
			}
			remove
			{
				pllNpOwKvCVetfQShkgWFhQMBZRHA = (Action<UpdateLoopType>)Delegate.Remove(pllNpOwKvCVetfQShkgWFhQMBZRHA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				butSpgNIMHLweckpZWNXeDjbbTyX = (Action<UpdateLoopType>)Delegate.Combine(butSpgNIMHLweckpZWNXeDjbbTyX, value);
			}
			remove
			{
				butSpgNIMHLweckpZWNXeDjbbTyX = (Action<UpdateLoopType>)Delegate.Remove(butSpgNIMHLweckpZWNXeDjbbTyX, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				hNtdHzCvQpnDlMCWxFEtsCfjjBGm = (Action<UpdateLoopType>)Delegate.Combine(hNtdHzCvQpnDlMCWxFEtsCfjjBGm, value);
			}
			remove
			{
				hNtdHzCvQpnDlMCWxFEtsCfjjBGm = (Action<UpdateLoopType>)Delegate.Remove(hNtdHzCvQpnDlMCWxFEtsCfjjBGm, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				FXLunQzflijcdrptymxvHatiALkdA = (Action)Delegate.Combine(FXLunQzflijcdrptymxvHatiALkdA, value);
			}
			remove
			{
				FXLunQzflijcdrptymxvHatiALkdA = (Action)Delegate.Remove(FXLunQzflijcdrptymxvHatiALkdA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				KmQCgHeYOJCxiDBwaOcULBvKOhwqB = (Action<bool>)Delegate.Combine(KmQCgHeYOJCxiDBwaOcULBvKOhwqB, value);
			}
			remove
			{
				KmQCgHeYOJCxiDBwaOcULBvKOhwqB = (Action<bool>)Delegate.Remove(KmQCgHeYOJCxiDBwaOcULBvKOhwqB, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				hkiDSocyXIuaQlPHxKsixDCekqlV = (Action<bool>)Delegate.Combine(hkiDSocyXIuaQlPHxKsixDCekqlV, value);
			}
			remove
			{
				hkiDSocyXIuaQlPHxKsixDCekqlV = (Action<bool>)Delegate.Remove(hkiDSocyXIuaQlPHxKsixDCekqlV, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				gecIXHFSUoPmLGPfTKwNHBywkppbA = (Action<bool>)Delegate.Combine(gecIXHFSUoPmLGPfTKwNHBywkppbA, value);
			}
			remove
			{
				gecIXHFSUoPmLGPfTKwNHBywkppbA = (Action<bool>)Delegate.Remove(gecIXHFSUoPmLGPfTKwNHBywkppbA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				qViubJdMmQnAYuOFvgytOYqFDRRk = (Action<FullScreenMode>)Delegate.Combine(qViubJdMmQnAYuOFvgytOYqFDRRk, value);
			}
			remove
			{
				qViubJdMmQnAYuOFvgytOYqFDRRk = (Action<FullScreenMode>)Delegate.Remove(qViubJdMmQnAYuOFvgytOYqFDRRk, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				CJyVIJbzXbEMGeOsIBFbiBekYmmCA = (Action)Delegate.Combine(CJyVIJbzXbEMGeOsIBFbiBekYmmCA, value);
			}
			remove
			{
				CJyVIJbzXbEMGeOsIBFbiBekYmmCA = (Action)Delegate.Remove(CJyVIJbzXbEMGeOsIBFbiBekYmmCA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				tsCulWjUUuZbuOqvCOnhaaqcGTJG = (Action<bool>)Delegate.Combine(tsCulWjUUuZbuOqvCOnhaaqcGTJG, value);
			}
			remove
			{
				tsCulWjUUuZbuOqvCOnhaaqcGTJG = (Action<bool>)Delegate.Remove(tsCulWjUUuZbuOqvCOnhaaqcGTJG, value);
			}
		}

		static ReInput()
		{
			IBDbMqTWAEPliCbdLPhGGjwzZbEV = true;
			ovaxTaERxGLLSvqHarEHWaYJCQobA = -1;
			_id = -1;
			AeueeCznUWNuEJgjpHhggaUXVnim = 0;
			EqsZCqTmahIKqtHiLBLEKLjaexktA = UnityTouch.YkOfalMPfJJtRpqgraJAkfubjGMbA;
			aZJXDUvppYuHnlpTmMWbSCeyDRFp = PlayerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA;
			quEDSttJGbNVVlwIZJpSSnPcmohT = ControllerHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA;
			IDUSZHLelTdSqNfPmyiMoPbwCTzm = MappingHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA;
			IaYAGXBmPXqEmQIskostEfpJKtjYb = TimeHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA;
			LgKNdGkrvEdAfkjYENnVJVwFexTS = ConfigHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA;
			pBmjwVtPqFLnhBhDCIKTpbZTcJOS = LocalizationHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA;
			UdkegPjpifPKYgGCKtdXbqgBwjiRc = GlyphHelper.YkOfalMPfJJtRpqgraJAkfubjGMbA;
			WwtYipNhPDJxZIBTjvjQKoEnLBck = new SafeAction<ControllerStatusChangedEventArgs>(EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.ruJNRMqOOyefDuqXVtoSNUuyLGyt);
			ttjViVPxTmpxrqMyiJBNhhyEmJSK = new SafeAction<ControllerStatusChangedEventArgs>(EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.fjvzILYxMKByMFJBweLfOGMeQqeA);
			bByLslgojaVqOegynioeejtzBOOfA = new SafeAction<ControllerStatusChangedEventArgs>(EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.sGJpcfyjNHWXKnxjaWAYtffkHyOCA);
			nbhdZVJncuHWMBGRRnAbDyNXqRGqA = new SafeAction(EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.EwNpBxYGaoTTnzFwWuQksIaAAUhHA);
			poreHOuvrHtzDEoEHbnyPyFRCbCy = new SafeAction(EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.OYlcqkdQosffUrJRMcaPUUBiBIeR);
			fFmCfXtNmGQlBatVOBYJtaMjbzBc = new SafeAction(EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.gWDsMNZvIIDHolaHkMvCKNXVGmDy);
			jHQfjHIidRTQLRlsuQSpbEGqoOR = new SafeAction(EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.NmhVOaLORYEUZeOJFKfLTeDjnhCgb);
			NPdMhekwkTKdDFxSioGttVadxujt = new SafeAction(EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.iLYOjOJUQTvqcdewSiumYmhDQhhN);
			SafeDelegate.S_ExceptionHandler = EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.niaDxhoSHobJWKtndPenlAHSaTXeA;
		}

		public static void Update()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				if (ukGbLXrYCSMpnnLxJInHsdxuZTKf.updateMode != UpdateMode.Manual)
				{
					Logger.LogError("Rewired cannot be updated manually unless Update Mode is set to Manual.");
				}
				else
				{
					dfKlflIDjsZUNtKhPwoXXpnzfYxp.DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
				}
			}
		}

		public static void Reset()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF && !(dfKlflIDjsZUNtKhPwoXXpnzfYxp == null))
			{
				dfKlflIDjsZUNtKhPwoXXpnzfYxp.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!QxxTorUOmbycSULCAAXvYmAcfSaw)
			{
				return false;
			}
			if (IpnsmOoojBqmcUynedtldFXBCUzB != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (hpOCJoGMuToTdZAMJxbcKPzNKNBGA)
				{
					if (!mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.value)
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

		private static void XlookFnriSXRfPkhjamvGpvMkbok()
		{
			YVQyBHMPmWUdKfZnrLVpGIsMzmis = UnityTools.platform;
			cgwcexEbFBmOaosKUOGelxwbxCEk = UnityTools.webplayerPlatform;
			IpnsmOoojBqmcUynedtldFXBCUzB = UnityTools.editorPlatform;
		}

		internal static void TlzckGoQDITHcUYaslQXPQBOhTwq(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.WiHDuMizgkMjdDkZtXRsLTLElVKgA> P_5, Action<Platform> P_6, Action<InputManager_Base.qSptsGExfDHxNhXKEPOktWGMyvHG> P_7)
		{
			try
			{
				_id = AeueeCznUWNuEJgjpHhggaUXVnim;
				AeueeCznUWNuEJgjpHhggaUXVnim++;
				UKOJIKREswByZtkIQEUQJcfFaZxF = true;
				ZxFQTvgLUMzMlqREfkibEbGmvMaY = true;
				aSVGvyjXXUKzfsuxyfNECRakidQKA = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				dfKlflIDjsZUNtKhPwoXXpnzfYxp = P_0;
				ukGbLXrYCSMpnnLxJInHsdxuZTKf = P_2;
				XlookFnriSXRfPkhjamvGpvMkbok();
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += YrHAuGoVHUlOLdQtmuafGcvTemTAA;
				TrUvNDsBpLBewgrhUcJYluTgENjsA = P_3;
				CXDUyJahCSWooVERZIbeGddBeaKq = P_4;
				doiDelyRudjTgCDTkkycLAZRRMTe = new TimerAbs(1.0);
				cDkUjzCJdXHwpgMXoYVYqaYFhWtI = new HOafJDFVxlzBogsecPljtcjOpBrIA();
				LocalizationManager.Initialize();
				GlyphManager.Initialize();
				P_4.zweOkwOYzJmmdPKMUZyDxJxHpxON();
				ThreadSafeUnityInput.Initialize();
				mhQtDSHceHhtNDTyZaWojMmBnYul = new afHScbWRxrtoFzPRuCPmFlLCDPhb();
				if (!UnityTools.isEditor)
				{
					IBDbMqTWAEPliCbdLPhGGjwzZbEV = Application.isFocused;
				}
				mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.Set(IBDbMqTWAEPliCbdLPhGGjwzZbEV);
				mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.Use();
				if (IpnsmOoojBqmcUynedtldFXBCUzB != EditorPlatform.None)
				{
					mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.getValueDelegate = EWhWZuzbwHUgopSrQLHxbyPQkRFM._003C_003E9.xITryYskoQEcxKEyFzMlovgCoDge;
					if (aSVGvyjXXUKzfsuxyfNECRakidQKA)
					{
						IBDbMqTWAEPliCbdLPhGGjwzZbEV = BYTvUGscfFblGNcCfQJFOchddqYZ;
					}
					mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				hZGEJGisZoDFdTgaRiaUBghwBgcXA();
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
							xfQMULbDolNOSljfhItZwOwIzFQO.TlzckGoQDITHcUYaslQXPQBOhTwq(customPlatformInitOptions);
							bool num = IpnsmOoojBqmcUynedtldFXBCUzB != EditorPlatform.None;
							P_7(new InputManager_Base.qSptsGExfDHxNhXKEPOktWGMyvHG
							{
								eHvBUfHrGWwvGRJKtxTYEJGllGiDb = Platform.Custom,
								pNvaYyOSoXZIFFPBXNIYvkpkabPi = EditorPlatform.None,
								WnnwCOschAaLAzSzNuuFbMfdcHLH = WebplayerPlatform.None
							});
							XlookFnriSXRfPkhjamvGpvMkbok();
							cDkUjzCJdXHwpgMXoYVYqaYFhWtI = new HOafJDFVxlzBogsecPljtcjOpBrIA();
							if (num)
							{
								Logger.LogWarning("A custom platform is in use. All input will be managed by user-defined custom platform handling.");
							}
							break;
						}
					}
				}
				ulPcGzerIFcYfatxiXMNAADePdovA(P_1, P_5(), P_6);
				oLBbvsaIpIbSBPWdHzABkcRnEFqPA = new ZMpcfnbkMDhQJzdCqDCNEGJIOILI(P_4.GetActions_Copy());
				vnBcsWOiBrsweGQzTZwXEVWsKEyb = new FNKIgOISFgsKyonqFvBnwwgKMXdU(P_2, kIYEyNIDuUrPSNKcQjXwLeROpxSc);
				LmvhkTCrnWKGfgMggYILVjKvuRWf = new zKNNZnSHSthbvEKCDSDTTqBJXGfm(P_2);
				kIYEyNIDuUrPSNKcQjXwLeROpxSc.DeviceConnectedEvent += SrJVClCZRyURdldaDaoRDmHkAdycb;
				kIYEyNIDuUrPSNKcQjXwLeROpxSc.DeviceDisconnectedEvent += dlEXHUVqemApLbThPcgYVKmRDFbyA;
				kIYEyNIDuUrPSNKcQjXwLeROpxSc.UpdateControllerInfoEvent += vnRzloVrthjykNtzaKQinuzakWUV;
				vnBcsWOiBrsweGQzTZwXEVWsKEyb.StXxLYlyOaBiSphJveVAkAiMktzR += CxVoPJzsfpaHKNvMMxgkHIbuOWzl;
				vnBcsWOiBrsweGQzTZwXEVWsKEyb.UCTggyfbGAIPtFTzlHEtuldKRzEJ += LmvhkTCrnWKGfgMggYILVjKvuRWf.SYypCjrRtkGujTdFrBIywpGgaLcq;
				ThreadSafeUnityInput.PostInitialize();
				NlnBKjDvrEeltjhyamtkHBqNutvZB();
				ThreadSafeUnityInput.PostInitialize2();
				nuUxOPyCGCQRGduJRkkPzwfwAwIS = UnityTools.GetComponent<UserDataStore>(dfKlflIDjsZUNtKhPwoXXpnzfYxp);
				if (nuUxOPyCGCQRGduJRkkPzwfwAwIS != null)
				{
					nuUxOPyCGCQRGduJRkkPzwfwAwIS.Initialize();
				}
				YybGTGTduYuBnpVMTAGbIXratIpL();
				ZxFQTvgLUMzMlqREfkibEbGmvMaY = false;
				if (aSVGvyjXXUKzfsuxyfNECRakidQKA)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (NPdMhekwkTKdDFxSioGttVadxujt != null)
				{
					NPdMhekwkTKdDFxSioGttVadxujt.Invoke();
				}
			}
			catch (Exception)
			{
				UKOJIKREswByZtkIQEUQJcfFaZxF = false;
				ZxFQTvgLUMzMlqREfkibEbGmvMaY = false;
				throw;
			}
		}

		internal static void YzxJYzIGUbUuQcUjIpyhOcHzsJaf()
		{
			if (cDkUjzCJdXHwpgMXoYVYqaYFhWtI != null)
			{
				cDkUjzCJdXHwpgMXoYVYqaYFhWtI.VJZYLwnozSOjeSmKfhNhCbaWAtFjA();
			}
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < vnBcsWOiBrsweGQzTZwXEVWsKEyb.wfXcGbTMFLTAwDvEytkMGYATlJxS; i++)
				{
					Joystick joystick = vnBcsWOiBrsweGQzTZwXEVWsKEyb.dqbLSAyEdKRYtfOmwCVufVUOhfaN[i];
					rrHRvgllNLfmoeWkqCldUPdjxSfj(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		internal static void bxYiqDXXeENnZsQaaUdUCxkYeQOq(UpdateLoopType P_0)
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				TLtqbaSeuTDZSsdXSUEPOVTHjFkW(P_0);
				if ((uint)P_0 <= 1u)
				{
					lnsoNshxFgadiiViCTHEuiAxzqo();
				}
			}
		}

		private static void TLtqbaSeuTDZSsdXSUEPOVTHjFkW(UpdateLoopType P_0)
		{
			if (mhQtDSHceHhtNDTyZaWojMmBnYul != null)
			{
				mhQtDSHceHhtNDTyZaWojMmBnYul.DsDuSUaDcVanpNAhDLIRqjKndMGi();
			}
			Action<UpdateLoopType> action = pllNpOwKvCVetfQShkgWFhQMBZRHA;
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
			cDkUjzCJdXHwpgMXoYVYqaYFhWtI.DsDuSUaDcVanpNAhDLIRqjKndMGi(P_0);
		}

		private static void lnsoNshxFgadiiViCTHEuiAxzqo()
		{
			int frameCount = Time.frameCount;
			if (ovaxTaERxGLLSvqHarEHWaYJCQobA == frameCount)
			{
				return;
			}
			ovaxTaERxGLLSvqHarEHWaYJCQobA = frameCount;
			ThreadSafeUnityInput.Update();
			Action action = wAcASZfydmAiIVjUHLLKavYDQrIe;
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

		internal static void DsDuSUaDcVanpNAhDLIRqjKndMGi(UpdateLoopType P_0)
		{
			if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				return;
			}
			if (dkpNMCVdbZccWUJrkIExRlqmfJMFA != P_0)
			{
				dkpNMCVdbZccWUJrkIExRlqmfJMFA = P_0;
			}
			if (editorPlatform != EditorPlatform.None)
			{
				OQhWfvHmjfydBnkYFdPCsKYnHpgN = mhQtDSHceHhtNDTyZaWojMmBnYul.sULhgzEJtPTVpuDtrvgYUNyiqAjG.value;
			}
			if (UmJzXUpcElTBhueAOdrwCmuZQuThA)
			{
				if (doiDelyRudjTgCDTkkycLAZRRMTe.Update())
				{
					UmJzXUpcElTBhueAOdrwCmuZQuThA = false;
					doiDelyRudjTgCDTkkycLAZRRMTe.Clear();
				}
				else
				{
					gDCjUaccLpnQcuebaIEpiBtEAKxZ.DsDuSUaDcVanpNAhDLIRqjKndMGi(P_0);
				}
			}
			mhQtDSHceHhtNDTyZaWojMmBnYul.QVPGsookfqdcHfetGjcrckBuNSOpA();
			Action<UpdateLoopType> action = butSpgNIMHLweckpZWNXeDjbbTyX;
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
			kIYEyNIDuUrPSNKcQjXwLeROpxSc.Update(P_0);
			if (nbhdZVJncuHWMBGRRnAbDyNXqRGqA != null)
			{
				nbhdZVJncuHWMBGRRnAbDyNXqRGqA.Invoke();
			}
			vnBcsWOiBrsweGQzTZwXEVWsKEyb.DsDuSUaDcVanpNAhDLIRqjKndMGi(P_0);
			Action<UpdateLoopType> action2 = hNtdHzCvQpnDlMCWxFEtsCfjjBGm;
			if (action2 == null)
			{
				return;
			}
			try
			{
				action2(P_0);
			}
			catch (Exception exception2)
			{
				HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
			}
		}

		internal static void JpDaSvhPAhZCavSOvXPLjMwUTawf()
		{
			Action fXLunQzflijcdrptymxvHatiALkdA = FXLunQzflijcdrptymxvHatiALkdA;
			if (fXLunQzflijcdrptymxvHatiALkdA != null)
			{
				try
				{
					fXLunQzflijcdrptymxvHatiALkdA();
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
			if (UKOJIKREswByZtkIQEUQJcfFaZxF && aSVGvyjXXUKzfsuxyfNECRakidQKA)
			{
				bxYiqDXXeENnZsQaaUdUCxkYeQOq(UpdateLoopType.Update);
				DsDuSUaDcVanpNAhDLIRqjKndMGi(UpdateLoopType.Update);
				JpDaSvhPAhZCavSOvXPLjMwUTawf();
			}
		}

		internal static void dFhadTBnKmNiCleIUhcbXuazKlvv()
		{
			if (fFmCfXtNmGQlBatVOBYJtaMjbzBc != null)
			{
				fFmCfXtNmGQlBatVOBYJtaMjbzBc.Invoke();
			}
			if (kIYEyNIDuUrPSNKcQjXwLeROpxSc != null)
			{
				kIYEyNIDuUrPSNKcQjXwLeROpxSc.OnDestroy();
			}
			icByeYhljryIhtjPcTkdwsfOjrqC();
			if (jHQfjHIidRTQLRlsuQSpbEGqoOR != null)
			{
				jHQfjHIidRTQLRlsuQSpbEGqoOR.Invoke();
				jHQfjHIidRTQLRlsuQSpbEGqoOR = null;
			}
		}

		internal static void FtoGpecFUWJdnCTVjlGqBHBNbEC()
		{
			if (poreHOuvrHtzDEoEHbnyPyFRCbCy != null)
			{
				poreHOuvrHtzDEoEHbnyPyFRCbCy.Invoke();
			}
		}

		internal static void HZEIwTDBTYRviWAsFvtNctYaCCdT(bool P_0)
		{
			IBDbMqTWAEPliCbdLPhGGjwzZbEV = P_0;
			if (IpnsmOoojBqmcUynedtldFXBCUzB == EditorPlatform.None && UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.Set(P_0);
				mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.TriggerEvent();
			}
		}

		internal static void DmthJJfnWgxaOAlCkvvaDwCyMVHx(bool P_0)
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				mhQtDSHceHhtNDTyZaWojMmBnYul.DziKkOiMdRlShDNLUzPfUCjwhfZhA.Set(P_0);
				mhQtDSHceHhtNDTyZaWojMmBnYul.DziKkOiMdRlShDNLUzPfUCjwhfZhA.TriggerEvent();
			}
		}

		internal static void TSHqRczaYTZFuiyENcdjaeElvtiR()
		{
			if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				return;
			}
			Action cJyVIJbzXbEMGeOsIBFbiBekYmmCA = CJyVIJbzXbEMGeOsIBFbiBekYmmCA;
			if (cJyVIJbzXbEMGeOsIBFbiBekYmmCA == null)
			{
				return;
			}
			try
			{
				cJyVIJbzXbEMGeOsIBFbiBekYmmCA();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.SceneLoadedEvent", exception);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return TrUvNDsBpLBewgrhUcJYluTgENjsA.qlERzGUWfMoiJXDloSfiqpIBgBUf(bridgedController);
		}

		internal static HardwareJoystickMap nxdVctUnUdySmaGmpwfGQasImYFq(Guid P_0)
		{
			return TrUvNDsBpLBewgrhUcJYluTgENjsA.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap diDqtoglemKhtlGtYUWzRokAEaDQ(Guid P_0)
		{
			return TrUvNDsBpLBewgrhUcJYluTgENjsA.GetJoystickTemplate(P_0);
		}

		internal static OkTaTaYFMOwbkgTtCFcCRyxWNNrJ vusCEvFeavAPqPHBYxnqdGTgSghv(Guid P_0)
		{
			return TrUvNDsBpLBewgrhUcJYluTgENjsA.vusCEvFeavAPqPHBYxnqdGTgSghv(P_0);
		}

		internal static IHardwareControllerTemplateMap cfNbZCOZOpMMkdhlwDGlazqeZDjeA(Guid P_0)
		{
			return TrUvNDsBpLBewgrhUcJYluTgENjsA.GetControllerTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap bgSGiqWFTNILkooTWQhLxgXaejeP(Guid P_0)
		{
			return TrUvNDsBpLBewgrhUcJYluTgENjsA.bgSGiqWFTNILkooTWQhLxgXaejeP(P_0);
		}

		internal static IList<OkTaTaYFMOwbkgTtCFcCRyxWNNrJ> vlnaYafgxhpVmEZvfuGkVTwUsQmr(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = TrUvNDsBpLBewgrhUcJYluTgENjsA.GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap == null)
			{
				return EmptyObjects<OkTaTaYFMOwbkgTtCFcCRyxWNNrJ>.EmptyReadOnlyIListT;
			}
			string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
			if (templateGuidsOrig == null || templateGuidsOrig.Length == 0)
			{
				return EmptyObjects<OkTaTaYFMOwbkgTtCFcCRyxWNNrJ>.EmptyReadOnlyIListT;
			}
			List<OkTaTaYFMOwbkgTtCFcCRyxWNNrJ> list = null;
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
				OkTaTaYFMOwbkgTtCFcCRyxWNNrJ okTaTaYFMOwbkgTtCFcCRyxWNNrJ = vusCEvFeavAPqPHBYxnqdGTgSghv(guid);
				if (okTaTaYFMOwbkgTtCFcCRyxWNNrJ == null)
				{
					Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
					continue;
				}
				if (list == null)
				{
					list = new List<OkTaTaYFMOwbkgTtCFcCRyxWNNrJ>();
				}
				ListTools.AddIfUnique(list, okTaTaYFMOwbkgTtCFcCRyxWNNrJ);
			}
			if (list == null)
			{
				return EmptyObjects<OkTaTaYFMOwbkgTtCFcCRyxWNNrJ>.EmptyReadOnlyIListT;
			}
			return list;
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return vnBcsWOiBrsweGQzTZwXEVWsKEyb.NYsffresRDKwCZdUqinajwfUIwoYA();
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

		internal static void WLkbIgMPyNsonEqvshyltLDpNawi()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				YybGTGTduYuBnpVMTAGbIXratIpL();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2019 != UnityTools.unityVersionObj.major)
			{
				ZRFDWHhKewiCruFHMInXeyUjoWoqA();
			}
		}

		internal static float hxwLWflxYsGCwXALQGMoKjUJzCYDA()
		{
			return mhQtDSHceHhtNDTyZaWojMmBnYul.SQfOockOhvzbaqsrgOHkyrdcXBeC.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
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

		private static void NlnBKjDvrEeltjhyamtkHBqNutvZB()
		{
			LmvhkTCrnWKGfgMggYILVjKvuRWf.TlzckGoQDITHcUYaslQXPQBOhTwq();
			vnBcsWOiBrsweGQzTZwXEVWsKEyb.TlzckGoQDITHcUYaslQXPQBOhTwq(kIYEyNIDuUrPSNKcQjXwLeROpxSc.GetInputDataUpdateDelegate(), CXDUyJahCSWooVERZIbeGddBeaKq.GetInputBehaviors_Copy());
			kIYEyNIDuUrPSNKcQjXwLeROpxSc.Initialize();
		}

		private static void icByeYhljryIhtjPcTkdwsfOjrqC()
		{
			if (dfKlflIDjsZUNtKhPwoXXpnzfYxp != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(dfKlflIDjsZUNtKhPwoXXpnzfYxp);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			dfKlflIDjsZUNtKhPwoXXpnzfYxp = null;
			kIYEyNIDuUrPSNKcQjXwLeROpxSc = null;
			oLBbvsaIpIbSBPWdHzABkcRnEFqPA = null;
			if (vnBcsWOiBrsweGQzTZwXEVWsKEyb != null)
			{
				vnBcsWOiBrsweGQzTZwXEVWsKEyb.Dispose();
			}
			vnBcsWOiBrsweGQzTZwXEVWsKEyb = null;
			LmvhkTCrnWKGfgMggYILVjKvuRWf = null;
			TrUvNDsBpLBewgrhUcJYluTgENjsA = null;
			if (CXDUyJahCSWooVERZIbeGddBeaKq != null)
			{
				CXDUyJahCSWooVERZIbeGddBeaKq.vjLugohvsLblZuxYcbzfaOVaQPnA();
			}
			CXDUyJahCSWooVERZIbeGddBeaKq = null;
			LocalizationHelper.ugpHHKHDpNItaDxZMwcsRnLBirPS();
			GlyphHelper.ugpHHKHDpNItaDxZMwcsRnLBirPS();
			LocalizationManager.Deinitialize();
			GlyphManager.Deinitialize();
			kYXkpbVTExDecQKltcFEdqrdLuPV = null;
			UKOJIKREswByZtkIQEUQJcfFaZxF = false;
			ukGbLXrYCSMpnnLxJInHsdxuZTKf = null;
			dkpNMCVdbZccWUJrkIExRlqmfJMFA = UpdateLoopType.Update;
			WkPFbmxAjGiQkapUnRbaNBukJiQNA = false;
			YVQyBHMPmWUdKfZnrLVpGIsMzmis = Platform.Windows;
			cgwcexEbFBmOaosKUOGelxwbxCEk = WebplayerPlatform.None;
			IpnsmOoojBqmcUynedtldFXBCUzB = EditorPlatform.None;
			UmJzXUpcElTBhueAOdrwCmuZQuThA = false;
			doiDelyRudjTgCDTkkycLAZRRMTe = null;
			cDkUjzCJdXHwpgMXoYVYqaYFhWtI = null;
			OQhWfvHmjfydBnkYFdPCsKYnHpgN = null;
			hpOCJoGMuToTdZAMJxbcKPzNKNBGA = false;
			aSVGvyjXXUKzfsuxyfNECRakidQKA = false;
			IBDbMqTWAEPliCbdLPhGGjwzZbEV = true;
			ovaxTaERxGLLSvqHarEHWaYJCQobA = -1;
			_id = -1;
			ugkIURROzXdyKzxPjCFHhacpPSIM = 0;
			unscaledDeltaTime = 0.0;
			unscaledTime = 0.0;
			unscaledTimePrev = 0.0;
			currentFrame = 0u;
			previousFrame = 0u;
			absFrame = 0u;
			WwtYipNhPDJxZIBTjvjQKoEnLBck.Clear();
			ttjViVPxTmpxrqMyiJBNhhyEmJSK.Clear();
			bByLslgojaVqOegynioeejtzBOOfA.Clear();
			nbhdZVJncuHWMBGRRnAbDyNXqRGqA.Clear();
			poreHOuvrHtzDEoEHbnyPyFRCbCy.Clear();
			_ApplicationFocusChangedEvent = null;
			_ApplicationPauseChangedEvent = null;
			KmQCgHeYOJCxiDBwaOcULBvKOhwqB = null;
			hkiDSocyXIuaQlPHxKsixDCekqlV = null;
			qViubJdMmQnAYuOFvgytOYqFDRRk = null;
			gecIXHFSUoPmLGPfTKwNHBywkppbA = null;
			wAcASZfydmAiIVjUHLLKavYDQrIe = null;
			butSpgNIMHLweckpZWNXeDjbbTyX = null;
			hNtdHzCvQpnDlMCWxFEtsCfjjBGm = null;
			FXLunQzflijcdrptymxvHatiALkdA = null;
			fFmCfXtNmGQlBatVOBYJtaMjbzBc = null;
			CJyVIJbzXbEMGeOsIBFbiBekYmmCA = null;
			tsCulWjUUuZbuOqvCOnhaaqcGTJG = null;
			sKKFNwDGocdGFXJBTtfEtARnrZwuA();
			mhQtDSHceHhtNDTyZaWojMmBnYul = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= YrHAuGoVHUlOLdQtmuafGcvTemTAA;
			}
			xfQMULbDolNOSljfhItZwOwIzFQO.wJjPIIRJfHhEbGedUconecGfiwzgB();
		}

		private static void otOLcjUShURNVDLHJhEpXcFeRhqG(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void LEMmFIAltMiAQTrcghzxAsRTnUXR()
		{
			if (!UmJzXUpcElTBhueAOdrwCmuZQuThA)
			{
				UmJzXUpcElTBhueAOdrwCmuZQuThA = true;
				gDCjUaccLpnQcuebaIEpiBtEAKxZ.wJjPIIRJfHhEbGedUconecGfiwzgB();
				gDCjUaccLpnQcuebaIEpiBtEAKxZ.CrGZoktgDmxlTHSjZWrxxhPdtStM();
			}
			doiDelyRudjTgCDTkkycLAZRRMTe.Start();
		}

		private static void vqslpBZNltBQiAHQLHsMSIiUXpngA()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void SrJVClCZRyURdldaDaoRDmHkAdycb(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			vnBcsWOiBrsweGQzTZwXEVWsKEyb.BCTLZQnARumowWrfyBZJTuGYtuHO(P_0);
			Joystick joystick = vnBcsWOiBrsweGQzTZwXEVWsKEyb.EPOGytyJCWylBVHKoFQXhUyQAprcb(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				LmvhkTCrnWKGfgMggYILVjKvuRWf.TEpNMPEPLAJUavBzbyUbFVjQrNHh(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !ZxFQTvgLUMzMlqREfkibEbGmvMaY)
				{
					rrHRvgllNLfmoeWkqCldUPdjxSfj(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void dlEXHUVqemApLbThPcgYVKmRDFbyA(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = vnBcsWOiBrsweGQzTZwXEVWsKEyb.EPOGytyJCWylBVHKoFQXhUyQAprcb(P_0.rewiredId);
				if (joystick != null)
				{
					vnBcsWOiBrsweGQzTZwXEVWsKEyb.vJyBZTBAkGLQndXFEnedryYvMetn(P_0.rewiredId);
					NqoeLePLmapoCESkDZoeIlcBvUZy(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void rrHRvgllNLfmoeWkqCldUPdjxSfj(ControllerStatusChangedEventArgs P_0)
		{
			if (WwtYipNhPDJxZIBTjvjQKoEnLBck != null)
			{
				WwtYipNhPDJxZIBTjvjQKoEnLBck.Invoke(P_0);
			}
		}

		private static void CxVoPJzsfpaHKNvMMxgkHIbuOWzl(ControllerStatusChangedEventArgs P_0)
		{
			if (ttjViVPxTmpxrqMyiJBNhhyEmJSK != null)
			{
				ttjViVPxTmpxrqMyiJBNhhyEmJSK.Invoke(P_0);
			}
		}

		private static void NqoeLePLmapoCESkDZoeIlcBvUZy(ControllerStatusChangedEventArgs P_0)
		{
			if (bByLslgojaVqOegynioeejtzBOOfA != null)
			{
				bByLslgojaVqOegynioeejtzBOOfA.Invoke(P_0);
			}
		}

		private static void vnRzloVrthjykNtzaKQinuzakWUV(UpdateControllerInfoEventArgs P_0)
		{
			vnBcsWOiBrsweGQzTZwXEVWsKEyb.RVKAUvgycSVPewVLbYhIRjVBrtIe(P_0);
		}

		private static void LkQTpFBeyUXMAddalyNJQqSBAfDB(bool P_0)
		{
			if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
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

		private static void cfSIQNsuVkXNpqOBXQEpzyiYSzfM(bool P_0)
		{
			if (!UKOJIKREswByZtkIQEUQJcfFaZxF)
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

		private static void IMOKHqNCMaiKxhEynyDZNfmeHGsjb(bool P_0)
		{
			Action<bool> kmQCgHeYOJCxiDBwaOcULBvKOhwqB = KmQCgHeYOJCxiDBwaOcULBvKOhwqB;
			if (kmQCgHeYOJCxiDBwaOcULBvKOhwqB != null)
			{
				try
				{
					kmQCgHeYOJCxiDBwaOcULBvKOhwqB(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void SsTFxcKlGAlFyrGZzaqiLwnBVvFA(int P_0)
		{
			if (qViubJdMmQnAYuOFvgytOYqFDRRk != null)
			{
				try
				{
					qViubJdMmQnAYuOFvgytOYqFDRRk((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void SdBsZCcCpKHlSyjmYttGJZRfNVPH(bool P_0)
		{
			Action<bool> action = hkiDSocyXIuaQlPHxKsixDCekqlV;
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

		private static void cSScePlxUUIYwNvBVCbQHJmnACiIA(bool P_0)
		{
			ugkIURROzXdyKzxPjCFHhacpPSIM++;
			Action<bool> action = gecIXHFSUoPmLGPfTKwNHBywkppbA;
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

		private static void hZGEJGisZoDFdTgaRiaUBghwBgcXA()
		{
			if (mhQtDSHceHhtNDTyZaWojMmBnYul != null)
			{
				sKKFNwDGocdGFXJBTtfEtARnrZwuA();
				mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.ChangedEvent += LkQTpFBeyUXMAddalyNJQqSBAfDB;
				mhQtDSHceHhtNDTyZaWojMmBnYul.DziKkOiMdRlShDNLUzPfUCjwhfZhA.ChangedEvent += cfSIQNsuVkXNpqOBXQEpzyiYSzfM;
				mhQtDSHceHhtNDTyZaWojMmBnYul.wKVRomDwDFlWZWlzeKAyYFGflyXf.ChangedEvent += IMOKHqNCMaiKxhEynyDZNfmeHGsjb;
				mhQtDSHceHhtNDTyZaWojMmBnYul.DxqrdfhVyQkdXVkbhGvnvmpiKwO.ChangedEvent += SdBsZCcCpKHlSyjmYttGJZRfNVPH;
				mhQtDSHceHhtNDTyZaWojMmBnYul.RDFSYbOhyAmilvRwlQxsRCjbiSiC.ChangedEvent += SsTFxcKlGAlFyrGZzaqiLwnBVvFA;
				mhQtDSHceHhtNDTyZaWojMmBnYul.UejIvyDwmLGYAOfrbobyeSLhTDGPB.ChangedEvent += cSScePlxUUIYwNvBVCbQHJmnACiIA;
			}
		}

		private static void sKKFNwDGocdGFXJBTtfEtARnrZwuA()
		{
			if (mhQtDSHceHhtNDTyZaWojMmBnYul != null)
			{
				mhQtDSHceHhtNDTyZaWojMmBnYul.wctCmdqGBFxjxSnPwpFfbwanRTpG.ChangedEvent -= LkQTpFBeyUXMAddalyNJQqSBAfDB;
				mhQtDSHceHhtNDTyZaWojMmBnYul.DziKkOiMdRlShDNLUzPfUCjwhfZhA.ChangedEvent -= cfSIQNsuVkXNpqOBXQEpzyiYSzfM;
				mhQtDSHceHhtNDTyZaWojMmBnYul.wKVRomDwDFlWZWlzeKAyYFGflyXf.ChangedEvent -= IMOKHqNCMaiKxhEynyDZNfmeHGsjb;
				mhQtDSHceHhtNDTyZaWojMmBnYul.DxqrdfhVyQkdXVkbhGvnvmpiKwO.ChangedEvent -= SdBsZCcCpKHlSyjmYttGJZRfNVPH;
				mhQtDSHceHhtNDTyZaWojMmBnYul.RDFSYbOhyAmilvRwlQxsRCjbiSiC.ChangedEvent -= SsTFxcKlGAlFyrGZzaqiLwnBVvFA;
				mhQtDSHceHhtNDTyZaWojMmBnYul.UejIvyDwmLGYAOfrbobyeSLhTDGPB.ChangedEvent -= cSScePlxUUIYwNvBVCbQHJmnACiIA;
			}
		}

		private static void YrHAuGoVHUlOLdQtmuafGcvTemTAA(bool P_0)
		{
			Action<bool> action = tsCulWjUUuZbuOqvCOnhaaqcGTJG;
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

		private static void ulPcGzerIFcYfatxiXMNAADePdovA(Func<ConfigVars, object> P_0, UnityTools.WiHDuMizgkMjdDkZtXRsLTLElVKgA P_1, Action<Platform> P_2)
		{
			bool flag = false;
			if (P_1.VnRZZRuzYsSRcjYOtZKUgeYeqowl != P_1.OpHpPYodDUZWJDdScPUVsMWHPFeh)
			{
				UnityTools.WiHDuMizgkMjdDkZtXRsLTLElVKgA wiHDuMizgkMjdDkZtXRsLTLElVKgA = P_1;
				wiHDuMizgkMjdDkZtXRsLTLElVKgA.VnRZZRuzYsSRcjYOtZKUgeYeqowl = P_1.OpHpPYodDUZWJDdScPUVsMWHPFeh;
				UnityTools.TlzckGoQDITHcUYaslQXPQBOhTwq(wiHDuMizgkMjdDkZtXRsLTLElVKgA);
				P_2(wiHDuMizgkMjdDkZtXRsLTLElVKgA.OpHpPYodDUZWJDdScPUVsMWHPFeh);
				XlookFnriSXRfPkhjamvGpvMkbok();
				flag = true;
			}
			if (!configVars.DoesPlatformUseFallback(P_1.OpHpPYodDUZWJDdScPUVsMWHPFeh, P_1.WnnwCOschAaLAzSzNuuFbMfdcHLH, isEditor) && !configVars.DoesPlatformUseFallback(P_1.VnRZZRuzYsSRcjYOtZKUgeYeqowl, P_1.WnnwCOschAaLAzSzNuuFbMfdcHLH, isEditor))
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(dfKlflIDjsZUNtKhPwoXXpnzfYxp);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(P_1.OpHpPYodDUZWJDdScPUVsMWHPFeh, ukGbLXrYCSMpnnLxJInHsdxuZTKf) is PlatformInputManager platformInputManager)
					{
						kIYEyNIDuUrPSNKcQjXwLeROpxSc = platformInputManager;
						return;
					}
				}
			}
			if (flag)
			{
				UnityTools.TlzckGoQDITHcUYaslQXPQBOhTwq(P_1);
				P_2(P_1.OpHpPYodDUZWJDdScPUVsMWHPFeh);
				XlookFnriSXRfPkhjamvGpvMkbok();
				flag = false;
			}
			if (configVars.DoesPlatformUseFallback(YVQyBHMPmWUdKfZnrLVpGIsMzmis, cgwcexEbFBmOaosKUOGelxwbxCEk, isEditor))
			{
				WkPFbmxAjGiQkapUnRbaNBukJiQNA = true;
				kIYEyNIDuUrPSNKcQjXwLeROpxSc = new hMQIZPyKJMwNVAVsJSknVtsealZN(ukGbLXrYCSMpnnLxJInHsdxuZTKf.updateLoop);
			}
			else if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.Windows || YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.WindowsAppStore || YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.WindowsUWP || YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.OSX || YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.Linux)
			{
				kIYEyNIDuUrPSNKcQjXwLeROpxSc = P_0(ukGbLXrYCSMpnnLxJInHsdxuZTKf) as PlatformInputManager;
			}
			else if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.WebGL && !isEditor)
			{
				try
				{
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = P_0(ukGbLXrYCSMpnnLxJInHsdxuZTKf) as PlatformInputManager;
					if (kIYEyNIDuUrPSNKcQjXwLeROpxSc == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = null;
				}
			}
			else if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.XboxOne && !isEditor)
			{
				try
				{
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = new CustomInputManager(new XboxOneInputSource(), ukGbLXrYCSMpnnLxJInHsdxuZTKf.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (kIYEyNIDuUrPSNKcQjXwLeROpxSc == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = null;
				}
			}
			else if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.PS4 && !isEditor)
			{
				try
				{
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = P_0(ukGbLXrYCSMpnnLxJInHsdxuZTKf) as PlatformInputManager;
					if (kIYEyNIDuUrPSNKcQjXwLeROpxSc == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
					Logger.LogError(msg);
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = null;
				}
			}
			else if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.PS5 && !isEditor)
			{
				try
				{
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = P_0(ukGbLXrYCSMpnnLxJInHsdxuZTKf) as PlatformInputManager;
					if (kIYEyNIDuUrPSNKcQjXwLeROpxSc == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
					Logger.LogError(msg2);
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = null;
				}
			}
			else if ((YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.GameCoreXboxOne || YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = P_0(ukGbLXrYCSMpnnLxJInHsdxuZTKf) as PlatformInputManager;
					if (kIYEyNIDuUrPSNKcQjXwLeROpxSc == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg3)
				{
					string text = ((YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg3);
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = null;
				}
			}
			else if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.Ouya && !isEditor)
			{
				Logger.LogError("Ouya is no longer supported.");
				kIYEyNIDuUrPSNKcQjXwLeROpxSc = null;
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.qzTujNnjGDlxsPwAaUDjnOIzcOGM = P_0(ukGbLXrYCSMpnnLxJInHsdxuZTKf) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg4)
				{
					Logger.LogError(msg4);
				}
			}
			else if (YVQyBHMPmWUdKfZnrLVpGIsMzmis == Platform.Custom)
			{
				try
				{
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = new CustomInputManager(xfQMULbDolNOSljfhItZwOwIzFQO.MvFScWscrxeEtNjKiqsXvDnglmgC(), ukGbLXrYCSMpnnLxJInHsdxuZTKf.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (kIYEyNIDuUrPSNKcQjXwLeROpxSc == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Custom platform could not be initialized due to an exception!");
					kIYEyNIDuUrPSNKcQjXwLeROpxSc = null;
					throw;
				}
			}
			if (kIYEyNIDuUrPSNKcQjXwLeROpxSc == null)
			{
				WkPFbmxAjGiQkapUnRbaNBukJiQNA = true;
				kIYEyNIDuUrPSNKcQjXwLeROpxSc = new hMQIZPyKJMwNVAVsJSknVtsealZN(ukGbLXrYCSMpnnLxJInHsdxuZTKf.updateLoop);
			}
		}

		private static void YybGTGTduYuBnpVMTAGbIXratIpL()
		{
			if (hpOCJoGMuToTdZAMJxbcKPzNKNBGA != ukGbLXrYCSMpnnLxJInHsdxuZTKf.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				hpOCJoGMuToTdZAMJxbcKPzNKNBGA = !hpOCJoGMuToTdZAMJxbcKPzNKNBGA;
			}
		}

		private static void ZRFDWHhKewiCruFHMInXeyUjoWoqA()
		{
			if (!(UnityTools.unityVersionObj == null))
			{
				Logger.LogWarning("The version of Rewired installed (" + programVersion + ") was not designed for Unity " + UnityTools.unityVersionObj.major + ". Please install Rewired for Unity " + UnityTools.unityVersionObj.major + ".\n\nThis warning does not mean that Rewired will not function, but it may not function optimally.\n\nSome different major versions of Unity download Asset Store assets to the same folder location on disk, so if you download an asset in one version of the Unity editor, then open another version of the Unity editor and install the asset without re-downloading it, the wrong asset version will be installed. To fix this, manually re-download Rewired in the Unity Asset Store panel in this version of the Unity Editor, then install it.\n\nIf you are using a beta version of a new major version of Unity, you will have to wait until the release of the final version before a compatible version of Rewired can be uploaded to the Asset Store. When the new version is ready, it will be available through the Unity Asset Store for download as usual.");
			}
		}
	}
}
