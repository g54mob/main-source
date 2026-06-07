using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputManagers;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Platforms.PS4;
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
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper SKcIgrdHSZRiIzfxUyDOqjyMnCX;

			private float qnCiTUsxDoODnPAGgisjCRalIHtl = 0.7f;

			private float DjvEFAjeaubJGjgnNrhhBinBmjSv = 100f;

			internal static ConfigHelper Instance => SKcIgrdHSZRiIzfxUyDOqjyMnCX ?? (SKcIgrdHSZRiIzfxUyDOqjyMnCX = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.platform == Platform.Windows && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						return (lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
					}
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.useXInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
						if (platformVars_WindowsUWP.useGamepadAPI != value)
						{
							platformVars_WindowsUWP.useGamepadAPI = value;
							if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
							{
								OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
							}
						}
					}
					else if (lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.useXInput != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.useXInput = value;
						if (!value && UnityTools.platform == Platform.Windows && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.Log("The primary input source has been changed to Raw Input.");
						}
						else if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.updateLoop = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.platform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.useXInput = true;
						}
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.osx_primaryInputSource != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.osx_primaryInputSource = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.linux_primaryInputSource != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.linux_primaryInputSource = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.windowsUWP_primaryInputSource = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					return platformVars_WindowsUWP.useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.xboxOne_primaryInputSource != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.xboxOne_primaryInputSource = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
						return PS4PrimaryInputSource.Native;
					}
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.ps4_primaryInputSource != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.ps4_primaryInputSource = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.webGL_primaryInputSource != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.webGL_primaryInputSource = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.alwaysUseUnityInput != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.alwaysUseUnityInput = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.SetPlatformVar_useNativeMouse(value) && OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
					{
						OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
					{
						OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
					{
						OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.GetPlatformVar_joystickRefreshRate();
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
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						jvAMkLnjgvMzaGTymYSPSqimDGa();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.android_supportUnknownGamepads != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.android_supportUnknownGamepads = value;
						if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
						{
							OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.defaultAxisSensitivityType != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.defaultAxisSensitivityType = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.force4WayHats != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.force4WayHats = value;
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
					return qnCiTUsxDoODnPAGgisjCRalIHtl;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (qnCiTUsxDoODnPAGgisjCRalIHtl != value)
						{
							qnCiTUsxDoODnPAGgisjCRalIHtl = value;
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
					return DjvEFAjeaubJGjgnNrhhBinBmjSv;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (DjvEFAjeaubJGjgnNrhhBinBmjSv != value)
						{
							DjvEFAjeaubJGjgnNrhhBinBmjSv = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.activateActionButtonsOnNegativeValue = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.throttleCalibrationMode != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.throttleCalibrationMode = value;
						AkpZeTvTvDWYnEqWDyDWrcufUCI.sdnEHVkszbacpcRGvFmAcEtNbcs(value);
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.autoAssignJoysticks != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.autoAssignJoysticks = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.maxJoysticksPerPlayer != value)
						{
							lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.maxJoysticksPerPlayer = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.distributeJoysticksEvenly != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.distributeJoysticksEvenly = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.logLevel != value)
					{
						lPlxhgNPpsgHbDrFTbwKnGHEkWU.ConfigVars.logLevel = value;
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
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class qlPCglxxogePwpybSBLytfRLeIFc : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerPollingInfo WdGCXhRqCOAPCjerMsMDcdAVMCW;

					public ControllerPollingInfo hfAqtQRbyivkSWNNyhDOfCEOxRRv;

					public ControllerPollingInfo qoLMCdoBCVsOAGRzhQHWvGCRNVr;

					public ControllerPollingInfo WsuRbglRGGGeGTToyVfSDBoGjldb;

					public IEnumerator<ControllerPollingInfo> DJLFbGiaKxpuLLzyGGMfIUUmvjL;

					public IEnumerator<ControllerPollingInfo> ERbENjfOmaDaDxnKZMjWbYEJVUVf;

					public IEnumerator<ControllerPollingInfo> mHygcFqbmwoNSTrIPIyCXFtqlGj;

					public IEnumerator<ControllerPollingInfo> ZpwCxldHCtLWjjPNiSkEYVpIoNj;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						qlPCglxxogePwpybSBLytfRLeIFc qlPCglxxogePwpybSBLytfRLeIFc2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							qlPCglxxogePwpybSBLytfRLeIFc2 = this;
						}
						else
						{
							qlPCglxxogePwpybSBLytfRLeIFc2 = new qlPCglxxogePwpybSBLytfRLeIFc(0);
							qlPCglxxogePwpybSBLytfRLeIFc2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return qlPCglxxogePwpybSBLytfRLeIFc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (!CheckInitialized())
								{
									break;
								}
								DJLFbGiaKxpuLLzyGGMfIUUmvjL = GxphHAMqMhNBLjnlhXuBQmXaALiE.erVHfuOXQJQmixaNxIGRYDHFFmc().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0098;
							case 2:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0098;
							case 4:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00fc;
							case 6:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
								goto IL_0160;
							case 8:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 7;
									goto IL_01c1;
								}
								IL_01c1:
								if (ZpwCxldHCtLWjjPNiSkEYVpIoNj.MoveNext())
								{
									WsuRbglRGGGeGTToyVfSDBoGjldb = ZpwCxldHCtLWjjPNiSkEYVpIoNj.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = WsuRbglRGGGeGTToyVfSDBoGjldb;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 8;
									return true;
								}
								ColDrDODVmqVyfhVWCHcqaQirYK();
								break;
								IL_0098:
								if (DJLFbGiaKxpuLLzyGGMfIUUmvjL.MoveNext())
								{
									WdGCXhRqCOAPCjerMsMDcdAVMCW = DJLFbGiaKxpuLLzyGGMfIUUmvjL.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = WdGCXhRqCOAPCjerMsMDcdAVMCW;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								PTaRwkqOeUGABUqYxAVLLggxoaV();
								ERbENjfOmaDaDxnKZMjWbYEJVUVf = GxphHAMqMhNBLjnlhXuBQmXaALiE.GDTRtyJdiGNqaKicbrgdtRvqOHF().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00fc;
								IL_0160:
								if (mHygcFqbmwoNSTrIPIyCXFtqlGj.MoveNext())
								{
									qoLMCdoBCVsOAGRzhQHWvGCRNVr = mHygcFqbmwoNSTrIPIyCXFtqlGj.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = qoLMCdoBCVsOAGRzhQHWvGCRNVr;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 6;
									return true;
								}
								irIGcwAUZXHGrPZQaPksexaPwtOO();
								ZpwCxldHCtLWjjPNiSkEYVpIoNj = GxphHAMqMhNBLjnlhXuBQmXaALiE.LDbbFzgGBZBtlwNAamuGaFxphto().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 7;
								goto IL_01c1;
								IL_00fc:
								if (ERbENjfOmaDaDxnKZMjWbYEJVUVf.MoveNext())
								{
									hfAqtQRbyivkSWNNyhDOfCEOxRRv = ERbENjfOmaDaDxnKZMjWbYEJVUVf.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = hfAqtQRbyivkSWNNyhDOfCEOxRRv;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 4;
									return true;
								}
								onsdWBGpAfKNTiiejmiNKIGCABJB();
								mHygcFqbmwoNSTrIPIyCXFtqlGj = GxphHAMqMhNBLjnlhXuBQmXaALiE.zvIyUDBRrgFtClHMTFEfFyrZmYQ().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
								goto IL_0160;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								PTaRwkqOeUGABUqYxAVLLggxoaV();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								onsdWBGpAfKNTiiejmiNKIGCABJB();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								irIGcwAUZXHGrPZQaPksexaPwtOO();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								ColDrDODVmqVyfhVWCHcqaQirYK();
							}
						}
					}

					[DebuggerHidden]
					public qlPCglxxogePwpybSBLytfRLeIFc(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void PTaRwkqOeUGABUqYxAVLLggxoaV()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (DJLFbGiaKxpuLLzyGGMfIUUmvjL != null)
						{
							DJLFbGiaKxpuLLzyGGMfIUUmvjL.Dispose();
						}
					}

					private void onsdWBGpAfKNTiiejmiNKIGCABJB()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ERbENjfOmaDaDxnKZMjWbYEJVUVf != null)
						{
							ERbENjfOmaDaDxnKZMjWbYEJVUVf.Dispose();
						}
					}

					private void irIGcwAUZXHGrPZQaPksexaPwtOO()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (mHygcFqbmwoNSTrIPIyCXFtqlGj != null)
						{
							mHygcFqbmwoNSTrIPIyCXFtqlGj.Dispose();
						}
					}

					private void ColDrDODVmqVyfhVWCHcqaQirYK()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ZpwCxldHCtLWjjPNiSkEYVpIoNj != null)
						{
							ZpwCxldHCtLWjjPNiSkEYVpIoNj.Dispose();
						}
					}
				}

				private sealed class CYiTlzNddDHfxrEWXjJbaxLqejf : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerPollingInfo KOvxVPUAAnWFbMNAWlfXGQIjCXm;

					public ControllerPollingInfo BsgYZkrxBJeQgShpfQvpiJQnUpx;

					public ControllerPollingInfo sINxKGHqbmcytvKJjEMcwVcEinJ;

					public ControllerPollingInfo KBXTJUtnsXtDZfHEohTfPAljLFD;

					public IEnumerator<ControllerPollingInfo> GHOgTPdbITYZoisLMRhUBplCSimE;

					public IEnumerator<ControllerPollingInfo> rpjEjxJnbFczGAaObAtablCHarSq;

					public IEnumerator<ControllerPollingInfo> YoyHRQalJJfINWCYieniAOmbHKqG;

					public IEnumerator<ControllerPollingInfo> doUYhvecMhpeqsCaHFTiIBUrDgE;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						CYiTlzNddDHfxrEWXjJbaxLqejf cYiTlzNddDHfxrEWXjJbaxLqejf;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							cYiTlzNddDHfxrEWXjJbaxLqejf = this;
						}
						else
						{
							cYiTlzNddDHfxrEWXjJbaxLqejf = new CYiTlzNddDHfxrEWXjJbaxLqejf(0);
							cYiTlzNddDHfxrEWXjJbaxLqejf.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return cYiTlzNddDHfxrEWXjJbaxLqejf;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (!CheckInitialized())
								{
									break;
								}
								GHOgTPdbITYZoisLMRhUBplCSimE = GxphHAMqMhNBLjnlhXuBQmXaALiE.ZFkAoDIDCULCKqCMJiqzlrqfyyyP().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0098;
							case 2:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0098;
							case 4:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00fc;
							case 6:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
								goto IL_0160;
							case 8:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 7;
									goto IL_01c1;
								}
								IL_01c1:
								if (doUYhvecMhpeqsCaHFTiIBUrDgE.MoveNext())
								{
									KBXTJUtnsXtDZfHEohTfPAljLFD = doUYhvecMhpeqsCaHFTiIBUrDgE.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = KBXTJUtnsXtDZfHEohTfPAljLFD;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 8;
									return true;
								}
								dVonbgHaNciSDcoeBnBzJxJfyHsb();
								break;
								IL_0098:
								if (GHOgTPdbITYZoisLMRhUBplCSimE.MoveNext())
								{
									KOvxVPUAAnWFbMNAWlfXGQIjCXm = GHOgTPdbITYZoisLMRhUBplCSimE.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = KOvxVPUAAnWFbMNAWlfXGQIjCXm;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								VNiexlsRYeINdrqanuQGgHuhpcY();
								rpjEjxJnbFczGAaObAtablCHarSq = GxphHAMqMhNBLjnlhXuBQmXaALiE.mENAeZeCVThercryLzDDaWWwAfIF().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00fc;
								IL_0160:
								if (YoyHRQalJJfINWCYieniAOmbHKqG.MoveNext())
								{
									sINxKGHqbmcytvKJjEMcwVcEinJ = YoyHRQalJJfINWCYieniAOmbHKqG.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = sINxKGHqbmcytvKJjEMcwVcEinJ;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 6;
									return true;
								}
								DIZfpEeWjURdKxUhQfPRLGxRaxvw();
								doUYhvecMhpeqsCaHFTiIBUrDgE = GxphHAMqMhNBLjnlhXuBQmXaALiE.bYGRiiTjCpEmWspRFAbFHwSSBLR().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 7;
								goto IL_01c1;
								IL_00fc:
								if (rpjEjxJnbFczGAaObAtablCHarSq.MoveNext())
								{
									BsgYZkrxBJeQgShpfQvpiJQnUpx = rpjEjxJnbFczGAaObAtablCHarSq.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = BsgYZkrxBJeQgShpfQvpiJQnUpx;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 4;
									return true;
								}
								UzdAFpmUpmmynrkntJibnxWiTls();
								YoyHRQalJJfINWCYieniAOmbHKqG = GxphHAMqMhNBLjnlhXuBQmXaALiE.vkSEpdgbYbJZIASlGKYuOGIuCKpM().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
								goto IL_0160;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								VNiexlsRYeINdrqanuQGgHuhpcY();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								UzdAFpmUpmmynrkntJibnxWiTls();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								DIZfpEeWjURdKxUhQfPRLGxRaxvw();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								dVonbgHaNciSDcoeBnBzJxJfyHsb();
							}
						}
					}

					[DebuggerHidden]
					public CYiTlzNddDHfxrEWXjJbaxLqejf(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void VNiexlsRYeINdrqanuQGgHuhpcY()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GHOgTPdbITYZoisLMRhUBplCSimE != null)
						{
							GHOgTPdbITYZoisLMRhUBplCSimE.Dispose();
						}
					}

					private void UzdAFpmUpmmynrkntJibnxWiTls()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (rpjEjxJnbFczGAaObAtablCHarSq != null)
						{
							rpjEjxJnbFczGAaObAtablCHarSq.Dispose();
						}
					}

					private void DIZfpEeWjURdKxUhQfPRLGxRaxvw()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (YoyHRQalJJfINWCYieniAOmbHKqG != null)
						{
							YoyHRQalJJfINWCYieniAOmbHKqG.Dispose();
						}
					}

					private void dVonbgHaNciSDcoeBnBzJxJfyHsb()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (doUYhvecMhpeqsCaHFTiIBUrDgE != null)
						{
							doUYhvecMhpeqsCaHFTiIBUrDgE.Dispose();
						}
					}
				}

				private sealed class JwpPqnvBxeFikLMqJOqmFOjKcWR : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerPollingInfo qFfjgIaBapDzALyDAxVGkOHtpYW;

					public ControllerPollingInfo VABlxotWVsoictDoEiEqoXtxKOs;

					public ControllerPollingInfo vUbWpcppLBMLxZLHYSysalQmpXx;

					public ControllerPollingInfo mbUTrdTFJTPJEQckKBnjfjiAjqg;

					public IEnumerator<ControllerPollingInfo> taLUNxcfhRhMGwveVdiHwpKkJBS;

					public IEnumerator<ControllerPollingInfo> AihbkpihjLhuuTsztIvrPJxeaP;

					public IEnumerator<ControllerPollingInfo> yvmtbOqtnKwfCCOYhFdPEmeCgZv;

					public IEnumerator<ControllerPollingInfo> dyDUXXBArqQDUgsivKJhrbuXmCU;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						JwpPqnvBxeFikLMqJOqmFOjKcWR jwpPqnvBxeFikLMqJOqmFOjKcWR;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							jwpPqnvBxeFikLMqJOqmFOjKcWR = this;
						}
						else
						{
							jwpPqnvBxeFikLMqJOqmFOjKcWR = new JwpPqnvBxeFikLMqJOqmFOjKcWR(0);
							jwpPqnvBxeFikLMqJOqmFOjKcWR.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return jwpPqnvBxeFikLMqJOqmFOjKcWR;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (!CheckInitialized())
								{
									break;
								}
								taLUNxcfhRhMGwveVdiHwpKkJBS = GxphHAMqMhNBLjnlhXuBQmXaALiE.bDiADUDvggEEvgiabwWCEYVMFrq().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0098;
							case 2:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0098;
							case 4:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00fc;
							case 6:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
								goto IL_0160;
							case 8:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 7;
									goto IL_01c1;
								}
								IL_01c1:
								if (dyDUXXBArqQDUgsivKJhrbuXmCU.MoveNext())
								{
									mbUTrdTFJTPJEQckKBnjfjiAjqg = dyDUXXBArqQDUgsivKJhrbuXmCU.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = mbUTrdTFJTPJEQckKBnjfjiAjqg;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 8;
									return true;
								}
								HQuVRhvflEHzMOCYPHQVVnDQAFQ();
								break;
								IL_0098:
								if (taLUNxcfhRhMGwveVdiHwpKkJBS.MoveNext())
								{
									qFfjgIaBapDzALyDAxVGkOHtpYW = taLUNxcfhRhMGwveVdiHwpKkJBS.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = qFfjgIaBapDzALyDAxVGkOHtpYW;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								rrgIdgPYqfXuDdZpWFaMmJYSas();
								AihbkpihjLhuuTsztIvrPJxeaP = GxphHAMqMhNBLjnlhXuBQmXaALiE.GDTRtyJdiGNqaKicbrgdtRvqOHF().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00fc;
								IL_0160:
								if (yvmtbOqtnKwfCCOYhFdPEmeCgZv.MoveNext())
								{
									vUbWpcppLBMLxZLHYSysalQmpXx = yvmtbOqtnKwfCCOYhFdPEmeCgZv.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = vUbWpcppLBMLxZLHYSysalQmpXx;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 6;
									return true;
								}
								inoHDPRLRgblicbMjaZqaSLwBrxd();
								dyDUXXBArqQDUgsivKJhrbuXmCU = GxphHAMqMhNBLjnlhXuBQmXaALiE.iwkqLxbnxQdjMxrryXpjaIRSFFnC().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 7;
								goto IL_01c1;
								IL_00fc:
								if (AihbkpihjLhuuTsztIvrPJxeaP.MoveNext())
								{
									VABlxotWVsoictDoEiEqoXtxKOs = AihbkpihjLhuuTsztIvrPJxeaP.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = VABlxotWVsoictDoEiEqoXtxKOs;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 4;
									return true;
								}
								iISzTWwkAiExeppdAooPpULfdKA();
								yvmtbOqtnKwfCCOYhFdPEmeCgZv = GxphHAMqMhNBLjnlhXuBQmXaALiE.YjiqDLNDAyXmIKIdnmzTAbkZHux().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
								goto IL_0160;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								rrgIdgPYqfXuDdZpWFaMmJYSas();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								iISzTWwkAiExeppdAooPpULfdKA();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								inoHDPRLRgblicbMjaZqaSLwBrxd();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								HQuVRhvflEHzMOCYPHQVVnDQAFQ();
							}
						}
					}

					[DebuggerHidden]
					public JwpPqnvBxeFikLMqJOqmFOjKcWR(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void rrgIdgPYqfXuDdZpWFaMmJYSas()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (taLUNxcfhRhMGwveVdiHwpKkJBS != null)
						{
							taLUNxcfhRhMGwveVdiHwpKkJBS.Dispose();
						}
					}

					private void iISzTWwkAiExeppdAooPpULfdKA()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (AihbkpihjLhuuTsztIvrPJxeaP != null)
						{
							AihbkpihjLhuuTsztIvrPJxeaP.Dispose();
						}
					}

					private void inoHDPRLRgblicbMjaZqaSLwBrxd()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (yvmtbOqtnKwfCCOYhFdPEmeCgZv != null)
						{
							yvmtbOqtnKwfCCOYhFdPEmeCgZv.Dispose();
						}
					}

					private void HQuVRhvflEHzMOCYPHQVVnDQAFQ()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (dyDUXXBArqQDUgsivKJhrbuXmCU != null)
						{
							dyDUXXBArqQDUgsivKJhrbuXmCU.Dispose();
						}
					}
				}

				private sealed class KFMsAkZZTIcYgqjgvtqqryKnhzk : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerPollingInfo UiRDMTiAvNkijfKsddedkiLNugq;

					public ControllerPollingInfo JiHtwJalNGTOFaYDVBJikdWDqZD;

					public ControllerPollingInfo oWKztYitnuqMbVkFHHHzWxdcOaA;

					public ControllerPollingInfo BcYtBCRPlkWKXHXdxUWHCEoUIKB;

					public IEnumerator<ControllerPollingInfo> KbmuDRSSYprWsttyQpVdgpechBW;

					public IEnumerator<ControllerPollingInfo> GhtEOPiriaDSaySIcrHtoETpwzX;

					public IEnumerator<ControllerPollingInfo> yAEqbYeisnepOaAEfwLYTBfFaDsB;

					public IEnumerator<ControllerPollingInfo> gATYBFppwClEaMZcOPHCqfcJxZA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						KFMsAkZZTIcYgqjgvtqqryKnhzk kFMsAkZZTIcYgqjgvtqqryKnhzk;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							kFMsAkZZTIcYgqjgvtqqryKnhzk = this;
						}
						else
						{
							kFMsAkZZTIcYgqjgvtqqryKnhzk = new KFMsAkZZTIcYgqjgvtqqryKnhzk(0);
							kFMsAkZZTIcYgqjgvtqqryKnhzk.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return kFMsAkZZTIcYgqjgvtqqryKnhzk;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (!CheckInitialized())
								{
									break;
								}
								KbmuDRSSYprWsttyQpVdgpechBW = GxphHAMqMhNBLjnlhXuBQmXaALiE.MekJfrMVwstkkdeGJzaSIojEhPeK().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0098;
							case 2:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0098;
							case 4:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00fc;
							case 6:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
								goto IL_0160;
							case 8:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 7;
									goto IL_01c1;
								}
								IL_01c1:
								if (gATYBFppwClEaMZcOPHCqfcJxZA.MoveNext())
								{
									BcYtBCRPlkWKXHXdxUWHCEoUIKB = gATYBFppwClEaMZcOPHCqfcJxZA.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = BcYtBCRPlkWKXHXdxUWHCEoUIKB;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 8;
									return true;
								}
								jVkHekBRcDejxgLhFcwqcvJcRBrW();
								break;
								IL_0098:
								if (KbmuDRSSYprWsttyQpVdgpechBW.MoveNext())
								{
									UiRDMTiAvNkijfKsddedkiLNugq = KbmuDRSSYprWsttyQpVdgpechBW.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = UiRDMTiAvNkijfKsddedkiLNugq;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								xEvYmzYFlninJZKlFfScGNBvnNRm();
								GhtEOPiriaDSaySIcrHtoETpwzX = GxphHAMqMhNBLjnlhXuBQmXaALiE.mENAeZeCVThercryLzDDaWWwAfIF().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00fc;
								IL_0160:
								if (yAEqbYeisnepOaAEfwLYTBfFaDsB.MoveNext())
								{
									oWKztYitnuqMbVkFHHHzWxdcOaA = yAEqbYeisnepOaAEfwLYTBfFaDsB.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = oWKztYitnuqMbVkFHHHzWxdcOaA;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 6;
									return true;
								}
								CiYaZIdkjLlBXTVlELrDAXzLLljb();
								gATYBFppwClEaMZcOPHCqfcJxZA = GxphHAMqMhNBLjnlhXuBQmXaALiE.MZmoCAIzSQZMaFaOcqFhLZjmhfe().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 7;
								goto IL_01c1;
								IL_00fc:
								if (GhtEOPiriaDSaySIcrHtoETpwzX.MoveNext())
								{
									JiHtwJalNGTOFaYDVBJikdWDqZD = GhtEOPiriaDSaySIcrHtoETpwzX.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = JiHtwJalNGTOFaYDVBJikdWDqZD;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 4;
									return true;
								}
								jQldpOKbgEmuXWJMVFHDFaXtofnn();
								yAEqbYeisnepOaAEfwLYTBfFaDsB = GxphHAMqMhNBLjnlhXuBQmXaALiE.sGnZfrsndkQuxnIfiAjlxgExdQO().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
								goto IL_0160;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								xEvYmzYFlninJZKlFfScGNBvnNRm();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								jQldpOKbgEmuXWJMVFHDFaXtofnn();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								CiYaZIdkjLlBXTVlELrDAXzLLljb();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								jVkHekBRcDejxgLhFcwqcvJcRBrW();
							}
						}
					}

					[DebuggerHidden]
					public KFMsAkZZTIcYgqjgvtqqryKnhzk(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void xEvYmzYFlninJZKlFfScGNBvnNRm()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (KbmuDRSSYprWsttyQpVdgpechBW != null)
						{
							KbmuDRSSYprWsttyQpVdgpechBW.Dispose();
						}
					}

					private void jQldpOKbgEmuXWJMVFHDFaXtofnn()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GhtEOPiriaDSaySIcrHtoETpwzX != null)
						{
							GhtEOPiriaDSaySIcrHtoETpwzX.Dispose();
						}
					}

					private void CiYaZIdkjLlBXTVlELrDAXzLLljb()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (yAEqbYeisnepOaAEfwLYTBfFaDsB != null)
						{
							yAEqbYeisnepOaAEfwLYTBfFaDsB.Dispose();
						}
					}

					private void jVkHekBRcDejxgLhFcwqcvJcRBrW()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (gATYBFppwClEaMZcOPHCqfcJxZA != null)
						{
							gATYBFppwClEaMZcOPHCqfcJxZA.Dispose();
						}
					}
				}

				private sealed class nQqeFmAzYdzxutEhRruJysUznzE : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public ControllerPollingInfo OarUkfGKYMiDEVTVqILEeKTMoxp;

					public ControllerPollingInfo hENAWCxVBSwDsHdipKFQLfXtqKK;

					public ControllerPollingInfo gcgRezcaZcgFrmowLvRtzrYrsBz;

					public IEnumerator<ControllerPollingInfo> vpsALzdFxTNgTcrTefckWSlRTdUt;

					public IEnumerator<ControllerPollingInfo> pdjFbsfnzeHoUtxYWWLtatKaEfA;

					public IEnumerator<ControllerPollingInfo> wHFtRUIIMSPwtRRwVabLcXyhIvj;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						nQqeFmAzYdzxutEhRruJysUznzE nQqeFmAzYdzxutEhRruJysUznzE2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							nQqeFmAzYdzxutEhRruJysUznzE2 = this;
						}
						else
						{
							nQqeFmAzYdzxutEhRruJysUznzE2 = new nQqeFmAzYdzxutEhRruJysUznzE(0);
							nQqeFmAzYdzxutEhRruJysUznzE2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return nQqeFmAzYdzxutEhRruJysUznzE2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (!CheckInitialized())
								{
									break;
								}
								vpsALzdFxTNgTcrTefckWSlRTdUt = GxphHAMqMhNBLjnlhXuBQmXaALiE.oTMUZeacEsgqzBrDYkhEWjiXxUwB().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0090;
							case 2:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0090;
							case 4:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00f4;
							case 6:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
									goto IL_0155;
								}
								IL_00f4:
								if (pdjFbsfnzeHoUtxYWWLtatKaEfA.MoveNext())
								{
									hENAWCxVBSwDsHdipKFQLfXtqKK = pdjFbsfnzeHoUtxYWWLtatKaEfA.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = hENAWCxVBSwDsHdipKFQLfXtqKK;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 4;
									return true;
								}
								GPJgZwwUAqdRfjzGVpdTHPtUNnzc();
								wHFtRUIIMSPwtRRwVabLcXyhIvj = GxphHAMqMhNBLjnlhXuBQmXaALiE.UItEHssUfFoTkLnHHgGNaeGMFOr().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 5;
								goto IL_0155;
								IL_0090:
								if (vpsALzdFxTNgTcrTefckWSlRTdUt.MoveNext())
								{
									OarUkfGKYMiDEVTVqILEeKTMoxp = vpsALzdFxTNgTcrTefckWSlRTdUt.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = OarUkfGKYMiDEVTVqILEeKTMoxp;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								YeCNNmfYcDUoazKFSFyAuFncOpO();
								pdjFbsfnzeHoUtxYWWLtatKaEfA = GxphHAMqMhNBLjnlhXuBQmXaALiE.yeahmXUBSZaGduljQunHxFkibYz().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
								goto IL_00f4;
								IL_0155:
								if (wHFtRUIIMSPwtRRwVabLcXyhIvj.MoveNext())
								{
									gcgRezcaZcgFrmowLvRtzrYrsBz = wHFtRUIIMSPwtRRwVabLcXyhIvj.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = gcgRezcaZcgFrmowLvRtzrYrsBz;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 6;
									return true;
								}
								AMvqdsOKKSWWOROmIADUKJBsTho();
								break;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								YeCNNmfYcDUoazKFSFyAuFncOpO();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								GPJgZwwUAqdRfjzGVpdTHPtUNnzc();
							}
							break;
						}
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 5:
						case 6:
							try
							{
								break;
							}
							finally
							{
								AMvqdsOKKSWWOROmIADUKJBsTho();
							}
						}
					}

					[DebuggerHidden]
					public nQqeFmAzYdzxutEhRruJysUznzE(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void YeCNNmfYcDUoazKFSFyAuFncOpO()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (vpsALzdFxTNgTcrTefckWSlRTdUt != null)
						{
							vpsALzdFxTNgTcrTefckWSlRTdUt.Dispose();
						}
					}

					private void GPJgZwwUAqdRfjzGVpdTHPtUNnzc()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (pdjFbsfnzeHoUtxYWWLtatKaEfA != null)
						{
							pdjFbsfnzeHoUtxYWWLtatKaEfA.Dispose();
						}
					}

					private void AMvqdsOKKSWWOROmIADUKJBsTho()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (wHFtRUIIMSPwtRRwVabLcXyhIvj != null)
						{
							wHFtRUIIMSPwtRRwVabLcXyhIvj.Dispose();
						}
					}
				}

				private sealed class FLxbBjjdzkSXecEwfkIVYDYScUB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<Joystick> EYNtLaqGWSBUfykEkhBJfOxtvbhc;

					public int TtJycNHsgsKmRkdIwcAjWerrkqm;

					public ControllerPollingInfo mTLVyGMjsGdgVrNpMRyikabOMBz;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> rtvhHHJzDWhcGCyQTwgiLINZjJoe;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						FLxbBjjdzkSXecEwfkIVYDYScUB fLxbBjjdzkSXecEwfkIVYDYScUB;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							fLxbBjjdzkSXecEwfkIVYDYScUB = this;
						}
						else
						{
							fLxbBjjdzkSXecEwfkIVYDYScUB = new FLxbBjjdzkSXecEwfkIVYDYScUB(0);
							fLxbBjjdzkSXecEwfkIVYDYScUB.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return fLxbBjjdzkSXecEwfkIVYDYScUB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								EYNtLaqGWSBUfykEkhBJfOxtvbhc = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
								TtJycNHsgsKmRkdIwcAjWerrkqm = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (TtJycNHsgsKmRkdIwcAjWerrkqm >= EYNtLaqGWSBUfykEkhBJfOxtvbhc.Count)
								{
									break;
								}
								rtvhHHJzDWhcGCyQTwgiLINZjJoe = EYNtLaqGWSBUfykEkhBJfOxtvbhc[TtJycNHsgsKmRkdIwcAjWerrkqm].PollForAllElements().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (rtvhHHJzDWhcGCyQTwgiLINZjJoe.MoveNext())
								{
									mTLVyGMjsGdgVrNpMRyikabOMBz = rtvhHHJzDWhcGCyQTwgiLINZjJoe.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = mTLVyGMjsGdgVrNpMRyikabOMBz;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								HiyiXXtGUhrHusaJqVupHTSvQOQ();
								TtJycNHsgsKmRkdIwcAjWerrkqm++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								HiyiXXtGUhrHusaJqVupHTSvQOQ();
							}
						}
					}

					[DebuggerHidden]
					public FLxbBjjdzkSXecEwfkIVYDYScUB(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void HiyiXXtGUhrHusaJqVupHTSvQOQ()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (rtvhHHJzDWhcGCyQTwgiLINZjJoe != null)
						{
							rtvhHHJzDWhcGCyQTwgiLINZjJoe.Dispose();
						}
					}
				}

				private sealed class PZnNejFnynQhltaPdWJHbEhNdCJ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<Joystick> LhYrFgIVRhbtheebqbMDDkGZEZK;

					public int diAKDKRmQwVJecGIpSszetRNCOr;

					public ControllerPollingInfo qEBDIcBJrFJDELplffAjrlOLGpa;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> pPhBtovCVFofVoibpAyCahMoNUO;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						PZnNejFnynQhltaPdWJHbEhNdCJ pZnNejFnynQhltaPdWJHbEhNdCJ;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							pZnNejFnynQhltaPdWJHbEhNdCJ = this;
						}
						else
						{
							pZnNejFnynQhltaPdWJHbEhNdCJ = new PZnNejFnynQhltaPdWJHbEhNdCJ(0);
							pZnNejFnynQhltaPdWJHbEhNdCJ.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return pZnNejFnynQhltaPdWJHbEhNdCJ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								LhYrFgIVRhbtheebqbMDDkGZEZK = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
								diAKDKRmQwVJecGIpSszetRNCOr = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (diAKDKRmQwVJecGIpSszetRNCOr >= LhYrFgIVRhbtheebqbMDDkGZEZK.Count)
								{
									break;
								}
								pPhBtovCVFofVoibpAyCahMoNUO = LhYrFgIVRhbtheebqbMDDkGZEZK[diAKDKRmQwVJecGIpSszetRNCOr].PollForAllElementsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (pPhBtovCVFofVoibpAyCahMoNUO.MoveNext())
								{
									qEBDIcBJrFJDELplffAjrlOLGpa = pPhBtovCVFofVoibpAyCahMoNUO.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = qEBDIcBJrFJDELplffAjrlOLGpa;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								DCBimMaioYHQLuwjNTYyyThJirEd();
								diAKDKRmQwVJecGIpSszetRNCOr++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								DCBimMaioYHQLuwjNTYyyThJirEd();
							}
						}
					}

					[DebuggerHidden]
					public PZnNejFnynQhltaPdWJHbEhNdCJ(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void DCBimMaioYHQLuwjNTYyyThJirEd()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (pPhBtovCVFofVoibpAyCahMoNUO != null)
						{
							pPhBtovCVFofVoibpAyCahMoNUO.Dispose();
						}
					}
				}

				private sealed class JTtFdkjkUpJockmrrgxwEkTamULM : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<Joystick> IqMEdHYVmyqZZkxymaCsQrNhlHK;

					public int JjkYtpHYcOPQBOistfaGFoCijlEG;

					public ControllerPollingInfo LbTVqaLKCvAbsIWDrGKeUzDwXMnU;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> cQIRZfZBUKpcRQyVzncOWgNwejr;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						JTtFdkjkUpJockmrrgxwEkTamULM jTtFdkjkUpJockmrrgxwEkTamULM;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							jTtFdkjkUpJockmrrgxwEkTamULM = this;
						}
						else
						{
							jTtFdkjkUpJockmrrgxwEkTamULM = new JTtFdkjkUpJockmrrgxwEkTamULM(0);
							jTtFdkjkUpJockmrrgxwEkTamULM.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return jTtFdkjkUpJockmrrgxwEkTamULM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								IqMEdHYVmyqZZkxymaCsQrNhlHK = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
								JjkYtpHYcOPQBOistfaGFoCijlEG = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (JjkYtpHYcOPQBOistfaGFoCijlEG >= IqMEdHYVmyqZZkxymaCsQrNhlHK.Count)
								{
									break;
								}
								cQIRZfZBUKpcRQyVzncOWgNwejr = IqMEdHYVmyqZZkxymaCsQrNhlHK[JjkYtpHYcOPQBOistfaGFoCijlEG].PollForAllButtons().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (cQIRZfZBUKpcRQyVzncOWgNwejr.MoveNext())
								{
									LbTVqaLKCvAbsIWDrGKeUzDwXMnU = cQIRZfZBUKpcRQyVzncOWgNwejr.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = LbTVqaLKCvAbsIWDrGKeUzDwXMnU;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								EbZWsogLrzBrasemsRYwMIcUAbB();
								JjkYtpHYcOPQBOistfaGFoCijlEG++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								EbZWsogLrzBrasemsRYwMIcUAbB();
							}
						}
					}

					[DebuggerHidden]
					public JTtFdkjkUpJockmrrgxwEkTamULM(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void EbZWsogLrzBrasemsRYwMIcUAbB()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (cQIRZfZBUKpcRQyVzncOWgNwejr != null)
						{
							cQIRZfZBUKpcRQyVzncOWgNwejr.Dispose();
						}
					}
				}

				private sealed class KAZytzQsPaPdqelCboGaTRWLPAB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<Joystick> VYQDBQBtDrvvvByfVvSXTAXYjEz;

					public int wtnxNyZDTcncqaXaqRiAHAQhjTd;

					public ControllerPollingInfo JRvPyHNJGzIodNhtiBfKWaLBSXZ;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> ngFsxDLbHrmUPgfbMCkpCFCnGSbh;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						KAZytzQsPaPdqelCboGaTRWLPAB kAZytzQsPaPdqelCboGaTRWLPAB;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							kAZytzQsPaPdqelCboGaTRWLPAB = this;
						}
						else
						{
							kAZytzQsPaPdqelCboGaTRWLPAB = new KAZytzQsPaPdqelCboGaTRWLPAB(0);
							kAZytzQsPaPdqelCboGaTRWLPAB.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return kAZytzQsPaPdqelCboGaTRWLPAB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								VYQDBQBtDrvvvByfVvSXTAXYjEz = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
								wtnxNyZDTcncqaXaqRiAHAQhjTd = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (wtnxNyZDTcncqaXaqRiAHAQhjTd >= VYQDBQBtDrvvvByfVvSXTAXYjEz.Count)
								{
									break;
								}
								ngFsxDLbHrmUPgfbMCkpCFCnGSbh = VYQDBQBtDrvvvByfVvSXTAXYjEz[wtnxNyZDTcncqaXaqRiAHAQhjTd].PollForAllButtonsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (ngFsxDLbHrmUPgfbMCkpCFCnGSbh.MoveNext())
								{
									JRvPyHNJGzIodNhtiBfKWaLBSXZ = ngFsxDLbHrmUPgfbMCkpCFCnGSbh.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = JRvPyHNJGzIodNhtiBfKWaLBSXZ;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								vMoNMbbouCOamxOKEHkgRrDGwUi();
								wtnxNyZDTcncqaXaqRiAHAQhjTd++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								vMoNMbbouCOamxOKEHkgRrDGwUi();
							}
						}
					}

					[DebuggerHidden]
					public KAZytzQsPaPdqelCboGaTRWLPAB(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void vMoNMbbouCOamxOKEHkgRrDGwUi()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ngFsxDLbHrmUPgfbMCkpCFCnGSbh != null)
						{
							ngFsxDLbHrmUPgfbMCkpCFCnGSbh.Dispose();
						}
					}
				}

				private sealed class yJQjaiZHHDuaxScWdfVUDvuDRuwC : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<Joystick> DIPskwMcRmRFJNNeOLgDmpHdJcd;

					public int cBqQbNqoGTajbKEDBZCcNYbnTAB;

					public ControllerPollingInfo ocFbDEpqTqRsiKItrtDifWLQSIR;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> GnccEJOHUpieBvEZLVeWFRyeSkH;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						yJQjaiZHHDuaxScWdfVUDvuDRuwC yJQjaiZHHDuaxScWdfVUDvuDRuwC2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							yJQjaiZHHDuaxScWdfVUDvuDRuwC2 = this;
						}
						else
						{
							yJQjaiZHHDuaxScWdfVUDvuDRuwC2 = new yJQjaiZHHDuaxScWdfVUDvuDRuwC(0);
							yJQjaiZHHDuaxScWdfVUDvuDRuwC2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return yJQjaiZHHDuaxScWdfVUDvuDRuwC2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								DIPskwMcRmRFJNNeOLgDmpHdJcd = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
								cBqQbNqoGTajbKEDBZCcNYbnTAB = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (cBqQbNqoGTajbKEDBZCcNYbnTAB >= DIPskwMcRmRFJNNeOLgDmpHdJcd.Count)
								{
									break;
								}
								GnccEJOHUpieBvEZLVeWFRyeSkH = DIPskwMcRmRFJNNeOLgDmpHdJcd[cBqQbNqoGTajbKEDBZCcNYbnTAB].PollForAllAxes().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (GnccEJOHUpieBvEZLVeWFRyeSkH.MoveNext())
								{
									ocFbDEpqTqRsiKItrtDifWLQSIR = GnccEJOHUpieBvEZLVeWFRyeSkH.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = ocFbDEpqTqRsiKItrtDifWLQSIR;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								NzofckIukeVDRuxLOFPEaffeZOVh();
								cBqQbNqoGTajbKEDBZCcNYbnTAB++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								NzofckIukeVDRuxLOFPEaffeZOVh();
							}
						}
					}

					[DebuggerHidden]
					public yJQjaiZHHDuaxScWdfVUDvuDRuwC(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void NzofckIukeVDRuxLOFPEaffeZOVh()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (GnccEJOHUpieBvEZLVeWFRyeSkH != null)
						{
							GnccEJOHUpieBvEZLVeWFRyeSkH.Dispose();
						}
					}
				}

				private sealed class vBEbySABTOBJbiYUDpBzUbjcQFsB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<CustomController> mEMjtPtLiWbvhpGUsCDjYyYpEKf;

					public int UytxGlKrjtFBGSDaPebGFAiOiRyl;

					public ControllerPollingInfo VuUQFKaajwAuNfaHdIblVEzkEVYm;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> zDexGiLrjblmQHRddIVytgpzcPN;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						vBEbySABTOBJbiYUDpBzUbjcQFsB vBEbySABTOBJbiYUDpBzUbjcQFsB2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							vBEbySABTOBJbiYUDpBzUbjcQFsB2 = this;
						}
						else
						{
							vBEbySABTOBJbiYUDpBzUbjcQFsB2 = new vBEbySABTOBJbiYUDpBzUbjcQFsB(0);
							vBEbySABTOBJbiYUDpBzUbjcQFsB2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return vBEbySABTOBJbiYUDpBzUbjcQFsB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								mEMjtPtLiWbvhpGUsCDjYyYpEKf = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
								UytxGlKrjtFBGSDaPebGFAiOiRyl = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (UytxGlKrjtFBGSDaPebGFAiOiRyl >= mEMjtPtLiWbvhpGUsCDjYyYpEKf.Count)
								{
									break;
								}
								zDexGiLrjblmQHRddIVytgpzcPN = mEMjtPtLiWbvhpGUsCDjYyYpEKf[UytxGlKrjtFBGSDaPebGFAiOiRyl].PollForAllElements().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (zDexGiLrjblmQHRddIVytgpzcPN.MoveNext())
								{
									VuUQFKaajwAuNfaHdIblVEzkEVYm = zDexGiLrjblmQHRddIVytgpzcPN.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = VuUQFKaajwAuNfaHdIblVEzkEVYm;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								bSMHimrNJPqjYDsBmooOOQqLmyE();
								UytxGlKrjtFBGSDaPebGFAiOiRyl++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								bSMHimrNJPqjYDsBmooOOQqLmyE();
							}
						}
					}

					[DebuggerHidden]
					public vBEbySABTOBJbiYUDpBzUbjcQFsB(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void bSMHimrNJPqjYDsBmooOOQqLmyE()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (zDexGiLrjblmQHRddIVytgpzcPN != null)
						{
							zDexGiLrjblmQHRddIVytgpzcPN.Dispose();
						}
					}
				}

				private sealed class uBbiKGCLwQStHlboJUdnIABadE : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<CustomController> jyJeRBcuSegrLKSbwTkscsklKTdN;

					public int tfFyKEgSLsnEhuLcNJOIiEttGfo;

					public ControllerPollingInfo TqoTSnxFZWyDidSRiPQtjjyThUo;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> zOeySwyfwvUsvoIgHPhEEeGqdtm;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						uBbiKGCLwQStHlboJUdnIABadE uBbiKGCLwQStHlboJUdnIABadE2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							uBbiKGCLwQStHlboJUdnIABadE2 = this;
						}
						else
						{
							uBbiKGCLwQStHlboJUdnIABadE2 = new uBbiKGCLwQStHlboJUdnIABadE(0);
							uBbiKGCLwQStHlboJUdnIABadE2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return uBbiKGCLwQStHlboJUdnIABadE2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								jyJeRBcuSegrLKSbwTkscsklKTdN = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
								tfFyKEgSLsnEhuLcNJOIiEttGfo = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (tfFyKEgSLsnEhuLcNJOIiEttGfo >= jyJeRBcuSegrLKSbwTkscsklKTdN.Count)
								{
									break;
								}
								zOeySwyfwvUsvoIgHPhEEeGqdtm = jyJeRBcuSegrLKSbwTkscsklKTdN[tfFyKEgSLsnEhuLcNJOIiEttGfo].PollForAllElementsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (zOeySwyfwvUsvoIgHPhEEeGqdtm.MoveNext())
								{
									TqoTSnxFZWyDidSRiPQtjjyThUo = zOeySwyfwvUsvoIgHPhEEeGqdtm.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = TqoTSnxFZWyDidSRiPQtjjyThUo;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								fRmzSDudHiwxLASLQGWZMMeFgGR();
								tfFyKEgSLsnEhuLcNJOIiEttGfo++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								fRmzSDudHiwxLASLQGWZMMeFgGR();
							}
						}
					}

					[DebuggerHidden]
					public uBbiKGCLwQStHlboJUdnIABadE(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void fRmzSDudHiwxLASLQGWZMMeFgGR()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (zOeySwyfwvUsvoIgHPhEEeGqdtm != null)
						{
							zOeySwyfwvUsvoIgHPhEEeGqdtm.Dispose();
						}
					}
				}

				private sealed class LFmbwmufFQLNoYokmilHQVKMGTMC : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<CustomController> hlWCWMdaxviLTVSGpqjBfNoITPJ;

					public int PkwcJZZQXQSjqSZLSHSGKNsciGu;

					public ControllerPollingInfo maYPEXGIeTaKRsrElDIgkePfrgS;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> liHfdmsuXWpTzyljkugWlhiAHGz;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						LFmbwmufFQLNoYokmilHQVKMGTMC lFmbwmufFQLNoYokmilHQVKMGTMC;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							lFmbwmufFQLNoYokmilHQVKMGTMC = this;
						}
						else
						{
							lFmbwmufFQLNoYokmilHQVKMGTMC = new LFmbwmufFQLNoYokmilHQVKMGTMC(0);
							lFmbwmufFQLNoYokmilHQVKMGTMC.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return lFmbwmufFQLNoYokmilHQVKMGTMC;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								hlWCWMdaxviLTVSGpqjBfNoITPJ = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
								PkwcJZZQXQSjqSZLSHSGKNsciGu = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (PkwcJZZQXQSjqSZLSHSGKNsciGu >= hlWCWMdaxviLTVSGpqjBfNoITPJ.Count)
								{
									break;
								}
								liHfdmsuXWpTzyljkugWlhiAHGz = hlWCWMdaxviLTVSGpqjBfNoITPJ[PkwcJZZQXQSjqSZLSHSGKNsciGu].PollForAllButtons().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (liHfdmsuXWpTzyljkugWlhiAHGz.MoveNext())
								{
									maYPEXGIeTaKRsrElDIgkePfrgS = liHfdmsuXWpTzyljkugWlhiAHGz.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = maYPEXGIeTaKRsrElDIgkePfrgS;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								OlzMLNmNfwAzwMafkUdJxygmTQW();
								PkwcJZZQXQSjqSZLSHSGKNsciGu++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								OlzMLNmNfwAzwMafkUdJxygmTQW();
							}
						}
					}

					[DebuggerHidden]
					public LFmbwmufFQLNoYokmilHQVKMGTMC(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void OlzMLNmNfwAzwMafkUdJxygmTQW()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (liHfdmsuXWpTzyljkugWlhiAHGz != null)
						{
							liHfdmsuXWpTzyljkugWlhiAHGz.Dispose();
						}
					}
				}

				private sealed class ZkGcNaYoBGhDmapHnaxqlznjFZi : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<CustomController> XRPcsJLTHbYvwJxsNqDMkMINIScj;

					public int OzEKPfhsgSALIJFzjOREIoAMFUCh;

					public ControllerPollingInfo eWuyGUojdbHAUIMjYlgwgUWKQaF;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> QejIEyQMWwUleVjHafJostsNwMu;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						ZkGcNaYoBGhDmapHnaxqlznjFZi zkGcNaYoBGhDmapHnaxqlznjFZi;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							zkGcNaYoBGhDmapHnaxqlznjFZi = this;
						}
						else
						{
							zkGcNaYoBGhDmapHnaxqlznjFZi = new ZkGcNaYoBGhDmapHnaxqlznjFZi(0);
							zkGcNaYoBGhDmapHnaxqlznjFZi.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return zkGcNaYoBGhDmapHnaxqlznjFZi;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								XRPcsJLTHbYvwJxsNqDMkMINIScj = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
								OzEKPfhsgSALIJFzjOREIoAMFUCh = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (OzEKPfhsgSALIJFzjOREIoAMFUCh >= XRPcsJLTHbYvwJxsNqDMkMINIScj.Count)
								{
									break;
								}
								QejIEyQMWwUleVjHafJostsNwMu = XRPcsJLTHbYvwJxsNqDMkMINIScj[OzEKPfhsgSALIJFzjOREIoAMFUCh].PollForAllButtonsDown().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (QejIEyQMWwUleVjHafJostsNwMu.MoveNext())
								{
									eWuyGUojdbHAUIMjYlgwgUWKQaF = QejIEyQMWwUleVjHafJostsNwMu.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = eWuyGUojdbHAUIMjYlgwgUWKQaF;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								ilbRhFWWKaGCuqGMtHJxXemAVNb();
								OzEKPfhsgSALIJFzjOREIoAMFUCh++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								ilbRhFWWKaGCuqGMtHJxXemAVNb();
							}
						}
					}

					[DebuggerHidden]
					public ZkGcNaYoBGhDmapHnaxqlznjFZi(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void ilbRhFWWKaGCuqGMtHJxXemAVNb()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (QejIEyQMWwUleVjHafJostsNwMu != null)
						{
							QejIEyQMWwUleVjHafJostsNwMu.Dispose();
						}
					}
				}

				private sealed class dKLDDhAUalbYTWXFZkwOADETHTfk : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public IList<CustomController> UZEcygaePzsLbtMHcHbkmzXwcplP;

					public int PqnOvUUuDQYsnCTWRZzBcncAbkV;

					public ControllerPollingInfo TBDLDyQORfjYoKPjeWUTirxZDaw;

					public PollingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ControllerPollingInfo> pMfdVgUwccjsiHVqmhZteCMTMdr;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						dKLDDhAUalbYTWXFZkwOADETHTfk dKLDDhAUalbYTWXFZkwOADETHTfk2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							dKLDDhAUalbYTWXFZkwOADETHTfk2 = this;
						}
						else
						{
							dKLDDhAUalbYTWXFZkwOADETHTfk2 = new dKLDDhAUalbYTWXFZkwOADETHTfk(0);
							dKLDDhAUalbYTWXFZkwOADETHTfk2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						return dKLDDhAUalbYTWXFZkwOADETHTfk2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								UZEcygaePzsLbtMHcHbkmzXwcplP = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
								PqnOvUUuDQYsnCTWRZzBcncAbkV = 0;
								goto IL_00b8;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (PqnOvUUuDQYsnCTWRZzBcncAbkV >= UZEcygaePzsLbtMHcHbkmzXwcplP.Count)
								{
									break;
								}
								pMfdVgUwccjsiHVqmhZteCMTMdr = UZEcygaePzsLbtMHcHbkmzXwcplP[PqnOvUUuDQYsnCTWRZzBcncAbkV].PollForAllAxes().GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_0097;
								IL_0097:
								if (pMfdVgUwccjsiHVqmhZteCMTMdr.MoveNext())
								{
									TBDLDyQORfjYoKPjeWUTirxZDaw = pMfdVgUwccjsiHVqmhZteCMTMdr.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = TBDLDyQORfjYoKPjeWUTirxZDaw;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								aQyBhETecfIeQxboqOQCXnTZXzP();
								PqnOvUUuDQYsnCTWRZzBcncAbkV++;
								goto IL_00b8;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								aQyBhETecfIeQxboqOQCXnTZXzP();
							}
						}
					}

					[DebuggerHidden]
					public dKLDDhAUalbYTWXFZkwOADETHTfk(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void aQyBhETecfIeQxboqOQCXnTZXzP()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (pMfdVgUwccjsiHVqmhZteCMTMdr != null)
						{
							pMfdVgUwccjsiHVqmhZteCMTMdr.Dispose();
						}
					}
				}

				private static PollingHelper SKcIgrdHSZRiIzfxUyDOqjyMnCX;

				internal static PollingHelper Instance => SKcIgrdHSZRiIzfxUyDOqjyMnCX ?? (SKcIgrdHSZRiIzfxUyDOqjyMnCX = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = RdcBMjhCECQBIRvqqFfggQVUNGg();
					if (result.success)
					{
						return result;
					}
					result = hyWEznkpZnCHzfcHojpLzoneCvyC();
					if (result.success)
					{
						return result;
					}
					result = JctJOlqUAcSHtrKTkDhqAfqYdqyJ();
					if (result.success)
					{
						return result;
					}
					result = GzbNpIDKebmkOFGFmXxqGvCbfqb();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = FkoUKIdaRciQBCDkqEKrQSFgFtzh();
					if (result.success)
					{
						return result;
					}
					result = YsihUDAQvqGuRHQplAvyPgOZcnK();
					if (result.success)
					{
						return result;
					}
					result = UkwEMbvVcqpwccvScSQSSEnPjNl();
					if (result.success)
					{
						return result;
					}
					result = xzUulTHqkvJqpsKDyCCofgEjERd();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = hfJOZVucIHczYsttwhukrJcsyVv();
					if (result.success)
					{
						return result;
					}
					result = hyWEznkpZnCHzfcHojpLzoneCvyC();
					if (result.success)
					{
						return result;
					}
					result = QkOHkGLpaCpqwUPpzHINnTyyPiY();
					if (result.success)
					{
						return result;
					}
					result = HOLQfDIdqdtvOUoaIDTFjZoijqGd();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = tiAcPesTbwwOSIcfTycPCasZCYj();
					if (result.success)
					{
						return result;
					}
					result = YsihUDAQvqGuRHQplAvyPgOZcnK();
					if (result.success)
					{
						return result;
					}
					result = cvKlstuetRpLqtYWfPzRWZOImAP();
					if (result.success)
					{
						return result;
					}
					result = nZLEfrMKdkyMqtFTeAxQOIPiYJk();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					ControllerPollingInfo result = irjsKDPNtrZmkumaRpuQyFlIShu();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					if (result.success)
					{
						return result;
					}
					result = KccjWBRlqNefKJtONmeFqHdjQRn();
					if (result.success)
					{
						return result;
					}
					result = WFNaZjDydvWGfSByIlHtOEFZhQl();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => RdcBMjhCECQBIRvqqFfggQVUNGg(), 
						ControllerType.Keyboard => hyWEznkpZnCHzfcHojpLzoneCvyC(), 
						ControllerType.Mouse => JctJOlqUAcSHtrKTkDhqAfqYdqyJ(), 
						ControllerType.Custom => GzbNpIDKebmkOFGFmXxqGvCbfqb(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => FkoUKIdaRciQBCDkqEKrQSFgFtzh(), 
						ControllerType.Keyboard => YsihUDAQvqGuRHQplAvyPgOZcnK(), 
						ControllerType.Mouse => UkwEMbvVcqpwccvScSQSSEnPjNl(), 
						ControllerType.Custom => xzUulTHqkvJqpsKDyCCofgEjERd(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => hfJOZVucIHczYsttwhukrJcsyVv(), 
						ControllerType.Keyboard => hyWEznkpZnCHzfcHojpLzoneCvyC(), 
						ControllerType.Mouse => QkOHkGLpaCpqwUPpzHINnTyyPiY(), 
						ControllerType.Custom => HOLQfDIdqdtvOUoaIDTFjZoijqGd(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => tiAcPesTbwwOSIcfTycPCasZCYj(), 
						ControllerType.Keyboard => YsihUDAQvqGuRHQplAvyPgOZcnK(), 
						ControllerType.Mouse => cvKlstuetRpLqtYWfPzRWZOImAP(), 
						ControllerType.Custom => nZLEfrMKdkyMqtFTeAxQOIPiYJk(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => irjsKDPNtrZmkumaRpuQyFlIShu(), 
						ControllerType.Keyboard => ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY(), 
						ControllerType.Mouse => KccjWBRlqNefKJtONmeFqHdjQRn(), 
						ControllerType.Custom => WFNaZjDydvWGfSByIlHtOEFZhQl(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => TPeaefIQntVrpOAZJBmPvVRingR(controllerId), 
						ControllerType.Keyboard => hyWEznkpZnCHzfcHojpLzoneCvyC(), 
						ControllerType.Mouse => JctJOlqUAcSHtrKTkDhqAfqYdqyJ(), 
						ControllerType.Custom => CtcvieBJrGGXyHrVBBpahyqubKH(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => JWWZmlKbszDDIoPzaZbWPnrSKdy(controllerId), 
						ControllerType.Keyboard => YsihUDAQvqGuRHQplAvyPgOZcnK(), 
						ControllerType.Mouse => UkwEMbvVcqpwccvScSQSSEnPjNl(), 
						ControllerType.Custom => wAWNxpVEOvZvJtxGKwISNabJAhA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => xBPqMkOhBUCscAPttIooWAXqHvO(controllerId), 
						ControllerType.Keyboard => hyWEznkpZnCHzfcHojpLzoneCvyC(), 
						ControllerType.Mouse => QkOHkGLpaCpqwUPpzHINnTyyPiY(), 
						ControllerType.Custom => lhlbjxegrXbGyFnpddAUGxSVObj(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => nUDXIiGmcsYHEoyfhiMrurtGIUz(controllerId), 
						ControllerType.Keyboard => YsihUDAQvqGuRHQplAvyPgOZcnK(), 
						ControllerType.Mouse => cvKlstuetRpLqtYWfPzRWZOImAP(), 
						ControllerType.Custom => qkMZGCzglnVjyozxCLYGbjCDrSc(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
					}
					return controllerType switch
					{
						ControllerType.Joystick => SzaVUwuxuStVudqiDOedbzdUFjv(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY(), 
						ControllerType.Mouse => KccjWBRlqNefKJtONmeFqHdjQRn(), 
						ControllerType.Custom => UMewfvUKWTsJdVILhigNiDnsKtp(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					qlPCglxxogePwpybSBLytfRLeIFc qlPCglxxogePwpybSBLytfRLeIFc2 = new qlPCglxxogePwpybSBLytfRLeIFc(-2);
					qlPCglxxogePwpybSBLytfRLeIFc2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return qlPCglxxogePwpybSBLytfRLeIFc2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					CYiTlzNddDHfxrEWXjJbaxLqejf cYiTlzNddDHfxrEWXjJbaxLqejf = new CYiTlzNddDHfxrEWXjJbaxLqejf(-2);
					cYiTlzNddDHfxrEWXjJbaxLqejf.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return cYiTlzNddDHfxrEWXjJbaxLqejf;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					JwpPqnvBxeFikLMqJOqmFOjKcWR jwpPqnvBxeFikLMqJOqmFOjKcWR = new JwpPqnvBxeFikLMqJOqmFOjKcWR(-2);
					jwpPqnvBxeFikLMqJOqmFOjKcWR.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return jwpPqnvBxeFikLMqJOqmFOjKcWR;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					KFMsAkZZTIcYgqjgvtqqryKnhzk kFMsAkZZTIcYgqjgvtqqryKnhzk = new KFMsAkZZTIcYgqjgvtqqryKnhzk(-2);
					kFMsAkZZTIcYgqjgvtqqryKnhzk.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return kFMsAkZZTIcYgqjgvtqqryKnhzk;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					nQqeFmAzYdzxutEhRruJysUznzE nQqeFmAzYdzxutEhRruJysUznzE2 = new nQqeFmAzYdzxutEhRruJysUznzE(-2);
					nQqeFmAzYdzxutEhRruJysUznzE2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return nQqeFmAzYdzxutEhRruJysUznzE2;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => rgGbAbGjtWXpUyrjislYFuvynVJ(controllerId), 
						ControllerType.Keyboard => GDTRtyJdiGNqaKicbrgdtRvqOHF(), 
						ControllerType.Mouse => zvIyUDBRrgFtClHMTFEfFyrZmYQ(), 
						ControllerType.Custom => EHGCsVxVAdkVXoRNAbvyqundrjb(controllerId), 
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
						ControllerType.Joystick => dqJnHrPynjmGwuHXwLLzopnkZDx(controllerId), 
						ControllerType.Keyboard => mENAeZeCVThercryLzDDaWWwAfIF(), 
						ControllerType.Mouse => vkSEpdgbYbJZIASlGKYuOGIuCKpM(), 
						ControllerType.Custom => fVeTNuGXJmEwQKfKVnEYncBRejT(controllerId), 
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
						ControllerType.Joystick => ZcdzSQoqbiPzKOaobweRedGOMHX(controllerId), 
						ControllerType.Keyboard => GDTRtyJdiGNqaKicbrgdtRvqOHF(), 
						ControllerType.Mouse => YjiqDLNDAyXmIKIdnmzTAbkZHux(), 
						ControllerType.Custom => mVHmsJeIrRhQdRmStbVmiWnQSeQ(controllerId), 
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
						ControllerType.Joystick => ifLyEuKWSFFyHNlFWbFvzHuHIJX(controllerId), 
						ControllerType.Keyboard => mENAeZeCVThercryLzDDaWWwAfIF(), 
						ControllerType.Mouse => sGnZfrsndkQuxnIfiAjlxgExdQO(), 
						ControllerType.Custom => cSTaALWojGypKeiqoNXDplOLeol(controllerId), 
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
						ControllerType.Joystick => odIzQzpvCiCuAWoINFzNZJzIPII(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => yeahmXUBSZaGduljQunHxFkibYz(), 
						ControllerType.Custom => lAkBylauoTmTgOELUwxNwIOPChY(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo RdcBMjhCECQBIRvqqFfggQVUNGg()
				{
					IList<Joystick> joysticks_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo FkoUKIdaRciQBCDkqEKrQSFgFtzh()
				{
					IList<Joystick> joysticks_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo hfJOZVucIHczYsttwhukrJcsyVv()
				{
					IList<Joystick> joysticks_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo tiAcPesTbwwOSIcfTycPCasZCYj()
				{
					IList<Joystick> joysticks_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo irjsKDPNtrZmkumaRpuQyFlIShu()
				{
					IList<Joystick> joysticks_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo TPeaefIQntVrpOAZJBmPvVRingR(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo JWWZmlKbszDDIoPzaZbWPnrSKdy(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo xBPqMkOhBUCscAPttIooWAXqHvO(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo nUDXIiGmcsYHEoyfhiMrurtGIUz(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo SzaVUwuxuStVudqiDOedbzdUFjv(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo hyWEznkpZnCHzfcHojpLzoneCvyC()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo YsihUDAQvqGuRHQplAvyPgOZcnK()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo JctJOlqUAcSHtrKTkDhqAfqYdqyJ()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo UkwEMbvVcqpwccvScSQSSEnPjNl()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo QkOHkGLpaCpqwUPpzHINnTyyPiY()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo cvKlstuetRpLqtYWfPzRWZOImAP()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo KccjWBRlqNefKJtONmeFqHdjQRn()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo GzbNpIDKebmkOFGFmXxqGvCbfqb()
				{
					IList<CustomController> customControllers_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo xzUulTHqkvJqpsKDyCCofgEjERd()
				{
					IList<CustomController> customControllers_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo HOLQfDIdqdtvOUoaIDTFjZoijqGd()
				{
					IList<CustomController> customControllers_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo nZLEfrMKdkyMqtFTeAxQOIPiYJk()
				{
					IList<CustomController> customControllers_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo WFNaZjDydvWGfSByIlHtOEFZhQl()
				{
					IList<CustomController> customControllers_readOnly = AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo CtcvieBJrGGXyHrVBBpahyqubKH(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo wAWNxpVEOvZvJtxGKwISNabJAhA(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo lhlbjxegrXbGyFnpddAUGxSVObj(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo qkMZGCzglnVjyozxCLYGbjCDrSc(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private ControllerPollingInfo UMewfvUKWTsJdVILhigNiDnsKtp(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.SzFLVfJyThMscGjHlMeaEHMuwJY();
				}

				private IEnumerable<ControllerPollingInfo> erVHfuOXQJQmixaNxIGRYDHFFmc()
				{
					FLxbBjjdzkSXecEwfkIVYDYScUB fLxbBjjdzkSXecEwfkIVYDYScUB = new FLxbBjjdzkSXecEwfkIVYDYScUB(-2);
					fLxbBjjdzkSXecEwfkIVYDYScUB.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return fLxbBjjdzkSXecEwfkIVYDYScUB;
				}

				private IEnumerable<ControllerPollingInfo> ZFkAoDIDCULCKqCMJiqzlrqfyyyP()
				{
					PZnNejFnynQhltaPdWJHbEhNdCJ pZnNejFnynQhltaPdWJHbEhNdCJ = new PZnNejFnynQhltaPdWJHbEhNdCJ(-2);
					pZnNejFnynQhltaPdWJHbEhNdCJ.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return pZnNejFnynQhltaPdWJHbEhNdCJ;
				}

				private IEnumerable<ControllerPollingInfo> bDiADUDvggEEvgiabwWCEYVMFrq()
				{
					JTtFdkjkUpJockmrrgxwEkTamULM jTtFdkjkUpJockmrrgxwEkTamULM = new JTtFdkjkUpJockmrrgxwEkTamULM(-2);
					jTtFdkjkUpJockmrrgxwEkTamULM.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return jTtFdkjkUpJockmrrgxwEkTamULM;
				}

				private IEnumerable<ControllerPollingInfo> MekJfrMVwstkkdeGJzaSIojEhPeK()
				{
					KAZytzQsPaPdqelCboGaTRWLPAB kAZytzQsPaPdqelCboGaTRWLPAB = new KAZytzQsPaPdqelCboGaTRWLPAB(-2);
					kAZytzQsPaPdqelCboGaTRWLPAB.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return kAZytzQsPaPdqelCboGaTRWLPAB;
				}

				private IEnumerable<ControllerPollingInfo> oTMUZeacEsgqzBrDYkhEWjiXxUwB()
				{
					yJQjaiZHHDuaxScWdfVUDvuDRuwC yJQjaiZHHDuaxScWdfVUDvuDRuwC2 = new yJQjaiZHHDuaxScWdfVUDvuDRuwC(-2);
					yJQjaiZHHDuaxScWdfVUDvuDRuwC2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return yJQjaiZHHDuaxScWdfVUDvuDRuwC2;
				}

				private IEnumerable<ControllerPollingInfo> rgGbAbGjtWXpUyrjislYFuvynVJ(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> dqJnHrPynjmGwuHXwLLzopnkZDx(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> ZcdzSQoqbiPzKOaobweRedGOMHX(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> ifLyEuKWSFFyHNlFWbFvzHuHIJX(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> odIzQzpvCiCuAWoINFzNZJzIPII(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> GDTRtyJdiGNqaKicbrgdtRvqOHF()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> mENAeZeCVThercryLzDDaWWwAfIF()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> zvIyUDBRrgFtClHMTFEfFyrZmYQ()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> vkSEpdgbYbJZIASlGKYuOGIuCKpM()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> YjiqDLNDAyXmIKIdnmzTAbkZHux()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> sGnZfrsndkQuxnIfiAjlxgExdQO()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> yeahmXUBSZaGduljQunHxFkibYz()
				{
					return ControllerHelper.Instance.Mouse.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> LDbbFzgGBZBtlwNAamuGaFxphto()
				{
					vBEbySABTOBJbiYUDpBzUbjcQFsB vBEbySABTOBJbiYUDpBzUbjcQFsB2 = new vBEbySABTOBJbiYUDpBzUbjcQFsB(-2);
					vBEbySABTOBJbiYUDpBzUbjcQFsB2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return vBEbySABTOBJbiYUDpBzUbjcQFsB2;
				}

				private IEnumerable<ControllerPollingInfo> bYGRiiTjCpEmWspRFAbFHwSSBLR()
				{
					uBbiKGCLwQStHlboJUdnIABadE uBbiKGCLwQStHlboJUdnIABadE2 = new uBbiKGCLwQStHlboJUdnIABadE(-2);
					uBbiKGCLwQStHlboJUdnIABadE2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return uBbiKGCLwQStHlboJUdnIABadE2;
				}

				private IEnumerable<ControllerPollingInfo> iwkqLxbnxQdjMxrryXpjaIRSFFnC()
				{
					LFmbwmufFQLNoYokmilHQVKMGTMC lFmbwmufFQLNoYokmilHQVKMGTMC = new LFmbwmufFQLNoYokmilHQVKMGTMC(-2);
					lFmbwmufFQLNoYokmilHQVKMGTMC.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return lFmbwmufFQLNoYokmilHQVKMGTMC;
				}

				private IEnumerable<ControllerPollingInfo> MZmoCAIzSQZMaFaOcqFhLZjmhfe()
				{
					ZkGcNaYoBGhDmapHnaxqlznjFZi zkGcNaYoBGhDmapHnaxqlznjFZi = new ZkGcNaYoBGhDmapHnaxqlznjFZi(-2);
					zkGcNaYoBGhDmapHnaxqlznjFZi.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return zkGcNaYoBGhDmapHnaxqlznjFZi;
				}

				private IEnumerable<ControllerPollingInfo> UItEHssUfFoTkLnHHgGNaeGMFOr()
				{
					dKLDDhAUalbYTWXFZkwOADETHTfk dKLDDhAUalbYTWXFZkwOADETHTfk2 = new dKLDDhAUalbYTWXFZkwOADETHTfk(-2);
					dKLDDhAUalbYTWXFZkwOADETHTfk2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					return dKLDDhAUalbYTWXFZkwOADETHTfk2;
				}

				private IEnumerable<ControllerPollingInfo> EHGCsVxVAdkVXoRNAbvyqundrjb(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> fVeTNuGXJmEwQKfKVnEYncBRejT(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> mVHmsJeIrRhQdRmStbVmiWnQSeQ(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> cSTaALWojGypKeiqoNXDplOLeol(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> lAkBylauoTmTgOELUwxNwIOPChY(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
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
				private sealed class EeqaBmjOoMpzsFEAzEXNQWOkCVL : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public int KcihJPqCzQKLaiJAuOEZocqkGuT;

					public int AfYqsSbNrMWaNGJMccPnIBWOrubS;

					public int wtKbEuOgpmCyodusgKCfdeRTDQVb;

					public int vwsWqbAxZchMsrPtAyVDSdLCrYZ;

					public JoystickMap VJzhVlrBOcGBCCFZprAmLnYqptl;

					public JoystickMap QAgyYUmecnNCVLpzuecMsGLCdJP;

					public ActionElementMap JDEKtLtSnUsjrIbhVeZfySvvFnT;

					public ActionElementMap NkBrCorifFgAHeRDTEXXfZaiuzJS;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public bool QVRHZmMsWpoXJRlMxTsDYRvqUKM;

					public bool PICEnAivGNBlCYqhkDjGZMVwzyho;

					public IList<Player> euwCgoFTlFHLOtAlVGQKXrmUOaJ;

					public int brmjsnskchOKnaubDCdOqqAgCEM;

					public ElementAssignmentConflictInfo uZZieFHBkfhqQbpzChbKIEmZWXj;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ElementAssignmentConflictInfo> fNsMBwprsbPOLrpQZUvcCKUHlpB;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						EeqaBmjOoMpzsFEAzEXNQWOkCVL eeqaBmjOoMpzsFEAzEXNQWOkCVL;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							eeqaBmjOoMpzsFEAzEXNQWOkCVL = this;
						}
						else
						{
							eeqaBmjOoMpzsFEAzEXNQWOkCVL = new EeqaBmjOoMpzsFEAzEXNQWOkCVL(0);
							eeqaBmjOoMpzsFEAzEXNQWOkCVL.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						eeqaBmjOoMpzsFEAzEXNQWOkCVL.KcihJPqCzQKLaiJAuOEZocqkGuT = AfYqsSbNrMWaNGJMccPnIBWOrubS;
						eeqaBmjOoMpzsFEAzEXNQWOkCVL.wtKbEuOgpmCyodusgKCfdeRTDQVb = vwsWqbAxZchMsrPtAyVDSdLCrYZ;
						eeqaBmjOoMpzsFEAzEXNQWOkCVL.VJzhVlrBOcGBCCFZprAmLnYqptl = QAgyYUmecnNCVLpzuecMsGLCdJP;
						eeqaBmjOoMpzsFEAzEXNQWOkCVL.JDEKtLtSnUsjrIbhVeZfySvvFnT = NkBrCorifFgAHeRDTEXXfZaiuzJS;
						eeqaBmjOoMpzsFEAzEXNQWOkCVL.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						eeqaBmjOoMpzsFEAzEXNQWOkCVL.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						eeqaBmjOoMpzsFEAzEXNQWOkCVL.QVRHZmMsWpoXJRlMxTsDYRvqUKM = PICEnAivGNBlCYqhkDjGZMVwzyho;
						return eeqaBmjOoMpzsFEAzEXNQWOkCVL;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (KcihJPqCzQKLaiJAuOEZocqkGuT < 0 || JDEKtLtSnUsjrIbhVeZfySvvFnT == null)
								{
									break;
								}
								euwCgoFTlFHLOtAlVGQKXrmUOaJ = (QVRHZmMsWpoXJRlMxTsDYRvqUKM ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
								brmjsnskchOKnaubDCdOqqAgCEM = 0;
								goto IL_010f;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00ee;
								}
								IL_010f:
								if (brmjsnskchOKnaubDCdOqqAgCEM >= euwCgoFTlFHLOtAlVGQKXrmUOaJ.Count)
								{
									break;
								}
								fNsMBwprsbPOLrpQZUvcCKUHlpB = euwCgoFTlFHLOtAlVGQKXrmUOaJ[brmjsnskchOKnaubDCdOqqAgCEM].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, wtKbEuOgpmCyodusgKCfdeRTDQVb, VJzhVlrBOcGBCCFZprAmLnYqptl, JDEKtLtSnUsjrIbhVeZfySvvFnT, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri).GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00ee;
								IL_00ee:
								if (fNsMBwprsbPOLrpQZUvcCKUHlpB.MoveNext())
								{
									uZZieFHBkfhqQbpzChbKIEmZWXj = fNsMBwprsbPOLrpQZUvcCKUHlpB.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = uZZieFHBkfhqQbpzChbKIEmZWXj;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								hcyXPKJSAQwXulAnRtenCFvlrIO();
								brmjsnskchOKnaubDCdOqqAgCEM++;
								goto IL_010f;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								hcyXPKJSAQwXulAnRtenCFvlrIO();
							}
						}
					}

					[DebuggerHidden]
					public EeqaBmjOoMpzsFEAzEXNQWOkCVL(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void hcyXPKJSAQwXulAnRtenCFvlrIO()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (fNsMBwprsbPOLrpQZUvcCKUHlpB != null)
						{
							fNsMBwprsbPOLrpQZUvcCKUHlpB.Dispose();
						}
					}
				}

				private sealed class lLycckjjDWAyCtBTCDcvDdNgYWkf : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ElementAssignmentConflictCheck CNxRWxtJdpKgAXgEBkMvLnqPffs;

					public ElementAssignmentConflictCheck VliyeXpMEMSvNHleVqLftHsOCYq;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public bool QVRHZmMsWpoXJRlMxTsDYRvqUKM;

					public bool PICEnAivGNBlCYqhkDjGZMVwzyho;

					public IList<Player> avdaakojJTklrswTJrykzJseoSe;

					public int KHGVsdeJOziiJEuebWtkbDcdGVP;

					public ElementAssignmentConflictInfo wkZPYyqNkEYzSGLcXSjXmpfrLVY;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ElementAssignmentConflictInfo> TDDRZfXlXaEsoUWFawHFbpcalMi;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						lLycckjjDWAyCtBTCDcvDdNgYWkf lLycckjjDWAyCtBTCDcvDdNgYWkf2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							lLycckjjDWAyCtBTCDcvDdNgYWkf2 = this;
						}
						else
						{
							lLycckjjDWAyCtBTCDcvDdNgYWkf2 = new lLycckjjDWAyCtBTCDcvDdNgYWkf(0);
							lLycckjjDWAyCtBTCDcvDdNgYWkf2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						lLycckjjDWAyCtBTCDcvDdNgYWkf2.CNxRWxtJdpKgAXgEBkMvLnqPffs = VliyeXpMEMSvNHleVqLftHsOCYq;
						lLycckjjDWAyCtBTCDcvDdNgYWkf2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						lLycckjjDWAyCtBTCDcvDdNgYWkf2.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						lLycckjjDWAyCtBTCDcvDdNgYWkf2.QVRHZmMsWpoXJRlMxTsDYRvqUKM = PICEnAivGNBlCYqhkDjGZMVwzyho;
						return lLycckjjDWAyCtBTCDcvDdNgYWkf2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (CNxRWxtJdpKgAXgEBkMvLnqPffs.playerId < 0 || CNxRWxtJdpKgAXgEBkMvLnqPffs.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								avdaakojJTklrswTJrykzJseoSe = (QVRHZmMsWpoXJRlMxTsDYRvqUKM ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
								KHGVsdeJOziiJEuebWtkbDcdGVP = 0;
								goto IL_010d;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00ec;
								}
								IL_010d:
								if (KHGVsdeJOziiJEuebWtkbDcdGVP >= avdaakojJTklrswTJrykzJseoSe.Count)
								{
									break;
								}
								TDDRZfXlXaEsoUWFawHFbpcalMi = avdaakojJTklrswTJrykzJseoSe[KHGVsdeJOziiJEuebWtkbDcdGVP].controllers.conflictChecking.ElementAssignmentConflicts(CNxRWxtJdpKgAXgEBkMvLnqPffs, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri).GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00ec;
								IL_00ec:
								if (TDDRZfXlXaEsoUWFawHFbpcalMi.MoveNext())
								{
									wkZPYyqNkEYzSGLcXSjXmpfrLVY = TDDRZfXlXaEsoUWFawHFbpcalMi.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = wkZPYyqNkEYzSGLcXSjXmpfrLVY;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								ligdUUAUcShHSZNaZDazjcxIBMz();
								KHGVsdeJOziiJEuebWtkbDcdGVP++;
								goto IL_010d;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								ligdUUAUcShHSZNaZDazjcxIBMz();
							}
						}
					}

					[DebuggerHidden]
					public lLycckjjDWAyCtBTCDcvDdNgYWkf(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void ligdUUAUcShHSZNaZDazjcxIBMz()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (TDDRZfXlXaEsoUWFawHFbpcalMi != null)
						{
							TDDRZfXlXaEsoUWFawHFbpcalMi.Dispose();
						}
					}
				}

				private sealed class EkmtDyortCsgnxcuJpycaGnhhnu : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public int KcihJPqCzQKLaiJAuOEZocqkGuT;

					public int AfYqsSbNrMWaNGJMccPnIBWOrubS;

					public KeyboardMap tgOUNHgFwqmYUPHxkyGtjzCSxcH;

					public KeyboardMap mzZqheLFGeXBhuUqfEBCyCsYbGz;

					public ActionElementMap JDEKtLtSnUsjrIbhVeZfySvvFnT;

					public ActionElementMap NkBrCorifFgAHeRDTEXXfZaiuzJS;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public bool QVRHZmMsWpoXJRlMxTsDYRvqUKM;

					public bool PICEnAivGNBlCYqhkDjGZMVwzyho;

					public IList<Player> ogYGYEAljOCQYWDdDFExstKMERU;

					public int dDjVbqgDeXYoMZPItuDxFIuazcE;

					public ElementAssignmentConflictInfo GUwcxmtoXDcQKbHkXhfBDrJAWCTH;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ElementAssignmentConflictInfo> YzBeLFEAdrGouCOXCvJvhgipQevT;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						EkmtDyortCsgnxcuJpycaGnhhnu ekmtDyortCsgnxcuJpycaGnhhnu;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							ekmtDyortCsgnxcuJpycaGnhhnu = this;
						}
						else
						{
							ekmtDyortCsgnxcuJpycaGnhhnu = new EkmtDyortCsgnxcuJpycaGnhhnu(0);
							ekmtDyortCsgnxcuJpycaGnhhnu.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						ekmtDyortCsgnxcuJpycaGnhhnu.KcihJPqCzQKLaiJAuOEZocqkGuT = AfYqsSbNrMWaNGJMccPnIBWOrubS;
						ekmtDyortCsgnxcuJpycaGnhhnu.tgOUNHgFwqmYUPHxkyGtjzCSxcH = mzZqheLFGeXBhuUqfEBCyCsYbGz;
						ekmtDyortCsgnxcuJpycaGnhhnu.JDEKtLtSnUsjrIbhVeZfySvvFnT = NkBrCorifFgAHeRDTEXXfZaiuzJS;
						ekmtDyortCsgnxcuJpycaGnhhnu.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						ekmtDyortCsgnxcuJpycaGnhhnu.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						ekmtDyortCsgnxcuJpycaGnhhnu.QVRHZmMsWpoXJRlMxTsDYRvqUKM = PICEnAivGNBlCYqhkDjGZMVwzyho;
						return ekmtDyortCsgnxcuJpycaGnhhnu;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (KcihJPqCzQKLaiJAuOEZocqkGuT < 0 || JDEKtLtSnUsjrIbhVeZfySvvFnT == null)
								{
									break;
								}
								ogYGYEAljOCQYWDdDFExstKMERU = (QVRHZmMsWpoXJRlMxTsDYRvqUKM ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
								dDjVbqgDeXYoMZPItuDxFIuazcE = 0;
								goto IL_010a;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e9;
								}
								IL_010a:
								if (dDjVbqgDeXYoMZPItuDxFIuazcE >= ogYGYEAljOCQYWDdDFExstKMERU.Count)
								{
									break;
								}
								YzBeLFEAdrGouCOXCvJvhgipQevT = ogYGYEAljOCQYWDdDFExstKMERU[dDjVbqgDeXYoMZPItuDxFIuazcE].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, tgOUNHgFwqmYUPHxkyGtjzCSxcH, JDEKtLtSnUsjrIbhVeZfySvvFnT, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri).GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e9;
								IL_00e9:
								if (YzBeLFEAdrGouCOXCvJvhgipQevT.MoveNext())
								{
									GUwcxmtoXDcQKbHkXhfBDrJAWCTH = YzBeLFEAdrGouCOXCvJvhgipQevT.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = GUwcxmtoXDcQKbHkXhfBDrJAWCTH;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								JxUqBCXzdnwTdepacuHaNcNzOge();
								dDjVbqgDeXYoMZPItuDxFIuazcE++;
								goto IL_010a;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								JxUqBCXzdnwTdepacuHaNcNzOge();
							}
						}
					}

					[DebuggerHidden]
					public EkmtDyortCsgnxcuJpycaGnhhnu(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void JxUqBCXzdnwTdepacuHaNcNzOge()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (YzBeLFEAdrGouCOXCvJvhgipQevT != null)
						{
							YzBeLFEAdrGouCOXCvJvhgipQevT.Dispose();
						}
					}
				}

				private sealed class vbddktcyUVeJnxHQPyQoHhMhhdO : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ElementAssignmentConflictCheck CNxRWxtJdpKgAXgEBkMvLnqPffs;

					public ElementAssignmentConflictCheck VliyeXpMEMSvNHleVqLftHsOCYq;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public bool QVRHZmMsWpoXJRlMxTsDYRvqUKM;

					public bool PICEnAivGNBlCYqhkDjGZMVwzyho;

					public IList<Player> aDjPAQtovOaILxuVonolNhMjKLS;

					public int hMHAzyWsPbYzcbEjMstJPduaIAd;

					public ElementAssignmentConflictInfo mLItjfbkNBLUZrUNmtrKUleqhUb;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ElementAssignmentConflictInfo> NAhjMGdPRbRUZNQOekLdFEysuAlb;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						vbddktcyUVeJnxHQPyQoHhMhhdO vbddktcyUVeJnxHQPyQoHhMhhdO2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							vbddktcyUVeJnxHQPyQoHhMhhdO2 = this;
						}
						else
						{
							vbddktcyUVeJnxHQPyQoHhMhhdO2 = new vbddktcyUVeJnxHQPyQoHhMhhdO(0);
							vbddktcyUVeJnxHQPyQoHhMhhdO2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						vbddktcyUVeJnxHQPyQoHhMhhdO2.CNxRWxtJdpKgAXgEBkMvLnqPffs = VliyeXpMEMSvNHleVqLftHsOCYq;
						vbddktcyUVeJnxHQPyQoHhMhhdO2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						vbddktcyUVeJnxHQPyQoHhMhhdO2.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						vbddktcyUVeJnxHQPyQoHhMhhdO2.QVRHZmMsWpoXJRlMxTsDYRvqUKM = PICEnAivGNBlCYqhkDjGZMVwzyho;
						return vbddktcyUVeJnxHQPyQoHhMhhdO2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (CNxRWxtJdpKgAXgEBkMvLnqPffs.playerId < 0 || CNxRWxtJdpKgAXgEBkMvLnqPffs.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								aDjPAQtovOaILxuVonolNhMjKLS = (QVRHZmMsWpoXJRlMxTsDYRvqUKM ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
								hMHAzyWsPbYzcbEjMstJPduaIAd = 0;
								goto IL_010d;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00ec;
								}
								IL_010d:
								if (hMHAzyWsPbYzcbEjMstJPduaIAd >= aDjPAQtovOaILxuVonolNhMjKLS.Count)
								{
									break;
								}
								NAhjMGdPRbRUZNQOekLdFEysuAlb = aDjPAQtovOaILxuVonolNhMjKLS[hMHAzyWsPbYzcbEjMstJPduaIAd].controllers.conflictChecking.ElementAssignmentConflicts(CNxRWxtJdpKgAXgEBkMvLnqPffs, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri).GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00ec;
								IL_00ec:
								if (NAhjMGdPRbRUZNQOekLdFEysuAlb.MoveNext())
								{
									mLItjfbkNBLUZrUNmtrKUleqhUb = NAhjMGdPRbRUZNQOekLdFEysuAlb.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = mLItjfbkNBLUZrUNmtrKUleqhUb;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								CKemwdGFVHlRtlolUzMlQdQffuXc();
								hMHAzyWsPbYzcbEjMstJPduaIAd++;
								goto IL_010d;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								CKemwdGFVHlRtlolUzMlQdQffuXc();
							}
						}
					}

					[DebuggerHidden]
					public vbddktcyUVeJnxHQPyQoHhMhhdO(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void CKemwdGFVHlRtlolUzMlQdQffuXc()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (NAhjMGdPRbRUZNQOekLdFEysuAlb != null)
						{
							NAhjMGdPRbRUZNQOekLdFEysuAlb.Dispose();
						}
					}
				}

				private sealed class aMWYNylPFFuAbxsqIGKVFrTYoPL : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public int KcihJPqCzQKLaiJAuOEZocqkGuT;

					public int AfYqsSbNrMWaNGJMccPnIBWOrubS;

					public MouseMap tRkMnEyrnLZrEgiztlgVshhLbyG;

					public MouseMap VfEAnoFVTCdRqGLsFnJebgaHJmfC;

					public ActionElementMap JDEKtLtSnUsjrIbhVeZfySvvFnT;

					public ActionElementMap NkBrCorifFgAHeRDTEXXfZaiuzJS;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public bool QVRHZmMsWpoXJRlMxTsDYRvqUKM;

					public bool PICEnAivGNBlCYqhkDjGZMVwzyho;

					public IList<Player> KdPWEojvhZVoRJDgbBPRIHjEvnCl;

					public int mzZwoHBBvoKpHABOpiSCkCyLZtjh;

					public ElementAssignmentConflictInfo avmAZIFQGmEzhlkhlUUFFRIwJpx;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ElementAssignmentConflictInfo> dJtvseXtWZpmgAiIxMvphAfSLUP;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						aMWYNylPFFuAbxsqIGKVFrTYoPL aMWYNylPFFuAbxsqIGKVFrTYoPL2;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							aMWYNylPFFuAbxsqIGKVFrTYoPL2 = this;
						}
						else
						{
							aMWYNylPFFuAbxsqIGKVFrTYoPL2 = new aMWYNylPFFuAbxsqIGKVFrTYoPL(0);
							aMWYNylPFFuAbxsqIGKVFrTYoPL2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						aMWYNylPFFuAbxsqIGKVFrTYoPL2.KcihJPqCzQKLaiJAuOEZocqkGuT = AfYqsSbNrMWaNGJMccPnIBWOrubS;
						aMWYNylPFFuAbxsqIGKVFrTYoPL2.tRkMnEyrnLZrEgiztlgVshhLbyG = VfEAnoFVTCdRqGLsFnJebgaHJmfC;
						aMWYNylPFFuAbxsqIGKVFrTYoPL2.JDEKtLtSnUsjrIbhVeZfySvvFnT = NkBrCorifFgAHeRDTEXXfZaiuzJS;
						aMWYNylPFFuAbxsqIGKVFrTYoPL2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						aMWYNylPFFuAbxsqIGKVFrTYoPL2.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						aMWYNylPFFuAbxsqIGKVFrTYoPL2.QVRHZmMsWpoXJRlMxTsDYRvqUKM = PICEnAivGNBlCYqhkDjGZMVwzyho;
						return aMWYNylPFFuAbxsqIGKVFrTYoPL2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (KcihJPqCzQKLaiJAuOEZocqkGuT < 0 || JDEKtLtSnUsjrIbhVeZfySvvFnT == null)
								{
									break;
								}
								KdPWEojvhZVoRJDgbBPRIHjEvnCl = (QVRHZmMsWpoXJRlMxTsDYRvqUKM ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
								mzZwoHBBvoKpHABOpiSCkCyLZtjh = 0;
								goto IL_010a;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00e9;
								}
								IL_010a:
								if (mzZwoHBBvoKpHABOpiSCkCyLZtjh >= KdPWEojvhZVoRJDgbBPRIHjEvnCl.Count)
								{
									break;
								}
								dJtvseXtWZpmgAiIxMvphAfSLUP = KdPWEojvhZVoRJDgbBPRIHjEvnCl[mzZwoHBBvoKpHABOpiSCkCyLZtjh].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, tRkMnEyrnLZrEgiztlgVshhLbyG, JDEKtLtSnUsjrIbhVeZfySvvFnT, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri).GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00e9;
								IL_00e9:
								if (dJtvseXtWZpmgAiIxMvphAfSLUP.MoveNext())
								{
									avmAZIFQGmEzhlkhlUUFFRIwJpx = dJtvseXtWZpmgAiIxMvphAfSLUP.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = avmAZIFQGmEzhlkhlUUFFRIwJpx;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								dKdbqUWsTNfEUTqeEAtXDbBoQctd();
								mzZwoHBBvoKpHABOpiSCkCyLZtjh++;
								goto IL_010a;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								dKdbqUWsTNfEUTqeEAtXDbBoQctd();
							}
						}
					}

					[DebuggerHidden]
					public aMWYNylPFFuAbxsqIGKVFrTYoPL(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void dKdbqUWsTNfEUTqeEAtXDbBoQctd()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (dJtvseXtWZpmgAiIxMvphAfSLUP != null)
						{
							dJtvseXtWZpmgAiIxMvphAfSLUP.Dispose();
						}
					}
				}

				private sealed class HlMYypnSEbQVrVmoDMgxthzWNp : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ElementAssignmentConflictCheck CNxRWxtJdpKgAXgEBkMvLnqPffs;

					public ElementAssignmentConflictCheck VliyeXpMEMSvNHleVqLftHsOCYq;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public bool QVRHZmMsWpoXJRlMxTsDYRvqUKM;

					public bool PICEnAivGNBlCYqhkDjGZMVwzyho;

					public IList<Player> gDEFFGtHYuxUpIbgDJgILjEvIcnI;

					public int vAvoAfknPewkyagigUoIVoZrgBJe;

					public ElementAssignmentConflictInfo BzIXeAClKhpUkRvwmLSkfvhihAA;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ElementAssignmentConflictInfo> uFKmOVfzqFTMoIWmSLWmYwXlTly;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						HlMYypnSEbQVrVmoDMgxthzWNp hlMYypnSEbQVrVmoDMgxthzWNp;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							hlMYypnSEbQVrVmoDMgxthzWNp = this;
						}
						else
						{
							hlMYypnSEbQVrVmoDMgxthzWNp = new HlMYypnSEbQVrVmoDMgxthzWNp(0);
							hlMYypnSEbQVrVmoDMgxthzWNp.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						hlMYypnSEbQVrVmoDMgxthzWNp.CNxRWxtJdpKgAXgEBkMvLnqPffs = VliyeXpMEMSvNHleVqLftHsOCYq;
						hlMYypnSEbQVrVmoDMgxthzWNp.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						hlMYypnSEbQVrVmoDMgxthzWNp.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						hlMYypnSEbQVrVmoDMgxthzWNp.QVRHZmMsWpoXJRlMxTsDYRvqUKM = PICEnAivGNBlCYqhkDjGZMVwzyho;
						return hlMYypnSEbQVrVmoDMgxthzWNp;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (CNxRWxtJdpKgAXgEBkMvLnqPffs.playerId < 0 || CNxRWxtJdpKgAXgEBkMvLnqPffs.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								gDEFFGtHYuxUpIbgDJgILjEvIcnI = (QVRHZmMsWpoXJRlMxTsDYRvqUKM ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
								vAvoAfknPewkyagigUoIVoZrgBJe = 0;
								goto IL_010d;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00ec;
								}
								IL_010d:
								if (vAvoAfknPewkyagigUoIVoZrgBJe >= gDEFFGtHYuxUpIbgDJgILjEvIcnI.Count)
								{
									break;
								}
								uFKmOVfzqFTMoIWmSLWmYwXlTly = gDEFFGtHYuxUpIbgDJgILjEvIcnI[vAvoAfknPewkyagigUoIVoZrgBJe].controllers.conflictChecking.ElementAssignmentConflicts(CNxRWxtJdpKgAXgEBkMvLnqPffs, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri).GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00ec;
								IL_00ec:
								if (uFKmOVfzqFTMoIWmSLWmYwXlTly.MoveNext())
								{
									BzIXeAClKhpUkRvwmLSkfvhihAA = uFKmOVfzqFTMoIWmSLWmYwXlTly.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = BzIXeAClKhpUkRvwmLSkfvhihAA;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								jBnPWQJtTNISRdZbiGIhmSBekMf();
								vAvoAfknPewkyagigUoIVoZrgBJe++;
								goto IL_010d;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								jBnPWQJtTNISRdZbiGIhmSBekMf();
							}
						}
					}

					[DebuggerHidden]
					public HlMYypnSEbQVrVmoDMgxthzWNp(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void jBnPWQJtTNISRdZbiGIhmSBekMf()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (uFKmOVfzqFTMoIWmSLWmYwXlTly != null)
						{
							uFKmOVfzqFTMoIWmSLWmYwXlTly.Dispose();
						}
					}
				}

				private sealed class JeKoJBODkDEAvYpvWudhXmIntJA : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public int KcihJPqCzQKLaiJAuOEZocqkGuT;

					public int AfYqsSbNrMWaNGJMccPnIBWOrubS;

					public int wtKbEuOgpmCyodusgKCfdeRTDQVb;

					public int vwsWqbAxZchMsrPtAyVDSdLCrYZ;

					public CustomControllerMap VxhXRlirnaUoFJNezjXbylAnbCh;

					public CustomControllerMap cZWuOBOpCJthSgelvekCWzFQsfH;

					public ActionElementMap JDEKtLtSnUsjrIbhVeZfySvvFnT;

					public ActionElementMap NkBrCorifFgAHeRDTEXXfZaiuzJS;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public bool QVRHZmMsWpoXJRlMxTsDYRvqUKM;

					public bool PICEnAivGNBlCYqhkDjGZMVwzyho;

					public IList<Player> BUecNiFqkKFqWlCOcmrqRHrwQNl;

					public int dWxUcLnnEtJLeqxIxqaWcZwpmNy;

					public ElementAssignmentConflictInfo jLbbQDHfUCPBItlFlDmciHvdeOwY;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ElementAssignmentConflictInfo> JzsAYNduuxHMRQGoJpIAApSYdbEU;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						JeKoJBODkDEAvYpvWudhXmIntJA jeKoJBODkDEAvYpvWudhXmIntJA;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							jeKoJBODkDEAvYpvWudhXmIntJA = this;
						}
						else
						{
							jeKoJBODkDEAvYpvWudhXmIntJA = new JeKoJBODkDEAvYpvWudhXmIntJA(0);
							jeKoJBODkDEAvYpvWudhXmIntJA.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						jeKoJBODkDEAvYpvWudhXmIntJA.KcihJPqCzQKLaiJAuOEZocqkGuT = AfYqsSbNrMWaNGJMccPnIBWOrubS;
						jeKoJBODkDEAvYpvWudhXmIntJA.wtKbEuOgpmCyodusgKCfdeRTDQVb = vwsWqbAxZchMsrPtAyVDSdLCrYZ;
						jeKoJBODkDEAvYpvWudhXmIntJA.VxhXRlirnaUoFJNezjXbylAnbCh = cZWuOBOpCJthSgelvekCWzFQsfH;
						jeKoJBODkDEAvYpvWudhXmIntJA.JDEKtLtSnUsjrIbhVeZfySvvFnT = NkBrCorifFgAHeRDTEXXfZaiuzJS;
						jeKoJBODkDEAvYpvWudhXmIntJA.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						jeKoJBODkDEAvYpvWudhXmIntJA.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						jeKoJBODkDEAvYpvWudhXmIntJA.QVRHZmMsWpoXJRlMxTsDYRvqUKM = PICEnAivGNBlCYqhkDjGZMVwzyho;
						return jeKoJBODkDEAvYpvWudhXmIntJA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (KcihJPqCzQKLaiJAuOEZocqkGuT < 0 || JDEKtLtSnUsjrIbhVeZfySvvFnT == null)
								{
									break;
								}
								BUecNiFqkKFqWlCOcmrqRHrwQNl = (QVRHZmMsWpoXJRlMxTsDYRvqUKM ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
								dWxUcLnnEtJLeqxIxqaWcZwpmNy = 0;
								goto IL_0110;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00ef;
								}
								IL_0110:
								if (dWxUcLnnEtJLeqxIxqaWcZwpmNy >= BUecNiFqkKFqWlCOcmrqRHrwQNl.Count)
								{
									break;
								}
								JzsAYNduuxHMRQGoJpIAApSYdbEU = BUecNiFqkKFqWlCOcmrqRHrwQNl[dWxUcLnnEtJLeqxIxqaWcZwpmNy].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, wtKbEuOgpmCyodusgKCfdeRTDQVb, VxhXRlirnaUoFJNezjXbylAnbCh, JDEKtLtSnUsjrIbhVeZfySvvFnT, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri).GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00ef;
								IL_00ef:
								if (JzsAYNduuxHMRQGoJpIAApSYdbEU.MoveNext())
								{
									jLbbQDHfUCPBItlFlDmciHvdeOwY = JzsAYNduuxHMRQGoJpIAApSYdbEU.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = jLbbQDHfUCPBItlFlDmciHvdeOwY;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								EnYgzXVZdwjohfZsxdfvJBWtgmQf();
								dWxUcLnnEtJLeqxIxqaWcZwpmNy++;
								goto IL_0110;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								EnYgzXVZdwjohfZsxdfvJBWtgmQf();
							}
						}
					}

					[DebuggerHidden]
					public JeKoJBODkDEAvYpvWudhXmIntJA(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void EnYgzXVZdwjohfZsxdfvJBWtgmQf()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (JzsAYNduuxHMRQGoJpIAApSYdbEU != null)
						{
							JzsAYNduuxHMRQGoJpIAApSYdbEU.Dispose();
						}
					}
				}

				private sealed class MRRmlwnbKoBFjDwIXJkJgcEBkIJL : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

					private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

					private int dFCUHNznYmJZjnnffQJUVAprSDy;

					public ElementAssignmentConflictCheck CNxRWxtJdpKgAXgEBkMvLnqPffs;

					public ElementAssignmentConflictCheck VliyeXpMEMSvNHleVqLftHsOCYq;

					public bool IftNYOsoyZKKlecDyJEriHNLMeG;

					public bool TGDalxAGxtEWicADkzmraNyMfPny;

					public bool uutDYsXUWncZDaAJTeaAWthFzri;

					public bool HmXfeIizRcPIeSaeglGADvomlCL;

					public bool QVRHZmMsWpoXJRlMxTsDYRvqUKM;

					public bool PICEnAivGNBlCYqhkDjGZMVwzyho;

					public IList<Player> QXBpAIClYYeBacyhIVEEWJkdMiX;

					public int DCugLgCdnpCaXqFUiFWkltYsPNbP;

					public ElementAssignmentConflictInfo DLeQKWlHocwYCPBousvREekIDdf;

					public ConflictCheckingHelper GxphHAMqMhNBLjnlhXuBQmXaALiE;

					public IEnumerator<ElementAssignmentConflictInfo> XilWEHtQggwsSsGVqmcqdHzLCqa;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return WCNlIsEdYuVTqbNYvICUPcTebLU;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						MRRmlwnbKoBFjDwIXJkJgcEBkIJL mRRmlwnbKoBFjDwIXJkJgcEBkIJL;
						if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
							mRRmlwnbKoBFjDwIXJkJgcEBkIJL = this;
						}
						else
						{
							mRRmlwnbKoBFjDwIXJkJgcEBkIJL = new MRRmlwnbKoBFjDwIXJkJgcEBkIJL(0);
							mRRmlwnbKoBFjDwIXJkJgcEBkIJL.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
						}
						mRRmlwnbKoBFjDwIXJkJgcEBkIJL.CNxRWxtJdpKgAXgEBkMvLnqPffs = VliyeXpMEMSvNHleVqLftHsOCYq;
						mRRmlwnbKoBFjDwIXJkJgcEBkIJL.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
						mRRmlwnbKoBFjDwIXJkJgcEBkIJL.uutDYsXUWncZDaAJTeaAWthFzri = HmXfeIizRcPIeSaeglGADvomlCL;
						mRRmlwnbKoBFjDwIXJkJgcEBkIJL.QVRHZmMsWpoXJRlMxTsDYRvqUKM = PICEnAivGNBlCYqhkDjGZMVwzyho;
						return mRRmlwnbKoBFjDwIXJkJgcEBkIJL;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}

					private bool MoveNext()
					{
						try
						{
							switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
							{
							case 0:
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
								if (CNxRWxtJdpKgAXgEBkMvLnqPffs.playerId < 0 || CNxRWxtJdpKgAXgEBkMvLnqPffs.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								QXBpAIClYYeBacyhIVEEWJkdMiX = (QVRHZmMsWpoXJRlMxTsDYRvqUKM ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
								DCugLgCdnpCaXqFUiFWkltYsPNbP = 0;
								goto IL_010d;
							case 2:
								{
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
									goto IL_00ec;
								}
								IL_010d:
								if (DCugLgCdnpCaXqFUiFWkltYsPNbP >= QXBpAIClYYeBacyhIVEEWJkdMiX.Count)
								{
									break;
								}
								XilWEHtQggwsSsGVqmcqdHzLCqa = QXBpAIClYYeBacyhIVEEWJkdMiX[DCugLgCdnpCaXqFUiFWkltYsPNbP].controllers.conflictChecking.ElementAssignmentConflicts(CNxRWxtJdpKgAXgEBkMvLnqPffs, IftNYOsoyZKKlecDyJEriHNLMeG, uutDYsXUWncZDaAJTeaAWthFzri).GetEnumerator();
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
								goto IL_00ec;
								IL_00ec:
								if (XilWEHtQggwsSsGVqmcqdHzLCqa.MoveNext())
								{
									DLeQKWlHocwYCPBousvREekIDdf = XilWEHtQggwsSsGVqmcqdHzLCqa.Current;
									WCNlIsEdYuVTqbNYvICUPcTebLU = DLeQKWlHocwYCPBousvREekIDdf;
									SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
									return true;
								}
								wtQmRSnSdyUWadkvqMFtYSwXaap();
								DCugLgCdnpCaXqFUiFWkltYsPNbP++;
								goto IL_010d;
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

					[DebuggerHidden]
					void IEnumerator.Reset()
					{
						throw new NotSupportedException();
					}

					void IDisposable.Dispose()
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								wtQmRSnSdyUWadkvqMFtYSwXaap();
							}
						}
					}

					[DebuggerHidden]
					public MRRmlwnbKoBFjDwIXJkJgcEBkIJL(int _003C_003E1__state)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
						dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
					}

					private void wtQmRSnSdyUWadkvqMFtYSwXaap()
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (XilWEHtQggwsSsGVqmcqdHzLCqa != null)
						{
							XilWEHtQggwsSsGVqmcqdHzLCqa.Dispose();
						}
					}
				}

				private static ConflictCheckingHelper SKcIgrdHSZRiIzfxUyDOqjyMnCX;

				internal static ConflictCheckingHelper Instance => SKcIgrdHSZRiIzfxUyDOqjyMnCX ?? (SKcIgrdHSZRiIzfxUyDOqjyMnCX = new ConflictCheckingHelper());

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
					IList<Player> list = (includeSystemPlayer ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
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
								Player player3 = list[n];
								if (player3.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, maps2[m], skipDisabledMaps, forceCheckAllCategories))
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
								Player player4 = list[num3];
								if (player4.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, maps3[num2], skipDisabledMaps, forceCheckAllCategories))
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
								Player player5 = list[num5];
								for (int num6 = 0; num6 < count3; num6++)
								{
									if (player5.controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, customController.id, maps4[num6], skipDisabledMaps, forceCheckAllCategories))
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
						ControllerType.Joystick => zhujiPtyKIUjoJCDAQdnKNLUPlG(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => OeUBbydtpfOEUXnYjUawdpyeLgY(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => WOrwUiciyJarkTlBnIeByaWUJVp(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => vcZSgcvWFniPEnEIAHADcJQUMHp(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return zhujiPtyKIUjoJCDAQdnKNLUPlG(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return OeUBbydtpfOEUXnYjUawdpyeLgY(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return WOrwUiciyJarkTlBnIeByaWUJVp(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return vcZSgcvWFniPEnEIAHADcJQUMHp(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool zhujiPtyKIUjoJCDAQdnKNLUPlG(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool zhujiPtyKIUjoJCDAQdnKNLUPlG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool OeUBbydtpfOEUXnYjUawdpyeLgY(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool OeUBbydtpfOEUXnYjUawdpyeLgY(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool WOrwUiciyJarkTlBnIeByaWUJVp(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool WOrwUiciyJarkTlBnIeByaWUJVp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool vcZSgcvWFniPEnEIAHADcJQUMHp(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool vcZSgcvWFniPEnEIAHADcJQUMHp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
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
						ControllerType.Joystick => imEfSDkTIsHIrdjAsQkcBtRagVfm(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => ThxRjdhbdGwOScyNlVNcNNEabZk(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => gmNpsZOqpLCaFvPmdoNPCGBdyub(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => XJBGBuwJZJlkBVsljPjUrsJRvfS(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return imEfSDkTIsHIrdjAsQkcBtRagVfm(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ThxRjdhbdGwOScyNlVNcNNEabZk(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return gmNpsZOqpLCaFvPmdoNPCGBdyub(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return XJBGBuwJZJlkBVsljPjUrsJRvfS(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private IEnumerable<ElementAssignmentConflictInfo> imEfSDkTIsHIrdjAsQkcBtRagVfm(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					EeqaBmjOoMpzsFEAzEXNQWOkCVL eeqaBmjOoMpzsFEAzEXNQWOkCVL = new EeqaBmjOoMpzsFEAzEXNQWOkCVL(-2);
					eeqaBmjOoMpzsFEAzEXNQWOkCVL.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					eeqaBmjOoMpzsFEAzEXNQWOkCVL.AfYqsSbNrMWaNGJMccPnIBWOrubS = P_0;
					eeqaBmjOoMpzsFEAzEXNQWOkCVL.vwsWqbAxZchMsrPtAyVDSdLCrYZ = P_1;
					eeqaBmjOoMpzsFEAzEXNQWOkCVL.QAgyYUmecnNCVLpzuecMsGLCdJP = P_2;
					eeqaBmjOoMpzsFEAzEXNQWOkCVL.NkBrCorifFgAHeRDTEXXfZaiuzJS = P_3;
					eeqaBmjOoMpzsFEAzEXNQWOkCVL.TGDalxAGxtEWicADkzmraNyMfPny = P_4;
					eeqaBmjOoMpzsFEAzEXNQWOkCVL.HmXfeIizRcPIeSaeglGADvomlCL = P_5;
					eeqaBmjOoMpzsFEAzEXNQWOkCVL.PICEnAivGNBlCYqhkDjGZMVwzyho = P_6;
					return eeqaBmjOoMpzsFEAzEXNQWOkCVL;
				}

				private IEnumerable<ElementAssignmentConflictInfo> imEfSDkTIsHIrdjAsQkcBtRagVfm(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					lLycckjjDWAyCtBTCDcvDdNgYWkf lLycckjjDWAyCtBTCDcvDdNgYWkf2 = new lLycckjjDWAyCtBTCDcvDdNgYWkf(-2);
					lLycckjjDWAyCtBTCDcvDdNgYWkf2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					lLycckjjDWAyCtBTCDcvDdNgYWkf2.VliyeXpMEMSvNHleVqLftHsOCYq = P_0;
					lLycckjjDWAyCtBTCDcvDdNgYWkf2.TGDalxAGxtEWicADkzmraNyMfPny = P_1;
					lLycckjjDWAyCtBTCDcvDdNgYWkf2.HmXfeIizRcPIeSaeglGADvomlCL = P_2;
					lLycckjjDWAyCtBTCDcvDdNgYWkf2.PICEnAivGNBlCYqhkDjGZMVwzyho = P_3;
					return lLycckjjDWAyCtBTCDcvDdNgYWkf2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> ThxRjdhbdGwOScyNlVNcNNEabZk(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					EkmtDyortCsgnxcuJpycaGnhhnu ekmtDyortCsgnxcuJpycaGnhhnu = new EkmtDyortCsgnxcuJpycaGnhhnu(-2);
					ekmtDyortCsgnxcuJpycaGnhhnu.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					ekmtDyortCsgnxcuJpycaGnhhnu.AfYqsSbNrMWaNGJMccPnIBWOrubS = P_0;
					ekmtDyortCsgnxcuJpycaGnhhnu.mzZqheLFGeXBhuUqfEBCyCsYbGz = P_1;
					ekmtDyortCsgnxcuJpycaGnhhnu.NkBrCorifFgAHeRDTEXXfZaiuzJS = P_2;
					ekmtDyortCsgnxcuJpycaGnhhnu.TGDalxAGxtEWicADkzmraNyMfPny = P_3;
					ekmtDyortCsgnxcuJpycaGnhhnu.HmXfeIizRcPIeSaeglGADvomlCL = P_4;
					ekmtDyortCsgnxcuJpycaGnhhnu.PICEnAivGNBlCYqhkDjGZMVwzyho = P_5;
					return ekmtDyortCsgnxcuJpycaGnhhnu;
				}

				private IEnumerable<ElementAssignmentConflictInfo> ThxRjdhbdGwOScyNlVNcNNEabZk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					vbddktcyUVeJnxHQPyQoHhMhhdO vbddktcyUVeJnxHQPyQoHhMhhdO2 = new vbddktcyUVeJnxHQPyQoHhMhhdO(-2);
					vbddktcyUVeJnxHQPyQoHhMhhdO2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					vbddktcyUVeJnxHQPyQoHhMhhdO2.VliyeXpMEMSvNHleVqLftHsOCYq = P_0;
					vbddktcyUVeJnxHQPyQoHhMhhdO2.TGDalxAGxtEWicADkzmraNyMfPny = P_1;
					vbddktcyUVeJnxHQPyQoHhMhhdO2.HmXfeIizRcPIeSaeglGADvomlCL = P_2;
					vbddktcyUVeJnxHQPyQoHhMhhdO2.PICEnAivGNBlCYqhkDjGZMVwzyho = P_3;
					return vbddktcyUVeJnxHQPyQoHhMhhdO2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> gmNpsZOqpLCaFvPmdoNPCGBdyub(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					aMWYNylPFFuAbxsqIGKVFrTYoPL aMWYNylPFFuAbxsqIGKVFrTYoPL2 = new aMWYNylPFFuAbxsqIGKVFrTYoPL(-2);
					aMWYNylPFFuAbxsqIGKVFrTYoPL2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					aMWYNylPFFuAbxsqIGKVFrTYoPL2.AfYqsSbNrMWaNGJMccPnIBWOrubS = P_0;
					aMWYNylPFFuAbxsqIGKVFrTYoPL2.VfEAnoFVTCdRqGLsFnJebgaHJmfC = P_1;
					aMWYNylPFFuAbxsqIGKVFrTYoPL2.NkBrCorifFgAHeRDTEXXfZaiuzJS = P_2;
					aMWYNylPFFuAbxsqIGKVFrTYoPL2.TGDalxAGxtEWicADkzmraNyMfPny = P_3;
					aMWYNylPFFuAbxsqIGKVFrTYoPL2.HmXfeIizRcPIeSaeglGADvomlCL = P_4;
					aMWYNylPFFuAbxsqIGKVFrTYoPL2.PICEnAivGNBlCYqhkDjGZMVwzyho = P_5;
					return aMWYNylPFFuAbxsqIGKVFrTYoPL2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> gmNpsZOqpLCaFvPmdoNPCGBdyub(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					HlMYypnSEbQVrVmoDMgxthzWNp hlMYypnSEbQVrVmoDMgxthzWNp = new HlMYypnSEbQVrVmoDMgxthzWNp(-2);
					hlMYypnSEbQVrVmoDMgxthzWNp.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					hlMYypnSEbQVrVmoDMgxthzWNp.VliyeXpMEMSvNHleVqLftHsOCYq = P_0;
					hlMYypnSEbQVrVmoDMgxthzWNp.TGDalxAGxtEWicADkzmraNyMfPny = P_1;
					hlMYypnSEbQVrVmoDMgxthzWNp.HmXfeIizRcPIeSaeglGADvomlCL = P_2;
					hlMYypnSEbQVrVmoDMgxthzWNp.PICEnAivGNBlCYqhkDjGZMVwzyho = P_3;
					return hlMYypnSEbQVrVmoDMgxthzWNp;
				}

				private IEnumerable<ElementAssignmentConflictInfo> XJBGBuwJZJlkBVsljPjUrsJRvfS(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					JeKoJBODkDEAvYpvWudhXmIntJA jeKoJBODkDEAvYpvWudhXmIntJA = new JeKoJBODkDEAvYpvWudhXmIntJA(-2);
					jeKoJBODkDEAvYpvWudhXmIntJA.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					jeKoJBODkDEAvYpvWudhXmIntJA.AfYqsSbNrMWaNGJMccPnIBWOrubS = P_0;
					jeKoJBODkDEAvYpvWudhXmIntJA.vwsWqbAxZchMsrPtAyVDSdLCrYZ = P_1;
					jeKoJBODkDEAvYpvWudhXmIntJA.cZWuOBOpCJthSgelvekCWzFQsfH = P_2;
					jeKoJBODkDEAvYpvWudhXmIntJA.NkBrCorifFgAHeRDTEXXfZaiuzJS = P_3;
					jeKoJBODkDEAvYpvWudhXmIntJA.TGDalxAGxtEWicADkzmraNyMfPny = P_4;
					jeKoJBODkDEAvYpvWudhXmIntJA.HmXfeIizRcPIeSaeglGADvomlCL = P_5;
					jeKoJBODkDEAvYpvWudhXmIntJA.PICEnAivGNBlCYqhkDjGZMVwzyho = P_6;
					return jeKoJBODkDEAvYpvWudhXmIntJA;
				}

				private IEnumerable<ElementAssignmentConflictInfo> XJBGBuwJZJlkBVsljPjUrsJRvfS(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					MRRmlwnbKoBFjDwIXJkJgcEBkIJL mRRmlwnbKoBFjDwIXJkJgcEBkIJL = new MRRmlwnbKoBFjDwIXJkJgcEBkIJL(-2);
					mRRmlwnbKoBFjDwIXJkJgcEBkIJL.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
					mRRmlwnbKoBFjDwIXJkJgcEBkIJL.VliyeXpMEMSvNHleVqLftHsOCYq = P_0;
					mRRmlwnbKoBFjDwIXJkJgcEBkIJL.TGDalxAGxtEWicADkzmraNyMfPny = P_1;
					mRRmlwnbKoBFjDwIXJkJgcEBkIJL.HmXfeIizRcPIeSaeglGADvomlCL = P_2;
					mRRmlwnbKoBFjDwIXJkJgcEBkIJL.PICEnAivGNBlCYqhkDjGZMVwzyho = P_3;
					return mRRmlwnbKoBFjDwIXJkJgcEBkIJL;
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
						ControllerType.Joystick => DLIMZofEHfKMVzGoYPfxNoBGWcU(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => erFMILoUPJnXxMYLEOrnNomHvks(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => QCvuesJWWfHNnEKFAzDYjoBeahQk(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => AvCaXpbgoguTJtawZMHGCOLuGFcO(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return DLIMZofEHfKMVzGoYPfxNoBGWcU(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return erFMILoUPJnXxMYLEOrnNomHvks(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return QCvuesJWWfHNnEKFAzDYjoBeahQk(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return AvCaXpbgoguTJtawZMHGCOLuGFcO(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int DLIMZofEHfKMVzGoYPfxNoBGWcU(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int DLIMZofEHfKMVzGoYPfxNoBGWcU(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int erFMILoUPJnXxMYLEOrnNomHvks(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int erFMILoUPJnXxMYLEOrnNomHvks(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int QCvuesJWWfHNnEKFAzDYjoBeahQk(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int QCvuesJWWfHNnEKFAzDYjoBeahQk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int AvCaXpbgoguTJtawZMHGCOLuGFcO(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int AvCaXpbgoguTJtawZMHGCOLuGFcO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
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
						ControllerType.Joystick => jNFRBfgbfyiqxfrUufoAeQcqEIC(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => ezLAEUGBATCEUqTUGfseNvMiBHpH(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => TBPAicmNmEBkNlZBZjQKpZeTSlA(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => YPzgJpJeGVyhUpFDrUjfNGIIDRxE(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return jNFRBfgbfyiqxfrUufoAeQcqEIC(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ezLAEUGBATCEUqTUGfseNvMiBHpH(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return TBPAicmNmEBkNlZBZjQKpZeTSlA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return YPzgJpJeGVyhUpFDrUjfNGIIDRxE(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int jNFRBfgbfyiqxfrUufoAeQcqEIC(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int jNFRBfgbfyiqxfrUufoAeQcqEIC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int ezLAEUGBATCEUqTUGfseNvMiBHpH(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int ezLAEUGBATCEUqTUGfseNvMiBHpH(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int TBPAicmNmEBkNlZBZjQKpZeTSlA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int TBPAicmNmEBkNlZBZjQKpZeTSlA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int YPzgJpJeGVyhUpFDrUjfNGIIDRxE(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int YPzgJpJeGVyhUpFDrUjfNGIIDRxE(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly : yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper SKcIgrdHSZRiIzfxUyDOqjyMnCX;

			public readonly PollingHelper polling = PollingHelper.Instance;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.Instance;

			internal static ControllerHelper Instance => SKcIgrdHSZRiIzfxUyDOqjyMnCX ?? (SKcIgrdHSZRiIzfxUyDOqjyMnCX = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.controllerCount;
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
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.Controllers;
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
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.Mouse;
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
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.Keyboard;
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
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.joystickCount;
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
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly;
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
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.customControllerCount;
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
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.CustomControllers_readOnly;
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
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.Keyboard as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return AkpZeTvTvDWYnEqWDyDWrcufUCI.Mouse as T;
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
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.ZqzzcVLLrMBIUyLpDAZiOGBIopG(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.ZqzzcVLLrMBIUyLpDAZiOGBIopG(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.kWDKDubSsTrSPPczHPBLAqrNgtB(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.BzUXJxDpeyaJzhOFTHxpLxSrdcM(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.GVznlLdqRgXcMHaCvcVsieBcNlQA(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.GVznlLdqRgXcMHaCvcVsieBcNlQA(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.pOoMiyOTIOHNVgqnXlxSqnnXwRw(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yIRdWijqyghmemPssevxkoxocsUE.IugDVSYkDFZiUqhwVGiwiTPVCdw(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yIRdWijqyghmemPssevxkoxocsUE.IugDVSYkDFZiUqhwVGiwiTPVCdw(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.zCynXQNrFypPOHsukRvftnVVvxv(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.WLxWQIGswHpTuGoGagfoNGpkNUi();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.lzUTlfxjIWCAxVpPYtNqRBHwRnF();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.aiTSSOKxTWlWSUxnTlgSBQYSFDb(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.aiTSSOKxTWlWSUxnTlgSBQYSFDb(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.KhsagjbQMXqLFdZRydktrWoNjob(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yIRdWijqyghmemPssevxkoxocsUE.MusrlwucDobbeEOklRAYNPplLBQz(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yIRdWijqyghmemPssevxkoxocsUE.MusrlwucDobbeEOklRAYNPplLBQz(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!rVpUCROuewHidvpkltGSoFPvVaG)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				cAcFqpExkaBiRPPGiHGBvxiIbSLP();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (unityInputBuffer.ibpwVFivgGFEGRkTwYpHtsrUEAK(i, j))
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
				if (!rVpUCROuewHidvpkltGSoFPvVaG)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				cAcFqpExkaBiRPPGiHGBvxiIbSLP();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (unityInputBuffer.ibpwVFivgGFEGRkTwYpHtsrUEAK(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (unityInputBuffer.EjHXQfThgAaacaDTMKLFRbbIClzK(i, k, positiveAxesOnly))
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
					if (!rVpUCROuewHidvpkltGSoFPvVaG)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						XZkCtazuKqRFXBDaYdGEgUNVjfjj.SetUnityJoystickId(joystickId, unityJoystickId);
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
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.XLOkGOGTJTTMgVorWpHofbbxLFg(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.aeriZUDCjjOFEjImDxUcfHiKMmjO();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.ojdLCTeIELScFPQxRSuPvWDcmqi();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.htlintTFWqroATMLzSJxYDxgpFt(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.htlintTFWqroATMLzSJxYDxgpFt(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.sZRejVcyWsEKSAjxvXLqCyPdCuA(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yIRdWijqyghmemPssevxkoxocsUE.BvlCDHporsdVoEpxIfCtPLSnyCEj(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					yIRdWijqyghmemPssevxkoxocsUE.BvlCDHporsdVoEpxIfCtPLSnyCEj(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.whxNiKHrMFxPJAgBjEgFFOeSlVHA(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = AkpZeTvTvDWYnEqWDyDWrcufUCI.whxNiKHrMFxPJAgBjEgFFOeSlVHA(sourceControllerId);
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
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.ssSdbGfZnDEhDUWmfPYQOsAGwMx(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.dsQtTEnYQFjVFFxLvbGUXZDvbar(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.cQAeGgQhxJEefiiwSPvDFzthihtv(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.lCPwepBkieLtLzatCuWyqPWSqO(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.JTfhmcCQtSnJUpEUWApocqDjLBeg(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.fgzioFOpODFqmPepxTDygvJRpyO<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.ezbHzgCqwLthxsWYOOyJKDwpFMX();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.ezbHzgCqwLthxsWYOOyJKDwpFMX(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.ezbHzgCqwLthxsWYOOyJKDwpFMX<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.yCSnAJgicRxnHscROcTistbBbLl();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					AkpZeTvTvDWYnEqWDyDWrcufUCI.yriBQDnkYvrvyaiUGEOUCIKrzPN(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					AkpZeTvTvDWYnEqWDyDWrcufUCI.yriBQDnkYvrvyaiUGEOUCIKrzPN(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					AkpZeTvTvDWYnEqWDyDWrcufUCI.ePRwkMZZWtoOHNmXUYNXQjcOLks(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					AkpZeTvTvDWYnEqWDyDWrcufUCI.PjOpTtOqxuHGnsuVpSkOPzznyw(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					AkpZeTvTvDWYnEqWDyDWrcufUCI.JITpkVFOnUeywEjxEasvcfvrohL();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.CoZRjQbUOQiESclBcEIdexoMtib();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.CoZRjQbUOQiESclBcEIdexoMtib(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.KyWOTzXnbnFXfcbzIhYfqSkrzkMa();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.KyWOTzXnbnFXfcbzIhYfqSkrzkMa(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.yERBofCdUWBmcVxkAYCWLnNYSuAS();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.yERBofCdUWBmcVxkAYCWLnNYSuAS(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.fSFOJycYWbgZkCObUKvhjBIWHpU();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.fSFOJycYWbgZkCObUKvhjBIWHpU(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.eqFovowBCGYtCfcTTXQKPQnFkQX();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.eqFovowBCGYtCfcTTXQKPQnFkQX(controllerType);
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
				yIRdWijqyghmemPssevxkoxocsUE.PkTWASHdMcjRDWrOrgHsjGBxPCR(joystick);
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
			private static MappingHelper SKcIgrdHSZRiIzfxUyDOqjyMnCX;

			internal static MappingHelper Instance => SKcIgrdHSZRiIzfxUyDOqjyMnCX ?? (SKcIgrdHSZRiIzfxUyDOqjyMnCX = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.MapCategories_readOnly;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.UserAssignableMapCategories;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ActionCategories_readOnly;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.UserAssignableActionCategories;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.JoystickLayouts_readOnly;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.KeyboardLayouts_readOnly;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.MouseLayouts_readOnly;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.CustomControllerLayouts_readOnly;
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
					return XVroGTnTmiTwGITDVAhlDMsuaLiG.Actions;
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
					return lPlxhgNPpsgHbDrFTbwKnGHEkWU.UserAssignableActions;
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
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.sEJhUIpyftedXZWXTArRzfRbHwW(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.SAFLTFRKTqUcISynofaBLUpKzsI(tag);
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
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.McycczgUVnhzYjRmBgMpORmytlt(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.gXDRHMtKwHvXyuAkhcBghwveWUO(tag);
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
					ControllerType.Joystick => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetCustomControllerLayoutById(layoutId), 
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
					ControllerType.Joystick => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetJoystickLayout(name), 
					ControllerType.Keyboard => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetKeyboardLayout(name), 
					ControllerType.Mouse => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetMouseLayout(name), 
					ControllerType.Custom => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetCustomControllerLayout(name), 
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
					ControllerType.Joystick => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetMouseLayoutId(name), 
					ControllerType.Custom => lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetCustomControllerLayoutId(name);
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
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ZMNXUvImaIeaHRjjFmXhcOnslTW(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ZMNXUvImaIeaHRjjFmXhcOnslTW(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ZMNXUvImaIeaHRjjFmXhcOnslTW(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.ZMNXUvImaIeaHRjjFmXhcOnslTW(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.WKkKolPzPcLkyzugSnSXlOKzbPr(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.cWbeulKVHddpbQNuRYZlRUrtTjG(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.cWbeulKVHddpbQNuRYZlRUrtTjG(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.cWbeulKVHddpbQNuRYZlRUrtTjG(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.cWbeulKVHddpbQNuRYZlRUrtTjG(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.qBAcKkDJYAgrLrUyXSQfoyMaOWli(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.qBAcKkDJYAgrLrUyXSQfoyMaOWli(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.tTnDGLKfHmwwnZlLMmzdSgXpidO(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return AkpZeTvTvDWYnEqWDyDWrcufUCI.tTnDGLKfHmwwnZlLMmzdSgXpidO(playerId, behaviorName);
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
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior nestrrfIVirECTnLUMsmpQfUNFW(int P_0)
			{
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetInputBehaviorById(P_0);
			}

			internal InputBehavior nestrrfIVirECTnLUMsmpQfUNFW(string P_0)
			{
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetInputBehavior(P_0);
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
				Controller controller = AkpZeTvTvDWYnEqWDyDWrcufUCI.ZqzzcVLLrMBIUyLpDAZiOGBIopG(controllerIdentifier);
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
				JoystickMap joystickMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.TNNQzekbpHjCKEeRbKifsgkUPMA(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.udRnEWOwQJDseTQQIEzfgbieiXAF(joystickMap);
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
				InputSource inputSourceType = XZkCtazuKqRFXBDaYdGEgUNVjfjj.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = yVekqoXoalcSjhETOEoiHtqtaHne.dMjNVlqbaijTonceqCKTHgiYOnrR(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.uYfcyxtdZVDjPEdyMfUvmLwnlbjG(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystickMap.controllerType = ControllerType.Joystick;
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.QWHeqeJpXgHwdBRUqASObIjwFdH(joystickMap, hardwareControllerMap_Game);
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
				if (AkpZeTvTvDWYnEqWDyDWrcufUCI.ZqzzcVLLrMBIUyLpDAZiOGBIopG(controllerIdentifier) is Joystick joystick)
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
				KeyboardMap keyboardMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.udRnEWOwQJDseTQQIEzfgbieiXAF(keyboardMap);
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
				MouseMap mouseMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.udRnEWOwQJDseTQQIEzfgbieiXAF(mouseMap);
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
				CustomControllerMap customControllerMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.afCOBqOskEPFuQelOCcHQoUgyBZ(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.udRnEWOwQJDseTQQIEzfgbieiXAF(customControllerMap);
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
				if (AkpZeTvTvDWYnEqWDyDWrcufUCI.ZqzzcVLLrMBIUyLpDAZiOGBIopG(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.afCOBqOskEPFuQelOCcHQoUgyBZ(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.yuVTyXTeLkmAEriUUAaddbTLpoaJ();
					if (hardwareControllerMap_Game == null)
					{
						Logger.LogError("No hardware map found.");
						return null;
					}
					customControllerMap.controllerType = ControllerType.Custom;
					foreach (ActionElementMap allMap in customControllerMap.AllMaps)
					{
						allMap.QWHeqeJpXgHwdBRUqASObIjwFdH(customControllerMap, hardwareControllerMap_Game);
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
					controllerMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.ifCgZrpoeKFgfwvVVGARrzzwHdG(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.udRnEWOwQJDseTQQIEzfgbieiXAF(controller, controllerMap);
					}
					else
					{
						controller.udRnEWOwQJDseTQQIEzfgbieiXAF(controllerMap);
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
				if (AkpZeTvTvDWYnEqWDyDWrcufUCI.ZqzzcVLLrMBIUyLpDAZiOGBIopG(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = XZkCtazuKqRFXBDaYdGEgUNVjfjj.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = yVekqoXoalcSjhETOEoiHtqtaHne.dMjNVlqbaijTonceqCKTHgiYOnrR(controllerIdentifier.hardwareTypeGuid, inputSourceType);
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
					joystickMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.uYfcyxtdZVDjPEdyMfUvmLwnlbjG(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				}
				if (joystickMap != null)
				{
					joystickMap.controllerType = ControllerType.Joystick;
					if (players.GetPlayer(playerId) != null)
					{
						joystickMap.playerId = playerId;
					}
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.QWHeqeJpXgHwdBRUqASObIjwFdH(joystickMap, hardwareControllerMap_Game);
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
				if (AkpZeTvTvDWYnEqWDyDWrcufUCI.ZqzzcVLLrMBIUyLpDAZiOGBIopG(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
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
					customControllerMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.afCOBqOskEPFuQelOCcHQoUgyBZ(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				}
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.yuVTyXTeLkmAEriUUAaddbTLpoaJ();
					if (hardwareControllerMap_Game == null)
					{
						Logger.LogError("No hardware map found.");
						return null;
					}
					customControllerMap.controllerType = ControllerType.Custom;
					if (players.GetPlayer(playerId) != null)
					{
						customControllerMap.playerId = playerId;
					}
					foreach (ActionElementMap allMap in customControllerMap.AllMaps)
					{
						allMap.QWHeqeJpXgHwdBRUqASObIjwFdH(customControllerMap, hardwareControllerMap_Game);
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
					keyboardMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.udRnEWOwQJDseTQQIEzfgbieiXAF(keyboard, keyboardMap);
					}
					else
					{
						keyboard.udRnEWOwQJDseTQQIEzfgbieiXAF(keyboardMap);
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
					mouseMap = lPlxhgNPpsgHbDrFTbwKnGHEkWU.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.udRnEWOwQJDseTQQIEzfgbieiXAF(mouse, mouseMap);
					}
					else
					{
						mouse.udRnEWOwQJDseTQQIEzfgbieiXAF(mouseMap);
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
				return HdYdlAiGUDYkWoKhRyzebqQdZIyf(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier HdYdlAiGUDYkWoKhRyzebqQdZIyf(Guid P_0, int P_1)
			{
				return yVekqoXoalcSjhETOEoiHtqtaHne.HdYdlAiGUDYkWoKhRyzebqQdZIyf(P_0, P_1)?.ToControllerElementIdentifier();
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.WKyHsVifphzVQBJXsCGVKpHIutgR(templateTypeGuid, mapCategoryId, layoutId);
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
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetControllerMapLayoutManagerRuleSetId(name);
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
				return lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper SKcIgrdHSZRiIzfxUyDOqjyMnCX;

			internal static PlayerHelper Instance => SKcIgrdHSZRiIzfxUyDOqjyMnCX ?? (SKcIgrdHSZRiIzfxUyDOqjyMnCX = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return yIRdWijqyghmemPssevxkoxocsUE.gamePlayerCount;
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
					return yIRdWijqyghmemPssevxkoxocsUE.allPlayerCount;
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
					return yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly;
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
					return yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly;
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
					return yIRdWijqyghmemPssevxkoxocsUE.ikAQnlPYKaPDyPGwvHipJdyKxOw();
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
					return yIRdWijqyghmemPssevxkoxocsUE.Players_readOnly;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.AllPlayers_readOnly;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.lZXmlWxQPcBFEbyBUMCSggeIoJj(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.lZXmlWxQPcBFEbyBUMCSggeIoJj(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.ikAQnlPYKaPDyPGwvHipJdyKxOw();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.GmfmqgwwruAcVvlPCjzaddlByMI(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.VPCnmgLFdrmuGBobAhPkIEeTAolB(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.XKJhTJfgdOBDZqfJcBGFkNaqcUU(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return yIRdWijqyghmemPssevxkoxocsUE.VrWNuYJxMDQfdSQUfevYuCHLXgk(includeSystemPlayer);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper SKcIgrdHSZRiIzfxUyDOqjyMnCX;

			internal static TimeHelper Instance => SKcIgrdHSZRiIzfxUyDOqjyMnCX ?? (SKcIgrdHSZRiIzfxUyDOqjyMnCX = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)NhAnIGdoBfzjyelOkjCyJAbIjsl.unscaledDeltaTime;
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
					return NhAnIGdoBfzjyelOkjCyJAbIjsl.unscaledTime;
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
					return NhAnIGdoBfzjyelOkjCyJAbIjsl.frame;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class qgMpmwaNoBbphajSwDKVeBKVjPxm
		{
			private class EYpABbTJGZAeCjlxTpkHjpcdSCtz
			{
				public readonly UpdateLoopType ENXLJBnoaLplSRNpPerVNetoNsG;

				private double MrDlgHQWcTNhuavzUwxfaiVsbmR;

				private double WQBnXLzDetHiAZBkEIpLMRpVOyI;

				private double rsIsvuyohiSXvmTdTmaszbehYjV;

				private double ScAZzRAWSeDYAmiYhRHQaMEKDUY;

				private uint EELoDQjgefEACiyetjBWttnrjEfh;

				private uint FjgHkhWTHElfAlHhCnjdfwqPJBA;

				private float sEjLZiNURJhkhhmdNXVsvOxabHtc;

				private float PJXBVMAYBblIbsaLJdbeXUXPOCFj;

				public double unscaledTime => MrDlgHQWcTNhuavzUwxfaiVsbmR;

				public double unscaledTimePrev => WQBnXLzDetHiAZBkEIpLMRpVOyI;

				public double unscaledDeltaTime => rsIsvuyohiSXvmTdTmaszbehYjV;

				public uint frame => EELoDQjgefEACiyetjBWttnrjEfh;

				public uint framePrev => FjgHkhWTHElfAlHhCnjdfwqPJBA;

				public float unityUnscaledDeltaTime => sEjLZiNURJhkhhmdNXVsvOxabHtc;

				public float unityUnscaledDeltaTimePrev => PJXBVMAYBblIbsaLJdbeXUXPOCFj;

				public EYpABbTJGZAeCjlxTpkHjpcdSCtz(UpdateLoopType updateLoop)
				{
					ENXLJBnoaLplSRNpPerVNetoNsG = updateLoop;
					ScAZzRAWSeDYAmiYhRHQaMEKDUY = Time.realtimeSinceStartup;
					EELoDQjgefEACiyetjBWttnrjEfh = 0u;
				}

				public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
				{
					WQBnXLzDetHiAZBkEIpLMRpVOyI = MrDlgHQWcTNhuavzUwxfaiVsbmR;
					MrDlgHQWcTNhuavzUwxfaiVsbmR = ReInput.realTime;
					if (ScAZzRAWSeDYAmiYhRHQaMEKDUY > MrDlgHQWcTNhuavzUwxfaiVsbmR)
					{
						ScAZzRAWSeDYAmiYhRHQaMEKDUY = 0.0;
					}
					rsIsvuyohiSXvmTdTmaszbehYjV = MrDlgHQWcTNhuavzUwxfaiVsbmR - ScAZzRAWSeDYAmiYhRHQaMEKDUY;
					ScAZzRAWSeDYAmiYhRHQaMEKDUY = MrDlgHQWcTNhuavzUwxfaiVsbmR;
					FjgHkhWTHElfAlHhCnjdfwqPJBA = EELoDQjgefEACiyetjBWttnrjEfh;
					EELoDQjgefEACiyetjBWttnrjEfh = MiscTools.Tick(EELoDQjgefEACiyetjBWttnrjEfh);
					PJXBVMAYBblIbsaLJdbeXUXPOCFj = sEjLZiNURJhkhhmdNXVsvOxabHtc;
					sEjLZiNURJhkhhmdNXVsvOxabHtc = KeSFrMJCDAPknwDjEMpWGSdAQAAO();
					previousFrame = FjgHkhWTHElfAlHhCnjdfwqPJBA;
					currentFrame = EELoDQjgefEACiyetjBWttnrjEfh;
					ReInput.unscaledTime = MrDlgHQWcTNhuavzUwxfaiVsbmR;
					ReInput.unscaledTimePrev = WQBnXLzDetHiAZBkEIpLMRpVOyI;
					ReInput.unscaledDeltaTime = rsIsvuyohiSXvmTdTmaszbehYjV;
				}
			}

			private static class HloyVEDkOlSJolDlueQgsVBgELn
			{
				public static StopwatchBase Global
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

				public static StopwatchBase ikoBGVHHLVNnLaVaWGffMETVhTJw()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase EkiDMsjlVlTDboAzWEPDaYplhaWb()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase gRgXlQpRIzoSZvhQWYJTFqaUQAp;

			private double zRHTOpDqzTGxecqhgvqkYUpyebH;

			private EYpABbTJGZAeCjlxTpkHjpcdSCtz ZlHBNkfwgSQZbHeSmjWbXjevOqK;

			private ADictionary<int, EYpABbTJGZAeCjlxTpkHjpcdSCtz> oAIWSariUcdUKhcoyChAnxLjZjW;

			private uint JVpAhcdmAtVvGoLbOdGTYSWMKzaV;

			public double unscaledTime => ZlHBNkfwgSQZbHeSmjWbXjevOqK.unscaledTime;

			public double unscaledTimePrev => ZlHBNkfwgSQZbHeSmjWbXjevOqK.unscaledTimePrev;

			public double unscaledDeltaTime => ZlHBNkfwgSQZbHeSmjWbXjevOqK.unscaledDeltaTime;

			public float unityUnscaledDeltaTime => ZlHBNkfwgSQZbHeSmjWbXjevOqK.unityUnscaledDeltaTime;

			public float unityUnscaledDeltaTimePrev => ZlHBNkfwgSQZbHeSmjWbXjevOqK.unityUnscaledDeltaTimePrev;

			internal double realTime => gRgXlQpRIzoSZvhQWYJTFqaUQAp.elapsedSeconds + zRHTOpDqzTGxecqhgvqkYUpyebH;

			public uint frame => ZlHBNkfwgSQZbHeSmjWbXjevOqK.frame;

			public uint framePrev => ZlHBNkfwgSQZbHeSmjWbXjevOqK.framePrev;

			public uint absFrame => JVpAhcdmAtVvGoLbOdGTYSWMKzaV;

			public qgMpmwaNoBbphajSwDKVeBKVjPxm()
			{
				gRgXlQpRIzoSZvhQWYJTFqaUQAp = HloyVEDkOlSJolDlueQgsVBgELn.Global;
				agvWMBoHtblzmgSmVloJbsDkfGk();
			}

			public void wnxemBQKskLTdCdgvkkJbpPFVfL()
			{
				zRHTOpDqzTGxecqhgvqkYUpyebH = Time.realtimeSinceStartup;
			}

			public void agvWMBoHtblzmgSmVloJbsDkfGk()
			{
				ZlHBNkfwgSQZbHeSmjWbXjevOqK = null;
				oAIWSariUcdUKhcoyChAnxLjZjW = new ADictionary<int, EYpABbTJGZAeCjlxTpkHjpcdSCtz>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)2147483647, list);
				for (int i = 0; i < list.Count; i++)
				{
					EYpABbTJGZAeCjlxTpkHjpcdSCtz eYpABbTJGZAeCjlxTpkHjpcdSCtz = new EYpABbTJGZAeCjlxTpkHjpcdSCtz(list[i]);
					oAIWSariUcdUKhcoyChAnxLjZjW.Add((int)list[i], eYpABbTJGZAeCjlxTpkHjpcdSCtz);
					if (ZlHBNkfwgSQZbHeSmjWbXjevOqK == null)
					{
						ZlHBNkfwgSQZbHeSmjWbXjevOqK = eYpABbTJGZAeCjlxTpkHjpcdSCtz;
					}
				}
			}

			public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
			{
				if (ZlHBNkfwgSQZbHeSmjWbXjevOqK.ENXLJBnoaLplSRNpPerVNetoNsG != P_0)
				{
					ZlHBNkfwgSQZbHeSmjWbXjevOqK = oAIWSariUcdUKhcoyChAnxLjZjW[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					ZlHBNkfwgSQZbHeSmjWbXjevOqK.iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
					JVpAhcdmAtVvGoLbOdGTYSWMKzaV = MiscTools.Tick(JVpAhcdmAtVvGoLbOdGTYSWMKzaV);
					ReInput.absFrame = JVpAhcdmAtVvGoLbOdGTYSWMKzaV;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch SKcIgrdHSZRiIzfxUyDOqjyMnCX;

			internal static UnityTouch Instance => SKcIgrdHSZRiIzfxUyDOqjyMnCX ?? (SKcIgrdHSZRiIzfxUyDOqjyMnCX = new UnityTouch());

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

		internal class DHRdDLjBOXERfzdjVarzaXUCbHPa
		{
			public readonly ValueWatcher<bool> VSXlKYVwWdZqgUfXaEfHIKNeFWd;

			public readonly ValueWatcher<bool> DTfsbNwKAnJRGCVMonjAjpBkhhP;

			public readonly ValueWatcher<bool> apPWrEWoQKEcqRyIjtpZSwZuCze;

			public readonly ValueWatcher<int> owppUzdnQgKqwtfIzlCJmdPiokr;

			public readonly ValueWatcher<float> bOwbxBZSDDDOsweOsGljPaOnTFw;

			public readonly ValueWatcher<string> TYjAESncDtdimoTpjOayjLplaln;

			public readonly ValueWatcher<bool> xHHoAHXprddqJfNNjjEEthmYSLY;

			private int AHrwZkSuUatzJFZYYQGRIlDxWHy;

			private readonly ValueWatcher[] FQTLfyJbsloIPkvJuDWdpyaxUCd;

			[CompilerGenerated]
			private static Func<bool> IQgdXlRTMLbWURbPUfOnafpHisCe;

			[CompilerGenerated]
			private static Func<bool> TdMnWRHxcwotmBdTUrJaPVKbJPp;

			[CompilerGenerated]
			private static Func<int> vbHNKULaUzykOQfxIkBEUxCXKHK;

			[CompilerGenerated]
			private static Func<float> czUHMEugxtjRLdgTzCaqnHvmeNm;

			[CompilerGenerated]
			private static Func<bool> RATwUXRUgLIdlpFJYHssbcpTfLA;

			[CompilerGenerated]
			private static Func<string> ZAXyhAORkPjPoGqtTDjxyRjunec;

			public int currentFrame => AHrwZkSuUatzJFZYYQGRIlDxWHy;

			public DHRdDLjBOXERfzdjVarzaXUCbHPa()
			{
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(VSXlKYVwWdZqgUfXaEfHIKNeFWd = new ValueWatcher<bool>(initialValue: true, autoTriggerEvent: false)),
					(DTfsbNwKAnJRGCVMonjAjpBkhhP = new ValueWatcher<bool>(Screen.fullScreen, () => Screen.fullScreen, autoTriggerEvent: false)),
					(apPWrEWoQKEcqRyIjtpZSwZuCze = new ValueWatcher<bool>(Application.runInBackground, () => Application.runInBackground, autoTriggerEvent: false)),
					(owppUzdnQgKqwtfIzlCJmdPiokr = new ValueWatcher<int>((int)Screen.fullScreenMode, () => (int)Screen.fullScreenMode, autoTriggerEvent: false)),
					(bOwbxBZSDDDOsweOsGljPaOnTFw = new ValueWatcher<float>(Time.unscaledDeltaTime, () => Time.unscaledDeltaTime, autoTriggerEvent: false)),
					(xHHoAHXprddqJfNNjjEEthmYSLY = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), () => MathTools.ApproximatelyZero(Time.timeScale), MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(TYjAESncDtdimoTpjOayjLplaln = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), () => UnityTools.externalTools.GetFocusedEditorWindowTitle(), autoTriggerEvent: false));
				}
				FQTLfyJbsloIPkvJuDWdpyaxUCd = list.ToArray();
				iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
			}

			public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
				for (int i = 0; i < FQTLfyJbsloIPkvJuDWdpyaxUCd.Length; i++)
				{
					FQTLfyJbsloIPkvJuDWdpyaxUCd[i].Update();
				}
				AHrwZkSuUatzJFZYYQGRIlDxWHy = Time.frameCount;
			}

			public void zHfuXPHEaUWOGePPGcHZRMwjmUW()
			{
				for (int i = 0; i < FQTLfyJbsloIPkvJuDWdpyaxUCd.Length; i++)
				{
					FQTLfyJbsloIPkvJuDWdpyaxUCd[i].TriggerEvent();
				}
			}

			[CompilerGenerated]
			private static bool tWawPOUEXfilEkdYobkxGLRbUbs()
			{
				return Screen.fullScreen;
			}

			[CompilerGenerated]
			private static bool nZzSZszbwPbxxTnTnThVolKzTAr()
			{
				return Application.runInBackground;
			}

			[CompilerGenerated]
			private static int snGDmZEznVKvYalWvHYcwWBUCMu()
			{
				return (int)Screen.fullScreenMode;
			}

			[CompilerGenerated]
			private static float hEBEjODjQrVowBgWpaRXORpIHHn()
			{
				return Time.unscaledDeltaTime;
			}

			[CompilerGenerated]
			private static bool BhaSQamxMUlYAIjPgrYFqcKExwh()
			{
				return MathTools.ApproximatelyZero(Time.timeScale);
			}

			[CompilerGenerated]
			private static string HsiDzrQEqKVUggfHeBgkhjzgAXtZ()
			{
				return UnityTools.externalTools.GetFocusedEditorWindowTitle();
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 41;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 1;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2021";

		private static InputManager_Base OayGWMjwwAWqSvvHJSLxyoWuEsp;

		private static PlatformInputManager XZkCtazuKqRFXBDaYdGEgUNVjfjj;

		internal static uXNRyMOantFPUprJgkJntGqFAgR XVroGTnTmiTwGITDVAhlDMsuaLiG;

		internal static wdexXznqMQgvrkdYBfwPPJZVQDx AkpZeTvTvDWYnEqWDyDWrcufUCI;

		internal static YOrqWFzXKZXgaAwGZbhDkecGRxO yIRdWijqyghmemPssevxkoxocsUE;

		private static ControllerDataFiles yVekqoXoalcSjhETOEoiHtqtaHne;

		private static UserData lPlxhgNPpsgHbDrFTbwKnGHEkWU;

		private static bool rXobafaxvUDrItlgWahiaYSKJqn;

		private static ConfigVars LOkMduUeVwqIadHuBlHhVcCnHqW;

		private static UpdateLoopType YOZcZdsiktGyBGLmwdsNcHQrXQS;

		private static bool rVpUCROuewHidvpkltGSoFPvVaG;

		private static Platform vOyhoezlzuDNJkbVrMoXSdBXzawR;

		private static WebplayerPlatform BCOeRMjFOnlSbaKyMghOdWRgLhUr;

		private static EditorPlatform tKHPgJVsdrQQjIgOmOzDCJwSQLI;

		private static bool lErgspMfHFHpykceGkSMpHLGMyXl;

		private static TimerAbs GdScAUHhKJPBbEtzwXeCebgMFHH;

		private static qgMpmwaNoBbphajSwDKVeBKVjPxm NhAnIGdoBfzjyelOkjCyJAbIjsl;

		private static string rwTIEWuvgZFTQrwuHoVeBZzkras;

		private static bool sOnDuWbBPgngqdqgfrBPEhfbAIiL;

		private static bool FNduOFCXOwBVgaDNutaejQNnbtS;

		private static bool vKbvJHaINwPJnYGLBEoubaXghCC;

		private static int TiCDeFxJusdbZzozygrzEdbKLEiH;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int dPSVZxQqmwlbNLjEtcvERnfQXYg;

		private static int BrGUjmcWslLCPvvzxyflOBRuICI;

		private static bool EZyrsJdTjlHvuSDwTNGMqOMKIJXc;

		private static readonly UnityTouch tIMsvLgRjFRolbxYZjaocOAxdpqA;

		private static readonly PlayerHelper RNvHmnWeqqCfsCzvyNfNcvLrtDZh;

		private static readonly ControllerHelper XCaZfAGuFNazSvMiTgIqdAolDeje;

		private static readonly MappingHelper llkewsDswpHefGLvaoTcaNUxjXng;

		private static readonly TimeHelper xMchbePRIdEqlCxGwgJLIMMHJhtr;

		private static readonly ConfigHelper qOcGSpDHkuHuqximKlWlboDWkvDN;

		private static PjDqdalDGReTRPKKohsygTMMDToW hCNkzlGBuAysBgqeMrxTrjQSWXz;

		private static UserDataStore SWwFvmLUBcxdThqhZtFnAICjSyK;

		private static IControllerAssigner DOhvOQuwNPmQpOyDlqTkUfQyEaL;

		private static DHRdDLjBOXERfzdjVarzaXUCbHPa TovKnmdlpWJMDQSDObMGYTYPOu;

		private static SafeAction<ControllerStatusChangedEventArgs> pmVAfOknAvafOWhrdgKwGxbiKXq;

		private static SafeAction<ControllerStatusChangedEventArgs> YBXwrwwFWIHQuokQckkpKVNXobS;

		private static SafeAction<ControllerStatusChangedEventArgs> QIAkIsJySajRGeOJnLIDRURaYWy;

		private static SafeAction KTLrwuiGjGUcPQzxFhtPZjyUcXS;

		private static SafeAction ILBzwpZPstFVKSZiXaYYqxqUjrA;

		private static SafeAction WbWjIACjYiiqusiPKXqgMRJepwf;

		private static SafeAction OrbORKqRdTlgLDIFaJvsCBnNugY;

		private static SafeAction eLNfANJDtfMJKiXgBkfTmKBiyehW;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action ByOvuwSdzMgmNDNFXOyaLDYCpYS;

		private static Action<UpdateLoopType> WdBjYfdLgiAMmOdmfZZetgtNdNZK;

		private static Action<UpdateLoopType> YoRxUZuzFddPvgiHNbuzJsCgDUw;

		private static Action<UpdateLoopType> SYXQPUlccDBPgUGsbXsHDzEiLnG;

		private static Action orbXmxICiYKcwdDZqbQTemUrgZaE;

		private static Action<bool> dayTHghmHzeNjkDUArLonoQTvvgn;

		private static Action<bool> GwYWrRDEKqQMZjdftOzCKprfOwr;

		private static Action<bool> PiYoycleRUIKGFkZLXLvgMNvidjH;

		private static Action<FullScreenMode> HeSIOcIObcdkRcoffhXXltVSUPJr;

		private static Action dDSmbcSsKZgkJioOYWsDFsBhiycq;

		private static Action<bool> GwaXpAxZClnbMRBUFpVTuTxqKP;

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

		[CompilerGenerated]
		private static Action<Exception> cwGOYhKwHMTRlLGgYYcQcxWZbHq;

		[CompilerGenerated]
		private static Action<Exception> ZnRWuXlHbTvfOmxtDBCcTJFUzCG;

		[CompilerGenerated]
		private static Action<Exception> qHBJmKNCVjycjQRAvhwoDOstoTn;

		[CompilerGenerated]
		private static Action<Exception> SntdUsfDSHIjtvOuCbxzDmwiDbGp;

		[CompilerGenerated]
		private static Action<Exception> hXecteAuDBMixCRzxtdbRatMBIs;

		[CompilerGenerated]
		private static Action<Exception> iZryCcsjDQStGUjgKEyckkGrBl;

		[CompilerGenerated]
		private static Action<Exception> ObhFYMGsWdLHOSITjOxbuCSunIGt;

		[CompilerGenerated]
		private static Action<Exception> qdLYUyQsQvyakjsHShAZOUUAbQq;

		[CompilerGenerated]
		private static Action<Exception> xygFezReAzfLHrvilzgAjLdhixUb;

		[CompilerGenerated]
		private static Func<bool> IsMNOHDGlmuNoqaKRaklfEYcDlca;

		private static PjDqdalDGReTRPKKohsygTMMDToW unityInputBuffer => hCNkzlGBuAysBgqeMrxTrjQSWXz ?? (hCNkzlGBuAysBgqeMrxTrjQSWXz = new PjDqdalDGReTRPKKohsygTMMDToW(LOkMduUeVwqIadHuBlHhVcCnHqW.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					CIAGYybgsNHgxFZiLAPuIvNZovja();
					return null;
				}
				return RNvHmnWeqqCfsCzvyNfNcvLrtDZh;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					CIAGYybgsNHgxFZiLAPuIvNZovja();
					return null;
				}
				return XCaZfAGuFNazSvMiTgIqdAolDeje;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					CIAGYybgsNHgxFZiLAPuIvNZovja();
					return null;
				}
				return llkewsDswpHefGLvaoTcaNUxjXng;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					CIAGYybgsNHgxFZiLAPuIvNZovja();
					return null;
				}
				return tIMsvLgRjFRolbxYZjaocOAxdpqA;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					CIAGYybgsNHgxFZiLAPuIvNZovja();
					return null;
				}
				return xMchbePRIdEqlCxGwgJLIMMHJhtr;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					CIAGYybgsNHgxFZiLAPuIvNZovja();
					return null;
				}
				return SWwFvmLUBcxdThqhZtFnAICjSyK;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					CIAGYybgsNHgxFZiLAPuIvNZovja();
					return null;
				}
				return qOcGSpDHkuHuqximKlWlboDWkvDN;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 41 + "." + 1 + ".U2021";

		public static bool usingUnityInput => rVpUCROuewHidvpkltGSoFPvVaG;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
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

		public static bool isReady => rXobafaxvUDrItlgWahiaYSKJqn;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => rXobafaxvUDrItlgWahiaYSKJqn;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => YOZcZdsiktGyBGLmwdsNcHQrXQS;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => LOkMduUeVwqIadHuBlHhVcCnHqW;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => LOkMduUeVwqIadHuBlHhVcCnHqW;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => lPlxhgNPpsgHbDrFTbwKnGHEkWU;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => vOyhoezlzuDNJkbVrMoXSdBXzawR;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => BCOeRMjFOnlSbaKyMghOdWRgLhUr;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => tKHPgJVsdrQQjIgOmOzDCJwSQLI;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (vOyhoezlzuDNJkbVrMoXSdBXzawR == Platform.Linux && rVpUCROuewHidvpkltGSoFPvVaG)
				{
					return true;
				}
				if (vOyhoezlzuDNJkbVrMoXSdBXzawR == Platform.OSX && (rVpUCROuewHidvpkltGSoFPvVaG || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && rVpUCROuewHidvpkltGSoFPvVaG)
				{
					return true;
				}
				if (vOyhoezlzuDNJkbVrMoXSdBXzawR == Platform.Webplayer && BCOeRMjFOnlSbaKyMghOdWRgLhUr == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (vOyhoezlzuDNJkbVrMoXSdBXzawR == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => tKHPgJVsdrQQjIgOmOzDCJwSQLI != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					return Guid.Empty;
				}
				return yVekqoXoalcSjhETOEoiHtqtaHne.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => FNduOFCXOwBVgaDNutaejQNnbtS;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => NhAnIGdoBfzjyelOkjCyJAbIjsl.unityUnscaledDeltaTime;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => NhAnIGdoBfzjyelOkjCyJAbIjsl.unityUnscaledDeltaTimePrev;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					return 0.0;
				}
				return NhAnIGdoBfzjyelOkjCyJAbIjsl.realTime;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					return 0;
				}
				return TovKnmdlpWJMDQSDObMGYTYPOu.currentFrame;
			}
		}

		private static bool isEditorGameViewFocused
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return rwTIEWuvgZFTQrwuHoVeBZzkras == "Game";
				}
				return rwTIEWuvgZFTQrwuHoVeBZzkras == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (LOkMduUeVwqIadHuBlHhVcCnHqW.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!vKbvJHaINwPJnYGLBEoubaXghCC)
				{
					return isEditorGameViewFocused;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (XZkCtazuKqRFXBDaYdGEgUNVjfjj is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return vKbvJHaINwPJnYGLBEoubaXghCC;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					return false;
				}
				if (!rVpUCROuewHidvpkltGSoFPvVaG)
				{
					return false;
				}
				if (vOyhoezlzuDNJkbVrMoXSdBXzawR != Platform.Windows && (vOyhoezlzuDNJkbVrMoXSdBXzawR != Platform.Webplayer || BCOeRMjFOnlSbaKyMghOdWRgLhUr != WebplayerPlatform.Windows))
				{
					return tKHPgJVsdrQQjIgOmOzDCJwSQLI == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool inputAllowed
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					return false;
				}
				if (!TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.value)
				{
					if (EZyrsJdTjlHvuSDwTNGMqOMKIJXc)
					{
						return false;
					}
					if (!isEditor && !TovKnmdlpWJMDQSDObMGYTYPOu.apPWrEWoQKEcqRyIjtpZSwZuCze.value)
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
				if (rXobafaxvUDrItlgWahiaYSKJqn)
				{
					return TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (rXobafaxvUDrItlgWahiaYSKJqn)
				{
					return TovKnmdlpWJMDQSDObMGYTYPOu.DTfsbNwKAnJRGCVMonjAjpBkhhP.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (rXobafaxvUDrItlgWahiaYSKJqn)
				{
					return TovKnmdlpWJMDQSDObMGYTYPOu.apPWrEWoQKEcqRyIjtpZSwZuCze.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (rXobafaxvUDrItlgWahiaYSKJqn)
				{
					return TovKnmdlpWJMDQSDObMGYTYPOu.xHHoAHXprddqJfNNjjEEthmYSLY.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => OayGWMjwwAWqSvvHJSLxyoWuEsp;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!rXobafaxvUDrItlgWahiaYSKJqn)
				{
					CIAGYybgsNHgxFZiLAPuIvNZovja();
					return null;
				}
				return XZkCtazuKqRFXBDaYdGEgUNVjfjj.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return DOhvOQuwNPmQpOyDlqTkUfQyEaL;
			}
			set
			{
				DOhvOQuwNPmQpOyDlqTkUfQyEaL = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => BrGUjmcWslLCPvvzxyflOBRuICI;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				pmVAfOknAvafOWhrdgKwGxbiKXq += value;
			}
			remove
			{
				pmVAfOknAvafOWhrdgKwGxbiKXq -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				YBXwrwwFWIHQuokQckkpKVNXobS += value;
			}
			remove
			{
				YBXwrwwFWIHQuokQckkpKVNXobS -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				QIAkIsJySajRGeOJnLIDRURaYWy += value;
			}
			remove
			{
				QIAkIsJySajRGeOJnLIDRURaYWy -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				KTLrwuiGjGUcPQzxFhtPZjyUcXS += value;
			}
			remove
			{
				KTLrwuiGjGUcPQzxFhtPZjyUcXS -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				ILBzwpZPstFVKSZiXaYYqxqUjrA += value;
			}
			remove
			{
				ILBzwpZPstFVKSZiXaYYqxqUjrA -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				WbWjIACjYiiqusiPKXqgMRJepwf += value;
			}
			remove
			{
				WbWjIACjYiiqusiPKXqgMRJepwf -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				OrbORKqRdTlgLDIFaJvsCBnNugY += value;
			}
			remove
			{
				OrbORKqRdTlgLDIFaJvsCBnNugY -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				eLNfANJDtfMJKiXgBkfTmKBiyehW += value;
			}
			remove
			{
				eLNfANJDtfMJKiXgBkfTmKBiyehW -= value;
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
		internal static event Action EarlyUpdateEvent
		{
			add
			{
				ByOvuwSdzMgmNDNFXOyaLDYCpYS = (Action)Delegate.Combine(ByOvuwSdzMgmNDNFXOyaLDYCpYS, value);
			}
			remove
			{
				ByOvuwSdzMgmNDNFXOyaLDYCpYS = (Action)Delegate.Remove(ByOvuwSdzMgmNDNFXOyaLDYCpYS, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				WdBjYfdLgiAMmOdmfZZetgtNdNZK = (Action<UpdateLoopType>)Delegate.Combine(WdBjYfdLgiAMmOdmfZZetgtNdNZK, value);
			}
			remove
			{
				WdBjYfdLgiAMmOdmfZZetgtNdNZK = (Action<UpdateLoopType>)Delegate.Remove(WdBjYfdLgiAMmOdmfZZetgtNdNZK, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				YoRxUZuzFddPvgiHNbuzJsCgDUw = (Action<UpdateLoopType>)Delegate.Combine(YoRxUZuzFddPvgiHNbuzJsCgDUw, value);
			}
			remove
			{
				YoRxUZuzFddPvgiHNbuzJsCgDUw = (Action<UpdateLoopType>)Delegate.Remove(YoRxUZuzFddPvgiHNbuzJsCgDUw, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				SYXQPUlccDBPgUGsbXsHDzEiLnG = (Action<UpdateLoopType>)Delegate.Combine(SYXQPUlccDBPgUGsbXsHDzEiLnG, value);
			}
			remove
			{
				SYXQPUlccDBPgUGsbXsHDzEiLnG = (Action<UpdateLoopType>)Delegate.Remove(SYXQPUlccDBPgUGsbXsHDzEiLnG, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				orbXmxICiYKcwdDZqbQTemUrgZaE = (Action)Delegate.Combine(orbXmxICiYKcwdDZqbQTemUrgZaE, value);
			}
			remove
			{
				orbXmxICiYKcwdDZqbQTemUrgZaE = (Action)Delegate.Remove(orbXmxICiYKcwdDZqbQTemUrgZaE, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				dayTHghmHzeNjkDUArLonoQTvvgn = (Action<bool>)Delegate.Combine(dayTHghmHzeNjkDUArLonoQTvvgn, value);
			}
			remove
			{
				dayTHghmHzeNjkDUArLonoQTvvgn = (Action<bool>)Delegate.Remove(dayTHghmHzeNjkDUArLonoQTvvgn, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				GwYWrRDEKqQMZjdftOzCKprfOwr = (Action<bool>)Delegate.Combine(GwYWrRDEKqQMZjdftOzCKprfOwr, value);
			}
			remove
			{
				GwYWrRDEKqQMZjdftOzCKprfOwr = (Action<bool>)Delegate.Remove(GwYWrRDEKqQMZjdftOzCKprfOwr, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				PiYoycleRUIKGFkZLXLvgMNvidjH = (Action<bool>)Delegate.Combine(PiYoycleRUIKGFkZLXLvgMNvidjH, value);
			}
			remove
			{
				PiYoycleRUIKGFkZLXLvgMNvidjH = (Action<bool>)Delegate.Remove(PiYoycleRUIKGFkZLXLvgMNvidjH, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				HeSIOcIObcdkRcoffhXXltVSUPJr = (Action<FullScreenMode>)Delegate.Combine(HeSIOcIObcdkRcoffhXXltVSUPJr, value);
			}
			remove
			{
				HeSIOcIObcdkRcoffhXXltVSUPJr = (Action<FullScreenMode>)Delegate.Remove(HeSIOcIObcdkRcoffhXXltVSUPJr, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				dDSmbcSsKZgkJioOYWsDFsBhiycq = (Action)Delegate.Combine(dDSmbcSsKZgkJioOYWsDFsBhiycq, value);
			}
			remove
			{
				dDSmbcSsKZgkJioOYWsDFsBhiycq = (Action)Delegate.Remove(dDSmbcSsKZgkJioOYWsDFsBhiycq, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				GwaXpAxZClnbMRBUFpVTuTxqKP = (Action<bool>)Delegate.Combine(GwaXpAxZClnbMRBUFpVTuTxqKP, value);
			}
			remove
			{
				GwaXpAxZClnbMRBUFpVTuTxqKP = (Action<bool>)Delegate.Remove(GwaXpAxZClnbMRBUFpVTuTxqKP, value);
			}
		}

		static ReInput()
		{
			vKbvJHaINwPJnYGLBEoubaXghCC = true;
			TiCDeFxJusdbZzozygrzEdbKLEiH = -1;
			_id = -1;
			dPSVZxQqmwlbNLjEtcvERnfQXYg = 0;
			tIMsvLgRjFRolbxYZjaocOAxdpqA = UnityTouch.Instance;
			RNvHmnWeqqCfsCzvyNfNcvLrtDZh = PlayerHelper.Instance;
			XCaZfAGuFNazSvMiTgIqdAolDeje = ControllerHelper.Instance;
			llkewsDswpHefGLvaoTcaNUxjXng = MappingHelper.Instance;
			xMchbePRIdEqlCxGwgJLIMMHJhtr = TimeHelper.Instance;
			qOcGSpDHkuHuqximKlWlboDWkvDN = ConfigHelper.Instance;
			pmVAfOknAvafOWhrdgKwGxbiKXq = new SafeAction<ControllerStatusChangedEventArgs>(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			});
			YBXwrwwFWIHQuokQckkpKVNXobS = new SafeAction<ControllerStatusChangedEventArgs>(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			});
			QIAkIsJySajRGeOJnLIDRURaYWy = new SafeAction<ControllerStatusChangedEventArgs>(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			});
			KTLrwuiGjGUcPQzxFhtPZjyUcXS = new SafeAction(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			});
			ILBzwpZPstFVKSZiXaYYqxqUjrA = new SafeAction(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			});
			WbWjIACjYiiqusiPKXqgMRJepwf = new SafeAction(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			});
			OrbORKqRdTlgLDIFaJvsCBnNugY = new SafeAction(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			});
			eLNfANJDtfMJKiXgBkfTmKBiyehW = new SafeAction(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			});
			SafeDelegate.S_ExceptionHandler = delegate(Exception P_0)
			{
				HandleCallbackException("", P_0);
			};
		}

		public static void Reset()
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn && !(OayGWMjwwAWqSvvHJSLxyoWuEsp == null))
			{
				OayGWMjwwAWqSvvHJSLxyoWuEsp.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!inputAllowed)
			{
				return false;
			}
			if (tKHPgJVsdrQQjIgOmOzDCJwSQLI != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (EZyrsJdTjlHvuSDwTNGMqOMKIJXc)
				{
					if (!TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.value)
					{
						return false;
					}
				}
				else
				{
					if (!isAllowedEditorWindowFocused)
					{
						return false;
					}
					if (controllerType == ControllerType.Mouse && !isUnityEditorFocused)
					{
						return false;
					}
				}
			}
			return true;
		}

		internal static void iDBXctPcOcjjzWbKaCnxuPiVNUc(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4)
		{
			try
			{
				_id = dPSVZxQqmwlbNLjEtcvERnfQXYg;
				dPSVZxQqmwlbNLjEtcvERnfQXYg++;
				rXobafaxvUDrItlgWahiaYSKJqn = true;
				sOnDuWbBPgngqdqgfrBPEhfbAIiL = true;
				FNduOFCXOwBVgaDNutaejQNnbtS = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				OayGWMjwwAWqSvvHJSLxyoWuEsp = P_0;
				LOkMduUeVwqIadHuBlHhVcCnHqW = P_2;
				vOyhoezlzuDNJkbVrMoXSdBXzawR = UnityTools.platform;
				BCOeRMjFOnlSbaKyMghOdWRgLhUr = UnityTools.webplayerPlatform;
				tKHPgJVsdrQQjIgOmOzDCJwSQLI = UnityTools.editorPlatform;
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += fkxNLpTOlqyRGrLFwJbRjhMOcLL;
				yVekqoXoalcSjhETOEoiHtqtaHne = P_3;
				lPlxhgNPpsgHbDrFTbwKnGHEkWU = P_4;
				P_4.iDBXctPcOcjjzWbKaCnxuPiVNUc();
				ThreadSafeUnityInput.Initialize();
				TovKnmdlpWJMDQSDObMGYTYPOu = new DHRdDLjBOXERfzdjVarzaXUCbHPa();
				TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.Set(vKbvJHaINwPJnYGLBEoubaXghCC);
				TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.Use();
				if (tKHPgJVsdrQQjIgOmOzDCJwSQLI != EditorPlatform.None)
				{
					TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.getValueDelegate = () => isUnityEditorFocused && isAllowedEditorWindowFocused;
					if (FNduOFCXOwBVgaDNutaejQNnbtS)
					{
						vKbvJHaINwPJnYGLBEoubaXghCC = isEditorGameViewFocused;
					}
					TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				YrkYozVGQEWvmRPIJfZyLIYrBkwJ();
				GdScAUHhKJPBbEtzwXeCebgMFHH = new TimerAbs(1.0);
				NhAnIGdoBfzjyelOkjCyJAbIjsl = new qgMpmwaNoBbphajSwDKVeBKVjPxm();
				PAbUpYFMZtjayxnHyKlxbrwjrok(P_1);
				XVroGTnTmiTwGITDVAhlDMsuaLiG = new uXNRyMOantFPUprJgkJntGqFAgR(P_4.GetActions_Copy());
				AkpZeTvTvDWYnEqWDyDWrcufUCI = new wdexXznqMQgvrkdYBfwPPJZVQDx(P_2, XZkCtazuKqRFXBDaYdGEgUNVjfjj);
				yIRdWijqyghmemPssevxkoxocsUE = new YOrqWFzXKZXgaAwGZbhDkecGRxO(P_2);
				XZkCtazuKqRFXBDaYdGEgUNVjfjj.DeviceConnectedEvent += zVlkbQhyYMfvatuGXmLzHuorLrk;
				XZkCtazuKqRFXBDaYdGEgUNVjfjj.DeviceDisconnectedEvent += UOaFizsidSMFGVJXTgZuxYVGNLv;
				XZkCtazuKqRFXBDaYdGEgUNVjfjj.UpdateControllerInfoEvent += AgzgMNeMwBsMjDKLwolGIFEnFAYB;
				AkpZeTvTvDWYnEqWDyDWrcufUCI.ControllerDisconnectStartedEvent += fdFmOKsIBWZDDubGKiQcUPhOAf;
				AkpZeTvTvDWYnEqWDyDWrcufUCI.JustBeforeControllerFullyDisconnectedEvent += yIRdWijqyghmemPssevxkoxocsUE.vgIatAEAoUywaMBdvLtOaZztCNeG;
				ThreadSafeUnityInput.PostInitialize();
				sTZNlWYOioeBcvCSmCWGAqLnOrxc();
				ThreadSafeUnityInput.PostInitialize2();
				SWwFvmLUBcxdThqhZtFnAICjSyK = UnityTools.GetComponent<UserDataStore>(OayGWMjwwAWqSvvHJSLxyoWuEsp);
				if (SWwFvmLUBcxdThqhZtFnAICjSyK != null)
				{
					SWwFvmLUBcxdThqhZtFnAICjSyK.Initialize();
				}
				bkNvRhmhbobOufrgJHfRbfCbcrl();
				sOnDuWbBPgngqdqgfrBPEhfbAIiL = false;
				if (FNduOFCXOwBVgaDNutaejQNnbtS)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (eLNfANJDtfMJKiXgBkfTmKBiyehW != null)
				{
					eLNfANJDtfMJKiXgBkfTmKBiyehW.Invoke();
				}
			}
			catch (Exception)
			{
				rXobafaxvUDrItlgWahiaYSKJqn = false;
				sOnDuWbBPgngqdqgfrBPEhfbAIiL = false;
				throw;
			}
		}

		internal static void xNRqfCbZrFcpJcVLMCeHrbgeubc()
		{
			if (NhAnIGdoBfzjyelOkjCyJAbIjsl != null)
			{
				NhAnIGdoBfzjyelOkjCyJAbIjsl.wnxemBQKskLTdCdgvkkJbpPFVfL();
			}
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < AkpZeTvTvDWYnEqWDyDWrcufUCI.joystickCount; i++)
				{
					Joystick joystick = AkpZeTvTvDWYnEqWDyDWrcufUCI.Joysticks_readOnly[i];
					ElgmXgECKrJvDmMGslgHjEMormd(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		internal static void ONaxTkghfgMZEieKyHYobhVZYEC(UpdateLoopType P_0)
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				wPrJRBjbAnbDpefVItxWvyqSJuj(P_0);
				switch (P_0)
				{
				case UpdateLoopType.Update:
				case UpdateLoopType.FixedUpdate:
					SUDFogBmsnUiqusbcyxrpkNTnXw();
					break;
				}
			}
		}

		private static void wPrJRBjbAnbDpefVItxWvyqSJuj(UpdateLoopType P_0)
		{
			if (TovKnmdlpWJMDQSDObMGYTYPOu != null)
			{
				TovKnmdlpWJMDQSDObMGYTYPOu.iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
			}
			Action<UpdateLoopType> wdBjYfdLgiAMmOdmfZZetgtNdNZK = WdBjYfdLgiAMmOdmfZZetgtNdNZK;
			if (wdBjYfdLgiAMmOdmfZZetgtNdNZK != null)
			{
				try
				{
					wdBjYfdLgiAMmOdmfZZetgtNdNZK(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.BeforeTimeManagerUpdateEvent", exception);
				}
			}
			NhAnIGdoBfzjyelOkjCyJAbIjsl.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0);
		}

		private static void SUDFogBmsnUiqusbcyxrpkNTnXw()
		{
			int frameCount = Time.frameCount;
			if (TiCDeFxJusdbZzozygrzEdbKLEiH == frameCount)
			{
				return;
			}
			TiCDeFxJusdbZzozygrzEdbKLEiH = frameCount;
			ThreadSafeUnityInput.Update();
			Action byOvuwSdzMgmNDNFXOyaLDYCpYS = ByOvuwSdzMgmNDNFXOyaLDYCpYS;
			if (byOvuwSdzMgmNDNFXOyaLDYCpYS == null)
			{
				return;
			}
			try
			{
				byOvuwSdzMgmNDNFXOyaLDYCpYS();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.EarlyUpdateEvent", exception);
			}
		}

		internal static void iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType P_0)
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
			{
				return;
			}
			if (YOZcZdsiktGyBGLmwdsNcHQrXQS != P_0)
			{
				YOZcZdsiktGyBGLmwdsNcHQrXQS = P_0;
			}
			if (editorPlatform != EditorPlatform.None)
			{
				rwTIEWuvgZFTQrwuHoVeBZzkras = TovKnmdlpWJMDQSDObMGYTYPOu.TYjAESncDtdimoTpjOayjLplaln.value;
			}
			if (lErgspMfHFHpykceGkSMpHLGMyXl)
			{
				if (GdScAUHhKJPBbEtzwXeCebgMFHH.Update())
				{
					lErgspMfHFHpykceGkSMpHLGMyXl = false;
					GdScAUHhKJPBbEtzwXeCebgMFHH.Clear();
				}
				else
				{
					unityInputBuffer.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0);
				}
			}
			TovKnmdlpWJMDQSDObMGYTYPOu.zHfuXPHEaUWOGePPGcHZRMwjmUW();
			Action<UpdateLoopType> yoRxUZuzFddPvgiHNbuzJsCgDUw = YoRxUZuzFddPvgiHNbuzJsCgDUw;
			if (yoRxUZuzFddPvgiHNbuzJsCgDUw != null)
			{
				try
				{
					yoRxUZuzFddPvgiHNbuzJsCgDUw(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.UpdateStartedEvent", exception);
				}
			}
			XZkCtazuKqRFXBDaYdGEgUNVjfjj.Update(P_0);
			if (KTLrwuiGjGUcPQzxFhtPZjyUcXS != null)
			{
				KTLrwuiGjGUcPQzxFhtPZjyUcXS.Invoke();
			}
			AkpZeTvTvDWYnEqWDyDWrcufUCI.iAnBBfDdWbgOiFHwNWqxFDtiXzYA(P_0);
			Action<UpdateLoopType> sYXQPUlccDBPgUGsbXsHDzEiLnG = SYXQPUlccDBPgUGsbXsHDzEiLnG;
			if (sYXQPUlccDBPgUGsbXsHDzEiLnG == null)
			{
				return;
			}
			try
			{
				sYXQPUlccDBPgUGsbXsHDzEiLnG(P_0);
			}
			catch (Exception exception2)
			{
				HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
			}
		}

		internal static void uhNFICcRFahphhyfYyrDCjJvJsh()
		{
			Action action = orbXmxICiYKcwdDZqbQTemUrgZaE;
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
			if (rXobafaxvUDrItlgWahiaYSKJqn && FNduOFCXOwBVgaDNutaejQNnbtS)
			{
				ONaxTkghfgMZEieKyHYobhVZYEC(UpdateLoopType.Update);
				iAnBBfDdWbgOiFHwNWqxFDtiXzYA(UpdateLoopType.Update);
				uhNFICcRFahphhyfYyrDCjJvJsh();
			}
		}

		internal static void QuXVmZoTaWlRqdcUSBPouNfytdU()
		{
			if (WbWjIACjYiiqusiPKXqgMRJepwf != null)
			{
				WbWjIACjYiiqusiPKXqgMRJepwf.Invoke();
			}
			if (XZkCtazuKqRFXBDaYdGEgUNVjfjj != null)
			{
				XZkCtazuKqRFXBDaYdGEgUNVjfjj.OnDestroy();
			}
			XOnLdzAqkHCLybnPowoBTcVXbxw();
			if (OrbORKqRdTlgLDIFaJvsCBnNugY != null)
			{
				OrbORKqRdTlgLDIFaJvsCBnNugY.Invoke();
				OrbORKqRdTlgLDIFaJvsCBnNugY = null;
			}
		}

		internal static void qwDHkKVvhosbitdsRJOyDiqOFHU()
		{
			if (ILBzwpZPstFVKSZiXaYYqxqUjrA != null)
			{
				ILBzwpZPstFVKSZiXaYYqxqUjrA.Invoke();
			}
		}

		internal static void ilyWTiyFMoFXpfCCLKAjzNlzcEtC(bool P_0)
		{
			vKbvJHaINwPJnYGLBEoubaXghCC = P_0;
			if (tKHPgJVsdrQQjIgOmOzDCJwSQLI == EditorPlatform.None && rXobafaxvUDrItlgWahiaYSKJqn)
			{
				TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.Set(P_0);
				TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.TriggerEvent();
			}
		}

		internal static void oZdcqZbQHvJfzLoyDHWTkZjuotaC()
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
			{
				return;
			}
			Action action = dDSmbcSsKZgkJioOYWsDFsBhiycq;
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
			return yVekqoXoalcSjhETOEoiHtqtaHne.RtkcWElSDcQlYJxUsbYIZSfMkCM(bridgedController);
		}

		internal static HardwareJoystickMap oNdHtGaPAUegFfNDYBItOQKRuna(Guid P_0)
		{
			return yVekqoXoalcSjhETOEoiHtqtaHne.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap cLdABFWHhJhGBDqNNUOhtHkebrR(Guid P_0)
		{
			return yVekqoXoalcSjhETOEoiHtqtaHne.GetJoystickTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap ZsypBnQrcIoDtvYqtntJVVagtzG(Guid P_0)
		{
			return yVekqoXoalcSjhETOEoiHtqtaHne.GetControllerTemplate(P_0);
		}

		internal static IList<HardwareJoystickTemplateMap> GUXvLJGdwZfIpEERnhhUakZVWei(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = yVekqoXoalcSjhETOEoiHtqtaHne.GetHardwareJoystickMap(P_0);
			if (hardwareJoystickMap == null)
			{
				return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
			}
			string[] templateGuidsOrig = hardwareJoystickMap.GetTemplateGuidsOrig();
			if (templateGuidsOrig == null || templateGuidsOrig.Length == 0)
			{
				return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
			}
			List<HardwareJoystickTemplateMap> list = null;
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
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = cLdABFWHhJhGBDqNNUOhtHkebrR(guid);
				if (hardwareJoystickTemplateMap == null)
				{
					Logger.LogWarning("Controller Template was not found for GUID " + guid.ToString());
					continue;
				}
				if (list == null)
				{
					list = new List<HardwareJoystickTemplateMap>();
				}
				ListTools.AddIfUnique(list, hardwareJoystickTemplateMap);
			}
			if (list == null)
			{
				return EmptyObjects<HardwareJoystickTemplateMap>.EmptyReadOnlyIListT;
			}
			return list;
		}

		[CustomObfuscation(rename = false)]
		internal static int GetNewJoystickId()
		{
			return AkpZeTvTvDWYnEqWDyDWrcufUCI.gqYOIAJQKjXYVpEcilQGRCMNcumg();
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleCallbackException(string source, Exception exception)
		{
			string msg = "An exception occurred inside an event handler or callback.\nSource: " + source + "\n\nThis happens if your event handler/callback code throws an exception. This means the error in your code, not Rewired. Read the exception message and the stack trace carefully to find the source of the exception being thrown by your code.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed. Make sure you unsubscribe to events in OnDisable or OnDestroy. Rewired will attempt to continue running.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception);
			Logger.LogError(msg, requiredThreadSafety: true);
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternException(string source, Exception exception)
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternalInterfaceException(string source, Exception exception)
		{
			string msg = "An exception occurred inside an external function call.\nSource: " + source + "\n\nThis happens if the external function throws an exception. This could indicate the error is in your code if Rewired is calling a function in an interface implementation you created. Read the exception message and the stack trace carefully to find the source of the exception being thrown.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception);
			Logger.LogError(msg, requiredThreadSafety: true);
		}

		internal static void jvAMkLnjgvMzaGTymYSPSqimDGa()
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				bkNvRhmhbobOufrgJHfRbfCbcrl();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2021 != UnityTools.unityVersionObj.major)
			{
				aFbZhyOylGVqqokfASIfRzdaMMk();
			}
		}

		internal static float KeSFrMJCDAPknwDjEMpWGSdAQAAO()
		{
			return TovKnmdlpWJMDQSDObMGYTYPOu.bOwbxBZSDDDOsweOsGljPaOnTFw.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
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

		private static void sTZNlWYOioeBcvCSmCWGAqLnOrxc()
		{
			yIRdWijqyghmemPssevxkoxocsUE.iDBXctPcOcjjzWbKaCnxuPiVNUc();
			AkpZeTvTvDWYnEqWDyDWrcufUCI.iDBXctPcOcjjzWbKaCnxuPiVNUc(XZkCtazuKqRFXBDaYdGEgUNVjfjj.GetInputDataUpdateDelegate(), lPlxhgNPpsgHbDrFTbwKnGHEkWU.GetInputBehaviors_Copy());
			XZkCtazuKqRFXBDaYdGEgUNVjfjj.Initialize();
		}

		private static void XOnLdzAqkHCLybnPowoBTcVXbxw()
		{
			if (OayGWMjwwAWqSvvHJSLxyoWuEsp != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(OayGWMjwwAWqSvvHJSLxyoWuEsp);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			OayGWMjwwAWqSvvHJSLxyoWuEsp = null;
			XZkCtazuKqRFXBDaYdGEgUNVjfjj = null;
			XVroGTnTmiTwGITDVAhlDMsuaLiG = null;
			if (AkpZeTvTvDWYnEqWDyDWrcufUCI != null)
			{
				AkpZeTvTvDWYnEqWDyDWrcufUCI.Dispose();
			}
			AkpZeTvTvDWYnEqWDyDWrcufUCI = null;
			yIRdWijqyghmemPssevxkoxocsUE = null;
			yVekqoXoalcSjhETOEoiHtqtaHne = null;
			lPlxhgNPpsgHbDrFTbwKnGHEkWU = null;
			DOhvOQuwNPmQpOyDlqTkUfQyEaL = null;
			rXobafaxvUDrItlgWahiaYSKJqn = false;
			LOkMduUeVwqIadHuBlHhVcCnHqW = null;
			YOZcZdsiktGyBGLmwdsNcHQrXQS = UpdateLoopType.Update;
			rVpUCROuewHidvpkltGSoFPvVaG = false;
			vOyhoezlzuDNJkbVrMoXSdBXzawR = Platform.Windows;
			BCOeRMjFOnlSbaKyMghOdWRgLhUr = WebplayerPlatform.None;
			tKHPgJVsdrQQjIgOmOzDCJwSQLI = EditorPlatform.None;
			lErgspMfHFHpykceGkSMpHLGMyXl = false;
			GdScAUHhKJPBbEtzwXeCebgMFHH = null;
			NhAnIGdoBfzjyelOkjCyJAbIjsl = null;
			rwTIEWuvgZFTQrwuHoVeBZzkras = null;
			EZyrsJdTjlHvuSDwTNGMqOMKIJXc = false;
			FNduOFCXOwBVgaDNutaejQNnbtS = false;
			vKbvJHaINwPJnYGLBEoubaXghCC = true;
			TiCDeFxJusdbZzozygrzEdbKLEiH = -1;
			_id = -1;
			BrGUjmcWslLCPvvzxyflOBRuICI = 0;
			pmVAfOknAvafOWhrdgKwGxbiKXq.Clear();
			YBXwrwwFWIHQuokQckkpKVNXobS.Clear();
			QIAkIsJySajRGeOJnLIDRURaYWy.Clear();
			KTLrwuiGjGUcPQzxFhtPZjyUcXS.Clear();
			ILBzwpZPstFVKSZiXaYYqxqUjrA.Clear();
			_ApplicationFocusChangedEvent = null;
			dayTHghmHzeNjkDUArLonoQTvvgn = null;
			GwYWrRDEKqQMZjdftOzCKprfOwr = null;
			HeSIOcIObcdkRcoffhXXltVSUPJr = null;
			PiYoycleRUIKGFkZLXLvgMNvidjH = null;
			ByOvuwSdzMgmNDNFXOyaLDYCpYS = null;
			YoRxUZuzFddPvgiHNbuzJsCgDUw = null;
			SYXQPUlccDBPgUGsbXsHDzEiLnG = null;
			orbXmxICiYKcwdDZqbQTemUrgZaE = null;
			WbWjIACjYiiqusiPKXqgMRJepwf = null;
			dDSmbcSsKZgkJioOYWsDFsBhiycq = null;
			GwaXpAxZClnbMRBUFpVTuTxqKP = null;
			FoumiJnplGFiSXthBGOalKssoTo();
			TovKnmdlpWJMDQSDObMGYTYPOu = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= fkxNLpTOlqyRGrLFwJbRjhMOcLL;
			}
		}

		private static void NNwqpEjUFkjbWXmnTMkNgJDtFyg(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void cAcFqpExkaBiRPPGiHGBvxiIbSLP()
		{
			if (!lErgspMfHFHpykceGkSMpHLGMyXl)
			{
				lErgspMfHFHpykceGkSMpHLGMyXl = true;
				unityInputBuffer.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				unityInputBuffer.haigBPYnEYOHMRhDBFILgYsuyYdT();
			}
			GdScAUHhKJPBbEtzwXeCebgMFHH.Start();
		}

		private static void CIAGYybgsNHgxFZiLAPuIvNZovja()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void zVlkbQhyYMfvatuGXmLzHuorLrk(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			AkpZeTvTvDWYnEqWDyDWrcufUCI.kifwqfIoWOaCtFKBcyaxisrThaZv(P_0);
			Joystick joystick = AkpZeTvTvDWYnEqWDyDWrcufUCI.zCynXQNrFypPOHsukRvftnVVvxv(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				yIRdWijqyghmemPssevxkoxocsUE.cILiesvYEynzhnVKvJDFgUiJtfR(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !sOnDuWbBPgngqdqgfrBPEhfbAIiL)
				{
					ElgmXgECKrJvDmMGslgHjEMormd(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void UOaFizsidSMFGVJXTgZuxYVGNLv(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = AkpZeTvTvDWYnEqWDyDWrcufUCI.zCynXQNrFypPOHsukRvftnVVvxv(P_0.rewiredId);
				if (joystick != null)
				{
					AkpZeTvTvDWYnEqWDyDWrcufUCI.ACEyGymgjawtaxNjGLZPWdlygix(P_0.rewiredId);
					ihQYmNiUzOUFVSgENeJCrXPSpEB(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void ElgmXgECKrJvDmMGslgHjEMormd(ControllerStatusChangedEventArgs P_0)
		{
			if (pmVAfOknAvafOWhrdgKwGxbiKXq != null)
			{
				pmVAfOknAvafOWhrdgKwGxbiKXq.Invoke(P_0);
			}
		}

		private static void fdFmOKsIBWZDDubGKiQcUPhOAf(ControllerStatusChangedEventArgs P_0)
		{
			if (YBXwrwwFWIHQuokQckkpKVNXobS != null)
			{
				YBXwrwwFWIHQuokQckkpKVNXobS.Invoke(P_0);
			}
		}

		private static void ihQYmNiUzOUFVSgENeJCrXPSpEB(ControllerStatusChangedEventArgs P_0)
		{
			if (QIAkIsJySajRGeOJnLIDRURaYWy != null)
			{
				QIAkIsJySajRGeOJnLIDRURaYWy.Invoke(P_0);
			}
		}

		private static void AgzgMNeMwBsMjDKLwolGIFEnFAYB(UpdateControllerInfoEventArgs P_0)
		{
			AkpZeTvTvDWYnEqWDyDWrcufUCI.ktuBhGHQjsvnfuwdpgbumZMATxQ(P_0);
		}

		private static void mmSeCYyGzAcrXjKTdGFrnOLGsGp(bool P_0)
		{
			if (!rXobafaxvUDrItlgWahiaYSKJqn)
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

		private static void teavwZcNBUHmwKNWffgheMXjyImL(bool P_0)
		{
			Action<bool> action = dayTHghmHzeNjkDUArLonoQTvvgn;
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

		private static void nQWcJELweuHaUgSeDFACRrXkBth(int P_0)
		{
			if (HeSIOcIObcdkRcoffhXXltVSUPJr != null)
			{
				try
				{
					HeSIOcIObcdkRcoffhXXltVSUPJr((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void hypZyrFRucqLJexGKFQealgyFFH(bool P_0)
		{
			Action<bool> gwYWrRDEKqQMZjdftOzCKprfOwr = GwYWrRDEKqQMZjdftOzCKprfOwr;
			if (gwYWrRDEKqQMZjdftOzCKprfOwr != null)
			{
				try
				{
					gwYWrRDEKqQMZjdftOzCKprfOwr(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationRunInBackgroundChangedEvent", exception);
				}
			}
		}

		private static void VwwVNaQDpimCbTCvRIVeoeHwGma(bool P_0)
		{
			BrGUjmcWslLCPvvzxyflOBRuICI++;
			Action<bool> piYoycleRUIKGFkZLXLvgMNvidjH = PiYoycleRUIKGFkZLXLvgMNvidjH;
			if (piYoycleRUIKGFkZLXLvgMNvidjH != null)
			{
				try
				{
					piYoycleRUIKGFkZLXLvgMNvidjH(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void YrkYozVGQEWvmRPIJfZyLIYrBkwJ()
		{
			if (TovKnmdlpWJMDQSDObMGYTYPOu != null)
			{
				FoumiJnplGFiSXthBGOalKssoTo();
				TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.ChangedEvent += mmSeCYyGzAcrXjKTdGFrnOLGsGp;
				TovKnmdlpWJMDQSDObMGYTYPOu.DTfsbNwKAnJRGCVMonjAjpBkhhP.ChangedEvent += teavwZcNBUHmwKNWffgheMXjyImL;
				TovKnmdlpWJMDQSDObMGYTYPOu.apPWrEWoQKEcqRyIjtpZSwZuCze.ChangedEvent += hypZyrFRucqLJexGKFQealgyFFH;
				TovKnmdlpWJMDQSDObMGYTYPOu.owppUzdnQgKqwtfIzlCJmdPiokr.ChangedEvent += nQWcJELweuHaUgSeDFACRrXkBth;
				TovKnmdlpWJMDQSDObMGYTYPOu.xHHoAHXprddqJfNNjjEEthmYSLY.ChangedEvent += VwwVNaQDpimCbTCvRIVeoeHwGma;
			}
		}

		private static void FoumiJnplGFiSXthBGOalKssoTo()
		{
			if (TovKnmdlpWJMDQSDObMGYTYPOu != null)
			{
				TovKnmdlpWJMDQSDObMGYTYPOu.VSXlKYVwWdZqgUfXaEfHIKNeFWd.ChangedEvent -= mmSeCYyGzAcrXjKTdGFrnOLGsGp;
				TovKnmdlpWJMDQSDObMGYTYPOu.DTfsbNwKAnJRGCVMonjAjpBkhhP.ChangedEvent -= teavwZcNBUHmwKNWffgheMXjyImL;
				TovKnmdlpWJMDQSDObMGYTYPOu.apPWrEWoQKEcqRyIjtpZSwZuCze.ChangedEvent -= hypZyrFRucqLJexGKFQealgyFFH;
				TovKnmdlpWJMDQSDObMGYTYPOu.owppUzdnQgKqwtfIzlCJmdPiokr.ChangedEvent -= nQWcJELweuHaUgSeDFACRrXkBth;
				TovKnmdlpWJMDQSDObMGYTYPOu.xHHoAHXprddqJfNNjjEEthmYSLY.ChangedEvent -= VwwVNaQDpimCbTCvRIVeoeHwGma;
			}
		}

		private static void fkxNLpTOlqyRGrLFwJbRjhMOcLL(bool P_0)
		{
			Action<bool> gwaXpAxZClnbMRBUFpVTuTxqKP = GwaXpAxZClnbMRBUFpVTuTxqKP;
			if (gwaXpAxZClnbMRBUFpVTuTxqKP != null)
			{
				try
				{
					gwaXpAxZClnbMRBUFpVTuTxqKP(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.EditorPauseChangedEvent", exception);
				}
			}
		}

		private static void PAbUpYFMZtjayxnHyKlxbrwjrok(Func<ConfigVars, object> P_0)
		{
			bool flag = configVars.DoesPlatformUseFallback(UnityTools.platform, UnityTools.webplayerPlatform, isEditor);
			if (!flag)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(OayGWMjwwAWqSvvHJSLxyoWuEsp);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(UnityTools.platform, LOkMduUeVwqIadHuBlHhVcCnHqW) is PlatformInputManager xZkCtazuKqRFXBDaYdGEgUNVjfjj)
					{
						XZkCtazuKqRFXBDaYdGEgUNVjfjj = xZkCtazuKqRFXBDaYdGEgUNVjfjj;
						return;
					}
				}
			}
			if (flag)
			{
				rVpUCROuewHidvpkltGSoFPvVaG = true;
				XZkCtazuKqRFXBDaYdGEgUNVjfjj = new QemWyoLGGeGnGWjMJDNDbwJbBhZU(LOkMduUeVwqIadHuBlHhVcCnHqW.updateLoop);
			}
			else if (configVars.DoesPlatformUseSDL2(UnityTools.platform, UnityTools.webplayerPlatform, isEditor))
			{
				try
				{
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = new hZHOVsmymPDAABKKFBfRVMYmptx(LOkMduUeVwqIadHuBlHhVcCnHqW, GetHardwareJoystickMap_InputManager, GetNewJoystickId, handleJoysticks: true, handleUnifiedMouse: false, handleUnifiedKeyboard: false);
					if (XZkCtazuKqRFXBDaYdGEgUNVjfjj == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = null;
				}
			}
			else if (UnityTools.platform == Platform.Windows || UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.WindowsUWP || UnityTools.platform == Platform.OSX || UnityTools.platform == Platform.Linux)
			{
				XZkCtazuKqRFXBDaYdGEgUNVjfjj = P_0(LOkMduUeVwqIadHuBlHhVcCnHqW) as PlatformInputManager;
			}
			else if (UnityTools.platform == Platform.WebGL && !isEditor)
			{
				try
				{
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = P_0(LOkMduUeVwqIadHuBlHhVcCnHqW) as PlatformInputManager;
					if (XZkCtazuKqRFXBDaYdGEgUNVjfjj == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = null;
				}
			}
			else if (UnityTools.platform == Platform.XboxOne && !isEditor)
			{
				try
				{
					XboxOneInputSource customInputSource = new XboxOneInputSource();
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = new CustomInputManager(customInputSource, LOkMduUeVwqIadHuBlHhVcCnHqW.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (XZkCtazuKqRFXBDaYdGEgUNVjfjj == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = null;
				}
			}
			else if (UnityTools.platform == Platform.PS4 && !isEditor)
			{
				try
				{
					PS4InputSource customInputSource2 = new PS4InputSource();
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = new CustomInputManager(customInputSource2, LOkMduUeVwqIadHuBlHhVcCnHqW.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (XZkCtazuKqRFXBDaYdGEgUNVjfjj == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("PS4 platform could not be initialized!");
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = null;
				}
			}
			else if (UnityTools.platform == Platform.Stadia && !isEditor)
			{
				try
				{
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = P_0(LOkMduUeVwqIadHuBlHhVcCnHqW) as PlatformInputManager;
					if (XZkCtazuKqRFXBDaYdGEgUNVjfjj == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("Stadia platform could not be initialized! Is the Rewired Stadia library installed? See the documentation for more information.");
					Logger.LogError(msg);
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = null;
				}
			}
			else if ((UnityTools.platform == Platform.GameCoreXboxOne || UnityTools.platform == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = P_0(LOkMduUeVwqIadHuBlHhVcCnHqW) as PlatformInputManager;
					if (XZkCtazuKqRFXBDaYdGEgUNVjfjj == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					string text = ((UnityTools.platform == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg2);
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = null;
				}
			}
			else if (UnityTools.platform == Platform.Ouya && !isEditor)
			{
				try
				{
					Type typeInUnityBuildAssembly = ReflectionTools.GetTypeInUnityBuildAssembly("OuyaSDK", ignoreCase: true);
					if ((object)typeInUnityBuildAssembly == null)
					{
						Logger.LogError("OuyaEverywhereSDK was not found! Input may not function. See the documentation for building to the Ouya platform.");
						throw new Exception();
					}
					typeInUnityBuildAssembly = ReflectionTools.GetTypeInUnityBuildAssembly("Rewired.Platforms.Ouya.OuyaInputSource", ignoreCase: true);
					if ((object)typeInUnityBuildAssembly == null)
					{
						Logger.LogError("Required files for Ouya support are missing. Input may not function. Please completely reinstall Rewired.");
						throw new Exception();
					}
					CustomInputSource customInputSource3 = (CustomInputSource)Assembly.GetAssembly(typeInUnityBuildAssembly).CreateInstance(typeInUnityBuildAssembly.FullName, ignoreCase: false);
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = new CustomInputManager(customInputSource3, LOkMduUeVwqIadHuBlHhVcCnHqW.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (XZkCtazuKqRFXBDaYdGEgUNVjfjj == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Ouya platform could not be initialized! Please see the documentation for required dependencies. Rewired will fall back to Unity input. All features may not be available.");
					XZkCtazuKqRFXBDaYdGEgUNVjfjj = null;
				}
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.androidFallbackPlatformHelper = P_0(LOkMduUeVwqIadHuBlHhVcCnHqW) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg3)
				{
					Logger.LogError(msg3);
				}
			}
			if (XZkCtazuKqRFXBDaYdGEgUNVjfjj == null)
			{
				rVpUCROuewHidvpkltGSoFPvVaG = true;
				XZkCtazuKqRFXBDaYdGEgUNVjfjj = new QemWyoLGGeGnGWjMJDNDbwJbBhZU(LOkMduUeVwqIadHuBlHhVcCnHqW.updateLoop);
			}
		}

		private static void bkNvRhmhbobOufrgJHfRbfCbcrl()
		{
			if (EZyrsJdTjlHvuSDwTNGMqOMKIJXc != LOkMduUeVwqIadHuBlHhVcCnHqW.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				EZyrsJdTjlHvuSDwTNGMqOMKIJXc = !EZyrsJdTjlHvuSDwTNGMqOMKIJXc;
			}
		}

		private static void aFbZhyOylGVqqokfASIfRzdaMMk()
		{
			if (!(UnityTools.unityVersionObj == null))
			{
				Logger.LogWarning("The version of Rewired installed (" + programVersion + ") was not designed for Unity " + UnityTools.unityVersionObj.major + ". Please install Rewired for Unity " + UnityTools.unityVersionObj.major + ".\n\nThis warning does not mean that Rewired will not function, but it may not function optimally.\n\nSome different major versions of Unity download Asset Store assets to the same folder location on disk, so if you download an asset in one version of the Unity editor, then open another version of the Unity editor and install the asset without re-downloading it, the wrong asset version will be installed. To fix this, manually re-download Rewired in the Unity Asset Store panel in this version of the Unity Editor, then install it.\n\nIf you are using a beta version of a new major version of Unity, you will have to wait until the release of the final version before a compatible version of Rewired can be uploaded to the Asset Store. When the new version is ready, it will be available through the Unity Asset Store for download as usual.");
			}
		}

		[CompilerGenerated]
		private static void aQJtWCpXsmcYuAFtjnTSDEYBTuQ(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void ZIJfrJcplnovQTGcTWakaunoYie(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
		}

		[CompilerGenerated]
		private static void seJJFHLoEmxrwSbdToEMUQGeOZf(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void TGNcLPKDkoOnhsAjBYcoKbcNUbLA(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
		}

		[CompilerGenerated]
		private static void dlxbdupXjxOAAIzYGkYrsrgYnRi(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
		}

		[CompilerGenerated]
		private static void aonjnhcitnfHikzluQkvSMfKBFba(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void iGeyPcPtwRPudMAFKLJCjmOgbqlD(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void kAoJVJNXNPBAAOHNOboSHEnxPxQ(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
		}

		[CompilerGenerated]
		private static void wNKMjVICxdzomdicsBfIKgsvaVo(Exception P_0)
		{
			HandleCallbackException("", P_0);
		}

		[CompilerGenerated]
		private static bool YCzvWVvklztTZPwHCszzJfuiFDV()
		{
			if (isUnityEditorFocused)
			{
				return isAllowedEditorWindowFocused;
			}
			return false;
		}
	}
}
