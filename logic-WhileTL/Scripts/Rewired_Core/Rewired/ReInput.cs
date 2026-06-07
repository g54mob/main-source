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
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			private float gdubZwjnsOWnYyJWNnQjdJsrNodj = 0.7f;

			private float XIBdCgfETWQefFqzyaBhSDtmhvYR = 100f;

			internal static ConfigHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => WjQAaHwnldjGbWthvILYYAgChYHq ?? (WjQAaHwnldjGbWthvILYYAgChYHq = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.platform == Platform.Windows && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						return (dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
					}
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.useXInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
						if (platformVars_WindowsUWP.useGamepadAPI != value)
						{
							platformVars_WindowsUWP.useGamepadAPI = value;
							if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
							{
								CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
							}
						}
					}
					else if (dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.useXInput != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.useXInput = value;
						if (!value && UnityTools.platform == Platform.Windows && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.Log("The primary input source has been changed to Raw Input.");
						}
						else if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.updateLoop = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.platform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.useXInput = true;
						}
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.osx_primaryInputSource != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.osx_primaryInputSource = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.linux_primaryInputSource != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.linux_primaryInputSource = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.windowsUWP_primaryInputSource = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return (dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.xboxOne_primaryInputSource != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.xboxOne_primaryInputSource = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.ps4_primaryInputSource != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.ps4_primaryInputSource = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.webGL_primaryInputSource != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.webGL_primaryInputSource = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.alwaysUseUnityInput != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.alwaysUseUnityInput = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.SetPlatformVar_useNativeMouse(value) && CVOosweFQkjenKNkyCghUKMwQzfI != null)
					{
						CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && CVOosweFQkjenKNkyCghUKMwQzfI != null)
					{
						CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && CVOosweFQkjenKNkyCghUKMwQzfI != null)
					{
						CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.GetPlatformVar_joystickRefreshRate();
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
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						pvgucvcpEBlNTxuHHBVNqzamlReP();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.android_supportUnknownGamepads != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.android_supportUnknownGamepads = value;
						if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
						{
							CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.defaultAxisSensitivityType != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.defaultAxisSensitivityType = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.force4WayHats != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.force4WayHats = value;
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
					return gdubZwjnsOWnYyJWNnQjdJsrNodj;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (gdubZwjnsOWnYyJWNnQjdJsrNodj != value)
						{
							gdubZwjnsOWnYyJWNnQjdJsrNodj = value;
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
					return XIBdCgfETWQefFqzyaBhSDtmhvYR;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (XIBdCgfETWQefFqzyaBhSDtmhvYR != value)
						{
							XIBdCgfETWQefFqzyaBhSDtmhvYR = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.activateActionButtonsOnNegativeValue = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.throttleCalibrationMode != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.throttleCalibrationMode = value;
						OkLkjfkBGntRAvakyAvYRRgphMAiA.wQZGevvrMLHzUDzCAUZWIvSLcdmg(value);
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.autoAssignJoysticks != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.autoAssignJoysticks = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.maxJoysticksPerPlayer != value)
						{
							dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.maxJoysticksPerPlayer = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.distributeJoysticksEvenly != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.distributeJoysticksEvenly = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.logLevel != value)
					{
						dhXuTEEziWFtUyjdydeOTtEMceSv.ConfigVars.logLevel = value;
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
				private sealed class ojyDkFcbSxpEoeAKgvBLZDFhfCUG : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public ojyDkFcbSxpEoeAKgvBLZDFhfCUG(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (GwbUsvLqBorYvZEWvPDttSzVhFNo)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								yizRLbsgxDTsbmoshgCidPKZUtUx();
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
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.kuupDKpzqIzRQUJLxmVOVonVOxcE().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0084;
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0084;
							case 2:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e4;
							case 3:
								{
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
									break;
								}
								IL_00e4:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
									return true;
								}
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.UpPqyUhkWnRbFwCZwnjTGqKWVKbW().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
								break;
								IL_0084:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current2 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current2;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
									return true;
								}
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.aNECRxgTvdIxEuDrjWbXdFsyQYvkA().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e4;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current3 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current3;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 3;
								return true;
							}
							yizRLbsgxDTsbmoshgCidPKZUtUx();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						ojyDkFcbSxpEoeAKgvBLZDFhfCUG ojyDkFcbSxpEoeAKgvBLZDFhfCUG2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							ojyDkFcbSxpEoeAKgvBLZDFhfCUG2 = this;
						}
						else
						{
							ojyDkFcbSxpEoeAKgvBLZDFhfCUG2 = new ojyDkFcbSxpEoeAKgvBLZDFhfCUG(0);
							ojyDkFcbSxpEoeAKgvBLZDFhfCUG2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return ojyDkFcbSxpEoeAKgvBLZDFhfCUG2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class WYHEzAHAquSOHSdtvEhCPghiSxpK : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public WYHEzAHAquSOHSdtvEhCPghiSxpK(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (GwbUsvLqBorYvZEWvPDttSzVhFNo)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								yizRLbsgxDTsbmoshgCidPKZUtUx();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								eIxpVKZXEDbBSXUMQCuCQdVlCiWaA();
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
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.ntSVuvEKSOIBzXFeKRpYkOMKJJpW().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0088;
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0088;
							case 2:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e8;
							case 3:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
								goto IL_0148;
							case 4:
								{
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -6;
									break;
								}
								IL_00e8:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
									return true;
								}
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.CgOhupIcrKhbfzOvEhqFojuLLkjp().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
								goto IL_0148;
								IL_0088:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current2 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current2;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
									return true;
								}
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.ULtaVEESJmqfDbraMhrzPodihJNDA().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e8;
								IL_0148:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current3 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current3;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 3;
									return true;
								}
								yizRLbsgxDTsbmoshgCidPKZUtUx();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.qVOfhPqHAmewrWNjBWivQlBINRnM().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -6;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current4 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current4;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 4;
								return true;
							}
							eIxpVKZXEDbBSXUMQCuCQdVlCiWaA();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void eIxpVKZXEDbBSXUMQCuCQdVlCiWaA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						WYHEzAHAquSOHSdtvEhCPghiSxpK wYHEzAHAquSOHSdtvEhCPghiSxpK;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							wYHEzAHAquSOHSdtvEhCPghiSxpK = this;
						}
						else
						{
							wYHEzAHAquSOHSdtvEhCPghiSxpK = new WYHEzAHAquSOHSdtvEhCPghiSxpK(0);
							wYHEzAHAquSOHSdtvEhCPghiSxpK.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return wYHEzAHAquSOHSdtvEhCPghiSxpK;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class MHacWYTrMrzxQLRVxdPDtmipMvgg : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public MHacWYTrMrzxQLRVxdPDtmipMvgg(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (GwbUsvLqBorYvZEWvPDttSzVhFNo)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								yizRLbsgxDTsbmoshgCidPKZUtUx();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								eIxpVKZXEDbBSXUMQCuCQdVlCiWaA();
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
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.KmWZqXFjZMlaFOFQirvAmUjMBOoi().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0088;
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0088;
							case 2:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e8;
							case 3:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
								goto IL_0148;
							case 4:
								{
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -6;
									break;
								}
								IL_00e8:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
									return true;
								}
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.wnFkpRdMAAeDUMnvXkXhVbQrtMWx().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
								goto IL_0148;
								IL_0088:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current2 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current2;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
									return true;
								}
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.klEGtgXqpcnAfMgCcWTxSOsmdWkb().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e8;
								IL_0148:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current3 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current3;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 3;
									return true;
								}
								yizRLbsgxDTsbmoshgCidPKZUtUx();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.KQOSGgLIEeSOXecyJTvxjcRkQpir().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -6;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current4 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current4;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 4;
								return true;
							}
							eIxpVKZXEDbBSXUMQCuCQdVlCiWaA();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void eIxpVKZXEDbBSXUMQCuCQdVlCiWaA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						MHacWYTrMrzxQLRVxdPDtmipMvgg mHacWYTrMrzxQLRVxdPDtmipMvgg;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							mHacWYTrMrzxQLRVxdPDtmipMvgg = this;
						}
						else
						{
							mHacWYTrMrzxQLRVxdPDtmipMvgg = new MHacWYTrMrzxQLRVxdPDtmipMvgg(0);
							mHacWYTrMrzxQLRVxdPDtmipMvgg.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return mHacWYTrMrzxQLRVxdPDtmipMvgg;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class TFrVvqEKxuCvPaKrekJexogtYqfv : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public TFrVvqEKxuCvPaKrekJexogtYqfv(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (GwbUsvLqBorYvZEWvPDttSzVhFNo)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								yizRLbsgxDTsbmoshgCidPKZUtUx();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								eIxpVKZXEDbBSXUMQCuCQdVlCiWaA();
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
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.wydrzWDnlpVBVEbRWzHPiqLZvimr().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0088;
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0088;
							case 2:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e8;
							case 3:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
								goto IL_0148;
							case 4:
								{
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -6;
									break;
								}
								IL_00e8:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
									return true;
								}
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.bSseUnOHIWiSfbOImWOjQdnBeeSab().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
								goto IL_0148;
								IL_0088:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current2 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current2;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
									return true;
								}
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.ULtaVEESJmqfDbraMhrzPodihJNDA().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e8;
								IL_0148:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current3 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current3;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 3;
									return true;
								}
								yizRLbsgxDTsbmoshgCidPKZUtUx();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.FUFeTXEnsdlGKxZULrzYgWhlRliEA().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -6;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current4 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current4;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 4;
								return true;
							}
							eIxpVKZXEDbBSXUMQCuCQdVlCiWaA();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void eIxpVKZXEDbBSXUMQCuCQdVlCiWaA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						TFrVvqEKxuCvPaKrekJexogtYqfv tFrVvqEKxuCvPaKrekJexogtYqfv;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							tFrVvqEKxuCvPaKrekJexogtYqfv = this;
						}
						else
						{
							tFrVvqEKxuCvPaKrekJexogtYqfv = new TFrVvqEKxuCvPaKrekJexogtYqfv(0);
							tFrVvqEKxuCvPaKrekJexogtYqfv.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return tFrVvqEKxuCvPaKrekJexogtYqfv;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class fZkBdeMDgDXiiEBDIcjmSntvzmyw : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					public PollingHelper GZXxEqHwrHYIyUJtInpLwgTukJaY;

					private IEnumerator<ControllerPollingInfo> otVuTclWHkLrdVIElDnnPoApusjv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public fZkBdeMDgDXiiEBDIcjmSntvzmyw(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (GwbUsvLqBorYvZEWvPDttSzVhFNo)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								yizRLbsgxDTsbmoshgCidPKZUtUx();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								eIxpVKZXEDbBSXUMQCuCQdVlCiWaA();
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
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							PollingHelper gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
							switch (gwbUsvLqBorYvZEWvPDttSzVhFNo)
							{
							default:
								return false;
							case 0:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.TPWIHjQClyZpndrKcjszPaqjKscv().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0088;
							case 1:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0088;
							case 2:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e8;
							case 3:
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
								goto IL_0148;
							case 4:
								{
									GwbUsvLqBorYvZEWvPDttSzVhFNo = -6;
									break;
								}
								IL_00e8:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 2;
									return true;
								}
								cjHgXFFYGWhdIQKUJynxjVusYouQA();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.hfcNcDmbtLKyvvHvvJlkyvKCMFri().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -5;
								goto IL_0148;
								IL_0088:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current2 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current2;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
									return true;
								}
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.klEGtgXqpcnAfMgCcWTxSOsmdWkb().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -4;
								goto IL_00e8;
								IL_0148:
								if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
								{
									ControllerPollingInfo current3 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
									USjDTWbJtWhEBdYYYfLUglTcnnGrA = current3;
									GwbUsvLqBorYvZEWvPDttSzVhFNo = 3;
									return true;
								}
								yizRLbsgxDTsbmoshgCidPKZUtUx();
								otVuTclWHkLrdVIElDnnPoApusjv = null;
								otVuTclWHkLrdVIElDnnPoApusjv = gZXxEqHwrHYIyUJtInpLwgTukJaY.rxkozAGDxDRznZgNovkNfzIMWBDW().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -6;
								break;
							}
							if (otVuTclWHkLrdVIElDnnPoApusjv.MoveNext())
							{
								ControllerPollingInfo current4 = otVuTclWHkLrdVIElDnnPoApusjv.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current4;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 4;
								return true;
							}
							eIxpVKZXEDbBSXUMQCuCQdVlCiWaA();
							otVuTclWHkLrdVIElDnnPoApusjv = null;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void cjHgXFFYGWhdIQKUJynxjVusYouQA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void yizRLbsgxDTsbmoshgCidPKZUtUx()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
						}
					}

					private void eIxpVKZXEDbBSXUMQCuCQdVlCiWaA()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (otVuTclWHkLrdVIElDnnPoApusjv != null)
						{
							otVuTclWHkLrdVIElDnnPoApusjv.Dispose();
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
						fZkBdeMDgDXiiEBDIcjmSntvzmyw fZkBdeMDgDXiiEBDIcjmSntvzmyw2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							fZkBdeMDgDXiiEBDIcjmSntvzmyw2 = this;
						}
						else
						{
							fZkBdeMDgDXiiEBDIcjmSntvzmyw2 = new fZkBdeMDgDXiiEBDIcjmSntvzmyw(0);
							fZkBdeMDgDXiiEBDIcjmSntvzmyw2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
						}
						return fZkBdeMDgDXiiEBDIcjmSntvzmyw2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class rorzAYagVFDagiEVMbwTPVzdZRPtA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public rorzAYagVFDagiEVMbwTPVzdZRPtA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = aafAjXCVQhgjOdPPxNvbSSUPrlbR[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllAxes().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new rorzAYagVFDagiEVMbwTPVzdZRPtA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class DhoKvVkHvsCjmrbmsbKyiabXFnEHA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public DhoKvVkHvsCjmrbmsbKyiabXFnEHA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = aafAjXCVQhgjOdPPxNvbSSUPrlbR[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllButtons().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new DhoKvVkHvsCjmrbmsbKyiabXFnEHA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class CYNIgDYEcVvZknNlypIuGMsRDQUdA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public CYNIgDYEcVvZknNlypIuGMsRDQUdA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = aafAjXCVQhgjOdPPxNvbSSUPrlbR[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllButtonsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new CYNIgDYEcVvZknNlypIuGMsRDQUdA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class bAGSrMWdqiINvCalrCIiBBRgEgyN : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public bAGSrMWdqiINvCalrCIiBBRgEgyN(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = aafAjXCVQhgjOdPPxNvbSSUPrlbR[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllElements().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new bAGSrMWdqiINvCalrCIiBBRgEgyN(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class FoGlGWLjBueEYxannYBzCQBMXGwD : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<CustomController> aafAjXCVQhgjOdPPxNvbSSUPrlbR;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public FoGlGWLjBueEYxannYBzCQBMXGwD(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							aafAjXCVQhgjOdPPxNvbSSUPrlbR = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < aafAjXCVQhgjOdPPxNvbSSUPrlbR.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = aafAjXCVQhgjOdPPxNvbSSUPrlbR[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllElementsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new FoGlGWLjBueEYxannYBzCQBMXGwD(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class LvCfSixmFUGGbWSeNgORiFufbEkv : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public LvCfSixmFUGGbWSeNgORiFufbEkv(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < UIhbyKfYtNBZjDUqliRDlZLkiScK.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = UIhbyKfYtNBZjDUqliRDlZLkiScK[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllAxes().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new LvCfSixmFUGGbWSeNgORiFufbEkv(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class fEkAqFFHZsbPhZHqTxQhgDgHkdbMA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public fEkAqFFHZsbPhZHqTxQhgDgHkdbMA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < UIhbyKfYtNBZjDUqliRDlZLkiScK.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = UIhbyKfYtNBZjDUqliRDlZLkiScK[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllButtons().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new fEkAqFFHZsbPhZHqTxQhgDgHkdbMA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class QTeXEpbuWgcmUSlSEEhPHasTSJwGA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public QTeXEpbuWgcmUSlSEEhPHasTSJwGA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < UIhbyKfYtNBZjDUqliRDlZLkiScK.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = UIhbyKfYtNBZjDUqliRDlZLkiScK[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllButtonsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new QTeXEpbuWgcmUSlSEEhPHasTSJwGA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class khuJFCEGWUbOCEUUHHzPWXxgCvIk : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public khuJFCEGWUbOCEUUHHzPWXxgCvIk(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < UIhbyKfYtNBZjDUqliRDlZLkiScK.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = UIhbyKfYtNBZjDUqliRDlZLkiScK[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllElements().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new khuJFCEGWUbOCEUUHHzPWXxgCvIk(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class upxMaQkbFgGMiDDgsuvsAMCjKjLz : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ControllerPollingInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private IList<Joystick> UIhbyKfYtNBZjDUqliRDlZLkiScK;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ControllerPollingInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public upxMaQkbFgGMiDDgsuvsAMCjKjLz(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_0086;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							UIhbyKfYtNBZjDUqliRDlZLkiScK = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_00b0;
							IL_0086:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ControllerPollingInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
							goto IL_00b0;
							IL_00b0:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < UIhbyKfYtNBZjDUqliRDlZLkiScK.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = UIhbyKfYtNBZjDUqliRDlZLkiScK[eolRghqutZOOIGqvOFTzJOGfYTsn].PollForAllElementsDown().GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							return this;
						}
						return new upxMaQkbFgGMiDDgsuvsAMCjKjLz(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private static PollingHelper WjQAaHwnldjGbWthvILYYAgChYHq;

				internal static PollingHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => WjQAaHwnldjGbWthvILYYAgChYHq ?? (WjQAaHwnldjGbWthvILYYAgChYHq = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = LmCCtDIwlaCJxvyeVOIcdGXStBwKA();
					if (result.success)
					{
						return result;
					}
					result = tTcTpZtooBSnURBfRqwLSbjujuaE();
					if (result.success)
					{
						return result;
					}
					result = PoFgtZdPjGCJOIrJBmGogpiAalkf();
					if (result.success)
					{
						return result;
					}
					result = QrZwrFYntBxbzmVMFdWwoGjhPhbt();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = NLAqwwcVeQAFylvkVATfsKXonfxT();
					if (result.success)
					{
						return result;
					}
					result = CxMGZpAJbEoXeXyMMiRsRtkVxmYhA();
					if (result.success)
					{
						return result;
					}
					result = EDKIaPiqBGEcZBwOHJFQiQpNsxnu();
					if (result.success)
					{
						return result;
					}
					result = dOogWtGRTNTWKToFNDTyVXMbxHpO();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = lQpAvvzDrddilGPtTfxaaPyhkPhnc();
					if (result.success)
					{
						return result;
					}
					result = tTcTpZtooBSnURBfRqwLSbjujuaE();
					if (result.success)
					{
						return result;
					}
					result = YJkTxoYUIqmURpYBEKhJVmPwBJIH();
					if (result.success)
					{
						return result;
					}
					result = JJnFilLfLRmWzvZcjAyBtncumIKi();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = hFeKUCpfSEghxHjtsKtNScwBpCtEb();
					if (result.success)
					{
						return result;
					}
					result = CxMGZpAJbEoXeXyMMiRsRtkVxmYhA();
					if (result.success)
					{
						return result;
					}
					result = wWmcUNvOElUYXQSGOgqHskSYKmRX();
					if (result.success)
					{
						return result;
					}
					result = nsnDqPkTWYRhBjUVRlLQIcJJqEsIc();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					ControllerPollingInfo result = qWJTWzUSmTbOBDUgekTSYbTASvcK();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					if (result.success)
					{
						return result;
					}
					result = OLGGVbOoPzFfzkuSaBfROOhrrMzM();
					if (result.success)
					{
						return result;
					}
					result = EJrRvJQyAHmTWrRypumjyNJPxAxU();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => LmCCtDIwlaCJxvyeVOIcdGXStBwKA(), 
						ControllerType.Keyboard => tTcTpZtooBSnURBfRqwLSbjujuaE(), 
						ControllerType.Mouse => PoFgtZdPjGCJOIrJBmGogpiAalkf(), 
						ControllerType.Custom => QrZwrFYntBxbzmVMFdWwoGjhPhbt(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => NLAqwwcVeQAFylvkVATfsKXonfxT(), 
						ControllerType.Keyboard => CxMGZpAJbEoXeXyMMiRsRtkVxmYhA(), 
						ControllerType.Mouse => EDKIaPiqBGEcZBwOHJFQiQpNsxnu(), 
						ControllerType.Custom => dOogWtGRTNTWKToFNDTyVXMbxHpO(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => lQpAvvzDrddilGPtTfxaaPyhkPhnc(), 
						ControllerType.Keyboard => tTcTpZtooBSnURBfRqwLSbjujuaE(), 
						ControllerType.Mouse => YJkTxoYUIqmURpYBEKhJVmPwBJIH(), 
						ControllerType.Custom => JJnFilLfLRmWzvZcjAyBtncumIKi(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => hFeKUCpfSEghxHjtsKtNScwBpCtEb(), 
						ControllerType.Keyboard => CxMGZpAJbEoXeXyMMiRsRtkVxmYhA(), 
						ControllerType.Mouse => wWmcUNvOElUYXQSGOgqHskSYKmRX(), 
						ControllerType.Custom => nsnDqPkTWYRhBjUVRlLQIcJJqEsIc(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => qWJTWzUSmTbOBDUgekTSYbTASvcK(), 
						ControllerType.Keyboard => ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV(), 
						ControllerType.Mouse => OLGGVbOoPzFfzkuSaBfROOhrrMzM(), 
						ControllerType.Custom => EJrRvJQyAHmTWrRypumjyNJPxAxU(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => ZFQPSDJcKZhWWHjXyOvBmZRuBmLmA(controllerId), 
						ControllerType.Keyboard => tTcTpZtooBSnURBfRqwLSbjujuaE(), 
						ControllerType.Mouse => PoFgtZdPjGCJOIrJBmGogpiAalkf(), 
						ControllerType.Custom => WYEQVWQbCamIVkUJsucyXGswgEHIA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => TSsZtTNgJLeYxFRpZPSUynhIoYcxA(controllerId), 
						ControllerType.Keyboard => CxMGZpAJbEoXeXyMMiRsRtkVxmYhA(), 
						ControllerType.Mouse => EDKIaPiqBGEcZBwOHJFQiQpNsxnu(), 
						ControllerType.Custom => uUiPhFIplLVGcEnYpMbEdkjDQlQN(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => dqjcWYFFuiYLRFzdMUNoqiHwKvMjA(controllerId), 
						ControllerType.Keyboard => tTcTpZtooBSnURBfRqwLSbjujuaE(), 
						ControllerType.Mouse => YJkTxoYUIqmURpYBEKhJVmPwBJIH(), 
						ControllerType.Custom => frNQPRtpMnDVZuUhICTYDjSRazdq(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => bbgaALKRIObjZebUDTnCpzMOYpl(controllerId), 
						ControllerType.Keyboard => CxMGZpAJbEoXeXyMMiRsRtkVxmYhA(), 
						ControllerType.Mouse => wWmcUNvOElUYXQSGOgqHskSYKmRX(), 
						ControllerType.Custom => aLmsncwhQHymTBbjxTLQPbOHKCqu(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
					}
					return controllerType switch
					{
						ControllerType.Joystick => UGJsIWrLkfCXXAgactfSLfQfzdab(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV(), 
						ControllerType.Mouse => OLGGVbOoPzFfzkuSaBfROOhrrMzM(), 
						ControllerType.Custom => CDAnUZFkhdIbQmxVWnlVIedquAxr(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return new TFrVvqEKxuCvPaKrekJexogtYqfv(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return new fZkBdeMDgDXiiEBDIcjmSntvzmyw(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return new WYHEzAHAquSOHSdtvEhCPghiSxpK(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return new MHacWYTrMrzxQLRVxdPDtmipMvgg(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return new ojyDkFcbSxpEoeAKgvBLZDFhfCUG(-2)
					{
						GZXxEqHwrHYIyUJtInpLwgTukJaY = this
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
						ControllerType.Joystick => jLqomNZmEgJcbVNpJbaCjYhuJLTq(controllerId), 
						ControllerType.Keyboard => ULtaVEESJmqfDbraMhrzPodihJNDA(), 
						ControllerType.Mouse => bSseUnOHIWiSfbOImWOjQdnBeeSab(), 
						ControllerType.Custom => UkqQsviXdNDzwJWRzsseIocxhZpF(controllerId), 
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
						ControllerType.Joystick => xBvExNCWMJkTZXNDZiUvCOncrPrSA(controllerId), 
						ControllerType.Keyboard => klEGtgXqpcnAfMgCcWTxSOsmdWkb(), 
						ControllerType.Mouse => hfcNcDmbtLKyvvHvvJlkyvKCMFri(), 
						ControllerType.Custom => naCfrYkNkGlXjVvdmYiSDNDFOeZTA(controllerId), 
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
						ControllerType.Joystick => RVDGPqEvDAwMpCzuKUxThApWMOTAA(controllerId), 
						ControllerType.Keyboard => ULtaVEESJmqfDbraMhrzPodihJNDA(), 
						ControllerType.Mouse => CgOhupIcrKhbfzOvEhqFojuLLkjp(), 
						ControllerType.Custom => mwpBCnCvAzFoObigAtkufAMgEQGlb(controllerId), 
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
						ControllerType.Joystick => qIziKcXjejvaniFgdSKtXmUPJERe(controllerId), 
						ControllerType.Keyboard => klEGtgXqpcnAfMgCcWTxSOsmdWkb(), 
						ControllerType.Mouse => wnFkpRdMAAeDUMnvXkXhVbQrtMWx(), 
						ControllerType.Custom => odvpmlDQOaJazHjiHGMRGJOZvwpaA(controllerId), 
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
						ControllerType.Joystick => cSoGNXgqSKUXrxwyoWKDfxZGhFMP(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => aNECRxgTvdIxEuDrjWbXdFsyQYvkA(), 
						ControllerType.Custom => nPGgnFxfFlCbDirHtOpNMWUDzEKrA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo LmCCtDIwlaCJxvyeVOIcdGXStBwKA()
				{
					IList<Joystick> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo NLAqwwcVeQAFylvkVATfsKXonfxT()
				{
					IList<Joystick> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo lQpAvvzDrddilGPtTfxaaPyhkPhnc()
				{
					IList<Joystick> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo hFeKUCpfSEghxHjtsKtNScwBpCtEb()
				{
					IList<Joystick> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo qWJTWzUSmTbOBDUgekTSYbTASvcK()
				{
					IList<Joystick> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo ZFQPSDJcKZhWWHjXyOvBmZRuBmLmA(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo TSsZtTNgJLeYxFRpZPSUynhIoYcxA(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo dqjcWYFFuiYLRFzdMUNoqiHwKvMjA(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo bbgaALKRIObjZebUDTnCpzMOYpl(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo UGJsIWrLkfCXXAgactfSLfQfzdab(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo tTcTpZtooBSnURBfRqwLSbjujuaE()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo CxMGZpAJbEoXeXyMMiRsRtkVxmYhA()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo PoFgtZdPjGCJOIrJBmGogpiAalkf()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo EDKIaPiqBGEcZBwOHJFQiQpNsxnu()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo YJkTxoYUIqmURpYBEKhJVmPwBJIH()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo wWmcUNvOElUYXQSGOgqHskSYKmRX()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo OLGGVbOoPzFfzkuSaBfROOhrrMzM()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo QrZwrFYntBxbzmVMFdWwoGjhPhbt()
				{
					IList<CustomController> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo dOogWtGRTNTWKToFNDTyVXMbxHpO()
				{
					IList<CustomController> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo JJnFilLfLRmWzvZcjAyBtncumIKi()
				{
					IList<CustomController> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo nsnDqPkTWYRhBjUVRlLQIcJJqEsIc()
				{
					IList<CustomController> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo EJrRvJQyAHmTWrRypumjyNJPxAxU()
				{
					IList<CustomController> list = OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo WYEQVWQbCamIVkUJsucyXGswgEHIA(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo uUiPhFIplLVGcEnYpMbEdkjDQlQN(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo frNQPRtpMnDVZuUhICTYDjSRazdq(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo aLmsncwhQHymTBbjxTLQPbOHKCqu(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private ControllerPollingInfo CDAnUZFkhdIbQmxVWnlVIedquAxr(int P_0)
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.WYxhQFUXiVvjJjdRGGxowZCsqZKV();
				}

				private IEnumerable<ControllerPollingInfo> wydrzWDnlpVBVEbRWzHPiqLZvimr()
				{
					return new khuJFCEGWUbOCEUUHHzPWXxgCvIk(-2);
				}

				private IEnumerable<ControllerPollingInfo> TPWIHjQClyZpndrKcjszPaqjKscv()
				{
					return new upxMaQkbFgGMiDDgsuvsAMCjKjLz(-2);
				}

				private IEnumerable<ControllerPollingInfo> ntSVuvEKSOIBzXFeKRpYkOMKJJpW()
				{
					return new fEkAqFFHZsbPhZHqTxQhgDgHkdbMA(-2);
				}

				private IEnumerable<ControllerPollingInfo> KmWZqXFjZMlaFOFQirvAmUjMBOoi()
				{
					return new QTeXEpbuWgcmUSlSEEhPHasTSJwGA(-2);
				}

				private IEnumerable<ControllerPollingInfo> kuupDKpzqIzRQUJLxmVOVonVOxcE()
				{
					return new LvCfSixmFUGGbWSeNgORiFufbEkv(-2);
				}

				private IEnumerable<ControllerPollingInfo> jLqomNZmEgJcbVNpJbaCjYhuJLTq(int P_0)
				{
					Joystick joystick = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> xBvExNCWMJkTZXNDZiUvCOncrPrSA(int P_0)
				{
					Joystick joystick = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> RVDGPqEvDAwMpCzuKUxThApWMOTAA(int P_0)
				{
					Joystick joystick = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> qIziKcXjejvaniFgdSKtXmUPJERe(int P_0)
				{
					Joystick joystick = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> cSoGNXgqSKUXrxwyoWKDfxZGhFMP(int P_0)
				{
					Joystick joystick = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> ULtaVEESJmqfDbraMhrzPodihJNDA()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> klEGtgXqpcnAfMgCcWTxSOsmdWkb()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> bSseUnOHIWiSfbOImWOjQdnBeeSab()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> hfcNcDmbtLKyvvHvvJlkyvKCMFri()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> CgOhupIcrKhbfzOvEhqFojuLLkjp()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> wnFkpRdMAAeDUMnvXkXhVbQrtMWx()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> aNECRxgTvdIxEuDrjWbXdFsyQYvkA()
				{
					return ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.Mouse.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> FUFeTXEnsdlGKxZULrzYgWhlRliEA()
				{
					return new bAGSrMWdqiINvCalrCIiBBRgEgyN(-2);
				}

				private IEnumerable<ControllerPollingInfo> rxkozAGDxDRznZgNovkNfzIMWBDW()
				{
					return new FoGlGWLjBueEYxannYBzCQBMXGwD(-2);
				}

				private IEnumerable<ControllerPollingInfo> qVOfhPqHAmewrWNjBWivQlBINRnM()
				{
					return new DhoKvVkHvsCjmrbmsbKyiabXFnEHA(-2);
				}

				private IEnumerable<ControllerPollingInfo> KQOSGgLIEeSOXecyJTvxjcRkQpir()
				{
					return new CYNIgDYEcVvZknNlypIuGMsRDQUdA(-2);
				}

				private IEnumerable<ControllerPollingInfo> UpPqyUhkWnRbFwCZwnjTGqKWVKbW()
				{
					return new rorzAYagVFDagiEVMbwTPVzdZRPtA(-2);
				}

				private IEnumerable<ControllerPollingInfo> UkqQsviXdNDzwJWRzsseIocxhZpF(int P_0)
				{
					CustomController customController = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> naCfrYkNkGlXjVvdmYiSDNDFOeZTA(int P_0)
				{
					CustomController customController = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> mwpBCnCvAzFoObigAtkufAMgEQGlb(int P_0)
				{
					CustomController customController = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> odvpmlDQOaJazHjiHGMRGJOZvwpaA(int P_0)
				{
					CustomController customController = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> nPGgnFxfFlCbDirHtOpNMWUDzEKrA(int P_0)
				{
					CustomController customController = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllAxes();
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class ConflictCheckingHelper : CodeHelper
			{
				private sealed class BFbJqBUGRarYFABXtpUGFXqnicGy : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int EsAvjzzsEcIoFBgWBERTYqcmBmPO;

					public int YMyYrgqjQcbpsfDGZPGbbmUONihv;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private int ewwLiKFmCKbnVFhcViVbHODDzYHW;

					public int vXQfuLBNeSomNCFhbslTsFXQMdDu;

					private CustomControllerMap VWFfxPjRKQCDyercMEqrSwQhLrtM;

					public CustomControllerMap wociEpLFbzKolRwnWObGgFZWmpXm;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public BFbJqBUGRarYFABXtpUGFXqnicGy(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00e2;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (EsAvjzzsEcIoFBgWBERTYqcmBmPO < 0 || PZbZkBoGnFCjWtQvUxrXIJOdhXlgA == null)
							{
								return false;
							}
							OIfFiYilnJtNyiFUeloDhaNGmDOP = (YytzdABPnNIxqySMEhnJehpkGpII ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_010c;
							IL_010c:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < OIfFiYilnJtNyiFUeloDhaNGmDOP.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = OIfFiYilnJtNyiFUeloDhaNGmDOP[eolRghqutZOOIGqvOFTzJOGfYTsn].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, ewwLiKFmCKbnVFhcViVbHODDzYHW, VWFfxPjRKQCDyercMEqrSwQhLrtM, PZbZkBoGnFCjWtQvUxrXIJOdhXlgA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj).GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00e2;
							}
							return false;
							IL_00e2:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						BFbJqBUGRarYFABXtpUGFXqnicGy bFbJqBUGRarYFABXtpUGFXqnicGy;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							bFbJqBUGRarYFABXtpUGFXqnicGy = this;
						}
						else
						{
							bFbJqBUGRarYFABXtpUGFXqnicGy = new BFbJqBUGRarYFABXtpUGFXqnicGy(0);
						}
						bFbJqBUGRarYFABXtpUGFXqnicGy.EsAvjzzsEcIoFBgWBERTYqcmBmPO = YMyYrgqjQcbpsfDGZPGbbmUONihv;
						bFbJqBUGRarYFABXtpUGFXqnicGy.ewwLiKFmCKbnVFhcViVbHODDzYHW = vXQfuLBNeSomNCFhbslTsFXQMdDu;
						bFbJqBUGRarYFABXtpUGFXqnicGy.VWFfxPjRKQCDyercMEqrSwQhLrtM = wociEpLFbzKolRwnWObGgFZWmpXm;
						bFbJqBUGRarYFABXtpUGFXqnicGy.PZbZkBoGnFCjWtQvUxrXIJOdhXlgA = NHvoQUmVUvFdqqRTiMRJbyTctFXf;
						bFbJqBUGRarYFABXtpUGFXqnicGy.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						bFbJqBUGRarYFABXtpUGFXqnicGy.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						bFbJqBUGRarYFABXtpUGFXqnicGy.YytzdABPnNIxqySMEhnJehpkGpII = BPsPdsiDfjqElVMjTklIiGDmwAtj;
						return bFbJqBUGRarYFABXtpUGFXqnicGy;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class mYNKMBzmMLGYJhvTFfkJBkAZGygQ : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public mYNKMBzmMLGYJhvTFfkJBkAZGygQ(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00df;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (WeJFlXuVmFcPnwQYoDnnchsJRzmFA.playerId < 0 || WeJFlXuVmFcPnwQYoDnnchsJRzmFA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							OIfFiYilnJtNyiFUeloDhaNGmDOP = (YytzdABPnNIxqySMEhnJehpkGpII ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0109;
							IL_0109:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < OIfFiYilnJtNyiFUeloDhaNGmDOP.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = OIfFiYilnJtNyiFUeloDhaNGmDOP[eolRghqutZOOIGqvOFTzJOGfYTsn].controllers.conflictChecking.ElementAssignmentConflicts(WeJFlXuVmFcPnwQYoDnnchsJRzmFA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj).GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						mYNKMBzmMLGYJhvTFfkJBkAZGygQ mYNKMBzmMLGYJhvTFfkJBkAZGygQ2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							mYNKMBzmMLGYJhvTFfkJBkAZGygQ2 = this;
						}
						else
						{
							mYNKMBzmMLGYJhvTFfkJBkAZGygQ2 = new mYNKMBzmMLGYJhvTFfkJBkAZGygQ(0);
						}
						mYNKMBzmMLGYJhvTFfkJBkAZGygQ2.WeJFlXuVmFcPnwQYoDnnchsJRzmFA = FCYmIzsyhgDFawLsaVlrNOiKvCgn;
						mYNKMBzmMLGYJhvTFfkJBkAZGygQ2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						mYNKMBzmMLGYJhvTFfkJBkAZGygQ2.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						mYNKMBzmMLGYJhvTFfkJBkAZGygQ2.YytzdABPnNIxqySMEhnJehpkGpII = BPsPdsiDfjqElVMjTklIiGDmwAtj;
						return mYNKMBzmMLGYJhvTFfkJBkAZGygQ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class GznbRJBlVwfeKOuaEqOTHPNduqDh : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int EsAvjzzsEcIoFBgWBERTYqcmBmPO;

					public int YMyYrgqjQcbpsfDGZPGbbmUONihv;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private int ewwLiKFmCKbnVFhcViVbHODDzYHW;

					public int vXQfuLBNeSomNCFhbslTsFXQMdDu;

					private JoystickMap FiFsRZmsfAlMtxuDUQHizqOuHnljA;

					public JoystickMap IrOaOiFrZJrGmpirPsrIrIXKRXRhA;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public GznbRJBlVwfeKOuaEqOTHPNduqDh(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00e1;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (EsAvjzzsEcIoFBgWBERTYqcmBmPO < 0 || PZbZkBoGnFCjWtQvUxrXIJOdhXlgA == null)
							{
								return false;
							}
							OIfFiYilnJtNyiFUeloDhaNGmDOP = (YytzdABPnNIxqySMEhnJehpkGpII ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_010b;
							IL_010b:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < OIfFiYilnJtNyiFUeloDhaNGmDOP.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = OIfFiYilnJtNyiFUeloDhaNGmDOP[eolRghqutZOOIGqvOFTzJOGfYTsn].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, ewwLiKFmCKbnVFhcViVbHODDzYHW, FiFsRZmsfAlMtxuDUQHizqOuHnljA, PZbZkBoGnFCjWtQvUxrXIJOdhXlgA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj).GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00e1;
							}
							return false;
							IL_00e1:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						GznbRJBlVwfeKOuaEqOTHPNduqDh gznbRJBlVwfeKOuaEqOTHPNduqDh;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							gznbRJBlVwfeKOuaEqOTHPNduqDh = this;
						}
						else
						{
							gznbRJBlVwfeKOuaEqOTHPNduqDh = new GznbRJBlVwfeKOuaEqOTHPNduqDh(0);
						}
						gznbRJBlVwfeKOuaEqOTHPNduqDh.EsAvjzzsEcIoFBgWBERTYqcmBmPO = YMyYrgqjQcbpsfDGZPGbbmUONihv;
						gznbRJBlVwfeKOuaEqOTHPNduqDh.ewwLiKFmCKbnVFhcViVbHODDzYHW = vXQfuLBNeSomNCFhbslTsFXQMdDu;
						gznbRJBlVwfeKOuaEqOTHPNduqDh.FiFsRZmsfAlMtxuDUQHizqOuHnljA = IrOaOiFrZJrGmpirPsrIrIXKRXRhA;
						gznbRJBlVwfeKOuaEqOTHPNduqDh.PZbZkBoGnFCjWtQvUxrXIJOdhXlgA = NHvoQUmVUvFdqqRTiMRJbyTctFXf;
						gznbRJBlVwfeKOuaEqOTHPNduqDh.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						gznbRJBlVwfeKOuaEqOTHPNduqDh.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						gznbRJBlVwfeKOuaEqOTHPNduqDh.YytzdABPnNIxqySMEhnJehpkGpII = BPsPdsiDfjqElVMjTklIiGDmwAtj;
						return gznbRJBlVwfeKOuaEqOTHPNduqDh;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class fZBgOkAXHBaAkbWsvjYoXrJJyrTU : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public fZBgOkAXHBaAkbWsvjYoXrJJyrTU(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00df;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (WeJFlXuVmFcPnwQYoDnnchsJRzmFA.playerId < 0 || WeJFlXuVmFcPnwQYoDnnchsJRzmFA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							OIfFiYilnJtNyiFUeloDhaNGmDOP = (YytzdABPnNIxqySMEhnJehpkGpII ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0109;
							IL_0109:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < OIfFiYilnJtNyiFUeloDhaNGmDOP.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = OIfFiYilnJtNyiFUeloDhaNGmDOP[eolRghqutZOOIGqvOFTzJOGfYTsn].controllers.conflictChecking.ElementAssignmentConflicts(WeJFlXuVmFcPnwQYoDnnchsJRzmFA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj).GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						fZBgOkAXHBaAkbWsvjYoXrJJyrTU fZBgOkAXHBaAkbWsvjYoXrJJyrTU2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							fZBgOkAXHBaAkbWsvjYoXrJJyrTU2 = this;
						}
						else
						{
							fZBgOkAXHBaAkbWsvjYoXrJJyrTU2 = new fZBgOkAXHBaAkbWsvjYoXrJJyrTU(0);
						}
						fZBgOkAXHBaAkbWsvjYoXrJJyrTU2.WeJFlXuVmFcPnwQYoDnnchsJRzmFA = FCYmIzsyhgDFawLsaVlrNOiKvCgn;
						fZBgOkAXHBaAkbWsvjYoXrJJyrTU2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						fZBgOkAXHBaAkbWsvjYoXrJJyrTU2.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						fZBgOkAXHBaAkbWsvjYoXrJJyrTU2.YytzdABPnNIxqySMEhnJehpkGpII = BPsPdsiDfjqElVMjTklIiGDmwAtj;
						return fZBgOkAXHBaAkbWsvjYoXrJJyrTU2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class sPBMFBzvxJJsjskFuJcjkJBleCCaA : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int EsAvjzzsEcIoFBgWBERTYqcmBmPO;

					public int YMyYrgqjQcbpsfDGZPGbbmUONihv;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private KeyboardMap fCQAyzzPcOyfdqQNYUpAFyzEBjau;

					public KeyboardMap krnVMFYBgWvUcDJECWBLMuWECdUR;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public sPBMFBzvxJJsjskFuJcjkJBleCCaA(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00dc;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (EsAvjzzsEcIoFBgWBERTYqcmBmPO < 0 || PZbZkBoGnFCjWtQvUxrXIJOdhXlgA == null)
							{
								return false;
							}
							OIfFiYilnJtNyiFUeloDhaNGmDOP = (YytzdABPnNIxqySMEhnJehpkGpII ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0106;
							IL_0106:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < OIfFiYilnJtNyiFUeloDhaNGmDOP.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = OIfFiYilnJtNyiFUeloDhaNGmDOP[eolRghqutZOOIGqvOFTzJOGfYTsn].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, fCQAyzzPcOyfdqQNYUpAFyzEBjau, PZbZkBoGnFCjWtQvUxrXIJOdhXlgA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj).GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						sPBMFBzvxJJsjskFuJcjkJBleCCaA sPBMFBzvxJJsjskFuJcjkJBleCCaA2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							sPBMFBzvxJJsjskFuJcjkJBleCCaA2 = this;
						}
						else
						{
							sPBMFBzvxJJsjskFuJcjkJBleCCaA2 = new sPBMFBzvxJJsjskFuJcjkJBleCCaA(0);
						}
						sPBMFBzvxJJsjskFuJcjkJBleCCaA2.EsAvjzzsEcIoFBgWBERTYqcmBmPO = YMyYrgqjQcbpsfDGZPGbbmUONihv;
						sPBMFBzvxJJsjskFuJcjkJBleCCaA2.fCQAyzzPcOyfdqQNYUpAFyzEBjau = krnVMFYBgWvUcDJECWBLMuWECdUR;
						sPBMFBzvxJJsjskFuJcjkJBleCCaA2.PZbZkBoGnFCjWtQvUxrXIJOdhXlgA = NHvoQUmVUvFdqqRTiMRJbyTctFXf;
						sPBMFBzvxJJsjskFuJcjkJBleCCaA2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						sPBMFBzvxJJsjskFuJcjkJBleCCaA2.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						sPBMFBzvxJJsjskFuJcjkJBleCCaA2.YytzdABPnNIxqySMEhnJehpkGpII = BPsPdsiDfjqElVMjTklIiGDmwAtj;
						return sPBMFBzvxJJsjskFuJcjkJBleCCaA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class HYgGSbKYLylpVPRgkEpSCZvgxrDo : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public HYgGSbKYLylpVPRgkEpSCZvgxrDo(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00df;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (WeJFlXuVmFcPnwQYoDnnchsJRzmFA.playerId < 0 || WeJFlXuVmFcPnwQYoDnnchsJRzmFA.elementAssignmentType != ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							OIfFiYilnJtNyiFUeloDhaNGmDOP = (YytzdABPnNIxqySMEhnJehpkGpII ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0109;
							IL_0109:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < OIfFiYilnJtNyiFUeloDhaNGmDOP.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = OIfFiYilnJtNyiFUeloDhaNGmDOP[eolRghqutZOOIGqvOFTzJOGfYTsn].controllers.conflictChecking.ElementAssignmentConflicts(WeJFlXuVmFcPnwQYoDnnchsJRzmFA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj).GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						HYgGSbKYLylpVPRgkEpSCZvgxrDo hYgGSbKYLylpVPRgkEpSCZvgxrDo;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							hYgGSbKYLylpVPRgkEpSCZvgxrDo = this;
						}
						else
						{
							hYgGSbKYLylpVPRgkEpSCZvgxrDo = new HYgGSbKYLylpVPRgkEpSCZvgxrDo(0);
						}
						hYgGSbKYLylpVPRgkEpSCZvgxrDo.WeJFlXuVmFcPnwQYoDnnchsJRzmFA = FCYmIzsyhgDFawLsaVlrNOiKvCgn;
						hYgGSbKYLylpVPRgkEpSCZvgxrDo.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						hYgGSbKYLylpVPRgkEpSCZvgxrDo.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						hYgGSbKYLylpVPRgkEpSCZvgxrDo.YytzdABPnNIxqySMEhnJehpkGpII = BPsPdsiDfjqElVMjTklIiGDmwAtj;
						return hYgGSbKYLylpVPRgkEpSCZvgxrDo;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class AjmbuxrKGPLAZQxGbCPynfkVVbaJ : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private int EsAvjzzsEcIoFBgWBERTYqcmBmPO;

					public int YMyYrgqjQcbpsfDGZPGbbmUONihv;

					private ActionElementMap PZbZkBoGnFCjWtQvUxrXIJOdhXlgA;

					public ActionElementMap NHvoQUmVUvFdqqRTiMRJbyTctFXf;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private MouseMap haIFRexsMbecbDLbGjzFbQrTBkWAb;

					public MouseMap XqsJkEGgycMMJucuWMJsGIaZauKj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public AjmbuxrKGPLAZQxGbCPynfkVVbaJ(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00dc;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (EsAvjzzsEcIoFBgWBERTYqcmBmPO < 0 || PZbZkBoGnFCjWtQvUxrXIJOdhXlgA == null)
							{
								return false;
							}
							OIfFiYilnJtNyiFUeloDhaNGmDOP = (YytzdABPnNIxqySMEhnJehpkGpII ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0106;
							IL_0106:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < OIfFiYilnJtNyiFUeloDhaNGmDOP.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = OIfFiYilnJtNyiFUeloDhaNGmDOP[eolRghqutZOOIGqvOFTzJOGfYTsn].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, haIFRexsMbecbDLbGjzFbQrTBkWAb, PZbZkBoGnFCjWtQvUxrXIJOdhXlgA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj).GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						AjmbuxrKGPLAZQxGbCPynfkVVbaJ ajmbuxrKGPLAZQxGbCPynfkVVbaJ;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							ajmbuxrKGPLAZQxGbCPynfkVVbaJ = this;
						}
						else
						{
							ajmbuxrKGPLAZQxGbCPynfkVVbaJ = new AjmbuxrKGPLAZQxGbCPynfkVVbaJ(0);
						}
						ajmbuxrKGPLAZQxGbCPynfkVVbaJ.EsAvjzzsEcIoFBgWBERTYqcmBmPO = YMyYrgqjQcbpsfDGZPGbbmUONihv;
						ajmbuxrKGPLAZQxGbCPynfkVVbaJ.haIFRexsMbecbDLbGjzFbQrTBkWAb = XqsJkEGgycMMJucuWMJsGIaZauKj;
						ajmbuxrKGPLAZQxGbCPynfkVVbaJ.PZbZkBoGnFCjWtQvUxrXIJOdhXlgA = NHvoQUmVUvFdqqRTiMRJbyTctFXf;
						ajmbuxrKGPLAZQxGbCPynfkVVbaJ.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						ajmbuxrKGPLAZQxGbCPynfkVVbaJ.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						ajmbuxrKGPLAZQxGbCPynfkVVbaJ.YytzdABPnNIxqySMEhnJehpkGpII = BPsPdsiDfjqElVMjTklIiGDmwAtj;
						return ajmbuxrKGPLAZQxGbCPynfkVVbaJ;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class dxQsekRBerjhEvoEnKzcsgluFGVQ : IDisposable, IEnumerable, IEnumerator, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

					private ElementAssignmentConflictInfo USjDTWbJtWhEBdYYYfLUglTcnnGrA;

					private int nOonfdwpqEUEASbbWObCvjhlCTmP;

					private ElementAssignmentConflictCheck WeJFlXuVmFcPnwQYoDnnchsJRzmFA;

					public ElementAssignmentConflictCheck FCYmIzsyhgDFawLsaVlrNOiKvCgn;

					private bool YytzdABPnNIxqySMEhnJehpkGpII;

					public bool BPsPdsiDfjqElVMjTklIiGDmwAtj;

					private bool SkVfnydpDzxVINVmPxKjrMVDeYYIA;

					public bool XrxFLJTgUPTsBtuHGrpvxRqvDedI;

					private bool eTTawGSopVMvmFmPchxUidtHdmgj;

					public bool HKnQaijXkKPDPjjsPiPStNaqHYXO;

					private IList<Player> OIfFiYilnJtNyiFUeloDhaNGmDOP;

					private int eolRghqutZOOIGqvOFTzJOGfYTsn;

					private IEnumerator<ElementAssignmentConflictInfo> mDjuRKAbfpbeOaVTkiWqBfhIPuRjA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
						}
					}

					[DebuggerHidden]
					public dxQsekRBerjhEvoEnKzcsgluFGVQ(int P_0)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
						nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo == -3 || gwbUsvLqBorYvZEWvPDttSzVhFNo == 1)
						{
							try
							{
							}
							finally
							{
								xrMgkdBFpRjKpJIbZTZinfoAczuP();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
							if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
							{
								if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
								{
									return false;
								}
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00df;
							}
							GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
							if (WeJFlXuVmFcPnwQYoDnnchsJRzmFA.playerId < 0 || WeJFlXuVmFcPnwQYoDnnchsJRzmFA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							OIfFiYilnJtNyiFUeloDhaNGmDOP = (YytzdABPnNIxqySMEhnJehpkGpII ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
							eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
							goto IL_0109;
							IL_0109:
							if (eolRghqutZOOIGqvOFTzJOGfYTsn < OIfFiYilnJtNyiFUeloDhaNGmDOP.Count)
							{
								mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = OIfFiYilnJtNyiFUeloDhaNGmDOP[eolRghqutZOOIGqvOFTzJOGfYTsn].controllers.conflictChecking.ElementAssignmentConflicts(WeJFlXuVmFcPnwQYoDnnchsJRzmFA, SkVfnydpDzxVINVmPxKjrMVDeYYIA, eTTawGSopVMvmFmPchxUidtHdmgj).GetEnumerator();
								GwbUsvLqBorYvZEWvPDttSzVhFNo = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.MoveNext())
							{
								ElementAssignmentConflictInfo current = mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Current;
								USjDTWbJtWhEBdYYYfLUglTcnnGrA = current;
								GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
								return true;
							}
							xrMgkdBFpRjKpJIbZTZinfoAczuP();
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA = null;
							eolRghqutZOOIGqvOFTzJOGfYTsn++;
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

					private void xrMgkdBFpRjKpJIbZTZinfoAczuP()
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						if (mDjuRKAbfpbeOaVTkiWqBfhIPuRjA != null)
						{
							mDjuRKAbfpbeOaVTkiWqBfhIPuRjA.Dispose();
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
						dxQsekRBerjhEvoEnKzcsgluFGVQ dxQsekRBerjhEvoEnKzcsgluFGVQ2;
						if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
						{
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
							dxQsekRBerjhEvoEnKzcsgluFGVQ2 = this;
						}
						else
						{
							dxQsekRBerjhEvoEnKzcsgluFGVQ2 = new dxQsekRBerjhEvoEnKzcsgluFGVQ(0);
						}
						dxQsekRBerjhEvoEnKzcsgluFGVQ2.WeJFlXuVmFcPnwQYoDnnchsJRzmFA = FCYmIzsyhgDFawLsaVlrNOiKvCgn;
						dxQsekRBerjhEvoEnKzcsgluFGVQ2.SkVfnydpDzxVINVmPxKjrMVDeYYIA = XrxFLJTgUPTsBtuHGrpvxRqvDedI;
						dxQsekRBerjhEvoEnKzcsgluFGVQ2.eTTawGSopVMvmFmPchxUidtHdmgj = HKnQaijXkKPDPjjsPiPStNaqHYXO;
						dxQsekRBerjhEvoEnKzcsgluFGVQ2.YytzdABPnNIxqySMEhnJehpkGpII = BPsPdsiDfjqElVMjTklIiGDmwAtj;
						return dxQsekRBerjhEvoEnKzcsgluFGVQ2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private static ConflictCheckingHelper WjQAaHwnldjGbWthvILYYAgChYHq;

				internal static ConflictCheckingHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => WjQAaHwnldjGbWthvILYYAgChYHq ?? (WjQAaHwnldjGbWthvILYYAgChYHq = new ConflictCheckingHelper());

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
					IList<Player> list = (includeSystemPlayer ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
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
						ControllerType.Joystick => zICZZCccXciZUccGppXlkEPUwHKP(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => ImeVxUiMMNeZpmFnGKZkLLbaeFAs(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => CdDIAQKzDtmpDvahYvPDoCAEhNxrA(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => tulhqQqnyLKnfCJWdcHLOkUWCBnFA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return zICZZCccXciZUccGppXlkEPUwHKP(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return ImeVxUiMMNeZpmFnGKZkLLbaeFAs(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return CdDIAQKzDtmpDvahYvPDoCAEhNxrA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return tulhqQqnyLKnfCJWdcHLOkUWCBnFA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool zICZZCccXciZUccGppXlkEPUwHKP(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool zICZZCccXciZUccGppXlkEPUwHKP(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool ImeVxUiMMNeZpmFnGKZkLLbaeFAs(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool ImeVxUiMMNeZpmFnGKZkLLbaeFAs(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool CdDIAQKzDtmpDvahYvPDoCAEhNxrA(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool CdDIAQKzDtmpDvahYvPDoCAEhNxrA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool tulhqQqnyLKnfCJWdcHLOkUWCBnFA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool tulhqQqnyLKnfCJWdcHLOkUWCBnFA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
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
						ControllerType.Joystick => qFiuBxtcrMZNCQdSZzSoDFDyTabj(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => HKXaLFkRUmMDpVePUmSmvgUqQPwO(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => sBtzBSFmJhmBXUwLUdjNmSIdHycV(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => TkjtoAfIkpBwoawmImAIkNkRqtGlA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return qFiuBxtcrMZNCQdSZzSoDFDyTabj(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return HKXaLFkRUmMDpVePUmSmvgUqQPwO(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return sBtzBSFmJhmBXUwLUdjNmSIdHycV(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return TkjtoAfIkpBwoawmImAIkNkRqtGlA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private IEnumerable<ElementAssignmentConflictInfo> qFiuBxtcrMZNCQdSZzSoDFDyTabj(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new GznbRJBlVwfeKOuaEqOTHPNduqDh(-2)
					{
						YMyYrgqjQcbpsfDGZPGbbmUONihv = P_0,
						vXQfuLBNeSomNCFhbslTsFXQMdDu = P_1,
						IrOaOiFrZJrGmpirPsrIrIXKRXRhA = P_2,
						NHvoQUmVUvFdqqRTiMRJbyTctFXf = P_3,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_4,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_5,
						BPsPdsiDfjqElVMjTklIiGDmwAtj = P_6
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> qFiuBxtcrMZNCQdSZzSoDFDyTabj(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new fZBgOkAXHBaAkbWsvjYoXrJJyrTU(-2)
					{
						FCYmIzsyhgDFawLsaVlrNOiKvCgn = P_0,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_1,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_2,
						BPsPdsiDfjqElVMjTklIiGDmwAtj = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> HKXaLFkRUmMDpVePUmSmvgUqQPwO(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new sPBMFBzvxJJsjskFuJcjkJBleCCaA(-2)
					{
						YMyYrgqjQcbpsfDGZPGbbmUONihv = P_0,
						krnVMFYBgWvUcDJECWBLMuWECdUR = P_1,
						NHvoQUmVUvFdqqRTiMRJbyTctFXf = P_2,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_3,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_4,
						BPsPdsiDfjqElVMjTklIiGDmwAtj = P_5
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> HKXaLFkRUmMDpVePUmSmvgUqQPwO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new HYgGSbKYLylpVPRgkEpSCZvgxrDo(-2)
					{
						FCYmIzsyhgDFawLsaVlrNOiKvCgn = P_0,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_1,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_2,
						BPsPdsiDfjqElVMjTklIiGDmwAtj = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> sBtzBSFmJhmBXUwLUdjNmSIdHycV(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new AjmbuxrKGPLAZQxGbCPynfkVVbaJ(-2)
					{
						YMyYrgqjQcbpsfDGZPGbbmUONihv = P_0,
						XqsJkEGgycMMJucuWMJsGIaZauKj = P_1,
						NHvoQUmVUvFdqqRTiMRJbyTctFXf = P_2,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_3,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_4,
						BPsPdsiDfjqElVMjTklIiGDmwAtj = P_5
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> sBtzBSFmJhmBXUwLUdjNmSIdHycV(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new dxQsekRBerjhEvoEnKzcsgluFGVQ(-2)
					{
						FCYmIzsyhgDFawLsaVlrNOiKvCgn = P_0,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_1,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_2,
						BPsPdsiDfjqElVMjTklIiGDmwAtj = P_3
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> TkjtoAfIkpBwoawmImAIkNkRqtGlA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new BFbJqBUGRarYFABXtpUGFXqnicGy(-2)
					{
						YMyYrgqjQcbpsfDGZPGbbmUONihv = P_0,
						vXQfuLBNeSomNCFhbslTsFXQMdDu = P_1,
						wociEpLFbzKolRwnWObGgFZWmpXm = P_2,
						NHvoQUmVUvFdqqRTiMRJbyTctFXf = P_3,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_4,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_5,
						BPsPdsiDfjqElVMjTklIiGDmwAtj = P_6
					};
				}

				private IEnumerable<ElementAssignmentConflictInfo> TkjtoAfIkpBwoawmImAIkNkRqtGlA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new mYNKMBzmMLGYJhvTFfkJBkAZGygQ(-2)
					{
						FCYmIzsyhgDFawLsaVlrNOiKvCgn = P_0,
						XrxFLJTgUPTsBtuHGrpvxRqvDedI = P_1,
						HKnQaijXkKPDPjjsPiPStNaqHYXO = P_2,
						BPsPdsiDfjqElVMjTklIiGDmwAtj = P_3
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
						ControllerType.Joystick => PkedvKucqBZBeMsixdsfvRHEAkYHA(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => wybdezbMizHuACtHjlXhldgRzhkLA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => KMZAnACDzFMMWtFRhGOEJFRcunSR(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => AUwflLfcFWUOiJhcaHSYydXsBRabA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return PkedvKucqBZBeMsixdsfvRHEAkYHA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return wybdezbMizHuACtHjlXhldgRzhkLA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return KMZAnACDzFMMWtFRhGOEJFRcunSR(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return AUwflLfcFWUOiJhcaHSYydXsBRabA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int PkedvKucqBZBeMsixdsfvRHEAkYHA(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int PkedvKucqBZBeMsixdsfvRHEAkYHA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int wybdezbMizHuACtHjlXhldgRzhkLA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int wybdezbMizHuACtHjlXhldgRzhkLA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int KMZAnACDzFMMWtFRhGOEJFRcunSR(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int KMZAnACDzFMMWtFRhGOEJFRcunSR(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int AUwflLfcFWUOiJhcaHSYydXsBRabA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int AUwflLfcFWUOiJhcaHSYydXsBRabA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
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
						ControllerType.Joystick => hGvFzVtHWEjUYYZGRbXUWateMzEd(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => mWzmVkMlujVKtaGKzjnqPOwaVEve(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => ZTjOEMvfFkcvyHYPehHUpBmTibGib(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => YaBfyVSqvvsWjSsDKoghrsAQVjff(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return hGvFzVtHWEjUYYZGRbXUWateMzEd(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return mWzmVkMlujVKtaGKzjnqPOwaVEve(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return ZTjOEMvfFkcvyHYPehHUpBmTibGib(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return YaBfyVSqvvsWjSsDKoghrsAQVjff(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int hGvFzVtHWEjUYYZGRbXUWateMzEd(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int hGvFzVtHWEjUYYZGRbXUWateMzEd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int mWzmVkMlujVKtaGKzjnqPOwaVEve(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int mWzmVkMlujVKtaGKzjnqPOwaVEve(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int ZTjOEMvfFkcvyHYPehHUpBmTibGib(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int ZTjOEMvfFkcvyHYPehHUpBmTibGib(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int YaBfyVSqvvsWjSsDKoghrsAQVjff(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int YaBfyVSqvvsWjSsDKoghrsAQVjff(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ : ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			public readonly PollingHelper polling = PollingHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC;

			internal static ControllerHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => WjQAaHwnldjGbWthvILYYAgChYHq ?? (WjQAaHwnldjGbWthvILYYAgChYHq = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.SsODYsoCnMZmmkJvPwoplcnNlBAv;
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
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.KBXpwdoMXEcoDkYoXNCAgTEltfun;
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
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.yBqJFIogVEdRIuiInajAqimbcbNA;
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
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.ZvUlvpaVsbPQTtRuvnrrPLgdkCtF;
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
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.NcFhTqaznBUbORimVwWyLExKyNzx;
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
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK;
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
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.JYxquPbZseAQLTolMDAfwrOEyJru;
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
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.IhmKpucosHmZRyANPvjCqzSpCkQy;
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
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.ZvUlvpaVsbPQTtRuvnrrPLgdkCtF as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return OkLkjfkBGntRAvakyAvYRRgphMAiA.yBqJFIogVEdRIuiInajAqimbcbNA as T;
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
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.BXBKHrCmMwnClRajoDNsKgTWBgIcb(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.BXBKHrCmMwnClRajoDNsKgTWBgIcb(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.cahWufwatdGsrbommnEHIowDgadTA(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.ZkTdNKSDYqOKcKLewenibQFfmOMB(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.ICJTVnicgKIrvkHYKFEcCFPuSjKs(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.ICJTVnicgKIrvkHYKFEcCFPuSjKs(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.nAGfKAVMrkOAaZmrwkoAEVdHukyx(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ajnOsEopTWvzJZjeDpcpYppqmqOw.OwMxxwFLqfpdvTcckateEzXHSnmu(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ajnOsEopTWvzJZjeDpcpYppqmqOw.OwMxxwFLqfpdvTcckateEzXHSnmu(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.tSIrwsOdwOFCroAaXNcrRqLZRblM(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.AELkemHHDhODBzkAHuuepOzaSdeL();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.rqcAdHfaleaTEBcVKlyqifJUuZXNb();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.omraCcXcKikUzbbjmcWAxEMCLerg(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.omraCcXcKikUzbbjmcWAxEMCLerg(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.MjYjKBupvdYrwAPPBmcvJhuPUhjo(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ajnOsEopTWvzJZjeDpcpYppqmqOw.CeCRRAdhwYEoDxpaYxXOdxnxmDEs(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ajnOsEopTWvzJZjeDpcpYppqmqOw.CeCRRAdhwYEoDxpaYxXOdxnxmDEs(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!xAXgrgTBrSfWQOaiATiEGRGhgWIC)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				ovWQjTmBaCjemwBSRBKNDCmCYQBg();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (ZMMbmdkWhjAWAhXVeHcFydUeJIjqb.iUHgGzhtQmTEfQwXJvBNsTvKhGQYA(i, j))
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
				if (!xAXgrgTBrSfWQOaiATiEGRGhgWIC)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				ovWQjTmBaCjemwBSRBKNDCmCYQBg();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (ZMMbmdkWhjAWAhXVeHcFydUeJIjqb.iUHgGzhtQmTEfQwXJvBNsTvKhGQYA(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (ZMMbmdkWhjAWAhXVeHcFydUeJIjqb.ShlsTWQNJghDpgJfrKLGNnEOlBnD(i, k, positiveAxesOnly))
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
					if (!xAXgrgTBrSfWQOaiATiEGRGhgWIC)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						DsUMFOuNrADSwelafhXWALBVQljt.SetUnityJoystickId(joystickId, unityJoystickId);
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
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.BEujAwJXazSYZkephxsuXudfwVop(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.aLFpVuDUVZIvkdsYwHmzjgOWkbIb();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.cMXbmnnuthNpieKxmWhTRyXoFguP();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.jbZTlFWpfSjnpyWVEGfdauhcZGnK(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.jbZTlFWpfSjnpyWVEGfdauhcZGnK(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.eQrTOfnkXQRTrjzrYHIaoOuhCYOiA(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ajnOsEopTWvzJZjeDpcpYppqmqOw.ZWVMhhuqIQBKLUkbdBRvziCfFMSHA(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					ajnOsEopTWvzJZjeDpcpYppqmqOw.ZWVMhhuqIQBKLUkbdBRvziCfFMSHA(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.eiZBKaQajfzCsvOZQPpHqLgKHDPAA(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = OkLkjfkBGntRAvakyAvYRRgphMAiA.eiZBKaQajfzCsvOZQPpHqLgKHDPAA(sourceControllerId);
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
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.wFmmPwwEMdAsytXgWcRKBgWWGQhZA(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.xVcdagcrTbKFoeXoYNuAfPalcuvC(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.wxaqxAPsErzJAPFwbsMTBftidDjF(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.fpoxnQyFJYoWOgCaKHjMaYXOkqKsA(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.HAXWgOXwIgGpdKfGjhagSIPpCRqhA(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.vHLSMnLTrxrfTqolEUmkUaFZkjGm<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.iXJHiSNtBnggULeIzHDLqRklUTBQ();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.iXJHiSNtBnggULeIzHDLqRklUTBQ(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.iXJHiSNtBnggULeIzHDLqRklUTBQ<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.sSocBrilXfIwcRtFxdAshYhHdFljA();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					OkLkjfkBGntRAvakyAvYRRgphMAiA.seOLgneYbXEgZXaAbbHCDgUxbVJlA(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					OkLkjfkBGntRAvakyAvYRRgphMAiA.seOLgneYbXEgZXaAbbHCDgUxbVJlA(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					OkLkjfkBGntRAvakyAvYRRgphMAiA.wZhqKwEuhTOxaksFvBZVcwiARRaN(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					OkLkjfkBGntRAvakyAvYRRgphMAiA.BmVzFduGJLnSxYGeafLsmXpbIsudA(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					OkLkjfkBGntRAvakyAvYRRgphMAiA.RfrIJnQlYqBtRxmhlHtbKUtvakBoA();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.OHxXMywYjiPsrXEHFZZfKniKkHzH();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.OHxXMywYjiPsrXEHFZZfKniKkHzH(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.EaaAxLYuELeKAEpndFRxgUgxjgWDA();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.EaaAxLYuELeKAEpndFRxgUgxjgWDA(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.yxDQHFstwJzFcOmHtPGbDLOSsGnc();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.yxDQHFstwJzFcOmHtPGbDLOSsGnc(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.xWtAwKhdrPUdHqlYhiXtqZRKBVQfb();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.uBbBZShepcHgpAYJmkFQzBdJCSDFA();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.uBbBZShepcHgpAYJmkFQzBdJCSDFA(controllerType);
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
				ajnOsEopTWvzJZjeDpcpYppqmqOw.ZmzfysOEnClEazlEGLYwiVNbIAJT(joystick);
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class MappingHelper : CodeHelper
		{
			private static MappingHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			internal static MappingHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => WjQAaHwnldjGbWthvILYYAgChYHq ?? (WjQAaHwnldjGbWthvILYYAgChYHq = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return dhXuTEEziWFtUyjdydeOTtEMceSv.QuihPWUtmEWgykttrhznkpfVggkj;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.srnxGjiCzcThxiGlxKeBziqfQiqH;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.BAgNKIlyRMbqWavPnoaTeSjTjVQe;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.xcDmYzOqkxbCiEDuYWumnJhpjpFW;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.yBTaVIXvmjEEfhJlhBHueVPUIbWKA;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.LYtZzJfhxYpFJjFfpNDBCkzpAabGA;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.SyOlkdhWLOiYUyuPjpjpThGFglOkA;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.cLzyDISHGQRgTCDOxAXAHqSfGEtJA;
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
					return TcJeRjoAHWajdfxVaSabfTeqWDcy.aIbkLzPaXeQZjqLXplSFfffNDmjM;
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
					return dhXuTEEziWFtUyjdydeOTtEMceSv.nOBeigZAIJHlBPazEdpSHuHflsdkA;
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
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.wpboJwwNGJmYiwVLqNPFNDHfbaKo(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.YUjGphbQdSfXfWvwZXgXfRCYcbAEA(tag);
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
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.OnMPQXxheXYkvEvqoPDpiOiodhdW(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.uRldOsoyFtCfBHYmOYGmPMpcIJOH(tag);
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
					ControllerType.Joystick => dhXuTEEziWFtUyjdydeOTtEMceSv.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => dhXuTEEziWFtUyjdydeOTtEMceSv.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => dhXuTEEziWFtUyjdydeOTtEMceSv.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => dhXuTEEziWFtUyjdydeOTtEMceSv.GetCustomControllerLayoutById(layoutId), 
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
					ControllerType.Joystick => dhXuTEEziWFtUyjdydeOTtEMceSv.GetJoystickLayout(name), 
					ControllerType.Keyboard => dhXuTEEziWFtUyjdydeOTtEMceSv.GetKeyboardLayout(name), 
					ControllerType.Mouse => dhXuTEEziWFtUyjdydeOTtEMceSv.GetMouseLayout(name), 
					ControllerType.Custom => dhXuTEEziWFtUyjdydeOTtEMceSv.GetCustomControllerLayout(name), 
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
					ControllerType.Joystick => dhXuTEEziWFtUyjdydeOTtEMceSv.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => dhXuTEEziWFtUyjdydeOTtEMceSv.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => dhXuTEEziWFtUyjdydeOTtEMceSv.GetMouseLayoutId(name), 
					ControllerType.Custom => dhXuTEEziWFtUyjdydeOTtEMceSv.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetCustomControllerLayoutId(name);
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
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.PdViJRIXmdlkJefoQEdnWvycLKwA(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.PdViJRIXmdlkJefoQEdnWvycLKwA(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.PdViJRIXmdlkJefoQEdnWvycLKwA(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.PdViJRIXmdlkJefoQEdnWvycLKwA(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.SjGUBRUluMnJNKhqdgFPZOWjSHlr(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.mXTEGDBSePHkAbgekLJbnebreZGbA(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.mXTEGDBSePHkAbgekLJbnebreZGbA(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.mXTEGDBSePHkAbgekLJbnebreZGbA(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.mXTEGDBSePHkAbgekLJbnebreZGbA(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.gqUiUBMjacceXtcqdHhhSMgwWdoB(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.gqUiUBMjacceXtcqdHhhSMgwWdoB(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.fWPoynXPcUbbMgtVneKpoHRjctAr(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return OkLkjfkBGntRAvakyAvYRRgphMAiA.fWPoynXPcUbbMgtVneKpoHRjctAr(playerId, behaviorName);
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
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior nNMZEBuegSCRzyePfHlgaJhIrLQmA(int P_0)
			{
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetInputBehaviorById(P_0);
			}

			internal InputBehavior nNMZEBuegSCRzyePfHlgaJhIrLQmA(string P_0)
			{
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetInputBehavior(P_0);
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
				Controller controller = OkLkjfkBGntRAvakyAvYRRgphMAiA.BXBKHrCmMwnClRajoDNsKgTWBgIcb(controllerIdentifier);
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
				JoystickMap joystickMap = dhXuTEEziWFtUyjdydeOTtEMceSv.HetfeQvTGnionvvgSERhKCeYNRCzA(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.cnpecuLKhtzxTyAKhiBbYvieXuGi(joystickMap);
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
				InputSource inputSourceType = DsUMFOuNrADSwelafhXWALBVQljt.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = yuMAFKYlLRXHYECDtAfqrzgtWNno.xfXPfXtfZWVGTIYqVCZJMPiYtvfK(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = dhXuTEEziWFtUyjdydeOTtEMceSv.gQDlKZqpgrEymKXajHXzlgcdzNnF(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.YxfUMMITaOjqKeSvHPHGBhfovMBh(joystickMap, hardwareControllerMap_Game);
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
				if (OkLkjfkBGntRAvakyAvYRRgphMAiA.BXBKHrCmMwnClRajoDNsKgTWBgIcb(controllerIdentifier) is Joystick joystick)
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
				KeyboardMap keyboardMap = dhXuTEEziWFtUyjdydeOTtEMceSv.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.cnpecuLKhtzxTyAKhiBbYvieXuGi(keyboardMap);
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
				MouseMap mouseMap = dhXuTEEziWFtUyjdydeOTtEMceSv.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.cnpecuLKhtzxTyAKhiBbYvieXuGi(mouseMap);
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
				CustomControllerMap customControllerMap = dhXuTEEziWFtUyjdydeOTtEMceSv.opgKaKVcPgBILvSltCnRcmUcNLJab(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.cnpecuLKhtzxTyAKhiBbYvieXuGi(customControllerMap);
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
				if (OkLkjfkBGntRAvakyAvYRRgphMAiA.BXBKHrCmMwnClRajoDNsKgTWBgIcb(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = dhXuTEEziWFtUyjdydeOTtEMceSv.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = dhXuTEEziWFtUyjdydeOTtEMceSv.opgKaKVcPgBILvSltCnRcmUcNLJab(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.YxfUMMITaOjqKeSvHPHGBhfovMBh(customControllerMap, hardwareControllerMap_Game);
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
					controllerMap = dhXuTEEziWFtUyjdydeOTtEMceSv.gpidnRqlHkndAPBFkaLBVVnkohYm(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.cnpecuLKhtzxTyAKhiBbYvieXuGi(controller, controllerMap);
					}
					else
					{
						controller.cnpecuLKhtzxTyAKhiBbYvieXuGi(controllerMap);
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
				if (OkLkjfkBGntRAvakyAvYRRgphMAiA.BXBKHrCmMwnClRajoDNsKgTWBgIcb(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = DsUMFOuNrADSwelafhXWALBVQljt.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = yuMAFKYlLRXHYECDtAfqrzgtWNno.xfXPfXtfZWVGTIYqVCZJMPiYtvfK(controllerIdentifier.hardwareTypeGuid, inputSourceType);
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
					joystickMap = dhXuTEEziWFtUyjdydeOTtEMceSv.gQDlKZqpgrEymKXajHXzlgcdzNnF(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
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
						allMap.YxfUMMITaOjqKeSvHPHGBhfovMBh(joystickMap, hardwareControllerMap_Game);
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
				if (OkLkjfkBGntRAvakyAvYRRgphMAiA.BXBKHrCmMwnClRajoDNsKgTWBgIcb(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = dhXuTEEziWFtUyjdydeOTtEMceSv.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
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
					customControllerMap = dhXuTEEziWFtUyjdydeOTtEMceSv.opgKaKVcPgBILvSltCnRcmUcNLJab(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.YxfUMMITaOjqKeSvHPHGBhfovMBh(customControllerMap, hardwareControllerMap_Game);
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
					keyboardMap = dhXuTEEziWFtUyjdydeOTtEMceSv.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.cnpecuLKhtzxTyAKhiBbYvieXuGi(keyboard, keyboardMap);
					}
					else
					{
						keyboard.cnpecuLKhtzxTyAKhiBbYvieXuGi(keyboardMap);
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
					mouseMap = dhXuTEEziWFtUyjdydeOTtEMceSv.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.cnpecuLKhtzxTyAKhiBbYvieXuGi(mouse, mouseMap);
					}
					else
					{
						mouse.cnpecuLKhtzxTyAKhiBbYvieXuGi(mouseMap);
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
				return JvgJisDEfjxbnnflwFguSiAthEijA(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier JvgJisDEfjxbnnflwFguSiAthEijA(Guid P_0, int P_1)
			{
				return yuMAFKYlLRXHYECDtAfqrzgtWNno.JvgJisDEfjxbnnflwFguSiAthEijA(P_0, P_1)?.ToControllerElementIdentifier();
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return dhXuTEEziWFtUyjdydeOTtEMceSv.AFQSZpvOSBQRtoEFNfZZVBBCrtkW(templateTypeGuid, mapCategoryId, layoutId);
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
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = dhXuTEEziWFtUyjdydeOTtEMceSv.GetControllerMapLayoutManagerRuleSetId(name);
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
				return dhXuTEEziWFtUyjdydeOTtEMceSv.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = dhXuTEEziWFtUyjdydeOTtEMceSv.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			internal static PlayerHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => WjQAaHwnldjGbWthvILYYAgChYHq ?? (WjQAaHwnldjGbWthvILYYAgChYHq = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return ajnOsEopTWvzJZjeDpcpYppqmqOw.DpfYFosOsNWtCFkziqdksZeTEArD;
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
					return ajnOsEopTWvzJZjeDpcpYppqmqOw.gHasbnHhBBqxrnCldOFuzaEkoPaA;
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
					return ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA;
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
					return ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ;
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
					return ajnOsEopTWvzJZjeDpcpYppqmqOw.iLesuLOztWcIVeAaALdlvBgOQKgx();
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
					return ajnOsEopTWvzJZjeDpcpYppqmqOw.JKsoUwCAgkKhpVANcbhaqhyjGJigA;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.LlmRwqxmzAqpUhaVpsDevbYYcmRZ;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.hwddIeJafOlGvnIklCDUFMkJMsvyB(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.hwddIeJafOlGvnIklCDUFMkJMsvyB(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.iLesuLOztWcIVeAaALdlvBgOQKgx();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.SFRhEOjlZMRFojItbLaaaDdHTyAOB(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.FcqfWWYOOTTjleKzvnGcwliZKyhK(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.VKfbXriwOizQcmHJLCVHqKcqCoEVA(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return ajnOsEopTWvzJZjeDpcpYppqmqOw.XeaCVkMGpncqGbKCMpgQIcPBRkcs(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper WjQAaHwnldjGbWthvILYYAgChYHq;

			internal static TimeHelper lbAduzmBhLEnHYIeWdaLoLCiGFSC => WjQAaHwnldjGbWthvILYYAgChYHq ?? (WjQAaHwnldjGbWthvILYYAgChYHq = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)DnguBusOPRzgVZOfVVmqrxdKVdpS.pFMFRzEdyhxELHWIZmqtzsEznVku;
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
					return DnguBusOPRzgVZOfVVmqrxdKVdpS.YfDpvXHlxwKYKajZMZpFbUSeEBHG;
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
					return DnguBusOPRzgVZOfVVmqrxdKVdpS.WIrjufOYMVKYdFHdgPrcSgNBuLui;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class yRkaAGhHJbjaAfJOVhXZUtCRPFjNA
		{
			private class hkhGqHspuahDxMNQPZtjBYMQSFrs
			{
				public readonly UpdateLoopType KKlbldiDPbDuxfifcGjVGpjaqJEqB;

				private double OyfcWpPYRdDsPZAdpihjCYZoQyJuA;

				private double CxjJFjitBPIVhmjuzAaDkOxBguSP;

				private double bDeFMEvHSObKEBftstvyPrsjDnLt;

				private double GLoPpoHzqYFplZQSJSACSAHAFKEc;

				private uint KTfntimZPNFDfZPyAQKIPAftEMlJ;

				private uint VEICCJNEuqgqrEWpjSszJWaDqXMp;

				private float yQZbvSUmaxXzMIwtyHCsPOryUTtm;

				private float BOjtQuVemZNFEDpFuaNwebVVAEJi;

				public double YfDpvXHlxwKYKajZMZpFbUSeEBHG => OyfcWpPYRdDsPZAdpihjCYZoQyJuA;

				public double mUXfyDFyovdLxLgZcBQDuAIMLSXQA => CxjJFjitBPIVhmjuzAaDkOxBguSP;

				public double pFMFRzEdyhxELHWIZmqtzsEznVku => bDeFMEvHSObKEBftstvyPrsjDnLt;

				public uint WIrjufOYMVKYdFHdgPrcSgNBuLui => KTfntimZPNFDfZPyAQKIPAftEMlJ;

				public uint wHMbQwkEiGmAGdhvpttevTwiffYaA => VEICCJNEuqgqrEWpjSszJWaDqXMp;

				public float TypfQRgIxbOVRytkNxUudjSFEOKq => yQZbvSUmaxXzMIwtyHCsPOryUTtm;

				public float nKzkaWTntQizTHlSOlBLlzbHjrF => BOjtQuVemZNFEDpFuaNwebVVAEJi;

				public hkhGqHspuahDxMNQPZtjBYMQSFrs(UpdateLoopType P_0)
				{
					KKlbldiDPbDuxfifcGjVGpjaqJEqB = P_0;
					GLoPpoHzqYFplZQSJSACSAHAFKEc = Time.realtimeSinceStartup;
					KTfntimZPNFDfZPyAQKIPAftEMlJ = 0u;
				}

				public void sOLNzBCCbZmFXkMugfndpShqgrUP()
				{
					CxjJFjitBPIVhmjuzAaDkOxBguSP = OyfcWpPYRdDsPZAdpihjCYZoQyJuA;
					OyfcWpPYRdDsPZAdpihjCYZoQyJuA = realTime;
					if (GLoPpoHzqYFplZQSJSACSAHAFKEc > OyfcWpPYRdDsPZAdpihjCYZoQyJuA)
					{
						GLoPpoHzqYFplZQSJSACSAHAFKEc = 0.0;
					}
					bDeFMEvHSObKEBftstvyPrsjDnLt = OyfcWpPYRdDsPZAdpihjCYZoQyJuA - GLoPpoHzqYFplZQSJSACSAHAFKEc;
					GLoPpoHzqYFplZQSJSACSAHAFKEc = OyfcWpPYRdDsPZAdpihjCYZoQyJuA;
					VEICCJNEuqgqrEWpjSszJWaDqXMp = KTfntimZPNFDfZPyAQKIPAftEMlJ;
					KTfntimZPNFDfZPyAQKIPAftEMlJ = MiscTools.Tick(KTfntimZPNFDfZPyAQKIPAftEMlJ);
					BOjtQuVemZNFEDpFuaNwebVVAEJi = yQZbvSUmaxXzMIwtyHCsPOryUTtm;
					yQZbvSUmaxXzMIwtyHCsPOryUTtm = ONcDHoNHsmreSyMftwbKquhWEVGf();
					previousFrame = VEICCJNEuqgqrEWpjSszJWaDqXMp;
					currentFrame = KTfntimZPNFDfZPyAQKIPAftEMlJ;
					unscaledTime = OyfcWpPYRdDsPZAdpihjCYZoQyJuA;
					unscaledTimePrev = CxjJFjitBPIVhmjuzAaDkOxBguSP;
					unscaledDeltaTime = bDeFMEvHSObKEBftstvyPrsjDnLt;
				}
			}

			private static class NSDoQflkgxTjnZtWEQEAfEzrAgQcA
			{
				public static StopwatchBase ucGpGFvhjlGdsxuFlLVQodlIBIac
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

				public static StopwatchBase goGesjEFofcTayLyzynfoITRPCBk()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase IMKiXSsnaTQOMHazxMgBuKdhyNYI()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase iCLMwyDnTRjqAVMtEjNdeqOKWzQ;

			private double bwlkKFEMjtwZZRtwDfkkcxWqnVBe;

			private hkhGqHspuahDxMNQPZtjBYMQSFrs RMrLdQiLLmoKMurKDMJfjnqbgaWQ;

			private ADictionary<int, hkhGqHspuahDxMNQPZtjBYMQSFrs> mOmDiOAylYvqtKUkBXRWeVPbgFUhb;

			private uint RwBPKMnErLwNdsIthcTXePYYibkt;

			public double YfDpvXHlxwKYKajZMZpFbUSeEBHG => RMrLdQiLLmoKMurKDMJfjnqbgaWQ.YfDpvXHlxwKYKajZMZpFbUSeEBHG;

			public double mUXfyDFyovdLxLgZcBQDuAIMLSXQA => RMrLdQiLLmoKMurKDMJfjnqbgaWQ.mUXfyDFyovdLxLgZcBQDuAIMLSXQA;

			public double pFMFRzEdyhxELHWIZmqtzsEznVku => RMrLdQiLLmoKMurKDMJfjnqbgaWQ.pFMFRzEdyhxELHWIZmqtzsEznVku;

			public float TypfQRgIxbOVRytkNxUudjSFEOKq => RMrLdQiLLmoKMurKDMJfjnqbgaWQ.TypfQRgIxbOVRytkNxUudjSFEOKq;

			public float nKzkaWTntQizTHlSOlBLlzbHjrF => RMrLdQiLLmoKMurKDMJfjnqbgaWQ.nKzkaWTntQizTHlSOlBLlzbHjrF;

			internal double jGTAfcHYNecoRNTlKuGtdvFZACxbb => iCLMwyDnTRjqAVMtEjNdeqOKWzQ.elapsedSeconds + bwlkKFEMjtwZZRtwDfkkcxWqnVBe;

			public uint WIrjufOYMVKYdFHdgPrcSgNBuLui => RMrLdQiLLmoKMurKDMJfjnqbgaWQ.WIrjufOYMVKYdFHdgPrcSgNBuLui;

			public uint wHMbQwkEiGmAGdhvpttevTwiffYaA => RMrLdQiLLmoKMurKDMJfjnqbgaWQ.wHMbQwkEiGmAGdhvpttevTwiffYaA;

			public uint YTBDkBquXTlNQBVsBCRPTfayRLVc => RwBPKMnErLwNdsIthcTXePYYibkt;

			public yRkaAGhHJbjaAfJOVhXZUtCRPFjNA()
			{
				iCLMwyDnTRjqAVMtEjNdeqOKWzQ = NSDoQflkgxTjnZtWEQEAfEzrAgQcA.ucGpGFvhjlGdsxuFlLVQodlIBIac;
				ooNidbhWzBcZZJydutNALDEuSswc();
			}

			public void cALQIhRaREIQMhCuKXfVXrDZfbVs()
			{
				bwlkKFEMjtwZZRtwDfkkcxWqnVBe = Time.realtimeSinceStartup;
			}

			public void ooNidbhWzBcZZJydutNALDEuSswc()
			{
				RMrLdQiLLmoKMurKDMJfjnqbgaWQ = null;
				mOmDiOAylYvqtKUkBXRWeVPbgFUhb = new ADictionary<int, hkhGqHspuahDxMNQPZtjBYMQSFrs>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)2147483647, list);
				for (int i = 0; i < list.Count; i++)
				{
					hkhGqHspuahDxMNQPZtjBYMQSFrs hkhGqHspuahDxMNQPZtjBYMQSFrs2 = new hkhGqHspuahDxMNQPZtjBYMQSFrs(list[i]);
					mOmDiOAylYvqtKUkBXRWeVPbgFUhb.Add((int)list[i], hkhGqHspuahDxMNQPZtjBYMQSFrs2);
					if (RMrLdQiLLmoKMurKDMJfjnqbgaWQ == null)
					{
						RMrLdQiLLmoKMurKDMJfjnqbgaWQ = hkhGqHspuahDxMNQPZtjBYMQSFrs2;
					}
				}
			}

			public void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
			{
				if (RMrLdQiLLmoKMurKDMJfjnqbgaWQ.KKlbldiDPbDuxfifcGjVGpjaqJEqB != P_0)
				{
					RMrLdQiLLmoKMurKDMJfjnqbgaWQ = mOmDiOAylYvqtKUkBXRWeVPbgFUhb[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					RMrLdQiLLmoKMurKDMJfjnqbgaWQ.sOLNzBCCbZmFXkMugfndpShqgrUP();
					RwBPKMnErLwNdsIthcTXePYYibkt = MiscTools.Tick(RwBPKMnErLwNdsIthcTXePYYibkt);
					absFrame = RwBPKMnErLwNdsIthcTXePYYibkt;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch WjQAaHwnldjGbWthvILYYAgChYHq;

			internal static UnityTouch lbAduzmBhLEnHYIeWdaLoLCiGFSC => WjQAaHwnldjGbWthvILYYAgChYHq ?? (WjQAaHwnldjGbWthvILYYAgChYHq = new UnityTouch());

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

		internal class VIpHHbminxOEQUZnmfcdQcAMhDZDA
		{
			[Serializable]
			private sealed class EPbTUEpCePfOnFZGoYmQPjqYAEiY
			{
				public static readonly EPbTUEpCePfOnFZGoYmQPjqYAEiY _003C_003E9 = new EPbTUEpCePfOnFZGoYmQPjqYAEiY();

				public static Func<bool> _003C_003E9__11_1;

				public static Func<bool> _003C_003E9__11_2;

				public static Func<int> _003C_003E9__11_3;

				public static Func<float> _003C_003E9__11_4;

				public static Func<bool> _003C_003E9__11_5;

				public static Func<string> _003C_003E9__11_0;

				internal bool eCuvqnNuiacLLYdDfwrholZIjoPQ()
				{
					return Screen.fullScreen;
				}

				internal bool QRRPLYROgJsrFPjEIcVmeqbIUbIE()
				{
					return Application.runInBackground;
				}

				internal int qRidascjfDkpLUYKoTyDilHsJCtC()
				{
					return (int)Screen.fullScreenMode;
				}

				internal float TLMbIJGnxdrubPJmGcvReWnHsnueA()
				{
					return Time.unscaledDeltaTime;
				}

				internal bool ZbYbpNVWMBWsgwyDoRXkOElsVHgC()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				internal string snOzlRajzXYRblwodGFlEALJmneI()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}
			}

			public readonly ValueWatcher<bool> FzbsNyUWhJkMFdEzPjPRgZViMPfw;

			public readonly ValueWatcher<bool> XuHSAthgpDzCdtDHZPeWHpzkAvLbA;

			public readonly ValueWatcher<bool> oflHewLIhoAXLooWQloPgHLmDCsIA;

			public readonly ValueWatcher<int> yaTWBuyJKYQHJKBtEFmGiCnezgmSA;

			public readonly ValueWatcher<float> pFMFRzEdyhxELHWIZmqtzsEznVku;

			public readonly ValueWatcher<string> FRTVgyoqXTTaNFfBWXVmXiRbXibX;

			public readonly ValueWatcher<bool> fHzbwjUdIFEbqiEHIwTGuNaUaRUlA;

			private int MpTxISTzKGaelgEmrFFSoTtjRclB;

			private readonly ValueWatcher[] LDrwbPEvURlltFrpsEOENqsqUQQV;

			public int doZLsZRgYxDwomvvWqCNGeRMTGMI => MpTxISTzKGaelgEmrFFSoTtjRclB;

			public VIpHHbminxOEQUZnmfcdQcAMhDZDA()
			{
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(FzbsNyUWhJkMFdEzPjPRgZViMPfw = new ValueWatcher<bool>(true, false)),
					(XuHSAthgpDzCdtDHZPeWHpzkAvLbA = new ValueWatcher<bool>(Screen.fullScreen, EPbTUEpCePfOnFZGoYmQPjqYAEiY._003C_003E9.eCuvqnNuiacLLYdDfwrholZIjoPQ, false)),
					(oflHewLIhoAXLooWQloPgHLmDCsIA = new ValueWatcher<bool>(Application.runInBackground, EPbTUEpCePfOnFZGoYmQPjqYAEiY._003C_003E9.QRRPLYROgJsrFPjEIcVmeqbIUbIE, false)),
					(yaTWBuyJKYQHJKBtEFmGiCnezgmSA = new ValueWatcher<int>((int)Screen.fullScreenMode, EPbTUEpCePfOnFZGoYmQPjqYAEiY._003C_003E9.qRidascjfDkpLUYKoTyDilHsJCtC, false)),
					(pFMFRzEdyhxELHWIZmqtzsEznVku = new ValueWatcher<float>(Time.unscaledDeltaTime, EPbTUEpCePfOnFZGoYmQPjqYAEiY._003C_003E9.TLMbIJGnxdrubPJmGcvReWnHsnueA, false)),
					(fHzbwjUdIFEbqiEHIwTGuNaUaRUlA = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), EPbTUEpCePfOnFZGoYmQPjqYAEiY._003C_003E9.ZbYbpNVWMBWsgwyDoRXkOElsVHgC, MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(FRTVgyoqXTTaNFfBWXVmXiRbXibX = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), EPbTUEpCePfOnFZGoYmQPjqYAEiY._003C_003E9.snOzlRajzXYRblwodGFlEALJmneI, false));
				}
				LDrwbPEvURlltFrpsEOENqsqUQQV = list.ToArray();
				sOLNzBCCbZmFXkMugfndpShqgrUP();
			}

			public void sOLNzBCCbZmFXkMugfndpShqgrUP()
			{
				for (int i = 0; i < LDrwbPEvURlltFrpsEOENqsqUQQV.Length; i++)
				{
					LDrwbPEvURlltFrpsEOENqsqUQQV[i].Update();
				}
				MpTxISTzKGaelgEmrFFSoTtjRclB = Time.frameCount;
			}

			public void rmDhkvCLKiRwpZPntUFXxmTjOnUE()
			{
				for (int i = 0; i < LDrwbPEvURlltFrpsEOENqsqUQQV.Length; i++)
				{
					LDrwbPEvURlltFrpsEOENqsqUQQV[i].TriggerEvent();
				}
			}
		}

		[Serializable]
		private sealed class fnxCvfZoSNZzOUDHzruZgJsBHbLk
		{
			public static readonly fnxCvfZoSNZzOUDHzruZgJsBHbLk _003C_003E9 = new fnxCvfZoSNZzOUDHzruZgJsBHbLk();

			public static Func<bool> _003C_003E9__222_0;

			internal void YEiiuyBSbupqkbbLAAYPucsLFTDib(Exception P_0)
			{
				HandleCallbackException("", P_0);
			}

			internal void ClLCPDQDaiWUzDvTqQxcEBOpSAye(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			}

			internal void UgfHmBroNArmKzavcBWdCkxPASoVA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			}

			internal void DkVplsUfAJwZmYRHLaiywdCnmGIl(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			}

			internal void jMDCMookOwmHLCEOpubAzqFBCjpI(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			}

			internal void pibhbhEHKkEWugWldbGbBXeIfAosB(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			}

			internal void ZZTVaKpAcOsPKIkxHZtuTIgSaFPm(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			}

			internal void wprRElxKhYbBflxhaVBzpfycFtYN(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			}

			internal void XUIuPJbLgHECIUhIhpOIVkGAglxS(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			}

			internal bool xLVCerGkNRkfYZqzZpmsGzMdHDbfA()
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
		internal const int programVersion3 = 44;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 0;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2021";

		private static InputManager_Base CVOosweFQkjenKNkyCghUKMwQzfI;

		private static PlatformInputManager DsUMFOuNrADSwelafhXWALBVQljt;

		internal static uwbgviXXIJPMnGJRVuzdFTgToYVv TcJeRjoAHWajdfxVaSabfTeqWDcy;

		internal static sQUhNuelsgdElREOuzBUnZbPDjkc OkLkjfkBGntRAvakyAvYRRgphMAiA;

		internal static OHBxQeqzwpSOXtKiahobKGuCdFjeb ajnOsEopTWvzJZjeDpcpYppqmqOw;

		private static ControllerDataFiles yuMAFKYlLRXHYECDtAfqrzgtWNno;

		private static UserData dhXuTEEziWFtUyjdydeOTtEMceSv;

		private static bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		private static ConfigVars HhUekGiZgESvZmOBirudgfCplDISA;

		private static UpdateLoopType SGbCYHanXXzBiWnXJzwBdELpFDCnA;

		private static bool xAXgrgTBrSfWQOaiATiEGRGhgWIC;

		private static Platform fzICSMslIAIogSLDYlSBPLBPiOoF;

		private static WebplayerPlatform ZpqltcgNrXUHCRtunjsQsaPwjfOIA;

		private static EditorPlatform vLtJrfESYPgDQDnGZPJTJqwWHIYlA;

		private static bool fPVGIFZOaraUFNEsjBjKxdJKjsBQ;

		private static TimerAbs SKyvYsUBAlhUEnadFFWMiAvAKNBDA;

		private static yRkaAGhHJbjaAfJOVhXZUtCRPFjNA DnguBusOPRzgVZOfVVmqrxdKVdpS;

		private static string hubgZmpbFjYDnMCksJvcpKfkxjuv;

		private static bool iAJESsWCiSvwBPNuAGiTFudrWkqL;

		private static bool JjXaHxVjZWMdZXJTNveiFRgxzXWe;

		private static bool xKPALbkrgWCQScxZCiBgyXBoonOyb;

		private static int XLiQYniPJQiCkGaxLchxZGvMEWgu;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int vAglbVJjRYqmigMCSfjCzWtGUPmo;

		private static int ZWsLEIbTkRLpeQxDCxjhyNRcUgKf;

		private static bool UsGQqdiGSRcgPzJccGZACMQWxRDlA;

		private static readonly UnityTouch jGgaTfdbIjOdGOdWkTriQCMbvhmP;

		private static readonly PlayerHelper HCNMZHRpLUkaDYlhLuwVXMJnNaHH;

		private static readonly ControllerHelper DlOHerLmRxyzOIuoeNyIHucbqbre;

		private static readonly MappingHelper pGAMRUtdDRjJOscfVgAobcYfwNfu;

		private static readonly TimeHelper bDOPsIGutLtEYlTWXQWNmcMNjujH;

		private static readonly ConfigHelper yjCktTGHyEtCBXqulFPfUZZAhDTD;

		private static BlhfMSqWdxGGmkrOLnhytYOWBVcP rNtPPZNSNevjaLXalgxBLmCULitH;

		private static UserDataStore WxMFnEYRcWmtcAezaIddwROfarEG;

		private static IControllerAssigner VBDkcaxujnFiYdBuOjuquSnyqjHE;

		private static VIpHHbminxOEQUZnmfcdQcAMhDZDA HeYakTEtCHWQxVwCyeqMlkZOUQafA;

		private static SafeAction<ControllerStatusChangedEventArgs> lFjrTanwbFwsbvgdYLZmBLvoFVkp;

		private static SafeAction<ControllerStatusChangedEventArgs> AqxDSCKdbkAKVwJYDWnhpyNDIyGQA;

		private static SafeAction<ControllerStatusChangedEventArgs> IygYEaSeXkocaFAKApGKrzOiCMIN;

		private static SafeAction EEvWOInbYwCpcrCfajmNfbyGrZAW;

		private static SafeAction OEfCNSKRaPIivtobaVBYGskOnHSh;

		private static SafeAction ApceFuDOxIppDLINvkfawFPcEthz;

		private static SafeAction YfHioobrCzormgbBBCmuqPfBAiGY;

		private static SafeAction ugluxrYYSXYofgwlByxDuTjacgpE;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action RXmlFWBfUsIbqgkTuejcfSOCHAWZ;

		private static Action<UpdateLoopType> COduTVCXoOVuRWiPKOjmEnRXLeND;

		private static Action<UpdateLoopType> ADpqDtxhaJkoGNlXgcqrdfKmlXscA;

		private static Action<UpdateLoopType> YWlOwyefRtPCLfngYWjLjwUcFjOt;

		private static Action ahHahVIVNwaZZPYXNpDPsAAjJLqGb;

		private static Action<bool> zpEdOYsGkXCCYuGYtLGyAaQZgnccA;

		private static Action<bool> GAkHzoGpoOPydMlwUwOvmvAhwbjc;

		private static Action<bool> NhobUMgUqklZnceVoRWjKhBdqvhu;

		private static Action<FullScreenMode> RmykIGJsGMxYoPLvQMNFFeTWLBXJ;

		private static Action vMeZFKVtjhxTgXBKbxLTKDVbcsgv;

		private static Action<bool> IpQzbRBLicjyYdGDxswJfmHjaOFS;

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

		private static BlhfMSqWdxGGmkrOLnhytYOWBVcP ZMMbmdkWhjAWAhXVeHcFydUeJIjqb => rNtPPZNSNevjaLXalgxBLmCULitH ?? (rNtPPZNSNevjaLXalgxBLmCULitH = new BlhfMSqWdxGGmkrOLnhytYOWBVcP(HhUekGiZgESvZmOBirudgfCplDISA.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					YGumDYhdZrtzIaNogMoqVpLRnpnf();
					return null;
				}
				return HCNMZHRpLUkaDYlhLuwVXMJnNaHH;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					YGumDYhdZrtzIaNogMoqVpLRnpnf();
					return null;
				}
				return DlOHerLmRxyzOIuoeNyIHucbqbre;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					YGumDYhdZrtzIaNogMoqVpLRnpnf();
					return null;
				}
				return pGAMRUtdDRjJOscfVgAobcYfwNfu;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					YGumDYhdZrtzIaNogMoqVpLRnpnf();
					return null;
				}
				return jGgaTfdbIjOdGOdWkTriQCMbvhmP;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					YGumDYhdZrtzIaNogMoqVpLRnpnf();
					return null;
				}
				return bDOPsIGutLtEYlTWXQWNmcMNjujH;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					YGumDYhdZrtzIaNogMoqVpLRnpnf();
					return null;
				}
				return WxMFnEYRcWmtcAezaIddwROfarEG;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					YGumDYhdZrtzIaNogMoqVpLRnpnf();
					return null;
				}
				return yjCktTGHyEtCBXqulFPfUZZAhDTD;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 44 + "." + 0 + ".U2021";

		public static bool usingUnityInput => xAXgrgTBrSfWQOaiATiEGRGhgWIC;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
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

		public static bool isReady => juAmOHdlEuZcdEbopfsigKMAJgtHb;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => juAmOHdlEuZcdEbopfsigKMAJgtHb;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => SGbCYHanXXzBiWnXJzwBdELpFDCnA;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => HhUekGiZgESvZmOBirudgfCplDISA;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => HhUekGiZgESvZmOBirudgfCplDISA;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => dhXuTEEziWFtUyjdydeOTtEMceSv;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => fzICSMslIAIogSLDYlSBPLBPiOoF;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => ZpqltcgNrXUHCRtunjsQsaPwjfOIA;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => vLtJrfESYPgDQDnGZPJTJqwWHIYlA;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.Linux && xAXgrgTBrSfWQOaiATiEGRGhgWIC)
				{
					return true;
				}
				if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.OSX && (xAXgrgTBrSfWQOaiATiEGRGhgWIC || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && xAXgrgTBrSfWQOaiATiEGRGhgWIC)
				{
					return true;
				}
				if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.Webplayer && ZpqltcgNrXUHCRtunjsQsaPwjfOIA == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => vLtJrfESYPgDQDnGZPJTJqwWHIYlA != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					return Guid.Empty;
				}
				return yuMAFKYlLRXHYECDtAfqrzgtWNno.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => JjXaHxVjZWMdZXJTNveiFRgxzXWe;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => DnguBusOPRzgVZOfVVmqrxdKVdpS.TypfQRgIxbOVRytkNxUudjSFEOKq;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => DnguBusOPRzgVZOfVVmqrxdKVdpS.nKzkaWTntQizTHlSOlBLlzbHjrF;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					return 0.0;
				}
				return DnguBusOPRzgVZOfVVmqrxdKVdpS.jGTAfcHYNecoRNTlKuGtdvFZACxbb;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					return 0;
				}
				return HeYakTEtCHWQxVwCyeqMlkZOUQafA.doZLsZRgYxDwomvvWqCNGeRMTGMI;
			}
		}

		private static bool qvZgiXjUPTsUgDmcMQvfwLWeZiCuA
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return hubgZmpbFjYDnMCksJvcpKfkxjuv == "Game";
				}
				return hubgZmpbFjYDnMCksJvcpKfkxjuv == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (HhUekGiZgESvZmOBirudgfCplDISA.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!xKPALbkrgWCQScxZCiBgyXBoonOyb)
				{
					return qvZgiXjUPTsUgDmcMQvfwLWeZiCuA;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (DsUMFOuNrADSwelafhXWALBVQljt is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return xKPALbkrgWCQScxZCiBgyXBoonOyb;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					return false;
				}
				if (!xAXgrgTBrSfWQOaiATiEGRGhgWIC)
				{
					return false;
				}
				if (fzICSMslIAIogSLDYlSBPLBPiOoF != Platform.Windows && (fzICSMslIAIogSLDYlSBPLBPiOoF != Platform.Webplayer || ZpqltcgNrXUHCRtunjsQsaPwjfOIA != WebplayerPlatform.Windows))
				{
					return vLtJrfESYPgDQDnGZPJTJqwWHIYlA == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool vNfnJueJAfZDitForEnRPJbxpOkQ
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					return false;
				}
				if (!HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.value)
				{
					if (UsGQqdiGSRcgPzJccGZACMQWxRDlA)
					{
						return false;
					}
					if (!isEditor && !HeYakTEtCHWQxVwCyeqMlkZOUQafA.oflHewLIhoAXLooWQloPgHLmDCsIA.value)
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
				if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					return HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					return HeYakTEtCHWQxVwCyeqMlkZOUQafA.XuHSAthgpDzCdtDHZPeWHpzkAvLbA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					return HeYakTEtCHWQxVwCyeqMlkZOUQafA.oflHewLIhoAXLooWQloPgHLmDCsIA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					return HeYakTEtCHWQxVwCyeqMlkZOUQafA.fHzbwjUdIFEbqiEHIwTGuNaUaRUlA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => CVOosweFQkjenKNkyCghUKMwQzfI;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
				{
					YGumDYhdZrtzIaNogMoqVpLRnpnf();
					return null;
				}
				return DsUMFOuNrADSwelafhXWALBVQljt.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return VBDkcaxujnFiYdBuOjuquSnyqjHE;
			}
			set
			{
				VBDkcaxujnFiYdBuOjuquSnyqjHE = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => ZWsLEIbTkRLpeQxDCxjhyNRcUgKf;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				lFjrTanwbFwsbvgdYLZmBLvoFVkp += value;
			}
			remove
			{
				lFjrTanwbFwsbvgdYLZmBLvoFVkp -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				AqxDSCKdbkAKVwJYDWnhpyNDIyGQA += value;
			}
			remove
			{
				AqxDSCKdbkAKVwJYDWnhpyNDIyGQA -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				IygYEaSeXkocaFAKApGKrzOiCMIN += value;
			}
			remove
			{
				IygYEaSeXkocaFAKApGKrzOiCMIN -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				EEvWOInbYwCpcrCfajmNfbyGrZAW += value;
			}
			remove
			{
				EEvWOInbYwCpcrCfajmNfbyGrZAW -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				OEfCNSKRaPIivtobaVBYGskOnHSh += value;
			}
			remove
			{
				OEfCNSKRaPIivtobaVBYGskOnHSh -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				ApceFuDOxIppDLINvkfawFPcEthz += value;
			}
			remove
			{
				ApceFuDOxIppDLINvkfawFPcEthz -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				YfHioobrCzormgbBBCmuqPfBAiGY += value;
			}
			remove
			{
				YfHioobrCzormgbBBCmuqPfBAiGY -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				ugluxrYYSXYofgwlByxDuTjacgpE += value;
			}
			remove
			{
				ugluxrYYSXYofgwlByxDuTjacgpE -= value;
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
				RXmlFWBfUsIbqgkTuejcfSOCHAWZ = (Action)Delegate.Combine(RXmlFWBfUsIbqgkTuejcfSOCHAWZ, value);
			}
			remove
			{
				RXmlFWBfUsIbqgkTuejcfSOCHAWZ = (Action)Delegate.Remove(RXmlFWBfUsIbqgkTuejcfSOCHAWZ, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				COduTVCXoOVuRWiPKOjmEnRXLeND = (Action<UpdateLoopType>)Delegate.Combine(COduTVCXoOVuRWiPKOjmEnRXLeND, value);
			}
			remove
			{
				COduTVCXoOVuRWiPKOjmEnRXLeND = (Action<UpdateLoopType>)Delegate.Remove(COduTVCXoOVuRWiPKOjmEnRXLeND, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				ADpqDtxhaJkoGNlXgcqrdfKmlXscA = (Action<UpdateLoopType>)Delegate.Combine(ADpqDtxhaJkoGNlXgcqrdfKmlXscA, value);
			}
			remove
			{
				ADpqDtxhaJkoGNlXgcqrdfKmlXscA = (Action<UpdateLoopType>)Delegate.Remove(ADpqDtxhaJkoGNlXgcqrdfKmlXscA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				YWlOwyefRtPCLfngYWjLjwUcFjOt = (Action<UpdateLoopType>)Delegate.Combine(YWlOwyefRtPCLfngYWjLjwUcFjOt, value);
			}
			remove
			{
				YWlOwyefRtPCLfngYWjLjwUcFjOt = (Action<UpdateLoopType>)Delegate.Remove(YWlOwyefRtPCLfngYWjLjwUcFjOt, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				ahHahVIVNwaZZPYXNpDPsAAjJLqGb = (Action)Delegate.Combine(ahHahVIVNwaZZPYXNpDPsAAjJLqGb, value);
			}
			remove
			{
				ahHahVIVNwaZZPYXNpDPsAAjJLqGb = (Action)Delegate.Remove(ahHahVIVNwaZZPYXNpDPsAAjJLqGb, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				zpEdOYsGkXCCYuGYtLGyAaQZgnccA = (Action<bool>)Delegate.Combine(zpEdOYsGkXCCYuGYtLGyAaQZgnccA, value);
			}
			remove
			{
				zpEdOYsGkXCCYuGYtLGyAaQZgnccA = (Action<bool>)Delegate.Remove(zpEdOYsGkXCCYuGYtLGyAaQZgnccA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				GAkHzoGpoOPydMlwUwOvmvAhwbjc = (Action<bool>)Delegate.Combine(GAkHzoGpoOPydMlwUwOvmvAhwbjc, value);
			}
			remove
			{
				GAkHzoGpoOPydMlwUwOvmvAhwbjc = (Action<bool>)Delegate.Remove(GAkHzoGpoOPydMlwUwOvmvAhwbjc, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				NhobUMgUqklZnceVoRWjKhBdqvhu = (Action<bool>)Delegate.Combine(NhobUMgUqklZnceVoRWjKhBdqvhu, value);
			}
			remove
			{
				NhobUMgUqklZnceVoRWjKhBdqvhu = (Action<bool>)Delegate.Remove(NhobUMgUqklZnceVoRWjKhBdqvhu, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				RmykIGJsGMxYoPLvQMNFFeTWLBXJ = (Action<FullScreenMode>)Delegate.Combine(RmykIGJsGMxYoPLvQMNFFeTWLBXJ, value);
			}
			remove
			{
				RmykIGJsGMxYoPLvQMNFFeTWLBXJ = (Action<FullScreenMode>)Delegate.Remove(RmykIGJsGMxYoPLvQMNFFeTWLBXJ, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				vMeZFKVtjhxTgXBKbxLTKDVbcsgv = (Action)Delegate.Combine(vMeZFKVtjhxTgXBKbxLTKDVbcsgv, value);
			}
			remove
			{
				vMeZFKVtjhxTgXBKbxLTKDVbcsgv = (Action)Delegate.Remove(vMeZFKVtjhxTgXBKbxLTKDVbcsgv, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				IpQzbRBLicjyYdGDxswJfmHjaOFS = (Action<bool>)Delegate.Combine(IpQzbRBLicjyYdGDxswJfmHjaOFS, value);
			}
			remove
			{
				IpQzbRBLicjyYdGDxswJfmHjaOFS = (Action<bool>)Delegate.Remove(IpQzbRBLicjyYdGDxswJfmHjaOFS, value);
			}
		}

		static ReInput()
		{
			xKPALbkrgWCQScxZCiBgyXBoonOyb = true;
			XLiQYniPJQiCkGaxLchxZGvMEWgu = -1;
			_id = -1;
			vAglbVJjRYqmigMCSfjCzWtGUPmo = 0;
			jGgaTfdbIjOdGOdWkTriQCMbvhmP = UnityTouch.lbAduzmBhLEnHYIeWdaLoLCiGFSC;
			HCNMZHRpLUkaDYlhLuwVXMJnNaHH = PlayerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC;
			DlOHerLmRxyzOIuoeNyIHucbqbre = ControllerHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC;
			pGAMRUtdDRjJOscfVgAobcYfwNfu = MappingHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC;
			bDOPsIGutLtEYlTWXQWNmcMNjujH = TimeHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC;
			yjCktTGHyEtCBXqulFPfUZZAhDTD = ConfigHelper.lbAduzmBhLEnHYIeWdaLoLCiGFSC;
			lFjrTanwbFwsbvgdYLZmBLvoFVkp = new SafeAction<ControllerStatusChangedEventArgs>(fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.ClLCPDQDaiWUzDvTqQxcEBOpSAye);
			AqxDSCKdbkAKVwJYDWnhpyNDIyGQA = new SafeAction<ControllerStatusChangedEventArgs>(fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.UgfHmBroNArmKzavcBWdCkxPASoVA);
			IygYEaSeXkocaFAKApGKrzOiCMIN = new SafeAction<ControllerStatusChangedEventArgs>(fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.DkVplsUfAJwZmYRHLaiywdCnmGIl);
			EEvWOInbYwCpcrCfajmNfbyGrZAW = new SafeAction(fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.jMDCMookOwmHLCEOpubAzqFBCjpI);
			OEfCNSKRaPIivtobaVBYGskOnHSh = new SafeAction(fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.pibhbhEHKkEWugWldbGbBXeIfAosB);
			ApceFuDOxIppDLINvkfawFPcEthz = new SafeAction(fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.ZZTVaKpAcOsPKIkxHZtuTIgSaFPm);
			YfHioobrCzormgbBBCmuqPfBAiGY = new SafeAction(fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.wprRElxKhYbBflxhaVBzpfycFtYN);
			ugluxrYYSXYofgwlByxDuTjacgpE = new SafeAction(fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.XUIuPJbLgHECIUhIhpOIVkGAglxS);
			SafeDelegate.S_ExceptionHandler = fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.YEiiuyBSbupqkbbLAAYPucsLFTDib;
		}

		public static void Reset()
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb && !(CVOosweFQkjenKNkyCghUKMwQzfI == null))
			{
				CVOosweFQkjenKNkyCghUKMwQzfI.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!vNfnJueJAfZDitForEnRPJbxpOkQ)
			{
				return false;
			}
			if (vLtJrfESYPgDQDnGZPJTJqwWHIYlA != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (UsGQqdiGSRcgPzJccGZACMQWxRDlA)
				{
					if (!HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.value)
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

		private static void sUcupMLOUYqoJsYPEvQJZJQLKuaM()
		{
			fzICSMslIAIogSLDYlSBPLBPiOoF = UnityTools.platform;
			ZpqltcgNrXUHCRtunjsQsaPwjfOIA = UnityTools.webplayerPlatform;
			vLtJrfESYPgDQDnGZPJTJqwWHIYlA = UnityTools.editorPlatform;
		}

		internal static void gUxczTgMdKUcYRnCXamteWaCXJodc(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, UnityTools.dLTpFXVUEoYOHBezYpFOWYkDPuSf P_5, Action<Platform> P_6)
		{
			try
			{
				UnityTools.gUxczTgMdKUcYRnCXamteWaCXJodc(P_5);
				_id = vAglbVJjRYqmigMCSfjCzWtGUPmo;
				vAglbVJjRYqmigMCSfjCzWtGUPmo++;
				juAmOHdlEuZcdEbopfsigKMAJgtHb = true;
				iAJESsWCiSvwBPNuAGiTFudrWkqL = true;
				JjXaHxVjZWMdZXJTNveiFRgxzXWe = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				CVOosweFQkjenKNkyCghUKMwQzfI = P_0;
				HhUekGiZgESvZmOBirudgfCplDISA = P_2;
				sUcupMLOUYqoJsYPEvQJZJQLKuaM();
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += loBFxBFIfYAnvaKTVuCDYNGMOeRuA;
				yuMAFKYlLRXHYECDtAfqrzgtWNno = P_3;
				dhXuTEEziWFtUyjdydeOTtEMceSv = P_4;
				P_4.gUxczTgMdKUcYRnCXamteWaCXJodc();
				ThreadSafeUnityInput.Initialize();
				HeYakTEtCHWQxVwCyeqMlkZOUQafA = new VIpHHbminxOEQUZnmfcdQcAMhDZDA();
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.Set(xKPALbkrgWCQScxZCiBgyXBoonOyb);
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.Use();
				if (vLtJrfESYPgDQDnGZPJTJqwWHIYlA != EditorPlatform.None)
				{
					HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.getValueDelegate = fnxCvfZoSNZzOUDHzruZgJsBHbLk._003C_003E9.xLVCerGkNRkfYZqzZpmsGzMdHDbfA;
					if (JjXaHxVjZWMdZXJTNveiFRgxzXWe)
					{
						xKPALbkrgWCQScxZCiBgyXBoonOyb = qvZgiXjUPTsUgDmcMQvfwLWeZiCuA;
					}
					HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				QMAuRSCtiiPBefUgCEgxlSpgiek();
				SKyvYsUBAlhUEnadFFWMiAvAKNBDA = new TimerAbs(1.0);
				DnguBusOPRzgVZOfVVmqrxdKVdpS = new yRkaAGhHJbjaAfJOVhXZUtCRPFjNA();
				NOVTJmKEcBJnXKENDhsxERaxmxqZA(P_1, P_5, P_6);
				TcJeRjoAHWajdfxVaSabfTeqWDcy = new uwbgviXXIJPMnGJRVuzdFTgToYVv(P_4.GetActions_Copy());
				OkLkjfkBGntRAvakyAvYRRgphMAiA = new sQUhNuelsgdElREOuzBUnZbPDjkc(P_2, DsUMFOuNrADSwelafhXWALBVQljt);
				ajnOsEopTWvzJZjeDpcpYppqmqOw = new OHBxQeqzwpSOXtKiahobKGuCdFjeb(P_2);
				DsUMFOuNrADSwelafhXWALBVQljt.DeviceConnectedEvent += zuPDFemqfyqKDOPSiYxjlNcdheek;
				DsUMFOuNrADSwelafhXWALBVQljt.DeviceDisconnectedEvent += CBOWnXpWSeIFjcCDmASmPwHMJPns;
				DsUMFOuNrADSwelafhXWALBVQljt.UpdateControllerInfoEvent += MQDslrblFnFPIksPJgNEutAbEGAJ;
				OkLkjfkBGntRAvakyAvYRRgphMAiA.zwLQnBPuyyNbeEdvWfIoruZHUzzK += lTPylGLYTtJZuyYypBZCODWvMGlN;
				OkLkjfkBGntRAvakyAvYRRgphMAiA.jmRLvdXZkKvdTejFUipRjxOZcXKdA += ajnOsEopTWvzJZjeDpcpYppqmqOw.xpgVMmFHxyxDDkbSYqwGfzQvNGmG;
				ThreadSafeUnityInput.PostInitialize();
				yBzFvgVjNOcORWMCZCNKYbHzydvO();
				ThreadSafeUnityInput.PostInitialize2();
				WxMFnEYRcWmtcAezaIddwROfarEG = UnityTools.GetComponent<UserDataStore>(CVOosweFQkjenKNkyCghUKMwQzfI);
				if (WxMFnEYRcWmtcAezaIddwROfarEG != null)
				{
					WxMFnEYRcWmtcAezaIddwROfarEG.Initialize();
				}
				zHtQLVrCGGvBPKxwkomJDaOttjfr();
				iAJESsWCiSvwBPNuAGiTFudrWkqL = false;
				if (JjXaHxVjZWMdZXJTNveiFRgxzXWe)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (ugluxrYYSXYofgwlByxDuTjacgpE != null)
				{
					ugluxrYYSXYofgwlByxDuTjacgpE.Invoke();
				}
			}
			catch (Exception)
			{
				juAmOHdlEuZcdEbopfsigKMAJgtHb = false;
				iAJESsWCiSvwBPNuAGiTFudrWkqL = false;
				throw;
			}
		}

		internal static void rIjUCmsjifmvcBNTbhJRFVmmqsqk()
		{
			if (DnguBusOPRzgVZOfVVmqrxdKVdpS != null)
			{
				DnguBusOPRzgVZOfVVmqrxdKVdpS.cALQIhRaREIQMhCuKXfVXrDZfbVs();
			}
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < OkLkjfkBGntRAvakyAvYRRgphMAiA.NcFhTqaznBUbORimVwWyLExKyNzx; i++)
				{
					Joystick joystick = OkLkjfkBGntRAvakyAvYRRgphMAiA.KGdLENWcPYxILUyAVplYwyvHjPaK[i];
					IAPYElNTdXAKYNaUXIwNJJAgppzx(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		internal static void KaOzEMzQwGGQbJUsZJreBHvRCACe(UpdateLoopType P_0)
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				svfvzlkpCJMaoNonneqvLHqMEJebA(P_0);
				if ((uint)P_0 <= 1u)
				{
					WzrFbEIYDXnXJJKfZWrdDRDBkdwV();
				}
			}
		}

		private static void svfvzlkpCJMaoNonneqvLHqMEJebA(UpdateLoopType P_0)
		{
			if (HeYakTEtCHWQxVwCyeqMlkZOUQafA != null)
			{
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.sOLNzBCCbZmFXkMugfndpShqgrUP();
			}
			Action<UpdateLoopType> cOduTVCXoOVuRWiPKOjmEnRXLeND = COduTVCXoOVuRWiPKOjmEnRXLeND;
			if (cOduTVCXoOVuRWiPKOjmEnRXLeND != null)
			{
				try
				{
					cOduTVCXoOVuRWiPKOjmEnRXLeND(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.BeforeTimeManagerUpdateEvent", exception);
				}
			}
			DnguBusOPRzgVZOfVVmqrxdKVdpS.sOLNzBCCbZmFXkMugfndpShqgrUP(P_0);
		}

		private static void WzrFbEIYDXnXJJKfZWrdDRDBkdwV()
		{
			int frameCount = Time.frameCount;
			if (XLiQYniPJQiCkGaxLchxZGvMEWgu == frameCount)
			{
				return;
			}
			XLiQYniPJQiCkGaxLchxZGvMEWgu = frameCount;
			ThreadSafeUnityInput.Update();
			Action rXmlFWBfUsIbqgkTuejcfSOCHAWZ = RXmlFWBfUsIbqgkTuejcfSOCHAWZ;
			if (rXmlFWBfUsIbqgkTuejcfSOCHAWZ == null)
			{
				return;
			}
			try
			{
				rXmlFWBfUsIbqgkTuejcfSOCHAWZ();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.EarlyUpdateEvent", exception);
			}
		}

		internal static void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return;
			}
			if (SGbCYHanXXzBiWnXJzwBdELpFDCnA != P_0)
			{
				SGbCYHanXXzBiWnXJzwBdELpFDCnA = P_0;
			}
			if (editorPlatform != EditorPlatform.None)
			{
				hubgZmpbFjYDnMCksJvcpKfkxjuv = HeYakTEtCHWQxVwCyeqMlkZOUQafA.FRTVgyoqXTTaNFfBWXVmXiRbXibX.value;
			}
			if (fPVGIFZOaraUFNEsjBjKxdJKjsBQ)
			{
				if (SKyvYsUBAlhUEnadFFWMiAvAKNBDA.Update())
				{
					fPVGIFZOaraUFNEsjBjKxdJKjsBQ = false;
					SKyvYsUBAlhUEnadFFWMiAvAKNBDA.Clear();
				}
				else
				{
					ZMMbmdkWhjAWAhXVeHcFydUeJIjqb.sOLNzBCCbZmFXkMugfndpShqgrUP(P_0);
				}
			}
			HeYakTEtCHWQxVwCyeqMlkZOUQafA.rmDhkvCLKiRwpZPntUFXxmTjOnUE();
			Action<UpdateLoopType> aDpqDtxhaJkoGNlXgcqrdfKmlXscA = ADpqDtxhaJkoGNlXgcqrdfKmlXscA;
			if (aDpqDtxhaJkoGNlXgcqrdfKmlXscA != null)
			{
				try
				{
					aDpqDtxhaJkoGNlXgcqrdfKmlXscA(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.UpdateStartedEvent", exception);
				}
			}
			DsUMFOuNrADSwelafhXWALBVQljt.Update(P_0);
			if (EEvWOInbYwCpcrCfajmNfbyGrZAW != null)
			{
				EEvWOInbYwCpcrCfajmNfbyGrZAW.Invoke();
			}
			OkLkjfkBGntRAvakyAvYRRgphMAiA.sOLNzBCCbZmFXkMugfndpShqgrUP(P_0);
			Action<UpdateLoopType> yWlOwyefRtPCLfngYWjLjwUcFjOt = YWlOwyefRtPCLfngYWjLjwUcFjOt;
			if (yWlOwyefRtPCLfngYWjLjwUcFjOt == null)
			{
				return;
			}
			try
			{
				yWlOwyefRtPCLfngYWjLjwUcFjOt(P_0);
			}
			catch (Exception exception2)
			{
				HandleCallbackException("ReInput.UpdateEndedEvent", exception2);
			}
		}

		internal static void uLXyvePCedSwMMkyMFvfsofVDBow()
		{
			Action action = ahHahVIVNwaZZPYXNpDPsAAjJLqGb;
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
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb && JjXaHxVjZWMdZXJTNveiFRgxzXWe)
			{
				KaOzEMzQwGGQbJUsZJreBHvRCACe(UpdateLoopType.Update);
				sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType.Update);
				uLXyvePCedSwMMkyMFvfsofVDBow();
			}
		}

		internal static void WcpUpKbeoqbiydAkzwOTTWTeWpxZ()
		{
			if (ApceFuDOxIppDLINvkfawFPcEthz != null)
			{
				ApceFuDOxIppDLINvkfawFPcEthz.Invoke();
			}
			if (DsUMFOuNrADSwelafhXWALBVQljt != null)
			{
				DsUMFOuNrADSwelafhXWALBVQljt.OnDestroy();
			}
			DzVKzZZSNhcHFMNPFIbHEhBFuhklA();
			if (YfHioobrCzormgbBBCmuqPfBAiGY != null)
			{
				YfHioobrCzormgbBBCmuqPfBAiGY.Invoke();
				YfHioobrCzormgbBBCmuqPfBAiGY = null;
			}
		}

		internal static void yXlebcKsEYElFWWmmLxmjbkMPWSk()
		{
			if (OEfCNSKRaPIivtobaVBYGskOnHSh != null)
			{
				OEfCNSKRaPIivtobaVBYGskOnHSh.Invoke();
			}
		}

		internal static void qCIbeGpzyGSbMtIssFCnvdjbWWve(bool P_0)
		{
			xKPALbkrgWCQScxZCiBgyXBoonOyb = P_0;
			if (vLtJrfESYPgDQDnGZPJTJqwWHIYlA == EditorPlatform.None && juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.Set(P_0);
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.TriggerEvent();
			}
		}

		internal static void cwNEDzPBuXiKMVFqcGPDbpxotzck()
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return;
			}
			Action action = vMeZFKVtjhxTgXBKbxLTKDVbcsgv;
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
			return yuMAFKYlLRXHYECDtAfqrzgtWNno.JUQeGiiVcSIBjobjVMcWfQEEIqSO(bridgedController);
		}

		internal static HardwareJoystickMap iCFBeqngbahtgGTVxrPduMQZXdmW(Guid P_0)
		{
			return yuMAFKYlLRXHYECDtAfqrzgtWNno.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap wgDfcpFFKvqeeKkPsJPdHHqsdbZZA(Guid P_0)
		{
			return yuMAFKYlLRXHYECDtAfqrzgtWNno.GetJoystickTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap ZXAKBHNCXgchECAyMuaZmpieKvSPA(Guid P_0)
		{
			return yuMAFKYlLRXHYECDtAfqrzgtWNno.GetControllerTemplate(P_0);
		}

		internal static IList<HardwareJoystickTemplateMap> UUdaBjbHBlTkYdRHEciSYTDLHKiz(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = yuMAFKYlLRXHYECDtAfqrzgtWNno.GetHardwareJoystickMap(P_0);
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
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = wgDfcpFFKvqeeKkPsJPdHHqsdbZZA(guid);
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
			return OkLkjfkBGntRAvakyAvYRRgphMAiA.sBwCuaOSnNILoUKqPGJScxAFJcoTA();
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleCallbackException(string source, Exception exception)
		{
			Logger.LogError("An exception occurred inside an event handler or callback.\nSource: " + source + "\n\nThis happens if your event handler/callback code throws an exception. This means the error is in your code, not Rewired. Read the exception message and the stack trace carefully to find the source of the exception being thrown by your code.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed. Make sure you unsubscribe to events in OnDisable or OnDestroy. Rewired will attempt to continue running.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception), requiredThreadSafety: true);
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternException(string source, Exception exception)
		{
		}

		[CustomObfuscation(rename = false)]
		internal static void HandleExternalInterfaceException(string source, Exception exception)
		{
			Logger.LogError("An exception occurred inside an external function call.\nSource: " + source + "\n\nThis happens if the external function throws an exception. This could indicate the error is in your code if Rewired is calling a function in an interface implementation you created. Read the exception message and the stack trace carefully to find the source of the exception being thrown.\n\nThis can also happen if you forget to unsubscribe to an event in a MonoBehaviour class and that object gets destroyed.\n\nException:\n" + ((exception.InnerException != null) ? exception.InnerException : exception), requiredThreadSafety: true);
		}

		internal static void pvgucvcpEBlNTxuHHBVNqzamlReP()
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				zHtQLVrCGGvBPKxwkomJDaOttjfr();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2021 != UnityTools.unityVersionObj.major)
			{
				yiPLYmFMNyvRUXdhnNxGvpwaMcwb();
			}
		}

		internal static float ONcDHoNHsmreSyMftwbKquhWEVGf()
		{
			return HeYakTEtCHWQxVwCyeqMlkZOUQafA.pFMFRzEdyhxELHWIZmqtzsEznVku.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
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

		private static void yBzFvgVjNOcORWMCZCNKYbHzydvO()
		{
			ajnOsEopTWvzJZjeDpcpYppqmqOw.gUxczTgMdKUcYRnCXamteWaCXJodc();
			OkLkjfkBGntRAvakyAvYRRgphMAiA.gUxczTgMdKUcYRnCXamteWaCXJodc(DsUMFOuNrADSwelafhXWALBVQljt.GetInputDataUpdateDelegate(), dhXuTEEziWFtUyjdydeOTtEMceSv.GetInputBehaviors_Copy());
			DsUMFOuNrADSwelafhXWALBVQljt.Initialize();
		}

		private static void DzVKzZZSNhcHFMNPFIbHEhBFuhklA()
		{
			if (CVOosweFQkjenKNkyCghUKMwQzfI != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(CVOosweFQkjenKNkyCghUKMwQzfI);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			CVOosweFQkjenKNkyCghUKMwQzfI = null;
			DsUMFOuNrADSwelafhXWALBVQljt = null;
			TcJeRjoAHWajdfxVaSabfTeqWDcy = null;
			if (OkLkjfkBGntRAvakyAvYRRgphMAiA != null)
			{
				OkLkjfkBGntRAvakyAvYRRgphMAiA.Dispose();
			}
			OkLkjfkBGntRAvakyAvYRRgphMAiA = null;
			ajnOsEopTWvzJZjeDpcpYppqmqOw = null;
			yuMAFKYlLRXHYECDtAfqrzgtWNno = null;
			dhXuTEEziWFtUyjdydeOTtEMceSv = null;
			VBDkcaxujnFiYdBuOjuquSnyqjHE = null;
			juAmOHdlEuZcdEbopfsigKMAJgtHb = false;
			HhUekGiZgESvZmOBirudgfCplDISA = null;
			SGbCYHanXXzBiWnXJzwBdELpFDCnA = UpdateLoopType.Update;
			xAXgrgTBrSfWQOaiATiEGRGhgWIC = false;
			fzICSMslIAIogSLDYlSBPLBPiOoF = Platform.Windows;
			ZpqltcgNrXUHCRtunjsQsaPwjfOIA = WebplayerPlatform.None;
			vLtJrfESYPgDQDnGZPJTJqwWHIYlA = EditorPlatform.None;
			fPVGIFZOaraUFNEsjBjKxdJKjsBQ = false;
			SKyvYsUBAlhUEnadFFWMiAvAKNBDA = null;
			DnguBusOPRzgVZOfVVmqrxdKVdpS = null;
			hubgZmpbFjYDnMCksJvcpKfkxjuv = null;
			UsGQqdiGSRcgPzJccGZACMQWxRDlA = false;
			JjXaHxVjZWMdZXJTNveiFRgxzXWe = false;
			xKPALbkrgWCQScxZCiBgyXBoonOyb = true;
			XLiQYniPJQiCkGaxLchxZGvMEWgu = -1;
			_id = -1;
			ZWsLEIbTkRLpeQxDCxjhyNRcUgKf = 0;
			lFjrTanwbFwsbvgdYLZmBLvoFVkp.Clear();
			AqxDSCKdbkAKVwJYDWnhpyNDIyGQA.Clear();
			IygYEaSeXkocaFAKApGKrzOiCMIN.Clear();
			EEvWOInbYwCpcrCfajmNfbyGrZAW.Clear();
			OEfCNSKRaPIivtobaVBYGskOnHSh.Clear();
			_ApplicationFocusChangedEvent = null;
			zpEdOYsGkXCCYuGYtLGyAaQZgnccA = null;
			GAkHzoGpoOPydMlwUwOvmvAhwbjc = null;
			RmykIGJsGMxYoPLvQMNFFeTWLBXJ = null;
			NhobUMgUqklZnceVoRWjKhBdqvhu = null;
			RXmlFWBfUsIbqgkTuejcfSOCHAWZ = null;
			ADpqDtxhaJkoGNlXgcqrdfKmlXscA = null;
			YWlOwyefRtPCLfngYWjLjwUcFjOt = null;
			ahHahVIVNwaZZPYXNpDPsAAjJLqGb = null;
			ApceFuDOxIppDLINvkfawFPcEthz = null;
			vMeZFKVtjhxTgXBKbxLTKDVbcsgv = null;
			IpQzbRBLicjyYdGDxswJfmHjaOFS = null;
			XbYFEfePGwBtdHctyNZwJGeyjHodA();
			HeYakTEtCHWQxVwCyeqMlkZOUQafA = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= loBFxBFIfYAnvaKTVuCDYNGMOeRuA;
			}
		}

		private static void LCAKOisTsGfefoAlygRRHMXhOLosA(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void ovWQjTmBaCjemwBSRBKNDCmCYQBg()
		{
			if (!fPVGIFZOaraUFNEsjBjKxdJKjsBQ)
			{
				fPVGIFZOaraUFNEsjBjKxdJKjsBQ = true;
				ZMMbmdkWhjAWAhXVeHcFydUeJIjqb.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
				ZMMbmdkWhjAWAhXVeHcFydUeJIjqb.juSlmfDxziAorsqBqHNNqNqkEgtJ();
			}
			SKyvYsUBAlhUEnadFFWMiAvAKNBDA.Start();
		}

		private static void YGumDYhdZrtzIaNogMoqVpLRnpnf()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void zuPDFemqfyqKDOPSiYxjlNcdheek(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			OkLkjfkBGntRAvakyAvYRRgphMAiA.oFLCjRHhraPnQvNXLbpUUzAVwaVe(P_0);
			Joystick joystick = OkLkjfkBGntRAvakyAvYRRgphMAiA.tSIrwsOdwOFCroAaXNcrRqLZRblM(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				ajnOsEopTWvzJZjeDpcpYppqmqOw.kozuOCiRpWQmCCDJQoKHCpMNlvXo(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !iAJESsWCiSvwBPNuAGiTFudrWkqL)
				{
					IAPYElNTdXAKYNaUXIwNJJAgppzx(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void CBOWnXpWSeIFjcCDmASmPwHMJPns(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = OkLkjfkBGntRAvakyAvYRRgphMAiA.tSIrwsOdwOFCroAaXNcrRqLZRblM(P_0.rewiredId);
				if (joystick != null)
				{
					OkLkjfkBGntRAvakyAvYRRgphMAiA.QtieAYcfOQNdZzYnbqKRkQzcwyds(P_0.rewiredId);
					qGqMhDzMzcHcxlEHiOIUXTRMQNaB(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void IAPYElNTdXAKYNaUXIwNJJAgppzx(ControllerStatusChangedEventArgs P_0)
		{
			if (lFjrTanwbFwsbvgdYLZmBLvoFVkp != null)
			{
				lFjrTanwbFwsbvgdYLZmBLvoFVkp.Invoke(P_0);
			}
		}

		private static void lTPylGLYTtJZuyYypBZCODWvMGlN(ControllerStatusChangedEventArgs P_0)
		{
			if (AqxDSCKdbkAKVwJYDWnhpyNDIyGQA != null)
			{
				AqxDSCKdbkAKVwJYDWnhpyNDIyGQA.Invoke(P_0);
			}
		}

		private static void qGqMhDzMzcHcxlEHiOIUXTRMQNaB(ControllerStatusChangedEventArgs P_0)
		{
			if (IygYEaSeXkocaFAKApGKrzOiCMIN != null)
			{
				IygYEaSeXkocaFAKApGKrzOiCMIN.Invoke(P_0);
			}
		}

		private static void MQDslrblFnFPIksPJgNEutAbEGAJ(UpdateControllerInfoEventArgs P_0)
		{
			OkLkjfkBGntRAvakyAvYRRgphMAiA.efUlJwIYWClyAVZbCsumYvIMdtYx(P_0);
		}

		private static void ciqEMkdNIetcwAdDEzSvXOVSVQfM(bool P_0)
		{
			if (!juAmOHdlEuZcdEbopfsigKMAJgtHb)
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

		private static void xPIGfStyoqlVjzIESriduPijGmaE(bool P_0)
		{
			Action<bool> action = zpEdOYsGkXCCYuGYtLGyAaQZgnccA;
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

		private static void bgwgQqCBRAQCxNYwifUOrWDeCDpo(int P_0)
		{
			if (RmykIGJsGMxYoPLvQMNFFeTWLBXJ != null)
			{
				try
				{
					RmykIGJsGMxYoPLvQMNFFeTWLBXJ((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void tTTQMXKDJGQXiVEAxHTiSooeXjBk(bool P_0)
		{
			Action<bool> gAkHzoGpoOPydMlwUwOvmvAhwbjc = GAkHzoGpoOPydMlwUwOvmvAhwbjc;
			if (gAkHzoGpoOPydMlwUwOvmvAhwbjc != null)
			{
				try
				{
					gAkHzoGpoOPydMlwUwOvmvAhwbjc(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationRunInBackgroundChangedEvent", exception);
				}
			}
		}

		private static void VBKEtSJRgMqnWhkboePkaGDhqCwmb(bool P_0)
		{
			ZWsLEIbTkRLpeQxDCxjhyNRcUgKf++;
			Action<bool> nhobUMgUqklZnceVoRWjKhBdqvhu = NhobUMgUqklZnceVoRWjKhBdqvhu;
			if (nhobUMgUqklZnceVoRWjKhBdqvhu != null)
			{
				try
				{
					nhobUMgUqklZnceVoRWjKhBdqvhu(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void QMAuRSCtiiPBefUgCEgxlSpgiek()
		{
			if (HeYakTEtCHWQxVwCyeqMlkZOUQafA != null)
			{
				XbYFEfePGwBtdHctyNZwJGeyjHodA();
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.ChangedEvent += ciqEMkdNIetcwAdDEzSvXOVSVQfM;
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.XuHSAthgpDzCdtDHZPeWHpzkAvLbA.ChangedEvent += xPIGfStyoqlVjzIESriduPijGmaE;
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.oflHewLIhoAXLooWQloPgHLmDCsIA.ChangedEvent += tTTQMXKDJGQXiVEAxHTiSooeXjBk;
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.yaTWBuyJKYQHJKBtEFmGiCnezgmSA.ChangedEvent += bgwgQqCBRAQCxNYwifUOrWDeCDpo;
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.fHzbwjUdIFEbqiEHIwTGuNaUaRUlA.ChangedEvent += VBKEtSJRgMqnWhkboePkaGDhqCwmb;
			}
		}

		private static void XbYFEfePGwBtdHctyNZwJGeyjHodA()
		{
			if (HeYakTEtCHWQxVwCyeqMlkZOUQafA != null)
			{
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.FzbsNyUWhJkMFdEzPjPRgZViMPfw.ChangedEvent -= ciqEMkdNIetcwAdDEzSvXOVSVQfM;
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.XuHSAthgpDzCdtDHZPeWHpzkAvLbA.ChangedEvent -= xPIGfStyoqlVjzIESriduPijGmaE;
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.oflHewLIhoAXLooWQloPgHLmDCsIA.ChangedEvent -= tTTQMXKDJGQXiVEAxHTiSooeXjBk;
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.yaTWBuyJKYQHJKBtEFmGiCnezgmSA.ChangedEvent -= bgwgQqCBRAQCxNYwifUOrWDeCDpo;
				HeYakTEtCHWQxVwCyeqMlkZOUQafA.fHzbwjUdIFEbqiEHIwTGuNaUaRUlA.ChangedEvent -= VBKEtSJRgMqnWhkboePkaGDhqCwmb;
			}
		}

		private static void loBFxBFIfYAnvaKTVuCDYNGMOeRuA(bool P_0)
		{
			Action<bool> ipQzbRBLicjyYdGDxswJfmHjaOFS = IpQzbRBLicjyYdGDxswJfmHjaOFS;
			if (ipQzbRBLicjyYdGDxswJfmHjaOFS != null)
			{
				try
				{
					ipQzbRBLicjyYdGDxswJfmHjaOFS(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.EditorPauseChangedEvent", exception);
				}
			}
		}

		private static void NOVTJmKEcBJnXKENDhsxERaxmxqZA(Func<ConfigVars, object> P_0, UnityTools.dLTpFXVUEoYOHBezYpFOWYkDPuSf P_1, Action<Platform> P_2)
		{
			bool flag = false;
			if (P_1.geTGwKSCgshpIWCyYNzgvHxtoWsl != P_1.lYXneBQNfIGyzfmqBblxyldQoJcKA)
			{
				UnityTools.dLTpFXVUEoYOHBezYpFOWYkDPuSf dLTpFXVUEoYOHBezYpFOWYkDPuSf = P_1;
				dLTpFXVUEoYOHBezYpFOWYkDPuSf.geTGwKSCgshpIWCyYNzgvHxtoWsl = P_1.lYXneBQNfIGyzfmqBblxyldQoJcKA;
				UnityTools.gUxczTgMdKUcYRnCXamteWaCXJodc(dLTpFXVUEoYOHBezYpFOWYkDPuSf);
				P_2(dLTpFXVUEoYOHBezYpFOWYkDPuSf.lYXneBQNfIGyzfmqBblxyldQoJcKA);
				sUcupMLOUYqoJsYPEvQJZJQLKuaM();
				flag = true;
			}
			if (!configVars.DoesPlatformUseFallback(P_1.lYXneBQNfIGyzfmqBblxyldQoJcKA, P_1.tWllbFMSNSkPiGIJcoKhuYAgfmBp, isEditor) && !configVars.DoesPlatformUseFallback(P_1.geTGwKSCgshpIWCyYNzgvHxtoWsl, P_1.tWllbFMSNSkPiGIJcoKhuYAgfmBp, isEditor))
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(CVOosweFQkjenKNkyCghUKMwQzfI);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(P_1.lYXneBQNfIGyzfmqBblxyldQoJcKA, HhUekGiZgESvZmOBirudgfCplDISA) is PlatformInputManager dsUMFOuNrADSwelafhXWALBVQljt)
					{
						DsUMFOuNrADSwelafhXWALBVQljt = dsUMFOuNrADSwelafhXWALBVQljt;
						return;
					}
				}
			}
			if (flag)
			{
				UnityTools.gUxczTgMdKUcYRnCXamteWaCXJodc(P_1);
				P_2(P_1.lYXneBQNfIGyzfmqBblxyldQoJcKA);
				sUcupMLOUYqoJsYPEvQJZJQLKuaM();
				flag = false;
			}
			if (configVars.DoesPlatformUseFallback(fzICSMslIAIogSLDYlSBPLBPiOoF, ZpqltcgNrXUHCRtunjsQsaPwjfOIA, isEditor))
			{
				xAXgrgTBrSfWQOaiATiEGRGhgWIC = true;
				DsUMFOuNrADSwelafhXWALBVQljt = new YPEGKdGlyEszNjScuARgURDzbRAc(HhUekGiZgESvZmOBirudgfCplDISA.updateLoop);
			}
			else if (configVars.DoesPlatformUseSDL2(fzICSMslIAIogSLDYlSBPLBPiOoF, ZpqltcgNrXUHCRtunjsQsaPwjfOIA, isEditor))
			{
				try
				{
					DsUMFOuNrADSwelafhXWALBVQljt = new lwbDySfvDdBYvtcCsmSJyxKynhnkA(HhUekGiZgESvZmOBirudgfCplDISA, GetHardwareJoystickMap_InputManager, GetNewJoystickId, true, false, false);
					if (DsUMFOuNrADSwelafhXWALBVQljt == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
					DsUMFOuNrADSwelafhXWALBVQljt = null;
				}
			}
			else if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.Windows || fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.WindowsAppStore || fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.WindowsUWP || fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.OSX || fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.Linux)
			{
				DsUMFOuNrADSwelafhXWALBVQljt = P_0(HhUekGiZgESvZmOBirudgfCplDISA) as PlatformInputManager;
			}
			else if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.WebGL && !isEditor)
			{
				try
				{
					DsUMFOuNrADSwelafhXWALBVQljt = P_0(HhUekGiZgESvZmOBirudgfCplDISA) as PlatformInputManager;
					if (DsUMFOuNrADSwelafhXWALBVQljt == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					DsUMFOuNrADSwelafhXWALBVQljt = null;
				}
			}
			else if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.XboxOne && !isEditor)
			{
				try
				{
					DsUMFOuNrADSwelafhXWALBVQljt = new CustomInputManager(new XboxOneInputSource(), HhUekGiZgESvZmOBirudgfCplDISA.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (DsUMFOuNrADSwelafhXWALBVQljt == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					DsUMFOuNrADSwelafhXWALBVQljt = null;
				}
			}
			else if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.PS4 && !isEditor)
			{
				try
				{
					DsUMFOuNrADSwelafhXWALBVQljt = P_0(HhUekGiZgESvZmOBirudgfCplDISA) as PlatformInputManager;
					if (DsUMFOuNrADSwelafhXWALBVQljt == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
					Logger.LogError(msg);
					DsUMFOuNrADSwelafhXWALBVQljt = null;
				}
			}
			else if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.PS5 && !isEditor)
			{
				try
				{
					DsUMFOuNrADSwelafhXWALBVQljt = P_0(HhUekGiZgESvZmOBirudgfCplDISA) as PlatformInputManager;
					if (DsUMFOuNrADSwelafhXWALBVQljt == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
					Logger.LogError(msg2);
					DsUMFOuNrADSwelafhXWALBVQljt = null;
				}
			}
			else if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.Stadia && !isEditor)
			{
				try
				{
					DsUMFOuNrADSwelafhXWALBVQljt = P_0(HhUekGiZgESvZmOBirudgfCplDISA) as PlatformInputManager;
					if (DsUMFOuNrADSwelafhXWALBVQljt == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg3)
				{
					Logger.LogError("Stadia platform could not be initialized! Is the Rewired Stadia library installed? See the documentation for more information.");
					Logger.LogError(msg3);
					DsUMFOuNrADSwelafhXWALBVQljt = null;
				}
			}
			else if ((fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.GameCoreXboxOne || fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					DsUMFOuNrADSwelafhXWALBVQljt = P_0(HhUekGiZgESvZmOBirudgfCplDISA) as PlatformInputManager;
					if (DsUMFOuNrADSwelafhXWALBVQljt == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg4)
				{
					string text = ((fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg4);
					DsUMFOuNrADSwelafhXWALBVQljt = null;
				}
			}
			else if (fzICSMslIAIogSLDYlSBPLBPiOoF == Platform.Ouya && !isEditor)
			{
				Logger.LogError("Ouya is no longer supported.");
				DsUMFOuNrADSwelafhXWALBVQljt = null;
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.BCHkYYLGsLQnMmusVpqPohjqMrGH = P_0(HhUekGiZgESvZmOBirudgfCplDISA) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg5)
				{
					Logger.LogError(msg5);
				}
			}
			if (DsUMFOuNrADSwelafhXWALBVQljt == null)
			{
				xAXgrgTBrSfWQOaiATiEGRGhgWIC = true;
				DsUMFOuNrADSwelafhXWALBVQljt = new YPEGKdGlyEszNjScuARgURDzbRAc(HhUekGiZgESvZmOBirudgfCplDISA.updateLoop);
			}
		}

		private static void zHtQLVrCGGvBPKxwkomJDaOttjfr()
		{
			if (UsGQqdiGSRcgPzJccGZACMQWxRDlA != HhUekGiZgESvZmOBirudgfCplDISA.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				UsGQqdiGSRcgPzJccGZACMQWxRDlA = !UsGQqdiGSRcgPzJccGZACMQWxRDlA;
			}
		}

		private static void yiPLYmFMNyvRUXdhnNxGvpwaMcwb()
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
