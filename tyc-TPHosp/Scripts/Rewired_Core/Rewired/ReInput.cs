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
			private static ConfigHelper cBGAPVaArOoNAxoZVXVJimDiaMfq;

			private float CZguwkPQcrqkvOwslResRKXPZZP = 0.7f;

			private float rSBOoaXzHvtgMrhBWelgIwIOwbgF = 100f;

			internal static ConfigHelper Instance => cBGAPVaArOoNAxoZVXVJimDiaMfq ?? (cBGAPVaArOoNAxoZVXVJimDiaMfq = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.platform == Platform.Windows && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						return (LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
					}
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.useXInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
						if (platformVars_WindowsUWP.useGamepadAPI != value)
						{
							platformVars_WindowsUWP.useGamepadAPI = value;
							if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
							{
								ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
							}
						}
					}
					else if (LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.useXInput != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.useXInput = value;
						if (!value && UnityTools.platform == Platform.Windows && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.Log("The primary input source has been changed to Raw Input.");
						}
						else if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.updateLoop = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.platform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.useXInput = true;
						}
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.osx_primaryInputSource != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.osx_primaryInputSource = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.linux_primaryInputSource != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.linux_primaryInputSource = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.windowsUWP_primaryInputSource = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					return platformVars_WindowsUWP.useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.xboxOne_primaryInputSource != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.xboxOne_primaryInputSource = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.ps4_primaryInputSource != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.ps4_primaryInputSource = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.webGL_primaryInputSource != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.webGL_primaryInputSource = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.alwaysUseUnityInput != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.alwaysUseUnityInput = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.SetPlatformVar_useNativeMouse(value) && ceSrziAFVHlZSgalWFBehsjWmKTA != null)
					{
						ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && ceSrziAFVHlZSgalWFBehsjWmKTA != null)
					{
						ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && ceSrziAFVHlZSgalWFBehsjWmKTA != null)
					{
						ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.GetPlatformVar_joystickRefreshRate();
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
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						NrufBlObSwJruLvdrVSCCrHWiNSH();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.android_supportUnknownGamepads != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.android_supportUnknownGamepads = value;
						if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
						{
							ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.defaultAxisSensitivityType != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.defaultAxisSensitivityType = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.force4WayHats != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.force4WayHats = value;
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
					return CZguwkPQcrqkvOwslResRKXPZZP;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (CZguwkPQcrqkvOwslResRKXPZZP != value)
						{
							CZguwkPQcrqkvOwslResRKXPZZP = value;
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
					return rSBOoaXzHvtgMrhBWelgIwIOwbgF;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (rSBOoaXzHvtgMrhBWelgIwIOwbgF != value)
						{
							rSBOoaXzHvtgMrhBWelgIwIOwbgF = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.activateActionButtonsOnNegativeValue = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.throttleCalibrationMode != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.throttleCalibrationMode = value;
						aPNcjJCKQolbdJEKHuJkfRPTMco.GhZnlbNKooLhPxyEkNBqwGgpeKr(value);
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.autoAssignJoysticks != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.autoAssignJoysticks = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.maxJoysticksPerPlayer != value)
						{
							LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.maxJoysticksPerPlayer = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.distributeJoysticksEvenly != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.distributeJoysticksEvenly = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.logLevel != value)
					{
						LWLODUkCwfcNvCWHWwdHlYbcikq.ConfigVars.logLevel = value;
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
				private sealed class WYvJrXGDJlcaagGHBDPjtgmzWUv : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerPollingInfo uWcfBkwdeBzQZyTBXuQdcvHvMeg;

					public ControllerPollingInfo JBoFUoDwNjxRQjTdjAPJFObeiZxm;

					public ControllerPollingInfo YllBtFBTfAbrWCPZkuDHqjfalTVU;

					public ControllerPollingInfo ozWgOKbUbTNRSZMAlNdTyVFeBrVe;

					public IEnumerator<ControllerPollingInfo> lWpmKgJbmkGiVIiEJGiqYszGzCn;

					public IEnumerator<ControllerPollingInfo> qBVOaVlGJvIVDgqmMcfHiEllrGta;

					public IEnumerator<ControllerPollingInfo> YDGVVrPxVddeUCJwUEaJNhMWZUZ;

					public IEnumerator<ControllerPollingInfo> rsWApJGcvinsnwtsjmcNKkWmDoL;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						WYvJrXGDJlcaagGHBDPjtgmzWUv wYvJrXGDJlcaagGHBDPjtgmzWUv;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							wYvJrXGDJlcaagGHBDPjtgmzWUv = this;
						}
						else
						{
							wYvJrXGDJlcaagGHBDPjtgmzWUv = new WYvJrXGDJlcaagGHBDPjtgmzWUv(0);
							wYvJrXGDJlcaagGHBDPjtgmzWUv.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return wYvJrXGDJlcaagGHBDPjtgmzWUv;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (!CheckInitialized())
								{
									break;
								}
								lWpmKgJbmkGiVIiEJGiqYszGzCn = kdBZqupjvsCsVkwJiOeEQzkEDVO.QbzynOjrnOnvocjncQfCACgbsUS().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0098;
							case 2:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0098;
							case 4:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00fc;
							case 6:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
								goto IL_0160;
							case 8:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 7;
									goto IL_01c1;
								}
								IL_01c1:
								if (rsWApJGcvinsnwtsjmcNKkWmDoL.MoveNext())
								{
									ozWgOKbUbTNRSZMAlNdTyVFeBrVe = rsWApJGcvinsnwtsjmcNKkWmDoL.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = ozWgOKbUbTNRSZMAlNdTyVFeBrVe;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 8;
									return true;
								}
								okZtAvbIytEciggdZLTzgLnSIIy();
								break;
								IL_0098:
								if (lWpmKgJbmkGiVIiEJGiqYszGzCn.MoveNext())
								{
									uWcfBkwdeBzQZyTBXuQdcvHvMeg = lWpmKgJbmkGiVIiEJGiqYszGzCn.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = uWcfBkwdeBzQZyTBXuQdcvHvMeg;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								raYIZUbPHBPfTmJuiHZYELXBRehd();
								qBVOaVlGJvIVDgqmMcfHiEllrGta = kdBZqupjvsCsVkwJiOeEQzkEDVO.gAvgWIgfVZbXuFTWgjqyGdKUFRxA().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00fc;
								IL_0160:
								if (YDGVVrPxVddeUCJwUEaJNhMWZUZ.MoveNext())
								{
									YllBtFBTfAbrWCPZkuDHqjfalTVU = YDGVVrPxVddeUCJwUEaJNhMWZUZ.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = YllBtFBTfAbrWCPZkuDHqjfalTVU;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 6;
									return true;
								}
								IeguNUvwoQzTdYxkbkOlteJxchw();
								rsWApJGcvinsnwtsjmcNKkWmDoL = kdBZqupjvsCsVkwJiOeEQzkEDVO.lKBAYRZBwSfgdnPyfoiNuNMHctMd().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 7;
								goto IL_01c1;
								IL_00fc:
								if (qBVOaVlGJvIVDgqmMcfHiEllrGta.MoveNext())
								{
									JBoFUoDwNjxRQjTdjAPJFObeiZxm = qBVOaVlGJvIVDgqmMcfHiEllrGta.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = JBoFUoDwNjxRQjTdjAPJFObeiZxm;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 4;
									return true;
								}
								ShENrbYNtqNkLhlStXaQQinwBJlk();
								YDGVVrPxVddeUCJwUEaJNhMWZUZ = kdBZqupjvsCsVkwJiOeEQzkEDVO.ZooFcvkMsjmnEomcITTqPWxhapy().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								raYIZUbPHBPfTmJuiHZYELXBRehd();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								ShENrbYNtqNkLhlStXaQQinwBJlk();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								IeguNUvwoQzTdYxkbkOlteJxchw();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								okZtAvbIytEciggdZLTzgLnSIIy();
							}
						}
					}

					[DebuggerHidden]
					public WYvJrXGDJlcaagGHBDPjtgmzWUv(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void raYIZUbPHBPfTmJuiHZYELXBRehd()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (lWpmKgJbmkGiVIiEJGiqYszGzCn != null)
						{
							lWpmKgJbmkGiVIiEJGiqYszGzCn.Dispose();
						}
					}

					private void ShENrbYNtqNkLhlStXaQQinwBJlk()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (qBVOaVlGJvIVDgqmMcfHiEllrGta != null)
						{
							qBVOaVlGJvIVDgqmMcfHiEllrGta.Dispose();
						}
					}

					private void IeguNUvwoQzTdYxkbkOlteJxchw()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (YDGVVrPxVddeUCJwUEaJNhMWZUZ != null)
						{
							YDGVVrPxVddeUCJwUEaJNhMWZUZ.Dispose();
						}
					}

					private void okZtAvbIytEciggdZLTzgLnSIIy()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (rsWApJGcvinsnwtsjmcNKkWmDoL != null)
						{
							rsWApJGcvinsnwtsjmcNKkWmDoL.Dispose();
						}
					}
				}

				private sealed class imSawLwSsWWtGimdSTiqykWQpPH : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerPollingInfo qPNOlvbjwOdxDOiRBdUOLnJlYA;

					public ControllerPollingInfo hVSKyQYOiMdjcFxHgKtyiSbZHbH;

					public ControllerPollingInfo GSbhhqsVWnBOtigpcKMdyoNsGbjd;

					public ControllerPollingInfo kOzgmuQsJGjiBbkurrFmjTCLnNff;

					public IEnumerator<ControllerPollingInfo> kRopcfMZtCCsmdsfLUrBpLYgDyI;

					public IEnumerator<ControllerPollingInfo> VlFSIJofUUkQUZXeqntdhjzpmhg;

					public IEnumerator<ControllerPollingInfo> sASwgaFNkUsbPTvazVztOHJFOGE;

					public IEnumerator<ControllerPollingInfo> NUopbFNaVwbWwrAWEADxhIlPOVca;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						imSawLwSsWWtGimdSTiqykWQpPH imSawLwSsWWtGimdSTiqykWQpPH2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							imSawLwSsWWtGimdSTiqykWQpPH2 = this;
						}
						else
						{
							imSawLwSsWWtGimdSTiqykWQpPH2 = new imSawLwSsWWtGimdSTiqykWQpPH(0);
							imSawLwSsWWtGimdSTiqykWQpPH2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return imSawLwSsWWtGimdSTiqykWQpPH2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (!CheckInitialized())
								{
									break;
								}
								kRopcfMZtCCsmdsfLUrBpLYgDyI = kdBZqupjvsCsVkwJiOeEQzkEDVO.jSWKFzaBtDaxCdTuAXqkFlVBfiYx().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0098;
							case 2:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0098;
							case 4:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00fc;
							case 6:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
								goto IL_0160;
							case 8:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 7;
									goto IL_01c1;
								}
								IL_01c1:
								if (NUopbFNaVwbWwrAWEADxhIlPOVca.MoveNext())
								{
									kOzgmuQsJGjiBbkurrFmjTCLnNff = NUopbFNaVwbWwrAWEADxhIlPOVca.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = kOzgmuQsJGjiBbkurrFmjTCLnNff;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 8;
									return true;
								}
								XHKbSQIgcdqxDbdYASRsajmBDHMo();
								break;
								IL_0098:
								if (kRopcfMZtCCsmdsfLUrBpLYgDyI.MoveNext())
								{
									qPNOlvbjwOdxDOiRBdUOLnJlYA = kRopcfMZtCCsmdsfLUrBpLYgDyI.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = qPNOlvbjwOdxDOiRBdUOLnJlYA;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								xkKSSVRXvfMudqLAmVIFwIVDwso();
								VlFSIJofUUkQUZXeqntdhjzpmhg = kdBZqupjvsCsVkwJiOeEQzkEDVO.UNbIRrbSwWaPpwzAWAJYgahWYve().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00fc;
								IL_0160:
								if (sASwgaFNkUsbPTvazVztOHJFOGE.MoveNext())
								{
									GSbhhqsVWnBOtigpcKMdyoNsGbjd = sASwgaFNkUsbPTvazVztOHJFOGE.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = GSbhhqsVWnBOtigpcKMdyoNsGbjd;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 6;
									return true;
								}
								bstNYavZMFVOSDfFNFTQEMQrqnJR();
								NUopbFNaVwbWwrAWEADxhIlPOVca = kdBZqupjvsCsVkwJiOeEQzkEDVO.PmkgcCkBjeZVCjctKfZQZIfmZmn().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 7;
								goto IL_01c1;
								IL_00fc:
								if (VlFSIJofUUkQUZXeqntdhjzpmhg.MoveNext())
								{
									hVSKyQYOiMdjcFxHgKtyiSbZHbH = VlFSIJofUUkQUZXeqntdhjzpmhg.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = hVSKyQYOiMdjcFxHgKtyiSbZHbH;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 4;
									return true;
								}
								ucTqQPNfIlVJrkhNqaKmfubEZlE();
								sASwgaFNkUsbPTvazVztOHJFOGE = kdBZqupjvsCsVkwJiOeEQzkEDVO.TTyoYZMohguwGZCZTlCpANfgGGB().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								xkKSSVRXvfMudqLAmVIFwIVDwso();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								ucTqQPNfIlVJrkhNqaKmfubEZlE();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								bstNYavZMFVOSDfFNFTQEMQrqnJR();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								XHKbSQIgcdqxDbdYASRsajmBDHMo();
							}
						}
					}

					[DebuggerHidden]
					public imSawLwSsWWtGimdSTiqykWQpPH(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void xkKSSVRXvfMudqLAmVIFwIVDwso()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (kRopcfMZtCCsmdsfLUrBpLYgDyI != null)
						{
							kRopcfMZtCCsmdsfLUrBpLYgDyI.Dispose();
						}
					}

					private void ucTqQPNfIlVJrkhNqaKmfubEZlE()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (VlFSIJofUUkQUZXeqntdhjzpmhg != null)
						{
							VlFSIJofUUkQUZXeqntdhjzpmhg.Dispose();
						}
					}

					private void bstNYavZMFVOSDfFNFTQEMQrqnJR()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (sASwgaFNkUsbPTvazVztOHJFOGE != null)
						{
							sASwgaFNkUsbPTvazVztOHJFOGE.Dispose();
						}
					}

					private void XHKbSQIgcdqxDbdYASRsajmBDHMo()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (NUopbFNaVwbWwrAWEADxhIlPOVca != null)
						{
							NUopbFNaVwbWwrAWEADxhIlPOVca.Dispose();
						}
					}
				}

				private sealed class jKUcUQKjgagAmCpepQUhZBzTiZw : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerPollingInfo EPTMopDJLmCIDYfDFZbJaebREVu;

					public ControllerPollingInfo fRvMnCYixhZXakHzFFuxqxuXnQa;

					public ControllerPollingInfo VHFKAKYhgOxsjGOnDUozyodWAHB;

					public ControllerPollingInfo EyqacHwqoUmcYHqWJDZkxLLgDaU;

					public IEnumerator<ControllerPollingInfo> HnAdofVTMyErYdQHxtibcROyRDv;

					public IEnumerator<ControllerPollingInfo> wqGQbDCVZaeKmjtTwfDonIePyFb;

					public IEnumerator<ControllerPollingInfo> OIOEskNIFXXdGBkxkJLOWJIiggN;

					public IEnumerator<ControllerPollingInfo> JHpEalwDAlukOrkWqeRyxGLtbKqH;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						jKUcUQKjgagAmCpepQUhZBzTiZw jKUcUQKjgagAmCpepQUhZBzTiZw2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							jKUcUQKjgagAmCpepQUhZBzTiZw2 = this;
						}
						else
						{
							jKUcUQKjgagAmCpepQUhZBzTiZw2 = new jKUcUQKjgagAmCpepQUhZBzTiZw(0);
							jKUcUQKjgagAmCpepQUhZBzTiZw2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return jKUcUQKjgagAmCpepQUhZBzTiZw2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (!CheckInitialized())
								{
									break;
								}
								HnAdofVTMyErYdQHxtibcROyRDv = kdBZqupjvsCsVkwJiOeEQzkEDVO.XjWvmrssIbttOhBAesLVKzhmDJZ().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0098;
							case 2:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0098;
							case 4:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00fc;
							case 6:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
								goto IL_0160;
							case 8:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 7;
									goto IL_01c1;
								}
								IL_01c1:
								if (JHpEalwDAlukOrkWqeRyxGLtbKqH.MoveNext())
								{
									EyqacHwqoUmcYHqWJDZkxLLgDaU = JHpEalwDAlukOrkWqeRyxGLtbKqH.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = EyqacHwqoUmcYHqWJDZkxLLgDaU;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 8;
									return true;
								}
								jhGcffKYUBoPzFbuAXmLXYGwEir();
								break;
								IL_0098:
								if (HnAdofVTMyErYdQHxtibcROyRDv.MoveNext())
								{
									EPTMopDJLmCIDYfDFZbJaebREVu = HnAdofVTMyErYdQHxtibcROyRDv.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = EPTMopDJLmCIDYfDFZbJaebREVu;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								BUFTzPHjdjObkCrRyYEzIEFgDWE();
								wqGQbDCVZaeKmjtTwfDonIePyFb = kdBZqupjvsCsVkwJiOeEQzkEDVO.gAvgWIgfVZbXuFTWgjqyGdKUFRxA().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00fc;
								IL_0160:
								if (OIOEskNIFXXdGBkxkJLOWJIiggN.MoveNext())
								{
									VHFKAKYhgOxsjGOnDUozyodWAHB = OIOEskNIFXXdGBkxkJLOWJIiggN.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = VHFKAKYhgOxsjGOnDUozyodWAHB;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 6;
									return true;
								}
								KZQuobubqzOCojyowmNnUMkSSnL();
								JHpEalwDAlukOrkWqeRyxGLtbKqH = kdBZqupjvsCsVkwJiOeEQzkEDVO.AtSfiFgQODQAQAgVrkhiPyooONFu().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 7;
								goto IL_01c1;
								IL_00fc:
								if (wqGQbDCVZaeKmjtTwfDonIePyFb.MoveNext())
								{
									fRvMnCYixhZXakHzFFuxqxuXnQa = wqGQbDCVZaeKmjtTwfDonIePyFb.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = fRvMnCYixhZXakHzFFuxqxuXnQa;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 4;
									return true;
								}
								USmHecRuhxpOkcMTLnkMxPwVzWw();
								OIOEskNIFXXdGBkxkJLOWJIiggN = kdBZqupjvsCsVkwJiOeEQzkEDVO.awSCqvjylhyTWfJPsmnKHANpeyZD().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								BUFTzPHjdjObkCrRyYEzIEFgDWE();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								USmHecRuhxpOkcMTLnkMxPwVzWw();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								KZQuobubqzOCojyowmNnUMkSSnL();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								jhGcffKYUBoPzFbuAXmLXYGwEir();
							}
						}
					}

					[DebuggerHidden]
					public jKUcUQKjgagAmCpepQUhZBzTiZw(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void BUFTzPHjdjObkCrRyYEzIEFgDWE()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (HnAdofVTMyErYdQHxtibcROyRDv != null)
						{
							HnAdofVTMyErYdQHxtibcROyRDv.Dispose();
						}
					}

					private void USmHecRuhxpOkcMTLnkMxPwVzWw()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (wqGQbDCVZaeKmjtTwfDonIePyFb != null)
						{
							wqGQbDCVZaeKmjtTwfDonIePyFb.Dispose();
						}
					}

					private void KZQuobubqzOCojyowmNnUMkSSnL()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (OIOEskNIFXXdGBkxkJLOWJIiggN != null)
						{
							OIOEskNIFXXdGBkxkJLOWJIiggN.Dispose();
						}
					}

					private void jhGcffKYUBoPzFbuAXmLXYGwEir()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (JHpEalwDAlukOrkWqeRyxGLtbKqH != null)
						{
							JHpEalwDAlukOrkWqeRyxGLtbKqH.Dispose();
						}
					}
				}

				private sealed class mcagvEdymLBpufpGsfebWttHSjY : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerPollingInfo gOxtfjPRAQbBpcRGcyxmaHwviuG;

					public ControllerPollingInfo bvheTlHdoZhfVCbpMyPjjahbOFxz;

					public ControllerPollingInfo SQckWuHpEpTfnAUbAIHkOmQQuUo;

					public ControllerPollingInfo tyvSyAmQlfxVRABmoWEHEZwDGjR;

					public IEnumerator<ControllerPollingInfo> coIgqpkrhkmzahyEDXJgBwNpSBoh;

					public IEnumerator<ControllerPollingInfo> uAXQzhILLvUreNSmzgPyKMgZZpl;

					public IEnumerator<ControllerPollingInfo> ChkFMmFRTgPWOXummZZZBbShJXC;

					public IEnumerator<ControllerPollingInfo> CErkwvMkZRznoPZWHVoTudRjNrk;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						mcagvEdymLBpufpGsfebWttHSjY mcagvEdymLBpufpGsfebWttHSjY2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							mcagvEdymLBpufpGsfebWttHSjY2 = this;
						}
						else
						{
							mcagvEdymLBpufpGsfebWttHSjY2 = new mcagvEdymLBpufpGsfebWttHSjY(0);
							mcagvEdymLBpufpGsfebWttHSjY2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return mcagvEdymLBpufpGsfebWttHSjY2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (!CheckInitialized())
								{
									break;
								}
								coIgqpkrhkmzahyEDXJgBwNpSBoh = kdBZqupjvsCsVkwJiOeEQzkEDVO.wAYzQZdOFdjBcGukUXuZNSQwOBYf().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0098;
							case 2:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0098;
							case 4:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00fc;
							case 6:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
								goto IL_0160;
							case 8:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 7;
									goto IL_01c1;
								}
								IL_01c1:
								if (CErkwvMkZRznoPZWHVoTudRjNrk.MoveNext())
								{
									tyvSyAmQlfxVRABmoWEHEZwDGjR = CErkwvMkZRznoPZWHVoTudRjNrk.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = tyvSyAmQlfxVRABmoWEHEZwDGjR;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 8;
									return true;
								}
								LcQzNUkZHACQlplLCyabdlwQePXC();
								break;
								IL_0098:
								if (coIgqpkrhkmzahyEDXJgBwNpSBoh.MoveNext())
								{
									gOxtfjPRAQbBpcRGcyxmaHwviuG = coIgqpkrhkmzahyEDXJgBwNpSBoh.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = gOxtfjPRAQbBpcRGcyxmaHwviuG;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								VsBvUBdWjeQPLKROUYQhRwNBPYn();
								uAXQzhILLvUreNSmzgPyKMgZZpl = kdBZqupjvsCsVkwJiOeEQzkEDVO.UNbIRrbSwWaPpwzAWAJYgahWYve().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00fc;
								IL_0160:
								if (ChkFMmFRTgPWOXummZZZBbShJXC.MoveNext())
								{
									SQckWuHpEpTfnAUbAIHkOmQQuUo = ChkFMmFRTgPWOXummZZZBbShJXC.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = SQckWuHpEpTfnAUbAIHkOmQQuUo;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 6;
									return true;
								}
								aVylwqXmQECmRYwHPLdUHJSffdRJ();
								CErkwvMkZRznoPZWHVoTudRjNrk = kdBZqupjvsCsVkwJiOeEQzkEDVO.mMONWadVQHiCiUwCrqqwFLeElTW().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 7;
								goto IL_01c1;
								IL_00fc:
								if (uAXQzhILLvUreNSmzgPyKMgZZpl.MoveNext())
								{
									bvheTlHdoZhfVCbpMyPjjahbOFxz = uAXQzhILLvUreNSmzgPyKMgZZpl.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = bvheTlHdoZhfVCbpMyPjjahbOFxz;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 4;
									return true;
								}
								JTDArstVVXVGZDciERwYgjeVfnD();
								ChkFMmFRTgPWOXummZZZBbShJXC = kdBZqupjvsCsVkwJiOeEQzkEDVO.ARYkLJaQlDfnKwXxPMqbvhDkYgI().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								VsBvUBdWjeQPLKROUYQhRwNBPYn();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								JTDArstVVXVGZDciERwYgjeVfnD();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 5:
						case 6:
							try
							{
							}
							finally
							{
								aVylwqXmQECmRYwHPLdUHJSffdRJ();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 7:
						case 8:
							try
							{
								break;
							}
							finally
							{
								LcQzNUkZHACQlplLCyabdlwQePXC();
							}
						}
					}

					[DebuggerHidden]
					public mcagvEdymLBpufpGsfebWttHSjY(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void VsBvUBdWjeQPLKROUYQhRwNBPYn()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (coIgqpkrhkmzahyEDXJgBwNpSBoh != null)
						{
							coIgqpkrhkmzahyEDXJgBwNpSBoh.Dispose();
						}
					}

					private void JTDArstVVXVGZDciERwYgjeVfnD()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (uAXQzhILLvUreNSmzgPyKMgZZpl != null)
						{
							uAXQzhILLvUreNSmzgPyKMgZZpl.Dispose();
						}
					}

					private void aVylwqXmQECmRYwHPLdUHJSffdRJ()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (ChkFMmFRTgPWOXummZZZBbShJXC != null)
						{
							ChkFMmFRTgPWOXummZZZBbShJXC.Dispose();
						}
					}

					private void LcQzNUkZHACQlplLCyabdlwQePXC()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (CErkwvMkZRznoPZWHVoTudRjNrk != null)
						{
							CErkwvMkZRznoPZWHVoTudRjNrk.Dispose();
						}
					}
				}

				private sealed class HhKRbrzDMcfAfiQyAhltaCVXBjR : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public ControllerPollingInfo uNDhHXvChZvuCEydtEDLmHyyjjZ;

					public ControllerPollingInfo NonfcBWqTFLseEUOsLRFFmWBSsN;

					public ControllerPollingInfo MVUgBMLesdixBlWyKLkidbWXDRQ;

					public IEnumerator<ControllerPollingInfo> JjEleBenKIeVJqTlyKwlSJCdSbw;

					public IEnumerator<ControllerPollingInfo> RTDuQUSfWxlmIyoeFjWqcRjAYGk;

					public IEnumerator<ControllerPollingInfo> WEfOPrdRpLsKeSRbWyIsqXgBGNT;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						HhKRbrzDMcfAfiQyAhltaCVXBjR hhKRbrzDMcfAfiQyAhltaCVXBjR;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							hhKRbrzDMcfAfiQyAhltaCVXBjR = this;
						}
						else
						{
							hhKRbrzDMcfAfiQyAhltaCVXBjR = new HhKRbrzDMcfAfiQyAhltaCVXBjR(0);
							hhKRbrzDMcfAfiQyAhltaCVXBjR.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return hhKRbrzDMcfAfiQyAhltaCVXBjR;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (!CheckInitialized())
								{
									break;
								}
								JjEleBenKIeVJqTlyKwlSJCdSbw = kdBZqupjvsCsVkwJiOeEQzkEDVO.MdyEqSXmldqLboElPopNnzFbCGU().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0090;
							case 2:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0090;
							case 4:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00f4;
							case 6:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
									goto IL_0155;
								}
								IL_00f4:
								if (RTDuQUSfWxlmIyoeFjWqcRjAYGk.MoveNext())
								{
									NonfcBWqTFLseEUOsLRFFmWBSsN = RTDuQUSfWxlmIyoeFjWqcRjAYGk.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = NonfcBWqTFLseEUOsLRFFmWBSsN;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 4;
									return true;
								}
								mdnuwYPedzpkpwLoCjhSLQSgxzZ();
								WEfOPrdRpLsKeSRbWyIsqXgBGNT = kdBZqupjvsCsVkwJiOeEQzkEDVO.cmLblIPEaIRbsSHdWaHCwBfiAEB().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 5;
								goto IL_0155;
								IL_0090:
								if (JjEleBenKIeVJqTlyKwlSJCdSbw.MoveNext())
								{
									uNDhHXvChZvuCEydtEDLmHyyjjZ = JjEleBenKIeVJqTlyKwlSJCdSbw.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = uNDhHXvChZvuCEydtEDLmHyyjjZ;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								gRoewWCVIOvmicphNZCDgiKEQuw();
								RTDuQUSfWxlmIyoeFjWqcRjAYGk = kdBZqupjvsCsVkwJiOeEQzkEDVO.IrWUrxbhfOHHjzFPTPeMdNBGBMD().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 3;
								goto IL_00f4;
								IL_0155:
								if (WEfOPrdRpLsKeSRbWyIsqXgBGNT.MoveNext())
								{
									MVUgBMLesdixBlWyKLkidbWXDRQ = WEfOPrdRpLsKeSRbWyIsqXgBGNT.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = MVUgBMLesdixBlWyKLkidbWXDRQ;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 6;
									return true;
								}
								mkoFkLdNdBvGEWOkjYASCMslRkN();
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
							}
							finally
							{
								gRoewWCVIOvmicphNZCDgiKEQuw();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 3:
						case 4:
							try
							{
							}
							finally
							{
								mdnuwYPedzpkpwLoCjhSLQSgxzZ();
							}
							break;
						}
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 5:
						case 6:
							try
							{
								break;
							}
							finally
							{
								mkoFkLdNdBvGEWOkjYASCMslRkN();
							}
						}
					}

					[DebuggerHidden]
					public HhKRbrzDMcfAfiQyAhltaCVXBjR(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void gRoewWCVIOvmicphNZCDgiKEQuw()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (JjEleBenKIeVJqTlyKwlSJCdSbw != null)
						{
							JjEleBenKIeVJqTlyKwlSJCdSbw.Dispose();
						}
					}

					private void mdnuwYPedzpkpwLoCjhSLQSgxzZ()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (RTDuQUSfWxlmIyoeFjWqcRjAYGk != null)
						{
							RTDuQUSfWxlmIyoeFjWqcRjAYGk.Dispose();
						}
					}

					private void mkoFkLdNdBvGEWOkjYASCMslRkN()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (WEfOPrdRpLsKeSRbWyIsqXgBGNT != null)
						{
							WEfOPrdRpLsKeSRbWyIsqXgBGNT.Dispose();
						}
					}
				}

				private sealed class zXVYgPKiAtcnunbwkpwNSCcwjemb : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<Joystick> kmrSfKRvTJtjnlfypDpYEOIJpTD;

					public int fZfNpYeNPfrnuxRNhqMwGeVFHaE;

					public ControllerPollingInfo EGdITidzRLcZXoWHZjaxaLOacLLB;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> VjHZkdmVsDeLANaiMcqtdHehNVGV;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						zXVYgPKiAtcnunbwkpwNSCcwjemb zXVYgPKiAtcnunbwkpwNSCcwjemb2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							zXVYgPKiAtcnunbwkpwNSCcwjemb2 = this;
						}
						else
						{
							zXVYgPKiAtcnunbwkpwNSCcwjemb2 = new zXVYgPKiAtcnunbwkpwNSCcwjemb(0);
							zXVYgPKiAtcnunbwkpwNSCcwjemb2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return zXVYgPKiAtcnunbwkpwNSCcwjemb2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								kmrSfKRvTJtjnlfypDpYEOIJpTD = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
								fZfNpYeNPfrnuxRNhqMwGeVFHaE = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (fZfNpYeNPfrnuxRNhqMwGeVFHaE >= kmrSfKRvTJtjnlfypDpYEOIJpTD.Count)
								{
									break;
								}
								VjHZkdmVsDeLANaiMcqtdHehNVGV = kmrSfKRvTJtjnlfypDpYEOIJpTD[fZfNpYeNPfrnuxRNhqMwGeVFHaE].PollForAllElements().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (VjHZkdmVsDeLANaiMcqtdHehNVGV.MoveNext())
								{
									EGdITidzRLcZXoWHZjaxaLOacLLB = VjHZkdmVsDeLANaiMcqtdHehNVGV.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = EGdITidzRLcZXoWHZjaxaLOacLLB;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								pYcFnJGjwmMoBvxfbTmUXbQVOiN();
								fZfNpYeNPfrnuxRNhqMwGeVFHaE++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								pYcFnJGjwmMoBvxfbTmUXbQVOiN();
							}
						}
					}

					[DebuggerHidden]
					public zXVYgPKiAtcnunbwkpwNSCcwjemb(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void pYcFnJGjwmMoBvxfbTmUXbQVOiN()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (VjHZkdmVsDeLANaiMcqtdHehNVGV != null)
						{
							VjHZkdmVsDeLANaiMcqtdHehNVGV.Dispose();
						}
					}
				}

				private sealed class fnDkHwgZNqtnVurEoAARzYExUGj : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<Joystick> rAcAYllavmMtshLxxjKcPxDlOoV;

					public int ToezyccbbywoptmkgUcDgkrpCJT;

					public ControllerPollingInfo EShePOcKaWcSAIXMaKMudtnbpcA;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> NtFAmSKswEShFnjJykkVymzCOkg;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						fnDkHwgZNqtnVurEoAARzYExUGj fnDkHwgZNqtnVurEoAARzYExUGj2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							fnDkHwgZNqtnVurEoAARzYExUGj2 = this;
						}
						else
						{
							fnDkHwgZNqtnVurEoAARzYExUGj2 = new fnDkHwgZNqtnVurEoAARzYExUGj(0);
							fnDkHwgZNqtnVurEoAARzYExUGj2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return fnDkHwgZNqtnVurEoAARzYExUGj2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								rAcAYllavmMtshLxxjKcPxDlOoV = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
								ToezyccbbywoptmkgUcDgkrpCJT = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (ToezyccbbywoptmkgUcDgkrpCJT >= rAcAYllavmMtshLxxjKcPxDlOoV.Count)
								{
									break;
								}
								NtFAmSKswEShFnjJykkVymzCOkg = rAcAYllavmMtshLxxjKcPxDlOoV[ToezyccbbywoptmkgUcDgkrpCJT].PollForAllElementsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (NtFAmSKswEShFnjJykkVymzCOkg.MoveNext())
								{
									EShePOcKaWcSAIXMaKMudtnbpcA = NtFAmSKswEShFnjJykkVymzCOkg.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = EShePOcKaWcSAIXMaKMudtnbpcA;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								hMxPJyLHXJLdFdhFYdKpEeYnlzku();
								ToezyccbbywoptmkgUcDgkrpCJT++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								hMxPJyLHXJLdFdhFYdKpEeYnlzku();
							}
						}
					}

					[DebuggerHidden]
					public fnDkHwgZNqtnVurEoAARzYExUGj(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void hMxPJyLHXJLdFdhFYdKpEeYnlzku()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (NtFAmSKswEShFnjJykkVymzCOkg != null)
						{
							NtFAmSKswEShFnjJykkVymzCOkg.Dispose();
						}
					}
				}

				private sealed class rWFsKINTvmkJuhIRuAvzdyuSrOtj : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<Joystick> anaSSjjmDpGeFfbWbUStsSwBINwt;

					public int rsQiWFqPDLQjHTPWqeuBgcrKIboB;

					public ControllerPollingInfo longFWsczqBSsHJnsCUzItiGHAXB;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> mDmJUobLRWRzTfsDrBqUwEQpDr;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						rWFsKINTvmkJuhIRuAvzdyuSrOtj rWFsKINTvmkJuhIRuAvzdyuSrOtj2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							rWFsKINTvmkJuhIRuAvzdyuSrOtj2 = this;
						}
						else
						{
							rWFsKINTvmkJuhIRuAvzdyuSrOtj2 = new rWFsKINTvmkJuhIRuAvzdyuSrOtj(0);
							rWFsKINTvmkJuhIRuAvzdyuSrOtj2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return rWFsKINTvmkJuhIRuAvzdyuSrOtj2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								anaSSjjmDpGeFfbWbUStsSwBINwt = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
								rsQiWFqPDLQjHTPWqeuBgcrKIboB = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (rsQiWFqPDLQjHTPWqeuBgcrKIboB >= anaSSjjmDpGeFfbWbUStsSwBINwt.Count)
								{
									break;
								}
								mDmJUobLRWRzTfsDrBqUwEQpDr = anaSSjjmDpGeFfbWbUStsSwBINwt[rsQiWFqPDLQjHTPWqeuBgcrKIboB].PollForAllButtons().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (mDmJUobLRWRzTfsDrBqUwEQpDr.MoveNext())
								{
									longFWsczqBSsHJnsCUzItiGHAXB = mDmJUobLRWRzTfsDrBqUwEQpDr.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = longFWsczqBSsHJnsCUzItiGHAXB;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								mothFYNLQqPIijzQjJOpQQRaPph();
								rsQiWFqPDLQjHTPWqeuBgcrKIboB++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								mothFYNLQqPIijzQjJOpQQRaPph();
							}
						}
					}

					[DebuggerHidden]
					public rWFsKINTvmkJuhIRuAvzdyuSrOtj(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void mothFYNLQqPIijzQjJOpQQRaPph()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (mDmJUobLRWRzTfsDrBqUwEQpDr != null)
						{
							mDmJUobLRWRzTfsDrBqUwEQpDr.Dispose();
						}
					}
				}

				private sealed class mGcPBTApHWmIldBTJkYHPefoHne : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<Joystick> ppuVuyeNyegAvJSJCdCUVPqsMMBk;

					public int IPJbUUwGolVAslDWfsNRJptJEFX;

					public ControllerPollingInfo nPympipwapKjKRkbJYTGybrUBv;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> DZbFntgiheVINtRrTeVaOrNHQHH;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						mGcPBTApHWmIldBTJkYHPefoHne mGcPBTApHWmIldBTJkYHPefoHne2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							mGcPBTApHWmIldBTJkYHPefoHne2 = this;
						}
						else
						{
							mGcPBTApHWmIldBTJkYHPefoHne2 = new mGcPBTApHWmIldBTJkYHPefoHne(0);
							mGcPBTApHWmIldBTJkYHPefoHne2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return mGcPBTApHWmIldBTJkYHPefoHne2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								ppuVuyeNyegAvJSJCdCUVPqsMMBk = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
								IPJbUUwGolVAslDWfsNRJptJEFX = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (IPJbUUwGolVAslDWfsNRJptJEFX >= ppuVuyeNyegAvJSJCdCUVPqsMMBk.Count)
								{
									break;
								}
								DZbFntgiheVINtRrTeVaOrNHQHH = ppuVuyeNyegAvJSJCdCUVPqsMMBk[IPJbUUwGolVAslDWfsNRJptJEFX].PollForAllButtonsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (DZbFntgiheVINtRrTeVaOrNHQHH.MoveNext())
								{
									nPympipwapKjKRkbJYTGybrUBv = DZbFntgiheVINtRrTeVaOrNHQHH.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = nPympipwapKjKRkbJYTGybrUBv;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								TSeeZeKTjPpsPkaENHErZmBmiSA();
								IPJbUUwGolVAslDWfsNRJptJEFX++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								TSeeZeKTjPpsPkaENHErZmBmiSA();
							}
						}
					}

					[DebuggerHidden]
					public mGcPBTApHWmIldBTJkYHPefoHne(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void TSeeZeKTjPpsPkaENHErZmBmiSA()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (DZbFntgiheVINtRrTeVaOrNHQHH != null)
						{
							DZbFntgiheVINtRrTeVaOrNHQHH.Dispose();
						}
					}
				}

				private sealed class AWmvXYywmMDJlNsccTRNxtJfhgK : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<Joystick> lVfDFUhryhduPcYKJAcItgcLNmZW;

					public int GHYjIRXLBKFmjXOgCTMdZdjDhVt;

					public ControllerPollingInfo UVtgaaKFcnJyoBSNeFcfxjwcgUd;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> gaQLszvewceRJwAhKyTTXyNQNYp;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						AWmvXYywmMDJlNsccTRNxtJfhgK aWmvXYywmMDJlNsccTRNxtJfhgK;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							aWmvXYywmMDJlNsccTRNxtJfhgK = this;
						}
						else
						{
							aWmvXYywmMDJlNsccTRNxtJfhgK = new AWmvXYywmMDJlNsccTRNxtJfhgK(0);
							aWmvXYywmMDJlNsccTRNxtJfhgK.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return aWmvXYywmMDJlNsccTRNxtJfhgK;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								lVfDFUhryhduPcYKJAcItgcLNmZW = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
								GHYjIRXLBKFmjXOgCTMdZdjDhVt = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (GHYjIRXLBKFmjXOgCTMdZdjDhVt >= lVfDFUhryhduPcYKJAcItgcLNmZW.Count)
								{
									break;
								}
								gaQLszvewceRJwAhKyTTXyNQNYp = lVfDFUhryhduPcYKJAcItgcLNmZW[GHYjIRXLBKFmjXOgCTMdZdjDhVt].PollForAllAxes().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (gaQLszvewceRJwAhKyTTXyNQNYp.MoveNext())
								{
									UVtgaaKFcnJyoBSNeFcfxjwcgUd = gaQLszvewceRJwAhKyTTXyNQNYp.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = UVtgaaKFcnJyoBSNeFcfxjwcgUd;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								vsOqLSRoPzSmNnQjDiXTjjWIMGd();
								GHYjIRXLBKFmjXOgCTMdZdjDhVt++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								vsOqLSRoPzSmNnQjDiXTjjWIMGd();
							}
						}
					}

					[DebuggerHidden]
					public AWmvXYywmMDJlNsccTRNxtJfhgK(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void vsOqLSRoPzSmNnQjDiXTjjWIMGd()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (gaQLszvewceRJwAhKyTTXyNQNYp != null)
						{
							gaQLszvewceRJwAhKyTTXyNQNYp.Dispose();
						}
					}
				}

				private sealed class RLsKXgwyqVegzFKgcbPocjEsLDOb : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<CustomController> MBoXEzALNPnCxmIaxxLaGNtBuAP;

					public int kRXjlVbaKetiAVWAAmxLISByNFG;

					public ControllerPollingInfo xAghouINIdJJBddzBmjumUKOEVgb;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> JKEAOvoWsLIKhUXolIbNfCBNozI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						RLsKXgwyqVegzFKgcbPocjEsLDOb rLsKXgwyqVegzFKgcbPocjEsLDOb;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							rLsKXgwyqVegzFKgcbPocjEsLDOb = this;
						}
						else
						{
							rLsKXgwyqVegzFKgcbPocjEsLDOb = new RLsKXgwyqVegzFKgcbPocjEsLDOb(0);
							rLsKXgwyqVegzFKgcbPocjEsLDOb.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return rLsKXgwyqVegzFKgcbPocjEsLDOb;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								MBoXEzALNPnCxmIaxxLaGNtBuAP = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
								kRXjlVbaKetiAVWAAmxLISByNFG = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (kRXjlVbaKetiAVWAAmxLISByNFG >= MBoXEzALNPnCxmIaxxLaGNtBuAP.Count)
								{
									break;
								}
								JKEAOvoWsLIKhUXolIbNfCBNozI = MBoXEzALNPnCxmIaxxLaGNtBuAP[kRXjlVbaKetiAVWAAmxLISByNFG].PollForAllElements().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (JKEAOvoWsLIKhUXolIbNfCBNozI.MoveNext())
								{
									xAghouINIdJJBddzBmjumUKOEVgb = JKEAOvoWsLIKhUXolIbNfCBNozI.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = xAghouINIdJJBddzBmjumUKOEVgb;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								DjszPMKLkShACKEtfZyXKIDrCmi();
								kRXjlVbaKetiAVWAAmxLISByNFG++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								DjszPMKLkShACKEtfZyXKIDrCmi();
							}
						}
					}

					[DebuggerHidden]
					public RLsKXgwyqVegzFKgcbPocjEsLDOb(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void DjszPMKLkShACKEtfZyXKIDrCmi()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (JKEAOvoWsLIKhUXolIbNfCBNozI != null)
						{
							JKEAOvoWsLIKhUXolIbNfCBNozI.Dispose();
						}
					}
				}

				private sealed class YljZAmzLklvctWFHpFLurKvhCnk : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<CustomController> JbhRelBpjrvKJTeNfDktjmPDSDRU;

					public int ZfrBicPgEhEvpfEOAVHBoSNLOOI;

					public ControllerPollingInfo xkSFdZWzeZRuyeThnCUyxGNpcrC;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> TvEdPIHjLaWbbrFQSrPFOMnAnhQ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						YljZAmzLklvctWFHpFLurKvhCnk yljZAmzLklvctWFHpFLurKvhCnk;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							yljZAmzLklvctWFHpFLurKvhCnk = this;
						}
						else
						{
							yljZAmzLklvctWFHpFLurKvhCnk = new YljZAmzLklvctWFHpFLurKvhCnk(0);
							yljZAmzLklvctWFHpFLurKvhCnk.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return yljZAmzLklvctWFHpFLurKvhCnk;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								JbhRelBpjrvKJTeNfDktjmPDSDRU = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
								ZfrBicPgEhEvpfEOAVHBoSNLOOI = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (ZfrBicPgEhEvpfEOAVHBoSNLOOI >= JbhRelBpjrvKJTeNfDktjmPDSDRU.Count)
								{
									break;
								}
								TvEdPIHjLaWbbrFQSrPFOMnAnhQ = JbhRelBpjrvKJTeNfDktjmPDSDRU[ZfrBicPgEhEvpfEOAVHBoSNLOOI].PollForAllElementsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (TvEdPIHjLaWbbrFQSrPFOMnAnhQ.MoveNext())
								{
									xkSFdZWzeZRuyeThnCUyxGNpcrC = TvEdPIHjLaWbbrFQSrPFOMnAnhQ.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = xkSFdZWzeZRuyeThnCUyxGNpcrC;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								VUMkzxFWahEhPDYxFIFUGdPdGQh();
								ZfrBicPgEhEvpfEOAVHBoSNLOOI++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								VUMkzxFWahEhPDYxFIFUGdPdGQh();
							}
						}
					}

					[DebuggerHidden]
					public YljZAmzLklvctWFHpFLurKvhCnk(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void VUMkzxFWahEhPDYxFIFUGdPdGQh()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (TvEdPIHjLaWbbrFQSrPFOMnAnhQ != null)
						{
							TvEdPIHjLaWbbrFQSrPFOMnAnhQ.Dispose();
						}
					}
				}

				private sealed class xPALCGPesNqVwNSRvjgGAGhyDeg : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<CustomController> NUcpvmYALkobRCJquflMzZFaZBv;

					public int fXAeulkCcTbDmXqrBPePMcVMAgY;

					public ControllerPollingInfo YgeFjlFbRQMbTnvgqFKbOqsPOqiD;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> LteEEhHeRmWlnhDhowDIpHwXHTI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						xPALCGPesNqVwNSRvjgGAGhyDeg xPALCGPesNqVwNSRvjgGAGhyDeg2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							xPALCGPesNqVwNSRvjgGAGhyDeg2 = this;
						}
						else
						{
							xPALCGPesNqVwNSRvjgGAGhyDeg2 = new xPALCGPesNqVwNSRvjgGAGhyDeg(0);
							xPALCGPesNqVwNSRvjgGAGhyDeg2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return xPALCGPesNqVwNSRvjgGAGhyDeg2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								NUcpvmYALkobRCJquflMzZFaZBv = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
								fXAeulkCcTbDmXqrBPePMcVMAgY = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (fXAeulkCcTbDmXqrBPePMcVMAgY >= NUcpvmYALkobRCJquflMzZFaZBv.Count)
								{
									break;
								}
								LteEEhHeRmWlnhDhowDIpHwXHTI = NUcpvmYALkobRCJquflMzZFaZBv[fXAeulkCcTbDmXqrBPePMcVMAgY].PollForAllButtons().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (LteEEhHeRmWlnhDhowDIpHwXHTI.MoveNext())
								{
									YgeFjlFbRQMbTnvgqFKbOqsPOqiD = LteEEhHeRmWlnhDhowDIpHwXHTI.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = YgeFjlFbRQMbTnvgqFKbOqsPOqiD;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								osBBefdLMrkEwEJDzOfCzlPWdYiF();
								fXAeulkCcTbDmXqrBPePMcVMAgY++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								osBBefdLMrkEwEJDzOfCzlPWdYiF();
							}
						}
					}

					[DebuggerHidden]
					public xPALCGPesNqVwNSRvjgGAGhyDeg(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void osBBefdLMrkEwEJDzOfCzlPWdYiF()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (LteEEhHeRmWlnhDhowDIpHwXHTI != null)
						{
							LteEEhHeRmWlnhDhowDIpHwXHTI.Dispose();
						}
					}
				}

				private sealed class rxskHUjHwPoPedqvseDhzWCRRyY : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<CustomController> vbtoDdspkolCiMJGSiVPceppcCMq;

					public int yLyYgXWUXZpuEAmXugFHduniOIgP;

					public ControllerPollingInfo UPGIlcXDQwqjGZpVROgnapvahkr;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> sAXylSpHvhMSyQJrvFBbHyThNYQG;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						rxskHUjHwPoPedqvseDhzWCRRyY rxskHUjHwPoPedqvseDhzWCRRyY2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							rxskHUjHwPoPedqvseDhzWCRRyY2 = this;
						}
						else
						{
							rxskHUjHwPoPedqvseDhzWCRRyY2 = new rxskHUjHwPoPedqvseDhzWCRRyY(0);
							rxskHUjHwPoPedqvseDhzWCRRyY2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return rxskHUjHwPoPedqvseDhzWCRRyY2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								vbtoDdspkolCiMJGSiVPceppcCMq = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
								yLyYgXWUXZpuEAmXugFHduniOIgP = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (yLyYgXWUXZpuEAmXugFHduniOIgP >= vbtoDdspkolCiMJGSiVPceppcCMq.Count)
								{
									break;
								}
								sAXylSpHvhMSyQJrvFBbHyThNYQG = vbtoDdspkolCiMJGSiVPceppcCMq[yLyYgXWUXZpuEAmXugFHduniOIgP].PollForAllButtonsDown().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (sAXylSpHvhMSyQJrvFBbHyThNYQG.MoveNext())
								{
									UPGIlcXDQwqjGZpVROgnapvahkr = sAXylSpHvhMSyQJrvFBbHyThNYQG.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = UPGIlcXDQwqjGZpVROgnapvahkr;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								QJsopjlfdbbyNvguCLgHNDCiNPF();
								yLyYgXWUXZpuEAmXugFHduniOIgP++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								QJsopjlfdbbyNvguCLgHNDCiNPF();
							}
						}
					}

					[DebuggerHidden]
					public rxskHUjHwPoPedqvseDhzWCRRyY(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void QJsopjlfdbbyNvguCLgHNDCiNPF()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (sAXylSpHvhMSyQJrvFBbHyThNYQG != null)
						{
							sAXylSpHvhMSyQJrvFBbHyThNYQG.Dispose();
						}
					}
				}

				private sealed class VrztoVxXXqtMVZGtMEcNYGjpQHD : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
				{
					private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public IList<CustomController> snoOXKVVwaagnFAfldhvGfgMEzBU;

					public int nTLjbuvoZFrgtZmqYVMNkDiotad;

					public ControllerPollingInfo nohXoCjxqiirqNITbqSSigKdvqW;

					public PollingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ControllerPollingInfo> XZFaRSzEHjNmgGzIhBWeorjjzhH;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
					{
						VrztoVxXXqtMVZGtMEcNYGjpQHD vrztoVxXXqtMVZGtMEcNYGjpQHD;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							vrztoVxXXqtMVZGtMEcNYGjpQHD = this;
						}
						else
						{
							vrztoVxXXqtMVZGtMEcNYGjpQHD = new VrztoVxXXqtMVZGtMEcNYGjpQHD(0);
							vrztoVxXXqtMVZGtMEcNYGjpQHD.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						return vrztoVxXXqtMVZGtMEcNYGjpQHD;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								snoOXKVVwaagnFAfldhvGfgMEzBU = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
								nTLjbuvoZFrgtZmqYVMNkDiotad = 0;
								goto IL_00b8;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_0097;
								}
								IL_00b8:
								if (nTLjbuvoZFrgtZmqYVMNkDiotad >= snoOXKVVwaagnFAfldhvGfgMEzBU.Count)
								{
									break;
								}
								XZFaRSzEHjNmgGzIhBWeorjjzhH = snoOXKVVwaagnFAfldhvGfgMEzBU[nTLjbuvoZFrgtZmqYVMNkDiotad].PollForAllAxes().GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_0097;
								IL_0097:
								if (XZFaRSzEHjNmgGzIhBWeorjjzhH.MoveNext())
								{
									nohXoCjxqiirqNITbqSSigKdvqW = XZFaRSzEHjNmgGzIhBWeorjjzhH.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = nohXoCjxqiirqNITbqSSigKdvqW;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								EKYeLwaJoePGIoKYzQPTTadhpDr();
								nTLjbuvoZFrgtZmqYVMNkDiotad++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								EKYeLwaJoePGIoKYzQPTTadhpDr();
							}
						}
					}

					[DebuggerHidden]
					public VrztoVxXXqtMVZGtMEcNYGjpQHD(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void EKYeLwaJoePGIoKYzQPTTadhpDr()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (XZFaRSzEHjNmgGzIhBWeorjjzhH != null)
						{
							XZFaRSzEHjNmgGzIhBWeorjjzhH.Dispose();
						}
					}
				}

				private static PollingHelper cBGAPVaArOoNAxoZVXVJimDiaMfq;

				internal static PollingHelper Instance => cBGAPVaArOoNAxoZVXVJimDiaMfq ?? (cBGAPVaArOoNAxoZVXVJimDiaMfq = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = tPYgRPKhhVDjOUFQfmJfoLoevLE();
					if (result.success)
					{
						return result;
					}
					result = HrcQQPJaqsradbKddMtWghIATrW();
					if (result.success)
					{
						return result;
					}
					result = rzJxhXDKpxDwjoPbvIrbdUHyheIr();
					if (result.success)
					{
						return result;
					}
					result = owDyqRuplqTKIMBsnJFxAYEZSzJ();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = nnInniYgLzlBNFCKzWAqEGaQjlH();
					if (result.success)
					{
						return result;
					}
					result = sEIQPdfYxpzZVUCygKmdLOXrsSa();
					if (result.success)
					{
						return result;
					}
					result = sKspVQCHtNAkEvazVAXaYGEpjBX();
					if (result.success)
					{
						return result;
					}
					result = BTgXzhgTgasnOzbifGtFfbSHRLc();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = RLxeqnbLpUYMAlzBvcyzYjZIMJFb();
					if (result.success)
					{
						return result;
					}
					result = HrcQQPJaqsradbKddMtWghIATrW();
					if (result.success)
					{
						return result;
					}
					result = sAiaokcjMDKCsDZrgfHAhasUBXuc();
					if (result.success)
					{
						return result;
					}
					result = zfdHKhvTLsjKYIZWDHDCCTLKQaqk();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = HcyFWWBYldHSKRLdKkYhADlrYHi();
					if (result.success)
					{
						return result;
					}
					result = sEIQPdfYxpzZVUCygKmdLOXrsSa();
					if (result.success)
					{
						return result;
					}
					result = OhqAXJPlKKAaaHiuafjWgUhAeodS();
					if (result.success)
					{
						return result;
					}
					result = ZVnabXpIUtnFumMppmSBCUuKQUW();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					ControllerPollingInfo result = SNXBYfaMocebwbdMYGdJctseTCW();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					if (result.success)
					{
						return result;
					}
					result = iVKCdfiRQANSqAoRGuGIsQoZKVv();
					if (result.success)
					{
						return result;
					}
					result = sZnktTgKuipUdJWCRpeaIwUzQCH();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => tPYgRPKhhVDjOUFQfmJfoLoevLE(), 
						ControllerType.Keyboard => HrcQQPJaqsradbKddMtWghIATrW(), 
						ControllerType.Mouse => rzJxhXDKpxDwjoPbvIrbdUHyheIr(), 
						ControllerType.Custom => owDyqRuplqTKIMBsnJFxAYEZSzJ(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => nnInniYgLzlBNFCKzWAqEGaQjlH(), 
						ControllerType.Keyboard => sEIQPdfYxpzZVUCygKmdLOXrsSa(), 
						ControllerType.Mouse => sKspVQCHtNAkEvazVAXaYGEpjBX(), 
						ControllerType.Custom => BTgXzhgTgasnOzbifGtFfbSHRLc(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => RLxeqnbLpUYMAlzBvcyzYjZIMJFb(), 
						ControllerType.Keyboard => HrcQQPJaqsradbKddMtWghIATrW(), 
						ControllerType.Mouse => sAiaokcjMDKCsDZrgfHAhasUBXuc(), 
						ControllerType.Custom => zfdHKhvTLsjKYIZWDHDCCTLKQaqk(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => HcyFWWBYldHSKRLdKkYhADlrYHi(), 
						ControllerType.Keyboard => sEIQPdfYxpzZVUCygKmdLOXrsSa(), 
						ControllerType.Mouse => OhqAXJPlKKAaaHiuafjWgUhAeodS(), 
						ControllerType.Custom => ZVnabXpIUtnFumMppmSBCUuKQUW(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => SNXBYfaMocebwbdMYGdJctseTCW(), 
						ControllerType.Keyboard => ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX(), 
						ControllerType.Mouse => iVKCdfiRQANSqAoRGuGIsQoZKVv(), 
						ControllerType.Custom => sZnktTgKuipUdJWCRpeaIwUzQCH(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => rdGJuXrStgmfnXelKaOGpkeSefd(controllerId), 
						ControllerType.Keyboard => HrcQQPJaqsradbKddMtWghIATrW(), 
						ControllerType.Mouse => rzJxhXDKpxDwjoPbvIrbdUHyheIr(), 
						ControllerType.Custom => gdAMPQcKADevcSlJIpFrfRcAOxn(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => zJsbaVfrRcowEzSDpFBFXTSoaKQ(controllerId), 
						ControllerType.Keyboard => sEIQPdfYxpzZVUCygKmdLOXrsSa(), 
						ControllerType.Mouse => sKspVQCHtNAkEvazVAXaYGEpjBX(), 
						ControllerType.Custom => SEasjFmflggVTqguJyNFZsWzjFy(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => HYnLQWjvyZpncHURwYJjWToCfBm(controllerId), 
						ControllerType.Keyboard => HrcQQPJaqsradbKddMtWghIATrW(), 
						ControllerType.Mouse => sAiaokcjMDKCsDZrgfHAhasUBXuc(), 
						ControllerType.Custom => VTJGpZPOWKtFoEVfkAvNzjHjpmH(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => VXjjnGlVPbloKnfZutAomsOiqIJ(controllerId), 
						ControllerType.Keyboard => sEIQPdfYxpzZVUCygKmdLOXrsSa(), 
						ControllerType.Mouse => OhqAXJPlKKAaaHiuafjWgUhAeodS(), 
						ControllerType.Custom => MoyLlkWoUuHAmbzHJPOHzuhtKTU(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
					}
					return controllerType switch
					{
						ControllerType.Joystick => kcQIvKJJJNWmqwFMYMuyjkEgztX(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX(), 
						ControllerType.Mouse => iVKCdfiRQANSqAoRGuGIsQoZKVv(), 
						ControllerType.Custom => aCiNVjazMwXrCJpoGiWuJGEOOZ(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					WYvJrXGDJlcaagGHBDPjtgmzWUv wYvJrXGDJlcaagGHBDPjtgmzWUv = new WYvJrXGDJlcaagGHBDPjtgmzWUv(-2);
					wYvJrXGDJlcaagGHBDPjtgmzWUv.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return wYvJrXGDJlcaagGHBDPjtgmzWUv;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					imSawLwSsWWtGimdSTiqykWQpPH imSawLwSsWWtGimdSTiqykWQpPH2 = new imSawLwSsWWtGimdSTiqykWQpPH(-2);
					imSawLwSsWWtGimdSTiqykWQpPH2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return imSawLwSsWWtGimdSTiqykWQpPH2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					jKUcUQKjgagAmCpepQUhZBzTiZw jKUcUQKjgagAmCpepQUhZBzTiZw2 = new jKUcUQKjgagAmCpepQUhZBzTiZw(-2);
					jKUcUQKjgagAmCpepQUhZBzTiZw2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return jKUcUQKjgagAmCpepQUhZBzTiZw2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					mcagvEdymLBpufpGsfebWttHSjY mcagvEdymLBpufpGsfebWttHSjY2 = new mcagvEdymLBpufpGsfebWttHSjY(-2);
					mcagvEdymLBpufpGsfebWttHSjY2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return mcagvEdymLBpufpGsfebWttHSjY2;
				}

				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					HhKRbrzDMcfAfiQyAhltaCVXBjR hhKRbrzDMcfAfiQyAhltaCVXBjR = new HhKRbrzDMcfAfiQyAhltaCVXBjR(-2);
					hhKRbrzDMcfAfiQyAhltaCVXBjR.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return hhKRbrzDMcfAfiQyAhltaCVXBjR;
				}

				public IEnumerable<ControllerPollingInfo> PollControllerForAllElements(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<ControllerPollingInfo>.EmptyReadOnlyIListT;
					}
					return controllerType switch
					{
						ControllerType.Joystick => DQubbTveCDSUArAPdrjNXGYKVir(controllerId), 
						ControllerType.Keyboard => gAvgWIgfVZbXuFTWgjqyGdKUFRxA(), 
						ControllerType.Mouse => ZooFcvkMsjmnEomcITTqPWxhapy(), 
						ControllerType.Custom => mAshBjCizaZoFfPzZdwdmJFLlpR(controllerId), 
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
						ControllerType.Joystick => PmxAmTkoCsJxaDvxtwLoNsMQwNJa(controllerId), 
						ControllerType.Keyboard => UNbIRrbSwWaPpwzAWAJYgahWYve(), 
						ControllerType.Mouse => TTyoYZMohguwGZCZTlCpANfgGGB(), 
						ControllerType.Custom => BLWiRKbYmdfmIDLTQxKFvfwdBor(controllerId), 
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
						ControllerType.Joystick => vsDUowPZRvglIPHAgigUqgGgeOlh(controllerId), 
						ControllerType.Keyboard => gAvgWIgfVZbXuFTWgjqyGdKUFRxA(), 
						ControllerType.Mouse => awSCqvjylhyTWfJPsmnKHANpeyZD(), 
						ControllerType.Custom => OshdBbPKEQXOtKOYqDntkchcTUoS(controllerId), 
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
						ControllerType.Joystick => OYhgnGnVdGhRNWsvXZxobGZvbTd(controllerId), 
						ControllerType.Keyboard => UNbIRrbSwWaPpwzAWAJYgahWYve(), 
						ControllerType.Mouse => ARYkLJaQlDfnKwXxPMqbvhDkYgI(), 
						ControllerType.Custom => CFxnsvpCMNCuGjAIfRPObHhpmlV(controllerId), 
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
						ControllerType.Joystick => GuwCOXEfElIdOJVYGrJCVNuanDa(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => IrWUrxbhfOHHjzFPTPeMdNBGBMD(), 
						ControllerType.Custom => HUYoTxNRGNXcaHnNWgQlkrdPUoD(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo tPYgRPKhhVDjOUFQfmJfoLoevLE()
				{
					IList<Joystick> joysticks_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo nnInniYgLzlBNFCKzWAqEGaQjlH()
				{
					IList<Joystick> joysticks_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo RLxeqnbLpUYMAlzBvcyzYjZIMJFb()
				{
					IList<Joystick> joysticks_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo HcyFWWBYldHSKRLdKkYhADlrYHi()
				{
					IList<Joystick> joysticks_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo SNXBYfaMocebwbdMYGdJctseTCW()
				{
					IList<Joystick> joysticks_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
					for (int i = 0; i < joysticks_readOnly.Count; i++)
					{
						ControllerPollingInfo result = joysticks_readOnly[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo rdGJuXrStgmfnXelKaOGpkeSefd(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo zJsbaVfrRcowEzSDpFBFXTSoaKQ(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo HYnLQWjvyZpncHURwYJjWToCfBm(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo VXjjnGlVPbloKnfZutAomsOiqIJ(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo kcQIvKJJJNWmqwFMYMuyjkEgztX(int P_0)
				{
					return ControllerHelper.Instance.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo HrcQQPJaqsradbKddMtWghIATrW()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo sEIQPdfYxpzZVUCygKmdLOXrsSa()
				{
					return ControllerHelper.Instance.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo rzJxhXDKpxDwjoPbvIrbdUHyheIr()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo sKspVQCHtNAkEvazVAXaYGEpjBX()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo sAiaokcjMDKCsDZrgfHAhasUBXuc()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo OhqAXJPlKKAaaHiuafjWgUhAeodS()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo iVKCdfiRQANSqAoRGuGIsQoZKVv()
				{
					return ControllerHelper.Instance.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo owDyqRuplqTKIMBsnJFxAYEZSzJ()
				{
					IList<CustomController> customControllers_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo BTgXzhgTgasnOzbifGtFfbSHRLc()
				{
					IList<CustomController> customControllers_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo zfdHKhvTLsjKYIZWDHDCCTLKQaqk()
				{
					IList<CustomController> customControllers_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo ZVnabXpIUtnFumMppmSBCUuKQUW()
				{
					IList<CustomController> customControllers_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo sZnktTgKuipUdJWCRpeaIwUzQCH()
				{
					IList<CustomController> customControllers_readOnly = aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
					for (int i = 0; i < customControllers_readOnly.Count; i++)
					{
						ControllerPollingInfo result = customControllers_readOnly[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo gdAMPQcKADevcSlJIpFrfRcAOxn(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo SEasjFmflggVTqguJyNFZsWzjFy(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo VTJGpZPOWKtFoEVfkAvNzjHjpmH(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo MoyLlkWoUuHAmbzHJPOHzuhtKTU(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private ControllerPollingInfo aCiNVjazMwXrCJpoGiWuJGEOOZ(int P_0)
				{
					return ControllerHelper.Instance.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
				}

				private IEnumerable<ControllerPollingInfo> QbzynOjrnOnvocjncQfCACgbsUS()
				{
					zXVYgPKiAtcnunbwkpwNSCcwjemb zXVYgPKiAtcnunbwkpwNSCcwjemb2 = new zXVYgPKiAtcnunbwkpwNSCcwjemb(-2);
					zXVYgPKiAtcnunbwkpwNSCcwjemb2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return zXVYgPKiAtcnunbwkpwNSCcwjemb2;
				}

				private IEnumerable<ControllerPollingInfo> jSWKFzaBtDaxCdTuAXqkFlVBfiYx()
				{
					fnDkHwgZNqtnVurEoAARzYExUGj fnDkHwgZNqtnVurEoAARzYExUGj2 = new fnDkHwgZNqtnVurEoAARzYExUGj(-2);
					fnDkHwgZNqtnVurEoAARzYExUGj2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return fnDkHwgZNqtnVurEoAARzYExUGj2;
				}

				private IEnumerable<ControllerPollingInfo> XjWvmrssIbttOhBAesLVKzhmDJZ()
				{
					rWFsKINTvmkJuhIRuAvzdyuSrOtj rWFsKINTvmkJuhIRuAvzdyuSrOtj2 = new rWFsKINTvmkJuhIRuAvzdyuSrOtj(-2);
					rWFsKINTvmkJuhIRuAvzdyuSrOtj2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return rWFsKINTvmkJuhIRuAvzdyuSrOtj2;
				}

				private IEnumerable<ControllerPollingInfo> wAYzQZdOFdjBcGukUXuZNSQwOBYf()
				{
					mGcPBTApHWmIldBTJkYHPefoHne mGcPBTApHWmIldBTJkYHPefoHne2 = new mGcPBTApHWmIldBTJkYHPefoHne(-2);
					mGcPBTApHWmIldBTJkYHPefoHne2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return mGcPBTApHWmIldBTJkYHPefoHne2;
				}

				private IEnumerable<ControllerPollingInfo> MdyEqSXmldqLboElPopNnzFbCGU()
				{
					AWmvXYywmMDJlNsccTRNxtJfhgK aWmvXYywmMDJlNsccTRNxtJfhgK = new AWmvXYywmMDJlNsccTRNxtJfhgK(-2);
					aWmvXYywmMDJlNsccTRNxtJfhgK.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return aWmvXYywmMDJlNsccTRNxtJfhgK;
				}

				private IEnumerable<ControllerPollingInfo> DQubbTveCDSUArAPdrjNXGYKVir(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> PmxAmTkoCsJxaDvxtwLoNsMQwNJa(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> vsDUowPZRvglIPHAgigUqgGgeOlh(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> OYhgnGnVdGhRNWsvXZxobGZvbTd(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> GuwCOXEfElIdOJVYGrJCVNuanDa(int P_0)
				{
					Joystick joystick = ControllerHelper.Instance.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> gAvgWIgfVZbXuFTWgjqyGdKUFRxA()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> UNbIRrbSwWaPpwzAWAJYgahWYve()
				{
					return ControllerHelper.Instance.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> ZooFcvkMsjmnEomcITTqPWxhapy()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> TTyoYZMohguwGZCZTlCpANfgGGB()
				{
					return ControllerHelper.Instance.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> awSCqvjylhyTWfJPsmnKHANpeyZD()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> ARYkLJaQlDfnKwXxPMqbvhDkYgI()
				{
					return ControllerHelper.Instance.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> IrWUrxbhfOHHjzFPTPeMdNBGBMD()
				{
					return ControllerHelper.Instance.Mouse.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> lKBAYRZBwSfgdnPyfoiNuNMHctMd()
				{
					RLsKXgwyqVegzFKgcbPocjEsLDOb rLsKXgwyqVegzFKgcbPocjEsLDOb = new RLsKXgwyqVegzFKgcbPocjEsLDOb(-2);
					rLsKXgwyqVegzFKgcbPocjEsLDOb.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return rLsKXgwyqVegzFKgcbPocjEsLDOb;
				}

				private IEnumerable<ControllerPollingInfo> PmkgcCkBjeZVCjctKfZQZIfmZmn()
				{
					YljZAmzLklvctWFHpFLurKvhCnk yljZAmzLklvctWFHpFLurKvhCnk = new YljZAmzLklvctWFHpFLurKvhCnk(-2);
					yljZAmzLklvctWFHpFLurKvhCnk.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return yljZAmzLklvctWFHpFLurKvhCnk;
				}

				private IEnumerable<ControllerPollingInfo> AtSfiFgQODQAQAgVrkhiPyooONFu()
				{
					xPALCGPesNqVwNSRvjgGAGhyDeg xPALCGPesNqVwNSRvjgGAGhyDeg2 = new xPALCGPesNqVwNSRvjgGAGhyDeg(-2);
					xPALCGPesNqVwNSRvjgGAGhyDeg2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return xPALCGPesNqVwNSRvjgGAGhyDeg2;
				}

				private IEnumerable<ControllerPollingInfo> mMONWadVQHiCiUwCrqqwFLeElTW()
				{
					rxskHUjHwPoPedqvseDhzWCRRyY rxskHUjHwPoPedqvseDhzWCRRyY2 = new rxskHUjHwPoPedqvseDhzWCRRyY(-2);
					rxskHUjHwPoPedqvseDhzWCRRyY2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return rxskHUjHwPoPedqvseDhzWCRRyY2;
				}

				private IEnumerable<ControllerPollingInfo> cmLblIPEaIRbsSHdWaHCwBfiAEB()
				{
					VrztoVxXXqtMVZGtMEcNYGjpQHD vrztoVxXXqtMVZGtMEcNYGjpQHD = new VrztoVxXXqtMVZGtMEcNYGjpQHD(-2);
					vrztoVxXXqtMVZGtMEcNYGjpQHD.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					return vrztoVxXXqtMVZGtMEcNYGjpQHD;
				}

				private IEnumerable<ControllerPollingInfo> mAshBjCizaZoFfPzZdwdmJFLlpR(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> BLWiRKbYmdfmIDLTQxKFvfwdBor(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> OshdBbPKEQXOtKOYqDntkchcTUoS(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> CFxnsvpCMNCuGjAIfRPObHhpmlV(int P_0)
				{
					CustomController customController = ControllerHelper.Instance.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> HUYoTxNRGNXcaHnNWgQlkrdPUoD(int P_0)
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
				private sealed class sHWefSKDRPSZeMePwBnKUphQVCr : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public int oiWUinLKWXyukpIwfOtSoxBWeDp;

					public int kBafVmgKEFQPPTBkvkHyCHfcckVn;

					public int KnonnCxGElFAypUKvIFykJitAex;

					public int JaIbgBvkJnGWqmXPHauWGgRuboj;

					public JoystickMap tdDUHJCJvhemGRBxcGYtRUjQnjV;

					public JoystickMap knCBLkNLXkuIFCDBlGcZsTysnZf;

					public ActionElementMap zDxxeVQthcTQrXNTuckCqntFBMJ;

					public ActionElementMap zwrclSFEGAptHdMvIKRCbTPkMpdN;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public bool ccpzqYrOjqPoDCogssgEWxWEBWy;

					public bool pLoOGeKkzYCWCrXJjFxTDSsCqmHV;

					public IList<Player> CXIvMLoYMQwIdiJBMWIJFVTemhh;

					public int XWGCEPPHFgcxdpiFEaKPBkhQoCe;

					public ElementAssignmentConflictInfo CxzaRfwtLmtUGmPDNFtLUMZnHMD;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ElementAssignmentConflictInfo> JTMbuWQtLuAvHEsaIbnhZYdpxbrr;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						sHWefSKDRPSZeMePwBnKUphQVCr sHWefSKDRPSZeMePwBnKUphQVCr2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							sHWefSKDRPSZeMePwBnKUphQVCr2 = this;
						}
						else
						{
							sHWefSKDRPSZeMePwBnKUphQVCr2 = new sHWefSKDRPSZeMePwBnKUphQVCr(0);
							sHWefSKDRPSZeMePwBnKUphQVCr2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						sHWefSKDRPSZeMePwBnKUphQVCr2.oiWUinLKWXyukpIwfOtSoxBWeDp = kBafVmgKEFQPPTBkvkHyCHfcckVn;
						sHWefSKDRPSZeMePwBnKUphQVCr2.KnonnCxGElFAypUKvIFykJitAex = JaIbgBvkJnGWqmXPHauWGgRuboj;
						sHWefSKDRPSZeMePwBnKUphQVCr2.tdDUHJCJvhemGRBxcGYtRUjQnjV = knCBLkNLXkuIFCDBlGcZsTysnZf;
						sHWefSKDRPSZeMePwBnKUphQVCr2.zDxxeVQthcTQrXNTuckCqntFBMJ = zwrclSFEGAptHdMvIKRCbTPkMpdN;
						sHWefSKDRPSZeMePwBnKUphQVCr2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						sHWefSKDRPSZeMePwBnKUphQVCr2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						sHWefSKDRPSZeMePwBnKUphQVCr2.ccpzqYrOjqPoDCogssgEWxWEBWy = pLoOGeKkzYCWCrXJjFxTDSsCqmHV;
						return sHWefSKDRPSZeMePwBnKUphQVCr2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (oiWUinLKWXyukpIwfOtSoxBWeDp < 0 || zDxxeVQthcTQrXNTuckCqntFBMJ == null)
								{
									break;
								}
								CXIvMLoYMQwIdiJBMWIJFVTemhh = (ccpzqYrOjqPoDCogssgEWxWEBWy ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
								XWGCEPPHFgcxdpiFEaKPBkhQoCe = 0;
								goto IL_010f;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00ee;
								}
								IL_010f:
								if (XWGCEPPHFgcxdpiFEaKPBkhQoCe >= CXIvMLoYMQwIdiJBMWIJFVTemhh.Count)
								{
									break;
								}
								JTMbuWQtLuAvHEsaIbnhZYdpxbrr = CXIvMLoYMQwIdiJBMWIJFVTemhh[XWGCEPPHFgcxdpiFEaKPBkhQoCe].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, KnonnCxGElFAypUKvIFykJitAex, tdDUHJCJvhemGRBxcGYtRUjQnjV, zDxxeVQthcTQrXNTuckCqntFBMJ, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD).GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00ee;
								IL_00ee:
								if (JTMbuWQtLuAvHEsaIbnhZYdpxbrr.MoveNext())
								{
									CxzaRfwtLmtUGmPDNFtLUMZnHMD = JTMbuWQtLuAvHEsaIbnhZYdpxbrr.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = CxzaRfwtLmtUGmPDNFtLUMZnHMD;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								RSGyOuovdFNamkFkKrvmYgcFKbq();
								XWGCEPPHFgcxdpiFEaKPBkhQoCe++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								RSGyOuovdFNamkFkKrvmYgcFKbq();
							}
						}
					}

					[DebuggerHidden]
					public sHWefSKDRPSZeMePwBnKUphQVCr(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void RSGyOuovdFNamkFkKrvmYgcFKbq()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (JTMbuWQtLuAvHEsaIbnhZYdpxbrr != null)
						{
							JTMbuWQtLuAvHEsaIbnhZYdpxbrr.Dispose();
						}
					}
				}

				private sealed class JfEoLIKuiBuVOMApXcochlsylSYp : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ElementAssignmentConflictCheck sADsWDUCiahlWYuuUKwcFHVfnhS;

					public ElementAssignmentConflictCheck zOaFzOkpHDjDdAUAbeoShTwGIGW;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public bool ccpzqYrOjqPoDCogssgEWxWEBWy;

					public bool pLoOGeKkzYCWCrXJjFxTDSsCqmHV;

					public IList<Player> SBVbJGBnaWpVbtKrWApllwRIWaC;

					public int qlygFTLOrsTBFBKUscWdlmPVsJz;

					public ElementAssignmentConflictInfo GxlyJQXNyTjlCHOjCWIImiURJKo;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ElementAssignmentConflictInfo> valGwNCyqjCXsuZfrZPGthTOJUUG;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						JfEoLIKuiBuVOMApXcochlsylSYp jfEoLIKuiBuVOMApXcochlsylSYp;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							jfEoLIKuiBuVOMApXcochlsylSYp = this;
						}
						else
						{
							jfEoLIKuiBuVOMApXcochlsylSYp = new JfEoLIKuiBuVOMApXcochlsylSYp(0);
							jfEoLIKuiBuVOMApXcochlsylSYp.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						jfEoLIKuiBuVOMApXcochlsylSYp.sADsWDUCiahlWYuuUKwcFHVfnhS = zOaFzOkpHDjDdAUAbeoShTwGIGW;
						jfEoLIKuiBuVOMApXcochlsylSYp.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						jfEoLIKuiBuVOMApXcochlsylSYp.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						jfEoLIKuiBuVOMApXcochlsylSYp.ccpzqYrOjqPoDCogssgEWxWEBWy = pLoOGeKkzYCWCrXJjFxTDSsCqmHV;
						return jfEoLIKuiBuVOMApXcochlsylSYp;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (sADsWDUCiahlWYuuUKwcFHVfnhS.playerId < 0 || sADsWDUCiahlWYuuUKwcFHVfnhS.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								SBVbJGBnaWpVbtKrWApllwRIWaC = (ccpzqYrOjqPoDCogssgEWxWEBWy ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
								qlygFTLOrsTBFBKUscWdlmPVsJz = 0;
								goto IL_010d;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00ec;
								}
								IL_010d:
								if (qlygFTLOrsTBFBKUscWdlmPVsJz >= SBVbJGBnaWpVbtKrWApllwRIWaC.Count)
								{
									break;
								}
								valGwNCyqjCXsuZfrZPGthTOJUUG = SBVbJGBnaWpVbtKrWApllwRIWaC[qlygFTLOrsTBFBKUscWdlmPVsJz].controllers.conflictChecking.ElementAssignmentConflicts(sADsWDUCiahlWYuuUKwcFHVfnhS, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD).GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00ec;
								IL_00ec:
								if (valGwNCyqjCXsuZfrZPGthTOJUUG.MoveNext())
								{
									GxlyJQXNyTjlCHOjCWIImiURJKo = valGwNCyqjCXsuZfrZPGthTOJUUG.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = GxlyJQXNyTjlCHOjCWIImiURJKo;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								HsGEmzhRBHOKdAOzILyurImQSLa();
								qlygFTLOrsTBFBKUscWdlmPVsJz++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								HsGEmzhRBHOKdAOzILyurImQSLa();
							}
						}
					}

					[DebuggerHidden]
					public JfEoLIKuiBuVOMApXcochlsylSYp(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void HsGEmzhRBHOKdAOzILyurImQSLa()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (valGwNCyqjCXsuZfrZPGthTOJUUG != null)
						{
							valGwNCyqjCXsuZfrZPGthTOJUUG.Dispose();
						}
					}
				}

				private sealed class wMGDuINmAJGPtcZKQwstyBWJGxA : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public int oiWUinLKWXyukpIwfOtSoxBWeDp;

					public int kBafVmgKEFQPPTBkvkHyCHfcckVn;

					public KeyboardMap VkWlZzLeQpPjSCktuqWPheQkvNG;

					public KeyboardMap EwnBMFcqyviETpCkcKgWmOpkfJu;

					public ActionElementMap zDxxeVQthcTQrXNTuckCqntFBMJ;

					public ActionElementMap zwrclSFEGAptHdMvIKRCbTPkMpdN;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public bool ccpzqYrOjqPoDCogssgEWxWEBWy;

					public bool pLoOGeKkzYCWCrXJjFxTDSsCqmHV;

					public IList<Player> SqmxmPxMeHpFELPAECRasjtiJbq;

					public int HJLsvIRYJWhUUUbcukAaHvFAxra;

					public ElementAssignmentConflictInfo uoAWuWSGoIxfUmtKCzpMbmguMYz;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ElementAssignmentConflictInfo> qczrcprpCqYNqLohouHoozZkgyF;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						wMGDuINmAJGPtcZKQwstyBWJGxA wMGDuINmAJGPtcZKQwstyBWJGxA2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							wMGDuINmAJGPtcZKQwstyBWJGxA2 = this;
						}
						else
						{
							wMGDuINmAJGPtcZKQwstyBWJGxA2 = new wMGDuINmAJGPtcZKQwstyBWJGxA(0);
							wMGDuINmAJGPtcZKQwstyBWJGxA2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						wMGDuINmAJGPtcZKQwstyBWJGxA2.oiWUinLKWXyukpIwfOtSoxBWeDp = kBafVmgKEFQPPTBkvkHyCHfcckVn;
						wMGDuINmAJGPtcZKQwstyBWJGxA2.VkWlZzLeQpPjSCktuqWPheQkvNG = EwnBMFcqyviETpCkcKgWmOpkfJu;
						wMGDuINmAJGPtcZKQwstyBWJGxA2.zDxxeVQthcTQrXNTuckCqntFBMJ = zwrclSFEGAptHdMvIKRCbTPkMpdN;
						wMGDuINmAJGPtcZKQwstyBWJGxA2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						wMGDuINmAJGPtcZKQwstyBWJGxA2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						wMGDuINmAJGPtcZKQwstyBWJGxA2.ccpzqYrOjqPoDCogssgEWxWEBWy = pLoOGeKkzYCWCrXJjFxTDSsCqmHV;
						return wMGDuINmAJGPtcZKQwstyBWJGxA2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (oiWUinLKWXyukpIwfOtSoxBWeDp < 0 || zDxxeVQthcTQrXNTuckCqntFBMJ == null)
								{
									break;
								}
								SqmxmPxMeHpFELPAECRasjtiJbq = (ccpzqYrOjqPoDCogssgEWxWEBWy ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
								HJLsvIRYJWhUUUbcukAaHvFAxra = 0;
								goto IL_010a;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e9;
								}
								IL_010a:
								if (HJLsvIRYJWhUUUbcukAaHvFAxra >= SqmxmPxMeHpFELPAECRasjtiJbq.Count)
								{
									break;
								}
								qczrcprpCqYNqLohouHoozZkgyF = SqmxmPxMeHpFELPAECRasjtiJbq[HJLsvIRYJWhUUUbcukAaHvFAxra].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, VkWlZzLeQpPjSCktuqWPheQkvNG, zDxxeVQthcTQrXNTuckCqntFBMJ, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD).GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e9;
								IL_00e9:
								if (qczrcprpCqYNqLohouHoozZkgyF.MoveNext())
								{
									uoAWuWSGoIxfUmtKCzpMbmguMYz = qczrcprpCqYNqLohouHoozZkgyF.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = uoAWuWSGoIxfUmtKCzpMbmguMYz;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								ffTZOrmRSwVuBpQJrcUdZLxHYhY();
								HJLsvIRYJWhUUUbcukAaHvFAxra++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								ffTZOrmRSwVuBpQJrcUdZLxHYhY();
							}
						}
					}

					[DebuggerHidden]
					public wMGDuINmAJGPtcZKQwstyBWJGxA(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void ffTZOrmRSwVuBpQJrcUdZLxHYhY()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (qczrcprpCqYNqLohouHoozZkgyF != null)
						{
							qczrcprpCqYNqLohouHoozZkgyF.Dispose();
						}
					}
				}

				private sealed class BlXKVRNnhWNDpyaeQiplLfMNfhm : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ElementAssignmentConflictCheck sADsWDUCiahlWYuuUKwcFHVfnhS;

					public ElementAssignmentConflictCheck zOaFzOkpHDjDdAUAbeoShTwGIGW;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public bool ccpzqYrOjqPoDCogssgEWxWEBWy;

					public bool pLoOGeKkzYCWCrXJjFxTDSsCqmHV;

					public IList<Player> GFioupUQTATDyozrkfcfZhaBHcH;

					public int LzgjCdRPmftgimcPyyEPZOYlMN;

					public ElementAssignmentConflictInfo CpaeONAPiGadXoLffGvTFKBWPYJc;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ElementAssignmentConflictInfo> jUJRdosmgaJhPHRurKJaEqVIMQB;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						BlXKVRNnhWNDpyaeQiplLfMNfhm blXKVRNnhWNDpyaeQiplLfMNfhm;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							blXKVRNnhWNDpyaeQiplLfMNfhm = this;
						}
						else
						{
							blXKVRNnhWNDpyaeQiplLfMNfhm = new BlXKVRNnhWNDpyaeQiplLfMNfhm(0);
							blXKVRNnhWNDpyaeQiplLfMNfhm.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						blXKVRNnhWNDpyaeQiplLfMNfhm.sADsWDUCiahlWYuuUKwcFHVfnhS = zOaFzOkpHDjDdAUAbeoShTwGIGW;
						blXKVRNnhWNDpyaeQiplLfMNfhm.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						blXKVRNnhWNDpyaeQiplLfMNfhm.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						blXKVRNnhWNDpyaeQiplLfMNfhm.ccpzqYrOjqPoDCogssgEWxWEBWy = pLoOGeKkzYCWCrXJjFxTDSsCqmHV;
						return blXKVRNnhWNDpyaeQiplLfMNfhm;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (sADsWDUCiahlWYuuUKwcFHVfnhS.playerId < 0 || sADsWDUCiahlWYuuUKwcFHVfnhS.elementAssignmentType != ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								GFioupUQTATDyozrkfcfZhaBHcH = (ccpzqYrOjqPoDCogssgEWxWEBWy ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
								LzgjCdRPmftgimcPyyEPZOYlMN = 0;
								goto IL_010d;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00ec;
								}
								IL_010d:
								if (LzgjCdRPmftgimcPyyEPZOYlMN >= GFioupUQTATDyozrkfcfZhaBHcH.Count)
								{
									break;
								}
								jUJRdosmgaJhPHRurKJaEqVIMQB = GFioupUQTATDyozrkfcfZhaBHcH[LzgjCdRPmftgimcPyyEPZOYlMN].controllers.conflictChecking.ElementAssignmentConflicts(sADsWDUCiahlWYuuUKwcFHVfnhS, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD).GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00ec;
								IL_00ec:
								if (jUJRdosmgaJhPHRurKJaEqVIMQB.MoveNext())
								{
									CpaeONAPiGadXoLffGvTFKBWPYJc = jUJRdosmgaJhPHRurKJaEqVIMQB.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = CpaeONAPiGadXoLffGvTFKBWPYJc;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								yqSZBTluaSaipkEHXaYmAgvJcexJ();
								LzgjCdRPmftgimcPyyEPZOYlMN++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								yqSZBTluaSaipkEHXaYmAgvJcexJ();
							}
						}
					}

					[DebuggerHidden]
					public BlXKVRNnhWNDpyaeQiplLfMNfhm(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void yqSZBTluaSaipkEHXaYmAgvJcexJ()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (jUJRdosmgaJhPHRurKJaEqVIMQB != null)
						{
							jUJRdosmgaJhPHRurKJaEqVIMQB.Dispose();
						}
					}
				}

				private sealed class YZcKcAClkUchzoUCTGAGBPqqgVdT : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public int oiWUinLKWXyukpIwfOtSoxBWeDp;

					public int kBafVmgKEFQPPTBkvkHyCHfcckVn;

					public MouseMap FoKBGmGREOKCWZzVkVoQOiUllmkg;

					public MouseMap jtwlAAkkyNGceIEYgxNxLsRjwuql;

					public ActionElementMap zDxxeVQthcTQrXNTuckCqntFBMJ;

					public ActionElementMap zwrclSFEGAptHdMvIKRCbTPkMpdN;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public bool ccpzqYrOjqPoDCogssgEWxWEBWy;

					public bool pLoOGeKkzYCWCrXJjFxTDSsCqmHV;

					public IList<Player> uPpHrAUNUMGFBGSEqiFQPNGkLxeq;

					public int McdKDvkLAtBGVNzksREZAYFjalR;

					public ElementAssignmentConflictInfo WOSpGyyfsrhGfoDQuWECLdAQHeH;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ElementAssignmentConflictInfo> LWFIEYwnEAEIqLogkATudASyLbl;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						YZcKcAClkUchzoUCTGAGBPqqgVdT yZcKcAClkUchzoUCTGAGBPqqgVdT;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							yZcKcAClkUchzoUCTGAGBPqqgVdT = this;
						}
						else
						{
							yZcKcAClkUchzoUCTGAGBPqqgVdT = new YZcKcAClkUchzoUCTGAGBPqqgVdT(0);
							yZcKcAClkUchzoUCTGAGBPqqgVdT.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						yZcKcAClkUchzoUCTGAGBPqqgVdT.oiWUinLKWXyukpIwfOtSoxBWeDp = kBafVmgKEFQPPTBkvkHyCHfcckVn;
						yZcKcAClkUchzoUCTGAGBPqqgVdT.FoKBGmGREOKCWZzVkVoQOiUllmkg = jtwlAAkkyNGceIEYgxNxLsRjwuql;
						yZcKcAClkUchzoUCTGAGBPqqgVdT.zDxxeVQthcTQrXNTuckCqntFBMJ = zwrclSFEGAptHdMvIKRCbTPkMpdN;
						yZcKcAClkUchzoUCTGAGBPqqgVdT.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						yZcKcAClkUchzoUCTGAGBPqqgVdT.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						yZcKcAClkUchzoUCTGAGBPqqgVdT.ccpzqYrOjqPoDCogssgEWxWEBWy = pLoOGeKkzYCWCrXJjFxTDSsCqmHV;
						return yZcKcAClkUchzoUCTGAGBPqqgVdT;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (oiWUinLKWXyukpIwfOtSoxBWeDp < 0 || zDxxeVQthcTQrXNTuckCqntFBMJ == null)
								{
									break;
								}
								uPpHrAUNUMGFBGSEqiFQPNGkLxeq = (ccpzqYrOjqPoDCogssgEWxWEBWy ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
								McdKDvkLAtBGVNzksREZAYFjalR = 0;
								goto IL_010a;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00e9;
								}
								IL_010a:
								if (McdKDvkLAtBGVNzksREZAYFjalR >= uPpHrAUNUMGFBGSEqiFQPNGkLxeq.Count)
								{
									break;
								}
								LWFIEYwnEAEIqLogkATudASyLbl = uPpHrAUNUMGFBGSEqiFQPNGkLxeq[McdKDvkLAtBGVNzksREZAYFjalR].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, FoKBGmGREOKCWZzVkVoQOiUllmkg, zDxxeVQthcTQrXNTuckCqntFBMJ, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD).GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00e9;
								IL_00e9:
								if (LWFIEYwnEAEIqLogkATudASyLbl.MoveNext())
								{
									WOSpGyyfsrhGfoDQuWECLdAQHeH = LWFIEYwnEAEIqLogkATudASyLbl.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = WOSpGyyfsrhGfoDQuWECLdAQHeH;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								TDPRdwdBeSzTUUkAFfgKlxwCcKV();
								McdKDvkLAtBGVNzksREZAYFjalR++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								TDPRdwdBeSzTUUkAFfgKlxwCcKV();
							}
						}
					}

					[DebuggerHidden]
					public YZcKcAClkUchzoUCTGAGBPqqgVdT(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void TDPRdwdBeSzTUUkAFfgKlxwCcKV()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (LWFIEYwnEAEIqLogkATudASyLbl != null)
						{
							LWFIEYwnEAEIqLogkATudASyLbl.Dispose();
						}
					}
				}

				private sealed class luPdVOUetLGzJuvObPpvfAOVEAP : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ElementAssignmentConflictCheck sADsWDUCiahlWYuuUKwcFHVfnhS;

					public ElementAssignmentConflictCheck zOaFzOkpHDjDdAUAbeoShTwGIGW;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public bool ccpzqYrOjqPoDCogssgEWxWEBWy;

					public bool pLoOGeKkzYCWCrXJjFxTDSsCqmHV;

					public IList<Player> GWsqwqQrUpIzpFAgCsjNLxpLadB;

					public int PrJcvLHUmbfRsFfOrRiJbXaJsPpj;

					public ElementAssignmentConflictInfo nMFaNItVAmCOSOWFpPIBzgIYbpa;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ElementAssignmentConflictInfo> MSkNtpORmOixgDSvJPjvOqQNBdS;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						luPdVOUetLGzJuvObPpvfAOVEAP luPdVOUetLGzJuvObPpvfAOVEAP2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							luPdVOUetLGzJuvObPpvfAOVEAP2 = this;
						}
						else
						{
							luPdVOUetLGzJuvObPpvfAOVEAP2 = new luPdVOUetLGzJuvObPpvfAOVEAP(0);
							luPdVOUetLGzJuvObPpvfAOVEAP2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						luPdVOUetLGzJuvObPpvfAOVEAP2.sADsWDUCiahlWYuuUKwcFHVfnhS = zOaFzOkpHDjDdAUAbeoShTwGIGW;
						luPdVOUetLGzJuvObPpvfAOVEAP2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						luPdVOUetLGzJuvObPpvfAOVEAP2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						luPdVOUetLGzJuvObPpvfAOVEAP2.ccpzqYrOjqPoDCogssgEWxWEBWy = pLoOGeKkzYCWCrXJjFxTDSsCqmHV;
						return luPdVOUetLGzJuvObPpvfAOVEAP2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (sADsWDUCiahlWYuuUKwcFHVfnhS.playerId < 0 || sADsWDUCiahlWYuuUKwcFHVfnhS.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								GWsqwqQrUpIzpFAgCsjNLxpLadB = (ccpzqYrOjqPoDCogssgEWxWEBWy ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
								PrJcvLHUmbfRsFfOrRiJbXaJsPpj = 0;
								goto IL_010d;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00ec;
								}
								IL_010d:
								if (PrJcvLHUmbfRsFfOrRiJbXaJsPpj >= GWsqwqQrUpIzpFAgCsjNLxpLadB.Count)
								{
									break;
								}
								MSkNtpORmOixgDSvJPjvOqQNBdS = GWsqwqQrUpIzpFAgCsjNLxpLadB[PrJcvLHUmbfRsFfOrRiJbXaJsPpj].controllers.conflictChecking.ElementAssignmentConflicts(sADsWDUCiahlWYuuUKwcFHVfnhS, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD).GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00ec;
								IL_00ec:
								if (MSkNtpORmOixgDSvJPjvOqQNBdS.MoveNext())
								{
									nMFaNItVAmCOSOWFpPIBzgIYbpa = MSkNtpORmOixgDSvJPjvOqQNBdS.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = nMFaNItVAmCOSOWFpPIBzgIYbpa;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								NRJDzacggCfhJOgLfeYgdsofWMTM();
								PrJcvLHUmbfRsFfOrRiJbXaJsPpj++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								NRJDzacggCfhJOgLfeYgdsofWMTM();
							}
						}
					}

					[DebuggerHidden]
					public luPdVOUetLGzJuvObPpvfAOVEAP(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void NRJDzacggCfhJOgLfeYgdsofWMTM()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (MSkNtpORmOixgDSvJPjvOqQNBdS != null)
						{
							MSkNtpORmOixgDSvJPjvOqQNBdS.Dispose();
						}
					}
				}

				private sealed class jraHphrTcYfQnFeJFeCoZEPTHjm : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public int oiWUinLKWXyukpIwfOtSoxBWeDp;

					public int kBafVmgKEFQPPTBkvkHyCHfcckVn;

					public int KnonnCxGElFAypUKvIFykJitAex;

					public int JaIbgBvkJnGWqmXPHauWGgRuboj;

					public CustomControllerMap vaFeHBHGXpfaBIEWonnaqpgDxIF;

					public CustomControllerMap QtcRzqtvBSYDEvTRmsUPKyXubAx;

					public ActionElementMap zDxxeVQthcTQrXNTuckCqntFBMJ;

					public ActionElementMap zwrclSFEGAptHdMvIKRCbTPkMpdN;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public bool ccpzqYrOjqPoDCogssgEWxWEBWy;

					public bool pLoOGeKkzYCWCrXJjFxTDSsCqmHV;

					public IList<Player> xyILMJeZEVuaKauNhwmnNGQIYfJ;

					public int LJLdurKVAeoacbHJyheBiJmDhaE;

					public ElementAssignmentConflictInfo XpFnxvOHbRwmUsAdiFevCVOMcMIW;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ElementAssignmentConflictInfo> pMCNxfDMTqfULNCKIKCZlthkSvk;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						jraHphrTcYfQnFeJFeCoZEPTHjm jraHphrTcYfQnFeJFeCoZEPTHjm2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							jraHphrTcYfQnFeJFeCoZEPTHjm2 = this;
						}
						else
						{
							jraHphrTcYfQnFeJFeCoZEPTHjm2 = new jraHphrTcYfQnFeJFeCoZEPTHjm(0);
							jraHphrTcYfQnFeJFeCoZEPTHjm2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						jraHphrTcYfQnFeJFeCoZEPTHjm2.oiWUinLKWXyukpIwfOtSoxBWeDp = kBafVmgKEFQPPTBkvkHyCHfcckVn;
						jraHphrTcYfQnFeJFeCoZEPTHjm2.KnonnCxGElFAypUKvIFykJitAex = JaIbgBvkJnGWqmXPHauWGgRuboj;
						jraHphrTcYfQnFeJFeCoZEPTHjm2.vaFeHBHGXpfaBIEWonnaqpgDxIF = QtcRzqtvBSYDEvTRmsUPKyXubAx;
						jraHphrTcYfQnFeJFeCoZEPTHjm2.zDxxeVQthcTQrXNTuckCqntFBMJ = zwrclSFEGAptHdMvIKRCbTPkMpdN;
						jraHphrTcYfQnFeJFeCoZEPTHjm2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						jraHphrTcYfQnFeJFeCoZEPTHjm2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						jraHphrTcYfQnFeJFeCoZEPTHjm2.ccpzqYrOjqPoDCogssgEWxWEBWy = pLoOGeKkzYCWCrXJjFxTDSsCqmHV;
						return jraHphrTcYfQnFeJFeCoZEPTHjm2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (oiWUinLKWXyukpIwfOtSoxBWeDp < 0 || zDxxeVQthcTQrXNTuckCqntFBMJ == null)
								{
									break;
								}
								xyILMJeZEVuaKauNhwmnNGQIYfJ = (ccpzqYrOjqPoDCogssgEWxWEBWy ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
								LJLdurKVAeoacbHJyheBiJmDhaE = 0;
								goto IL_0110;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00ef;
								}
								IL_0110:
								if (LJLdurKVAeoacbHJyheBiJmDhaE >= xyILMJeZEVuaKauNhwmnNGQIYfJ.Count)
								{
									break;
								}
								pMCNxfDMTqfULNCKIKCZlthkSvk = xyILMJeZEVuaKauNhwmnNGQIYfJ[LJLdurKVAeoacbHJyheBiJmDhaE].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, KnonnCxGElFAypUKvIFykJitAex, vaFeHBHGXpfaBIEWonnaqpgDxIF, zDxxeVQthcTQrXNTuckCqntFBMJ, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD).GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00ef;
								IL_00ef:
								if (pMCNxfDMTqfULNCKIKCZlthkSvk.MoveNext())
								{
									XpFnxvOHbRwmUsAdiFevCVOMcMIW = pMCNxfDMTqfULNCKIKCZlthkSvk.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = XpFnxvOHbRwmUsAdiFevCVOMcMIW;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								oZitYnarEtkHzucEoLjqVNjPhey();
								LJLdurKVAeoacbHJyheBiJmDhaE++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								oZitYnarEtkHzucEoLjqVNjPhey();
							}
						}
					}

					[DebuggerHidden]
					public jraHphrTcYfQnFeJFeCoZEPTHjm(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void oZitYnarEtkHzucEoLjqVNjPhey()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (pMCNxfDMTqfULNCKIKCZlthkSvk != null)
						{
							pMCNxfDMTqfULNCKIKCZlthkSvk.Dispose();
						}
					}
				}

				private sealed class oofcIAIAlpLufPneOnyEapdbcUve : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
				{
					private ElementAssignmentConflictInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

					private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

					private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

					public ElementAssignmentConflictCheck sADsWDUCiahlWYuuUKwcFHVfnhS;

					public ElementAssignmentConflictCheck zOaFzOkpHDjDdAUAbeoShTwGIGW;

					public bool sBBuxyRWJQpBnxBQfhNyotyrnMk;

					public bool jujLEVfWMealwLetaGacIFFBsHPi;

					public bool CHBtzEcrnidqJpXrYvkBWeWbcbSD;

					public bool tszTRkROmrapuCTEblAHZJZKJOrE;

					public bool ccpzqYrOjqPoDCogssgEWxWEBWy;

					public bool pLoOGeKkzYCWCrXJjFxTDSsCqmHV;

					public IList<Player> cezgpaCxrRqgqHrPFdQNUSZHJqpP;

					public int vfSReYYiAehXROeaftMhrrjAqFF;

					public ElementAssignmentConflictInfo vcWhdckIHvPdYmQWljgQaELKcdNE;

					public ConflictCheckingHelper kdBZqupjvsCsVkwJiOeEQzkEDVO;

					public IEnumerator<ElementAssignmentConflictInfo> fkGfEeALzjTqwrHiCoErxGoVIWA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ajbaQItphrIyqhowgmMTfPkCBvcN;
						}
					}

					[DebuggerHidden]
					IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
					{
						oofcIAIAlpLufPneOnyEapdbcUve oofcIAIAlpLufPneOnyEapdbcUve2;
						if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
							oofcIAIAlpLufPneOnyEapdbcUve2 = this;
						}
						else
						{
							oofcIAIAlpLufPneOnyEapdbcUve2 = new oofcIAIAlpLufPneOnyEapdbcUve(0);
							oofcIAIAlpLufPneOnyEapdbcUve2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
						}
						oofcIAIAlpLufPneOnyEapdbcUve2.sADsWDUCiahlWYuuUKwcFHVfnhS = zOaFzOkpHDjDdAUAbeoShTwGIGW;
						oofcIAIAlpLufPneOnyEapdbcUve2.sBBuxyRWJQpBnxBQfhNyotyrnMk = jujLEVfWMealwLetaGacIFFBsHPi;
						oofcIAIAlpLufPneOnyEapdbcUve2.CHBtzEcrnidqJpXrYvkBWeWbcbSD = tszTRkROmrapuCTEblAHZJZKJOrE;
						oofcIAIAlpLufPneOnyEapdbcUve2.ccpzqYrOjqPoDCogssgEWxWEBWy = pLoOGeKkzYCWCrXJjFxTDSsCqmHV;
						return oofcIAIAlpLufPneOnyEapdbcUve2;
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
							switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
							{
							case 0:
								uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
								if (sADsWDUCiahlWYuuUKwcFHVfnhS.playerId < 0 || sADsWDUCiahlWYuuUKwcFHVfnhS.elementAssignmentType == ElementAssignmentType.KeyboardKey)
								{
									break;
								}
								cezgpaCxrRqgqHrPFdQNUSZHJqpP = (ccpzqYrOjqPoDCogssgEWxWEBWy ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
								vfSReYYiAehXROeaftMhrrjAqFF = 0;
								goto IL_010d;
							case 2:
								{
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
									goto IL_00ec;
								}
								IL_010d:
								if (vfSReYYiAehXROeaftMhrrjAqFF >= cezgpaCxrRqgqHrPFdQNUSZHJqpP.Count)
								{
									break;
								}
								fkGfEeALzjTqwrHiCoErxGoVIWA = cezgpaCxrRqgqHrPFdQNUSZHJqpP[vfSReYYiAehXROeaftMhrrjAqFF].controllers.conflictChecking.ElementAssignmentConflicts(sADsWDUCiahlWYuuUKwcFHVfnhS, sBBuxyRWJQpBnxBQfhNyotyrnMk, CHBtzEcrnidqJpXrYvkBWeWbcbSD).GetEnumerator();
								uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
								goto IL_00ec;
								IL_00ec:
								if (fkGfEeALzjTqwrHiCoErxGoVIWA.MoveNext())
								{
									vcWhdckIHvPdYmQWljgQaELKcdNE = fkGfEeALzjTqwrHiCoErxGoVIWA.Current;
									ajbaQItphrIyqhowgmMTfPkCBvcN = vcWhdckIHvPdYmQWljgQaELKcdNE;
									uoxvBdjXZPeiUprcFCMcTbYvPLr = 2;
									return true;
								}
								WgecwefGOvPjaEiFjzZuAQHVryPr();
								vfSReYYiAehXROeaftMhrrjAqFF++;
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
						switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
						{
						case 1:
						case 2:
							try
							{
								break;
							}
							finally
							{
								WgecwefGOvPjaEiFjzZuAQHVryPr();
							}
						}
					}

					[DebuggerHidden]
					public oofcIAIAlpLufPneOnyEapdbcUve(int _003C_003E1__state)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
						LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
					}

					private void WgecwefGOvPjaEiFjzZuAQHVryPr()
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						if (fkGfEeALzjTqwrHiCoErxGoVIWA != null)
						{
							fkGfEeALzjTqwrHiCoErxGoVIWA.Dispose();
						}
					}
				}

				private static ConflictCheckingHelper cBGAPVaArOoNAxoZVXVJimDiaMfq;

				internal static ConflictCheckingHelper Instance => cBGAPVaArOoNAxoZVXVJimDiaMfq ?? (cBGAPVaArOoNAxoZVXVJimDiaMfq = new ConflictCheckingHelper());

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
					IList<Player> list = (includeSystemPlayer ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
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
						ControllerType.Joystick => JeIWtKQTBXnyjCkiDAMmWaiiJsk(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => grekmIOqUshEKIQRaOdlrSSMZoo(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => emFXmSHxPCZvoGONqKjUcUduDKV(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => DFdzYgYcPgFYNkoMXQQtkhGuFPM(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return JeIWtKQTBXnyjCkiDAMmWaiiJsk(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return grekmIOqUshEKIQRaOdlrSSMZoo(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return emFXmSHxPCZvoGONqKjUcUduDKV(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return DFdzYgYcPgFYNkoMXQQtkhGuFPM(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool JeIWtKQTBXnyjCkiDAMmWaiiJsk(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool JeIWtKQTBXnyjCkiDAMmWaiiJsk(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool grekmIOqUshEKIQRaOdlrSSMZoo(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool grekmIOqUshEKIQRaOdlrSSMZoo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool emFXmSHxPCZvoGONqKjUcUduDKV(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool emFXmSHxPCZvoGONqKjUcUduDKV(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool DFdzYgYcPgFYNkoMXQQtkhGuFPM(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool DFdzYgYcPgFYNkoMXQQtkhGuFPM(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
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
						ControllerType.Joystick => OVmodnTpthUtpqvipfivteyGGVL(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => bUTDGHUuYDffUhrbmCXprZxCMFET(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => SypGFGjsRWpPuavtmcmMKAnLbyG(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => baznHSJGgKGCZAcOofJRInLpyzmh(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return OVmodnTpthUtpqvipfivteyGGVL(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return bUTDGHUuYDffUhrbmCXprZxCMFET(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return SypGFGjsRWpPuavtmcmMKAnLbyG(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return baznHSJGgKGCZAcOofJRInLpyzmh(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private IEnumerable<ElementAssignmentConflictInfo> OVmodnTpthUtpqvipfivteyGGVL(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					sHWefSKDRPSZeMePwBnKUphQVCr sHWefSKDRPSZeMePwBnKUphQVCr2 = new sHWefSKDRPSZeMePwBnKUphQVCr(-2);
					sHWefSKDRPSZeMePwBnKUphQVCr2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					sHWefSKDRPSZeMePwBnKUphQVCr2.kBafVmgKEFQPPTBkvkHyCHfcckVn = P_0;
					sHWefSKDRPSZeMePwBnKUphQVCr2.JaIbgBvkJnGWqmXPHauWGgRuboj = P_1;
					sHWefSKDRPSZeMePwBnKUphQVCr2.knCBLkNLXkuIFCDBlGcZsTysnZf = P_2;
					sHWefSKDRPSZeMePwBnKUphQVCr2.zwrclSFEGAptHdMvIKRCbTPkMpdN = P_3;
					sHWefSKDRPSZeMePwBnKUphQVCr2.jujLEVfWMealwLetaGacIFFBsHPi = P_4;
					sHWefSKDRPSZeMePwBnKUphQVCr2.tszTRkROmrapuCTEblAHZJZKJOrE = P_5;
					sHWefSKDRPSZeMePwBnKUphQVCr2.pLoOGeKkzYCWCrXJjFxTDSsCqmHV = P_6;
					return sHWefSKDRPSZeMePwBnKUphQVCr2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> OVmodnTpthUtpqvipfivteyGGVL(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					JfEoLIKuiBuVOMApXcochlsylSYp jfEoLIKuiBuVOMApXcochlsylSYp = new JfEoLIKuiBuVOMApXcochlsylSYp(-2);
					jfEoLIKuiBuVOMApXcochlsylSYp.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					jfEoLIKuiBuVOMApXcochlsylSYp.zOaFzOkpHDjDdAUAbeoShTwGIGW = P_0;
					jfEoLIKuiBuVOMApXcochlsylSYp.jujLEVfWMealwLetaGacIFFBsHPi = P_1;
					jfEoLIKuiBuVOMApXcochlsylSYp.tszTRkROmrapuCTEblAHZJZKJOrE = P_2;
					jfEoLIKuiBuVOMApXcochlsylSYp.pLoOGeKkzYCWCrXJjFxTDSsCqmHV = P_3;
					return jfEoLIKuiBuVOMApXcochlsylSYp;
				}

				private IEnumerable<ElementAssignmentConflictInfo> bUTDGHUuYDffUhrbmCXprZxCMFET(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					wMGDuINmAJGPtcZKQwstyBWJGxA wMGDuINmAJGPtcZKQwstyBWJGxA2 = new wMGDuINmAJGPtcZKQwstyBWJGxA(-2);
					wMGDuINmAJGPtcZKQwstyBWJGxA2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					wMGDuINmAJGPtcZKQwstyBWJGxA2.kBafVmgKEFQPPTBkvkHyCHfcckVn = P_0;
					wMGDuINmAJGPtcZKQwstyBWJGxA2.EwnBMFcqyviETpCkcKgWmOpkfJu = P_1;
					wMGDuINmAJGPtcZKQwstyBWJGxA2.zwrclSFEGAptHdMvIKRCbTPkMpdN = P_2;
					wMGDuINmAJGPtcZKQwstyBWJGxA2.jujLEVfWMealwLetaGacIFFBsHPi = P_3;
					wMGDuINmAJGPtcZKQwstyBWJGxA2.tszTRkROmrapuCTEblAHZJZKJOrE = P_4;
					wMGDuINmAJGPtcZKQwstyBWJGxA2.pLoOGeKkzYCWCrXJjFxTDSsCqmHV = P_5;
					return wMGDuINmAJGPtcZKQwstyBWJGxA2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> bUTDGHUuYDffUhrbmCXprZxCMFET(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					BlXKVRNnhWNDpyaeQiplLfMNfhm blXKVRNnhWNDpyaeQiplLfMNfhm = new BlXKVRNnhWNDpyaeQiplLfMNfhm(-2);
					blXKVRNnhWNDpyaeQiplLfMNfhm.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					blXKVRNnhWNDpyaeQiplLfMNfhm.zOaFzOkpHDjDdAUAbeoShTwGIGW = P_0;
					blXKVRNnhWNDpyaeQiplLfMNfhm.jujLEVfWMealwLetaGacIFFBsHPi = P_1;
					blXKVRNnhWNDpyaeQiplLfMNfhm.tszTRkROmrapuCTEblAHZJZKJOrE = P_2;
					blXKVRNnhWNDpyaeQiplLfMNfhm.pLoOGeKkzYCWCrXJjFxTDSsCqmHV = P_3;
					return blXKVRNnhWNDpyaeQiplLfMNfhm;
				}

				private IEnumerable<ElementAssignmentConflictInfo> SypGFGjsRWpPuavtmcmMKAnLbyG(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					YZcKcAClkUchzoUCTGAGBPqqgVdT yZcKcAClkUchzoUCTGAGBPqqgVdT = new YZcKcAClkUchzoUCTGAGBPqqgVdT(-2);
					yZcKcAClkUchzoUCTGAGBPqqgVdT.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					yZcKcAClkUchzoUCTGAGBPqqgVdT.kBafVmgKEFQPPTBkvkHyCHfcckVn = P_0;
					yZcKcAClkUchzoUCTGAGBPqqgVdT.jtwlAAkkyNGceIEYgxNxLsRjwuql = P_1;
					yZcKcAClkUchzoUCTGAGBPqqgVdT.zwrclSFEGAptHdMvIKRCbTPkMpdN = P_2;
					yZcKcAClkUchzoUCTGAGBPqqgVdT.jujLEVfWMealwLetaGacIFFBsHPi = P_3;
					yZcKcAClkUchzoUCTGAGBPqqgVdT.tszTRkROmrapuCTEblAHZJZKJOrE = P_4;
					yZcKcAClkUchzoUCTGAGBPqqgVdT.pLoOGeKkzYCWCrXJjFxTDSsCqmHV = P_5;
					return yZcKcAClkUchzoUCTGAGBPqqgVdT;
				}

				private IEnumerable<ElementAssignmentConflictInfo> SypGFGjsRWpPuavtmcmMKAnLbyG(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					luPdVOUetLGzJuvObPpvfAOVEAP luPdVOUetLGzJuvObPpvfAOVEAP2 = new luPdVOUetLGzJuvObPpvfAOVEAP(-2);
					luPdVOUetLGzJuvObPpvfAOVEAP2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					luPdVOUetLGzJuvObPpvfAOVEAP2.zOaFzOkpHDjDdAUAbeoShTwGIGW = P_0;
					luPdVOUetLGzJuvObPpvfAOVEAP2.jujLEVfWMealwLetaGacIFFBsHPi = P_1;
					luPdVOUetLGzJuvObPpvfAOVEAP2.tszTRkROmrapuCTEblAHZJZKJOrE = P_2;
					luPdVOUetLGzJuvObPpvfAOVEAP2.pLoOGeKkzYCWCrXJjFxTDSsCqmHV = P_3;
					return luPdVOUetLGzJuvObPpvfAOVEAP2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> baznHSJGgKGCZAcOofJRInLpyzmh(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					jraHphrTcYfQnFeJFeCoZEPTHjm jraHphrTcYfQnFeJFeCoZEPTHjm2 = new jraHphrTcYfQnFeJFeCoZEPTHjm(-2);
					jraHphrTcYfQnFeJFeCoZEPTHjm2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					jraHphrTcYfQnFeJFeCoZEPTHjm2.kBafVmgKEFQPPTBkvkHyCHfcckVn = P_0;
					jraHphrTcYfQnFeJFeCoZEPTHjm2.JaIbgBvkJnGWqmXPHauWGgRuboj = P_1;
					jraHphrTcYfQnFeJFeCoZEPTHjm2.QtcRzqtvBSYDEvTRmsUPKyXubAx = P_2;
					jraHphrTcYfQnFeJFeCoZEPTHjm2.zwrclSFEGAptHdMvIKRCbTPkMpdN = P_3;
					jraHphrTcYfQnFeJFeCoZEPTHjm2.jujLEVfWMealwLetaGacIFFBsHPi = P_4;
					jraHphrTcYfQnFeJFeCoZEPTHjm2.tszTRkROmrapuCTEblAHZJZKJOrE = P_5;
					jraHphrTcYfQnFeJFeCoZEPTHjm2.pLoOGeKkzYCWCrXJjFxTDSsCqmHV = P_6;
					return jraHphrTcYfQnFeJFeCoZEPTHjm2;
				}

				private IEnumerable<ElementAssignmentConflictInfo> baznHSJGgKGCZAcOofJRInLpyzmh(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					oofcIAIAlpLufPneOnyEapdbcUve oofcIAIAlpLufPneOnyEapdbcUve2 = new oofcIAIAlpLufPneOnyEapdbcUve(-2);
					oofcIAIAlpLufPneOnyEapdbcUve2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
					oofcIAIAlpLufPneOnyEapdbcUve2.zOaFzOkpHDjDdAUAbeoShTwGIGW = P_0;
					oofcIAIAlpLufPneOnyEapdbcUve2.jujLEVfWMealwLetaGacIFFBsHPi = P_1;
					oofcIAIAlpLufPneOnyEapdbcUve2.tszTRkROmrapuCTEblAHZJZKJOrE = P_2;
					oofcIAIAlpLufPneOnyEapdbcUve2.pLoOGeKkzYCWCrXJjFxTDSsCqmHV = P_3;
					return oofcIAIAlpLufPneOnyEapdbcUve2;
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
						ControllerType.Joystick => xRqBqWbMswerNseUVdpgFLoCocek(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => GNfBhpBDaQXObKJdTfWawDZxlrIW(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => gqRgLYwXhghsxJBnHxTPNtkOJtgd(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => oEiLyVZoXriXDbfWEBQBSdqOeXM(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return xRqBqWbMswerNseUVdpgFLoCocek(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return GNfBhpBDaQXObKJdTfWawDZxlrIW(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return gqRgLYwXhghsxJBnHxTPNtkOJtgd(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return oEiLyVZoXriXDbfWEBQBSdqOeXM(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int xRqBqWbMswerNseUVdpgFLoCocek(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int xRqBqWbMswerNseUVdpgFLoCocek(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int GNfBhpBDaQXObKJdTfWawDZxlrIW(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int GNfBhpBDaQXObKJdTfWawDZxlrIW(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int gqRgLYwXhghsxJBnHxTPNtkOJtgd(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int gqRgLYwXhghsxJBnHxTPNtkOJtgd(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int oEiLyVZoXriXDbfWEBQBSdqOeXM(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int oEiLyVZoXriXDbfWEBQBSdqOeXM(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
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
						ControllerType.Joystick => XrrakVLUIvJCxksvvkbBsiLCWry(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => SMvnpwePjOFzEdCsFoypuhhOqTFA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => jfjTCSLIZLJBNiRhECdBlZFntem(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => gdHVmJgkjQzYIcgryrfgFLhgkJF(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return XrrakVLUIvJCxksvvkbBsiLCWry(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return SMvnpwePjOFzEdCsFoypuhhOqTFA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return jfjTCSLIZLJBNiRhECdBlZFntem(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return gdHVmJgkjQzYIcgryrfgFLhgkJF(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int XrrakVLUIvJCxksvvkbBsiLCWry(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int XrrakVLUIvJCxksvvkbBsiLCWry(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int SMvnpwePjOFzEdCsFoypuhhOqTFA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int SMvnpwePjOFzEdCsFoypuhhOqTFA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int jfjTCSLIZLJBNiRhECdBlZFntem(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int jfjTCSLIZLJBNiRhECdBlZFntem(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int gdHVmJgkjQzYIcgryrfgFLhgkJF(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int gdHVmJgkjQzYIcgryrfgFLhgkJF(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly : USfldASbLlPourbEtKfoowSEGgo.Players_readOnly);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper cBGAPVaArOoNAxoZVXVJimDiaMfq;

			public readonly PollingHelper polling = PollingHelper.Instance;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.Instance;

			internal static ControllerHelper Instance => cBGAPVaArOoNAxoZVXVJimDiaMfq ?? (cBGAPVaArOoNAxoZVXVJimDiaMfq = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return aPNcjJCKQolbdJEKHuJkfRPTMco.controllerCount;
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
					return aPNcjJCKQolbdJEKHuJkfRPTMco.Controllers;
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
					return aPNcjJCKQolbdJEKHuJkfRPTMco.Mouse;
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
					return aPNcjJCKQolbdJEKHuJkfRPTMco.Keyboard;
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
					return aPNcjJCKQolbdJEKHuJkfRPTMco.joystickCount;
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
					return aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly;
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
					return aPNcjJCKQolbdJEKHuJkfRPTMco.customControllerCount;
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
					return aPNcjJCKQolbdJEKHuJkfRPTMco.CustomControllers_readOnly;
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
					return aPNcjJCKQolbdJEKHuJkfRPTMco.Keyboard as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return aPNcjJCKQolbdJEKHuJkfRPTMco.Mouse as T;
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
				return aPNcjJCKQolbdJEKHuJkfRPTMco.ZbGtisIkVmOkbLNUAlpAicawGu(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.ZbGtisIkVmOkbLNUAlpAicawGu(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.CDjnCrMZbGGAMUnUMTDGCdPpJkZ(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.rsuIiBmxTdeVboabAJdwNPzTWqs(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return USfldASbLlPourbEtKfoowSEGgo.qmDFIzGYulUJKGUsgvBzDqiWKvsF(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return USfldASbLlPourbEtKfoowSEGgo.qmDFIzGYulUJKGUsgvBzDqiWKvsF(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return USfldASbLlPourbEtKfoowSEGgo.BlQbHKandRnqXPhFYnpPfaWhUaKl(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					USfldASbLlPourbEtKfoowSEGgo.cGMtaipcmCyBYxrAQiqfiOsfYtW(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					USfldASbLlPourbEtKfoowSEGgo.cGMtaipcmCyBYxrAQiqfiOsfYtW(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.DjEdqahmwjneIiOCxudqBnmlLdFW(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return aPNcjJCKQolbdJEKHuJkfRPTMco.sFRhzwbwJENamFdozTvrBCQUxGC();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.TmuBgXKIzPBrnJUzRIdxdVobKNzN();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return USfldASbLlPourbEtKfoowSEGgo.IvrezgzceBEuYLfNAkpTLjlquXT(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return USfldASbLlPourbEtKfoowSEGgo.IvrezgzceBEuYLfNAkpTLjlquXT(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return USfldASbLlPourbEtKfoowSEGgo.qAWZRYIzkKFTLclJrdyvtJKhdHf(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					USfldASbLlPourbEtKfoowSEGgo.ebWjIQjVsjKQiODYgaOPjBSkXNwq(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					USfldASbLlPourbEtKfoowSEGgo.ebWjIQjVsjKQiODYgaOPjBSkXNwq(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!XjZjvbdFPtQBjmMQgUSNicoRCos)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				KDWPXJUwBfUFZCUizeOGzDRavGt();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (unityInputBuffer.MrDDmvTbGRImOEGdthEGcvYkPQwI(i, j))
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
				if (!XjZjvbdFPtQBjmMQgUSNicoRCos)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				KDWPXJUwBfUFZCUizeOGzDRavGt();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (unityInputBuffer.MrDDmvTbGRImOEGdthEGcvYkPQwI(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (unityInputBuffer.ushGfLoAVXAJqWwtRwZSjmKqKdT(i, k, positiveAxesOnly))
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
					if (!XjZjvbdFPtQBjmMQgUSNicoRCos)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						fjIUsQKflnkYVKJEJIlJoJufbQP.SetUnityJoystickId(joystickId, unityJoystickId);
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
				return aPNcjJCKQolbdJEKHuJkfRPTMco.bsfTsyrwELqckGDTZplJtQXhLEf(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.GNFsuerMGaIqAjZQCHWxdXBqZcXK();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.SpFatxALfUoRPNGNSAyUBzkhGqWC();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return USfldASbLlPourbEtKfoowSEGgo.JJFYCZaNtlCVQfSheeLgHUEbMDXT(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return USfldASbLlPourbEtKfoowSEGgo.JJFYCZaNtlCVQfSheeLgHUEbMDXT(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return USfldASbLlPourbEtKfoowSEGgo.CMfJZvBuJjpaQFmBkHplQOFPMbc(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					USfldASbLlPourbEtKfoowSEGgo.boJkshEfCridssATBESoRChHBOuB(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					USfldASbLlPourbEtKfoowSEGgo.boJkshEfCridssATBESoRChHBOuB(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.EEXCNqgVpUfeLKZrirmWsCPeGFli(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = aPNcjJCKQolbdJEKHuJkfRPTMco.EEXCNqgVpUfeLKZrirmWsCPeGFli(sourceControllerId);
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
				return aPNcjJCKQolbdJEKHuJkfRPTMco.IVeWpiSIKGIDRHGSqGuVGfhqHAL(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.LlcDycQirIicJKrnomSRXMoVxmD(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.GMitpWtyESwPjvwSHqzCjFCGvfR(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.NLscTSEJNtmCrMdGobsVmkcehci(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.tkZxDOlgYJVqYwoeJXjnqLyZBNU(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.XSPVJndKfUtJgYwHcgLhaPazdky<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.EgFZYQxVBCCUzptkFaEGSYRVBNb();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.EgFZYQxVBCCUzptkFaEGSYRVBNb(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.EgFZYQxVBCCUzptkFaEGSYRVBNb<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.CjgErvTVJOUFVnarHAVzmHSrpBV();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					aPNcjJCKQolbdJEKHuJkfRPTMco.MvGborIExmOgobVmPUOPCDhRdZd(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					aPNcjJCKQolbdJEKHuJkfRPTMco.MvGborIExmOgobVmPUOPCDhRdZd(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					aPNcjJCKQolbdJEKHuJkfRPTMco.CjdNlmspnwRwPMzNTWWEMLksHWK(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					aPNcjJCKQolbdJEKHuJkfRPTMco.rODMHhGlRsmkAmXMAUOhEStVaYW(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					aPNcjJCKQolbdJEKHuJkfRPTMco.rBtCdQwOhFJaLVTaHeAeaGEBcRb();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.uErIGsaCfVrhMzjnvTAimaVcBuDM();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.uErIGsaCfVrhMzjnvTAimaVcBuDM(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.uEcGaHgkKaQepEeRRYIyaETDGsiR();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.uEcGaHgkKaQepEeRRYIyaETDGsiR(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.UOlkBNWKtHFJwsNGRxGVpAsaAmeb();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.UOlkBNWKtHFJwsNGRxGVpAsaAmeb(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.PplchENCbauLcPKcNgQefbauMVmA();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.PplchENCbauLcPKcNgQefbauMVmA(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.MdzcSCEDfXUWKSyxQLUNeDIjnWta();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.MdzcSCEDfXUWKSyxQLUNeDIjnWta(controllerType);
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
				USfldASbLlPourbEtKfoowSEGgo.pxrxiumvSxmFHZqNkZtuUuxFAva(joystick);
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
			private static MappingHelper cBGAPVaArOoNAxoZVXVJimDiaMfq;

			internal static MappingHelper Instance => cBGAPVaArOoNAxoZVXVJimDiaMfq ?? (cBGAPVaArOoNAxoZVXVJimDiaMfq = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return LWLODUkCwfcNvCWHWwdHlYbcikq.MapCategories_readOnly;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.UserAssignableMapCategories;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.ActionCategories_readOnly;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.UserAssignableActionCategories;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.JoystickLayouts_readOnly;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.KeyboardLayouts_readOnly;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.MouseLayouts_readOnly;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.CustomControllerLayouts_readOnly;
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
					return bmLEnbkKNrTNSFrbOCrmcDPSGZKL.Actions;
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
					return LWLODUkCwfcNvCWHWwdHlYbcikq.UserAssignableActions;
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
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.KLxUdmCBCmPUZQpdQCUWpGaZTgw(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.cRngqjkIldbxIHSIfwrCHSxuEvc(tag);
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
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.sVMBiBXgoyIEWkVUSWZaOMHUbUL(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.AulGmsHARQKcmjjGmvHbujQSnEsf(tag);
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
					ControllerType.Joystick => LWLODUkCwfcNvCWHWwdHlYbcikq.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => LWLODUkCwfcNvCWHWwdHlYbcikq.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => LWLODUkCwfcNvCWHWwdHlYbcikq.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => LWLODUkCwfcNvCWHWwdHlYbcikq.GetCustomControllerLayoutById(layoutId), 
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
					ControllerType.Joystick => LWLODUkCwfcNvCWHWwdHlYbcikq.GetJoystickLayout(name), 
					ControllerType.Keyboard => LWLODUkCwfcNvCWHWwdHlYbcikq.GetKeyboardLayout(name), 
					ControllerType.Mouse => LWLODUkCwfcNvCWHWwdHlYbcikq.GetMouseLayout(name), 
					ControllerType.Custom => LWLODUkCwfcNvCWHWwdHlYbcikq.GetCustomControllerLayout(name), 
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
					ControllerType.Joystick => LWLODUkCwfcNvCWHWwdHlYbcikq.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => LWLODUkCwfcNvCWHWwdHlYbcikq.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => LWLODUkCwfcNvCWHWwdHlYbcikq.GetMouseLayoutId(name), 
					ControllerType.Custom => LWLODUkCwfcNvCWHWwdHlYbcikq.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetCustomControllerLayoutId(name);
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
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.nArLdFtrHDPJFSqVWpRakNGSbJq(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.nArLdFtrHDPJFSqVWpRakNGSbJq(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.nArLdFtrHDPJFSqVWpRakNGSbJq(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.nArLdFtrHDPJFSqVWpRakNGSbJq(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.ybWAFDKqydVBoHuSPMEEBhrTKZDE(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.AaLREFnuDoCnfLQTWKJsNAlJVcs(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.AaLREFnuDoCnfLQTWKJsNAlJVcs(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.AaLREFnuDoCnfLQTWKJsNAlJVcs(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.AaLREFnuDoCnfLQTWKJsNAlJVcs(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.ULwJdKkNlZyMLRMUSpEcyLnEHMVd(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.ULwJdKkNlZyMLRMUSpEcyLnEHMVd(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.TGBTlzxMydGPzMLlNNpkWykXunu(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return aPNcjJCKQolbdJEKHuJkfRPTMco.TGBTlzxMydGPzMLlNNpkWykXunu(playerId, behaviorName);
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
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior FrIEWThKozntQoWhXMslnsKoxTm(int P_0)
			{
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetInputBehaviorById(P_0);
			}

			internal InputBehavior FrIEWThKozntQoWhXMslnsKoxTm(string P_0)
			{
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetInputBehavior(P_0);
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
				Controller controller = aPNcjJCKQolbdJEKHuJkfRPTMco.ZbGtisIkVmOkbLNUAlpAicawGu(controllerIdentifier);
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
				JoystickMap joystickMap = LWLODUkCwfcNvCWHWwdHlYbcikq.dAntuILfYUUPSPWGcWNciDFsLko(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.UqhYnihUfIHBqSaeTWbwiJVKQLu(joystickMap);
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
				InputSource inputSourceType = fjIUsQKflnkYVKJEJIlJoJufbQP.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = YSEzHOqqVaKlvooxZDulFVVLiRTj.LVXijLLBGfgjuiYSfGhIuZvkjhB(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = LWLODUkCwfcNvCWHWwdHlYbcikq.YIRXiPCBuWEhVcNSXWLaNpLRdOL(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystickMap.controllerType = ControllerType.Joystick;
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.iNfVHMskitUPlImetCGFzJIKWnx(joystickMap, hardwareControllerMap_Game);
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
				if (aPNcjJCKQolbdJEKHuJkfRPTMco.ZbGtisIkVmOkbLNUAlpAicawGu(controllerIdentifier) is Joystick joystick)
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
				KeyboardMap keyboardMap = LWLODUkCwfcNvCWHWwdHlYbcikq.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.UqhYnihUfIHBqSaeTWbwiJVKQLu(keyboardMap);
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
				MouseMap mouseMap = LWLODUkCwfcNvCWHWwdHlYbcikq.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.UqhYnihUfIHBqSaeTWbwiJVKQLu(mouseMap);
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
				CustomControllerMap customControllerMap = LWLODUkCwfcNvCWHWwdHlYbcikq.AuMvOlnFHBkcQXDNUsENAfSzNfH(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.UqhYnihUfIHBqSaeTWbwiJVKQLu(customControllerMap);
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
				if (aPNcjJCKQolbdJEKHuJkfRPTMco.ZbGtisIkVmOkbLNUAlpAicawGu(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = LWLODUkCwfcNvCWHWwdHlYbcikq.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = LWLODUkCwfcNvCWHWwdHlYbcikq.AuMvOlnFHBkcQXDNUsENAfSzNfH(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.ODbFZfeokzbSMyFiHAkwhiknQgY();
					if (hardwareControllerMap_Game == null)
					{
						Logger.LogError("No hardware map found.");
						return null;
					}
					customControllerMap.controllerType = ControllerType.Custom;
					foreach (ActionElementMap allMap in customControllerMap.AllMaps)
					{
						allMap.iNfVHMskitUPlImetCGFzJIKWnx(customControllerMap, hardwareControllerMap_Game);
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
					controllerMap = LWLODUkCwfcNvCWHWwdHlYbcikq.UlqVyTSDDBoZvjxnAEFEnfKUirw(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.UqhYnihUfIHBqSaeTWbwiJVKQLu(controller, controllerMap);
					}
					else
					{
						controller.UqhYnihUfIHBqSaeTWbwiJVKQLu(controllerMap);
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
				if (aPNcjJCKQolbdJEKHuJkfRPTMco.ZbGtisIkVmOkbLNUAlpAicawGu(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = fjIUsQKflnkYVKJEJIlJoJufbQP.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = YSEzHOqqVaKlvooxZDulFVVLiRTj.LVXijLLBGfgjuiYSfGhIuZvkjhB(controllerIdentifier.hardwareTypeGuid, inputSourceType);
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
					joystickMap = LWLODUkCwfcNvCWHWwdHlYbcikq.YIRXiPCBuWEhVcNSXWLaNpLRdOL(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
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
						allMap.iNfVHMskitUPlImetCGFzJIKWnx(joystickMap, hardwareControllerMap_Game);
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
				if (aPNcjJCKQolbdJEKHuJkfRPTMco.ZbGtisIkVmOkbLNUAlpAicawGu(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = LWLODUkCwfcNvCWHWwdHlYbcikq.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
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
					customControllerMap = LWLODUkCwfcNvCWHWwdHlYbcikq.AuMvOlnFHBkcQXDNUsENAfSzNfH(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
				}
				if (customControllerMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = customControllerByHardwareTypeGuid.ODbFZfeokzbSMyFiHAkwhiknQgY();
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
						allMap.iNfVHMskitUPlImetCGFzJIKWnx(customControllerMap, hardwareControllerMap_Game);
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
					keyboardMap = LWLODUkCwfcNvCWHWwdHlYbcikq.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.UqhYnihUfIHBqSaeTWbwiJVKQLu(keyboard, keyboardMap);
					}
					else
					{
						keyboard.UqhYnihUfIHBqSaeTWbwiJVKQLu(keyboardMap);
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
					mouseMap = LWLODUkCwfcNvCWHWwdHlYbcikq.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.UqhYnihUfIHBqSaeTWbwiJVKQLu(mouse, mouseMap);
					}
					else
					{
						mouse.UqhYnihUfIHBqSaeTWbwiJVKQLu(mouseMap);
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
				return pqcPIenjzQxHCLBREMzpwCtZwAW(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier pqcPIenjzQxHCLBREMzpwCtZwAW(Guid P_0, int P_1)
			{
				return YSEzHOqqVaKlvooxZDulFVVLiRTj.pqcPIenjzQxHCLBREMzpwCtZwAW(P_0, P_1)?.ToControllerElementIdentifier();
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return LWLODUkCwfcNvCWHWwdHlYbcikq.eiSwDrNBAkymCImtrGOWbbgubhUY(templateTypeGuid, mapCategoryId, layoutId);
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
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = LWLODUkCwfcNvCWHWwdHlYbcikq.GetControllerMapLayoutManagerRuleSetId(name);
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
				return LWLODUkCwfcNvCWHWwdHlYbcikq.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = LWLODUkCwfcNvCWHWwdHlYbcikq.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper cBGAPVaArOoNAxoZVXVJimDiaMfq;

			internal static PlayerHelper Instance => cBGAPVaArOoNAxoZVXVJimDiaMfq ?? (cBGAPVaArOoNAxoZVXVJimDiaMfq = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return USfldASbLlPourbEtKfoowSEGgo.gamePlayerCount;
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
					return USfldASbLlPourbEtKfoowSEGgo.allPlayerCount;
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
					return USfldASbLlPourbEtKfoowSEGgo.Players_readOnly;
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
					return USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly;
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
					return USfldASbLlPourbEtKfoowSEGgo.InehxVsbhjanyOASwkbyVFduGgO();
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
					return USfldASbLlPourbEtKfoowSEGgo.Players_readOnly;
				}
				return USfldASbLlPourbEtKfoowSEGgo.AllPlayers_readOnly;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return USfldASbLlPourbEtKfoowSEGgo.FgvPueKchdieOiiAPcILDqNkmwJD(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return USfldASbLlPourbEtKfoowSEGgo.FgvPueKchdieOiiAPcILDqNkmwJD(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return USfldASbLlPourbEtKfoowSEGgo.InehxVsbhjanyOASwkbyVFduGgO();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return USfldASbLlPourbEtKfoowSEGgo.qITXfUNdBbAdXeHXFufzpoAzNmo(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return USfldASbLlPourbEtKfoowSEGgo.xmwbDOmUOkXNMSlXXfHxCKJhTeJW(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return USfldASbLlPourbEtKfoowSEGgo.pBdfGrYUULEoLxvxxmGAsARSAkya(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return USfldASbLlPourbEtKfoowSEGgo.xHufTcekvGBGnyBwePzLaeiczqCB(includeSystemPlayer);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper cBGAPVaArOoNAxoZVXVJimDiaMfq;

			internal static TimeHelper Instance => cBGAPVaArOoNAxoZVXVJimDiaMfq ?? (cBGAPVaArOoNAxoZVXVJimDiaMfq = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)pXuAagCXTuKWizWLfjxfVKYqdgX.unscaledDeltaTime;
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
					return pXuAagCXTuKWizWLfjxfVKYqdgX.unscaledTime;
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
					return pXuAagCXTuKWizWLfjxfVKYqdgX.frame;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class AnoDDYCXDUkEdKtwdcUYyHjbaDHT
		{
			private class CHCKusXHUJldREdbFQqVLVzacXT
			{
				public readonly UpdateLoopType iTlZorELHQDCESPLUCqUXMAKNVy;

				private double ynjANzJrXKZModnZDIcqqisQTavB;

				private double ibAfzCHQiyJGCQdVjCGEAWzmPg;

				private double RzegSOgDEdcalxxLIlidmpPPKpdA;

				private double aVohYhlQdfHrEtsuaSHViZfyPNg;

				private uint glnCkefADwqhUSvQepJThzMDQQF;

				private uint ngGWFTnHkXYMOqVZJcrchOPxDJgf;

				private float WUDawMBokYvRdJyPIbDjBxCGXVVh;

				private float vxjmaoflwkOvrdhzKqhhSgendSzC;

				public double unscaledTime => ynjANzJrXKZModnZDIcqqisQTavB;

				public double unscaledTimePrev => ibAfzCHQiyJGCQdVjCGEAWzmPg;

				public double unscaledDeltaTime => RzegSOgDEdcalxxLIlidmpPPKpdA;

				public uint frame => glnCkefADwqhUSvQepJThzMDQQF;

				public uint framePrev => ngGWFTnHkXYMOqVZJcrchOPxDJgf;

				public float unityUnscaledDeltaTime => WUDawMBokYvRdJyPIbDjBxCGXVVh;

				public float unityUnscaledDeltaTimePrev => vxjmaoflwkOvrdhzKqhhSgendSzC;

				public CHCKusXHUJldREdbFQqVLVzacXT(UpdateLoopType updateLoop)
				{
					iTlZorELHQDCESPLUCqUXMAKNVy = updateLoop;
					aVohYhlQdfHrEtsuaSHViZfyPNg = Time.realtimeSinceStartup;
					glnCkefADwqhUSvQepJThzMDQQF = 0u;
				}

				public void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
				{
					ibAfzCHQiyJGCQdVjCGEAWzmPg = ynjANzJrXKZModnZDIcqqisQTavB;
					ynjANzJrXKZModnZDIcqqisQTavB = ReInput.realTime;
					if (aVohYhlQdfHrEtsuaSHViZfyPNg > ynjANzJrXKZModnZDIcqqisQTavB)
					{
						aVohYhlQdfHrEtsuaSHViZfyPNg = 0.0;
					}
					RzegSOgDEdcalxxLIlidmpPPKpdA = ynjANzJrXKZModnZDIcqqisQTavB - aVohYhlQdfHrEtsuaSHViZfyPNg;
					aVohYhlQdfHrEtsuaSHViZfyPNg = ynjANzJrXKZModnZDIcqqisQTavB;
					ngGWFTnHkXYMOqVZJcrchOPxDJgf = glnCkefADwqhUSvQepJThzMDQQF;
					glnCkefADwqhUSvQepJThzMDQQF = MiscTools.Tick(glnCkefADwqhUSvQepJThzMDQQF);
					vxjmaoflwkOvrdhzKqhhSgendSzC = WUDawMBokYvRdJyPIbDjBxCGXVVh;
					WUDawMBokYvRdJyPIbDjBxCGXVVh = iXgPCkfWgLtHnELFVjdXDAUoqWu();
					previousFrame = ngGWFTnHkXYMOqVZJcrchOPxDJgf;
					currentFrame = glnCkefADwqhUSvQepJThzMDQQF;
					ReInput.unscaledTime = ynjANzJrXKZModnZDIcqqisQTavB;
					ReInput.unscaledTimePrev = ibAfzCHQiyJGCQdVjCGEAWzmPg;
					ReInput.unscaledDeltaTime = RzegSOgDEdcalxxLIlidmpPPKpdA;
				}
			}

			private static class ybvzgrIBTwUPlszsIsFvGDIYkBW
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

				public static StopwatchBase AxGMnpcloIAUTQTSFCdghQatHHxd()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase gQOtdCEPgcHixGpRNARUCQAaDckD()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase OUEjEiUJvkBjPkauXiNSsHDwkIHE;

			private double PllFjHmiGIxOgviVjrwdAJCCVln;

			private CHCKusXHUJldREdbFQqVLVzacXT pYfkoKEDPHacnQemzFQkFSPPaeo;

			private ADictionary<int, CHCKusXHUJldREdbFQqVLVzacXT> QxmarWEGdhLYCsDInsAHncgThDsa;

			private uint xfJlIAJOleMuWGDTDGAOWYhwwpE;

			public double unscaledTime => pYfkoKEDPHacnQemzFQkFSPPaeo.unscaledTime;

			public double unscaledTimePrev => pYfkoKEDPHacnQemzFQkFSPPaeo.unscaledTimePrev;

			public double unscaledDeltaTime => pYfkoKEDPHacnQemzFQkFSPPaeo.unscaledDeltaTime;

			public float unityUnscaledDeltaTime => pYfkoKEDPHacnQemzFQkFSPPaeo.unityUnscaledDeltaTime;

			public float unityUnscaledDeltaTimePrev => pYfkoKEDPHacnQemzFQkFSPPaeo.unityUnscaledDeltaTimePrev;

			internal double realTime => OUEjEiUJvkBjPkauXiNSsHDwkIHE.elapsedSeconds + PllFjHmiGIxOgviVjrwdAJCCVln;

			public uint frame => pYfkoKEDPHacnQemzFQkFSPPaeo.frame;

			public uint framePrev => pYfkoKEDPHacnQemzFQkFSPPaeo.framePrev;

			public uint absFrame => xfJlIAJOleMuWGDTDGAOWYhwwpE;

			public AnoDDYCXDUkEdKtwdcUYyHjbaDHT()
			{
				OUEjEiUJvkBjPkauXiNSsHDwkIHE = ybvzgrIBTwUPlszsIsFvGDIYkBW.Global;
				QjNHfjHnCmaQyvCGKbwODraSxUWC();
			}

			public void IJRSFtjbDxmmlTBOqQcAzaqrQpb()
			{
				PllFjHmiGIxOgviVjrwdAJCCVln = Time.realtimeSinceStartup;
			}

			public void QjNHfjHnCmaQyvCGKbwODraSxUWC()
			{
				pYfkoKEDPHacnQemzFQkFSPPaeo = null;
				QxmarWEGdhLYCsDInsAHncgThDsa = new ADictionary<int, CHCKusXHUJldREdbFQqVLVzacXT>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)2147483647, list);
				for (int i = 0; i < list.Count; i++)
				{
					CHCKusXHUJldREdbFQqVLVzacXT value = new CHCKusXHUJldREdbFQqVLVzacXT(list[i]);
					QxmarWEGdhLYCsDInsAHncgThDsa.Add((int)list[i], value);
					if (pYfkoKEDPHacnQemzFQkFSPPaeo == null)
					{
						pYfkoKEDPHacnQemzFQkFSPPaeo = value;
					}
				}
			}

			public void QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType P_0)
			{
				if (pYfkoKEDPHacnQemzFQkFSPPaeo.iTlZorELHQDCESPLUCqUXMAKNVy != P_0)
				{
					pYfkoKEDPHacnQemzFQkFSPPaeo = QxmarWEGdhLYCsDInsAHncgThDsa[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					pYfkoKEDPHacnQemzFQkFSPPaeo.QTPiZFmnRsxmyQYmMuIoBQkOtfg();
					xfJlIAJOleMuWGDTDGAOWYhwwpE = MiscTools.Tick(xfJlIAJOleMuWGDTDGAOWYhwwpE);
					ReInput.absFrame = xfJlIAJOleMuWGDTDGAOWYhwwpE;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch cBGAPVaArOoNAxoZVXVJimDiaMfq;

			internal static UnityTouch Instance => cBGAPVaArOoNAxoZVXVJimDiaMfq ?? (cBGAPVaArOoNAxoZVXVJimDiaMfq = new UnityTouch());

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

		internal class zrlYfeOvbUgAvePOGvJoyndkLTn
		{
			public readonly ValueWatcher<bool> dcjIWomhskoMuPNntGwCMofGPLB;

			public readonly ValueWatcher<bool> vqHFvdRWtggwOLVtjpoFnfUGpQt;

			public readonly ValueWatcher<bool> GCnzhsbfQXpZcCgKcbeYShaQMgK;

			public readonly ValueWatcher<int> QCNMecIGSpddsmfDqqrXmjMEQmC;

			public readonly ValueWatcher<float> RRIOjlceVUgBefornfxmXjrZPqA;

			public readonly ValueWatcher<string> nvXvMiOlDmAWgjcnyYTbztyVuzH;

			public readonly ValueWatcher<bool> BebCphBuGyXVHMobopQJvnVkoRuT;

			private int skXHqWxNjbxQPYxuVuSQCZmTRVA;

			private readonly ValueWatcher[] phtuZRkSEwBnOhCPMARFdxDUwQa;

			[CompilerGenerated]
			private static Func<bool> iTGyRHqczWvCMEPpHOFwdcSxakq;

			[CompilerGenerated]
			private static Func<bool> bQkYthqrDrRKsKajVUFpZwhNQFJ;

			[CompilerGenerated]
			private static Func<int> XXrutemcfqADKDmJRSkHODhntIk;

			[CompilerGenerated]
			private static Func<float> GvogOuZrViCVRerUgOGfljgQCez;

			[CompilerGenerated]
			private static Func<bool> jNlNYnqPAWjbrwhuJZchfiGbLnm;

			[CompilerGenerated]
			private static Func<string> pejIKonVXSiwuNnFQJroaWYUlqC;

			public int currentFrame => skXHqWxNjbxQPYxuVuSQCZmTRVA;

			public zrlYfeOvbUgAvePOGvJoyndkLTn()
			{
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(dcjIWomhskoMuPNntGwCMofGPLB = new ValueWatcher<bool>(initialValue: true, autoTriggerEvent: false)),
					(vqHFvdRWtggwOLVtjpoFnfUGpQt = new ValueWatcher<bool>(Screen.fullScreen, () => Screen.fullScreen, autoTriggerEvent: false)),
					(GCnzhsbfQXpZcCgKcbeYShaQMgK = new ValueWatcher<bool>(Application.runInBackground, () => Application.runInBackground, autoTriggerEvent: false)),
					(QCNMecIGSpddsmfDqqrXmjMEQmC = new ValueWatcher<int>((int)Screen.fullScreenMode, () => (int)Screen.fullScreenMode, autoTriggerEvent: false)),
					(RRIOjlceVUgBefornfxmXjrZPqA = new ValueWatcher<float>(Time.unscaledDeltaTime, () => Time.unscaledDeltaTime, autoTriggerEvent: false)),
					(BebCphBuGyXVHMobopQJvnVkoRuT = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), () => MathTools.ApproximatelyZero(Time.timeScale), MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(nvXvMiOlDmAWgjcnyYTbztyVuzH = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), () => UnityTools.externalTools.GetFocusedEditorWindowTitle(), autoTriggerEvent: false));
				}
				phtuZRkSEwBnOhCPMARFdxDUwQa = list.ToArray();
				QTPiZFmnRsxmyQYmMuIoBQkOtfg();
			}

			public void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
				for (int i = 0; i < phtuZRkSEwBnOhCPMARFdxDUwQa.Length; i++)
				{
					phtuZRkSEwBnOhCPMARFdxDUwQa[i].Update();
				}
				skXHqWxNjbxQPYxuVuSQCZmTRVA = Time.frameCount;
			}

			public void PvDFaluYFJJxMtMtZaTCVYLFpGq()
			{
				for (int i = 0; i < phtuZRkSEwBnOhCPMARFdxDUwQa.Length; i++)
				{
					phtuZRkSEwBnOhCPMARFdxDUwQa[i].TriggerEvent();
				}
			}

			[CompilerGenerated]
			private static bool JkYTeenfcgRfUbokfaRaGGcNlcK()
			{
				return Screen.fullScreen;
			}

			[CompilerGenerated]
			private static bool LnJnUvKTFYWbuUbUgTOuanlLFRp()
			{
				return Application.runInBackground;
			}

			[CompilerGenerated]
			private static int SgkwVplAKEzHYtgmkZBvizycWaG()
			{
				return (int)Screen.fullScreenMode;
			}

			[CompilerGenerated]
			private static float JbxvWaebtgGcoSlcebXOOGCqTVT()
			{
				return Time.unscaledDeltaTime;
			}

			[CompilerGenerated]
			private static bool lTMEzWVQhRmrEJSfjvAWeitaegHB()
			{
				return MathTools.ApproximatelyZero(Time.timeScale);
			}

			[CompilerGenerated]
			private static string zEOtYPfmPTHdszflnyevxPYKHRL()
			{
				return UnityTools.externalTools.GetFocusedEditorWindowTitle();
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int programVersion1 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion2 = 1;

		[CustomObfuscation(rename = false)]
		internal const int programVersion3 = 40;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 0;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2020";

		private static InputManager_Base ceSrziAFVHlZSgalWFBehsjWmKTA;

		private static PlatformInputManager fjIUsQKflnkYVKJEJIlJoJufbQP;

		internal static SlfkunxWuMcSymhpycotdVbpUpl bmLEnbkKNrTNSFrbOCrmcDPSGZKL;

		internal static ChYhaBSijJnTpdXwQSqYJssvGND aPNcjJCKQolbdJEKHuJkfRPTMco;

		internal static kfVJCyCDaGCuiDEEEMtqgVXykXX USfldASbLlPourbEtKfoowSEGgo;

		private static ControllerDataFiles YSEzHOqqVaKlvooxZDulFVVLiRTj;

		private static UserData LWLODUkCwfcNvCWHWwdHlYbcikq;

		private static bool XrAXpRFFCZWxSkTUXpVlgetwinP;

		private static ConfigVars zeOdvKvLepaDssBfYXvcNnfTGHoC;

		private static UpdateLoopType aFzbHLXYPqOlDTBvxsrImZkLaRs;

		private static bool XjZjvbdFPtQBjmMQgUSNicoRCos;

		private static Platform NBExHKACOtceRjeveueAfrwdqkMW;

		private static WebplayerPlatform nMieJgQejclQhhHENtuZGMmIdmi;

		private static EditorPlatform HvUsjbcKcvfjVDepXAAIQHsgOww;

		private static bool HKZvDBrDsCgGajtCNzALINscVkrg;

		private static TimerAbs qPuFJukrKCcGvZtLpLLHcFEeTPt;

		private static AnoDDYCXDUkEdKtwdcUYyHjbaDHT pXuAagCXTuKWizWLfjxfVKYqdgX;

		private static string DStXnsJPDYBkOaDCOpcdNDUCVpG;

		private static bool QyVMBkucmxpRoztSqHXCzXWZMWE;

		private static bool vQJFdlnOvzdcghIhxuyhpwuBafc;

		private static bool JANEGdNmkfnchLMzOdWbzhwMsbi;

		private static int nOqtNxCcNhoSXgsBttvcrmEcFSE;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int LeqsTlLDjeOPDUuyfgRRZGsvPKt;

		private static int xKafMYTkZexvDqVBmfswMzqGqSe;

		private static bool qVYgDleOAcZYuNBYKhOVnajcORpT;

		private static readonly UnityTouch VvcDSlhFAMPDdTqaSqwhbydZYbA;

		private static readonly PlayerHelper taXwJZxAXteMsBkTbirAkbwVqTz;

		private static readonly ControllerHelper fwOhMezaqAlQEcPOQhEvpMRTJuZ;

		private static readonly MappingHelper BEKpREJARyzPnScVzVTzDkjHvTF;

		private static readonly TimeHelper XZSsOYkkhitBnZcszsPGUEnbpbH;

		private static readonly ConfigHelper IBSTvRgaVrWTyzrOFbAkkPeqBlbI;

		private static dxdVHUQhSKaxTEqojwtlXxPkTiQ TYpWQJrIXPKLBpKYDjrOnproFHN;

		private static UserDataStore cNIwUCqOcbVUPawPCiVyYBlREkaj;

		private static IControllerAssigner ryPehyHpeIXjvNfdmrovYfpIImhh;

		private static zrlYfeOvbUgAvePOGvJoyndkLTn bhIzyHLfWoyXWELgSlrJYhqmUHY;

		private static SafeAction<ControllerStatusChangedEventArgs> DwjGQaJjOeKzELLYwYKnxItCJOM;

		private static SafeAction<ControllerStatusChangedEventArgs> iYtaZKJWbBhuafhohwyeCWyphei;

		private static SafeAction<ControllerStatusChangedEventArgs> scoRCaiNNHKrBvMueNRLVIlEgSu;

		private static SafeAction uapjRCHVYLXRJmHVSxlSgZLoTDyw;

		private static SafeAction qUbiBHgIBetcCXoWCNADunPwCzcE;

		private static SafeAction clyEamldAbFPcbnaTgDvOceCdMX;

		private static SafeAction geXnHaLAAGSuNCtsphijUOmpkxu;

		private static SafeAction KvpNnnojMosgISmEtarGaEoUeaDi;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action rbmELGhAKXHnZYZdUwvzRbnqMQk;

		private static Action<UpdateLoopType> cnvrxNioVvBjmgZYoHXfqBGpSBt;

		private static Action<UpdateLoopType> kYlWmpVmhiIyrhzvCdhiRzrIPmG;

		private static Action<UpdateLoopType> sLhzeeMaJGmpyHSEywBIJUhWfma;

		private static Action YXVbcRhPNFQzcqNjtaIOqylNhRU;

		private static Action<bool> NMAGmUgKaqqchVSkPbVpqujljfGU;

		private static Action<bool> gjqJApsmjvHfHsaZwlpFSoCTqUD;

		private static Action<bool> zEucRCdGgVQpGwEnIJLwoikDCrLM;

		private static Action<FullScreenMode> hbsXhQvyCrPFPzzLgeNApumilJr;

		private static Action NqiZOWvirKVFPjtaZpsUkikBFoQ;

		private static Action<bool> qLQgENvTyBMEpNcbJbmUHiqPSff;

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
		private static Action<Exception> GMUjmsdqRVqHRAZkBEOFiCKrAlO;

		[CompilerGenerated]
		private static Action<Exception> xWtfVpEAAEIKKdpVATSjOZuqaKin;

		[CompilerGenerated]
		private static Action<Exception> CuxsraehqcBBnFzwaUhfNpVJmUD;

		[CompilerGenerated]
		private static Action<Exception> ohFNtQgufMrUlDPMHEjeyWNlCrmj;

		[CompilerGenerated]
		private static Action<Exception> VbWBeYhyXOxlSVXrgfsxXKbeIWM;

		[CompilerGenerated]
		private static Action<Exception> EudIHqBtECzYpNADrIYxshPgjtH;

		[CompilerGenerated]
		private static Action<Exception> oeTPpiFSbmpcOHCzkExecQjUdYcL;

		[CompilerGenerated]
		private static Action<Exception> CJthRozlPiPZkgiQDbPAQnradBI;

		[CompilerGenerated]
		private static Action<Exception> BOYwLHmOpmseXqSMacsBrCKNQni;

		[CompilerGenerated]
		private static Func<bool> uisfbpwvEjdcmGlkGyymOWfUddWI;

		private static dxdVHUQhSKaxTEqojwtlXxPkTiQ unityInputBuffer => TYpWQJrIXPKLBpKYDjrOnproFHN ?? (TYpWQJrIXPKLBpKYDjrOnproFHN = new dxdVHUQhSKaxTEqojwtlXxPkTiQ(zeOdvKvLepaDssBfYXvcNnfTGHoC.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					ascpxOPqZQABvGgKQMJhnFonvlX();
					return null;
				}
				return taXwJZxAXteMsBkTbirAkbwVqTz;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					ascpxOPqZQABvGgKQMJhnFonvlX();
					return null;
				}
				return fwOhMezaqAlQEcPOQhEvpMRTJuZ;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					ascpxOPqZQABvGgKQMJhnFonvlX();
					return null;
				}
				return BEKpREJARyzPnScVzVTzDkjHvTF;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					ascpxOPqZQABvGgKQMJhnFonvlX();
					return null;
				}
				return VvcDSlhFAMPDdTqaSqwhbydZYbA;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					ascpxOPqZQABvGgKQMJhnFonvlX();
					return null;
				}
				return XZSsOYkkhitBnZcszsPGUEnbpbH;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					ascpxOPqZQABvGgKQMJhnFonvlX();
					return null;
				}
				return cNIwUCqOcbVUPawPCiVyYBlREkaj;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					ascpxOPqZQABvGgKQMJhnFonvlX();
					return null;
				}
				return IBSTvRgaVrWTyzrOFbAkkPeqBlbI;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 40 + "." + 0 + ".U2020";

		public static bool usingUnityInput => XjZjvbdFPtQBjmMQgUSNicoRCos;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
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

		public static bool isReady => XrAXpRFFCZWxSkTUXpVlgetwinP;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => XrAXpRFFCZWxSkTUXpVlgetwinP;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => aFzbHLXYPqOlDTBvxsrImZkLaRs;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => zeOdvKvLepaDssBfYXvcNnfTGHoC;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => zeOdvKvLepaDssBfYXvcNnfTGHoC;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => LWLODUkCwfcNvCWHWwdHlYbcikq;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => NBExHKACOtceRjeveueAfrwdqkMW;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => nMieJgQejclQhhHENtuZGMmIdmi;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => HvUsjbcKcvfjVDepXAAIQHsgOww;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (NBExHKACOtceRjeveueAfrwdqkMW == Platform.Linux && XjZjvbdFPtQBjmMQgUSNicoRCos)
				{
					return true;
				}
				if (NBExHKACOtceRjeveueAfrwdqkMW == Platform.OSX && (XjZjvbdFPtQBjmMQgUSNicoRCos || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && XjZjvbdFPtQBjmMQgUSNicoRCos)
				{
					return true;
				}
				if (NBExHKACOtceRjeveueAfrwdqkMW == Platform.Webplayer && nMieJgQejclQhhHENtuZGMmIdmi == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (NBExHKACOtceRjeveueAfrwdqkMW == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => HvUsjbcKcvfjVDepXAAIQHsgOww != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					return Guid.Empty;
				}
				return YSEzHOqqVaKlvooxZDulFVVLiRTj.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => vQJFdlnOvzdcghIhxuyhpwuBafc;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => pXuAagCXTuKWizWLfjxfVKYqdgX.unityUnscaledDeltaTime;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => pXuAagCXTuKWizWLfjxfVKYqdgX.unityUnscaledDeltaTimePrev;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					return 0.0;
				}
				return pXuAagCXTuKWizWLfjxfVKYqdgX.realTime;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					return 0;
				}
				return bhIzyHLfWoyXWELgSlrJYhqmUHY.currentFrame;
			}
		}

		private static bool isEditorGameViewFocused
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return DStXnsJPDYBkOaDCOpcdNDUCVpG == "Game";
				}
				return DStXnsJPDYBkOaDCOpcdNDUCVpG == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (zeOdvKvLepaDssBfYXvcNnfTGHoC.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!JANEGdNmkfnchLMzOdWbzhwMsbi)
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
				if (fjIUsQKflnkYVKJEJIlJoJufbQP is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return JANEGdNmkfnchLMzOdWbzhwMsbi;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					return false;
				}
				if (!XjZjvbdFPtQBjmMQgUSNicoRCos)
				{
					return false;
				}
				if (NBExHKACOtceRjeveueAfrwdqkMW != Platform.Windows && (NBExHKACOtceRjeveueAfrwdqkMW != Platform.Webplayer || nMieJgQejclQhhHENtuZGMmIdmi != WebplayerPlatform.Windows))
				{
					return HvUsjbcKcvfjVDepXAAIQHsgOww == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool inputAllowed
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					return false;
				}
				if (!bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.value)
				{
					if (qVYgDleOAcZYuNBYKhOVnajcORpT)
					{
						return false;
					}
					if (!isEditor && !bhIzyHLfWoyXWELgSlrJYhqmUHY.GCnzhsbfQXpZcCgKcbeYShaQMgK.value)
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
				if (XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					return bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					return bhIzyHLfWoyXWELgSlrJYhqmUHY.vqHFvdRWtggwOLVtjpoFnfUGpQt.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					return bhIzyHLfWoyXWELgSlrJYhqmUHY.GCnzhsbfQXpZcCgKcbeYShaQMgK.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					return bhIzyHLfWoyXWELgSlrJYhqmUHY.BebCphBuGyXVHMobopQJvnVkoRuT.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => ceSrziAFVHlZSgalWFBehsjWmKTA;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
				{
					ascpxOPqZQABvGgKQMJhnFonvlX();
					return null;
				}
				return fjIUsQKflnkYVKJEJIlJoJufbQP.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return ryPehyHpeIXjvNfdmrovYfpIImhh;
			}
			set
			{
				ryPehyHpeIXjvNfdmrovYfpIImhh = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => xKafMYTkZexvDqVBmfswMzqGqSe;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				DwjGQaJjOeKzELLYwYKnxItCJOM += value;
			}
			remove
			{
				DwjGQaJjOeKzELLYwYKnxItCJOM -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				iYtaZKJWbBhuafhohwyeCWyphei += value;
			}
			remove
			{
				iYtaZKJWbBhuafhohwyeCWyphei -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				scoRCaiNNHKrBvMueNRLVIlEgSu += value;
			}
			remove
			{
				scoRCaiNNHKrBvMueNRLVIlEgSu -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				uapjRCHVYLXRJmHVSxlSgZLoTDyw += value;
			}
			remove
			{
				uapjRCHVYLXRJmHVSxlSgZLoTDyw -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				qUbiBHgIBetcCXoWCNADunPwCzcE += value;
			}
			remove
			{
				qUbiBHgIBetcCXoWCNADunPwCzcE -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				clyEamldAbFPcbnaTgDvOceCdMX += value;
			}
			remove
			{
				clyEamldAbFPcbnaTgDvOceCdMX -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				geXnHaLAAGSuNCtsphijUOmpkxu += value;
			}
			remove
			{
				geXnHaLAAGSuNCtsphijUOmpkxu -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				KvpNnnojMosgISmEtarGaEoUeaDi += value;
			}
			remove
			{
				KvpNnnojMosgISmEtarGaEoUeaDi -= value;
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
				rbmELGhAKXHnZYZdUwvzRbnqMQk = (Action)Delegate.Combine(rbmELGhAKXHnZYZdUwvzRbnqMQk, value);
			}
			remove
			{
				rbmELGhAKXHnZYZdUwvzRbnqMQk = (Action)Delegate.Remove(rbmELGhAKXHnZYZdUwvzRbnqMQk, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				cnvrxNioVvBjmgZYoHXfqBGpSBt = (Action<UpdateLoopType>)Delegate.Combine(cnvrxNioVvBjmgZYoHXfqBGpSBt, value);
			}
			remove
			{
				cnvrxNioVvBjmgZYoHXfqBGpSBt = (Action<UpdateLoopType>)Delegate.Remove(cnvrxNioVvBjmgZYoHXfqBGpSBt, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				kYlWmpVmhiIyrhzvCdhiRzrIPmG = (Action<UpdateLoopType>)Delegate.Combine(kYlWmpVmhiIyrhzvCdhiRzrIPmG, value);
			}
			remove
			{
				kYlWmpVmhiIyrhzvCdhiRzrIPmG = (Action<UpdateLoopType>)Delegate.Remove(kYlWmpVmhiIyrhzvCdhiRzrIPmG, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				sLhzeeMaJGmpyHSEywBIJUhWfma = (Action<UpdateLoopType>)Delegate.Combine(sLhzeeMaJGmpyHSEywBIJUhWfma, value);
			}
			remove
			{
				sLhzeeMaJGmpyHSEywBIJUhWfma = (Action<UpdateLoopType>)Delegate.Remove(sLhzeeMaJGmpyHSEywBIJUhWfma, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				YXVbcRhPNFQzcqNjtaIOqylNhRU = (Action)Delegate.Combine(YXVbcRhPNFQzcqNjtaIOqylNhRU, value);
			}
			remove
			{
				YXVbcRhPNFQzcqNjtaIOqylNhRU = (Action)Delegate.Remove(YXVbcRhPNFQzcqNjtaIOqylNhRU, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				NMAGmUgKaqqchVSkPbVpqujljfGU = (Action<bool>)Delegate.Combine(NMAGmUgKaqqchVSkPbVpqujljfGU, value);
			}
			remove
			{
				NMAGmUgKaqqchVSkPbVpqujljfGU = (Action<bool>)Delegate.Remove(NMAGmUgKaqqchVSkPbVpqujljfGU, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				gjqJApsmjvHfHsaZwlpFSoCTqUD = (Action<bool>)Delegate.Combine(gjqJApsmjvHfHsaZwlpFSoCTqUD, value);
			}
			remove
			{
				gjqJApsmjvHfHsaZwlpFSoCTqUD = (Action<bool>)Delegate.Remove(gjqJApsmjvHfHsaZwlpFSoCTqUD, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				zEucRCdGgVQpGwEnIJLwoikDCrLM = (Action<bool>)Delegate.Combine(zEucRCdGgVQpGwEnIJLwoikDCrLM, value);
			}
			remove
			{
				zEucRCdGgVQpGwEnIJLwoikDCrLM = (Action<bool>)Delegate.Remove(zEucRCdGgVQpGwEnIJLwoikDCrLM, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				hbsXhQvyCrPFPzzLgeNApumilJr = (Action<FullScreenMode>)Delegate.Combine(hbsXhQvyCrPFPzzLgeNApumilJr, value);
			}
			remove
			{
				hbsXhQvyCrPFPzzLgeNApumilJr = (Action<FullScreenMode>)Delegate.Remove(hbsXhQvyCrPFPzzLgeNApumilJr, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				NqiZOWvirKVFPjtaZpsUkikBFoQ = (Action)Delegate.Combine(NqiZOWvirKVFPjtaZpsUkikBFoQ, value);
			}
			remove
			{
				NqiZOWvirKVFPjtaZpsUkikBFoQ = (Action)Delegate.Remove(NqiZOWvirKVFPjtaZpsUkikBFoQ, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				qLQgENvTyBMEpNcbJbmUHiqPSff = (Action<bool>)Delegate.Combine(qLQgENvTyBMEpNcbJbmUHiqPSff, value);
			}
			remove
			{
				qLQgENvTyBMEpNcbJbmUHiqPSff = (Action<bool>)Delegate.Remove(qLQgENvTyBMEpNcbJbmUHiqPSff, value);
			}
		}

		static ReInput()
		{
			JANEGdNmkfnchLMzOdWbzhwMsbi = true;
			nOqtNxCcNhoSXgsBttvcrmEcFSE = -1;
			_id = -1;
			LeqsTlLDjeOPDUuyfgRRZGsvPKt = 0;
			VvcDSlhFAMPDdTqaSqwhbydZYbA = UnityTouch.Instance;
			taXwJZxAXteMsBkTbirAkbwVqTz = PlayerHelper.Instance;
			fwOhMezaqAlQEcPOQhEvpMRTJuZ = ControllerHelper.Instance;
			BEKpREJARyzPnScVzVTzDkjHvTF = MappingHelper.Instance;
			XZSsOYkkhitBnZcszsPGUEnbpbH = TimeHelper.Instance;
			IBSTvRgaVrWTyzrOFbAkkPeqBlbI = ConfigHelper.Instance;
			DwjGQaJjOeKzELLYwYKnxItCJOM = new SafeAction<ControllerStatusChangedEventArgs>(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			});
			iYtaZKJWbBhuafhohwyeCWyphei = new SafeAction<ControllerStatusChangedEventArgs>(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			});
			scoRCaiNNHKrBvMueNRLVIlEgSu = new SafeAction<ControllerStatusChangedEventArgs>(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			});
			uapjRCHVYLXRJmHVSxlSgZLoTDyw = new SafeAction(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			});
			qUbiBHgIBetcCXoWCNADunPwCzcE = new SafeAction(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			});
			clyEamldAbFPcbnaTgDvOceCdMX = new SafeAction(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			});
			geXnHaLAAGSuNCtsphijUOmpkxu = new SafeAction(delegate(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			});
			KvpNnnojMosgISmEtarGaEoUeaDi = new SafeAction(delegate(Exception P_0)
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
			if (XrAXpRFFCZWxSkTUXpVlgetwinP && !(ceSrziAFVHlZSgalWFBehsjWmKTA == null))
			{
				ceSrziAFVHlZSgalWFBehsjWmKTA.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!inputAllowed)
			{
				return false;
			}
			if (HvUsjbcKcvfjVDepXAAIQHsgOww != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (qVYgDleOAcZYuNBYKhOVnajcORpT)
				{
					if (!bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.value)
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

		internal static void EJpmrTgGvrhKjJnkpXbomYBpQTQ(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4)
		{
			try
			{
				_id = LeqsTlLDjeOPDUuyfgRRZGsvPKt;
				LeqsTlLDjeOPDUuyfgRRZGsvPKt++;
				XrAXpRFFCZWxSkTUXpVlgetwinP = true;
				QyVMBkucmxpRoztSqHXCzXWZMWE = true;
				vQJFdlnOvzdcghIhxuyhpwuBafc = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				ceSrziAFVHlZSgalWFBehsjWmKTA = P_0;
				zeOdvKvLepaDssBfYXvcNnfTGHoC = P_2;
				NBExHKACOtceRjeveueAfrwdqkMW = UnityTools.platform;
				nMieJgQejclQhhHENtuZGMmIdmi = UnityTools.webplayerPlatform;
				HvUsjbcKcvfjVDepXAAIQHsgOww = UnityTools.editorPlatform;
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += XQXsGVqzhnHkYcjjpBOGbydmaGd;
				YSEzHOqqVaKlvooxZDulFVVLiRTj = P_3;
				LWLODUkCwfcNvCWHWwdHlYbcikq = P_4;
				P_4.EJpmrTgGvrhKjJnkpXbomYBpQTQ();
				ThreadSafeUnityInput.Initialize();
				bhIzyHLfWoyXWELgSlrJYhqmUHY = new zrlYfeOvbUgAvePOGvJoyndkLTn();
				bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.Set(JANEGdNmkfnchLMzOdWbzhwMsbi);
				bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.Use();
				if (HvUsjbcKcvfjVDepXAAIQHsgOww != EditorPlatform.None)
				{
					bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.getValueDelegate = () => isUnityEditorFocused && isAllowedEditorWindowFocused;
					if (vQJFdlnOvzdcghIhxuyhpwuBafc)
					{
						JANEGdNmkfnchLMzOdWbzhwMsbi = isEditorGameViewFocused;
					}
					bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				wUOKBPkNlVEKwIKiYQJjTHvFGsCb();
				qPuFJukrKCcGvZtLpLLHcFEeTPt = new TimerAbs(1.0);
				pXuAagCXTuKWizWLfjxfVKYqdgX = new AnoDDYCXDUkEdKtwdcUYyHjbaDHT();
				jnZFYyguooyHwecthNbcgpTJotAf(P_1);
				bmLEnbkKNrTNSFrbOCrmcDPSGZKL = new SlfkunxWuMcSymhpycotdVbpUpl(P_4.GetActions_Copy());
				aPNcjJCKQolbdJEKHuJkfRPTMco = new ChYhaBSijJnTpdXwQSqYJssvGND(P_2, fjIUsQKflnkYVKJEJIlJoJufbQP);
				USfldASbLlPourbEtKfoowSEGgo = new kfVJCyCDaGCuiDEEEMtqgVXykXX(P_2);
				fjIUsQKflnkYVKJEJIlJoJufbQP.DeviceConnectedEvent += ZSTzWeUbvBqMooHwSNDkPtFHcdI;
				fjIUsQKflnkYVKJEJIlJoJufbQP.DeviceDisconnectedEvent += uLUTPNJvSHqVOKEbQhBrzpwsIBJ;
				fjIUsQKflnkYVKJEJIlJoJufbQP.UpdateControllerInfoEvent += anHVdnFpTOCtxfAzjgxHvCpBCGqf;
				aPNcjJCKQolbdJEKHuJkfRPTMco.ControllerDisconnectStartedEvent += TqLuaCxSJQzjXEWxHEyVezvTWdB;
				aPNcjJCKQolbdJEKHuJkfRPTMco.JustBeforeControllerFullyDisconnectedEvent += USfldASbLlPourbEtKfoowSEGgo.VtoLUmzBFNaRsYtVcArJETKFsZA;
				ThreadSafeUnityInput.PostInitialize();
				UkxfEqbxDrRekSeafhKXPemRTbXJ();
				ThreadSafeUnityInput.PostInitialize2();
				cNIwUCqOcbVUPawPCiVyYBlREkaj = UnityTools.GetComponent<UserDataStore>(ceSrziAFVHlZSgalWFBehsjWmKTA);
				if (cNIwUCqOcbVUPawPCiVyYBlREkaj != null)
				{
					cNIwUCqOcbVUPawPCiVyYBlREkaj.Initialize();
				}
				JdrOBRVCYfffukYUSlVUhpxNzTX();
				QyVMBkucmxpRoztSqHXCzXWZMWE = false;
				if (vQJFdlnOvzdcghIhxuyhpwuBafc)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (KvpNnnojMosgISmEtarGaEoUeaDi != null)
				{
					KvpNnnojMosgISmEtarGaEoUeaDi.Invoke();
				}
			}
			catch (Exception)
			{
				XrAXpRFFCZWxSkTUXpVlgetwinP = false;
				QyVMBkucmxpRoztSqHXCzXWZMWE = false;
				throw;
			}
		}

		internal static void PUfBGkQEoKKPRrTrZNGGdNNSToS()
		{
			if (pXuAagCXTuKWizWLfjxfVKYqdgX != null)
			{
				pXuAagCXTuKWizWLfjxfVKYqdgX.IJRSFtjbDxmmlTBOqQcAzaqrQpb();
			}
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < aPNcjJCKQolbdJEKHuJkfRPTMco.joystickCount; i++)
				{
					Joystick joystick = aPNcjJCKQolbdJEKHuJkfRPTMco.Joysticks_readOnly[i];
					sLVDObjLjeslxzzejdYWdQbWlsJ(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		internal static void sXOEyENaQpysOtzkdOTtrqodKbs(UpdateLoopType P_0)
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				QfjmixGpSaKiLjzPFxlalkVsFqS(P_0);
				switch (P_0)
				{
				case UpdateLoopType.Update:
				case UpdateLoopType.FixedUpdate:
					ayhiUiyPgshDojPkhkgoncpdnOu();
					break;
				}
			}
		}

		private static void QfjmixGpSaKiLjzPFxlalkVsFqS(UpdateLoopType P_0)
		{
			if (bhIzyHLfWoyXWELgSlrJYhqmUHY != null)
			{
				bhIzyHLfWoyXWELgSlrJYhqmUHY.QTPiZFmnRsxmyQYmMuIoBQkOtfg();
			}
			Action<UpdateLoopType> action = cnvrxNioVvBjmgZYoHXfqBGpSBt;
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
			pXuAagCXTuKWizWLfjxfVKYqdgX.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_0);
		}

		private static void ayhiUiyPgshDojPkhkgoncpdnOu()
		{
			int frameCount = Time.frameCount;
			if (nOqtNxCcNhoSXgsBttvcrmEcFSE == frameCount)
			{
				return;
			}
			nOqtNxCcNhoSXgsBttvcrmEcFSE = frameCount;
			ThreadSafeUnityInput.Update();
			Action action = rbmELGhAKXHnZYZdUwvzRbnqMQk;
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

		internal static void QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType P_0)
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return;
			}
			if (aFzbHLXYPqOlDTBvxsrImZkLaRs != P_0)
			{
				aFzbHLXYPqOlDTBvxsrImZkLaRs = P_0;
			}
			if (editorPlatform != EditorPlatform.None)
			{
				DStXnsJPDYBkOaDCOpcdNDUCVpG = bhIzyHLfWoyXWELgSlrJYhqmUHY.nvXvMiOlDmAWgjcnyYTbztyVuzH.value;
			}
			if (HKZvDBrDsCgGajtCNzALINscVkrg)
			{
				if (qPuFJukrKCcGvZtLpLLHcFEeTPt.Update())
				{
					HKZvDBrDsCgGajtCNzALINscVkrg = false;
					qPuFJukrKCcGvZtLpLLHcFEeTPt.Clear();
				}
				else
				{
					unityInputBuffer.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_0);
				}
			}
			bhIzyHLfWoyXWELgSlrJYhqmUHY.PvDFaluYFJJxMtMtZaTCVYLFpGq();
			Action<UpdateLoopType> action = kYlWmpVmhiIyrhzvCdhiRzrIPmG;
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
			fjIUsQKflnkYVKJEJIlJoJufbQP.Update(P_0);
			if (uapjRCHVYLXRJmHVSxlSgZLoTDyw != null)
			{
				uapjRCHVYLXRJmHVSxlSgZLoTDyw.Invoke();
			}
			aPNcjJCKQolbdJEKHuJkfRPTMco.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_0);
			Action<UpdateLoopType> action2 = sLhzeeMaJGmpyHSEywBIJUhWfma;
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

		internal static void GOTiAehRqEQcxuoCakrqQgWdDNS()
		{
			Action yXVbcRhPNFQzcqNjtaIOqylNhRU = YXVbcRhPNFQzcqNjtaIOqylNhRU;
			if (yXVbcRhPNFQzcqNjtaIOqylNhRU != null)
			{
				try
				{
					yXVbcRhPNFQzcqNjtaIOqylNhRU();
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
			if (XrAXpRFFCZWxSkTUXpVlgetwinP && vQJFdlnOvzdcghIhxuyhpwuBafc)
			{
				sXOEyENaQpysOtzkdOTtrqodKbs(UpdateLoopType.Update);
				QTPiZFmnRsxmyQYmMuIoBQkOtfg(UpdateLoopType.Update);
				GOTiAehRqEQcxuoCakrqQgWdDNS();
			}
		}

		internal static void abrusMNmoPOkJcTYBXpUgMeQbqH()
		{
			if (clyEamldAbFPcbnaTgDvOceCdMX != null)
			{
				clyEamldAbFPcbnaTgDvOceCdMX.Invoke();
			}
			if (fjIUsQKflnkYVKJEJIlJoJufbQP != null)
			{
				fjIUsQKflnkYVKJEJIlJoJufbQP.OnDestroy();
			}
			fLPaVrTLMUdouRlrpeYVEadmvY();
			if (geXnHaLAAGSuNCtsphijUOmpkxu != null)
			{
				geXnHaLAAGSuNCtsphijUOmpkxu.Invoke();
				geXnHaLAAGSuNCtsphijUOmpkxu = null;
			}
		}

		internal static void MahycecEhxFKucGZMGavXVWyPta()
		{
			if (qUbiBHgIBetcCXoWCNADunPwCzcE != null)
			{
				qUbiBHgIBetcCXoWCNADunPwCzcE.Invoke();
			}
		}

		internal static void IeShcUVzptWqhZMoWlGsVtKVtAL(bool P_0)
		{
			JANEGdNmkfnchLMzOdWbzhwMsbi = P_0;
			if (HvUsjbcKcvfjVDepXAAIQHsgOww == EditorPlatform.None && XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.Set(P_0);
				bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.TriggerEvent();
			}
		}

		internal static void UnVOZrzcgqIQhnDYGcMYPsUSMjU()
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return;
			}
			Action nqiZOWvirKVFPjtaZpsUkikBFoQ = NqiZOWvirKVFPjtaZpsUkikBFoQ;
			if (nqiZOWvirKVFPjtaZpsUkikBFoQ == null)
			{
				return;
			}
			try
			{
				nqiZOWvirKVFPjtaZpsUkikBFoQ();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.SceneLoadedEvent", exception);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return YSEzHOqqVaKlvooxZDulFVVLiRTj.xMQTcyGiClhHYUNTtvqDTvtysfy(bridgedController);
		}

		internal static HardwareJoystickMap QaLWEoBkhPPZHwFxXAQmGTvzudU(Guid P_0)
		{
			return YSEzHOqqVaKlvooxZDulFVVLiRTj.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap WXZzghlyGEKLVUqxSWMufmDMvxn(Guid P_0)
		{
			return YSEzHOqqVaKlvooxZDulFVVLiRTj.GetJoystickTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap fWGfBfBXPLMbawKaxcSHyXYhVq(Guid P_0)
		{
			return YSEzHOqqVaKlvooxZDulFVVLiRTj.GetControllerTemplate(P_0);
		}

		internal static IList<HardwareJoystickTemplateMap> sQzbEhzfZYwQlNlpwwtVmsyxCQA(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = YSEzHOqqVaKlvooxZDulFVVLiRTj.GetHardwareJoystickMap(P_0);
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
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = WXZzghlyGEKLVUqxSWMufmDMvxn(guid);
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
			return aPNcjJCKQolbdJEKHuJkfRPTMco.OdgeliGexstdTqqKtmEBqLlngeAN();
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

		internal static void NrufBlObSwJruLvdrVSCCrHWiNSH()
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				JdrOBRVCYfffukYUSlVUhpxNzTX();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2020 != UnityTools.unityVersionObj.major)
			{
				AYPhOIfhQBhXeFpDXPYcwZUSyWCT();
			}
		}

		internal static float iXgPCkfWgLtHnELFVjdXDAUoqWu()
		{
			return bhIzyHLfWoyXWELgSlrJYhqmUHY.RRIOjlceVUgBefornfxmXjrZPqA.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
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

		private static void UkxfEqbxDrRekSeafhKXPemRTbXJ()
		{
			USfldASbLlPourbEtKfoowSEGgo.EJpmrTgGvrhKjJnkpXbomYBpQTQ();
			aPNcjJCKQolbdJEKHuJkfRPTMco.EJpmrTgGvrhKjJnkpXbomYBpQTQ(fjIUsQKflnkYVKJEJIlJoJufbQP.GetInputDataUpdateDelegate(), LWLODUkCwfcNvCWHWwdHlYbcikq.GetInputBehaviors_Copy());
			fjIUsQKflnkYVKJEJIlJoJufbQP.Initialize();
		}

		private static void fLPaVrTLMUdouRlrpeYVEadmvY()
		{
			if (ceSrziAFVHlZSgalWFBehsjWmKTA != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(ceSrziAFVHlZSgalWFBehsjWmKTA);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			ceSrziAFVHlZSgalWFBehsjWmKTA = null;
			fjIUsQKflnkYVKJEJIlJoJufbQP = null;
			bmLEnbkKNrTNSFrbOCrmcDPSGZKL = null;
			if (aPNcjJCKQolbdJEKHuJkfRPTMco != null)
			{
				aPNcjJCKQolbdJEKHuJkfRPTMco.Dispose();
			}
			aPNcjJCKQolbdJEKHuJkfRPTMco = null;
			USfldASbLlPourbEtKfoowSEGgo = null;
			YSEzHOqqVaKlvooxZDulFVVLiRTj = null;
			LWLODUkCwfcNvCWHWwdHlYbcikq = null;
			ryPehyHpeIXjvNfdmrovYfpIImhh = null;
			XrAXpRFFCZWxSkTUXpVlgetwinP = false;
			zeOdvKvLepaDssBfYXvcNnfTGHoC = null;
			aFzbHLXYPqOlDTBvxsrImZkLaRs = UpdateLoopType.Update;
			XjZjvbdFPtQBjmMQgUSNicoRCos = false;
			NBExHKACOtceRjeveueAfrwdqkMW = Platform.Windows;
			nMieJgQejclQhhHENtuZGMmIdmi = WebplayerPlatform.None;
			HvUsjbcKcvfjVDepXAAIQHsgOww = EditorPlatform.None;
			HKZvDBrDsCgGajtCNzALINscVkrg = false;
			qPuFJukrKCcGvZtLpLLHcFEeTPt = null;
			pXuAagCXTuKWizWLfjxfVKYqdgX = null;
			DStXnsJPDYBkOaDCOpcdNDUCVpG = null;
			qVYgDleOAcZYuNBYKhOVnajcORpT = false;
			vQJFdlnOvzdcghIhxuyhpwuBafc = false;
			JANEGdNmkfnchLMzOdWbzhwMsbi = true;
			nOqtNxCcNhoSXgsBttvcrmEcFSE = -1;
			_id = -1;
			xKafMYTkZexvDqVBmfswMzqGqSe = 0;
			DwjGQaJjOeKzELLYwYKnxItCJOM.Clear();
			iYtaZKJWbBhuafhohwyeCWyphei.Clear();
			scoRCaiNNHKrBvMueNRLVIlEgSu.Clear();
			uapjRCHVYLXRJmHVSxlSgZLoTDyw.Clear();
			qUbiBHgIBetcCXoWCNADunPwCzcE.Clear();
			_ApplicationFocusChangedEvent = null;
			NMAGmUgKaqqchVSkPbVpqujljfGU = null;
			gjqJApsmjvHfHsaZwlpFSoCTqUD = null;
			hbsXhQvyCrPFPzzLgeNApumilJr = null;
			zEucRCdGgVQpGwEnIJLwoikDCrLM = null;
			rbmELGhAKXHnZYZdUwvzRbnqMQk = null;
			kYlWmpVmhiIyrhzvCdhiRzrIPmG = null;
			sLhzeeMaJGmpyHSEywBIJUhWfma = null;
			YXVbcRhPNFQzcqNjtaIOqylNhRU = null;
			clyEamldAbFPcbnaTgDvOceCdMX = null;
			NqiZOWvirKVFPjtaZpsUkikBFoQ = null;
			qLQgENvTyBMEpNcbJbmUHiqPSff = null;
			zkAcHjBUWTMLSBQBAWMzjlBlOXSB();
			bhIzyHLfWoyXWELgSlrJYhqmUHY = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= XQXsGVqzhnHkYcjjpBOGbydmaGd;
			}
		}

		private static void zONFgEOoczSCLGBhUEUsiioFTAn(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void KDWPXJUwBfUFZCUizeOGzDRavGt()
		{
			if (!HKZvDBrDsCgGajtCNzALINscVkrg)
			{
				HKZvDBrDsCgGajtCNzALINscVkrg = true;
				unityInputBuffer.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				unityInputBuffer.BQWVwztidFDoKSonWGAEASTWFMHb();
			}
			qPuFJukrKCcGvZtLpLLHcFEeTPt.Start();
		}

		private static void ascpxOPqZQABvGgKQMJhnFonvlX()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void ZSTzWeUbvBqMooHwSNDkPtFHcdI(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			aPNcjJCKQolbdJEKHuJkfRPTMco.OcJiFTfYhVOxbPWzpBkiqlUfCqj(P_0);
			Joystick joystick = aPNcjJCKQolbdJEKHuJkfRPTMco.DjEdqahmwjneIiOCxudqBnmlLdFW(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				USfldASbLlPourbEtKfoowSEGgo.WYzHcCWbflFQfqeneHHCgklpstlG(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !QyVMBkucmxpRoztSqHXCzXWZMWE)
				{
					sLVDObjLjeslxzzejdYWdQbWlsJ(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void uLUTPNJvSHqVOKEbQhBrzpwsIBJ(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = aPNcjJCKQolbdJEKHuJkfRPTMco.DjEdqahmwjneIiOCxudqBnmlLdFW(P_0.rewiredId);
				if (joystick != null)
				{
					aPNcjJCKQolbdJEKHuJkfRPTMco.aJmAFIJYAhoNsonZPnVCEQKSIgF(P_0.rewiredId);
					GQyHFbLYYPalPXVaGnFDfPucbOh(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void sLVDObjLjeslxzzejdYWdQbWlsJ(ControllerStatusChangedEventArgs P_0)
		{
			if (DwjGQaJjOeKzELLYwYKnxItCJOM != null)
			{
				DwjGQaJjOeKzELLYwYKnxItCJOM.Invoke(P_0);
			}
		}

		private static void TqLuaCxSJQzjXEWxHEyVezvTWdB(ControllerStatusChangedEventArgs P_0)
		{
			if (iYtaZKJWbBhuafhohwyeCWyphei != null)
			{
				iYtaZKJWbBhuafhohwyeCWyphei.Invoke(P_0);
			}
		}

		private static void GQyHFbLYYPalPXVaGnFDfPucbOh(ControllerStatusChangedEventArgs P_0)
		{
			if (scoRCaiNNHKrBvMueNRLVIlEgSu != null)
			{
				scoRCaiNNHKrBvMueNRLVIlEgSu.Invoke(P_0);
			}
		}

		private static void anHVdnFpTOCtxfAzjgxHvCpBCGqf(UpdateControllerInfoEventArgs P_0)
		{
			aPNcjJCKQolbdJEKHuJkfRPTMco.CwUUJciFYlAaprEDiknrgmfmGne(P_0);
		}

		private static void WYmLDaFUlNQSFcnYqPRibopaGWP(bool P_0)
		{
			if (!XrAXpRFFCZWxSkTUXpVlgetwinP)
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

		private static void ThEhBjJPsRQVwLjaggokiSaLTSYq(bool P_0)
		{
			Action<bool> nMAGmUgKaqqchVSkPbVpqujljfGU = NMAGmUgKaqqchVSkPbVpqujljfGU;
			if (nMAGmUgKaqqchVSkPbVpqujljfGU != null)
			{
				try
				{
					nMAGmUgKaqqchVSkPbVpqujljfGU(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void XdmFAoqDxziHAvUTSNjBVwAQBZR(int P_0)
		{
			if (hbsXhQvyCrPFPzzLgeNApumilJr != null)
			{
				try
				{
					hbsXhQvyCrPFPzzLgeNApumilJr((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void VHTLRLeyXfRsHvEyLjWhmrDUMPx(bool P_0)
		{
			Action<bool> action = gjqJApsmjvHfHsaZwlpFSoCTqUD;
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

		private static void fnIgRQxaszbVtSsHMaMrmBmIrEY(bool P_0)
		{
			xKafMYTkZexvDqVBmfswMzqGqSe++;
			Action<bool> action = zEucRCdGgVQpGwEnIJLwoikDCrLM;
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

		private static void wUOKBPkNlVEKwIKiYQJjTHvFGsCb()
		{
			if (bhIzyHLfWoyXWELgSlrJYhqmUHY != null)
			{
				zkAcHjBUWTMLSBQBAWMzjlBlOXSB();
				bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.ChangedEvent += WYmLDaFUlNQSFcnYqPRibopaGWP;
				bhIzyHLfWoyXWELgSlrJYhqmUHY.vqHFvdRWtggwOLVtjpoFnfUGpQt.ChangedEvent += ThEhBjJPsRQVwLjaggokiSaLTSYq;
				bhIzyHLfWoyXWELgSlrJYhqmUHY.GCnzhsbfQXpZcCgKcbeYShaQMgK.ChangedEvent += VHTLRLeyXfRsHvEyLjWhmrDUMPx;
				bhIzyHLfWoyXWELgSlrJYhqmUHY.QCNMecIGSpddsmfDqqrXmjMEQmC.ChangedEvent += XdmFAoqDxziHAvUTSNjBVwAQBZR;
				bhIzyHLfWoyXWELgSlrJYhqmUHY.BebCphBuGyXVHMobopQJvnVkoRuT.ChangedEvent += fnIgRQxaszbVtSsHMaMrmBmIrEY;
			}
		}

		private static void zkAcHjBUWTMLSBQBAWMzjlBlOXSB()
		{
			if (bhIzyHLfWoyXWELgSlrJYhqmUHY != null)
			{
				bhIzyHLfWoyXWELgSlrJYhqmUHY.dcjIWomhskoMuPNntGwCMofGPLB.ChangedEvent -= WYmLDaFUlNQSFcnYqPRibopaGWP;
				bhIzyHLfWoyXWELgSlrJYhqmUHY.vqHFvdRWtggwOLVtjpoFnfUGpQt.ChangedEvent -= ThEhBjJPsRQVwLjaggokiSaLTSYq;
				bhIzyHLfWoyXWELgSlrJYhqmUHY.GCnzhsbfQXpZcCgKcbeYShaQMgK.ChangedEvent -= VHTLRLeyXfRsHvEyLjWhmrDUMPx;
				bhIzyHLfWoyXWELgSlrJYhqmUHY.QCNMecIGSpddsmfDqqrXmjMEQmC.ChangedEvent -= XdmFAoqDxziHAvUTSNjBVwAQBZR;
				bhIzyHLfWoyXWELgSlrJYhqmUHY.BebCphBuGyXVHMobopQJvnVkoRuT.ChangedEvent -= fnIgRQxaszbVtSsHMaMrmBmIrEY;
			}
		}

		private static void XQXsGVqzhnHkYcjjpBOGbydmaGd(bool P_0)
		{
			Action<bool> action = qLQgENvTyBMEpNcbJbmUHiqPSff;
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

		private static void jnZFYyguooyHwecthNbcgpTJotAf(Func<ConfigVars, object> P_0)
		{
			bool flag = configVars.DoesPlatformUseFallback(UnityTools.platform, UnityTools.webplayerPlatform, isEditor);
			if (!flag)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(ceSrziAFVHlZSgalWFBehsjWmKTA);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(UnityTools.platform, zeOdvKvLepaDssBfYXvcNnfTGHoC) is PlatformInputManager platformInputManager)
					{
						fjIUsQKflnkYVKJEJIlJoJufbQP = platformInputManager;
						return;
					}
				}
			}
			if (flag)
			{
				XjZjvbdFPtQBjmMQgUSNicoRCos = true;
				fjIUsQKflnkYVKJEJIlJoJufbQP = new qhEHTWwzpdfUANmcCHXUDkkVGxvn(zeOdvKvLepaDssBfYXvcNnfTGHoC.updateLoop);
			}
			else if (configVars.DoesPlatformUseSDL2(UnityTools.platform, UnityTools.webplayerPlatform, isEditor))
			{
				try
				{
					fjIUsQKflnkYVKJEJIlJoJufbQP = new JgtdwCPZBEmqSQnaWXtOJKpKzuR(zeOdvKvLepaDssBfYXvcNnfTGHoC, GetHardwareJoystickMap_InputManager, GetNewJoystickId, handleJoysticks: true, handleUnifiedMouse: false, handleUnifiedKeyboard: false);
					if (fjIUsQKflnkYVKJEJIlJoJufbQP == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
					fjIUsQKflnkYVKJEJIlJoJufbQP = null;
				}
			}
			else if (UnityTools.platform == Platform.Windows || UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.WindowsUWP || UnityTools.platform == Platform.OSX || UnityTools.platform == Platform.Linux)
			{
				fjIUsQKflnkYVKJEJIlJoJufbQP = P_0(zeOdvKvLepaDssBfYXvcNnfTGHoC) as PlatformInputManager;
			}
			else if (UnityTools.platform == Platform.WebGL && !isEditor)
			{
				try
				{
					fjIUsQKflnkYVKJEJIlJoJufbQP = P_0(zeOdvKvLepaDssBfYXvcNnfTGHoC) as PlatformInputManager;
					if (fjIUsQKflnkYVKJEJIlJoJufbQP == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					fjIUsQKflnkYVKJEJIlJoJufbQP = null;
				}
			}
			else if (UnityTools.platform == Platform.XboxOne && !isEditor)
			{
				try
				{
					XboxOneInputSource customInputSource = new XboxOneInputSource();
					fjIUsQKflnkYVKJEJIlJoJufbQP = new CustomInputManager(customInputSource, zeOdvKvLepaDssBfYXvcNnfTGHoC.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (fjIUsQKflnkYVKJEJIlJoJufbQP == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					fjIUsQKflnkYVKJEJIlJoJufbQP = null;
				}
			}
			else if (UnityTools.platform == Platform.PS4 && !isEditor)
			{
				try
				{
					PS4InputSource customInputSource2 = new PS4InputSource();
					fjIUsQKflnkYVKJEJIlJoJufbQP = new CustomInputManager(customInputSource2, zeOdvKvLepaDssBfYXvcNnfTGHoC.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (fjIUsQKflnkYVKJEJIlJoJufbQP == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("PS4 platform could not be initialized!");
					fjIUsQKflnkYVKJEJIlJoJufbQP = null;
				}
			}
			else if (UnityTools.platform == Platform.Stadia && !isEditor)
			{
				try
				{
					fjIUsQKflnkYVKJEJIlJoJufbQP = P_0(zeOdvKvLepaDssBfYXvcNnfTGHoC) as PlatformInputManager;
					if (fjIUsQKflnkYVKJEJIlJoJufbQP == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("Stadia platform could not be initialized! Is the Rewired Stadia library installed? See the documentation for more information.");
					Logger.LogError(msg);
					fjIUsQKflnkYVKJEJIlJoJufbQP = null;
				}
			}
			else if ((UnityTools.platform == Platform.GameCoreXboxOne || UnityTools.platform == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					fjIUsQKflnkYVKJEJIlJoJufbQP = P_0(zeOdvKvLepaDssBfYXvcNnfTGHoC) as PlatformInputManager;
					if (fjIUsQKflnkYVKJEJIlJoJufbQP == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					string text = ((UnityTools.platform == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg2);
					fjIUsQKflnkYVKJEJIlJoJufbQP = null;
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
					fjIUsQKflnkYVKJEJIlJoJufbQP = new CustomInputManager(customInputSource3, zeOdvKvLepaDssBfYXvcNnfTGHoC.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (fjIUsQKflnkYVKJEJIlJoJufbQP == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Ouya platform could not be initialized! Please see the documentation for required dependencies. Rewired will fall back to Unity input. All features may not be available.");
					fjIUsQKflnkYVKJEJIlJoJufbQP = null;
				}
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.androidFallbackPlatformHelper = P_0(zeOdvKvLepaDssBfYXvcNnfTGHoC) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg3)
				{
					Logger.LogError(msg3);
				}
			}
			if (fjIUsQKflnkYVKJEJIlJoJufbQP == null)
			{
				XjZjvbdFPtQBjmMQgUSNicoRCos = true;
				fjIUsQKflnkYVKJEJIlJoJufbQP = new qhEHTWwzpdfUANmcCHXUDkkVGxvn(zeOdvKvLepaDssBfYXvcNnfTGHoC.updateLoop);
			}
		}

		private static void JdrOBRVCYfffukYUSlVUhpxNzTX()
		{
			if (qVYgDleOAcZYuNBYKhOVnajcORpT != zeOdvKvLepaDssBfYXvcNnfTGHoC.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				qVYgDleOAcZYuNBYKhOVnajcORpT = !qVYgDleOAcZYuNBYKhOVnajcORpT;
			}
		}

		private static void AYPhOIfhQBhXeFpDXPYcwZUSyWCT()
		{
			if (!(UnityTools.unityVersionObj == null))
			{
				Logger.LogWarning("The version of Rewired installed (" + programVersion + ") was not designed for Unity " + UnityTools.unityVersionObj.major + ". Please install Rewired for Unity " + UnityTools.unityVersionObj.major + ".\n\nThis warning does not mean that Rewired will not function, but it may not function optimally.\n\nSome different major versions of Unity download Asset Store assets to the same folder location on disk, so if you download an asset in one version of the Unity editor, then open another version of the Unity editor and install the asset without re-downloading it, the wrong asset version will be installed. To fix this, manually re-download Rewired in the Unity Asset Store panel in this version of the Unity Editor, then install it.\n\nIf you are using a beta version of a new major version of Unity, you will have to wait until the release of the final version before a compatible version of Rewired can be uploaded to the Asset Store. When the new version is ready, it will be available through the Unity Asset Store for download as usual.");
			}
		}

		[CompilerGenerated]
		private static void vhSczOwnyTmRZjqOfOSDxheNSO(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void jPxOqxVDMoEZlMHmOEYlcFTSkMI(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
		}

		[CompilerGenerated]
		private static void UAxxkxmmnzmIwBwVCAUPETlILLP(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
		}

		[CompilerGenerated]
		private static void bkroireWZbqYpVFPKMujpwLtfrl(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
		}

		[CompilerGenerated]
		private static void NXJUDOIWoejmSTmPRiEiqCJmdRW(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
		}

		[CompilerGenerated]
		private static void EiTKuTLSEcmMqfZRngtaAWKcLwN(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void QZYgaOihHEABrfZhTzNFolxIIgJ(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
		}

		[CompilerGenerated]
		private static void ExWWcnoBuGPtIBCnRxiZCgOVwjk(Exception P_0)
		{
			HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
		}

		[CompilerGenerated]
		private static void YagapnxBYevGguoEpHRHEKZDYLI(Exception P_0)
		{
			HandleCallbackException("", P_0);
		}

		[CompilerGenerated]
		private static bool yJBMPoUmPsGPRSJYIqtsNLIIPWf()
		{
			if (isUnityEditorFocused)
			{
				return isAllowedEditorWindowFocused;
			}
			return false;
		}
	}
}
