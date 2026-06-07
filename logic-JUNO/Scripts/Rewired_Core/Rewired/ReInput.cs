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
		public sealed class ConfigHelper : CodeHelper
		{
			private static ConfigHelper BztHMYPEiXYPCBiAIbcSxOeZmXXT;

			private float oWamJqmJHRhswZbeEdugkwxjVixQ = 0.7f;

			private float ioISHBKBjfjkyltOxNhFFQzkHpiE = 100f;

			internal static ConfigHelper knzCGddRCsFunrfWEmZKGkfecRudb => BztHMYPEiXYPCBiAIbcSxOeZmXXT ?? (BztHMYPEiXYPCBiAIbcSxOeZmXXT = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.platform == Platform.Windows && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						return (zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
					}
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.useXInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
						if (platformVars_WindowsUWP.useGamepadAPI != value)
						{
							platformVars_WindowsUWP.useGamepadAPI = value;
							if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
							{
								tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
							}
						}
					}
					else if (zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.useXInput != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.useXInput = value;
						if (!value && UnityTools.platform == Platform.Windows && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.Log("The primary input source has been changed to Raw Input.");
						}
						else if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.updateLoop = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.platform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.useXInput = true;
						}
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.osx_primaryInputSource != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.osx_primaryInputSource = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.linux_primaryInputSource != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.linux_primaryInputSource = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.windowsUWP_primaryInputSource = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return (zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.xboxOne_primaryInputSource != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.xboxOne_primaryInputSource = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.ps4_primaryInputSource != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.ps4_primaryInputSource = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.webGL_primaryInputSource != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.webGL_primaryInputSource = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.alwaysUseUnityInput != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.alwaysUseUnityInput = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.SetPlatformVar_useNativeMouse(value) && tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
					{
						tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
					{
						tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
					{
						tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.GetPlatformVar_joystickRefreshRate();
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
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						vsQTXTaOOgoJMQnkwcIxSjBsfizg();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.android_supportUnknownGamepads != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.android_supportUnknownGamepads = value;
						if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
						{
							tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.defaultAxisSensitivityType != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.defaultAxisSensitivityType = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.force4WayHats != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.force4WayHats = value;
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
					return oWamJqmJHRhswZbeEdugkwxjVixQ;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (oWamJqmJHRhswZbeEdugkwxjVixQ != value)
						{
							oWamJqmJHRhswZbeEdugkwxjVixQ = value;
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
					return ioISHBKBjfjkyltOxNhFFQzkHpiE;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (ioISHBKBjfjkyltOxNhFFQzkHpiE != value)
						{
							ioISHBKBjfjkyltOxNhFFQzkHpiE = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.activateActionButtonsOnNegativeValue = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.throttleCalibrationMode != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.throttleCalibrationMode = value;
						WUBqcfcHLvbkdiiUnEhQlzYVACJm.uGhagEXrxHCGvjtOpDbwiRAKhWPKB(value);
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.autoAssignJoysticks != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.autoAssignJoysticks = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.maxJoysticksPerPlayer != value)
						{
							zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.maxJoysticksPerPlayer = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.distributeJoysticksEvenly != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.distributeJoysticksEvenly = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.logLevel != value)
					{
						zCDqGEhTxmNAFQUBgylNBlDdZINJ.ConfigVars.logLevel = value;
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
				private sealed class WSIZGXzGKeslCgcxwdpXCyfVCtQK : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int viAfVPwYtkWcnBySAgszTTLzyHee;

					private ControllerPollingInfo ZADGRQiDzHKeyIJJCxvLGyKSIYIl;

					private int dphDikhNQkioxSdminsiNkmIjdwlA;

					public PollingHelper mDHKsCoNoUjKXFofHRKMXvnHmXyE;

					private IEnumerator<ControllerPollingInfo> CqcOxKhWfGrhPALpOCIXMqjRIKqF;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return ZADGRQiDzHKeyIJJCxvLGyKSIYIl;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return ZADGRQiDzHKeyIJJCxvLGyKSIYIl;
						}
					}

					[DebuggerHidden]
					public WSIZGXzGKeslCgcxwdpXCyfVCtQK(int P_0)
					{
						viAfVPwYtkWcnBySAgszTTLzyHee = P_0;
						dphDikhNQkioxSdminsiNkmIjdwlA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (viAfVPwYtkWcnBySAgszTTLzyHee)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								NXlJNiGsGDwLisbGoHuhDydPLYPOA();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								fsPxCmlPHgyivOKZfeouQNpkWDCC();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								gRTKnHxAlvalQPttMkmTHQBUtyAh();
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
							int num = viAfVPwYtkWcnBySAgszTTLzyHee;
							PollingHelper pollingHelper = mDHKsCoNoUjKXFofHRKMXvnHmXyE;
							switch (num)
							{
							default:
								return false;
							case 0:
								viAfVPwYtkWcnBySAgszTTLzyHee = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								CqcOxKhWfGrhPALpOCIXMqjRIKqF = pollingHelper.OPrLeygLgdYIMCJptiprRKtKGwREA().GetEnumerator();
								viAfVPwYtkWcnBySAgszTTLzyHee = -3;
								goto IL_0084;
							case 1:
								viAfVPwYtkWcnBySAgszTTLzyHee = -3;
								goto IL_0084;
							case 2:
								viAfVPwYtkWcnBySAgszTTLzyHee = -4;
								goto IL_00e4;
							case 3:
								{
									viAfVPwYtkWcnBySAgszTTLzyHee = -5;
									break;
								}
								IL_00e4:
								if (CqcOxKhWfGrhPALpOCIXMqjRIKqF.MoveNext())
								{
									ControllerPollingInfo current = CqcOxKhWfGrhPALpOCIXMqjRIKqF.Current;
									ZADGRQiDzHKeyIJJCxvLGyKSIYIl = current;
									viAfVPwYtkWcnBySAgszTTLzyHee = 2;
									return true;
								}
								fsPxCmlPHgyivOKZfeouQNpkWDCC();
								CqcOxKhWfGrhPALpOCIXMqjRIKqF = null;
								CqcOxKhWfGrhPALpOCIXMqjRIKqF = pollingHelper.QkUzPdZjNVZhJnRFdLCIaDKvZMEN().GetEnumerator();
								viAfVPwYtkWcnBySAgszTTLzyHee = -5;
								break;
								IL_0084:
								if (CqcOxKhWfGrhPALpOCIXMqjRIKqF.MoveNext())
								{
									ControllerPollingInfo current2 = CqcOxKhWfGrhPALpOCIXMqjRIKqF.Current;
									ZADGRQiDzHKeyIJJCxvLGyKSIYIl = current2;
									viAfVPwYtkWcnBySAgszTTLzyHee = 1;
									return true;
								}
								NXlJNiGsGDwLisbGoHuhDydPLYPOA();
								CqcOxKhWfGrhPALpOCIXMqjRIKqF = null;
								CqcOxKhWfGrhPALpOCIXMqjRIKqF = pollingHelper.UwaZMCTqiRTaorFEOOrYwqtadZRbA().GetEnumerator();
								viAfVPwYtkWcnBySAgszTTLzyHee = -4;
								goto IL_00e4;
							}
							if (CqcOxKhWfGrhPALpOCIXMqjRIKqF.MoveNext())
							{
								ControllerPollingInfo current3 = CqcOxKhWfGrhPALpOCIXMqjRIKqF.Current;
								ZADGRQiDzHKeyIJJCxvLGyKSIYIl = current3;
								viAfVPwYtkWcnBySAgszTTLzyHee = 3;
								return true;
							}
							gRTKnHxAlvalQPttMkmTHQBUtyAh();
							CqcOxKhWfGrhPALpOCIXMqjRIKqF = null;
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

					private void NXlJNiGsGDwLisbGoHuhDydPLYPOA()
					{
						viAfVPwYtkWcnBySAgszTTLzyHee = -1;
						if (CqcOxKhWfGrhPALpOCIXMqjRIKqF != null)
						{
							CqcOxKhWfGrhPALpOCIXMqjRIKqF.Dispose();
						}
					}

					private void fsPxCmlPHgyivOKZfeouQNpkWDCC()
					{
						viAfVPwYtkWcnBySAgszTTLzyHee = -1;
						if (CqcOxKhWfGrhPALpOCIXMqjRIKqF != null)
						{
							CqcOxKhWfGrhPALpOCIXMqjRIKqF.Dispose();
						}
					}

					private void gRTKnHxAlvalQPttMkmTHQBUtyAh()
					{
						viAfVPwYtkWcnBySAgszTTLzyHee = -1;
						if (CqcOxKhWfGrhPALpOCIXMqjRIKqF != null)
						{
							CqcOxKhWfGrhPALpOCIXMqjRIKqF.Dispose();
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
						WSIZGXzGKeslCgcxwdpXCyfVCtQK wSIZGXzGKeslCgcxwdpXCyfVCtQK;
						if (viAfVPwYtkWcnBySAgszTTLzyHee == -2 && dphDikhNQkioxSdminsiNkmIjdwlA == Environment.CurrentManagedThreadId)
						{
							viAfVPwYtkWcnBySAgszTTLzyHee = 0;
							wSIZGXzGKeslCgcxwdpXCyfVCtQK = this;
						}
						else
						{
							wSIZGXzGKeslCgcxwdpXCyfVCtQK = new WSIZGXzGKeslCgcxwdpXCyfVCtQK(0);
							wSIZGXzGKeslCgcxwdpXCyfVCtQK.mDHKsCoNoUjKXFofHRKMXvnHmXyE = mDHKsCoNoUjKXFofHRKMXvnHmXyE;
						}
						return wSIZGXzGKeslCgcxwdpXCyfVCtQK;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class cqzSBUGEXxBFdOiMfxOECKLUFbjt : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int kJHyPhlZnMkTmNDLhIWwftKOKoag;

					private ControllerPollingInfo pIlHipoiZRzKSArrzvRlfdhiAmgg;

					private int aEjiANvGOQTALadupENCbYZEqtEbA;

					public PollingHelper rqvEHVKiaSpfMwbZcOIVFqOCccRh;

					private IEnumerator<ControllerPollingInfo> GgtebAimjDcbTClFjGGkTMcwLiCFb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return pIlHipoiZRzKSArrzvRlfdhiAmgg;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return pIlHipoiZRzKSArrzvRlfdhiAmgg;
						}
					}

					[DebuggerHidden]
					public cqzSBUGEXxBFdOiMfxOECKLUFbjt(int P_0)
					{
						kJHyPhlZnMkTmNDLhIWwftKOKoag = P_0;
						aEjiANvGOQTALadupENCbYZEqtEbA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (kJHyPhlZnMkTmNDLhIWwftKOKoag)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								FmHQGsTHAXFKDBaqGigPlpOXLkTm();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								xRQPRTuVjDGadawQBiWbjzEulNkF();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								ejlTPqtYjGaEXjORCUdUDQoxERps();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								eYAqTyEpIUTEzBEmlqgvVjnOiwhQ();
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
							int num = kJHyPhlZnMkTmNDLhIWwftKOKoag;
							PollingHelper pollingHelper = rqvEHVKiaSpfMwbZcOIVFqOCccRh;
							switch (num)
							{
							default:
								return false;
							case 0:
								kJHyPhlZnMkTmNDLhIWwftKOKoag = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								GgtebAimjDcbTClFjGGkTMcwLiCFb = pollingHelper.qWuuJaTODsDRwczSrExKhsNCfUSL().GetEnumerator();
								kJHyPhlZnMkTmNDLhIWwftKOKoag = -3;
								goto IL_0088;
							case 1:
								kJHyPhlZnMkTmNDLhIWwftKOKoag = -3;
								goto IL_0088;
							case 2:
								kJHyPhlZnMkTmNDLhIWwftKOKoag = -4;
								goto IL_00e8;
							case 3:
								kJHyPhlZnMkTmNDLhIWwftKOKoag = -5;
								goto IL_0148;
							case 4:
								{
									kJHyPhlZnMkTmNDLhIWwftKOKoag = -6;
									break;
								}
								IL_00e8:
								if (GgtebAimjDcbTClFjGGkTMcwLiCFb.MoveNext())
								{
									ControllerPollingInfo current = GgtebAimjDcbTClFjGGkTMcwLiCFb.Current;
									pIlHipoiZRzKSArrzvRlfdhiAmgg = current;
									kJHyPhlZnMkTmNDLhIWwftKOKoag = 2;
									return true;
								}
								xRQPRTuVjDGadawQBiWbjzEulNkF();
								GgtebAimjDcbTClFjGGkTMcwLiCFb = null;
								GgtebAimjDcbTClFjGGkTMcwLiCFb = pollingHelper.buHAgOMPBNFnEgCyYkkwQNcTqNcyA().GetEnumerator();
								kJHyPhlZnMkTmNDLhIWwftKOKoag = -5;
								goto IL_0148;
								IL_0088:
								if (GgtebAimjDcbTClFjGGkTMcwLiCFb.MoveNext())
								{
									ControllerPollingInfo current2 = GgtebAimjDcbTClFjGGkTMcwLiCFb.Current;
									pIlHipoiZRzKSArrzvRlfdhiAmgg = current2;
									kJHyPhlZnMkTmNDLhIWwftKOKoag = 1;
									return true;
								}
								FmHQGsTHAXFKDBaqGigPlpOXLkTm();
								GgtebAimjDcbTClFjGGkTMcwLiCFb = null;
								GgtebAimjDcbTClFjGGkTMcwLiCFb = pollingHelper.NlXsvxRnrRFilgFLEJALyrLdnzGE().GetEnumerator();
								kJHyPhlZnMkTmNDLhIWwftKOKoag = -4;
								goto IL_00e8;
								IL_0148:
								if (GgtebAimjDcbTClFjGGkTMcwLiCFb.MoveNext())
								{
									ControllerPollingInfo current3 = GgtebAimjDcbTClFjGGkTMcwLiCFb.Current;
									pIlHipoiZRzKSArrzvRlfdhiAmgg = current3;
									kJHyPhlZnMkTmNDLhIWwftKOKoag = 3;
									return true;
								}
								ejlTPqtYjGaEXjORCUdUDQoxERps();
								GgtebAimjDcbTClFjGGkTMcwLiCFb = null;
								GgtebAimjDcbTClFjGGkTMcwLiCFb = pollingHelper.oiPVIlNGowqixdcYwXbGtJfFOSsb().GetEnumerator();
								kJHyPhlZnMkTmNDLhIWwftKOKoag = -6;
								break;
							}
							if (GgtebAimjDcbTClFjGGkTMcwLiCFb.MoveNext())
							{
								ControllerPollingInfo current4 = GgtebAimjDcbTClFjGGkTMcwLiCFb.Current;
								pIlHipoiZRzKSArrzvRlfdhiAmgg = current4;
								kJHyPhlZnMkTmNDLhIWwftKOKoag = 4;
								return true;
							}
							eYAqTyEpIUTEzBEmlqgvVjnOiwhQ();
							GgtebAimjDcbTClFjGGkTMcwLiCFb = null;
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

					private void FmHQGsTHAXFKDBaqGigPlpOXLkTm()
					{
						kJHyPhlZnMkTmNDLhIWwftKOKoag = -1;
						if (GgtebAimjDcbTClFjGGkTMcwLiCFb != null)
						{
							GgtebAimjDcbTClFjGGkTMcwLiCFb.Dispose();
						}
					}

					private void xRQPRTuVjDGadawQBiWbjzEulNkF()
					{
						kJHyPhlZnMkTmNDLhIWwftKOKoag = -1;
						if (GgtebAimjDcbTClFjGGkTMcwLiCFb != null)
						{
							GgtebAimjDcbTClFjGGkTMcwLiCFb.Dispose();
						}
					}

					private void ejlTPqtYjGaEXjORCUdUDQoxERps()
					{
						kJHyPhlZnMkTmNDLhIWwftKOKoag = -1;
						if (GgtebAimjDcbTClFjGGkTMcwLiCFb != null)
						{
							GgtebAimjDcbTClFjGGkTMcwLiCFb.Dispose();
						}
					}

					private void eYAqTyEpIUTEzBEmlqgvVjnOiwhQ()
					{
						kJHyPhlZnMkTmNDLhIWwftKOKoag = -1;
						if (GgtebAimjDcbTClFjGGkTMcwLiCFb != null)
						{
							GgtebAimjDcbTClFjGGkTMcwLiCFb.Dispose();
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
						cqzSBUGEXxBFdOiMfxOECKLUFbjt cqzSBUGEXxBFdOiMfxOECKLUFbjt2;
						if (kJHyPhlZnMkTmNDLhIWwftKOKoag == -2 && aEjiANvGOQTALadupENCbYZEqtEbA == Environment.CurrentManagedThreadId)
						{
							kJHyPhlZnMkTmNDLhIWwftKOKoag = 0;
							cqzSBUGEXxBFdOiMfxOECKLUFbjt2 = this;
						}
						else
						{
							cqzSBUGEXxBFdOiMfxOECKLUFbjt2 = new cqzSBUGEXxBFdOiMfxOECKLUFbjt(0);
							cqzSBUGEXxBFdOiMfxOECKLUFbjt2.rqvEHVKiaSpfMwbZcOIVFqOCccRh = rqvEHVKiaSpfMwbZcOIVFqOCccRh;
						}
						return cqzSBUGEXxBFdOiMfxOECKLUFbjt2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ioKecCEQrykkoVhuvezJufAXJhso : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int yzKDElcekpjXwlpHrABDcaFAuZxSA;

					private ControllerPollingInfo hWNnDpDdXxIuTaSIUQAhLTaSnxAc;

					private int ftajnSWiRPDmKZUwngOZZTTOdLPb;

					public PollingHelper DqOcQIRrcUcDohbEJIbEPLLzgvnyA;

					private IEnumerator<ControllerPollingInfo> DxhgnCdyLwBiPVyOxkMTyCnEYjTh;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return hWNnDpDdXxIuTaSIUQAhLTaSnxAc;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hWNnDpDdXxIuTaSIUQAhLTaSnxAc;
						}
					}

					[DebuggerHidden]
					public ioKecCEQrykkoVhuvezJufAXJhso(int P_0)
					{
						yzKDElcekpjXwlpHrABDcaFAuZxSA = P_0;
						ftajnSWiRPDmKZUwngOZZTTOdLPb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (yzKDElcekpjXwlpHrABDcaFAuZxSA)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								jTTUbAUIxDPhwHmGTffPdhuQRWmD();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								OWfcgtAyhfSpCwGpEofXbQWiWoYtA();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								ERMLslaITEyPcRmcWlVYoEcWGneP();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								IPlbeWAmbjbtKaGXfORuXpVsVvdvb();
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
							int num = yzKDElcekpjXwlpHrABDcaFAuZxSA;
							PollingHelper dqOcQIRrcUcDohbEJIbEPLLzgvnyA = DqOcQIRrcUcDohbEJIbEPLLzgvnyA;
							switch (num)
							{
							default:
								return false;
							case 0:
								yzKDElcekpjXwlpHrABDcaFAuZxSA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								DxhgnCdyLwBiPVyOxkMTyCnEYjTh = dqOcQIRrcUcDohbEJIbEPLLzgvnyA.dWIVSBSVnEVCgLJofycOnPGowHl().GetEnumerator();
								yzKDElcekpjXwlpHrABDcaFAuZxSA = -3;
								goto IL_0088;
							case 1:
								yzKDElcekpjXwlpHrABDcaFAuZxSA = -3;
								goto IL_0088;
							case 2:
								yzKDElcekpjXwlpHrABDcaFAuZxSA = -4;
								goto IL_00e8;
							case 3:
								yzKDElcekpjXwlpHrABDcaFAuZxSA = -5;
								goto IL_0148;
							case 4:
								{
									yzKDElcekpjXwlpHrABDcaFAuZxSA = -6;
									break;
								}
								IL_00e8:
								if (DxhgnCdyLwBiPVyOxkMTyCnEYjTh.MoveNext())
								{
									ControllerPollingInfo current = DxhgnCdyLwBiPVyOxkMTyCnEYjTh.Current;
									hWNnDpDdXxIuTaSIUQAhLTaSnxAc = current;
									yzKDElcekpjXwlpHrABDcaFAuZxSA = 2;
									return true;
								}
								OWfcgtAyhfSpCwGpEofXbQWiWoYtA();
								DxhgnCdyLwBiPVyOxkMTyCnEYjTh = null;
								DxhgnCdyLwBiPVyOxkMTyCnEYjTh = dqOcQIRrcUcDohbEJIbEPLLzgvnyA.RYEcTpDwiGljDUEBGiNKHIFNQNdbA().GetEnumerator();
								yzKDElcekpjXwlpHrABDcaFAuZxSA = -5;
								goto IL_0148;
								IL_0088:
								if (DxhgnCdyLwBiPVyOxkMTyCnEYjTh.MoveNext())
								{
									ControllerPollingInfo current2 = DxhgnCdyLwBiPVyOxkMTyCnEYjTh.Current;
									hWNnDpDdXxIuTaSIUQAhLTaSnxAc = current2;
									yzKDElcekpjXwlpHrABDcaFAuZxSA = 1;
									return true;
								}
								jTTUbAUIxDPhwHmGTffPdhuQRWmD();
								DxhgnCdyLwBiPVyOxkMTyCnEYjTh = null;
								DxhgnCdyLwBiPVyOxkMTyCnEYjTh = dqOcQIRrcUcDohbEJIbEPLLzgvnyA.azstpdDOHRwdpmAiUMJbJwzHgkiy().GetEnumerator();
								yzKDElcekpjXwlpHrABDcaFAuZxSA = -4;
								goto IL_00e8;
								IL_0148:
								if (DxhgnCdyLwBiPVyOxkMTyCnEYjTh.MoveNext())
								{
									ControllerPollingInfo current3 = DxhgnCdyLwBiPVyOxkMTyCnEYjTh.Current;
									hWNnDpDdXxIuTaSIUQAhLTaSnxAc = current3;
									yzKDElcekpjXwlpHrABDcaFAuZxSA = 3;
									return true;
								}
								ERMLslaITEyPcRmcWlVYoEcWGneP();
								DxhgnCdyLwBiPVyOxkMTyCnEYjTh = null;
								DxhgnCdyLwBiPVyOxkMTyCnEYjTh = dqOcQIRrcUcDohbEJIbEPLLzgvnyA.ctjgXRSHOQPeVLNLqpDMszUeKYTD().GetEnumerator();
								yzKDElcekpjXwlpHrABDcaFAuZxSA = -6;
								break;
							}
							if (DxhgnCdyLwBiPVyOxkMTyCnEYjTh.MoveNext())
							{
								ControllerPollingInfo current4 = DxhgnCdyLwBiPVyOxkMTyCnEYjTh.Current;
								hWNnDpDdXxIuTaSIUQAhLTaSnxAc = current4;
								yzKDElcekpjXwlpHrABDcaFAuZxSA = 4;
								return true;
							}
							IPlbeWAmbjbtKaGXfORuXpVsVvdvb();
							DxhgnCdyLwBiPVyOxkMTyCnEYjTh = null;
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

					private void jTTUbAUIxDPhwHmGTffPdhuQRWmD()
					{
						yzKDElcekpjXwlpHrABDcaFAuZxSA = -1;
						if (DxhgnCdyLwBiPVyOxkMTyCnEYjTh != null)
						{
							DxhgnCdyLwBiPVyOxkMTyCnEYjTh.Dispose();
						}
					}

					private void OWfcgtAyhfSpCwGpEofXbQWiWoYtA()
					{
						yzKDElcekpjXwlpHrABDcaFAuZxSA = -1;
						if (DxhgnCdyLwBiPVyOxkMTyCnEYjTh != null)
						{
							DxhgnCdyLwBiPVyOxkMTyCnEYjTh.Dispose();
						}
					}

					private void ERMLslaITEyPcRmcWlVYoEcWGneP()
					{
						yzKDElcekpjXwlpHrABDcaFAuZxSA = -1;
						if (DxhgnCdyLwBiPVyOxkMTyCnEYjTh != null)
						{
							DxhgnCdyLwBiPVyOxkMTyCnEYjTh.Dispose();
						}
					}

					private void IPlbeWAmbjbtKaGXfORuXpVsVvdvb()
					{
						yzKDElcekpjXwlpHrABDcaFAuZxSA = -1;
						if (DxhgnCdyLwBiPVyOxkMTyCnEYjTh != null)
						{
							DxhgnCdyLwBiPVyOxkMTyCnEYjTh.Dispose();
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
						ioKecCEQrykkoVhuvezJufAXJhso ioKecCEQrykkoVhuvezJufAXJhso2;
						if (yzKDElcekpjXwlpHrABDcaFAuZxSA == -2 && ftajnSWiRPDmKZUwngOZZTTOdLPb == Environment.CurrentManagedThreadId)
						{
							yzKDElcekpjXwlpHrABDcaFAuZxSA = 0;
							ioKecCEQrykkoVhuvezJufAXJhso2 = this;
						}
						else
						{
							ioKecCEQrykkoVhuvezJufAXJhso2 = new ioKecCEQrykkoVhuvezJufAXJhso(0);
							ioKecCEQrykkoVhuvezJufAXJhso2.DqOcQIRrcUcDohbEJIbEPLLzgvnyA = DqOcQIRrcUcDohbEJIbEPLLzgvnyA;
						}
						return ioKecCEQrykkoVhuvezJufAXJhso2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class fPRzjyTrMdLcfuLMyUJgqlKHCFjz : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int dHzhlfukojrMkxEiRdPVnEMeTEUX;

					private ControllerPollingInfo UOeDjQogFBGbCOnMQdSJctybntmRA;

					private int szUbofdJqnCaOGnGlnZXuQevsXsaA;

					public PollingHelper dnCqKZVWZvTeIixfEIBOZBuHeIOT;

					private IEnumerator<ControllerPollingInfo> FJQhwftJGjePyTWgpBSVsyIlunLp;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return UOeDjQogFBGbCOnMQdSJctybntmRA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return UOeDjQogFBGbCOnMQdSJctybntmRA;
						}
					}

					[DebuggerHidden]
					public fPRzjyTrMdLcfuLMyUJgqlKHCFjz(int P_0)
					{
						dHzhlfukojrMkxEiRdPVnEMeTEUX = P_0;
						szUbofdJqnCaOGnGlnZXuQevsXsaA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (dHzhlfukojrMkxEiRdPVnEMeTEUX)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								rUKpZxqbzvbdrrSKWMKFreDzLzIl();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								eMSYmgTMFzEfdqdfIaWoXoKjVPrj();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								jIkGoGsorHIDzaMDRtPkokmGmfVd();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								LFMSjcNsMAiMHDfeTZdGTzwcEqXV();
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
							int num = dHzhlfukojrMkxEiRdPVnEMeTEUX;
							PollingHelper pollingHelper = dnCqKZVWZvTeIixfEIBOZBuHeIOT;
							switch (num)
							{
							default:
								return false;
							case 0:
								dHzhlfukojrMkxEiRdPVnEMeTEUX = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								FJQhwftJGjePyTWgpBSVsyIlunLp = pollingHelper.xJHAfqVEbwmBWTJwKkIuGcuBFcnF().GetEnumerator();
								dHzhlfukojrMkxEiRdPVnEMeTEUX = -3;
								goto IL_0088;
							case 1:
								dHzhlfukojrMkxEiRdPVnEMeTEUX = -3;
								goto IL_0088;
							case 2:
								dHzhlfukojrMkxEiRdPVnEMeTEUX = -4;
								goto IL_00e8;
							case 3:
								dHzhlfukojrMkxEiRdPVnEMeTEUX = -5;
								goto IL_0148;
							case 4:
								{
									dHzhlfukojrMkxEiRdPVnEMeTEUX = -6;
									break;
								}
								IL_00e8:
								if (FJQhwftJGjePyTWgpBSVsyIlunLp.MoveNext())
								{
									ControllerPollingInfo current = FJQhwftJGjePyTWgpBSVsyIlunLp.Current;
									UOeDjQogFBGbCOnMQdSJctybntmRA = current;
									dHzhlfukojrMkxEiRdPVnEMeTEUX = 2;
									return true;
								}
								eMSYmgTMFzEfdqdfIaWoXoKjVPrj();
								FJQhwftJGjePyTWgpBSVsyIlunLp = null;
								FJQhwftJGjePyTWgpBSVsyIlunLp = pollingHelper.NKVSoGlMbHAlcVIhaVriQeuOfkweA().GetEnumerator();
								dHzhlfukojrMkxEiRdPVnEMeTEUX = -5;
								goto IL_0148;
								IL_0088:
								if (FJQhwftJGjePyTWgpBSVsyIlunLp.MoveNext())
								{
									ControllerPollingInfo current2 = FJQhwftJGjePyTWgpBSVsyIlunLp.Current;
									UOeDjQogFBGbCOnMQdSJctybntmRA = current2;
									dHzhlfukojrMkxEiRdPVnEMeTEUX = 1;
									return true;
								}
								rUKpZxqbzvbdrrSKWMKFreDzLzIl();
								FJQhwftJGjePyTWgpBSVsyIlunLp = null;
								FJQhwftJGjePyTWgpBSVsyIlunLp = pollingHelper.NlXsvxRnrRFilgFLEJALyrLdnzGE().GetEnumerator();
								dHzhlfukojrMkxEiRdPVnEMeTEUX = -4;
								goto IL_00e8;
								IL_0148:
								if (FJQhwftJGjePyTWgpBSVsyIlunLp.MoveNext())
								{
									ControllerPollingInfo current3 = FJQhwftJGjePyTWgpBSVsyIlunLp.Current;
									UOeDjQogFBGbCOnMQdSJctybntmRA = current3;
									dHzhlfukojrMkxEiRdPVnEMeTEUX = 3;
									return true;
								}
								jIkGoGsorHIDzaMDRtPkokmGmfVd();
								FJQhwftJGjePyTWgpBSVsyIlunLp = null;
								FJQhwftJGjePyTWgpBSVsyIlunLp = pollingHelper.BtzTyEZapEmuaYLapwhZoqgPBXyBA().GetEnumerator();
								dHzhlfukojrMkxEiRdPVnEMeTEUX = -6;
								break;
							}
							if (FJQhwftJGjePyTWgpBSVsyIlunLp.MoveNext())
							{
								ControllerPollingInfo current4 = FJQhwftJGjePyTWgpBSVsyIlunLp.Current;
								UOeDjQogFBGbCOnMQdSJctybntmRA = current4;
								dHzhlfukojrMkxEiRdPVnEMeTEUX = 4;
								return true;
							}
							LFMSjcNsMAiMHDfeTZdGTzwcEqXV();
							FJQhwftJGjePyTWgpBSVsyIlunLp = null;
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

					private void rUKpZxqbzvbdrrSKWMKFreDzLzIl()
					{
						dHzhlfukojrMkxEiRdPVnEMeTEUX = -1;
						if (FJQhwftJGjePyTWgpBSVsyIlunLp != null)
						{
							FJQhwftJGjePyTWgpBSVsyIlunLp.Dispose();
						}
					}

					private void eMSYmgTMFzEfdqdfIaWoXoKjVPrj()
					{
						dHzhlfukojrMkxEiRdPVnEMeTEUX = -1;
						if (FJQhwftJGjePyTWgpBSVsyIlunLp != null)
						{
							FJQhwftJGjePyTWgpBSVsyIlunLp.Dispose();
						}
					}

					private void jIkGoGsorHIDzaMDRtPkokmGmfVd()
					{
						dHzhlfukojrMkxEiRdPVnEMeTEUX = -1;
						if (FJQhwftJGjePyTWgpBSVsyIlunLp != null)
						{
							FJQhwftJGjePyTWgpBSVsyIlunLp.Dispose();
						}
					}

					private void LFMSjcNsMAiMHDfeTZdGTzwcEqXV()
					{
						dHzhlfukojrMkxEiRdPVnEMeTEUX = -1;
						if (FJQhwftJGjePyTWgpBSVsyIlunLp != null)
						{
							FJQhwftJGjePyTWgpBSVsyIlunLp.Dispose();
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
						fPRzjyTrMdLcfuLMyUJgqlKHCFjz fPRzjyTrMdLcfuLMyUJgqlKHCFjz2;
						if (dHzhlfukojrMkxEiRdPVnEMeTEUX == -2 && szUbofdJqnCaOGnGlnZXuQevsXsaA == Environment.CurrentManagedThreadId)
						{
							dHzhlfukojrMkxEiRdPVnEMeTEUX = 0;
							fPRzjyTrMdLcfuLMyUJgqlKHCFjz2 = this;
						}
						else
						{
							fPRzjyTrMdLcfuLMyUJgqlKHCFjz2 = new fPRzjyTrMdLcfuLMyUJgqlKHCFjz(0);
							fPRzjyTrMdLcfuLMyUJgqlKHCFjz2.dnCqKZVWZvTeIixfEIBOZBuHeIOT = dnCqKZVWZvTeIixfEIBOZBuHeIOT;
						}
						return fPRzjyTrMdLcfuLMyUJgqlKHCFjz2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class TPWBlcFBDUWGAWbkMxfyZjDTBXkI : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ImXgkeewCjEIhpSgRsVoiWVoacWd;

					private ControllerPollingInfo SioAYIBmKDgmFIRwgUZPHbTfeJKZ;

					private int aCUpJotzSwmqMzUspGFpFSJptjFR;

					public PollingHelper AhpIZochpqySVRAyWlffGIImVPHI;

					private IEnumerator<ControllerPollingInfo> didchcCLbzPBqdmtVVtzSokufReFb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return SioAYIBmKDgmFIRwgUZPHbTfeJKZ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return SioAYIBmKDgmFIRwgUZPHbTfeJKZ;
						}
					}

					[DebuggerHidden]
					public TPWBlcFBDUWGAWbkMxfyZjDTBXkI(int P_0)
					{
						ImXgkeewCjEIhpSgRsVoiWVoacWd = P_0;
						aCUpJotzSwmqMzUspGFpFSJptjFR = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (ImXgkeewCjEIhpSgRsVoiWVoacWd)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								PZLEHSKKCfZpYiwZhzhbMCWQvOMk();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								EfNSdojgEOZZRwRdShklHVFqKSSQ();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								RYYPrDEpjYqTxDzZOUhoszHGdIOH();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								MMlfAixIpXCrxDshLqOAHWIKjDdaA();
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
							int imXgkeewCjEIhpSgRsVoiWVoacWd = ImXgkeewCjEIhpSgRsVoiWVoacWd;
							PollingHelper ahpIZochpqySVRAyWlffGIImVPHI = AhpIZochpqySVRAyWlffGIImVPHI;
							switch (imXgkeewCjEIhpSgRsVoiWVoacWd)
							{
							default:
								return false;
							case 0:
								ImXgkeewCjEIhpSgRsVoiWVoacWd = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								didchcCLbzPBqdmtVVtzSokufReFb = ahpIZochpqySVRAyWlffGIImVPHI.hRjZirmgNONEXPGetVTQpFPieoUj().GetEnumerator();
								ImXgkeewCjEIhpSgRsVoiWVoacWd = -3;
								goto IL_0088;
							case 1:
								ImXgkeewCjEIhpSgRsVoiWVoacWd = -3;
								goto IL_0088;
							case 2:
								ImXgkeewCjEIhpSgRsVoiWVoacWd = -4;
								goto IL_00e8;
							case 3:
								ImXgkeewCjEIhpSgRsVoiWVoacWd = -5;
								goto IL_0148;
							case 4:
								{
									ImXgkeewCjEIhpSgRsVoiWVoacWd = -6;
									break;
								}
								IL_00e8:
								if (didchcCLbzPBqdmtVVtzSokufReFb.MoveNext())
								{
									ControllerPollingInfo current = didchcCLbzPBqdmtVVtzSokufReFb.Current;
									SioAYIBmKDgmFIRwgUZPHbTfeJKZ = current;
									ImXgkeewCjEIhpSgRsVoiWVoacWd = 2;
									return true;
								}
								EfNSdojgEOZZRwRdShklHVFqKSSQ();
								didchcCLbzPBqdmtVVtzSokufReFb = null;
								didchcCLbzPBqdmtVVtzSokufReFb = ahpIZochpqySVRAyWlffGIImVPHI.DePWBnTLnjZRSBJTFtBZsrODIFAB().GetEnumerator();
								ImXgkeewCjEIhpSgRsVoiWVoacWd = -5;
								goto IL_0148;
								IL_0088:
								if (didchcCLbzPBqdmtVVtzSokufReFb.MoveNext())
								{
									ControllerPollingInfo current2 = didchcCLbzPBqdmtVVtzSokufReFb.Current;
									SioAYIBmKDgmFIRwgUZPHbTfeJKZ = current2;
									ImXgkeewCjEIhpSgRsVoiWVoacWd = 1;
									return true;
								}
								PZLEHSKKCfZpYiwZhzhbMCWQvOMk();
								didchcCLbzPBqdmtVVtzSokufReFb = null;
								didchcCLbzPBqdmtVVtzSokufReFb = ahpIZochpqySVRAyWlffGIImVPHI.azstpdDOHRwdpmAiUMJbJwzHgkiy().GetEnumerator();
								ImXgkeewCjEIhpSgRsVoiWVoacWd = -4;
								goto IL_00e8;
								IL_0148:
								if (didchcCLbzPBqdmtVVtzSokufReFb.MoveNext())
								{
									ControllerPollingInfo current3 = didchcCLbzPBqdmtVVtzSokufReFb.Current;
									SioAYIBmKDgmFIRwgUZPHbTfeJKZ = current3;
									ImXgkeewCjEIhpSgRsVoiWVoacWd = 3;
									return true;
								}
								RYYPrDEpjYqTxDzZOUhoszHGdIOH();
								didchcCLbzPBqdmtVVtzSokufReFb = null;
								didchcCLbzPBqdmtVVtzSokufReFb = ahpIZochpqySVRAyWlffGIImVPHI.LNmyaMxcBNoglkAUrGyogpfFVZVg().GetEnumerator();
								ImXgkeewCjEIhpSgRsVoiWVoacWd = -6;
								break;
							}
							if (didchcCLbzPBqdmtVVtzSokufReFb.MoveNext())
							{
								ControllerPollingInfo current4 = didchcCLbzPBqdmtVVtzSokufReFb.Current;
								SioAYIBmKDgmFIRwgUZPHbTfeJKZ = current4;
								ImXgkeewCjEIhpSgRsVoiWVoacWd = 4;
								return true;
							}
							MMlfAixIpXCrxDshLqOAHWIKjDdaA();
							didchcCLbzPBqdmtVVtzSokufReFb = null;
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

					private void PZLEHSKKCfZpYiwZhzhbMCWQvOMk()
					{
						ImXgkeewCjEIhpSgRsVoiWVoacWd = -1;
						if (didchcCLbzPBqdmtVVtzSokufReFb != null)
						{
							didchcCLbzPBqdmtVVtzSokufReFb.Dispose();
						}
					}

					private void EfNSdojgEOZZRwRdShklHVFqKSSQ()
					{
						ImXgkeewCjEIhpSgRsVoiWVoacWd = -1;
						if (didchcCLbzPBqdmtVVtzSokufReFb != null)
						{
							didchcCLbzPBqdmtVVtzSokufReFb.Dispose();
						}
					}

					private void RYYPrDEpjYqTxDzZOUhoszHGdIOH()
					{
						ImXgkeewCjEIhpSgRsVoiWVoacWd = -1;
						if (didchcCLbzPBqdmtVVtzSokufReFb != null)
						{
							didchcCLbzPBqdmtVVtzSokufReFb.Dispose();
						}
					}

					private void MMlfAixIpXCrxDshLqOAHWIKjDdaA()
					{
						ImXgkeewCjEIhpSgRsVoiWVoacWd = -1;
						if (didchcCLbzPBqdmtVVtzSokufReFb != null)
						{
							didchcCLbzPBqdmtVVtzSokufReFb.Dispose();
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
						TPWBlcFBDUWGAWbkMxfyZjDTBXkI tPWBlcFBDUWGAWbkMxfyZjDTBXkI;
						if (ImXgkeewCjEIhpSgRsVoiWVoacWd == -2 && aCUpJotzSwmqMzUspGFpFSJptjFR == Environment.CurrentManagedThreadId)
						{
							ImXgkeewCjEIhpSgRsVoiWVoacWd = 0;
							tPWBlcFBDUWGAWbkMxfyZjDTBXkI = this;
						}
						else
						{
							tPWBlcFBDUWGAWbkMxfyZjDTBXkI = new TPWBlcFBDUWGAWbkMxfyZjDTBXkI(0);
							tPWBlcFBDUWGAWbkMxfyZjDTBXkI.AhpIZochpqySVRAyWlffGIImVPHI = AhpIZochpqySVRAyWlffGIImVPHI;
						}
						return tPWBlcFBDUWGAWbkMxfyZjDTBXkI;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class HhRVMIxSiOVtUMnwADyLfELTKiFAA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int qNtOfYeRnJQVtBaXOhptXsZEBXlc;

					private ControllerPollingInfo QpBcfwyopLpotxUhlJPfSxOJdVjD;

					private int CcwRIOdOFpeaFsMqZVotwlLlgtxFA;

					private IList<CustomController> ZdoRPrdgBwzyAqRRvpaFjyhqMwTH;

					private int LhVrgLFnJqFeBEAsDjMDcloZdFSqA;

					private IEnumerator<ControllerPollingInfo> StspoUWVwpYCKkXdFyecFeHBIiKJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return QpBcfwyopLpotxUhlJPfSxOJdVjD;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return QpBcfwyopLpotxUhlJPfSxOJdVjD;
						}
					}

					[DebuggerHidden]
					public HhRVMIxSiOVtUMnwADyLfELTKiFAA(int P_0)
					{
						qNtOfYeRnJQVtBaXOhptXsZEBXlc = P_0;
						CcwRIOdOFpeaFsMqZVotwlLlgtxFA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = qNtOfYeRnJQVtBaXOhptXsZEBXlc;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								nARYYItVRhmrcTpzqWTlvKLOfiuo();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = qNtOfYeRnJQVtBaXOhptXsZEBXlc;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								qNtOfYeRnJQVtBaXOhptXsZEBXlc = -3;
								goto IL_0086;
							}
							qNtOfYeRnJQVtBaXOhptXsZEBXlc = -1;
							ZdoRPrdgBwzyAqRRvpaFjyhqMwTH = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
							LhVrgLFnJqFeBEAsDjMDcloZdFSqA = 0;
							goto IL_00b0;
							IL_0086:
							if (StspoUWVwpYCKkXdFyecFeHBIiKJ.MoveNext())
							{
								ControllerPollingInfo current = StspoUWVwpYCKkXdFyecFeHBIiKJ.Current;
								QpBcfwyopLpotxUhlJPfSxOJdVjD = current;
								qNtOfYeRnJQVtBaXOhptXsZEBXlc = 1;
								return true;
							}
							nARYYItVRhmrcTpzqWTlvKLOfiuo();
							StspoUWVwpYCKkXdFyecFeHBIiKJ = null;
							LhVrgLFnJqFeBEAsDjMDcloZdFSqA++;
							goto IL_00b0;
							IL_00b0:
							if (LhVrgLFnJqFeBEAsDjMDcloZdFSqA < ZdoRPrdgBwzyAqRRvpaFjyhqMwTH.Count)
							{
								StspoUWVwpYCKkXdFyecFeHBIiKJ = ZdoRPrdgBwzyAqRRvpaFjyhqMwTH[LhVrgLFnJqFeBEAsDjMDcloZdFSqA].PollForAllAxes().GetEnumerator();
								qNtOfYeRnJQVtBaXOhptXsZEBXlc = -3;
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

					private void nARYYItVRhmrcTpzqWTlvKLOfiuo()
					{
						qNtOfYeRnJQVtBaXOhptXsZEBXlc = -1;
						if (StspoUWVwpYCKkXdFyecFeHBIiKJ != null)
						{
							StspoUWVwpYCKkXdFyecFeHBIiKJ.Dispose();
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
						if (qNtOfYeRnJQVtBaXOhptXsZEBXlc == -2 && CcwRIOdOFpeaFsMqZVotwlLlgtxFA == Environment.CurrentManagedThreadId)
						{
							qNtOfYeRnJQVtBaXOhptXsZEBXlc = 0;
							return this;
						}
						return new HhRVMIxSiOVtUMnwADyLfELTKiFAA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class lQYSpDtLIxFbSxXRqACetmDxWuCf : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int rqvcNZbkSnDJTgiqaunHljRsWisr;

					private ControllerPollingInfo oFsAPTmffTVxVIeMkLAkFsXRLYHC;

					private int znzJqSNxHSTYovaiKRsbQgSeOxBe;

					private IList<CustomController> cEpqdMWnxsWLXtzGJujsCCsqirfY;

					private int IdEpSaCimzEeDbmofgPujgqctvgub;

					private IEnumerator<ControllerPollingInfo> XySGarLUUzwmAYdygvQexWrZOuLM;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return oFsAPTmffTVxVIeMkLAkFsXRLYHC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oFsAPTmffTVxVIeMkLAkFsXRLYHC;
						}
					}

					[DebuggerHidden]
					public lQYSpDtLIxFbSxXRqACetmDxWuCf(int P_0)
					{
						rqvcNZbkSnDJTgiqaunHljRsWisr = P_0;
						znzJqSNxHSTYovaiKRsbQgSeOxBe = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = rqvcNZbkSnDJTgiqaunHljRsWisr;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								NZyWhCsIUkBytnONrCehxHJxolty();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = rqvcNZbkSnDJTgiqaunHljRsWisr;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								rqvcNZbkSnDJTgiqaunHljRsWisr = -3;
								goto IL_0086;
							}
							rqvcNZbkSnDJTgiqaunHljRsWisr = -1;
							cEpqdMWnxsWLXtzGJujsCCsqirfY = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
							IdEpSaCimzEeDbmofgPujgqctvgub = 0;
							goto IL_00b0;
							IL_0086:
							if (XySGarLUUzwmAYdygvQexWrZOuLM.MoveNext())
							{
								ControllerPollingInfo current = XySGarLUUzwmAYdygvQexWrZOuLM.Current;
								oFsAPTmffTVxVIeMkLAkFsXRLYHC = current;
								rqvcNZbkSnDJTgiqaunHljRsWisr = 1;
								return true;
							}
							NZyWhCsIUkBytnONrCehxHJxolty();
							XySGarLUUzwmAYdygvQexWrZOuLM = null;
							IdEpSaCimzEeDbmofgPujgqctvgub++;
							goto IL_00b0;
							IL_00b0:
							if (IdEpSaCimzEeDbmofgPujgqctvgub < cEpqdMWnxsWLXtzGJujsCCsqirfY.Count)
							{
								XySGarLUUzwmAYdygvQexWrZOuLM = cEpqdMWnxsWLXtzGJujsCCsqirfY[IdEpSaCimzEeDbmofgPujgqctvgub].PollForAllButtons().GetEnumerator();
								rqvcNZbkSnDJTgiqaunHljRsWisr = -3;
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

					private void NZyWhCsIUkBytnONrCehxHJxolty()
					{
						rqvcNZbkSnDJTgiqaunHljRsWisr = -1;
						if (XySGarLUUzwmAYdygvQexWrZOuLM != null)
						{
							XySGarLUUzwmAYdygvQexWrZOuLM.Dispose();
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
						if (rqvcNZbkSnDJTgiqaunHljRsWisr == -2 && znzJqSNxHSTYovaiKRsbQgSeOxBe == Environment.CurrentManagedThreadId)
						{
							rqvcNZbkSnDJTgiqaunHljRsWisr = 0;
							return this;
						}
						return new lQYSpDtLIxFbSxXRqACetmDxWuCf(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class uOhHiPZMFQHQAvFKiAGkIDQbSnKQA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int OauWWSeyjEnvBAdQEyUpWADVQpGg;

					private ControllerPollingInfo wvNZCJiBbCviVroTvadAoaKUaYiL;

					private int GhbzaitmKJAMjsJRniEnCGLtEfF;

					private IList<CustomController> ELGnJLQAutxjHaLwYRipyPJiEyFH;

					private int dvFSchIhIGxVuEoFNdZwdepvRCyH;

					private IEnumerator<ControllerPollingInfo> qOvNOmecWdmbOCGakyxPozojBDRW;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return wvNZCJiBbCviVroTvadAoaKUaYiL;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wvNZCJiBbCviVroTvadAoaKUaYiL;
						}
					}

					[DebuggerHidden]
					public uOhHiPZMFQHQAvFKiAGkIDQbSnKQA(int P_0)
					{
						OauWWSeyjEnvBAdQEyUpWADVQpGg = P_0;
						GhbzaitmKJAMjsJRniEnCGLtEfF = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int oauWWSeyjEnvBAdQEyUpWADVQpGg = OauWWSeyjEnvBAdQEyUpWADVQpGg;
						if (oauWWSeyjEnvBAdQEyUpWADVQpGg == -3 || oauWWSeyjEnvBAdQEyUpWADVQpGg == 1)
						{
							try
							{
							}
							finally
							{
								ampElJiBngZQZILXarAQKlXGFigGb();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int oauWWSeyjEnvBAdQEyUpWADVQpGg = OauWWSeyjEnvBAdQEyUpWADVQpGg;
							if (oauWWSeyjEnvBAdQEyUpWADVQpGg != 0)
							{
								if (oauWWSeyjEnvBAdQEyUpWADVQpGg != 1)
								{
									return false;
								}
								OauWWSeyjEnvBAdQEyUpWADVQpGg = -3;
								goto IL_0086;
							}
							OauWWSeyjEnvBAdQEyUpWADVQpGg = -1;
							ELGnJLQAutxjHaLwYRipyPJiEyFH = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
							dvFSchIhIGxVuEoFNdZwdepvRCyH = 0;
							goto IL_00b0;
							IL_0086:
							if (qOvNOmecWdmbOCGakyxPozojBDRW.MoveNext())
							{
								ControllerPollingInfo current = qOvNOmecWdmbOCGakyxPozojBDRW.Current;
								wvNZCJiBbCviVroTvadAoaKUaYiL = current;
								OauWWSeyjEnvBAdQEyUpWADVQpGg = 1;
								return true;
							}
							ampElJiBngZQZILXarAQKlXGFigGb();
							qOvNOmecWdmbOCGakyxPozojBDRW = null;
							dvFSchIhIGxVuEoFNdZwdepvRCyH++;
							goto IL_00b0;
							IL_00b0:
							if (dvFSchIhIGxVuEoFNdZwdepvRCyH < ELGnJLQAutxjHaLwYRipyPJiEyFH.Count)
							{
								qOvNOmecWdmbOCGakyxPozojBDRW = ELGnJLQAutxjHaLwYRipyPJiEyFH[dvFSchIhIGxVuEoFNdZwdepvRCyH].PollForAllButtonsDown().GetEnumerator();
								OauWWSeyjEnvBAdQEyUpWADVQpGg = -3;
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

					private void ampElJiBngZQZILXarAQKlXGFigGb()
					{
						OauWWSeyjEnvBAdQEyUpWADVQpGg = -1;
						if (qOvNOmecWdmbOCGakyxPozojBDRW != null)
						{
							qOvNOmecWdmbOCGakyxPozojBDRW.Dispose();
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
						if (OauWWSeyjEnvBAdQEyUpWADVQpGg == -2 && GhbzaitmKJAMjsJRniEnCGLtEfF == Environment.CurrentManagedThreadId)
						{
							OauWWSeyjEnvBAdQEyUpWADVQpGg = 0;
							return this;
						}
						return new uOhHiPZMFQHQAvFKiAGkIDQbSnKQA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class NtyIJOFJjzJsRUAApCWsQnjEXIyE : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int BakElPIyLonVqEpQUfPEvVQhxSyW;

					private ControllerPollingInfo wgFMjqUovrBGDGSZsFcESsPMAfxBA;

					private int qRSawNtYuURKdUCRMNQduMkllfsl;

					private IList<CustomController> rVlopcUOVwctJjrCCVKFUvYSoSyQA;

					private int SaLQQxRMTgDajvvRDgbQKiejkijQ;

					private IEnumerator<ControllerPollingInfo> KmCmlePlGoaInxFnesNxQgmYzqvv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return wgFMjqUovrBGDGSZsFcESsPMAfxBA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wgFMjqUovrBGDGSZsFcESsPMAfxBA;
						}
					}

					[DebuggerHidden]
					public NtyIJOFJjzJsRUAApCWsQnjEXIyE(int P_0)
					{
						BakElPIyLonVqEpQUfPEvVQhxSyW = P_0;
						qRSawNtYuURKdUCRMNQduMkllfsl = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int bakElPIyLonVqEpQUfPEvVQhxSyW = BakElPIyLonVqEpQUfPEvVQhxSyW;
						if (bakElPIyLonVqEpQUfPEvVQhxSyW == -3 || bakElPIyLonVqEpQUfPEvVQhxSyW == 1)
						{
							try
							{
							}
							finally
							{
								QIPWQPMwqOExposhNalmAtPItXAn();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int bakElPIyLonVqEpQUfPEvVQhxSyW = BakElPIyLonVqEpQUfPEvVQhxSyW;
							if (bakElPIyLonVqEpQUfPEvVQhxSyW != 0)
							{
								if (bakElPIyLonVqEpQUfPEvVQhxSyW != 1)
								{
									return false;
								}
								BakElPIyLonVqEpQUfPEvVQhxSyW = -3;
								goto IL_0086;
							}
							BakElPIyLonVqEpQUfPEvVQhxSyW = -1;
							rVlopcUOVwctJjrCCVKFUvYSoSyQA = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
							SaLQQxRMTgDajvvRDgbQKiejkijQ = 0;
							goto IL_00b0;
							IL_0086:
							if (KmCmlePlGoaInxFnesNxQgmYzqvv.MoveNext())
							{
								ControllerPollingInfo current = KmCmlePlGoaInxFnesNxQgmYzqvv.Current;
								wgFMjqUovrBGDGSZsFcESsPMAfxBA = current;
								BakElPIyLonVqEpQUfPEvVQhxSyW = 1;
								return true;
							}
							QIPWQPMwqOExposhNalmAtPItXAn();
							KmCmlePlGoaInxFnesNxQgmYzqvv = null;
							SaLQQxRMTgDajvvRDgbQKiejkijQ++;
							goto IL_00b0;
							IL_00b0:
							if (SaLQQxRMTgDajvvRDgbQKiejkijQ < rVlopcUOVwctJjrCCVKFUvYSoSyQA.Count)
							{
								KmCmlePlGoaInxFnesNxQgmYzqvv = rVlopcUOVwctJjrCCVKFUvYSoSyQA[SaLQQxRMTgDajvvRDgbQKiejkijQ].PollForAllElements().GetEnumerator();
								BakElPIyLonVqEpQUfPEvVQhxSyW = -3;
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

					private void QIPWQPMwqOExposhNalmAtPItXAn()
					{
						BakElPIyLonVqEpQUfPEvVQhxSyW = -1;
						if (KmCmlePlGoaInxFnesNxQgmYzqvv != null)
						{
							KmCmlePlGoaInxFnesNxQgmYzqvv.Dispose();
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
						if (BakElPIyLonVqEpQUfPEvVQhxSyW == -2 && qRSawNtYuURKdUCRMNQduMkllfsl == Environment.CurrentManagedThreadId)
						{
							BakElPIyLonVqEpQUfPEvVQhxSyW = 0;
							return this;
						}
						return new NtyIJOFJjzJsRUAApCWsQnjEXIyE(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class fyylEMOYfLtqLvLtMOdpRyaIeoSA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int RCdbHNGxVsgJNPQcoOSHBklaLaGuB;

					private ControllerPollingInfo qgwkSgGnMrMTvaJsJaUBWUNXfaDu;

					private int jEJqVwbunTrhyjMycghbnBdwqzSU;

					private IList<CustomController> oWKDQcjjQjXFfIyFXrYfFPZxOOEC;

					private int mBbWsJwtWOqDGxtdtLLaRehKIJJKA;

					private IEnumerator<ControllerPollingInfo> NstkWuULJdNswbcJfEYGMZxgJkti;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return qgwkSgGnMrMTvaJsJaUBWUNXfaDu;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qgwkSgGnMrMTvaJsJaUBWUNXfaDu;
						}
					}

					[DebuggerHidden]
					public fyylEMOYfLtqLvLtMOdpRyaIeoSA(int P_0)
					{
						RCdbHNGxVsgJNPQcoOSHBklaLaGuB = P_0;
						jEJqVwbunTrhyjMycghbnBdwqzSU = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int rCdbHNGxVsgJNPQcoOSHBklaLaGuB = RCdbHNGxVsgJNPQcoOSHBklaLaGuB;
						if (rCdbHNGxVsgJNPQcoOSHBklaLaGuB == -3 || rCdbHNGxVsgJNPQcoOSHBklaLaGuB == 1)
						{
							try
							{
							}
							finally
							{
								ZifmjaxPSqoQBUXReBbQLWnSMyIg();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int rCdbHNGxVsgJNPQcoOSHBklaLaGuB = RCdbHNGxVsgJNPQcoOSHBklaLaGuB;
							if (rCdbHNGxVsgJNPQcoOSHBklaLaGuB != 0)
							{
								if (rCdbHNGxVsgJNPQcoOSHBklaLaGuB != 1)
								{
									return false;
								}
								RCdbHNGxVsgJNPQcoOSHBklaLaGuB = -3;
								goto IL_0086;
							}
							RCdbHNGxVsgJNPQcoOSHBklaLaGuB = -1;
							oWKDQcjjQjXFfIyFXrYfFPZxOOEC = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
							mBbWsJwtWOqDGxtdtLLaRehKIJJKA = 0;
							goto IL_00b0;
							IL_0086:
							if (NstkWuULJdNswbcJfEYGMZxgJkti.MoveNext())
							{
								ControllerPollingInfo current = NstkWuULJdNswbcJfEYGMZxgJkti.Current;
								qgwkSgGnMrMTvaJsJaUBWUNXfaDu = current;
								RCdbHNGxVsgJNPQcoOSHBklaLaGuB = 1;
								return true;
							}
							ZifmjaxPSqoQBUXReBbQLWnSMyIg();
							NstkWuULJdNswbcJfEYGMZxgJkti = null;
							mBbWsJwtWOqDGxtdtLLaRehKIJJKA++;
							goto IL_00b0;
							IL_00b0:
							if (mBbWsJwtWOqDGxtdtLLaRehKIJJKA < oWKDQcjjQjXFfIyFXrYfFPZxOOEC.Count)
							{
								NstkWuULJdNswbcJfEYGMZxgJkti = oWKDQcjjQjXFfIyFXrYfFPZxOOEC[mBbWsJwtWOqDGxtdtLLaRehKIJJKA].PollForAllElementsDown().GetEnumerator();
								RCdbHNGxVsgJNPQcoOSHBklaLaGuB = -3;
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

					private void ZifmjaxPSqoQBUXReBbQLWnSMyIg()
					{
						RCdbHNGxVsgJNPQcoOSHBklaLaGuB = -1;
						if (NstkWuULJdNswbcJfEYGMZxgJkti != null)
						{
							NstkWuULJdNswbcJfEYGMZxgJkti.Dispose();
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
						if (RCdbHNGxVsgJNPQcoOSHBklaLaGuB == -2 && jEJqVwbunTrhyjMycghbnBdwqzSU == Environment.CurrentManagedThreadId)
						{
							RCdbHNGxVsgJNPQcoOSHBklaLaGuB = 0;
							return this;
						}
						return new fyylEMOYfLtqLvLtMOdpRyaIeoSA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class hBwvWomGaDPgNSTZJuxRbpQHtMsk : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int EWAlgmBljbjLgrhjgbVjwRIfcqUY;

					private ControllerPollingInfo TcyCMgDzMTPAnfdjgVekHCXBXogNA;

					private int TCYgZgNTeXCsDsiZuFYbAxZiQNrw;

					private IList<Joystick> htJfXlZhrKiWPZSpNgbSpiArnMDU;

					private int CTLMfuUshKUUqgxMwMeGwjuxbpnG;

					private IEnumerator<ControllerPollingInfo> PVKDiwOOUkytGJudTMlEhGKAhBegA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return TcyCMgDzMTPAnfdjgVekHCXBXogNA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TcyCMgDzMTPAnfdjgVekHCXBXogNA;
						}
					}

					[DebuggerHidden]
					public hBwvWomGaDPgNSTZJuxRbpQHtMsk(int P_0)
					{
						EWAlgmBljbjLgrhjgbVjwRIfcqUY = P_0;
						TCYgZgNTeXCsDsiZuFYbAxZiQNrw = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int eWAlgmBljbjLgrhjgbVjwRIfcqUY = EWAlgmBljbjLgrhjgbVjwRIfcqUY;
						if (eWAlgmBljbjLgrhjgbVjwRIfcqUY == -3 || eWAlgmBljbjLgrhjgbVjwRIfcqUY == 1)
						{
							try
							{
							}
							finally
							{
								KeRebRKSEAguBFOLVKAtufVLGPzS();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int eWAlgmBljbjLgrhjgbVjwRIfcqUY = EWAlgmBljbjLgrhjgbVjwRIfcqUY;
							if (eWAlgmBljbjLgrhjgbVjwRIfcqUY != 0)
							{
								if (eWAlgmBljbjLgrhjgbVjwRIfcqUY != 1)
								{
									return false;
								}
								EWAlgmBljbjLgrhjgbVjwRIfcqUY = -3;
								goto IL_0086;
							}
							EWAlgmBljbjLgrhjgbVjwRIfcqUY = -1;
							htJfXlZhrKiWPZSpNgbSpiArnMDU = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
							CTLMfuUshKUUqgxMwMeGwjuxbpnG = 0;
							goto IL_00b0;
							IL_0086:
							if (PVKDiwOOUkytGJudTMlEhGKAhBegA.MoveNext())
							{
								ControllerPollingInfo current = PVKDiwOOUkytGJudTMlEhGKAhBegA.Current;
								TcyCMgDzMTPAnfdjgVekHCXBXogNA = current;
								EWAlgmBljbjLgrhjgbVjwRIfcqUY = 1;
								return true;
							}
							KeRebRKSEAguBFOLVKAtufVLGPzS();
							PVKDiwOOUkytGJudTMlEhGKAhBegA = null;
							CTLMfuUshKUUqgxMwMeGwjuxbpnG++;
							goto IL_00b0;
							IL_00b0:
							if (CTLMfuUshKUUqgxMwMeGwjuxbpnG < htJfXlZhrKiWPZSpNgbSpiArnMDU.Count)
							{
								PVKDiwOOUkytGJudTMlEhGKAhBegA = htJfXlZhrKiWPZSpNgbSpiArnMDU[CTLMfuUshKUUqgxMwMeGwjuxbpnG].PollForAllAxes().GetEnumerator();
								EWAlgmBljbjLgrhjgbVjwRIfcqUY = -3;
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

					private void KeRebRKSEAguBFOLVKAtufVLGPzS()
					{
						EWAlgmBljbjLgrhjgbVjwRIfcqUY = -1;
						if (PVKDiwOOUkytGJudTMlEhGKAhBegA != null)
						{
							PVKDiwOOUkytGJudTMlEhGKAhBegA.Dispose();
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
						if (EWAlgmBljbjLgrhjgbVjwRIfcqUY == -2 && TCYgZgNTeXCsDsiZuFYbAxZiQNrw == Environment.CurrentManagedThreadId)
						{
							EWAlgmBljbjLgrhjgbVjwRIfcqUY = 0;
							return this;
						}
						return new hBwvWomGaDPgNSTZJuxRbpQHtMsk(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class BlUWqPKtmnvCHJOVNlSnGbGxfOhgA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int cvmcqofmJdSnnLUjatIwmcsiDcipA;

					private ControllerPollingInfo aWMDPrfQVnYtKMUIVeZiSqdKNaLE;

					private int fMchJeDKrauLVWmFDFEaqcxJYciMA;

					private IList<Joystick> XtTgHDHcIWgYDDGcdMiYDNqpuzzNb;

					private int caWAzLMnckOndOURvQDzUSJtGmyI;

					private IEnumerator<ControllerPollingInfo> opzqcGXFMTFDeUkypYtzzrIkOPfb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aWMDPrfQVnYtKMUIVeZiSqdKNaLE;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aWMDPrfQVnYtKMUIVeZiSqdKNaLE;
						}
					}

					[DebuggerHidden]
					public BlUWqPKtmnvCHJOVNlSnGbGxfOhgA(int P_0)
					{
						cvmcqofmJdSnnLUjatIwmcsiDcipA = P_0;
						fMchJeDKrauLVWmFDFEaqcxJYciMA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = cvmcqofmJdSnnLUjatIwmcsiDcipA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								zRaYIVDprmaPIfcizbCqhrZjjUn();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = cvmcqofmJdSnnLUjatIwmcsiDcipA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								cvmcqofmJdSnnLUjatIwmcsiDcipA = -3;
								goto IL_0086;
							}
							cvmcqofmJdSnnLUjatIwmcsiDcipA = -1;
							XtTgHDHcIWgYDDGcdMiYDNqpuzzNb = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
							caWAzLMnckOndOURvQDzUSJtGmyI = 0;
							goto IL_00b0;
							IL_0086:
							if (opzqcGXFMTFDeUkypYtzzrIkOPfb.MoveNext())
							{
								ControllerPollingInfo current = opzqcGXFMTFDeUkypYtzzrIkOPfb.Current;
								aWMDPrfQVnYtKMUIVeZiSqdKNaLE = current;
								cvmcqofmJdSnnLUjatIwmcsiDcipA = 1;
								return true;
							}
							zRaYIVDprmaPIfcizbCqhrZjjUn();
							opzqcGXFMTFDeUkypYtzzrIkOPfb = null;
							caWAzLMnckOndOURvQDzUSJtGmyI++;
							goto IL_00b0;
							IL_00b0:
							if (caWAzLMnckOndOURvQDzUSJtGmyI < XtTgHDHcIWgYDDGcdMiYDNqpuzzNb.Count)
							{
								opzqcGXFMTFDeUkypYtzzrIkOPfb = XtTgHDHcIWgYDDGcdMiYDNqpuzzNb[caWAzLMnckOndOURvQDzUSJtGmyI].PollForAllButtons().GetEnumerator();
								cvmcqofmJdSnnLUjatIwmcsiDcipA = -3;
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

					private void zRaYIVDprmaPIfcizbCqhrZjjUn()
					{
						cvmcqofmJdSnnLUjatIwmcsiDcipA = -1;
						if (opzqcGXFMTFDeUkypYtzzrIkOPfb != null)
						{
							opzqcGXFMTFDeUkypYtzzrIkOPfb.Dispose();
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
						if (cvmcqofmJdSnnLUjatIwmcsiDcipA == -2 && fMchJeDKrauLVWmFDFEaqcxJYciMA == Environment.CurrentManagedThreadId)
						{
							cvmcqofmJdSnnLUjatIwmcsiDcipA = 0;
							return this;
						}
						return new BlUWqPKtmnvCHJOVNlSnGbGxfOhgA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class kCIwGxqspbajwWcnOChLgrSnvsqpA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int yeQvcsZpdolmAqbPXOgUswHHkmbh;

					private ControllerPollingInfo aYubSscHfLpzZKeyRmkOjIgQVuSWA;

					private int YrYlfDjHQTuVvWrdRdKQJLvVCTid;

					private IList<Joystick> InaSeQYTqULYxMPYcSVrJmuEUEeE;

					private int oBxJIiCOnHkfPDcSTPlakCAFGakQ;

					private IEnumerator<ControllerPollingInfo> jDhvSthrQKhlLtcrYucOVniQVUAJ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return aYubSscHfLpzZKeyRmkOjIgQVuSWA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return aYubSscHfLpzZKeyRmkOjIgQVuSWA;
						}
					}

					[DebuggerHidden]
					public kCIwGxqspbajwWcnOChLgrSnvsqpA(int P_0)
					{
						yeQvcsZpdolmAqbPXOgUswHHkmbh = P_0;
						YrYlfDjHQTuVvWrdRdKQJLvVCTid = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = yeQvcsZpdolmAqbPXOgUswHHkmbh;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								hRYAHUKKnJDReZpCTUcMDmWNXAFc();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = yeQvcsZpdolmAqbPXOgUswHHkmbh;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								yeQvcsZpdolmAqbPXOgUswHHkmbh = -3;
								goto IL_0086;
							}
							yeQvcsZpdolmAqbPXOgUswHHkmbh = -1;
							InaSeQYTqULYxMPYcSVrJmuEUEeE = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
							oBxJIiCOnHkfPDcSTPlakCAFGakQ = 0;
							goto IL_00b0;
							IL_0086:
							if (jDhvSthrQKhlLtcrYucOVniQVUAJ.MoveNext())
							{
								ControllerPollingInfo current = jDhvSthrQKhlLtcrYucOVniQVUAJ.Current;
								aYubSscHfLpzZKeyRmkOjIgQVuSWA = current;
								yeQvcsZpdolmAqbPXOgUswHHkmbh = 1;
								return true;
							}
							hRYAHUKKnJDReZpCTUcMDmWNXAFc();
							jDhvSthrQKhlLtcrYucOVniQVUAJ = null;
							oBxJIiCOnHkfPDcSTPlakCAFGakQ++;
							goto IL_00b0;
							IL_00b0:
							if (oBxJIiCOnHkfPDcSTPlakCAFGakQ < InaSeQYTqULYxMPYcSVrJmuEUEeE.Count)
							{
								jDhvSthrQKhlLtcrYucOVniQVUAJ = InaSeQYTqULYxMPYcSVrJmuEUEeE[oBxJIiCOnHkfPDcSTPlakCAFGakQ].PollForAllButtonsDown().GetEnumerator();
								yeQvcsZpdolmAqbPXOgUswHHkmbh = -3;
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

					private void hRYAHUKKnJDReZpCTUcMDmWNXAFc()
					{
						yeQvcsZpdolmAqbPXOgUswHHkmbh = -1;
						if (jDhvSthrQKhlLtcrYucOVniQVUAJ != null)
						{
							jDhvSthrQKhlLtcrYucOVniQVUAJ.Dispose();
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
						if (yeQvcsZpdolmAqbPXOgUswHHkmbh == -2 && YrYlfDjHQTuVvWrdRdKQJLvVCTid == Environment.CurrentManagedThreadId)
						{
							yeQvcsZpdolmAqbPXOgUswHHkmbh = 0;
							return this;
						}
						return new kCIwGxqspbajwWcnOChLgrSnvsqpA(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class MyOaFKBJlTzJyGmnBSzNDbZARnGN : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ZbTBoRlMkRHWxvhVvziAruRBMRr;

					private ControllerPollingInfo FHrIIXynOMtqkSyyGnWUrsOMyJZD;

					private int haOWxrbsjeSBXlvgOnusZaphEtZq;

					private IList<Joystick> rLORBrGFWVcIoCmXFLVeQwrmQzdLA;

					private int FGVbhThteDrIufbRJtEfNkXgiJGec;

					private IEnumerator<ControllerPollingInfo> faDbfUeaYuEgAtklJFyLRsPIKBnAA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return FHrIIXynOMtqkSyyGnWUrsOMyJZD;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return FHrIIXynOMtqkSyyGnWUrsOMyJZD;
						}
					}

					[DebuggerHidden]
					public MyOaFKBJlTzJyGmnBSzNDbZARnGN(int P_0)
					{
						ZbTBoRlMkRHWxvhVvziAruRBMRr = P_0;
						haOWxrbsjeSBXlvgOnusZaphEtZq = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int zbTBoRlMkRHWxvhVvziAruRBMRr = ZbTBoRlMkRHWxvhVvziAruRBMRr;
						if (zbTBoRlMkRHWxvhVvziAruRBMRr == -3 || zbTBoRlMkRHWxvhVvziAruRBMRr == 1)
						{
							try
							{
							}
							finally
							{
								phUdgxsaqrjxytHARNiIqWdUFHPJ();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int zbTBoRlMkRHWxvhVvziAruRBMRr = ZbTBoRlMkRHWxvhVvziAruRBMRr;
							if (zbTBoRlMkRHWxvhVvziAruRBMRr != 0)
							{
								if (zbTBoRlMkRHWxvhVvziAruRBMRr != 1)
								{
									return false;
								}
								ZbTBoRlMkRHWxvhVvziAruRBMRr = -3;
								goto IL_0086;
							}
							ZbTBoRlMkRHWxvhVvziAruRBMRr = -1;
							rLORBrGFWVcIoCmXFLVeQwrmQzdLA = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
							FGVbhThteDrIufbRJtEfNkXgiJGec = 0;
							goto IL_00b0;
							IL_0086:
							if (faDbfUeaYuEgAtklJFyLRsPIKBnAA.MoveNext())
							{
								ControllerPollingInfo current = faDbfUeaYuEgAtklJFyLRsPIKBnAA.Current;
								FHrIIXynOMtqkSyyGnWUrsOMyJZD = current;
								ZbTBoRlMkRHWxvhVvziAruRBMRr = 1;
								return true;
							}
							phUdgxsaqrjxytHARNiIqWdUFHPJ();
							faDbfUeaYuEgAtklJFyLRsPIKBnAA = null;
							FGVbhThteDrIufbRJtEfNkXgiJGec++;
							goto IL_00b0;
							IL_00b0:
							if (FGVbhThteDrIufbRJtEfNkXgiJGec < rLORBrGFWVcIoCmXFLVeQwrmQzdLA.Count)
							{
								faDbfUeaYuEgAtklJFyLRsPIKBnAA = rLORBrGFWVcIoCmXFLVeQwrmQzdLA[FGVbhThteDrIufbRJtEfNkXgiJGec].PollForAllElements().GetEnumerator();
								ZbTBoRlMkRHWxvhVvziAruRBMRr = -3;
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

					private void phUdgxsaqrjxytHARNiIqWdUFHPJ()
					{
						ZbTBoRlMkRHWxvhVvziAruRBMRr = -1;
						if (faDbfUeaYuEgAtklJFyLRsPIKBnAA != null)
						{
							faDbfUeaYuEgAtklJFyLRsPIKBnAA.Dispose();
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
						if (ZbTBoRlMkRHWxvhVvziAruRBMRr == -2 && haOWxrbsjeSBXlvgOnusZaphEtZq == Environment.CurrentManagedThreadId)
						{
							ZbTBoRlMkRHWxvhVvziAruRBMRr = 0;
							return this;
						}
						return new MyOaFKBJlTzJyGmnBSzNDbZARnGN(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class AGRQoOpkmbHZYGLFkSruXDyBLODgb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int XQYbxCqRPTNfPXSESgjQnqNsJsec;

					private ControllerPollingInfo UtvyunnSBxCAhoynbVHovtVKTZAU;

					private int PQKeXdGbLTCyszsxcwtBtJCPnClj;

					private IList<Joystick> AQHuPKIQpuPXYcSLhcuKGXRPetZs;

					private int ArzleTLrtdUpCcKkqrienIlScIGU;

					private IEnumerator<ControllerPollingInfo> mHZcsajrvOqugFOxWqZYGZLmnnnBb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return UtvyunnSBxCAhoynbVHovtVKTZAU;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return UtvyunnSBxCAhoynbVHovtVKTZAU;
						}
					}

					[DebuggerHidden]
					public AGRQoOpkmbHZYGLFkSruXDyBLODgb(int P_0)
					{
						XQYbxCqRPTNfPXSESgjQnqNsJsec = P_0;
						PQKeXdGbLTCyszsxcwtBtJCPnClj = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int xQYbxCqRPTNfPXSESgjQnqNsJsec = XQYbxCqRPTNfPXSESgjQnqNsJsec;
						if (xQYbxCqRPTNfPXSESgjQnqNsJsec == -3 || xQYbxCqRPTNfPXSESgjQnqNsJsec == 1)
						{
							try
							{
							}
							finally
							{
								mSFcLptrojMLRLJukALgwiAVWkwT();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int xQYbxCqRPTNfPXSESgjQnqNsJsec = XQYbxCqRPTNfPXSESgjQnqNsJsec;
							if (xQYbxCqRPTNfPXSESgjQnqNsJsec != 0)
							{
								if (xQYbxCqRPTNfPXSESgjQnqNsJsec != 1)
								{
									return false;
								}
								XQYbxCqRPTNfPXSESgjQnqNsJsec = -3;
								goto IL_0086;
							}
							XQYbxCqRPTNfPXSESgjQnqNsJsec = -1;
							AQHuPKIQpuPXYcSLhcuKGXRPetZs = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
							ArzleTLrtdUpCcKkqrienIlScIGU = 0;
							goto IL_00b0;
							IL_0086:
							if (mHZcsajrvOqugFOxWqZYGZLmnnnBb.MoveNext())
							{
								ControllerPollingInfo current = mHZcsajrvOqugFOxWqZYGZLmnnnBb.Current;
								UtvyunnSBxCAhoynbVHovtVKTZAU = current;
								XQYbxCqRPTNfPXSESgjQnqNsJsec = 1;
								return true;
							}
							mSFcLptrojMLRLJukALgwiAVWkwT();
							mHZcsajrvOqugFOxWqZYGZLmnnnBb = null;
							ArzleTLrtdUpCcKkqrienIlScIGU++;
							goto IL_00b0;
							IL_00b0:
							if (ArzleTLrtdUpCcKkqrienIlScIGU < AQHuPKIQpuPXYcSLhcuKGXRPetZs.Count)
							{
								mHZcsajrvOqugFOxWqZYGZLmnnnBb = AQHuPKIQpuPXYcSLhcuKGXRPetZs[ArzleTLrtdUpCcKkqrienIlScIGU].PollForAllElementsDown().GetEnumerator();
								XQYbxCqRPTNfPXSESgjQnqNsJsec = -3;
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

					private void mSFcLptrojMLRLJukALgwiAVWkwT()
					{
						XQYbxCqRPTNfPXSESgjQnqNsJsec = -1;
						if (mHZcsajrvOqugFOxWqZYGZLmnnnBb != null)
						{
							mHZcsajrvOqugFOxWqZYGZLmnnnBb.Dispose();
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
						if (XQYbxCqRPTNfPXSESgjQnqNsJsec == -2 && PQKeXdGbLTCyszsxcwtBtJCPnClj == Environment.CurrentManagedThreadId)
						{
							XQYbxCqRPTNfPXSESgjQnqNsJsec = 0;
							return this;
						}
						return new AGRQoOpkmbHZYGLFkSruXDyBLODgb(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private static PollingHelper mZcjuJLpKkCPDiCaDmhxUxyfUkvG;

				internal static PollingHelper thWgkJSONtUsWEQtXpLdpkKitAts => mZcjuJLpKkCPDiCaDmhxUxyfUkvG ?? (mZcjuJLpKkCPDiCaDmhxUxyfUkvG = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					ControllerPollingInfo result = ZIizhMqPNNAxAaQPDIQJyIadsuYlA();
					if (result.success)
					{
						return result;
					}
					result = vCMRZliKMeFOOLrmFsKocOiSoMPj();
					if (result.success)
					{
						return result;
					}
					result = jkjkoMMIQLyYJqLYJtgPZtzHpczw();
					if (result.success)
					{
						return result;
					}
					result = sHXtBOawTaRXENdcisEBEAxuJWHc();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					ControllerPollingInfo result = vRlEuPCZzjJfKiXEOWciioSOuzpFA();
					if (result.success)
					{
						return result;
					}
					result = TBXULABiTPMXPpRZsmJifJsQGurB();
					if (result.success)
					{
						return result;
					}
					result = plbrHYQQuKwcqAsihpnxXBnbSarj();
					if (result.success)
					{
						return result;
					}
					result = wArXJbDVsmupAXUUmqrkGGhVqhvl();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					ControllerPollingInfo result = MAgLIhqTORdKjxbZckCxADEFZyYL();
					if (result.success)
					{
						return result;
					}
					result = vCMRZliKMeFOOLrmFsKocOiSoMPj();
					if (result.success)
					{
						return result;
					}
					result = KtwfCVczXGlBDWYCrWAhXqBsgllb();
					if (result.success)
					{
						return result;
					}
					result = nmRoEHWbaIvBruItjOQJsnUjGhgE();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					ControllerPollingInfo result = vwlXFcSfNDizexQACBdDLDedAwNP();
					if (result.success)
					{
						return result;
					}
					result = TBXULABiTPMXPpRZsmJifJsQGurB();
					if (result.success)
					{
						return result;
					}
					result = pwuDpePjWAwsEUUEfafJejfWwPbq();
					if (result.success)
					{
						return result;
					}
					result = PssTChxoNnSSfXbisOYovOtJqLTi();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					ControllerPollingInfo result = kRhIySkipHdRlyIyNbnWTtdkuIVI();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					if (result.success)
					{
						return result;
					}
					result = HVuCrqfMYLAisikONjDhYjFBdtqgA();
					if (result.success)
					{
						return result;
					}
					result = lpPLmsTMnWkcKfGcUPmuTlGpaJAF();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => ZIizhMqPNNAxAaQPDIQJyIadsuYlA(), 
						ControllerType.Keyboard => vCMRZliKMeFOOLrmFsKocOiSoMPj(), 
						ControllerType.Mouse => jkjkoMMIQLyYJqLYJtgPZtzHpczw(), 
						ControllerType.Custom => sHXtBOawTaRXENdcisEBEAxuJWHc(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => vRlEuPCZzjJfKiXEOWciioSOuzpFA(), 
						ControllerType.Keyboard => TBXULABiTPMXPpRZsmJifJsQGurB(), 
						ControllerType.Mouse => plbrHYQQuKwcqAsihpnxXBnbSarj(), 
						ControllerType.Custom => wArXJbDVsmupAXUUmqrkGGhVqhvl(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => MAgLIhqTORdKjxbZckCxADEFZyYL(), 
						ControllerType.Keyboard => vCMRZliKMeFOOLrmFsKocOiSoMPj(), 
						ControllerType.Mouse => KtwfCVczXGlBDWYCrWAhXqBsgllb(), 
						ControllerType.Custom => nmRoEHWbaIvBruItjOQJsnUjGhgE(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => vwlXFcSfNDizexQACBdDLDedAwNP(), 
						ControllerType.Keyboard => TBXULABiTPMXPpRZsmJifJsQGurB(), 
						ControllerType.Mouse => pwuDpePjWAwsEUUEfafJejfWwPbq(), 
						ControllerType.Custom => PssTChxoNnSSfXbisOYovOtJqLTi(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => kRhIySkipHdRlyIyNbnWTtdkuIVI(), 
						ControllerType.Keyboard => ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd(), 
						ControllerType.Mouse => HVuCrqfMYLAisikONjDhYjFBdtqgA(), 
						ControllerType.Custom => lpPLmsTMnWkcKfGcUPmuTlGpaJAF(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => BeNFeEpeoRrjQGEjNqZaBPiIzhdK(controllerId), 
						ControllerType.Keyboard => vCMRZliKMeFOOLrmFsKocOiSoMPj(), 
						ControllerType.Mouse => jkjkoMMIQLyYJqLYJtgPZtzHpczw(), 
						ControllerType.Custom => oxRRApEYlqmBAsNvTEfXokJqWEHV(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => GMYpOWdariSxxKuJeelUInudkiAH(controllerId), 
						ControllerType.Keyboard => TBXULABiTPMXPpRZsmJifJsQGurB(), 
						ControllerType.Mouse => plbrHYQQuKwcqAsihpnxXBnbSarj(), 
						ControllerType.Custom => crfsTROCjfvVGakhQHCBfLXfPdvG(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => rrfYfldCMrzkvcZqgahTVgNXYoPB(controllerId), 
						ControllerType.Keyboard => vCMRZliKMeFOOLrmFsKocOiSoMPj(), 
						ControllerType.Mouse => KtwfCVczXGlBDWYCrWAhXqBsgllb(), 
						ControllerType.Custom => UiphEDWniqnmjWcgtZsMKIXmrChQ(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => XTfcsOHqozaCunuGqvXlIwlgedjK(controllerId), 
						ControllerType.Keyboard => TBXULABiTPMXPpRZsmJifJsQGurB(), 
						ControllerType.Mouse => pwuDpePjWAwsEUUEfafJejfWwPbq(), 
						ControllerType.Custom => WGwaSFbBLkOVxGyuNlbaUEYcOFSB(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
					}
					return controllerType switch
					{
						ControllerType.Joystick => XhlwLQuhveTsujumwGzswTIMctrE(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd(), 
						ControllerType.Mouse => HVuCrqfMYLAisikONjDhYjFBdtqgA(), 
						ControllerType.Custom => DGIEXVEpZpidsEDbQdJqkibyocEfb(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				[IteratorStateMachine(typeof(fPRzjyTrMdLcfuLMyUJgqlKHCFjz))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return new fPRzjyTrMdLcfuLMyUJgqlKHCFjz(-2)
					{
						dnCqKZVWZvTeIixfEIBOZBuHeIOT = this
					};
				}

				[IteratorStateMachine(typeof(TPWBlcFBDUWGAWbkMxfyZjDTBXkI))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return new TPWBlcFBDUWGAWbkMxfyZjDTBXkI(-2)
					{
						AhpIZochpqySVRAyWlffGIImVPHI = this
					};
				}

				[IteratorStateMachine(typeof(cqzSBUGEXxBFdOiMfxOECKLUFbjt))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return new cqzSBUGEXxBFdOiMfxOECKLUFbjt(-2)
					{
						rqvEHVKiaSpfMwbZcOIVFqOCccRh = this
					};
				}

				[IteratorStateMachine(typeof(ioKecCEQrykkoVhuvezJufAXJhso))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return new ioKecCEQrykkoVhuvezJufAXJhso(-2)
					{
						DqOcQIRrcUcDohbEJIbEPLLzgvnyA = this
					};
				}

				[IteratorStateMachine(typeof(WSIZGXzGKeslCgcxwdpXCyfVCtQK))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return new WSIZGXzGKeslCgcxwdpXCyfVCtQK(-2)
					{
						mDHKsCoNoUjKXFofHRKMXvnHmXyE = this
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
						ControllerType.Joystick => BdAmaSJKgqNBVRhGkXRGwqbdFJrDA(controllerId), 
						ControllerType.Keyboard => NlXsvxRnrRFilgFLEJALyrLdnzGE(), 
						ControllerType.Mouse => NKVSoGlMbHAlcVIhaVriQeuOfkweA(), 
						ControllerType.Custom => nppnGDMoAfZmpoWMDkCxNydoLLCl(controllerId), 
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
						ControllerType.Joystick => tldyfUZYfCBQwyfvkrpeAUmvsMQh(controllerId), 
						ControllerType.Keyboard => azstpdDOHRwdpmAiUMJbJwzHgkiy(), 
						ControllerType.Mouse => DePWBnTLnjZRSBJTFtBZsrODIFAB(), 
						ControllerType.Custom => EevWBSerhqLeLZezAZZjrVscSOMB(controllerId), 
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
						ControllerType.Joystick => VLWOXjVztdYfqMjspQgfMbFokxJS(controllerId), 
						ControllerType.Keyboard => NlXsvxRnrRFilgFLEJALyrLdnzGE(), 
						ControllerType.Mouse => buHAgOMPBNFnEgCyYkkwQNcTqNcyA(), 
						ControllerType.Custom => VJiHQoZSNwUIGIiEcOeEXBeVPhR(controllerId), 
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
						ControllerType.Joystick => RTHtRnagDecSUnbzrameIbKqtMxTA(controllerId), 
						ControllerType.Keyboard => azstpdDOHRwdpmAiUMJbJwzHgkiy(), 
						ControllerType.Mouse => RYEcTpDwiGljDUEBGiNKHIFNQNdbA(), 
						ControllerType.Custom => NnYyVkRcjmbfShciCQwkPcMgDEvE(controllerId), 
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
						ControllerType.Joystick => ZWXbcRqdnoJttgTKrPvPNcKzEQQZ(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => UwaZMCTqiRTaorFEOOrYwqtadZRbA(), 
						ControllerType.Custom => IJFziHQmJIIYEayguJKhoqDtRPdyA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo ZIizhMqPNNAxAaQPDIQJyIadsuYlA()
				{
					IList<Joystick> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo vRlEuPCZzjJfKiXEOWciioSOuzpFA()
				{
					IList<Joystick> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo MAgLIhqTORdKjxbZckCxADEFZyYL()
				{
					IList<Joystick> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo vwlXFcSfNDizexQACBdDLDedAwNP()
				{
					IList<Joystick> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo kRhIySkipHdRlyIyNbnWTtdkuIVI()
				{
					IList<Joystick> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo BeNFeEpeoRrjQGEjNqZaBPiIzhdK(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo GMYpOWdariSxxKuJeelUInudkiAH(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo rrfYfldCMrzkvcZqgahTVgNXYoPB(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo XTfcsOHqozaCunuGqvXlIwlgedjK(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo XhlwLQuhveTsujumwGzswTIMctrE(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo vCMRZliKMeFOOLrmFsKocOiSoMPj()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo TBXULABiTPMXPpRZsmJifJsQGurB()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo jkjkoMMIQLyYJqLYJtgPZtzHpczw()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo plbrHYQQuKwcqAsihpnxXBnbSarj()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo KtwfCVczXGlBDWYCrWAhXqBsgllb()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo pwuDpePjWAwsEUUEfafJejfWwPbq()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo HVuCrqfMYLAisikONjDhYjFBdtqgA()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo sHXtBOawTaRXENdcisEBEAxuJWHc()
				{
					IList<CustomController> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo wArXJbDVsmupAXUUmqrkGGhVqhvl()
				{
					IList<CustomController> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo nmRoEHWbaIvBruItjOQJsnUjGhgE()
				{
					IList<CustomController> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo PssTChxoNnSSfXbisOYovOtJqLTi()
				{
					IList<CustomController> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo lpPLmsTMnWkcKfGcUPmuTlGpaJAF()
				{
					IList<CustomController> list = WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo oxRRApEYlqmBAsNvTEfXokJqWEHV(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo crfsTROCjfvVGakhQHCBfLXfPdvG(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo UiphEDWniqnmjWcgtZsMKIXmrChQ(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo WGwaSFbBLkOVxGyuNlbaUEYcOFSB(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				private ControllerPollingInfo DGIEXVEpZpidsEDbQdJqkibyocEfb(int P_0)
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
				}

				[IteratorStateMachine(typeof(MyOaFKBJlTzJyGmnBSzNDbZARnGN))]
				private IEnumerable<ControllerPollingInfo> xJHAfqVEbwmBWTJwKkIuGcuBFcnF()
				{
					return new MyOaFKBJlTzJyGmnBSzNDbZARnGN(-2);
				}

				[IteratorStateMachine(typeof(AGRQoOpkmbHZYGLFkSruXDyBLODgb))]
				private IEnumerable<ControllerPollingInfo> hRjZirmgNONEXPGetVTQpFPieoUj()
				{
					return new AGRQoOpkmbHZYGLFkSruXDyBLODgb(-2);
				}

				[IteratorStateMachine(typeof(BlUWqPKtmnvCHJOVNlSnGbGxfOhgA))]
				private IEnumerable<ControllerPollingInfo> qWuuJaTODsDRwczSrExKhsNCfUSL()
				{
					return new BlUWqPKtmnvCHJOVNlSnGbGxfOhgA(-2);
				}

				[IteratorStateMachine(typeof(kCIwGxqspbajwWcnOChLgrSnvsqpA))]
				private IEnumerable<ControllerPollingInfo> dWIVSBSVnEVCgLJofycOnPGowHl()
				{
					return new kCIwGxqspbajwWcnOChLgrSnvsqpA(-2);
				}

				[IteratorStateMachine(typeof(hBwvWomGaDPgNSTZJuxRbpQHtMsk))]
				private IEnumerable<ControllerPollingInfo> OPrLeygLgdYIMCJptiprRKtKGwREA()
				{
					return new hBwvWomGaDPgNSTZJuxRbpQHtMsk(-2);
				}

				private IEnumerable<ControllerPollingInfo> BdAmaSJKgqNBVRhGkXRGwqbdFJrDA(int P_0)
				{
					Joystick joystick = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> tldyfUZYfCBQwyfvkrpeAUmvsMQh(int P_0)
				{
					Joystick joystick = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> VLWOXjVztdYfqMjspQgfMbFokxJS(int P_0)
				{
					Joystick joystick = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> RTHtRnagDecSUnbzrameIbKqtMxTA(int P_0)
				{
					Joystick joystick = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> ZWXbcRqdnoJttgTKrPvPNcKzEQQZ(int P_0)
				{
					Joystick joystick = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> NlXsvxRnrRFilgFLEJALyrLdnzGE()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> azstpdDOHRwdpmAiUMJbJwzHgkiy()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> NKVSoGlMbHAlcVIhaVriQeuOfkweA()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> DePWBnTLnjZRSBJTFtBZsrODIFAB()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> buHAgOMPBNFnEgCyYkkwQNcTqNcyA()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> RYEcTpDwiGljDUEBGiNKHIFNQNdbA()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> UwaZMCTqiRTaorFEOOrYwqtadZRbA()
				{
					return CsuKbPMYYdIqXzlzPdNxFQOpARmdA.Mouse.PollForAllAxes();
				}

				[IteratorStateMachine(typeof(NtyIJOFJjzJsRUAApCWsQnjEXIyE))]
				private IEnumerable<ControllerPollingInfo> BtzTyEZapEmuaYLapwhZoqgPBXyBA()
				{
					return new NtyIJOFJjzJsRUAApCWsQnjEXIyE(-2);
				}

				[IteratorStateMachine(typeof(fyylEMOYfLtqLvLtMOdpRyaIeoSA))]
				private IEnumerable<ControllerPollingInfo> LNmyaMxcBNoglkAUrGyogpfFVZVg()
				{
					return new fyylEMOYfLtqLvLtMOdpRyaIeoSA(-2);
				}

				[IteratorStateMachine(typeof(lQYSpDtLIxFbSxXRqACetmDxWuCf))]
				private IEnumerable<ControllerPollingInfo> oiPVIlNGowqixdcYwXbGtJfFOSsb()
				{
					return new lQYSpDtLIxFbSxXRqACetmDxWuCf(-2);
				}

				[IteratorStateMachine(typeof(uOhHiPZMFQHQAvFKiAGkIDQbSnKQA))]
				private IEnumerable<ControllerPollingInfo> ctjgXRSHOQPeVLNLqpDMszUeKYTD()
				{
					return new uOhHiPZMFQHQAvFKiAGkIDQbSnKQA(-2);
				}

				[IteratorStateMachine(typeof(HhRVMIxSiOVtUMnwADyLfELTKiFAA))]
				private IEnumerable<ControllerPollingInfo> QkUzPdZjNVZhJnRFdLCIaDKvZMEN()
				{
					return new HhRVMIxSiOVtUMnwADyLfELTKiFAA(-2);
				}

				private IEnumerable<ControllerPollingInfo> nppnGDMoAfZmpoWMDkCxNydoLLCl(int P_0)
				{
					CustomController customController = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> EevWBSerhqLeLZezAZZjrVscSOMB(int P_0)
				{
					CustomController customController = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> VJiHQoZSNwUIGIiEcOeEXBeVPhR(int P_0)
				{
					CustomController customController = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> NnYyVkRcjmbfShciCQwkPcMgDEvE(int P_0)
				{
					CustomController customController = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> IJFziHQmJIIYEayguJKhoqDtRPdyA(int P_0)
				{
					CustomController customController = CsuKbPMYYdIqXzlzPdNxFQOpARmdA.GetCustomController(P_0);
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
				private sealed class voHFcRLlanJZzESsjcUESBKZoDOn : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int vfaVCUxbakBhSIabGNeSBGnohXkFA;

					private ElementAssignmentConflictInfo VOvBmFyHdeBWWovJcbiUQPKoxzWK;

					private int vSXHgrdgjloJddTsbbrheDpoMTrX;

					private int diFbciFMKJPqSBFYgxGpSeFRtEKj;

					public int xhrDddAkzeqkRGwvMwPuKduSptlh;

					private ActionElementMap aBvdxtDxHsjsvmEmSgvkYgbSbycw;

					public ActionElementMap YAhASlBCshZfYFUgBzmXVUgTMxnA;

					private bool HIpRoTTGKVhPirBpBZNayReBrusN;

					public bool hJnWfiRbIbBYvdEyrUjbanooWynt;

					private int QYjllmJOcsPzssNKKLohLUXvJvmU;

					public int MewLfblKbGrEPZWBYctOvkWpixPL;

					private CustomControllerMap DidBVUoGwpjEwqeVUfUaiOJRkSAc;

					public CustomControllerMap yCKbyeAPmvJxZJyVcAZKwLsorhuTA;

					private bool wrmIbEiqXpOuLsbIsPshsHBGFhDe;

					public bool hitDbUjqOskyNUyozhYjxvGNMVlx;

					private bool lOlOgvXcVqFtbYneMmdJuhJhbPEiA;

					public bool ACYmpgapwtzzMKdemlpZaXlhZKAD;

					private IList<Player> zhfJKOXlrdsZlJQZZqEssXmlCeTS;

					private int PjstLPydUdCnRfmFqTUDZbqBcZfB;

					private IEnumerator<ElementAssignmentConflictInfo> YlNRihqLTTviuPHAiMmBZjUuXlLe;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return VOvBmFyHdeBWWovJcbiUQPKoxzWK;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return VOvBmFyHdeBWWovJcbiUQPKoxzWK;
						}
					}

					[DebuggerHidden]
					public voHFcRLlanJZzESsjcUESBKZoDOn(int P_0)
					{
						vfaVCUxbakBhSIabGNeSBGnohXkFA = P_0;
						vSXHgrdgjloJddTsbbrheDpoMTrX = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = vfaVCUxbakBhSIabGNeSBGnohXkFA;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								wfehuqGFSqGPsUkuMOJXIEkaCDsNA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = vfaVCUxbakBhSIabGNeSBGnohXkFA;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								vfaVCUxbakBhSIabGNeSBGnohXkFA = -3;
								goto IL_00e2;
							}
							vfaVCUxbakBhSIabGNeSBGnohXkFA = -1;
							if (diFbciFMKJPqSBFYgxGpSeFRtEKj < 0 || aBvdxtDxHsjsvmEmSgvkYgbSbycw == null)
							{
								return false;
							}
							zhfJKOXlrdsZlJQZZqEssXmlCeTS = (HIpRoTTGKVhPirBpBZNayReBrusN ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
							PjstLPydUdCnRfmFqTUDZbqBcZfB = 0;
							goto IL_010c;
							IL_010c:
							if (PjstLPydUdCnRfmFqTUDZbqBcZfB < zhfJKOXlrdsZlJQZZqEssXmlCeTS.Count)
							{
								YlNRihqLTTviuPHAiMmBZjUuXlLe = zhfJKOXlrdsZlJQZZqEssXmlCeTS[PjstLPydUdCnRfmFqTUDZbqBcZfB].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, QYjllmJOcsPzssNKKLohLUXvJvmU, DidBVUoGwpjEwqeVUfUaiOJRkSAc, aBvdxtDxHsjsvmEmSgvkYgbSbycw, wrmIbEiqXpOuLsbIsPshsHBGFhDe, lOlOgvXcVqFtbYneMmdJuhJhbPEiA).GetEnumerator();
								vfaVCUxbakBhSIabGNeSBGnohXkFA = -3;
								goto IL_00e2;
							}
							return false;
							IL_00e2:
							if (YlNRihqLTTviuPHAiMmBZjUuXlLe.MoveNext())
							{
								ElementAssignmentConflictInfo current = YlNRihqLTTviuPHAiMmBZjUuXlLe.Current;
								VOvBmFyHdeBWWovJcbiUQPKoxzWK = current;
								vfaVCUxbakBhSIabGNeSBGnohXkFA = 1;
								return true;
							}
							wfehuqGFSqGPsUkuMOJXIEkaCDsNA();
							YlNRihqLTTviuPHAiMmBZjUuXlLe = null;
							PjstLPydUdCnRfmFqTUDZbqBcZfB++;
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

					private void wfehuqGFSqGPsUkuMOJXIEkaCDsNA()
					{
						vfaVCUxbakBhSIabGNeSBGnohXkFA = -1;
						if (YlNRihqLTTviuPHAiMmBZjUuXlLe != null)
						{
							YlNRihqLTTviuPHAiMmBZjUuXlLe.Dispose();
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
						voHFcRLlanJZzESsjcUESBKZoDOn voHFcRLlanJZzESsjcUESBKZoDOn2;
						if (vfaVCUxbakBhSIabGNeSBGnohXkFA == -2 && vSXHgrdgjloJddTsbbrheDpoMTrX == Environment.CurrentManagedThreadId)
						{
							vfaVCUxbakBhSIabGNeSBGnohXkFA = 0;
							voHFcRLlanJZzESsjcUESBKZoDOn2 = this;
						}
						else
						{
							voHFcRLlanJZzESsjcUESBKZoDOn2 = new voHFcRLlanJZzESsjcUESBKZoDOn(0);
						}
						voHFcRLlanJZzESsjcUESBKZoDOn2.diFbciFMKJPqSBFYgxGpSeFRtEKj = xhrDddAkzeqkRGwvMwPuKduSptlh;
						voHFcRLlanJZzESsjcUESBKZoDOn2.QYjllmJOcsPzssNKKLohLUXvJvmU = MewLfblKbGrEPZWBYctOvkWpixPL;
						voHFcRLlanJZzESsjcUESBKZoDOn2.DidBVUoGwpjEwqeVUfUaiOJRkSAc = yCKbyeAPmvJxZJyVcAZKwLsorhuTA;
						voHFcRLlanJZzESsjcUESBKZoDOn2.aBvdxtDxHsjsvmEmSgvkYgbSbycw = YAhASlBCshZfYFUgBzmXVUgTMxnA;
						voHFcRLlanJZzESsjcUESBKZoDOn2.wrmIbEiqXpOuLsbIsPshsHBGFhDe = hitDbUjqOskyNUyozhYjxvGNMVlx;
						voHFcRLlanJZzESsjcUESBKZoDOn2.lOlOgvXcVqFtbYneMmdJuhJhbPEiA = ACYmpgapwtzzMKdemlpZaXlhZKAD;
						voHFcRLlanJZzESsjcUESBKZoDOn2.HIpRoTTGKVhPirBpBZNayReBrusN = hJnWfiRbIbBYvdEyrUjbanooWynt;
						return voHFcRLlanJZzESsjcUESBKZoDOn2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class AptGKLwClAWZpfBsHqkHQQwdbNkU : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int bAJdQfdgcdFxJyeAudAVzDwpoKuG;

					private ElementAssignmentConflictInfo rLpGDnxDhPDcIWpZaufIpBTuOqUr;

					private int AALUGTvpCSGshMwvneLCkZyfTdgZ;

					private ElementAssignmentConflictCheck oTZVZXbgcnrxDkfLhBLyVaOcdJhL;

					public ElementAssignmentConflictCheck WsiXLNBoxIDPHEBaROunscMUBbUd;

					private bool TzycABysLwuTMCIAiKwTFbYekMtg;

					public bool wZUfeIYkrbNgnAHRWQXLrbNtwFQI;

					private bool hPNKqenMUjSwgEgugBgMeBTGZSfi;

					public bool vOiOIhQmqscKEmLGabOOgjKybdtb;

					private bool dpoRszDdUJTBmkkrPQuEOTxRHGbc;

					public bool dnAQDZnvVPchomPkybYRfuRcPCiiA;

					private IList<Player> IpUaakUBwbSWKkbMVokDcHGyGiUHA;

					private int DaQlHMLhZFPorlimwEZFZqauzJqL;

					private IEnumerator<ElementAssignmentConflictInfo> YhTFNeEBzOjeMDPLaRXQOrcckrJHe;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rLpGDnxDhPDcIWpZaufIpBTuOqUr;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rLpGDnxDhPDcIWpZaufIpBTuOqUr;
						}
					}

					[DebuggerHidden]
					public AptGKLwClAWZpfBsHqkHQQwdbNkU(int P_0)
					{
						bAJdQfdgcdFxJyeAudAVzDwpoKuG = P_0;
						AALUGTvpCSGshMwvneLCkZyfTdgZ = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = bAJdQfdgcdFxJyeAudAVzDwpoKuG;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								bzMPyRlTQUPNYQRfPnzdqjqvtwat();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = bAJdQfdgcdFxJyeAudAVzDwpoKuG;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								bAJdQfdgcdFxJyeAudAVzDwpoKuG = -3;
								goto IL_00df;
							}
							bAJdQfdgcdFxJyeAudAVzDwpoKuG = -1;
							if (oTZVZXbgcnrxDkfLhBLyVaOcdJhL.playerId < 0 || oTZVZXbgcnrxDkfLhBLyVaOcdJhL.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							IpUaakUBwbSWKkbMVokDcHGyGiUHA = (TzycABysLwuTMCIAiKwTFbYekMtg ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
							DaQlHMLhZFPorlimwEZFZqauzJqL = 0;
							goto IL_0109;
							IL_0109:
							if (DaQlHMLhZFPorlimwEZFZqauzJqL < IpUaakUBwbSWKkbMVokDcHGyGiUHA.Count)
							{
								YhTFNeEBzOjeMDPLaRXQOrcckrJHe = IpUaakUBwbSWKkbMVokDcHGyGiUHA[DaQlHMLhZFPorlimwEZFZqauzJqL].controllers.conflictChecking.ElementAssignmentConflicts(oTZVZXbgcnrxDkfLhBLyVaOcdJhL, hPNKqenMUjSwgEgugBgMeBTGZSfi, dpoRszDdUJTBmkkrPQuEOTxRHGbc).GetEnumerator();
								bAJdQfdgcdFxJyeAudAVzDwpoKuG = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (YhTFNeEBzOjeMDPLaRXQOrcckrJHe.MoveNext())
							{
								ElementAssignmentConflictInfo current = YhTFNeEBzOjeMDPLaRXQOrcckrJHe.Current;
								rLpGDnxDhPDcIWpZaufIpBTuOqUr = current;
								bAJdQfdgcdFxJyeAudAVzDwpoKuG = 1;
								return true;
							}
							bzMPyRlTQUPNYQRfPnzdqjqvtwat();
							YhTFNeEBzOjeMDPLaRXQOrcckrJHe = null;
							DaQlHMLhZFPorlimwEZFZqauzJqL++;
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

					private void bzMPyRlTQUPNYQRfPnzdqjqvtwat()
					{
						bAJdQfdgcdFxJyeAudAVzDwpoKuG = -1;
						if (YhTFNeEBzOjeMDPLaRXQOrcckrJHe != null)
						{
							YhTFNeEBzOjeMDPLaRXQOrcckrJHe.Dispose();
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
						AptGKLwClAWZpfBsHqkHQQwdbNkU aptGKLwClAWZpfBsHqkHQQwdbNkU;
						if (bAJdQfdgcdFxJyeAudAVzDwpoKuG == -2 && AALUGTvpCSGshMwvneLCkZyfTdgZ == Environment.CurrentManagedThreadId)
						{
							bAJdQfdgcdFxJyeAudAVzDwpoKuG = 0;
							aptGKLwClAWZpfBsHqkHQQwdbNkU = this;
						}
						else
						{
							aptGKLwClAWZpfBsHqkHQQwdbNkU = new AptGKLwClAWZpfBsHqkHQQwdbNkU(0);
						}
						aptGKLwClAWZpfBsHqkHQQwdbNkU.oTZVZXbgcnrxDkfLhBLyVaOcdJhL = WsiXLNBoxIDPHEBaROunscMUBbUd;
						aptGKLwClAWZpfBsHqkHQQwdbNkU.hPNKqenMUjSwgEgugBgMeBTGZSfi = vOiOIhQmqscKEmLGabOOgjKybdtb;
						aptGKLwClAWZpfBsHqkHQQwdbNkU.dpoRszDdUJTBmkkrPQuEOTxRHGbc = dnAQDZnvVPchomPkybYRfuRcPCiiA;
						aptGKLwClAWZpfBsHqkHQQwdbNkU.TzycABysLwuTMCIAiKwTFbYekMtg = wZUfeIYkrbNgnAHRWQXLrbNtwFQI;
						return aptGKLwClAWZpfBsHqkHQQwdbNkU;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class sRNrZPEiufeJyWgVMeXTWgrZXFBI : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int FFlbGDCECKPvdlvhTojJOjjEjhDi;

					private ElementAssignmentConflictInfo pXCBCcBylmXNRqaHCmcDAvESyEbRA;

					private int wRvMjrILrUswGCSdqWSIhJNShXmE;

					private int dHGSHLNEsPhJWtUTWvmsFpWosalA;

					public int BTcYszfjORcrPbIeqglrElzShHYz;

					private ActionElementMap idrHAqfyxmCXAQWFxrBGmQBEPUHfA;

					public ActionElementMap SzaYZAXJpXzwPKToJqdaVvtxyjWf;

					private bool vYFObCfcBWGiTncXISHfGraxoJKQ;

					public bool JuzkyeixYUcltfOXRPAXCiYsFkjQ;

					private int PXUFftqcaiXYGRuhBsccBlZnzZTq;

					public int BYmdwiaovxYPqazoBNjAKLMirJES;

					private JoystickMap rNcEnLVGtSnBhQEGzSrwNgjZShyB;

					public JoystickMap CHyekaUuIleEEUzBxuDvIhnHnqkr;

					private bool UPsTgJxAuysozjjMlYlphdstcIpR;

					public bool LvtrkXuAdfGWrUSmzxZSdSXWbyPp;

					private bool FMrQGcOvCoMIVYuSTckEYQFjCvrDA;

					public bool YlShpcyBcTDjbkCRQLOXELDMLFGjb;

					private IList<Player> CbNitxFrpEeusfnZViVdCxcdHpIiB;

					private int CtvVYJMmOqAzcbAfynuBPKnLLMFy;

					private IEnumerator<ElementAssignmentConflictInfo> RRcboAwQukeAPeKPWdhoBJTdCQppA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return pXCBCcBylmXNRqaHCmcDAvESyEbRA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return pXCBCcBylmXNRqaHCmcDAvESyEbRA;
						}
					}

					[DebuggerHidden]
					public sRNrZPEiufeJyWgVMeXTWgrZXFBI(int P_0)
					{
						FFlbGDCECKPvdlvhTojJOjjEjhDi = P_0;
						wRvMjrILrUswGCSdqWSIhJNShXmE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int fFlbGDCECKPvdlvhTojJOjjEjhDi = FFlbGDCECKPvdlvhTojJOjjEjhDi;
						if (fFlbGDCECKPvdlvhTojJOjjEjhDi == -3 || fFlbGDCECKPvdlvhTojJOjjEjhDi == 1)
						{
							try
							{
							}
							finally
							{
								QDnCilTSVobbLeOIIrqePxpueNlr();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int fFlbGDCECKPvdlvhTojJOjjEjhDi = FFlbGDCECKPvdlvhTojJOjjEjhDi;
							if (fFlbGDCECKPvdlvhTojJOjjEjhDi != 0)
							{
								if (fFlbGDCECKPvdlvhTojJOjjEjhDi != 1)
								{
									return false;
								}
								FFlbGDCECKPvdlvhTojJOjjEjhDi = -3;
								goto IL_00e1;
							}
							FFlbGDCECKPvdlvhTojJOjjEjhDi = -1;
							if (dHGSHLNEsPhJWtUTWvmsFpWosalA < 0 || idrHAqfyxmCXAQWFxrBGmQBEPUHfA == null)
							{
								return false;
							}
							CbNitxFrpEeusfnZViVdCxcdHpIiB = (vYFObCfcBWGiTncXISHfGraxoJKQ ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
							CtvVYJMmOqAzcbAfynuBPKnLLMFy = 0;
							goto IL_010b;
							IL_010b:
							if (CtvVYJMmOqAzcbAfynuBPKnLLMFy < CbNitxFrpEeusfnZViVdCxcdHpIiB.Count)
							{
								RRcboAwQukeAPeKPWdhoBJTdCQppA = CbNitxFrpEeusfnZViVdCxcdHpIiB[CtvVYJMmOqAzcbAfynuBPKnLLMFy].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, PXUFftqcaiXYGRuhBsccBlZnzZTq, rNcEnLVGtSnBhQEGzSrwNgjZShyB, idrHAqfyxmCXAQWFxrBGmQBEPUHfA, UPsTgJxAuysozjjMlYlphdstcIpR, FMrQGcOvCoMIVYuSTckEYQFjCvrDA).GetEnumerator();
								FFlbGDCECKPvdlvhTojJOjjEjhDi = -3;
								goto IL_00e1;
							}
							return false;
							IL_00e1:
							if (RRcboAwQukeAPeKPWdhoBJTdCQppA.MoveNext())
							{
								ElementAssignmentConflictInfo current = RRcboAwQukeAPeKPWdhoBJTdCQppA.Current;
								pXCBCcBylmXNRqaHCmcDAvESyEbRA = current;
								FFlbGDCECKPvdlvhTojJOjjEjhDi = 1;
								return true;
							}
							QDnCilTSVobbLeOIIrqePxpueNlr();
							RRcboAwQukeAPeKPWdhoBJTdCQppA = null;
							CtvVYJMmOqAzcbAfynuBPKnLLMFy++;
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

					private void QDnCilTSVobbLeOIIrqePxpueNlr()
					{
						FFlbGDCECKPvdlvhTojJOjjEjhDi = -1;
						if (RRcboAwQukeAPeKPWdhoBJTdCQppA != null)
						{
							RRcboAwQukeAPeKPWdhoBJTdCQppA.Dispose();
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
						sRNrZPEiufeJyWgVMeXTWgrZXFBI sRNrZPEiufeJyWgVMeXTWgrZXFBI2;
						if (FFlbGDCECKPvdlvhTojJOjjEjhDi == -2 && wRvMjrILrUswGCSdqWSIhJNShXmE == Environment.CurrentManagedThreadId)
						{
							FFlbGDCECKPvdlvhTojJOjjEjhDi = 0;
							sRNrZPEiufeJyWgVMeXTWgrZXFBI2 = this;
						}
						else
						{
							sRNrZPEiufeJyWgVMeXTWgrZXFBI2 = new sRNrZPEiufeJyWgVMeXTWgrZXFBI(0);
						}
						sRNrZPEiufeJyWgVMeXTWgrZXFBI2.dHGSHLNEsPhJWtUTWvmsFpWosalA = BTcYszfjORcrPbIeqglrElzShHYz;
						sRNrZPEiufeJyWgVMeXTWgrZXFBI2.PXUFftqcaiXYGRuhBsccBlZnzZTq = BYmdwiaovxYPqazoBNjAKLMirJES;
						sRNrZPEiufeJyWgVMeXTWgrZXFBI2.rNcEnLVGtSnBhQEGzSrwNgjZShyB = CHyekaUuIleEEUzBxuDvIhnHnqkr;
						sRNrZPEiufeJyWgVMeXTWgrZXFBI2.idrHAqfyxmCXAQWFxrBGmQBEPUHfA = SzaYZAXJpXzwPKToJqdaVvtxyjWf;
						sRNrZPEiufeJyWgVMeXTWgrZXFBI2.UPsTgJxAuysozjjMlYlphdstcIpR = LvtrkXuAdfGWrUSmzxZSdSXWbyPp;
						sRNrZPEiufeJyWgVMeXTWgrZXFBI2.FMrQGcOvCoMIVYuSTckEYQFjCvrDA = YlShpcyBcTDjbkCRQLOXELDMLFGjb;
						sRNrZPEiufeJyWgVMeXTWgrZXFBI2.vYFObCfcBWGiTncXISHfGraxoJKQ = JuzkyeixYUcltfOXRPAXCiYsFkjQ;
						return sRNrZPEiufeJyWgVMeXTWgrZXFBI2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class RsbCCkfNeILTCcYPnSWmMSxzpCXMA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int XYvkQYNYXSeidHQBbkKlmZKOTQgS;

					private ElementAssignmentConflictInfo DFnfrfpGYjtVXoAtnrnFkQSbrwvG;

					private int RWGNVlZaBlAESjiGBFZBZaIZVboc;

					private ElementAssignmentConflictCheck vFRIYKvZSPkOQDwkvmiVyJdCBtwC;

					public ElementAssignmentConflictCheck PBnecCNMHEaCKDRSgWGLbqeRimOj;

					private bool JSEMRRWbHLFXGFpMOKgQeVqCHHYdc;

					public bool hFsHODXudrTpBoKivdbudpCsLxCbA;

					private bool USOAygdpxhgXeStNpkKtxmpCJjbCb;

					public bool VIhokTyFcUTJJOBfUDEYadikZGoR;

					private bool IyXYKVbClCBRUzOxxPrdqyxZRtrs;

					public bool yDZHfPcZYRiLhdUQnqaHTeuLEdSI;

					private IList<Player> bvxeNlYSgpHYiRTuOAzhkfaaOfYi;

					private int cYKQFSthneQBeXfFvzaYPTUGMnNj;

					private IEnumerator<ElementAssignmentConflictInfo> ldoNkyeQCqAbMSnBQwgyHlzbTAuW;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DFnfrfpGYjtVXoAtnrnFkQSbrwvG;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DFnfrfpGYjtVXoAtnrnFkQSbrwvG;
						}
					}

					[DebuggerHidden]
					public RsbCCkfNeILTCcYPnSWmMSxzpCXMA(int P_0)
					{
						XYvkQYNYXSeidHQBbkKlmZKOTQgS = P_0;
						RWGNVlZaBlAESjiGBFZBZaIZVboc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int xYvkQYNYXSeidHQBbkKlmZKOTQgS = XYvkQYNYXSeidHQBbkKlmZKOTQgS;
						if (xYvkQYNYXSeidHQBbkKlmZKOTQgS == -3 || xYvkQYNYXSeidHQBbkKlmZKOTQgS == 1)
						{
							try
							{
							}
							finally
							{
								WZmonEUkxIGIuiyaYacQuQKNeall();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int xYvkQYNYXSeidHQBbkKlmZKOTQgS = XYvkQYNYXSeidHQBbkKlmZKOTQgS;
							if (xYvkQYNYXSeidHQBbkKlmZKOTQgS != 0)
							{
								if (xYvkQYNYXSeidHQBbkKlmZKOTQgS != 1)
								{
									return false;
								}
								XYvkQYNYXSeidHQBbkKlmZKOTQgS = -3;
								goto IL_00df;
							}
							XYvkQYNYXSeidHQBbkKlmZKOTQgS = -1;
							if (vFRIYKvZSPkOQDwkvmiVyJdCBtwC.playerId < 0 || vFRIYKvZSPkOQDwkvmiVyJdCBtwC.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							bvxeNlYSgpHYiRTuOAzhkfaaOfYi = (JSEMRRWbHLFXGFpMOKgQeVqCHHYdc ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
							cYKQFSthneQBeXfFvzaYPTUGMnNj = 0;
							goto IL_0109;
							IL_0109:
							if (cYKQFSthneQBeXfFvzaYPTUGMnNj < bvxeNlYSgpHYiRTuOAzhkfaaOfYi.Count)
							{
								ldoNkyeQCqAbMSnBQwgyHlzbTAuW = bvxeNlYSgpHYiRTuOAzhkfaaOfYi[cYKQFSthneQBeXfFvzaYPTUGMnNj].controllers.conflictChecking.ElementAssignmentConflicts(vFRIYKvZSPkOQDwkvmiVyJdCBtwC, USOAygdpxhgXeStNpkKtxmpCJjbCb, IyXYKVbClCBRUzOxxPrdqyxZRtrs).GetEnumerator();
								XYvkQYNYXSeidHQBbkKlmZKOTQgS = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (ldoNkyeQCqAbMSnBQwgyHlzbTAuW.MoveNext())
							{
								ElementAssignmentConflictInfo current = ldoNkyeQCqAbMSnBQwgyHlzbTAuW.Current;
								DFnfrfpGYjtVXoAtnrnFkQSbrwvG = current;
								XYvkQYNYXSeidHQBbkKlmZKOTQgS = 1;
								return true;
							}
							WZmonEUkxIGIuiyaYacQuQKNeall();
							ldoNkyeQCqAbMSnBQwgyHlzbTAuW = null;
							cYKQFSthneQBeXfFvzaYPTUGMnNj++;
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

					private void WZmonEUkxIGIuiyaYacQuQKNeall()
					{
						XYvkQYNYXSeidHQBbkKlmZKOTQgS = -1;
						if (ldoNkyeQCqAbMSnBQwgyHlzbTAuW != null)
						{
							ldoNkyeQCqAbMSnBQwgyHlzbTAuW.Dispose();
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
						RsbCCkfNeILTCcYPnSWmMSxzpCXMA rsbCCkfNeILTCcYPnSWmMSxzpCXMA;
						if (XYvkQYNYXSeidHQBbkKlmZKOTQgS == -2 && RWGNVlZaBlAESjiGBFZBZaIZVboc == Environment.CurrentManagedThreadId)
						{
							XYvkQYNYXSeidHQBbkKlmZKOTQgS = 0;
							rsbCCkfNeILTCcYPnSWmMSxzpCXMA = this;
						}
						else
						{
							rsbCCkfNeILTCcYPnSWmMSxzpCXMA = new RsbCCkfNeILTCcYPnSWmMSxzpCXMA(0);
						}
						rsbCCkfNeILTCcYPnSWmMSxzpCXMA.vFRIYKvZSPkOQDwkvmiVyJdCBtwC = PBnecCNMHEaCKDRSgWGLbqeRimOj;
						rsbCCkfNeILTCcYPnSWmMSxzpCXMA.USOAygdpxhgXeStNpkKtxmpCJjbCb = VIhokTyFcUTJJOBfUDEYadikZGoR;
						rsbCCkfNeILTCcYPnSWmMSxzpCXMA.IyXYKVbClCBRUzOxxPrdqyxZRtrs = yDZHfPcZYRiLhdUQnqaHTeuLEdSI;
						rsbCCkfNeILTCcYPnSWmMSxzpCXMA.JSEMRRWbHLFXGFpMOKgQeVqCHHYdc = hFsHODXudrTpBoKivdbudpCsLxCbA;
						return rsbCCkfNeILTCcYPnSWmMSxzpCXMA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class YGbqTFusCWAdPekymcwbGplKLvQDB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int dBbfrfueyLaLXrcorOvVEldkutdk;

					private ElementAssignmentConflictInfo gHKzCegGcsKyJCSohjscljGxRzgH;

					private int KArLMhZSGRoxztUEhVRkbVPwaljE;

					private int pDWuMRYNPQyvNQjHwCksJEUNTsisA;

					public int VnmblkYNgqlxCpRlQEIvcBHrcDeK;

					private ActionElementMap bXmrVuKcncCCLvAZMDqPiIJeDFRjb;

					public ActionElementMap gIOUHRElhQQNSOIKwpgnvcAiiQCjA;

					private bool IVPGscFfrHsiPAglzpHvTZxWImVG;

					public bool eceXstoMyLLBqpLMLXPxreseLaYi;

					private KeyboardMap wZIEakYoDIfflAssqyAVDJDupWbab;

					public KeyboardMap MNdQecYhONNrxkFhxenfdsQyygZy;

					private bool VUMsrKRZWwumeTxxAcJnVQIsBVpp;

					public bool TKcJktFmhLybSYiTQfQAlfwIBRaN;

					private bool oudyTYWgcvSbNgZWwNRgSepCFFFS;

					public bool RkZRvKMJfHrjJNHHZCwUwBafWRmF;

					private IList<Player> DOUDklymVdVkGtRmgcQZLSWWlToV;

					private int nFIPXLTLKiDhhbYvYKwLteuJRAJk;

					private IEnumerator<ElementAssignmentConflictInfo> AhTSCDUPDywCTPCQrCQJfvjDnSaTA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return gHKzCegGcsKyJCSohjscljGxRzgH;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return gHKzCegGcsKyJCSohjscljGxRzgH;
						}
					}

					[DebuggerHidden]
					public YGbqTFusCWAdPekymcwbGplKLvQDB(int P_0)
					{
						dBbfrfueyLaLXrcorOvVEldkutdk = P_0;
						KArLMhZSGRoxztUEhVRkbVPwaljE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = dBbfrfueyLaLXrcorOvVEldkutdk;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								kjJBPPLbhjOsawmhFIXcRhiztehV();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = dBbfrfueyLaLXrcorOvVEldkutdk;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								dBbfrfueyLaLXrcorOvVEldkutdk = -3;
								goto IL_00dc;
							}
							dBbfrfueyLaLXrcorOvVEldkutdk = -1;
							if (pDWuMRYNPQyvNQjHwCksJEUNTsisA < 0 || bXmrVuKcncCCLvAZMDqPiIJeDFRjb == null)
							{
								return false;
							}
							DOUDklymVdVkGtRmgcQZLSWWlToV = (IVPGscFfrHsiPAglzpHvTZxWImVG ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
							nFIPXLTLKiDhhbYvYKwLteuJRAJk = 0;
							goto IL_0106;
							IL_0106:
							if (nFIPXLTLKiDhhbYvYKwLteuJRAJk < DOUDklymVdVkGtRmgcQZLSWWlToV.Count)
							{
								AhTSCDUPDywCTPCQrCQJfvjDnSaTA = DOUDklymVdVkGtRmgcQZLSWWlToV[nFIPXLTLKiDhhbYvYKwLteuJRAJk].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, wZIEakYoDIfflAssqyAVDJDupWbab, bXmrVuKcncCCLvAZMDqPiIJeDFRjb, VUMsrKRZWwumeTxxAcJnVQIsBVpp, oudyTYWgcvSbNgZWwNRgSepCFFFS).GetEnumerator();
								dBbfrfueyLaLXrcorOvVEldkutdk = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (AhTSCDUPDywCTPCQrCQJfvjDnSaTA.MoveNext())
							{
								ElementAssignmentConflictInfo current = AhTSCDUPDywCTPCQrCQJfvjDnSaTA.Current;
								gHKzCegGcsKyJCSohjscljGxRzgH = current;
								dBbfrfueyLaLXrcorOvVEldkutdk = 1;
								return true;
							}
							kjJBPPLbhjOsawmhFIXcRhiztehV();
							AhTSCDUPDywCTPCQrCQJfvjDnSaTA = null;
							nFIPXLTLKiDhhbYvYKwLteuJRAJk++;
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

					private void kjJBPPLbhjOsawmhFIXcRhiztehV()
					{
						dBbfrfueyLaLXrcorOvVEldkutdk = -1;
						if (AhTSCDUPDywCTPCQrCQJfvjDnSaTA != null)
						{
							AhTSCDUPDywCTPCQrCQJfvjDnSaTA.Dispose();
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
						YGbqTFusCWAdPekymcwbGplKLvQDB yGbqTFusCWAdPekymcwbGplKLvQDB;
						if (dBbfrfueyLaLXrcorOvVEldkutdk == -2 && KArLMhZSGRoxztUEhVRkbVPwaljE == Environment.CurrentManagedThreadId)
						{
							dBbfrfueyLaLXrcorOvVEldkutdk = 0;
							yGbqTFusCWAdPekymcwbGplKLvQDB = this;
						}
						else
						{
							yGbqTFusCWAdPekymcwbGplKLvQDB = new YGbqTFusCWAdPekymcwbGplKLvQDB(0);
						}
						yGbqTFusCWAdPekymcwbGplKLvQDB.pDWuMRYNPQyvNQjHwCksJEUNTsisA = VnmblkYNgqlxCpRlQEIvcBHrcDeK;
						yGbqTFusCWAdPekymcwbGplKLvQDB.wZIEakYoDIfflAssqyAVDJDupWbab = MNdQecYhONNrxkFhxenfdsQyygZy;
						yGbqTFusCWAdPekymcwbGplKLvQDB.bXmrVuKcncCCLvAZMDqPiIJeDFRjb = gIOUHRElhQQNSOIKwpgnvcAiiQCjA;
						yGbqTFusCWAdPekymcwbGplKLvQDB.VUMsrKRZWwumeTxxAcJnVQIsBVpp = TKcJktFmhLybSYiTQfQAlfwIBRaN;
						yGbqTFusCWAdPekymcwbGplKLvQDB.oudyTYWgcvSbNgZWwNRgSepCFFFS = RkZRvKMJfHrjJNHHZCwUwBafWRmF;
						yGbqTFusCWAdPekymcwbGplKLvQDB.IVPGscFfrHsiPAglzpHvTZxWImVG = eceXstoMyLLBqpLMLXPxreseLaYi;
						return yGbqTFusCWAdPekymcwbGplKLvQDB;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class zOGdEfgJgnJapdVPfkdGxONTAEPsB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int bwUFfeeJCHGxOHYoeLEcOWLNRbrx;

					private ElementAssignmentConflictInfo lzoMRyMBokDMGBkDRqRqSlBQUmHn;

					private int DFHWJuKQqrAqTraxjrIRcbGnpStX;

					private ElementAssignmentConflictCheck KmKbvBCMNDUTLNhttNdZDWxyvYTs;

					public ElementAssignmentConflictCheck oZGoLhTlArpOTxmoWKhmCypcnxPA;

					private bool tWSfBdpBLSaexYFIgmLdwHryjSg;

					public bool ocOHAhuxukXXirsYMeldKOVSlIbw;

					private bool asYOSgdsdARlbekPpuYMsjiLzsuH;

					public bool eXwAOXJFhbzgHOAyjQVZTLYiDTsW;

					private bool tFjASRGCGlGgQiJjbnfcCMSHtsprB;

					public bool GPhbzGFcchdADvHedcySVjsyslvPA;

					private IList<Player> GFDeUPuqtCDMnvvkojCXdTKTbXaM;

					private int lFlYBmVjCgBgoDBPUQUSNWbKLzKA;

					private IEnumerator<ElementAssignmentConflictInfo> NEnJdEspKOFpCCXVXDeHhujhKqOqb;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return lzoMRyMBokDMGBkDRqRqSlBQUmHn;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return lzoMRyMBokDMGBkDRqRqSlBQUmHn;
						}
					}

					[DebuggerHidden]
					public zOGdEfgJgnJapdVPfkdGxONTAEPsB(int P_0)
					{
						bwUFfeeJCHGxOHYoeLEcOWLNRbrx = P_0;
						DFHWJuKQqrAqTraxjrIRcbGnpStX = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = bwUFfeeJCHGxOHYoeLEcOWLNRbrx;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								wLQWyBkLvaQcxmxjNOoScFDzYCBX();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = bwUFfeeJCHGxOHYoeLEcOWLNRbrx;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								bwUFfeeJCHGxOHYoeLEcOWLNRbrx = -3;
								goto IL_00df;
							}
							bwUFfeeJCHGxOHYoeLEcOWLNRbrx = -1;
							if (KmKbvBCMNDUTLNhttNdZDWxyvYTs.playerId < 0 || KmKbvBCMNDUTLNhttNdZDWxyvYTs.elementAssignmentType != ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							GFDeUPuqtCDMnvvkojCXdTKTbXaM = (tWSfBdpBLSaexYFIgmLdwHryjSg ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
							lFlYBmVjCgBgoDBPUQUSNWbKLzKA = 0;
							goto IL_0109;
							IL_0109:
							if (lFlYBmVjCgBgoDBPUQUSNWbKLzKA < GFDeUPuqtCDMnvvkojCXdTKTbXaM.Count)
							{
								NEnJdEspKOFpCCXVXDeHhujhKqOqb = GFDeUPuqtCDMnvvkojCXdTKTbXaM[lFlYBmVjCgBgoDBPUQUSNWbKLzKA].controllers.conflictChecking.ElementAssignmentConflicts(KmKbvBCMNDUTLNhttNdZDWxyvYTs, asYOSgdsdARlbekPpuYMsjiLzsuH, tFjASRGCGlGgQiJjbnfcCMSHtsprB).GetEnumerator();
								bwUFfeeJCHGxOHYoeLEcOWLNRbrx = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (NEnJdEspKOFpCCXVXDeHhujhKqOqb.MoveNext())
							{
								ElementAssignmentConflictInfo current = NEnJdEspKOFpCCXVXDeHhujhKqOqb.Current;
								lzoMRyMBokDMGBkDRqRqSlBQUmHn = current;
								bwUFfeeJCHGxOHYoeLEcOWLNRbrx = 1;
								return true;
							}
							wLQWyBkLvaQcxmxjNOoScFDzYCBX();
							NEnJdEspKOFpCCXVXDeHhujhKqOqb = null;
							lFlYBmVjCgBgoDBPUQUSNWbKLzKA++;
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

					private void wLQWyBkLvaQcxmxjNOoScFDzYCBX()
					{
						bwUFfeeJCHGxOHYoeLEcOWLNRbrx = -1;
						if (NEnJdEspKOFpCCXVXDeHhujhKqOqb != null)
						{
							NEnJdEspKOFpCCXVXDeHhujhKqOqb.Dispose();
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
						zOGdEfgJgnJapdVPfkdGxONTAEPsB zOGdEfgJgnJapdVPfkdGxONTAEPsB2;
						if (bwUFfeeJCHGxOHYoeLEcOWLNRbrx == -2 && DFHWJuKQqrAqTraxjrIRcbGnpStX == Environment.CurrentManagedThreadId)
						{
							bwUFfeeJCHGxOHYoeLEcOWLNRbrx = 0;
							zOGdEfgJgnJapdVPfkdGxONTAEPsB2 = this;
						}
						else
						{
							zOGdEfgJgnJapdVPfkdGxONTAEPsB2 = new zOGdEfgJgnJapdVPfkdGxONTAEPsB(0);
						}
						zOGdEfgJgnJapdVPfkdGxONTAEPsB2.KmKbvBCMNDUTLNhttNdZDWxyvYTs = oZGoLhTlArpOTxmoWKhmCypcnxPA;
						zOGdEfgJgnJapdVPfkdGxONTAEPsB2.asYOSgdsdARlbekPpuYMsjiLzsuH = eXwAOXJFhbzgHOAyjQVZTLYiDTsW;
						zOGdEfgJgnJapdVPfkdGxONTAEPsB2.tFjASRGCGlGgQiJjbnfcCMSHtsprB = GPhbzGFcchdADvHedcySVjsyslvPA;
						zOGdEfgJgnJapdVPfkdGxONTAEPsB2.tWSfBdpBLSaexYFIgmLdwHryjSg = ocOHAhuxukXXirsYMeldKOVSlIbw;
						return zOGdEfgJgnJapdVPfkdGxONTAEPsB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class qBWroziShAOlnYznjAscmIXrgYeD : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int FWoOxqdfIOaRZzkKPEIvypvGntIc;

					private ElementAssignmentConflictInfo arSehFHUGQXIRLprzwpDoaebfyLB;

					private int wMsqcuvcBRpAqBitpbqoEXRpfPwN;

					private int IXewxprOfxcQXhjtKCnAkWqGasSY;

					public int klmGgoDxskqtOCOGQhGXwUvAvyLiA;

					private ActionElementMap RTFCMrguYkplknvRAKRtIGTmyymx;

					public ActionElementMap TbbwJmRipOuFaWTYQKYlBDCyGSxk;

					private bool xIcOvBwEpYstvximsyhwQKtvckfiA;

					public bool vXPjJbzadHZQEpBxCpihGHAzdGXr;

					private MouseMap gYtluHqwsTwIZTcMKWxHgCPqpSvK;

					public MouseMap ZqDckzBEuNwSbAsldRiqjRNFdBjv;

					private bool sGLdofJRDWkNKorytbUzxtQkaevjb;

					public bool aQPLlVYstkxHNIGIQPHDfsrHKCgG;

					private bool rPESpsyjUdGgecJugHEbHFVeMNEhA;

					public bool UCpYZmVcEwDWKdEAwQhPXztCFoug;

					private IList<Player> eNfdvSEEpylaHMFqeyBqgHXQioViA;

					private int GYawDdTAXNRjwAkJsgGgcJXbdoSvA;

					private IEnumerator<ElementAssignmentConflictInfo> FmUEBbTFoQuZvZyQeWdquqxVnoNh;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return arSehFHUGQXIRLprzwpDoaebfyLB;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return arSehFHUGQXIRLprzwpDoaebfyLB;
						}
					}

					[DebuggerHidden]
					public qBWroziShAOlnYznjAscmIXrgYeD(int P_0)
					{
						FWoOxqdfIOaRZzkKPEIvypvGntIc = P_0;
						wMsqcuvcBRpAqBitpbqoEXRpfPwN = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int fWoOxqdfIOaRZzkKPEIvypvGntIc = FWoOxqdfIOaRZzkKPEIvypvGntIc;
						if (fWoOxqdfIOaRZzkKPEIvypvGntIc == -3 || fWoOxqdfIOaRZzkKPEIvypvGntIc == 1)
						{
							try
							{
							}
							finally
							{
								TcjROTmUEXLMrgsoknaXaZkewFYB();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int fWoOxqdfIOaRZzkKPEIvypvGntIc = FWoOxqdfIOaRZzkKPEIvypvGntIc;
							if (fWoOxqdfIOaRZzkKPEIvypvGntIc != 0)
							{
								if (fWoOxqdfIOaRZzkKPEIvypvGntIc != 1)
								{
									return false;
								}
								FWoOxqdfIOaRZzkKPEIvypvGntIc = -3;
								goto IL_00dc;
							}
							FWoOxqdfIOaRZzkKPEIvypvGntIc = -1;
							if (IXewxprOfxcQXhjtKCnAkWqGasSY < 0 || RTFCMrguYkplknvRAKRtIGTmyymx == null)
							{
								return false;
							}
							eNfdvSEEpylaHMFqeyBqgHXQioViA = (xIcOvBwEpYstvximsyhwQKtvckfiA ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
							GYawDdTAXNRjwAkJsgGgcJXbdoSvA = 0;
							goto IL_0106;
							IL_0106:
							if (GYawDdTAXNRjwAkJsgGgcJXbdoSvA < eNfdvSEEpylaHMFqeyBqgHXQioViA.Count)
							{
								FmUEBbTFoQuZvZyQeWdquqxVnoNh = eNfdvSEEpylaHMFqeyBqgHXQioViA[GYawDdTAXNRjwAkJsgGgcJXbdoSvA].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, gYtluHqwsTwIZTcMKWxHgCPqpSvK, RTFCMrguYkplknvRAKRtIGTmyymx, sGLdofJRDWkNKorytbUzxtQkaevjb, rPESpsyjUdGgecJugHEbHFVeMNEhA).GetEnumerator();
								FWoOxqdfIOaRZzkKPEIvypvGntIc = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (FmUEBbTFoQuZvZyQeWdquqxVnoNh.MoveNext())
							{
								ElementAssignmentConflictInfo current = FmUEBbTFoQuZvZyQeWdquqxVnoNh.Current;
								arSehFHUGQXIRLprzwpDoaebfyLB = current;
								FWoOxqdfIOaRZzkKPEIvypvGntIc = 1;
								return true;
							}
							TcjROTmUEXLMrgsoknaXaZkewFYB();
							FmUEBbTFoQuZvZyQeWdquqxVnoNh = null;
							GYawDdTAXNRjwAkJsgGgcJXbdoSvA++;
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

					private void TcjROTmUEXLMrgsoknaXaZkewFYB()
					{
						FWoOxqdfIOaRZzkKPEIvypvGntIc = -1;
						if (FmUEBbTFoQuZvZyQeWdquqxVnoNh != null)
						{
							FmUEBbTFoQuZvZyQeWdquqxVnoNh.Dispose();
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
						qBWroziShAOlnYznjAscmIXrgYeD qBWroziShAOlnYznjAscmIXrgYeD2;
						if (FWoOxqdfIOaRZzkKPEIvypvGntIc == -2 && wMsqcuvcBRpAqBitpbqoEXRpfPwN == Environment.CurrentManagedThreadId)
						{
							FWoOxqdfIOaRZzkKPEIvypvGntIc = 0;
							qBWroziShAOlnYznjAscmIXrgYeD2 = this;
						}
						else
						{
							qBWroziShAOlnYznjAscmIXrgYeD2 = new qBWroziShAOlnYznjAscmIXrgYeD(0);
						}
						qBWroziShAOlnYznjAscmIXrgYeD2.IXewxprOfxcQXhjtKCnAkWqGasSY = klmGgoDxskqtOCOGQhGXwUvAvyLiA;
						qBWroziShAOlnYznjAscmIXrgYeD2.gYtluHqwsTwIZTcMKWxHgCPqpSvK = ZqDckzBEuNwSbAsldRiqjRNFdBjv;
						qBWroziShAOlnYznjAscmIXrgYeD2.RTFCMrguYkplknvRAKRtIGTmyymx = TbbwJmRipOuFaWTYQKYlBDCyGSxk;
						qBWroziShAOlnYznjAscmIXrgYeD2.sGLdofJRDWkNKorytbUzxtQkaevjb = aQPLlVYstkxHNIGIQPHDfsrHKCgG;
						qBWroziShAOlnYznjAscmIXrgYeD2.rPESpsyjUdGgecJugHEbHFVeMNEhA = UCpYZmVcEwDWKdEAwQhPXztCFoug;
						qBWroziShAOlnYznjAscmIXrgYeD2.xIcOvBwEpYstvximsyhwQKtvckfiA = vXPjJbzadHZQEpBxCpihGHAzdGXr;
						return qBWroziShAOlnYznjAscmIXrgYeD2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class DQiCocUADuTkqfwlnjzgryJSxnDg : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int LDEflZIkGMgWtznrKmgwlYKgIGleA;

					private ElementAssignmentConflictInfo LkPRfUCMrlSAENApagzjZnvRycyE;

					private int LwmCoFGeSEoBGVbftjSchFZcdZJmc;

					private ElementAssignmentConflictCheck sMglWqlpnQSIQpvusPDUVjpOQrOr;

					public ElementAssignmentConflictCheck dkJkmuSPzdoHiQWUbbtfFmNauoUk;

					private bool jBSfZwdtBTOqEQnwuAmiQWUgAVRBb;

					public bool XPBDMnaptgdysGarIxWbofGNYcmob;

					private bool toNvqotcNHbYBwQpraOKFMfsvHIOA;

					public bool xOiajEkEozovYhdhOYEBAhUckJuIb;

					private bool RCAFuhHUgACmqcfGjtXxHETvjpLeB;

					public bool BjbhwadhXKNutNWaaMlwTGkpGvzGA;

					private IList<Player> MFIkfkGSfrwHYUBKoFbEmikyOrww;

					private int fCOxENpzcoTitAZYlhJtBgrGDNvn;

					private IEnumerator<ElementAssignmentConflictInfo> SgjJqrvZKIKfJcjtPzBWwMOEFgOt;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return LkPRfUCMrlSAENApagzjZnvRycyE;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return LkPRfUCMrlSAENApagzjZnvRycyE;
						}
					}

					[DebuggerHidden]
					public DQiCocUADuTkqfwlnjzgryJSxnDg(int P_0)
					{
						LDEflZIkGMgWtznrKmgwlYKgIGleA = P_0;
						LwmCoFGeSEoBGVbftjSchFZcdZJmc = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int lDEflZIkGMgWtznrKmgwlYKgIGleA = LDEflZIkGMgWtznrKmgwlYKgIGleA;
						if (lDEflZIkGMgWtznrKmgwlYKgIGleA == -3 || lDEflZIkGMgWtznrKmgwlYKgIGleA == 1)
						{
							try
							{
							}
							finally
							{
								MmQdzCAZWcQewHTiEjqLARDONbVf();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int lDEflZIkGMgWtznrKmgwlYKgIGleA = LDEflZIkGMgWtznrKmgwlYKgIGleA;
							if (lDEflZIkGMgWtznrKmgwlYKgIGleA != 0)
							{
								if (lDEflZIkGMgWtznrKmgwlYKgIGleA != 1)
								{
									return false;
								}
								LDEflZIkGMgWtznrKmgwlYKgIGleA = -3;
								goto IL_00df;
							}
							LDEflZIkGMgWtznrKmgwlYKgIGleA = -1;
							if (sMglWqlpnQSIQpvusPDUVjpOQrOr.playerId < 0 || sMglWqlpnQSIQpvusPDUVjpOQrOr.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							MFIkfkGSfrwHYUBKoFbEmikyOrww = (jBSfZwdtBTOqEQnwuAmiQWUgAVRBb ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
							fCOxENpzcoTitAZYlhJtBgrGDNvn = 0;
							goto IL_0109;
							IL_0109:
							if (fCOxENpzcoTitAZYlhJtBgrGDNvn < MFIkfkGSfrwHYUBKoFbEmikyOrww.Count)
							{
								SgjJqrvZKIKfJcjtPzBWwMOEFgOt = MFIkfkGSfrwHYUBKoFbEmikyOrww[fCOxENpzcoTitAZYlhJtBgrGDNvn].controllers.conflictChecking.ElementAssignmentConflicts(sMglWqlpnQSIQpvusPDUVjpOQrOr, toNvqotcNHbYBwQpraOKFMfsvHIOA, RCAFuhHUgACmqcfGjtXxHETvjpLeB).GetEnumerator();
								LDEflZIkGMgWtznrKmgwlYKgIGleA = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (SgjJqrvZKIKfJcjtPzBWwMOEFgOt.MoveNext())
							{
								ElementAssignmentConflictInfo current = SgjJqrvZKIKfJcjtPzBWwMOEFgOt.Current;
								LkPRfUCMrlSAENApagzjZnvRycyE = current;
								LDEflZIkGMgWtznrKmgwlYKgIGleA = 1;
								return true;
							}
							MmQdzCAZWcQewHTiEjqLARDONbVf();
							SgjJqrvZKIKfJcjtPzBWwMOEFgOt = null;
							fCOxENpzcoTitAZYlhJtBgrGDNvn++;
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

					private void MmQdzCAZWcQewHTiEjqLARDONbVf()
					{
						LDEflZIkGMgWtznrKmgwlYKgIGleA = -1;
						if (SgjJqrvZKIKfJcjtPzBWwMOEFgOt != null)
						{
							SgjJqrvZKIKfJcjtPzBWwMOEFgOt.Dispose();
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
						DQiCocUADuTkqfwlnjzgryJSxnDg dQiCocUADuTkqfwlnjzgryJSxnDg;
						if (LDEflZIkGMgWtznrKmgwlYKgIGleA == -2 && LwmCoFGeSEoBGVbftjSchFZcdZJmc == Environment.CurrentManagedThreadId)
						{
							LDEflZIkGMgWtznrKmgwlYKgIGleA = 0;
							dQiCocUADuTkqfwlnjzgryJSxnDg = this;
						}
						else
						{
							dQiCocUADuTkqfwlnjzgryJSxnDg = new DQiCocUADuTkqfwlnjzgryJSxnDg(0);
						}
						dQiCocUADuTkqfwlnjzgryJSxnDg.sMglWqlpnQSIQpvusPDUVjpOQrOr = dkJkmuSPzdoHiQWUbbtfFmNauoUk;
						dQiCocUADuTkqfwlnjzgryJSxnDg.toNvqotcNHbYBwQpraOKFMfsvHIOA = xOiajEkEozovYhdhOYEBAhUckJuIb;
						dQiCocUADuTkqfwlnjzgryJSxnDg.RCAFuhHUgACmqcfGjtXxHETvjpLeB = BjbhwadhXKNutNWaaMlwTGkpGvzGA;
						dQiCocUADuTkqfwlnjzgryJSxnDg.jBSfZwdtBTOqEQnwuAmiQWUgAVRBb = XPBDMnaptgdysGarIxWbofGNYcmob;
						return dQiCocUADuTkqfwlnjzgryJSxnDg;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private static ConflictCheckingHelper FyhZTXCTiObNWLHwiQLhaSuFVQBK;

				internal static ConflictCheckingHelper XNBUDAKegmjMOCPcdECkuUfmZZNp => FyhZTXCTiObNWLHwiQLhaSuFVQBK ?? (FyhZTXCTiObNWLHwiQLhaSuFVQBK = new ConflictCheckingHelper());

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
					IList<Player> list = (includeSystemPlayer ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
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
						ControllerType.Joystick => MfmUuSmXuNTCcchYmBdfdmdGaznBb(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => WlfijCDLUJnImFdNELuBJOdIIhKO(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => JZFqLXOGEAlNIYoDWHzBkbalPgzu(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => dbUHUPsNdTNhlmRNXmBlqUyMaqJr(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return zfuugRauoDXZiUIfNhJjvpMFkhRH(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return IQTAGJFlBGnXfMEjXnSbBpCoLchUA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return HmkGVMHBKSBYoCVAgcuZaGPWepMoc(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return XSmfUyUPKUQSNGSylaXavmOzzxkg(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool MfmUuSmXuNTCcchYmBdfdmdGaznBb(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool zfuugRauoDXZiUIfNhJjvpMFkhRH(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool WlfijCDLUJnImFdNELuBJOdIIhKO(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool IQTAGJFlBGnXfMEjXnSbBpCoLchUA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool JZFqLXOGEAlNIYoDWHzBkbalPgzu(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool HmkGVMHBKSBYoCVAgcuZaGPWepMoc(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool dbUHUPsNdTNhlmRNXmBlqUyMaqJr(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool XSmfUyUPKUQSNGSylaXavmOzzxkg(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
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
						ControllerType.Joystick => jDklevkmFQSNNVaQOvHkNZEAsjUo(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => NpLdowezqzmQcQHlpOhwUTQSDPuvA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => rrgabZnkxPSMTnwqYCRQOsYQumEN(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => WCIhCABLyRGADQHDhIRDyLJybTkl(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return ggIEchhbQZhXAXTcEcUHGlrLmAkfA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return SIZKqGKFwEAkdHeCwUtImLBZpYJRA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return NZQXuaSpoBjvRDWSUiTLszyydGmZ(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return RffqUceDcGWhfYmvwJSHLaVnDkEs(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				[IteratorStateMachine(typeof(sRNrZPEiufeJyWgVMeXTWgrZXFBI))]
				private IEnumerable<ElementAssignmentConflictInfo> jDklevkmFQSNNVaQOvHkNZEAsjUo(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new sRNrZPEiufeJyWgVMeXTWgrZXFBI(-2)
					{
						BTcYszfjORcrPbIeqglrElzShHYz = P_0,
						BYmdwiaovxYPqazoBNjAKLMirJES = P_1,
						CHyekaUuIleEEUzBxuDvIhnHnqkr = P_2,
						SzaYZAXJpXzwPKToJqdaVvtxyjWf = P_3,
						LvtrkXuAdfGWrUSmzxZSdSXWbyPp = P_4,
						YlShpcyBcTDjbkCRQLOXELDMLFGjb = P_5,
						JuzkyeixYUcltfOXRPAXCiYsFkjQ = P_6
					};
				}

				[IteratorStateMachine(typeof(RsbCCkfNeILTCcYPnSWmMSxzpCXMA))]
				private IEnumerable<ElementAssignmentConflictInfo> ggIEchhbQZhXAXTcEcUHGlrLmAkfA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new RsbCCkfNeILTCcYPnSWmMSxzpCXMA(-2)
					{
						PBnecCNMHEaCKDRSgWGLbqeRimOj = P_0,
						VIhokTyFcUTJJOBfUDEYadikZGoR = P_1,
						yDZHfPcZYRiLhdUQnqaHTeuLEdSI = P_2,
						hFsHODXudrTpBoKivdbudpCsLxCbA = P_3
					};
				}

				[IteratorStateMachine(typeof(YGbqTFusCWAdPekymcwbGplKLvQDB))]
				private IEnumerable<ElementAssignmentConflictInfo> NpLdowezqzmQcQHlpOhwUTQSDPuvA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new YGbqTFusCWAdPekymcwbGplKLvQDB(-2)
					{
						VnmblkYNgqlxCpRlQEIvcBHrcDeK = P_0,
						MNdQecYhONNrxkFhxenfdsQyygZy = P_1,
						gIOUHRElhQQNSOIKwpgnvcAiiQCjA = P_2,
						TKcJktFmhLybSYiTQfQAlfwIBRaN = P_3,
						RkZRvKMJfHrjJNHHZCwUwBafWRmF = P_4,
						eceXstoMyLLBqpLMLXPxreseLaYi = P_5
					};
				}

				[IteratorStateMachine(typeof(zOGdEfgJgnJapdVPfkdGxONTAEPsB))]
				private IEnumerable<ElementAssignmentConflictInfo> SIZKqGKFwEAkdHeCwUtImLBZpYJRA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new zOGdEfgJgnJapdVPfkdGxONTAEPsB(-2)
					{
						oZGoLhTlArpOTxmoWKhmCypcnxPA = P_0,
						eXwAOXJFhbzgHOAyjQVZTLYiDTsW = P_1,
						GPhbzGFcchdADvHedcySVjsyslvPA = P_2,
						ocOHAhuxukXXirsYMeldKOVSlIbw = P_3
					};
				}

				[IteratorStateMachine(typeof(qBWroziShAOlnYznjAscmIXrgYeD))]
				private IEnumerable<ElementAssignmentConflictInfo> rrgabZnkxPSMTnwqYCRQOsYQumEN(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new qBWroziShAOlnYznjAscmIXrgYeD(-2)
					{
						klmGgoDxskqtOCOGQhGXwUvAvyLiA = P_0,
						ZqDckzBEuNwSbAsldRiqjRNFdBjv = P_1,
						TbbwJmRipOuFaWTYQKYlBDCyGSxk = P_2,
						aQPLlVYstkxHNIGIQPHDfsrHKCgG = P_3,
						UCpYZmVcEwDWKdEAwQhPXztCFoug = P_4,
						vXPjJbzadHZQEpBxCpihGHAzdGXr = P_5
					};
				}

				[IteratorStateMachine(typeof(DQiCocUADuTkqfwlnjzgryJSxnDg))]
				private IEnumerable<ElementAssignmentConflictInfo> NZQXuaSpoBjvRDWSUiTLszyydGmZ(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new DQiCocUADuTkqfwlnjzgryJSxnDg(-2)
					{
						dkJkmuSPzdoHiQWUbbtfFmNauoUk = P_0,
						xOiajEkEozovYhdhOYEBAhUckJuIb = P_1,
						BjbhwadhXKNutNWaaMlwTGkpGvzGA = P_2,
						XPBDMnaptgdysGarIxWbofGNYcmob = P_3
					};
				}

				[IteratorStateMachine(typeof(voHFcRLlanJZzESsjcUESBKZoDOn))]
				private IEnumerable<ElementAssignmentConflictInfo> WCIhCABLyRGADQHDhIRDyLJybTkl(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new voHFcRLlanJZzESsjcUESBKZoDOn(-2)
					{
						xhrDddAkzeqkRGwvMwPuKduSptlh = P_0,
						MewLfblKbGrEPZWBYctOvkWpixPL = P_1,
						yCKbyeAPmvJxZJyVcAZKwLsorhuTA = P_2,
						YAhASlBCshZfYFUgBzmXVUgTMxnA = P_3,
						hitDbUjqOskyNUyozhYjxvGNMVlx = P_4,
						ACYmpgapwtzzMKdemlpZaXlhZKAD = P_5,
						hJnWfiRbIbBYvdEyrUjbanooWynt = P_6
					};
				}

				[IteratorStateMachine(typeof(AptGKLwClAWZpfBsHqkHQQwdbNkU))]
				private IEnumerable<ElementAssignmentConflictInfo> RffqUceDcGWhfYmvwJSHLaVnDkEs(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new AptGKLwClAWZpfBsHqkHQQwdbNkU(-2)
					{
						WsiXLNBoxIDPHEBaROunscMUBbUd = P_0,
						vOiOIhQmqscKEmLGabOOgjKybdtb = P_1,
						dnAQDZnvVPchomPkybYRfuRcPCiiA = P_2,
						wZUfeIYkrbNgnAHRWQXLrbNtwFQI = P_3
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
						ControllerType.Joystick => iUIuHocftaAzlrmliXoJGJMHVLmL(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => uOTHJqorNnpkmNPHnczuuzsCjJRh(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => UHkPvyLLLFApyVjuMPzcHaYBErIy(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => HiRMcaPDShzVDruWlrSFDXgxzWom(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return DDmLvvanapGHvcttlmPUckoKIROlB(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return rOVSFjTlBmicYBOnmilxdideWJIg(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return wvRMWSHuAHPQjdiTmubvMpaokYqA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return aBahultyaTDwzgpPvbhBkefxKsco(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int iUIuHocftaAzlrmliXoJGJMHVLmL(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int DDmLvvanapGHvcttlmPUckoKIROlB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int uOTHJqorNnpkmNPHnczuuzsCjJRh(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int rOVSFjTlBmicYBOnmilxdideWJIg(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int UHkPvyLLLFApyVjuMPzcHaYBErIy(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int wvRMWSHuAHPQjdiTmubvMpaokYqA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int HiRMcaPDShzVDruWlrSFDXgxzWom(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int aBahultyaTDwzgpPvbhBkefxKsco(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
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
						ControllerType.Joystick => nonyKpQhXIojmmEpdZeOGuMOtoLC(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => YWgRlygVqQMjASAkJeoJJyAZDcHk(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => wqygtTveuLHUAsPYqVsOXRxFMMfX(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => UKFfsKzVbBIwbhVWEjbKikHBaQKEB(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return XiUKexTXVplUrAgQHcLiEOCYTJARA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return aPANAahBACmQFHuZRLBSwYcDVJQp(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return IWxEzWQCLPwWVkzQeWGknwbammxL(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return JgJJpyhmQmltivMmIBNDixOHvkAGA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int nonyKpQhXIojmmEpdZeOGuMOtoLC(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int XiUKexTXVplUrAgQHcLiEOCYTJARA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int YWgRlygVqQMjASAkJeoJJyAZDcHk(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int aPANAahBACmQFHuZRLBSwYcDVJQp(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int wqygtTveuLHUAsPYqVsOXRxFMMfX(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int IWxEzWQCLPwWVkzQeWGknwbammxL(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int UKFfsKzVbBIwbhVWEjbKikHBaQKEB(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int JgJJpyhmQmltivMmIBNDixOHvkAGA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA : VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper cxdqneekArtvOvoeitcrNIVCCLnk;

			public readonly PollingHelper polling = PollingHelper.thWgkJSONtUsWEQtXpLdpkKitAts;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.XNBUDAKegmjMOCPcdECkuUfmZZNp;

			internal static ControllerHelper CsuKbPMYYdIqXzlzPdNxFQOpARmdA => cxdqneekArtvOvoeitcrNIVCCLnk ?? (cxdqneekArtvOvoeitcrNIVCCLnk = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.rYGECVtoqMhAvYNYeARovaGodjFL;
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
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.nffGlbsLrJqoOdKFcAYXpkOVtReh;
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
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.QOfynKyLBkjDOhsBLZngEUcDGzzy;
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
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.WNWSmXDJjWGCNaqhXgXPNVyPdtGgb;
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
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.wURgxTJZNaSLNnCGmXznMTsQiLRN;
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
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA;
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
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.LizNnbYKXjebNHsTsYbvUTWOfEFG;
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
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.OfXwvmendXziMZySnqEbdcVFcFXO;
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
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.WNWSmXDJjWGCNaqhXgXPNVyPdtGgb as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return WUBqcfcHLvbkdiiUnEhQlzYVACJm.QOfynKyLBkjDOhsBLZngEUcDGzzy as T;
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
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.RdwbZcApWxKMveONGCHALzbrDsZZb(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.HXqDyahUzpKQPuoAHBEQrHhlLEOiA(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.oHNJFncyjYORPINFcBNmDgWNrLVpA(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.ylZVVezfuQwRIKJJgWOQDPxuenMQ(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.dQGjxbDQwXTvhBSfjdFlvglvIdihA(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.MpMEJddRuwkYwaYOoJnkVupRrOUuA(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.RSdfPAXAOoNuNGjBmAKsHsfswMQG(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					VouJZmDPLGSEXPCTzKAxDlURnAgC.EGUYVFTXzgVOqyBiQkrIeRmrieLx(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					VouJZmDPLGSEXPCTzKAxDlURnAgC.QzOrqgzxApPhsHMhYCFaiZrXIhwK(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.lJNHwTBZiOepTHokyHvamZjJSanE(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.rcgVAvJYOyccCeXMGXhtBgVRXAAb();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.ojQaPWjwYdVhoZsqlkpyOjVMDkdn();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.pjYjhLcFIZVVxCWWKlzxyxpLBKkf(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.RONwjKMELSizrftsBKUewdFPWoWbA(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.SLcuoNAuJOhgfciGuUyCDUHJJquq(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					VouJZmDPLGSEXPCTzKAxDlURnAgC.ZAhuuMdmCOdaHFekcblImUeVnbEXA(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					VouJZmDPLGSEXPCTzKAxDlURnAgC.BachvcTguUTLTWGAcMoKVSFoZeZA(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!ZSJAFPazSEmLOrDHlfzrFagTppzdA)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				vNbnUolXtDEBoShcpqSvAzFalZnS();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (KmkDqPgxNSXNiRZTawHQNMGRIrgNA.hbPLVVmrYZvTFcFqkCCgODLTCQzJ(i, j))
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
				if (!ZSJAFPazSEmLOrDHlfzrFagTppzdA)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				vNbnUolXtDEBoShcpqSvAzFalZnS();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (KmkDqPgxNSXNiRZTawHQNMGRIrgNA.hbPLVVmrYZvTFcFqkCCgODLTCQzJ(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (KmkDqPgxNSXNiRZTawHQNMGRIrgNA.NWyZCWuyDfHqZMYbAbZVOazZkeeI(i, k, positiveAxesOnly))
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
					if (!ZSJAFPazSEmLOrDHlfzrFagTppzdA)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						sshUGYCzCIzLUbpSPwGhPzcMldAC.SetUnityJoystickId(joystickId, unityJoystickId);
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
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.XvAOcIKVJdrnVzxITFVLOOsfHCAH(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.OHYzbWhCDJedNHkyxeQJXazGAEfPA();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.jXDpqtDNAKwfhDcAksduzWKZzXRc();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.rCiBQESZfsRuaGJhkJsXaIryMEqg(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.rbnzeILxAbqIjxxsjhAWxMKDjLNe(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.xPunGBCMChMTuGgFWGtTdruoYHzL(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					VouJZmDPLGSEXPCTzKAxDlURnAgC.wzvRppNUsgCKRdXlfrbszeNEsSot(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					VouJZmDPLGSEXPCTzKAxDlURnAgC.irdAqnavOmwSihLHXkHBiTNZVPpB(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.JlfQnWRmJLDrniFGUGXtiLXbIAIO(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = WUBqcfcHLvbkdiiUnEhQlzYVACJm.JlfQnWRmJLDrniFGUGXtiLXbIAIO(sourceControllerId);
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
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.avXDjqtUsROcOwdiGscGBuDLkXal(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.ugHspKWCYOKYqoJhblJOVOOkAmpkA(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.RwXTdvqtKvefkLtmoEHPnirBUDcL(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.puEXWMSeBjmVlqBULIqqQyoTZFDf(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.uNrfzbHTigEApugzKMGrCKlzopvtA(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.XRreBdbBvDwUCdYLxSGEHDKbIPCCb<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.PmHCxACwyGCOFvVzcMTfWBGubFLGA();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.jflmIHcsvKPjKVoaEeCOheMyqMYK(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.PmHCxACwyGCOFvVzcMTfWBGubFLGA<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.jkHoswdJNMmoRlmwAdfScmqOQaAm();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					WUBqcfcHLvbkdiiUnEhQlzYVACJm.rqRFubVqBTsPtkmTTFQVjzOKEoxK(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					WUBqcfcHLvbkdiiUnEhQlzYVACJm.TdiyplLkVVQRqNCeXXZJGYpNAedT(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					WUBqcfcHLvbkdiiUnEhQlzYVACJm.IRyleYPvXLKxXzUQFwigTVoEjvyE(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					WUBqcfcHLvbkdiiUnEhQlzYVACJm.JyKQYEFHOcCsCnSUcaQEkibJYySsA(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					WUBqcfcHLvbkdiiUnEhQlzYVACJm.bCNoccdaIrispcRYXJrzYyjjtxiBA();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.AzMccuIzYZCZxFPIZYeHUUsUCWyDA();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.pNhuVTerGZEDftSiNDYORvUZaYZd(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.nhHQFBNdYhBYMcdfTzhWXJtcMIZw();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.ygqxtaQAAdUmiOFNFilzfwpKKqNwA(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.GufsrcKjvTyDfDDYDpKoXuroANED();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.oWCImHAZWtcIGuoAnfdqFYskaognA(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.ZCDEcfYdlmSHVwITtCVAZhqUdtam();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.IzuKpvDUtuTYJPKjYOHNoQiXVyAA(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.sYxEIFSDJaUUGxbygfVieRIqftVM();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.nDVXsUJMOgKOHZEfxzUqbwUmOSDM(controllerType);
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
				VouJZmDPLGSEXPCTzKAxDlURnAgC.jXoqutavsNBfWWIeOzvWSVwdbfRT(joystick);
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
			private static MappingHelper KqrDGlUOtRIFrJTTyfYmEZDJMNSf;

			internal static MappingHelper ZQUfslhbQhTHasbsshFCCTlKaMIlb => KqrDGlUOtRIFrJTTyfYmEZDJMNSf ?? (KqrDGlUOtRIFrJTTyfYmEZDJMNSf = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ckIHfthJnEQqFUQQhKHZpqLnWNQH;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.oiHpIwpGjoatCGcGufkeHCJobTZl;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.RZGeymbvACCaHRQDBiCaiOLWZaWWA;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.KFyBrCxYbinHtSBhkthvBkfYdkgCA;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.soeahDnvWEUInkXpARYGfVZaEGgH;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GRVglZafkGhPDbzQDTqQNLFHEITLb;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.XCFOJdLTNnjYWkByIFJXmtPtnpXA;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ABMPfALCxGYKrCWXBvyTJnHswxzb;
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
					return prxXuKwOwEjZuqOfmARKiCcLjOdAA.jyuLoFNATCeressrQgpNGCxIRXCeA;
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
					return zCDqGEhTxmNAFQUBgylNBlDdZINJ.YLNHPIpRrTbKXqcoCsqOIIPXcNNi;
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
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.ojAMOEysTWIgjjfDpcqBCxhBdvFU(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.xZUzmwibstpRAiiJLDuciRLjDiRyA(tag);
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
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.DWwKxTVidLKgzrWJmhUEvPfmrKnF(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.dfFVQLfuJowRSUrsKinwKCjvebmG(tag);
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
					ControllerType.Joystick => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetCustomControllerLayoutById(layoutId), 
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
					ControllerType.Joystick => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetJoystickLayout(name), 
					ControllerType.Keyboard => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetKeyboardLayout(name), 
					ControllerType.Mouse => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetMouseLayout(name), 
					ControllerType.Custom => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetCustomControllerLayout(name), 
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
					ControllerType.Joystick => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetMouseLayoutId(name), 
					ControllerType.Custom => zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetCustomControllerLayoutId(name);
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
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.NnHeJtGFsRRYnvgXwGhKJzQQRtcY(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.NnHeJtGFsRRYnvgXwGhKJzQQRtcY(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.pSHNxtuOutXDmtiPrKTrzPMSgNAC(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.pSHNxtuOutXDmtiPrKTrzPMSgNAC(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.wwbAeZBwigwufXpTFHIHJHciAKwv(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.MjzPYWTIViYYAByoNZxkChQKEFGg(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.MjzPYWTIViYYAByoNZxkChQKEFGg(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.hLjeOmjntEKAZURVTGLgTedgcDLhA(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.hLjeOmjntEKAZURVTGLgTedgcDLhA(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.VOFiqERXjAvCjjqOvJfeHzvMfmCv(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.VOFiqERXjAvCjjqOvJfeHzvMfmCv(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.HquYTqzJPbmOsyQHFsOTzKtmyUgP(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return WUBqcfcHLvbkdiiUnEhQlzYVACJm.SDMFAWCrgmleeoNXrjhdUhSXNceBA(playerId, behaviorName);
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
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior TSZoBUIlaafTMpBTwSqsYUMLGdBF(int P_0)
			{
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetInputBehaviorById(P_0);
			}

			internal InputBehavior QROHcBffuLcrTChMdjioUEJpHidf(string P_0)
			{
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetInputBehavior(P_0);
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
				Controller controller = WUBqcfcHLvbkdiiUnEhQlzYVACJm.HXqDyahUzpKQPuoAHBEQrHhlLEOiA(controllerIdentifier);
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
				JoystickMap joystickMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.ofgceWFBKkrijXmMdOMJaICYoztJ(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.CcpVpJXpmYkVYgqCIFpzMFDIxVbs(joystickMap);
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
				InputSource inputSourceType = sshUGYCzCIzLUbpSPwGhPzcMldAC.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = CJmBaqyzKLtcgmGuniaRETPlVLVg.eoBggzlWIVqDFpVvbWWxQMcFSygj(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.MVHgjIqDhLqNwgZLhrRSmTtNpiSk(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.vEGQzUymTGCTIdiJWrhjoKSxdEBL(joystickMap, hardwareControllerMap_Game);
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
				if (WUBqcfcHLvbkdiiUnEhQlzYVACJm.HXqDyahUzpKQPuoAHBEQrHhlLEOiA(controllerIdentifier) is Joystick joystick)
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
				KeyboardMap keyboardMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.CcpVpJXpmYkVYgqCIFpzMFDIxVbs(keyboardMap);
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
				MouseMap mouseMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.CcpVpJXpmYkVYgqCIFpzMFDIxVbs(mouseMap);
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
				CustomControllerMap customControllerMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.FOpnPAIEvAFTsdbpngFJvcNiJQaEb(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.CcpVpJXpmYkVYgqCIFpzMFDIxVbs(customControllerMap);
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
				if (WUBqcfcHLvbkdiiUnEhQlzYVACJm.HXqDyahUzpKQPuoAHBEQrHhlLEOiA(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.YmbxuyuXpSmSheLBzftpCALfaFcqA(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.vEGQzUymTGCTIdiJWrhjoKSxdEBL(customControllerMap, hardwareControllerMap_Game);
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
					controllerMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.pPgpuDFygCUisHKHQWpvgEBAJPeK(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.IzGwVnFCClAbFXbaSFePgRIYWnxIA(controller, controllerMap);
					}
					else
					{
						controller.CcpVpJXpmYkVYgqCIFpzMFDIxVbs(controllerMap);
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
				if (WUBqcfcHLvbkdiiUnEhQlzYVACJm.HXqDyahUzpKQPuoAHBEQrHhlLEOiA(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = sshUGYCzCIzLUbpSPwGhPzcMldAC.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = CJmBaqyzKLtcgmGuniaRETPlVLVg.eoBggzlWIVqDFpVvbWWxQMcFSygj(controllerIdentifier.hardwareTypeGuid, inputSourceType);
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
					joystickMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.MVHgjIqDhLqNwgZLhrRSmTtNpiSk(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
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
						allMap.vEGQzUymTGCTIdiJWrhjoKSxdEBL(joystickMap, hardwareControllerMap_Game);
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
				if (WUBqcfcHLvbkdiiUnEhQlzYVACJm.HXqDyahUzpKQPuoAHBEQrHhlLEOiA(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
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
					customControllerMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.YmbxuyuXpSmSheLBzftpCALfaFcqA(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.vEGQzUymTGCTIdiJWrhjoKSxdEBL(customControllerMap, hardwareControllerMap_Game);
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
					keyboardMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.IzGwVnFCClAbFXbaSFePgRIYWnxIA(keyboard, keyboardMap);
					}
					else
					{
						keyboard.CcpVpJXpmYkVYgqCIFpzMFDIxVbs(keyboardMap);
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
					mouseMap = zCDqGEhTxmNAFQUBgylNBlDdZINJ.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.IzGwVnFCClAbFXbaSFePgRIYWnxIA(mouse, mouseMap);
					}
					else
					{
						mouse.CcpVpJXpmYkVYgqCIFpzMFDIxVbs(mouseMap);
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
				return ddhcRdFvKjVWuNXoDjtuRlNhjotJ(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier ddhcRdFvKjVWuNXoDjtuRlNhjotJ(Guid P_0, int P_1)
			{
				return CJmBaqyzKLtcgmGuniaRETPlVLVg.jqMaQDCFTUvLskauDHuHFTkKdaJK(P_0, P_1)?.ToControllerElementIdentifier();
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.KEvHIvSAbvNISdOVKPguruDeXAM(templateTypeGuid, mapCategoryId, layoutId);
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
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetControllerMapLayoutManagerRuleSetId(name);
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
				return zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper oNzAjliyTVtHwoJKkEOxQnrbSFAhA;

			internal static PlayerHelper qkSLDKEgRnJzjguTaLCYqMHBeUyb => oNzAjliyTVtHwoJKkEOxQnrbSFAhA ?? (oNzAjliyTVtHwoJKkEOxQnrbSFAhA = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return VouJZmDPLGSEXPCTzKAxDlURnAgC.QgKBkzTWRhNyHSaqnbOBoqQdimmk;
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
					return VouJZmDPLGSEXPCTzKAxDlURnAgC.mooyxmIaIkRmxhKLrtWLQNfGkXnC;
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
					return VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl;
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
					return VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA;
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
					return VouJZmDPLGSEXPCTzKAxDlURnAgC.LPpnIhYgEyRiiqljhjpHPsIBtMwL();
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
					return VouJZmDPLGSEXPCTzKAxDlURnAgC.yAwpzjFCiQoMTZIlbKhXnUfBNRjl;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.PMpThobquCgsRjfzpSvflwDGgSfmA;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.CdVzoIAGjOsZSBsVEHDGWSgvSrMu(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.yDDPDFuPIyZoCdTwIddvOaQsOZSb(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.LPpnIhYgEyRiiqljhjpHPsIBtMwL();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.VSZbmXOPTkgGrdIhFbZvJCljdOblA(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.VcTfkUBSznrojWSaanOBsGcugzyE(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.ghDfFjEGXXQGFoleWBnJGHaMyVoE(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return VouJZmDPLGSEXPCTzKAxDlURnAgC.EPutkDjhkekPRywUlzDFIEwvfBDP(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper LvkbzrIGypgrqcLBgGCYByAlcUspA;

			internal static TimeHelper rbCdVSpCGVWUmEsqUfZNlvMSoSHG => LvkbzrIGypgrqcLBgGCYByAlcUspA ?? (LvkbzrIGypgrqcLBgGCYByAlcUspA = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)qnUinDQAjgDhqPDjdzVTrfTyQMAo.RAEUQYtqvOmiZebvIDEMQwwDencg;
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
					return qnUinDQAjgDhqPDjdzVTrfTyQMAo.AuDxFzmmxGPGIfGmBQSoTkJrQHtF;
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
					return qnUinDQAjgDhqPDjdzVTrfTyQMAo.XuCkqahyDPRedUhTddcoQHbkfNZn;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class MiQEFGuimaGvgXtjBDDFmRsvaxfL
		{
			private class HDPneDzLHprMNCqvHpthOCgsbafiA
			{
				public readonly UpdateLoopType SqwhagiKolbmgbbdXJJWFiEROfiWA;

				private double PMnPPwqeYtPOhMBzIEYHxxGjtqKC;

				private double VjnfiyFhvlsCxrcbKFXGlJLepLHJA;

				private double GoNmjloMMQMQlEBMVHsfdcHOCIpLA;

				private double BbwATJsrgpBMJhqXvqeHkhlMeFSQ;

				private uint ZNuUxVllMhVaHqVIwqdGvEELiSxBA;

				private uint iHHJOPFGtRnXPRwmyNtpTfvavtnU;

				private float fbHKibQKqhTuMWgPUbSZihLfMboo;

				private float uvyVLUFugJtRBZTjTcUcIeHIeQLv;

				public double FZmCxJYTbdEKMFgqdwYIiLLYBMDjb => PMnPPwqeYtPOhMBzIEYHxxGjtqKC;

				public double VJUpHxIodqiKOEDRoAsdUBMpbrmY => VjnfiyFhvlsCxrcbKFXGlJLepLHJA;

				public double uLTowqpLkBFhnVoPCOvMyWkFvGSV => GoNmjloMMQMQlEBMVHsfdcHOCIpLA;

				public uint RFzedDETkuCtTHWYgswbLOhMjHeQA => ZNuUxVllMhVaHqVIwqdGvEELiSxBA;

				public uint jEefIcikPOeYXILzIKRQEcXrjFAjA => iHHJOPFGtRnXPRwmyNtpTfvavtnU;

				public float fdthtSnpFxBCJqNSxerUREowwJIc => fbHKibQKqhTuMWgPUbSZihLfMboo;

				public float DvqEWzCGrCHqyskTUVfbzfoVrCBG => uvyVLUFugJtRBZTjTcUcIeHIeQLv;

				public HDPneDzLHprMNCqvHpthOCgsbafiA(UpdateLoopType P_0)
				{
					SqwhagiKolbmgbbdXJJWFiEROfiWA = P_0;
					BbwATJsrgpBMJhqXvqeHkhlMeFSQ = Time.realtimeSinceStartup;
					ZNuUxVllMhVaHqVIwqdGvEELiSxBA = 0u;
				}

				public void vXbnFfeEsTloYyQWapgaijdALqqp()
				{
					VjnfiyFhvlsCxrcbKFXGlJLepLHJA = PMnPPwqeYtPOhMBzIEYHxxGjtqKC;
					PMnPPwqeYtPOhMBzIEYHxxGjtqKC = realTime;
					if (BbwATJsrgpBMJhqXvqeHkhlMeFSQ > PMnPPwqeYtPOhMBzIEYHxxGjtqKC)
					{
						BbwATJsrgpBMJhqXvqeHkhlMeFSQ = 0.0;
					}
					GoNmjloMMQMQlEBMVHsfdcHOCIpLA = PMnPPwqeYtPOhMBzIEYHxxGjtqKC - BbwATJsrgpBMJhqXvqeHkhlMeFSQ;
					BbwATJsrgpBMJhqXvqeHkhlMeFSQ = PMnPPwqeYtPOhMBzIEYHxxGjtqKC;
					iHHJOPFGtRnXPRwmyNtpTfvavtnU = ZNuUxVllMhVaHqVIwqdGvEELiSxBA;
					ZNuUxVllMhVaHqVIwqdGvEELiSxBA = MiscTools.Tick(ZNuUxVllMhVaHqVIwqdGvEELiSxBA);
					uvyVLUFugJtRBZTjTcUcIeHIeQLv = fbHKibQKqhTuMWgPUbSZihLfMboo;
					fbHKibQKqhTuMWgPUbSZihLfMboo = laCaVXsqpKgTpgjFmOQjftcvRByh();
					previousFrame = iHHJOPFGtRnXPRwmyNtpTfvavtnU;
					currentFrame = ZNuUxVllMhVaHqVIwqdGvEELiSxBA;
					unscaledTime = PMnPPwqeYtPOhMBzIEYHxxGjtqKC;
					unscaledTimePrev = VjnfiyFhvlsCxrcbKFXGlJLepLHJA;
					unscaledDeltaTime = GoNmjloMMQMQlEBMVHsfdcHOCIpLA;
				}
			}

			private static class cjCTvCyBFbcxSCmHHqMvDakttxIg
			{
				public static StopwatchBase mMYzcyfYRvmzpomkEgumwadAhzTM
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

				public static StopwatchBase lEpvntDSlZorpqIfdSBrXYVJQyAw()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase aNIGjnSMbRRyChDfNOJXdDeFhKkS()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase AMhsABlHtNkCZZYThJCEbehDJNv;

			private double oCegOTXcXucvMIpzRRjUhhLoHVOx;

			private HDPneDzLHprMNCqvHpthOCgsbafiA AlHnHbEIpeSIdCLosYwzwJsptJHs;

			private ADictionary<int, HDPneDzLHprMNCqvHpthOCgsbafiA> jBEJqpmKqzfKGEjxwDspbVZeFBekc;

			private uint NpXkReMrvCZWDFOJhYbVgCFGNJZd;

			public double AuDxFzmmxGPGIfGmBQSoTkJrQHtF => AlHnHbEIpeSIdCLosYwzwJsptJHs.FZmCxJYTbdEKMFgqdwYIiLLYBMDjb;

			public double AyxIGVHSpkpGrfnUTsWpuuKxDxoL => AlHnHbEIpeSIdCLosYwzwJsptJHs.VJUpHxIodqiKOEDRoAsdUBMpbrmY;

			public double RAEUQYtqvOmiZebvIDEMQwwDencg => AlHnHbEIpeSIdCLosYwzwJsptJHs.uLTowqpLkBFhnVoPCOvMyWkFvGSV;

			public float KjtaCtrPBwIxttBRYIdByFdOoGBc => AlHnHbEIpeSIdCLosYwzwJsptJHs.fdthtSnpFxBCJqNSxerUREowwJIc;

			public float XaZmYdrMbEpgNzgIuxHRZKiyqffF => AlHnHbEIpeSIdCLosYwzwJsptJHs.DvqEWzCGrCHqyskTUVfbzfoVrCBG;

			internal double SWseGKEKtLBQjCVLFGusJZfavmhFB => AMhsABlHtNkCZZYThJCEbehDJNv.elapsedSeconds + oCegOTXcXucvMIpzRRjUhhLoHVOx;

			public uint XuCkqahyDPRedUhTddcoQHbkfNZn => AlHnHbEIpeSIdCLosYwzwJsptJHs.RFzedDETkuCtTHWYgswbLOhMjHeQA;

			public uint FurHKCcmCDjCqvVEMsmqQMqdsUoP => AlHnHbEIpeSIdCLosYwzwJsptJHs.jEefIcikPOeYXILzIKRQEcXrjFAjA;

			public uint lQkfIaeXrAxoyXibORqomFpoqpxc => NpXkReMrvCZWDFOJhYbVgCFGNJZd;

			public MiQEFGuimaGvgXtjBDDFmRsvaxfL()
			{
				AMhsABlHtNkCZZYThJCEbehDJNv = cjCTvCyBFbcxSCmHHqMvDakttxIg.mMYzcyfYRvmzpomkEgumwadAhzTM;
				enJcVPDdLGmbmKiPebSgyRdvkBEl();
			}

			public void xwJkMTkfMQvgaJnzNfxFxrlyFlAeA()
			{
				oCegOTXcXucvMIpzRRjUhhLoHVOx = Time.realtimeSinceStartup;
			}

			public void enJcVPDdLGmbmKiPebSgyRdvkBEl()
			{
				AlHnHbEIpeSIdCLosYwzwJsptJHs = null;
				jBEJqpmKqzfKGEjxwDspbVZeFBekc = new ADictionary<int, HDPneDzLHprMNCqvHpthOCgsbafiA>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)2147483647, list);
				for (int i = 0; i < list.Count; i++)
				{
					HDPneDzLHprMNCqvHpthOCgsbafiA hDPneDzLHprMNCqvHpthOCgsbafiA = new HDPneDzLHprMNCqvHpthOCgsbafiA(list[i]);
					jBEJqpmKqzfKGEjxwDspbVZeFBekc.Add((int)list[i], hDPneDzLHprMNCqvHpthOCgsbafiA);
					if (AlHnHbEIpeSIdCLosYwzwJsptJHs == null)
					{
						AlHnHbEIpeSIdCLosYwzwJsptJHs = hDPneDzLHprMNCqvHpthOCgsbafiA;
					}
				}
			}

			public void kjyalTLvzQBJlhRIwOknSmmsNZtn(UpdateLoopType P_0)
			{
				if (AlHnHbEIpeSIdCLosYwzwJsptJHs.SqwhagiKolbmgbbdXJJWFiEROfiWA != P_0)
				{
					AlHnHbEIpeSIdCLosYwzwJsptJHs = jBEJqpmKqzfKGEjxwDspbVZeFBekc[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					AlHnHbEIpeSIdCLosYwzwJsptJHs.vXbnFfeEsTloYyQWapgaijdALqqp();
					NpXkReMrvCZWDFOJhYbVgCFGNJZd = MiscTools.Tick(NpXkReMrvCZWDFOJhYbVgCFGNJZd);
					absFrame = NpXkReMrvCZWDFOJhYbVgCFGNJZd;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch sUFzEeJUmHWxRbZYORlZmQlKZfHL;

			internal static UnityTouch WLwUnJFLwQPOZpLHJSCaRARWAnze => sUFzEeJUmHWxRbZYORlZmQlKZfHL ?? (sUFzEeJUmHWxRbZYORlZmQlKZfHL = new UnityTouch());

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

		internal class xZFITjbtGaRVuWvMsohxNPcciOJI
		{
			[Serializable]
			private sealed class akXQGzTKPVpIbBSeDkTWfOFJcYlJ
			{
				public static readonly akXQGzTKPVpIbBSeDkTWfOFJcYlJ _003C_003E9 = new akXQGzTKPVpIbBSeDkTWfOFJcYlJ();

				public static Func<bool> _003C_003E9__11_1;

				public static Func<bool> _003C_003E9__11_2;

				public static Func<int> _003C_003E9__11_3;

				public static Func<float> _003C_003E9__11_4;

				public static Func<bool> _003C_003E9__11_5;

				public static Func<string> _003C_003E9__11_0;

				internal bool SWuQXaaFERfDhreyBEQKJdReWkhFA()
				{
					return Screen.fullScreen;
				}

				internal bool inMOKjCPCCuedFnycQqyuWHsQsgO()
				{
					return Application.runInBackground;
				}

				internal int xtGDhysRIVSrpcQBgquHHyyGSBJu()
				{
					return (int)Screen.fullScreenMode;
				}

				internal float iUvHmQtOKLiecDRVElGmaVRbIcnUA()
				{
					return Time.unscaledDeltaTime;
				}

				internal bool HNwAKCwMrmhVZBYggGxKWWtltwUt()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				internal string DYSbIcysJfYgkWljXBxYJoQJdLVH()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}
			}

			public readonly ValueWatcher<bool> iDwgARdclxgluVbQzxQPvKBEGbuhb;

			public readonly ValueWatcher<bool> KYdIleVPWVcCxITfxDLoUfWCMnZA;

			public readonly ValueWatcher<bool> ovPGBNhsomsMknOdlqKpIBYJQgygA;

			public readonly ValueWatcher<int> wbXgidaUHQrqWCRnODdTZOHgiwhC;

			public readonly ValueWatcher<float> VGsMGiVCeIGDBBuBfmsjuSdKwtKd;

			public readonly ValueWatcher<string> LDhBlJRDSOWcIVgEPLOxyrJOwMvF;

			public readonly ValueWatcher<bool> GKWSbthJjIJNogLHkBgcJaiQOpLnA;

			private int vSOkLcKnOOxesdbSoELFikNWBTJp;

			private readonly ValueWatcher[] QXHzhsamSkSlxbFpxdIneWqxndRRA;

			public int YgVAUcgjqTbekeMqRNXxLXdwWNcVA => vSOkLcKnOOxesdbSoELFikNWBTJp;

			public xZFITjbtGaRVuWvMsohxNPcciOJI()
			{
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(iDwgARdclxgluVbQzxQPvKBEGbuhb = new ValueWatcher<bool>(true, false)),
					(KYdIleVPWVcCxITfxDLoUfWCMnZA = new ValueWatcher<bool>(Screen.fullScreen, akXQGzTKPVpIbBSeDkTWfOFJcYlJ._003C_003E9.SWuQXaaFERfDhreyBEQKJdReWkhFA, false)),
					(ovPGBNhsomsMknOdlqKpIBYJQgygA = new ValueWatcher<bool>(Application.runInBackground, akXQGzTKPVpIbBSeDkTWfOFJcYlJ._003C_003E9.inMOKjCPCCuedFnycQqyuWHsQsgO, false)),
					(wbXgidaUHQrqWCRnODdTZOHgiwhC = new ValueWatcher<int>((int)Screen.fullScreenMode, akXQGzTKPVpIbBSeDkTWfOFJcYlJ._003C_003E9.xtGDhysRIVSrpcQBgquHHyyGSBJu, false)),
					(VGsMGiVCeIGDBBuBfmsjuSdKwtKd = new ValueWatcher<float>(Time.unscaledDeltaTime, akXQGzTKPVpIbBSeDkTWfOFJcYlJ._003C_003E9.iUvHmQtOKLiecDRVElGmaVRbIcnUA, false)),
					(GKWSbthJjIJNogLHkBgcJaiQOpLnA = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), akXQGzTKPVpIbBSeDkTWfOFJcYlJ._003C_003E9.HNwAKCwMrmhVZBYggGxKWWtltwUt, MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(LDhBlJRDSOWcIVgEPLOxyrJOwMvF = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), akXQGzTKPVpIbBSeDkTWfOFJcYlJ._003C_003E9.DYSbIcysJfYgkWljXBxYJoQJdLVH, false));
				}
				QXHzhsamSkSlxbFpxdIneWqxndRRA = list.ToArray();
				oxWsdfXSDqGbBaDPvmWfCGQJnCZOc();
			}

			public void oxWsdfXSDqGbBaDPvmWfCGQJnCZOc()
			{
				for (int i = 0; i < QXHzhsamSkSlxbFpxdIneWqxndRRA.Length; i++)
				{
					QXHzhsamSkSlxbFpxdIneWqxndRRA[i].Update();
				}
				vSOkLcKnOOxesdbSoELFikNWBTJp = Time.frameCount;
			}

			public void LWTNzNmzfWaodCbpPIeRIqgEnfDM()
			{
				for (int i = 0; i < QXHzhsamSkSlxbFpxdIneWqxndRRA.Length; i++)
				{
					QXHzhsamSkSlxbFpxdIneWqxndRRA[i].TriggerEvent();
				}
			}
		}

		[Serializable]
		private sealed class XdHCtrUrhOQOgSkanlBXzDMnbwHq
		{
			public static readonly XdHCtrUrhOQOgSkanlBXzDMnbwHq _003C_003E9 = new XdHCtrUrhOQOgSkanlBXzDMnbwHq();

			public static Func<bool> _003C_003E9__222_0;

			internal void pfJhbIJfXUdWApqUXzeTvTmQdDgcb(Exception P_0)
			{
				HandleCallbackException("", P_0);
			}

			internal void xPgirIypcHFvZqnPBgHTYDJVziWR(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			}

			internal void IMEzIMEURPGgBKQFxiQBqVRSidWW(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			}

			internal void ydwqgNIWwVoXRTnTkgKAtHXtwJRu(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			}

			internal void LiIKNLKMIbuiJwerAnrstXQBgbax(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			}

			internal void buQJYVQGemYfIMwhlTtGrbITMAwB(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			}

			internal void OXHXPClTZeCTJjliXdcuGMwHWrsj(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			}

			internal void ClQCrIcLDBkjfEgKIPahdxrgzTXTb(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			}

			internal void mYwBRidYwzOOGQagOdLZiBYTTqQoA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			}

			internal bool ihBfPUXRtwvvxKGayhAXoeOracHEA()
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
		internal const int programVersion3 = 45;

		[CustomObfuscation(rename = false)]
		internal const int programVersion4 = 0;

		[CustomObfuscation(rename = false)]
		internal const int dataVersion = 1;

		[CustomObfuscation(rename = false)]
		internal const bool isTrial = false;

		[CustomObfuscation(rename = false)]
		internal const string majorBranch = "U2022";

		private static InputManager_Base tGysrhjbFLFrPgXIMcaBbLLWWuFOA;

		private static PlatformInputManager sshUGYCzCIzLUbpSPwGhPzcMldAC;

		internal static SfPfxaQrjElDDUkmFFxxeUUjFvLIA prxXuKwOwEjZuqOfmARKiCcLjOdAA;

		internal static IevfLhwIfTciNnbiFjVqslbhqjt WUBqcfcHLvbkdiiUnEhQlzYVACJm;

		internal static cphySyblTqRHzdCDofohJZUaAidOA VouJZmDPLGSEXPCTzKAxDlURnAgC;

		private static ControllerDataFiles CJmBaqyzKLtcgmGuniaRETPlVLVg;

		private static UserData zCDqGEhTxmNAFQUBgylNBlDdZINJ;

		private static bool pSTaCukNUoEKDRgpOLQTDccaXDAqB;

		private static ConfigVars RlIDQmCuUoarYIPHdoQoxUAGGFpXA;

		private static UpdateLoopType gWAkDmZrzcRdSGrXIGTUXjBkgnFhA;

		private static bool ZSJAFPazSEmLOrDHlfzrFagTppzdA;

		private static Platform JtVlEYIdwTMZxWDWzCIAKPpoZrFm;

		private static WebplayerPlatform kifIeOdMBpgaIjSHllKrFLanVJoV;

		private static EditorPlatform UbEFcELxcMRbeOFRFlzlwPEVUZEP;

		private static bool WXclTgUcQfebCRTWIswlsrbAgdrQ;

		private static TimerAbs lafhvvLusIaqxDQwZFdzUlxqoAlHb;

		private static MiQEFGuimaGvgXtjBDDFmRsvaxfL qnUinDQAjgDhqPDjdzVTrfTyQMAo;

		private static string RXUCqLzJggGmRDVUvqzGfcDssFH;

		private static bool DgqQZOQUowIeCfQKVpEAqmGwDvtn;

		private static bool anqbMRdoEEBKNlNiSnbPwUnqgDQpA;

		private static bool gJJMTbzZjBhEldYVKNoFNYxyfiar;

		private static int davEbLNameENdDEjLQrxpTZqDWWdb;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int XlvZCODMQozQCuSzHgQoFJdNduHJ;

		private static int gjsyGpOJRSSUjRBUWpqlQCUsqBVy;

		private static bool prlRHUFholaMmazdwEHMTmdeEiadA;

		private static readonly UnityTouch RSbDKwNDMjYJOccYAODTHMvgqmuR;

		private static readonly PlayerHelper YfUflcCFWGflwZsTACMMTXBOVQkw;

		private static readonly ControllerHelper htfavCSPKfMtMJAPsFqrAlWLVsSQ;

		private static readonly MappingHelper GcLETDuEhJmZCrQXqjRZzDQQctbQ;

		private static readonly TimeHelper UfgWkksywYfBecerdYOtTixxoloP;

		private static readonly ConfigHelper YVyEUWdLCdVqWsimefzBYUksRhBUA;

		private static nUJgYArIGyJREiRpVnTschssHiew lpUfZcOeqvdNOKkGCeOzDSbfkQop;

		private static UserDataStore VeaitAAcKEfvNYhnQtoyHXItWIbAA;

		private static IControllerAssigner SoGBixweDUvzjAchbCjMAhlqEPGh;

		private static xZFITjbtGaRVuWvMsohxNPcciOJI DMqhrzriSLlkfCJUZcWlbEcYnKsKA;

		private static SafeAction<ControllerStatusChangedEventArgs> NtYsLSRUxEkCMIyoEGtvMyKgFzpH;

		private static SafeAction<ControllerStatusChangedEventArgs> afssTaOHqNnWSLPteqExbAFAVahs;

		private static SafeAction<ControllerStatusChangedEventArgs> BeiJoVGqdzczdGpBIgarWXJvKhIM;

		private static SafeAction MAeKbWEpNHuEdFLpyEbfbrcVNUESA;

		private static SafeAction wPGVulalQLHCwzJytfiNXQEWUuPl;

		private static SafeAction eAaOaYORxBwDCvgMLWSRGcfmLGuH;

		private static SafeAction umoqUpGAeuXnpMgvbcBAKbXiCpKu;

		private static SafeAction gDAgmcPLrHcIfMZejaqgPkbvSZUJ;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action qUVDNdCoPMpEktAjbVpIrivKpByqA;

		private static Action<UpdateLoopType> szEdgGaRoxDEskyFGDtpsleYMDxZ;

		private static Action<UpdateLoopType> WKZscmkDdBDAgLqYpnwnhUkBJyGw;

		private static Action<UpdateLoopType> heWXixkNLpsLyKerSeJGQROYKTvE;

		private static Action UXiwQuLvPmQYnfEgzIloaxBdubEp;

		private static Action<bool> QTYQBrEmEejFnHcieCVuuxAeeGhu;

		private static Action<bool> rmhYJBFpzsbkFALkqUiuehiUByBO;

		private static Action<bool> NyHwroGMKwYZwttowQJwZRdcofpU;

		private static Action<FullScreenMode> PwjcWbJgTSccCFEiWECFPGvqyqrhA;

		private static Action CGraKiivMKnTlfjTjROhbPvnRkyTB;

		private static Action<bool> kETANuwkokGCxqVAojHMeMEkmUzGb;

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

		private static nUJgYArIGyJREiRpVnTschssHiew KmkDqPgxNSXNiRZTawHQNMGRIrgNA => lpUfZcOeqvdNOKkGCeOzDSbfkQop ?? (lpUfZcOeqvdNOKkGCeOzDSbfkQop = new nUJgYArIGyJREiRpVnTschssHiew(RlIDQmCuUoarYIPHdoQoxUAGGFpXA.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					rmpDbcszCztqcuEpJytwJGEZCzLg();
					return null;
				}
				return YfUflcCFWGflwZsTACMMTXBOVQkw;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					rmpDbcszCztqcuEpJytwJGEZCzLg();
					return null;
				}
				return htfavCSPKfMtMJAPsFqrAlWLVsSQ;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					rmpDbcszCztqcuEpJytwJGEZCzLg();
					return null;
				}
				return GcLETDuEhJmZCrQXqjRZzDQQctbQ;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					rmpDbcszCztqcuEpJytwJGEZCzLg();
					return null;
				}
				return RSbDKwNDMjYJOccYAODTHMvgqmuR;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					rmpDbcszCztqcuEpJytwJGEZCzLg();
					return null;
				}
				return UfgWkksywYfBecerdYOtTixxoloP;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					rmpDbcszCztqcuEpJytwJGEZCzLg();
					return null;
				}
				return VeaitAAcKEfvNYhnQtoyHXItWIbAA;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					rmpDbcszCztqcuEpJytwJGEZCzLg();
					return null;
				}
				return YVyEUWdLCdVqWsimefzBYUksRhBUA;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 45 + "." + 0 + ".U2022";

		public static bool usingUnityInput => ZSJAFPazSEmLOrDHlfzrFagTppzdA;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
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

		public static bool isReady => pSTaCukNUoEKDRgpOLQTDccaXDAqB;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => pSTaCukNUoEKDRgpOLQTDccaXDAqB;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => gWAkDmZrzcRdSGrXIGTUXjBkgnFhA;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => RlIDQmCuUoarYIPHdoQoxUAGGFpXA;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => RlIDQmCuUoarYIPHdoQoxUAGGFpXA;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => zCDqGEhTxmNAFQUBgylNBlDdZINJ;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => JtVlEYIdwTMZxWDWzCIAKPpoZrFm;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => kifIeOdMBpgaIjSHllKrFLanVJoV;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => UbEFcELxcMRbeOFRFlzlwPEVUZEP;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.Linux && ZSJAFPazSEmLOrDHlfzrFagTppzdA)
				{
					return true;
				}
				if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.OSX && (ZSJAFPazSEmLOrDHlfzrFagTppzdA || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && ZSJAFPazSEmLOrDHlfzrFagTppzdA)
				{
					return true;
				}
				if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.Webplayer && kifIeOdMBpgaIjSHllKrFLanVJoV == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => UbEFcELxcMRbeOFRFlzlwPEVUZEP != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					return Guid.Empty;
				}
				return CJmBaqyzKLtcgmGuniaRETPlVLVg.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => anqbMRdoEEBKNlNiSnbPwUnqgDQpA;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => qnUinDQAjgDhqPDjdzVTrfTyQMAo.KjtaCtrPBwIxttBRYIdByFdOoGBc;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => qnUinDQAjgDhqPDjdzVTrfTyQMAo.XaZmYdrMbEpgNzgIuxHRZKiyqffF;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					return 0.0;
				}
				return qnUinDQAjgDhqPDjdzVTrfTyQMAo.SWseGKEKtLBQjCVLFGusJZfavmhFB;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					return 0;
				}
				return DMqhrzriSLlkfCJUZcWlbEcYnKsKA.YgVAUcgjqTbekeMqRNXxLXdwWNcVA;
			}
		}

		private static bool DnJBxefefkikAcBNeCHEXLsQvOXLc
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return RXUCqLzJggGmRDVUvqzGfcDssFH == "Game";
				}
				return RXUCqLzJggGmRDVUvqzGfcDssFH == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (RlIDQmCuUoarYIPHdoQoxUAGGFpXA.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!gJJMTbzZjBhEldYVKNoFNYxyfiar)
				{
					return DnJBxefefkikAcBNeCHEXLsQvOXLc;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (sshUGYCzCIzLUbpSPwGhPzcMldAC is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return gJJMTbzZjBhEldYVKNoFNYxyfiar;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					return false;
				}
				if (!ZSJAFPazSEmLOrDHlfzrFagTppzdA)
				{
					return false;
				}
				if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm != Platform.Windows && (JtVlEYIdwTMZxWDWzCIAKPpoZrFm != Platform.Webplayer || kifIeOdMBpgaIjSHllKrFLanVJoV != WebplayerPlatform.Windows))
				{
					return UbEFcELxcMRbeOFRFlzlwPEVUZEP == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool dpLbHNuIdHMlomXLqNNXyxyFNaoU
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					return false;
				}
				if (!DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.value)
				{
					if (prlRHUFholaMmazdwEHMTmdeEiadA)
					{
						return false;
					}
					if (!isEditor && !DMqhrzriSLlkfCJUZcWlbEcYnKsKA.ovPGBNhsomsMknOdlqKpIBYJQgygA.value)
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
				if (pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					return DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					return DMqhrzriSLlkfCJUZcWlbEcYnKsKA.KYdIleVPWVcCxITfxDLoUfWCMnZA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					return DMqhrzriSLlkfCJUZcWlbEcYnKsKA.ovPGBNhsomsMknOdlqKpIBYJQgygA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					return DMqhrzriSLlkfCJUZcWlbEcYnKsKA.GKWSbthJjIJNogLHkBgcJaiQOpLnA.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => tGysrhjbFLFrPgXIMcaBbLLWWuFOA;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
				{
					rmpDbcszCztqcuEpJytwJGEZCzLg();
					return null;
				}
				return sshUGYCzCIzLUbpSPwGhPzcMldAC.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return SoGBixweDUvzjAchbCjMAhlqEPGh;
			}
			set
			{
				SoGBixweDUvzjAchbCjMAhlqEPGh = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => gjsyGpOJRSSUjRBUWpqlQCUsqBVy;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				NtYsLSRUxEkCMIyoEGtvMyKgFzpH += value;
			}
			remove
			{
				NtYsLSRUxEkCMIyoEGtvMyKgFzpH -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				afssTaOHqNnWSLPteqExbAFAVahs += value;
			}
			remove
			{
				afssTaOHqNnWSLPteqExbAFAVahs -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				BeiJoVGqdzczdGpBIgarWXJvKhIM += value;
			}
			remove
			{
				BeiJoVGqdzczdGpBIgarWXJvKhIM -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				MAeKbWEpNHuEdFLpyEbfbrcVNUESA += value;
			}
			remove
			{
				MAeKbWEpNHuEdFLpyEbfbrcVNUESA -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				wPGVulalQLHCwzJytfiNXQEWUuPl += value;
			}
			remove
			{
				wPGVulalQLHCwzJytfiNXQEWUuPl -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				eAaOaYORxBwDCvgMLWSRGcfmLGuH += value;
			}
			remove
			{
				eAaOaYORxBwDCvgMLWSRGcfmLGuH -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				umoqUpGAeuXnpMgvbcBAKbXiCpKu += value;
			}
			remove
			{
				umoqUpGAeuXnpMgvbcBAKbXiCpKu -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				gDAgmcPLrHcIfMZejaqgPkbvSZUJ += value;
			}
			remove
			{
				gDAgmcPLrHcIfMZejaqgPkbvSZUJ -= value;
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
				qUVDNdCoPMpEktAjbVpIrivKpByqA = (Action)Delegate.Combine(qUVDNdCoPMpEktAjbVpIrivKpByqA, value);
			}
			remove
			{
				qUVDNdCoPMpEktAjbVpIrivKpByqA = (Action)Delegate.Remove(qUVDNdCoPMpEktAjbVpIrivKpByqA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				szEdgGaRoxDEskyFGDtpsleYMDxZ = (Action<UpdateLoopType>)Delegate.Combine(szEdgGaRoxDEskyFGDtpsleYMDxZ, value);
			}
			remove
			{
				szEdgGaRoxDEskyFGDtpsleYMDxZ = (Action<UpdateLoopType>)Delegate.Remove(szEdgGaRoxDEskyFGDtpsleYMDxZ, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				WKZscmkDdBDAgLqYpnwnhUkBJyGw = (Action<UpdateLoopType>)Delegate.Combine(WKZscmkDdBDAgLqYpnwnhUkBJyGw, value);
			}
			remove
			{
				WKZscmkDdBDAgLqYpnwnhUkBJyGw = (Action<UpdateLoopType>)Delegate.Remove(WKZscmkDdBDAgLqYpnwnhUkBJyGw, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				heWXixkNLpsLyKerSeJGQROYKTvE = (Action<UpdateLoopType>)Delegate.Combine(heWXixkNLpsLyKerSeJGQROYKTvE, value);
			}
			remove
			{
				heWXixkNLpsLyKerSeJGQROYKTvE = (Action<UpdateLoopType>)Delegate.Remove(heWXixkNLpsLyKerSeJGQROYKTvE, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				UXiwQuLvPmQYnfEgzIloaxBdubEp = (Action)Delegate.Combine(UXiwQuLvPmQYnfEgzIloaxBdubEp, value);
			}
			remove
			{
				UXiwQuLvPmQYnfEgzIloaxBdubEp = (Action)Delegate.Remove(UXiwQuLvPmQYnfEgzIloaxBdubEp, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				QTYQBrEmEejFnHcieCVuuxAeeGhu = (Action<bool>)Delegate.Combine(QTYQBrEmEejFnHcieCVuuxAeeGhu, value);
			}
			remove
			{
				QTYQBrEmEejFnHcieCVuuxAeeGhu = (Action<bool>)Delegate.Remove(QTYQBrEmEejFnHcieCVuuxAeeGhu, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				rmhYJBFpzsbkFALkqUiuehiUByBO = (Action<bool>)Delegate.Combine(rmhYJBFpzsbkFALkqUiuehiUByBO, value);
			}
			remove
			{
				rmhYJBFpzsbkFALkqUiuehiUByBO = (Action<bool>)Delegate.Remove(rmhYJBFpzsbkFALkqUiuehiUByBO, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				NyHwroGMKwYZwttowQJwZRdcofpU = (Action<bool>)Delegate.Combine(NyHwroGMKwYZwttowQJwZRdcofpU, value);
			}
			remove
			{
				NyHwroGMKwYZwttowQJwZRdcofpU = (Action<bool>)Delegate.Remove(NyHwroGMKwYZwttowQJwZRdcofpU, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				PwjcWbJgTSccCFEiWECFPGvqyqrhA = (Action<FullScreenMode>)Delegate.Combine(PwjcWbJgTSccCFEiWECFPGvqyqrhA, value);
			}
			remove
			{
				PwjcWbJgTSccCFEiWECFPGvqyqrhA = (Action<FullScreenMode>)Delegate.Remove(PwjcWbJgTSccCFEiWECFPGvqyqrhA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				CGraKiivMKnTlfjTjROhbPvnRkyTB = (Action)Delegate.Combine(CGraKiivMKnTlfjTjROhbPvnRkyTB, value);
			}
			remove
			{
				CGraKiivMKnTlfjTjROhbPvnRkyTB = (Action)Delegate.Remove(CGraKiivMKnTlfjTjROhbPvnRkyTB, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				kETANuwkokGCxqVAojHMeMEkmUzGb = (Action<bool>)Delegate.Combine(kETANuwkokGCxqVAojHMeMEkmUzGb, value);
			}
			remove
			{
				kETANuwkokGCxqVAojHMeMEkmUzGb = (Action<bool>)Delegate.Remove(kETANuwkokGCxqVAojHMeMEkmUzGb, value);
			}
		}

		static ReInput()
		{
			gJJMTbzZjBhEldYVKNoFNYxyfiar = true;
			davEbLNameENdDEjLQrxpTZqDWWdb = -1;
			_id = -1;
			XlvZCODMQozQCuSzHgQoFJdNduHJ = 0;
			RSbDKwNDMjYJOccYAODTHMvgqmuR = UnityTouch.WLwUnJFLwQPOZpLHJSCaRARWAnze;
			YfUflcCFWGflwZsTACMMTXBOVQkw = PlayerHelper.qkSLDKEgRnJzjguTaLCYqMHBeUyb;
			htfavCSPKfMtMJAPsFqrAlWLVsSQ = ControllerHelper.CsuKbPMYYdIqXzlzPdNxFQOpARmdA;
			GcLETDuEhJmZCrQXqjRZzDQQctbQ = MappingHelper.ZQUfslhbQhTHasbsshFCCTlKaMIlb;
			UfgWkksywYfBecerdYOtTixxoloP = TimeHelper.rbCdVSpCGVWUmEsqUfZNlvMSoSHG;
			YVyEUWdLCdVqWsimefzBYUksRhBUA = ConfigHelper.knzCGddRCsFunrfWEmZKGkfecRudb;
			NtYsLSRUxEkCMIyoEGtvMyKgFzpH = new SafeAction<ControllerStatusChangedEventArgs>(XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.xPgirIypcHFvZqnPBgHTYDJVziWR);
			afssTaOHqNnWSLPteqExbAFAVahs = new SafeAction<ControllerStatusChangedEventArgs>(XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.IMEzIMEURPGgBKQFxiQBqVRSidWW);
			BeiJoVGqdzczdGpBIgarWXJvKhIM = new SafeAction<ControllerStatusChangedEventArgs>(XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.ydwqgNIWwVoXRTnTkgKAtHXtwJRu);
			MAeKbWEpNHuEdFLpyEbfbrcVNUESA = new SafeAction(XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.LiIKNLKMIbuiJwerAnrstXQBgbax);
			wPGVulalQLHCwzJytfiNXQEWUuPl = new SafeAction(XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.buQJYVQGemYfIMwhlTtGrbITMAwB);
			eAaOaYORxBwDCvgMLWSRGcfmLGuH = new SafeAction(XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.OXHXPClTZeCTJjliXdcuGMwHWrsj);
			umoqUpGAeuXnpMgvbcBAKbXiCpKu = new SafeAction(XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.ClQCrIcLDBkjfEgKIPahdxrgzTXTb);
			gDAgmcPLrHcIfMZejaqgPkbvSZUJ = new SafeAction(XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.mYwBRidYwzOOGQagOdLZiBYTTqQoA);
			SafeDelegate.S_ExceptionHandler = XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.pfJhbIJfXUdWApqUXzeTvTmQdDgcb;
		}

		public static void Reset()
		{
			if (pSTaCukNUoEKDRgpOLQTDccaXDAqB && !(tGysrhjbFLFrPgXIMcaBbLLWWuFOA == null))
			{
				tGysrhjbFLFrPgXIMcaBbLLWWuFOA.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!dpLbHNuIdHMlomXLqNNXyxyFNaoU)
			{
				return false;
			}
			if (UbEFcELxcMRbeOFRFlzlwPEVUZEP != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (prlRHUFholaMmazdwEHMTmdeEiadA)
				{
					if (!DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.value)
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

		private static void GDQpmENfBIXPXYNCKCpZWsHiDZtu()
		{
			JtVlEYIdwTMZxWDWzCIAKPpoZrFm = UnityTools.platform;
			kifIeOdMBpgaIjSHllKrFLanVJoV = UnityTools.webplayerPlatform;
			UbEFcELxcMRbeOFRFlzlwPEVUZEP = UnityTools.editorPlatform;
		}

		internal static void OMYKFukhZskHtbQlRIOeCKIXVnlhA(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, UnityTools.RSjavNYDnzcBvAPUEIvOEFCjomGrA P_5, Action<Platform> P_6)
		{
			try
			{
				UnityTools.aorjqHeBqaMJCLvbPCUZQgcbYWSL(P_5);
				_id = XlvZCODMQozQCuSzHgQoFJdNduHJ;
				XlvZCODMQozQCuSzHgQoFJdNduHJ++;
				pSTaCukNUoEKDRgpOLQTDccaXDAqB = true;
				DgqQZOQUowIeCfQKVpEAqmGwDvtn = true;
				anqbMRdoEEBKNlNiSnbPwUnqgDQpA = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				tGysrhjbFLFrPgXIMcaBbLLWWuFOA = P_0;
				RlIDQmCuUoarYIPHdoQoxUAGGFpXA = P_2;
				GDQpmENfBIXPXYNCKCpZWsHiDZtu();
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += AnjFdXLAfGbUZCrToQcXvzNkRJgP;
				CJmBaqyzKLtcgmGuniaRETPlVLVg = P_3;
				zCDqGEhTxmNAFQUBgylNBlDdZINJ = P_4;
				P_4.FIoTzaLiABjUAwDEDTJFlnqAPkqp();
				ThreadSafeUnityInput.Initialize();
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA = new xZFITjbtGaRVuWvMsohxNPcciOJI();
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.Set(gJJMTbzZjBhEldYVKNoFNYxyfiar);
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.Use();
				if (UbEFcELxcMRbeOFRFlzlwPEVUZEP != EditorPlatform.None)
				{
					DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.getValueDelegate = XdHCtrUrhOQOgSkanlBXzDMnbwHq._003C_003E9.ihBfPUXRtwvvxKGayhAXoeOracHEA;
					if (anqbMRdoEEBKNlNiSnbPwUnqgDQpA)
					{
						gJJMTbzZjBhEldYVKNoFNYxyfiar = DnJBxefefkikAcBNeCHEXLsQvOXLc;
					}
					DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				SqFxKTxNhWjJPLDJXCewPFPztpEN();
				lafhvvLusIaqxDQwZFdzUlxqoAlHb = new TimerAbs(1.0);
				qnUinDQAjgDhqPDjdzVTrfTyQMAo = new MiQEFGuimaGvgXtjBDDFmRsvaxfL();
				VrPskCiqMqoqPbiVHqRqtKqGpBtv(P_1, P_5, P_6);
				prxXuKwOwEjZuqOfmARKiCcLjOdAA = new SfPfxaQrjElDDUkmFFxxeUUjFvLIA(P_4.GetActions_Copy());
				WUBqcfcHLvbkdiiUnEhQlzYVACJm = new IevfLhwIfTciNnbiFjVqslbhqjt(P_2, sshUGYCzCIzLUbpSPwGhPzcMldAC);
				VouJZmDPLGSEXPCTzKAxDlURnAgC = new cphySyblTqRHzdCDofohJZUaAidOA(P_2);
				sshUGYCzCIzLUbpSPwGhPzcMldAC.DeviceConnectedEvent += CAUpDgEFJnAMTEMhQWeqBDKIEEQvA;
				sshUGYCzCIzLUbpSPwGhPzcMldAC.DeviceDisconnectedEvent += XWghiuDKqnmRGFZxjduGnDGGbLgfA;
				sshUGYCzCIzLUbpSPwGhPzcMldAC.UpdateControllerInfoEvent += XAzhkiDsFueCaLqAHMwelxgDQlaaA;
				WUBqcfcHLvbkdiiUnEhQlzYVACJm.iAxiOOZnhZggwDpPulnrGoMfpldNb += LOPlWkYwQQzzKUucExogwcaTVDND;
				WUBqcfcHLvbkdiiUnEhQlzYVACJm.CJOAvERqHMEBsNRqxPANMAPAeOKq += VouJZmDPLGSEXPCTzKAxDlURnAgC.SiZLDopAVHxpJoZrTGLEgzyzFZEI;
				ThreadSafeUnityInput.PostInitialize();
				VOWBlPkypBonZprBwBGxGmZupSBT();
				ThreadSafeUnityInput.PostInitialize2();
				VeaitAAcKEfvNYhnQtoyHXItWIbAA = UnityTools.GetComponent<UserDataStore>(tGysrhjbFLFrPgXIMcaBbLLWWuFOA);
				if (VeaitAAcKEfvNYhnQtoyHXItWIbAA != null)
				{
					VeaitAAcKEfvNYhnQtoyHXItWIbAA.Initialize();
				}
				ZtocioJxZFWldAGJQMwKMslPRDJe();
				DgqQZOQUowIeCfQKVpEAqmGwDvtn = false;
				if (anqbMRdoEEBKNlNiSnbPwUnqgDQpA)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (gDAgmcPLrHcIfMZejaqgPkbvSZUJ != null)
				{
					gDAgmcPLrHcIfMZejaqgPkbvSZUJ.Invoke();
				}
			}
			catch (Exception)
			{
				pSTaCukNUoEKDRgpOLQTDccaXDAqB = false;
				DgqQZOQUowIeCfQKVpEAqmGwDvtn = false;
				throw;
			}
		}

		internal static void KSlfZqOVAGbruWTomRPpgxLnoUDK()
		{
			if (qnUinDQAjgDhqPDjdzVTrfTyQMAo != null)
			{
				qnUinDQAjgDhqPDjdzVTrfTyQMAo.xwJkMTkfMQvgaJnzNfxFxrlyFlAeA();
			}
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < WUBqcfcHLvbkdiiUnEhQlzYVACJm.wURgxTJZNaSLNnCGmXznMTsQiLRN; i++)
				{
					Joystick joystick = WUBqcfcHLvbkdiiUnEhQlzYVACJm.qQPYUHGpeSYXIATfmfGHglnODAfiA[i];
					VhaiVcOqXQgbXUedUkDLyhpOEUDR(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		internal static void iMRCRyQFgsiKlIkoaQrqpcvPruXfA(UpdateLoopType P_0)
		{
			if (pSTaCukNUoEKDRgpOLQTDccaXDAqB)
			{
				WlNWxUvOCJPlJCYyFSDvuPCjGAyE(P_0);
				if ((uint)P_0 <= 1u)
				{
					hGhBiDFKGiecbHNHJpzKpMtJFEFQc();
				}
			}
		}

		private static void WlNWxUvOCJPlJCYyFSDvuPCjGAyE(UpdateLoopType P_0)
		{
			if (DMqhrzriSLlkfCJUZcWlbEcYnKsKA != null)
			{
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.oxWsdfXSDqGbBaDPvmWfCGQJnCZOc();
			}
			Action<UpdateLoopType> action = szEdgGaRoxDEskyFGDtpsleYMDxZ;
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
			qnUinDQAjgDhqPDjdzVTrfTyQMAo.kjyalTLvzQBJlhRIwOknSmmsNZtn(P_0);
		}

		private static void hGhBiDFKGiecbHNHJpzKpMtJFEFQc()
		{
			int frameCount = Time.frameCount;
			if (davEbLNameENdDEjLQrxpTZqDWWdb == frameCount)
			{
				return;
			}
			davEbLNameENdDEjLQrxpTZqDWWdb = frameCount;
			ThreadSafeUnityInput.Update();
			Action action = qUVDNdCoPMpEktAjbVpIrivKpByqA;
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

		internal static void glqgsacLzcDFPARbIPppzVMSjvkG(UpdateLoopType P_0)
		{
			if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
			{
				return;
			}
			if (gWAkDmZrzcRdSGrXIGTUXjBkgnFhA != P_0)
			{
				gWAkDmZrzcRdSGrXIGTUXjBkgnFhA = P_0;
			}
			if (editorPlatform != EditorPlatform.None)
			{
				RXUCqLzJggGmRDVUvqzGfcDssFH = DMqhrzriSLlkfCJUZcWlbEcYnKsKA.LDhBlJRDSOWcIVgEPLOxyrJOwMvF.value;
			}
			if (WXclTgUcQfebCRTWIswlsrbAgdrQ)
			{
				if (lafhvvLusIaqxDQwZFdzUlxqoAlHb.Update())
				{
					WXclTgUcQfebCRTWIswlsrbAgdrQ = false;
					lafhvvLusIaqxDQwZFdzUlxqoAlHb.Clear();
				}
				else
				{
					KmkDqPgxNSXNiRZTawHQNMGRIrgNA.kwTOBjSQWOYXFNzOfKKuhldbbXYf(P_0);
				}
			}
			DMqhrzriSLlkfCJUZcWlbEcYnKsKA.LWTNzNmzfWaodCbpPIeRIqgEnfDM();
			Action<UpdateLoopType> wKZscmkDdBDAgLqYpnwnhUkBJyGw = WKZscmkDdBDAgLqYpnwnhUkBJyGw;
			if (wKZscmkDdBDAgLqYpnwnhUkBJyGw != null)
			{
				try
				{
					wKZscmkDdBDAgLqYpnwnhUkBJyGw(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.UpdateStartedEvent", exception);
				}
			}
			sshUGYCzCIzLUbpSPwGhPzcMldAC.Update(P_0);
			if (MAeKbWEpNHuEdFLpyEbfbrcVNUESA != null)
			{
				MAeKbWEpNHuEdFLpyEbfbrcVNUESA.Invoke();
			}
			WUBqcfcHLvbkdiiUnEhQlzYVACJm.HshKYrNOXVuRqESxIGQIeEGvHNrT(P_0);
			Action<UpdateLoopType> action = heWXixkNLpsLyKerSeJGQROYKTvE;
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

		internal static void YftsaQZvtAaarSTOqPOXOCAGhCLR()
		{
			Action uXiwQuLvPmQYnfEgzIloaxBdubEp = UXiwQuLvPmQYnfEgzIloaxBdubEp;
			if (uXiwQuLvPmQYnfEgzIloaxBdubEp != null)
			{
				try
				{
					uXiwQuLvPmQYnfEgzIloaxBdubEp();
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
			if (pSTaCukNUoEKDRgpOLQTDccaXDAqB && anqbMRdoEEBKNlNiSnbPwUnqgDQpA)
			{
				iMRCRyQFgsiKlIkoaQrqpcvPruXfA(UpdateLoopType.Update);
				glqgsacLzcDFPARbIPppzVMSjvkG(UpdateLoopType.Update);
				YftsaQZvtAaarSTOqPOXOCAGhCLR();
			}
		}

		internal static void iWImclvEMlWWWQxofRqsWhMbsaDV()
		{
			if (eAaOaYORxBwDCvgMLWSRGcfmLGuH != null)
			{
				eAaOaYORxBwDCvgMLWSRGcfmLGuH.Invoke();
			}
			if (sshUGYCzCIzLUbpSPwGhPzcMldAC != null)
			{
				sshUGYCzCIzLUbpSPwGhPzcMldAC.OnDestroy();
			}
			AMeNRoKsFFiZonBBMiJkFoSknMzw();
			if (umoqUpGAeuXnpMgvbcBAKbXiCpKu != null)
			{
				umoqUpGAeuXnpMgvbcBAKbXiCpKu.Invoke();
				umoqUpGAeuXnpMgvbcBAKbXiCpKu = null;
			}
		}

		internal static void AxrawJFNLmWSVOrLAaagfjWFwAkXb()
		{
			if (wPGVulalQLHCwzJytfiNXQEWUuPl != null)
			{
				wPGVulalQLHCwzJytfiNXQEWUuPl.Invoke();
			}
		}

		internal static void nQGCFKCWNRLeGRKXhkSBzVUMTzDO(bool P_0)
		{
			gJJMTbzZjBhEldYVKNoFNYxyfiar = P_0;
			if (UbEFcELxcMRbeOFRFlzlwPEVUZEP == EditorPlatform.None && pSTaCukNUoEKDRgpOLQTDccaXDAqB)
			{
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.Set(P_0);
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.TriggerEvent();
			}
		}

		internal static void IhnePsciDGJVhBjTvDMLscBloRRC()
		{
			if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
			{
				return;
			}
			Action cGraKiivMKnTlfjTjROhbPvnRkyTB = CGraKiivMKnTlfjTjROhbPvnRkyTB;
			if (cGraKiivMKnTlfjTjROhbPvnRkyTB == null)
			{
				return;
			}
			try
			{
				cGraKiivMKnTlfjTjROhbPvnRkyTB();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.SceneLoadedEvent", exception);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return CJmBaqyzKLtcgmGuniaRETPlVLVg.qMvtARTWarEdJVSpJgRFkHFUFLekA(bridgedController);
		}

		internal static HardwareJoystickMap IGEHkEuFsqJKrUsbmEUhfZlcQsHB(Guid P_0)
		{
			return CJmBaqyzKLtcgmGuniaRETPlVLVg.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap JygnrFiMhuenDfjLmROYbiKJJoKeA(Guid P_0)
		{
			return CJmBaqyzKLtcgmGuniaRETPlVLVg.GetJoystickTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap BTeBpTCtussbwcDUqvfkWderjnElA(Guid P_0)
		{
			return CJmBaqyzKLtcgmGuniaRETPlVLVg.GetControllerTemplate(P_0);
		}

		internal static IList<HardwareJoystickTemplateMap> UUHFzppCZFYByNjKfJCDPBOGIIgQ(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = CJmBaqyzKLtcgmGuniaRETPlVLVg.GetHardwareJoystickMap(P_0);
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
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = JygnrFiMhuenDfjLmROYbiKJJoKeA(guid);
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
			return WUBqcfcHLvbkdiiUnEhQlzYVACJm.LByEehKndcPABuWdbwiILAfacKafb();
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

		internal static void vsQTXTaOOgoJMQnkwcIxSjBsfizg()
		{
			if (pSTaCukNUoEKDRgpOLQTDccaXDAqB)
			{
				ZtocioJxZFWldAGJQMwKMslPRDJe();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2022 != UnityTools.unityVersionObj.major)
			{
				TtCAUzBdEmLIpyXTvcfhVjBieenW();
			}
		}

		internal static float laCaVXsqpKgTpgjFmOQjftcvRByh()
		{
			return DMqhrzriSLlkfCJUZcWlbEcYnKsKA.VGsMGiVCeIGDBBuBfmsjuSdKwtKd.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
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

		private static void VOWBlPkypBonZprBwBGxGmZupSBT()
		{
			VouJZmDPLGSEXPCTzKAxDlURnAgC.kXldWpzJqMVeExiPFEkQCadSSSOxA();
			WUBqcfcHLvbkdiiUnEhQlzYVACJm.dXEgTSdHfDwdGWXHuWbKsASChoQn(sshUGYCzCIzLUbpSPwGhPzcMldAC.GetInputDataUpdateDelegate(), zCDqGEhTxmNAFQUBgylNBlDdZINJ.GetInputBehaviors_Copy());
			sshUGYCzCIzLUbpSPwGhPzcMldAC.Initialize();
		}

		private static void AMeNRoKsFFiZonBBMiJkFoSknMzw()
		{
			if (tGysrhjbFLFrPgXIMcaBbLLWWuFOA != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(tGysrhjbFLFrPgXIMcaBbLLWWuFOA);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			tGysrhjbFLFrPgXIMcaBbLLWWuFOA = null;
			sshUGYCzCIzLUbpSPwGhPzcMldAC = null;
			prxXuKwOwEjZuqOfmARKiCcLjOdAA = null;
			if (WUBqcfcHLvbkdiiUnEhQlzYVACJm != null)
			{
				WUBqcfcHLvbkdiiUnEhQlzYVACJm.Dispose();
			}
			WUBqcfcHLvbkdiiUnEhQlzYVACJm = null;
			VouJZmDPLGSEXPCTzKAxDlURnAgC = null;
			CJmBaqyzKLtcgmGuniaRETPlVLVg = null;
			zCDqGEhTxmNAFQUBgylNBlDdZINJ = null;
			SoGBixweDUvzjAchbCjMAhlqEPGh = null;
			pSTaCukNUoEKDRgpOLQTDccaXDAqB = false;
			RlIDQmCuUoarYIPHdoQoxUAGGFpXA = null;
			gWAkDmZrzcRdSGrXIGTUXjBkgnFhA = UpdateLoopType.Update;
			ZSJAFPazSEmLOrDHlfzrFagTppzdA = false;
			JtVlEYIdwTMZxWDWzCIAKPpoZrFm = Platform.Windows;
			kifIeOdMBpgaIjSHllKrFLanVJoV = WebplayerPlatform.None;
			UbEFcELxcMRbeOFRFlzlwPEVUZEP = EditorPlatform.None;
			WXclTgUcQfebCRTWIswlsrbAgdrQ = false;
			lafhvvLusIaqxDQwZFdzUlxqoAlHb = null;
			qnUinDQAjgDhqPDjdzVTrfTyQMAo = null;
			RXUCqLzJggGmRDVUvqzGfcDssFH = null;
			prlRHUFholaMmazdwEHMTmdeEiadA = false;
			anqbMRdoEEBKNlNiSnbPwUnqgDQpA = false;
			gJJMTbzZjBhEldYVKNoFNYxyfiar = true;
			davEbLNameENdDEjLQrxpTZqDWWdb = -1;
			_id = -1;
			gjsyGpOJRSSUjRBUWpqlQCUsqBVy = 0;
			NtYsLSRUxEkCMIyoEGtvMyKgFzpH.Clear();
			afssTaOHqNnWSLPteqExbAFAVahs.Clear();
			BeiJoVGqdzczdGpBIgarWXJvKhIM.Clear();
			MAeKbWEpNHuEdFLpyEbfbrcVNUESA.Clear();
			wPGVulalQLHCwzJytfiNXQEWUuPl.Clear();
			_ApplicationFocusChangedEvent = null;
			QTYQBrEmEejFnHcieCVuuxAeeGhu = null;
			rmhYJBFpzsbkFALkqUiuehiUByBO = null;
			PwjcWbJgTSccCFEiWECFPGvqyqrhA = null;
			NyHwroGMKwYZwttowQJwZRdcofpU = null;
			qUVDNdCoPMpEktAjbVpIrivKpByqA = null;
			WKZscmkDdBDAgLqYpnwnhUkBJyGw = null;
			heWXixkNLpsLyKerSeJGQROYKTvE = null;
			UXiwQuLvPmQYnfEgzIloaxBdubEp = null;
			eAaOaYORxBwDCvgMLWSRGcfmLGuH = null;
			CGraKiivMKnTlfjTjROhbPvnRkyTB = null;
			kETANuwkokGCxqVAojHMeMEkmUzGb = null;
			ZkepyxNANBybwIuRMHRcWdwQzWPf();
			DMqhrzriSLlkfCJUZcWlbEcYnKsKA = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= AnjFdXLAfGbUZCrToQcXvzNkRJgP;
			}
		}

		private static void EBsobzeoFqIQSnEevrXybzGyhILC(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void vNbnUolXtDEBoShcpqSvAzFalZnS()
		{
			if (!WXclTgUcQfebCRTWIswlsrbAgdrQ)
			{
				WXclTgUcQfebCRTWIswlsrbAgdrQ = true;
				KmkDqPgxNSXNiRZTawHQNMGRIrgNA.eEXmEuiMvYBNMbfEtQmyPXlpRgRu();
				KmkDqPgxNSXNiRZTawHQNMGRIrgNA.GvoEQNSBCwbqzCbkNArnnMgVHbKKA();
			}
			lafhvvLusIaqxDQwZFdzUlxqoAlHb.Start();
		}

		private static void rmpDbcszCztqcuEpJytwJGEZCzLg()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void CAUpDgEFJnAMTEMhQWeqBDKIEEQvA(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			WUBqcfcHLvbkdiiUnEhQlzYVACJm.nlrdBPJxbHrPVPzluXttCBlluWzk(P_0);
			Joystick joystick = WUBqcfcHLvbkdiiUnEhQlzYVACJm.lJNHwTBZiOepTHokyHvamZjJSanE(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				VouJZmDPLGSEXPCTzKAxDlURnAgC.McQkKmbAVuOBoNIPxiGwBMvwSpglA(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !DgqQZOQUowIeCfQKVpEAqmGwDvtn)
				{
					VhaiVcOqXQgbXUedUkDLyhpOEUDR(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void XWghiuDKqnmRGFZxjduGnDGGbLgfA(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = WUBqcfcHLvbkdiiUnEhQlzYVACJm.lJNHwTBZiOepTHokyHvamZjJSanE(P_0.rewiredId);
				if (joystick != null)
				{
					WUBqcfcHLvbkdiiUnEhQlzYVACJm.aoRpcnejKsMCdpTbHVJjvqppkHYQ(P_0.rewiredId);
					cnUcWWhtscjLTzFBPncNuNWQAhZL(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void VhaiVcOqXQgbXUedUkDLyhpOEUDR(ControllerStatusChangedEventArgs P_0)
		{
			if (NtYsLSRUxEkCMIyoEGtvMyKgFzpH != null)
			{
				NtYsLSRUxEkCMIyoEGtvMyKgFzpH.Invoke(P_0);
			}
		}

		private static void LOPlWkYwQQzzKUucExogwcaTVDND(ControllerStatusChangedEventArgs P_0)
		{
			if (afssTaOHqNnWSLPteqExbAFAVahs != null)
			{
				afssTaOHqNnWSLPteqExbAFAVahs.Invoke(P_0);
			}
		}

		private static void cnUcWWhtscjLTzFBPncNuNWQAhZL(ControllerStatusChangedEventArgs P_0)
		{
			if (BeiJoVGqdzczdGpBIgarWXJvKhIM != null)
			{
				BeiJoVGqdzczdGpBIgarWXJvKhIM.Invoke(P_0);
			}
		}

		private static void XAzhkiDsFueCaLqAHMwelxgDQlaaA(UpdateControllerInfoEventArgs P_0)
		{
			WUBqcfcHLvbkdiiUnEhQlzYVACJm.NhePbzmXatqlakJyGwDLbOcSaroBA(P_0);
		}

		private static void YGzLwoyNpSdnmIesQRJcrEvIFOtm(bool P_0)
		{
			if (!pSTaCukNUoEKDRgpOLQTDccaXDAqB)
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

		private static void SYLnQcgPHusRknnvatwtpunggGJr(bool P_0)
		{
			Action<bool> qTYQBrEmEejFnHcieCVuuxAeeGhu = QTYQBrEmEejFnHcieCVuuxAeeGhu;
			if (qTYQBrEmEejFnHcieCVuuxAeeGhu != null)
			{
				try
				{
					qTYQBrEmEejFnHcieCVuuxAeeGhu(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void PxwjoWuaCHwVnedylTJcsPGNjLZr(int P_0)
		{
			if (PwjcWbJgTSccCFEiWECFPGvqyqrhA != null)
			{
				try
				{
					PwjcWbJgTSccCFEiWECFPGvqyqrhA((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void mfLjnighgXlITKAOwiWjVGBGdjlAA(bool P_0)
		{
			Action<bool> action = rmhYJBFpzsbkFALkqUiuehiUByBO;
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

		private static void aZtgbPeDtVciSfMrkAvWnwdidXlh(bool P_0)
		{
			gjsyGpOJRSSUjRBUWpqlQCUsqBVy++;
			Action<bool> nyHwroGMKwYZwttowQJwZRdcofpU = NyHwroGMKwYZwttowQJwZRdcofpU;
			if (nyHwroGMKwYZwttowQJwZRdcofpU != null)
			{
				try
				{
					nyHwroGMKwYZwttowQJwZRdcofpU(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void SqFxKTxNhWjJPLDJXCewPFPztpEN()
		{
			if (DMqhrzriSLlkfCJUZcWlbEcYnKsKA != null)
			{
				ZkepyxNANBybwIuRMHRcWdwQzWPf();
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.ChangedEvent += YGzLwoyNpSdnmIesQRJcrEvIFOtm;
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.KYdIleVPWVcCxITfxDLoUfWCMnZA.ChangedEvent += SYLnQcgPHusRknnvatwtpunggGJr;
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.ovPGBNhsomsMknOdlqKpIBYJQgygA.ChangedEvent += mfLjnighgXlITKAOwiWjVGBGdjlAA;
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.wbXgidaUHQrqWCRnODdTZOHgiwhC.ChangedEvent += PxwjoWuaCHwVnedylTJcsPGNjLZr;
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.GKWSbthJjIJNogLHkBgcJaiQOpLnA.ChangedEvent += aZtgbPeDtVciSfMrkAvWnwdidXlh;
			}
		}

		private static void ZkepyxNANBybwIuRMHRcWdwQzWPf()
		{
			if (DMqhrzriSLlkfCJUZcWlbEcYnKsKA != null)
			{
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.iDwgARdclxgluVbQzxQPvKBEGbuhb.ChangedEvent -= YGzLwoyNpSdnmIesQRJcrEvIFOtm;
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.KYdIleVPWVcCxITfxDLoUfWCMnZA.ChangedEvent -= SYLnQcgPHusRknnvatwtpunggGJr;
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.ovPGBNhsomsMknOdlqKpIBYJQgygA.ChangedEvent -= mfLjnighgXlITKAOwiWjVGBGdjlAA;
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.wbXgidaUHQrqWCRnODdTZOHgiwhC.ChangedEvent -= PxwjoWuaCHwVnedylTJcsPGNjLZr;
				DMqhrzriSLlkfCJUZcWlbEcYnKsKA.GKWSbthJjIJNogLHkBgcJaiQOpLnA.ChangedEvent -= aZtgbPeDtVciSfMrkAvWnwdidXlh;
			}
		}

		private static void AnjFdXLAfGbUZCrToQcXvzNkRJgP(bool P_0)
		{
			Action<bool> action = kETANuwkokGCxqVAojHMeMEkmUzGb;
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

		private static void VrPskCiqMqoqPbiVHqRqtKqGpBtv(Func<ConfigVars, object> P_0, UnityTools.RSjavNYDnzcBvAPUEIvOEFCjomGrA P_1, Action<Platform> P_2)
		{
			bool flag = false;
			if (P_1.MOUASjtxCryOdwLayuXnHjfwaEPm != P_1.qbJFZlTqLWJrETUdSIwrXWyTZITe)
			{
				UnityTools.RSjavNYDnzcBvAPUEIvOEFCjomGrA rSjavNYDnzcBvAPUEIvOEFCjomGrA = P_1;
				rSjavNYDnzcBvAPUEIvOEFCjomGrA.MOUASjtxCryOdwLayuXnHjfwaEPm = P_1.qbJFZlTqLWJrETUdSIwrXWyTZITe;
				UnityTools.aorjqHeBqaMJCLvbPCUZQgcbYWSL(rSjavNYDnzcBvAPUEIvOEFCjomGrA);
				P_2(rSjavNYDnzcBvAPUEIvOEFCjomGrA.qbJFZlTqLWJrETUdSIwrXWyTZITe);
				GDQpmENfBIXPXYNCKCpZWsHiDZtu();
				flag = true;
			}
			if (!configVars.DoesPlatformUseFallback(P_1.qbJFZlTqLWJrETUdSIwrXWyTZITe, P_1.vrDQyodTzmWOChcqUJvEarTWQYTn, isEditor) && !configVars.DoesPlatformUseFallback(P_1.MOUASjtxCryOdwLayuXnHjfwaEPm, P_1.vrDQyodTzmWOChcqUJvEarTWQYTn, isEditor))
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(tGysrhjbFLFrPgXIMcaBbLLWWuFOA);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(P_1.qbJFZlTqLWJrETUdSIwrXWyTZITe, RlIDQmCuUoarYIPHdoQoxUAGGFpXA) is PlatformInputManager platformInputManager)
					{
						sshUGYCzCIzLUbpSPwGhPzcMldAC = platformInputManager;
						return;
					}
				}
			}
			if (flag)
			{
				UnityTools.aorjqHeBqaMJCLvbPCUZQgcbYWSL(P_1);
				P_2(P_1.qbJFZlTqLWJrETUdSIwrXWyTZITe);
				GDQpmENfBIXPXYNCKCpZWsHiDZtu();
				flag = false;
			}
			if (configVars.DoesPlatformUseFallback(JtVlEYIdwTMZxWDWzCIAKPpoZrFm, kifIeOdMBpgaIjSHllKrFLanVJoV, isEditor))
			{
				ZSJAFPazSEmLOrDHlfzrFagTppzdA = true;
				sshUGYCzCIzLUbpSPwGhPzcMldAC = new kgqWAFMONnxVtQdidGZVSnDQQTp(RlIDQmCuUoarYIPHdoQoxUAGGFpXA.updateLoop);
			}
			else if (configVars.DoesPlatformUseSDL2(JtVlEYIdwTMZxWDWzCIAKPpoZrFm, kifIeOdMBpgaIjSHllKrFLanVJoV, isEditor))
			{
				try
				{
					sshUGYCzCIzLUbpSPwGhPzcMldAC = new XONamUjigaDHVcyhasINIkcjWIxGc(RlIDQmCuUoarYIPHdoQoxUAGGFpXA, GetHardwareJoystickMap_InputManager, GetNewJoystickId, true, false, false);
					if (sshUGYCzCIzLUbpSPwGhPzcMldAC == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
					sshUGYCzCIzLUbpSPwGhPzcMldAC = null;
				}
			}
			else if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.Windows || JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.WindowsAppStore || JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.WindowsUWP || JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.OSX || JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.Linux)
			{
				sshUGYCzCIzLUbpSPwGhPzcMldAC = P_0(RlIDQmCuUoarYIPHdoQoxUAGGFpXA) as PlatformInputManager;
			}
			else if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.WebGL && !isEditor)
			{
				try
				{
					sshUGYCzCIzLUbpSPwGhPzcMldAC = P_0(RlIDQmCuUoarYIPHdoQoxUAGGFpXA) as PlatformInputManager;
					if (sshUGYCzCIzLUbpSPwGhPzcMldAC == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					sshUGYCzCIzLUbpSPwGhPzcMldAC = null;
				}
			}
			else if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.XboxOne && !isEditor)
			{
				try
				{
					sshUGYCzCIzLUbpSPwGhPzcMldAC = new CustomInputManager(new XboxOneInputSource(), RlIDQmCuUoarYIPHdoQoxUAGGFpXA.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (sshUGYCzCIzLUbpSPwGhPzcMldAC == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					sshUGYCzCIzLUbpSPwGhPzcMldAC = null;
				}
			}
			else if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.PS4 && !isEditor)
			{
				try
				{
					sshUGYCzCIzLUbpSPwGhPzcMldAC = P_0(RlIDQmCuUoarYIPHdoQoxUAGGFpXA) as PlatformInputManager;
					if (sshUGYCzCIzLUbpSPwGhPzcMldAC == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
					Logger.LogError(msg);
					sshUGYCzCIzLUbpSPwGhPzcMldAC = null;
				}
			}
			else if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.PS5 && !isEditor)
			{
				try
				{
					sshUGYCzCIzLUbpSPwGhPzcMldAC = P_0(RlIDQmCuUoarYIPHdoQoxUAGGFpXA) as PlatformInputManager;
					if (sshUGYCzCIzLUbpSPwGhPzcMldAC == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
					Logger.LogError(msg2);
					sshUGYCzCIzLUbpSPwGhPzcMldAC = null;
				}
			}
			else if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.Stadia && !isEditor)
			{
				try
				{
					sshUGYCzCIzLUbpSPwGhPzcMldAC = P_0(RlIDQmCuUoarYIPHdoQoxUAGGFpXA) as PlatformInputManager;
					if (sshUGYCzCIzLUbpSPwGhPzcMldAC == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg3)
				{
					Logger.LogError("Stadia platform could not be initialized! Is the Rewired Stadia library installed? See the documentation for more information.");
					Logger.LogError(msg3);
					sshUGYCzCIzLUbpSPwGhPzcMldAC = null;
				}
			}
			else if ((JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.GameCoreXboxOne || JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					sshUGYCzCIzLUbpSPwGhPzcMldAC = P_0(RlIDQmCuUoarYIPHdoQoxUAGGFpXA) as PlatformInputManager;
					if (sshUGYCzCIzLUbpSPwGhPzcMldAC == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg4)
				{
					string text = ((JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg4);
					sshUGYCzCIzLUbpSPwGhPzcMldAC = null;
				}
			}
			else if (JtVlEYIdwTMZxWDWzCIAKPpoZrFm == Platform.Ouya && !isEditor)
			{
				Logger.LogError("Ouya is no longer supported.");
				sshUGYCzCIzLUbpSPwGhPzcMldAC = null;
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.cpLrCxcQtxKuFzfzsDGNdJvftxsmA = P_0(RlIDQmCuUoarYIPHdoQoxUAGGFpXA) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg5)
				{
					Logger.LogError(msg5);
				}
			}
			if (sshUGYCzCIzLUbpSPwGhPzcMldAC == null)
			{
				ZSJAFPazSEmLOrDHlfzrFagTppzdA = true;
				sshUGYCzCIzLUbpSPwGhPzcMldAC = new kgqWAFMONnxVtQdidGZVSnDQQTp(RlIDQmCuUoarYIPHdoQoxUAGGFpXA.updateLoop);
			}
		}

		private static void ZtocioJxZFWldAGJQMwKMslPRDJe()
		{
			if (prlRHUFholaMmazdwEHMTmdeEiadA != RlIDQmCuUoarYIPHdoQoxUAGGFpXA.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				prlRHUFholaMmazdwEHMTmdeEiadA = !prlRHUFholaMmazdwEHMTmdeEiadA;
			}
		}

		private static void TtCAUzBdEmLIpyXTvcfhVjBieenW()
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
