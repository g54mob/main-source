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
			private static LocalizationHelper PqFQBRthqmubRAquVNtNZPgJRoxB;

			internal static LocalizationHelper kScfYREWKeSweNxisyOBriBHDOWiA => PqFQBRthqmubRAquVNtNZPgJRoxB ?? (PqFQBRthqmubRAquVNtNZPgJRoxB = new LocalizationHelper());

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

			internal static void YMpbVhJCCSzyErUIVmIljDxXAKfn()
			{
				PqFQBRthqmubRAquVNtNZPgJRoxB = null;
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
			private static GlyphHelper FFNJuYqLbuxbZfcwwaBQKBxjTGTnA;

			internal static GlyphHelper gBekWBZCQbeeFnPGVBrokpSZozJg => FFNJuYqLbuxbZfcwwaBQKBxjTGTnA ?? (FFNJuYqLbuxbZfcwwaBQKBxjTGTnA = new GlyphHelper());

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

			internal static void amCpibRdtunuMkLnvoAfXZqiOdXN()
			{
				FFNJuYqLbuxbZfcwwaBQKBxjTGTnA = null;
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
			private static ConfigHelper LkllJrvIGaAHQCImWuzEtNdnBkAJA;

			private float srqPIXKGbobkgGkEQdumccoJTWsg = 0.7f;

			private float khSHCwkIhUegmaAHbWQFVMXYcsxEA = 100f;

			internal static ConfigHelper iuzUSMpxqVpBnytkMYyAorwOumnJ => LkllJrvIGaAHQCImWuzEtNdnBkAJA ?? (LkllJrvIGaAHQCImWuzEtNdnBkAJA = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.effectivePlatform == Platform.Windows && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.useXInput;
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
						if (xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.useXInput == value)
						{
							return;
						}
						if (value)
						{
							if (xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								Logger.LogWarning("XInput cannot be enabled with the current primary input source: " + xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("XInput cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.useXInput = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					if (UnityTools.effectivePlatform == Platform.Windows && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
					{
						return true;
					}
					if (UnityTools.effectivePlatform == Platform.WindowsUWP)
					{
						return windowsUWPSupportGamepads;
					}
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_useWindowsGamingInput();
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
						if (xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_useWindowsGamingInput() == value)
						{
							return;
						}
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.SetPlatformVar_useWindowsGamingInput(value);
						if (value)
						{
							if (xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
							{
								return;
							}
							if (UnityTools.effectivePlatform == Platform.Windows && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput)
							{
								Logger.LogWarning("Windows Gaming Input cannot be enabled with the current primary input source: " + xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource);
								return;
							}
						}
						else if (UnityTools.effectivePlatform == Platform.Windows && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
						{
							xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.LogWarning("Windows Gaming Input cannot be used with the current primary input source. The primary input source has been changed to Raw Input.");
						}
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.updateMode;
				}
				set
				{
					if (CheckInitialized() && value != xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.updateMode)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.updateMode = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.updateLoop = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.effectivePlatform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.useXInput = true;
						}
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.osx_primaryInputSource != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.osx_primaryInputSource = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.linux_primaryInputSource != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.linux_primaryInputSource = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.windowsUWP_primaryInputSource = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return (xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return (xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useGamepadAPI != value)
					{
						platformVars_WindowsUWP.useGamepadAPI = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					if (UnityTools.effectivePlatform == Platform.OSX && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.osx_primaryInputSource == OSXStandalonePrimaryInputSource.GameController)
					{
						return true;
					}
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_useAppleGameController();
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_useAppleGameController() != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.SetPlatformVar_useAppleGameController(value);
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.xboxOne_primaryInputSource != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.xboxOne_primaryInputSource = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.ps4_primaryInputSource != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.ps4_primaryInputSource = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.webGL_primaryInputSource != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.webGL_primaryInputSource = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.alwaysUseUnityInput != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.alwaysUseUnityInput = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.SetPlatformVar_useNativeMouse(value) && nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
					{
						nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
					{
						nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
					{
						nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_joystickRefreshRate();
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
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						pxSsTwQxyRmtUJZCaBtrCxOIcIqQ();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.android_supportUnknownGamepads != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.android_supportUnknownGamepads = value;
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.defaultAxisSensitivityType != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.defaultAxisSensitivityType = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.force4WayHats != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.force4WayHats = value;
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
					return srqPIXKGbobkgGkEQdumccoJTWsg;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (srqPIXKGbobkgGkEQdumccoJTWsg != value)
						{
							srqPIXKGbobkgGkEQdumccoJTWsg = value;
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
					return khSHCwkIhUegmaAHbWQFVMXYcsxEA;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (khSHCwkIhUegmaAHbWQFVMXYcsxEA != value)
						{
							khSHCwkIhUegmaAHbWQFVMXYcsxEA = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.activateActionButtonsOnNegativeValue = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.throttleCalibrationMode != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.throttleCalibrationMode = value;
						YNZnkUUWdETsfnFwfyPUjVPxExCq.oSxeerbdZuiFfoUevYuwJpLZPtMP(value);
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.keyCombinationOverrideMode;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.keyCombinationOverrideMode != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.keyCombinationOverrideMode = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.generateKeyEventsOnKeyCombinationOverride;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.generateKeyEventsOnKeyCombinationOverride != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.generateKeyEventsOnKeyCombinationOverride = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.autoAssignJoysticks != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.autoAssignJoysticks = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.maxJoysticksPerPlayer != value)
						{
							xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.maxJoysticksPerPlayer = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.distributeJoysticksEvenly != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.distributeJoysticksEvenly = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.logLevel != value)
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.logLevel = value;
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
					return new List<EnhancedDeviceSupportDeviceType>(xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes());
				}
				set
				{
					if (CheckInitialized())
					{
						xXNYybZYVXuCDBsfcGvDXJSXkuEl.ConfigVars.SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(value);
						if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
						{
							nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
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
				private sealed class SlSpNoVwqJdtCtKDuhoZUNifcfRw : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pdYTpsWmiTGFfFWQMntxPLYBqLfKA;

					private ControllerPollingInfo PBHBDxURNorcmDrTMmDHOHSqvbVE;

					private int pUtAgPdQmTfxzghQgchgelxsbWxM;

					public PollingHelper yjDYInAAWfzoNShFJfSAdXujuHdJA;

					private IEnumerator<ControllerPollingInfo> SWkSKxLhNbVsXBzHYBTPSAebopjp;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PBHBDxURNorcmDrTMmDHOHSqvbVE;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PBHBDxURNorcmDrTMmDHOHSqvbVE;
						}
					}

					[DebuggerHidden]
					public SlSpNoVwqJdtCtKDuhoZUNifcfRw(int P_0)
					{
						pdYTpsWmiTGFfFWQMntxPLYBqLfKA = P_0;
						pUtAgPdQmTfxzghQgchgelxsbWxM = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (pdYTpsWmiTGFfFWQMntxPLYBqLfKA)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								LzZoFayssYwspHumrLxwacxtHGh();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								tkNhnjDStTjrhLNabHbmbOQQuzJJA();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								aWLlCyRPTEzfGSLHQZzPZaQkZQZN();
							}
							break;
						}
						SWkSKxLhNbVsXBzHYBTPSAebopjp = null;
						pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pdYTpsWmiTGFfFWQMntxPLYBqLfKA;
							PollingHelper pollingHelper = yjDYInAAWfzoNShFJfSAdXujuHdJA;
							switch (num)
							{
							default:
								return false;
							case 0:
								pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								SWkSKxLhNbVsXBzHYBTPSAebopjp = pollingHelper.EJnkKZICEIHWEZQZnwdfTcquVOKJ().GetEnumerator();
								pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -3;
								goto IL_0084;
							case 1:
								pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -3;
								goto IL_0084;
							case 2:
								pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -4;
								goto IL_00e4;
							case 3:
								{
									pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -5;
									break;
								}
								IL_00e4:
								if (SWkSKxLhNbVsXBzHYBTPSAebopjp.MoveNext())
								{
									ControllerPollingInfo current = SWkSKxLhNbVsXBzHYBTPSAebopjp.Current;
									PBHBDxURNorcmDrTMmDHOHSqvbVE = current;
									pdYTpsWmiTGFfFWQMntxPLYBqLfKA = 2;
									return true;
								}
								tkNhnjDStTjrhLNabHbmbOQQuzJJA();
								SWkSKxLhNbVsXBzHYBTPSAebopjp = null;
								SWkSKxLhNbVsXBzHYBTPSAebopjp = pollingHelper.UCGVNIzSlqcnRcDztgZAiFVLVdFr().GetEnumerator();
								pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -5;
								break;
								IL_0084:
								if (SWkSKxLhNbVsXBzHYBTPSAebopjp.MoveNext())
								{
									ControllerPollingInfo current2 = SWkSKxLhNbVsXBzHYBTPSAebopjp.Current;
									PBHBDxURNorcmDrTMmDHOHSqvbVE = current2;
									pdYTpsWmiTGFfFWQMntxPLYBqLfKA = 1;
									return true;
								}
								LzZoFayssYwspHumrLxwacxtHGh();
								SWkSKxLhNbVsXBzHYBTPSAebopjp = null;
								SWkSKxLhNbVsXBzHYBTPSAebopjp = pollingHelper.CcoEbnznEiblmmcoEmtSouqGkvWi().GetEnumerator();
								pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -4;
								goto IL_00e4;
							}
							if (SWkSKxLhNbVsXBzHYBTPSAebopjp.MoveNext())
							{
								ControllerPollingInfo current3 = SWkSKxLhNbVsXBzHYBTPSAebopjp.Current;
								PBHBDxURNorcmDrTMmDHOHSqvbVE = current3;
								pdYTpsWmiTGFfFWQMntxPLYBqLfKA = 3;
								return true;
							}
							aWLlCyRPTEzfGSLHQZzPZaQkZQZN();
							SWkSKxLhNbVsXBzHYBTPSAebopjp = null;
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

					private void LzZoFayssYwspHumrLxwacxtHGh()
					{
						pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -1;
						if (SWkSKxLhNbVsXBzHYBTPSAebopjp != null)
						{
							SWkSKxLhNbVsXBzHYBTPSAebopjp.Dispose();
						}
					}

					private void tkNhnjDStTjrhLNabHbmbOQQuzJJA()
					{
						pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -1;
						if (SWkSKxLhNbVsXBzHYBTPSAebopjp != null)
						{
							SWkSKxLhNbVsXBzHYBTPSAebopjp.Dispose();
						}
					}

					private void aWLlCyRPTEzfGSLHQZzPZaQkZQZN()
					{
						pdYTpsWmiTGFfFWQMntxPLYBqLfKA = -1;
						if (SWkSKxLhNbVsXBzHYBTPSAebopjp != null)
						{
							SWkSKxLhNbVsXBzHYBTPSAebopjp.Dispose();
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
						SlSpNoVwqJdtCtKDuhoZUNifcfRw slSpNoVwqJdtCtKDuhoZUNifcfRw;
						if (pdYTpsWmiTGFfFWQMntxPLYBqLfKA == -2 && pUtAgPdQmTfxzghQgchgelxsbWxM == Environment.CurrentManagedThreadId)
						{
							pdYTpsWmiTGFfFWQMntxPLYBqLfKA = 0;
							slSpNoVwqJdtCtKDuhoZUNifcfRw = this;
						}
						else
						{
							slSpNoVwqJdtCtKDuhoZUNifcfRw = new SlSpNoVwqJdtCtKDuhoZUNifcfRw(0);
							slSpNoVwqJdtCtKDuhoZUNifcfRw.yjDYInAAWfzoNShFJfSAdXujuHdJA = yjDYInAAWfzoNShFJfSAdXujuHdJA;
						}
						return slSpNoVwqJdtCtKDuhoZUNifcfRw;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class sWrTCjsvbWWKrPLutmPECWAkJKeQ : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int mEVIiSaTVxbxuuUvbzRoFdVqiptsA;

					private ControllerPollingInfo bVjOVCIwpsMyGZBDtiejtXeGanlY;

					private int qfrYfiZuflDyLtUFbIQQUQuaUvFD;

					public PollingHelper zVjeQyuBGfCcEbfHkSNXCLvuEVYFb;

					private IEnumerator<ControllerPollingInfo> IupldWUTBiadLknhtHWgIrDULbHf;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return bVjOVCIwpsMyGZBDtiejtXeGanlY;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return bVjOVCIwpsMyGZBDtiejtXeGanlY;
						}
					}

					[DebuggerHidden]
					public sWrTCjsvbWWKrPLutmPECWAkJKeQ(int P_0)
					{
						mEVIiSaTVxbxuuUvbzRoFdVqiptsA = P_0;
						qfrYfiZuflDyLtUFbIQQUQuaUvFD = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (mEVIiSaTVxbxuuUvbzRoFdVqiptsA)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								PzRpELtxsiBGZAGWMkfRvQDrDBSP();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								jEKFEaQjZehejdckLpGpzzNQOUpf();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								mWtJeJHdFtgLVcRzQJiKZpvBUgwT();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								ufQVNNguAjJMlACfzlyzRetuLeke();
							}
							break;
						}
						IupldWUTBiadLknhtHWgIrDULbHf = null;
						mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = mEVIiSaTVxbxuuUvbzRoFdVqiptsA;
							PollingHelper pollingHelper = zVjeQyuBGfCcEbfHkSNXCLvuEVYFb;
							switch (num)
							{
							default:
								return false;
							case 0:
								mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								IupldWUTBiadLknhtHWgIrDULbHf = pollingHelper.eqqFbRpdpZhGebvkdPgIfGEkQOPv().GetEnumerator();
								mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -3;
								goto IL_0088;
							case 1:
								mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -3;
								goto IL_0088;
							case 2:
								mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -4;
								goto IL_00e8;
							case 3:
								mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -5;
								goto IL_0148;
							case 4:
								{
									mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -6;
									break;
								}
								IL_00e8:
								if (IupldWUTBiadLknhtHWgIrDULbHf.MoveNext())
								{
									ControllerPollingInfo current = IupldWUTBiadLknhtHWgIrDULbHf.Current;
									bVjOVCIwpsMyGZBDtiejtXeGanlY = current;
									mEVIiSaTVxbxuuUvbzRoFdVqiptsA = 2;
									return true;
								}
								jEKFEaQjZehejdckLpGpzzNQOUpf();
								IupldWUTBiadLknhtHWgIrDULbHf = null;
								IupldWUTBiadLknhtHWgIrDULbHf = pollingHelper.dnLDehBsvogcCAZAGnpqHVzhtqbgB().GetEnumerator();
								mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -5;
								goto IL_0148;
								IL_0088:
								if (IupldWUTBiadLknhtHWgIrDULbHf.MoveNext())
								{
									ControllerPollingInfo current2 = IupldWUTBiadLknhtHWgIrDULbHf.Current;
									bVjOVCIwpsMyGZBDtiejtXeGanlY = current2;
									mEVIiSaTVxbxuuUvbzRoFdVqiptsA = 1;
									return true;
								}
								PzRpELtxsiBGZAGWMkfRvQDrDBSP();
								IupldWUTBiadLknhtHWgIrDULbHf = null;
								IupldWUTBiadLknhtHWgIrDULbHf = pollingHelper.ZXDOwOvQRcrUbrMhMExVggkBcOFX().GetEnumerator();
								mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -4;
								goto IL_00e8;
								IL_0148:
								if (IupldWUTBiadLknhtHWgIrDULbHf.MoveNext())
								{
									ControllerPollingInfo current3 = IupldWUTBiadLknhtHWgIrDULbHf.Current;
									bVjOVCIwpsMyGZBDtiejtXeGanlY = current3;
									mEVIiSaTVxbxuuUvbzRoFdVqiptsA = 3;
									return true;
								}
								mWtJeJHdFtgLVcRzQJiKZpvBUgwT();
								IupldWUTBiadLknhtHWgIrDULbHf = null;
								IupldWUTBiadLknhtHWgIrDULbHf = pollingHelper.iuViFplomLjveigOGnClUlCzfhNjb().GetEnumerator();
								mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -6;
								break;
							}
							if (IupldWUTBiadLknhtHWgIrDULbHf.MoveNext())
							{
								ControllerPollingInfo current4 = IupldWUTBiadLknhtHWgIrDULbHf.Current;
								bVjOVCIwpsMyGZBDtiejtXeGanlY = current4;
								mEVIiSaTVxbxuuUvbzRoFdVqiptsA = 4;
								return true;
							}
							ufQVNNguAjJMlACfzlyzRetuLeke();
							IupldWUTBiadLknhtHWgIrDULbHf = null;
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

					private void PzRpELtxsiBGZAGWMkfRvQDrDBSP()
					{
						mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -1;
						if (IupldWUTBiadLknhtHWgIrDULbHf != null)
						{
							IupldWUTBiadLknhtHWgIrDULbHf.Dispose();
						}
					}

					private void jEKFEaQjZehejdckLpGpzzNQOUpf()
					{
						mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -1;
						if (IupldWUTBiadLknhtHWgIrDULbHf != null)
						{
							IupldWUTBiadLknhtHWgIrDULbHf.Dispose();
						}
					}

					private void mWtJeJHdFtgLVcRzQJiKZpvBUgwT()
					{
						mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -1;
						if (IupldWUTBiadLknhtHWgIrDULbHf != null)
						{
							IupldWUTBiadLknhtHWgIrDULbHf.Dispose();
						}
					}

					private void ufQVNNguAjJMlACfzlyzRetuLeke()
					{
						mEVIiSaTVxbxuuUvbzRoFdVqiptsA = -1;
						if (IupldWUTBiadLknhtHWgIrDULbHf != null)
						{
							IupldWUTBiadLknhtHWgIrDULbHf.Dispose();
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
						sWrTCjsvbWWKrPLutmPECWAkJKeQ sWrTCjsvbWWKrPLutmPECWAkJKeQ2;
						if (mEVIiSaTVxbxuuUvbzRoFdVqiptsA == -2 && qfrYfiZuflDyLtUFbIQQUQuaUvFD == Environment.CurrentManagedThreadId)
						{
							mEVIiSaTVxbxuuUvbzRoFdVqiptsA = 0;
							sWrTCjsvbWWKrPLutmPECWAkJKeQ2 = this;
						}
						else
						{
							sWrTCjsvbWWKrPLutmPECWAkJKeQ2 = new sWrTCjsvbWWKrPLutmPECWAkJKeQ(0);
							sWrTCjsvbWWKrPLutmPECWAkJKeQ2.zVjeQyuBGfCcEbfHkSNXCLvuEVYFb = zVjeQyuBGfCcEbfHkSNXCLvuEVYFb;
						}
						return sWrTCjsvbWWKrPLutmPECWAkJKeQ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class uOWzurgODDBtuUNMzNeZkLJhsWtN : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int qASKbYECRQWdowvtdGLRaWZauiyC;

					private ControllerPollingInfo jPBHjanqRIrZqvAoUfNEXcEoIIeFA;

					private int hmogrUkdYijEiAdsrBfIITEwrUAEb;

					public PollingHelper XVQUWbphSdHSqydeDVyUTSOBCKeM;

					private IEnumerator<ControllerPollingInfo> ZetQedTgEVoQVAtYdllNggXaHdYx;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return jPBHjanqRIrZqvAoUfNEXcEoIIeFA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return jPBHjanqRIrZqvAoUfNEXcEoIIeFA;
						}
					}

					[DebuggerHidden]
					public uOWzurgODDBtuUNMzNeZkLJhsWtN(int P_0)
					{
						qASKbYECRQWdowvtdGLRaWZauiyC = P_0;
						hmogrUkdYijEiAdsrBfIITEwrUAEb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (qASKbYECRQWdowvtdGLRaWZauiyC)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								hGLDMtqPyiMQpEMINnaVlNeydopKA();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								YRvciQSTHIOeSVRBQHwDKLFAaJPw();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								KMIwkCKKlvERiMLWYqCAcHpiICdR();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								AktdkvKuZWKyKLKxCKYkvBMpbUuo();
							}
							break;
						}
						ZetQedTgEVoQVAtYdllNggXaHdYx = null;
						qASKbYECRQWdowvtdGLRaWZauiyC = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = qASKbYECRQWdowvtdGLRaWZauiyC;
							PollingHelper xVQUWbphSdHSqydeDVyUTSOBCKeM = XVQUWbphSdHSqydeDVyUTSOBCKeM;
							switch (num)
							{
							default:
								return false;
							case 0:
								qASKbYECRQWdowvtdGLRaWZauiyC = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								ZetQedTgEVoQVAtYdllNggXaHdYx = xVQUWbphSdHSqydeDVyUTSOBCKeM.hACLPldKrQMCSxizmzfsUZEqDBCT().GetEnumerator();
								qASKbYECRQWdowvtdGLRaWZauiyC = -3;
								goto IL_0088;
							case 1:
								qASKbYECRQWdowvtdGLRaWZauiyC = -3;
								goto IL_0088;
							case 2:
								qASKbYECRQWdowvtdGLRaWZauiyC = -4;
								goto IL_00e8;
							case 3:
								qASKbYECRQWdowvtdGLRaWZauiyC = -5;
								goto IL_0148;
							case 4:
								{
									qASKbYECRQWdowvtdGLRaWZauiyC = -6;
									break;
								}
								IL_00e8:
								if (ZetQedTgEVoQVAtYdllNggXaHdYx.MoveNext())
								{
									ControllerPollingInfo current = ZetQedTgEVoQVAtYdllNggXaHdYx.Current;
									jPBHjanqRIrZqvAoUfNEXcEoIIeFA = current;
									qASKbYECRQWdowvtdGLRaWZauiyC = 2;
									return true;
								}
								YRvciQSTHIOeSVRBQHwDKLFAaJPw();
								ZetQedTgEVoQVAtYdllNggXaHdYx = null;
								ZetQedTgEVoQVAtYdllNggXaHdYx = xVQUWbphSdHSqydeDVyUTSOBCKeM.LKWZVShFAzTgTZblAlUCUZYpTyil().GetEnumerator();
								qASKbYECRQWdowvtdGLRaWZauiyC = -5;
								goto IL_0148;
								IL_0088:
								if (ZetQedTgEVoQVAtYdllNggXaHdYx.MoveNext())
								{
									ControllerPollingInfo current2 = ZetQedTgEVoQVAtYdllNggXaHdYx.Current;
									jPBHjanqRIrZqvAoUfNEXcEoIIeFA = current2;
									qASKbYECRQWdowvtdGLRaWZauiyC = 1;
									return true;
								}
								hGLDMtqPyiMQpEMINnaVlNeydopKA();
								ZetQedTgEVoQVAtYdllNggXaHdYx = null;
								ZetQedTgEVoQVAtYdllNggXaHdYx = xVQUWbphSdHSqydeDVyUTSOBCKeM.gzafIWpptaoXzxIXYMCpHwRbFebG().GetEnumerator();
								qASKbYECRQWdowvtdGLRaWZauiyC = -4;
								goto IL_00e8;
								IL_0148:
								if (ZetQedTgEVoQVAtYdllNggXaHdYx.MoveNext())
								{
									ControllerPollingInfo current3 = ZetQedTgEVoQVAtYdllNggXaHdYx.Current;
									jPBHjanqRIrZqvAoUfNEXcEoIIeFA = current3;
									qASKbYECRQWdowvtdGLRaWZauiyC = 3;
									return true;
								}
								KMIwkCKKlvERiMLWYqCAcHpiICdR();
								ZetQedTgEVoQVAtYdllNggXaHdYx = null;
								ZetQedTgEVoQVAtYdllNggXaHdYx = xVQUWbphSdHSqydeDVyUTSOBCKeM.mljoqeyRznqMTWbnchcMIakGojAUA().GetEnumerator();
								qASKbYECRQWdowvtdGLRaWZauiyC = -6;
								break;
							}
							if (ZetQedTgEVoQVAtYdllNggXaHdYx.MoveNext())
							{
								ControllerPollingInfo current4 = ZetQedTgEVoQVAtYdllNggXaHdYx.Current;
								jPBHjanqRIrZqvAoUfNEXcEoIIeFA = current4;
								qASKbYECRQWdowvtdGLRaWZauiyC = 4;
								return true;
							}
							AktdkvKuZWKyKLKxCKYkvBMpbUuo();
							ZetQedTgEVoQVAtYdllNggXaHdYx = null;
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

					private void hGLDMtqPyiMQpEMINnaVlNeydopKA()
					{
						qASKbYECRQWdowvtdGLRaWZauiyC = -1;
						if (ZetQedTgEVoQVAtYdllNggXaHdYx != null)
						{
							ZetQedTgEVoQVAtYdllNggXaHdYx.Dispose();
						}
					}

					private void YRvciQSTHIOeSVRBQHwDKLFAaJPw()
					{
						qASKbYECRQWdowvtdGLRaWZauiyC = -1;
						if (ZetQedTgEVoQVAtYdllNggXaHdYx != null)
						{
							ZetQedTgEVoQVAtYdllNggXaHdYx.Dispose();
						}
					}

					private void KMIwkCKKlvERiMLWYqCAcHpiICdR()
					{
						qASKbYECRQWdowvtdGLRaWZauiyC = -1;
						if (ZetQedTgEVoQVAtYdllNggXaHdYx != null)
						{
							ZetQedTgEVoQVAtYdllNggXaHdYx.Dispose();
						}
					}

					private void AktdkvKuZWKyKLKxCKYkvBMpbUuo()
					{
						qASKbYECRQWdowvtdGLRaWZauiyC = -1;
						if (ZetQedTgEVoQVAtYdllNggXaHdYx != null)
						{
							ZetQedTgEVoQVAtYdllNggXaHdYx.Dispose();
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
						uOWzurgODDBtuUNMzNeZkLJhsWtN uOWzurgODDBtuUNMzNeZkLJhsWtN2;
						if (qASKbYECRQWdowvtdGLRaWZauiyC == -2 && hmogrUkdYijEiAdsrBfIITEwrUAEb == Environment.CurrentManagedThreadId)
						{
							qASKbYECRQWdowvtdGLRaWZauiyC = 0;
							uOWzurgODDBtuUNMzNeZkLJhsWtN2 = this;
						}
						else
						{
							uOWzurgODDBtuUNMzNeZkLJhsWtN2 = new uOWzurgODDBtuUNMzNeZkLJhsWtN(0);
							uOWzurgODDBtuUNMzNeZkLJhsWtN2.XVQUWbphSdHSqydeDVyUTSOBCKeM = XVQUWbphSdHSqydeDVyUTSOBCKeM;
						}
						return uOWzurgODDBtuUNMzNeZkLJhsWtN2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class nqVtCBfnsGptzpKyuUnoydZtwUgi : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int pgvNzUKwGGexqseQFUnDfWZCxuNj;

					private ControllerPollingInfo AqaFHzbOviFiEzZyMUFJLjrLdGrgb;

					private int ykYamScJIWjjUnowpHAPGYtXqcfzA;

					public PollingHelper xMCfwuvpzEFISfrNYMTMQXfdCnTdb;

					private IEnumerator<ControllerPollingInfo> LQSeEoDeeQAkkESKtRaFaXfFUtQd;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return AqaFHzbOviFiEzZyMUFJLjrLdGrgb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return AqaFHzbOviFiEzZyMUFJLjrLdGrgb;
						}
					}

					[DebuggerHidden]
					public nqVtCBfnsGptzpKyuUnoydZtwUgi(int P_0)
					{
						pgvNzUKwGGexqseQFUnDfWZCxuNj = P_0;
						ykYamScJIWjjUnowpHAPGYtXqcfzA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (pgvNzUKwGGexqseQFUnDfWZCxuNj)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								bhQLgSUFDGymnaaeKkBBdBGHNONO();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								ymYqATpHmEXxbnYZEtZsRBFZmLiL();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								bdiSKbWRMceRbjrcHGycaepBcLIOb();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								NSEhYJxpcrNMFCGQTqlSHorYJuUI();
							}
							break;
						}
						LQSeEoDeeQAkkESKtRaFaXfFUtQd = null;
						pgvNzUKwGGexqseQFUnDfWZCxuNj = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pgvNzUKwGGexqseQFUnDfWZCxuNj;
							PollingHelper pollingHelper = xMCfwuvpzEFISfrNYMTMQXfdCnTdb;
							switch (num)
							{
							default:
								return false;
							case 0:
								pgvNzUKwGGexqseQFUnDfWZCxuNj = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								LQSeEoDeeQAkkESKtRaFaXfFUtQd = pollingHelper.dqJDCHhyyFzoQCcjWEfoAEvlXcyw().GetEnumerator();
								pgvNzUKwGGexqseQFUnDfWZCxuNj = -3;
								goto IL_0088;
							case 1:
								pgvNzUKwGGexqseQFUnDfWZCxuNj = -3;
								goto IL_0088;
							case 2:
								pgvNzUKwGGexqseQFUnDfWZCxuNj = -4;
								goto IL_00e8;
							case 3:
								pgvNzUKwGGexqseQFUnDfWZCxuNj = -5;
								goto IL_0148;
							case 4:
								{
									pgvNzUKwGGexqseQFUnDfWZCxuNj = -6;
									break;
								}
								IL_00e8:
								if (LQSeEoDeeQAkkESKtRaFaXfFUtQd.MoveNext())
								{
									ControllerPollingInfo current = LQSeEoDeeQAkkESKtRaFaXfFUtQd.Current;
									AqaFHzbOviFiEzZyMUFJLjrLdGrgb = current;
									pgvNzUKwGGexqseQFUnDfWZCxuNj = 2;
									return true;
								}
								ymYqATpHmEXxbnYZEtZsRBFZmLiL();
								LQSeEoDeeQAkkESKtRaFaXfFUtQd = null;
								LQSeEoDeeQAkkESKtRaFaXfFUtQd = pollingHelper.DXXmVfBSPkcyyWNTkoKaUbpkNJpH().GetEnumerator();
								pgvNzUKwGGexqseQFUnDfWZCxuNj = -5;
								goto IL_0148;
								IL_0088:
								if (LQSeEoDeeQAkkESKtRaFaXfFUtQd.MoveNext())
								{
									ControllerPollingInfo current2 = LQSeEoDeeQAkkESKtRaFaXfFUtQd.Current;
									AqaFHzbOviFiEzZyMUFJLjrLdGrgb = current2;
									pgvNzUKwGGexqseQFUnDfWZCxuNj = 1;
									return true;
								}
								bhQLgSUFDGymnaaeKkBBdBGHNONO();
								LQSeEoDeeQAkkESKtRaFaXfFUtQd = null;
								LQSeEoDeeQAkkESKtRaFaXfFUtQd = pollingHelper.ZXDOwOvQRcrUbrMhMExVggkBcOFX().GetEnumerator();
								pgvNzUKwGGexqseQFUnDfWZCxuNj = -4;
								goto IL_00e8;
								IL_0148:
								if (LQSeEoDeeQAkkESKtRaFaXfFUtQd.MoveNext())
								{
									ControllerPollingInfo current3 = LQSeEoDeeQAkkESKtRaFaXfFUtQd.Current;
									AqaFHzbOviFiEzZyMUFJLjrLdGrgb = current3;
									pgvNzUKwGGexqseQFUnDfWZCxuNj = 3;
									return true;
								}
								bdiSKbWRMceRbjrcHGycaepBcLIOb();
								LQSeEoDeeQAkkESKtRaFaXfFUtQd = null;
								LQSeEoDeeQAkkESKtRaFaXfFUtQd = pollingHelper.RMrqDdxgXvfvoPVKbbuLyRbfMijp().GetEnumerator();
								pgvNzUKwGGexqseQFUnDfWZCxuNj = -6;
								break;
							}
							if (LQSeEoDeeQAkkESKtRaFaXfFUtQd.MoveNext())
							{
								ControllerPollingInfo current4 = LQSeEoDeeQAkkESKtRaFaXfFUtQd.Current;
								AqaFHzbOviFiEzZyMUFJLjrLdGrgb = current4;
								pgvNzUKwGGexqseQFUnDfWZCxuNj = 4;
								return true;
							}
							NSEhYJxpcrNMFCGQTqlSHorYJuUI();
							LQSeEoDeeQAkkESKtRaFaXfFUtQd = null;
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

					private void bhQLgSUFDGymnaaeKkBBdBGHNONO()
					{
						pgvNzUKwGGexqseQFUnDfWZCxuNj = -1;
						if (LQSeEoDeeQAkkESKtRaFaXfFUtQd != null)
						{
							LQSeEoDeeQAkkESKtRaFaXfFUtQd.Dispose();
						}
					}

					private void ymYqATpHmEXxbnYZEtZsRBFZmLiL()
					{
						pgvNzUKwGGexqseQFUnDfWZCxuNj = -1;
						if (LQSeEoDeeQAkkESKtRaFaXfFUtQd != null)
						{
							LQSeEoDeeQAkkESKtRaFaXfFUtQd.Dispose();
						}
					}

					private void bdiSKbWRMceRbjrcHGycaepBcLIOb()
					{
						pgvNzUKwGGexqseQFUnDfWZCxuNj = -1;
						if (LQSeEoDeeQAkkESKtRaFaXfFUtQd != null)
						{
							LQSeEoDeeQAkkESKtRaFaXfFUtQd.Dispose();
						}
					}

					private void NSEhYJxpcrNMFCGQTqlSHorYJuUI()
					{
						pgvNzUKwGGexqseQFUnDfWZCxuNj = -1;
						if (LQSeEoDeeQAkkESKtRaFaXfFUtQd != null)
						{
							LQSeEoDeeQAkkESKtRaFaXfFUtQd.Dispose();
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
						nqVtCBfnsGptzpKyuUnoydZtwUgi nqVtCBfnsGptzpKyuUnoydZtwUgi2;
						if (pgvNzUKwGGexqseQFUnDfWZCxuNj == -2 && ykYamScJIWjjUnowpHAPGYtXqcfzA == Environment.CurrentManagedThreadId)
						{
							pgvNzUKwGGexqseQFUnDfWZCxuNj = 0;
							nqVtCBfnsGptzpKyuUnoydZtwUgi2 = this;
						}
						else
						{
							nqVtCBfnsGptzpKyuUnoydZtwUgi2 = new nqVtCBfnsGptzpKyuUnoydZtwUgi(0);
							nqVtCBfnsGptzpKyuUnoydZtwUgi2.xMCfwuvpzEFISfrNYMTMQXfdCnTdb = xMCfwuvpzEFISfrNYMTMQXfdCnTdb;
						}
						return nqVtCBfnsGptzpKyuUnoydZtwUgi2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class FQCQHRxVhzLBSPMOIfsmTIOvUmnO : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int GaPkaVQHECVTdsHgHDziqjJGaDNbA;

					private ControllerPollingInfo MwcDQtftukvbXEFUwtYRrVETrwZKA;

					private int wDSJOTFfmFjkCquCrILxVQSBGyMd;

					public PollingHelper ObxZSJAkTDEpNUnOQHivKDLAMaIO;

					private IEnumerator<ControllerPollingInfo> tWtcnTvJPYESoHxZNziztydYWixUA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return MwcDQtftukvbXEFUwtYRrVETrwZKA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return MwcDQtftukvbXEFUwtYRrVETrwZKA;
						}
					}

					[DebuggerHidden]
					public FQCQHRxVhzLBSPMOIfsmTIOvUmnO(int P_0)
					{
						GaPkaVQHECVTdsHgHDziqjJGaDNbA = P_0;
						wDSJOTFfmFjkCquCrILxVQSBGyMd = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (GaPkaVQHECVTdsHgHDziqjJGaDNbA)
						{
						case -3:
						case 1:
							try
							{
							}
							finally
							{
								BABPdUmigIgCKhvNniBhCNWsEETd();
							}
							break;
						case -4:
						case 2:
							try
							{
							}
							finally
							{
								StFhyHPwstCNFxcXQdbhZrKCTjVS();
							}
							break;
						case -5:
						case 3:
							try
							{
							}
							finally
							{
								JfEnqaeDNpUwtSxlOHmtoWhqIbTd();
							}
							break;
						case -6:
						case 4:
							try
							{
							}
							finally
							{
								CZdCJZBJcecifxeJPBeQJoHqqZcJ();
							}
							break;
						}
						tWtcnTvJPYESoHxZNziztydYWixUA = null;
						GaPkaVQHECVTdsHgHDziqjJGaDNbA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int gaPkaVQHECVTdsHgHDziqjJGaDNbA = GaPkaVQHECVTdsHgHDziqjJGaDNbA;
							PollingHelper obxZSJAkTDEpNUnOQHivKDLAMaIO = ObxZSJAkTDEpNUnOQHivKDLAMaIO;
							switch (gaPkaVQHECVTdsHgHDziqjJGaDNbA)
							{
							default:
								return false;
							case 0:
								GaPkaVQHECVTdsHgHDziqjJGaDNbA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								tWtcnTvJPYESoHxZNziztydYWixUA = obxZSJAkTDEpNUnOQHivKDLAMaIO.xdbfDSUuExQSVEJEldCMCvMAeDPbb().GetEnumerator();
								GaPkaVQHECVTdsHgHDziqjJGaDNbA = -3;
								goto IL_0088;
							case 1:
								GaPkaVQHECVTdsHgHDziqjJGaDNbA = -3;
								goto IL_0088;
							case 2:
								GaPkaVQHECVTdsHgHDziqjJGaDNbA = -4;
								goto IL_00e8;
							case 3:
								GaPkaVQHECVTdsHgHDziqjJGaDNbA = -5;
								goto IL_0148;
							case 4:
								{
									GaPkaVQHECVTdsHgHDziqjJGaDNbA = -6;
									break;
								}
								IL_00e8:
								if (tWtcnTvJPYESoHxZNziztydYWixUA.MoveNext())
								{
									ControllerPollingInfo current = tWtcnTvJPYESoHxZNziztydYWixUA.Current;
									MwcDQtftukvbXEFUwtYRrVETrwZKA = current;
									GaPkaVQHECVTdsHgHDziqjJGaDNbA = 2;
									return true;
								}
								StFhyHPwstCNFxcXQdbhZrKCTjVS();
								tWtcnTvJPYESoHxZNziztydYWixUA = null;
								tWtcnTvJPYESoHxZNziztydYWixUA = obxZSJAkTDEpNUnOQHivKDLAMaIO.RrViCwtflOZKLWgfJBaXIgkxDfQrA().GetEnumerator();
								GaPkaVQHECVTdsHgHDziqjJGaDNbA = -5;
								goto IL_0148;
								IL_0088:
								if (tWtcnTvJPYESoHxZNziztydYWixUA.MoveNext())
								{
									ControllerPollingInfo current2 = tWtcnTvJPYESoHxZNziztydYWixUA.Current;
									MwcDQtftukvbXEFUwtYRrVETrwZKA = current2;
									GaPkaVQHECVTdsHgHDziqjJGaDNbA = 1;
									return true;
								}
								BABPdUmigIgCKhvNniBhCNWsEETd();
								tWtcnTvJPYESoHxZNziztydYWixUA = null;
								tWtcnTvJPYESoHxZNziztydYWixUA = obxZSJAkTDEpNUnOQHivKDLAMaIO.gzafIWpptaoXzxIXYMCpHwRbFebG().GetEnumerator();
								GaPkaVQHECVTdsHgHDziqjJGaDNbA = -4;
								goto IL_00e8;
								IL_0148:
								if (tWtcnTvJPYESoHxZNziztydYWixUA.MoveNext())
								{
									ControllerPollingInfo current3 = tWtcnTvJPYESoHxZNziztydYWixUA.Current;
									MwcDQtftukvbXEFUwtYRrVETrwZKA = current3;
									GaPkaVQHECVTdsHgHDziqjJGaDNbA = 3;
									return true;
								}
								JfEnqaeDNpUwtSxlOHmtoWhqIbTd();
								tWtcnTvJPYESoHxZNziztydYWixUA = null;
								tWtcnTvJPYESoHxZNziztydYWixUA = obxZSJAkTDEpNUnOQHivKDLAMaIO.ZTqewjDAKeOrbzZapLQogbkxuRGm().GetEnumerator();
								GaPkaVQHECVTdsHgHDziqjJGaDNbA = -6;
								break;
							}
							if (tWtcnTvJPYESoHxZNziztydYWixUA.MoveNext())
							{
								ControllerPollingInfo current4 = tWtcnTvJPYESoHxZNziztydYWixUA.Current;
								MwcDQtftukvbXEFUwtYRrVETrwZKA = current4;
								GaPkaVQHECVTdsHgHDziqjJGaDNbA = 4;
								return true;
							}
							CZdCJZBJcecifxeJPBeQJoHqqZcJ();
							tWtcnTvJPYESoHxZNziztydYWixUA = null;
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

					private void BABPdUmigIgCKhvNniBhCNWsEETd()
					{
						GaPkaVQHECVTdsHgHDziqjJGaDNbA = -1;
						if (tWtcnTvJPYESoHxZNziztydYWixUA != null)
						{
							tWtcnTvJPYESoHxZNziztydYWixUA.Dispose();
						}
					}

					private void StFhyHPwstCNFxcXQdbhZrKCTjVS()
					{
						GaPkaVQHECVTdsHgHDziqjJGaDNbA = -1;
						if (tWtcnTvJPYESoHxZNziztydYWixUA != null)
						{
							tWtcnTvJPYESoHxZNziztydYWixUA.Dispose();
						}
					}

					private void JfEnqaeDNpUwtSxlOHmtoWhqIbTd()
					{
						GaPkaVQHECVTdsHgHDziqjJGaDNbA = -1;
						if (tWtcnTvJPYESoHxZNziztydYWixUA != null)
						{
							tWtcnTvJPYESoHxZNziztydYWixUA.Dispose();
						}
					}

					private void CZdCJZBJcecifxeJPBeQJoHqqZcJ()
					{
						GaPkaVQHECVTdsHgHDziqjJGaDNbA = -1;
						if (tWtcnTvJPYESoHxZNziztydYWixUA != null)
						{
							tWtcnTvJPYESoHxZNziztydYWixUA.Dispose();
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
						FQCQHRxVhzLBSPMOIfsmTIOvUmnO fQCQHRxVhzLBSPMOIfsmTIOvUmnO;
						if (GaPkaVQHECVTdsHgHDziqjJGaDNbA == -2 && wDSJOTFfmFjkCquCrILxVQSBGyMd == Environment.CurrentManagedThreadId)
						{
							GaPkaVQHECVTdsHgHDziqjJGaDNbA = 0;
							fQCQHRxVhzLBSPMOIfsmTIOvUmnO = this;
						}
						else
						{
							fQCQHRxVhzLBSPMOIfsmTIOvUmnO = new FQCQHRxVhzLBSPMOIfsmTIOvUmnO(0);
							fQCQHRxVhzLBSPMOIfsmTIOvUmnO.ObxZSJAkTDEpNUnOQHivKDLAMaIO = ObxZSJAkTDEpNUnOQHivKDLAMaIO;
						}
						return fQCQHRxVhzLBSPMOIfsmTIOvUmnO;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class DIZQshBLQpsdERWWAnHPOqEjDSIj : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int sTnFGzAofqGXtMGWAoejHWjkCgGS;

					private ControllerPollingInfo QUDDaZCAIiPedoCwjaUneOmdOYynA;

					private int CUaAujDfMMnwDrCpJvjwmGgXMHqD;

					private IList<CustomController> PdgPTGVkhJuTKbzzvafPnuvSlYGd;

					private int DZVySgnrdPjTZVUNDRgRrjZzyBFd;

					private IEnumerator<ControllerPollingInfo> YucqtxyjlQeVQAdjHzjcQLIdKnVZ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return QUDDaZCAIiPedoCwjaUneOmdOYynA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return QUDDaZCAIiPedoCwjaUneOmdOYynA;
						}
					}

					[DebuggerHidden]
					public DIZQshBLQpsdERWWAnHPOqEjDSIj(int P_0)
					{
						sTnFGzAofqGXtMGWAoejHWjkCgGS = P_0;
						CUaAujDfMMnwDrCpJvjwmGgXMHqD = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = sTnFGzAofqGXtMGWAoejHWjkCgGS;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								hOPIQxPuxGcPqWPXuOadvYCaJObL();
							}
						}
						PdgPTGVkhJuTKbzzvafPnuvSlYGd = null;
						YucqtxyjlQeVQAdjHzjcQLIdKnVZ = null;
						sTnFGzAofqGXtMGWAoejHWjkCgGS = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = sTnFGzAofqGXtMGWAoejHWjkCgGS;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								sTnFGzAofqGXtMGWAoejHWjkCgGS = -3;
								goto IL_0086;
							}
							sTnFGzAofqGXtMGWAoejHWjkCgGS = -1;
							PdgPTGVkhJuTKbzzvafPnuvSlYGd = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
							DZVySgnrdPjTZVUNDRgRrjZzyBFd = 0;
							goto IL_00b0;
							IL_0086:
							if (YucqtxyjlQeVQAdjHzjcQLIdKnVZ.MoveNext())
							{
								ControllerPollingInfo current = YucqtxyjlQeVQAdjHzjcQLIdKnVZ.Current;
								QUDDaZCAIiPedoCwjaUneOmdOYynA = current;
								sTnFGzAofqGXtMGWAoejHWjkCgGS = 1;
								return true;
							}
							hOPIQxPuxGcPqWPXuOadvYCaJObL();
							YucqtxyjlQeVQAdjHzjcQLIdKnVZ = null;
							DZVySgnrdPjTZVUNDRgRrjZzyBFd++;
							goto IL_00b0;
							IL_00b0:
							if (DZVySgnrdPjTZVUNDRgRrjZzyBFd < PdgPTGVkhJuTKbzzvafPnuvSlYGd.Count)
							{
								YucqtxyjlQeVQAdjHzjcQLIdKnVZ = PdgPTGVkhJuTKbzzvafPnuvSlYGd[DZVySgnrdPjTZVUNDRgRrjZzyBFd].PollForAllAxes().GetEnumerator();
								sTnFGzAofqGXtMGWAoejHWjkCgGS = -3;
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

					private void hOPIQxPuxGcPqWPXuOadvYCaJObL()
					{
						sTnFGzAofqGXtMGWAoejHWjkCgGS = -1;
						if (YucqtxyjlQeVQAdjHzjcQLIdKnVZ != null)
						{
							YucqtxyjlQeVQAdjHzjcQLIdKnVZ.Dispose();
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
						if (sTnFGzAofqGXtMGWAoejHWjkCgGS == -2 && CUaAujDfMMnwDrCpJvjwmGgXMHqD == Environment.CurrentManagedThreadId)
						{
							sTnFGzAofqGXtMGWAoejHWjkCgGS = 0;
							return this;
						}
						return new DIZQshBLQpsdERWWAnHPOqEjDSIj(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class lkIWIgPgwEIGMuYvwfRelwQTolXP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int zVfcLcHBcQJKNQpQmHkZUlQWcPdOA;

					private ControllerPollingInfo iAaSGaYIFgwIRXNSmCKwPrbpfkYGA;

					private int jOtFDdFtfhHSwtwMUdCfHWzEWlOzA;

					private IList<CustomController> yWpdpniPrZNKBsunBvLaOxtIURoD;

					private int OdIQRPeiCMppDpTWrIdqgFdTIUtM;

					private IEnumerator<ControllerPollingInfo> BeGsnAzGgEglCRHSwSLgnxyxMFKn;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return iAaSGaYIFgwIRXNSmCKwPrbpfkYGA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return iAaSGaYIFgwIRXNSmCKwPrbpfkYGA;
						}
					}

					[DebuggerHidden]
					public lkIWIgPgwEIGMuYvwfRelwQTolXP(int P_0)
					{
						zVfcLcHBcQJKNQpQmHkZUlQWcPdOA = P_0;
						jOtFDdFtfhHSwtwMUdCfHWzEWlOzA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = zVfcLcHBcQJKNQpQmHkZUlQWcPdOA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								RhyEEziIiDQlxGwbCzlvwrWsLMqsb();
							}
						}
						yWpdpniPrZNKBsunBvLaOxtIURoD = null;
						BeGsnAzGgEglCRHSwSLgnxyxMFKn = null;
						zVfcLcHBcQJKNQpQmHkZUlQWcPdOA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = zVfcLcHBcQJKNQpQmHkZUlQWcPdOA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								zVfcLcHBcQJKNQpQmHkZUlQWcPdOA = -3;
								goto IL_0086;
							}
							zVfcLcHBcQJKNQpQmHkZUlQWcPdOA = -1;
							yWpdpniPrZNKBsunBvLaOxtIURoD = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
							OdIQRPeiCMppDpTWrIdqgFdTIUtM = 0;
							goto IL_00b0;
							IL_0086:
							if (BeGsnAzGgEglCRHSwSLgnxyxMFKn.MoveNext())
							{
								ControllerPollingInfo current = BeGsnAzGgEglCRHSwSLgnxyxMFKn.Current;
								iAaSGaYIFgwIRXNSmCKwPrbpfkYGA = current;
								zVfcLcHBcQJKNQpQmHkZUlQWcPdOA = 1;
								return true;
							}
							RhyEEziIiDQlxGwbCzlvwrWsLMqsb();
							BeGsnAzGgEglCRHSwSLgnxyxMFKn = null;
							OdIQRPeiCMppDpTWrIdqgFdTIUtM++;
							goto IL_00b0;
							IL_00b0:
							if (OdIQRPeiCMppDpTWrIdqgFdTIUtM < yWpdpniPrZNKBsunBvLaOxtIURoD.Count)
							{
								BeGsnAzGgEglCRHSwSLgnxyxMFKn = yWpdpniPrZNKBsunBvLaOxtIURoD[OdIQRPeiCMppDpTWrIdqgFdTIUtM].PollForAllButtons().GetEnumerator();
								zVfcLcHBcQJKNQpQmHkZUlQWcPdOA = -3;
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

					private void RhyEEziIiDQlxGwbCzlvwrWsLMqsb()
					{
						zVfcLcHBcQJKNQpQmHkZUlQWcPdOA = -1;
						if (BeGsnAzGgEglCRHSwSLgnxyxMFKn != null)
						{
							BeGsnAzGgEglCRHSwSLgnxyxMFKn.Dispose();
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
						if (zVfcLcHBcQJKNQpQmHkZUlQWcPdOA == -2 && jOtFDdFtfhHSwtwMUdCfHWzEWlOzA == Environment.CurrentManagedThreadId)
						{
							zVfcLcHBcQJKNQpQmHkZUlQWcPdOA = 0;
							return this;
						}
						return new lkIWIgPgwEIGMuYvwfRelwQTolXP(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class mvdswMvzxbRElwyhyNaCLReFWLbB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int EhyGWhAATppwJTxcUixngYAxYdXPA;

					private ControllerPollingInfo oNDPPoGMXfgkBjitridOqVZkzpno;

					private int KVbJnZYQRhfOCoMEBkyUxPHduAmp;

					private IList<CustomController> UsKLjeegIGZcXtIMONWxkbIWUrKP;

					private int tNLPIAoxwvJaoNIhTPqkvLwVWqtW;

					private IEnumerator<ControllerPollingInfo> cWbAcHEFqKsPOVOYkisLcobBuoUf;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return oNDPPoGMXfgkBjitridOqVZkzpno;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oNDPPoGMXfgkBjitridOqVZkzpno;
						}
					}

					[DebuggerHidden]
					public mvdswMvzxbRElwyhyNaCLReFWLbB(int P_0)
					{
						EhyGWhAATppwJTxcUixngYAxYdXPA = P_0;
						KVbJnZYQRhfOCoMEBkyUxPHduAmp = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ehyGWhAATppwJTxcUixngYAxYdXPA = EhyGWhAATppwJTxcUixngYAxYdXPA;
						if (ehyGWhAATppwJTxcUixngYAxYdXPA == -3 || ehyGWhAATppwJTxcUixngYAxYdXPA == 1)
						{
							try
							{
							}
							finally
							{
								kfdrVunVZJFUTWonsJNSxHEkLhzI();
							}
						}
						UsKLjeegIGZcXtIMONWxkbIWUrKP = null;
						cWbAcHEFqKsPOVOYkisLcobBuoUf = null;
						EhyGWhAATppwJTxcUixngYAxYdXPA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int ehyGWhAATppwJTxcUixngYAxYdXPA = EhyGWhAATppwJTxcUixngYAxYdXPA;
							if (ehyGWhAATppwJTxcUixngYAxYdXPA != 0)
							{
								if (ehyGWhAATppwJTxcUixngYAxYdXPA != 1)
								{
									return false;
								}
								EhyGWhAATppwJTxcUixngYAxYdXPA = -3;
								goto IL_0086;
							}
							EhyGWhAATppwJTxcUixngYAxYdXPA = -1;
							UsKLjeegIGZcXtIMONWxkbIWUrKP = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
							tNLPIAoxwvJaoNIhTPqkvLwVWqtW = 0;
							goto IL_00b0;
							IL_0086:
							if (cWbAcHEFqKsPOVOYkisLcobBuoUf.MoveNext())
							{
								ControllerPollingInfo current = cWbAcHEFqKsPOVOYkisLcobBuoUf.Current;
								oNDPPoGMXfgkBjitridOqVZkzpno = current;
								EhyGWhAATppwJTxcUixngYAxYdXPA = 1;
								return true;
							}
							kfdrVunVZJFUTWonsJNSxHEkLhzI();
							cWbAcHEFqKsPOVOYkisLcobBuoUf = null;
							tNLPIAoxwvJaoNIhTPqkvLwVWqtW++;
							goto IL_00b0;
							IL_00b0:
							if (tNLPIAoxwvJaoNIhTPqkvLwVWqtW < UsKLjeegIGZcXtIMONWxkbIWUrKP.Count)
							{
								cWbAcHEFqKsPOVOYkisLcobBuoUf = UsKLjeegIGZcXtIMONWxkbIWUrKP[tNLPIAoxwvJaoNIhTPqkvLwVWqtW].PollForAllButtonsDown().GetEnumerator();
								EhyGWhAATppwJTxcUixngYAxYdXPA = -3;
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

					private void kfdrVunVZJFUTWonsJNSxHEkLhzI()
					{
						EhyGWhAATppwJTxcUixngYAxYdXPA = -1;
						if (cWbAcHEFqKsPOVOYkisLcobBuoUf != null)
						{
							cWbAcHEFqKsPOVOYkisLcobBuoUf.Dispose();
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
						if (EhyGWhAATppwJTxcUixngYAxYdXPA == -2 && KVbJnZYQRhfOCoMEBkyUxPHduAmp == Environment.CurrentManagedThreadId)
						{
							EhyGWhAATppwJTxcUixngYAxYdXPA = 0;
							return this;
						}
						return new mvdswMvzxbRElwyhyNaCLReFWLbB(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class FUarClvkzUEYNReknYXeKCmkbedJA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ZLoZhmeQtPeCgJOgObSKglNHAxxEb;

					private ControllerPollingInfo evXhSPgfZCBGDZItaChCOdWyxWkp;

					private int gKYesaFRGzMWtZVxKwYvImvPMCveb;

					private IList<CustomController> zildyPyphBegLcgtGDAZxHBitIxE;

					private int ONNYySrbgFhUdoxzRyoCEhaPRtie;

					private IEnumerator<ControllerPollingInfo> IzSvIRlKaVRtjwoLgMclMnfmNpoj;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return evXhSPgfZCBGDZItaChCOdWyxWkp;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return evXhSPgfZCBGDZItaChCOdWyxWkp;
						}
					}

					[DebuggerHidden]
					public FUarClvkzUEYNReknYXeKCmkbedJA(int P_0)
					{
						ZLoZhmeQtPeCgJOgObSKglNHAxxEb = P_0;
						gKYesaFRGzMWtZVxKwYvImvPMCveb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int zLoZhmeQtPeCgJOgObSKglNHAxxEb = ZLoZhmeQtPeCgJOgObSKglNHAxxEb;
						if (zLoZhmeQtPeCgJOgObSKglNHAxxEb == -3 || zLoZhmeQtPeCgJOgObSKglNHAxxEb == 1)
						{
							try
							{
							}
							finally
							{
								QpPAPuwtQtwlxxFBHaquWXWiqiZH();
							}
						}
						zildyPyphBegLcgtGDAZxHBitIxE = null;
						IzSvIRlKaVRtjwoLgMclMnfmNpoj = null;
						ZLoZhmeQtPeCgJOgObSKglNHAxxEb = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int zLoZhmeQtPeCgJOgObSKglNHAxxEb = ZLoZhmeQtPeCgJOgObSKglNHAxxEb;
							if (zLoZhmeQtPeCgJOgObSKglNHAxxEb != 0)
							{
								if (zLoZhmeQtPeCgJOgObSKglNHAxxEb != 1)
								{
									return false;
								}
								ZLoZhmeQtPeCgJOgObSKglNHAxxEb = -3;
								goto IL_0086;
							}
							ZLoZhmeQtPeCgJOgObSKglNHAxxEb = -1;
							zildyPyphBegLcgtGDAZxHBitIxE = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
							ONNYySrbgFhUdoxzRyoCEhaPRtie = 0;
							goto IL_00b0;
							IL_0086:
							if (IzSvIRlKaVRtjwoLgMclMnfmNpoj.MoveNext())
							{
								ControllerPollingInfo current = IzSvIRlKaVRtjwoLgMclMnfmNpoj.Current;
								evXhSPgfZCBGDZItaChCOdWyxWkp = current;
								ZLoZhmeQtPeCgJOgObSKglNHAxxEb = 1;
								return true;
							}
							QpPAPuwtQtwlxxFBHaquWXWiqiZH();
							IzSvIRlKaVRtjwoLgMclMnfmNpoj = null;
							ONNYySrbgFhUdoxzRyoCEhaPRtie++;
							goto IL_00b0;
							IL_00b0:
							if (ONNYySrbgFhUdoxzRyoCEhaPRtie < zildyPyphBegLcgtGDAZxHBitIxE.Count)
							{
								IzSvIRlKaVRtjwoLgMclMnfmNpoj = zildyPyphBegLcgtGDAZxHBitIxE[ONNYySrbgFhUdoxzRyoCEhaPRtie].PollForAllElements().GetEnumerator();
								ZLoZhmeQtPeCgJOgObSKglNHAxxEb = -3;
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

					private void QpPAPuwtQtwlxxFBHaquWXWiqiZH()
					{
						ZLoZhmeQtPeCgJOgObSKglNHAxxEb = -1;
						if (IzSvIRlKaVRtjwoLgMclMnfmNpoj != null)
						{
							IzSvIRlKaVRtjwoLgMclMnfmNpoj.Dispose();
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
						if (ZLoZhmeQtPeCgJOgObSKglNHAxxEb == -2 && gKYesaFRGzMWtZVxKwYvImvPMCveb == Environment.CurrentManagedThreadId)
						{
							ZLoZhmeQtPeCgJOgObSKglNHAxxEb = 0;
							return this;
						}
						return new FUarClvkzUEYNReknYXeKCmkbedJA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class pAyknxkkuCnsqiuzlrTlHqfUZubK : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int XHlVFaLudHUFXVdYaDhLiHqrKXRv;

					private ControllerPollingInfo uwsSTyqiYBAhVpAVTNZpKOnrHGQA;

					private int jxJXoVBNmkwzsoMJscBptqUEKPFC;

					private IList<CustomController> eCMsNXJqHMaCzJWUDAwxhJQJxfZtA;

					private int qbfsceIzinMPCiiZnSTsHSiqoDMl;

					private IEnumerator<ControllerPollingInfo> HxrSkPoDjAoSegxdjbFOYKoKtoqw;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return uwsSTyqiYBAhVpAVTNZpKOnrHGQA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return uwsSTyqiYBAhVpAVTNZpKOnrHGQA;
						}
					}

					[DebuggerHidden]
					public pAyknxkkuCnsqiuzlrTlHqfUZubK(int P_0)
					{
						XHlVFaLudHUFXVdYaDhLiHqrKXRv = P_0;
						jxJXoVBNmkwzsoMJscBptqUEKPFC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int xHlVFaLudHUFXVdYaDhLiHqrKXRv = XHlVFaLudHUFXVdYaDhLiHqrKXRv;
						if (xHlVFaLudHUFXVdYaDhLiHqrKXRv == -3 || xHlVFaLudHUFXVdYaDhLiHqrKXRv == 1)
						{
							try
							{
							}
							finally
							{
								BVvpIVXfwVppBTNxaCtMDUeafoPh();
							}
						}
						eCMsNXJqHMaCzJWUDAwxhJQJxfZtA = null;
						HxrSkPoDjAoSegxdjbFOYKoKtoqw = null;
						XHlVFaLudHUFXVdYaDhLiHqrKXRv = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int xHlVFaLudHUFXVdYaDhLiHqrKXRv = XHlVFaLudHUFXVdYaDhLiHqrKXRv;
							if (xHlVFaLudHUFXVdYaDhLiHqrKXRv != 0)
							{
								if (xHlVFaLudHUFXVdYaDhLiHqrKXRv != 1)
								{
									return false;
								}
								XHlVFaLudHUFXVdYaDhLiHqrKXRv = -3;
								goto IL_0086;
							}
							XHlVFaLudHUFXVdYaDhLiHqrKXRv = -1;
							eCMsNXJqHMaCzJWUDAwxhJQJxfZtA = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
							qbfsceIzinMPCiiZnSTsHSiqoDMl = 0;
							goto IL_00b0;
							IL_0086:
							if (HxrSkPoDjAoSegxdjbFOYKoKtoqw.MoveNext())
							{
								ControllerPollingInfo current = HxrSkPoDjAoSegxdjbFOYKoKtoqw.Current;
								uwsSTyqiYBAhVpAVTNZpKOnrHGQA = current;
								XHlVFaLudHUFXVdYaDhLiHqrKXRv = 1;
								return true;
							}
							BVvpIVXfwVppBTNxaCtMDUeafoPh();
							HxrSkPoDjAoSegxdjbFOYKoKtoqw = null;
							qbfsceIzinMPCiiZnSTsHSiqoDMl++;
							goto IL_00b0;
							IL_00b0:
							if (qbfsceIzinMPCiiZnSTsHSiqoDMl < eCMsNXJqHMaCzJWUDAwxhJQJxfZtA.Count)
							{
								HxrSkPoDjAoSegxdjbFOYKoKtoqw = eCMsNXJqHMaCzJWUDAwxhJQJxfZtA[qbfsceIzinMPCiiZnSTsHSiqoDMl].PollForAllElementsDown().GetEnumerator();
								XHlVFaLudHUFXVdYaDhLiHqrKXRv = -3;
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

					private void BVvpIVXfwVppBTNxaCtMDUeafoPh()
					{
						XHlVFaLudHUFXVdYaDhLiHqrKXRv = -1;
						if (HxrSkPoDjAoSegxdjbFOYKoKtoqw != null)
						{
							HxrSkPoDjAoSegxdjbFOYKoKtoqw.Dispose();
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
						if (XHlVFaLudHUFXVdYaDhLiHqrKXRv == -2 && jxJXoVBNmkwzsoMJscBptqUEKPFC == Environment.CurrentManagedThreadId)
						{
							XHlVFaLudHUFXVdYaDhLiHqrKXRv = 0;
							return this;
						}
						return new pAyknxkkuCnsqiuzlrTlHqfUZubK(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class bWmXvDGUMiQUFXbbNxhJhZDpiQvp : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int CRYmNTvHTACbqgoVcISxcMDJDOXF;

					private ControllerPollingInfo DCwbUFVumaTuboiXyhXkWdCjjJps;

					private int TcCZcJzENuZeLbnfmNDxYbSYogqK;

					private IList<Joystick> zlXcbKDfRbLPRTALLtgGmvFTnvYDA;

					private int MGVFIVmMIrZvwxeDwCHOaCxRBIcAA;

					private IEnumerator<ControllerPollingInfo> RQSkBDeuKDwjEGVbBygQbiZesofI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DCwbUFVumaTuboiXyhXkWdCjjJps;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DCwbUFVumaTuboiXyhXkWdCjjJps;
						}
					}

					[DebuggerHidden]
					public bWmXvDGUMiQUFXbbNxhJhZDpiQvp(int P_0)
					{
						CRYmNTvHTACbqgoVcISxcMDJDOXF = P_0;
						TcCZcJzENuZeLbnfmNDxYbSYogqK = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int cRYmNTvHTACbqgoVcISxcMDJDOXF = CRYmNTvHTACbqgoVcISxcMDJDOXF;
						if (cRYmNTvHTACbqgoVcISxcMDJDOXF == -3 || cRYmNTvHTACbqgoVcISxcMDJDOXF == 1)
						{
							try
							{
							}
							finally
							{
								IzNzmiojmhttZIhdFFVxmpMnCcsHA();
							}
						}
						zlXcbKDfRbLPRTALLtgGmvFTnvYDA = null;
						RQSkBDeuKDwjEGVbBygQbiZesofI = null;
						CRYmNTvHTACbqgoVcISxcMDJDOXF = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int cRYmNTvHTACbqgoVcISxcMDJDOXF = CRYmNTvHTACbqgoVcISxcMDJDOXF;
							if (cRYmNTvHTACbqgoVcISxcMDJDOXF != 0)
							{
								if (cRYmNTvHTACbqgoVcISxcMDJDOXF != 1)
								{
									return false;
								}
								CRYmNTvHTACbqgoVcISxcMDJDOXF = -3;
								goto IL_0086;
							}
							CRYmNTvHTACbqgoVcISxcMDJDOXF = -1;
							zlXcbKDfRbLPRTALLtgGmvFTnvYDA = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
							MGVFIVmMIrZvwxeDwCHOaCxRBIcAA = 0;
							goto IL_00b0;
							IL_0086:
							if (RQSkBDeuKDwjEGVbBygQbiZesofI.MoveNext())
							{
								ControllerPollingInfo current = RQSkBDeuKDwjEGVbBygQbiZesofI.Current;
								DCwbUFVumaTuboiXyhXkWdCjjJps = current;
								CRYmNTvHTACbqgoVcISxcMDJDOXF = 1;
								return true;
							}
							IzNzmiojmhttZIhdFFVxmpMnCcsHA();
							RQSkBDeuKDwjEGVbBygQbiZesofI = null;
							MGVFIVmMIrZvwxeDwCHOaCxRBIcAA++;
							goto IL_00b0;
							IL_00b0:
							if (MGVFIVmMIrZvwxeDwCHOaCxRBIcAA < zlXcbKDfRbLPRTALLtgGmvFTnvYDA.Count)
							{
								RQSkBDeuKDwjEGVbBygQbiZesofI = zlXcbKDfRbLPRTALLtgGmvFTnvYDA[MGVFIVmMIrZvwxeDwCHOaCxRBIcAA].PollForAllAxes().GetEnumerator();
								CRYmNTvHTACbqgoVcISxcMDJDOXF = -3;
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

					private void IzNzmiojmhttZIhdFFVxmpMnCcsHA()
					{
						CRYmNTvHTACbqgoVcISxcMDJDOXF = -1;
						if (RQSkBDeuKDwjEGVbBygQbiZesofI != null)
						{
							RQSkBDeuKDwjEGVbBygQbiZesofI.Dispose();
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
						if (CRYmNTvHTACbqgoVcISxcMDJDOXF == -2 && TcCZcJzENuZeLbnfmNDxYbSYogqK == Environment.CurrentManagedThreadId)
						{
							CRYmNTvHTACbqgoVcISxcMDJDOXF = 0;
							return this;
						}
						return new bWmXvDGUMiQUFXbbNxhJhZDpiQvp(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class DsUcoievEEDcNQurRZitEDHPIhqx : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ehocwHOBhQcynJuZclZqcbjKQXnQ;

					private ControllerPollingInfo eqSiLePNaCkJpHdgDIpXcOdyvkSrA;

					private int fnaDmBqjLBhAJrOhZEDmqKcrkXjo;

					private IList<Joystick> TSDToaYAizGTHRDAWljOFyrKQQcQ;

					private int cAExIgkrOHSHtRMrxDHpdMGDJnbiA;

					private IEnumerator<ControllerPollingInfo> mipigBrCfwyWDJRAzgDftmoqtSQk;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return eqSiLePNaCkJpHdgDIpXcOdyvkSrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return eqSiLePNaCkJpHdgDIpXcOdyvkSrA;
						}
					}

					[DebuggerHidden]
					public DsUcoievEEDcNQurRZitEDHPIhqx(int P_0)
					{
						ehocwHOBhQcynJuZclZqcbjKQXnQ = P_0;
						fnaDmBqjLBhAJrOhZEDmqKcrkXjo = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = ehocwHOBhQcynJuZclZqcbjKQXnQ;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								bXFjorrIjEKxRZDQgceEiasdbUZKA();
							}
						}
						TSDToaYAizGTHRDAWljOFyrKQQcQ = null;
						mipigBrCfwyWDJRAzgDftmoqtSQk = null;
						ehocwHOBhQcynJuZclZqcbjKQXnQ = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = ehocwHOBhQcynJuZclZqcbjKQXnQ;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								ehocwHOBhQcynJuZclZqcbjKQXnQ = -3;
								goto IL_0086;
							}
							ehocwHOBhQcynJuZclZqcbjKQXnQ = -1;
							TSDToaYAizGTHRDAWljOFyrKQQcQ = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
							cAExIgkrOHSHtRMrxDHpdMGDJnbiA = 0;
							goto IL_00b0;
							IL_0086:
							if (mipigBrCfwyWDJRAzgDftmoqtSQk.MoveNext())
							{
								ControllerPollingInfo current = mipigBrCfwyWDJRAzgDftmoqtSQk.Current;
								eqSiLePNaCkJpHdgDIpXcOdyvkSrA = current;
								ehocwHOBhQcynJuZclZqcbjKQXnQ = 1;
								return true;
							}
							bXFjorrIjEKxRZDQgceEiasdbUZKA();
							mipigBrCfwyWDJRAzgDftmoqtSQk = null;
							cAExIgkrOHSHtRMrxDHpdMGDJnbiA++;
							goto IL_00b0;
							IL_00b0:
							if (cAExIgkrOHSHtRMrxDHpdMGDJnbiA < TSDToaYAizGTHRDAWljOFyrKQQcQ.Count)
							{
								mipigBrCfwyWDJRAzgDftmoqtSQk = TSDToaYAizGTHRDAWljOFyrKQQcQ[cAExIgkrOHSHtRMrxDHpdMGDJnbiA].PollForAllButtons().GetEnumerator();
								ehocwHOBhQcynJuZclZqcbjKQXnQ = -3;
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

					private void bXFjorrIjEKxRZDQgceEiasdbUZKA()
					{
						ehocwHOBhQcynJuZclZqcbjKQXnQ = -1;
						if (mipigBrCfwyWDJRAzgDftmoqtSQk != null)
						{
							mipigBrCfwyWDJRAzgDftmoqtSQk.Dispose();
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
						if (ehocwHOBhQcynJuZclZqcbjKQXnQ == -2 && fnaDmBqjLBhAJrOhZEDmqKcrkXjo == Environment.CurrentManagedThreadId)
						{
							ehocwHOBhQcynJuZclZqcbjKQXnQ = 0;
							return this;
						}
						return new DsUcoievEEDcNQurRZitEDHPIhqx(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class qCSEDUKzTGqIiBtNGmXRpALJLknG : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int uYMzfDnPNHigKpkrVyNMmVGlNZyN;

					private ControllerPollingInfo uswCSHpxXuLuBdYELqlQEqvwLRZN;

					private int UDCFdeVvnaCdNVbHHgeWiHYjIzheA;

					private IList<Joystick> CscDOryFhxAYfCLrsiZvTgvuUhrv;

					private int qUzQJLyTcwKvPIswJlAskUPzvLho;

					private IEnumerator<ControllerPollingInfo> njdYtSRlmdDkFboHMNzCFNvAywLIb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return uswCSHpxXuLuBdYELqlQEqvwLRZN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return uswCSHpxXuLuBdYELqlQEqvwLRZN;
						}
					}

					[DebuggerHidden]
					public qCSEDUKzTGqIiBtNGmXRpALJLknG(int P_0)
					{
						uYMzfDnPNHigKpkrVyNMmVGlNZyN = P_0;
						UDCFdeVvnaCdNVbHHgeWiHYjIzheA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = uYMzfDnPNHigKpkrVyNMmVGlNZyN;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								xaLkEaolaQJOXQnZNPFiNvrbfcTO();
							}
						}
						CscDOryFhxAYfCLrsiZvTgvuUhrv = null;
						njdYtSRlmdDkFboHMNzCFNvAywLIb = null;
						uYMzfDnPNHigKpkrVyNMmVGlNZyN = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = uYMzfDnPNHigKpkrVyNMmVGlNZyN;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								uYMzfDnPNHigKpkrVyNMmVGlNZyN = -3;
								goto IL_0086;
							}
							uYMzfDnPNHigKpkrVyNMmVGlNZyN = -1;
							CscDOryFhxAYfCLrsiZvTgvuUhrv = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
							qUzQJLyTcwKvPIswJlAskUPzvLho = 0;
							goto IL_00b0;
							IL_0086:
							if (njdYtSRlmdDkFboHMNzCFNvAywLIb.MoveNext())
							{
								ControllerPollingInfo current = njdYtSRlmdDkFboHMNzCFNvAywLIb.Current;
								uswCSHpxXuLuBdYELqlQEqvwLRZN = current;
								uYMzfDnPNHigKpkrVyNMmVGlNZyN = 1;
								return true;
							}
							xaLkEaolaQJOXQnZNPFiNvrbfcTO();
							njdYtSRlmdDkFboHMNzCFNvAywLIb = null;
							qUzQJLyTcwKvPIswJlAskUPzvLho++;
							goto IL_00b0;
							IL_00b0:
							if (qUzQJLyTcwKvPIswJlAskUPzvLho < CscDOryFhxAYfCLrsiZvTgvuUhrv.Count)
							{
								njdYtSRlmdDkFboHMNzCFNvAywLIb = CscDOryFhxAYfCLrsiZvTgvuUhrv[qUzQJLyTcwKvPIswJlAskUPzvLho].PollForAllButtonsDown().GetEnumerator();
								uYMzfDnPNHigKpkrVyNMmVGlNZyN = -3;
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

					private void xaLkEaolaQJOXQnZNPFiNvrbfcTO()
					{
						uYMzfDnPNHigKpkrVyNMmVGlNZyN = -1;
						if (njdYtSRlmdDkFboHMNzCFNvAywLIb != null)
						{
							njdYtSRlmdDkFboHMNzCFNvAywLIb.Dispose();
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
						if (uYMzfDnPNHigKpkrVyNMmVGlNZyN == -2 && UDCFdeVvnaCdNVbHHgeWiHYjIzheA == Environment.CurrentManagedThreadId)
						{
							uYMzfDnPNHigKpkrVyNMmVGlNZyN = 0;
							return this;
						}
						return new qCSEDUKzTGqIiBtNGmXRpALJLknG(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class AQOeFtEfJmBKsRLJVfgRYDIoHYTnA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int HddlVBfZwFmQCawRZmroYhzjjUCl;

					private ControllerPollingInfo PNtEIuIzHxlquZBOCbkIgprkyLCUA;

					private int pAMvaEZHDLaWRuwWGSegFnwDgIGt;

					private IList<Joystick> flIVtQkqouXDepKpLMuyipmQYFuH;

					private int VtXCjqFNGaCJocvjrBRpwPAWfmHX;

					private IEnumerator<ControllerPollingInfo> nFLrHlOtmZbuIjJtRjeTcIAmegaj;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PNtEIuIzHxlquZBOCbkIgprkyLCUA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PNtEIuIzHxlquZBOCbkIgprkyLCUA;
						}
					}

					[DebuggerHidden]
					public AQOeFtEfJmBKsRLJVfgRYDIoHYTnA(int P_0)
					{
						HddlVBfZwFmQCawRZmroYhzjjUCl = P_0;
						pAMvaEZHDLaWRuwWGSegFnwDgIGt = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int hddlVBfZwFmQCawRZmroYhzjjUCl = HddlVBfZwFmQCawRZmroYhzjjUCl;
						if (hddlVBfZwFmQCawRZmroYhzjjUCl == -3 || hddlVBfZwFmQCawRZmroYhzjjUCl == 1)
						{
							try
							{
							}
							finally
							{
								dUYOxQItKKJiaqOcJtIMuRquLiAX();
							}
						}
						flIVtQkqouXDepKpLMuyipmQYFuH = null;
						nFLrHlOtmZbuIjJtRjeTcIAmegaj = null;
						HddlVBfZwFmQCawRZmroYhzjjUCl = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int hddlVBfZwFmQCawRZmroYhzjjUCl = HddlVBfZwFmQCawRZmroYhzjjUCl;
							if (hddlVBfZwFmQCawRZmroYhzjjUCl != 0)
							{
								if (hddlVBfZwFmQCawRZmroYhzjjUCl != 1)
								{
									return false;
								}
								HddlVBfZwFmQCawRZmroYhzjjUCl = -3;
								goto IL_0086;
							}
							HddlVBfZwFmQCawRZmroYhzjjUCl = -1;
							flIVtQkqouXDepKpLMuyipmQYFuH = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
							VtXCjqFNGaCJocvjrBRpwPAWfmHX = 0;
							goto IL_00b0;
							IL_0086:
							if (nFLrHlOtmZbuIjJtRjeTcIAmegaj.MoveNext())
							{
								ControllerPollingInfo current = nFLrHlOtmZbuIjJtRjeTcIAmegaj.Current;
								PNtEIuIzHxlquZBOCbkIgprkyLCUA = current;
								HddlVBfZwFmQCawRZmroYhzjjUCl = 1;
								return true;
							}
							dUYOxQItKKJiaqOcJtIMuRquLiAX();
							nFLrHlOtmZbuIjJtRjeTcIAmegaj = null;
							VtXCjqFNGaCJocvjrBRpwPAWfmHX++;
							goto IL_00b0;
							IL_00b0:
							if (VtXCjqFNGaCJocvjrBRpwPAWfmHX < flIVtQkqouXDepKpLMuyipmQYFuH.Count)
							{
								nFLrHlOtmZbuIjJtRjeTcIAmegaj = flIVtQkqouXDepKpLMuyipmQYFuH[VtXCjqFNGaCJocvjrBRpwPAWfmHX].PollForAllElements().GetEnumerator();
								HddlVBfZwFmQCawRZmroYhzjjUCl = -3;
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

					private void dUYOxQItKKJiaqOcJtIMuRquLiAX()
					{
						HddlVBfZwFmQCawRZmroYhzjjUCl = -1;
						if (nFLrHlOtmZbuIjJtRjeTcIAmegaj != null)
						{
							nFLrHlOtmZbuIjJtRjeTcIAmegaj.Dispose();
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
						if (HddlVBfZwFmQCawRZmroYhzjjUCl == -2 && pAMvaEZHDLaWRuwWGSegFnwDgIGt == Environment.CurrentManagedThreadId)
						{
							HddlVBfZwFmQCawRZmroYhzjjUCl = 0;
							return this;
						}
						return new AQOeFtEfJmBKsRLJVfgRYDIoHYTnA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class MaDcytLUIQIqYQdpmiGgHdutfsGE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int TjMgrSIHhycUhEygWdjvhVzMOovn;

					private ControllerPollingInfo ATtkUSPApUXltrnZlGLwraQwsRLH;

					private int BRGygUqpxaVpsgdNqJdXnrRhPMey;

					private IList<Joystick> UkJPcngXRHQSGhitrvFCUmWnIwMJ;

					private int YQjYruxYVUqVEnOOmlakbPyextXr;

					private IEnumerator<ControllerPollingInfo> ijTBqVVeDzKbcToRMmEGLcOGjGefA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ATtkUSPApUXltrnZlGLwraQwsRLH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ATtkUSPApUXltrnZlGLwraQwsRLH;
						}
					}

					[DebuggerHidden]
					public MaDcytLUIQIqYQdpmiGgHdutfsGE(int P_0)
					{
						TjMgrSIHhycUhEygWdjvhVzMOovn = P_0;
						BRGygUqpxaVpsgdNqJdXnrRhPMey = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int tjMgrSIHhycUhEygWdjvhVzMOovn = TjMgrSIHhycUhEygWdjvhVzMOovn;
						if (tjMgrSIHhycUhEygWdjvhVzMOovn == -3 || tjMgrSIHhycUhEygWdjvhVzMOovn == 1)
						{
							try
							{
							}
							finally
							{
								iyXZROLLWIDMHKkIuIOiIcBvcRvQA();
							}
						}
						UkJPcngXRHQSGhitrvFCUmWnIwMJ = null;
						ijTBqVVeDzKbcToRMmEGLcOGjGefA = null;
						TjMgrSIHhycUhEygWdjvhVzMOovn = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int tjMgrSIHhycUhEygWdjvhVzMOovn = TjMgrSIHhycUhEygWdjvhVzMOovn;
							if (tjMgrSIHhycUhEygWdjvhVzMOovn != 0)
							{
								if (tjMgrSIHhycUhEygWdjvhVzMOovn != 1)
								{
									return false;
								}
								TjMgrSIHhycUhEygWdjvhVzMOovn = -3;
								goto IL_0086;
							}
							TjMgrSIHhycUhEygWdjvhVzMOovn = -1;
							UkJPcngXRHQSGhitrvFCUmWnIwMJ = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
							YQjYruxYVUqVEnOOmlakbPyextXr = 0;
							goto IL_00b0;
							IL_0086:
							if (ijTBqVVeDzKbcToRMmEGLcOGjGefA.MoveNext())
							{
								ControllerPollingInfo current = ijTBqVVeDzKbcToRMmEGLcOGjGefA.Current;
								ATtkUSPApUXltrnZlGLwraQwsRLH = current;
								TjMgrSIHhycUhEygWdjvhVzMOovn = 1;
								return true;
							}
							iyXZROLLWIDMHKkIuIOiIcBvcRvQA();
							ijTBqVVeDzKbcToRMmEGLcOGjGefA = null;
							YQjYruxYVUqVEnOOmlakbPyextXr++;
							goto IL_00b0;
							IL_00b0:
							if (YQjYruxYVUqVEnOOmlakbPyextXr < UkJPcngXRHQSGhitrvFCUmWnIwMJ.Count)
							{
								ijTBqVVeDzKbcToRMmEGLcOGjGefA = UkJPcngXRHQSGhitrvFCUmWnIwMJ[YQjYruxYVUqVEnOOmlakbPyextXr].PollForAllElementsDown().GetEnumerator();
								TjMgrSIHhycUhEygWdjvhVzMOovn = -3;
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

					private void iyXZROLLWIDMHKkIuIOiIcBvcRvQA()
					{
						TjMgrSIHhycUhEygWdjvhVzMOovn = -1;
						if (ijTBqVVeDzKbcToRMmEGLcOGjGefA != null)
						{
							ijTBqVVeDzKbcToRMmEGLcOGjGefA.Dispose();
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
						if (TjMgrSIHhycUhEygWdjvhVzMOovn == -2 && BRGygUqpxaVpsgdNqJdXnrRhPMey == Environment.CurrentManagedThreadId)
						{
							TjMgrSIHhycUhEygWdjvhVzMOovn = 0;
							return this;
						}
						return new MaDcytLUIQIqYQdpmiGgHdutfsGE(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private static PollingHelper uycThavfcLSNVlHEJLhpSTxFchat;

				internal static PollingHelper lNSgwWgfjIjIYHBMJCfEpNjStetc => uycThavfcLSNVlHEJLhpSTxFchat ?? (uycThavfcLSNVlHEJLhpSTxFchat = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = ZbalqzMnlkaqKTFjJFHJKzhFhJDn();
					if (result.success)
					{
						return result;
					}
					result = lXWxBSIvuHEuKAhEJBbiyllwKRUv();
					if (result.success)
					{
						return result;
					}
					result = vdBmjdsakpVTNdcHkbZINgrwPeVA();
					if (result.success)
					{
						return result;
					}
					result = aABjreQBSuWATGYBwgzKQYHGTiXm();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = xRrelilANKkqAUdcQUfoopJeaIcfA();
					if (result.success)
					{
						return result;
					}
					result = PiJIYytuWgLVDeTvsifTnWEuijvX();
					if (result.success)
					{
						return result;
					}
					result = vejbfjeaQjDnopVObqkfVHsNgneWA();
					if (result.success)
					{
						return result;
					}
					result = shzXNSjJOZjQKGdkgktcKBktSLso();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = WcGIUEticVNdqcpygXdiQVvjLDMA();
					if (result.success)
					{
						return result;
					}
					result = lXWxBSIvuHEuKAhEJBbiyllwKRUv();
					if (result.success)
					{
						return result;
					}
					result = IblkfbAEDuwgTJqeYvHEDCbGyZwL();
					if (result.success)
					{
						return result;
					}
					result = daNJitgmPbEyxEvcvfFDmsqPSnbCA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = ppfpVLgQdoAnmeJsICEXPKjVCHWO();
					if (result.success)
					{
						return result;
					}
					result = PiJIYytuWgLVDeTvsifTnWEuijvX();
					if (result.success)
					{
						return result;
					}
					result = bqmvBNfwmxdnOXsDpehFmsUwmFoh();
					if (result.success)
					{
						return result;
					}
					result = JsozJSDNbUtDzIuAqDLgnYsbSTWO();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					ControllerPollingInfo result = ctdyOlGXTeDkbzcMRZqYPqqELBYt();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					if (result.success)
					{
						return result;
					}
					result = RGiBjVEVgkBdoVzqDkEtGAUjDGfVA();
					if (result.success)
					{
						return result;
					}
					result = fpLQPPvrwhAlAeKgIoSaJOwZdDJjA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => ZbalqzMnlkaqKTFjJFHJKzhFhJDn(), 
						ControllerType.Keyboard => lXWxBSIvuHEuKAhEJBbiyllwKRUv(), 
						ControllerType.Mouse => vdBmjdsakpVTNdcHkbZINgrwPeVA(), 
						ControllerType.Custom => aABjreQBSuWATGYBwgzKQYHGTiXm(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => xRrelilANKkqAUdcQUfoopJeaIcfA(), 
						ControllerType.Keyboard => PiJIYytuWgLVDeTvsifTnWEuijvX(), 
						ControllerType.Mouse => vejbfjeaQjDnopVObqkfVHsNgneWA(), 
						ControllerType.Custom => shzXNSjJOZjQKGdkgktcKBktSLso(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => WcGIUEticVNdqcpygXdiQVvjLDMA(), 
						ControllerType.Keyboard => lXWxBSIvuHEuKAhEJBbiyllwKRUv(), 
						ControllerType.Mouse => IblkfbAEDuwgTJqeYvHEDCbGyZwL(), 
						ControllerType.Custom => daNJitgmPbEyxEvcvfFDmsqPSnbCA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => ppfpVLgQdoAnmeJsICEXPKjVCHWO(), 
						ControllerType.Keyboard => PiJIYytuWgLVDeTvsifTnWEuijvX(), 
						ControllerType.Mouse => bqmvBNfwmxdnOXsDpehFmsUwmFoh(), 
						ControllerType.Custom => JsozJSDNbUtDzIuAqDLgnYsbSTWO(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => ctdyOlGXTeDkbzcMRZqYPqqELBYt(), 
						ControllerType.Keyboard => ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY(), 
						ControllerType.Mouse => RGiBjVEVgkBdoVzqDkEtGAUjDGfVA(), 
						ControllerType.Custom => fpLQPPvrwhAlAeKgIoSaJOwZdDJjA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => RJBsBnNnQgRmIZQBXfryNAjwSYsp(controllerId), 
						ControllerType.Keyboard => lXWxBSIvuHEuKAhEJBbiyllwKRUv(), 
						ControllerType.Mouse => vdBmjdsakpVTNdcHkbZINgrwPeVA(), 
						ControllerType.Custom => meLSsUcXtPMnKdPRLyiFiKTWjrOe(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => IRCnnnZrBZRDxXKjkffIbUhJCLVyA(controllerId), 
						ControllerType.Keyboard => PiJIYytuWgLVDeTvsifTnWEuijvX(), 
						ControllerType.Mouse => vejbfjeaQjDnopVObqkfVHsNgneWA(), 
						ControllerType.Custom => islRaqyMiSjkWtNIKxGPbWMTiocQ(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => xldgQSJRkOgxgtxlahJrDQhdhHxi(controllerId), 
						ControllerType.Keyboard => lXWxBSIvuHEuKAhEJBbiyllwKRUv(), 
						ControllerType.Mouse => IblkfbAEDuwgTJqeYvHEDCbGyZwL(), 
						ControllerType.Custom => WprIkpaODDrBzXCJbdsCCYLGnIke(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => DodwardXCSUfaeCwcNgpGSiOkBau(controllerId), 
						ControllerType.Keyboard => PiJIYytuWgLVDeTvsifTnWEuijvX(), 
						ControllerType.Mouse => bqmvBNfwmxdnOXsDpehFmsUwmFoh(), 
						ControllerType.Custom => CtkgkhZglZPNJZmKDnktYjTGGrQz(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => PBftwdIULTUOqwNIadHiHyYgvZqcA(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY(), 
						ControllerType.Mouse => RGiBjVEVgkBdoVzqDkEtGAUjDGfVA(), 
						ControllerType.Custom => XtYFqmgjyOcaaNFuMQuQqaHOJXbB(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				[IteratorStateMachine(typeof(nqVtCBfnsGptzpKyuUnoydZtwUgi))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return new nqVtCBfnsGptzpKyuUnoydZtwUgi(-2)
					{
						xMCfwuvpzEFISfrNYMTMQXfdCnTdb = this
					};
				}

				[IteratorStateMachine(typeof(FQCQHRxVhzLBSPMOIfsmTIOvUmnO))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return new FQCQHRxVhzLBSPMOIfsmTIOvUmnO(-2)
					{
						ObxZSJAkTDEpNUnOQHivKDLAMaIO = this
					};
				}

				[IteratorStateMachine(typeof(sWrTCjsvbWWKrPLutmPECWAkJKeQ))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return new sWrTCjsvbWWKrPLutmPECWAkJKeQ(-2)
					{
						zVjeQyuBGfCcEbfHkSNXCLvuEVYFb = this
					};
				}

				[IteratorStateMachine(typeof(uOWzurgODDBtuUNMzNeZkLJhsWtN))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return new uOWzurgODDBtuUNMzNeZkLJhsWtN(-2)
					{
						XVQUWbphSdHSqydeDVyUTSOBCKeM = this
					};
				}

				[IteratorStateMachine(typeof(SlSpNoVwqJdtCtKDuhoZUNifcfRw))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return new SlSpNoVwqJdtCtKDuhoZUNifcfRw(-2)
					{
						yjDYInAAWfzoNShFJfSAdXujuHdJA = this
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
						ControllerType.Joystick => PQsufnaMBIMVSrywfISFwaBEuidb(controllerId), 
						ControllerType.Keyboard => ZXDOwOvQRcrUbrMhMExVggkBcOFX(), 
						ControllerType.Mouse => DXXmVfBSPkcyyWNTkoKaUbpkNJpH(), 
						ControllerType.Custom => vIvVvmwzyYuYxdqeHfvrPHkIFoVm(controllerId), 
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
						ControllerType.Joystick => bsfTepvqHjfMeApBszukrSrBUDLrA(controllerId), 
						ControllerType.Keyboard => gzafIWpptaoXzxIXYMCpHwRbFebG(), 
						ControllerType.Mouse => RrViCwtflOZKLWgfJBaXIgkxDfQrA(), 
						ControllerType.Custom => OrvGGsYkZJLWqENUCIABzfKWnpLq(controllerId), 
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
						ControllerType.Joystick => DMMXAIhsVWPHqNZWxLDpIyKMuMSV(controllerId), 
						ControllerType.Keyboard => ZXDOwOvQRcrUbrMhMExVggkBcOFX(), 
						ControllerType.Mouse => dnLDehBsvogcCAZAGnpqHVzhtqbgB(), 
						ControllerType.Custom => ZaRmHzGlqcExIaBAQLPcFUQcOwspb(controllerId), 
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
						ControllerType.Joystick => NnNdpWESlFjVOAkXnZjqqlHCnduWA(controllerId), 
						ControllerType.Keyboard => gzafIWpptaoXzxIXYMCpHwRbFebG(), 
						ControllerType.Mouse => LKWZVShFAzTgTZblAlUCUZYpTyil(), 
						ControllerType.Custom => FACrcFbRAHCyKbkMWjXiSHnUygucA(controllerId), 
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
						ControllerType.Joystick => TIPTluOxDTNwxjLsbfoVXBTXCbLY(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => CcoEbnznEiblmmcoEmtSouqGkvWi(), 
						ControllerType.Custom => MdXkNegqhdRXSniKiZoxmBATiegM(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo ZbalqzMnlkaqKTFjJFHJKzhFhJDn()
				{
					IList<Joystick> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo xRrelilANKkqAUdcQUfoopJeaIcfA()
				{
					IList<Joystick> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo WcGIUEticVNdqcpygXdiQVvjLDMA()
				{
					IList<Joystick> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo ppfpVLgQdoAnmeJsICEXPKjVCHWO()
				{
					IList<Joystick> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo ctdyOlGXTeDkbzcMRZqYPqqELBYt()
				{
					IList<Joystick> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo RJBsBnNnQgRmIZQBXfryNAjwSYsp(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo IRCnnnZrBZRDxXKjkffIbUhJCLVyA(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo xldgQSJRkOgxgtxlahJrDQhdhHxi(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo DodwardXCSUfaeCwcNgpGSiOkBau(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo PBftwdIULTUOqwNIadHiHyYgvZqcA(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo lXWxBSIvuHEuKAhEJBbiyllwKRUv()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo PiJIYytuWgLVDeTvsifTnWEuijvX()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo vdBmjdsakpVTNdcHkbZINgrwPeVA()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo vejbfjeaQjDnopVObqkfVHsNgneWA()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo IblkfbAEDuwgTJqeYvHEDCbGyZwL()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo bqmvBNfwmxdnOXsDpehFmsUwmFoh()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo RGiBjVEVgkBdoVzqDkEtGAUjDGfVA()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo aABjreQBSuWATGYBwgzKQYHGTiXm()
				{
					IList<CustomController> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo shzXNSjJOZjQKGdkgktcKBktSLso()
				{
					IList<CustomController> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo daNJitgmPbEyxEvcvfFDmsqPSnbCA()
				{
					IList<CustomController> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo JsozJSDNbUtDzIuAqDLgnYsbSTWO()
				{
					IList<CustomController> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo fpLQPPvrwhAlAeKgIoSaJOwZdDJjA()
				{
					IList<CustomController> list = YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo meLSsUcXtPMnKdPRLyiFiKTWjrOe(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo islRaqyMiSjkWtNIKxGPbWMTiocQ(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo WprIkpaODDrBzXCJbdsCCYLGnIke(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo CtkgkhZglZPNJZmKDnktYjTGGrQz(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				private ControllerPollingInfo XtYFqmgjyOcaaNFuMQuQqaHOJXbB(int P_0)
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.ZWKipessSShuyCTGSTGJDqyiCJyY();
				}

				[IteratorStateMachine(typeof(AQOeFtEfJmBKsRLJVfgRYDIoHYTnA))]
				private IEnumerable<ControllerPollingInfo> dqJDCHhyyFzoQCcjWEfoAEvlXcyw()
				{
					return new AQOeFtEfJmBKsRLJVfgRYDIoHYTnA(-2);
				}

				[IteratorStateMachine(typeof(MaDcytLUIQIqYQdpmiGgHdutfsGE))]
				private IEnumerable<ControllerPollingInfo> xdbfDSUuExQSVEJEldCMCvMAeDPbb()
				{
					return new MaDcytLUIQIqYQdpmiGgHdutfsGE(-2);
				}

				[IteratorStateMachine(typeof(DsUcoievEEDcNQurRZitEDHPIhqx))]
				private IEnumerable<ControllerPollingInfo> eqqFbRpdpZhGebvkdPgIfGEkQOPv()
				{
					return new DsUcoievEEDcNQurRZitEDHPIhqx(-2);
				}

				[IteratorStateMachine(typeof(qCSEDUKzTGqIiBtNGmXRpALJLknG))]
				private IEnumerable<ControllerPollingInfo> hACLPldKrQMCSxizmzfsUZEqDBCT()
				{
					return new qCSEDUKzTGqIiBtNGmXRpALJLknG(-2);
				}

				[IteratorStateMachine(typeof(bWmXvDGUMiQUFXbbNxhJhZDpiQvp))]
				private IEnumerable<ControllerPollingInfo> EJnkKZICEIHWEZQZnwdfTcquVOKJ()
				{
					return new bWmXvDGUMiQUFXbbNxhJhZDpiQvp(-2);
				}

				private IEnumerable<ControllerPollingInfo> PQsufnaMBIMVSrywfISFwaBEuidb(int P_0)
				{
					Joystick joystick = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> bsfTepvqHjfMeApBszukrSrBUDLrA(int P_0)
				{
					Joystick joystick = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> DMMXAIhsVWPHqNZWxLDpIyKMuMSV(int P_0)
				{
					Joystick joystick = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> NnNdpWESlFjVOAkXnZjqqlHCnduWA(int P_0)
				{
					Joystick joystick = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> TIPTluOxDTNwxjLsbfoVXBTXCbLY(int P_0)
				{
					Joystick joystick = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> ZXDOwOvQRcrUbrMhMExVggkBcOFX()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> gzafIWpptaoXzxIXYMCpHwRbFebG()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> DXXmVfBSPkcyyWNTkoKaUbpkNJpH()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> RrViCwtflOZKLWgfJBaXIgkxDfQrA()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> dnLDehBsvogcCAZAGnpqHVzhtqbgB()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> LKWZVShFAzTgTZblAlUCUZYpTyil()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> CcoEbnznEiblmmcoEmtSouqGkvWi()
				{
					return EyLxuJgyUntPEmJHLKfpBTvBavPb.Mouse.PollForAllAxes();
				}

				[IteratorStateMachine(typeof(FUarClvkzUEYNReknYXeKCmkbedJA))]
				private IEnumerable<ControllerPollingInfo> RMrqDdxgXvfvoPVKbbuLyRbfMijp()
				{
					return new FUarClvkzUEYNReknYXeKCmkbedJA(-2);
				}

				[IteratorStateMachine(typeof(pAyknxkkuCnsqiuzlrTlHqfUZubK))]
				private IEnumerable<ControllerPollingInfo> ZTqewjDAKeOrbzZapLQogbkxuRGm()
				{
					return new pAyknxkkuCnsqiuzlrTlHqfUZubK(-2);
				}

				[IteratorStateMachine(typeof(lkIWIgPgwEIGMuYvwfRelwQTolXP))]
				private IEnumerable<ControllerPollingInfo> iuViFplomLjveigOGnClUlCzfhNjb()
				{
					return new lkIWIgPgwEIGMuYvwfRelwQTolXP(-2);
				}

				[IteratorStateMachine(typeof(mvdswMvzxbRElwyhyNaCLReFWLbB))]
				private IEnumerable<ControllerPollingInfo> mljoqeyRznqMTWbnchcMIakGojAUA()
				{
					return new mvdswMvzxbRElwyhyNaCLReFWLbB(-2);
				}

				[IteratorStateMachine(typeof(DIZQshBLQpsdERWWAnHPOqEjDSIj))]
				private IEnumerable<ControllerPollingInfo> UCGVNIzSlqcnRcDztgZAiFVLVdFr()
				{
					return new DIZQshBLQpsdERWWAnHPOqEjDSIj(-2);
				}

				private IEnumerable<ControllerPollingInfo> vIvVvmwzyYuYxdqeHfvrPHkIFoVm(int P_0)
				{
					CustomController customController = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> OrvGGsYkZJLWqENUCIABzfKWnpLq(int P_0)
				{
					CustomController customController = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> ZaRmHzGlqcExIaBAQLPcFUQcOwspb(int P_0)
				{
					CustomController customController = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> FACrcFbRAHCyKbkMWjXiSHnUygucA(int P_0)
				{
					CustomController customController = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> MdXkNegqhdRXSniKiZoxmBATiegM(int P_0)
				{
					CustomController customController = EyLxuJgyUntPEmJHLKfpBTvBavPb.GetCustomController(P_0);
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
				private sealed class xjDiHybSfWEzjPUddXxKYDUxsIHC : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int tfmWVbHBIDEgQgLXGybKSToQaidgb;

					private ElementAssignmentConflictInfo BqbGLiDYLXiRIejpqdnKeOLECCLiB;

					private int xENqGeBTeKGKniKzvoqvkwfEkGah;

					private int vcFcpBbpqkmCEBKsHewxKYYZbARbc;

					public int fuhPTKkjNNYjZTQLOKnaILxmbYyhA;

					private ActionElementMap gAvdpEiptBqmtchUWPxosGemkJrib;

					public ActionElementMap ISSKEhjdsXdIhiEmeKsqxLTUIbmdb;

					private bool JDnIJaGlqusEqpoBRtKcwezxeZrWA;

					public bool prdjPFprgKHGdmAUxGcteobEHPov;

					private int MartmFxFWZuamxheYIvtDSMDPKvw;

					public int SscdLIRGRpLwTUnvAaRYxVZVLUMG;

					private CustomControllerMap LUdiNiGrwKneSjHIJjyMyxVtgNPiA;

					public CustomControllerMap wJCkhPzMKSaiTvTdaQjATTlEYQvj;

					private bool alaHCAAFIGDReHpHcrUwKiKiCiUpA;

					public bool pWlhCfDqgFtrZBYotDkfzLktgikC;

					private bool vPnFWMBflJWuhdTQAFcVsuSDVeHkA;

					public bool OBAPqZIoNWikGXsPmCsDHcQNGmJlA;

					private IList<Player> vfVKdYdHWkWfCYrDaXgwSxVWPUQ;

					private int XViiheOtPEpFraTOkMUAXdirBXMS;

					private IEnumerator<ElementAssignmentConflictInfo> YQBFPQGBrwQeoQJvoZXTNdgKBiIo;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return BqbGLiDYLXiRIejpqdnKeOLECCLiB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return BqbGLiDYLXiRIejpqdnKeOLECCLiB;
						}
					}

					[DebuggerHidden]
					public xjDiHybSfWEzjPUddXxKYDUxsIHC(int P_0)
					{
						tfmWVbHBIDEgQgLXGybKSToQaidgb = P_0;
						xENqGeBTeKGKniKzvoqvkwfEkGah = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = tfmWVbHBIDEgQgLXGybKSToQaidgb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								oLmmkDbfkZHEidnUMcYTGGrIuwxp();
							}
						}
						vfVKdYdHWkWfCYrDaXgwSxVWPUQ = null;
						YQBFPQGBrwQeoQJvoZXTNdgKBiIo = null;
						tfmWVbHBIDEgQgLXGybKSToQaidgb = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = tfmWVbHBIDEgQgLXGybKSToQaidgb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								tfmWVbHBIDEgQgLXGybKSToQaidgb = -3;
								goto IL_00e2;
							}
							tfmWVbHBIDEgQgLXGybKSToQaidgb = -1;
							if (vcFcpBbpqkmCEBKsHewxKYYZbARbc < 0 || gAvdpEiptBqmtchUWPxosGemkJrib == null)
							{
								return false;
							}
							vfVKdYdHWkWfCYrDaXgwSxVWPUQ = (JDnIJaGlqusEqpoBRtKcwezxeZrWA ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
							XViiheOtPEpFraTOkMUAXdirBXMS = 0;
							goto IL_010c;
							IL_010c:
							if (XViiheOtPEpFraTOkMUAXdirBXMS < vfVKdYdHWkWfCYrDaXgwSxVWPUQ.Count)
							{
								YQBFPQGBrwQeoQJvoZXTNdgKBiIo = vfVKdYdHWkWfCYrDaXgwSxVWPUQ[XViiheOtPEpFraTOkMUAXdirBXMS].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, MartmFxFWZuamxheYIvtDSMDPKvw, LUdiNiGrwKneSjHIJjyMyxVtgNPiA, gAvdpEiptBqmtchUWPxosGemkJrib, alaHCAAFIGDReHpHcrUwKiKiCiUpA, vPnFWMBflJWuhdTQAFcVsuSDVeHkA).GetEnumerator();
								tfmWVbHBIDEgQgLXGybKSToQaidgb = -3;
								goto IL_00e2;
							}
							return false;
							IL_00e2:
							if (YQBFPQGBrwQeoQJvoZXTNdgKBiIo.MoveNext())
							{
								ElementAssignmentConflictInfo current = YQBFPQGBrwQeoQJvoZXTNdgKBiIo.Current;
								BqbGLiDYLXiRIejpqdnKeOLECCLiB = current;
								tfmWVbHBIDEgQgLXGybKSToQaidgb = 1;
								return true;
							}
							oLmmkDbfkZHEidnUMcYTGGrIuwxp();
							YQBFPQGBrwQeoQJvoZXTNdgKBiIo = null;
							XViiheOtPEpFraTOkMUAXdirBXMS++;
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

					private void oLmmkDbfkZHEidnUMcYTGGrIuwxp()
					{
						tfmWVbHBIDEgQgLXGybKSToQaidgb = -1;
						if (YQBFPQGBrwQeoQJvoZXTNdgKBiIo != null)
						{
							YQBFPQGBrwQeoQJvoZXTNdgKBiIo.Dispose();
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
						xjDiHybSfWEzjPUddXxKYDUxsIHC xjDiHybSfWEzjPUddXxKYDUxsIHC2;
						if (tfmWVbHBIDEgQgLXGybKSToQaidgb == -2 && xENqGeBTeKGKniKzvoqvkwfEkGah == Environment.CurrentManagedThreadId)
						{
							tfmWVbHBIDEgQgLXGybKSToQaidgb = 0;
							xjDiHybSfWEzjPUddXxKYDUxsIHC2 = this;
						}
						else
						{
							xjDiHybSfWEzjPUddXxKYDUxsIHC2 = new xjDiHybSfWEzjPUddXxKYDUxsIHC(0);
						}
						xjDiHybSfWEzjPUddXxKYDUxsIHC2.vcFcpBbpqkmCEBKsHewxKYYZbARbc = fuhPTKkjNNYjZTQLOKnaILxmbYyhA;
						xjDiHybSfWEzjPUddXxKYDUxsIHC2.MartmFxFWZuamxheYIvtDSMDPKvw = SscdLIRGRpLwTUnvAaRYxVZVLUMG;
						xjDiHybSfWEzjPUddXxKYDUxsIHC2.LUdiNiGrwKneSjHIJjyMyxVtgNPiA = wJCkhPzMKSaiTvTdaQjATTlEYQvj;
						xjDiHybSfWEzjPUddXxKYDUxsIHC2.gAvdpEiptBqmtchUWPxosGemkJrib = ISSKEhjdsXdIhiEmeKsqxLTUIbmdb;
						xjDiHybSfWEzjPUddXxKYDUxsIHC2.alaHCAAFIGDReHpHcrUwKiKiCiUpA = pWlhCfDqgFtrZBYotDkfzLktgikC;
						xjDiHybSfWEzjPUddXxKYDUxsIHC2.vPnFWMBflJWuhdTQAFcVsuSDVeHkA = OBAPqZIoNWikGXsPmCsDHcQNGmJlA;
						xjDiHybSfWEzjPUddXxKYDUxsIHC2.JDnIJaGlqusEqpoBRtKcwezxeZrWA = prdjPFprgKHGdmAUxGcteobEHPov;
						return xjDiHybSfWEzjPUddXxKYDUxsIHC2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class QUtCyuMJGfQxqmYNuvXbYbhPktnB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int pLVFnMPNUEyAZvSMeguVfOzNBBzv;

					private ElementAssignmentConflictInfo nrxTMWLoTcHnGPQhyMyYjpYSAHJU;

					private int MgLAQyZiEljdbTPWnYhWXtIRQNnC;

					private ElementAssignmentConflictCheck gtTxZsHyOCgoNbndrCIuNwHEYusj;

					public ElementAssignmentConflictCheck WSuQXebxOfsIBTJbLfNbkvtcocTw;

					private bool JgsxkaCzrFkrMFAmqHLZBPRSmXmdA;

					public bool gzWMbjitKCqSdXHtIqNNzxYZtBXQ;

					private bool bIRwGZRquAgPiGHWuCEOViOoseiBA;

					public bool fdMKQdqGIVshGnaloQcEwlkGGSsS;

					private bool ziyHZXruPopKFzRGROXoATKrCkDV;

					public bool rmUVmoJlNmqEodFWsFRJyPQMrtrI;

					private IList<Player> MBCGwHEsMINRWfrmVAvDqcXOQRDRA;

					private int RzAmjbdJfueIdasUgMRBoVfGdWjpA;

					private IEnumerator<ElementAssignmentConflictInfo> UZZFOJzdBvCfEOStPOWUplbOTGOV;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return nrxTMWLoTcHnGPQhyMyYjpYSAHJU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return nrxTMWLoTcHnGPQhyMyYjpYSAHJU;
						}
					}

					[DebuggerHidden]
					public QUtCyuMJGfQxqmYNuvXbYbhPktnB(int P_0)
					{
						pLVFnMPNUEyAZvSMeguVfOzNBBzv = P_0;
						MgLAQyZiEljdbTPWnYhWXtIRQNnC = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = pLVFnMPNUEyAZvSMeguVfOzNBBzv;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								tmGodiNKohAsKZhBDwNheyvPZhtj();
							}
						}
						MBCGwHEsMINRWfrmVAvDqcXOQRDRA = null;
						UZZFOJzdBvCfEOStPOWUplbOTGOV = null;
						pLVFnMPNUEyAZvSMeguVfOzNBBzv = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = pLVFnMPNUEyAZvSMeguVfOzNBBzv;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								pLVFnMPNUEyAZvSMeguVfOzNBBzv = -3;
								goto IL_00df;
							}
							pLVFnMPNUEyAZvSMeguVfOzNBBzv = -1;
							if (gtTxZsHyOCgoNbndrCIuNwHEYusj.playerId < 0 || gtTxZsHyOCgoNbndrCIuNwHEYusj.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							MBCGwHEsMINRWfrmVAvDqcXOQRDRA = (JgsxkaCzrFkrMFAmqHLZBPRSmXmdA ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
							RzAmjbdJfueIdasUgMRBoVfGdWjpA = 0;
							goto IL_0109;
							IL_0109:
							if (RzAmjbdJfueIdasUgMRBoVfGdWjpA < MBCGwHEsMINRWfrmVAvDqcXOQRDRA.Count)
							{
								UZZFOJzdBvCfEOStPOWUplbOTGOV = MBCGwHEsMINRWfrmVAvDqcXOQRDRA[RzAmjbdJfueIdasUgMRBoVfGdWjpA].controllers.conflictChecking.ElementAssignmentConflicts(gtTxZsHyOCgoNbndrCIuNwHEYusj, bIRwGZRquAgPiGHWuCEOViOoseiBA, ziyHZXruPopKFzRGROXoATKrCkDV).GetEnumerator();
								pLVFnMPNUEyAZvSMeguVfOzNBBzv = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (UZZFOJzdBvCfEOStPOWUplbOTGOV.MoveNext())
							{
								ElementAssignmentConflictInfo current = UZZFOJzdBvCfEOStPOWUplbOTGOV.Current;
								nrxTMWLoTcHnGPQhyMyYjpYSAHJU = current;
								pLVFnMPNUEyAZvSMeguVfOzNBBzv = 1;
								return true;
							}
							tmGodiNKohAsKZhBDwNheyvPZhtj();
							UZZFOJzdBvCfEOStPOWUplbOTGOV = null;
							RzAmjbdJfueIdasUgMRBoVfGdWjpA++;
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

					private void tmGodiNKohAsKZhBDwNheyvPZhtj()
					{
						pLVFnMPNUEyAZvSMeguVfOzNBBzv = -1;
						if (UZZFOJzdBvCfEOStPOWUplbOTGOV != null)
						{
							UZZFOJzdBvCfEOStPOWUplbOTGOV.Dispose();
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
						QUtCyuMJGfQxqmYNuvXbYbhPktnB qUtCyuMJGfQxqmYNuvXbYbhPktnB;
						if (pLVFnMPNUEyAZvSMeguVfOzNBBzv == -2 && MgLAQyZiEljdbTPWnYhWXtIRQNnC == Environment.CurrentManagedThreadId)
						{
							pLVFnMPNUEyAZvSMeguVfOzNBBzv = 0;
							qUtCyuMJGfQxqmYNuvXbYbhPktnB = this;
						}
						else
						{
							qUtCyuMJGfQxqmYNuvXbYbhPktnB = new QUtCyuMJGfQxqmYNuvXbYbhPktnB(0);
						}
						qUtCyuMJGfQxqmYNuvXbYbhPktnB.gtTxZsHyOCgoNbndrCIuNwHEYusj = WSuQXebxOfsIBTJbLfNbkvtcocTw;
						qUtCyuMJGfQxqmYNuvXbYbhPktnB.bIRwGZRquAgPiGHWuCEOViOoseiBA = fdMKQdqGIVshGnaloQcEwlkGGSsS;
						qUtCyuMJGfQxqmYNuvXbYbhPktnB.ziyHZXruPopKFzRGROXoATKrCkDV = rmUVmoJlNmqEodFWsFRJyPQMrtrI;
						qUtCyuMJGfQxqmYNuvXbYbhPktnB.JgsxkaCzrFkrMFAmqHLZBPRSmXmdA = gzWMbjitKCqSdXHtIqNNzxYZtBXQ;
						return qUtCyuMJGfQxqmYNuvXbYbhPktnB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class eSXxbggxUGfpwFkvYCpTiEqzRyGY : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ZtfpviobcpmAvmaTDFrFFEwyGIOSA;

					private ElementAssignmentConflictInfo zQOCILAPZVGEZedjAodLslJygnoBb;

					private int yEfmGMeeljRnYTvuiHZUlSQieCpN;

					private int rqHIUujpaRrmNiqmDfkcZOoyjFrZ;

					public int VtichMHwmkoGBezEosRjtSkoqYTf;

					private ActionElementMap qInQINKaJNSwCBZzvQdCGbOqtIWG;

					public ActionElementMap IgqXCvxlByAqNJQSFfjuZqaBrDPW;

					private bool tLZuUxTcdbnpDeGdSXEnIUlTgRJL;

					public bool LzaFTMwDrsyturPRNdVOBVGLdgG;

					private int PxMtMFWYOVNMmIZqNvaoTGqDuYwB;

					public int RlgksBQDPGDIgbXWDEcSOMXWisJr;

					private JoystickMap nhihMKdtgEtwXJqsfIJvVvjlarsO;

					public JoystickMap KvewaZsmXUDElZlAlCgvEesrLEpD;

					private bool YjwOHmDvMNlRloaslHszrCbVdtaP;

					public bool VbjwUmGPdALRhNAdfYqKzMJgVaCF;

					private bool ZmfAlRoeTDJRTRwUFzJQMGuBIpyd;

					public bool OrUvJEGGBauxSDbEMXFHHQDwgBZg;

					private IList<Player> AgNhFMjFNlfWgcItBFAtbfnpcINZ;

					private int EfpEhkySsHgmusJPopMXTNgfhkKj;

					private IEnumerator<ElementAssignmentConflictInfo> HKaDkteSKPyNZbtjSBakcZIJHbepA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return zQOCILAPZVGEZedjAodLslJygnoBb;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return zQOCILAPZVGEZedjAodLslJygnoBb;
						}
					}

					[DebuggerHidden]
					public eSXxbggxUGfpwFkvYCpTiEqzRyGY(int P_0)
					{
						ZtfpviobcpmAvmaTDFrFFEwyGIOSA = P_0;
						yEfmGMeeljRnYTvuiHZUlSQieCpN = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ztfpviobcpmAvmaTDFrFFEwyGIOSA = ZtfpviobcpmAvmaTDFrFFEwyGIOSA;
						if (ztfpviobcpmAvmaTDFrFFEwyGIOSA == -3 || ztfpviobcpmAvmaTDFrFFEwyGIOSA == 1)
						{
							try
							{
							}
							finally
							{
								CDpegQgvnLrsPRlqCjpaXLkOcwabb();
							}
						}
						AgNhFMjFNlfWgcItBFAtbfnpcINZ = null;
						HKaDkteSKPyNZbtjSBakcZIJHbepA = null;
						ZtfpviobcpmAvmaTDFrFFEwyGIOSA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int ztfpviobcpmAvmaTDFrFFEwyGIOSA = ZtfpviobcpmAvmaTDFrFFEwyGIOSA;
							if (ztfpviobcpmAvmaTDFrFFEwyGIOSA != 0)
							{
								if (ztfpviobcpmAvmaTDFrFFEwyGIOSA != 1)
								{
									return false;
								}
								ZtfpviobcpmAvmaTDFrFFEwyGIOSA = -3;
								goto IL_00e1;
							}
							ZtfpviobcpmAvmaTDFrFFEwyGIOSA = -1;
							if (rqHIUujpaRrmNiqmDfkcZOoyjFrZ < 0 || qInQINKaJNSwCBZzvQdCGbOqtIWG == null)
							{
								return false;
							}
							AgNhFMjFNlfWgcItBFAtbfnpcINZ = (tLZuUxTcdbnpDeGdSXEnIUlTgRJL ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
							EfpEhkySsHgmusJPopMXTNgfhkKj = 0;
							goto IL_010b;
							IL_010b:
							if (EfpEhkySsHgmusJPopMXTNgfhkKj < AgNhFMjFNlfWgcItBFAtbfnpcINZ.Count)
							{
								HKaDkteSKPyNZbtjSBakcZIJHbepA = AgNhFMjFNlfWgcItBFAtbfnpcINZ[EfpEhkySsHgmusJPopMXTNgfhkKj].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, PxMtMFWYOVNMmIZqNvaoTGqDuYwB, nhihMKdtgEtwXJqsfIJvVvjlarsO, qInQINKaJNSwCBZzvQdCGbOqtIWG, YjwOHmDvMNlRloaslHszrCbVdtaP, ZmfAlRoeTDJRTRwUFzJQMGuBIpyd).GetEnumerator();
								ZtfpviobcpmAvmaTDFrFFEwyGIOSA = -3;
								goto IL_00e1;
							}
							return false;
							IL_00e1:
							if (HKaDkteSKPyNZbtjSBakcZIJHbepA.MoveNext())
							{
								ElementAssignmentConflictInfo current = HKaDkteSKPyNZbtjSBakcZIJHbepA.Current;
								zQOCILAPZVGEZedjAodLslJygnoBb = current;
								ZtfpviobcpmAvmaTDFrFFEwyGIOSA = 1;
								return true;
							}
							CDpegQgvnLrsPRlqCjpaXLkOcwabb();
							HKaDkteSKPyNZbtjSBakcZIJHbepA = null;
							EfpEhkySsHgmusJPopMXTNgfhkKj++;
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

					private void CDpegQgvnLrsPRlqCjpaXLkOcwabb()
					{
						ZtfpviobcpmAvmaTDFrFFEwyGIOSA = -1;
						if (HKaDkteSKPyNZbtjSBakcZIJHbepA != null)
						{
							HKaDkteSKPyNZbtjSBakcZIJHbepA.Dispose();
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
						eSXxbggxUGfpwFkvYCpTiEqzRyGY eSXxbggxUGfpwFkvYCpTiEqzRyGY2;
						if (ZtfpviobcpmAvmaTDFrFFEwyGIOSA == -2 && yEfmGMeeljRnYTvuiHZUlSQieCpN == Environment.CurrentManagedThreadId)
						{
							ZtfpviobcpmAvmaTDFrFFEwyGIOSA = 0;
							eSXxbggxUGfpwFkvYCpTiEqzRyGY2 = this;
						}
						else
						{
							eSXxbggxUGfpwFkvYCpTiEqzRyGY2 = new eSXxbggxUGfpwFkvYCpTiEqzRyGY(0);
						}
						eSXxbggxUGfpwFkvYCpTiEqzRyGY2.rqHIUujpaRrmNiqmDfkcZOoyjFrZ = VtichMHwmkoGBezEosRjtSkoqYTf;
						eSXxbggxUGfpwFkvYCpTiEqzRyGY2.PxMtMFWYOVNMmIZqNvaoTGqDuYwB = RlgksBQDPGDIgbXWDEcSOMXWisJr;
						eSXxbggxUGfpwFkvYCpTiEqzRyGY2.nhihMKdtgEtwXJqsfIJvVvjlarsO = KvewaZsmXUDElZlAlCgvEesrLEpD;
						eSXxbggxUGfpwFkvYCpTiEqzRyGY2.qInQINKaJNSwCBZzvQdCGbOqtIWG = IgqXCvxlByAqNJQSFfjuZqaBrDPW;
						eSXxbggxUGfpwFkvYCpTiEqzRyGY2.YjwOHmDvMNlRloaslHszrCbVdtaP = VbjwUmGPdALRhNAdfYqKzMJgVaCF;
						eSXxbggxUGfpwFkvYCpTiEqzRyGY2.ZmfAlRoeTDJRTRwUFzJQMGuBIpyd = OrUvJEGGBauxSDbEMXFHHQDwgBZg;
						eSXxbggxUGfpwFkvYCpTiEqzRyGY2.tLZuUxTcdbnpDeGdSXEnIUlTgRJL = LzaFTMwDrsyturPRNdVOBVGLdgG;
						return eSXxbggxUGfpwFkvYCpTiEqzRyGY2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class VYxEvDraCzGUMNJrlSLaYciHwxUN : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ZtCUhpMnbZhjEPfhzRnwzDcxhvV;

					private ElementAssignmentConflictInfo HgjplUFUaIwqHjKHfcyLBgNNGCkMA;

					private int PPUhBklEWSvTSkoUDmKPHIrvtuaS;

					private ElementAssignmentConflictCheck jtBoWfLMxkijSILUzrzHamYwRyxp;

					public ElementAssignmentConflictCheck JWzzujdVnxIfSGfumrRVjmnpxLXS;

					private bool PNWVRiucfmWRMqEiEjeYPfjdKkPy;

					public bool zGgWgitLOOiLQvQfhijwlJSICqPD;

					private bool AmEbuJBWXOrOcsnhfgNnqXqwKUgK;

					public bool LNlLkmOKUnaIDgHZAaZGGojbEftlB;

					private bool YDZGEoNuDviEYFiHzXgptigxFCiEb;

					public bool kDBiZkMZvkdCfiTelphZTydxnfJJ;

					private IList<Player> pnhWsEsKGSMGaWHWYPDvkxvWCrLw;

					private int eLUFIdHyNZATkMljlDuWRrRaUxCo;

					private IEnumerator<ElementAssignmentConflictInfo> ndiqNHQcmFuySRtnKdrmLgmRdixH;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return HgjplUFUaIwqHjKHfcyLBgNNGCkMA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return HgjplUFUaIwqHjKHfcyLBgNNGCkMA;
						}
					}

					[DebuggerHidden]
					public VYxEvDraCzGUMNJrlSLaYciHwxUN(int P_0)
					{
						ZtCUhpMnbZhjEPfhzRnwzDcxhvV = P_0;
						PPUhBklEWSvTSkoUDmKPHIrvtuaS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ztCUhpMnbZhjEPfhzRnwzDcxhvV = ZtCUhpMnbZhjEPfhzRnwzDcxhvV;
						if (ztCUhpMnbZhjEPfhzRnwzDcxhvV == -3 || ztCUhpMnbZhjEPfhzRnwzDcxhvV == 1)
						{
							try
							{
							}
							finally
							{
								UNmbztkDglJCwpbSKbQYuCJbKZir();
							}
						}
						pnhWsEsKGSMGaWHWYPDvkxvWCrLw = null;
						ndiqNHQcmFuySRtnKdrmLgmRdixH = null;
						ZtCUhpMnbZhjEPfhzRnwzDcxhvV = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int ztCUhpMnbZhjEPfhzRnwzDcxhvV = ZtCUhpMnbZhjEPfhzRnwzDcxhvV;
							if (ztCUhpMnbZhjEPfhzRnwzDcxhvV != 0)
							{
								if (ztCUhpMnbZhjEPfhzRnwzDcxhvV != 1)
								{
									return false;
								}
								ZtCUhpMnbZhjEPfhzRnwzDcxhvV = -3;
								goto IL_00df;
							}
							ZtCUhpMnbZhjEPfhzRnwzDcxhvV = -1;
							if (jtBoWfLMxkijSILUzrzHamYwRyxp.playerId < 0 || jtBoWfLMxkijSILUzrzHamYwRyxp.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							pnhWsEsKGSMGaWHWYPDvkxvWCrLw = (PNWVRiucfmWRMqEiEjeYPfjdKkPy ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
							eLUFIdHyNZATkMljlDuWRrRaUxCo = 0;
							goto IL_0109;
							IL_0109:
							if (eLUFIdHyNZATkMljlDuWRrRaUxCo < pnhWsEsKGSMGaWHWYPDvkxvWCrLw.Count)
							{
								ndiqNHQcmFuySRtnKdrmLgmRdixH = pnhWsEsKGSMGaWHWYPDvkxvWCrLw[eLUFIdHyNZATkMljlDuWRrRaUxCo].controllers.conflictChecking.ElementAssignmentConflicts(jtBoWfLMxkijSILUzrzHamYwRyxp, AmEbuJBWXOrOcsnhfgNnqXqwKUgK, YDZGEoNuDviEYFiHzXgptigxFCiEb).GetEnumerator();
								ZtCUhpMnbZhjEPfhzRnwzDcxhvV = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (ndiqNHQcmFuySRtnKdrmLgmRdixH.MoveNext())
							{
								ElementAssignmentConflictInfo current = ndiqNHQcmFuySRtnKdrmLgmRdixH.Current;
								HgjplUFUaIwqHjKHfcyLBgNNGCkMA = current;
								ZtCUhpMnbZhjEPfhzRnwzDcxhvV = 1;
								return true;
							}
							UNmbztkDglJCwpbSKbQYuCJbKZir();
							ndiqNHQcmFuySRtnKdrmLgmRdixH = null;
							eLUFIdHyNZATkMljlDuWRrRaUxCo++;
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

					private void UNmbztkDglJCwpbSKbQYuCJbKZir()
					{
						ZtCUhpMnbZhjEPfhzRnwzDcxhvV = -1;
						if (ndiqNHQcmFuySRtnKdrmLgmRdixH != null)
						{
							ndiqNHQcmFuySRtnKdrmLgmRdixH.Dispose();
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
						VYxEvDraCzGUMNJrlSLaYciHwxUN vYxEvDraCzGUMNJrlSLaYciHwxUN;
						if (ZtCUhpMnbZhjEPfhzRnwzDcxhvV == -2 && PPUhBklEWSvTSkoUDmKPHIrvtuaS == Environment.CurrentManagedThreadId)
						{
							ZtCUhpMnbZhjEPfhzRnwzDcxhvV = 0;
							vYxEvDraCzGUMNJrlSLaYciHwxUN = this;
						}
						else
						{
							vYxEvDraCzGUMNJrlSLaYciHwxUN = new VYxEvDraCzGUMNJrlSLaYciHwxUN(0);
						}
						vYxEvDraCzGUMNJrlSLaYciHwxUN.jtBoWfLMxkijSILUzrzHamYwRyxp = JWzzujdVnxIfSGfumrRVjmnpxLXS;
						vYxEvDraCzGUMNJrlSLaYciHwxUN.AmEbuJBWXOrOcsnhfgNnqXqwKUgK = LNlLkmOKUnaIDgHZAaZGGojbEftlB;
						vYxEvDraCzGUMNJrlSLaYciHwxUN.YDZGEoNuDviEYFiHzXgptigxFCiEb = kDBiZkMZvkdCfiTelphZTydxnfJJ;
						vYxEvDraCzGUMNJrlSLaYciHwxUN.PNWVRiucfmWRMqEiEjeYPfjdKkPy = zGgWgitLOOiLQvQfhijwlJSICqPD;
						return vYxEvDraCzGUMNJrlSLaYciHwxUN;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class YzrPokAqVzsRVlCfinCtluPvIZJd : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int hofTvKSmMgqMHsgSzeoFbKaQlVujA;

					private ElementAssignmentConflictInfo kuQPpTChAFzDZFQCtWqqlpJXjabJA;

					private int ULxeNSjhmqhplwiuvBYsfxUSlPqmA;

					private int dkCAtiyncrusPBhpwfagAFalVglg;

					public int BZavrXaoGVMkCeIXEFJrjgGBvRfeA;

					private ActionElementMap xQkclJGqXDDJTpkjEldHGQWEQgSdc;

					public ActionElementMap qPQNMquQZxAsEHaUclGjlIPMfuFi;

					private bool MbBsITvxLsedHLoPvlmfZmyebxEo;

					public bool siaYPOCrAkvUwclaHxMlpMtEviLw;

					private KeyboardMap caYmLJclcjmFphSJsXnLLUsOnjod;

					public KeyboardMap CUfTCLgtoeRKbxzLtSwfprXMPRYU;

					private bool LBKrQhrcLTzOcYJrWUjfRBcKsXed;

					public bool FRkfJEhKKkFlWVBxKmoGtnvgLavm;

					private bool wShTwtgIKEwqXdbqqOGgAGweHoIr;

					public bool XwFOZtaGjeVmBMvlZDVGyzpDdjfp;

					private IList<Player> ZIMqBGUfvInKMsMFwBWPRZMcodhe;

					private int bfYUVcnOmDbIljoLGmHZbdzEnuAMc;

					private IEnumerator<ElementAssignmentConflictInfo> UTVAWmcOpTJuHKgqfDyTpfcfddzh;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return kuQPpTChAFzDZFQCtWqqlpJXjabJA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return kuQPpTChAFzDZFQCtWqqlpJXjabJA;
						}
					}

					[DebuggerHidden]
					public YzrPokAqVzsRVlCfinCtluPvIZJd(int P_0)
					{
						hofTvKSmMgqMHsgSzeoFbKaQlVujA = P_0;
						ULxeNSjhmqhplwiuvBYsfxUSlPqmA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = hofTvKSmMgqMHsgSzeoFbKaQlVujA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								kHVCNgJdHESbavrHTWEgAPxJPLiRA();
							}
						}
						ZIMqBGUfvInKMsMFwBWPRZMcodhe = null;
						UTVAWmcOpTJuHKgqfDyTpfcfddzh = null;
						hofTvKSmMgqMHsgSzeoFbKaQlVujA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = hofTvKSmMgqMHsgSzeoFbKaQlVujA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								hofTvKSmMgqMHsgSzeoFbKaQlVujA = -3;
								goto IL_00dc;
							}
							hofTvKSmMgqMHsgSzeoFbKaQlVujA = -1;
							if (dkCAtiyncrusPBhpwfagAFalVglg < 0 || xQkclJGqXDDJTpkjEldHGQWEQgSdc == null)
							{
								return false;
							}
							ZIMqBGUfvInKMsMFwBWPRZMcodhe = (MbBsITvxLsedHLoPvlmfZmyebxEo ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
							bfYUVcnOmDbIljoLGmHZbdzEnuAMc = 0;
							goto IL_0106;
							IL_0106:
							if (bfYUVcnOmDbIljoLGmHZbdzEnuAMc < ZIMqBGUfvInKMsMFwBWPRZMcodhe.Count)
							{
								UTVAWmcOpTJuHKgqfDyTpfcfddzh = ZIMqBGUfvInKMsMFwBWPRZMcodhe[bfYUVcnOmDbIljoLGmHZbdzEnuAMc].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, caYmLJclcjmFphSJsXnLLUsOnjod, xQkclJGqXDDJTpkjEldHGQWEQgSdc, LBKrQhrcLTzOcYJrWUjfRBcKsXed, wShTwtgIKEwqXdbqqOGgAGweHoIr).GetEnumerator();
								hofTvKSmMgqMHsgSzeoFbKaQlVujA = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (UTVAWmcOpTJuHKgqfDyTpfcfddzh.MoveNext())
							{
								ElementAssignmentConflictInfo current = UTVAWmcOpTJuHKgqfDyTpfcfddzh.Current;
								kuQPpTChAFzDZFQCtWqqlpJXjabJA = current;
								hofTvKSmMgqMHsgSzeoFbKaQlVujA = 1;
								return true;
							}
							kHVCNgJdHESbavrHTWEgAPxJPLiRA();
							UTVAWmcOpTJuHKgqfDyTpfcfddzh = null;
							bfYUVcnOmDbIljoLGmHZbdzEnuAMc++;
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

					private void kHVCNgJdHESbavrHTWEgAPxJPLiRA()
					{
						hofTvKSmMgqMHsgSzeoFbKaQlVujA = -1;
						if (UTVAWmcOpTJuHKgqfDyTpfcfddzh != null)
						{
							UTVAWmcOpTJuHKgqfDyTpfcfddzh.Dispose();
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
						YzrPokAqVzsRVlCfinCtluPvIZJd yzrPokAqVzsRVlCfinCtluPvIZJd;
						if (hofTvKSmMgqMHsgSzeoFbKaQlVujA == -2 && ULxeNSjhmqhplwiuvBYsfxUSlPqmA == Environment.CurrentManagedThreadId)
						{
							hofTvKSmMgqMHsgSzeoFbKaQlVujA = 0;
							yzrPokAqVzsRVlCfinCtluPvIZJd = this;
						}
						else
						{
							yzrPokAqVzsRVlCfinCtluPvIZJd = new YzrPokAqVzsRVlCfinCtluPvIZJd(0);
						}
						yzrPokAqVzsRVlCfinCtluPvIZJd.dkCAtiyncrusPBhpwfagAFalVglg = BZavrXaoGVMkCeIXEFJrjgGBvRfeA;
						yzrPokAqVzsRVlCfinCtluPvIZJd.caYmLJclcjmFphSJsXnLLUsOnjod = CUfTCLgtoeRKbxzLtSwfprXMPRYU;
						yzrPokAqVzsRVlCfinCtluPvIZJd.xQkclJGqXDDJTpkjEldHGQWEQgSdc = qPQNMquQZxAsEHaUclGjlIPMfuFi;
						yzrPokAqVzsRVlCfinCtluPvIZJd.LBKrQhrcLTzOcYJrWUjfRBcKsXed = FRkfJEhKKkFlWVBxKmoGtnvgLavm;
						yzrPokAqVzsRVlCfinCtluPvIZJd.wShTwtgIKEwqXdbqqOGgAGweHoIr = XwFOZtaGjeVmBMvlZDVGyzpDdjfp;
						yzrPokAqVzsRVlCfinCtluPvIZJd.MbBsITvxLsedHLoPvlmfZmyebxEo = siaYPOCrAkvUwclaHxMlpMtEviLw;
						return yzrPokAqVzsRVlCfinCtluPvIZJd;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class tUQKQGtIWShrfWkbsRuKMLSmgbIx : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int fQKjfTAaJmgHMAAKyXgeMzAtCoyJ;

					private ElementAssignmentConflictInfo bsedWVhoOPJZCOKzLaMqHYQccRYiB;

					private int LfVFbZyYYGpmLaMVdPgVwqHDbtqG;

					private ElementAssignmentConflictCheck OZSdrogzncRSReLDvTgXPNkYNpKT;

					public ElementAssignmentConflictCheck mLNJwmnCDjqwMkSQuJPvGwlLKGuU;

					private bool xWSJGqVpfolTwckhSslHnPERABHKA;

					public bool mhKWiKIDOTESeeBoGaolkOMylpgrA;

					private bool iXStQHBlJpgIvcffrLdIBgrFfUrgB;

					public bool irudMydzRUzfXuFKflMDOZHYfwlfb;

					private bool rTnDSgBewAifGCSHvMmyUYNPpRgWA;

					public bool CkpdbvYkUSZtFOBYnvkEfbjMBEoU;

					private IList<Player> SuFUciIVnjDUhoQZsHLVpJJxmbvd;

					private int hRFjWijNHvOKyAudXvPKFTFJmywK;

					private IEnumerator<ElementAssignmentConflictInfo> LdodfCMmvxaCGKtgPlXZigvaDZrB;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return bsedWVhoOPJZCOKzLaMqHYQccRYiB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return bsedWVhoOPJZCOKzLaMqHYQccRYiB;
						}
					}

					[DebuggerHidden]
					public tUQKQGtIWShrfWkbsRuKMLSmgbIx(int P_0)
					{
						fQKjfTAaJmgHMAAKyXgeMzAtCoyJ = P_0;
						LfVFbZyYYGpmLaMVdPgVwqHDbtqG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = fQKjfTAaJmgHMAAKyXgeMzAtCoyJ;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								eTQgNgMSTNjuxrGTZrQOymIHhFOJ();
							}
						}
						SuFUciIVnjDUhoQZsHLVpJJxmbvd = null;
						LdodfCMmvxaCGKtgPlXZigvaDZrB = null;
						fQKjfTAaJmgHMAAKyXgeMzAtCoyJ = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int num = fQKjfTAaJmgHMAAKyXgeMzAtCoyJ;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								fQKjfTAaJmgHMAAKyXgeMzAtCoyJ = -3;
								goto IL_00df;
							}
							fQKjfTAaJmgHMAAKyXgeMzAtCoyJ = -1;
							if (OZSdrogzncRSReLDvTgXPNkYNpKT.playerId < 0 || OZSdrogzncRSReLDvTgXPNkYNpKT.elementAssignmentType != ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							SuFUciIVnjDUhoQZsHLVpJJxmbvd = (xWSJGqVpfolTwckhSslHnPERABHKA ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
							hRFjWijNHvOKyAudXvPKFTFJmywK = 0;
							goto IL_0109;
							IL_0109:
							if (hRFjWijNHvOKyAudXvPKFTFJmywK < SuFUciIVnjDUhoQZsHLVpJJxmbvd.Count)
							{
								LdodfCMmvxaCGKtgPlXZigvaDZrB = SuFUciIVnjDUhoQZsHLVpJJxmbvd[hRFjWijNHvOKyAudXvPKFTFJmywK].controllers.conflictChecking.ElementAssignmentConflicts(OZSdrogzncRSReLDvTgXPNkYNpKT, iXStQHBlJpgIvcffrLdIBgrFfUrgB, rTnDSgBewAifGCSHvMmyUYNPpRgWA).GetEnumerator();
								fQKjfTAaJmgHMAAKyXgeMzAtCoyJ = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (LdodfCMmvxaCGKtgPlXZigvaDZrB.MoveNext())
							{
								ElementAssignmentConflictInfo current = LdodfCMmvxaCGKtgPlXZigvaDZrB.Current;
								bsedWVhoOPJZCOKzLaMqHYQccRYiB = current;
								fQKjfTAaJmgHMAAKyXgeMzAtCoyJ = 1;
								return true;
							}
							eTQgNgMSTNjuxrGTZrQOymIHhFOJ();
							LdodfCMmvxaCGKtgPlXZigvaDZrB = null;
							hRFjWijNHvOKyAudXvPKFTFJmywK++;
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

					private void eTQgNgMSTNjuxrGTZrQOymIHhFOJ()
					{
						fQKjfTAaJmgHMAAKyXgeMzAtCoyJ = -1;
						if (LdodfCMmvxaCGKtgPlXZigvaDZrB != null)
						{
							LdodfCMmvxaCGKtgPlXZigvaDZrB.Dispose();
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
						tUQKQGtIWShrfWkbsRuKMLSmgbIx tUQKQGtIWShrfWkbsRuKMLSmgbIx2;
						if (fQKjfTAaJmgHMAAKyXgeMzAtCoyJ == -2 && LfVFbZyYYGpmLaMVdPgVwqHDbtqG == Environment.CurrentManagedThreadId)
						{
							fQKjfTAaJmgHMAAKyXgeMzAtCoyJ = 0;
							tUQKQGtIWShrfWkbsRuKMLSmgbIx2 = this;
						}
						else
						{
							tUQKQGtIWShrfWkbsRuKMLSmgbIx2 = new tUQKQGtIWShrfWkbsRuKMLSmgbIx(0);
						}
						tUQKQGtIWShrfWkbsRuKMLSmgbIx2.OZSdrogzncRSReLDvTgXPNkYNpKT = mLNJwmnCDjqwMkSQuJPvGwlLKGuU;
						tUQKQGtIWShrfWkbsRuKMLSmgbIx2.iXStQHBlJpgIvcffrLdIBgrFfUrgB = irudMydzRUzfXuFKflMDOZHYfwlfb;
						tUQKQGtIWShrfWkbsRuKMLSmgbIx2.rTnDSgBewAifGCSHvMmyUYNPpRgWA = CkpdbvYkUSZtFOBYnvkEfbjMBEoU;
						tUQKQGtIWShrfWkbsRuKMLSmgbIx2.xWSJGqVpfolTwckhSslHnPERABHKA = mhKWiKIDOTESeeBoGaolkOMylpgrA;
						return tUQKQGtIWShrfWkbsRuKMLSmgbIx2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class gIEzrUKKNndPzBNDdkBoskJLeJlT : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int POooALHyTnqrNoYKHGHYiDuqOMyN;

					private ElementAssignmentConflictInfo mevJgInQizIGIUQNdczhcbvXZGhT;

					private int wmcsOLHdiyLPmYXUbzDcMWqPagfE;

					private int QkgxtEBrPIPGTawTIgzSwBbgXyZF;

					public int cDoacFJRCTxuUTPuUMZHKNiaPRCX;

					private ActionElementMap TFBOVMCGwHoliyfpYiQxIGQMORtm;

					public ActionElementMap BcbVgTtfBjEKcTrqKTFxNOJIopsW;

					private bool hqwjWmCPGbwsnuItecamYoYXTOge;

					public bool neJEnEfFFkSWOggDECefjIDVWlGAb;

					private MouseMap qLntfuQVIudjLQueIIJZcZCOQQwT;

					public MouseMap BVVZkIxDEgSXfTeFxpvcnGYdkkaT;

					private bool eHTbmIpCrjQGMmTCzrLhdyPOIVyU;

					public bool yjZHTKuLYFtkNDcqWOWVzDbdZllo;

					private bool pKMnXTAQuShawSLUeBzxPqUAaNZE;

					public bool KXzxCBzSoVKOMgccmXLXPvceesxy;

					private IList<Player> ytplrveaBHKtRIOMwiWogXEsoFQJA;

					private int GmcZtQlojagOyTgjmHqiVoOJPNDK;

					private IEnumerator<ElementAssignmentConflictInfo> LaQPwEdEnxWdzGihyNtewctxUkMD;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return mevJgInQizIGIUQNdczhcbvXZGhT;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return mevJgInQizIGIUQNdczhcbvXZGhT;
						}
					}

					[DebuggerHidden]
					public gIEzrUKKNndPzBNDdkBoskJLeJlT(int P_0)
					{
						POooALHyTnqrNoYKHGHYiDuqOMyN = P_0;
						wmcsOLHdiyLPmYXUbzDcMWqPagfE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int pOooALHyTnqrNoYKHGHYiDuqOMyN = POooALHyTnqrNoYKHGHYiDuqOMyN;
						if (pOooALHyTnqrNoYKHGHYiDuqOMyN == -3 || pOooALHyTnqrNoYKHGHYiDuqOMyN == 1)
						{
							try
							{
							}
							finally
							{
								XJbjBjUDucXAWpDYmqgiidMYRBOV();
							}
						}
						ytplrveaBHKtRIOMwiWogXEsoFQJA = null;
						LaQPwEdEnxWdzGihyNtewctxUkMD = null;
						POooALHyTnqrNoYKHGHYiDuqOMyN = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int pOooALHyTnqrNoYKHGHYiDuqOMyN = POooALHyTnqrNoYKHGHYiDuqOMyN;
							if (pOooALHyTnqrNoYKHGHYiDuqOMyN != 0)
							{
								if (pOooALHyTnqrNoYKHGHYiDuqOMyN != 1)
								{
									return false;
								}
								POooALHyTnqrNoYKHGHYiDuqOMyN = -3;
								goto IL_00dc;
							}
							POooALHyTnqrNoYKHGHYiDuqOMyN = -1;
							if (QkgxtEBrPIPGTawTIgzSwBbgXyZF < 0 || TFBOVMCGwHoliyfpYiQxIGQMORtm == null)
							{
								return false;
							}
							ytplrveaBHKtRIOMwiWogXEsoFQJA = (hqwjWmCPGbwsnuItecamYoYXTOge ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
							GmcZtQlojagOyTgjmHqiVoOJPNDK = 0;
							goto IL_0106;
							IL_0106:
							if (GmcZtQlojagOyTgjmHqiVoOJPNDK < ytplrveaBHKtRIOMwiWogXEsoFQJA.Count)
							{
								LaQPwEdEnxWdzGihyNtewctxUkMD = ytplrveaBHKtRIOMwiWogXEsoFQJA[GmcZtQlojagOyTgjmHqiVoOJPNDK].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, qLntfuQVIudjLQueIIJZcZCOQQwT, TFBOVMCGwHoliyfpYiQxIGQMORtm, eHTbmIpCrjQGMmTCzrLhdyPOIVyU, pKMnXTAQuShawSLUeBzxPqUAaNZE).GetEnumerator();
								POooALHyTnqrNoYKHGHYiDuqOMyN = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (LaQPwEdEnxWdzGihyNtewctxUkMD.MoveNext())
							{
								ElementAssignmentConflictInfo current = LaQPwEdEnxWdzGihyNtewctxUkMD.Current;
								mevJgInQizIGIUQNdczhcbvXZGhT = current;
								POooALHyTnqrNoYKHGHYiDuqOMyN = 1;
								return true;
							}
							XJbjBjUDucXAWpDYmqgiidMYRBOV();
							LaQPwEdEnxWdzGihyNtewctxUkMD = null;
							GmcZtQlojagOyTgjmHqiVoOJPNDK++;
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

					private void XJbjBjUDucXAWpDYmqgiidMYRBOV()
					{
						POooALHyTnqrNoYKHGHYiDuqOMyN = -1;
						if (LaQPwEdEnxWdzGihyNtewctxUkMD != null)
						{
							LaQPwEdEnxWdzGihyNtewctxUkMD.Dispose();
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
						gIEzrUKKNndPzBNDdkBoskJLeJlT gIEzrUKKNndPzBNDdkBoskJLeJlT2;
						if (POooALHyTnqrNoYKHGHYiDuqOMyN == -2 && wmcsOLHdiyLPmYXUbzDcMWqPagfE == Environment.CurrentManagedThreadId)
						{
							POooALHyTnqrNoYKHGHYiDuqOMyN = 0;
							gIEzrUKKNndPzBNDdkBoskJLeJlT2 = this;
						}
						else
						{
							gIEzrUKKNndPzBNDdkBoskJLeJlT2 = new gIEzrUKKNndPzBNDdkBoskJLeJlT(0);
						}
						gIEzrUKKNndPzBNDdkBoskJLeJlT2.QkgxtEBrPIPGTawTIgzSwBbgXyZF = cDoacFJRCTxuUTPuUMZHKNiaPRCX;
						gIEzrUKKNndPzBNDdkBoskJLeJlT2.qLntfuQVIudjLQueIIJZcZCOQQwT = BVVZkIxDEgSXfTeFxpvcnGYdkkaT;
						gIEzrUKKNndPzBNDdkBoskJLeJlT2.TFBOVMCGwHoliyfpYiQxIGQMORtm = BcbVgTtfBjEKcTrqKTFxNOJIopsW;
						gIEzrUKKNndPzBNDdkBoskJLeJlT2.eHTbmIpCrjQGMmTCzrLhdyPOIVyU = yjZHTKuLYFtkNDcqWOWVzDbdZllo;
						gIEzrUKKNndPzBNDdkBoskJLeJlT2.pKMnXTAQuShawSLUeBzxPqUAaNZE = KXzxCBzSoVKOMgccmXLXPvceesxy;
						gIEzrUKKNndPzBNDdkBoskJLeJlT2.hqwjWmCPGbwsnuItecamYoYXTOge = neJEnEfFFkSWOggDECefjIDVWlGAb;
						return gIEzrUKKNndPzBNDdkBoskJLeJlT2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class XvmBmVjmbHwlahaJjIaiqnYewIAgA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int PwOzhsSGgjcVdkBDYgzibOXAQrcBA;

					private ElementAssignmentConflictInfo PPZFNdgloGKRSOJRmqpjLKmpiZxK;

					private int ViscuwAfkhASUgIZdEDcRCQPgwKeA;

					private ElementAssignmentConflictCheck yAmUYDRcFfNNCmlSmSyEFfwuITZi;

					public ElementAssignmentConflictCheck xXXUyBcdDOjvgZsmvcmlVkGMHBBP;

					private bool dPKBvBLzxqbiKyIRsfcwSdNAsrYl;

					public bool TwDbMYRkLZNtefSHvKTfxXDaoBnS;

					private bool fwTgjZXLleFjXzCZvDTOGPyEayVdA;

					public bool zBielbezSUaaKwDTIQXJdHBEvyhV;

					private bool JxEoHEgbGzFxuoxkvFUrGfQZNOQw;

					public bool ROliDrXfixrtiSQRqkwaNnYVAisB;

					private IList<Player> EaWbwXBiNCnnKqTuaJgIlsvEjYbhA;

					private int dVUWymJfKHtlnLaSxiVnTiNcmCyE;

					private IEnumerator<ElementAssignmentConflictInfo> SnQoUiRqjtiRWvVFJOGXaVpaDZyB;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PPZFNdgloGKRSOJRmqpjLKmpiZxK;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PPZFNdgloGKRSOJRmqpjLKmpiZxK;
						}
					}

					[DebuggerHidden]
					public XvmBmVjmbHwlahaJjIaiqnYewIAgA(int P_0)
					{
						PwOzhsSGgjcVdkBDYgzibOXAQrcBA = P_0;
						ViscuwAfkhASUgIZdEDcRCQPgwKeA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int pwOzhsSGgjcVdkBDYgzibOXAQrcBA = PwOzhsSGgjcVdkBDYgzibOXAQrcBA;
						if (pwOzhsSGgjcVdkBDYgzibOXAQrcBA == -3 || pwOzhsSGgjcVdkBDYgzibOXAQrcBA == 1)
						{
							try
							{
							}
							finally
							{
								WzAolveRpZHDgMCvSEmVcYGongAQA();
							}
						}
						EaWbwXBiNCnnKqTuaJgIlsvEjYbhA = null;
						SnQoUiRqjtiRWvVFJOGXaVpaDZyB = null;
						PwOzhsSGgjcVdkBDYgzibOXAQrcBA = -2;
					}

					private bool MoveNext()
					{
						try
						{
							int pwOzhsSGgjcVdkBDYgzibOXAQrcBA = PwOzhsSGgjcVdkBDYgzibOXAQrcBA;
							if (pwOzhsSGgjcVdkBDYgzibOXAQrcBA != 0)
							{
								if (pwOzhsSGgjcVdkBDYgzibOXAQrcBA != 1)
								{
									return false;
								}
								PwOzhsSGgjcVdkBDYgzibOXAQrcBA = -3;
								goto IL_00df;
							}
							PwOzhsSGgjcVdkBDYgzibOXAQrcBA = -1;
							if (yAmUYDRcFfNNCmlSmSyEFfwuITZi.playerId < 0 || yAmUYDRcFfNNCmlSmSyEFfwuITZi.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							EaWbwXBiNCnnKqTuaJgIlsvEjYbhA = (dPKBvBLzxqbiKyIRsfcwSdNAsrYl ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
							dVUWymJfKHtlnLaSxiVnTiNcmCyE = 0;
							goto IL_0109;
							IL_0109:
							if (dVUWymJfKHtlnLaSxiVnTiNcmCyE < EaWbwXBiNCnnKqTuaJgIlsvEjYbhA.Count)
							{
								SnQoUiRqjtiRWvVFJOGXaVpaDZyB = EaWbwXBiNCnnKqTuaJgIlsvEjYbhA[dVUWymJfKHtlnLaSxiVnTiNcmCyE].controllers.conflictChecking.ElementAssignmentConflicts(yAmUYDRcFfNNCmlSmSyEFfwuITZi, fwTgjZXLleFjXzCZvDTOGPyEayVdA, JxEoHEgbGzFxuoxkvFUrGfQZNOQw).GetEnumerator();
								PwOzhsSGgjcVdkBDYgzibOXAQrcBA = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (SnQoUiRqjtiRWvVFJOGXaVpaDZyB.MoveNext())
							{
								ElementAssignmentConflictInfo current = SnQoUiRqjtiRWvVFJOGXaVpaDZyB.Current;
								PPZFNdgloGKRSOJRmqpjLKmpiZxK = current;
								PwOzhsSGgjcVdkBDYgzibOXAQrcBA = 1;
								return true;
							}
							WzAolveRpZHDgMCvSEmVcYGongAQA();
							SnQoUiRqjtiRWvVFJOGXaVpaDZyB = null;
							dVUWymJfKHtlnLaSxiVnTiNcmCyE++;
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

					private void WzAolveRpZHDgMCvSEmVcYGongAQA()
					{
						PwOzhsSGgjcVdkBDYgzibOXAQrcBA = -1;
						if (SnQoUiRqjtiRWvVFJOGXaVpaDZyB != null)
						{
							SnQoUiRqjtiRWvVFJOGXaVpaDZyB.Dispose();
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
						XvmBmVjmbHwlahaJjIaiqnYewIAgA xvmBmVjmbHwlahaJjIaiqnYewIAgA;
						if (PwOzhsSGgjcVdkBDYgzibOXAQrcBA == -2 && ViscuwAfkhASUgIZdEDcRCQPgwKeA == Environment.CurrentManagedThreadId)
						{
							PwOzhsSGgjcVdkBDYgzibOXAQrcBA = 0;
							xvmBmVjmbHwlahaJjIaiqnYewIAgA = this;
						}
						else
						{
							xvmBmVjmbHwlahaJjIaiqnYewIAgA = new XvmBmVjmbHwlahaJjIaiqnYewIAgA(0);
						}
						xvmBmVjmbHwlahaJjIaiqnYewIAgA.yAmUYDRcFfNNCmlSmSyEFfwuITZi = xXXUyBcdDOjvgZsmvcmlVkGMHBBP;
						xvmBmVjmbHwlahaJjIaiqnYewIAgA.fwTgjZXLleFjXzCZvDTOGPyEayVdA = zBielbezSUaaKwDTIQXJdHBEvyhV;
						xvmBmVjmbHwlahaJjIaiqnYewIAgA.JxEoHEgbGzFxuoxkvFUrGfQZNOQw = ROliDrXfixrtiSQRqkwaNnYVAisB;
						xvmBmVjmbHwlahaJjIaiqnYewIAgA.dPKBvBLzxqbiKyIRsfcwSdNAsrYl = TwDbMYRkLZNtefSHvKTfxXDaoBnS;
						return xvmBmVjmbHwlahaJjIaiqnYewIAgA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private static ConflictCheckingHelper FRfwZmyXYjFyAICMwnDhyOztEcMp;

				internal static ConflictCheckingHelper DuPuCnuoIHPLIJQMbHHmkhcAmiWp => FRfwZmyXYjFyAICMwnDhyOztEcMp ?? (FRfwZmyXYjFyAICMwnDhyOztEcMp = new ConflictCheckingHelper());

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
					IList<Player> list = (includeSystemPlayer ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
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
						ControllerType.Joystick => UScwatMcUaBVybnikHyfsUwcGOqq(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => QrfpdDxyymFifIdsOjHMXsywQFYA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => HEVNNoeqidSGCFJzWcbLwsnFRPof(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => lBIYggULVmuEzhppPSVtwtayPFOg(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return jSkVmeCjAqjQsCRBBeirVpPfFJYfb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return OLJbCkVIrdzWhZfRZeHpnsXUURaS(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return FfmaZdnAsjpTwIvosGzZCGOIfUTx(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return BFatfRqvuhkBFLaAtxjmhXBLUujm(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool UScwatMcUaBVybnikHyfsUwcGOqq(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool jSkVmeCjAqjQsCRBBeirVpPfFJYfb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool QrfpdDxyymFifIdsOjHMXsywQFYA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool OLJbCkVIrdzWhZfRZeHpnsXUURaS(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool HEVNNoeqidSGCFJzWcbLwsnFRPof(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool FfmaZdnAsjpTwIvosGzZCGOIfUTx(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool lBIYggULVmuEzhppPSVtwtayPFOg(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool BFatfRqvuhkBFLaAtxjmhXBLUujm(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
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
						ControllerType.Joystick => huQyKOBvhwCLGwyKLCkNLJiYYZN(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => DxVarHZgQIhVaYVPhdyiTjLsqcjW(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => rKwetgHNJwLZVQsOQcGOSCDscZNnA(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => YXUzxbhGScNFZHNjdmMHyXEABElO(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return yyOsjMBdiuhQSSxKSrNVzxutLntQ(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return EXXyMjeASvfCjljgojgEPEYjTnIt(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return FgAizPwQrwmAJTdkWUMRhSrEhrtJ(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return ZYvOpTWGzfmFzBBceGCBXEHRXOVC(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				[IteratorStateMachine(typeof(eSXxbggxUGfpwFkvYCpTiEqzRyGY))]
				private IEnumerable<ElementAssignmentConflictInfo> huQyKOBvhwCLGwyKLCkNLJiYYZN(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new eSXxbggxUGfpwFkvYCpTiEqzRyGY(-2)
					{
						VtichMHwmkoGBezEosRjtSkoqYTf = P_0,
						RlgksBQDPGDIgbXWDEcSOMXWisJr = P_1,
						KvewaZsmXUDElZlAlCgvEesrLEpD = P_2,
						IgqXCvxlByAqNJQSFfjuZqaBrDPW = P_3,
						VbjwUmGPdALRhNAdfYqKzMJgVaCF = P_4,
						OrUvJEGGBauxSDbEMXFHHQDwgBZg = P_5,
						LzaFTMwDrsyturPRNdVOBVGLdgG = P_6
					};
				}

				[IteratorStateMachine(typeof(VYxEvDraCzGUMNJrlSLaYciHwxUN))]
				private IEnumerable<ElementAssignmentConflictInfo> yyOsjMBdiuhQSSxKSrNVzxutLntQ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new VYxEvDraCzGUMNJrlSLaYciHwxUN(-2)
					{
						JWzzujdVnxIfSGfumrRVjmnpxLXS = P_0,
						LNlLkmOKUnaIDgHZAaZGGojbEftlB = P_1,
						kDBiZkMZvkdCfiTelphZTydxnfJJ = P_2,
						zGgWgitLOOiLQvQfhijwlJSICqPD = P_3
					};
				}

				[IteratorStateMachine(typeof(YzrPokAqVzsRVlCfinCtluPvIZJd))]
				private IEnumerable<ElementAssignmentConflictInfo> DxVarHZgQIhVaYVPhdyiTjLsqcjW(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new YzrPokAqVzsRVlCfinCtluPvIZJd(-2)
					{
						BZavrXaoGVMkCeIXEFJrjgGBvRfeA = P_0,
						CUfTCLgtoeRKbxzLtSwfprXMPRYU = P_1,
						qPQNMquQZxAsEHaUclGjlIPMfuFi = P_2,
						FRkfJEhKKkFlWVBxKmoGtnvgLavm = P_3,
						XwFOZtaGjeVmBMvlZDVGyzpDdjfp = P_4,
						siaYPOCrAkvUwclaHxMlpMtEviLw = P_5
					};
				}

				[IteratorStateMachine(typeof(tUQKQGtIWShrfWkbsRuKMLSmgbIx))]
				private IEnumerable<ElementAssignmentConflictInfo> EXXyMjeASvfCjljgojgEPEYjTnIt(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new tUQKQGtIWShrfWkbsRuKMLSmgbIx(-2)
					{
						mLNJwmnCDjqwMkSQuJPvGwlLKGuU = P_0,
						irudMydzRUzfXuFKflMDOZHYfwlfb = P_1,
						CkpdbvYkUSZtFOBYnvkEfbjMBEoU = P_2,
						mhKWiKIDOTESeeBoGaolkOMylpgrA = P_3
					};
				}

				[IteratorStateMachine(typeof(gIEzrUKKNndPzBNDdkBoskJLeJlT))]
				private IEnumerable<ElementAssignmentConflictInfo> rKwetgHNJwLZVQsOQcGOSCDscZNnA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new gIEzrUKKNndPzBNDdkBoskJLeJlT(-2)
					{
						cDoacFJRCTxuUTPuUMZHKNiaPRCX = P_0,
						BVVZkIxDEgSXfTeFxpvcnGYdkkaT = P_1,
						BcbVgTtfBjEKcTrqKTFxNOJIopsW = P_2,
						yjZHTKuLYFtkNDcqWOWVzDbdZllo = P_3,
						KXzxCBzSoVKOMgccmXLXPvceesxy = P_4,
						neJEnEfFFkSWOggDECefjIDVWlGAb = P_5
					};
				}

				[IteratorStateMachine(typeof(XvmBmVjmbHwlahaJjIaiqnYewIAgA))]
				private IEnumerable<ElementAssignmentConflictInfo> FgAizPwQrwmAJTdkWUMRhSrEhrtJ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new XvmBmVjmbHwlahaJjIaiqnYewIAgA(-2)
					{
						xXXUyBcdDOjvgZsmvcmlVkGMHBBP = P_0,
						zBielbezSUaaKwDTIQXJdHBEvyhV = P_1,
						ROliDrXfixrtiSQRqkwaNnYVAisB = P_2,
						TwDbMYRkLZNtefSHvKTfxXDaoBnS = P_3
					};
				}

				[IteratorStateMachine(typeof(xjDiHybSfWEzjPUddXxKYDUxsIHC))]
				private IEnumerable<ElementAssignmentConflictInfo> YXUzxbhGScNFZHNjdmMHyXEABElO(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new xjDiHybSfWEzjPUddXxKYDUxsIHC(-2)
					{
						fuhPTKkjNNYjZTQLOKnaILxmbYyhA = P_0,
						SscdLIRGRpLwTUnvAaRYxVZVLUMG = P_1,
						wJCkhPzMKSaiTvTdaQjATTlEYQvj = P_2,
						ISSKEhjdsXdIhiEmeKsqxLTUIbmdb = P_3,
						pWlhCfDqgFtrZBYotDkfzLktgikC = P_4,
						OBAPqZIoNWikGXsPmCsDHcQNGmJlA = P_5,
						prdjPFprgKHGdmAUxGcteobEHPov = P_6
					};
				}

				[IteratorStateMachine(typeof(QUtCyuMJGfQxqmYNuvXbYbhPktnB))]
				private IEnumerable<ElementAssignmentConflictInfo> ZYvOpTWGzfmFzBBceGCBXEHRXOVC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new QUtCyuMJGfQxqmYNuvXbYbhPktnB(-2)
					{
						WSuQXebxOfsIBTJbLfNbkvtcocTw = P_0,
						fdMKQdqGIVshGnaloQcEwlkGGSsS = P_1,
						rmUVmoJlNmqEodFWsFRJyPQMrtrI = P_2,
						gzWMbjitKCqSdXHtIqNNzxYZtBXQ = P_3
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
						ControllerType.Joystick => moGOoJElXZBTlmXXkfMFFQZdduhMA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => mvJPXcEtjErFsAhFhsyaidsyABQD(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => ApezdZtffqgyiOnEEaAyRZVrSgXl(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => JwDwQPbCkWCLXgrubFgJRmjLWhlI(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return NkqrCSaGOLOpkdXzaEQIwtyziTNA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return tAJyKEvflZcvUbYZqfdnKryOHxHxA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return sSnJWtbBKnTYWwwSFxWpKauSXFTk(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return wAiaAMFAMsnRvhnibiaNkeiVVypG(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int moGOoJElXZBTlmXXkfMFFQZdduhMA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int NkqrCSaGOLOpkdXzaEQIwtyziTNA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int mvJPXcEtjErFsAhFhsyaidsyABQD(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int tAJyKEvflZcvUbYZqfdnKryOHxHxA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int ApezdZtffqgyiOnEEaAyRZVrSgXl(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int sSnJWtbBKnTYWwwSFxWpKauSXFTk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int JwDwQPbCkWCLXgrubFgJRmjLWhlI(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int wAiaAMFAMsnRvhnibiaNkeiVVypG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
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
						ControllerType.Joystick => fNjQaUsaZdVbwhWgbqICGshugGQP(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => KCqEHPFAKnqHYFUMHZrBPIRnwyQn(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => mjcCykELSaxZSJtiwBdQjBwjdhqqc(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => SDNuupNdNaBrtSKqYEuWmjSGorXy(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return VbQsIGzjmYRrgPuTXCkSAZTmoZbc(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return sVCIDVHbmjBdXODtBjAQejjzEwRBA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return WPfdkfazxozGZdkEqLswzkAMRheG(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return NNQpLyRiTAymWcQEqSNihJjaTZqA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int fNjQaUsaZdVbwhWgbqICGshugGQP(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int VbQsIGzjmYRrgPuTXCkSAZTmoZbc(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int KCqEHPFAKnqHYFUMHZrBPIRnwyQn(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int sVCIDVHbmjBdXODtBjAQejjzEwRBA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int mjcCykELSaxZSJtiwBdQjBwjdhqqc(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int WPfdkfazxozGZdkEqLswzkAMRheG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int SDNuupNdNaBrtSKqYEuWmjSGorXy(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int NNQpLyRiTAymWcQEqSNihJjaTZqA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH : BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper yepQsTSAGCouYmdWaZujRDWmqzeU;

			public readonly PollingHelper polling = PollingHelper.lNSgwWgfjIjIYHBMJCfEpNjStetc;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.DuPuCnuoIHPLIJQMbHHmkhcAmiWp;

			internal static ControllerHelper EyLxuJgyUntPEmJHLKfpBTvBavPb => yepQsTSAGCouYmdWaZujRDWmqzeU ?? (yepQsTSAGCouYmdWaZujRDWmqzeU = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.dEIZKiBpKfKatNkoeKJarxNAGWCV;
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
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.ltjvSYGqPasbUgqxiBZNzVFbRElq;
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
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.MojdWfKBpNKzYvgrFqSyOknzCmgl;
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
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.WbGyhovABrZvNbHXBQtDZzjtIeFm;
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
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.qHNpazdlcHQNVocnmulXYfyMuYzA;
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
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS;
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
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.VoblREuvmSdxTWYQiDXrETWyuEMy;
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
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.IfTvqDIDVwBeMcQkrHzvybKdhoIAb;
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
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.WbGyhovABrZvNbHXBQtDZzjtIeFm as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return YNZnkUUWdETsfnFwfyPUjVPxExCq.MojdWfKBpNKzYvgrFqSyOknzCmgl as T;
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
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.FJiNERFMwUDilNHrWEgQjOqbPMAh(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.NJmAcFapVCMDPfbaZNDUXOgZErLS(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.ccRPGFMXznQZjLthcGkEkZbrghCe(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.uRTNGJPlIxItEVRvuPpYReqGCVJj(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.hKgzQLzMimanKYZnYAtStoHNIpcb(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.SpSZlMvyOXBRiBxsgupmwbmbFjRX(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.FennzzbDaTIEDHXzmpJgfXyKUBFpA(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BIeoRJtgpppJNOjultHrXTwltUhx.WYUHfojTJRKYuvmSUmpSwjhXJLEk(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BIeoRJtgpppJNOjultHrXTwltUhx.EFOgfZdHsCfIqoSBGvNkveodmxrUA(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.jXDhPVbEhpTlzUnGofGzsIWldtafA(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.zJeKNppoaNzdyzqdCmEpNcnbckVbA();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.eyCBLpVKiCUiiMNUnzokMXQwGBqp();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.bdKzsrEsGsOnUDkUGshKwgmtwtWb(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.XVZjqdsVftiWjqJOTXCevEGnDHBs(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.UYegdeaXzxxYbxqxuboABAlxXVfE(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BIeoRJtgpppJNOjultHrXTwltUhx.XHtitfXmatfTPnYIciQOQpDnEfLF(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BIeoRJtgpppJNOjultHrXTwltUhx.DKkJnKtkADaAPIUcGnHgeDNKritLB(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!XLNDDcaMaxOAKOmtpXwruqtrrEuEA)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				bjxSqXBHPqUsmJdMvJwbOPIYgagJ();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (KSgAuiFhzvuGaETjmRAWYUDbeErP.zvJrTgWUZqomHzczkKTuUwIvhdqx(i, j))
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
				if (!XLNDDcaMaxOAKOmtpXwruqtrrEuEA)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				bjxSqXBHPqUsmJdMvJwbOPIYgagJ();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (KSgAuiFhzvuGaETjmRAWYUDbeErP.zvJrTgWUZqomHzczkKTuUwIvhdqx(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (KSgAuiFhzvuGaETjmRAWYUDbeErP.FjqTZpKcvOAYPTSNYhaNYRshYHtO(i, k, positiveAxesOnly))
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
					if (!XLNDDcaMaxOAKOmtpXwruqtrrEuEA)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						cMbGYfgcXpZcVeWLLwrCPlgsDUNx.SetUnityJoystickId(joystickId, unityJoystickId);
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
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.BdCZAtyTlYbsPszaTDYTUbxFoSBl(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.KaKhnbDlvkqXFpwGjVJByxoezpqg();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.vxLEzDhWxtBdpAXSsqxujGTdtAMO();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.jxigLlCkHVhQirFRysODjaHSKpxzA(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.rIzJpBpjTIyztewPfOcOpaHjAYCdA(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.likVvwkeiQfXaHHnQLVDktrObpapA(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BIeoRJtgpppJNOjultHrXTwltUhx.cEzjsIjKqFTXRqNkhkjilKNstDzg(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					BIeoRJtgpppJNOjultHrXTwltUhx.olbgONITRLatKcqxLZhHqkUxBoWEA(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.NLzlMtxpmeUuvzoGWKnjaIzBvDLD(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = YNZnkUUWdETsfnFwfyPUjVPxExCq.NLzlMtxpmeUuvzoGWKnjaIzBvDLD(sourceControllerId);
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
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.qOPpbDRWYqtMKjOlKdrWHKXxRkfC(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.caTzebsfovZvwbPDlGKAHiBSbZgV(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.VIPDJKMeZMlpcOfJqrFLhHupRrdy(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.dTOrHbgFCEVtxdqpFUPkEffxrgSU(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.cOltHAjcAXDTpnBJMSDfQcoBUIkw(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.ZYbaHWzSNwwTMLNxlkTIPBRDBiVGA<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.RsLBpxiiSzdFDOgFeSCbhQNASkMCb();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.zEbHmcCgAzCYMFSKEBlUblRaUBXWB(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.RsLBpxiiSzdFDOgFeSCbhQNASkMCb<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.hyFwmTPcrfXrXwMYSRuQqSvsRfLq();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					YNZnkUUWdETsfnFwfyPUjVPxExCq.fWBTJGdozotbfdLvZyOPxHDsudkw(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					YNZnkUUWdETsfnFwfyPUjVPxExCq.DXwrTYrhtsWroWDCFChPKZgtVNiI(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					YNZnkUUWdETsfnFwfyPUjVPxExCq.GMakonxJliVqNqokVtWyPGjkCOzi(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					YNZnkUUWdETsfnFwfyPUjVPxExCq.TdOAMfrooNnMsyqDcXcUginnLUDD(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					YNZnkUUWdETsfnFwfyPUjVPxExCq.xDLcJXRbgQpxtSmwPuXpwkhVCQjd();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.YMOkWPBFkuAOvEbuJqxTUUpcGpdU();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.bUltwaEQmsjZteCIJcYQbZwnDZGqA(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.zFHwAolbyCTREdOBNkeWZnyKdtAU();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.czwlATmomEnmkTdbVkVpmkwaFQKh(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.AuzPaDohBsldrIExVgkofTlOZrXKA();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.kWiAkgSeMXGSldyxbysQftQaDlN(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.NoXZwEolZVJIBzKhpjDIFDxanCvJA();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.KbdJOOjeiWuCOSScbiTJiKVAdgdN(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.mFxEIeqXbBgHEbqGoYMqPwVKfYIjA();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.tWPkxtpDeHBzFYgDvDlcvdXAbdSn(controllerType);
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
				BIeoRJtgpppJNOjultHrXTwltUhx.tDoopMAISoyhWFONCqEESDzFEcCI(joystick);
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
			private static MappingHelper EkzQCEqRluERpOhzeHhiSMRtdaRd;

			internal static MappingHelper VqYsfQFEkIgEwgOKkQQSXgeKFdNAA => EkzQCEqRluERpOhzeHhiSMRtdaRd ?? (EkzQCEqRluERpOhzeHhiSMRtdaRd = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.kWSpTYDgTfmDHLUsnrDJbZABxhFs;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.awVOjRJJZJEvYRhmqAugFrECBEWo;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ZmWayRBOslTvXKHlPxFwIPKsfTVJA;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.OgeCvvCRBRqEjUBXcMstfDsyRZxpA;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.uasGjggZybOPfmhZOYGCifMIJfvQA;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.KsFxPkZyQnAOBqWeVdhEHDQgJbEN;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.PcVhUEvtdAfwGrqpOqOBoActLCcn;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.MbUiHxbssjHZMTXkNQgmHhgIvRoO;
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
					return lQrqwhCfIfIgktHXoHKYyChngzyX.zDegZifxhvKwqdNZQWkPQxguqoRu;
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
					return xXNYybZYVXuCDBsfcGvDXJSXkuEl.YyRwHhTyPersPbKCYWjGScUbGFCz;
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
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.cWGxChMMjjCZfgujpDvJWkgxaKCW(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.fFIgdFAOYQWWAdsjJbfgXWQJDPWh(tag);
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
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.DemXSmhlZuCXlcNbwewUlwkWBCau(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.hKXYTiLotDhfMZSIAjfuOJHNgJhV(tag);
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
					ControllerType.Joystick => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetCustomControllerLayoutById(layoutId), 
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
					ControllerType.Joystick => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetJoystickLayout(name), 
					ControllerType.Keyboard => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetKeyboardLayout(name), 
					ControllerType.Mouse => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetMouseLayout(name), 
					ControllerType.Custom => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetCustomControllerLayout(name), 
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
					ControllerType.Joystick => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetMouseLayoutId(name), 
					ControllerType.Custom => xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetCustomControllerLayoutId(name);
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
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.RHJTdCsKbaLsvklPwcKOLJfiUurD(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.RHJTdCsKbaLsvklPwcKOLJfiUurD(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.llXoDYIaeAHCaKeIbDDpIzSfgTHKb(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.llXoDYIaeAHCaKeIbDDpIzSfgTHKb(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.ujpuGarHQXSddElzRQUTVElGCvft(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.IDrZVnjRiPTFCACCBVAoGRogphTO(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.IDrZVnjRiPTFCACCBVAoGRogphTO(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.bYvURWLXXxFVhDdlDGefNglOcInB(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.bYvURWLXXxFVhDdlDGefNglOcInB(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.NvFilYvRjbHxgmgfnyIyVkaoPTTE(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.NvFilYvRjbHxgmgfnyIyVkaoPTTE(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.VpuNDZZuzINQmbsfHDcBrOyCzwtf(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return YNZnkUUWdETsfnFwfyPUjVPxExCq.OyKOFlNzKDxseCZpbakxpSXhTRdF(playerId, behaviorName);
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
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior JERDmxmjXTZcYmQpopFiMELrnhYp(int P_0)
			{
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetInputBehaviorById(P_0);
			}

			internal InputBehavior CDWDVaBbVianLEBBnCqqRATNygcOA(string P_0)
			{
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetInputBehavior(P_0);
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
				Controller controller = YNZnkUUWdETsfnFwfyPUjVPxExCq.NJmAcFapVCMDPfbaZNDUXOgZErLS(controllerIdentifier);
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
				JoystickMap joystickMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.cEwcgjjduDknbeUijZLXUaDeJMmZ(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.YdxptuxNGpUaQtWkYqBlEXOcgbkk(joystickMap);
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
				InputSource inputSourceType = cMbGYfgcXpZcVeWLLwrCPlgsDUNx.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = WqqeZZGjXiwIahHYdDlDUFCDdyOiA.kuDTkCRUswjvXiZZxIFpUHpjvldV(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.WPVOclMlLgNtstndhCwCmTydQORu(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.vdWUSpIFvdQJSkPvGFyhdyPVaUQzA(joystickMap, hardwareControllerMap_Game);
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
				if (YNZnkUUWdETsfnFwfyPUjVPxExCq.NJmAcFapVCMDPfbaZNDUXOgZErLS(controllerIdentifier) is Joystick joystick)
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
				KeyboardMap keyboardMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.YdxptuxNGpUaQtWkYqBlEXOcgbkk(keyboardMap);
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
				MouseMap mouseMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.YdxptuxNGpUaQtWkYqBlEXOcgbkk(mouseMap);
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
				CustomControllerMap customControllerMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.RifLOhoZwdAImmgTfQyFqnUIpNjg(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.YdxptuxNGpUaQtWkYqBlEXOcgbkk(customControllerMap);
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
				if (YNZnkUUWdETsfnFwfyPUjVPxExCq.NJmAcFapVCMDPfbaZNDUXOgZErLS(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.CtlgoRWNZjPivjmbrsinEqCNgeri(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.vdWUSpIFvdQJSkPvGFyhdyPVaUQzA(customControllerMap, hardwareControllerMap_Game);
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
					controllerMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.zQmRzuxxMzBJuAOvKUHvmpMofonu(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.CsUcoIEdaYqkNpAMGzzHSHTgKUySA(controller, controllerMap);
					}
					else
					{
						controller.YdxptuxNGpUaQtWkYqBlEXOcgbkk(controllerMap);
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
				if (YNZnkUUWdETsfnFwfyPUjVPxExCq.NJmAcFapVCMDPfbaZNDUXOgZErLS(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = cMbGYfgcXpZcVeWLLwrCPlgsDUNx.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = WqqeZZGjXiwIahHYdDlDUFCDdyOiA.kuDTkCRUswjvXiZZxIFpUHpjvldV(controllerIdentifier.hardwareTypeGuid, inputSourceType);
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
					joystickMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.WPVOclMlLgNtstndhCwCmTydQORu(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
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
						allMap.vdWUSpIFvdQJSkPvGFyhdyPVaUQzA(joystickMap, hardwareControllerMap_Game);
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
				if (YNZnkUUWdETsfnFwfyPUjVPxExCq.NJmAcFapVCMDPfbaZNDUXOgZErLS(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
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
					customControllerMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.CtlgoRWNZjPivjmbrsinEqCNgeri(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.vdWUSpIFvdQJSkPvGFyhdyPVaUQzA(customControllerMap, hardwareControllerMap_Game);
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
					keyboardMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.CsUcoIEdaYqkNpAMGzzHSHTgKUySA(keyboard, keyboardMap);
					}
					else
					{
						keyboard.YdxptuxNGpUaQtWkYqBlEXOcgbkk(keyboardMap);
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
					mouseMap = xXNYybZYVXuCDBsfcGvDXJSXkuEl.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.CsUcoIEdaYqkNpAMGzzHSHTgKUySA(mouse, mouseMap);
					}
					else
					{
						mouse.YdxptuxNGpUaQtWkYqBlEXOcgbkk(mouseMap);
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
				return dBxcJIDnoMNAidCOBVsoFZIkNAeVB(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier dBxcJIDnoMNAidCOBVsoFZIkNAeVB(Guid P_0, int P_1)
			{
				HardwareJoystickMap hardwareControllerMap;
				return WqqeZZGjXiwIahHYdDlDUFCDdyOiA.ehdHlrNGsSWjmvTIqxPMQtZBQGki(P_0, P_1, out hardwareControllerMap)?.ToControllerElementIdentifier(hardwareControllerMap);
			}

			internal int RhkeUOeywqPswCCGBjjAPhWuxqGb(Guid P_0, Guid P_1, int P_2, List<HardwareControllerTemplateMap.ovLXoyvOyAIvHyJVxtrGqFYCplsV> P_3)
			{
				return WqqeZZGjXiwIahHYdDlDUFCDdyOiA.wQbKxjGGKJMTpxrjfiRpEjAcFpdcA(P_0, P_1, P_2, P_3);
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.OWKJfjNzsEBgUBrwFaOawApxSgNn(templateTypeGuid, mapCategoryId, layoutId);
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
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetControllerMapLayoutManagerRuleSetId(name);
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
				return xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper iAvFhQWibugMoCvyuKJvthkJeoRDA;

			internal static PlayerHelper cxIiVayiAALCnbqQeAGYqSFrHDNEA => iAvFhQWibugMoCvyuKJvthkJeoRDA ?? (iAvFhQWibugMoCvyuKJvthkJeoRDA = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return BIeoRJtgpppJNOjultHrXTwltUhx.MAShPKKnbATAFLRWtWcZveXJQFbZ;
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
					return BIeoRJtgpppJNOjultHrXTwltUhx.sioooHayORrWlgDepTgNQcWmyHqn;
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
					return BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb;
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
					return BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH;
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
					return BIeoRJtgpppJNOjultHrXTwltUhx.TjnOdGcnoTiIujHJzGeRHFXfoKtbb();
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
					return BIeoRJtgpppJNOjultHrXTwltUhx.sMalrQnbUjebJHEHhcHBxfuzkigcb;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.XavrOVNYUlxVBmAFjuhpuXIcfxaH;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.UvJedjalXzUlKEDfIYQQGGlTWIFK(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.erNGFwEGrTRGakctWpmpEvjArXUl(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.TjnOdGcnoTiIujHJzGeRHFXfoKtbb();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.RyDAgibqhBJJvgBRBHYxZKcARruGB(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.DiLXbntIPOlezDqOcSyNwBrUnFrs(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.wNFDdUooawLBTfTZMQGREyCawTdq(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return BIeoRJtgpppJNOjultHrXTwltUhx.OViLpuHhSVyjRfNwbWeBMZnDukIM(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper XGuAbUgoIKmusInpsmVSLiVVffjpA;

			internal static TimeHelper bASOhdDdgmnTqTdSQWuLtdBwOHCy => XGuAbUgoIKmusInpsmVSLiVVffjpA ?? (XGuAbUgoIKmusInpsmVSLiVVffjpA = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)iMAGamCsRNlowcOTxDCXztCIoxHzA.LAMPQvVdOdorRpjXUrUEUpvnaLfbA;
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
					return iMAGamCsRNlowcOTxDCXztCIoxHzA.WmNpvWQrYjAECoHCBKJgDeCRAzobA;
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
					return iMAGamCsRNlowcOTxDCXztCIoxHzA.LTWPkVFJUqNIlFVzngMkIFsKAcUO;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class ObAiMlISWHwckOMLHDGREerXMJiuA
		{
			private class JHryuVbtIXDZNlBRuidWEzSWNuS
			{
				public readonly UpdateLoopType MwimZkOIGOjaosVaHMPSeXYnKuje;

				private double JThnVZGmiODAvPELOfRHjzwNtGJZ;

				private double FCfwtFDZBSNAlpHREOwMNXWKwwAH;

				private double YiLzvISfsxHltLTaNdwlmIYozZqH;

				private double BIsFPuDCIQuHVWcbtpzLBskAckZZb;

				private uint RuwlluPQeWdeFnsggqaMfSLlhSqH;

				private uint aaDMkLxXsJUPyKImakhCJwBAWoPB;

				private float pTVeGUcICnWGbTzhGZFDiATDAdIc;

				private float iHsTFldwYaEjJKGDDdjyCZOqlLIh;

				public double VmszuygEVGGDYdNOtVBQPdKqdbMkA => JThnVZGmiODAvPELOfRHjzwNtGJZ;

				public double XVKVjCknXNpvIVfhcwjhIETPWCzn => FCfwtFDZBSNAlpHREOwMNXWKwwAH;

				public double usDiYZXSZakrxGrFGczMgbXnxcVD => YiLzvISfsxHltLTaNdwlmIYozZqH;

				public uint ZgrcfgsCUFZcJDCaoVlpAvceDanu => RuwlluPQeWdeFnsggqaMfSLlhSqH;

				public uint pXoWGRUxxrJFRWoNUUHIkSMPgCHi => aaDMkLxXsJUPyKImakhCJwBAWoPB;

				public float rBvGdQZtTQuUXvennRrQBfHOdBMfA => pTVeGUcICnWGbTzhGZFDiATDAdIc;

				public float TBkrKYioezaKkzHAAJInizqhpSUpA => iHsTFldwYaEjJKGDDdjyCZOqlLIh;

				public JHryuVbtIXDZNlBRuidWEzSWNuS(UpdateLoopType P_0)
				{
					MwimZkOIGOjaosVaHMPSeXYnKuje = P_0;
					BIsFPuDCIQuHVWcbtpzLBskAckZZb = Time.realtimeSinceStartup;
					RuwlluPQeWdeFnsggqaMfSLlhSqH = 0u;
				}

				public void lYzTeOEdMipoIzugizBiwXkyBxjF()
				{
					FCfwtFDZBSNAlpHREOwMNXWKwwAH = JThnVZGmiODAvPELOfRHjzwNtGJZ;
					JThnVZGmiODAvPELOfRHjzwNtGJZ = realTime;
					if (BIsFPuDCIQuHVWcbtpzLBskAckZZb > JThnVZGmiODAvPELOfRHjzwNtGJZ)
					{
						BIsFPuDCIQuHVWcbtpzLBskAckZZb = 0.0;
					}
					YiLzvISfsxHltLTaNdwlmIYozZqH = JThnVZGmiODAvPELOfRHjzwNtGJZ - BIsFPuDCIQuHVWcbtpzLBskAckZZb;
					BIsFPuDCIQuHVWcbtpzLBskAckZZb = JThnVZGmiODAvPELOfRHjzwNtGJZ;
					aaDMkLxXsJUPyKImakhCJwBAWoPB = RuwlluPQeWdeFnsggqaMfSLlhSqH;
					RuwlluPQeWdeFnsggqaMfSLlhSqH = MiscTools.Tick(RuwlluPQeWdeFnsggqaMfSLlhSqH);
					iHsTFldwYaEjJKGDDdjyCZOqlLIh = pTVeGUcICnWGbTzhGZFDiATDAdIc;
					pTVeGUcICnWGbTzhGZFDiATDAdIc = lAEVusYvRzqnnjmfsgPnJdjNMgfOA();
					previousFrame = aaDMkLxXsJUPyKImakhCJwBAWoPB;
					currentFrame = RuwlluPQeWdeFnsggqaMfSLlhSqH;
					unscaledTime = JThnVZGmiODAvPELOfRHjzwNtGJZ;
					unscaledTimePrev = FCfwtFDZBSNAlpHREOwMNXWKwwAH;
					unscaledDeltaTime = YiLzvISfsxHltLTaNdwlmIYozZqH;
				}
			}

			private static class sNUmZtOAjKntENjtFfnnTsbXXODw
			{
				public static StopwatchBase ulMoARLPxCakvxLEYbhomAomIICn
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

				public static StopwatchBase dgtnUMnVHeqptjaBnEAtFjKxENNJA()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase uzIVQCodLkeOQIiBTiHTOjbtevxeb()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase SAMnyddsrOJnKEuoDSsUAanHmsOt;

			private double kxugskEfvLDqSpHJDYqUNrASvcZiA;

			private JHryuVbtIXDZNlBRuidWEzSWNuS UXNFQQcJDRNnbLmMgxqxibrLDsIp;

			private ADictionary<int, JHryuVbtIXDZNlBRuidWEzSWNuS> tUBgEbOIhGNCJmBfmpgxBGqbytvC;

			private uint NOTRwBozLrjGJAnadJVjusByccYT;

			public double WmNpvWQrYjAECoHCBKJgDeCRAzobA => UXNFQQcJDRNnbLmMgxqxibrLDsIp.VmszuygEVGGDYdNOtVBQPdKqdbMkA;

			public double WrCUkdvLLJFlkieDLVxwXFLaHlj => UXNFQQcJDRNnbLmMgxqxibrLDsIp.XVKVjCknXNpvIVfhcwjhIETPWCzn;

			public double LAMPQvVdOdorRpjXUrUEUpvnaLfbA => UXNFQQcJDRNnbLmMgxqxibrLDsIp.usDiYZXSZakrxGrFGczMgbXnxcVD;

			public float KVtGitDJtPIDlktzCcPnguOyfNNS => UXNFQQcJDRNnbLmMgxqxibrLDsIp.rBvGdQZtTQuUXvennRrQBfHOdBMfA;

			public float NhBkczLIehlkVmHOqbmXHFJIrVsNA => UXNFQQcJDRNnbLmMgxqxibrLDsIp.TBkrKYioezaKkzHAAJInizqhpSUpA;

			internal double KkcaCjwNFwXBlUMlCmjcFwqLgNaX => SAMnyddsrOJnKEuoDSsUAanHmsOt.elapsedSeconds + kxugskEfvLDqSpHJDYqUNrASvcZiA;

			public uint LTWPkVFJUqNIlFVzngMkIFsKAcUO => UXNFQQcJDRNnbLmMgxqxibrLDsIp.ZgrcfgsCUFZcJDCaoVlpAvceDanu;

			public uint LgxAzdKkAkRegymSWtFkIjfPzqnC => UXNFQQcJDRNnbLmMgxqxibrLDsIp.pXoWGRUxxrJFRWoNUUHIkSMPgCHi;

			public uint fVcffBUAxfcueeCUAQAyZkYOSPmpA => NOTRwBozLrjGJAnadJVjusByccYT;

			public ObAiMlISWHwckOMLHDGREerXMJiuA()
			{
				SAMnyddsrOJnKEuoDSsUAanHmsOt = sNUmZtOAjKntENjtFfnnTsbXXODw.ulMoARLPxCakvxLEYbhomAomIICn;
				woTrqsreBxBnsdTxcJakpucBSTZGb();
			}

			public void vPSicIubhdqeWXoLsyRrwyOSwHd()
			{
				kxugskEfvLDqSpHJDYqUNrASvcZiA = Time.realtimeSinceStartup;
			}

			public void woTrqsreBxBnsdTxcJakpucBSTZGb()
			{
				UXNFQQcJDRNnbLmMgxqxibrLDsIp = null;
				tUBgEbOIhGNCJmBfmpgxBGqbytvC = new ADictionary<int, JHryuVbtIXDZNlBRuidWEzSWNuS>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)(-1), list);
				for (int i = 0; i < list.Count; i++)
				{
					JHryuVbtIXDZNlBRuidWEzSWNuS jHryuVbtIXDZNlBRuidWEzSWNuS = new JHryuVbtIXDZNlBRuidWEzSWNuS(list[i]);
					tUBgEbOIhGNCJmBfmpgxBGqbytvC.Add((int)list[i], jHryuVbtIXDZNlBRuidWEzSWNuS);
					if (UXNFQQcJDRNnbLmMgxqxibrLDsIp == null)
					{
						UXNFQQcJDRNnbLmMgxqxibrLDsIp = jHryuVbtIXDZNlBRuidWEzSWNuS;
					}
				}
			}

			public void kVsDjmKhNbQIjDeuhsdhfOlcEobkC(UpdateLoopType P_0)
			{
				if (UXNFQQcJDRNnbLmMgxqxibrLDsIp.MwimZkOIGOjaosVaHMPSeXYnKuje != P_0)
				{
					UXNFQQcJDRNnbLmMgxqxibrLDsIp = tUBgEbOIhGNCJmBfmpgxBGqbytvC[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					UXNFQQcJDRNnbLmMgxqxibrLDsIp.lYzTeOEdMipoIzugizBiwXkyBxjF();
					NOTRwBozLrjGJAnadJVjusByccYT = MiscTools.Tick(NOTRwBozLrjGJAnadJVjusByccYT);
					absFrame = NOTRwBozLrjGJAnadJVjusByccYT;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch qUZUcZdKUmBqRsOsSYTVmEkooXSj;

			internal static UnityTouch GngqCadyvdKWDgZjXDXyTWPeQtmX => qUZUcZdKUmBqRsOsSYTVmEkooXSj ?? (qUZUcZdKUmBqRsOsSYTVmEkooXSj = new UnityTouch());

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

		internal class zTFKKBYaVEeiJaeeczzBWrSnNCT
		{
			[Serializable]
			private sealed class yXNVYYxdxiZkfMfEDgrOGtGtFLgrA
			{
				public static readonly yXNVYYxdxiZkfMfEDgrOGtGtFLgrA _003C_003E9 = new yXNVYYxdxiZkfMfEDgrOGtGtFLgrA();

				public static Func<bool> _003C_003E9__12_1;

				public static Func<bool> _003C_003E9__12_2;

				public static Func<int> _003C_003E9__12_3;

				public static Func<float> _003C_003E9__12_4;

				public static Func<bool> _003C_003E9__12_5;

				public static Func<string> _003C_003E9__12_0;

				internal bool iGdPyhdMQlhWvJtzwADFAuAmpgib()
				{
					return Screen.fullScreen;
				}

				internal bool DJdQkfMvHYUJxGjBcpgQikZUJZys()
				{
					return Application.runInBackground;
				}

				internal int ywzXKMnqipuckQfPMglKBPIXaPaN()
				{
					return (int)Screen.fullScreenMode;
				}

				internal float eVEFUHhliIbcZlvjwhPiVnaldTrQA()
				{
					return Time.unscaledDeltaTime;
				}

				internal bool vVPfqEQvJVerwaQNuhjOryvmMZnhA()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				internal string IVDgxuSMGyqUYWSLwnmYKzkpmQnr()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}
			}

			public readonly ValueWatcher<bool> awgGPyKVJGmFmyMkfNyZUJGiMbjK;

			public readonly ValueWatcher<bool> iWKGRkLGQBbbogHwESOOqKfBjBdDA;

			public readonly ValueWatcher<bool> QmSKQSvPntDjGRSlhhWRMoueDjqs;

			public readonly ValueWatcher<bool> wVDLLqIbMDHZaJCZnzXbBILjwTvR;

			public readonly ValueWatcher<int> qbDHgQOrirNsGZxfYNMTXZJSrJiU;

			public readonly ValueWatcher<float> VtqhWndnyxNVJELEtEpjEuXkIJNab;

			public readonly ValueWatcher<string> DdjoDkvgfpqLSCpeBGCzJoWqiBcNA;

			public readonly ValueWatcher<bool> IXIbwAFVTjYdmpmtyzoggovcWBQl;

			private int xMCvaBqsaxbqajsyyIUBasIbuaSpb;

			private readonly ValueWatcher[] OCBtfPQRgHsnhynPxFFbGRtXGHGL;

			public int KtJDODdEKcclscNWjTCrMLaIEovPB => xMCvaBqsaxbqajsyyIUBasIbuaSpb;

			public zTFKKBYaVEeiJaeeczzBWrSnNCT()
			{
				bool flag = UnityTools.isEditor || Application.isFocused;
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(awgGPyKVJGmFmyMkfNyZUJGiMbjK = new ValueWatcher<bool>(flag, false)),
					(iWKGRkLGQBbbogHwESOOqKfBjBdDA = new ValueWatcher<bool>(false, false)),
					(QmSKQSvPntDjGRSlhhWRMoueDjqs = new ValueWatcher<bool>(Screen.fullScreen, yXNVYYxdxiZkfMfEDgrOGtGtFLgrA._003C_003E9.iGdPyhdMQlhWvJtzwADFAuAmpgib, false)),
					(wVDLLqIbMDHZaJCZnzXbBILjwTvR = new ValueWatcher<bool>(Application.runInBackground, yXNVYYxdxiZkfMfEDgrOGtGtFLgrA._003C_003E9.DJdQkfMvHYUJxGjBcpgQikZUJZys, false)),
					(qbDHgQOrirNsGZxfYNMTXZJSrJiU = new ValueWatcher<int>((int)Screen.fullScreenMode, yXNVYYxdxiZkfMfEDgrOGtGtFLgrA._003C_003E9.ywzXKMnqipuckQfPMglKBPIXaPaN, false)),
					(VtqhWndnyxNVJELEtEpjEuXkIJNab = new ValueWatcher<float>(Time.unscaledDeltaTime, yXNVYYxdxiZkfMfEDgrOGtGtFLgrA._003C_003E9.eVEFUHhliIbcZlvjwhPiVnaldTrQA, false)),
					(IXIbwAFVTjYdmpmtyzoggovcWBQl = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), yXNVYYxdxiZkfMfEDgrOGtGtFLgrA._003C_003E9.vVPfqEQvJVerwaQNuhjOryvmMZnhA, MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(DdjoDkvgfpqLSCpeBGCzJoWqiBcNA = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), yXNVYYxdxiZkfMfEDgrOGtGtFLgrA._003C_003E9.IVDgxuSMGyqUYWSLwnmYKzkpmQnr, false));
				}
				OCBtfPQRgHsnhynPxFFbGRtXGHGL = list.ToArray();
				usUhyGfMbLwoPIHzlTXfAAZJfBIk();
			}

			public void usUhyGfMbLwoPIHzlTXfAAZJfBIk()
			{
				for (int i = 0; i < OCBtfPQRgHsnhynPxFFbGRtXGHGL.Length; i++)
				{
					OCBtfPQRgHsnhynPxFFbGRtXGHGL[i].Update();
				}
				xMCvaBqsaxbqajsyyIUBasIbuaSpb = Time.frameCount;
			}

			public void DkZrYwCVatrUlLVTFfbJEvJoECYF()
			{
				for (int i = 0; i < OCBtfPQRgHsnhynPxFFbGRtXGHGL.Length; i++)
				{
					OCBtfPQRgHsnhynPxFFbGRtXGHGL[i].TriggerEvent();
				}
			}
		}

		[Serializable]
		private sealed class PJDYUOszZjqZwFbOfBkBfzRJGDOPA
		{
			public static readonly PJDYUOszZjqZwFbOfBkBfzRJGDOPA _003C_003E9 = new PJDYUOszZjqZwFbOfBkBfzRJGDOPA();

			public static Func<bool> _003C_003E9__235_0;

			internal void hLRxkrXcnlCXGnTyRotNVHlgsyfq(Exception P_0)
			{
				HandleCallbackException("", P_0);
			}

			internal void twgxxXUOMusHDrpUXSTfQYVvHLlB(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			}

			internal void YlYYchmldynRRXmblTNZwuWyAnNH(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			}

			internal void uVgynewONsAGZAbduBNIvUTTagWf(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			}

			internal void XBUDujiyPChTsbVAOgyulNwfExsB(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			}

			internal void fTuKJnoCgFvVdLKAnbAdidaxKfPzA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			}

			internal void URBWRxHkpJLPBszMZfomKFnrghnkA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			}

			internal void UrGzvprCfqherfJeQnfjrogRDsCn(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			}

			internal void eleaVRcRMWoDEBHOMtQNCJJelRJUB(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			}

			internal bool zTUfbtBDLeBBHqaPaHdvFmhxHKHbb()
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
		internal const int programVersion3 = 59;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 0;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U6000";

		private static InputManager_Base nTgvXYFPzomGRpaiQbZRXhYwLMAf;

		private static PlatformInputManager cMbGYfgcXpZcVeWLLwrCPlgsDUNx;

		internal static IsRfGTyTEbMSFXGhXufpYZyPCKjB lQrqwhCfIfIgktHXoHKYyChngzyX;

		internal static GCkLfqNtcKbVwGxJyqaDoIgNIHaV YNZnkUUWdETsfnFwfyPUjVPxExCq;

		internal static qolSwVLcvXSMneGdcvjdFoTKDPcf BIeoRJtgpppJNOjultHrXTwltUhx;

		private static ControllerDataFiles WqqeZZGjXiwIahHYdDlDUFCDdyOiA;

		private static UserData xXNYybZYVXuCDBsfcGvDXJSXkuEl;

		private static bool hmFBGJpiuHNJVzQVWoNBgmpvGwLeA;

		private static ConfigVars HrUAQRgNyFTeOOnpzcHqEyFohaaP;

		private static UpdateLoopType iMFRVtmHVaJKZehGUKMBGOIIPUJ;

		private static bool XLNDDcaMaxOAKOmtpXwruqtrrEuEA;

		private static Platform FNXMLniCQqYMnNWenRaYOYgKoLUI;

		private static WebplayerPlatform wBjsroTdNCjCbqrzhFnSDhOHkhqb;

		private static EditorPlatform SnObwxrmQrFucHJbHtgfxcFfsgVbA;

		private static bool QQcdhVjggExuEfUgSydpPekaUKiaA;

		private static TimerAbs jhnjKEbfCpJxxLAWZtuhfkeOtrku;

		private static ObAiMlISWHwckOMLHDGREerXMJiuA iMAGamCsRNlowcOTxDCXztCIoxHzA;

		private static string LwLIKZdHRZiruWRlQkolIApbYBMn;

		private static bool VacLzjeOOJvdKkIuZNoAsPPKGmif;

		private static bool mBgFOoUewbZBNCLISAcDHKeWxsLpA;

		private static bool gxLRtCRiZsBFzmAfSpUVBNqATCtl;

		private static int xLhczqpjKVXIbHKZNIidFVGOHnDT;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int LMrzFnfFwZLuKvgNDxviTqotVQIX;

		private static int gBoQHAgxjzDmnCSeUrZbIURQqWUI;

		private static bool xRfDundGKGRYyvPloUJWLwKKVQpe;

		private static readonly UnityTouch VydbENfssECMYHpsSLUZvPaIpXhCb;

		private static readonly PlayerHelper GzWGvVBcihwkqJAlAoRUfDQcmtbsb;

		private static readonly ControllerHelper zlvenbEwqKADKhEtaUfrCUTejBHqb;

		private static readonly MappingHelper EpPZTcCLBifOAikfetgTmzNciEkRA;

		private static readonly TimeHelper CfugBHAdQlSwodDNnKVtNJqZxAbR;

		private static readonly ConfigHelper MvyGIbzzsIhqOpOUkyUJCutAAOOI;

		private static readonly LocalizationHelper iOjBxBcPtlcmlteYnmHLBpITEkIL;

		private static readonly GlyphHelper fUnYoWNbZZQXgqQhJEnWQvVztSQq;

		private static biVSrAHcVRQItzRAZoqLcvJKFnAc riGFHXySMEGPUNiXKVBfZaKZpFdF;

		private static UserDataStore DkqhFjAYixqDReFBGalaZEZZZbyq;

		private static IControllerAssigner QtUfFGUJUlJidLRCnJNWGXcGPpJq;

		private static zTFKKBYaVEeiJaeeczzBWrSnNCT TssdUiFyAapgxHwMFTbxMlJkxkrD;

		private static SafeAction<ControllerStatusChangedEventArgs> FMGFxxbrJtXTQJOIYTHvYvLSigmK;

		private static SafeAction<ControllerStatusChangedEventArgs> gtqRzBkmWwLjMQQRyRYfzCMmLvoH;

		private static SafeAction<ControllerStatusChangedEventArgs> XoogoCmRKSixSVfIWfnZSUBnQByA;

		private static SafeAction QgwrhtqtiKPdlKRqgezNhnjcjFib;

		private static SafeAction yWGyjSKucqHicoLUtjeNFvLezxEh;

		private static SafeAction igsqWtuPboMlIeGaRwDHIXoCmivp;

		private static SafeAction mLqywIosKXHUjRBZnKvUWmUWMYTR;

		private static SafeAction mDAqfVvXNuXgzRIqnbhgDbqTehXK;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationPauseChangedEvent;

		private static Action gHBAPSOldfyHuXvNdIiUeMikImfBA;

		private static Action<UpdateLoopType> gMOqsdEhMGRQoxchOemblOzwUumO;

		private static Action<UpdateLoopType> YPRTsTCnNwvXiCNqjwhhpEfdSPZx;

		private static Action<UpdateLoopType> ndCHRYSYpUhvkRmUOTzAYAIgkjav;

		private static Action EkuAQDzsrBNVpqhQfsNiybQBUoJK;

		private static Action<bool> EtEzUGkcgTXgtAhMmsIakPTSxukK;

		private static Action<bool> rLxXEshqDNrMXJvWmxMwwpQiXxSD;

		private static Action<bool> LmJpSHyNsRCgeoPMyYtaFKkOSKyE;

		private static Action<FullScreenMode> HIlZYYvUrpalYHlWAKXVURqMNXom;

		private static Action WtdBMTHIezYQvkbxHeLvBFmxbNvaA;

		private static Action<bool> kmFgHDcOAVpRdKzeexAMAXPMfpkJA;

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

		private static biVSrAHcVRQItzRAZoqLcvJKFnAc KSgAuiFhzvuGaETjmRAWYUDbeErP => riGFHXySMEGPUNiXKVBfZaKZpFdF ?? (riGFHXySMEGPUNiXKVBfZaKZpFdF = new biVSrAHcVRQItzRAZoqLcvJKFnAc(HrUAQRgNyFTeOOnpzcHqEyFohaaP.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return GzWGvVBcihwkqJAlAoRUfDQcmtbsb;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return zlvenbEwqKADKhEtaUfrCUTejBHqb;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return EpPZTcCLBifOAikfetgTmzNciEkRA;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return VydbENfssECMYHpsSLUZvPaIpXhCb;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return CfugBHAdQlSwodDNnKVtNJqZxAbR;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return DkqhFjAYixqDReFBGalaZEZZZbyq;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return MvyGIbzzsIhqOpOUkyUJCutAAOOI;
			}
		}

		public static LocalizationHelper localization
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return iOjBxBcPtlcmlteYnmHLBpITEkIL;
			}
		}

		public static GlyphHelper glyphs
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return fUnYoWNbZZQXgqQhJEnWQvVztSQq;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 59 + "." + 0 + ".U6000";

		public static bool usingUnityInput => XLNDDcaMaxOAKOmtpXwruqtrrEuEA;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
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

		public static bool isReady => hmFBGJpiuHNJVzQVWoNBgmpvGwLeA;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => hmFBGJpiuHNJVzQVWoNBgmpvGwLeA;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => iMFRVtmHVaJKZehGUKMBGOIIPUJ;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => HrUAQRgNyFTeOOnpzcHqEyFohaaP;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => HrUAQRgNyFTeOOnpzcHqEyFohaaP;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => xXNYybZYVXuCDBsfcGvDXJSXkuEl;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => FNXMLniCQqYMnNWenRaYOYgKoLUI;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => wBjsroTdNCjCbqrzhFnSDhOHkhqb;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => SnObwxrmQrFucHJbHtgfxcFfsgVbA;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.Linux && XLNDDcaMaxOAKOmtpXwruqtrrEuEA)
				{
					return true;
				}
				if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.OSX && (XLNDDcaMaxOAKOmtpXwruqtrrEuEA || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && XLNDDcaMaxOAKOmtpXwruqtrrEuEA)
				{
					return true;
				}
				if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.Webplayer && wBjsroTdNCjCbqrzhFnSDhOHkhqb == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => SnObwxrmQrFucHJbHtgfxcFfsgVbA != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return Guid.Empty;
				}
				return WqqeZZGjXiwIahHYdDlDUFCDdyOiA.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => mBgFOoUewbZBNCLISAcDHKeWxsLpA;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => iMAGamCsRNlowcOTxDCXztCIoxHzA.KVtGitDJtPIDlktzCcPnguOyfNNS;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => iMAGamCsRNlowcOTxDCXztCIoxHzA.NhBkczLIehlkVmHOqbmXHFJIrVsNA;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return 0.0;
				}
				return iMAGamCsRNlowcOTxDCXztCIoxHzA.KkcaCjwNFwXBlUMlCmjcFwqLgNaX;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return 0;
				}
				return TssdUiFyAapgxHwMFTbxMlJkxkrD.KtJDODdEKcclscNWjTCrMLaIEovPB;
			}
		}

		private static bool LBTfbXExVZDhMWzlKRIYHNxXtWUK
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return LwLIKZdHRZiruWRlQkolIApbYBMn == "Game";
				}
				return LwLIKZdHRZiruWRlQkolIApbYBMn == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (HrUAQRgNyFTeOOnpzcHqEyFohaaP.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!gxLRtCRiZsBFzmAfSpUVBNqATCtl)
				{
					return LBTfbXExVZDhMWzlKRIYHNxXtWUK;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (cMbGYfgcXpZcVeWLLwrCPlgsDUNx is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return gxLRtCRiZsBFzmAfSpUVBNqATCtl;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return false;
				}
				if (!XLNDDcaMaxOAKOmtpXwruqtrrEuEA)
				{
					return false;
				}
				if (FNXMLniCQqYMnNWenRaYOYgKoLUI != Platform.Windows && (FNXMLniCQqYMnNWenRaYOYgKoLUI != Platform.Webplayer || wBjsroTdNCjCbqrzhFnSDhOHkhqb != WebplayerPlatform.Windows))
				{
					return SnObwxrmQrFucHJbHtgfxcFfsgVbA == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool zuVADykGVcOcubpnipURHknzkJfDA
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return false;
				}
				if (!TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.value)
				{
					if (xRfDundGKGRYyvPloUJWLwKKVQpe)
					{
						return false;
					}
					if ((!isEditor || !isUnityEditorFocused) && !TssdUiFyAapgxHwMFTbxMlJkxkrD.wVDLLqIbMDHZaJCZnzXbBILjwTvR.value)
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
				if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsPaused
		{
			get
			{
				if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return TssdUiFyAapgxHwMFTbxMlJkxkrD.iWKGRkLGQBbbogHwESOOqKfBjBdDA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return TssdUiFyAapgxHwMFTbxMlJkxkrD.QmSKQSvPntDjGRSlhhWRMoueDjqs.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return TssdUiFyAapgxHwMFTbxMlJkxkrD.wVDLLqIbMDHZaJCZnzXbBILjwTvR.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					return TssdUiFyAapgxHwMFTbxMlJkxkrD.IXIbwAFVTjYdmpmtyzoggovcWBQl.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => nTgvXYFPzomGRpaiQbZRXhYwLMAf;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
				{
					lttuDHGUmKgwixLFTJjaZSJblbCT();
					return null;
				}
				return cMbGYfgcXpZcVeWLLwrCPlgsDUNx.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return QtUfFGUJUlJidLRCnJNWGXcGPpJq;
			}
			set
			{
				QtUfFGUJUlJidLRCnJNWGXcGPpJq = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => gBoQHAgxjzDmnCSeUrZbIURQqWUI;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				FMGFxxbrJtXTQJOIYTHvYvLSigmK += value;
			}
			remove
			{
				FMGFxxbrJtXTQJOIYTHvYvLSigmK -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				gtqRzBkmWwLjMQQRyRYfzCMmLvoH += value;
			}
			remove
			{
				gtqRzBkmWwLjMQQRyRYfzCMmLvoH -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				XoogoCmRKSixSVfIWfnZSUBnQByA += value;
			}
			remove
			{
				XoogoCmRKSixSVfIWfnZSUBnQByA -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				QgwrhtqtiKPdlKRqgezNhnjcjFib += value;
			}
			remove
			{
				QgwrhtqtiKPdlKRqgezNhnjcjFib -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				yWGyjSKucqHicoLUtjeNFvLezxEh += value;
			}
			remove
			{
				yWGyjSKucqHicoLUtjeNFvLezxEh -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				igsqWtuPboMlIeGaRwDHIXoCmivp += value;
			}
			remove
			{
				igsqWtuPboMlIeGaRwDHIXoCmivp -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				mLqywIosKXHUjRBZnKvUWmUWMYTR += value;
			}
			remove
			{
				mLqywIosKXHUjRBZnKvUWmUWMYTR -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				mDAqfVvXNuXgzRIqnbhgDbqTehXK += value;
			}
			remove
			{
				mDAqfVvXNuXgzRIqnbhgDbqTehXK -= value;
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
				gHBAPSOldfyHuXvNdIiUeMikImfBA = (Action)Delegate.Combine(gHBAPSOldfyHuXvNdIiUeMikImfBA, value);
			}
			remove
			{
				gHBAPSOldfyHuXvNdIiUeMikImfBA = (Action)Delegate.Remove(gHBAPSOldfyHuXvNdIiUeMikImfBA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				gMOqsdEhMGRQoxchOemblOzwUumO = (Action<UpdateLoopType>)Delegate.Combine(gMOqsdEhMGRQoxchOemblOzwUumO, value);
			}
			remove
			{
				gMOqsdEhMGRQoxchOemblOzwUumO = (Action<UpdateLoopType>)Delegate.Remove(gMOqsdEhMGRQoxchOemblOzwUumO, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				YPRTsTCnNwvXiCNqjwhhpEfdSPZx = (Action<UpdateLoopType>)Delegate.Combine(YPRTsTCnNwvXiCNqjwhhpEfdSPZx, value);
			}
			remove
			{
				YPRTsTCnNwvXiCNqjwhhpEfdSPZx = (Action<UpdateLoopType>)Delegate.Remove(YPRTsTCnNwvXiCNqjwhhpEfdSPZx, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				ndCHRYSYpUhvkRmUOTzAYAIgkjav = (Action<UpdateLoopType>)Delegate.Combine(ndCHRYSYpUhvkRmUOTzAYAIgkjav, value);
			}
			remove
			{
				ndCHRYSYpUhvkRmUOTzAYAIgkjav = (Action<UpdateLoopType>)Delegate.Remove(ndCHRYSYpUhvkRmUOTzAYAIgkjav, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				EkuAQDzsrBNVpqhQfsNiybQBUoJK = (Action)Delegate.Combine(EkuAQDzsrBNVpqhQfsNiybQBUoJK, value);
			}
			remove
			{
				EkuAQDzsrBNVpqhQfsNiybQBUoJK = (Action)Delegate.Remove(EkuAQDzsrBNVpqhQfsNiybQBUoJK, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				EtEzUGkcgTXgtAhMmsIakPTSxukK = (Action<bool>)Delegate.Combine(EtEzUGkcgTXgtAhMmsIakPTSxukK, value);
			}
			remove
			{
				EtEzUGkcgTXgtAhMmsIakPTSxukK = (Action<bool>)Delegate.Remove(EtEzUGkcgTXgtAhMmsIakPTSxukK, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				rLxXEshqDNrMXJvWmxMwwpQiXxSD = (Action<bool>)Delegate.Combine(rLxXEshqDNrMXJvWmxMwwpQiXxSD, value);
			}
			remove
			{
				rLxXEshqDNrMXJvWmxMwwpQiXxSD = (Action<bool>)Delegate.Remove(rLxXEshqDNrMXJvWmxMwwpQiXxSD, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				LmJpSHyNsRCgeoPMyYtaFKkOSKyE = (Action<bool>)Delegate.Combine(LmJpSHyNsRCgeoPMyYtaFKkOSKyE, value);
			}
			remove
			{
				LmJpSHyNsRCgeoPMyYtaFKkOSKyE = (Action<bool>)Delegate.Remove(LmJpSHyNsRCgeoPMyYtaFKkOSKyE, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				HIlZYYvUrpalYHlWAKXVURqMNXom = (Action<FullScreenMode>)Delegate.Combine(HIlZYYvUrpalYHlWAKXVURqMNXom, value);
			}
			remove
			{
				HIlZYYvUrpalYHlWAKXVURqMNXom = (Action<FullScreenMode>)Delegate.Remove(HIlZYYvUrpalYHlWAKXVURqMNXom, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				WtdBMTHIezYQvkbxHeLvBFmxbNvaA = (Action)Delegate.Combine(WtdBMTHIezYQvkbxHeLvBFmxbNvaA, value);
			}
			remove
			{
				WtdBMTHIezYQvkbxHeLvBFmxbNvaA = (Action)Delegate.Remove(WtdBMTHIezYQvkbxHeLvBFmxbNvaA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				kmFgHDcOAVpRdKzeexAMAXPMfpkJA = (Action<bool>)Delegate.Combine(kmFgHDcOAVpRdKzeexAMAXPMfpkJA, value);
			}
			remove
			{
				kmFgHDcOAVpRdKzeexAMAXPMfpkJA = (Action<bool>)Delegate.Remove(kmFgHDcOAVpRdKzeexAMAXPMfpkJA, value);
			}
		}

		static ReInput()
		{
			gxLRtCRiZsBFzmAfSpUVBNqATCtl = true;
			xLhczqpjKVXIbHKZNIidFVGOHnDT = -1;
			_id = -1;
			LMrzFnfFwZLuKvgNDxviTqotVQIX = 0;
			VydbENfssECMYHpsSLUZvPaIpXhCb = UnityTouch.GngqCadyvdKWDgZjXDXyTWPeQtmX;
			GzWGvVBcihwkqJAlAoRUfDQcmtbsb = PlayerHelper.cxIiVayiAALCnbqQeAGYqSFrHDNEA;
			zlvenbEwqKADKhEtaUfrCUTejBHqb = ControllerHelper.EyLxuJgyUntPEmJHLKfpBTvBavPb;
			EpPZTcCLBifOAikfetgTmzNciEkRA = MappingHelper.VqYsfQFEkIgEwgOKkQQSXgeKFdNAA;
			CfugBHAdQlSwodDNnKVtNJqZxAbR = TimeHelper.bASOhdDdgmnTqTdSQWuLtdBwOHCy;
			MvyGIbzzsIhqOpOUkyUJCutAAOOI = ConfigHelper.iuzUSMpxqVpBnytkMYyAorwOumnJ;
			iOjBxBcPtlcmlteYnmHLBpITEkIL = LocalizationHelper.kScfYREWKeSweNxisyOBriBHDOWiA;
			fUnYoWNbZZQXgqQhJEnWQvVztSQq = GlyphHelper.gBekWBZCQbeeFnPGVBrokpSZozJg;
			FMGFxxbrJtXTQJOIYTHvYvLSigmK = new SafeAction<ControllerStatusChangedEventArgs>(PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.twgxxXUOMusHDrpUXSTfQYVvHLlB);
			gtqRzBkmWwLjMQQRyRYfzCMmLvoH = new SafeAction<ControllerStatusChangedEventArgs>(PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.YlYYchmldynRRXmblTNZwuWyAnNH);
			XoogoCmRKSixSVfIWfnZSUBnQByA = new SafeAction<ControllerStatusChangedEventArgs>(PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.uVgynewONsAGZAbduBNIvUTTagWf);
			QgwrhtqtiKPdlKRqgezNhnjcjFib = new SafeAction(PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.XBUDujiyPChTsbVAOgyulNwfExsB);
			yWGyjSKucqHicoLUtjeNFvLezxEh = new SafeAction(PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.fTuKJnoCgFvVdLKAnbAdidaxKfPzA);
			igsqWtuPboMlIeGaRwDHIXoCmivp = new SafeAction(PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.URBWRxHkpJLPBszMZfomKFnrghnkA);
			mLqywIosKXHUjRBZnKvUWmUWMYTR = new SafeAction(PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.UrGzvprCfqherfJeQnfjrogRDsCn);
			mDAqfVvXNuXgzRIqnbhgDbqTehXK = new SafeAction(PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.eleaVRcRMWoDEBHOMtQNCJJelRJUB);
			SafeDelegate.S_ExceptionHandler = PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.hLRxkrXcnlCXGnTyRotNVHlgsyfq;
		}

		public static void Update()
		{
			if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
			{
				if (HrUAQRgNyFTeOOnpzcHqEyFohaaP.updateMode != UpdateMode.Manual)
				{
					Logger.LogError("Rewired cannot be updated manually unless Update Mode is set to Manual.");
				}
				else
				{
					nTgvXYFPzomGRpaiQbZRXhYwLMAf.DoUpdate(UpdateLoopType.Update, UpdateLoopSetting.Update);
				}
			}
		}

		public static void Reset()
		{
			if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA && !(nTgvXYFPzomGRpaiQbZRXhYwLMAf == null))
			{
				nTgvXYFPzomGRpaiQbZRXhYwLMAf.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!zuVADykGVcOcubpnipURHknzkJfDA)
			{
				return false;
			}
			if (SnObwxrmQrFucHJbHtgfxcFfsgVbA != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (xRfDundGKGRYyvPloUJWLwKKVQpe)
				{
					if (!TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.value)
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

		private static void GdEkrlljUpKePVakKsqBEWOYqouf()
		{
			FNXMLniCQqYMnNWenRaYOYgKoLUI = UnityTools.platform;
			wBjsroTdNCjCbqrzhFnSDhOHkhqb = UnityTools.webplayerPlatform;
			SnObwxrmQrFucHJbHtgfxcFfsgVbA = UnityTools.editorPlatform;
		}

		internal static void ITYVXfWNUvZsqgBWGBmwuEziMFDL(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, Func<UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA> P_5, Action<Platform> P_6, Action<InputManager_Base.rmNSveHrOvbaVJVjdcwGabOiRcCeB> P_7)
		{
			try
			{
				_id = LMrzFnfFwZLuKvgNDxviTqotVQIX;
				LMrzFnfFwZLuKvgNDxviTqotVQIX++;
				hmFBGJpiuHNJVzQVWoNBgmpvGwLeA = true;
				VacLzjeOOJvdKkIuZNoAsPPKGmif = true;
				mBgFOoUewbZBNCLISAcDHKeWxsLpA = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				nTgvXYFPzomGRpaiQbZRXhYwLMAf = P_0;
				HrUAQRgNyFTeOOnpzcHqEyFohaaP = P_2;
				GdEkrlljUpKePVakKsqBEWOYqouf();
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += AShuRmzONpkVDZfnwnzBlZUCuylp;
				WqqeZZGjXiwIahHYdDlDUFCDdyOiA = P_3;
				xXNYybZYVXuCDBsfcGvDXJSXkuEl = P_4;
				jhnjKEbfCpJxxLAWZtuhfkeOtrku = new TimerAbs(1.0);
				iMAGamCsRNlowcOTxDCXztCIoxHzA = new ObAiMlISWHwckOMLHDGREerXMJiuA();
				LocalizationManager.Initialize();
				GlyphManager.Initialize();
				P_4.haVEMEnjGwwMTYvaOdejpHcywGYu();
				ThreadSafeUnityInput.Initialize();
				TssdUiFyAapgxHwMFTbxMlJkxkrD = new zTFKKBYaVEeiJaeeczzBWrSnNCT();
				if (!UnityTools.isEditor)
				{
					gxLRtCRiZsBFzmAfSpUVBNqATCtl = Application.isFocused;
				}
				TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.Set(gxLRtCRiZsBFzmAfSpUVBNqATCtl);
				TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.Use();
				if (SnObwxrmQrFucHJbHtgfxcFfsgVbA != EditorPlatform.None)
				{
					TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.getValueDelegate = PJDYUOszZjqZwFbOfBkBfzRJGDOPA._003C_003E9.zTUfbtBDLeBBHqaPaHdvFmhxHKHbb;
					if (mBgFOoUewbZBNCLISAcDHKeWxsLpA)
					{
						gxLRtCRiZsBFzmAfSpUVBNqATCtl = LBTfbXExVZDhMWzlKRIYHNxXtWUK;
					}
					TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				CKJvnyFLLzNcDKqlNDxcJhQPcWZy();
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
							mtomRtgTRNntCRDCGTAlowoDhPZo.hhclSRBEysiNfguOmMzNJLKeUdfG(customPlatformInitOptions);
							bool num = SnObwxrmQrFucHJbHtgfxcFfsgVbA != EditorPlatform.None;
							P_7(new InputManager_Base.rmNSveHrOvbaVJVjdcwGabOiRcCeB
							{
								xvBiMyTsTwpisPuFqShSSGmMdFED = Platform.Custom,
								oIGsXrVKPpKLpOtNRQSFLameGgjZ = EditorPlatform.None,
								shmOEEBZNZPJiSFRYxKzALUvfSUf = WebplayerPlatform.None
							});
							GdEkrlljUpKePVakKsqBEWOYqouf();
							iMAGamCsRNlowcOTxDCXztCIoxHzA = new ObAiMlISWHwckOMLHDGREerXMJiuA();
							if (num)
							{
								Logger.LogWarning("A custom platform is in use. All input will be managed by user-defined custom platform handling.");
							}
							break;
						}
					}
				}
				BRNkqrCgyBhJPcjBDMskrxwomhcE(P_1, P_5(), P_6);
				lQrqwhCfIfIgktHXoHKYyChngzyX = new IsRfGTyTEbMSFXGhXufpYZyPCKjB(P_4.GetActions_Copy());
				YNZnkUUWdETsfnFwfyPUjVPxExCq = new GCkLfqNtcKbVwGxJyqaDoIgNIHaV(P_2, cMbGYfgcXpZcVeWLLwrCPlgsDUNx);
				BIeoRJtgpppJNOjultHrXTwltUhx = new qolSwVLcvXSMneGdcvjdFoTKDPcf(P_2);
				cMbGYfgcXpZcVeWLLwrCPlgsDUNx.DeviceConnectedEvent += ObSZoJkAhKTpXZEHYixuPmTkFtXu;
				cMbGYfgcXpZcVeWLLwrCPlgsDUNx.DeviceDisconnectedEvent += XkauZsbYhWYCOMFkpbKedLheckze;
				cMbGYfgcXpZcVeWLLwrCPlgsDUNx.UpdateControllerInfoEvent += HgbcJFEhbZaJkhLmVDjaBhtfSApdA;
				YNZnkUUWdETsfnFwfyPUjVPxExCq.ecpSelzTdcjrgarOicRdqZNJUAyG += RIVivreiOrTifBcCYbwudmxzawOKA;
				YNZnkUUWdETsfnFwfyPUjVPxExCq.EOCtYlholfvBgCDSpWIFYJSofdLFA += BIeoRJtgpppJNOjultHrXTwltUhx.GVZpBJNShkccPvGVJlREsknRRyVm;
				ThreadSafeUnityInput.PostInitialize();
				XUEafcaCVcQePIkbDcVbuMWgCvSAc();
				ThreadSafeUnityInput.PostInitialize2();
				DkqhFjAYixqDReFBGalaZEZZZbyq = UnityTools.GetComponent<UserDataStore>(nTgvXYFPzomGRpaiQbZRXhYwLMAf);
				if (DkqhFjAYixqDReFBGalaZEZZZbyq != null)
				{
					DkqhFjAYixqDReFBGalaZEZZZbyq.Initialize();
				}
				BGmfcFbMNaRRbZvmSONAUGbzjaYCA();
				VacLzjeOOJvdKkIuZNoAsPPKGmif = false;
				if (mBgFOoUewbZBNCLISAcDHKeWxsLpA)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (mDAqfVvXNuXgzRIqnbhgDbqTehXK != null)
				{
					mDAqfVvXNuXgzRIqnbhgDbqTehXK.Invoke();
				}
			}
			catch (Exception)
			{
				hmFBGJpiuHNJVzQVWoNBgmpvGwLeA = false;
				VacLzjeOOJvdKkIuZNoAsPPKGmif = false;
				throw;
			}
		}

		internal static void AMdXkHmanjgfeVCMqEbzckEPNxAF()
		{
			if (iMAGamCsRNlowcOTxDCXztCIoxHzA != null)
			{
				iMAGamCsRNlowcOTxDCXztCIoxHzA.vPSicIubhdqeWXoLsyRrwyOSwHd();
			}
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < YNZnkUUWdETsfnFwfyPUjVPxExCq.qHNpazdlcHQNVocnmulXYfyMuYzA; i++)
				{
					Joystick joystick = YNZnkUUWdETsfnFwfyPUjVPxExCq.yrPEeoylGtUTYBrNmPdLuBuginuS[i];
					NGqOiBcgMbPvNJDTGOlHwBsyGjQGA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		internal static void msFBLZCqCBXHhLrSqeceZsenpLKHA(UpdateLoopType P_0)
		{
			if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
			{
				YxNoIzPzsyOYXTsuFSPheHYNlftP(P_0);
				if ((uint)P_0 <= 1u)
				{
					bVtCqqoLgNehbMPljGcMMlqngjOJA();
				}
			}
		}

		private static void YxNoIzPzsyOYXTsuFSPheHYNlftP(UpdateLoopType P_0)
		{
			if (TssdUiFyAapgxHwMFTbxMlJkxkrD != null)
			{
				TssdUiFyAapgxHwMFTbxMlJkxkrD.usUhyGfMbLwoPIHzlTXfAAZJfBIk();
			}
			Action<UpdateLoopType> action = gMOqsdEhMGRQoxchOemblOzwUumO;
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
			iMAGamCsRNlowcOTxDCXztCIoxHzA.kVsDjmKhNbQIjDeuhsdhfOlcEobkC(P_0);
		}

		private static void bVtCqqoLgNehbMPljGcMMlqngjOJA()
		{
			int frameCount = Time.frameCount;
			if (xLhczqpjKVXIbHKZNIidFVGOHnDT == frameCount)
			{
				return;
			}
			xLhczqpjKVXIbHKZNIidFVGOHnDT = frameCount;
			ThreadSafeUnityInput.Update();
			Action action = gHBAPSOldfyHuXvNdIiUeMikImfBA;
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

		internal static void wRaTeXGcZHEYBNqBWGQxftVeUUbFA(UpdateLoopType P_0)
		{
			if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
			{
				return;
			}
			if (iMFRVtmHVaJKZehGUKMBGOIIPUJ != P_0)
			{
				iMFRVtmHVaJKZehGUKMBGOIIPUJ = P_0;
			}
			if (editorPlatform != EditorPlatform.None)
			{
				LwLIKZdHRZiruWRlQkolIApbYBMn = TssdUiFyAapgxHwMFTbxMlJkxkrD.DdjoDkvgfpqLSCpeBGCzJoWqiBcNA.value;
			}
			if (QQcdhVjggExuEfUgSydpPekaUKiaA)
			{
				if (jhnjKEbfCpJxxLAWZtuhfkeOtrku.Update())
				{
					QQcdhVjggExuEfUgSydpPekaUKiaA = false;
					jhnjKEbfCpJxxLAWZtuhfkeOtrku.Clear();
				}
				else
				{
					KSgAuiFhzvuGaETjmRAWYUDbeErP.mkFHIWiCkfHPFYOitDxahauVCbJF(P_0);
				}
			}
			TssdUiFyAapgxHwMFTbxMlJkxkrD.DkZrYwCVatrUlLVTFfbJEvJoECYF();
			Action<UpdateLoopType> yPRTsTCnNwvXiCNqjwhhpEfdSPZx = YPRTsTCnNwvXiCNqjwhhpEfdSPZx;
			if (yPRTsTCnNwvXiCNqjwhhpEfdSPZx != null)
			{
				try
				{
					yPRTsTCnNwvXiCNqjwhhpEfdSPZx(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.UpdateStartedEvent", exception);
				}
			}
			cMbGYfgcXpZcVeWLLwrCPlgsDUNx.Update(P_0);
			if (QgwrhtqtiKPdlKRqgezNhnjcjFib != null)
			{
				QgwrhtqtiKPdlKRqgezNhnjcjFib.Invoke();
			}
			YNZnkUUWdETsfnFwfyPUjVPxExCq.BbmWCLpfikSsFBRKUVCaaDxJicAc(P_0);
			Action<UpdateLoopType> action = ndCHRYSYpUhvkRmUOTzAYAIgkjav;
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

		internal static void SalZczvFHhxhnRCskmYPUpRyinWp()
		{
			Action ekuAQDzsrBNVpqhQfsNiybQBUoJK = EkuAQDzsrBNVpqhQfsNiybQBUoJK;
			if (ekuAQDzsrBNVpqhQfsNiybQBUoJK != null)
			{
				try
				{
					ekuAQDzsrBNVpqhQfsNiybQBUoJK();
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
			if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA && mBgFOoUewbZBNCLISAcDHKeWxsLpA)
			{
				msFBLZCqCBXHhLrSqeceZsenpLKHA(UpdateLoopType.Update);
				wRaTeXGcZHEYBNqBWGQxftVeUUbFA(UpdateLoopType.Update);
				SalZczvFHhxhnRCskmYPUpRyinWp();
			}
		}

		internal static void irGsUSXAeSTYWVGMphFsSmZHHAEL()
		{
			if (igsqWtuPboMlIeGaRwDHIXoCmivp != null)
			{
				igsqWtuPboMlIeGaRwDHIXoCmivp.Invoke();
			}
			if (cMbGYfgcXpZcVeWLLwrCPlgsDUNx != null)
			{
				cMbGYfgcXpZcVeWLLwrCPlgsDUNx.OnDestroy();
			}
			MuqXARkAlmSouiaxGSAyDQBKdpki();
			if (mLqywIosKXHUjRBZnKvUWmUWMYTR != null)
			{
				mLqywIosKXHUjRBZnKvUWmUWMYTR.Invoke();
				mLqywIosKXHUjRBZnKvUWmUWMYTR = null;
			}
		}

		internal static void WrdBaqdyjTeTLorpMNdmtFXQcztaA()
		{
			if (yWGyjSKucqHicoLUtjeNFvLezxEh != null)
			{
				yWGyjSKucqHicoLUtjeNFvLezxEh.Invoke();
			}
		}

		internal static void dVKBDhAmhophYPUjjfFFSpDcBCMYA(bool P_0)
		{
			gxLRtCRiZsBFzmAfSpUVBNqATCtl = P_0;
			if (SnObwxrmQrFucHJbHtgfxcFfsgVbA == EditorPlatform.None && hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
			{
				TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.Set(P_0);
				TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.TriggerEvent();
			}
		}

		internal static void ZEDceSIrGxKKKNrCZZjurBLuhodsA(bool P_0)
		{
			if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
			{
				TssdUiFyAapgxHwMFTbxMlJkxkrD.iWKGRkLGQBbbogHwESOOqKfBjBdDA.Set(P_0);
				TssdUiFyAapgxHwMFTbxMlJkxkrD.iWKGRkLGQBbbogHwESOOqKfBjBdDA.TriggerEvent();
			}
		}

		internal static void CclSeDWfShQEfWVXjoENaKzLxLWW()
		{
			if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
			{
				return;
			}
			Action wtdBMTHIezYQvkbxHeLvBFmxbNvaA = WtdBMTHIezYQvkbxHeLvBFmxbNvaA;
			if (wtdBMTHIezYQvkbxHeLvBFmxbNvaA == null)
			{
				return;
			}
			try
			{
				wtdBMTHIezYQvkbxHeLvBFmxbNvaA();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.SceneLoadedEvent", exception);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return WqqeZZGjXiwIahHYdDlDUFCDdyOiA.uajQFyhfQEGuDYnTVVKVqgGexwrV(bridgedController);
		}

		internal static HardwareJoystickMap hSqOsssNAbtRpBPgfYBSveZbjBck(Guid P_0)
		{
			return WqqeZZGjXiwIahHYdDlDUFCDdyOiA.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap tAGkXVjNFWdkDejSUJuRDGQpkRgL(Guid P_0)
		{
			return WqqeZZGjXiwIahHYdDlDUFCDdyOiA.GetJoystickTemplate(P_0);
		}

		internal static TOvbXCLGpcDMwICKloBsHgxZNTif iVXcdPPjNjXrBRmVJUjdVLfzNocd(Guid P_0)
		{
			return WqqeZZGjXiwIahHYdDlDUFCDdyOiA.mprDMFjMFiPKraeGwPqLbGSduYuub(P_0);
		}

		internal static IHardwareControllerTemplateMap IApIuEftnNVzFlzpQzkhwhWbyQDU(Guid P_0)
		{
			return WqqeZZGjXiwIahHYdDlDUFCDdyOiA.GetControllerTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap PsTKSHsnZqJcBurcmvqiUnasOQwi(Guid P_0)
		{
			return WqqeZZGjXiwIahHYdDlDUFCDdyOiA.lzBTyjxmNRRmqklTrIqOieuylFJM(P_0);
		}

		internal static IList<TOvbXCLGpcDMwICKloBsHgxZNTif> OUHXRYZNzefNueQwdNMNXXZgdxrCA(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = WqqeZZGjXiwIahHYdDlDUFCDdyOiA.GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap == null)
			{
				return EmptyObjects<TOvbXCLGpcDMwICKloBsHgxZNTif>.EmptyReadOnlyIListT;
			}
			string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
			if (templateGuidsOrig == null || templateGuidsOrig.Length == 0)
			{
				return EmptyObjects<TOvbXCLGpcDMwICKloBsHgxZNTif>.EmptyReadOnlyIListT;
			}
			List<TOvbXCLGpcDMwICKloBsHgxZNTif> list = null;
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
				TOvbXCLGpcDMwICKloBsHgxZNTif tOvbXCLGpcDMwICKloBsHgxZNTif = iVXcdPPjNjXrBRmVJUjdVLfzNocd(guid);
				if (tOvbXCLGpcDMwICKloBsHgxZNTif == null)
				{
					Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
					continue;
				}
				if (list == null)
				{
					list = new List<TOvbXCLGpcDMwICKloBsHgxZNTif>();
				}
				ListTools.AddIfUnique(list, tOvbXCLGpcDMwICKloBsHgxZNTif);
			}
			if (list == null)
			{
				return EmptyObjects<TOvbXCLGpcDMwICKloBsHgxZNTif>.EmptyReadOnlyIListT;
			}
			return list;
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return YNZnkUUWdETsfnFwfyPUjVPxExCq.LpwmTUTWDFRRFNkJdjpWWAuAEhdx();
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

		internal static void pxSsTwQxyRmtUJZCaBtrCxOIcIqQ()
		{
			if (hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
			{
				BGmfcFbMNaRRbZvmSONAUGbzjaYCA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 6000 != UnityTools.unityVersionObj.major)
			{
				LFUmYArAsZAApcbrdxzhAZGYURyvA();
			}
		}

		internal static float lAEVusYvRzqnnjmfsgPnJdjNMgfOA()
		{
			return TssdUiFyAapgxHwMFTbxMlJkxkrD.VtqhWndnyxNVJELEtEpjEuXkIJNab.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
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

		private static void XUEafcaCVcQePIkbDcVbuMWgCvSAc()
		{
			BIeoRJtgpppJNOjultHrXTwltUhx.iJtbAKdHSvInWyczNilCYqmkndRyA();
			YNZnkUUWdETsfnFwfyPUjVPxExCq.vIWmohVWJemnAVYzgdBIoXReqZHk(cMbGYfgcXpZcVeWLLwrCPlgsDUNx.GetInputDataUpdateDelegate(), xXNYybZYVXuCDBsfcGvDXJSXkuEl.GetInputBehaviors_Copy());
			cMbGYfgcXpZcVeWLLwrCPlgsDUNx.Initialize();
		}

		private static void MuqXARkAlmSouiaxGSAyDQBKdpki()
		{
			if (nTgvXYFPzomGRpaiQbZRXhYwLMAf != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(nTgvXYFPzomGRpaiQbZRXhYwLMAf);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			nTgvXYFPzomGRpaiQbZRXhYwLMAf = null;
			cMbGYfgcXpZcVeWLLwrCPlgsDUNx = null;
			lQrqwhCfIfIgktHXoHKYyChngzyX = null;
			if (YNZnkUUWdETsfnFwfyPUjVPxExCq != null)
			{
				YNZnkUUWdETsfnFwfyPUjVPxExCq.Dispose();
			}
			YNZnkUUWdETsfnFwfyPUjVPxExCq = null;
			BIeoRJtgpppJNOjultHrXTwltUhx = null;
			WqqeZZGjXiwIahHYdDlDUFCDdyOiA = null;
			if (xXNYybZYVXuCDBsfcGvDXJSXkuEl != null)
			{
				xXNYybZYVXuCDBsfcGvDXJSXkuEl.IJQYwmIOuZPNQKGehzwMMTRYGqtM();
			}
			xXNYybZYVXuCDBsfcGvDXJSXkuEl = null;
			LocalizationHelper.YMpbVhJCCSzyErUIVmIljDxXAKfn();
			GlyphHelper.amCpibRdtunuMkLnvoAfXZqiOdXN();
			LocalizationManager.Deinitialize();
			GlyphManager.Deinitialize();
			QtUfFGUJUlJidLRCnJNWGXcGPpJq = null;
			hmFBGJpiuHNJVzQVWoNBgmpvGwLeA = false;
			HrUAQRgNyFTeOOnpzcHqEyFohaaP = null;
			iMFRVtmHVaJKZehGUKMBGOIIPUJ = UpdateLoopType.Update;
			XLNDDcaMaxOAKOmtpXwruqtrrEuEA = false;
			FNXMLniCQqYMnNWenRaYOYgKoLUI = Platform.Windows;
			wBjsroTdNCjCbqrzhFnSDhOHkhqb = WebplayerPlatform.None;
			SnObwxrmQrFucHJbHtgfxcFfsgVbA = EditorPlatform.None;
			QQcdhVjggExuEfUgSydpPekaUKiaA = false;
			jhnjKEbfCpJxxLAWZtuhfkeOtrku = null;
			iMAGamCsRNlowcOTxDCXztCIoxHzA = null;
			LwLIKZdHRZiruWRlQkolIApbYBMn = null;
			xRfDundGKGRYyvPloUJWLwKKVQpe = false;
			mBgFOoUewbZBNCLISAcDHKeWxsLpA = false;
			gxLRtCRiZsBFzmAfSpUVBNqATCtl = true;
			xLhczqpjKVXIbHKZNIidFVGOHnDT = -1;
			_id = -1;
			gBoQHAgxjzDmnCSeUrZbIURQqWUI = 0;
			unscaledDeltaTime = 0.0;
			unscaledTime = 0.0;
			unscaledTimePrev = 0.0;
			currentFrame = 0u;
			previousFrame = 0u;
			absFrame = 0u;
			FMGFxxbrJtXTQJOIYTHvYvLSigmK.Clear();
			gtqRzBkmWwLjMQQRyRYfzCMmLvoH.Clear();
			XoogoCmRKSixSVfIWfnZSUBnQByA.Clear();
			QgwrhtqtiKPdlKRqgezNhnjcjFib.Clear();
			yWGyjSKucqHicoLUtjeNFvLezxEh.Clear();
			_ApplicationFocusChangedEvent = null;
			_ApplicationPauseChangedEvent = null;
			EtEzUGkcgTXgtAhMmsIakPTSxukK = null;
			rLxXEshqDNrMXJvWmxMwwpQiXxSD = null;
			HIlZYYvUrpalYHlWAKXVURqMNXom = null;
			LmJpSHyNsRCgeoPMyYtaFKkOSKyE = null;
			gHBAPSOldfyHuXvNdIiUeMikImfBA = null;
			YPRTsTCnNwvXiCNqjwhhpEfdSPZx = null;
			ndCHRYSYpUhvkRmUOTzAYAIgkjav = null;
			EkuAQDzsrBNVpqhQfsNiybQBUoJK = null;
			igsqWtuPboMlIeGaRwDHIXoCmivp = null;
			WtdBMTHIezYQvkbxHeLvBFmxbNvaA = null;
			kmFgHDcOAVpRdKzeexAMAXPMfpkJA = null;
			VEyapEdlxeqleTLvADWwyAlaHIYab();
			TssdUiFyAapgxHwMFTbxMlJkxkrD = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= AShuRmzONpkVDZfnwnzBlZUCuylp;
			}
			mtomRtgTRNntCRDCGTAlowoDhPZo.sHNnRsoonDsypoWmYMFIcTXKiZFr();
		}

		private static void SAigiCCbIDfZYEaetvekovoCdQOyA(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void bjxSqXBHPqUsmJdMvJwbOPIYgagJ()
		{
			if (!QQcdhVjggExuEfUgSydpPekaUKiaA)
			{
				QQcdhVjggExuEfUgSydpPekaUKiaA = true;
				KSgAuiFhzvuGaETjmRAWYUDbeErP.asFAvTODZvWdSgemhgxyDAuXgPCeA();
				KSgAuiFhzvuGaETjmRAWYUDbeErP.UginGwknwLoyjXLCNkklrNfhSSJX();
			}
			jhnjKEbfCpJxxLAWZtuhfkeOtrku.Start();
		}

		private static void lttuDHGUmKgwixLFTJjaZSJblbCT()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void ObSZoJkAhKTpXZEHYixuPmTkFtXu(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			YNZnkUUWdETsfnFwfyPUjVPxExCq.vQjbZetmLkfYVDGXwrKvBGoRGBgfb(P_0);
			Joystick joystick = YNZnkUUWdETsfnFwfyPUjVPxExCq.jXDhPVbEhpTlzUnGofGzsIWldtafA(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				BIeoRJtgpppJNOjultHrXTwltUhx.OEbERiLhiRGkJKfGlNmHQsCGKdRc(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !VacLzjeOOJvdKkIuZNoAsPPKGmif)
				{
					NGqOiBcgMbPvNJDTGOlHwBsyGjQGA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void XkauZsbYhWYCOMFkpbKedLheckze(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = YNZnkUUWdETsfnFwfyPUjVPxExCq.jXDhPVbEhpTlzUnGofGzsIWldtafA(P_0.rewiredId);
				if (joystick != null)
				{
					YNZnkUUWdETsfnFwfyPUjVPxExCq.kvHiGWEGuRVLxqRNVYkhnieHqCNl(P_0.rewiredId);
					sREcSfeNUNVANQynHEfNQiDkJvSYA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void NGqOiBcgMbPvNJDTGOlHwBsyGjQGA(ControllerStatusChangedEventArgs P_0)
		{
			if (FMGFxxbrJtXTQJOIYTHvYvLSigmK != null)
			{
				FMGFxxbrJtXTQJOIYTHvYvLSigmK.Invoke(P_0);
			}
		}

		private static void RIVivreiOrTifBcCYbwudmxzawOKA(ControllerStatusChangedEventArgs P_0)
		{
			if (gtqRzBkmWwLjMQQRyRYfzCMmLvoH != null)
			{
				gtqRzBkmWwLjMQQRyRYfzCMmLvoH.Invoke(P_0);
			}
		}

		private static void sREcSfeNUNVANQynHEfNQiDkJvSYA(ControllerStatusChangedEventArgs P_0)
		{
			if (XoogoCmRKSixSVfIWfnZSUBnQByA != null)
			{
				XoogoCmRKSixSVfIWfnZSUBnQByA.Invoke(P_0);
			}
		}

		private static void HgbcJFEhbZaJkhLmVDjaBhtfSApdA(UpdateControllerInfoEventArgs P_0)
		{
			YNZnkUUWdETsfnFwfyPUjVPxExCq.VGmbOSIbQCiZyhjWWADFhhheOuxk(P_0);
		}

		private static void MgfvHFSRTfFwqDqWKlIgpbowTzwK(bool P_0)
		{
			if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
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

		private static void MNznruwniYMRveWfvVbjEdXKkAWq(bool P_0)
		{
			if (!hmFBGJpiuHNJVzQVWoNBgmpvGwLeA)
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

		private static void KaRSOPUBzDOFsyGHmlJxrkXAhdOg(bool P_0)
		{
			Action<bool> etEzUGkcgTXgtAhMmsIakPTSxukK = EtEzUGkcgTXgtAhMmsIakPTSxukK;
			if (etEzUGkcgTXgtAhMmsIakPTSxukK != null)
			{
				try
				{
					etEzUGkcgTXgtAhMmsIakPTSxukK(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void BykVxQEooOxtphKjQumkHNdawWi(int P_0)
		{
			if (HIlZYYvUrpalYHlWAKXVURqMNXom != null)
			{
				try
				{
					HIlZYYvUrpalYHlWAKXVURqMNXom((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void iHwlThSIHqVFKRsvkPrjPEXgSklb(bool P_0)
		{
			Action<bool> action = rLxXEshqDNrMXJvWmxMwwpQiXxSD;
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

		private static void mlxuguWNZyghMyhFwHNAGngQXOqrA(bool P_0)
		{
			gBoQHAgxjzDmnCSeUrZbIURQqWUI++;
			Action<bool> lmJpSHyNsRCgeoPMyYtaFKkOSKyE = LmJpSHyNsRCgeoPMyYtaFKkOSKyE;
			if (lmJpSHyNsRCgeoPMyYtaFKkOSKyE != null)
			{
				try
				{
					lmJpSHyNsRCgeoPMyYtaFKkOSKyE(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void CKJvnyFLLzNcDKqlNDxcJhQPcWZy()
		{
			if (TssdUiFyAapgxHwMFTbxMlJkxkrD != null)
			{
				VEyapEdlxeqleTLvADWwyAlaHIYab();
				TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.ChangedEvent += MgfvHFSRTfFwqDqWKlIgpbowTzwK;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.iWKGRkLGQBbbogHwESOOqKfBjBdDA.ChangedEvent += MNznruwniYMRveWfvVbjEdXKkAWq;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.QmSKQSvPntDjGRSlhhWRMoueDjqs.ChangedEvent += KaRSOPUBzDOFsyGHmlJxrkXAhdOg;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.wVDLLqIbMDHZaJCZnzXbBILjwTvR.ChangedEvent += iHwlThSIHqVFKRsvkPrjPEXgSklb;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.qbDHgQOrirNsGZxfYNMTXZJSrJiU.ChangedEvent += BykVxQEooOxtphKjQumkHNdawWi;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.IXIbwAFVTjYdmpmtyzoggovcWBQl.ChangedEvent += mlxuguWNZyghMyhFwHNAGngQXOqrA;
			}
		}

		private static void VEyapEdlxeqleTLvADWwyAlaHIYab()
		{
			if (TssdUiFyAapgxHwMFTbxMlJkxkrD != null)
			{
				TssdUiFyAapgxHwMFTbxMlJkxkrD.awgGPyKVJGmFmyMkfNyZUJGiMbjK.ChangedEvent -= MgfvHFSRTfFwqDqWKlIgpbowTzwK;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.iWKGRkLGQBbbogHwESOOqKfBjBdDA.ChangedEvent -= MNznruwniYMRveWfvVbjEdXKkAWq;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.QmSKQSvPntDjGRSlhhWRMoueDjqs.ChangedEvent -= KaRSOPUBzDOFsyGHmlJxrkXAhdOg;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.wVDLLqIbMDHZaJCZnzXbBILjwTvR.ChangedEvent -= iHwlThSIHqVFKRsvkPrjPEXgSklb;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.qbDHgQOrirNsGZxfYNMTXZJSrJiU.ChangedEvent -= BykVxQEooOxtphKjQumkHNdawWi;
				TssdUiFyAapgxHwMFTbxMlJkxkrD.IXIbwAFVTjYdmpmtyzoggovcWBQl.ChangedEvent -= mlxuguWNZyghMyhFwHNAGngQXOqrA;
			}
		}

		private static void AShuRmzONpkVDZfnwnzBlZUCuylp(bool P_0)
		{
			Action<bool> action = kmFgHDcOAVpRdKzeexAMAXPMfpkJA;
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

		private static void BRNkqrCgyBhJPcjBDMskrxwomhcE(Func<ConfigVars, object> P_0, UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA P_1, Action<Platform> P_2)
		{
			bool flag = false;
			if (P_1.YcIFSYCNiADtdLnKqTzbFXaOBVMmA != P_1.eHHQNMlYSngIGWtqSoJhFkHbbgQaA)
			{
				UnityTools.PLjezcBkFGJQfWOkGFiEWPRPdDHUA pLjezcBkFGJQfWOkGFiEWPRPdDHUA = P_1;
				pLjezcBkFGJQfWOkGFiEWPRPdDHUA.YcIFSYCNiADtdLnKqTzbFXaOBVMmA = P_1.eHHQNMlYSngIGWtqSoJhFkHbbgQaA;
				UnityTools.mpTsyjCONOEMkUHJcHNjQreTdBSb(pLjezcBkFGJQfWOkGFiEWPRPdDHUA);
				P_2(pLjezcBkFGJQfWOkGFiEWPRPdDHUA.eHHQNMlYSngIGWtqSoJhFkHbbgQaA);
				GdEkrlljUpKePVakKsqBEWOYqouf();
				flag = true;
			}
			if (!configVars.DoesPlatformUseFallback(P_1.eHHQNMlYSngIGWtqSoJhFkHbbgQaA, P_1.bRXuMJVZiPPbIwEwImjSmkSmlsGH, isEditor) && !configVars.DoesPlatformUseFallback(P_1.YcIFSYCNiADtdLnKqTzbFXaOBVMmA, P_1.bRXuMJVZiPPbIwEwImjSmkSmlsGH, isEditor))
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(nTgvXYFPzomGRpaiQbZRXhYwLMAf);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(P_1.eHHQNMlYSngIGWtqSoJhFkHbbgQaA, HrUAQRgNyFTeOOnpzcHqEyFohaaP) is PlatformInputManager platformInputManager)
					{
						cMbGYfgcXpZcVeWLLwrCPlgsDUNx = platformInputManager;
						return;
					}
				}
			}
			if (flag)
			{
				UnityTools.mpTsyjCONOEMkUHJcHNjQreTdBSb(P_1);
				P_2(P_1.eHHQNMlYSngIGWtqSoJhFkHbbgQaA);
				GdEkrlljUpKePVakKsqBEWOYqouf();
				flag = false;
			}
			if (configVars.DoesPlatformUseFallback(FNXMLniCQqYMnNWenRaYOYgKoLUI, wBjsroTdNCjCbqrzhFnSDhOHkhqb, isEditor))
			{
				XLNDDcaMaxOAKOmtpXwruqtrrEuEA = true;
				cMbGYfgcXpZcVeWLLwrCPlgsDUNx = new eDyLCbhEucQsDiFFyDBPIJmhqdCQA(HrUAQRgNyFTeOOnpzcHqEyFohaaP.updateLoop);
			}
			else if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.Windows || FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.WindowsAppStore || FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.WindowsUWP || FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.OSX || FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.Linux)
			{
				cMbGYfgcXpZcVeWLLwrCPlgsDUNx = P_0(HrUAQRgNyFTeOOnpzcHqEyFohaaP) as PlatformInputManager;
			}
			else if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.WebGL && !isEditor)
			{
				try
				{
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = P_0(HrUAQRgNyFTeOOnpzcHqEyFohaaP) as PlatformInputManager;
					if (cMbGYfgcXpZcVeWLLwrCPlgsDUNx == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = null;
				}
			}
			else if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.XboxOne && !isEditor)
			{
				try
				{
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = new CustomInputManager(new XboxOneInputSource(), HrUAQRgNyFTeOOnpzcHqEyFohaaP.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (cMbGYfgcXpZcVeWLLwrCPlgsDUNx == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = null;
				}
			}
			else if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.PS4 && !isEditor)
			{
				try
				{
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = P_0(HrUAQRgNyFTeOOnpzcHqEyFohaaP) as PlatformInputManager;
					if (cMbGYfgcXpZcVeWLLwrCPlgsDUNx == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
					Logger.LogError(msg);
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = null;
				}
			}
			else if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.PS5 && !isEditor)
			{
				try
				{
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = P_0(HrUAQRgNyFTeOOnpzcHqEyFohaaP) as PlatformInputManager;
					if (cMbGYfgcXpZcVeWLLwrCPlgsDUNx == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
					Logger.LogError(msg2);
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = null;
				}
			}
			else if ((FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.GameCoreXboxOne || FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = P_0(HrUAQRgNyFTeOOnpzcHqEyFohaaP) as PlatformInputManager;
					if (cMbGYfgcXpZcVeWLLwrCPlgsDUNx == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg3)
				{
					string text = ((FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg3);
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = null;
				}
			}
			else if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.Ouya && !isEditor)
			{
				Logger.LogError("Ouya is no longer supported.");
				cMbGYfgcXpZcVeWLLwrCPlgsDUNx = null;
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.wORQWYSBYMpFwaXLaNVINsCZUzgc = P_0(HrUAQRgNyFTeOOnpzcHqEyFohaaP) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg4)
				{
					Logger.LogError(msg4);
				}
			}
			else if (FNXMLniCQqYMnNWenRaYOYgKoLUI == Platform.Custom)
			{
				try
				{
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = new CustomInputManager(mtomRtgTRNntCRDCGTAlowoDhPZo.NnOiOlKnipoPFMRQMAqlgzaSVflP(), HrUAQRgNyFTeOOnpzcHqEyFohaaP.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (cMbGYfgcXpZcVeWLLwrCPlgsDUNx == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Custom platform could not be initialized due to an exception!");
					cMbGYfgcXpZcVeWLLwrCPlgsDUNx = null;
					throw;
				}
			}
			if (cMbGYfgcXpZcVeWLLwrCPlgsDUNx == null)
			{
				XLNDDcaMaxOAKOmtpXwruqtrrEuEA = true;
				cMbGYfgcXpZcVeWLLwrCPlgsDUNx = new eDyLCbhEucQsDiFFyDBPIJmhqdCQA(HrUAQRgNyFTeOOnpzcHqEyFohaaP.updateLoop);
			}
		}

		private static void BGmfcFbMNaRRbZvmSONAUGbzjaYCA()
		{
			if (xRfDundGKGRYyvPloUJWLwKKVQpe != HrUAQRgNyFTeOOnpzcHqEyFohaaP.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				xRfDundGKGRYyvPloUJWLwKKVQpe = !xRfDundGKGRYyvPloUJWLwKKVQpe;
			}
		}

		private static void LFUmYArAsZAApcbrdxzhAZGYURyvA()
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
