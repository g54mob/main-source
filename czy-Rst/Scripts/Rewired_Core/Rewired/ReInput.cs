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
			private static LocalizationHelper EUiqIDOJYkzMqVSSxThYjRGDMyXv;

			internal static LocalizationHelper hPVGmFrmxwEQzAQCEwHaDMIZfLxi => EUiqIDOJYkzMqVSSxThYjRGDMyXv ?? (EUiqIDOJYkzMqVSSxThYjRGDMyXv = new LocalizationHelper());

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

			internal static void ROYCfdKalSTRRIocdSUKgTaeLzCNc()
			{
				EUiqIDOJYkzMqVSSxThYjRGDMyXv = null;
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
			private static GlyphHelper UTqoSSPaKgLAQknAIvrbvwmdnSyF;

			internal static GlyphHelper xFPduNCwrrVWYmjqjAjJEKDVXNysA => UTqoSSPaKgLAQknAIvrbvwmdnSyF ?? (UTqoSSPaKgLAQknAIvrbvwmdnSyF = new GlyphHelper());

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

			internal static void ddKalqeMivSXTnVXkiEuxpaNEcGA()
			{
				UTqoSSPaKgLAQknAIvrbvwmdnSyF = null;
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
			private static ConfigHelper AGXZtuItyFdDmHQuqHdzLunIDhcb;

			private float ltRGRTvkMcOZhLWqqcTZSzlDBwNT = 0.7f;

			private float zRrSqyRAgCKldttuTknorYyWVlYc = 100f;

			internal static ConfigHelper ntQyYYYAVXWXqxiCmimfWyvYQNOn => AGXZtuItyFdDmHQuqHdzLunIDhcb ?? (AGXZtuItyFdDmHQuqHdzLunIDhcb = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.useXInput;
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
						if (afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.useXInput == value)
						{
							return;
						}
						if (value)
						{
							if (afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								Logger.LogWarning("XInput cannot be enabled with the current primary input source: " + afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("XInput cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.useXInput = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					if (UnityTools.effectivePlatform == Platform.Windows && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_useWindowsGamingInput();
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
						if (afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_useWindowsGamingInput() == value)
						{
							return;
						}
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.SetPlatformVar_useWindowsGamingInput(value);
						if (value)
						{
							if (afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
							{
								Logger.LogWarning("Windows Gaming Input cannot be enabled with the current primary input source: " + afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("Windows Gaming Input cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.updateMode;
				}
				set
				{
					if (CheckInitialized() && value != afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.updateMode)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.updateMode = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.updateLoop = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.effectivePlatform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.useXInput = true;
						}
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.osx_primaryInputSource != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.osx_primaryInputSource = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.linux_primaryInputSource != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.linux_primaryInputSource = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.windowsUWP_primaryInputSource = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return (afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return (afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useGamepadAPI != value)
					{
						platformVars_WindowsUWP.useGamepadAPI = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					if (UnityTools.effectivePlatform == Platform.OSX && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.osx_primaryInputSource == OSXStandalonePrimaryInputSource.GameController)
					{
						return true;
					}
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_useAppleGameController();
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_useAppleGameController() != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.SetPlatformVar_useAppleGameController(value);
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.xboxOne_primaryInputSource != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.xboxOne_primaryInputSource = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.ps4_primaryInputSource != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.ps4_primaryInputSource = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.webGL_primaryInputSource != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.webGL_primaryInputSource = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.alwaysUseUnityInput != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.alwaysUseUnityInput = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.SetPlatformVar_useNativeMouse(value) && kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
					{
						kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
					{
						kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
					{
						kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_joystickRefreshRate();
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
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						gjvZvadYVTPdHYtsUXbCcmTOfADi();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.android_supportUnknownGamepads != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.android_supportUnknownGamepads = value;
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.defaultAxisSensitivityType != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.defaultAxisSensitivityType = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.force4WayHats != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.force4WayHats = value;
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
					return ltRGRTvkMcOZhLWqqcTZSzlDBwNT;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (ltRGRTvkMcOZhLWqqcTZSzlDBwNT != value)
						{
							ltRGRTvkMcOZhLWqqcTZSzlDBwNT = value;
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
					return zRrSqyRAgCKldttuTknorYyWVlYc;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (zRrSqyRAgCKldttuTknorYyWVlYc != value)
						{
							zRrSqyRAgCKldttuTknorYyWVlYc = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.activateActionButtonsOnNegativeValue = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.throttleCalibrationMode != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.throttleCalibrationMode = value;
						VeAmGFtEIHUuquEZXjxbJYdKKrEb.vpYcAjODiwCjetgWTIQLfpMDqSbY(value);
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.keyCombinationOverrideMode;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.keyCombinationOverrideMode != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.keyCombinationOverrideMode = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.generateKeyEventsOnKeyCombinationOverride;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.generateKeyEventsOnKeyCombinationOverride != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.generateKeyEventsOnKeyCombinationOverride = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.autoAssignJoysticks != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.autoAssignJoysticks = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.maxJoysticksPerPlayer != value)
						{
							afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.maxJoysticksPerPlayer = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.distributeJoysticksEvenly != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.distributeJoysticksEvenly = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.logLevel != value)
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.logLevel = value;
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
					return new List<EnhancedDeviceSupportDeviceType>(afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes());
				}
				set
				{
					if (CheckInitialized())
					{
						afadmdopkFDkKcMXUOVulpLPkXjgA.ConfigVars.SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(value);
						if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
						{
							kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
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
				private sealed class HfmXyOwNFhZZpizOnWkLwvdVCerA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int wbrxkofDVZtDiToNsPEOzLILkGKd;

					private ControllerPollingInfo UceSRnvbamhBfKMPiJCiyUEofKeEA;

					private int kNCzuVMiZTiZodFaGPDVKIygbvMt;

					public PollingHelper pXkdQllkrlOEGNgzzDelFbrvgaCPA;

					private IEnumerator<ControllerPollingInfo> XJRSxhmCcdgAEMSnidhamdhnoOWX;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return UceSRnvbamhBfKMPiJCiyUEofKeEA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return UceSRnvbamhBfKMPiJCiyUEofKeEA;
						}
					}

					[DebuggerHidden]
					public HfmXyOwNFhZZpizOnWkLwvdVCerA(int P_0)
					{
						wbrxkofDVZtDiToNsPEOzLILkGKd = P_0;
						kNCzuVMiZTiZodFaGPDVKIygbvMt = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (wbrxkofDVZtDiToNsPEOzLILkGKd)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								QfYONHPQXoyjxaVWWRQKSafbULdg();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								iSwhSnsWUHPaqGOyDTgBaRdGWwmE();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								rGiYieawLOBXNFbVoJuQdPQkdcpb();
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
							int num = wbrxkofDVZtDiToNsPEOzLILkGKd;
							PollingHelper pollingHelper = pXkdQllkrlOEGNgzzDelFbrvgaCPA;
							switch (num)
							{
							default:
								return false;
							case 0:
								wbrxkofDVZtDiToNsPEOzLILkGKd = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								XJRSxhmCcdgAEMSnidhamdhnoOWX = pollingHelper.BWIhgLnFnWVnBEdhXxYOzLleRknn().GetEnumerator();
								wbrxkofDVZtDiToNsPEOzLILkGKd = -3;
								goto IL_0084;
							case 1:
								wbrxkofDVZtDiToNsPEOzLILkGKd = -3;
								goto IL_0084;
							case 2:
								wbrxkofDVZtDiToNsPEOzLILkGKd = -4;
								goto IL_00e4;
							case 3:
								{
									wbrxkofDVZtDiToNsPEOzLILkGKd = -5;
									break;
								}
								IL_00e4:
								if (XJRSxhmCcdgAEMSnidhamdhnoOWX.MoveNext())
								{
									ControllerPollingInfo current = XJRSxhmCcdgAEMSnidhamdhnoOWX.Current;
									UceSRnvbamhBfKMPiJCiyUEofKeEA = current;
									wbrxkofDVZtDiToNsPEOzLILkGKd = 2;
									return true;
								}
								iSwhSnsWUHPaqGOyDTgBaRdGWwmE();
								XJRSxhmCcdgAEMSnidhamdhnoOWX = null;
								XJRSxhmCcdgAEMSnidhamdhnoOWX = pollingHelper.ZJfBXYbIUuNUYfvBdBhxDGIcFAfud().GetEnumerator();
								wbrxkofDVZtDiToNsPEOzLILkGKd = -5;
								break;
								IL_0084:
								if (XJRSxhmCcdgAEMSnidhamdhnoOWX.MoveNext())
								{
									ControllerPollingInfo current2 = XJRSxhmCcdgAEMSnidhamdhnoOWX.Current;
									UceSRnvbamhBfKMPiJCiyUEofKeEA = current2;
									wbrxkofDVZtDiToNsPEOzLILkGKd = 1;
									return true;
								}
								QfYONHPQXoyjxaVWWRQKSafbULdg();
								XJRSxhmCcdgAEMSnidhamdhnoOWX = null;
								XJRSxhmCcdgAEMSnidhamdhnoOWX = pollingHelper.TgFeKdAEzaVNnTrIioSdsSfScFbJb().GetEnumerator();
								wbrxkofDVZtDiToNsPEOzLILkGKd = -4;
								goto IL_00e4;
							}
							if (XJRSxhmCcdgAEMSnidhamdhnoOWX.MoveNext())
							{
								ControllerPollingInfo current3 = XJRSxhmCcdgAEMSnidhamdhnoOWX.Current;
								UceSRnvbamhBfKMPiJCiyUEofKeEA = current3;
								wbrxkofDVZtDiToNsPEOzLILkGKd = 3;
								return true;
							}
							rGiYieawLOBXNFbVoJuQdPQkdcpb();
							XJRSxhmCcdgAEMSnidhamdhnoOWX = null;
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

					private void QfYONHPQXoyjxaVWWRQKSafbULdg()
					{
						wbrxkofDVZtDiToNsPEOzLILkGKd = -1;
						if (XJRSxhmCcdgAEMSnidhamdhnoOWX != null)
						{
							XJRSxhmCcdgAEMSnidhamdhnoOWX.Dispose();
						}
					}

					private void iSwhSnsWUHPaqGOyDTgBaRdGWwmE()
					{
						wbrxkofDVZtDiToNsPEOzLILkGKd = -1;
						if (XJRSxhmCcdgAEMSnidhamdhnoOWX != null)
						{
							XJRSxhmCcdgAEMSnidhamdhnoOWX.Dispose();
						}
					}

					private void rGiYieawLOBXNFbVoJuQdPQkdcpb()
					{
						wbrxkofDVZtDiToNsPEOzLILkGKd = -1;
						if (XJRSxhmCcdgAEMSnidhamdhnoOWX != null)
						{
							XJRSxhmCcdgAEMSnidhamdhnoOWX.Dispose();
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
						HfmXyOwNFhZZpizOnWkLwvdVCerA hfmXyOwNFhZZpizOnWkLwvdVCerA;
						if (wbrxkofDVZtDiToNsPEOzLILkGKd == -2 && kNCzuVMiZTiZodFaGPDVKIygbvMt == Environment.CurrentManagedThreadId)
						{
							wbrxkofDVZtDiToNsPEOzLILkGKd = 0;
							hfmXyOwNFhZZpizOnWkLwvdVCerA = this;
						}
						else
						{
							hfmXyOwNFhZZpizOnWkLwvdVCerA = new HfmXyOwNFhZZpizOnWkLwvdVCerA(0);
							hfmXyOwNFhZZpizOnWkLwvdVCerA.pXkdQllkrlOEGNgzzDelFbrvgaCPA = pXkdQllkrlOEGNgzzDelFbrvgaCPA;
						}
						return hfmXyOwNFhZZpizOnWkLwvdVCerA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class xJCAWpBPGYrcsCnMVxltauDwJlFW : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int vCwkcKiZqpJFfJYZNdENZtEsQuSg;

					private ControllerPollingInfo iPWTiKtGtgIrDKpVXMYENpHWUAxc;

					private int dYMRQoykPpyfWwLaXAkbyFNiWjsy;

					public PollingHelper qHCIZiRjptGNRetFWzXkrwokqynC;

					private IEnumerator<ControllerPollingInfo> TJWQljjHkssSGhkRLmdXgloMFyuZ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return iPWTiKtGtgIrDKpVXMYENpHWUAxc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return iPWTiKtGtgIrDKpVXMYENpHWUAxc;
						}
					}

					[DebuggerHidden]
					public xJCAWpBPGYrcsCnMVxltauDwJlFW(int P_0)
					{
						vCwkcKiZqpJFfJYZNdENZtEsQuSg = P_0;
						dYMRQoykPpyfWwLaXAkbyFNiWjsy = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (vCwkcKiZqpJFfJYZNdENZtEsQuSg)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								QKwMEPODvaiqCLwLwXxkDUfvowhE();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								cuhFRutWoqpVeyoMfWLSNjMSbzCo();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								llSgVNgsatfxWEpRkQQvbnaKVNHFc();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								zebGDJTrLvBnoPjgFBHQDdtupaXhb();
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
							int num = vCwkcKiZqpJFfJYZNdENZtEsQuSg;
							PollingHelper pollingHelper = qHCIZiRjptGNRetFWzXkrwokqynC;
							switch (num)
							{
							default:
								return false;
							case 0:
								vCwkcKiZqpJFfJYZNdENZtEsQuSg = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								TJWQljjHkssSGhkRLmdXgloMFyuZ = pollingHelper.jxFEPHDAILNkrjuKGXIraLDOebswb().GetEnumerator();
								vCwkcKiZqpJFfJYZNdENZtEsQuSg = -3;
								goto IL_0088;
							case 1:
								vCwkcKiZqpJFfJYZNdENZtEsQuSg = -3;
								goto IL_0088;
							case 2:
								vCwkcKiZqpJFfJYZNdENZtEsQuSg = -4;
								goto IL_00e8;
							case 3:
								vCwkcKiZqpJFfJYZNdENZtEsQuSg = -5;
								goto IL_0148;
							case 4:
								{
									vCwkcKiZqpJFfJYZNdENZtEsQuSg = -6;
									break;
								}
								IL_00e8:
								if (TJWQljjHkssSGhkRLmdXgloMFyuZ.MoveNext())
								{
									ControllerPollingInfo current = TJWQljjHkssSGhkRLmdXgloMFyuZ.Current;
									iPWTiKtGtgIrDKpVXMYENpHWUAxc = current;
									vCwkcKiZqpJFfJYZNdENZtEsQuSg = 2;
									return true;
								}
								cuhFRutWoqpVeyoMfWLSNjMSbzCo();
								TJWQljjHkssSGhkRLmdXgloMFyuZ = null;
								TJWQljjHkssSGhkRLmdXgloMFyuZ = pollingHelper.qTgsGbJtGcWATIssuVHTppydNOEj().GetEnumerator();
								vCwkcKiZqpJFfJYZNdENZtEsQuSg = -5;
								goto IL_0148;
								IL_0088:
								if (TJWQljjHkssSGhkRLmdXgloMFyuZ.MoveNext())
								{
									ControllerPollingInfo current2 = TJWQljjHkssSGhkRLmdXgloMFyuZ.Current;
									iPWTiKtGtgIrDKpVXMYENpHWUAxc = current2;
									vCwkcKiZqpJFfJYZNdENZtEsQuSg = 1;
									return true;
								}
								QKwMEPODvaiqCLwLwXxkDUfvowhE();
								TJWQljjHkssSGhkRLmdXgloMFyuZ = null;
								TJWQljjHkssSGhkRLmdXgloMFyuZ = pollingHelper.OiskaGKoXwmsWuNcmmkuEbMBzCyE().GetEnumerator();
								vCwkcKiZqpJFfJYZNdENZtEsQuSg = -4;
								goto IL_00e8;
								IL_0148:
								if (TJWQljjHkssSGhkRLmdXgloMFyuZ.MoveNext())
								{
									ControllerPollingInfo current3 = TJWQljjHkssSGhkRLmdXgloMFyuZ.Current;
									iPWTiKtGtgIrDKpVXMYENpHWUAxc = current3;
									vCwkcKiZqpJFfJYZNdENZtEsQuSg = 3;
									return true;
								}
								llSgVNgsatfxWEpRkQQvbnaKVNHFc();
								TJWQljjHkssSGhkRLmdXgloMFyuZ = null;
								TJWQljjHkssSGhkRLmdXgloMFyuZ = pollingHelper.tPyHQjICDHRAffYowiYUHuPfWJwK().GetEnumerator();
								vCwkcKiZqpJFfJYZNdENZtEsQuSg = -6;
								break;
							}
							if (TJWQljjHkssSGhkRLmdXgloMFyuZ.MoveNext())
							{
								ControllerPollingInfo current4 = TJWQljjHkssSGhkRLmdXgloMFyuZ.Current;
								iPWTiKtGtgIrDKpVXMYENpHWUAxc = current4;
								vCwkcKiZqpJFfJYZNdENZtEsQuSg = 4;
								return true;
							}
							zebGDJTrLvBnoPjgFBHQDdtupaXhb();
							TJWQljjHkssSGhkRLmdXgloMFyuZ = null;
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

					private void QKwMEPODvaiqCLwLwXxkDUfvowhE()
					{
						vCwkcKiZqpJFfJYZNdENZtEsQuSg = -1;
						if (TJWQljjHkssSGhkRLmdXgloMFyuZ != null)
						{
							TJWQljjHkssSGhkRLmdXgloMFyuZ.Dispose();
						}
					}

					private void cuhFRutWoqpVeyoMfWLSNjMSbzCo()
					{
						vCwkcKiZqpJFfJYZNdENZtEsQuSg = -1;
						if (TJWQljjHkssSGhkRLmdXgloMFyuZ != null)
						{
							TJWQljjHkssSGhkRLmdXgloMFyuZ.Dispose();
						}
					}

					private void llSgVNgsatfxWEpRkQQvbnaKVNHFc()
					{
						vCwkcKiZqpJFfJYZNdENZtEsQuSg = -1;
						if (TJWQljjHkssSGhkRLmdXgloMFyuZ != null)
						{
							TJWQljjHkssSGhkRLmdXgloMFyuZ.Dispose();
						}
					}

					private void zebGDJTrLvBnoPjgFBHQDdtupaXhb()
					{
						vCwkcKiZqpJFfJYZNdENZtEsQuSg = -1;
						if (TJWQljjHkssSGhkRLmdXgloMFyuZ != null)
						{
							TJWQljjHkssSGhkRLmdXgloMFyuZ.Dispose();
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
						xJCAWpBPGYrcsCnMVxltauDwJlFW xJCAWpBPGYrcsCnMVxltauDwJlFW2;
						if (vCwkcKiZqpJFfJYZNdENZtEsQuSg == -2 && dYMRQoykPpyfWwLaXAkbyFNiWjsy == Environment.CurrentManagedThreadId)
						{
							vCwkcKiZqpJFfJYZNdENZtEsQuSg = 0;
							xJCAWpBPGYrcsCnMVxltauDwJlFW2 = this;
						}
						else
						{
							xJCAWpBPGYrcsCnMVxltauDwJlFW2 = new xJCAWpBPGYrcsCnMVxltauDwJlFW(0);
							xJCAWpBPGYrcsCnMVxltauDwJlFW2.qHCIZiRjptGNRetFWzXkrwokqynC = qHCIZiRjptGNRetFWzXkrwokqynC;
						}
						return xJCAWpBPGYrcsCnMVxltauDwJlFW2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class xyragxPIkPZxvNbeTCAsMoGlsvKR : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int vDrSWUlOlQosdxePZEmsYYFqHTTq;

					private ControllerPollingInfo goqxSsCqvOtGdaOAanblzINodmBK;

					private int cnFtoAJhzwypoLOdPZddfFigxnxd;

					public PollingHelper UmhXIpIYrfsabrLQbKUhnvRXcpDv;

					private IEnumerator<ControllerPollingInfo> SZAocjwnPLgmKNoJBBKmEMNgSdjf;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return goqxSsCqvOtGdaOAanblzINodmBK;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return goqxSsCqvOtGdaOAanblzINodmBK;
						}
					}

					[DebuggerHidden]
					public xyragxPIkPZxvNbeTCAsMoGlsvKR(int P_0)
					{
						vDrSWUlOlQosdxePZEmsYYFqHTTq = P_0;
						cnFtoAJhzwypoLOdPZddfFigxnxd = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (vDrSWUlOlQosdxePZEmsYYFqHTTq)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								cDaYbjVCVkmHcTSyzIBwHFngTNQi();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								PwUWqMbocUMOZOUlcGSooLGWiwsl();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								VyfhuAbzCfkqtFruqtIjEqkuUbSX();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								JyCWobnNqEoSPQBFgykVPoLlbpXR();
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
							int num = vDrSWUlOlQosdxePZEmsYYFqHTTq;
							PollingHelper umhXIpIYrfsabrLQbKUhnvRXcpDv = UmhXIpIYrfsabrLQbKUhnvRXcpDv;
							switch (num)
							{
							default:
								return false;
							case 0:
								vDrSWUlOlQosdxePZEmsYYFqHTTq = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								SZAocjwnPLgmKNoJBBKmEMNgSdjf = umhXIpIYrfsabrLQbKUhnvRXcpDv.ezdZYbCAyMerPeBLKNoRwZBwukvd().GetEnumerator();
								vDrSWUlOlQosdxePZEmsYYFqHTTq = -3;
								goto IL_0088;
							case 1:
								vDrSWUlOlQosdxePZEmsYYFqHTTq = -3;
								goto IL_0088;
							case 2:
								vDrSWUlOlQosdxePZEmsYYFqHTTq = -4;
								goto IL_00e8;
							case 3:
								vDrSWUlOlQosdxePZEmsYYFqHTTq = -5;
								goto IL_0148;
							case 4:
								{
									vDrSWUlOlQosdxePZEmsYYFqHTTq = -6;
									break;
								}
								IL_00e8:
								if (SZAocjwnPLgmKNoJBBKmEMNgSdjf.MoveNext())
								{
									ControllerPollingInfo current = SZAocjwnPLgmKNoJBBKmEMNgSdjf.Current;
									goqxSsCqvOtGdaOAanblzINodmBK = current;
									vDrSWUlOlQosdxePZEmsYYFqHTTq = 2;
									return true;
								}
								PwUWqMbocUMOZOUlcGSooLGWiwsl();
								SZAocjwnPLgmKNoJBBKmEMNgSdjf = null;
								SZAocjwnPLgmKNoJBBKmEMNgSdjf = umhXIpIYrfsabrLQbKUhnvRXcpDv.YxbLzGWBrtWoQABBwcypyZBbwDXT().GetEnumerator();
								vDrSWUlOlQosdxePZEmsYYFqHTTq = -5;
								goto IL_0148;
								IL_0088:
								if (SZAocjwnPLgmKNoJBBKmEMNgSdjf.MoveNext())
								{
									ControllerPollingInfo current2 = SZAocjwnPLgmKNoJBBKmEMNgSdjf.Current;
									goqxSsCqvOtGdaOAanblzINodmBK = current2;
									vDrSWUlOlQosdxePZEmsYYFqHTTq = 1;
									return true;
								}
								cDaYbjVCVkmHcTSyzIBwHFngTNQi();
								SZAocjwnPLgmKNoJBBKmEMNgSdjf = null;
								SZAocjwnPLgmKNoJBBKmEMNgSdjf = umhXIpIYrfsabrLQbKUhnvRXcpDv.xdPHfCbWOiuQwFieyPmCldjvpyEBA().GetEnumerator();
								vDrSWUlOlQosdxePZEmsYYFqHTTq = -4;
								goto IL_00e8;
								IL_0148:
								if (SZAocjwnPLgmKNoJBBKmEMNgSdjf.MoveNext())
								{
									ControllerPollingInfo current3 = SZAocjwnPLgmKNoJBBKmEMNgSdjf.Current;
									goqxSsCqvOtGdaOAanblzINodmBK = current3;
									vDrSWUlOlQosdxePZEmsYYFqHTTq = 3;
									return true;
								}
								VyfhuAbzCfkqtFruqtIjEqkuUbSX();
								SZAocjwnPLgmKNoJBBKmEMNgSdjf = null;
								SZAocjwnPLgmKNoJBBKmEMNgSdjf = umhXIpIYrfsabrLQbKUhnvRXcpDv.bIKeetTIhGcQVPVEsQbGWpUBIdmA().GetEnumerator();
								vDrSWUlOlQosdxePZEmsYYFqHTTq = -6;
								break;
							}
							if (SZAocjwnPLgmKNoJBBKmEMNgSdjf.MoveNext())
							{
								ControllerPollingInfo current4 = SZAocjwnPLgmKNoJBBKmEMNgSdjf.Current;
								goqxSsCqvOtGdaOAanblzINodmBK = current4;
								vDrSWUlOlQosdxePZEmsYYFqHTTq = 4;
								return true;
							}
							JyCWobnNqEoSPQBFgykVPoLlbpXR();
							SZAocjwnPLgmKNoJBBKmEMNgSdjf = null;
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

					private void cDaYbjVCVkmHcTSyzIBwHFngTNQi()
					{
						vDrSWUlOlQosdxePZEmsYYFqHTTq = -1;
						if (SZAocjwnPLgmKNoJBBKmEMNgSdjf != null)
						{
							SZAocjwnPLgmKNoJBBKmEMNgSdjf.Dispose();
						}
					}

					private void PwUWqMbocUMOZOUlcGSooLGWiwsl()
					{
						vDrSWUlOlQosdxePZEmsYYFqHTTq = -1;
						if (SZAocjwnPLgmKNoJBBKmEMNgSdjf != null)
						{
							SZAocjwnPLgmKNoJBBKmEMNgSdjf.Dispose();
						}
					}

					private void VyfhuAbzCfkqtFruqtIjEqkuUbSX()
					{
						vDrSWUlOlQosdxePZEmsYYFqHTTq = -1;
						if (SZAocjwnPLgmKNoJBBKmEMNgSdjf != null)
						{
							SZAocjwnPLgmKNoJBBKmEMNgSdjf.Dispose();
						}
					}

					private void JyCWobnNqEoSPQBFgykVPoLlbpXR()
					{
						vDrSWUlOlQosdxePZEmsYYFqHTTq = -1;
						if (SZAocjwnPLgmKNoJBBKmEMNgSdjf != null)
						{
							SZAocjwnPLgmKNoJBBKmEMNgSdjf.Dispose();
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
						xyragxPIkPZxvNbeTCAsMoGlsvKR xyragxPIkPZxvNbeTCAsMoGlsvKR2;
						if (vDrSWUlOlQosdxePZEmsYYFqHTTq == -2 && cnFtoAJhzwypoLOdPZddfFigxnxd == Environment.CurrentManagedThreadId)
						{
							vDrSWUlOlQosdxePZEmsYYFqHTTq = 0;
							xyragxPIkPZxvNbeTCAsMoGlsvKR2 = this;
						}
						else
						{
							xyragxPIkPZxvNbeTCAsMoGlsvKR2 = new xyragxPIkPZxvNbeTCAsMoGlsvKR(0);
							xyragxPIkPZxvNbeTCAsMoGlsvKR2.UmhXIpIYrfsabrLQbKUhnvRXcpDv = UmhXIpIYrfsabrLQbKUhnvRXcpDv;
						}
						return xyragxPIkPZxvNbeTCAsMoGlsvKR2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class sQeEhZJENWEBkWaKULmHEOKdpPPeb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int kKvYSdelSEolhCsrmgqDuWYUqii;

					private ControllerPollingInfo ByRRGjftGiUeVQIKmvAsJpcFzLIk;

					private int nxruuGmAdKHPNtsKDwhqwsgBRsGK;

					public PollingHelper iwvklcIqKImkFarfqtLbnRqzYUiJ;

					private IEnumerator<ControllerPollingInfo> OTbReKczRCRsnVqoPDdahOSZdvdGb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ByRRGjftGiUeVQIKmvAsJpcFzLIk;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ByRRGjftGiUeVQIKmvAsJpcFzLIk;
						}
					}

					[DebuggerHidden]
					public sQeEhZJENWEBkWaKULmHEOKdpPPeb(int P_0)
					{
						kKvYSdelSEolhCsrmgqDuWYUqii = P_0;
						nxruuGmAdKHPNtsKDwhqwsgBRsGK = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (kKvYSdelSEolhCsrmgqDuWYUqii)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								uwbfXObGiSRCqbQSwIpwRpHFbnos();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								ntjSZKIJJUryqwlcyZFabOBBDHVC();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								ibBEFxjrXoffsiAjzMADSqTamXnD();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								IJlEpVfEDxKfYLXelBGxafyCAyjJb();
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
							int num = kKvYSdelSEolhCsrmgqDuWYUqii;
							PollingHelper pollingHelper = iwvklcIqKImkFarfqtLbnRqzYUiJ;
							switch (num)
							{
							default:
								return false;
							case 0:
								kKvYSdelSEolhCsrmgqDuWYUqii = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								OTbReKczRCRsnVqoPDdahOSZdvdGb = pollingHelper.yMkKZLWRvHBrDLBTeRMRegkrRNxc().GetEnumerator();
								kKvYSdelSEolhCsrmgqDuWYUqii = -3;
								goto IL_0088;
							case 1:
								kKvYSdelSEolhCsrmgqDuWYUqii = -3;
								goto IL_0088;
							case 2:
								kKvYSdelSEolhCsrmgqDuWYUqii = -4;
								goto IL_00e8;
							case 3:
								kKvYSdelSEolhCsrmgqDuWYUqii = -5;
								goto IL_0148;
							case 4:
								{
									kKvYSdelSEolhCsrmgqDuWYUqii = -6;
									break;
								}
								IL_00e8:
								if (OTbReKczRCRsnVqoPDdahOSZdvdGb.MoveNext())
								{
									ControllerPollingInfo current = OTbReKczRCRsnVqoPDdahOSZdvdGb.Current;
									ByRRGjftGiUeVQIKmvAsJpcFzLIk = current;
									kKvYSdelSEolhCsrmgqDuWYUqii = 2;
									return true;
								}
								ntjSZKIJJUryqwlcyZFabOBBDHVC();
								OTbReKczRCRsnVqoPDdahOSZdvdGb = null;
								OTbReKczRCRsnVqoPDdahOSZdvdGb = pollingHelper.GEsEkrgksicOxYXlGwSDqsisOwWX().GetEnumerator();
								kKvYSdelSEolhCsrmgqDuWYUqii = -5;
								goto IL_0148;
								IL_0088:
								if (OTbReKczRCRsnVqoPDdahOSZdvdGb.MoveNext())
								{
									ControllerPollingInfo current2 = OTbReKczRCRsnVqoPDdahOSZdvdGb.Current;
									ByRRGjftGiUeVQIKmvAsJpcFzLIk = current2;
									kKvYSdelSEolhCsrmgqDuWYUqii = 1;
									return true;
								}
								uwbfXObGiSRCqbQSwIpwRpHFbnos();
								OTbReKczRCRsnVqoPDdahOSZdvdGb = null;
								OTbReKczRCRsnVqoPDdahOSZdvdGb = pollingHelper.OiskaGKoXwmsWuNcmmkuEbMBzCyE().GetEnumerator();
								kKvYSdelSEolhCsrmgqDuWYUqii = -4;
								goto IL_00e8;
								IL_0148:
								if (OTbReKczRCRsnVqoPDdahOSZdvdGb.MoveNext())
								{
									ControllerPollingInfo current3 = OTbReKczRCRsnVqoPDdahOSZdvdGb.Current;
									ByRRGjftGiUeVQIKmvAsJpcFzLIk = current3;
									kKvYSdelSEolhCsrmgqDuWYUqii = 3;
									return true;
								}
								ibBEFxjrXoffsiAjzMADSqTamXnD();
								OTbReKczRCRsnVqoPDdahOSZdvdGb = null;
								OTbReKczRCRsnVqoPDdahOSZdvdGb = pollingHelper.ObWFmpIMinsZzaEqPiOmFQmdgHSIb().GetEnumerator();
								kKvYSdelSEolhCsrmgqDuWYUqii = -6;
								break;
							}
							if (OTbReKczRCRsnVqoPDdahOSZdvdGb.MoveNext())
							{
								ControllerPollingInfo current4 = OTbReKczRCRsnVqoPDdahOSZdvdGb.Current;
								ByRRGjftGiUeVQIKmvAsJpcFzLIk = current4;
								kKvYSdelSEolhCsrmgqDuWYUqii = 4;
								return true;
							}
							IJlEpVfEDxKfYLXelBGxafyCAyjJb();
							OTbReKczRCRsnVqoPDdahOSZdvdGb = null;
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

					private void uwbfXObGiSRCqbQSwIpwRpHFbnos()
					{
						kKvYSdelSEolhCsrmgqDuWYUqii = -1;
						if (OTbReKczRCRsnVqoPDdahOSZdvdGb != null)
						{
							OTbReKczRCRsnVqoPDdahOSZdvdGb.Dispose();
						}
					}

					private void ntjSZKIJJUryqwlcyZFabOBBDHVC()
					{
						kKvYSdelSEolhCsrmgqDuWYUqii = -1;
						if (OTbReKczRCRsnVqoPDdahOSZdvdGb != null)
						{
							OTbReKczRCRsnVqoPDdahOSZdvdGb.Dispose();
						}
					}

					private void ibBEFxjrXoffsiAjzMADSqTamXnD()
					{
						kKvYSdelSEolhCsrmgqDuWYUqii = -1;
						if (OTbReKczRCRsnVqoPDdahOSZdvdGb != null)
						{
							OTbReKczRCRsnVqoPDdahOSZdvdGb.Dispose();
						}
					}

					private void IJlEpVfEDxKfYLXelBGxafyCAyjJb()
					{
						kKvYSdelSEolhCsrmgqDuWYUqii = -1;
						if (OTbReKczRCRsnVqoPDdahOSZdvdGb != null)
						{
							OTbReKczRCRsnVqoPDdahOSZdvdGb.Dispose();
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
						sQeEhZJENWEBkWaKULmHEOKdpPPeb sQeEhZJENWEBkWaKULmHEOKdpPPeb2;
						if (kKvYSdelSEolhCsrmgqDuWYUqii == -2 && nxruuGmAdKHPNtsKDwhqwsgBRsGK == Environment.CurrentManagedThreadId)
						{
							kKvYSdelSEolhCsrmgqDuWYUqii = 0;
							sQeEhZJENWEBkWaKULmHEOKdpPPeb2 = this;
						}
						else
						{
							sQeEhZJENWEBkWaKULmHEOKdpPPeb2 = new sQeEhZJENWEBkWaKULmHEOKdpPPeb(0);
							sQeEhZJENWEBkWaKULmHEOKdpPPeb2.iwvklcIqKImkFarfqtLbnRqzYUiJ = iwvklcIqKImkFarfqtLbnRqzYUiJ;
						}
						return sQeEhZJENWEBkWaKULmHEOKdpPPeb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class MOnLZqYOxtnTbAuhuGNOdBDjFYRb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int NKciuJnEnWdTgdwWbXiBUnMOcyig;

					private ControllerPollingInfo HRFADpIZNgFgIOocYuIgbHTPVAol;

					private int hVrKTTehBBJPPzKeHMsYlsDTUtby;

					public PollingHelper ZAQBIDrssRgHODoaqvMGmgMMMBjU;

					private IEnumerator<ControllerPollingInfo> alMzzZCeoKdqlEanvBWGQCcAJDWAb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return HRFADpIZNgFgIOocYuIgbHTPVAol;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HRFADpIZNgFgIOocYuIgbHTPVAol;
						}
					}

					[DebuggerHidden]
					public MOnLZqYOxtnTbAuhuGNOdBDjFYRb(int P_0)
					{
						NKciuJnEnWdTgdwWbXiBUnMOcyig = P_0;
						hVrKTTehBBJPPzKeHMsYlsDTUtby = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (NKciuJnEnWdTgdwWbXiBUnMOcyig)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								EDktHrJGRQUSNkPXHGOImVKcbtyHA();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								DjkEdNccTjdsYqkpokZYBpPHWQgqB();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								MevgjmRTypCouHqXigtJWvJuXhiV();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								JeIrKVgwgefCcsEllojzlWCkHPRs();
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
							int nKciuJnEnWdTgdwWbXiBUnMOcyig = NKciuJnEnWdTgdwWbXiBUnMOcyig;
							PollingHelper zAQBIDrssRgHODoaqvMGmgMMMBjU = ZAQBIDrssRgHODoaqvMGmgMMMBjU;
							switch (nKciuJnEnWdTgdwWbXiBUnMOcyig)
							{
							default:
								return false;
							case 0:
								NKciuJnEnWdTgdwWbXiBUnMOcyig = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								alMzzZCeoKdqlEanvBWGQCcAJDWAb = zAQBIDrssRgHODoaqvMGmgMMMBjU.eBQFgIveptelCFdyZuqjLRZEeGsk().GetEnumerator();
								NKciuJnEnWdTgdwWbXiBUnMOcyig = -3;
								goto IL_0088;
							case 1:
								NKciuJnEnWdTgdwWbXiBUnMOcyig = -3;
								goto IL_0088;
							case 2:
								NKciuJnEnWdTgdwWbXiBUnMOcyig = -4;
								goto IL_00e8;
							case 3:
								NKciuJnEnWdTgdwWbXiBUnMOcyig = -5;
								goto IL_0148;
							case 4:
								{
									NKciuJnEnWdTgdwWbXiBUnMOcyig = -6;
									break;
								}
								IL_00e8:
								if (alMzzZCeoKdqlEanvBWGQCcAJDWAb.MoveNext())
								{
									ControllerPollingInfo current = alMzzZCeoKdqlEanvBWGQCcAJDWAb.Current;
									HRFADpIZNgFgIOocYuIgbHTPVAol = current;
									NKciuJnEnWdTgdwWbXiBUnMOcyig = 2;
									return true;
								}
								DjkEdNccTjdsYqkpokZYBpPHWQgqB();
								alMzzZCeoKdqlEanvBWGQCcAJDWAb = null;
								alMzzZCeoKdqlEanvBWGQCcAJDWAb = zAQBIDrssRgHODoaqvMGmgMMMBjU.MoyIQoAFAWmlQVgNzKXiSdvhOBbf().GetEnumerator();
								NKciuJnEnWdTgdwWbXiBUnMOcyig = -5;
								goto IL_0148;
								IL_0088:
								if (alMzzZCeoKdqlEanvBWGQCcAJDWAb.MoveNext())
								{
									ControllerPollingInfo current2 = alMzzZCeoKdqlEanvBWGQCcAJDWAb.Current;
									HRFADpIZNgFgIOocYuIgbHTPVAol = current2;
									NKciuJnEnWdTgdwWbXiBUnMOcyig = 1;
									return true;
								}
								EDktHrJGRQUSNkPXHGOImVKcbtyHA();
								alMzzZCeoKdqlEanvBWGQCcAJDWAb = null;
								alMzzZCeoKdqlEanvBWGQCcAJDWAb = zAQBIDrssRgHODoaqvMGmgMMMBjU.xdPHfCbWOiuQwFieyPmCldjvpyEBA().GetEnumerator();
								NKciuJnEnWdTgdwWbXiBUnMOcyig = -4;
								goto IL_00e8;
								IL_0148:
								if (alMzzZCeoKdqlEanvBWGQCcAJDWAb.MoveNext())
								{
									ControllerPollingInfo current3 = alMzzZCeoKdqlEanvBWGQCcAJDWAb.Current;
									HRFADpIZNgFgIOocYuIgbHTPVAol = current3;
									NKciuJnEnWdTgdwWbXiBUnMOcyig = 3;
									return true;
								}
								MevgjmRTypCouHqXigtJWvJuXhiV();
								alMzzZCeoKdqlEanvBWGQCcAJDWAb = null;
								alMzzZCeoKdqlEanvBWGQCcAJDWAb = zAQBIDrssRgHODoaqvMGmgMMMBjU.EEVgVxudUuXKqeQKRbqJObbxNljD().GetEnumerator();
								NKciuJnEnWdTgdwWbXiBUnMOcyig = -6;
								break;
							}
							if (alMzzZCeoKdqlEanvBWGQCcAJDWAb.MoveNext())
							{
								ControllerPollingInfo current4 = alMzzZCeoKdqlEanvBWGQCcAJDWAb.Current;
								HRFADpIZNgFgIOocYuIgbHTPVAol = current4;
								NKciuJnEnWdTgdwWbXiBUnMOcyig = 4;
								return true;
							}
							JeIrKVgwgefCcsEllojzlWCkHPRs();
							alMzzZCeoKdqlEanvBWGQCcAJDWAb = null;
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

					private void EDktHrJGRQUSNkPXHGOImVKcbtyHA()
					{
						NKciuJnEnWdTgdwWbXiBUnMOcyig = -1;
						if (alMzzZCeoKdqlEanvBWGQCcAJDWAb != null)
						{
							alMzzZCeoKdqlEanvBWGQCcAJDWAb.Dispose();
						}
					}

					private void DjkEdNccTjdsYqkpokZYBpPHWQgqB()
					{
						NKciuJnEnWdTgdwWbXiBUnMOcyig = -1;
						if (alMzzZCeoKdqlEanvBWGQCcAJDWAb != null)
						{
							alMzzZCeoKdqlEanvBWGQCcAJDWAb.Dispose();
						}
					}

					private void MevgjmRTypCouHqXigtJWvJuXhiV()
					{
						NKciuJnEnWdTgdwWbXiBUnMOcyig = -1;
						if (alMzzZCeoKdqlEanvBWGQCcAJDWAb != null)
						{
							alMzzZCeoKdqlEanvBWGQCcAJDWAb.Dispose();
						}
					}

					private void JeIrKVgwgefCcsEllojzlWCkHPRs()
					{
						NKciuJnEnWdTgdwWbXiBUnMOcyig = -1;
						if (alMzzZCeoKdqlEanvBWGQCcAJDWAb != null)
						{
							alMzzZCeoKdqlEanvBWGQCcAJDWAb.Dispose();
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
						MOnLZqYOxtnTbAuhuGNOdBDjFYRb mOnLZqYOxtnTbAuhuGNOdBDjFYRb;
						if (NKciuJnEnWdTgdwWbXiBUnMOcyig == -2 && hVrKTTehBBJPPzKeHMsYlsDTUtby == Environment.CurrentManagedThreadId)
						{
							NKciuJnEnWdTgdwWbXiBUnMOcyig = 0;
							mOnLZqYOxtnTbAuhuGNOdBDjFYRb = this;
						}
						else
						{
							mOnLZqYOxtnTbAuhuGNOdBDjFYRb = new MOnLZqYOxtnTbAuhuGNOdBDjFYRb(0);
							mOnLZqYOxtnTbAuhuGNOdBDjFYRb.ZAQBIDrssRgHODoaqvMGmgMMMBjU = ZAQBIDrssRgHODoaqvMGmgMMMBjU;
						}
						return mOnLZqYOxtnTbAuhuGNOdBDjFYRb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class QzqfKxcxvnwOHIweeEXymZZfPyhR : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int zeCCfjdJOwjgqFgawfQOnugoCFjw;

					private ControllerPollingInfo HjimZNtvGwYewfMMFsFSqcxzjMTI;

					private int XJZFQbsuOIRRGsCinYZMEMTPRhFM;

					private IList<CustomController> WNLgIeAfXQZJuDhHIacRxvOQXbE;

					private int EfqEgoEQKNOBAURwdfzkBWipdRykA;

					private IEnumerator<ControllerPollingInfo> JqFjxdJQuElPxiDOvPLBdNldAonB;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return HjimZNtvGwYewfMMFsFSqcxzjMTI;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HjimZNtvGwYewfMMFsFSqcxzjMTI;
						}
					}

					[DebuggerHidden]
					public QzqfKxcxvnwOHIweeEXymZZfPyhR(int P_0)
					{
						zeCCfjdJOwjgqFgawfQOnugoCFjw = P_0;
						XJZFQbsuOIRRGsCinYZMEMTPRhFM = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = zeCCfjdJOwjgqFgawfQOnugoCFjw;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								aswAGnBaGUQMloVjIOaOaBHiccOmc();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = zeCCfjdJOwjgqFgawfQOnugoCFjw;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								zeCCfjdJOwjgqFgawfQOnugoCFjw = -3;
								goto IL_0086;
							}
							zeCCfjdJOwjgqFgawfQOnugoCFjw = -1;
							WNLgIeAfXQZJuDhHIacRxvOQXbE = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
							EfqEgoEQKNOBAURwdfzkBWipdRykA = 0;
							goto IL_00b0;
							IL_0086:
							if (JqFjxdJQuElPxiDOvPLBdNldAonB.MoveNext())
							{
								ControllerPollingInfo current = JqFjxdJQuElPxiDOvPLBdNldAonB.Current;
								HjimZNtvGwYewfMMFsFSqcxzjMTI = current;
								zeCCfjdJOwjgqFgawfQOnugoCFjw = 1;
								return true;
							}
							aswAGnBaGUQMloVjIOaOaBHiccOmc();
							JqFjxdJQuElPxiDOvPLBdNldAonB = null;
							EfqEgoEQKNOBAURwdfzkBWipdRykA++;
							goto IL_00b0;
							IL_00b0:
							if (EfqEgoEQKNOBAURwdfzkBWipdRykA < WNLgIeAfXQZJuDhHIacRxvOQXbE.Count)
							{
								JqFjxdJQuElPxiDOvPLBdNldAonB = WNLgIeAfXQZJuDhHIacRxvOQXbE[EfqEgoEQKNOBAURwdfzkBWipdRykA].PollForAllAxes().GetEnumerator();
								zeCCfjdJOwjgqFgawfQOnugoCFjw = -3;
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

					private void aswAGnBaGUQMloVjIOaOaBHiccOmc()
					{
						zeCCfjdJOwjgqFgawfQOnugoCFjw = -1;
						if (JqFjxdJQuElPxiDOvPLBdNldAonB != null)
						{
							JqFjxdJQuElPxiDOvPLBdNldAonB.Dispose();
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
						if (zeCCfjdJOwjgqFgawfQOnugoCFjw == -2 && XJZFQbsuOIRRGsCinYZMEMTPRhFM == Environment.CurrentManagedThreadId)
						{
							zeCCfjdJOwjgqFgawfQOnugoCFjw = 0;
							return this;
						}
						return new QzqfKxcxvnwOHIweeEXymZZfPyhR(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ordQMqkbPMBmVvqLIedJHgRVAIkKA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ogUTosuMJWcRUcriEMoaNBDWoBEm;

					private ControllerPollingInfo rYFWkxpmksaUCGyyMmFshaptDlyb;

					private int kuONqbQPGxsyhtSucuWIaLoSSLdi;

					private IList<CustomController> tmGDtxLGgVvlSpaWdYJDenoSrdZr;

					private int LwvJUDZztIAPMyXuJtsXYqyPSpSS;

					private IEnumerator<ControllerPollingInfo> QenWsQYIJUvJNWJwUHhVTUxtMejV;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rYFWkxpmksaUCGyyMmFshaptDlyb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rYFWkxpmksaUCGyyMmFshaptDlyb;
						}
					}

					[DebuggerHidden]
					public ordQMqkbPMBmVvqLIedJHgRVAIkKA(int P_0)
					{
						ogUTosuMJWcRUcriEMoaNBDWoBEm = P_0;
						kuONqbQPGxsyhtSucuWIaLoSSLdi = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ogUTosuMJWcRUcriEMoaNBDWoBEm;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								MaNSlnrCPNfXkjJLJQVYPSBHjRTJ();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = ogUTosuMJWcRUcriEMoaNBDWoBEm;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								ogUTosuMJWcRUcriEMoaNBDWoBEm = -3;
								goto IL_0086;
							}
							ogUTosuMJWcRUcriEMoaNBDWoBEm = -1;
							tmGDtxLGgVvlSpaWdYJDenoSrdZr = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
							LwvJUDZztIAPMyXuJtsXYqyPSpSS = 0;
							goto IL_00b0;
							IL_0086:
							if (QenWsQYIJUvJNWJwUHhVTUxtMejV.MoveNext())
							{
								ControllerPollingInfo current = QenWsQYIJUvJNWJwUHhVTUxtMejV.Current;
								rYFWkxpmksaUCGyyMmFshaptDlyb = current;
								ogUTosuMJWcRUcriEMoaNBDWoBEm = 1;
								return true;
							}
							MaNSlnrCPNfXkjJLJQVYPSBHjRTJ();
							QenWsQYIJUvJNWJwUHhVTUxtMejV = null;
							LwvJUDZztIAPMyXuJtsXYqyPSpSS++;
							goto IL_00b0;
							IL_00b0:
							if (LwvJUDZztIAPMyXuJtsXYqyPSpSS < tmGDtxLGgVvlSpaWdYJDenoSrdZr.Count)
							{
								QenWsQYIJUvJNWJwUHhVTUxtMejV = tmGDtxLGgVvlSpaWdYJDenoSrdZr[LwvJUDZztIAPMyXuJtsXYqyPSpSS].PollForAllButtons().GetEnumerator();
								ogUTosuMJWcRUcriEMoaNBDWoBEm = -3;
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

					private void MaNSlnrCPNfXkjJLJQVYPSBHjRTJ()
					{
						ogUTosuMJWcRUcriEMoaNBDWoBEm = -1;
						if (QenWsQYIJUvJNWJwUHhVTUxtMejV != null)
						{
							QenWsQYIJUvJNWJwUHhVTUxtMejV.Dispose();
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
						if (ogUTosuMJWcRUcriEMoaNBDWoBEm == -2 && kuONqbQPGxsyhtSucuWIaLoSSLdi == Environment.CurrentManagedThreadId)
						{
							ogUTosuMJWcRUcriEMoaNBDWoBEm = 0;
							return this;
						}
						return new ordQMqkbPMBmVvqLIedJHgRVAIkKA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class lPKrquIhChobJzKIGrpTdhKNodgo : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int BaLOLzrYuxSfAQfQeIVIcWJrpEgX;

					private ControllerPollingInfo lwbVcGryxYGKUhVTeDbyIYeLKUeA;

					private int BeStJBhfwzadLnDsrIMjTPEzTzPS;

					private IList<CustomController> RlbjypJrMxMCYosgweGrQDYtSpKA;

					private int oobOWfNFnMUrnULjAGViLnBSHOBb;

					private IEnumerator<ControllerPollingInfo> noGIWZzCTUFEDfYmAEYiJKoJuRhCA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return lwbVcGryxYGKUhVTeDbyIYeLKUeA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return lwbVcGryxYGKUhVTeDbyIYeLKUeA;
						}
					}

					[DebuggerHidden]
					public lPKrquIhChobJzKIGrpTdhKNodgo(int P_0)
					{
						BaLOLzrYuxSfAQfQeIVIcWJrpEgX = P_0;
						BeStJBhfwzadLnDsrIMjTPEzTzPS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int baLOLzrYuxSfAQfQeIVIcWJrpEgX = BaLOLzrYuxSfAQfQeIVIcWJrpEgX;
						if (baLOLzrYuxSfAQfQeIVIcWJrpEgX == -3 || baLOLzrYuxSfAQfQeIVIcWJrpEgX == 1)
						{
							try
							{
							}
							finally
							{
								piQSpmSqoLEpSNcVKKltLDBuByGz();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int baLOLzrYuxSfAQfQeIVIcWJrpEgX = BaLOLzrYuxSfAQfQeIVIcWJrpEgX;
							if (baLOLzrYuxSfAQfQeIVIcWJrpEgX != 0)
							{
								if (baLOLzrYuxSfAQfQeIVIcWJrpEgX != 1)
								{
									return false;
								}
								BaLOLzrYuxSfAQfQeIVIcWJrpEgX = -3;
								goto IL_0086;
							}
							BaLOLzrYuxSfAQfQeIVIcWJrpEgX = -1;
							RlbjypJrMxMCYosgweGrQDYtSpKA = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
							oobOWfNFnMUrnULjAGViLnBSHOBb = 0;
							goto IL_00b0;
							IL_0086:
							if (noGIWZzCTUFEDfYmAEYiJKoJuRhCA.MoveNext())
							{
								ControllerPollingInfo current = noGIWZzCTUFEDfYmAEYiJKoJuRhCA.Current;
								lwbVcGryxYGKUhVTeDbyIYeLKUeA = current;
								BaLOLzrYuxSfAQfQeIVIcWJrpEgX = 1;
								return true;
							}
							piQSpmSqoLEpSNcVKKltLDBuByGz();
							noGIWZzCTUFEDfYmAEYiJKoJuRhCA = null;
							oobOWfNFnMUrnULjAGViLnBSHOBb++;
							goto IL_00b0;
							IL_00b0:
							if (oobOWfNFnMUrnULjAGViLnBSHOBb < RlbjypJrMxMCYosgweGrQDYtSpKA.Count)
							{
								noGIWZzCTUFEDfYmAEYiJKoJuRhCA = RlbjypJrMxMCYosgweGrQDYtSpKA[oobOWfNFnMUrnULjAGViLnBSHOBb].PollForAllButtonsDown().GetEnumerator();
								BaLOLzrYuxSfAQfQeIVIcWJrpEgX = -3;
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

					private void piQSpmSqoLEpSNcVKKltLDBuByGz()
					{
						BaLOLzrYuxSfAQfQeIVIcWJrpEgX = -1;
						if (noGIWZzCTUFEDfYmAEYiJKoJuRhCA != null)
						{
							noGIWZzCTUFEDfYmAEYiJKoJuRhCA.Dispose();
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
						if (BaLOLzrYuxSfAQfQeIVIcWJrpEgX == -2 && BeStJBhfwzadLnDsrIMjTPEzTzPS == Environment.CurrentManagedThreadId)
						{
							BaLOLzrYuxSfAQfQeIVIcWJrpEgX = 0;
							return this;
						}
						return new lPKrquIhChobJzKIGrpTdhKNodgo(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class OqVArVAKJOiMaMQvLtLtkxBmVQkB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int OwJnYyTIlVawfIIRmgAdFQETCrIe;

					private ControllerPollingInfo njoJrBLimIRpCWUFAqLxsdVmxrBV;

					private int vrtucokotjmcsKfLcBgSOjgBhdQx;

					private IList<CustomController> uvGEzZZcEJPMStDOiwzeHgGqjKAaA;

					private int HPmEOKGTENsFilXHhnYzoukHiwBu;

					private IEnumerator<ControllerPollingInfo> LEnjlNQlRJVzetAhOZkQeiyiOgFP;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return njoJrBLimIRpCWUFAqLxsdVmxrBV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return njoJrBLimIRpCWUFAqLxsdVmxrBV;
						}
					}

					[DebuggerHidden]
					public OqVArVAKJOiMaMQvLtLtkxBmVQkB(int P_0)
					{
						OwJnYyTIlVawfIIRmgAdFQETCrIe = P_0;
						vrtucokotjmcsKfLcBgSOjgBhdQx = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int owJnYyTIlVawfIIRmgAdFQETCrIe = OwJnYyTIlVawfIIRmgAdFQETCrIe;
						if (owJnYyTIlVawfIIRmgAdFQETCrIe == -3 || owJnYyTIlVawfIIRmgAdFQETCrIe == 1)
						{
							try
							{
							}
							finally
							{
								HTyGOgGBrrkScdcdAjSVdaVOyDeSb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int owJnYyTIlVawfIIRmgAdFQETCrIe = OwJnYyTIlVawfIIRmgAdFQETCrIe;
							if (owJnYyTIlVawfIIRmgAdFQETCrIe != 0)
							{
								if (owJnYyTIlVawfIIRmgAdFQETCrIe != 1)
								{
									return false;
								}
								OwJnYyTIlVawfIIRmgAdFQETCrIe = -3;
								goto IL_0086;
							}
							OwJnYyTIlVawfIIRmgAdFQETCrIe = -1;
							uvGEzZZcEJPMStDOiwzeHgGqjKAaA = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
							HPmEOKGTENsFilXHhnYzoukHiwBu = 0;
							goto IL_00b0;
							IL_0086:
							if (LEnjlNQlRJVzetAhOZkQeiyiOgFP.MoveNext())
							{
								ControllerPollingInfo current = LEnjlNQlRJVzetAhOZkQeiyiOgFP.Current;
								njoJrBLimIRpCWUFAqLxsdVmxrBV = current;
								OwJnYyTIlVawfIIRmgAdFQETCrIe = 1;
								return true;
							}
							HTyGOgGBrrkScdcdAjSVdaVOyDeSb();
							LEnjlNQlRJVzetAhOZkQeiyiOgFP = null;
							HPmEOKGTENsFilXHhnYzoukHiwBu++;
							goto IL_00b0;
							IL_00b0:
							if (HPmEOKGTENsFilXHhnYzoukHiwBu < uvGEzZZcEJPMStDOiwzeHgGqjKAaA.Count)
							{
								LEnjlNQlRJVzetAhOZkQeiyiOgFP = uvGEzZZcEJPMStDOiwzeHgGqjKAaA[HPmEOKGTENsFilXHhnYzoukHiwBu].PollForAllElements().GetEnumerator();
								OwJnYyTIlVawfIIRmgAdFQETCrIe = -3;
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

					private void HTyGOgGBrrkScdcdAjSVdaVOyDeSb()
					{
						OwJnYyTIlVawfIIRmgAdFQETCrIe = -1;
						if (LEnjlNQlRJVzetAhOZkQeiyiOgFP != null)
						{
							LEnjlNQlRJVzetAhOZkQeiyiOgFP.Dispose();
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
						if (OwJnYyTIlVawfIIRmgAdFQETCrIe == -2 && vrtucokotjmcsKfLcBgSOjgBhdQx == Environment.CurrentManagedThreadId)
						{
							OwJnYyTIlVawfIIRmgAdFQETCrIe = 0;
							return this;
						}
						return new OqVArVAKJOiMaMQvLtLtkxBmVQkB(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class wYFnqbFJZKOctbSNPzsIvTiAaMYG : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int WZQbRicuMRIsWjEyMhxeKYnjVwgBA;

					private ControllerPollingInfo zFJnCBPVVAGmkookvvfeahVxTqjo;

					private int cMeDNRmYugcOxnDwYWSMLpnUvTsl;

					private IList<CustomController> nWfBiJqmKYkokAsBbKWOzZaTYUkE;

					private int hFYiawdWDrBcZjjpJsaJKtdqSZfbA;

					private IEnumerator<ControllerPollingInfo> YICgWZLYEUghfdJTHrBdqNrSPvHI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return zFJnCBPVVAGmkookvvfeahVxTqjo;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zFJnCBPVVAGmkookvvfeahVxTqjo;
						}
					}

					[DebuggerHidden]
					public wYFnqbFJZKOctbSNPzsIvTiAaMYG(int P_0)
					{
						WZQbRicuMRIsWjEyMhxeKYnjVwgBA = P_0;
						cMeDNRmYugcOxnDwYWSMLpnUvTsl = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int wZQbRicuMRIsWjEyMhxeKYnjVwgBA = WZQbRicuMRIsWjEyMhxeKYnjVwgBA;
						if (wZQbRicuMRIsWjEyMhxeKYnjVwgBA == -3 || wZQbRicuMRIsWjEyMhxeKYnjVwgBA == 1)
						{
							try
							{
							}
							finally
							{
								WiSjrRiGPBUPWQYJSQezlRzmjIks();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int wZQbRicuMRIsWjEyMhxeKYnjVwgBA = WZQbRicuMRIsWjEyMhxeKYnjVwgBA;
							if (wZQbRicuMRIsWjEyMhxeKYnjVwgBA != 0)
							{
								if (wZQbRicuMRIsWjEyMhxeKYnjVwgBA != 1)
								{
									return false;
								}
								WZQbRicuMRIsWjEyMhxeKYnjVwgBA = -3;
								goto IL_0086;
							}
							WZQbRicuMRIsWjEyMhxeKYnjVwgBA = -1;
							nWfBiJqmKYkokAsBbKWOzZaTYUkE = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
							hFYiawdWDrBcZjjpJsaJKtdqSZfbA = 0;
							goto IL_00b0;
							IL_0086:
							if (YICgWZLYEUghfdJTHrBdqNrSPvHI.MoveNext())
							{
								ControllerPollingInfo current = YICgWZLYEUghfdJTHrBdqNrSPvHI.Current;
								zFJnCBPVVAGmkookvvfeahVxTqjo = current;
								WZQbRicuMRIsWjEyMhxeKYnjVwgBA = 1;
								return true;
							}
							WiSjrRiGPBUPWQYJSQezlRzmjIks();
							YICgWZLYEUghfdJTHrBdqNrSPvHI = null;
							hFYiawdWDrBcZjjpJsaJKtdqSZfbA++;
							goto IL_00b0;
							IL_00b0:
							if (hFYiawdWDrBcZjjpJsaJKtdqSZfbA < nWfBiJqmKYkokAsBbKWOzZaTYUkE.Count)
							{
								YICgWZLYEUghfdJTHrBdqNrSPvHI = nWfBiJqmKYkokAsBbKWOzZaTYUkE[hFYiawdWDrBcZjjpJsaJKtdqSZfbA].PollForAllElementsDown().GetEnumerator();
								WZQbRicuMRIsWjEyMhxeKYnjVwgBA = -3;
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

					private void WiSjrRiGPBUPWQYJSQezlRzmjIks()
					{
						WZQbRicuMRIsWjEyMhxeKYnjVwgBA = -1;
						if (YICgWZLYEUghfdJTHrBdqNrSPvHI != null)
						{
							YICgWZLYEUghfdJTHrBdqNrSPvHI.Dispose();
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
						if (WZQbRicuMRIsWjEyMhxeKYnjVwgBA == -2 && cMeDNRmYugcOxnDwYWSMLpnUvTsl == Environment.CurrentManagedThreadId)
						{
							WZQbRicuMRIsWjEyMhxeKYnjVwgBA = 0;
							return this;
						}
						return new wYFnqbFJZKOctbSNPzsIvTiAaMYG(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class cgBcrVvntuEqQeOXtiRkcLUxprOWA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int VtxgoFELuUkgrdClYQsWWUCDagew;

					private ControllerPollingInfo QfPAERyxDeddoIphMiNVTqRrqyMUA;

					private int QWdqHZAzpoWbUsyHMDpQoURQvZHr;

					private IList<Joystick> kUyfWIEFubdlQVBnlUtnXbOLSblj;

					private int JDuCCFNKhpxUvqbtWfXnKjeHtrNi;

					private IEnumerator<ControllerPollingInfo> KuvNiLVOVNTCPNzvvgCxNqQeDNUAA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return QfPAERyxDeddoIphMiNVTqRrqyMUA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return QfPAERyxDeddoIphMiNVTqRrqyMUA;
						}
					}

					[DebuggerHidden]
					public cgBcrVvntuEqQeOXtiRkcLUxprOWA(int P_0)
					{
						VtxgoFELuUkgrdClYQsWWUCDagew = P_0;
						QWdqHZAzpoWbUsyHMDpQoURQvZHr = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int vtxgoFELuUkgrdClYQsWWUCDagew = VtxgoFELuUkgrdClYQsWWUCDagew;
						if (vtxgoFELuUkgrdClYQsWWUCDagew == -3 || vtxgoFELuUkgrdClYQsWWUCDagew == 1)
						{
							try
							{
							}
							finally
							{
								LIscmaVDTxcBCFVJbkdYIEZErXTHb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int vtxgoFELuUkgrdClYQsWWUCDagew = VtxgoFELuUkgrdClYQsWWUCDagew;
							if (vtxgoFELuUkgrdClYQsWWUCDagew != 0)
							{
								if (vtxgoFELuUkgrdClYQsWWUCDagew != 1)
								{
									return false;
								}
								VtxgoFELuUkgrdClYQsWWUCDagew = -3;
								goto IL_0086;
							}
							VtxgoFELuUkgrdClYQsWWUCDagew = -1;
							kUyfWIEFubdlQVBnlUtnXbOLSblj = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
							JDuCCFNKhpxUvqbtWfXnKjeHtrNi = 0;
							goto IL_00b0;
							IL_0086:
							if (KuvNiLVOVNTCPNzvvgCxNqQeDNUAA.MoveNext())
							{
								ControllerPollingInfo current = KuvNiLVOVNTCPNzvvgCxNqQeDNUAA.Current;
								QfPAERyxDeddoIphMiNVTqRrqyMUA = current;
								VtxgoFELuUkgrdClYQsWWUCDagew = 1;
								return true;
							}
							LIscmaVDTxcBCFVJbkdYIEZErXTHb();
							KuvNiLVOVNTCPNzvvgCxNqQeDNUAA = null;
							JDuCCFNKhpxUvqbtWfXnKjeHtrNi++;
							goto IL_00b0;
							IL_00b0:
							if (JDuCCFNKhpxUvqbtWfXnKjeHtrNi < kUyfWIEFubdlQVBnlUtnXbOLSblj.Count)
							{
								KuvNiLVOVNTCPNzvvgCxNqQeDNUAA = kUyfWIEFubdlQVBnlUtnXbOLSblj[JDuCCFNKhpxUvqbtWfXnKjeHtrNi].PollForAllAxes().GetEnumerator();
								VtxgoFELuUkgrdClYQsWWUCDagew = -3;
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

					private void LIscmaVDTxcBCFVJbkdYIEZErXTHb()
					{
						VtxgoFELuUkgrdClYQsWWUCDagew = -1;
						if (KuvNiLVOVNTCPNzvvgCxNqQeDNUAA != null)
						{
							KuvNiLVOVNTCPNzvvgCxNqQeDNUAA.Dispose();
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
						if (VtxgoFELuUkgrdClYQsWWUCDagew == -2 && QWdqHZAzpoWbUsyHMDpQoURQvZHr == Environment.CurrentManagedThreadId)
						{
							VtxgoFELuUkgrdClYQsWWUCDagew = 0;
							return this;
						}
						return new cgBcrVvntuEqQeOXtiRkcLUxprOWA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class GvbhoocLbAkbOURDnvdMHyUFqCHPA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int buNScJfsGCAOgMPlMmdDOngYqqEU;

					private ControllerPollingInfo rnxLqqwPtIbxkUQolNiUewEaZDfC;

					private int gOTWLVLMgPIsAqaRdNhTWibdKuAs;

					private IList<Joystick> QjiwTsprJvIbQAjeqaFdbyoYqvDW;

					private int hHnQmiRZxNvmyGONRxISaSRDOJCF;

					private IEnumerator<ControllerPollingInfo> dQIkTVKERwgIWGugJjgGJziaILbe;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rnxLqqwPtIbxkUQolNiUewEaZDfC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rnxLqqwPtIbxkUQolNiUewEaZDfC;
						}
					}

					[DebuggerHidden]
					public GvbhoocLbAkbOURDnvdMHyUFqCHPA(int P_0)
					{
						buNScJfsGCAOgMPlMmdDOngYqqEU = P_0;
						gOTWLVLMgPIsAqaRdNhTWibdKuAs = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = buNScJfsGCAOgMPlMmdDOngYqqEU;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								chaqJrMDKGRAGGXgUSmlMvbnvtqI();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = buNScJfsGCAOgMPlMmdDOngYqqEU;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								buNScJfsGCAOgMPlMmdDOngYqqEU = -3;
								goto IL_0086;
							}
							buNScJfsGCAOgMPlMmdDOngYqqEU = -1;
							QjiwTsprJvIbQAjeqaFdbyoYqvDW = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
							hHnQmiRZxNvmyGONRxISaSRDOJCF = 0;
							goto IL_00b0;
							IL_0086:
							if (dQIkTVKERwgIWGugJjgGJziaILbe.MoveNext())
							{
								ControllerPollingInfo current = dQIkTVKERwgIWGugJjgGJziaILbe.Current;
								rnxLqqwPtIbxkUQolNiUewEaZDfC = current;
								buNScJfsGCAOgMPlMmdDOngYqqEU = 1;
								return true;
							}
							chaqJrMDKGRAGGXgUSmlMvbnvtqI();
							dQIkTVKERwgIWGugJjgGJziaILbe = null;
							hHnQmiRZxNvmyGONRxISaSRDOJCF++;
							goto IL_00b0;
							IL_00b0:
							if (hHnQmiRZxNvmyGONRxISaSRDOJCF < QjiwTsprJvIbQAjeqaFdbyoYqvDW.Count)
							{
								dQIkTVKERwgIWGugJjgGJziaILbe = QjiwTsprJvIbQAjeqaFdbyoYqvDW[hHnQmiRZxNvmyGONRxISaSRDOJCF].PollForAllButtons().GetEnumerator();
								buNScJfsGCAOgMPlMmdDOngYqqEU = -3;
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

					private void chaqJrMDKGRAGGXgUSmlMvbnvtqI()
					{
						buNScJfsGCAOgMPlMmdDOngYqqEU = -1;
						if (dQIkTVKERwgIWGugJjgGJziaILbe != null)
						{
							dQIkTVKERwgIWGugJjgGJziaILbe.Dispose();
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
						if (buNScJfsGCAOgMPlMmdDOngYqqEU == -2 && gOTWLVLMgPIsAqaRdNhTWibdKuAs == Environment.CurrentManagedThreadId)
						{
							buNScJfsGCAOgMPlMmdDOngYqqEU = 0;
							return this;
						}
						return new GvbhoocLbAkbOURDnvdMHyUFqCHPA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class jErIMIfbkYqIfmOxawAoULWVEaAHb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int xitcxZWheVJMTsAPjZbtStFxNsRR;

					private ControllerPollingInfo zvLwSZWpqgaQYEsktZVtFwogKigeA;

					private int RAhjCggECwTtSWbdxMTxdSJhYQEG;

					private IList<Joystick> TgJIBjJDEnwrqSdNQthUnAycQxAd;

					private int deMZXWVXagZcUVKctwDZMbUxeIOk;

					private IEnumerator<ControllerPollingInfo> cXKdtYadRlGAYabfmpRlGtcqTDcGA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return zvLwSZWpqgaQYEsktZVtFwogKigeA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zvLwSZWpqgaQYEsktZVtFwogKigeA;
						}
					}

					[DebuggerHidden]
					public jErIMIfbkYqIfmOxawAoULWVEaAHb(int P_0)
					{
						xitcxZWheVJMTsAPjZbtStFxNsRR = P_0;
						RAhjCggECwTtSWbdxMTxdSJhYQEG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = xitcxZWheVJMTsAPjZbtStFxNsRR;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								eYyUrkNDNGcRYJPbrrKBlWuzFmsI();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = xitcxZWheVJMTsAPjZbtStFxNsRR;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								xitcxZWheVJMTsAPjZbtStFxNsRR = -3;
								goto IL_0086;
							}
							xitcxZWheVJMTsAPjZbtStFxNsRR = -1;
							TgJIBjJDEnwrqSdNQthUnAycQxAd = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
							deMZXWVXagZcUVKctwDZMbUxeIOk = 0;
							goto IL_00b0;
							IL_0086:
							if (cXKdtYadRlGAYabfmpRlGtcqTDcGA.MoveNext())
							{
								ControllerPollingInfo current = cXKdtYadRlGAYabfmpRlGtcqTDcGA.Current;
								zvLwSZWpqgaQYEsktZVtFwogKigeA = current;
								xitcxZWheVJMTsAPjZbtStFxNsRR = 1;
								return true;
							}
							eYyUrkNDNGcRYJPbrrKBlWuzFmsI();
							cXKdtYadRlGAYabfmpRlGtcqTDcGA = null;
							deMZXWVXagZcUVKctwDZMbUxeIOk++;
							goto IL_00b0;
							IL_00b0:
							if (deMZXWVXagZcUVKctwDZMbUxeIOk < TgJIBjJDEnwrqSdNQthUnAycQxAd.Count)
							{
								cXKdtYadRlGAYabfmpRlGtcqTDcGA = TgJIBjJDEnwrqSdNQthUnAycQxAd[deMZXWVXagZcUVKctwDZMbUxeIOk].PollForAllButtonsDown().GetEnumerator();
								xitcxZWheVJMTsAPjZbtStFxNsRR = -3;
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

					private void eYyUrkNDNGcRYJPbrrKBlWuzFmsI()
					{
						xitcxZWheVJMTsAPjZbtStFxNsRR = -1;
						if (cXKdtYadRlGAYabfmpRlGtcqTDcGA != null)
						{
							cXKdtYadRlGAYabfmpRlGtcqTDcGA.Dispose();
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
						if (xitcxZWheVJMTsAPjZbtStFxNsRR == -2 && RAhjCggECwTtSWbdxMTxdSJhYQEG == Environment.CurrentManagedThreadId)
						{
							xitcxZWheVJMTsAPjZbtStFxNsRR = 0;
							return this;
						}
						return new jErIMIfbkYqIfmOxawAoULWVEaAHb(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class VPfXbhEnwgywdKlnjWtodeVahPuK : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int EBIToJSaXNsVDjKztQpZqgcfSVlh;

					private ControllerPollingInfo KKYYFkjjgzOZpAbiqMhxJMcmqndI;

					private int ubxjnMcuwDjoUdbadcULtdvRNvnRb;

					private IList<Joystick> sNpiLMXzJqdhzseVxdmRjIxExjVTA;

					private int OIiYtkwthmAhjpRLBddYIcBYRJsO;

					private IEnumerator<ControllerPollingInfo> eHoDfvItRVSHBnwvpsRsuYTwZRPR;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return KKYYFkjjgzOZpAbiqMhxJMcmqndI;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return KKYYFkjjgzOZpAbiqMhxJMcmqndI;
						}
					}

					[DebuggerHidden]
					public VPfXbhEnwgywdKlnjWtodeVahPuK(int P_0)
					{
						EBIToJSaXNsVDjKztQpZqgcfSVlh = P_0;
						ubxjnMcuwDjoUdbadcULtdvRNvnRb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int eBIToJSaXNsVDjKztQpZqgcfSVlh = EBIToJSaXNsVDjKztQpZqgcfSVlh;
						if (eBIToJSaXNsVDjKztQpZqgcfSVlh == -3 || eBIToJSaXNsVDjKztQpZqgcfSVlh == 1)
						{
							try
							{
							}
							finally
							{
								wPnfIEzdXSSghvCXdwjtEbrcPClf();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int eBIToJSaXNsVDjKztQpZqgcfSVlh = EBIToJSaXNsVDjKztQpZqgcfSVlh;
							if (eBIToJSaXNsVDjKztQpZqgcfSVlh != 0)
							{
								if (eBIToJSaXNsVDjKztQpZqgcfSVlh != 1)
								{
									return false;
								}
								EBIToJSaXNsVDjKztQpZqgcfSVlh = -3;
								goto IL_0086;
							}
							EBIToJSaXNsVDjKztQpZqgcfSVlh = -1;
							sNpiLMXzJqdhzseVxdmRjIxExjVTA = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
							OIiYtkwthmAhjpRLBddYIcBYRJsO = 0;
							goto IL_00b0;
							IL_0086:
							if (eHoDfvItRVSHBnwvpsRsuYTwZRPR.MoveNext())
							{
								ControllerPollingInfo current = eHoDfvItRVSHBnwvpsRsuYTwZRPR.Current;
								KKYYFkjjgzOZpAbiqMhxJMcmqndI = current;
								EBIToJSaXNsVDjKztQpZqgcfSVlh = 1;
								return true;
							}
							wPnfIEzdXSSghvCXdwjtEbrcPClf();
							eHoDfvItRVSHBnwvpsRsuYTwZRPR = null;
							OIiYtkwthmAhjpRLBddYIcBYRJsO++;
							goto IL_00b0;
							IL_00b0:
							if (OIiYtkwthmAhjpRLBddYIcBYRJsO < sNpiLMXzJqdhzseVxdmRjIxExjVTA.Count)
							{
								eHoDfvItRVSHBnwvpsRsuYTwZRPR = sNpiLMXzJqdhzseVxdmRjIxExjVTA[OIiYtkwthmAhjpRLBddYIcBYRJsO].PollForAllElements().GetEnumerator();
								EBIToJSaXNsVDjKztQpZqgcfSVlh = -3;
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

					private void wPnfIEzdXSSghvCXdwjtEbrcPClf()
					{
						EBIToJSaXNsVDjKztQpZqgcfSVlh = -1;
						if (eHoDfvItRVSHBnwvpsRsuYTwZRPR != null)
						{
							eHoDfvItRVSHBnwvpsRsuYTwZRPR.Dispose();
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
						if (EBIToJSaXNsVDjKztQpZqgcfSVlh == -2 && ubxjnMcuwDjoUdbadcULtdvRNvnRb == Environment.CurrentManagedThreadId)
						{
							EBIToJSaXNsVDjKztQpZqgcfSVlh = 0;
							return this;
						}
						return new VPfXbhEnwgywdKlnjWtodeVahPuK(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class DEieypoUfMAgFBtLYlSDhAudTKtP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GuhhNUnOnysSiXGfwRbSJceIToCJ;

					private ControllerPollingInfo NMCdiQHeQKDbmnelLloPgNBqBJubb;

					private int KrlcrSHZSetCppOnMRfqVgUvdjHP;

					private IList<Joystick> TYgDFvaPuZMuXQsJRPDjyuPxEhfZ;

					private int VRYavwMpkKFvNGqoWxUXiNrwHUkmA;

					private IEnumerator<ControllerPollingInfo> vyoxwBuaghoZbEnvmqsbbHRWkdHW;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return NMCdiQHeQKDbmnelLloPgNBqBJubb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NMCdiQHeQKDbmnelLloPgNBqBJubb;
						}
					}

					[DebuggerHidden]
					public DEieypoUfMAgFBtLYlSDhAudTKtP(int P_0)
					{
						GuhhNUnOnysSiXGfwRbSJceIToCJ = P_0;
						KrlcrSHZSetCppOnMRfqVgUvdjHP = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int guhhNUnOnysSiXGfwRbSJceIToCJ = GuhhNUnOnysSiXGfwRbSJceIToCJ;
						if (guhhNUnOnysSiXGfwRbSJceIToCJ == -3 || guhhNUnOnysSiXGfwRbSJceIToCJ == 1)
						{
							try
							{
							}
							finally
							{
								ziyViWyqrSkwYNrmKcjXMXMxcNQJ();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int guhhNUnOnysSiXGfwRbSJceIToCJ = GuhhNUnOnysSiXGfwRbSJceIToCJ;
							if (guhhNUnOnysSiXGfwRbSJceIToCJ != 0)
							{
								if (guhhNUnOnysSiXGfwRbSJceIToCJ != 1)
								{
									return false;
								}
								GuhhNUnOnysSiXGfwRbSJceIToCJ = -3;
								goto IL_0086;
							}
							GuhhNUnOnysSiXGfwRbSJceIToCJ = -1;
							TYgDFvaPuZMuXQsJRPDjyuPxEhfZ = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
							VRYavwMpkKFvNGqoWxUXiNrwHUkmA = 0;
							goto IL_00b0;
							IL_0086:
							if (vyoxwBuaghoZbEnvmqsbbHRWkdHW.MoveNext())
							{
								ControllerPollingInfo current = vyoxwBuaghoZbEnvmqsbbHRWkdHW.Current;
								NMCdiQHeQKDbmnelLloPgNBqBJubb = current;
								GuhhNUnOnysSiXGfwRbSJceIToCJ = 1;
								return true;
							}
							ziyViWyqrSkwYNrmKcjXMXMxcNQJ();
							vyoxwBuaghoZbEnvmqsbbHRWkdHW = null;
							VRYavwMpkKFvNGqoWxUXiNrwHUkmA++;
							goto IL_00b0;
							IL_00b0:
							if (VRYavwMpkKFvNGqoWxUXiNrwHUkmA < TYgDFvaPuZMuXQsJRPDjyuPxEhfZ.Count)
							{
								vyoxwBuaghoZbEnvmqsbbHRWkdHW = TYgDFvaPuZMuXQsJRPDjyuPxEhfZ[VRYavwMpkKFvNGqoWxUXiNrwHUkmA].PollForAllElementsDown().GetEnumerator();
								GuhhNUnOnysSiXGfwRbSJceIToCJ = -3;
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

					private void ziyViWyqrSkwYNrmKcjXMXMxcNQJ()
					{
						GuhhNUnOnysSiXGfwRbSJceIToCJ = -1;
						if (vyoxwBuaghoZbEnvmqsbbHRWkdHW != null)
						{
							vyoxwBuaghoZbEnvmqsbbHRWkdHW.Dispose();
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
						if (GuhhNUnOnysSiXGfwRbSJceIToCJ == -2 && KrlcrSHZSetCppOnMRfqVgUvdjHP == Environment.CurrentManagedThreadId)
						{
							GuhhNUnOnysSiXGfwRbSJceIToCJ = 0;
							return this;
						}
						return new DEieypoUfMAgFBtLYlSDhAudTKtP(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private static PollingHelper jjLrpkSXPFtlSyEadATIuwyJcEDW;

				internal static PollingHelper asxPkyFRKAbDVEAjrSmIHjCEHITJA => jjLrpkSXPFtlSyEadATIuwyJcEDW ?? (jjLrpkSXPFtlSyEadATIuwyJcEDW = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = EgZBflfnAmESTPENxNpaOoaNeewuA();
					if (result.success)
					{
						return result;
					}
					result = oElBBOlOZPcwRLhotCFXWImilwfp();
					if (result.success)
					{
						return result;
					}
					result = yNQOyzRwBuJxGqVYxDNgxYtvqRRG();
					if (result.success)
					{
						return result;
					}
					result = jYsxowdhkoedGDinQRbzkzIEFbsl();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = gJKvucEqaChWPXlOqiRTiIAelnDlA();
					if (result.success)
					{
						return result;
					}
					result = EWwQLoSexobUQpAZOPXeNLFsYcKk();
					if (result.success)
					{
						return result;
					}
					result = sCCdhpLElrQZvKVuXGBCndbXUrPk();
					if (result.success)
					{
						return result;
					}
					result = jVQbPWGqfFETBLZMSIHXoBjhSoTu();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = LXZLQAfpFcShilgVOftWimShJiuqA();
					if (result.success)
					{
						return result;
					}
					result = oElBBOlOZPcwRLhotCFXWImilwfp();
					if (result.success)
					{
						return result;
					}
					result = FyYhspzwsaUhKSaSgvPhlHgOiUDK();
					if (result.success)
					{
						return result;
					}
					result = iKqatnZyxjAhkaCCJdxoKNbNYqUJ();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = iEVFHNrGqbFtdpScJcmypwNJcbwA();
					if (result.success)
					{
						return result;
					}
					result = EWwQLoSexobUQpAZOPXeNLFsYcKk();
					if (result.success)
					{
						return result;
					}
					result = gUVnzZOVFdJNXUKSZtKsMknsHZJU();
					if (result.success)
					{
						return result;
					}
					result = GQTJwUgYQKnHuLgyCChVLwrxssvx();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					ControllerPollingInfo result = pqGGRjtEsmGMsyKydYUflqpQLutU();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					if (result.success)
					{
						return result;
					}
					result = YALvOJoMZeNwbiuSbiSAaeDjbHML();
					if (result.success)
					{
						return result;
					}
					result = sVeFXkQDExRJRzMjaqVqxpYTukMB();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => EgZBflfnAmESTPENxNpaOoaNeewuA(), 
						ControllerType.Keyboard => oElBBOlOZPcwRLhotCFXWImilwfp(), 
						ControllerType.Mouse => yNQOyzRwBuJxGqVYxDNgxYtvqRRG(), 
						ControllerType.Custom => jYsxowdhkoedGDinQRbzkzIEFbsl(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => gJKvucEqaChWPXlOqiRTiIAelnDlA(), 
						ControllerType.Keyboard => EWwQLoSexobUQpAZOPXeNLFsYcKk(), 
						ControllerType.Mouse => sCCdhpLElrQZvKVuXGBCndbXUrPk(), 
						ControllerType.Custom => jVQbPWGqfFETBLZMSIHXoBjhSoTu(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => LXZLQAfpFcShilgVOftWimShJiuqA(), 
						ControllerType.Keyboard => oElBBOlOZPcwRLhotCFXWImilwfp(), 
						ControllerType.Mouse => FyYhspzwsaUhKSaSgvPhlHgOiUDK(), 
						ControllerType.Custom => iKqatnZyxjAhkaCCJdxoKNbNYqUJ(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => iEVFHNrGqbFtdpScJcmypwNJcbwA(), 
						ControllerType.Keyboard => EWwQLoSexobUQpAZOPXeNLFsYcKk(), 
						ControllerType.Mouse => gUVnzZOVFdJNXUKSZtKsMknsHZJU(), 
						ControllerType.Custom => GQTJwUgYQKnHuLgyCChVLwrxssvx(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => pqGGRjtEsmGMsyKydYUflqpQLutU(), 
						ControllerType.Keyboard => ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj(), 
						ControllerType.Mouse => YALvOJoMZeNwbiuSbiSAaeDjbHML(), 
						ControllerType.Custom => sVeFXkQDExRJRzMjaqVqxpYTukMB(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => GuiPGfatSmGjZIhidLBPhaHmtpHe(controllerId), 
						ControllerType.Keyboard => oElBBOlOZPcwRLhotCFXWImilwfp(), 
						ControllerType.Mouse => yNQOyzRwBuJxGqVYxDNgxYtvqRRG(), 
						ControllerType.Custom => pFmiAQJusXGePycblAIaUXFUgSdz(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => RLpbjquoNVzolCXOMFnxmouLaadB(controllerId), 
						ControllerType.Keyboard => EWwQLoSexobUQpAZOPXeNLFsYcKk(), 
						ControllerType.Mouse => sCCdhpLElrQZvKVuXGBCndbXUrPk(), 
						ControllerType.Custom => tNUocKPDuIUBsaqigguKHJpNZDOc(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => aSIGNGcRgSSnfcHsQVdMhGehMGQJ(controllerId), 
						ControllerType.Keyboard => oElBBOlOZPcwRLhotCFXWImilwfp(), 
						ControllerType.Mouse => FyYhspzwsaUhKSaSgvPhlHgOiUDK(), 
						ControllerType.Custom => DqUrMeLSlJhHaSxkZeTpIgLQVKTgA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => MNIiPdMjnGGLxnkAYECAivlCkaBo(controllerId), 
						ControllerType.Keyboard => EWwQLoSexobUQpAZOPXeNLFsYcKk(), 
						ControllerType.Mouse => gUVnzZOVFdJNXUKSZtKsMknsHZJU(), 
						ControllerType.Custom => LrXgKvudARvIUICaxBOYwGUCGOhFA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
					}
					return controllerType switch
					{
						ControllerType.Joystick => YxAghvjiHFurBjsmEpZMOTZggBcc(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj(), 
						ControllerType.Mouse => YALvOJoMZeNwbiuSbiSAaeDjbHML(), 
						ControllerType.Custom => SkhQFkJDWAXCvAMbyhmPARtEQyso(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				[IteratorStateMachine(typeof(sQeEhZJENWEBkWaKULmHEOKdpPPeb))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return new sQeEhZJENWEBkWaKULmHEOKdpPPeb(-2)
					{
						iwvklcIqKImkFarfqtLbnRqzYUiJ = this
					};
				}

				[IteratorStateMachine(typeof(MOnLZqYOxtnTbAuhuGNOdBDjFYRb))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return new MOnLZqYOxtnTbAuhuGNOdBDjFYRb(-2)
					{
						ZAQBIDrssRgHODoaqvMGmgMMMBjU = this
					};
				}

				[IteratorStateMachine(typeof(xJCAWpBPGYrcsCnMVxltauDwJlFW))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return new xJCAWpBPGYrcsCnMVxltauDwJlFW(-2)
					{
						qHCIZiRjptGNRetFWzXkrwokqynC = this
					};
				}

				[IteratorStateMachine(typeof(xyragxPIkPZxvNbeTCAsMoGlsvKR))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return new xyragxPIkPZxvNbeTCAsMoGlsvKR(-2)
					{
						UmhXIpIYrfsabrLQbKUhnvRXcpDv = this
					};
				}

				[IteratorStateMachine(typeof(HfmXyOwNFhZZpizOnWkLwvdVCerA))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return new HfmXyOwNFhZZpizOnWkLwvdVCerA(-2)
					{
						pXkdQllkrlOEGNgzzDelFbrvgaCPA = this
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
						ControllerType.Joystick => CaloqjKGxPeeIFNCSDqneQtiFTZjb(controllerId), 
						ControllerType.Keyboard => OiskaGKoXwmsWuNcmmkuEbMBzCyE(), 
						ControllerType.Mouse => GEsEkrgksicOxYXlGwSDqsisOwWX(), 
						ControllerType.Custom => wsYjGqRYNSgouioWfTwQnruMVFug(controllerId), 
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
						ControllerType.Joystick => wOGAgvYhcjiejDizAxKHfwsNUacvA(controllerId), 
						ControllerType.Keyboard => xdPHfCbWOiuQwFieyPmCldjvpyEBA(), 
						ControllerType.Mouse => MoyIQoAFAWmlQVgNzKXiSdvhOBbf(), 
						ControllerType.Custom => LoUMHwpGuRmvvXCmioOwLFNCIyyE(controllerId), 
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
						ControllerType.Joystick => EwdQwUSboGGrjMlkBZpCmyJQunvn(controllerId), 
						ControllerType.Keyboard => OiskaGKoXwmsWuNcmmkuEbMBzCyE(), 
						ControllerType.Mouse => qTgsGbJtGcWATIssuVHTppydNOEj(), 
						ControllerType.Custom => WYmNGjfXxcJFTUbscfpFwoNOPiTj(controllerId), 
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
						ControllerType.Joystick => OSgfwGdhEJvaJtXfNVAFDYQYUDHi(controllerId), 
						ControllerType.Keyboard => xdPHfCbWOiuQwFieyPmCldjvpyEBA(), 
						ControllerType.Mouse => YxbLzGWBrtWoQABBwcypyZBbwDXT(), 
						ControllerType.Custom => IJrqABItsDSqXrqxuxkFdwMEVALC(controllerId), 
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
						ControllerType.Joystick => CEeApaptgFmYaibKHqCitBQTCEyhA(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => TgFeKdAEzaVNnTrIioSdsSfScFbJb(), 
						ControllerType.Custom => FjuBgqFPWrSrXPmiKuzYKvVXeDLHA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo EgZBflfnAmESTPENxNpaOoaNeewuA()
				{
					IList<Joystick> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo gJKvucEqaChWPXlOqiRTiIAelnDlA()
				{
					IList<Joystick> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo LXZLQAfpFcShilgVOftWimShJiuqA()
				{
					IList<Joystick> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo iEVFHNrGqbFtdpScJcmypwNJcbwA()
				{
					IList<Joystick> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo pqGGRjtEsmGMsyKydYUflqpQLutU()
				{
					IList<Joystick> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo GuiPGfatSmGjZIhidLBPhaHmtpHe(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo RLpbjquoNVzolCXOMFnxmouLaadB(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo aSIGNGcRgSSnfcHsQVdMhGehMGQJ(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo MNIiPdMjnGGLxnkAYECAivlCkaBo(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo YxAghvjiHFurBjsmEpZMOTZggBcc(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo oElBBOlOZPcwRLhotCFXWImilwfp()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo EWwQLoSexobUQpAZOPXeNLFsYcKk()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo yNQOyzRwBuJxGqVYxDNgxYtvqRRG()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo sCCdhpLElrQZvKVuXGBCndbXUrPk()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo FyYhspzwsaUhKSaSgvPhlHgOiUDK()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo gUVnzZOVFdJNXUKSZtKsMknsHZJU()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo YALvOJoMZeNwbiuSbiSAaeDjbHML()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo jYsxowdhkoedGDinQRbzkzIEFbsl()
				{
					IList<CustomController> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo jVQbPWGqfFETBLZMSIHXoBjhSoTu()
				{
					IList<CustomController> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo iKqatnZyxjAhkaCCJdxoKNbNYqUJ()
				{
					IList<CustomController> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo GQTJwUgYQKnHuLgyCChVLwrxssvx()
				{
					IList<CustomController> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo sVeFXkQDExRJRzMjaqVqxpYTukMB()
				{
					IList<CustomController> list = VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo pFmiAQJusXGePycblAIaUXFUgSdz(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo tNUocKPDuIUBsaqigguKHJpNZDOc(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo DqUrMeLSlJhHaSxkZeTpIgLQVKTgA(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo LrXgKvudARvIUICaxBOYwGUCGOhFA(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				private ControllerPollingInfo SkhQFkJDWAXCvAMbyhmPARtEQyso(int P_0)
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.QIblrqHbUMAgdPjecsWonWhgowHj();
				}

				[IteratorStateMachine(typeof(VPfXbhEnwgywdKlnjWtodeVahPuK))]
				private IEnumerable<ControllerPollingInfo> yMkKZLWRvHBrDLBTeRMRegkrRNxc()
				{
					return new VPfXbhEnwgywdKlnjWtodeVahPuK(-2);
				}

				[IteratorStateMachine(typeof(DEieypoUfMAgFBtLYlSDhAudTKtP))]
				private IEnumerable<ControllerPollingInfo> eBQFgIveptelCFdyZuqjLRZEeGsk()
				{
					return new DEieypoUfMAgFBtLYlSDhAudTKtP(-2);
				}

				[IteratorStateMachine(typeof(GvbhoocLbAkbOURDnvdMHyUFqCHPA))]
				private IEnumerable<ControllerPollingInfo> jxFEPHDAILNkrjuKGXIraLDOebswb()
				{
					return new GvbhoocLbAkbOURDnvdMHyUFqCHPA(-2);
				}

				[IteratorStateMachine(typeof(jErIMIfbkYqIfmOxawAoULWVEaAHb))]
				private IEnumerable<ControllerPollingInfo> ezdZYbCAyMerPeBLKNoRwZBwukvd()
				{
					return new jErIMIfbkYqIfmOxawAoULWVEaAHb(-2);
				}

				[IteratorStateMachine(typeof(cgBcrVvntuEqQeOXtiRkcLUxprOWA))]
				private IEnumerable<ControllerPollingInfo> BWIhgLnFnWVnBEdhXxYOzLleRknn()
				{
					return new cgBcrVvntuEqQeOXtiRkcLUxprOWA(-2);
				}

				private IEnumerable<ControllerPollingInfo> CaloqjKGxPeeIFNCSDqneQtiFTZjb(int P_0)
				{
					Joystick joystick = RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> wOGAgvYhcjiejDizAxKHfwsNUacvA(int P_0)
				{
					Joystick joystick = RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> EwdQwUSboGGrjMlkBZpCmyJQunvn(int P_0)
				{
					Joystick joystick = RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> OSgfwGdhEJvaJtXfNVAFDYQYUDHi(int P_0)
				{
					Joystick joystick = RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> CEeApaptgFmYaibKHqCitBQTCEyhA(int P_0)
				{
					Joystick joystick = RlZpbqBuFSKPMnqftskGduWLlDKw.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> OiskaGKoXwmsWuNcmmkuEbMBzCyE()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> xdPHfCbWOiuQwFieyPmCldjvpyEBA()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> GEsEkrgksicOxYXlGwSDqsisOwWX()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> MoyIQoAFAWmlQVgNzKXiSdvhOBbf()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> qTgsGbJtGcWATIssuVHTppydNOEj()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> YxbLzGWBrtWoQABBwcypyZBbwDXT()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> TgFeKdAEzaVNnTrIioSdsSfScFbJb()
				{
					return RlZpbqBuFSKPMnqftskGduWLlDKw.Mouse.PollForAllAxes();
				}

				[IteratorStateMachine(typeof(OqVArVAKJOiMaMQvLtLtkxBmVQkB))]
				private IEnumerable<ControllerPollingInfo> ObWFmpIMinsZzaEqPiOmFQmdgHSIb()
				{
					return new OqVArVAKJOiMaMQvLtLtkxBmVQkB(-2);
				}

				[IteratorStateMachine(typeof(wYFnqbFJZKOctbSNPzsIvTiAaMYG))]
				private IEnumerable<ControllerPollingInfo> EEVgVxudUuXKqeQKRbqJObbxNljD()
				{
					return new wYFnqbFJZKOctbSNPzsIvTiAaMYG(-2);
				}

				[IteratorStateMachine(typeof(ordQMqkbPMBmVvqLIedJHgRVAIkKA))]
				private IEnumerable<ControllerPollingInfo> tPyHQjICDHRAffYowiYUHuPfWJwK()
				{
					return new ordQMqkbPMBmVvqLIedJHgRVAIkKA(-2);
				}

				[IteratorStateMachine(typeof(lPKrquIhChobJzKIGrpTdhKNodgo))]
				private IEnumerable<ControllerPollingInfo> bIKeetTIhGcQVPVEsQbGWpUBIdmA()
				{
					return new lPKrquIhChobJzKIGrpTdhKNodgo(-2);
				}

				[IteratorStateMachine(typeof(QzqfKxcxvnwOHIweeEXymZZfPyhR))]
				private IEnumerable<ControllerPollingInfo> ZJfBXYbIUuNUYfvBdBhxDGIcFAfud()
				{
					return new QzqfKxcxvnwOHIweeEXymZZfPyhR(-2);
				}

				private IEnumerable<ControllerPollingInfo> wsYjGqRYNSgouioWfTwQnruMVFug(int P_0)
				{
					CustomController customController = RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> LoUMHwpGuRmvvXCmioOwLFNCIyyE(int P_0)
				{
					CustomController customController = RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> WYmNGjfXxcJFTUbscfpFwoNOPiTj(int P_0)
				{
					CustomController customController = RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> IJrqABItsDSqXrqxuxkFdwMEVALC(int P_0)
				{
					CustomController customController = RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> FjuBgqFPWrSrXPmiKuzYKvVXeDLHA(int P_0)
				{
					CustomController customController = RlZpbqBuFSKPMnqftskGduWLlDKw.GetCustomController(P_0);
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
				private sealed class iWqPssWItCmwqClkLTfrqpCvZRel : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int eCHDofwXbTWNBKHxwFJlzTxArLSm;

					private ElementAssignmentConflictInfo AyGTOuvreFpDFqCROgPjotESQniS;

					private int utkngSqlgKgkihtcNsUYMEvINHNeA;

					private int gZoalROMNiJgTRHCQjYKooHlMvin;

					public int kQMVHEFcyXDtASbiaLsDegtivtDC;

					private ActionElementMap vhQjFEGOUVOoacbsgkNNeeroAmMbA;

					public ActionElementMap TsbCgpYbRJgegHXAQGgLfnKISfDJ;

					private bool SzGRtyCqNkyybrtXzaxHMkcdsYGd;

					public bool uRSGvVAYHIRdqhxmNRCELYmKbeNXA;

					private int RzCjlDMurTFWtcLSikZMxUPPPlEq;

					public int BGLjnAgjspdlCkRRmpAdaBEEJmzJb;

					private CustomControllerMap UqCNqohbXSCcLyrmdCJnCBWjHkaN;

					public CustomControllerMap jdxDyRfEtKqAWsmROZsrcfyAztCLA;

					private bool fsROTUvpfUrTxyvaGslTWXKcRKfd;

					public bool gCUPznoqJXlTCGFgVypCLvAvpHDS;

					private bool uXCYIWYuCBMIeCMukIYkWLFLDuaF;

					public bool DjruHzyyMRGHWDlGRYaCAZVVLcS;

					private IList<Player> aEKLKdIlgMDwkToFffvLWLcBAovW;

					private int MkDfRuxbyMrhqviaCyEjnOjfuYdf;

					private IEnumerator<ElementAssignmentConflictInfo> JMqJdUbbUmOvlBxVMfVijhlGBaji;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return AyGTOuvreFpDFqCROgPjotESQniS;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AyGTOuvreFpDFqCROgPjotESQniS;
						}
					}

					[DebuggerHidden]
					public iWqPssWItCmwqClkLTfrqpCvZRel(int P_0)
					{
						eCHDofwXbTWNBKHxwFJlzTxArLSm = P_0;
						utkngSqlgKgkihtcNsUYMEvINHNeA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = eCHDofwXbTWNBKHxwFJlzTxArLSm;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								bbHvoFIxHNJonmccosmeijsUuRMV();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = eCHDofwXbTWNBKHxwFJlzTxArLSm;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								eCHDofwXbTWNBKHxwFJlzTxArLSm = -3;
								goto IL_00e2;
							}
							eCHDofwXbTWNBKHxwFJlzTxArLSm = -1;
							if (gZoalROMNiJgTRHCQjYKooHlMvin < 0 || vhQjFEGOUVOoacbsgkNNeeroAmMbA == null)
							{
								return false;
							}
							aEKLKdIlgMDwkToFffvLWLcBAovW = (SzGRtyCqNkyybrtXzaxHMkcdsYGd ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
							MkDfRuxbyMrhqviaCyEjnOjfuYdf = 0;
							goto IL_010c;
							IL_010c:
							if (MkDfRuxbyMrhqviaCyEjnOjfuYdf < aEKLKdIlgMDwkToFffvLWLcBAovW.Count)
							{
								JMqJdUbbUmOvlBxVMfVijhlGBaji = aEKLKdIlgMDwkToFffvLWLcBAovW[MkDfRuxbyMrhqviaCyEjnOjfuYdf].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, RzCjlDMurTFWtcLSikZMxUPPPlEq, UqCNqohbXSCcLyrmdCJnCBWjHkaN, vhQjFEGOUVOoacbsgkNNeeroAmMbA, fsROTUvpfUrTxyvaGslTWXKcRKfd, uXCYIWYuCBMIeCMukIYkWLFLDuaF).GetEnumerator();
								eCHDofwXbTWNBKHxwFJlzTxArLSm = -3;
								goto IL_00e2;
							}
							return false;
							IL_00e2:
							if (JMqJdUbbUmOvlBxVMfVijhlGBaji.MoveNext())
							{
								ElementAssignmentConflictInfo current = JMqJdUbbUmOvlBxVMfVijhlGBaji.Current;
								AyGTOuvreFpDFqCROgPjotESQniS = current;
								eCHDofwXbTWNBKHxwFJlzTxArLSm = 1;
								return true;
							}
							bbHvoFIxHNJonmccosmeijsUuRMV();
							JMqJdUbbUmOvlBxVMfVijhlGBaji = null;
							MkDfRuxbyMrhqviaCyEjnOjfuYdf++;
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

					private void bbHvoFIxHNJonmccosmeijsUuRMV()
					{
						eCHDofwXbTWNBKHxwFJlzTxArLSm = -1;
						if (JMqJdUbbUmOvlBxVMfVijhlGBaji != null)
						{
							JMqJdUbbUmOvlBxVMfVijhlGBaji.Dispose();
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
						iWqPssWItCmwqClkLTfrqpCvZRel iWqPssWItCmwqClkLTfrqpCvZRel2;
						if (eCHDofwXbTWNBKHxwFJlzTxArLSm == -2 && utkngSqlgKgkihtcNsUYMEvINHNeA == Environment.CurrentManagedThreadId)
						{
							eCHDofwXbTWNBKHxwFJlzTxArLSm = 0;
							iWqPssWItCmwqClkLTfrqpCvZRel2 = this;
						}
						else
						{
							iWqPssWItCmwqClkLTfrqpCvZRel2 = new iWqPssWItCmwqClkLTfrqpCvZRel(0);
						}
						iWqPssWItCmwqClkLTfrqpCvZRel2.gZoalROMNiJgTRHCQjYKooHlMvin = kQMVHEFcyXDtASbiaLsDegtivtDC;
						iWqPssWItCmwqClkLTfrqpCvZRel2.RzCjlDMurTFWtcLSikZMxUPPPlEq = BGLjnAgjspdlCkRRmpAdaBEEJmzJb;
						iWqPssWItCmwqClkLTfrqpCvZRel2.UqCNqohbXSCcLyrmdCJnCBWjHkaN = jdxDyRfEtKqAWsmROZsrcfyAztCLA;
						iWqPssWItCmwqClkLTfrqpCvZRel2.vhQjFEGOUVOoacbsgkNNeeroAmMbA = TsbCgpYbRJgegHXAQGgLfnKISfDJ;
						iWqPssWItCmwqClkLTfrqpCvZRel2.fsROTUvpfUrTxyvaGslTWXKcRKfd = gCUPznoqJXlTCGFgVypCLvAvpHDS;
						iWqPssWItCmwqClkLTfrqpCvZRel2.uXCYIWYuCBMIeCMukIYkWLFLDuaF = DjruHzyyMRGHWDlGRYaCAZVVLcS;
						iWqPssWItCmwqClkLTfrqpCvZRel2.SzGRtyCqNkyybrtXzaxHMkcdsYGd = uRSGvVAYHIRdqhxmNRCELYmKbeNXA;
						return iWqPssWItCmwqClkLTfrqpCvZRel2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class PpCrAqxoevXsqducrPFmkpwPODGq : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int gXwtRYyzMEaSVuoYQMaJXyjTqOTb;

					private ElementAssignmentConflictInfo upCbOAcusoFFLWfVCVUfFpBUdciO;

					private int JziFGgooNhNLgWTfVqkxlNgDOpES;

					private ElementAssignmentConflictCheck duyJTweEzSHYAqTRTHaHtVAOSdFU;

					public ElementAssignmentConflictCheck FrBFiHApubwAWWTtttCOEacsZeZb;

					private bool GAVecsrRYBsXJWLEKWjulYYIBwPU;

					public bool vtcnrVaxKtamQJLgfbsXUBLVyqs;

					private bool otaMSPqaNGFxbOOeItupChPcgFHkA;

					public bool mbdKefVRjPDhRmCTMFGrALnSGzTM;

					private bool cPTHsPAgKmwRYwcVhbTOyZxiBayA;

					public bool gMxGDgaXMkrKbiYkUexsWzPESUSm;

					private IList<Player> DmlwABVibOdvNiTIjrNqQjCMwwgM;

					private int EvDdfUpYigcuBxmGzfcEzgCdrKSA;

					private IEnumerator<ElementAssignmentConflictInfo> RMuTHDWJsxdVRHlFnDkbTlcCTdbn;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return upCbOAcusoFFLWfVCVUfFpBUdciO;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return upCbOAcusoFFLWfVCVUfFpBUdciO;
						}
					}

					[DebuggerHidden]
					public PpCrAqxoevXsqducrPFmkpwPODGq(int P_0)
					{
						gXwtRYyzMEaSVuoYQMaJXyjTqOTb = P_0;
						JziFGgooNhNLgWTfVqkxlNgDOpES = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = gXwtRYyzMEaSVuoYQMaJXyjTqOTb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								iQdFiwczHvFsZCntlgOICHmXckAZ();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = gXwtRYyzMEaSVuoYQMaJXyjTqOTb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								gXwtRYyzMEaSVuoYQMaJXyjTqOTb = -3;
								goto IL_00df;
							}
							gXwtRYyzMEaSVuoYQMaJXyjTqOTb = -1;
							if (duyJTweEzSHYAqTRTHaHtVAOSdFU.playerId < 0 || duyJTweEzSHYAqTRTHaHtVAOSdFU.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							DmlwABVibOdvNiTIjrNqQjCMwwgM = (GAVecsrRYBsXJWLEKWjulYYIBwPU ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
							EvDdfUpYigcuBxmGzfcEzgCdrKSA = 0;
							goto IL_0109;
							IL_0109:
							if (EvDdfUpYigcuBxmGzfcEzgCdrKSA < DmlwABVibOdvNiTIjrNqQjCMwwgM.Count)
							{
								RMuTHDWJsxdVRHlFnDkbTlcCTdbn = DmlwABVibOdvNiTIjrNqQjCMwwgM[EvDdfUpYigcuBxmGzfcEzgCdrKSA].controllers.conflictChecking.ElementAssignmentConflicts(duyJTweEzSHYAqTRTHaHtVAOSdFU, otaMSPqaNGFxbOOeItupChPcgFHkA, cPTHsPAgKmwRYwcVhbTOyZxiBayA).GetEnumerator();
								gXwtRYyzMEaSVuoYQMaJXyjTqOTb = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (RMuTHDWJsxdVRHlFnDkbTlcCTdbn.MoveNext())
							{
								ElementAssignmentConflictInfo current = RMuTHDWJsxdVRHlFnDkbTlcCTdbn.Current;
								upCbOAcusoFFLWfVCVUfFpBUdciO = current;
								gXwtRYyzMEaSVuoYQMaJXyjTqOTb = 1;
								return true;
							}
							iQdFiwczHvFsZCntlgOICHmXckAZ();
							RMuTHDWJsxdVRHlFnDkbTlcCTdbn = null;
							EvDdfUpYigcuBxmGzfcEzgCdrKSA++;
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

					private void iQdFiwczHvFsZCntlgOICHmXckAZ()
					{
						gXwtRYyzMEaSVuoYQMaJXyjTqOTb = -1;
						if (RMuTHDWJsxdVRHlFnDkbTlcCTdbn != null)
						{
							RMuTHDWJsxdVRHlFnDkbTlcCTdbn.Dispose();
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
						PpCrAqxoevXsqducrPFmkpwPODGq ppCrAqxoevXsqducrPFmkpwPODGq;
						if (gXwtRYyzMEaSVuoYQMaJXyjTqOTb == -2 && JziFGgooNhNLgWTfVqkxlNgDOpES == Environment.CurrentManagedThreadId)
						{
							gXwtRYyzMEaSVuoYQMaJXyjTqOTb = 0;
							ppCrAqxoevXsqducrPFmkpwPODGq = this;
						}
						else
						{
							ppCrAqxoevXsqducrPFmkpwPODGq = new PpCrAqxoevXsqducrPFmkpwPODGq(0);
						}
						ppCrAqxoevXsqducrPFmkpwPODGq.duyJTweEzSHYAqTRTHaHtVAOSdFU = FrBFiHApubwAWWTtttCOEacsZeZb;
						ppCrAqxoevXsqducrPFmkpwPODGq.otaMSPqaNGFxbOOeItupChPcgFHkA = mbdKefVRjPDhRmCTMFGrALnSGzTM;
						ppCrAqxoevXsqducrPFmkpwPODGq.cPTHsPAgKmwRYwcVhbTOyZxiBayA = gMxGDgaXMkrKbiYkUexsWzPESUSm;
						ppCrAqxoevXsqducrPFmkpwPODGq.GAVecsrRYBsXJWLEKWjulYYIBwPU = vtcnrVaxKtamQJLgfbsXUBLVyqs;
						return ppCrAqxoevXsqducrPFmkpwPODGq;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class rPmhteZErOiFtGwLquDokovnFXxEA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int UmGtjyPVCruicvdpfFwusvjsxczg;

					private ElementAssignmentConflictInfo aWzWCRlheNDmIamDopRaPHKkGMPHb;

					private int taUYUMRAKrNTgUMzSntLHXhqxSAB;

					private int oOaQbaMcTRERMnBUzAiJjVtquPGm;

					public int GMRDgYGuBasOEdzqOMISJXbenRsfA;

					private ActionElementMap pzQtKHfPaPacJAKFVJsfceJoJKnz;

					public ActionElementMap HADEYzWpmuCICOKklqXLnezRoimt;

					private bool ywuEMxoxKjZCUjlDkgrYshkRDjsf;

					public bool OeMPoZvHHrdSittDvExqbkIKhqHSA;

					private int EBruxMxqrFKxRFnrfbLVtVHNMNpW;

					public int SQHtwZjPuWSgbmuirFGzukYKiTix;

					private JoystickMap oQRKmSKPRGWLYWAyNreQvkrnWiXD;

					public JoystickMap JJBQkHBOVGpbRQiDHemSoIhtEeUw;

					private bool BLyTiiVdRCReavIRVjErLqFyQFKA;

					public bool WCOHuitRoIBxaGomJxqhZeTgLmjy;

					private bool CLGGYFHNRXIjIAoIfFLpFeVPRlBbA;

					public bool HtzrrDnttieGmIxJeIhwflPgFZcBA;

					private IList<Player> RgiVlAUYevqZnfKNnewOFvqdqpuV;

					private int BwYaEwgJHToMzgvbCKDorvxydOnYb;

					private IEnumerator<ElementAssignmentConflictInfo> UrTafpnUdZnoEuUJmIYRbcVLSqJk;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aWzWCRlheNDmIamDopRaPHKkGMPHb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aWzWCRlheNDmIamDopRaPHKkGMPHb;
						}
					}

					[DebuggerHidden]
					public rPmhteZErOiFtGwLquDokovnFXxEA(int P_0)
					{
						UmGtjyPVCruicvdpfFwusvjsxczg = P_0;
						taUYUMRAKrNTgUMzSntLHXhqxSAB = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int umGtjyPVCruicvdpfFwusvjsxczg = UmGtjyPVCruicvdpfFwusvjsxczg;
						if (umGtjyPVCruicvdpfFwusvjsxczg == -3 || umGtjyPVCruicvdpfFwusvjsxczg == 1)
						{
							try
							{
							}
							finally
							{
								FjEgcEQSQXUrYmIQoRYXxabIRIFk();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int umGtjyPVCruicvdpfFwusvjsxczg = UmGtjyPVCruicvdpfFwusvjsxczg;
							if (umGtjyPVCruicvdpfFwusvjsxczg != 0)
							{
								if (umGtjyPVCruicvdpfFwusvjsxczg != 1)
								{
									return false;
								}
								UmGtjyPVCruicvdpfFwusvjsxczg = -3;
								goto IL_00e1;
							}
							UmGtjyPVCruicvdpfFwusvjsxczg = -1;
							if (oOaQbaMcTRERMnBUzAiJjVtquPGm < 0 || pzQtKHfPaPacJAKFVJsfceJoJKnz == null)
							{
								return false;
							}
							RgiVlAUYevqZnfKNnewOFvqdqpuV = (ywuEMxoxKjZCUjlDkgrYshkRDjsf ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
							BwYaEwgJHToMzgvbCKDorvxydOnYb = 0;
							goto IL_010b;
							IL_010b:
							if (BwYaEwgJHToMzgvbCKDorvxydOnYb < RgiVlAUYevqZnfKNnewOFvqdqpuV.Count)
							{
								UrTafpnUdZnoEuUJmIYRbcVLSqJk = RgiVlAUYevqZnfKNnewOFvqdqpuV[BwYaEwgJHToMzgvbCKDorvxydOnYb].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, EBruxMxqrFKxRFnrfbLVtVHNMNpW, oQRKmSKPRGWLYWAyNreQvkrnWiXD, pzQtKHfPaPacJAKFVJsfceJoJKnz, BLyTiiVdRCReavIRVjErLqFyQFKA, CLGGYFHNRXIjIAoIfFLpFeVPRlBbA).GetEnumerator();
								UmGtjyPVCruicvdpfFwusvjsxczg = -3;
								goto IL_00e1;
							}
							return false;
							IL_00e1:
							if (UrTafpnUdZnoEuUJmIYRbcVLSqJk.MoveNext())
							{
								ElementAssignmentConflictInfo current = UrTafpnUdZnoEuUJmIYRbcVLSqJk.Current;
								aWzWCRlheNDmIamDopRaPHKkGMPHb = current;
								UmGtjyPVCruicvdpfFwusvjsxczg = 1;
								return true;
							}
							FjEgcEQSQXUrYmIQoRYXxabIRIFk();
							UrTafpnUdZnoEuUJmIYRbcVLSqJk = null;
							BwYaEwgJHToMzgvbCKDorvxydOnYb++;
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

					private void FjEgcEQSQXUrYmIQoRYXxabIRIFk()
					{
						UmGtjyPVCruicvdpfFwusvjsxczg = -1;
						if (UrTafpnUdZnoEuUJmIYRbcVLSqJk != null)
						{
							UrTafpnUdZnoEuUJmIYRbcVLSqJk.Dispose();
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
						rPmhteZErOiFtGwLquDokovnFXxEA rPmhteZErOiFtGwLquDokovnFXxEA2;
						if (UmGtjyPVCruicvdpfFwusvjsxczg == -2 && taUYUMRAKrNTgUMzSntLHXhqxSAB == Environment.CurrentManagedThreadId)
						{
							UmGtjyPVCruicvdpfFwusvjsxczg = 0;
							rPmhteZErOiFtGwLquDokovnFXxEA2 = this;
						}
						else
						{
							rPmhteZErOiFtGwLquDokovnFXxEA2 = new rPmhteZErOiFtGwLquDokovnFXxEA(0);
						}
						rPmhteZErOiFtGwLquDokovnFXxEA2.oOaQbaMcTRERMnBUzAiJjVtquPGm = GMRDgYGuBasOEdzqOMISJXbenRsfA;
						rPmhteZErOiFtGwLquDokovnFXxEA2.EBruxMxqrFKxRFnrfbLVtVHNMNpW = SQHtwZjPuWSgbmuirFGzukYKiTix;
						rPmhteZErOiFtGwLquDokovnFXxEA2.oQRKmSKPRGWLYWAyNreQvkrnWiXD = JJBQkHBOVGpbRQiDHemSoIhtEeUw;
						rPmhteZErOiFtGwLquDokovnFXxEA2.pzQtKHfPaPacJAKFVJsfceJoJKnz = HADEYzWpmuCICOKklqXLnezRoimt;
						rPmhteZErOiFtGwLquDokovnFXxEA2.BLyTiiVdRCReavIRVjErLqFyQFKA = WCOHuitRoIBxaGomJxqhZeTgLmjy;
						rPmhteZErOiFtGwLquDokovnFXxEA2.CLGGYFHNRXIjIAoIfFLpFeVPRlBbA = HtzrrDnttieGmIxJeIhwflPgFZcBA;
						rPmhteZErOiFtGwLquDokovnFXxEA2.ywuEMxoxKjZCUjlDkgrYshkRDjsf = OeMPoZvHHrdSittDvExqbkIKhqHSA;
						return rPmhteZErOiFtGwLquDokovnFXxEA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class SpMxMNQqlbHuTiMRVElBpmxPdOjCb : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int KzKnQpAuAxrNsXSXFjdYSjCwjAMZ;

					private ElementAssignmentConflictInfo OYjdWogJGFGOqafVACcECORGhLSA;

					private int MopDUuCvNApRZbiblmwgtaLxDBJC;

					private ElementAssignmentConflictCheck emgMzseWieTgLJgAPBYeKHOmPuAE;

					public ElementAssignmentConflictCheck KgUCgpGMEjhLDBkIMDniNmobXqgM;

					private bool EsrhRuHDIgOwBfnEgGLbtrgxIJqBA;

					public bool mXDsGeYoeGcSKcDkRoMZRdAUOjwT;

					private bool VbdyqLqMoKjevEhVXofGNShkvbPMA;

					public bool QkAsetxhtHgYIOjCsfneGqZAIGuB;

					private bool HymQZwuumdicXvXjZKrGIpttvLPl;

					public bool xAiXqupYZaXWcvYmLNSyzsYrEJiD;

					private IList<Player> koEsnOVgfQcmlRJmqhrQOnsIdMkq;

					private int jYxYQrysjLvtlRPiPADvlHWgMFlk;

					private IEnumerator<ElementAssignmentConflictInfo> iwFIkRtPFZUQRATVejJNnOjLDMUq;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return OYjdWogJGFGOqafVACcECORGhLSA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return OYjdWogJGFGOqafVACcECORGhLSA;
						}
					}

					[DebuggerHidden]
					public SpMxMNQqlbHuTiMRVElBpmxPdOjCb(int P_0)
					{
						KzKnQpAuAxrNsXSXFjdYSjCwjAMZ = P_0;
						MopDUuCvNApRZbiblmwgtaLxDBJC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int kzKnQpAuAxrNsXSXFjdYSjCwjAMZ = KzKnQpAuAxrNsXSXFjdYSjCwjAMZ;
						if (kzKnQpAuAxrNsXSXFjdYSjCwjAMZ == -3 || kzKnQpAuAxrNsXSXFjdYSjCwjAMZ == 1)
						{
							try
							{
							}
							finally
							{
								NPNEnnLmgjWbtmpecVNvUJGdjuBhA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int kzKnQpAuAxrNsXSXFjdYSjCwjAMZ = KzKnQpAuAxrNsXSXFjdYSjCwjAMZ;
							if (kzKnQpAuAxrNsXSXFjdYSjCwjAMZ != 0)
							{
								if (kzKnQpAuAxrNsXSXFjdYSjCwjAMZ != 1)
								{
									return false;
								}
								KzKnQpAuAxrNsXSXFjdYSjCwjAMZ = -3;
								goto IL_00df;
							}
							KzKnQpAuAxrNsXSXFjdYSjCwjAMZ = -1;
							if (emgMzseWieTgLJgAPBYeKHOmPuAE.playerId < 0 || emgMzseWieTgLJgAPBYeKHOmPuAE.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							koEsnOVgfQcmlRJmqhrQOnsIdMkq = (EsrhRuHDIgOwBfnEgGLbtrgxIJqBA ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
							jYxYQrysjLvtlRPiPADvlHWgMFlk = 0;
							goto IL_0109;
							IL_0109:
							if (jYxYQrysjLvtlRPiPADvlHWgMFlk < koEsnOVgfQcmlRJmqhrQOnsIdMkq.Count)
							{
								iwFIkRtPFZUQRATVejJNnOjLDMUq = koEsnOVgfQcmlRJmqhrQOnsIdMkq[jYxYQrysjLvtlRPiPADvlHWgMFlk].controllers.conflictChecking.ElementAssignmentConflicts(emgMzseWieTgLJgAPBYeKHOmPuAE, VbdyqLqMoKjevEhVXofGNShkvbPMA, HymQZwuumdicXvXjZKrGIpttvLPl).GetEnumerator();
								KzKnQpAuAxrNsXSXFjdYSjCwjAMZ = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (iwFIkRtPFZUQRATVejJNnOjLDMUq.MoveNext())
							{
								ElementAssignmentConflictInfo current = iwFIkRtPFZUQRATVejJNnOjLDMUq.Current;
								OYjdWogJGFGOqafVACcECORGhLSA = current;
								KzKnQpAuAxrNsXSXFjdYSjCwjAMZ = 1;
								return true;
							}
							NPNEnnLmgjWbtmpecVNvUJGdjuBhA();
							iwFIkRtPFZUQRATVejJNnOjLDMUq = null;
							jYxYQrysjLvtlRPiPADvlHWgMFlk++;
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

					private void NPNEnnLmgjWbtmpecVNvUJGdjuBhA()
					{
						KzKnQpAuAxrNsXSXFjdYSjCwjAMZ = -1;
						if (iwFIkRtPFZUQRATVejJNnOjLDMUq != null)
						{
							iwFIkRtPFZUQRATVejJNnOjLDMUq.Dispose();
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
						SpMxMNQqlbHuTiMRVElBpmxPdOjCb spMxMNQqlbHuTiMRVElBpmxPdOjCb;
						if (KzKnQpAuAxrNsXSXFjdYSjCwjAMZ == -2 && MopDUuCvNApRZbiblmwgtaLxDBJC == Environment.CurrentManagedThreadId)
						{
							KzKnQpAuAxrNsXSXFjdYSjCwjAMZ = 0;
							spMxMNQqlbHuTiMRVElBpmxPdOjCb = this;
						}
						else
						{
							spMxMNQqlbHuTiMRVElBpmxPdOjCb = new SpMxMNQqlbHuTiMRVElBpmxPdOjCb(0);
						}
						spMxMNQqlbHuTiMRVElBpmxPdOjCb.emgMzseWieTgLJgAPBYeKHOmPuAE = KgUCgpGMEjhLDBkIMDniNmobXqgM;
						spMxMNQqlbHuTiMRVElBpmxPdOjCb.VbdyqLqMoKjevEhVXofGNShkvbPMA = QkAsetxhtHgYIOjCsfneGqZAIGuB;
						spMxMNQqlbHuTiMRVElBpmxPdOjCb.HymQZwuumdicXvXjZKrGIpttvLPl = xAiXqupYZaXWcvYmLNSyzsYrEJiD;
						spMxMNQqlbHuTiMRVElBpmxPdOjCb.EsrhRuHDIgOwBfnEgGLbtrgxIJqBA = mXDsGeYoeGcSKcDkRoMZRdAUOjwT;
						return spMxMNQqlbHuTiMRVElBpmxPdOjCb;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class BfCeVexbXxQCOiOqIzLKZDdxEpidA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int mYIpPKphxqGgMfhePdCybodUlyJsA;

					private ElementAssignmentConflictInfo rQdzHDzxmJdCQEauDALPFFONKJIT;

					private int NXYPIUSNpmXTsbQkPybTXEJCyLVh;

					private int ozxFEqLPOdTMWCENEpLBqoGzpmAM;

					public int QNRBjBRwdJOIXdCnoGnCJKJFvwMaA;

					private ActionElementMap epDfZZVioLbxAllFuPJomwVQFQbH;

					public ActionElementMap vSzEFaIXktyoXMQAUZNIuHEKrGgFA;

					private bool TXiGhHKeuiRlMApbHSsGpjjgSmtC;

					public bool luFdLSdvhqQwbxDKlFoOJHoMgBqOA;

					private KeyboardMap teftkRVCMrpOueWcYunobLXQFQDy;

					public KeyboardMap HHGAWHHpTmUmsejvZDIOFPKKzsfNA;

					private bool MdhirbKHZTlVtZLfsFeOEbSUEDFjb;

					public bool CmNZhOCFdoVLVWAPgAshREuuHUQl;

					private bool vnMdBjNxbIBSUFcCMviBawniDJfib;

					public bool KjqJazFKTiELQRBldjhdQaLXEUIe;

					private IList<Player> KwvncOlrIQwLHhWkKrhoxSQmoFSp;

					private int ydpHIiKbXDsPklcngHjiZBolsHlo;

					private IEnumerator<ElementAssignmentConflictInfo> TiuEIukDMXExSVHQTipuINdGtWGJB;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rQdzHDzxmJdCQEauDALPFFONKJIT;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rQdzHDzxmJdCQEauDALPFFONKJIT;
						}
					}

					[DebuggerHidden]
					public BfCeVexbXxQCOiOqIzLKZDdxEpidA(int P_0)
					{
						mYIpPKphxqGgMfhePdCybodUlyJsA = P_0;
						NXYPIUSNpmXTsbQkPybTXEJCyLVh = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = mYIpPKphxqGgMfhePdCybodUlyJsA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								hEaRXiYkcQLyzyTbdoFPbwgTmEPk();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = mYIpPKphxqGgMfhePdCybodUlyJsA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								mYIpPKphxqGgMfhePdCybodUlyJsA = -3;
								goto IL_00dc;
							}
							mYIpPKphxqGgMfhePdCybodUlyJsA = -1;
							if (ozxFEqLPOdTMWCENEpLBqoGzpmAM < 0 || epDfZZVioLbxAllFuPJomwVQFQbH == null)
							{
								return false;
							}
							KwvncOlrIQwLHhWkKrhoxSQmoFSp = (TXiGhHKeuiRlMApbHSsGpjjgSmtC ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
							ydpHIiKbXDsPklcngHjiZBolsHlo = 0;
							goto IL_0106;
							IL_0106:
							if (ydpHIiKbXDsPklcngHjiZBolsHlo < KwvncOlrIQwLHhWkKrhoxSQmoFSp.Count)
							{
								TiuEIukDMXExSVHQTipuINdGtWGJB = KwvncOlrIQwLHhWkKrhoxSQmoFSp[ydpHIiKbXDsPklcngHjiZBolsHlo].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, teftkRVCMrpOueWcYunobLXQFQDy, epDfZZVioLbxAllFuPJomwVQFQbH, MdhirbKHZTlVtZLfsFeOEbSUEDFjb, vnMdBjNxbIBSUFcCMviBawniDJfib).GetEnumerator();
								mYIpPKphxqGgMfhePdCybodUlyJsA = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (TiuEIukDMXExSVHQTipuINdGtWGJB.MoveNext())
							{
								ElementAssignmentConflictInfo current = TiuEIukDMXExSVHQTipuINdGtWGJB.Current;
								rQdzHDzxmJdCQEauDALPFFONKJIT = current;
								mYIpPKphxqGgMfhePdCybodUlyJsA = 1;
								return true;
							}
							hEaRXiYkcQLyzyTbdoFPbwgTmEPk();
							TiuEIukDMXExSVHQTipuINdGtWGJB = null;
							ydpHIiKbXDsPklcngHjiZBolsHlo++;
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

					private void hEaRXiYkcQLyzyTbdoFPbwgTmEPk()
					{
						mYIpPKphxqGgMfhePdCybodUlyJsA = -1;
						if (TiuEIukDMXExSVHQTipuINdGtWGJB != null)
						{
							TiuEIukDMXExSVHQTipuINdGtWGJB.Dispose();
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
						BfCeVexbXxQCOiOqIzLKZDdxEpidA bfCeVexbXxQCOiOqIzLKZDdxEpidA;
						if (mYIpPKphxqGgMfhePdCybodUlyJsA == -2 && NXYPIUSNpmXTsbQkPybTXEJCyLVh == Environment.CurrentManagedThreadId)
						{
							mYIpPKphxqGgMfhePdCybodUlyJsA = 0;
							bfCeVexbXxQCOiOqIzLKZDdxEpidA = this;
						}
						else
						{
							bfCeVexbXxQCOiOqIzLKZDdxEpidA = new BfCeVexbXxQCOiOqIzLKZDdxEpidA(0);
						}
						bfCeVexbXxQCOiOqIzLKZDdxEpidA.ozxFEqLPOdTMWCENEpLBqoGzpmAM = QNRBjBRwdJOIXdCnoGnCJKJFvwMaA;
						bfCeVexbXxQCOiOqIzLKZDdxEpidA.teftkRVCMrpOueWcYunobLXQFQDy = HHGAWHHpTmUmsejvZDIOFPKKzsfNA;
						bfCeVexbXxQCOiOqIzLKZDdxEpidA.epDfZZVioLbxAllFuPJomwVQFQbH = vSzEFaIXktyoXMQAUZNIuHEKrGgFA;
						bfCeVexbXxQCOiOqIzLKZDdxEpidA.MdhirbKHZTlVtZLfsFeOEbSUEDFjb = CmNZhOCFdoVLVWAPgAshREuuHUQl;
						bfCeVexbXxQCOiOqIzLKZDdxEpidA.vnMdBjNxbIBSUFcCMviBawniDJfib = KjqJazFKTiELQRBldjhdQaLXEUIe;
						bfCeVexbXxQCOiOqIzLKZDdxEpidA.TXiGhHKeuiRlMApbHSsGpjjgSmtC = luFdLSdvhqQwbxDKlFoOJHoMgBqOA;
						return bfCeVexbXxQCOiOqIzLKZDdxEpidA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class oNtXYAKOpWfBsVoTAAWhuSRgEAxFA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int yTvpvNbnBepUXLDmSwtJcWVxTnPq;

					private ElementAssignmentConflictInfo wOPGyXDnHBzhLHGDlaeRiALcEwxS;

					private int KxqGPDFJjGrPGKnzRzpsaYALlGTeA;

					private ElementAssignmentConflictCheck TCbzvqROSahsKHtxVnQsOfdIYIbaA;

					public ElementAssignmentConflictCheck dusyfaIuVtKABtovAzXYygVNdINE;

					private bool kHlERwuOTuhBnbeFwNzeXwJRaZag;

					public bool jarVSAnIvJuybpKEyrMIwMVqaWRY;

					private bool bJjAvLqhejKiaumNTENzSegrVlKV;

					public bool rpRMeuYoqSBjGYygZkNizpSEXkAL;

					private bool kpAKfyRDLYbNNZMdFcMNkiQFEoTBA;

					public bool LyYwbxhCxWndEBNgPnVnPZgYBfZo;

					private IList<Player> DkaqKytcczehchnmEXlgbBSzuJQiA;

					private int cScQYaQgOzoifBLjllgrpaGPDqFh;

					private IEnumerator<ElementAssignmentConflictInfo> ImYmffzePnmQNDfVpXNuUHlcmkin;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return wOPGyXDnHBzhLHGDlaeRiALcEwxS;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wOPGyXDnHBzhLHGDlaeRiALcEwxS;
						}
					}

					[DebuggerHidden]
					public oNtXYAKOpWfBsVoTAAWhuSRgEAxFA(int P_0)
					{
						yTvpvNbnBepUXLDmSwtJcWVxTnPq = P_0;
						KxqGPDFJjGrPGKnzRzpsaYALlGTeA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = yTvpvNbnBepUXLDmSwtJcWVxTnPq;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								luxGyahiyXbBoislldXdDEXDWOvoA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = yTvpvNbnBepUXLDmSwtJcWVxTnPq;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								yTvpvNbnBepUXLDmSwtJcWVxTnPq = -3;
								goto IL_00df;
							}
							yTvpvNbnBepUXLDmSwtJcWVxTnPq = -1;
							if (TCbzvqROSahsKHtxVnQsOfdIYIbaA.playerId < 0 || TCbzvqROSahsKHtxVnQsOfdIYIbaA.elementAssignmentType != ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							DkaqKytcczehchnmEXlgbBSzuJQiA = (kHlERwuOTuhBnbeFwNzeXwJRaZag ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
							cScQYaQgOzoifBLjllgrpaGPDqFh = 0;
							goto IL_0109;
							IL_0109:
							if (cScQYaQgOzoifBLjllgrpaGPDqFh < DkaqKytcczehchnmEXlgbBSzuJQiA.Count)
							{
								ImYmffzePnmQNDfVpXNuUHlcmkin = DkaqKytcczehchnmEXlgbBSzuJQiA[cScQYaQgOzoifBLjllgrpaGPDqFh].controllers.conflictChecking.ElementAssignmentConflicts(TCbzvqROSahsKHtxVnQsOfdIYIbaA, bJjAvLqhejKiaumNTENzSegrVlKV, kpAKfyRDLYbNNZMdFcMNkiQFEoTBA).GetEnumerator();
								yTvpvNbnBepUXLDmSwtJcWVxTnPq = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (ImYmffzePnmQNDfVpXNuUHlcmkin.MoveNext())
							{
								ElementAssignmentConflictInfo current = ImYmffzePnmQNDfVpXNuUHlcmkin.Current;
								wOPGyXDnHBzhLHGDlaeRiALcEwxS = current;
								yTvpvNbnBepUXLDmSwtJcWVxTnPq = 1;
								return true;
							}
							luxGyahiyXbBoislldXdDEXDWOvoA();
							ImYmffzePnmQNDfVpXNuUHlcmkin = null;
							cScQYaQgOzoifBLjllgrpaGPDqFh++;
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

					private void luxGyahiyXbBoislldXdDEXDWOvoA()
					{
						yTvpvNbnBepUXLDmSwtJcWVxTnPq = -1;
						if (ImYmffzePnmQNDfVpXNuUHlcmkin != null)
						{
							ImYmffzePnmQNDfVpXNuUHlcmkin.Dispose();
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
						oNtXYAKOpWfBsVoTAAWhuSRgEAxFA oNtXYAKOpWfBsVoTAAWhuSRgEAxFA2;
						if (yTvpvNbnBepUXLDmSwtJcWVxTnPq == -2 && KxqGPDFJjGrPGKnzRzpsaYALlGTeA == Environment.CurrentManagedThreadId)
						{
							yTvpvNbnBepUXLDmSwtJcWVxTnPq = 0;
							oNtXYAKOpWfBsVoTAAWhuSRgEAxFA2 = this;
						}
						else
						{
							oNtXYAKOpWfBsVoTAAWhuSRgEAxFA2 = new oNtXYAKOpWfBsVoTAAWhuSRgEAxFA(0);
						}
						oNtXYAKOpWfBsVoTAAWhuSRgEAxFA2.TCbzvqROSahsKHtxVnQsOfdIYIbaA = dusyfaIuVtKABtovAzXYygVNdINE;
						oNtXYAKOpWfBsVoTAAWhuSRgEAxFA2.bJjAvLqhejKiaumNTENzSegrVlKV = rpRMeuYoqSBjGYygZkNizpSEXkAL;
						oNtXYAKOpWfBsVoTAAWhuSRgEAxFA2.kpAKfyRDLYbNNZMdFcMNkiQFEoTBA = LyYwbxhCxWndEBNgPnVnPZgYBfZo;
						oNtXYAKOpWfBsVoTAAWhuSRgEAxFA2.kHlERwuOTuhBnbeFwNzeXwJRaZag = jarVSAnIvJuybpKEyrMIwMVqaWRY;
						return oNtXYAKOpWfBsVoTAAWhuSRgEAxFA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class ntbClYdQanahaCQnHSnDWkKXeiKN : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int IBrWXFecfpTSwtopbnjBOjuWhLfb;

					private ElementAssignmentConflictInfo xZIsrKSRUdsCJJbjXJfKUTyPbVWF;

					private int nMJgcRiCYkCdvhHzDoTDXyJHRZEQA;

					private int VrTbdOicqUMlCBdjecUzhGoackCuE;

					public int fjLUiLkldTaURgACyhhwDgvBsyzuB;

					private ActionElementMap MvusQGbnRBBQxpmHcwuQkjTQOkIS;

					public ActionElementMap EfIIHFjMethwrFGGditYnbQGIEVaB;

					private bool kpTjtavOovzOujDmKwQHwopXtcTp;

					public bool uyylwSeMiyypZzfdukOCoQQHbSpKA;

					private MouseMap xwIzHsddfuaLQPxSsJfeGZFArxFq;

					public MouseMap QFsmjKGPnirJcUdnTBHHBQBnMRBN;

					private bool pzwXaMOGQfSqDpOqHanKbNYKOuVZA;

					public bool nusBRQBdiFWxQSAZoiAwNccfUIMF;

					private bool aylCxJbjNQhDzjTeFCbYplHXMRoxb;

					public bool PEQBYHIKDNHiTdGWYwpqrXbsDTYP;

					private IList<Player> pTUXzpVikJfBARweSUuLbvLiPgdp;

					private int BPPbBQiQSohCvZYHMXnFmvHZGewRA;

					private IEnumerator<ElementAssignmentConflictInfo> EDzrBKIBpdXgqVzIMQhZOKvjNbxr;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return xZIsrKSRUdsCJJbjXJfKUTyPbVWF;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return xZIsrKSRUdsCJJbjXJfKUTyPbVWF;
						}
					}

					[DebuggerHidden]
					public ntbClYdQanahaCQnHSnDWkKXeiKN(int P_0)
					{
						IBrWXFecfpTSwtopbnjBOjuWhLfb = P_0;
						nMJgcRiCYkCdvhHzDoTDXyJHRZEQA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int iBrWXFecfpTSwtopbnjBOjuWhLfb = IBrWXFecfpTSwtopbnjBOjuWhLfb;
						if (iBrWXFecfpTSwtopbnjBOjuWhLfb == -3 || iBrWXFecfpTSwtopbnjBOjuWhLfb == 1)
						{
							try
							{
							}
							finally
							{
								CUSBNrlcXomzNeAmSOaHWGNWfabn();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int iBrWXFecfpTSwtopbnjBOjuWhLfb = IBrWXFecfpTSwtopbnjBOjuWhLfb;
							if (iBrWXFecfpTSwtopbnjBOjuWhLfb != 0)
							{
								if (iBrWXFecfpTSwtopbnjBOjuWhLfb != 1)
								{
									return false;
								}
								IBrWXFecfpTSwtopbnjBOjuWhLfb = -3;
								goto IL_00dc;
							}
							IBrWXFecfpTSwtopbnjBOjuWhLfb = -1;
							if (VrTbdOicqUMlCBdjecUzhGoackCuE < 0 || MvusQGbnRBBQxpmHcwuQkjTQOkIS == null)
							{
								return false;
							}
							pTUXzpVikJfBARweSUuLbvLiPgdp = (kpTjtavOovzOujDmKwQHwopXtcTp ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
							BPPbBQiQSohCvZYHMXnFmvHZGewRA = 0;
							goto IL_0106;
							IL_0106:
							if (BPPbBQiQSohCvZYHMXnFmvHZGewRA < pTUXzpVikJfBARweSUuLbvLiPgdp.Count)
							{
								EDzrBKIBpdXgqVzIMQhZOKvjNbxr = pTUXzpVikJfBARweSUuLbvLiPgdp[BPPbBQiQSohCvZYHMXnFmvHZGewRA].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, xwIzHsddfuaLQPxSsJfeGZFArxFq, MvusQGbnRBBQxpmHcwuQkjTQOkIS, pzwXaMOGQfSqDpOqHanKbNYKOuVZA, aylCxJbjNQhDzjTeFCbYplHXMRoxb).GetEnumerator();
								IBrWXFecfpTSwtopbnjBOjuWhLfb = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (EDzrBKIBpdXgqVzIMQhZOKvjNbxr.MoveNext())
							{
								ElementAssignmentConflictInfo current = EDzrBKIBpdXgqVzIMQhZOKvjNbxr.Current;
								xZIsrKSRUdsCJJbjXJfKUTyPbVWF = current;
								IBrWXFecfpTSwtopbnjBOjuWhLfb = 1;
								return true;
							}
							CUSBNrlcXomzNeAmSOaHWGNWfabn();
							EDzrBKIBpdXgqVzIMQhZOKvjNbxr = null;
							BPPbBQiQSohCvZYHMXnFmvHZGewRA++;
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

					private void CUSBNrlcXomzNeAmSOaHWGNWfabn()
					{
						IBrWXFecfpTSwtopbnjBOjuWhLfb = -1;
						if (EDzrBKIBpdXgqVzIMQhZOKvjNbxr != null)
						{
							EDzrBKIBpdXgqVzIMQhZOKvjNbxr.Dispose();
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
						ntbClYdQanahaCQnHSnDWkKXeiKN ntbClYdQanahaCQnHSnDWkKXeiKN2;
						if (IBrWXFecfpTSwtopbnjBOjuWhLfb == -2 && nMJgcRiCYkCdvhHzDoTDXyJHRZEQA == Environment.CurrentManagedThreadId)
						{
							IBrWXFecfpTSwtopbnjBOjuWhLfb = 0;
							ntbClYdQanahaCQnHSnDWkKXeiKN2 = this;
						}
						else
						{
							ntbClYdQanahaCQnHSnDWkKXeiKN2 = new ntbClYdQanahaCQnHSnDWkKXeiKN(0);
						}
						ntbClYdQanahaCQnHSnDWkKXeiKN2.VrTbdOicqUMlCBdjecUzhGoackCuE = fjLUiLkldTaURgACyhhwDgvBsyzuB;
						ntbClYdQanahaCQnHSnDWkKXeiKN2.xwIzHsddfuaLQPxSsJfeGZFArxFq = QFsmjKGPnirJcUdnTBHHBQBnMRBN;
						ntbClYdQanahaCQnHSnDWkKXeiKN2.MvusQGbnRBBQxpmHcwuQkjTQOkIS = EfIIHFjMethwrFGGditYnbQGIEVaB;
						ntbClYdQanahaCQnHSnDWkKXeiKN2.pzwXaMOGQfSqDpOqHanKbNYKOuVZA = nusBRQBdiFWxQSAZoiAwNccfUIMF;
						ntbClYdQanahaCQnHSnDWkKXeiKN2.aylCxJbjNQhDzjTeFCbYplHXMRoxb = PEQBYHIKDNHiTdGWYwpqrXbsDTYP;
						ntbClYdQanahaCQnHSnDWkKXeiKN2.kpTjtavOovzOujDmKwQHwopXtcTp = uyylwSeMiyypZzfdukOCoQQHbSpKA;
						return ntbClYdQanahaCQnHSnDWkKXeiKN2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class MFZeMLFxGFZabpTxBYRBZRTsxUtD : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ILbSfstIFzltylidySFDcICOuSLX;

					private ElementAssignmentConflictInfo WNyZcnFDFQxbFDdnKfBUzulticSV;

					private int OXDSqyjxDdCcJtqlFUpXvCPTgZjAA;

					private ElementAssignmentConflictCheck rCXIYTwEqbAnRzScMdmfhNtggdyo;

					public ElementAssignmentConflictCheck almBcBHigGqFxWlEBNAQtHJIHyst;

					private bool urrtRVokUuaZNAzoKzDVviUWqFhHb;

					public bool QMsYMQycwVVDvylpXVfOJkYeyuQT;

					private bool sMqEoNCuWsazGdytfBtlemndUDAud;

					public bool cfXxdtTRzKPUTlvlcFjmZrYSSFEs;

					private bool QlztoUNDljMDblBSXQgIyTTNNpbq;

					public bool IQEQuJoMGjeVgdBmKqIBQpoRPhRcA;

					private IList<Player> JhndoLTfuIMBTGpKOZYrCXeMbsQh;

					private int ymbaUskQbLAHgKUMBPAEBlxHwNLcB;

					private IEnumerator<ElementAssignmentConflictInfo> XFOLqWsSXjICQgohpvylAzYoHugW;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WNyZcnFDFQxbFDdnKfBUzulticSV;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WNyZcnFDFQxbFDdnKfBUzulticSV;
						}
					}

					[DebuggerHidden]
					public MFZeMLFxGFZabpTxBYRBZRTsxUtD(int P_0)
					{
						ILbSfstIFzltylidySFDcICOuSLX = P_0;
						OXDSqyjxDdCcJtqlFUpXvCPTgZjAA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int iLbSfstIFzltylidySFDcICOuSLX = ILbSfstIFzltylidySFDcICOuSLX;
						if (iLbSfstIFzltylidySFDcICOuSLX == -3 || iLbSfstIFzltylidySFDcICOuSLX == 1)
						{
							try
							{
							}
							finally
							{
								ZKhzrrDEILzFdXVqwOeagRAyHvbE();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int iLbSfstIFzltylidySFDcICOuSLX = ILbSfstIFzltylidySFDcICOuSLX;
							if (iLbSfstIFzltylidySFDcICOuSLX != 0)
							{
								if (iLbSfstIFzltylidySFDcICOuSLX != 1)
								{
									return false;
								}
								ILbSfstIFzltylidySFDcICOuSLX = -3;
								goto IL_00df;
							}
							ILbSfstIFzltylidySFDcICOuSLX = -1;
							if (rCXIYTwEqbAnRzScMdmfhNtggdyo.playerId < 0 || rCXIYTwEqbAnRzScMdmfhNtggdyo.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							JhndoLTfuIMBTGpKOZYrCXeMbsQh = (urrtRVokUuaZNAzoKzDVviUWqFhHb ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
							ymbaUskQbLAHgKUMBPAEBlxHwNLcB = 0;
							goto IL_0109;
							IL_0109:
							if (ymbaUskQbLAHgKUMBPAEBlxHwNLcB < JhndoLTfuIMBTGpKOZYrCXeMbsQh.Count)
							{
								XFOLqWsSXjICQgohpvylAzYoHugW = JhndoLTfuIMBTGpKOZYrCXeMbsQh[ymbaUskQbLAHgKUMBPAEBlxHwNLcB].controllers.conflictChecking.ElementAssignmentConflicts(rCXIYTwEqbAnRzScMdmfhNtggdyo, sMqEoNCuWsazGdytfBtlemndUDAud, QlztoUNDljMDblBSXQgIyTTNNpbq).GetEnumerator();
								ILbSfstIFzltylidySFDcICOuSLX = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (XFOLqWsSXjICQgohpvylAzYoHugW.MoveNext())
							{
								ElementAssignmentConflictInfo current = XFOLqWsSXjICQgohpvylAzYoHugW.Current;
								WNyZcnFDFQxbFDdnKfBUzulticSV = current;
								ILbSfstIFzltylidySFDcICOuSLX = 1;
								return true;
							}
							ZKhzrrDEILzFdXVqwOeagRAyHvbE();
							XFOLqWsSXjICQgohpvylAzYoHugW = null;
							ymbaUskQbLAHgKUMBPAEBlxHwNLcB++;
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

					private void ZKhzrrDEILzFdXVqwOeagRAyHvbE()
					{
						ILbSfstIFzltylidySFDcICOuSLX = -1;
						if (XFOLqWsSXjICQgohpvylAzYoHugW != null)
						{
							XFOLqWsSXjICQgohpvylAzYoHugW.Dispose();
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
						MFZeMLFxGFZabpTxBYRBZRTsxUtD mFZeMLFxGFZabpTxBYRBZRTsxUtD;
						if (ILbSfstIFzltylidySFDcICOuSLX == -2 && OXDSqyjxDdCcJtqlFUpXvCPTgZjAA == Environment.CurrentManagedThreadId)
						{
							ILbSfstIFzltylidySFDcICOuSLX = 0;
							mFZeMLFxGFZabpTxBYRBZRTsxUtD = this;
						}
						else
						{
							mFZeMLFxGFZabpTxBYRBZRTsxUtD = new MFZeMLFxGFZabpTxBYRBZRTsxUtD(0);
						}
						mFZeMLFxGFZabpTxBYRBZRTsxUtD.rCXIYTwEqbAnRzScMdmfhNtggdyo = almBcBHigGqFxWlEBNAQtHJIHyst;
						mFZeMLFxGFZabpTxBYRBZRTsxUtD.sMqEoNCuWsazGdytfBtlemndUDAud = cfXxdtTRzKPUTlvlcFjmZrYSSFEs;
						mFZeMLFxGFZabpTxBYRBZRTsxUtD.QlztoUNDljMDblBSXQgIyTTNNpbq = IQEQuJoMGjeVgdBmKqIBQpoRPhRcA;
						mFZeMLFxGFZabpTxBYRBZRTsxUtD.urrtRVokUuaZNAzoKzDVviUWqFhHb = QMsYMQycwVVDvylpXVfOJkYeyuQT;
						return mFZeMLFxGFZabpTxBYRBZRTsxUtD;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private static ConflictCheckingHelper QOOZOuTdtvJWXBkeQchSCpavhXpS;

				internal static ConflictCheckingHelper GheaKvPTdJafBYyyPDvJOxhGRXvL => QOOZOuTdtvJWXBkeQchSCpavhXpS ?? (QOOZOuTdtvJWXBkeQchSCpavhXpS = new ConflictCheckingHelper());

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
					IList<Player> list = (includeSystemPlayer ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
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
						ControllerType.Joystick => RJLGklbfnwvbhRySENQQMSpsPlNvA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => JtOsjzQFZsEhdIDHeTBuoddwBrgqA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => WEeGLmTnTtKiZMtBmqAmAOiHasDo(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => qczuEsfSesHAckkNpiwSdOgqYadvA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return ePFByafCjigyrUKzleOGjTMrFejzA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ZxiVIouMUdcsgeQblobYlBQKsoHlA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return IiNUPhGeXnnbrJRCEKLimvNMfrcr(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return WcVdsTBhRpdtWQiyFwNBDXCZdrOK(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool RJLGklbfnwvbhRySENQQMSpsPlNvA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool ePFByafCjigyrUKzleOGjTMrFejzA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool JtOsjzQFZsEhdIDHeTBuoddwBrgqA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool ZxiVIouMUdcsgeQblobYlBQKsoHlA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool WEeGLmTnTtKiZMtBmqAmAOiHasDo(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool IiNUPhGeXnnbrJRCEKLimvNMfrcr(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool qczuEsfSesHAckkNpiwSdOgqYadvA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool WcVdsTBhRpdtWQiyFwNBDXCZdrOK(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
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
						ControllerType.Joystick => gAXNmOjfKfBsQKREuXoRhfIuKrgeA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => OmwXiLykvAebtHFdJoMPrGMoqJQS(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => sqDfFwolcgjFCxTkeqJhwlKcarqi(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => DfrCrxIaxoLvWYNXZsOyQWFOzxWF(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return tNhSwQyjJcKwBHRqeqbaVxtfmQSW(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return VBoIqfRBtbRJowJQYkSlvcBlwOjn(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return KGvcuRCLxmgUOmKQsQogKTgEVQWEA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return IKGeSHnqxnvOcCDhWIkiGnJFsyyX(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				[IteratorStateMachine(typeof(rPmhteZErOiFtGwLquDokovnFXxEA))]
				private IEnumerable<ElementAssignmentConflictInfo> gAXNmOjfKfBsQKREuXoRhfIuKrgeA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new rPmhteZErOiFtGwLquDokovnFXxEA(-2)
					{
						GMRDgYGuBasOEdzqOMISJXbenRsfA = P_0,
						SQHtwZjPuWSgbmuirFGzukYKiTix = P_1,
						JJBQkHBOVGpbRQiDHemSoIhtEeUw = P_2,
						HADEYzWpmuCICOKklqXLnezRoimt = P_3,
						WCOHuitRoIBxaGomJxqhZeTgLmjy = P_4,
						HtzrrDnttieGmIxJeIhwflPgFZcBA = P_5,
						OeMPoZvHHrdSittDvExqbkIKhqHSA = P_6
					};
				}

				[IteratorStateMachine(typeof(SpMxMNQqlbHuTiMRVElBpmxPdOjCb))]
				private IEnumerable<ElementAssignmentConflictInfo> tNhSwQyjJcKwBHRqeqbaVxtfmQSW(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new SpMxMNQqlbHuTiMRVElBpmxPdOjCb(-2)
					{
						KgUCgpGMEjhLDBkIMDniNmobXqgM = P_0,
						QkAsetxhtHgYIOjCsfneGqZAIGuB = P_1,
						xAiXqupYZaXWcvYmLNSyzsYrEJiD = P_2,
						mXDsGeYoeGcSKcDkRoMZRdAUOjwT = P_3
					};
				}

				[IteratorStateMachine(typeof(BfCeVexbXxQCOiOqIzLKZDdxEpidA))]
				private IEnumerable<ElementAssignmentConflictInfo> OmwXiLykvAebtHFdJoMPrGMoqJQS(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new BfCeVexbXxQCOiOqIzLKZDdxEpidA(-2)
					{
						QNRBjBRwdJOIXdCnoGnCJKJFvwMaA = P_0,
						HHGAWHHpTmUmsejvZDIOFPKKzsfNA = P_1,
						vSzEFaIXktyoXMQAUZNIuHEKrGgFA = P_2,
						CmNZhOCFdoVLVWAPgAshREuuHUQl = P_3,
						KjqJazFKTiELQRBldjhdQaLXEUIe = P_4,
						luFdLSdvhqQwbxDKlFoOJHoMgBqOA = P_5
					};
				}

				[IteratorStateMachine(typeof(oNtXYAKOpWfBsVoTAAWhuSRgEAxFA))]
				private IEnumerable<ElementAssignmentConflictInfo> VBoIqfRBtbRJowJQYkSlvcBlwOjn(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new oNtXYAKOpWfBsVoTAAWhuSRgEAxFA(-2)
					{
						dusyfaIuVtKABtovAzXYygVNdINE = P_0,
						rpRMeuYoqSBjGYygZkNizpSEXkAL = P_1,
						LyYwbxhCxWndEBNgPnVnPZgYBfZo = P_2,
						jarVSAnIvJuybpKEyrMIwMVqaWRY = P_3
					};
				}

				[IteratorStateMachine(typeof(ntbClYdQanahaCQnHSnDWkKXeiKN))]
				private IEnumerable<ElementAssignmentConflictInfo> sqDfFwolcgjFCxTkeqJhwlKcarqi(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new ntbClYdQanahaCQnHSnDWkKXeiKN(-2)
					{
						fjLUiLkldTaURgACyhhwDgvBsyzuB = P_0,
						QFsmjKGPnirJcUdnTBHHBQBnMRBN = P_1,
						EfIIHFjMethwrFGGditYnbQGIEVaB = P_2,
						nusBRQBdiFWxQSAZoiAwNccfUIMF = P_3,
						PEQBYHIKDNHiTdGWYwpqrXbsDTYP = P_4,
						uyylwSeMiyypZzfdukOCoQQHbSpKA = P_5
					};
				}

				[IteratorStateMachine(typeof(MFZeMLFxGFZabpTxBYRBZRTsxUtD))]
				private IEnumerable<ElementAssignmentConflictInfo> KGvcuRCLxmgUOmKQsQogKTgEVQWEA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new MFZeMLFxGFZabpTxBYRBZRTsxUtD(-2)
					{
						almBcBHigGqFxWlEBNAQtHJIHyst = P_0,
						cfXxdtTRzKPUTlvlcFjmZrYSSFEs = P_1,
						IQEQuJoMGjeVgdBmKqIBQpoRPhRcA = P_2,
						QMsYMQycwVVDvylpXVfOJkYeyuQT = P_3
					};
				}

				[IteratorStateMachine(typeof(iWqPssWItCmwqClkLTfrqpCvZRel))]
				private IEnumerable<ElementAssignmentConflictInfo> DfrCrxIaxoLvWYNXZsOyQWFOzxWF(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new iWqPssWItCmwqClkLTfrqpCvZRel(-2)
					{
						kQMVHEFcyXDtASbiaLsDegtivtDC = P_0,
						BGLjnAgjspdlCkRRmpAdaBEEJmzJb = P_1,
						jdxDyRfEtKqAWsmROZsrcfyAztCLA = P_2,
						TsbCgpYbRJgegHXAQGgLfnKISfDJ = P_3,
						gCUPznoqJXlTCGFgVypCLvAvpHDS = P_4,
						DjruHzyyMRGHWDlGRYaCAZVVLcS = P_5,
						uRSGvVAYHIRdqhxmNRCELYmKbeNXA = P_6
					};
				}

				[IteratorStateMachine(typeof(PpCrAqxoevXsqducrPFmkpwPODGq))]
				private IEnumerable<ElementAssignmentConflictInfo> IKGeSHnqxnvOcCDhWIkiGnJFsyyX(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new PpCrAqxoevXsqducrPFmkpwPODGq(-2)
					{
						FrBFiHApubwAWWTtttCOEacsZeZb = P_0,
						mbdKefVRjPDhRmCTMFGrALnSGzTM = P_1,
						gMxGDgaXMkrKbiYkUexsWzPESUSm = P_2,
						vtcnrVaxKtamQJLgfbsXUBLVyqs = P_3
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
						ControllerType.Joystick => xrWwFnfoRYfwnnpEusioSGjUTCR(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => lPcsJRvmCEfJdgBNXPYBBUocylhqA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => DQBKlJMUMsvQxXQikgAHjKOtUdmR(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => SHgKcLMDBOvaKvzGFExqbliPdhCM(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return MAZoxGtedCNiuzfvNBqfISqcZNqwA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return kMeBOMGMURtDXFFnOuTEPehOAEyGA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return rrSYfxUAhpapPzfcjCZUcvrEIeuN(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return pCDtsSkGrieXgesZPYOymKbTzeOGA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int xrWwFnfoRYfwnnpEusioSGjUTCR(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int MAZoxGtedCNiuzfvNBqfISqcZNqwA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int lPcsJRvmCEfJdgBNXPYBBUocylhqA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int kMeBOMGMURtDXFFnOuTEPehOAEyGA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int DQBKlJMUMsvQxXQikgAHjKOtUdmR(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int rrSYfxUAhpapPzfcjCZUcvrEIeuN(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int SHgKcLMDBOvaKvzGFExqbliPdhCM(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int pCDtsSkGrieXgesZPYOymKbTzeOGA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
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
						ControllerType.Joystick => qWYsYcRoGlLnUgGaVslhaeRwzttb(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => RzRFvDxrxbdfRIdwrZWsxXSvHKnm(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => zsZqZiiIrwrkLcBYCRBlhGtxCYTP(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => VjaSknauywjJgLtMaqQjOLRKoMyP(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return YibnwIUUCAKnaMbIfSkFoKYkDXsW(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return pOtIADuFDtinEXwBvIudhSwpmRmGb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return DUGpxnRrMewDUaBIAqnTTPlQemFGA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return QFoLhJquRBiOvrViyDycFCKpBaedA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int qWYsYcRoGlLnUgGaVslhaeRwzttb(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int YibnwIUUCAKnaMbIfSkFoKYkDXsW(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int RzRFvDxrxbdfRIdwrZWsxXSvHKnm(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int pOtIADuFDtinEXwBvIudhSwpmRmGb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int zsZqZiiIrwrkLcBYCRBlhGtxCYTP(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int DUGpxnRrMewDUaBIAqnTTPlQemFGA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int VjaSknauywjJgLtMaqQjOLRKoMyP(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int QFoLhJquRBiOvrViyDycFCKpBaedA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA : ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper tZWcDwzrcCAaVpqmWMcMjTiqSyXe;

			public readonly PollingHelper polling = PollingHelper.asxPkyFRKAbDVEAjrSmIHjCEHITJA;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.GheaKvPTdJafBYyyPDvJOxhGRXvL;

			internal static ControllerHelper RlZpbqBuFSKPMnqftskGduWLlDKw => tZWcDwzrcCAaVpqmWMcMjTiqSyXe ?? (tZWcDwzrcCAaVpqmWMcMjTiqSyXe = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.kCjfQealhxhSiAHGGVnNNxKWgzdP;
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
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.gqOcGSxyswTTNjzDQfvsXtCfRjKw;
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
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.DSSddfFhMNEuZUeDpMEBaimidxHxB;
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
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.DgfFcsFEypGvKCatIhkeSdaWtzwHc;
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
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.pwyKpsUfOHnkYjLOCiQAqFosrZvs;
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
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA;
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
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.OJSBCxBHDCPIwHiTOpUPcRusrxJc;
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
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.VciiLHzZwsMOLBgQDNuKLdDrPvph;
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
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.DgfFcsFEypGvKCatIhkeSdaWtzwHc as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return VeAmGFtEIHUuquEZXjxbJYdKKrEb.DSSddfFhMNEuZUeDpMEBaimidxHxB as T;
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
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.QCDDZTfeTGMbmcEJicshLRdxImzvA(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.IWHTkDTWwMdxIsaOjphjbpfVESum(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.vHymXCtKkrGqQEWRSDiJEfInGXbGA(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.lwyfLXcmbpSkNMOPSJjvcrjMDxkSA(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.uHrozQCgbwBKiBItVqiSRudRuvQN(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.VQjvBWONvPgtzDMAEuUJEOdxbYqXA(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.KACzddYFWPaCRMRgYzhRhtqUiKoC(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ABDTVoIIjFlEZLKHRhISrlbClCcb.VnbbRojUeZTerKamyiExpAwDrmlOA(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ABDTVoIIjFlEZLKHRhISrlbClCcb.LcdpRTuBLUFctXObwCnLSgblfEWhA(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.oisDKJWbKjPOgFFsCBsSMlVpdULY(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.eUHZqjMCLNJbpsmFgevMpIqbDiej();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.pJlyPhggDGIMvGPiTkIHbwDadsPDb();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.ugjLfyrLVgwwuEeEkxAGGIdbQHCY(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.KMwghhEZYhtAqlhodovVOJZhmcqkA(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.BDBgkqhPEdyHkVeMWkNrPnFvdaAVA(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ABDTVoIIjFlEZLKHRhISrlbClCcb.IxAfwpqfRhrFSgIcGcIbCagpqpaeb(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ABDTVoIIjFlEZLKHRhISrlbClCcb.QvVhGSAKlTmnEDIQulhFrWKfFNAk(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!IveJgwrIDzyjDxaVLdWEMEsffdNIA)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				ixWiSPshcgDoxhUuXqdAhoVMHFVyA();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (ZvBYsooYKxEonRkVIeotklAxDjEY.ydcTKofqZoAlKwDwYnBZmDXnMELE(i, j))
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
				if (!IveJgwrIDzyjDxaVLdWEMEsffdNIA)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				ixWiSPshcgDoxhUuXqdAhoVMHFVyA();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (ZvBYsooYKxEonRkVIeotklAxDjEY.ydcTKofqZoAlKwDwYnBZmDXnMELE(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (ZvBYsooYKxEonRkVIeotklAxDjEY.CDDANtdiQOXuOADfwwGiqKvxkXQl(i, k, positiveAxesOnly))
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
					if (!IveJgwrIDzyjDxaVLdWEMEsffdNIA)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						nmQIPpFiDbQPOhxkdBLxhfsyzmvc.SetUnityJoystickId(joystickId, unityJoystickId);
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
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.WZjCApZPCCEVYhDYjCkwqlyTROem(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.PhjBzhagGkZWQIykZHpwNGjclUBgA();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.wGqnLRCAShTniHgdCTFZJYxjnbzF();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.ifDTfvBZeFogdEcvSgmsWgOUbMIEA(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.uVMvSTEHyIJxkxefJAHnJQOznapi(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.ySJhjaZCFYiphYLBmsliPpaWgSLW(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ABDTVoIIjFlEZLKHRhISrlbClCcb.tEQixQAylHQlAnvnBcONTEXeTIOM(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ABDTVoIIjFlEZLKHRhISrlbClCcb.tsKINBdiQJRwJpFKlXFkWRznTIzc(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.OnAhnnQHKixkcuMWkpqEUJNLAIkDA(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = VeAmGFtEIHUuquEZXjxbJYdKKrEb.OnAhnnQHKixkcuMWkpqEUJNLAIkDA(sourceControllerId);
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
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.vVaNtReLpaETTeJmaNXzneLjNwOq(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.teyfxtHcBfhvpaslJtmzfxQUVcVeA(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.YVgBOQlieUBNhDhJIpLaBhPtUfMF(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.yqrTpxNlpMNoroFizbZaqytpPnuB(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.hNQVlAMhrTLbkunbgHrSeqpXifLq(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.KoGzTCYOaaUvFIYHVlftboOPBFeAA<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.KNabPxHPnbpKIbShSuiSwEAMATzN();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.iEQeTwznTlabRPoKsLBxXWhUgUsD(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.KNabPxHPnbpKIbShSuiSwEAMATzN<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.klkdmRyLWxoBYnLgwfWtgSmkCEqUA();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					VeAmGFtEIHUuquEZXjxbJYdKKrEb.iJaLTSIWMiBJwuPRtyisPAEiCdPl(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					VeAmGFtEIHUuquEZXjxbJYdKKrEb.OKTafOYtYkbyrBFcpPuyvcbjqmJIA(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					VeAmGFtEIHUuquEZXjxbJYdKKrEb.RyPgcfOJYsFxGhnGfBBZFrwcZbMdA(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					VeAmGFtEIHUuquEZXjxbJYdKKrEb.GglhWnApFRtPPlzGUHvdArbbnswQ(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					VeAmGFtEIHUuquEZXjxbJYdKKrEb.gViJcJyhHAmXyZCIrbQGCMpNPlCKA();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.ROnSgHmAByOeqDoIhfJceJogSKMo();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.eHKmQgpiFkgpcxJqhrelfjflvyll(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.uGmKoyGwNInQDqPtpIUppOzIIepj();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.bNHarTiTPAhZhYKJtKIEKIlwvcdrA(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.XQQqFUZwmHFieXVHdOPctoTWGsPb();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.pgrNugLVHYQjJoZAFfKLauqMagKT(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.CYauZSLioVcfSyqPFpklfhagEhOr();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.HyICKCWCJEymZTvKBvxaGmUOZECH(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.hbOEJkRHMDKhJxrgKeeROeYSuhpV();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.qlgAgdgMZJsdYLTfVBxZCNAeGQhoc(controllerType);
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
				ABDTVoIIjFlEZLKHRhISrlbClCcb.ufFgsSdkjuDAVfUimDAlLssVnttAA(joystick);
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
			private static MappingHelper BbUqOWDReyMmeLnDEazJBeXphQizA;

			internal static MappingHelper KQvVmSouHQjuvrMsIFmnrIdGFCmGA => BbUqOWDReyMmeLnDEazJBeXphQizA ?? (BbUqOWDReyMmeLnDEazJBeXphQizA = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return afadmdopkFDkKcMXUOVulpLPkXjgA.zjvLfOagottnMWWpDdziNFuLUWue;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.xOsvgDsqBXTyZYWcOKaTpDFIzxjF;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.CPdUaLyUPxRDERAVzytFodNwfogbA;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.ZBXjztcovFyzyGvuMShUvlMeqWGd;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.jnBjdsmCJfKdamrrgpehBFRAYCEY;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.VJownyunvtuwYrsMnuBxtPTujAvT;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.KdoYsIOYnUIuBuRPcmGeOlsdbRFE;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.RidNSlOJEffwHGQAxCFRhanGkjNl;
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
					return ilKdcvAddvhstqcjWcabGGsfjMRZB.gyJTduGYIhUqxuNheINoubncViuj;
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
					return afadmdopkFDkKcMXUOVulpLPkXjgA.RkwdTdaSsmuUEqeoaiDjicPtfghuA;
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
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.brhCYlltEvAbixJVTrZwuHflaldQ(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.whdesFibbOmkXbeXlTVBejPJZorAc(tag);
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
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.AYBcIgYQuyAzofBXYpInDllAozDL(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.ywodJmeRSVDPTKTookJBkJIBgiIn(tag);
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
					ControllerType.Joystick => afadmdopkFDkKcMXUOVulpLPkXjgA.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => afadmdopkFDkKcMXUOVulpLPkXjgA.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => afadmdopkFDkKcMXUOVulpLPkXjgA.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => afadmdopkFDkKcMXUOVulpLPkXjgA.GetCustomControllerLayoutById(layoutId), 
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
					ControllerType.Joystick => afadmdopkFDkKcMXUOVulpLPkXjgA.GetJoystickLayout(name), 
					ControllerType.Keyboard => afadmdopkFDkKcMXUOVulpLPkXjgA.GetKeyboardLayout(name), 
					ControllerType.Mouse => afadmdopkFDkKcMXUOVulpLPkXjgA.GetMouseLayout(name), 
					ControllerType.Custom => afadmdopkFDkKcMXUOVulpLPkXjgA.GetCustomControllerLayout(name), 
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
					ControllerType.Joystick => afadmdopkFDkKcMXUOVulpLPkXjgA.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => afadmdopkFDkKcMXUOVulpLPkXjgA.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => afadmdopkFDkKcMXUOVulpLPkXjgA.GetMouseLayoutId(name), 
					ControllerType.Custom => afadmdopkFDkKcMXUOVulpLPkXjgA.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetCustomControllerLayoutId(name);
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
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.AXgNZSXzzyNhazxBImQvpYSsTjAR(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.AXgNZSXzzyNhazxBImQvpYSsTjAR(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.ykITMqpVIMgtcredTnSUDPHcqgQb(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.ykITMqpVIMgtcredTnSUDPHcqgQb(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.tDEaGuQLrXPNsDeNvMgebEiYbUUz(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.TdWBFrIVFPWlZJksvkeJauncpGgX(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.TdWBFrIVFPWlZJksvkeJauncpGgX(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.eFQQMVotetlfOGzDlMcVfObGYVpN(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.eFQQMVotetlfOGzDlMcVfObGYVpN(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.KPosqjUxyvnPglXSXWmDpcrqwcsK(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.KPosqjUxyvnPglXSXWmDpcrqwcsK(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.MrZdBRkTKSFptotNpZzmHmxWnIYX(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VeAmGFtEIHUuquEZXjxbJYdKKrEb.ZJftCxyafRgHdKBNXPAUKBOxxqAiA(playerId, behaviorName);
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
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior SackBhJauJUmRxJwYfyNeCmbMjbh(int P_0)
			{
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetInputBehaviorById(P_0);
			}

			internal InputBehavior LBdBEikeraJeKYHzXAJFuwIHRpHJ(string P_0)
			{
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetInputBehavior(P_0);
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
				Controller controller = VeAmGFtEIHUuquEZXjxbJYdKKrEb.IWHTkDTWwMdxIsaOjphjbpfVESum(controllerIdentifier);
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
				JoystickMap joystickMap = afadmdopkFDkKcMXUOVulpLPkXjgA.xDZwXbEkVZRakTvMLrpwClMerKHh(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.FeQHluiWzbggXquWcpGEIuFssFTaA(joystickMap);
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
				InputSource inputSourceType = nmQIPpFiDbQPOhxkdBLxhfsyzmvc.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = TnVTULtaLeGRpomSLLfeqTMBPAhg.phiAqYaMZyDTStMfJMbIwkqnvGEn(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = afadmdopkFDkKcMXUOVulpLPkXjgA.FsSixdhmefXtbeXeRCdQMdHnbsXb(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.qerKHzhyQlrTNnLVyYCOIjYHEzxR(joystickMap, hardwareControllerMap_Game);
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
				if (VeAmGFtEIHUuquEZXjxbJYdKKrEb.IWHTkDTWwMdxIsaOjphjbpfVESum(controllerIdentifier) is Joystick joystick)
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
				KeyboardMap keyboardMap = afadmdopkFDkKcMXUOVulpLPkXjgA.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.FeQHluiWzbggXquWcpGEIuFssFTaA(keyboardMap);
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
				MouseMap mouseMap = afadmdopkFDkKcMXUOVulpLPkXjgA.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.FeQHluiWzbggXquWcpGEIuFssFTaA(mouseMap);
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
				CustomControllerMap customControllerMap = afadmdopkFDkKcMXUOVulpLPkXjgA.KXAiRfDQanCwvlzzVuoqYkPCLMYm(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.FeQHluiWzbggXquWcpGEIuFssFTaA(customControllerMap);
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
				if (VeAmGFtEIHUuquEZXjxbJYdKKrEb.IWHTkDTWwMdxIsaOjphjbpfVESum(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = afadmdopkFDkKcMXUOVulpLPkXjgA.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = afadmdopkFDkKcMXUOVulpLPkXjgA.VUEGkVdxebQlmPeRVmAAMgTFLROKA(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.qerKHzhyQlrTNnLVyYCOIjYHEzxR(customControllerMap, hardwareControllerMap_Game);
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
					controllerMap = afadmdopkFDkKcMXUOVulpLPkXjgA.gpTdgMWdIjjfKTDdirChMNOgXGTB(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.ZObaaEOWJCUGSFVciZmydJCyrGXj(controller, controllerMap);
					}
					else
					{
						controller.FeQHluiWzbggXquWcpGEIuFssFTaA(controllerMap);
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
				if (VeAmGFtEIHUuquEZXjxbJYdKKrEb.IWHTkDTWwMdxIsaOjphjbpfVESum(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = nmQIPpFiDbQPOhxkdBLxhfsyzmvc.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = TnVTULtaLeGRpomSLLfeqTMBPAhg.phiAqYaMZyDTStMfJMbIwkqnvGEn(controllerIdentifier.hardwareTypeGuid, inputSourceType);
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
					joystickMap = afadmdopkFDkKcMXUOVulpLPkXjgA.FsSixdhmefXtbeXeRCdQMdHnbsXb(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
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
						allMap.qerKHzhyQlrTNnLVyYCOIjYHEzxR(joystickMap, hardwareControllerMap_Game);
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
				if (VeAmGFtEIHUuquEZXjxbJYdKKrEb.IWHTkDTWwMdxIsaOjphjbpfVESum(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = afadmdopkFDkKcMXUOVulpLPkXjgA.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
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
					customControllerMap = afadmdopkFDkKcMXUOVulpLPkXjgA.VUEGkVdxebQlmPeRVmAAMgTFLROKA(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.qerKHzhyQlrTNnLVyYCOIjYHEzxR(customControllerMap, hardwareControllerMap_Game);
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
					keyboardMap = afadmdopkFDkKcMXUOVulpLPkXjgA.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.ZObaaEOWJCUGSFVciZmydJCyrGXj(keyboard, keyboardMap);
					}
					else
					{
						keyboard.FeQHluiWzbggXquWcpGEIuFssFTaA(keyboardMap);
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
					mouseMap = afadmdopkFDkKcMXUOVulpLPkXjgA.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.ZObaaEOWJCUGSFVciZmydJCyrGXj(mouse, mouseMap);
					}
					else
					{
						mouse.FeQHluiWzbggXquWcpGEIuFssFTaA(mouseMap);
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
				return oKYJXWOeRIamzVDmnbIHdJJDHnXt(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier oKYJXWOeRIamzVDmnbIHdJJDHnXt(Guid P_0, int P_1)
			{
				HardwareJoystickMap hardwareControllerMap;
				return TnVTULtaLeGRpomSLLfeqTMBPAhg.dXKjXduMTUsejefoEAVtAuQHAvLuA(P_0, P_1, out hardwareControllerMap)?.ToControllerElementIdentifier(hardwareControllerMap);
			}

			internal int OmSOeSNHHaSbjLXouQLAnYuCaITs(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.bSeoxkAXPAPaGzvxBXEzIEDOfGVn> P_3)
			{
				return TnVTULtaLeGRpomSLLfeqTMBPAhg.joEbdxxCjJftaoMFFlzUoPFsSzMJ(P_0, P_1, P_2, P_3);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return afadmdopkFDkKcMXUOVulpLPkXjgA.DHthsvsHDYAzJCbSfokDMgqdJYkJ(templateTypeGuid, mapCategoryId, layoutId);
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
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = afadmdopkFDkKcMXUOVulpLPkXjgA.GetControllerMapLayoutManagerRuleSetId(name);
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
				return afadmdopkFDkKcMXUOVulpLPkXjgA.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = afadmdopkFDkKcMXUOVulpLPkXjgA.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper lgOYvKvOQujgfDSCUyvGNJjFeRyZ;

			internal static PlayerHelper vIdDSoPEnUcZigmuWmEdUAMzoIgm => lgOYvKvOQujgfDSCUyvGNJjFeRyZ ?? (lgOYvKvOQujgfDSCUyvGNJjFeRyZ = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return ABDTVoIIjFlEZLKHRhISrlbClCcb.PgvVwCKqIMiCGICkPcSeOjADhiYHA;
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
					return ABDTVoIIjFlEZLKHRhISrlbClCcb.tTAgJsZjTDwqxfQZLEchyJiueBhb;
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
					return ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB;
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
					return ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA;
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
					return ABDTVoIIjFlEZLKHRhISrlbClCcb.UYvxAAXLLbizFcdHDYaOxGuhfKrc();
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
					return ABDTVoIIjFlEZLKHRhISrlbClCcb.jHkpGHSbDxJCtHlTDhmvZphxDDtB;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.AHWgfJfctrWLAdtjHSOGbKBsDGRTA;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.RmeButhFmdxsBQPRyEgbZicZgdaPA(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.bocNkkzFUJiZbroHaQlOkMmYMkvf(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.UYvxAAXLLbizFcdHDYaOxGuhfKrc();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.GIsqGsJQAFbAcORnhkeGcqxHCbHm(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.UTccntAdaUQUkUlaYJCwIosGNySV(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.tKgxaALdNenyWoGnoeDmoAHwJsSw(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return ABDTVoIIjFlEZLKHRhISrlbClCcb.RhLpctkdEXHYRuQFrCigsaAHBfDc(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper EbHhJILSdCCGhsVDKfIfAoCDUSMk;

			internal static TimeHelper mnWhxwgDipzbIjikLGuFPCipgfP => EbHhJILSdCCGhsVDKfIfAoCDUSMk ?? (EbHhJILSdCCGhsVDKfIfAoCDUSMk = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)vVhenyNmyJKFhFovDsjqXGPMgWcs.KvrWbaavfIBEsRjyEghKomxKmIwA;
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
					return vVhenyNmyJKFhFovDsjqXGPMgWcs.RcgfSvulvaiXbpchCzRelLjBIRQB;
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
					return vVhenyNmyJKFhFovDsjqXGPMgWcs.GQtePfuxlwasYETXQAVeuzbQJvAc;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class JAlMUtzQpJYerJOtbgjcATeZqPJi
		{
			private class IAupmyufSIArMQUfxfCGiisMvmLz
			{
				public readonly UpdateLoopType NoDRkXvunEETfzMndGknKOQrfrKNA;

				private double KfITNudXuMgsCOxuqtuCXrzLtgoc;

				private double IFOtkHmpsIKbieItuzopzTTWgZpq;

				private double HWiHjQfERhfzkbWGfXDAAITmSUTfA;

				private double CuNDDehGzQfjYxsBJxBgSsbgvTou;

				private uint OOBfxoigHSYFGcrOKdUxDcCtEGPkA;

				private uint hEqLGuCNacIuWVbiYRUYtgpAOfFq;

				private float klqMqIPLnKusHEMLufvoAgBBejWDA;

				private float fYDATdUVnqbmIEPfbDLFiqRIuYlKb;

				public double YpDShwBwoWPtXuNgRKndrFJedGxDA => KfITNudXuMgsCOxuqtuCXrzLtgoc;

				public double GRfBfABXuXFwVYURIXFUcfYFrPEm => IFOtkHmpsIKbieItuzopzTTWgZpq;

				public double lSejeRiUxyNAoVeFgDAjhUwlpQiY => HWiHjQfERhfzkbWGfXDAAITmSUTfA;

				public uint KVOzveDMtLpWCCzOOiPIuxbqDBWN => OOBfxoigHSYFGcrOKdUxDcCtEGPkA;

				public uint kKBSUTjqYhadMTAreDstJOHPnVkdA => hEqLGuCNacIuWVbiYRUYtgpAOfFq;

				public float mCYxJYocJSuqOiTPDTdbvExYgdpC => klqMqIPLnKusHEMLufvoAgBBejWDA;

				public float MxBQIKPBHjsDroJuquKKDgzbFrru => fYDATdUVnqbmIEPfbDLFiqRIuYlKb;

				public IAupmyufSIArMQUfxfCGiisMvmLz(UpdateLoopType P_0)
				{
					NoDRkXvunEETfzMndGknKOQrfrKNA = P_0;
					CuNDDehGzQfjYxsBJxBgSsbgvTou = Time.realtimeSinceStartup;
					OOBfxoigHSYFGcrOKdUxDcCtEGPkA = 0u;
				}

				public void maSnDEnpxmGPPmVCQfHLMrdyacEKA()
				{
					IFOtkHmpsIKbieItuzopzTTWgZpq = KfITNudXuMgsCOxuqtuCXrzLtgoc;
					KfITNudXuMgsCOxuqtuCXrzLtgoc = realTime;
					if (CuNDDehGzQfjYxsBJxBgSsbgvTou > KfITNudXuMgsCOxuqtuCXrzLtgoc)
					{
						CuNDDehGzQfjYxsBJxBgSsbgvTou = 0.0;
					}
					HWiHjQfERhfzkbWGfXDAAITmSUTfA = KfITNudXuMgsCOxuqtuCXrzLtgoc - CuNDDehGzQfjYxsBJxBgSsbgvTou;
					CuNDDehGzQfjYxsBJxBgSsbgvTou = KfITNudXuMgsCOxuqtuCXrzLtgoc;
					hEqLGuCNacIuWVbiYRUYtgpAOfFq = OOBfxoigHSYFGcrOKdUxDcCtEGPkA;
					OOBfxoigHSYFGcrOKdUxDcCtEGPkA = MiscTools.Tick(OOBfxoigHSYFGcrOKdUxDcCtEGPkA);
					fYDATdUVnqbmIEPfbDLFiqRIuYlKb = klqMqIPLnKusHEMLufvoAgBBejWDA;
					klqMqIPLnKusHEMLufvoAgBBejWDA = oHjiGudGsfgLiqYBOSnQTMqFBJMKA();
					previousFrame = hEqLGuCNacIuWVbiYRUYtgpAOfFq;
					currentFrame = OOBfxoigHSYFGcrOKdUxDcCtEGPkA;
					unscaledTime = KfITNudXuMgsCOxuqtuCXrzLtgoc;
					unscaledTimePrev = IFOtkHmpsIKbieItuzopzTTWgZpq;
					unscaledDeltaTime = HWiHjQfERhfzkbWGfXDAAITmSUTfA;
				}
			}

			private static class zkxBxxxYqCNXAKDjjDGQhgrLrbwd
			{
				public static StopwatchBase lPheaVdmIMeSksyecRVJjWfmFfxuA
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

				public static StopwatchBase qWOEnEWxisFMmasnRzsMttDlOiuZA()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase lNjbUWPhsggeLipnfhlepNcfEUYVA()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase FyxmcpIACCBeLDfAzJGjeakVLZzM;

			private double lfZydeMjILEAVMufzDGbFIDQWHgS;

			private IAupmyufSIArMQUfxfCGiisMvmLz ZAqkHINloBZjmQekYvRAGKoNcRnkA;

			private ADictionary<int, IAupmyufSIArMQUfxfCGiisMvmLz> ejlLaMhGnCMtZvrxIHtCrgZraFYX;

			private uint AVmeNMPauhaYnXWfRjAjMKCmDDrD;

			public double RcgfSvulvaiXbpchCzRelLjBIRQB => ZAqkHINloBZjmQekYvRAGKoNcRnkA.YpDShwBwoWPtXuNgRKndrFJedGxDA;

			public double DfENYmQNiNGbibiYzWdAIkEPdLMM => ZAqkHINloBZjmQekYvRAGKoNcRnkA.GRfBfABXuXFwVYURIXFUcfYFrPEm;

			public double KvrWbaavfIBEsRjyEghKomxKmIwA => ZAqkHINloBZjmQekYvRAGKoNcRnkA.lSejeRiUxyNAoVeFgDAjhUwlpQiY;

			public float BkWyhdcHALlXwlIDufqWYSPmsPaH => ZAqkHINloBZjmQekYvRAGKoNcRnkA.mCYxJYocJSuqOiTPDTdbvExYgdpC;

			public float SRigudwJJjAaMnriIMJczVWUsbVl => ZAqkHINloBZjmQekYvRAGKoNcRnkA.MxBQIKPBHjsDroJuquKKDgzbFrru;

			internal double VVJuIpBfakZzuLOBudNPbwpHgiDp => FyxmcpIACCBeLDfAzJGjeakVLZzM.elapsedSeconds + lfZydeMjILEAVMufzDGbFIDQWHgS;

			public uint GQtePfuxlwasYETXQAVeuzbQJvAc => ZAqkHINloBZjmQekYvRAGKoNcRnkA.KVOzveDMtLpWCCzOOiPIuxbqDBWN;

			public uint GxUmKpdKVuMdrhrYoDLHklqXFGQJA => ZAqkHINloBZjmQekYvRAGKoNcRnkA.kKBSUTjqYhadMTAreDstJOHPnVkdA;

			public uint whPdgJlATdYgrVIqmgkTCzLAuoLF => AVmeNMPauhaYnXWfRjAjMKCmDDrD;

			public JAlMUtzQpJYerJOtbgjcATeZqPJi()
			{
				FyxmcpIACCBeLDfAzJGjeakVLZzM = zkxBxxxYqCNXAKDjjDGQhgrLrbwd.lPheaVdmIMeSksyecRVJjWfmFfxuA;
				xwuggdUuczJDvORMGYBUKbJDeJwd();
			}

			public void mdqOUstZJtMLdFwxlMMePivKFzuL()
			{
				lfZydeMjILEAVMufzDGbFIDQWHgS = Time.realtimeSinceStartup;
			}

			public void xwuggdUuczJDvORMGYBUKbJDeJwd()
			{
				ZAqkHINloBZjmQekYvRAGKoNcRnkA = null;
				ejlLaMhGnCMtZvrxIHtCrgZraFYX = new ADictionary<int, IAupmyufSIArMQUfxfCGiisMvmLz>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)(-1), list);
				for (int i = 0; i < list.Count; i++)
				{
					IAupmyufSIArMQUfxfCGiisMvmLz aupmyufSIArMQUfxfCGiisMvmLz = new IAupmyufSIArMQUfxfCGiisMvmLz(list[i]);
					ejlLaMhGnCMtZvrxIHtCrgZraFYX.Add((int)list[i], aupmyufSIArMQUfxfCGiisMvmLz);
					if (ZAqkHINloBZjmQekYvRAGKoNcRnkA == null)
					{
						ZAqkHINloBZjmQekYvRAGKoNcRnkA = aupmyufSIArMQUfxfCGiisMvmLz;
					}
				}
			}

			public void rsVvDcOCktfyepXMYqNSmKsIVJBv(UpdateLoopType P_0)
			{
				if (ZAqkHINloBZjmQekYvRAGKoNcRnkA.NoDRkXvunEETfzMndGknKOQrfrKNA != P_0)
				{
					ZAqkHINloBZjmQekYvRAGKoNcRnkA = ejlLaMhGnCMtZvrxIHtCrgZraFYX[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					ZAqkHINloBZjmQekYvRAGKoNcRnkA.maSnDEnpxmGPPmVCQfHLMrdyacEKA();
					AVmeNMPauhaYnXWfRjAjMKCmDDrD = MiscTools.Tick(AVmeNMPauhaYnXWfRjAjMKCmDDrD);
					absFrame = AVmeNMPauhaYnXWfRjAjMKCmDDrD;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch fLseSBfGjarvWObSaJmgMExeoRjVA;

			internal static UnityTouch JSJMiCWKttqCJfTrhnBdjAImYBZC => fLseSBfGjarvWObSaJmgMExeoRjVA ?? (fLseSBfGjarvWObSaJmgMExeoRjVA = new UnityTouch());

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

		internal class wzqlJWmZRXwihObKYBTIhfcYIijyA
		{
			[Serializable]
			private sealed class dlcBMSOjOwbKajVsnnBxVPFpFqHlA
			{
				public static readonly dlcBMSOjOwbKajVsnnBxVPFpFqHlA _003C_003E9 = new dlcBMSOjOwbKajVsnnBxVPFpFqHlA();

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool bntNVmQgtMxJZMYLRMyiqHfSSQLr()
				{
					return Screen.fullScreen;
				}

				internal bool EvKwrxjqIQxboHzNOSLjUCrOeeHC()
				{
					return Application.runInBackground;
				}

				internal int xQIGLUWRHziSfbPrsdTdWxDXxkRFA()
				{
					return (int)Screen.fullScreenMode;
				}

				internal float bSlYkFCxXGGXOkwJGxIZDAlnFcGr()
				{
					return Time.unscaledDeltaTime;
				}

				internal bool eRuuFWdQaLPMdRdlGFUjKfcsecUr()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				internal string ZJefNijjfmkFZDghQcAteBljYtKN()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}
			}

			public readonly ValueWatcher<bool> vlPTCknbcCzSzdDAVutciJBcTxIQ;

			public readonly ValueWatcher<bool> vLhyOcyzdNfZlbRSyhkdUKgFjyUhA;

			public readonly ValueWatcher<bool> VtbSEUGGvtXaHAeDBkEyuzzaMkDJ;

			public readonly ValueWatcher<bool> jliWDgngdBxpxImpLolMfIMfwySo;

			public readonly ValueWatcher<int> vimwvIzBTvECBIJCgigkbeKAonNJ;

			public readonly ValueWatcher<float> CRXASrSjVvfNCBgeLRAMCcMedooX;

			public readonly ValueWatcher<string> WUPUaYSPtfpRXEqdyCKWJXyiKLD;

			public readonly ValueWatcher<bool> NEfFxOeqijFyxzgFCNLRQGmqfdvsA;

			private int autajRTZLnWUrfIIKwzaGJVsRzxe;

			private readonly ValueWatcher[] HEqefZibFNkCmOvtNHhYHgwiJlfgB;

			public int RPgQCNpZrgJMxSsgvuNEdszUPAIG => autajRTZLnWUrfIIKwzaGJVsRzxe;

			public wzqlJWmZRXwihObKYBTIhfcYIijyA()
			{
				bool flag = UnityTools.isEditor || Application.isFocused;
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(vlPTCknbcCzSzdDAVutciJBcTxIQ = new ValueWatcher<bool>(flag, false)),
					(vLhyOcyzdNfZlbRSyhkdUKgFjyUhA = new ValueWatcher<bool>(false, false)),
					(VtbSEUGGvtXaHAeDBkEyuzzaMkDJ = new ValueWatcher<bool>(Screen.fullScreen, dlcBMSOjOwbKajVsnnBxVPFpFqHlA._003C_003E9.bntNVmQgtMxJZMYLRMyiqHfSSQLr, false)),
					(jliWDgngdBxpxImpLolMfIMfwySo = new ValueWatcher<bool>(Application.runInBackground, dlcBMSOjOwbKajVsnnBxVPFpFqHlA._003C_003E9.EvKwrxjqIQxboHzNOSLjUCrOeeHC, false)),
					(vimwvIzBTvECBIJCgigkbeKAonNJ = new ValueWatcher<int>((int)Screen.fullScreenMode, dlcBMSOjOwbKajVsnnBxVPFpFqHlA._003C_003E9.xQIGLUWRHziSfbPrsdTdWxDXxkRFA, false)),
					(CRXASrSjVvfNCBgeLRAMCcMedooX = new ValueWatcher<float>(Time.unscaledDeltaTime, dlcBMSOjOwbKajVsnnBxVPFpFqHlA._003C_003E9.bSlYkFCxXGGXOkwJGxIZDAlnFcGr, false)),
					(NEfFxOeqijFyxzgFCNLRQGmqfdvsA = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), dlcBMSOjOwbKajVsnnBxVPFpFqHlA._003C_003E9.eRuuFWdQaLPMdRdlGFUjKfcsecUr, MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(WUPUaYSPtfpRXEqdyCKWJXyiKLD = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), dlcBMSOjOwbKajVsnnBxVPFpFqHlA._003C_003E9.ZJefNijjfmkFZDghQcAteBljYtKN, false));
				}
				HEqefZibFNkCmOvtNHhYHgwiJlfgB = list.ToArray();
				pVdCdUcEILmAAgRVXZtCGwMFdYxYA();
			}

			public void pVdCdUcEILmAAgRVXZtCGwMFdYxYA()
			{
				for (int i = 0; i < HEqefZibFNkCmOvtNHhYHgwiJlfgB.Length; i++)
				{
					HEqefZibFNkCmOvtNHhYHgwiJlfgB[i].Update();
				}
				autajRTZLnWUrfIIKwzaGJVsRzxe = Time.frameCount;
			}

			public void SomDxgdluhLTsSdppMLowRcwcpjT()
			{
				for (int i = 0; i < HEqefZibFNkCmOvtNHhYHgwiJlfgB.Length; i++)
				{
					HEqefZibFNkCmOvtNHhYHgwiJlfgB[i].TriggerEvent();
				}
			}
		}

		[Serializable]
		private sealed class EykdQQDpmfinjEGyXYWmfVSVGcpVA
		{
			public static readonly EykdQQDpmfinjEGyXYWmfVSVGcpVA _003C_003E9 = new EykdQQDpmfinjEGyXYWmfVSVGcpVA();

			public static Func<bool> _003C_003E9__235_0;

			internal void sAkvftkvApArNevWfPPgxkmksXWT(Exception P_0)
			{
				HandleCallbackException("", P_0);
			}

			internal void soNspfnFtcCIOFcFlLosiqRfKmmIb(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			}

			internal void PPteOtELIkJLEUYTFYhudAJinnwbb(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			}

			internal void rIPDycNmlafyGHsFOnnlBjJRpZvN(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			}

			internal void OHpMNyXhLKBJYkjjgHWBZvSldlUCA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			}

			internal void qQZPdbLPxTpbwEEqHiXSZktvECci(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			}

			internal void HpqTPxiFCFDfIxPspeKZoFkngCYbA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			}

			internal void LRjytnKuKgWUmquAqNVWFcfFDRtt(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			}

			internal void hWZJzFwtuItZBYoRsoEihGpfkimD(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			}

			internal bool wirGpjDuwoirOjvvIrXAPIilHpghb()
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
		internal const string majorBranch = "U6000";

		private static InputManager_Base kiHfpMdgIcZKOFqEcATiPzLkjinwA;

		private static PlatformInputManager nmQIPpFiDbQPOhxkdBLxhfsyzmvc;

		internal static HGmrzRPfohKeKWRglmOSyhGDDlzFA ilKdcvAddvhstqcjWcabGGsfjMRZB;

		internal static FbTdHcsBNUVZtBghOGVsEuhLuePk VeAmGFtEIHUuquEZXjxbJYdKKrEb;

		internal static hSQdAZAaMRJsyVvNAYTUQfKIxyBHA ABDTVoIIjFlEZLKHRhISrlbClCcb;

		private static ControllerDataFiles TnVTULtaLeGRpomSLLfeqTMBPAhg;

		private static UserData afadmdopkFDkKcMXUOVulpLPkXjgA;

		private static bool aBiyGFUEVLLrGykdoFrmCmqzGZiAA;

		private static ConfigVars WrbzILXVJRROTTBDFNtXcVCaHZTt;

		private static UpdateLoopType nGjOLNKmeRaAJGUTohqprdHGHxtmA;

		private static bool IveJgwrIDzyjDxaVLdWEMEsffdNIA;

		private static Platform URkgCdLotifeaGAAFDdtQevGyBvUA;

		private static WebplayerPlatform pHQluveHGIPRNrYPNUnGzJgNcXKz;

		private static EditorPlatform HadeSpEntnEJrKOPzYqWGEMxGNsX;

		private static bool LqTzvNJKHIUrRZNIuFGUSsvkblRk;

		private static TimerAbs mgGvfCOVhlRDcSdqnUQMDHhATWTq;

		private static JAlMUtzQpJYerJOtbgjcATeZqPJi vVhenyNmyJKFhFovDsjqXGPMgWcs;

		private static string OdcSmJWEcVJVhXmPqSiEyFqhaabw;

		private static bool KEJePpNkhFzDFdjIhCtzBCIKkdRhA;

		private static bool dgFYWkbbPpbpMfBawoGqhodSxNmSA;

		private static bool jCsJTMmvosObkpTJsHBuvVrEHwQT;

		private static int mwUrbgSwhTcgoKsjpEOOpiLMKZqi;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int MwYNWnAAVXbATiXjzjRVxqrpVnvO;

		private static int ngZaEKjPEpXvagNUkmTYyuCApHrZA;

		private static bool ihKiPxCntGtvbcSzMdonfbfCJqMSA;

		private static readonly UnityTouch KIQYPVUqRIgzByKGgiZqpPtOwWWI;

		private static readonly PlayerHelper TipnaNHgDteKxPULwtbrxJHkcAKFA;

		private static readonly ControllerHelper kUEzEnRVRAzPRRGLMbXOamIbNcmW;

		private static readonly MappingHelper JyiLasftomkKBtyLAGQiDgYwnqHK;

		private static readonly TimeHelper DxRGyLgtppJyfVwdLGfEVdpTVtShA;

		private static readonly ConfigHelper LLPUUvWJRSFVFCwqWEQqmogUArnxA;

		private static readonly LocalizationHelper bUGCXHAFUbYQmBawLySaTbTRCpbHb;

		private static readonly GlyphHelper ctCAySmxqDjzztVTvdBjkXWntthW;

		private static mvwlWjoNBZLoHgkpzwSLYSqKfyEM oWfPXRBghQsiNObUkejWdlzBMAOWA;

		private static UserDataStore YCXvlvnZJrwUSfhfilHPfCWNZYDR;

		private static IControllerAssigner JfpTCKlgtlYDaWrqLdTbwSfEAiuh;

		private static wzqlJWmZRXwihObKYBTIhfcYIijyA QMBRjSqLBmKHeMhElRbCuJgyAYCp;

		private static SafeAction<ControllerStatusChangedEventArgs> CbhfTfIvgxHrFfCgauvQNeCQFTTpA;

		private static SafeAction<ControllerStatusChangedEventArgs> rIXERBHRlwQxTZubEctIBXJwEiNkA;

		private static SafeAction<ControllerStatusChangedEventArgs> ILPLmkHCyEdUkDSTmzLQNoTFnpaeb;

		private static SafeAction BkRnrdFOMyXdkJQfQMMYZUwdGOir;

		private static SafeAction lqrFiUGxLywbbihuRXDyRtAcMClZ;

		private static SafeAction xSTIClDCBkDqBvGCnnMiwpwYTdYe;

		private static SafeAction bWZmQGHahLJacOZhHVWhwbVCAboQ;

		private static SafeAction nVlqmPQKgqTjcSoqNfFDjrzXOHqeb;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action dUkTXYzCCtZnpMrlRJUjAMloINCkA;

		private static Action<UpdateLoopType> zozSqtjmfCQlfcARqpQUHOwsUPPs;

		private static Action<UpdateLoopType> JLcAgVnCyocprGTSDcNWBDmHziwZA;

		private static Action<UpdateLoopType> kBnNVMhKnWFGbIGwyNsxmONuULFk;

		private static Action JrXbOJBISFYdqsjoLkYPtOHZvnuHA;

		private static Action<bool> BudaQABKZRxOoHsqMEeHQnQWYtPL;

		private static Action<bool> gqUDPgDOyLzRSMEeYIBXcQqirchEb;

		private static Action<bool> EPqbzLdZLJqejrfcUneXAbxKEpJYA;

		private static Action<FullScreenMode> AeCWlIWqExHRBMpkevmmaJvSgMZF;

		private static Action RIKyONyoJhciufoHhRpGvHltbkWDA;

		private static Action<bool> pviZCLrinBhUemYCQcTryCWCKXDH;

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

		private static mvwlWjoNBZLoHgkpzwSLYSqKfyEM ZvBYsooYKxEonRkVIeotklAxDjEY => oWfPXRBghQsiNObUkejWdlzBMAOWA ?? (oWfPXRBghQsiNObUkejWdlzBMAOWA = new mvwlWjoNBZLoHgkpzwSLYSqKfyEM(WrbzILXVJRROTTBDFNtXcVCaHZTt.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return TipnaNHgDteKxPULwtbrxJHkcAKFA;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return kUEzEnRVRAzPRRGLMbXOamIbNcmW;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return JyiLasftomkKBtyLAGQiDgYwnqHK;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return KIQYPVUqRIgzByKGgiZqpPtOwWWI;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return DxRGyLgtppJyfVwdLGfEVdpTVtShA;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return YCXvlvnZJrwUSfhfilHPfCWNZYDR;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return LLPUUvWJRSFVFCwqWEQqmogUArnxA;
			}
		}

		public static LocalizationHelper localization
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return bUGCXHAFUbYQmBawLySaTbTRCpbHb;
			}
		}

		public static GlyphHelper glyphs
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return ctCAySmxqDjzztVTvdBjkXWntthW;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 58 + "." + 4 + ".U6000";

		public static bool usingUnityInput => IveJgwrIDzyjDxaVLdWEMEsffdNIA;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
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

		public static bool isReady => aBiyGFUEVLLrGykdoFrmCmqzGZiAA;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => aBiyGFUEVLLrGykdoFrmCmqzGZiAA;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => nGjOLNKmeRaAJGUTohqprdHGHxtmA;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => WrbzILXVJRROTTBDFNtXcVCaHZTt;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => WrbzILXVJRROTTBDFNtXcVCaHZTt;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => afadmdopkFDkKcMXUOVulpLPkXjgA;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => URkgCdLotifeaGAAFDdtQevGyBvUA;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => pHQluveHGIPRNrYPNUnGzJgNcXKz;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => HadeSpEntnEJrKOPzYqWGEMxGNsX;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.Linux && IveJgwrIDzyjDxaVLdWEMEsffdNIA)
				{
					return true;
				}
				if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.OSX && (IveJgwrIDzyjDxaVLdWEMEsffdNIA || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && IveJgwrIDzyjDxaVLdWEMEsffdNIA)
				{
					return true;
				}
				if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.Webplayer && pHQluveHGIPRNrYPNUnGzJgNcXKz == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => HadeSpEntnEJrKOPzYqWGEMxGNsX != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return Guid.Empty;
				}
				return TnVTULtaLeGRpomSLLfeqTMBPAhg.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => dgFYWkbbPpbpMfBawoGqhodSxNmSA;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => vVhenyNmyJKFhFovDsjqXGPMgWcs.BkWyhdcHALlXwlIDufqWYSPmsPaH;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => vVhenyNmyJKFhFovDsjqXGPMgWcs.SRigudwJJjAaMnriIMJczVWUsbVl;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return 0.0;
				}
				return vVhenyNmyJKFhFovDsjqXGPMgWcs.VVJuIpBfakZzuLOBudNPbwpHgiDp;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return 0;
				}
				return QMBRjSqLBmKHeMhElRbCuJgyAYCp.RPgQCNpZrgJMxSsgvuNEdszUPAIG;
			}
		}

		private static bool AgyzbTnrqZGRFDLPqCcvhUqHYUnO
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return OdcSmJWEcVJVhXmPqSiEyFqhaabw == "Game";
				}
				return OdcSmJWEcVJVhXmPqSiEyFqhaabw == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (WrbzILXVJRROTTBDFNtXcVCaHZTt.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!jCsJTMmvosObkpTJsHBuvVrEHwQT)
				{
					return AgyzbTnrqZGRFDLPqCcvhUqHYUnO;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (nmQIPpFiDbQPOhxkdBLxhfsyzmvc is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return jCsJTMmvosObkpTJsHBuvVrEHwQT;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return false;
				}
				if (!IveJgwrIDzyjDxaVLdWEMEsffdNIA)
				{
					return false;
				}
				if (URkgCdLotifeaGAAFDdtQevGyBvUA != Platform.Windows && (URkgCdLotifeaGAAFDdtQevGyBvUA != Platform.Webplayer || pHQluveHGIPRNrYPNUnGzJgNcXKz != WebplayerPlatform.Windows))
				{
					return HadeSpEntnEJrKOPzYqWGEMxGNsX == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool mhgRkafpsoAhbgjNAFaeSLmvyqMN
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return false;
				}
				if (!QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.value)
				{
					if (ihKiPxCntGtvbcSzMdonfbfCJqMSA)
					{
						return false;
					}
					if ((!isEditor || !isUnityEditorFocused) && !QMBRjSqLBmKHeMhElRbCuJgyAYCp.jliWDgngdBxpxImpLolMfIMfwySo.value)
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
				if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsPaused
		{
			get
			{
				if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return QMBRjSqLBmKHeMhElRbCuJgyAYCp.vLhyOcyzdNfZlbRSyhkdUKgFjyUhA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return QMBRjSqLBmKHeMhElRbCuJgyAYCp.VtbSEUGGvtXaHAeDBkEyuzzaMkDJ.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return QMBRjSqLBmKHeMhElRbCuJgyAYCp.jliWDgngdBxpxImpLolMfIMfwySo.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					return QMBRjSqLBmKHeMhElRbCuJgyAYCp.NEfFxOeqijFyxzgFCNLRQGmqfdvsA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => kiHfpMdgIcZKOFqEcATiPzLkjinwA;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
				{
					iNSDwPbaFSjYzsdrzUXJpeGflUhU();
					return null;
				}
				return nmQIPpFiDbQPOhxkdBLxhfsyzmvc.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return JfpTCKlgtlYDaWrqLdTbwSfEAiuh;
			}
			set
			{
				JfpTCKlgtlYDaWrqLdTbwSfEAiuh = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => ngZaEKjPEpXvagNUkmTYyuCApHrZA;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				CbhfTfIvgxHrFfCgauvQNeCQFTTpA += value;
			}
			remove
			{
				CbhfTfIvgxHrFfCgauvQNeCQFTTpA -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				rIXERBHRlwQxTZubEctIBXJwEiNkA += value;
			}
			remove
			{
				rIXERBHRlwQxTZubEctIBXJwEiNkA -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				ILPLmkHCyEdUkDSTmzLQNoTFnpaeb += value;
			}
			remove
			{
				ILPLmkHCyEdUkDSTmzLQNoTFnpaeb -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				BkRnrdFOMyXdkJQfQMMYZUwdGOir += value;
			}
			remove
			{
				BkRnrdFOMyXdkJQfQMMYZUwdGOir -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				lqrFiUGxLywbbihuRXDyRtAcMClZ += value;
			}
			remove
			{
				lqrFiUGxLywbbihuRXDyRtAcMClZ -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				xSTIClDCBkDqBvGCnnMiwpwYTdYe += value;
			}
			remove
			{
				xSTIClDCBkDqBvGCnnMiwpwYTdYe -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				bWZmQGHahLJacOZhHVWhwbVCAboQ += value;
			}
			remove
			{
				bWZmQGHahLJacOZhHVWhwbVCAboQ -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				nVlqmPQKgqTjcSoqNfFDjrzXOHqeb += value;
			}
			remove
			{
				nVlqmPQKgqTjcSoqNfFDjrzXOHqeb -= value;
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
				dUkTXYzCCtZnpMrlRJUjAMloINCkA = (Action)Delegate.Combine(dUkTXYzCCtZnpMrlRJUjAMloINCkA, value);
			}
			remove
			{
				dUkTXYzCCtZnpMrlRJUjAMloINCkA = (Action)Delegate.Remove(dUkTXYzCCtZnpMrlRJUjAMloINCkA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				zozSqtjmfCQlfcARqpQUHOwsUPPs = (Action<UpdateLoopType>)Delegate.Combine(zozSqtjmfCQlfcARqpQUHOwsUPPs, value);
			}
			remove
			{
				zozSqtjmfCQlfcARqpQUHOwsUPPs = (Action<UpdateLoopType>)Delegate.Remove(zozSqtjmfCQlfcARqpQUHOwsUPPs, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				JLcAgVnCyocprGTSDcNWBDmHziwZA = (Action<UpdateLoopType>)Delegate.Combine(JLcAgVnCyocprGTSDcNWBDmHziwZA, value);
			}
			remove
			{
				JLcAgVnCyocprGTSDcNWBDmHziwZA = (Action<UpdateLoopType>)Delegate.Remove(JLcAgVnCyocprGTSDcNWBDmHziwZA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				kBnNVMhKnWFGbIGwyNsxmONuULFk = (Action<UpdateLoopType>)Delegate.Combine(kBnNVMhKnWFGbIGwyNsxmONuULFk, value);
			}
			remove
			{
				kBnNVMhKnWFGbIGwyNsxmONuULFk = (Action<UpdateLoopType>)Delegate.Remove(kBnNVMhKnWFGbIGwyNsxmONuULFk, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				JrXbOJBISFYdqsjoLkYPtOHZvnuHA = (Action)Delegate.Combine(JrXbOJBISFYdqsjoLkYPtOHZvnuHA, value);
			}
			remove
			{
				JrXbOJBISFYdqsjoLkYPtOHZvnuHA = (Action)Delegate.Remove(JrXbOJBISFYdqsjoLkYPtOHZvnuHA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				BudaQABKZRxOoHsqMEeHQnQWYtPL = (Action<bool>)Delegate.Combine(BudaQABKZRxOoHsqMEeHQnQWYtPL, value);
			}
			remove
			{
				BudaQABKZRxOoHsqMEeHQnQWYtPL = (Action<bool>)Delegate.Remove(BudaQABKZRxOoHsqMEeHQnQWYtPL, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				gqUDPgDOyLzRSMEeYIBXcQqirchEb = (Action<bool>)Delegate.Combine(gqUDPgDOyLzRSMEeYIBXcQqirchEb, value);
			}
			remove
			{
				gqUDPgDOyLzRSMEeYIBXcQqirchEb = (Action<bool>)Delegate.Remove(gqUDPgDOyLzRSMEeYIBXcQqirchEb, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				EPqbzLdZLJqejrfcUneXAbxKEpJYA = (Action<bool>)Delegate.Combine(EPqbzLdZLJqejrfcUneXAbxKEpJYA, value);
			}
			remove
			{
				EPqbzLdZLJqejrfcUneXAbxKEpJYA = (Action<bool>)Delegate.Remove(EPqbzLdZLJqejrfcUneXAbxKEpJYA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				AeCWlIWqExHRBMpkevmmaJvSgMZF = (Action<FullScreenMode>)Delegate.Combine(AeCWlIWqExHRBMpkevmmaJvSgMZF, value);
			}
			remove
			{
				AeCWlIWqExHRBMpkevmmaJvSgMZF = (Action<FullScreenMode>)Delegate.Remove(AeCWlIWqExHRBMpkevmmaJvSgMZF, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				RIKyONyoJhciufoHhRpGvHltbkWDA = (Action)Delegate.Combine(RIKyONyoJhciufoHhRpGvHltbkWDA, value);
			}
			remove
			{
				RIKyONyoJhciufoHhRpGvHltbkWDA = (Action)Delegate.Remove(RIKyONyoJhciufoHhRpGvHltbkWDA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				pviZCLrinBhUemYCQcTryCWCKXDH = (Action<bool>)Delegate.Combine(pviZCLrinBhUemYCQcTryCWCKXDH, value);
			}
			remove
			{
				pviZCLrinBhUemYCQcTryCWCKXDH = (Action<bool>)Delegate.Remove(pviZCLrinBhUemYCQcTryCWCKXDH, value);
			}
		}

		static ReInput()
		{
			jCsJTMmvosObkpTJsHBuvVrEHwQT = true;
			mwUrbgSwhTcgoKsjpEOOpiLMKZqi = -1;
			_id = -1;
			MwYNWnAAVXbATiXjzjRVxqrpVnvO = 0;
			KIQYPVUqRIgzByKGgiZqpPtOwWWI = UnityTouch.JSJMiCWKttqCJfTrhnBdjAImYBZC;
			TipnaNHgDteKxPULwtbrxJHkcAKFA = PlayerHelper.vIdDSoPEnUcZigmuWmEdUAMzoIgm;
			kUEzEnRVRAzPRRGLMbXOamIbNcmW = ControllerHelper.RlZpbqBuFSKPMnqftskGduWLlDKw;
			JyiLasftomkKBtyLAGQiDgYwnqHK = MappingHelper.KQvVmSouHQjuvrMsIFmnrIdGFCmGA;
			DxRGyLgtppJyfVwdLGfEVdpTVtShA = TimeHelper.mnWhxwgDipzbIjikLGuFPCipgfP;
			LLPUUvWJRSFVFCwqWEQqmogUArnxA = ConfigHelper.ntQyYYYAVXWXqxiCmimfWyvYQNOn;
			bUGCXHAFUbYQmBawLySaTbTRCpbHb = LocalizationHelper.hPVGmFrmxwEQzAQCEwHaDMIZfLxi;
			ctCAySmxqDjzztVTvdBjkXWntthW = GlyphHelper.xFPduNCwrrVWYmjqjAjJEKDVXNysA;
			CbhfTfIvgxHrFfCgauvQNeCQFTTpA = new SafeAction<ControllerStatusChangedEventArgs>(EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.soNspfnFtcCIOFcFlLosiqRfKmmIb);
			rIXERBHRlwQxTZubEctIBXJwEiNkA = new SafeAction<ControllerStatusChangedEventArgs>(EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.PPteOtELIkJLEUYTFYhudAJinnwbb);
			ILPLmkHCyEdUkDSTmzLQNoTFnpaeb = new SafeAction<ControllerStatusChangedEventArgs>(EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.rIPDycNmlafyGHsFOnnlBjJRpZvN);
			BkRnrdFOMyXdkJQfQMMYZUwdGOir = new SafeAction(EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.OHpMNyXhLKBJYkjjgHWBZvSldlUCA);
			lqrFiUGxLywbbihuRXDyRtAcMClZ = new SafeAction(EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.qQZPdbLPxTpbwEEqHiXSZktvECci);
			xSTIClDCBkDqBvGCnnMiwpwYTdYe = new SafeAction(EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.HpqTPxiFCFDfIxPspeKZoFkngCYbA);
			bWZmQGHahLJacOZhHVWhwbVCAboQ = new SafeAction(EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.LRjytnKuKgWUmquAqNVWFcfFDRtt);
			nVlqmPQKgqTjcSoqNfFDjrzXOHqeb = new SafeAction(EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.hWZJzFwtuItZBYoRsoEihGpfkimD);
			SafeDelegate.S_ExceptionHandler = EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.sAkvftkvApArNevWfPPgxkmksXWT;
		}

		public static void Update()
		{
			if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
			{
				if (WrbzILXVJRROTTBDFNtXcVCaHZTt.updateMode != UpdateMode.Manual)
				{
					Logger.LogError("Rewired cannot be updated manually unless Update Mode is set to Manual.");
				}
				else
				{
					kiHfpMdgIcZKOFqEcATiPzLkjinwA.DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
				}
			}
		}

		public static void Reset()
		{
			if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA && !(kiHfpMdgIcZKOFqEcATiPzLkjinwA == null))
			{
				kiHfpMdgIcZKOFqEcATiPzLkjinwA.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!mhgRkafpsoAhbgjNAFaeSLmvyqMN)
			{
				return false;
			}
			if (HadeSpEntnEJrKOPzYqWGEMxGNsX != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (ihKiPxCntGtvbcSzMdonfbfCJqMSA)
				{
					if (!QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.value)
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

		private static void DwnKojYPQfKqWOqUcQKgwhNSLPRq()
		{
			URkgCdLotifeaGAAFDdtQevGyBvUA = UnityTools.platform;
			pHQluveHGIPRNrYPNUnGzJgNcXKz = UnityTools.webplayerPlatform;
			HadeSpEntnEJrKOPzYqWGEMxGNsX = UnityTools.editorPlatform;
		}

		internal static void TpzbFjxRzvBxrjNiklbFUFukIxgM(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.AvCdBwJqgMgreVrAsELpddWPgcmn> P_5, Action<Platform> P_6, Action<InputManager_Base.gAovxugbbzdKCKlVLTYrDvJFjNlo> P_7)
		{
			try
			{
				_id = MwYNWnAAVXbATiXjzjRVxqrpVnvO;
				MwYNWnAAVXbATiXjzjRVxqrpVnvO++;
				aBiyGFUEVLLrGykdoFrmCmqzGZiAA = true;
				KEJePpNkhFzDFdjIhCtzBCIKkdRhA = true;
				dgFYWkbbPpbpMfBawoGqhodSxNmSA = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				kiHfpMdgIcZKOFqEcATiPzLkjinwA = P_0;
				WrbzILXVJRROTTBDFNtXcVCaHZTt = P_2;
				DwnKojYPQfKqWOqUcQKgwhNSLPRq();
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += LoSALsAIetibWEYFQcVmPZXYTXAV;
				TnVTULtaLeGRpomSLLfeqTMBPAhg = P_3;
				afadmdopkFDkKcMXUOVulpLPkXjgA = P_4;
				mgGvfCOVhlRDcSdqnUQMDHhATWTq = new TimerAbs(1.0);
				vVhenyNmyJKFhFovDsjqXGPMgWcs = new JAlMUtzQpJYerJOtbgjcATeZqPJi();
				LocalizationManager.Initialize();
				GlyphManager.Initialize();
				P_4.yBqzMWUbfqGaCAVGykOEdZvydxhWA();
				ThreadSafeUnityInput.Initialize();
				QMBRjSqLBmKHeMhElRbCuJgyAYCp = new wzqlJWmZRXwihObKYBTIhfcYIijyA();
				if (!UnityTools.isEditor)
				{
					jCsJTMmvosObkpTJsHBuvVrEHwQT = Application.isFocused;
				}
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.Set(jCsJTMmvosObkpTJsHBuvVrEHwQT);
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.Use();
				if (HadeSpEntnEJrKOPzYqWGEMxGNsX != EditorPlatform.None)
				{
					QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.getValueDelegate = EykdQQDpmfinjEGyXYWmfVSVGcpVA._003C_003E9.wirGpjDuwoirOjvvIrXAPIilHpghb;
					if (dgFYWkbbPpbpMfBawoGqhodSxNmSA)
					{
						jCsJTMmvosObkpTJsHBuvVrEHwQT = AgyzbTnrqZGRFDLPqCcvhUqHYUnO;
					}
					QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				HRsblagzcxMnYZLFjZxZjNYJvupb();
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
							pEDFtRXsVNNJtQauegEJObAFaioB.eXXFjFsopcMTgpXMWkContYkxnYH(customPlatformInitOptions);
							bool num = HadeSpEntnEJrKOPzYqWGEMxGNsX != EditorPlatform.None;
							P_7(new InputManager_Base.gAovxugbbzdKCKlVLTYrDvJFjNlo
							{
								eJueoggTXeOJlUYUIeuniGZSJExt = Platform.Custom,
								dVlHgdgewjfUuPryduWmfpYwBuUE = EditorPlatform.None,
								paJVEGkpcLbfvVVreDBYuTRzaCtN = WebplayerPlatform.None
							});
							DwnKojYPQfKqWOqUcQKgwhNSLPRq();
							vVhenyNmyJKFhFovDsjqXGPMgWcs = new JAlMUtzQpJYerJOtbgjcATeZqPJi();
							if (num)
							{
								Logger.LogWarning("A custom platform is in use. All input will be managed by user-defined custom platform handling.");
							}
							break;
						}
					}
				}
				MGeiknnSHVhPMdPDbDgHLJuqzRBn(P_1, P_5(), P_6);
				ilKdcvAddvhstqcjWcabGGsfjMRZB = new HGmrzRPfohKeKWRglmOSyhGDDlzFA(P_4.GetActions_Copy());
				VeAmGFtEIHUuquEZXjxbJYdKKrEb = new FbTdHcsBNUVZtBghOGVsEuhLuePk(P_2, nmQIPpFiDbQPOhxkdBLxhfsyzmvc);
				ABDTVoIIjFlEZLKHRhISrlbClCcb = new hSQdAZAaMRJsyVvNAYTUQfKIxyBHA(P_2);
				nmQIPpFiDbQPOhxkdBLxhfsyzmvc.DeviceConnectedEvent += RCpnDFXBKQTrCCLrmJTJlmQwFUuQ;
				nmQIPpFiDbQPOhxkdBLxhfsyzmvc.DeviceDisconnectedEvent += QNLLiHQGnOFoVkBdZrBhiNMkGTUvA;
				nmQIPpFiDbQPOhxkdBLxhfsyzmvc.UpdateControllerInfoEvent += WgUUmZdNMVcptaZMrqPRHTwnHxSs;
				VeAmGFtEIHUuquEZXjxbJYdKKrEb.lCUuYvUDisNZzzaZIcCQiCWFCxPfb += UPcxTxFfmxCUaAkuaIcDAwknHItF;
				VeAmGFtEIHUuquEZXjxbJYdKKrEb.NMtIsxMWGlrzzHjmHwogmBBcMlwK += ABDTVoIIjFlEZLKHRhISrlbClCcb.DOoFeNcCwaYbSapZvprfEkUZVhwD;
				ThreadSafeUnityInput.PostInitialize();
				YgxdlwhJkuEbWpbFMkjQmNRWaIvm();
				ThreadSafeUnityInput.PostInitialize2();
				YCXvlvnZJrwUSfhfilHPfCWNZYDR = UnityTools.GetComponent<UserDataStore>(kiHfpMdgIcZKOFqEcATiPzLkjinwA);
				if (YCXvlvnZJrwUSfhfilHPfCWNZYDR != null)
				{
					YCXvlvnZJrwUSfhfilHPfCWNZYDR.Initialize();
				}
				WdDqHTYGyurdaEIEsbrpsecnjVteA();
				KEJePpNkhFzDFdjIhCtzBCIKkdRhA = false;
				if (dgFYWkbbPpbpMfBawoGqhodSxNmSA)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (nVlqmPQKgqTjcSoqNfFDjrzXOHqeb != null)
				{
					nVlqmPQKgqTjcSoqNfFDjrzXOHqeb.Invoke();
				}
			}
			catch (Exception)
			{
				aBiyGFUEVLLrGykdoFrmCmqzGZiAA = false;
				KEJePpNkhFzDFdjIhCtzBCIKkdRhA = false;
				throw;
			}
		}

		internal static void FTKOPNPjVzGYtcIaIYyWOsBHawpaA()
		{
			if (vVhenyNmyJKFhFovDsjqXGPMgWcs != null)
			{
				vVhenyNmyJKFhFovDsjqXGPMgWcs.mdqOUstZJtMLdFwxlMMePivKFzuL();
			}
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < VeAmGFtEIHUuquEZXjxbJYdKKrEb.pwyKpsUfOHnkYjLOCiQAqFosrZvs; i++)
				{
					Joystick joystick = VeAmGFtEIHUuquEZXjxbJYdKKrEb.lKwdUsCXdtSuRQQrSNnwQMfcqIRXA[i];
					IFiQDHrbnBpCKAhoThcOUbwQonL(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		internal static void tOgHoLRobXhMmcDcEEODOIlxwilH(UpdateLoopType P_0)
		{
			if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
			{
				PHcYnViNakoJCIGqrvCCWkBRCyEh(P_0);
				if ((uint)P_0 <= 1u)
				{
					khAZkuJpNHRriLFBTHQdazrbuKbp();
				}
			}
		}

		private static void PHcYnViNakoJCIGqrvCCWkBRCyEh(UpdateLoopType P_0)
		{
			if (QMBRjSqLBmKHeMhElRbCuJgyAYCp != null)
			{
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.pVdCdUcEILmAAgRVXZtCGwMFdYxYA();
			}
			Action<UpdateLoopType> action = zozSqtjmfCQlfcARqpQUHOwsUPPs;
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
			vVhenyNmyJKFhFovDsjqXGPMgWcs.rsVvDcOCktfyepXMYqNSmKsIVJBv(P_0);
		}

		private static void khAZkuJpNHRriLFBTHQdazrbuKbp()
		{
			int frameCount = Time.frameCount;
			if (mwUrbgSwhTcgoKsjpEOOpiLMKZqi == frameCount)
			{
				return;
			}
			mwUrbgSwhTcgoKsjpEOOpiLMKZqi = frameCount;
			ThreadSafeUnityInput.Update();
			Action action = dUkTXYzCCtZnpMrlRJUjAMloINCkA;
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

		internal static void tOBaUBzDiNesOQThghoARSYwjdIP(UpdateLoopType P_0)
		{
			if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
			{
				return;
			}
			if (nGjOLNKmeRaAJGUTohqprdHGHxtmA != P_0)
			{
				nGjOLNKmeRaAJGUTohqprdHGHxtmA = P_0;
			}
			if (editorPlatform != EditorPlatform.None)
			{
				OdcSmJWEcVJVhXmPqSiEyFqhaabw = QMBRjSqLBmKHeMhElRbCuJgyAYCp.WUPUaYSPtfpRXEqdyCKWJXyiKLD.value;
			}
			if (LqTzvNJKHIUrRZNIuFGUSsvkblRk)
			{
				if (mgGvfCOVhlRDcSdqnUQMDHhATWTq.Update())
				{
					LqTzvNJKHIUrRZNIuFGUSsvkblRk = false;
					mgGvfCOVhlRDcSdqnUQMDHhATWTq.Clear();
				}
				else
				{
					ZvBYsooYKxEonRkVIeotklAxDjEY.dOsfZGDsBfwnEDBKJpxFXwvLctwo(P_0);
				}
			}
			QMBRjSqLBmKHeMhElRbCuJgyAYCp.SomDxgdluhLTsSdppMLowRcwcpjT();
			Action<UpdateLoopType> jLcAgVnCyocprGTSDcNWBDmHziwZA = JLcAgVnCyocprGTSDcNWBDmHziwZA;
			if (jLcAgVnCyocprGTSDcNWBDmHziwZA != null)
			{
				try
				{
					jLcAgVnCyocprGTSDcNWBDmHziwZA(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.UpdateStartedEvent", exception);
				}
			}
			nmQIPpFiDbQPOhxkdBLxhfsyzmvc.Update(P_0);
			if (BkRnrdFOMyXdkJQfQMMYZUwdGOir != null)
			{
				BkRnrdFOMyXdkJQfQMMYZUwdGOir.Invoke();
			}
			VeAmGFtEIHUuquEZXjxbJYdKKrEb.MlOpAQKRAybotEIhyWbnGpGVwDBr(P_0);
			Action<UpdateLoopType> action = kBnNVMhKnWFGbIGwyNsxmONuULFk;
			if (action == null)
			{
				return;
			}
			try
			{
				action(P_0);
			}
			catch (Exception exception2)
			{
				HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
			}
		}

		internal static void XhUBkfACghuNiQmSGcrcgFSkIQly()
		{
			Action jrXbOJBISFYdqsjoLkYPtOHZvnuHA = JrXbOJBISFYdqsjoLkYPtOHZvnuHA;
			if (jrXbOJBISFYdqsjoLkYPtOHZvnuHA != null)
			{
				try
				{
					jrXbOJBISFYdqsjoLkYPtOHZvnuHA();
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
			if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA && dgFYWkbbPpbpMfBawoGqhodSxNmSA)
			{
				tOgHoLRobXhMmcDcEEODOIlxwilH(UpdateLoopType.Update);
				tOBaUBzDiNesOQThghoARSYwjdIP(UpdateLoopType.Update);
				XhUBkfACghuNiQmSGcrcgFSkIQly();
			}
		}

		internal static void btfHcAgCHOXvXAviVBHVqFUZFozY()
		{
			if (xSTIClDCBkDqBvGCnnMiwpwYTdYe != null)
			{
				xSTIClDCBkDqBvGCnnMiwpwYTdYe.Invoke();
			}
			if (nmQIPpFiDbQPOhxkdBLxhfsyzmvc != null)
			{
				nmQIPpFiDbQPOhxkdBLxhfsyzmvc.OnDestroy();
			}
			XLXIPZDAAeaeripXuyeZjwSWAWZCA();
			if (bWZmQGHahLJacOZhHVWhwbVCAboQ != null)
			{
				bWZmQGHahLJacOZhHVWhwbVCAboQ.Invoke();
				bWZmQGHahLJacOZhHVWhwbVCAboQ = null;
			}
		}

		internal static void NVMVawGpCNIvQhSBwORBFwWWPYER()
		{
			if (lqrFiUGxLywbbihuRXDyRtAcMClZ != null)
			{
				lqrFiUGxLywbbihuRXDyRtAcMClZ.Invoke();
			}
		}

		internal static void sFbDNbNNWsZbRDgBLjfkLwKmsjrT(bool P_0)
		{
			jCsJTMmvosObkpTJsHBuvVrEHwQT = P_0;
			if (HadeSpEntnEJrKOPzYqWGEMxGNsX == EditorPlatform.None && aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
			{
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.Set(P_0);
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.TriggerEvent();
			}
		}

		internal static void KcgCeWGmtpVeZwrqrfZDdNOuwZWn(bool P_0)
		{
			if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
			{
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vLhyOcyzdNfZlbRSyhkdUKgFjyUhA.Set(P_0);
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vLhyOcyzdNfZlbRSyhkdUKgFjyUhA.TriggerEvent();
			}
		}

		internal static void NXIwBldpplggVZjcBcapKmcHkjre()
		{
			if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
			{
				return;
			}
			Action rIKyONyoJhciufoHhRpGvHltbkWDA = RIKyONyoJhciufoHhRpGvHltbkWDA;
			if (rIKyONyoJhciufoHhRpGvHltbkWDA == null)
			{
				return;
			}
			try
			{
				rIKyONyoJhciufoHhRpGvHltbkWDA();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.SceneLoadedEvent", exception);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return TnVTULtaLeGRpomSLLfeqTMBPAhg.zhWfYoeUlKoYGQLdjyueeIDwHVGoA(bridgedController);
		}

		internal static HardwareJoystickMap qkTHQiTDunCNmEArTSopkNQhEEJOA(Guid P_0)
		{
			return TnVTULtaLeGRpomSLLfeqTMBPAhg.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap ybfHyZdOwUYBOlroeLxodrHdUXLSA(Guid P_0)
		{
			return TnVTULtaLeGRpomSLLfeqTMBPAhg.GetJoystickTemplate(P_0);
		}

		internal static WRScrEekSojpdBXyEFARqvkVFcPPb vIwqoVqeOjBtSKOUlpaSczWHzkThB(Guid P_0)
		{
			return TnVTULtaLeGRpomSLLfeqTMBPAhg.jmIIHVhuciwhwfawEGIykNHwVjFw(P_0);
		}

		internal static IHardwareControllerTemplateMap LgUwdQKyWNLeUiUXkQoISHTdjAsG(Guid P_0)
		{
			return TnVTULtaLeGRpomSLLfeqTMBPAhg.GetControllerTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap IVqCCTEToeytMHpQGzDNccruNpDbA(Guid P_0)
		{
			return TnVTULtaLeGRpomSLLfeqTMBPAhg.mIcqijShwPhGhdGdRwEjKGtmlewv(P_0);
		}

		internal static IList<WRScrEekSojpdBXyEFARqvkVFcPPb> NtqZxOyXKuhMtTRYHuwqvdGuUYMH(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = TnVTULtaLeGRpomSLLfeqTMBPAhg.GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap == null)
			{
				return EmptyObjects<WRScrEekSojpdBXyEFARqvkVFcPPb>.EmptyReadOnlyIListT;
			}
			string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
			if (templateGuidsOrig == null || templateGuidsOrig.Length == 0)
			{
				return EmptyObjects<WRScrEekSojpdBXyEFARqvkVFcPPb>.EmptyReadOnlyIListT;
			}
			List<WRScrEekSojpdBXyEFARqvkVFcPPb> list = null;
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
				WRScrEekSojpdBXyEFARqvkVFcPPb wRScrEekSojpdBXyEFARqvkVFcPPb = vIwqoVqeOjBtSKOUlpaSczWHzkThB(guid);
				if (wRScrEekSojpdBXyEFARqvkVFcPPb == null)
				{
					Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
					continue;
				}
				if (list == null)
				{
					list = new List<WRScrEekSojpdBXyEFARqvkVFcPPb>();
				}
				ListTools.AddIfUnique(list, wRScrEekSojpdBXyEFARqvkVFcPPb);
			}
			if (list == null)
			{
				return EmptyObjects<WRScrEekSojpdBXyEFARqvkVFcPPb>.EmptyReadOnlyIListT;
			}
			return list;
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return VeAmGFtEIHUuquEZXjxbJYdKKrEb.CrRsgImokLPbGOkrFjDfwLvCrGMQ();
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

		internal static void gjvZvadYVTPdHYtsUXbCcmTOfADi()
		{
			if (aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
			{
				WdDqHTYGyurdaEIEsbrpsecnjVteA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 6000 != UnityTools.unityVersionObj.major)
			{
				GfSGQhWHDvqaBuTgTZKGxBfSyJvc();
			}
		}

		internal static float oHjiGudGsfgLiqYBOSnQTMqFBJMKA()
		{
			return QMBRjSqLBmKHeMhElRbCuJgyAYCp.CRXASrSjVvfNCBgeLRAMCcMedooX.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
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

		private static void YgxdlwhJkuEbWpbFMkjQmNRWaIvm()
		{
			ABDTVoIIjFlEZLKHRhISrlbClCcb.rDGAsGaojnDPNxgJdXwzYFbyGYcJ();
			VeAmGFtEIHUuquEZXjxbJYdKKrEb.ipDezDqkBwVXiSFhMdzDIOOywaDb(nmQIPpFiDbQPOhxkdBLxhfsyzmvc.GetInputDataUpdateDelegate(), afadmdopkFDkKcMXUOVulpLPkXjgA.GetInputBehaviors_Copy());
			nmQIPpFiDbQPOhxkdBLxhfsyzmvc.Initialize();
		}

		private static void XLXIPZDAAeaeripXuyeZjwSWAWZCA()
		{
			if (kiHfpMdgIcZKOFqEcATiPzLkjinwA != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(kiHfpMdgIcZKOFqEcATiPzLkjinwA);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			kiHfpMdgIcZKOFqEcATiPzLkjinwA = null;
			nmQIPpFiDbQPOhxkdBLxhfsyzmvc = null;
			ilKdcvAddvhstqcjWcabGGsfjMRZB = null;
			if (VeAmGFtEIHUuquEZXjxbJYdKKrEb != null)
			{
				VeAmGFtEIHUuquEZXjxbJYdKKrEb.Dispose();
			}
			VeAmGFtEIHUuquEZXjxbJYdKKrEb = null;
			ABDTVoIIjFlEZLKHRhISrlbClCcb = null;
			TnVTULtaLeGRpomSLLfeqTMBPAhg = null;
			if (afadmdopkFDkKcMXUOVulpLPkXjgA != null)
			{
				afadmdopkFDkKcMXUOVulpLPkXjgA.ZXvdcqdsNZSlLZBUVvStsrOKhLSS();
			}
			afadmdopkFDkKcMXUOVulpLPkXjgA = null;
			LocalizationHelper.ROYCfdKalSTRRIocdSUKgTaeLzCNc();
			GlyphHelper.ddKalqeMivSXTnVXkiEuxpaNEcGA();
			LocalizationManager.Deinitialize();
			GlyphManager.Deinitialize();
			JfpTCKlgtlYDaWrqLdTbwSfEAiuh = null;
			aBiyGFUEVLLrGykdoFrmCmqzGZiAA = false;
			WrbzILXVJRROTTBDFNtXcVCaHZTt = null;
			nGjOLNKmeRaAJGUTohqprdHGHxtmA = UpdateLoopType.Update;
			IveJgwrIDzyjDxaVLdWEMEsffdNIA = false;
			URkgCdLotifeaGAAFDdtQevGyBvUA = Platform.Windows;
			pHQluveHGIPRNrYPNUnGzJgNcXKz = WebplayerPlatform.None;
			HadeSpEntnEJrKOPzYqWGEMxGNsX = EditorPlatform.None;
			LqTzvNJKHIUrRZNIuFGUSsvkblRk = false;
			mgGvfCOVhlRDcSdqnUQMDHhATWTq = null;
			vVhenyNmyJKFhFovDsjqXGPMgWcs = null;
			OdcSmJWEcVJVhXmPqSiEyFqhaabw = null;
			ihKiPxCntGtvbcSzMdonfbfCJqMSA = false;
			dgFYWkbbPpbpMfBawoGqhodSxNmSA = false;
			jCsJTMmvosObkpTJsHBuvVrEHwQT = true;
			mwUrbgSwhTcgoKsjpEOOpiLMKZqi = -1;
			_id = -1;
			ngZaEKjPEpXvagNUkmTYyuCApHrZA = 0;
			unscaledDeltaTime = 0.0;
			unscaledTime = 0.0;
			unscaledTimePrev = 0.0;
			currentFrame = 0u;
			previousFrame = 0u;
			absFrame = 0u;
			CbhfTfIvgxHrFfCgauvQNeCQFTTpA.Clear();
			rIXERBHRlwQxTZubEctIBXJwEiNkA.Clear();
			ILPLmkHCyEdUkDSTmzLQNoTFnpaeb.Clear();
			BkRnrdFOMyXdkJQfQMMYZUwdGOir.Clear();
			lqrFiUGxLywbbihuRXDyRtAcMClZ.Clear();
			_ApplicationFocusChangedEvent = null;
			_ApplicationPauseChangedEvent = null;
			BudaQABKZRxOoHsqMEeHQnQWYtPL = null;
			gqUDPgDOyLzRSMEeYIBXcQqirchEb = null;
			AeCWlIWqExHRBMpkevmmaJvSgMZF = null;
			EPqbzLdZLJqejrfcUneXAbxKEpJYA = null;
			dUkTXYzCCtZnpMrlRJUjAMloINCkA = null;
			JLcAgVnCyocprGTSDcNWBDmHziwZA = null;
			kBnNVMhKnWFGbIGwyNsxmONuULFk = null;
			JrXbOJBISFYdqsjoLkYPtOHZvnuHA = null;
			xSTIClDCBkDqBvGCnnMiwpwYTdYe = null;
			RIKyONyoJhciufoHhRpGvHltbkWDA = null;
			pviZCLrinBhUemYCQcTryCWCKXDH = null;
			GcHbxUIwKehJrUhNyhoXkvwcypby();
			QMBRjSqLBmKHeMhElRbCuJgyAYCp = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= LoSALsAIetibWEYFQcVmPZXYTXAV;
			}
			pEDFtRXsVNNJtQauegEJObAFaioB.bccVwZBOWHAqBvQvmzbVIIAUgepc();
		}

		private static void JjDmOMxnjVzdPfQYBMjJFjRSrOvE(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void ixWiSPshcgDoxhUuXqdAhoVMHFVyA()
		{
			if (!LqTzvNJKHIUrRZNIuFGUSsvkblRk)
			{
				LqTzvNJKHIUrRZNIuFGUSsvkblRk = true;
				ZvBYsooYKxEonRkVIeotklAxDjEY.vhmkUPzhmbRuDpJUZdZVhdnHrobMA();
				ZvBYsooYKxEonRkVIeotklAxDjEY.BdPSoUDPSNSkoCyadMYcDgpbjwyb();
			}
			mgGvfCOVhlRDcSdqnUQMDHhATWTq.Start();
		}

		private static void iNSDwPbaFSjYzsdrzUXJpeGflUhU()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void RCpnDFXBKQTrCCLrmJTJlmQwFUuQ(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			VeAmGFtEIHUuquEZXjxbJYdKKrEb.clKFqwIKysanEZWrUeaCuefTbcVN(P_0);
			Joystick joystick = VeAmGFtEIHUuquEZXjxbJYdKKrEb.oisDKJWbKjPOgFFsCBsSMlVpdULY(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				ABDTVoIIjFlEZLKHRhISrlbClCcb.NJhnARcEELdedFLFVWpTyufQZhAw(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !KEJePpNkhFzDFdjIhCtzBCIKkdRhA)
				{
					IFiQDHrbnBpCKAhoThcOUbwQonL(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void QNLLiHQGnOFoVkBdZrBhiNMkGTUvA(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = VeAmGFtEIHUuquEZXjxbJYdKKrEb.oisDKJWbKjPOgFFsCBsSMlVpdULY(P_0.rewiredId);
				if (joystick != null)
				{
					VeAmGFtEIHUuquEZXjxbJYdKKrEb.xkmKkOpiPJfdujbpjveAfHrLNLgEb(P_0.rewiredId);
					zovKObcSjPsrWdfZvZSaGsQiSxzf(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void IFiQDHrbnBpCKAhoThcOUbwQonL(ControllerStatusChangedEventArgs P_0)
		{
			if (CbhfTfIvgxHrFfCgauvQNeCQFTTpA != null)
			{
				CbhfTfIvgxHrFfCgauvQNeCQFTTpA.Invoke(P_0);
			}
		}

		private static void UPcxTxFfmxCUaAkuaIcDAwknHItF(ControllerStatusChangedEventArgs P_0)
		{
			if (rIXERBHRlwQxTZubEctIBXJwEiNkA != null)
			{
				rIXERBHRlwQxTZubEctIBXJwEiNkA.Invoke(P_0);
			}
		}

		private static void zovKObcSjPsrWdfZvZSaGsQiSxzf(ControllerStatusChangedEventArgs P_0)
		{
			if (ILPLmkHCyEdUkDSTmzLQNoTFnpaeb != null)
			{
				ILPLmkHCyEdUkDSTmzLQNoTFnpaeb.Invoke(P_0);
			}
		}

		private static void WgUUmZdNMVcptaZMrqPRHTwnHxSs(UpdateControllerInfoEventArgs P_0)
		{
			VeAmGFtEIHUuquEZXjxbJYdKKrEb.SxRkbErhvMRGlwEustkcZBagXdQX(P_0);
		}

		private static void JhOJJNfzulMbfEzqompBFGruYABm(bool P_0)
		{
			if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
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

		private static void JEAheGNTIJtirtLLVNUasIYFtnCb(bool P_0)
		{
			if (!aBiyGFUEVLLrGykdoFrmCmqzGZiAA)
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

		private static void PzukINptQZdovzidMaDEJKhUjQzT(bool P_0)
		{
			Action<bool> budaQABKZRxOoHsqMEeHQnQWYtPL = BudaQABKZRxOoHsqMEeHQnQWYtPL;
			if (budaQABKZRxOoHsqMEeHQnQWYtPL != null)
			{
				try
				{
					budaQABKZRxOoHsqMEeHQnQWYtPL(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void QhBowrtsZiJwoetwDJgJSOKvSBnO(int P_0)
		{
			if (AeCWlIWqExHRBMpkevmmaJvSgMZF != null)
			{
				try
				{
					AeCWlIWqExHRBMpkevmmaJvSgMZF((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void bFwLvDvajyIlKItIOybCbILalzRR(bool P_0)
		{
			Action<bool> action = gqUDPgDOyLzRSMEeYIBXcQqirchEb;
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

		private static void fxYiJafimkENHhglKjbpgJjEXvBlA(bool P_0)
		{
			ngZaEKjPEpXvagNUkmTYyuCApHrZA++;
			Action<bool> ePqbzLdZLJqejrfcUneXAbxKEpJYA = EPqbzLdZLJqejrfcUneXAbxKEpJYA;
			if (ePqbzLdZLJqejrfcUneXAbxKEpJYA != null)
			{
				try
				{
					ePqbzLdZLJqejrfcUneXAbxKEpJYA(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void HRsblagzcxMnYZLFjZxZjNYJvupb()
		{
			if (QMBRjSqLBmKHeMhElRbCuJgyAYCp != null)
			{
				GcHbxUIwKehJrUhNyhoXkvwcypby();
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.ChangedEvent += JhOJJNfzulMbfEzqompBFGruYABm;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vLhyOcyzdNfZlbRSyhkdUKgFjyUhA.ChangedEvent += JEAheGNTIJtirtLLVNUasIYFtnCb;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.VtbSEUGGvtXaHAeDBkEyuzzaMkDJ.ChangedEvent += PzukINptQZdovzidMaDEJKhUjQzT;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.jliWDgngdBxpxImpLolMfIMfwySo.ChangedEvent += bFwLvDvajyIlKItIOybCbILalzRR;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vimwvIzBTvECBIJCgigkbeKAonNJ.ChangedEvent += QhBowrtsZiJwoetwDJgJSOKvSBnO;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.NEfFxOeqijFyxzgFCNLRQGmqfdvsA.ChangedEvent += fxYiJafimkENHhglKjbpgJjEXvBlA;
			}
		}

		private static void GcHbxUIwKehJrUhNyhoXkvwcypby()
		{
			if (QMBRjSqLBmKHeMhElRbCuJgyAYCp != null)
			{
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vlPTCknbcCzSzdDAVutciJBcTxIQ.ChangedEvent -= JhOJJNfzulMbfEzqompBFGruYABm;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vLhyOcyzdNfZlbRSyhkdUKgFjyUhA.ChangedEvent -= JEAheGNTIJtirtLLVNUasIYFtnCb;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.VtbSEUGGvtXaHAeDBkEyuzzaMkDJ.ChangedEvent -= PzukINptQZdovzidMaDEJKhUjQzT;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.jliWDgngdBxpxImpLolMfIMfwySo.ChangedEvent -= bFwLvDvajyIlKItIOybCbILalzRR;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.vimwvIzBTvECBIJCgigkbeKAonNJ.ChangedEvent -= QhBowrtsZiJwoetwDJgJSOKvSBnO;
				QMBRjSqLBmKHeMhElRbCuJgyAYCp.NEfFxOeqijFyxzgFCNLRQGmqfdvsA.ChangedEvent -= fxYiJafimkENHhglKjbpgJjEXvBlA;
			}
		}

		private static void LoSALsAIetibWEYFQcVmPZXYTXAV(bool P_0)
		{
			Action<bool> action = pviZCLrinBhUemYCQcTryCWCKXDH;
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

		private static void MGeiknnSHVhPMdPDbDgHLJuqzRBn(Func<ConfigVars, object> P_0, UnityTools.AvCdBwJqgMgreVrAsELpddWPgcmn P_1, Action<Platform> P_2)
		{
			bool flag = false;
			if (P_1.DLnSvKkPXCHLgesiOZnChilGEszr != P_1.vRyLELIfDlwbBLAZevKKdGzrNfpC)
			{
				UnityTools.AvCdBwJqgMgreVrAsELpddWPgcmn avCdBwJqgMgreVrAsELpddWPgcmn = P_1;
				avCdBwJqgMgreVrAsELpddWPgcmn.DLnSvKkPXCHLgesiOZnChilGEszr = P_1.vRyLELIfDlwbBLAZevKKdGzrNfpC;
				UnityTools.tpEOqexFnXfkJhDrrEnkWwcFlCwlA(avCdBwJqgMgreVrAsELpddWPgcmn);
				P_2(avCdBwJqgMgreVrAsELpddWPgcmn.vRyLELIfDlwbBLAZevKKdGzrNfpC);
				DwnKojYPQfKqWOqUcQKgwhNSLPRq();
				flag = true;
			}
			if (!configVars.DoesPlatformUseFallback(P_1.vRyLELIfDlwbBLAZevKKdGzrNfpC, P_1.mGchoPaLgZhtDKjeojOrWIDgcCxFb, isEditor) && !configVars.DoesPlatformUseFallback(P_1.DLnSvKkPXCHLgesiOZnChilGEszr, P_1.mGchoPaLgZhtDKjeojOrWIDgcCxFb, isEditor))
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(kiHfpMdgIcZKOFqEcATiPzLkjinwA);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(P_1.vRyLELIfDlwbBLAZevKKdGzrNfpC, WrbzILXVJRROTTBDFNtXcVCaHZTt) is PlatformInputManager platformInputManager)
					{
						nmQIPpFiDbQPOhxkdBLxhfsyzmvc = platformInputManager;
						return;
					}
				}
			}
			if (flag)
			{
				UnityTools.tpEOqexFnXfkJhDrrEnkWwcFlCwlA(P_1);
				P_2(P_1.vRyLELIfDlwbBLAZevKKdGzrNfpC);
				DwnKojYPQfKqWOqUcQKgwhNSLPRq();
				flag = false;
			}
			if (configVars.DoesPlatformUseFallback(URkgCdLotifeaGAAFDdtQevGyBvUA, pHQluveHGIPRNrYPNUnGzJgNcXKz, isEditor))
			{
				IveJgwrIDzyjDxaVLdWEMEsffdNIA = true;
				nmQIPpFiDbQPOhxkdBLxhfsyzmvc = new rATCJpEXUsOwYzbNYzacxdopMAdE(WrbzILXVJRROTTBDFNtXcVCaHZTt.updateLoop);
			}
			else if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.Windows || URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.WindowsAppStore || URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.WindowsUWP || URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.OSX || URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.Linux)
			{
				nmQIPpFiDbQPOhxkdBLxhfsyzmvc = P_0(WrbzILXVJRROTTBDFNtXcVCaHZTt) as PlatformInputManager;
			}
			else if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.WebGL && !isEditor)
			{
				try
				{
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = P_0(WrbzILXVJRROTTBDFNtXcVCaHZTt) as PlatformInputManager;
					if (nmQIPpFiDbQPOhxkdBLxhfsyzmvc == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = null;
				}
			}
			else if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.XboxOne && !isEditor)
			{
				try
				{
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = new CustomInputManager(new XboxOneInputSource(), WrbzILXVJRROTTBDFNtXcVCaHZTt.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (nmQIPpFiDbQPOhxkdBLxhfsyzmvc == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = null;
				}
			}
			else if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.PS4 && !isEditor)
			{
				try
				{
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = P_0(WrbzILXVJRROTTBDFNtXcVCaHZTt) as PlatformInputManager;
					if (nmQIPpFiDbQPOhxkdBLxhfsyzmvc == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
					Logger.LogError(msg);
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = null;
				}
			}
			else if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.PS5 && !isEditor)
			{
				try
				{
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = P_0(WrbzILXVJRROTTBDFNtXcVCaHZTt) as PlatformInputManager;
					if (nmQIPpFiDbQPOhxkdBLxhfsyzmvc == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
					Logger.LogError(msg2);
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = null;
				}
			}
			else if ((URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.GameCoreXboxOne || URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = P_0(WrbzILXVJRROTTBDFNtXcVCaHZTt) as PlatformInputManager;
					if (nmQIPpFiDbQPOhxkdBLxhfsyzmvc == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg3)
				{
					string text = ((URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg3);
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = null;
				}
			}
			else if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.Ouya && !isEditor)
			{
				Logger.LogError("Ouya is no longer supported.");
				nmQIPpFiDbQPOhxkdBLxhfsyzmvc = null;
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.bogHKChnwWGVEctpAkleZxzXilUtA = P_0(WrbzILXVJRROTTBDFNtXcVCaHZTt) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg4)
				{
					Logger.LogError(msg4);
				}
			}
			else if (URkgCdLotifeaGAAFDdtQevGyBvUA == Platform.Custom)
			{
				try
				{
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = new CustomInputManager(pEDFtRXsVNNJtQauegEJObAFaioB.KLjCudzFOhpKWViCoIdECpHUEPOE(), WrbzILXVJRROTTBDFNtXcVCaHZTt.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (nmQIPpFiDbQPOhxkdBLxhfsyzmvc == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Custom platform could not be initialized due to an exception!");
					nmQIPpFiDbQPOhxkdBLxhfsyzmvc = null;
					throw;
				}
			}
			if (nmQIPpFiDbQPOhxkdBLxhfsyzmvc == null)
			{
				IveJgwrIDzyjDxaVLdWEMEsffdNIA = true;
				nmQIPpFiDbQPOhxkdBLxhfsyzmvc = new rATCJpEXUsOwYzbNYzacxdopMAdE(WrbzILXVJRROTTBDFNtXcVCaHZTt.updateLoop);
			}
		}

		private static void WdDqHTYGyurdaEIEsbrpsecnjVteA()
		{
			if (ihKiPxCntGtvbcSzMdonfbfCJqMSA != WrbzILXVJRROTTBDFNtXcVCaHZTt.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				ihKiPxCntGtvbcSzMdonfbfCJqMSA = !ihKiPxCntGtvbcSzMdonfbfCJqMSA;
			}
		}

		private static void GfSGQhWHDvqaBuTgTZKGxBfSyJvc()
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
