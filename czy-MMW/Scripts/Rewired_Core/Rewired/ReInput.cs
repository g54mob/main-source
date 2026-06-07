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
			private static ConfigHelper BVcCSCCTljkpRPhVgiRBLiGWWbfs;

			private float otzAGmEnAfRNjoHpiYTxuKFosGRwA = 0.7f;

			private float aUVDkXRQQBOctrGaBIiAhJwjIjUN = 100f;

			internal static ConfigHelper uqwOPfUqHKjZytALiFsNYuZzhTKL => BVcCSCCTljkpRPhVgiRBLiGWWbfs ?? (BVcCSCCTljkpRPhVgiRBLiGWWbfs = new ConfigHelper());

			public bool useXInput
			{
				get
				{
					if (!CheckInitialized())
					{
						return false;
					}
					if (UnityTools.platform == Platform.Windows && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
					{
						return true;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						return (jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useGamepadAPI;
					}
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.useXInput;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					if (UnityTools.platform == Platform.WindowsUWP)
					{
						ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
						if (platformVars_WindowsUWP.useGamepadAPI != value)
						{
							platformVars_WindowsUWP.useGamepadAPI = value;
							if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
							{
								xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
							}
						}
					}
					else if (jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.useXInput != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.useXInput = value;
						if (!value && UnityTools.platform == Platform.Windows && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
						{
							windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							Logger.Log("The primary input source has been changed to Raw Input.");
						}
						else if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.updateLoop;
				}
				set
				{
					if (CheckInitialized() && value != jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.updateLoop)
					{
						if ((value & UpdateLoopSetting.Update) == 0)
						{
							value |= UpdateLoopSetting.Update;
						}
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.updateLoop = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.windowsStandalonePrimaryInputSource;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.windowsStandalonePrimaryInputSource != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.windowsStandalonePrimaryInputSource = value;
						if (UnityTools.platform == Platform.Windows && value == WindowsStandalonePrimaryInputSource.XInput)
						{
							jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.useXInput = true;
						}
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.osx_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.osx_primaryInputSource != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.osx_primaryInputSource = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.linux_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.linux_primaryInputSource != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.linux_primaryInputSource = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.windowsUWP_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.windowsUWP_primaryInputSource != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.windowsUWP_primaryInputSource = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return (jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP).useHIDAPI;
				}
				set
				{
					if (!CheckInitialized())
					{
						return;
					}
					ConfigVars.PlatformVars_WindowsUWP platformVars_WindowsUWP = jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.GetPlatformVars(Platform.WindowsUWP) as ConfigVars.PlatformVars_WindowsUWP;
					if (platformVars_WindowsUWP.useHIDAPI != value)
					{
						platformVars_WindowsUWP.useHIDAPI = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.xboxOne_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.xboxOne_primaryInputSource != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.xboxOne_primaryInputSource = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.ps4_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.ps4_primaryInputSource != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.ps4_primaryInputSource = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.webGL_primaryInputSource;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.webGL_primaryInputSource != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.webGL_primaryInputSource = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.alwaysUseUnityInput;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.alwaysUseUnityInput != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.alwaysUseUnityInput = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.GetPlatformVar_useNativeMouse();
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.SetPlatformVar_useNativeMouse(value) && xknFermcIdfIAHgTczNAVdjLNQvSA != null)
					{
						xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.GetPlatformVar_useNativeKeyboard();
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.SetPlatformVar_useNativeKeyboard(value) && xknFermcIdfIAHgTczNAVdjLNQvSA != null)
					{
						xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.GetPlatformVar_useEnhancedDeviceSupport();
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.SetPlatformVar_useEnhancedDeviceSupport(value) && xknFermcIdfIAHgTczNAVdjLNQvSA != null)
					{
						xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.GetPlatformVar_joystickRefreshRate();
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
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.SetPlatformVar_joystickRefreshRate(value);
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.GetPlatformVar_ignoreInputWhenAppNotInFocus();
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.SetPlatformVar_ignoreInputWhenAppNotInFocus(value))
					{
						rLJGDVbHUCDeRCzaSLegyhtrLIBm();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.android_supportUnknownGamepads;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.android_supportUnknownGamepads != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.android_supportUnknownGamepads = value;
						if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
						{
							xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.defaultJoystickAxis2DDeadZoneType;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.defaultJoystickAxis2DDeadZoneType != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.defaultJoystickAxis2DDeadZoneType = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.defaultJoystickAxis2DSensitivityType;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.defaultJoystickAxis2DSensitivityType != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.defaultJoystickAxis2DSensitivityType = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.defaultAxisSensitivityType;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.defaultAxisSensitivityType != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.defaultAxisSensitivityType = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.force4WayHats;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.force4WayHats != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.force4WayHats = value;
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
					return otzAGmEnAfRNjoHpiYTxuKFosGRwA;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (otzAGmEnAfRNjoHpiYTxuKFosGRwA != value)
						{
							otzAGmEnAfRNjoHpiYTxuKFosGRwA = value;
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
					return aUVDkXRQQBOctrGaBIiAhJwjIjUN;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 0f)
						{
							value = 0f;
						}
						if (aUVDkXRQQBOctrGaBIiAhJwjIjUN != value)
						{
							aUVDkXRQQBOctrGaBIiAhJwjIjUN = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.activateActionButtonsOnNegativeValue;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.activateActionButtonsOnNegativeValue != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.activateActionButtonsOnNegativeValue = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.throttleCalibrationMode;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.throttleCalibrationMode != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.throttleCalibrationMode = value;
						MRYlWddHEDKxegbDTAfXRjoQYitX.uksbbIUHgnfyidRTFQJzlytusznd(value);
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.deferControllerConnectedEventsOnStart;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.deferControllerConnectedEventsOnStart != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.deferControllerConnectedEventsOnStart = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.autoAssignJoysticks;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.autoAssignJoysticks != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.autoAssignJoysticks = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.maxJoysticksPerPlayer;
				}
				set
				{
					if (CheckInitialized())
					{
						if (value < 1)
						{
							value = 1;
						}
						if (jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.maxJoysticksPerPlayer != value)
						{
							jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.maxJoysticksPerPlayer = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.distributeJoysticksEvenly;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.distributeJoysticksEvenly != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.distributeJoysticksEvenly = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.assignJoysticksToPlayingPlayersOnly;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.assignJoysticksToPlayingPlayersOnly != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.assignJoysticksToPlayingPlayersOnly = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.reassignJoystickToPreviousOwnerOnReconnect = value;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.logLevel;
				}
				set
				{
					if (CheckInitialized() && jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.logLevel != value)
					{
						jODnKgTyGBuOYuWSEDEtbledplkA.ConfigVars.logLevel = value;
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
			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public sealed class PollingHelper : CodeHelper
			{
				private sealed class OzREURaEFCjFXecsIqEAgEHYHqwbA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int vEDshHzyZYxUuNlcwBqkjhsqUQKE;

					private ControllerPollingInfo NhMWWQpqwzXNzUeKiEUQcCeHexoL;

					private int viwofiYGTEyRsrAxAPXtMNQLSJQU;

					public PollingHelper eSjDOclnhqOOPBscpyJqhBRWMYYb;

					private IEnumerator<ControllerPollingInfo> KJfNGMyivaQSWUgVirWIeHVCeFMC;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return NhMWWQpqwzXNzUeKiEUQcCeHexoL;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return NhMWWQpqwzXNzUeKiEUQcCeHexoL;
						}
					}

					[DebuggerHidden]
					public OzREURaEFCjFXecsIqEAgEHYHqwbA(int P_0)
					{
						vEDshHzyZYxUuNlcwBqkjhsqUQKE = P_0;
						viwofiYGTEyRsrAxAPXtMNQLSJQU = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (vEDshHzyZYxUuNlcwBqkjhsqUQKE)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								ReqAKkkZVhRohmmZATTkpQVQburuA();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								nYOkHWsoECNEqWMZLHbradfvHowR();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								goCCJLwMmVDLHHUqkpRKpxrBGDiv();
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
							int num = vEDshHzyZYxUuNlcwBqkjhsqUQKE;
							PollingHelper pollingHelper = eSjDOclnhqOOPBscpyJqhBRWMYYb;
							switch (num)
							{
							default:
								return false;
							case 0:
								vEDshHzyZYxUuNlcwBqkjhsqUQKE = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								KJfNGMyivaQSWUgVirWIeHVCeFMC = pollingHelper.GwqbjsHzzXvnZfEkZiAuMvLRxAzCA().GetEnumerator();
								vEDshHzyZYxUuNlcwBqkjhsqUQKE = -3;
								goto IL_0084;
							case 1:
								vEDshHzyZYxUuNlcwBqkjhsqUQKE = -3;
								goto IL_0084;
							case 2:
								vEDshHzyZYxUuNlcwBqkjhsqUQKE = -4;
								goto IL_00e4;
							case 3:
								{
									vEDshHzyZYxUuNlcwBqkjhsqUQKE = -5;
									break;
								}
								IL_00e4:
								if (KJfNGMyivaQSWUgVirWIeHVCeFMC.MoveNext())
								{
									ControllerPollingInfo current = KJfNGMyivaQSWUgVirWIeHVCeFMC.Current;
									NhMWWQpqwzXNzUeKiEUQcCeHexoL = current;
									vEDshHzyZYxUuNlcwBqkjhsqUQKE = 2;
									return true;
								}
								nYOkHWsoECNEqWMZLHbradfvHowR();
								KJfNGMyivaQSWUgVirWIeHVCeFMC = null;
								KJfNGMyivaQSWUgVirWIeHVCeFMC = pollingHelper.MDJIWxAhKfoIEjiCBIpNcYseBkkuA().GetEnumerator();
								vEDshHzyZYxUuNlcwBqkjhsqUQKE = -5;
								break;
								IL_0084:
								if (KJfNGMyivaQSWUgVirWIeHVCeFMC.MoveNext())
								{
									ControllerPollingInfo current2 = KJfNGMyivaQSWUgVirWIeHVCeFMC.Current;
									NhMWWQpqwzXNzUeKiEUQcCeHexoL = current2;
									vEDshHzyZYxUuNlcwBqkjhsqUQKE = 1;
									return true;
								}
								ReqAKkkZVhRohmmZATTkpQVQburuA();
								KJfNGMyivaQSWUgVirWIeHVCeFMC = null;
								KJfNGMyivaQSWUgVirWIeHVCeFMC = pollingHelper.IZlINAASdzgNhKhBkqYHjSNnmvtGA().GetEnumerator();
								vEDshHzyZYxUuNlcwBqkjhsqUQKE = -4;
								goto IL_00e4;
							}
							if (KJfNGMyivaQSWUgVirWIeHVCeFMC.MoveNext())
							{
								ControllerPollingInfo current3 = KJfNGMyivaQSWUgVirWIeHVCeFMC.Current;
								NhMWWQpqwzXNzUeKiEUQcCeHexoL = current3;
								vEDshHzyZYxUuNlcwBqkjhsqUQKE = 3;
								return true;
							}
							goCCJLwMmVDLHHUqkpRKpxrBGDiv();
							KJfNGMyivaQSWUgVirWIeHVCeFMC = null;
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

					private void ReqAKkkZVhRohmmZATTkpQVQburuA()
					{
						vEDshHzyZYxUuNlcwBqkjhsqUQKE = -1;
						if (KJfNGMyivaQSWUgVirWIeHVCeFMC != null)
						{
							KJfNGMyivaQSWUgVirWIeHVCeFMC.Dispose();
						}
					}

					private void nYOkHWsoECNEqWMZLHbradfvHowR()
					{
						vEDshHzyZYxUuNlcwBqkjhsqUQKE = -1;
						if (KJfNGMyivaQSWUgVirWIeHVCeFMC != null)
						{
							KJfNGMyivaQSWUgVirWIeHVCeFMC.Dispose();
						}
					}

					private void goCCJLwMmVDLHHUqkpRKpxrBGDiv()
					{
						vEDshHzyZYxUuNlcwBqkjhsqUQKE = -1;
						if (KJfNGMyivaQSWUgVirWIeHVCeFMC != null)
						{
							KJfNGMyivaQSWUgVirWIeHVCeFMC.Dispose();
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
						OzREURaEFCjFXecsIqEAgEHYHqwbA ozREURaEFCjFXecsIqEAgEHYHqwbA;
						if (vEDshHzyZYxUuNlcwBqkjhsqUQKE == -2 && viwofiYGTEyRsrAxAPXtMNQLSJQU == Environment.CurrentManagedThreadId)
						{
							vEDshHzyZYxUuNlcwBqkjhsqUQKE = 0;
							ozREURaEFCjFXecsIqEAgEHYHqwbA = this;
						}
						else
						{
							ozREURaEFCjFXecsIqEAgEHYHqwbA = new OzREURaEFCjFXecsIqEAgEHYHqwbA(0);
							ozREURaEFCjFXecsIqEAgEHYHqwbA.eSjDOclnhqOOPBscpyJqhBRWMYYb = eSjDOclnhqOOPBscpyJqhBRWMYYb;
						}
						return ozREURaEFCjFXecsIqEAgEHYHqwbA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class kJiHCxNEdZucqALcPnAFsdAFFGNg : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int wdWzMlkiOyTfbJOlPbvvLyCNeLWC;

					private ControllerPollingInfo hpgIQjtdSzDMVCxwRSWwNPJbvaOu;

					private int mbyUBBooVsHdOyVpBAeTejhXBPgGA;

					public PollingHelper hneZBZJzbkGDHwsqQrHEbNMPQSjj;

					private IEnumerator<ControllerPollingInfo> UmsToEvdmrbYWebOFvhxbsStMKwY;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return hpgIQjtdSzDMVCxwRSWwNPJbvaOu;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return hpgIQjtdSzDMVCxwRSWwNPJbvaOu;
						}
					}

					[DebuggerHidden]
					public kJiHCxNEdZucqALcPnAFsdAFFGNg(int P_0)
					{
						wdWzMlkiOyTfbJOlPbvvLyCNeLWC = P_0;
						mbyUBBooVsHdOyVpBAeTejhXBPgGA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (wdWzMlkiOyTfbJOlPbvvLyCNeLWC)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								VISXueWCDdKgYPpxkVRCZxaCCIbK();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								fYNcUNzWifFBuiwTdELwrFgtTFOY();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								smaECgyxeyalYpIUqXQRfEWkBtDz();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								ifPjQuKFZidboUPtDLHuIxNNUMTFb();
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
							int num = wdWzMlkiOyTfbJOlPbvvLyCNeLWC;
							PollingHelper pollingHelper = hneZBZJzbkGDHwsqQrHEbNMPQSjj;
							switch (num)
							{
							default:
								return false;
							case 0:
								wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								UmsToEvdmrbYWebOFvhxbsStMKwY = pollingHelper.yqzDImWJECrslwZTJoWPLYbRVDiq().GetEnumerator();
								wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -3;
								goto IL_0088;
							case 1:
								wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -3;
								goto IL_0088;
							case 2:
								wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -4;
								goto IL_00e8;
							case 3:
								wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -5;
								goto IL_0148;
							case 4:
								{
									wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -6;
									break;
								}
								IL_00e8:
								if (UmsToEvdmrbYWebOFvhxbsStMKwY.MoveNext())
								{
									ControllerPollingInfo current = UmsToEvdmrbYWebOFvhxbsStMKwY.Current;
									hpgIQjtdSzDMVCxwRSWwNPJbvaOu = current;
									wdWzMlkiOyTfbJOlPbvvLyCNeLWC = 2;
									return true;
								}
								fYNcUNzWifFBuiwTdELwrFgtTFOY();
								UmsToEvdmrbYWebOFvhxbsStMKwY = null;
								UmsToEvdmrbYWebOFvhxbsStMKwY = pollingHelper.fXKdYUNMJpMlNKhgkTytfAvYjrIC().GetEnumerator();
								wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -5;
								goto IL_0148;
								IL_0088:
								if (UmsToEvdmrbYWebOFvhxbsStMKwY.MoveNext())
								{
									ControllerPollingInfo current2 = UmsToEvdmrbYWebOFvhxbsStMKwY.Current;
									hpgIQjtdSzDMVCxwRSWwNPJbvaOu = current2;
									wdWzMlkiOyTfbJOlPbvvLyCNeLWC = 1;
									return true;
								}
								VISXueWCDdKgYPpxkVRCZxaCCIbK();
								UmsToEvdmrbYWebOFvhxbsStMKwY = null;
								UmsToEvdmrbYWebOFvhxbsStMKwY = pollingHelper.NHCbpxWYqfagkaGMqMsKInNojDoS().GetEnumerator();
								wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -4;
								goto IL_00e8;
								IL_0148:
								if (UmsToEvdmrbYWebOFvhxbsStMKwY.MoveNext())
								{
									ControllerPollingInfo current3 = UmsToEvdmrbYWebOFvhxbsStMKwY.Current;
									hpgIQjtdSzDMVCxwRSWwNPJbvaOu = current3;
									wdWzMlkiOyTfbJOlPbvvLyCNeLWC = 3;
									return true;
								}
								smaECgyxeyalYpIUqXQRfEWkBtDz();
								UmsToEvdmrbYWebOFvhxbsStMKwY = null;
								UmsToEvdmrbYWebOFvhxbsStMKwY = pollingHelper.sOWOKYQpHQXxznctywnyJopAszyG().GetEnumerator();
								wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -6;
								break;
							}
							if (UmsToEvdmrbYWebOFvhxbsStMKwY.MoveNext())
							{
								ControllerPollingInfo current4 = UmsToEvdmrbYWebOFvhxbsStMKwY.Current;
								hpgIQjtdSzDMVCxwRSWwNPJbvaOu = current4;
								wdWzMlkiOyTfbJOlPbvvLyCNeLWC = 4;
								return true;
							}
							ifPjQuKFZidboUPtDLHuIxNNUMTFb();
							UmsToEvdmrbYWebOFvhxbsStMKwY = null;
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

					private void VISXueWCDdKgYPpxkVRCZxaCCIbK()
					{
						wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -1;
						if (UmsToEvdmrbYWebOFvhxbsStMKwY != null)
						{
							UmsToEvdmrbYWebOFvhxbsStMKwY.Dispose();
						}
					}

					private void fYNcUNzWifFBuiwTdELwrFgtTFOY()
					{
						wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -1;
						if (UmsToEvdmrbYWebOFvhxbsStMKwY != null)
						{
							UmsToEvdmrbYWebOFvhxbsStMKwY.Dispose();
						}
					}

					private void smaECgyxeyalYpIUqXQRfEWkBtDz()
					{
						wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -1;
						if (UmsToEvdmrbYWebOFvhxbsStMKwY != null)
						{
							UmsToEvdmrbYWebOFvhxbsStMKwY.Dispose();
						}
					}

					private void ifPjQuKFZidboUPtDLHuIxNNUMTFb()
					{
						wdWzMlkiOyTfbJOlPbvvLyCNeLWC = -1;
						if (UmsToEvdmrbYWebOFvhxbsStMKwY != null)
						{
							UmsToEvdmrbYWebOFvhxbsStMKwY.Dispose();
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
						kJiHCxNEdZucqALcPnAFsdAFFGNg kJiHCxNEdZucqALcPnAFsdAFFGNg2;
						if (wdWzMlkiOyTfbJOlPbvvLyCNeLWC == -2 && mbyUBBooVsHdOyVpBAeTejhXBPgGA == Environment.CurrentManagedThreadId)
						{
							wdWzMlkiOyTfbJOlPbvvLyCNeLWC = 0;
							kJiHCxNEdZucqALcPnAFsdAFFGNg2 = this;
						}
						else
						{
							kJiHCxNEdZucqALcPnAFsdAFFGNg2 = new kJiHCxNEdZucqALcPnAFsdAFFGNg(0);
							kJiHCxNEdZucqALcPnAFsdAFFGNg2.hneZBZJzbkGDHwsqQrHEbNMPQSjj = hneZBZJzbkGDHwsqQrHEbNMPQSjj;
						}
						return kJiHCxNEdZucqALcPnAFsdAFFGNg2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class mFjdMvFeISNrhNfcRIEsQkqCTGnc : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int qFZWRjbApTIwhDlSBqoAiEpVtdTPA;

					private ControllerPollingInfo xtYuhFKmsTbnxkhPovxHzpjDPADJ;

					private int fPlaOxXIltmbbRdPHcZPdbpRoPjo;

					public PollingHelper LJPPFAUabaQynnmZjiOZvUpqwXHR;

					private IEnumerator<ControllerPollingInfo> HDuArSyjnGwkQVavLnHAYzaJfqfQ;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return xtYuhFKmsTbnxkhPovxHzpjDPADJ;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return xtYuhFKmsTbnxkhPovxHzpjDPADJ;
						}
					}

					[DebuggerHidden]
					public mFjdMvFeISNrhNfcRIEsQkqCTGnc(int P_0)
					{
						qFZWRjbApTIwhDlSBqoAiEpVtdTPA = P_0;
						fPlaOxXIltmbbRdPHcZPdbpRoPjo = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (qFZWRjbApTIwhDlSBqoAiEpVtdTPA)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								xZGFaWLBJreimHqptXSSTwNXafGt();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								KqcljplnkLVWLOzsiDMEwzevTWqp();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								SXNbrhErUeJmhHPleGIPVAYFhJOhb();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								ItwLhAxPgDsQJMoSmyonDPnEvHZV();
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
							int num = qFZWRjbApTIwhDlSBqoAiEpVtdTPA;
							PollingHelper lJPPFAUabaQynnmZjiOZvUpqwXHR = LJPPFAUabaQynnmZjiOZvUpqwXHR;
							switch (num)
							{
							default:
								return false;
							case 0:
								qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								HDuArSyjnGwkQVavLnHAYzaJfqfQ = lJPPFAUabaQynnmZjiOZvUpqwXHR.zdJUDUSqSDsJRwwCIDMpuvdDCjnL().GetEnumerator();
								qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -3;
								goto IL_0088;
							case 1:
								qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -3;
								goto IL_0088;
							case 2:
								qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -4;
								goto IL_00e8;
							case 3:
								qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -5;
								goto IL_0148;
							case 4:
								{
									qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -6;
									break;
								}
								IL_00e8:
								if (HDuArSyjnGwkQVavLnHAYzaJfqfQ.MoveNext())
								{
									ControllerPollingInfo current = HDuArSyjnGwkQVavLnHAYzaJfqfQ.Current;
									xtYuhFKmsTbnxkhPovxHzpjDPADJ = current;
									qFZWRjbApTIwhDlSBqoAiEpVtdTPA = 2;
									return true;
								}
								KqcljplnkLVWLOzsiDMEwzevTWqp();
								HDuArSyjnGwkQVavLnHAYzaJfqfQ = null;
								HDuArSyjnGwkQVavLnHAYzaJfqfQ = lJPPFAUabaQynnmZjiOZvUpqwXHR.ZsRGqdCejaWmEQMtgmfZirpAtFNG().GetEnumerator();
								qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -5;
								goto IL_0148;
								IL_0088:
								if (HDuArSyjnGwkQVavLnHAYzaJfqfQ.MoveNext())
								{
									ControllerPollingInfo current2 = HDuArSyjnGwkQVavLnHAYzaJfqfQ.Current;
									xtYuhFKmsTbnxkhPovxHzpjDPADJ = current2;
									qFZWRjbApTIwhDlSBqoAiEpVtdTPA = 1;
									return true;
								}
								xZGFaWLBJreimHqptXSSTwNXafGt();
								HDuArSyjnGwkQVavLnHAYzaJfqfQ = null;
								HDuArSyjnGwkQVavLnHAYzaJfqfQ = lJPPFAUabaQynnmZjiOZvUpqwXHR.eCzhgbMoAbJYuEobmsgyTjDAHCEbb().GetEnumerator();
								qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -4;
								goto IL_00e8;
								IL_0148:
								if (HDuArSyjnGwkQVavLnHAYzaJfqfQ.MoveNext())
								{
									ControllerPollingInfo current3 = HDuArSyjnGwkQVavLnHAYzaJfqfQ.Current;
									xtYuhFKmsTbnxkhPovxHzpjDPADJ = current3;
									qFZWRjbApTIwhDlSBqoAiEpVtdTPA = 3;
									return true;
								}
								SXNbrhErUeJmhHPleGIPVAYFhJOhb();
								HDuArSyjnGwkQVavLnHAYzaJfqfQ = null;
								HDuArSyjnGwkQVavLnHAYzaJfqfQ = lJPPFAUabaQynnmZjiOZvUpqwXHR.qziAfRPYIeAyWDuMAVOLEcXpLapQ().GetEnumerator();
								qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -6;
								break;
							}
							if (HDuArSyjnGwkQVavLnHAYzaJfqfQ.MoveNext())
							{
								ControllerPollingInfo current4 = HDuArSyjnGwkQVavLnHAYzaJfqfQ.Current;
								xtYuhFKmsTbnxkhPovxHzpjDPADJ = current4;
								qFZWRjbApTIwhDlSBqoAiEpVtdTPA = 4;
								return true;
							}
							ItwLhAxPgDsQJMoSmyonDPnEvHZV();
							HDuArSyjnGwkQVavLnHAYzaJfqfQ = null;
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

					private void xZGFaWLBJreimHqptXSSTwNXafGt()
					{
						qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -1;
						if (HDuArSyjnGwkQVavLnHAYzaJfqfQ != null)
						{
							HDuArSyjnGwkQVavLnHAYzaJfqfQ.Dispose();
						}
					}

					private void KqcljplnkLVWLOzsiDMEwzevTWqp()
					{
						qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -1;
						if (HDuArSyjnGwkQVavLnHAYzaJfqfQ != null)
						{
							HDuArSyjnGwkQVavLnHAYzaJfqfQ.Dispose();
						}
					}

					private void SXNbrhErUeJmhHPleGIPVAYFhJOhb()
					{
						qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -1;
						if (HDuArSyjnGwkQVavLnHAYzaJfqfQ != null)
						{
							HDuArSyjnGwkQVavLnHAYzaJfqfQ.Dispose();
						}
					}

					private void ItwLhAxPgDsQJMoSmyonDPnEvHZV()
					{
						qFZWRjbApTIwhDlSBqoAiEpVtdTPA = -1;
						if (HDuArSyjnGwkQVavLnHAYzaJfqfQ != null)
						{
							HDuArSyjnGwkQVavLnHAYzaJfqfQ.Dispose();
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
						mFjdMvFeISNrhNfcRIEsQkqCTGnc mFjdMvFeISNrhNfcRIEsQkqCTGnc2;
						if (qFZWRjbApTIwhDlSBqoAiEpVtdTPA == -2 && fPlaOxXIltmbbRdPHcZPdbpRoPjo == Environment.CurrentManagedThreadId)
						{
							qFZWRjbApTIwhDlSBqoAiEpVtdTPA = 0;
							mFjdMvFeISNrhNfcRIEsQkqCTGnc2 = this;
						}
						else
						{
							mFjdMvFeISNrhNfcRIEsQkqCTGnc2 = new mFjdMvFeISNrhNfcRIEsQkqCTGnc(0);
							mFjdMvFeISNrhNfcRIEsQkqCTGnc2.LJPPFAUabaQynnmZjiOZvUpqwXHR = LJPPFAUabaQynnmZjiOZvUpqwXHR;
						}
						return mFjdMvFeISNrhNfcRIEsQkqCTGnc2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class pSUIisUOTVVSiwGZAuotUEaGEjTU : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int teoCwrnanXIIrIpfrDaQtRsnXguFA;

					private ControllerPollingInfo EszETMrMJvEoFMZqcrTSBGyiTSMD;

					private int kSTvsrqatJJlHhUVTeDUcPGsjEMJ;

					public PollingHelper nqBpuHAMzJoFDiqpenbBdMHCqcgF;

					private IEnumerator<ControllerPollingInfo> TPZVrfaaBHqutJZjRTbKAeciOPlx;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return EszETMrMJvEoFMZqcrTSBGyiTSMD;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return EszETMrMJvEoFMZqcrTSBGyiTSMD;
						}
					}

					[DebuggerHidden]
					public pSUIisUOTVVSiwGZAuotUEaGEjTU(int P_0)
					{
						teoCwrnanXIIrIpfrDaQtRsnXguFA = P_0;
						kSTvsrqatJJlHhUVTeDUcPGsjEMJ = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (teoCwrnanXIIrIpfrDaQtRsnXguFA)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								fbRfWhBbmBZYsApRyQhEgLzocVeeb();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								itDFqyWdXPEhouAkuBRtAfumyjJrA();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								fflDmKtatxbskaeRhGUrMnEJHExY();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								ZIHFiiMsHiTrCFknvHQZzdOfaSlCA();
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
							int num = teoCwrnanXIIrIpfrDaQtRsnXguFA;
							PollingHelper pollingHelper = nqBpuHAMzJoFDiqpenbBdMHCqcgF;
							switch (num)
							{
							default:
								return false;
							case 0:
								teoCwrnanXIIrIpfrDaQtRsnXguFA = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								TPZVrfaaBHqutJZjRTbKAeciOPlx = pollingHelper.fQALBiYcLWgJPFFEgSPdedSUPrZO().GetEnumerator();
								teoCwrnanXIIrIpfrDaQtRsnXguFA = -3;
								goto IL_0088;
							case 1:
								teoCwrnanXIIrIpfrDaQtRsnXguFA = -3;
								goto IL_0088;
							case 2:
								teoCwrnanXIIrIpfrDaQtRsnXguFA = -4;
								goto IL_00e8;
							case 3:
								teoCwrnanXIIrIpfrDaQtRsnXguFA = -5;
								goto IL_0148;
							case 4:
								{
									teoCwrnanXIIrIpfrDaQtRsnXguFA = -6;
									break;
								}
								IL_00e8:
								if (TPZVrfaaBHqutJZjRTbKAeciOPlx.MoveNext())
								{
									ControllerPollingInfo current = TPZVrfaaBHqutJZjRTbKAeciOPlx.Current;
									EszETMrMJvEoFMZqcrTSBGyiTSMD = current;
									teoCwrnanXIIrIpfrDaQtRsnXguFA = 2;
									return true;
								}
								itDFqyWdXPEhouAkuBRtAfumyjJrA();
								TPZVrfaaBHqutJZjRTbKAeciOPlx = null;
								TPZVrfaaBHqutJZjRTbKAeciOPlx = pollingHelper.FeYfjCwXwbYLnJfiEaCdqSQJYQGk().GetEnumerator();
								teoCwrnanXIIrIpfrDaQtRsnXguFA = -5;
								goto IL_0148;
								IL_0088:
								if (TPZVrfaaBHqutJZjRTbKAeciOPlx.MoveNext())
								{
									ControllerPollingInfo current2 = TPZVrfaaBHqutJZjRTbKAeciOPlx.Current;
									EszETMrMJvEoFMZqcrTSBGyiTSMD = current2;
									teoCwrnanXIIrIpfrDaQtRsnXguFA = 1;
									return true;
								}
								fbRfWhBbmBZYsApRyQhEgLzocVeeb();
								TPZVrfaaBHqutJZjRTbKAeciOPlx = null;
								TPZVrfaaBHqutJZjRTbKAeciOPlx = pollingHelper.NHCbpxWYqfagkaGMqMsKInNojDoS().GetEnumerator();
								teoCwrnanXIIrIpfrDaQtRsnXguFA = -4;
								goto IL_00e8;
								IL_0148:
								if (TPZVrfaaBHqutJZjRTbKAeciOPlx.MoveNext())
								{
									ControllerPollingInfo current3 = TPZVrfaaBHqutJZjRTbKAeciOPlx.Current;
									EszETMrMJvEoFMZqcrTSBGyiTSMD = current3;
									teoCwrnanXIIrIpfrDaQtRsnXguFA = 3;
									return true;
								}
								fflDmKtatxbskaeRhGUrMnEJHExY();
								TPZVrfaaBHqutJZjRTbKAeciOPlx = null;
								TPZVrfaaBHqutJZjRTbKAeciOPlx = pollingHelper.PwuezGQyoiHJjUivBOmEQbGIrbGk().GetEnumerator();
								teoCwrnanXIIrIpfrDaQtRsnXguFA = -6;
								break;
							}
							if (TPZVrfaaBHqutJZjRTbKAeciOPlx.MoveNext())
							{
								ControllerPollingInfo current4 = TPZVrfaaBHqutJZjRTbKAeciOPlx.Current;
								EszETMrMJvEoFMZqcrTSBGyiTSMD = current4;
								teoCwrnanXIIrIpfrDaQtRsnXguFA = 4;
								return true;
							}
							ZIHFiiMsHiTrCFknvHQZzdOfaSlCA();
							TPZVrfaaBHqutJZjRTbKAeciOPlx = null;
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

					private void fbRfWhBbmBZYsApRyQhEgLzocVeeb()
					{
						teoCwrnanXIIrIpfrDaQtRsnXguFA = -1;
						if (TPZVrfaaBHqutJZjRTbKAeciOPlx != null)
						{
							TPZVrfaaBHqutJZjRTbKAeciOPlx.Dispose();
						}
					}

					private void itDFqyWdXPEhouAkuBRtAfumyjJrA()
					{
						teoCwrnanXIIrIpfrDaQtRsnXguFA = -1;
						if (TPZVrfaaBHqutJZjRTbKAeciOPlx != null)
						{
							TPZVrfaaBHqutJZjRTbKAeciOPlx.Dispose();
						}
					}

					private void fflDmKtatxbskaeRhGUrMnEJHExY()
					{
						teoCwrnanXIIrIpfrDaQtRsnXguFA = -1;
						if (TPZVrfaaBHqutJZjRTbKAeciOPlx != null)
						{
							TPZVrfaaBHqutJZjRTbKAeciOPlx.Dispose();
						}
					}

					private void ZIHFiiMsHiTrCFknvHQZzdOfaSlCA()
					{
						teoCwrnanXIIrIpfrDaQtRsnXguFA = -1;
						if (TPZVrfaaBHqutJZjRTbKAeciOPlx != null)
						{
							TPZVrfaaBHqutJZjRTbKAeciOPlx.Dispose();
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
						pSUIisUOTVVSiwGZAuotUEaGEjTU pSUIisUOTVVSiwGZAuotUEaGEjTU2;
						if (teoCwrnanXIIrIpfrDaQtRsnXguFA == -2 && kSTvsrqatJJlHhUVTeDUcPGsjEMJ == Environment.CurrentManagedThreadId)
						{
							teoCwrnanXIIrIpfrDaQtRsnXguFA = 0;
							pSUIisUOTVVSiwGZAuotUEaGEjTU2 = this;
						}
						else
						{
							pSUIisUOTVVSiwGZAuotUEaGEjTU2 = new pSUIisUOTVVSiwGZAuotUEaGEjTU(0);
							pSUIisUOTVVSiwGZAuotUEaGEjTU2.nqBpuHAMzJoFDiqpenbBdMHCqcgF = nqBpuHAMzJoFDiqpenbBdMHCqcgF;
						}
						return pSUIisUOTVVSiwGZAuotUEaGEjTU2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class JMHEpgUHAqhbRQqlcSKhfSpGBzIt : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int YIOlJkzsrBhEuxQLfRVdCxqvIgkk;

					private ControllerPollingInfo SLdHyGKJqpRbQWrOOcMtxhAmrfwC;

					private int mzDaAajaPAkJDSznNVkkptrghZfFb;

					public PollingHelper oiDuitsIQXKkPjseImRymhtbxOB;

					private IEnumerator<ControllerPollingInfo> nlwKoqMscVfaryTgxSWgUTQxIbER;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return SLdHyGKJqpRbQWrOOcMtxhAmrfwC;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return SLdHyGKJqpRbQWrOOcMtxhAmrfwC;
						}
					}

					[DebuggerHidden]
					public JMHEpgUHAqhbRQqlcSKhfSpGBzIt(int P_0)
					{
						YIOlJkzsrBhEuxQLfRVdCxqvIgkk = P_0;
						mzDaAajaPAkJDSznNVkkptrghZfFb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						switch (YIOlJkzsrBhEuxQLfRVdCxqvIgkk)
						{
						case -3:
						case 1:
							try
							{
								break;
							}
							finally
							{
								HgGwOMNiJDMUTkaKPjIyHseJsHeib();
							}
						case -4:
						case 2:
							try
							{
								break;
							}
							finally
							{
								SiGFismvDkoeKmUmmoJulhhzYugX();
							}
						case -5:
						case 3:
							try
							{
								break;
							}
							finally
							{
								VfZjgRkFgcbmqTBGghlpTKfZpNcEA();
							}
						case -6:
						case 4:
							try
							{
								break;
							}
							finally
							{
								YjitPuayuzPEoqRezedVvPyPwhNV();
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
							int yIOlJkzsrBhEuxQLfRVdCxqvIgkk = YIOlJkzsrBhEuxQLfRVdCxqvIgkk;
							PollingHelper pollingHelper = oiDuitsIQXKkPjseImRymhtbxOB;
							switch (yIOlJkzsrBhEuxQLfRVdCxqvIgkk)
							{
							default:
								return false;
							case 0:
								YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -1;
								if (!CheckInitialized())
								{
									return false;
								}
								nlwKoqMscVfaryTgxSWgUTQxIbER = pollingHelper.pyyAtlrSrgoASFXjRoDLJXfpYroI().GetEnumerator();
								YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -3;
								goto IL_0088;
							case 1:
								YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -3;
								goto IL_0088;
							case 2:
								YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -4;
								goto IL_00e8;
							case 3:
								YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -5;
								goto IL_0148;
							case 4:
								{
									YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -6;
									break;
								}
								IL_00e8:
								if (nlwKoqMscVfaryTgxSWgUTQxIbER.MoveNext())
								{
									ControllerPollingInfo current = nlwKoqMscVfaryTgxSWgUTQxIbER.Current;
									SLdHyGKJqpRbQWrOOcMtxhAmrfwC = current;
									YIOlJkzsrBhEuxQLfRVdCxqvIgkk = 2;
									return true;
								}
								SiGFismvDkoeKmUmmoJulhhzYugX();
								nlwKoqMscVfaryTgxSWgUTQxIbER = null;
								nlwKoqMscVfaryTgxSWgUTQxIbER = pollingHelper.RkWRKFSTIXupCNGGnEMCOEVEOurX().GetEnumerator();
								YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -5;
								goto IL_0148;
								IL_0088:
								if (nlwKoqMscVfaryTgxSWgUTQxIbER.MoveNext())
								{
									ControllerPollingInfo current2 = nlwKoqMscVfaryTgxSWgUTQxIbER.Current;
									SLdHyGKJqpRbQWrOOcMtxhAmrfwC = current2;
									YIOlJkzsrBhEuxQLfRVdCxqvIgkk = 1;
									return true;
								}
								HgGwOMNiJDMUTkaKPjIyHseJsHeib();
								nlwKoqMscVfaryTgxSWgUTQxIbER = null;
								nlwKoqMscVfaryTgxSWgUTQxIbER = pollingHelper.eCzhgbMoAbJYuEobmsgyTjDAHCEbb().GetEnumerator();
								YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -4;
								goto IL_00e8;
								IL_0148:
								if (nlwKoqMscVfaryTgxSWgUTQxIbER.MoveNext())
								{
									ControllerPollingInfo current3 = nlwKoqMscVfaryTgxSWgUTQxIbER.Current;
									SLdHyGKJqpRbQWrOOcMtxhAmrfwC = current3;
									YIOlJkzsrBhEuxQLfRVdCxqvIgkk = 3;
									return true;
								}
								VfZjgRkFgcbmqTBGghlpTKfZpNcEA();
								nlwKoqMscVfaryTgxSWgUTQxIbER = null;
								nlwKoqMscVfaryTgxSWgUTQxIbER = pollingHelper.LknzdIwhjxJXkcvZJalzGQLASbvo().GetEnumerator();
								YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -6;
								break;
							}
							if (nlwKoqMscVfaryTgxSWgUTQxIbER.MoveNext())
							{
								ControllerPollingInfo current4 = nlwKoqMscVfaryTgxSWgUTQxIbER.Current;
								SLdHyGKJqpRbQWrOOcMtxhAmrfwC = current4;
								YIOlJkzsrBhEuxQLfRVdCxqvIgkk = 4;
								return true;
							}
							YjitPuayuzPEoqRezedVvPyPwhNV();
							nlwKoqMscVfaryTgxSWgUTQxIbER = null;
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

					private void HgGwOMNiJDMUTkaKPjIyHseJsHeib()
					{
						YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -1;
						if (nlwKoqMscVfaryTgxSWgUTQxIbER != null)
						{
							nlwKoqMscVfaryTgxSWgUTQxIbER.Dispose();
						}
					}

					private void SiGFismvDkoeKmUmmoJulhhzYugX()
					{
						YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -1;
						if (nlwKoqMscVfaryTgxSWgUTQxIbER != null)
						{
							nlwKoqMscVfaryTgxSWgUTQxIbER.Dispose();
						}
					}

					private void VfZjgRkFgcbmqTBGghlpTKfZpNcEA()
					{
						YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -1;
						if (nlwKoqMscVfaryTgxSWgUTQxIbER != null)
						{
							nlwKoqMscVfaryTgxSWgUTQxIbER.Dispose();
						}
					}

					private void YjitPuayuzPEoqRezedVvPyPwhNV()
					{
						YIOlJkzsrBhEuxQLfRVdCxqvIgkk = -1;
						if (nlwKoqMscVfaryTgxSWgUTQxIbER != null)
						{
							nlwKoqMscVfaryTgxSWgUTQxIbER.Dispose();
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
						JMHEpgUHAqhbRQqlcSKhfSpGBzIt jMHEpgUHAqhbRQqlcSKhfSpGBzIt;
						if (YIOlJkzsrBhEuxQLfRVdCxqvIgkk == -2 && mzDaAajaPAkJDSznNVkkptrghZfFb == Environment.CurrentManagedThreadId)
						{
							YIOlJkzsrBhEuxQLfRVdCxqvIgkk = 0;
							jMHEpgUHAqhbRQqlcSKhfSpGBzIt = this;
						}
						else
						{
							jMHEpgUHAqhbRQqlcSKhfSpGBzIt = new JMHEpgUHAqhbRQqlcSKhfSpGBzIt(0);
							jMHEpgUHAqhbRQqlcSKhfSpGBzIt.oiDuitsIQXKkPjseImRymhtbxOB = oiDuitsIQXKkPjseImRymhtbxOB;
						}
						return jMHEpgUHAqhbRQqlcSKhfSpGBzIt;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ZaYhNUaodeHUTBAzgHNWZunODGzFb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int mkgDzWfSGbntkDhteGHwfRMJfoxl;

					private ControllerPollingInfo QLYpzujSnnIgyhADRcgiyRBMCPNW;

					private int GIdfHCFwQPKLEWytrhBsMOvmLXVaA;

					private IList<CustomController> ZZjMXleDCGiCJcCSVLASZAHlZkvn;

					private int HDWfnPFYEWEHKJCfnsbQuPIAjbuVA;

					private IEnumerator<ControllerPollingInfo> EqdkmMPzWTxHLiCOfXypxinGimej;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return QLYpzujSnnIgyhADRcgiyRBMCPNW;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return QLYpzujSnnIgyhADRcgiyRBMCPNW;
						}
					}

					[DebuggerHidden]
					public ZaYhNUaodeHUTBAzgHNWZunODGzFb(int P_0)
					{
						mkgDzWfSGbntkDhteGHwfRMJfoxl = P_0;
						GIdfHCFwQPKLEWytrhBsMOvmLXVaA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = mkgDzWfSGbntkDhteGHwfRMJfoxl;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								vuOGNSwWMNlYfXVsYiaiVmbBEIYhA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = mkgDzWfSGbntkDhteGHwfRMJfoxl;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								mkgDzWfSGbntkDhteGHwfRMJfoxl = -3;
								goto IL_0086;
							}
							mkgDzWfSGbntkDhteGHwfRMJfoxl = -1;
							ZZjMXleDCGiCJcCSVLASZAHlZkvn = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
							HDWfnPFYEWEHKJCfnsbQuPIAjbuVA = 0;
							goto IL_00b0;
							IL_0086:
							if (EqdkmMPzWTxHLiCOfXypxinGimej.MoveNext())
							{
								ControllerPollingInfo current = EqdkmMPzWTxHLiCOfXypxinGimej.Current;
								QLYpzujSnnIgyhADRcgiyRBMCPNW = current;
								mkgDzWfSGbntkDhteGHwfRMJfoxl = 1;
								return true;
							}
							vuOGNSwWMNlYfXVsYiaiVmbBEIYhA();
							EqdkmMPzWTxHLiCOfXypxinGimej = null;
							HDWfnPFYEWEHKJCfnsbQuPIAjbuVA++;
							goto IL_00b0;
							IL_00b0:
							if (HDWfnPFYEWEHKJCfnsbQuPIAjbuVA < ZZjMXleDCGiCJcCSVLASZAHlZkvn.Count)
							{
								EqdkmMPzWTxHLiCOfXypxinGimej = ZZjMXleDCGiCJcCSVLASZAHlZkvn[HDWfnPFYEWEHKJCfnsbQuPIAjbuVA].PollForAllAxes().GetEnumerator();
								mkgDzWfSGbntkDhteGHwfRMJfoxl = -3;
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

					private void vuOGNSwWMNlYfXVsYiaiVmbBEIYhA()
					{
						mkgDzWfSGbntkDhteGHwfRMJfoxl = -1;
						if (EqdkmMPzWTxHLiCOfXypxinGimej != null)
						{
							EqdkmMPzWTxHLiCOfXypxinGimej.Dispose();
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
						if (mkgDzWfSGbntkDhteGHwfRMJfoxl == -2 && GIdfHCFwQPKLEWytrhBsMOvmLXVaA == Environment.CurrentManagedThreadId)
						{
							mkgDzWfSGbntkDhteGHwfRMJfoxl = 0;
							return this;
						}
						return new ZaYhNUaodeHUTBAzgHNWZunODGzFb(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class zTFDHBkDWLePIxSYExlJJnpmmyDB : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int nJaEPDiaZXqkGewbMYzWJfzrOeIF;

					private ControllerPollingInfo eCdXnDfgofcqYWHdITuthOAAmbdP;

					private int drwMkIGQNqaMrjdeaoyokOclobfh;

					private IList<CustomController> klkGsYbBuSjlGFfTrTJjvmIziJBBb;

					private int YZTaReEJpFsPODwjDtuhjQWuKDWsA;

					private IEnumerator<ControllerPollingInfo> HBFSvpWTDVARJGotOKdbFHVCsQns;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return eCdXnDfgofcqYWHdITuthOAAmbdP;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return eCdXnDfgofcqYWHdITuthOAAmbdP;
						}
					}

					[DebuggerHidden]
					public zTFDHBkDWLePIxSYExlJJnpmmyDB(int P_0)
					{
						nJaEPDiaZXqkGewbMYzWJfzrOeIF = P_0;
						drwMkIGQNqaMrjdeaoyokOclobfh = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = nJaEPDiaZXqkGewbMYzWJfzrOeIF;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								NdvFCEvgBAPJcvoCHNYaRNhgJvZI();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = nJaEPDiaZXqkGewbMYzWJfzrOeIF;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								nJaEPDiaZXqkGewbMYzWJfzrOeIF = -3;
								goto IL_0086;
							}
							nJaEPDiaZXqkGewbMYzWJfzrOeIF = -1;
							klkGsYbBuSjlGFfTrTJjvmIziJBBb = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
							YZTaReEJpFsPODwjDtuhjQWuKDWsA = 0;
							goto IL_00b0;
							IL_0086:
							if (HBFSvpWTDVARJGotOKdbFHVCsQns.MoveNext())
							{
								ControllerPollingInfo current = HBFSvpWTDVARJGotOKdbFHVCsQns.Current;
								eCdXnDfgofcqYWHdITuthOAAmbdP = current;
								nJaEPDiaZXqkGewbMYzWJfzrOeIF = 1;
								return true;
							}
							NdvFCEvgBAPJcvoCHNYaRNhgJvZI();
							HBFSvpWTDVARJGotOKdbFHVCsQns = null;
							YZTaReEJpFsPODwjDtuhjQWuKDWsA++;
							goto IL_00b0;
							IL_00b0:
							if (YZTaReEJpFsPODwjDtuhjQWuKDWsA < klkGsYbBuSjlGFfTrTJjvmIziJBBb.Count)
							{
								HBFSvpWTDVARJGotOKdbFHVCsQns = klkGsYbBuSjlGFfTrTJjvmIziJBBb[YZTaReEJpFsPODwjDtuhjQWuKDWsA].PollForAllButtons().GetEnumerator();
								nJaEPDiaZXqkGewbMYzWJfzrOeIF = -3;
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

					private void NdvFCEvgBAPJcvoCHNYaRNhgJvZI()
					{
						nJaEPDiaZXqkGewbMYzWJfzrOeIF = -1;
						if (HBFSvpWTDVARJGotOKdbFHVCsQns != null)
						{
							HBFSvpWTDVARJGotOKdbFHVCsQns.Dispose();
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
						if (nJaEPDiaZXqkGewbMYzWJfzrOeIF == -2 && drwMkIGQNqaMrjdeaoyokOclobfh == Environment.CurrentManagedThreadId)
						{
							nJaEPDiaZXqkGewbMYzWJfzrOeIF = 0;
							return this;
						}
						return new zTFDHBkDWLePIxSYExlJJnpmmyDB(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class qliVjJAKYastZvvDKHlzvpmeJVcM : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int YdxFcGzfmaQRAOkBkHHmiCpIKsmW;

					private ControllerPollingInfo sREGwVxwwyEZOnDYPRKNSKgDisOm;

					private int UiakHgrpuwmkRnjztKsVTpiCNqZE;

					private IList<CustomController> IsHdiDNLvHqKMeuxcCmaKIfdaapjA;

					private int pRMNWnRjLehAjCpGlHIhZkBcUfWs;

					private IEnumerator<ControllerPollingInfo> cLaeBedlPXJGRdYvMrSYRAOeAblcb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return sREGwVxwwyEZOnDYPRKNSKgDisOm;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return sREGwVxwwyEZOnDYPRKNSKgDisOm;
						}
					}

					[DebuggerHidden]
					public qliVjJAKYastZvvDKHlzvpmeJVcM(int P_0)
					{
						YdxFcGzfmaQRAOkBkHHmiCpIKsmW = P_0;
						UiakHgrpuwmkRnjztKsVTpiCNqZE = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int ydxFcGzfmaQRAOkBkHHmiCpIKsmW = YdxFcGzfmaQRAOkBkHHmiCpIKsmW;
						if (ydxFcGzfmaQRAOkBkHHmiCpIKsmW == -3 || ydxFcGzfmaQRAOkBkHHmiCpIKsmW == 1)
						{
							try
							{
							}
							finally
							{
								wfcsyRAbuMBvEdBIOknDLVzTSKAaA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int ydxFcGzfmaQRAOkBkHHmiCpIKsmW = YdxFcGzfmaQRAOkBkHHmiCpIKsmW;
							if (ydxFcGzfmaQRAOkBkHHmiCpIKsmW != 0)
							{
								if (ydxFcGzfmaQRAOkBkHHmiCpIKsmW != 1)
								{
									return false;
								}
								YdxFcGzfmaQRAOkBkHHmiCpIKsmW = -3;
								goto IL_0086;
							}
							YdxFcGzfmaQRAOkBkHHmiCpIKsmW = -1;
							IsHdiDNLvHqKMeuxcCmaKIfdaapjA = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
							pRMNWnRjLehAjCpGlHIhZkBcUfWs = 0;
							goto IL_00b0;
							IL_0086:
							if (cLaeBedlPXJGRdYvMrSYRAOeAblcb.MoveNext())
							{
								ControllerPollingInfo current = cLaeBedlPXJGRdYvMrSYRAOeAblcb.Current;
								sREGwVxwwyEZOnDYPRKNSKgDisOm = current;
								YdxFcGzfmaQRAOkBkHHmiCpIKsmW = 1;
								return true;
							}
							wfcsyRAbuMBvEdBIOknDLVzTSKAaA();
							cLaeBedlPXJGRdYvMrSYRAOeAblcb = null;
							pRMNWnRjLehAjCpGlHIhZkBcUfWs++;
							goto IL_00b0;
							IL_00b0:
							if (pRMNWnRjLehAjCpGlHIhZkBcUfWs < IsHdiDNLvHqKMeuxcCmaKIfdaapjA.Count)
							{
								cLaeBedlPXJGRdYvMrSYRAOeAblcb = IsHdiDNLvHqKMeuxcCmaKIfdaapjA[pRMNWnRjLehAjCpGlHIhZkBcUfWs].PollForAllButtonsDown().GetEnumerator();
								YdxFcGzfmaQRAOkBkHHmiCpIKsmW = -3;
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

					private void wfcsyRAbuMBvEdBIOknDLVzTSKAaA()
					{
						YdxFcGzfmaQRAOkBkHHmiCpIKsmW = -1;
						if (cLaeBedlPXJGRdYvMrSYRAOeAblcb != null)
						{
							cLaeBedlPXJGRdYvMrSYRAOeAblcb.Dispose();
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
						if (YdxFcGzfmaQRAOkBkHHmiCpIKsmW == -2 && UiakHgrpuwmkRnjztKsVTpiCNqZE == Environment.CurrentManagedThreadId)
						{
							YdxFcGzfmaQRAOkBkHHmiCpIKsmW = 0;
							return this;
						}
						return new qliVjJAKYastZvvDKHlzvpmeJVcM(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class DqfRQKSgSZdaCCPFTlhbgaRVwvWp : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int NTjeQZPArYsDfCeVyauXReyeyfGf;

					private ControllerPollingInfo anCAgsDZqZypQeSYQUNHLcnBNFBvA;

					private int avZdATgBrmmmaWHIowGyWPIyZLCh;

					private IList<CustomController> fciguuEFOQmOSbjDicrQvJeoTmYUB;

					private int OWQDJjBSKKaRqcbAGzEDgcUEmKKND;

					private IEnumerator<ControllerPollingInfo> WIXAaseQFSLfiKbwKlccMiSDSSVdA;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return anCAgsDZqZypQeSYQUNHLcnBNFBvA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return anCAgsDZqZypQeSYQUNHLcnBNFBvA;
						}
					}

					[DebuggerHidden]
					public DqfRQKSgSZdaCCPFTlhbgaRVwvWp(int P_0)
					{
						NTjeQZPArYsDfCeVyauXReyeyfGf = P_0;
						avZdATgBrmmmaWHIowGyWPIyZLCh = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int nTjeQZPArYsDfCeVyauXReyeyfGf = NTjeQZPArYsDfCeVyauXReyeyfGf;
						if (nTjeQZPArYsDfCeVyauXReyeyfGf == -3 || nTjeQZPArYsDfCeVyauXReyeyfGf == 1)
						{
							try
							{
							}
							finally
							{
								QmSgXBNqviFGesWezVIzwcxJltqr();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int nTjeQZPArYsDfCeVyauXReyeyfGf = NTjeQZPArYsDfCeVyauXReyeyfGf;
							if (nTjeQZPArYsDfCeVyauXReyeyfGf != 0)
							{
								if (nTjeQZPArYsDfCeVyauXReyeyfGf != 1)
								{
									return false;
								}
								NTjeQZPArYsDfCeVyauXReyeyfGf = -3;
								goto IL_0086;
							}
							NTjeQZPArYsDfCeVyauXReyeyfGf = -1;
							fciguuEFOQmOSbjDicrQvJeoTmYUB = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
							OWQDJjBSKKaRqcbAGzEDgcUEmKKND = 0;
							goto IL_00b0;
							IL_0086:
							if (WIXAaseQFSLfiKbwKlccMiSDSSVdA.MoveNext())
							{
								ControllerPollingInfo current = WIXAaseQFSLfiKbwKlccMiSDSSVdA.Current;
								anCAgsDZqZypQeSYQUNHLcnBNFBvA = current;
								NTjeQZPArYsDfCeVyauXReyeyfGf = 1;
								return true;
							}
							QmSgXBNqviFGesWezVIzwcxJltqr();
							WIXAaseQFSLfiKbwKlccMiSDSSVdA = null;
							OWQDJjBSKKaRqcbAGzEDgcUEmKKND++;
							goto IL_00b0;
							IL_00b0:
							if (OWQDJjBSKKaRqcbAGzEDgcUEmKKND < fciguuEFOQmOSbjDicrQvJeoTmYUB.Count)
							{
								WIXAaseQFSLfiKbwKlccMiSDSSVdA = fciguuEFOQmOSbjDicrQvJeoTmYUB[OWQDJjBSKKaRqcbAGzEDgcUEmKKND].PollForAllElements().GetEnumerator();
								NTjeQZPArYsDfCeVyauXReyeyfGf = -3;
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

					private void QmSgXBNqviFGesWezVIzwcxJltqr()
					{
						NTjeQZPArYsDfCeVyauXReyeyfGf = -1;
						if (WIXAaseQFSLfiKbwKlccMiSDSSVdA != null)
						{
							WIXAaseQFSLfiKbwKlccMiSDSSVdA.Dispose();
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
						if (NTjeQZPArYsDfCeVyauXReyeyfGf == -2 && avZdATgBrmmmaWHIowGyWPIyZLCh == Environment.CurrentManagedThreadId)
						{
							NTjeQZPArYsDfCeVyauXReyeyfGf = 0;
							return this;
						}
						return new DqfRQKSgSZdaCCPFTlhbgaRVwvWp(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class tAdqlEBvPPQJjzuURlJghLIjExYi : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int JwgJCLueEYxwSMtvSmvWKMNMpKoq;

					private ControllerPollingInfo qCpXTmFPPLYkyidznFxOGwvEZWhx;

					private int xKIGYqeechCMtrxjCLKaGBZhyZwNA;

					private IList<CustomController> gdRSVyaXmPgpuSytbCGinLbemheK;

					private int mfgGtVnLZmdkNIhqVPctarJgLttic;

					private IEnumerator<ControllerPollingInfo> ZLgnhiFOuZsqvbIoJnUJaHptpAPf;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return qCpXTmFPPLYkyidznFxOGwvEZWhx;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return qCpXTmFPPLYkyidznFxOGwvEZWhx;
						}
					}

					[DebuggerHidden]
					public tAdqlEBvPPQJjzuURlJghLIjExYi(int P_0)
					{
						JwgJCLueEYxwSMtvSmvWKMNMpKoq = P_0;
						xKIGYqeechCMtrxjCLKaGBZhyZwNA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int jwgJCLueEYxwSMtvSmvWKMNMpKoq = JwgJCLueEYxwSMtvSmvWKMNMpKoq;
						if (jwgJCLueEYxwSMtvSmvWKMNMpKoq == -3 || jwgJCLueEYxwSMtvSmvWKMNMpKoq == 1)
						{
							try
							{
							}
							finally
							{
								HpcbgcecJMkPUFWWSpgJjfZJPowCA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int jwgJCLueEYxwSMtvSmvWKMNMpKoq = JwgJCLueEYxwSMtvSmvWKMNMpKoq;
							if (jwgJCLueEYxwSMtvSmvWKMNMpKoq != 0)
							{
								if (jwgJCLueEYxwSMtvSmvWKMNMpKoq != 1)
								{
									return false;
								}
								JwgJCLueEYxwSMtvSmvWKMNMpKoq = -3;
								goto IL_0086;
							}
							JwgJCLueEYxwSMtvSmvWKMNMpKoq = -1;
							gdRSVyaXmPgpuSytbCGinLbemheK = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
							mfgGtVnLZmdkNIhqVPctarJgLttic = 0;
							goto IL_00b0;
							IL_0086:
							if (ZLgnhiFOuZsqvbIoJnUJaHptpAPf.MoveNext())
							{
								ControllerPollingInfo current = ZLgnhiFOuZsqvbIoJnUJaHptpAPf.Current;
								qCpXTmFPPLYkyidznFxOGwvEZWhx = current;
								JwgJCLueEYxwSMtvSmvWKMNMpKoq = 1;
								return true;
							}
							HpcbgcecJMkPUFWWSpgJjfZJPowCA();
							ZLgnhiFOuZsqvbIoJnUJaHptpAPf = null;
							mfgGtVnLZmdkNIhqVPctarJgLttic++;
							goto IL_00b0;
							IL_00b0:
							if (mfgGtVnLZmdkNIhqVPctarJgLttic < gdRSVyaXmPgpuSytbCGinLbemheK.Count)
							{
								ZLgnhiFOuZsqvbIoJnUJaHptpAPf = gdRSVyaXmPgpuSytbCGinLbemheK[mfgGtVnLZmdkNIhqVPctarJgLttic].PollForAllElementsDown().GetEnumerator();
								JwgJCLueEYxwSMtvSmvWKMNMpKoq = -3;
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

					private void HpcbgcecJMkPUFWWSpgJjfZJPowCA()
					{
						JwgJCLueEYxwSMtvSmvWKMNMpKoq = -1;
						if (ZLgnhiFOuZsqvbIoJnUJaHptpAPf != null)
						{
							ZLgnhiFOuZsqvbIoJnUJaHptpAPf.Dispose();
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
						if (JwgJCLueEYxwSMtvSmvWKMNMpKoq == -2 && xKIGYqeechCMtrxjCLKaGBZhyZwNA == Environment.CurrentManagedThreadId)
						{
							JwgJCLueEYxwSMtvSmvWKMNMpKoq = 0;
							return this;
						}
						return new tAdqlEBvPPQJjzuURlJghLIjExYi(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class lraagfQvraaCAWKhMXMVCwSWDOx : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int AtHcfaECyVRcfFlsUbsauKucCKmQA;

					private ControllerPollingInfo DFxOHosiThelojjoOgJxnuzAZSQjA;

					private int TzLuScYEhhmdQujKUbvyuSppblDP;

					private IList<Joystick> hWQyDnOHwydbMPYwpQsPVkowwLfk;

					private int UZOBzaBwdspAbaZcQzKJWOYwRdPm;

					private IEnumerator<ControllerPollingInfo> PsBUrqFpTYlEFZKenIIBRYaTCbAn;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DFxOHosiThelojjoOgJxnuzAZSQjA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DFxOHosiThelojjoOgJxnuzAZSQjA;
						}
					}

					[DebuggerHidden]
					public lraagfQvraaCAWKhMXMVCwSWDOx(int P_0)
					{
						AtHcfaECyVRcfFlsUbsauKucCKmQA = P_0;
						TzLuScYEhhmdQujKUbvyuSppblDP = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int atHcfaECyVRcfFlsUbsauKucCKmQA = AtHcfaECyVRcfFlsUbsauKucCKmQA;
						if (atHcfaECyVRcfFlsUbsauKucCKmQA == -3 || atHcfaECyVRcfFlsUbsauKucCKmQA == 1)
						{
							try
							{
							}
							finally
							{
								UOjjBDCFcRFSTACtofkCmtAltJO();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int atHcfaECyVRcfFlsUbsauKucCKmQA = AtHcfaECyVRcfFlsUbsauKucCKmQA;
							if (atHcfaECyVRcfFlsUbsauKucCKmQA != 0)
							{
								if (atHcfaECyVRcfFlsUbsauKucCKmQA != 1)
								{
									return false;
								}
								AtHcfaECyVRcfFlsUbsauKucCKmQA = -3;
								goto IL_0086;
							}
							AtHcfaECyVRcfFlsUbsauKucCKmQA = -1;
							hWQyDnOHwydbMPYwpQsPVkowwLfk = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
							UZOBzaBwdspAbaZcQzKJWOYwRdPm = 0;
							goto IL_00b0;
							IL_0086:
							if (PsBUrqFpTYlEFZKenIIBRYaTCbAn.MoveNext())
							{
								ControllerPollingInfo current = PsBUrqFpTYlEFZKenIIBRYaTCbAn.Current;
								DFxOHosiThelojjoOgJxnuzAZSQjA = current;
								AtHcfaECyVRcfFlsUbsauKucCKmQA = 1;
								return true;
							}
							UOjjBDCFcRFSTACtofkCmtAltJO();
							PsBUrqFpTYlEFZKenIIBRYaTCbAn = null;
							UZOBzaBwdspAbaZcQzKJWOYwRdPm++;
							goto IL_00b0;
							IL_00b0:
							if (UZOBzaBwdspAbaZcQzKJWOYwRdPm < hWQyDnOHwydbMPYwpQsPVkowwLfk.Count)
							{
								PsBUrqFpTYlEFZKenIIBRYaTCbAn = hWQyDnOHwydbMPYwpQsPVkowwLfk[UZOBzaBwdspAbaZcQzKJWOYwRdPm].PollForAllAxes().GetEnumerator();
								AtHcfaECyVRcfFlsUbsauKucCKmQA = -3;
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

					private void UOjjBDCFcRFSTACtofkCmtAltJO()
					{
						AtHcfaECyVRcfFlsUbsauKucCKmQA = -1;
						if (PsBUrqFpTYlEFZKenIIBRYaTCbAn != null)
						{
							PsBUrqFpTYlEFZKenIIBRYaTCbAn.Dispose();
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
						if (AtHcfaECyVRcfFlsUbsauKucCKmQA == -2 && TzLuScYEhhmdQujKUbvyuSppblDP == Environment.CurrentManagedThreadId)
						{
							AtHcfaECyVRcfFlsUbsauKucCKmQA = 0;
							return this;
						}
						return new lraagfQvraaCAWKhMXMVCwSWDOx(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class FOVgfRNWrRVnONlMzGzqkRauZuBP : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int cYrPterQKDiKkHGoGgbzhQQIbWWRB;

					private ControllerPollingInfo wSRIMRuVXVxXyScFdPIUgVMHlKbj;

					private int fqxPKuHhuGwaOaIGnNlrAoFKsICw;

					private IList<Joystick> PMYqCVtOXawzWEMbscBJlhUzLDBX;

					private int cDDNfZLzzQrhaWGNBzaagntuaLIE;

					private IEnumerator<ControllerPollingInfo> sVmdLcCMCjmaSAVvZtLyJuNDijxh;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return wSRIMRuVXVxXyScFdPIUgVMHlKbj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return wSRIMRuVXVxXyScFdPIUgVMHlKbj;
						}
					}

					[DebuggerHidden]
					public FOVgfRNWrRVnONlMzGzqkRauZuBP(int P_0)
					{
						cYrPterQKDiKkHGoGgbzhQQIbWWRB = P_0;
						fqxPKuHhuGwaOaIGnNlrAoFKsICw = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = cYrPterQKDiKkHGoGgbzhQQIbWWRB;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								hjIbFCYtORXxWKdpAIYLKdBKPluf();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = cYrPterQKDiKkHGoGgbzhQQIbWWRB;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								cYrPterQKDiKkHGoGgbzhQQIbWWRB = -3;
								goto IL_0086;
							}
							cYrPterQKDiKkHGoGgbzhQQIbWWRB = -1;
							PMYqCVtOXawzWEMbscBJlhUzLDBX = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
							cDDNfZLzzQrhaWGNBzaagntuaLIE = 0;
							goto IL_00b0;
							IL_0086:
							if (sVmdLcCMCjmaSAVvZtLyJuNDijxh.MoveNext())
							{
								ControllerPollingInfo current = sVmdLcCMCjmaSAVvZtLyJuNDijxh.Current;
								wSRIMRuVXVxXyScFdPIUgVMHlKbj = current;
								cYrPterQKDiKkHGoGgbzhQQIbWWRB = 1;
								return true;
							}
							hjIbFCYtORXxWKdpAIYLKdBKPluf();
							sVmdLcCMCjmaSAVvZtLyJuNDijxh = null;
							cDDNfZLzzQrhaWGNBzaagntuaLIE++;
							goto IL_00b0;
							IL_00b0:
							if (cDDNfZLzzQrhaWGNBzaagntuaLIE < PMYqCVtOXawzWEMbscBJlhUzLDBX.Count)
							{
								sVmdLcCMCjmaSAVvZtLyJuNDijxh = PMYqCVtOXawzWEMbscBJlhUzLDBX[cDDNfZLzzQrhaWGNBzaagntuaLIE].PollForAllButtons().GetEnumerator();
								cYrPterQKDiKkHGoGgbzhQQIbWWRB = -3;
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

					private void hjIbFCYtORXxWKdpAIYLKdBKPluf()
					{
						cYrPterQKDiKkHGoGgbzhQQIbWWRB = -1;
						if (sVmdLcCMCjmaSAVvZtLyJuNDijxh != null)
						{
							sVmdLcCMCjmaSAVvZtLyJuNDijxh.Dispose();
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
						if (cYrPterQKDiKkHGoGgbzhQQIbWWRB == -2 && fqxPKuHhuGwaOaIGnNlrAoFKsICw == Environment.CurrentManagedThreadId)
						{
							cYrPterQKDiKkHGoGgbzhQQIbWWRB = 0;
							return this;
						}
						return new FOVgfRNWrRVnONlMzGzqkRauZuBP(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class ogZGHjfnqVMUxOHsaCKQRAiysSAv : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int mNLqgIvuAjOReQUvkxBSRlIIKJv;

					private ControllerPollingInfo isfLDoItkpEASydfhbBVkvODdAyhA;

					private int QXBqYBiNKnLlCMzojAIBlsjEkZYh;

					private IList<Joystick> IJzBXKNtMgojmYxWQvKqbeCNuUUI;

					private int wiySpaHEFliBABcXvwspStoOcWCS;

					private IEnumerator<ControllerPollingInfo> rsjsnziNiKYSapoiMJXBrMGZliDb;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return isfLDoItkpEASydfhbBVkvODdAyhA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return isfLDoItkpEASydfhbBVkvODdAyhA;
						}
					}

					[DebuggerHidden]
					public ogZGHjfnqVMUxOHsaCKQRAiysSAv(int P_0)
					{
						mNLqgIvuAjOReQUvkxBSRlIIKJv = P_0;
						QXBqYBiNKnLlCMzojAIBlsjEkZYh = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = mNLqgIvuAjOReQUvkxBSRlIIKJv;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								pbKBkJZtXPyaWLIexhxhvDWYpqaF();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = mNLqgIvuAjOReQUvkxBSRlIIKJv;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								mNLqgIvuAjOReQUvkxBSRlIIKJv = -3;
								goto IL_0086;
							}
							mNLqgIvuAjOReQUvkxBSRlIIKJv = -1;
							IJzBXKNtMgojmYxWQvKqbeCNuUUI = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
							wiySpaHEFliBABcXvwspStoOcWCS = 0;
							goto IL_00b0;
							IL_0086:
							if (rsjsnziNiKYSapoiMJXBrMGZliDb.MoveNext())
							{
								ControllerPollingInfo current = rsjsnziNiKYSapoiMJXBrMGZliDb.Current;
								isfLDoItkpEASydfhbBVkvODdAyhA = current;
								mNLqgIvuAjOReQUvkxBSRlIIKJv = 1;
								return true;
							}
							pbKBkJZtXPyaWLIexhxhvDWYpqaF();
							rsjsnziNiKYSapoiMJXBrMGZliDb = null;
							wiySpaHEFliBABcXvwspStoOcWCS++;
							goto IL_00b0;
							IL_00b0:
							if (wiySpaHEFliBABcXvwspStoOcWCS < IJzBXKNtMgojmYxWQvKqbeCNuUUI.Count)
							{
								rsjsnziNiKYSapoiMJXBrMGZliDb = IJzBXKNtMgojmYxWQvKqbeCNuUUI[wiySpaHEFliBABcXvwspStoOcWCS].PollForAllButtonsDown().GetEnumerator();
								mNLqgIvuAjOReQUvkxBSRlIIKJv = -3;
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

					private void pbKBkJZtXPyaWLIexhxhvDWYpqaF()
					{
						mNLqgIvuAjOReQUvkxBSRlIIKJv = -1;
						if (rsjsnziNiKYSapoiMJXBrMGZliDb != null)
						{
							rsjsnziNiKYSapoiMJXBrMGZliDb.Dispose();
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
						if (mNLqgIvuAjOReQUvkxBSRlIIKJv == -2 && QXBqYBiNKnLlCMzojAIBlsjEkZYh == Environment.CurrentManagedThreadId)
						{
							mNLqgIvuAjOReQUvkxBSRlIIKJv = 0;
							return this;
						}
						return new ogZGHjfnqVMUxOHsaCKQRAiysSAv(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class IRLWbOYyVfqevQdwjSsSlArDBHqj : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int ZFeQAmAnNMcNBzsknUqdaFWScgfi;

					private ControllerPollingInfo TNqLtVjSckYdhQZnsQwVVeATOmzL;

					private int rdTgctsVeWScCngdyiKjFvRelRfxA;

					private IList<Joystick> fsLfMtGLZhpxrGoAvnofcQXbdPPAB;

					private int PJELcDipljintahUTzdysIntRxcpA;

					private IEnumerator<ControllerPollingInfo> tdEmgYlILOKTZapybXTYYBvBGfLv;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return TNqLtVjSckYdhQZnsQwVVeATOmzL;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return TNqLtVjSckYdhQZnsQwVVeATOmzL;
						}
					}

					[DebuggerHidden]
					public IRLWbOYyVfqevQdwjSsSlArDBHqj(int P_0)
					{
						ZFeQAmAnNMcNBzsknUqdaFWScgfi = P_0;
						rdTgctsVeWScCngdyiKjFvRelRfxA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int zFeQAmAnNMcNBzsknUqdaFWScgfi = ZFeQAmAnNMcNBzsknUqdaFWScgfi;
						if (zFeQAmAnNMcNBzsknUqdaFWScgfi == -3 || zFeQAmAnNMcNBzsknUqdaFWScgfi == 1)
						{
							try
							{
							}
							finally
							{
								dNXctdbClDcIpplXpFqBUjLXCvtCA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int zFeQAmAnNMcNBzsknUqdaFWScgfi = ZFeQAmAnNMcNBzsknUqdaFWScgfi;
							if (zFeQAmAnNMcNBzsknUqdaFWScgfi != 0)
							{
								if (zFeQAmAnNMcNBzsknUqdaFWScgfi != 1)
								{
									return false;
								}
								ZFeQAmAnNMcNBzsknUqdaFWScgfi = -3;
								goto IL_0086;
							}
							ZFeQAmAnNMcNBzsknUqdaFWScgfi = -1;
							fsLfMtGLZhpxrGoAvnofcQXbdPPAB = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
							PJELcDipljintahUTzdysIntRxcpA = 0;
							goto IL_00b0;
							IL_0086:
							if (tdEmgYlILOKTZapybXTYYBvBGfLv.MoveNext())
							{
								ControllerPollingInfo current = tdEmgYlILOKTZapybXTYYBvBGfLv.Current;
								TNqLtVjSckYdhQZnsQwVVeATOmzL = current;
								ZFeQAmAnNMcNBzsknUqdaFWScgfi = 1;
								return true;
							}
							dNXctdbClDcIpplXpFqBUjLXCvtCA();
							tdEmgYlILOKTZapybXTYYBvBGfLv = null;
							PJELcDipljintahUTzdysIntRxcpA++;
							goto IL_00b0;
							IL_00b0:
							if (PJELcDipljintahUTzdysIntRxcpA < fsLfMtGLZhpxrGoAvnofcQXbdPPAB.Count)
							{
								tdEmgYlILOKTZapybXTYYBvBGfLv = fsLfMtGLZhpxrGoAvnofcQXbdPPAB[PJELcDipljintahUTzdysIntRxcpA].PollForAllElements().GetEnumerator();
								ZFeQAmAnNMcNBzsknUqdaFWScgfi = -3;
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

					private void dNXctdbClDcIpplXpFqBUjLXCvtCA()
					{
						ZFeQAmAnNMcNBzsknUqdaFWScgfi = -1;
						if (tdEmgYlILOKTZapybXTYYBvBGfLv != null)
						{
							tdEmgYlILOKTZapybXTYYBvBGfLv.Dispose();
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
						if (ZFeQAmAnNMcNBzsknUqdaFWScgfi == -2 && rdTgctsVeWScCngdyiKjFvRelRfxA == Environment.CurrentManagedThreadId)
						{
							ZFeQAmAnNMcNBzsknUqdaFWScgfi = 0;
							return this;
						}
						return new IRLWbOYyVfqevQdwjSsSlArDBHqj(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private sealed class WCAgvGeuzNpcXAXIDEOntlMKxsnBb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
				{
					private int PxNqpbhUQpqjmVeFkeBgNEUfubSu;

					private ControllerPollingInfo GnqJhbkbUXmdcidwXJmfDerXMdwr;

					private int LRzfnNFIzEjtIxgQDPQVPgSfXRPA;

					private IList<Joystick> KTMeGWXlqAdeDgeKZnTHDgfEEPvlb;

					private int MsZeRKrmNAvLwifGYSjRzFVHggM;

					private IEnumerator<ControllerPollingInfo> ubWpvqsmcyuBvQKkiutZfztxJFRI;

					ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return GnqJhbkbUXmdcidwXJmfDerXMdwr;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return GnqJhbkbUXmdcidwXJmfDerXMdwr;
						}
					}

					[DebuggerHidden]
					public WCAgvGeuzNpcXAXIDEOntlMKxsnBb(int P_0)
					{
						PxNqpbhUQpqjmVeFkeBgNEUfubSu = P_0;
						LRzfnNFIzEjtIxgQDPQVPgSfXRPA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int pxNqpbhUQpqjmVeFkeBgNEUfubSu = PxNqpbhUQpqjmVeFkeBgNEUfubSu;
						if (pxNqpbhUQpqjmVeFkeBgNEUfubSu == -3 || pxNqpbhUQpqjmVeFkeBgNEUfubSu == 1)
						{
							try
							{
							}
							finally
							{
								umQKQxyDpDiUWZGrQktvWRoQIOOF();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int pxNqpbhUQpqjmVeFkeBgNEUfubSu = PxNqpbhUQpqjmVeFkeBgNEUfubSu;
							if (pxNqpbhUQpqjmVeFkeBgNEUfubSu != 0)
							{
								if (pxNqpbhUQpqjmVeFkeBgNEUfubSu != 1)
								{
									return false;
								}
								PxNqpbhUQpqjmVeFkeBgNEUfubSu = -3;
								goto IL_0086;
							}
							PxNqpbhUQpqjmVeFkeBgNEUfubSu = -1;
							KTMeGWXlqAdeDgeKZnTHDgfEEPvlb = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
							MsZeRKrmNAvLwifGYSjRzFVHggM = 0;
							goto IL_00b0;
							IL_0086:
							if (ubWpvqsmcyuBvQKkiutZfztxJFRI.MoveNext())
							{
								ControllerPollingInfo current = ubWpvqsmcyuBvQKkiutZfztxJFRI.Current;
								GnqJhbkbUXmdcidwXJmfDerXMdwr = current;
								PxNqpbhUQpqjmVeFkeBgNEUfubSu = 1;
								return true;
							}
							umQKQxyDpDiUWZGrQktvWRoQIOOF();
							ubWpvqsmcyuBvQKkiutZfztxJFRI = null;
							MsZeRKrmNAvLwifGYSjRzFVHggM++;
							goto IL_00b0;
							IL_00b0:
							if (MsZeRKrmNAvLwifGYSjRzFVHggM < KTMeGWXlqAdeDgeKZnTHDgfEEPvlb.Count)
							{
								ubWpvqsmcyuBvQKkiutZfztxJFRI = KTMeGWXlqAdeDgeKZnTHDgfEEPvlb[MsZeRKrmNAvLwifGYSjRzFVHggM].PollForAllElementsDown().GetEnumerator();
								PxNqpbhUQpqjmVeFkeBgNEUfubSu = -3;
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

					private void umQKQxyDpDiUWZGrQktvWRoQIOOF()
					{
						PxNqpbhUQpqjmVeFkeBgNEUfubSu = -1;
						if (ubWpvqsmcyuBvQKkiutZfztxJFRI != null)
						{
							ubWpvqsmcyuBvQKkiutZfztxJFRI.Dispose();
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
						if (PxNqpbhUQpqjmVeFkeBgNEUfubSu == -2 && LRzfnNFIzEjtIxgQDPQVPgSfXRPA == Environment.CurrentManagedThreadId)
						{
							PxNqpbhUQpqjmVeFkeBgNEUfubSu = 0;
							return this;
						}
						return new WCAgvGeuzNpcXAXIDEOntlMKxsnBb(0);
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
					}
				}

				private static PollingHelper mdzyZjOVxWzWdszEtXkooYrooPRD;

				internal static PollingHelper xNTWlPDOOVHDHSQojcgyELwpJuBGA => mdzyZjOVxWzWdszEtXkooYrooPRD ?? (mdzyZjOVxWzWdszEtXkooYrooPRD = new PollingHelper());

				private PollingHelper()
				{
				}

				public ControllerPollingInfo PollAllControllersForFirstElement()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = HCdjoGjNKtNERIyEttxMgDAuXUus();
					if (result.success)
					{
						return result;
					}
					result = vXEQnrMLIewPHLzdbHlKOWXxAjOA();
					if (result.success)
					{
						return result;
					}
					result = rQuXxSBLXzlzGmcRzRwIbFPUFGJs();
					if (result.success)
					{
						return result;
					}
					result = kbCiPZvlpnmvOHSuMXNDevihtsyf();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				public ControllerPollingInfo PollAllControllersForFirstElementDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = nlosfLYUiTBWRNhXmHPfKZoNIZZl();
					if (result.success)
					{
						return result;
					}
					result = TyIDbFSSnvnNOfNUQLIEVgdFAwAq();
					if (result.success)
					{
						return result;
					}
					result = hwcgGXjxadXvWnhLJGsdrDwseDS();
					if (result.success)
					{
						return result;
					}
					result = suwUnTQjMbVNaVLdMTdrkRDEOHQb();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				public ControllerPollingInfo PollAllControllersForFirstButton()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = IxdzJbtrJhpzqvxOSVriqzgKkAkv();
					if (result.success)
					{
						return result;
					}
					result = vXEQnrMLIewPHLzdbHlKOWXxAjOA();
					if (result.success)
					{
						return result;
					}
					result = YakaJGhLsbYyWKBBczQFtbGbhKBT();
					if (result.success)
					{
						return result;
					}
					result = djMfgIFnsyAjocTWHlbSWkDecuWI();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				public ControllerPollingInfo PollAllControllersForFirstButtonDown()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = vSgMvwJXInHttvPNyiUSzGMyGllk();
					if (result.success)
					{
						return result;
					}
					result = TyIDbFSSnvnNOfNUQLIEVgdFAwAq();
					if (result.success)
					{
						return result;
					}
					result = btruwgEJVeKLPMuDBVOKIOHLnrBy();
					if (result.success)
					{
						return result;
					}
					result = XvfGdguSNFjmbLlBGplWNXoOWprb();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				public ControllerPollingInfo PollAllControllersForFirstAxis()
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					ControllerPollingInfo result = gieVOEfgrkAsUerhaWVjfDzaGljb();
					if (result.success)
					{
						return result;
					}
					result = ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					if (result.success)
					{
						return result;
					}
					result = VYbmMmoaXfPPdyIBfqOwgijYLGQi();
					if (result.success)
					{
						return result;
					}
					result = zvOWqoGcNceLPhoDqeanezNqTOeOA();
					if (result.success)
					{
						return result;
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElement(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => HCdjoGjNKtNERIyEttxMgDAuXUus(), 
						ControllerType.Keyboard => vXEQnrMLIewPHLzdbHlKOWXxAjOA(), 
						ControllerType.Mouse => rQuXxSBLXzlzGmcRzRwIbFPUFGJs(), 
						ControllerType.Custom => kbCiPZvlpnmvOHSuMXNDevihtsyf(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstElementDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => nlosfLYUiTBWRNhXmHPfKZoNIZZl(), 
						ControllerType.Keyboard => TyIDbFSSnvnNOfNUQLIEVgdFAwAq(), 
						ControllerType.Mouse => hwcgGXjxadXvWnhLJGsdrDwseDS(), 
						ControllerType.Custom => suwUnTQjMbVNaVLdMTdrkRDEOHQb(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButton(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => IxdzJbtrJhpzqvxOSVriqzgKkAkv(), 
						ControllerType.Keyboard => vXEQnrMLIewPHLzdbHlKOWXxAjOA(), 
						ControllerType.Mouse => YakaJGhLsbYyWKBBczQFtbGbhKBT(), 
						ControllerType.Custom => djMfgIFnsyAjocTWHlbSWkDecuWI(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstButtonDown(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => vSgMvwJXInHttvPNyiUSzGMyGllk(), 
						ControllerType.Keyboard => TyIDbFSSnvnNOfNUQLIEVgdFAwAq(), 
						ControllerType.Mouse => btruwgEJVeKLPMuDBVOKIOHLnrBy(), 
						ControllerType.Custom => XvfGdguSNFjmbLlBGplWNXoOWprb(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollAllControllersOfTypeForFirstAxis(ControllerType controllerType)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => gieVOEfgrkAsUerhaWVjfDzaGljb(), 
						ControllerType.Keyboard => ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf(), 
						ControllerType.Mouse => VYbmMmoaXfPPdyIBfqOwgijYLGQi(), 
						ControllerType.Custom => zvOWqoGcNceLPhoDqeanezNqTOeOA(), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElement(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => RAEExQsztlGnDEDevRanbvKXNoBf(controllerId), 
						ControllerType.Keyboard => vXEQnrMLIewPHLzdbHlKOWXxAjOA(), 
						ControllerType.Mouse => rQuXxSBLXzlzGmcRzRwIbFPUFGJs(), 
						ControllerType.Custom => sDGHTdGDiQXuLfkkrXKOsKzbIaxZ(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstElementDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => YSXBiYsysCGjiIwMKrXXsxUqoCwu(controllerId), 
						ControllerType.Keyboard => TyIDbFSSnvnNOfNUQLIEVgdFAwAq(), 
						ControllerType.Mouse => hwcgGXjxadXvWnhLJGsdrDwseDS(), 
						ControllerType.Custom => ynqlINNgNTCKLefzsfuQHBzsTxJTA(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButton(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => jXyTMderBLSbzocGIHHellGCKiGP(controllerId), 
						ControllerType.Keyboard => vXEQnrMLIewPHLzdbHlKOWXxAjOA(), 
						ControllerType.Mouse => YakaJGhLsbYyWKBBczQFtbGbhKBT(), 
						ControllerType.Custom => MOsVNJJShKaRkMkzXfBZcnpvpyZs(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstButtonDown(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => JNyvOBOxeNDphjBFYAfgeBznSDJC(controllerId), 
						ControllerType.Keyboard => TyIDbFSSnvnNOfNUQLIEVgdFAwAq(), 
						ControllerType.Mouse => btruwgEJVeKLPMuDBVOKIOHLnrBy(), 
						ControllerType.Custom => ENhroMuOYCjVYSHhtWMouKcxirfI(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				public ControllerPollingInfo PollControllerForFirstAxis(ControllerType controllerType, int controllerId)
				{
					if (!CheckInitialized())
					{
						return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
					}
					return controllerType switch
					{
						ControllerType.Joystick => TDkjoIneiSdwzxHjCUbhKxjNhMVX(controllerId), 
						ControllerType.Keyboard => ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf(), 
						ControllerType.Mouse => VYbmMmoaXfPPdyIBfqOwgijYLGQi(), 
						ControllerType.Custom => LnDTQDLHAZwArMvmkfixQmBbcGun(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				[IteratorStateMachine(typeof(pSUIisUOTVVSiwGZAuotUEaGEjTU))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElements()
				{
					return new pSUIisUOTVVSiwGZAuotUEaGEjTU(-2)
					{
						nqBpuHAMzJoFDiqpenbBdMHCqcgF = this
					};
				}

				[IteratorStateMachine(typeof(JMHEpgUHAqhbRQqlcSKhfSpGBzIt))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllElementsDown()
				{
					return new JMHEpgUHAqhbRQqlcSKhfSpGBzIt(-2)
					{
						oiDuitsIQXKkPjseImRymhtbxOB = this
					};
				}

				[IteratorStateMachine(typeof(kJiHCxNEdZucqALcPnAFsdAFFGNg))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtons()
				{
					return new kJiHCxNEdZucqALcPnAFsdAFFGNg(-2)
					{
						hneZBZJzbkGDHwsqQrHEbNMPQSjj = this
					};
				}

				[IteratorStateMachine(typeof(mFjdMvFeISNrhNfcRIEsQkqCTGnc))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllButtonsDown()
				{
					return new mFjdMvFeISNrhNfcRIEsQkqCTGnc(-2)
					{
						LJPPFAUabaQynnmZjiOZvUpqwXHR = this
					};
				}

				[IteratorStateMachine(typeof(OzREURaEFCjFXecsIqEAgEHYHqwbA))]
				public IEnumerable<ControllerPollingInfo> PollAllControllersForAllAxes()
				{
					return new OzREURaEFCjFXecsIqEAgEHYHqwbA(-2)
					{
						eSjDOclnhqOOPBscpyJqhBRWMYYb = this
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
						ControllerType.Joystick => RZBYbUYKfIciUBBJYWcZUmLubpLn(controllerId), 
						ControllerType.Keyboard => NHCbpxWYqfagkaGMqMsKInNojDoS(), 
						ControllerType.Mouse => FeYfjCwXwbYLnJfiEaCdqSQJYQGk(), 
						ControllerType.Custom => rSokXePFFZcaJwTChLaovXnhrwcd(controllerId), 
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
						ControllerType.Joystick => dOwrUfKoxesxHieFIObbgKLuAbme(controllerId), 
						ControllerType.Keyboard => eCzhgbMoAbJYuEobmsgyTjDAHCEbb(), 
						ControllerType.Mouse => RkWRKFSTIXupCNGGnEMCOEVEOurX(), 
						ControllerType.Custom => WkqPrJtvkSupdXlxegSALbrhqIul(controllerId), 
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
						ControllerType.Joystick => FDXZreQaNWpfSQvJjtabwdpyZjAA(controllerId), 
						ControllerType.Keyboard => NHCbpxWYqfagkaGMqMsKInNojDoS(), 
						ControllerType.Mouse => fXKdYUNMJpMlNKhgkTytfAvYjrIC(), 
						ControllerType.Custom => HDYQTOlZQhHyJSnSmhGludJdhXZd(controllerId), 
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
						ControllerType.Joystick => RxKqjpdDIOlWNrCmJLnjPtufepFm(controllerId), 
						ControllerType.Keyboard => eCzhgbMoAbJYuEobmsgyTjDAHCEbb(), 
						ControllerType.Mouse => ZsRGqdCejaWmEQMtgmfZirpAtFNG(), 
						ControllerType.Custom => DkBbjeUnrCiAFjszijHbjgQfGvBV(controllerId), 
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
						ControllerType.Joystick => JaIemZxmeUYfoeKDFYUWjPcmgZaF(controllerId), 
						ControllerType.Keyboard => new List<ControllerPollingInfo>(), 
						ControllerType.Mouse => IZlINAASdzgNhKhBkqYHjSNnmvtGA(), 
						ControllerType.Custom => QdYIrNDROixdVizzMtfeOEvgWrXr(controllerId), 
						_ => throw new NotImplementedException(), 
					};
				}

				private ControllerPollingInfo HCdjoGjNKtNERIyEttxMgDAuXUus()
				{
					IList<Joystick> list = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo nlosfLYUiTBWRNhXmHPfKZoNIZZl()
				{
					IList<Joystick> list = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo IxdzJbtrJhpzqvxOSVriqzgKkAkv()
				{
					IList<Joystick> list = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo vSgMvwJXInHttvPNyiUSzGMyGllk()
				{
					IList<Joystick> list = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo gieVOEfgrkAsUerhaWVjfDzaGljb()
				{
					IList<Joystick> list = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo RAEExQsztlGnDEDevRanbvKXNoBf(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo YSXBiYsysCGjiIwMKrXXsxUqoCwu(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo jXyTMderBLSbzocGIHHellGCKiGP(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo JNyvOBOxeNDphjBFYAfgeBznSDJC(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo TDkjoIneiSdwzxHjCUbhKxjNhMVX(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo vXEQnrMLIewPHLzdbHlKOWXxAjOA()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Keyboard.PollForFirstKey();
				}

				private ControllerPollingInfo TyIDbFSSnvnNOfNUQLIEVgdFAwAq()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Keyboard.PollForFirstKeyDown();
				}

				private ControllerPollingInfo rQuXxSBLXzlzGmcRzRwIbFPUFGJs()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForFirstElement();
				}

				private ControllerPollingInfo hwcgGXjxadXvWnhLJGsdrDwseDS()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForFirstElementDown();
				}

				private ControllerPollingInfo YakaJGhLsbYyWKBBczQFtbGbhKBT()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForFirstButton();
				}

				private ControllerPollingInfo btruwgEJVeKLPMuDBVOKIOHLnrBy()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForFirstButtonDown();
				}

				private ControllerPollingInfo VYbmMmoaXfPPdyIBfqOwgijYLGQi()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForFirstAxis();
				}

				private ControllerPollingInfo kbCiPZvlpnmvOHSuMXNDevihtsyf()
				{
					IList<CustomController> list = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElement();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo suwUnTQjMbVNaVLdMTdrkRDEOHQb()
				{
					IList<CustomController> list = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstElementDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo djMfgIFnsyAjocTWHlbSWkDecuWI()
				{
					IList<CustomController> list = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButton();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo XvfGdguSNFjmbLlBGplWNXoOWprb()
				{
					IList<CustomController> list = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstButtonDown();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo zvOWqoGcNceLPhoDqeanezNqTOeOA()
				{
					IList<CustomController> list = MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
					for (int i = 0; i < list.Count; i++)
					{
						ControllerPollingInfo result = list[i].PollForFirstAxis();
						if (result.success)
						{
							return result;
						}
					}
					return ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo sDGHTdGDiQXuLfkkrXKOsKzbIaxZ(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0)?.PollForFirstElement() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo ynqlINNgNTCKLefzsfuQHBzsTxJTA(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0)?.PollForFirstElementDown() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo MOsVNJJShKaRkMkzXfBZcnpvpyZs(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0)?.PollForFirstButton() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo ENhroMuOYCjVYSHhtWMouKcxirfI(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0)?.PollForFirstButtonDown() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				private ControllerPollingInfo LnDTQDLHAZwArMvmkfixQmBbcGun(int P_0)
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0)?.PollForFirstAxis() ?? ControllerPollingInfo.LhJuMFPLfNImbTTnukGMlNDRCIFf();
				}

				[IteratorStateMachine(typeof(IRLWbOYyVfqevQdwjSsSlArDBHqj))]
				private IEnumerable<ControllerPollingInfo> fQALBiYcLWgJPFFEgSPdedSUPrZO()
				{
					return new IRLWbOYyVfqevQdwjSsSlArDBHqj(-2);
				}

				[IteratorStateMachine(typeof(WCAgvGeuzNpcXAXIDEOntlMKxsnBb))]
				private IEnumerable<ControllerPollingInfo> pyyAtlrSrgoASFXjRoDLJXfpYroI()
				{
					return new WCAgvGeuzNpcXAXIDEOntlMKxsnBb(-2);
				}

				[IteratorStateMachine(typeof(FOVgfRNWrRVnONlMzGzqkRauZuBP))]
				private IEnumerable<ControllerPollingInfo> yqzDImWJECrslwZTJoWPLYbRVDiq()
				{
					return new FOVgfRNWrRVnONlMzGzqkRauZuBP(-2);
				}

				[IteratorStateMachine(typeof(ogZGHjfnqVMUxOHsaCKQRAiysSAv))]
				private IEnumerable<ControllerPollingInfo> zdJUDUSqSDsJRwwCIDMpuvdDCjnL()
				{
					return new ogZGHjfnqVMUxOHsaCKQRAiysSAv(-2);
				}

				[IteratorStateMachine(typeof(lraagfQvraaCAWKhMXMVCwSWDOx))]
				private IEnumerable<ControllerPollingInfo> GwqbjsHzzXvnZfEkZiAuMvLRxAzCA()
				{
					return new lraagfQvraaCAWKhMXMVCwSWDOx(-2);
				}

				private IEnumerable<ControllerPollingInfo> RZBYbUYKfIciUBBJYWcZUmLubpLn(int P_0)
				{
					Joystick joystick = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> dOwrUfKoxesxHieFIObbgKLuAbme(int P_0)
				{
					Joystick joystick = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> FDXZreQaNWpfSQvJjtabwdpyZjAA(int P_0)
				{
					Joystick joystick = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> RxKqjpdDIOlWNrCmJLnjPtufepFm(int P_0)
				{
					Joystick joystick = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> JaIemZxmeUYfoeKDFYUWjPcmgZaF(int P_0)
				{
					Joystick joystick = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetJoystick(P_0);
					if (joystick == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return joystick.PollForAllAxes();
				}

				private IEnumerable<ControllerPollingInfo> NHCbpxWYqfagkaGMqMsKInNojDoS()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Keyboard.PollForAllKeys();
				}

				private IEnumerable<ControllerPollingInfo> eCzhgbMoAbJYuEobmsgyTjDAHCEbb()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Keyboard.PollForAllKeysDown();
				}

				private IEnumerable<ControllerPollingInfo> FeYfjCwXwbYLnJfiEaCdqSQJYQGk()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> RkWRKFSTIXupCNGGnEMCOEVEOurX()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> fXKdYUNMJpMlNKhgkTytfAvYjrIC()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> ZsRGqdCejaWmEQMtgmfZirpAtFNG()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> IZlINAASdzgNhKhBkqYHjSNnmvtGA()
				{
					return YorxuNVUVPjNOlbshCeyhTsgCtAkA.Mouse.PollForAllAxes();
				}

				[IteratorStateMachine(typeof(DqfRQKSgSZdaCCPFTlhbgaRVwvWp))]
				private IEnumerable<ControllerPollingInfo> PwuezGQyoiHJjUivBOmEQbGIrbGk()
				{
					return new DqfRQKSgSZdaCCPFTlhbgaRVwvWp(-2);
				}

				[IteratorStateMachine(typeof(tAdqlEBvPPQJjzuURlJghLIjExYi))]
				private IEnumerable<ControllerPollingInfo> LknzdIwhjxJXkcvZJalzGQLASbvo()
				{
					return new tAdqlEBvPPQJjzuURlJghLIjExYi(-2);
				}

				[IteratorStateMachine(typeof(zTFDHBkDWLePIxSYExlJJnpmmyDB))]
				private IEnumerable<ControllerPollingInfo> sOWOKYQpHQXxznctywnyJopAszyG()
				{
					return new zTFDHBkDWLePIxSYExlJJnpmmyDB(-2);
				}

				[IteratorStateMachine(typeof(qliVjJAKYastZvvDKHlzvpmeJVcM))]
				private IEnumerable<ControllerPollingInfo> qziAfRPYIeAyWDuMAVOLEcXpLapQ()
				{
					return new qliVjJAKYastZvvDKHlzvpmeJVcM(-2);
				}

				[IteratorStateMachine(typeof(ZaYhNUaodeHUTBAzgHNWZunODGzFb))]
				private IEnumerable<ControllerPollingInfo> MDJIWxAhKfoIEjiCBIpNcYseBkkuA()
				{
					return new ZaYhNUaodeHUTBAzgHNWZunODGzFb(-2);
				}

				private IEnumerable<ControllerPollingInfo> rSokXePFFZcaJwTChLaovXnhrwcd(int P_0)
				{
					CustomController customController = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElements();
				}

				private IEnumerable<ControllerPollingInfo> WkqPrJtvkSupdXlxegSALbrhqIul(int P_0)
				{
					CustomController customController = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllElementsDown();
				}

				private IEnumerable<ControllerPollingInfo> HDYQTOlZQhHyJSnSmhGludJdhXZd(int P_0)
				{
					CustomController customController = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtons();
				}

				private IEnumerable<ControllerPollingInfo> DkBbjeUnrCiAFjszijHbjgQfGvBV(int P_0)
				{
					CustomController customController = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0);
					if (customController == null)
					{
						return new List<ControllerPollingInfo>();
					}
					return customController.PollForAllButtonsDown();
				}

				private IEnumerable<ControllerPollingInfo> QdYIrNDROixdVizzMtfeOEvgWrXr(int P_0)
				{
					CustomController customController = YorxuNVUVPjNOlbshCeyhTsgCtAkA.GetCustomController(P_0);
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
				private sealed class nUMSvZUYxFiemEupXrzRuJaOSfcu : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int rYjQMTohStWDgIkHwBBwlZKptUxb;

					private ElementAssignmentConflictInfo FsaEoBjcCSfcPikKCBhNkAahjBiu;

					private int jzSvhxoloJbosjGbLvCqEzXdTrDr;

					private int lEesoSBwxqgDBTRWANaifCQXPuE;

					public int boiCwpHCsKEJYEiauvXpydUNTPXq;

					private ActionElementMap afskhdQFMYGkuodXqDCdeDRFAyGj;

					public ActionElementMap YNZPzUMBPMgowLdFSIXjjDkvcQBK;

					private bool DcoEmXURmtgSjdkpxemfSOKYYKXc;

					public bool vMcGqkKCNTBvyFbjBuGcsCQpUAZcA;

					private int UfweiaKYvUMWvghTuFDcCfdiSTGab;

					public int UKlbktescmedYkZQofYPhZieqYpJA;

					private CustomControllerMap RoaQlTvoNRWhRiVrlGYRKveYKlyj;

					public CustomControllerMap gWZjncAbzJnWUkmACpoZzEIfZJAO;

					private bool ayzLGpfpzBhqfwuXOczpUfNLpWjE;

					public bool tEsuaAqsRMwRUWkrZXveBqgUKtLp;

					private bool pskTwlAEnCMEsYBjcEJEWddcivmq;

					public bool OIXBbipacVoEZUOyKrEIOxdsGdgu;

					private IList<Player> peyyLAIIsXDwcPGIhbnrhIWkQYniA;

					private int LFlsmNfogZjhcnEhYuVJbiLGJKxN;

					private IEnumerator<ElementAssignmentConflictInfo> GsUWVbtmSnWplRDYOnFGdaLpjKlm;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return FsaEoBjcCSfcPikKCBhNkAahjBiu;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return FsaEoBjcCSfcPikKCBhNkAahjBiu;
						}
					}

					[DebuggerHidden]
					public nUMSvZUYxFiemEupXrzRuJaOSfcu(int P_0)
					{
						rYjQMTohStWDgIkHwBBwlZKptUxb = P_0;
						jzSvhxoloJbosjGbLvCqEzXdTrDr = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = rYjQMTohStWDgIkHwBBwlZKptUxb;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								oYlsdyKuXSIwdmGlqpiEmPWxdjMx();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = rYjQMTohStWDgIkHwBBwlZKptUxb;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								rYjQMTohStWDgIkHwBBwlZKptUxb = -3;
								goto IL_00e2;
							}
							rYjQMTohStWDgIkHwBBwlZKptUxb = -1;
							if (lEesoSBwxqgDBTRWANaifCQXPuE < 0 || afskhdQFMYGkuodXqDCdeDRFAyGj == null)
							{
								return false;
							}
							peyyLAIIsXDwcPGIhbnrhIWkQYniA = (DcoEmXURmtgSjdkpxemfSOKYYKXc ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
							LFlsmNfogZjhcnEhYuVJbiLGJKxN = 0;
							goto IL_010c;
							IL_010c:
							if (LFlsmNfogZjhcnEhYuVJbiLGJKxN < peyyLAIIsXDwcPGIhbnrhIWkQYniA.Count)
							{
								GsUWVbtmSnWplRDYOnFGdaLpjKlm = peyyLAIIsXDwcPGIhbnrhIWkQYniA[LFlsmNfogZjhcnEhYuVJbiLGJKxN].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Custom, UfweiaKYvUMWvghTuFDcCfdiSTGab, RoaQlTvoNRWhRiVrlGYRKveYKlyj, afskhdQFMYGkuodXqDCdeDRFAyGj, ayzLGpfpzBhqfwuXOczpUfNLpWjE, pskTwlAEnCMEsYBjcEJEWddcivmq).GetEnumerator();
								rYjQMTohStWDgIkHwBBwlZKptUxb = -3;
								goto IL_00e2;
							}
							return false;
							IL_00e2:
							if (GsUWVbtmSnWplRDYOnFGdaLpjKlm.MoveNext())
							{
								ElementAssignmentConflictInfo current = GsUWVbtmSnWplRDYOnFGdaLpjKlm.Current;
								FsaEoBjcCSfcPikKCBhNkAahjBiu = current;
								rYjQMTohStWDgIkHwBBwlZKptUxb = 1;
								return true;
							}
							oYlsdyKuXSIwdmGlqpiEmPWxdjMx();
							GsUWVbtmSnWplRDYOnFGdaLpjKlm = null;
							LFlsmNfogZjhcnEhYuVJbiLGJKxN++;
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

					private void oYlsdyKuXSIwdmGlqpiEmPWxdjMx()
					{
						rYjQMTohStWDgIkHwBBwlZKptUxb = -1;
						if (GsUWVbtmSnWplRDYOnFGdaLpjKlm != null)
						{
							GsUWVbtmSnWplRDYOnFGdaLpjKlm.Dispose();
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
						nUMSvZUYxFiemEupXrzRuJaOSfcu nUMSvZUYxFiemEupXrzRuJaOSfcu2;
						if (rYjQMTohStWDgIkHwBBwlZKptUxb == -2 && jzSvhxoloJbosjGbLvCqEzXdTrDr == Environment.CurrentManagedThreadId)
						{
							rYjQMTohStWDgIkHwBBwlZKptUxb = 0;
							nUMSvZUYxFiemEupXrzRuJaOSfcu2 = this;
						}
						else
						{
							nUMSvZUYxFiemEupXrzRuJaOSfcu2 = new nUMSvZUYxFiemEupXrzRuJaOSfcu(0);
						}
						nUMSvZUYxFiemEupXrzRuJaOSfcu2.lEesoSBwxqgDBTRWANaifCQXPuE = boiCwpHCsKEJYEiauvXpydUNTPXq;
						nUMSvZUYxFiemEupXrzRuJaOSfcu2.UfweiaKYvUMWvghTuFDcCfdiSTGab = UKlbktescmedYkZQofYPhZieqYpJA;
						nUMSvZUYxFiemEupXrzRuJaOSfcu2.RoaQlTvoNRWhRiVrlGYRKveYKlyj = gWZjncAbzJnWUkmACpoZzEIfZJAO;
						nUMSvZUYxFiemEupXrzRuJaOSfcu2.afskhdQFMYGkuodXqDCdeDRFAyGj = YNZPzUMBPMgowLdFSIXjjDkvcQBK;
						nUMSvZUYxFiemEupXrzRuJaOSfcu2.ayzLGpfpzBhqfwuXOczpUfNLpWjE = tEsuaAqsRMwRUWkrZXveBqgUKtLp;
						nUMSvZUYxFiemEupXrzRuJaOSfcu2.pskTwlAEnCMEsYBjcEJEWddcivmq = OIXBbipacVoEZUOyKrEIOxdsGdgu;
						nUMSvZUYxFiemEupXrzRuJaOSfcu2.DcoEmXURmtgSjdkpxemfSOKYYKXc = vMcGqkKCNTBvyFbjBuGcsCQpUAZcA;
						return nUMSvZUYxFiemEupXrzRuJaOSfcu2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class QLwwRXbsqkKqqdJthBHCjwMmSjAz : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int nxOmxziInDeQKsprAGrQJnWoMxMI;

					private ElementAssignmentConflictInfo rpsHAdcuHbZBBOESOQNPPaxtYPii;

					private int WWMENLfgFiSHshCcXyePpsEuHFUgA;

					private ElementAssignmentConflictCheck aOPUZhsnLjWSJcUBQqfYjszFHNsA;

					public ElementAssignmentConflictCheck IpvIoJYItmqRUYcCtbxwEqQFhrep;

					private bool TCpzPMhAQKVZAEPRUnKqncGfSABE;

					public bool eGVBaYLwvNnyiMoCuhxABVfoeMmV;

					private bool ltQNwksHJWzzeEfCAoPMKrVNfXBc;

					public bool zdNDmAJpbERTLukMKEdPYcJnLVTl;

					private bool hVxWigUSgzcGYgchvDnzyljQixyAA;

					public bool rtRgMZBmQhYGfeyrWanQZKflJwQwA;

					private IList<Player> UIFzacJKfTjjXcADrHJQUPerCIeN;

					private int RgXdsIIVAlbccdJfQolExpMfzNAX;

					private IEnumerator<ElementAssignmentConflictInfo> MKYQGaWheadLNTTIbaeXABOjTRlnA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return rpsHAdcuHbZBBOESOQNPPaxtYPii;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return rpsHAdcuHbZBBOESOQNPPaxtYPii;
						}
					}

					[DebuggerHidden]
					public QLwwRXbsqkKqqdJthBHCjwMmSjAz(int P_0)
					{
						nxOmxziInDeQKsprAGrQJnWoMxMI = P_0;
						WWMENLfgFiSHshCcXyePpsEuHFUgA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = nxOmxziInDeQKsprAGrQJnWoMxMI;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								rVJclJGoRqpiNEscvhSaCOKwUWQnA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = nxOmxziInDeQKsprAGrQJnWoMxMI;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								nxOmxziInDeQKsprAGrQJnWoMxMI = -3;
								goto IL_00df;
							}
							nxOmxziInDeQKsprAGrQJnWoMxMI = -1;
							if (aOPUZhsnLjWSJcUBQqfYjszFHNsA.playerId < 0 || aOPUZhsnLjWSJcUBQqfYjszFHNsA.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							UIFzacJKfTjjXcADrHJQUPerCIeN = (TCpzPMhAQKVZAEPRUnKqncGfSABE ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
							RgXdsIIVAlbccdJfQolExpMfzNAX = 0;
							goto IL_0109;
							IL_0109:
							if (RgXdsIIVAlbccdJfQolExpMfzNAX < UIFzacJKfTjjXcADrHJQUPerCIeN.Count)
							{
								MKYQGaWheadLNTTIbaeXABOjTRlnA = UIFzacJKfTjjXcADrHJQUPerCIeN[RgXdsIIVAlbccdJfQolExpMfzNAX].controllers.conflictChecking.ElementAssignmentConflicts(aOPUZhsnLjWSJcUBQqfYjszFHNsA, ltQNwksHJWzzeEfCAoPMKrVNfXBc, hVxWigUSgzcGYgchvDnzyljQixyAA).GetEnumerator();
								nxOmxziInDeQKsprAGrQJnWoMxMI = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (MKYQGaWheadLNTTIbaeXABOjTRlnA.MoveNext())
							{
								ElementAssignmentConflictInfo current = MKYQGaWheadLNTTIbaeXABOjTRlnA.Current;
								rpsHAdcuHbZBBOESOQNPPaxtYPii = current;
								nxOmxziInDeQKsprAGrQJnWoMxMI = 1;
								return true;
							}
							rVJclJGoRqpiNEscvhSaCOKwUWQnA();
							MKYQGaWheadLNTTIbaeXABOjTRlnA = null;
							RgXdsIIVAlbccdJfQolExpMfzNAX++;
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

					private void rVJclJGoRqpiNEscvhSaCOKwUWQnA()
					{
						nxOmxziInDeQKsprAGrQJnWoMxMI = -1;
						if (MKYQGaWheadLNTTIbaeXABOjTRlnA != null)
						{
							MKYQGaWheadLNTTIbaeXABOjTRlnA.Dispose();
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
						QLwwRXbsqkKqqdJthBHCjwMmSjAz qLwwRXbsqkKqqdJthBHCjwMmSjAz;
						if (nxOmxziInDeQKsprAGrQJnWoMxMI == -2 && WWMENLfgFiSHshCcXyePpsEuHFUgA == Environment.CurrentManagedThreadId)
						{
							nxOmxziInDeQKsprAGrQJnWoMxMI = 0;
							qLwwRXbsqkKqqdJthBHCjwMmSjAz = this;
						}
						else
						{
							qLwwRXbsqkKqqdJthBHCjwMmSjAz = new QLwwRXbsqkKqqdJthBHCjwMmSjAz(0);
						}
						qLwwRXbsqkKqqdJthBHCjwMmSjAz.aOPUZhsnLjWSJcUBQqfYjszFHNsA = IpvIoJYItmqRUYcCtbxwEqQFhrep;
						qLwwRXbsqkKqqdJthBHCjwMmSjAz.ltQNwksHJWzzeEfCAoPMKrVNfXBc = zdNDmAJpbERTLukMKEdPYcJnLVTl;
						qLwwRXbsqkKqqdJthBHCjwMmSjAz.hVxWigUSgzcGYgchvDnzyljQixyAA = rtRgMZBmQhYGfeyrWanQZKflJwQwA;
						qLwwRXbsqkKqqdJthBHCjwMmSjAz.TCpzPMhAQKVZAEPRUnKqncGfSABE = eGVBaYLwvNnyiMoCuhxABVfoeMmV;
						return qLwwRXbsqkKqqdJthBHCjwMmSjAz;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class eAgoPJJhZwVbeQIyCFEOkNEkhhfb : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int JmgmUXHZHksYwrjgjVoMebJLHBrO;

					private ElementAssignmentConflictInfo lrXlTyhMsIbgSasAaiPSTjuLecNKA;

					private int oyaDPjDmUoLBRMCRCvpZTvtDmPUS;

					private int pNKHBVIIVUCyKhMNhUvhfpTNGEEi;

					public int JnjJfhwYLldYShCdSoGkPkJJVlwT;

					private ActionElementMap uWgRLgpVaUhcRCdSFloFqqfJCyrAA;

					public ActionElementMap SCnFMdWaWhCQmGdkhJvulFFkGwzb;

					private bool nsUNCYsSbaHdEdCgkcweiWmqjnoD;

					public bool BAcaxizjRmBKsrvSdCrMkaehYIDwA;

					private int XePUqrxAfQyzHBYcnBIhzVperbdm;

					public int TRjOzqjesLnolgqffiKXoryrpfgy;

					private JoystickMap vujHtdSTDDORKQaXBlDgjCKUhcNW;

					public JoystickMap UNnTduZpLFqzXGnOJbqqyNZUTSYX;

					private bool IwzMSHgAxOFLezTLVajgFlWwfeRx;

					public bool PBeidVKfeRsdqiWrBRqNtBjDoQxtA;

					private bool JtagRchTXATxCUALnpHRmvdodZBZ;

					public bool QRXVaynKzzBCkeIGeqzMNvtJMhaCA;

					private IList<Player> CEITgpSZwyEBjznAlhsoXcSYlXsR;

					private int CWmhTXLUTUaQvfngMGXOdbNQoebbb;

					private IEnumerator<ElementAssignmentConflictInfo> BvxzvSdfnExXSgYSiGpvbdMmwILg;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return lrXlTyhMsIbgSasAaiPSTjuLecNKA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return lrXlTyhMsIbgSasAaiPSTjuLecNKA;
						}
					}

					[DebuggerHidden]
					public eAgoPJJhZwVbeQIyCFEOkNEkhhfb(int P_0)
					{
						JmgmUXHZHksYwrjgjVoMebJLHBrO = P_0;
						oyaDPjDmUoLBRMCRCvpZTvtDmPUS = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int jmgmUXHZHksYwrjgjVoMebJLHBrO = JmgmUXHZHksYwrjgjVoMebJLHBrO;
						if (jmgmUXHZHksYwrjgjVoMebJLHBrO == -3 || jmgmUXHZHksYwrjgjVoMebJLHBrO == 1)
						{
							try
							{
							}
							finally
							{
								AhilnpUeAWYkEesFgLmrhQDzbiLj();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int jmgmUXHZHksYwrjgjVoMebJLHBrO = JmgmUXHZHksYwrjgjVoMebJLHBrO;
							if (jmgmUXHZHksYwrjgjVoMebJLHBrO != 0)
							{
								if (jmgmUXHZHksYwrjgjVoMebJLHBrO != 1)
								{
									return false;
								}
								JmgmUXHZHksYwrjgjVoMebJLHBrO = -3;
								goto IL_00e1;
							}
							JmgmUXHZHksYwrjgjVoMebJLHBrO = -1;
							if (pNKHBVIIVUCyKhMNhUvhfpTNGEEi < 0 || uWgRLgpVaUhcRCdSFloFqqfJCyrAA == null)
							{
								return false;
							}
							CEITgpSZwyEBjznAlhsoXcSYlXsR = (nsUNCYsSbaHdEdCgkcweiWmqjnoD ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
							CWmhTXLUTUaQvfngMGXOdbNQoebbb = 0;
							goto IL_010b;
							IL_010b:
							if (CWmhTXLUTUaQvfngMGXOdbNQoebbb < CEITgpSZwyEBjznAlhsoXcSYlXsR.Count)
							{
								BvxzvSdfnExXSgYSiGpvbdMmwILg = CEITgpSZwyEBjznAlhsoXcSYlXsR[CWmhTXLUTUaQvfngMGXOdbNQoebbb].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Joystick, XePUqrxAfQyzHBYcnBIhzVperbdm, vujHtdSTDDORKQaXBlDgjCKUhcNW, uWgRLgpVaUhcRCdSFloFqqfJCyrAA, IwzMSHgAxOFLezTLVajgFlWwfeRx, JtagRchTXATxCUALnpHRmvdodZBZ).GetEnumerator();
								JmgmUXHZHksYwrjgjVoMebJLHBrO = -3;
								goto IL_00e1;
							}
							return false;
							IL_00e1:
							if (BvxzvSdfnExXSgYSiGpvbdMmwILg.MoveNext())
							{
								ElementAssignmentConflictInfo current = BvxzvSdfnExXSgYSiGpvbdMmwILg.Current;
								lrXlTyhMsIbgSasAaiPSTjuLecNKA = current;
								JmgmUXHZHksYwrjgjVoMebJLHBrO = 1;
								return true;
							}
							AhilnpUeAWYkEesFgLmrhQDzbiLj();
							BvxzvSdfnExXSgYSiGpvbdMmwILg = null;
							CWmhTXLUTUaQvfngMGXOdbNQoebbb++;
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

					private void AhilnpUeAWYkEesFgLmrhQDzbiLj()
					{
						JmgmUXHZHksYwrjgjVoMebJLHBrO = -1;
						if (BvxzvSdfnExXSgYSiGpvbdMmwILg != null)
						{
							BvxzvSdfnExXSgYSiGpvbdMmwILg.Dispose();
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
						eAgoPJJhZwVbeQIyCFEOkNEkhhfb eAgoPJJhZwVbeQIyCFEOkNEkhhfb2;
						if (JmgmUXHZHksYwrjgjVoMebJLHBrO == -2 && oyaDPjDmUoLBRMCRCvpZTvtDmPUS == Environment.CurrentManagedThreadId)
						{
							JmgmUXHZHksYwrjgjVoMebJLHBrO = 0;
							eAgoPJJhZwVbeQIyCFEOkNEkhhfb2 = this;
						}
						else
						{
							eAgoPJJhZwVbeQIyCFEOkNEkhhfb2 = new eAgoPJJhZwVbeQIyCFEOkNEkhhfb(0);
						}
						eAgoPJJhZwVbeQIyCFEOkNEkhhfb2.pNKHBVIIVUCyKhMNhUvhfpTNGEEi = JnjJfhwYLldYShCdSoGkPkJJVlwT;
						eAgoPJJhZwVbeQIyCFEOkNEkhhfb2.XePUqrxAfQyzHBYcnBIhzVperbdm = TRjOzqjesLnolgqffiKXoryrpfgy;
						eAgoPJJhZwVbeQIyCFEOkNEkhhfb2.vujHtdSTDDORKQaXBlDgjCKUhcNW = UNnTduZpLFqzXGnOJbqqyNZUTSYX;
						eAgoPJJhZwVbeQIyCFEOkNEkhhfb2.uWgRLgpVaUhcRCdSFloFqqfJCyrAA = SCnFMdWaWhCQmGdkhJvulFFkGwzb;
						eAgoPJJhZwVbeQIyCFEOkNEkhhfb2.IwzMSHgAxOFLezTLVajgFlWwfeRx = PBeidVKfeRsdqiWrBRqNtBjDoQxtA;
						eAgoPJJhZwVbeQIyCFEOkNEkhhfb2.JtagRchTXATxCUALnpHRmvdodZBZ = QRXVaynKzzBCkeIGeqzMNvtJMhaCA;
						eAgoPJJhZwVbeQIyCFEOkNEkhhfb2.nsUNCYsSbaHdEdCgkcweiWmqjnoD = BAcaxizjRmBKsrvSdCrMkaehYIDwA;
						return eAgoPJJhZwVbeQIyCFEOkNEkhhfb2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class NLupNaMUhsyXFMDQXJtpqSHipifv : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int NVqXXQSlSgDPkDmODmjiAycJduQo;

					private ElementAssignmentConflictInfo DciBgxurRBOYMyQqFoIEIPuadRVEA;

					private int NtXWFBAUlPneHtyblarGdiYWdwHG;

					private ElementAssignmentConflictCheck zmAAVEuRUlZJJZRfNgJSCszXvqWK;

					public ElementAssignmentConflictCheck DilXKGaIgdTTVNFQgjQLkKQqYgl;

					private bool VpDACJiHYlbuDjnZmLDJQbUMWvgPA;

					public bool hcpvHXMMwBeYUCarDkKpfHiKjHkbc;

					private bool EwLmbqkOkLmwnxiIRfdwEmJFdRFZ;

					public bool ZpgdrXzRxgieSSniyenXBOQbawOFb;

					private bool MBWRBJkkqqyyHpCmVQDiEVTONbTH;

					public bool uaAUYNlWEnNluhwNZDlObgWEFmsQ;

					private IList<Player> xogjjAXvTVmxkJtJoxqbSEBpeJwC;

					private int cvPLyEgSyUrgvDRINIZXpoyPwEhI;

					private IEnumerator<ElementAssignmentConflictInfo> xZrBbmFlRIvMHJYKyWLdepBshyQZA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return DciBgxurRBOYMyQqFoIEIPuadRVEA;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return DciBgxurRBOYMyQqFoIEIPuadRVEA;
						}
					}

					[DebuggerHidden]
					public NLupNaMUhsyXFMDQXJtpqSHipifv(int P_0)
					{
						NVqXXQSlSgDPkDmODmjiAycJduQo = P_0;
						NtXWFBAUlPneHtyblarGdiYWdwHG = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int nVqXXQSlSgDPkDmODmjiAycJduQo = NVqXXQSlSgDPkDmODmjiAycJduQo;
						if (nVqXXQSlSgDPkDmODmjiAycJduQo == -3 || nVqXXQSlSgDPkDmODmjiAycJduQo == 1)
						{
							try
							{
							}
							finally
							{
								MWrDcSeVoatpbPinuRHTDEuGWGNWA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int nVqXXQSlSgDPkDmODmjiAycJduQo = NVqXXQSlSgDPkDmODmjiAycJduQo;
							if (nVqXXQSlSgDPkDmODmjiAycJduQo != 0)
							{
								if (nVqXXQSlSgDPkDmODmjiAycJduQo != 1)
								{
									return false;
								}
								NVqXXQSlSgDPkDmODmjiAycJduQo = -3;
								goto IL_00df;
							}
							NVqXXQSlSgDPkDmODmjiAycJduQo = -1;
							if (zmAAVEuRUlZJJZRfNgJSCszXvqWK.playerId < 0 || zmAAVEuRUlZJJZRfNgJSCszXvqWK.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							xogjjAXvTVmxkJtJoxqbSEBpeJwC = (VpDACJiHYlbuDjnZmLDJQbUMWvgPA ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
							cvPLyEgSyUrgvDRINIZXpoyPwEhI = 0;
							goto IL_0109;
							IL_0109:
							if (cvPLyEgSyUrgvDRINIZXpoyPwEhI < xogjjAXvTVmxkJtJoxqbSEBpeJwC.Count)
							{
								xZrBbmFlRIvMHJYKyWLdepBshyQZA = xogjjAXvTVmxkJtJoxqbSEBpeJwC[cvPLyEgSyUrgvDRINIZXpoyPwEhI].controllers.conflictChecking.ElementAssignmentConflicts(zmAAVEuRUlZJJZRfNgJSCszXvqWK, EwLmbqkOkLmwnxiIRfdwEmJFdRFZ, MBWRBJkkqqyyHpCmVQDiEVTONbTH).GetEnumerator();
								NVqXXQSlSgDPkDmODmjiAycJduQo = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (xZrBbmFlRIvMHJYKyWLdepBshyQZA.MoveNext())
							{
								ElementAssignmentConflictInfo current = xZrBbmFlRIvMHJYKyWLdepBshyQZA.Current;
								DciBgxurRBOYMyQqFoIEIPuadRVEA = current;
								NVqXXQSlSgDPkDmODmjiAycJduQo = 1;
								return true;
							}
							MWrDcSeVoatpbPinuRHTDEuGWGNWA();
							xZrBbmFlRIvMHJYKyWLdepBshyQZA = null;
							cvPLyEgSyUrgvDRINIZXpoyPwEhI++;
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

					private void MWrDcSeVoatpbPinuRHTDEuGWGNWA()
					{
						NVqXXQSlSgDPkDmODmjiAycJduQo = -1;
						if (xZrBbmFlRIvMHJYKyWLdepBshyQZA != null)
						{
							xZrBbmFlRIvMHJYKyWLdepBshyQZA.Dispose();
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
						NLupNaMUhsyXFMDQXJtpqSHipifv nLupNaMUhsyXFMDQXJtpqSHipifv;
						if (NVqXXQSlSgDPkDmODmjiAycJduQo == -2 && NtXWFBAUlPneHtyblarGdiYWdwHG == Environment.CurrentManagedThreadId)
						{
							NVqXXQSlSgDPkDmODmjiAycJduQo = 0;
							nLupNaMUhsyXFMDQXJtpqSHipifv = this;
						}
						else
						{
							nLupNaMUhsyXFMDQXJtpqSHipifv = new NLupNaMUhsyXFMDQXJtpqSHipifv(0);
						}
						nLupNaMUhsyXFMDQXJtpqSHipifv.zmAAVEuRUlZJJZRfNgJSCszXvqWK = DilXKGaIgdTTVNFQgjQLkKQqYgl;
						nLupNaMUhsyXFMDQXJtpqSHipifv.EwLmbqkOkLmwnxiIRfdwEmJFdRFZ = ZpgdrXzRxgieSSniyenXBOQbawOFb;
						nLupNaMUhsyXFMDQXJtpqSHipifv.MBWRBJkkqqyyHpCmVQDiEVTONbTH = uaAUYNlWEnNluhwNZDlObgWEFmsQ;
						nLupNaMUhsyXFMDQXJtpqSHipifv.VpDACJiHYlbuDjnZmLDJQbUMWvgPA = hcpvHXMMwBeYUCarDkKpfHiKjHkbc;
						return nLupNaMUhsyXFMDQXJtpqSHipifv;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class KDqGQPftXiLIEkqzWuNamXBIJHmEA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int zUwajlbhCrykIrvEBUpOkXMfErPd;

					private ElementAssignmentConflictInfo yNPgwcfjfSglKCnxBhInXLimprGP;

					private int KxoSDzCeXlLKkrDRVBsrNKbhJEPv;

					private int fAZhLNFJEeIQQOISULDplayURWGMA;

					public int HhzswiDvTSCZPnmiafmlKtHwKDEC;

					private ActionElementMap jrfodiVJsIpDCfsQsTYOkcxjfudG;

					public ActionElementMap uLTiGTFlmeekVYOBAgNkNAivlqyP;

					private bool WBERWmKdyraLIIKiTYWwjGVBGidv;

					public bool qtBAtAlbcvgngpBZhmkYTEfjpymb;

					private KeyboardMap eGBwpkFbGeFOgesdAQpWEptvlwXGA;

					public KeyboardMap EhwJuKHDflkdcqmUNKDiDoanWSje;

					private bool ZbLhcCiOREdRbGJwJkwicvwYhjDsb;

					public bool BRfCWfGubrNTJMGVsMxLLQUHrECd;

					private bool gNakSWVIxFdAMhuDAQihCmLXWvfGb;

					public bool RGAbMQNcIfpEAZmGrTlJIPMyjsKgA;

					private IList<Player> LvRulzvrADlNFrKzGRdUhcoXtxMq;

					private int fzTKJjKXWYaidliwyrAqPSqCjlHc;

					private IEnumerator<ElementAssignmentConflictInfo> OkAFLJHvIMKbQFTXZcbAXIVIRaQR;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return yNPgwcfjfSglKCnxBhInXLimprGP;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return yNPgwcfjfSglKCnxBhInXLimprGP;
						}
					}

					[DebuggerHidden]
					public KDqGQPftXiLIEkqzWuNamXBIJHmEA(int P_0)
					{
						zUwajlbhCrykIrvEBUpOkXMfErPd = P_0;
						KxoSDzCeXlLKkrDRVBsrNKbhJEPv = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = zUwajlbhCrykIrvEBUpOkXMfErPd;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								sCMARZQHgTZEditivusphcGqWVNg();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = zUwajlbhCrykIrvEBUpOkXMfErPd;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								zUwajlbhCrykIrvEBUpOkXMfErPd = -3;
								goto IL_00dc;
							}
							zUwajlbhCrykIrvEBUpOkXMfErPd = -1;
							if (fAZhLNFJEeIQQOISULDplayURWGMA < 0 || jrfodiVJsIpDCfsQsTYOkcxjfudG == null)
							{
								return false;
							}
							LvRulzvrADlNFrKzGRdUhcoXtxMq = (WBERWmKdyraLIIKiTYWwjGVBGidv ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
							fzTKJjKXWYaidliwyrAqPSqCjlHc = 0;
							goto IL_0106;
							IL_0106:
							if (fzTKJjKXWYaidliwyrAqPSqCjlHc < LvRulzvrADlNFrKzGRdUhcoXtxMq.Count)
							{
								OkAFLJHvIMKbQFTXZcbAXIVIRaQR = LvRulzvrADlNFrKzGRdUhcoXtxMq[fzTKJjKXWYaidliwyrAqPSqCjlHc].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Keyboard, 0, eGBwpkFbGeFOgesdAQpWEptvlwXGA, jrfodiVJsIpDCfsQsTYOkcxjfudG, ZbLhcCiOREdRbGJwJkwicvwYhjDsb, gNakSWVIxFdAMhuDAQihCmLXWvfGb).GetEnumerator();
								zUwajlbhCrykIrvEBUpOkXMfErPd = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (OkAFLJHvIMKbQFTXZcbAXIVIRaQR.MoveNext())
							{
								ElementAssignmentConflictInfo current = OkAFLJHvIMKbQFTXZcbAXIVIRaQR.Current;
								yNPgwcfjfSglKCnxBhInXLimprGP = current;
								zUwajlbhCrykIrvEBUpOkXMfErPd = 1;
								return true;
							}
							sCMARZQHgTZEditivusphcGqWVNg();
							OkAFLJHvIMKbQFTXZcbAXIVIRaQR = null;
							fzTKJjKXWYaidliwyrAqPSqCjlHc++;
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

					private void sCMARZQHgTZEditivusphcGqWVNg()
					{
						zUwajlbhCrykIrvEBUpOkXMfErPd = -1;
						if (OkAFLJHvIMKbQFTXZcbAXIVIRaQR != null)
						{
							OkAFLJHvIMKbQFTXZcbAXIVIRaQR.Dispose();
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
						KDqGQPftXiLIEkqzWuNamXBIJHmEA kDqGQPftXiLIEkqzWuNamXBIJHmEA;
						if (zUwajlbhCrykIrvEBUpOkXMfErPd == -2 && KxoSDzCeXlLKkrDRVBsrNKbhJEPv == Environment.CurrentManagedThreadId)
						{
							zUwajlbhCrykIrvEBUpOkXMfErPd = 0;
							kDqGQPftXiLIEkqzWuNamXBIJHmEA = this;
						}
						else
						{
							kDqGQPftXiLIEkqzWuNamXBIJHmEA = new KDqGQPftXiLIEkqzWuNamXBIJHmEA(0);
						}
						kDqGQPftXiLIEkqzWuNamXBIJHmEA.fAZhLNFJEeIQQOISULDplayURWGMA = HhzswiDvTSCZPnmiafmlKtHwKDEC;
						kDqGQPftXiLIEkqzWuNamXBIJHmEA.eGBwpkFbGeFOgesdAQpWEptvlwXGA = EhwJuKHDflkdcqmUNKDiDoanWSje;
						kDqGQPftXiLIEkqzWuNamXBIJHmEA.jrfodiVJsIpDCfsQsTYOkcxjfudG = uLTiGTFlmeekVYOBAgNkNAivlqyP;
						kDqGQPftXiLIEkqzWuNamXBIJHmEA.ZbLhcCiOREdRbGJwJkwicvwYhjDsb = BRfCWfGubrNTJMGVsMxLLQUHrECd;
						kDqGQPftXiLIEkqzWuNamXBIJHmEA.gNakSWVIxFdAMhuDAQihCmLXWvfGb = RGAbMQNcIfpEAZmGrTlJIPMyjsKgA;
						kDqGQPftXiLIEkqzWuNamXBIJHmEA.WBERWmKdyraLIIKiTYWwjGVBGidv = qtBAtAlbcvgngpBZhmkYTEfjpymb;
						return kDqGQPftXiLIEkqzWuNamXBIJHmEA;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class riPOTrEVxVoJcZNAGAADHytHamzBA : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int bSRswenZZrDMLJCzKTpjobbGrFPR;

					private ElementAssignmentConflictInfo dSdThaNBnYviTDuOxgQpgTpZSlhf;

					private int ZYCeIaJtlLMTGzAgFAjKgCswMkBcb;

					private ElementAssignmentConflictCheck SFXLeXRrUxyvMfFwNDOKxiLjhafBA;

					public ElementAssignmentConflictCheck wsObvXGaSmYfHrfvCfWqkUKuJDFi;

					private bool hJZHvBkKUlbhttkMyBoCBonoGHuL;

					public bool wVJRVfhWvIkxlxzNoYByyLvNexFj;

					private bool wlJBjuqwWemNcuQELJuHMABAPOED;

					public bool wQvNwPCcwHDKYUhzJcFOjiHfdAAf;

					private bool xjiVYVFNrJPqJLaPROczukluATRE;

					public bool KtsLuEdblPDdYdDjHIJZIDQFdHRIB;

					private IList<Player> OmIuHPfeumQlyphjImrOXbaAFrSeA;

					private int xOIDeXMnoqslzJeWtizHfpimHlVR;

					private IEnumerator<ElementAssignmentConflictInfo> RlqyiWlzRiSSVLYEdlJAArLVeCkr;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return dSdThaNBnYviTDuOxgQpgTpZSlhf;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return dSdThaNBnYviTDuOxgQpgTpZSlhf;
						}
					}

					[DebuggerHidden]
					public riPOTrEVxVoJcZNAGAADHytHamzBA(int P_0)
					{
						bSRswenZZrDMLJCzKTpjobbGrFPR = P_0;
						ZYCeIaJtlLMTGzAgFAjKgCswMkBcb = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int num = bSRswenZZrDMLJCzKTpjobbGrFPR;
						if (num == -3 || num == 1)
						{
							try
							{
							}
							finally
							{
								aPRgrVzgoUcZeswubdDJaGbcicrRA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int num = bSRswenZZrDMLJCzKTpjobbGrFPR;
							if (num != 0)
							{
								if (num != 1)
								{
									return false;
								}
								bSRswenZZrDMLJCzKTpjobbGrFPR = -3;
								goto IL_00df;
							}
							bSRswenZZrDMLJCzKTpjobbGrFPR = -1;
							if (SFXLeXRrUxyvMfFwNDOKxiLjhafBA.playerId < 0 || SFXLeXRrUxyvMfFwNDOKxiLjhafBA.elementAssignmentType != ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							OmIuHPfeumQlyphjImrOXbaAFrSeA = (hJZHvBkKUlbhttkMyBoCBonoGHuL ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
							xOIDeXMnoqslzJeWtizHfpimHlVR = 0;
							goto IL_0109;
							IL_0109:
							if (xOIDeXMnoqslzJeWtizHfpimHlVR < OmIuHPfeumQlyphjImrOXbaAFrSeA.Count)
							{
								RlqyiWlzRiSSVLYEdlJAArLVeCkr = OmIuHPfeumQlyphjImrOXbaAFrSeA[xOIDeXMnoqslzJeWtizHfpimHlVR].controllers.conflictChecking.ElementAssignmentConflicts(SFXLeXRrUxyvMfFwNDOKxiLjhafBA, wlJBjuqwWemNcuQELJuHMABAPOED, xjiVYVFNrJPqJLaPROczukluATRE).GetEnumerator();
								bSRswenZZrDMLJCzKTpjobbGrFPR = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (RlqyiWlzRiSSVLYEdlJAArLVeCkr.MoveNext())
							{
								ElementAssignmentConflictInfo current = RlqyiWlzRiSSVLYEdlJAArLVeCkr.Current;
								dSdThaNBnYviTDuOxgQpgTpZSlhf = current;
								bSRswenZZrDMLJCzKTpjobbGrFPR = 1;
								return true;
							}
							aPRgrVzgoUcZeswubdDJaGbcicrRA();
							RlqyiWlzRiSSVLYEdlJAArLVeCkr = null;
							xOIDeXMnoqslzJeWtizHfpimHlVR++;
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

					private void aPRgrVzgoUcZeswubdDJaGbcicrRA()
					{
						bSRswenZZrDMLJCzKTpjobbGrFPR = -1;
						if (RlqyiWlzRiSSVLYEdlJAArLVeCkr != null)
						{
							RlqyiWlzRiSSVLYEdlJAArLVeCkr.Dispose();
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
						riPOTrEVxVoJcZNAGAADHytHamzBA riPOTrEVxVoJcZNAGAADHytHamzBA2;
						if (bSRswenZZrDMLJCzKTpjobbGrFPR == -2 && ZYCeIaJtlLMTGzAgFAjKgCswMkBcb == Environment.CurrentManagedThreadId)
						{
							bSRswenZZrDMLJCzKTpjobbGrFPR = 0;
							riPOTrEVxVoJcZNAGAADHytHamzBA2 = this;
						}
						else
						{
							riPOTrEVxVoJcZNAGAADHytHamzBA2 = new riPOTrEVxVoJcZNAGAADHytHamzBA(0);
						}
						riPOTrEVxVoJcZNAGAADHytHamzBA2.SFXLeXRrUxyvMfFwNDOKxiLjhafBA = wsObvXGaSmYfHrfvCfWqkUKuJDFi;
						riPOTrEVxVoJcZNAGAADHytHamzBA2.wlJBjuqwWemNcuQELJuHMABAPOED = wQvNwPCcwHDKYUhzJcFOjiHfdAAf;
						riPOTrEVxVoJcZNAGAADHytHamzBA2.xjiVYVFNrJPqJLaPROczukluATRE = KtsLuEdblPDdYdDjHIJZIDQFdHRIB;
						riPOTrEVxVoJcZNAGAADHytHamzBA2.hJZHvBkKUlbhttkMyBoCBonoGHuL = wVJRVfhWvIkxlxzNoYByyLvNexFj;
						return riPOTrEVxVoJcZNAGAADHytHamzBA2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class yDaezijmiabyNWqFJjnqGqgcKIIB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int RtlABgmrmuMXQvrntFxNSYRTTZLS;

					private ElementAssignmentConflictInfo oEurHlMlPoueXTnwRFeiGLWgTWSj;

					private int otzgnmdaYpxvnFJkRqBnhcpyMhEsA;

					private int QrlhqpyEgVpzAzewiPEVYPQLdOueA;

					public int cEnqjecNdMiUZEhVyVjCglNLKErS;

					private ActionElementMap RxYpBjpjJSFMfgrIwEwyJkfrrYQqA;

					public ActionElementMap DEghIaKPuuhknGgNuhtajjejGyFOA;

					private bool fPbDaDbpoiRUkCdnKPGlXuLizIFaA;

					public bool vbEqCdyaaloNDjHoeCRkgcooHczW;

					private MouseMap ssgqJBjpWfHmKLRayvqWIzvnLBVC;

					public MouseMap LkKlPxScfldraMkWRXBvVcfEvzZj;

					private bool eASOzrWiOgMsVhbdXZtsVzkfNIZq;

					public bool exWCjrBtxAEDQKmNwcuYHBIEqdIm;

					private bool rtPFwmzjBLwBbHMnSjlybvdfAhkXA;

					public bool UcfTyMsFGNaFbJLAYtIlZXXshQt;

					private IList<Player> erqOoATqqMZTCHlrUSqlrClHWUdQ;

					private int CshhOnKEApTGjYKGQolpldhqbOocA;

					private IEnumerator<ElementAssignmentConflictInfo> VIZtMrActiTysVRBQtlzMGREfHpCA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return oEurHlMlPoueXTnwRFeiGLWgTWSj;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return oEurHlMlPoueXTnwRFeiGLWgTWSj;
						}
					}

					[DebuggerHidden]
					public yDaezijmiabyNWqFJjnqGqgcKIIB(int P_0)
					{
						RtlABgmrmuMXQvrntFxNSYRTTZLS = P_0;
						otzgnmdaYpxvnFJkRqBnhcpyMhEsA = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int rtlABgmrmuMXQvrntFxNSYRTTZLS = RtlABgmrmuMXQvrntFxNSYRTTZLS;
						if (rtlABgmrmuMXQvrntFxNSYRTTZLS == -3 || rtlABgmrmuMXQvrntFxNSYRTTZLS == 1)
						{
							try
							{
							}
							finally
							{
								FzeOeQhNNhqqLwNvKCphKlvdKTlh();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int rtlABgmrmuMXQvrntFxNSYRTTZLS = RtlABgmrmuMXQvrntFxNSYRTTZLS;
							if (rtlABgmrmuMXQvrntFxNSYRTTZLS != 0)
							{
								if (rtlABgmrmuMXQvrntFxNSYRTTZLS != 1)
								{
									return false;
								}
								RtlABgmrmuMXQvrntFxNSYRTTZLS = -3;
								goto IL_00dc;
							}
							RtlABgmrmuMXQvrntFxNSYRTTZLS = -1;
							if (QrlhqpyEgVpzAzewiPEVYPQLdOueA < 0 || RxYpBjpjJSFMfgrIwEwyJkfrrYQqA == null)
							{
								return false;
							}
							erqOoATqqMZTCHlrUSqlrClHWUdQ = (fPbDaDbpoiRUkCdnKPGlXuLizIFaA ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
							CshhOnKEApTGjYKGQolpldhqbOocA = 0;
							goto IL_0106;
							IL_0106:
							if (CshhOnKEApTGjYKGQolpldhqbOocA < erqOoATqqMZTCHlrUSqlrClHWUdQ.Count)
							{
								VIZtMrActiTysVRBQtlzMGREfHpCA = erqOoATqqMZTCHlrUSqlrClHWUdQ[CshhOnKEApTGjYKGQolpldhqbOocA].controllers.conflictChecking.ElementAssignmentConflicts(ControllerType.Mouse, 0, ssgqJBjpWfHmKLRayvqWIzvnLBVC, RxYpBjpjJSFMfgrIwEwyJkfrrYQqA, eASOzrWiOgMsVhbdXZtsVzkfNIZq, rtPFwmzjBLwBbHMnSjlybvdfAhkXA).GetEnumerator();
								RtlABgmrmuMXQvrntFxNSYRTTZLS = -3;
								goto IL_00dc;
							}
							return false;
							IL_00dc:
							if (VIZtMrActiTysVRBQtlzMGREfHpCA.MoveNext())
							{
								ElementAssignmentConflictInfo current = VIZtMrActiTysVRBQtlzMGREfHpCA.Current;
								oEurHlMlPoueXTnwRFeiGLWgTWSj = current;
								RtlABgmrmuMXQvrntFxNSYRTTZLS = 1;
								return true;
							}
							FzeOeQhNNhqqLwNvKCphKlvdKTlh();
							VIZtMrActiTysVRBQtlzMGREfHpCA = null;
							CshhOnKEApTGjYKGQolpldhqbOocA++;
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

					private void FzeOeQhNNhqqLwNvKCphKlvdKTlh()
					{
						RtlABgmrmuMXQvrntFxNSYRTTZLS = -1;
						if (VIZtMrActiTysVRBQtlzMGREfHpCA != null)
						{
							VIZtMrActiTysVRBQtlzMGREfHpCA.Dispose();
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
						yDaezijmiabyNWqFJjnqGqgcKIIB yDaezijmiabyNWqFJjnqGqgcKIIB2;
						if (RtlABgmrmuMXQvrntFxNSYRTTZLS == -2 && otzgnmdaYpxvnFJkRqBnhcpyMhEsA == Environment.CurrentManagedThreadId)
						{
							RtlABgmrmuMXQvrntFxNSYRTTZLS = 0;
							yDaezijmiabyNWqFJjnqGqgcKIIB2 = this;
						}
						else
						{
							yDaezijmiabyNWqFJjnqGqgcKIIB2 = new yDaezijmiabyNWqFJjnqGqgcKIIB(0);
						}
						yDaezijmiabyNWqFJjnqGqgcKIIB2.QrlhqpyEgVpzAzewiPEVYPQLdOueA = cEnqjecNdMiUZEhVyVjCglNLKErS;
						yDaezijmiabyNWqFJjnqGqgcKIIB2.ssgqJBjpWfHmKLRayvqWIzvnLBVC = LkKlPxScfldraMkWRXBvVcfEvzZj;
						yDaezijmiabyNWqFJjnqGqgcKIIB2.RxYpBjpjJSFMfgrIwEwyJkfrrYQqA = DEghIaKPuuhknGgNuhtajjejGyFOA;
						yDaezijmiabyNWqFJjnqGqgcKIIB2.eASOzrWiOgMsVhbdXZtsVzkfNIZq = exWCjrBtxAEDQKmNwcuYHBIEqdIm;
						yDaezijmiabyNWqFJjnqGqgcKIIB2.rtPFwmzjBLwBbHMnSjlybvdfAhkXA = UcfTyMsFGNaFbJLAYtIlZXXshQt;
						yDaezijmiabyNWqFJjnqGqgcKIIB2.fPbDaDbpoiRUkCdnKPGlXuLizIFaA = vbEqCdyaaloNDjHoeCRkgcooHczW;
						return yDaezijmiabyNWqFJjnqGqgcKIIB2;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private sealed class PkffMuBHCERgzjFkVYXzVDjVIZrM : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
				{
					private int ZGNRmXzKNkwbmpWgwQJvglwxWeLw;

					private ElementAssignmentConflictInfo PQSWYGRtJRfVPFkcIBbahgLKAKUR;

					private int LZrpfRhzXsqeFpEoXRvbnnzcCnvn;

					private ElementAssignmentConflictCheck iJtBNmKkkmerBMptCooTFhRHYToz;

					public ElementAssignmentConflictCheck lDUleRPoQJTdUWRQBKqclzslAkQB;

					private bool bvJpAgwQOnFDXrOrIdDvgPgnpxlv;

					public bool TjCOJxiDgSWFvcvyNGlqFEeVVMOX;

					private bool biUHfeyAIhBvKDoiLczLoiPrPjiWA;

					public bool jIrMkUDrpNQMZbzckinMFJctclADA;

					private bool BgZrdtLClsEDzAvZNNgiVojarBvDA;

					public bool TpowfsmOUocPqNcrSVIbtvAgCBFR;

					private IList<Player> WRqdcBguTEHTJSTKlONrWQfBJEAb;

					private int fgPKRDwvzMRBeOLLTIYyGpRBznZgA;

					private IEnumerator<ElementAssignmentConflictInfo> OCcYxjckHmkEOkEorssBMPwHbAuJA;

					ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
					{
						[DebuggerHidden]
						get
						{
							return PQSWYGRtJRfVPFkcIBbahgLKAKUR;
						}
					}

					object IEnumerator.Current
					{
						[DebuggerHidden]
						get
						{
							return PQSWYGRtJRfVPFkcIBbahgLKAKUR;
						}
					}

					[DebuggerHidden]
					public PkffMuBHCERgzjFkVYXzVDjVIZrM(int P_0)
					{
						ZGNRmXzKNkwbmpWgwQJvglwxWeLw = P_0;
						LZrpfRhzXsqeFpEoXRvbnnzcCnvn = Environment.CurrentManagedThreadId;
					}

					[DebuggerHidden]
					void IDisposable.Dispose()
					{
						int zGNRmXzKNkwbmpWgwQJvglwxWeLw = ZGNRmXzKNkwbmpWgwQJvglwxWeLw;
						if (zGNRmXzKNkwbmpWgwQJvglwxWeLw == -3 || zGNRmXzKNkwbmpWgwQJvglwxWeLw == 1)
						{
							try
							{
							}
							finally
							{
								MIBAaODKCCCvlhTYsEAOUglZivdJA();
							}
						}
					}

					private bool MoveNext()
					{
						try
						{
							int zGNRmXzKNkwbmpWgwQJvglwxWeLw = ZGNRmXzKNkwbmpWgwQJvglwxWeLw;
							if (zGNRmXzKNkwbmpWgwQJvglwxWeLw != 0)
							{
								if (zGNRmXzKNkwbmpWgwQJvglwxWeLw != 1)
								{
									return false;
								}
								ZGNRmXzKNkwbmpWgwQJvglwxWeLw = -3;
								goto IL_00df;
							}
							ZGNRmXzKNkwbmpWgwQJvglwxWeLw = -1;
							if (iJtBNmKkkmerBMptCooTFhRHYToz.playerId < 0 || iJtBNmKkkmerBMptCooTFhRHYToz.elementAssignmentType == ElementAssignmentType.KeyboardKey)
							{
								return false;
							}
							WRqdcBguTEHTJSTKlONrWQfBJEAb = (bvJpAgwQOnFDXrOrIdDvgPgnpxlv ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
							fgPKRDwvzMRBeOLLTIYyGpRBznZgA = 0;
							goto IL_0109;
							IL_0109:
							if (fgPKRDwvzMRBeOLLTIYyGpRBznZgA < WRqdcBguTEHTJSTKlONrWQfBJEAb.Count)
							{
								OCcYxjckHmkEOkEorssBMPwHbAuJA = WRqdcBguTEHTJSTKlONrWQfBJEAb[fgPKRDwvzMRBeOLLTIYyGpRBznZgA].controllers.conflictChecking.ElementAssignmentConflicts(iJtBNmKkkmerBMptCooTFhRHYToz, biUHfeyAIhBvKDoiLczLoiPrPjiWA, BgZrdtLClsEDzAvZNNgiVojarBvDA).GetEnumerator();
								ZGNRmXzKNkwbmpWgwQJvglwxWeLw = -3;
								goto IL_00df;
							}
							return false;
							IL_00df:
							if (OCcYxjckHmkEOkEorssBMPwHbAuJA.MoveNext())
							{
								ElementAssignmentConflictInfo current = OCcYxjckHmkEOkEorssBMPwHbAuJA.Current;
								PQSWYGRtJRfVPFkcIBbahgLKAKUR = current;
								ZGNRmXzKNkwbmpWgwQJvglwxWeLw = 1;
								return true;
							}
							MIBAaODKCCCvlhTYsEAOUglZivdJA();
							OCcYxjckHmkEOkEorssBMPwHbAuJA = null;
							fgPKRDwvzMRBeOLLTIYyGpRBznZgA++;
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

					private void MIBAaODKCCCvlhTYsEAOUglZivdJA()
					{
						ZGNRmXzKNkwbmpWgwQJvglwxWeLw = -1;
						if (OCcYxjckHmkEOkEorssBMPwHbAuJA != null)
						{
							OCcYxjckHmkEOkEorssBMPwHbAuJA.Dispose();
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
						PkffMuBHCERgzjFkVYXzVDjVIZrM pkffMuBHCERgzjFkVYXzVDjVIZrM;
						if (ZGNRmXzKNkwbmpWgwQJvglwxWeLw == -2 && LZrpfRhzXsqeFpEoXRvbnnzcCnvn == Environment.CurrentManagedThreadId)
						{
							ZGNRmXzKNkwbmpWgwQJvglwxWeLw = 0;
							pkffMuBHCERgzjFkVYXzVDjVIZrM = this;
						}
						else
						{
							pkffMuBHCERgzjFkVYXzVDjVIZrM = new PkffMuBHCERgzjFkVYXzVDjVIZrM(0);
						}
						pkffMuBHCERgzjFkVYXzVDjVIZrM.iJtBNmKkkmerBMptCooTFhRHYToz = lDUleRPoQJTdUWRQBKqclzslAkQB;
						pkffMuBHCERgzjFkVYXzVDjVIZrM.biUHfeyAIhBvKDoiLczLoiPrPjiWA = jIrMkUDrpNQMZbzckinMFJctclADA;
						pkffMuBHCERgzjFkVYXzVDjVIZrM.BgZrdtLClsEDzAvZNNgiVojarBvDA = TpowfsmOUocPqNcrSVIbtvAgCBFR;
						pkffMuBHCERgzjFkVYXzVDjVIZrM.bvJpAgwQOnFDXrOrIdDvgPgnpxlv = TjCOJxiDgSWFvcvyNGlqFEeVVMOX;
						return pkffMuBHCERgzjFkVYXzVDjVIZrM;
					}

					[DebuggerHidden]
					IEnumerator IEnumerable.GetEnumerator()
					{
						return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
					}
				}

				private static ConflictCheckingHelper BReUZPFvirSPvTlIYhsPYKQTltsA;

				internal static ConflictCheckingHelper JHGVCWZrLClFwCxiTxApURmdrpdD => BReUZPFvirSPvTlIYhsPYKQTltsA ?? (BReUZPFvirSPvTlIYhsPYKQTltsA = new ConflictCheckingHelper());

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
					IList<Player> list = (includeSystemPlayer ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
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
						ControllerType.Joystick => QIhDbItwznuhnmeJSPOiGyZBNBFX(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => KRkviESLBrCbtBKUagXWHzBPvFeuA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => XFSjITjHXgfeJdCUemMYOIOkiQJsB(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => rhNvVVbqenAGsIsOnqoaVMIZfOdWA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return djjzDFjhyfqjJOschGwlDuYIObVB(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return STOmJNgOOuecuGVaxSzkRNatSEBo(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return ZfpqCGOEXaFxlaNBCGJYCsdfUDsCb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return LwvyGmFBNchBOWvtJZglVGeoFsOj(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private bool QIhDbItwznuhnmeJSPOiGyZBNBFX(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool djjzDFjhyfqjJOschGwlDuYIObVB(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool KRkviESLBrCbtBKUagXWHzBPvFeuA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool STOmJNgOOuecuGVaxSzkRNatSEBo(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool XFSjITjHXgfeJdCUemMYOIOkiQJsB(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return false;
					}
					IList<Player> list = (P_5 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4))
						{
							return true;
						}
					}
					return false;
				}

				private bool ZfpqCGOEXaFxlaNBCGJYCsdfUDsCb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(P_0, P_1, P_2))
						{
							return true;
						}
					}
					return false;
				}

				private bool rhNvVVbqenAGsIsOnqoaVMIZfOdWA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return false;
					}
					IList<Player> list = (P_6 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i].controllers.conflictChecking.DoesElementAssignmentConflict(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5))
						{
							return true;
						}
					}
					return false;
				}

				private bool LwvyGmFBNchBOWvtJZglVGeoFsOj(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return false;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
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
						ControllerType.Joystick => vaxBlffTGgFuMhHRiuipNhuPKFegb(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => JISOjswebJDbpaFqZMGlaxgJinUnA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => vUtmZBagozddCdvKaqXNokcNYDqG(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => KBEeSGwzjUnQGHSBAcQMmdrhPAFA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return gJJsrpuVZfJeJPchcfvYAFFAMsUGb(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return IFAcdMHZbicPokvVQGUBGhxEawvKA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return XCTMvcTpnlwAKIVHyHwUNXMbdkKu(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return JLuGBwAlxsdKuDEwCQcYIjdimUbkC(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				[IteratorStateMachine(typeof(eAgoPJJhZwVbeQIyCFEOkNEkhhfb))]
				private IEnumerable<ElementAssignmentConflictInfo> vaxBlffTGgFuMhHRiuipNhuPKFegb(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new eAgoPJJhZwVbeQIyCFEOkNEkhhfb(-2)
					{
						JnjJfhwYLldYShCdSoGkPkJJVlwT = P_0,
						TRjOzqjesLnolgqffiKXoryrpfgy = P_1,
						UNnTduZpLFqzXGnOJbqqyNZUTSYX = P_2,
						SCnFMdWaWhCQmGdkhJvulFFkGwzb = P_3,
						PBeidVKfeRsdqiWrBRqNtBjDoQxtA = P_4,
						QRXVaynKzzBCkeIGeqzMNvtJMhaCA = P_5,
						BAcaxizjRmBKsrvSdCrMkaehYIDwA = P_6
					};
				}

				[IteratorStateMachine(typeof(NLupNaMUhsyXFMDQXJtpqSHipifv))]
				private IEnumerable<ElementAssignmentConflictInfo> gJJsrpuVZfJeJPchcfvYAFFAMsUGb(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new NLupNaMUhsyXFMDQXJtpqSHipifv(-2)
					{
						DilXKGaIgdTTVNFQgjQLkKQqYgl = P_0,
						ZpgdrXzRxgieSSniyenXBOQbawOFb = P_1,
						uaAUYNlWEnNluhwNZDlObgWEFmsQ = P_2,
						hcpvHXMMwBeYUCarDkKpfHiKjHkbc = P_3
					};
				}

				[IteratorStateMachine(typeof(KDqGQPftXiLIEkqzWuNamXBIJHmEA))]
				private IEnumerable<ElementAssignmentConflictInfo> JISOjswebJDbpaFqZMGlaxgJinUnA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new KDqGQPftXiLIEkqzWuNamXBIJHmEA(-2)
					{
						HhzswiDvTSCZPnmiafmlKtHwKDEC = P_0,
						EhwJuKHDflkdcqmUNKDiDoanWSje = P_1,
						uLTiGTFlmeekVYOBAgNkNAivlqyP = P_2,
						BRfCWfGubrNTJMGVsMxLLQUHrECd = P_3,
						RGAbMQNcIfpEAZmGrTlJIPMyjsKgA = P_4,
						qtBAtAlbcvgngpBZhmkYTEfjpymb = P_5
					};
				}

				[IteratorStateMachine(typeof(riPOTrEVxVoJcZNAGAADHytHamzBA))]
				private IEnumerable<ElementAssignmentConflictInfo> IFAcdMHZbicPokvVQGUBGhxEawvKA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new riPOTrEVxVoJcZNAGAADHytHamzBA(-2)
					{
						wsObvXGaSmYfHrfvCfWqkUKuJDFi = P_0,
						wQvNwPCcwHDKYUhzJcFOjiHfdAAf = P_1,
						KtsLuEdblPDdYdDjHIJZIDQFdHRIB = P_2,
						wVJRVfhWvIkxlxzNoYByyLvNexFj = P_3
					};
				}

				[IteratorStateMachine(typeof(yDaezijmiabyNWqFJjnqGqgcKIIB))]
				private IEnumerable<ElementAssignmentConflictInfo> vUtmZBagozddCdvKaqXNokcNYDqG(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					return new yDaezijmiabyNWqFJjnqGqgcKIIB(-2)
					{
						cEnqjecNdMiUZEhVyVjCglNLKErS = P_0,
						LkKlPxScfldraMkWRXBvVcfEvzZj = P_1,
						DEghIaKPuuhknGgNuhtajjejGyFOA = P_2,
						exWCjrBtxAEDQKmNwcuYHBIEqdIm = P_3,
						UcfTyMsFGNaFbJLAYtIlZXXshQt = P_4,
						vbEqCdyaaloNDjHoeCRkgcooHczW = P_5
					};
				}

				[IteratorStateMachine(typeof(PkffMuBHCERgzjFkVYXzVDjVIZrM))]
				private IEnumerable<ElementAssignmentConflictInfo> XCTMvcTpnlwAKIVHyHwUNXMbdkKu(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new PkffMuBHCERgzjFkVYXzVDjVIZrM(-2)
					{
						lDUleRPoQJTdUWRQBKqclzslAkQB = P_0,
						jIrMkUDrpNQMZbzckinMFJctclADA = P_1,
						TpowfsmOUocPqNcrSVIbtvAgCBFR = P_2,
						TjCOJxiDgSWFvcvyNGlqFEeVVMOX = P_3
					};
				}

				[IteratorStateMachine(typeof(nUMSvZUYxFiemEupXrzRuJaOSfcu))]
				private IEnumerable<ElementAssignmentConflictInfo> KBEeSGwzjUnQGHSBAcQMmdrhPAFA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					return new nUMSvZUYxFiemEupXrzRuJaOSfcu(-2)
					{
						boiCwpHCsKEJYEiauvXpydUNTPXq = P_0,
						UKlbktescmedYkZQofYPhZieqYpJA = P_1,
						gWZjncAbzJnWUkmACpoZzEIfZJAO = P_2,
						YNZPzUMBPMgowLdFSIXjjDkvcQBK = P_3,
						tEsuaAqsRMwRUWkrZXveBqgUKtLp = P_4,
						OIXBbipacVoEZUOyKrEIOxdsGdgu = P_5,
						vMcGqkKCNTBvyFbjBuGcsCQpUAZcA = P_6
					};
				}

				[IteratorStateMachine(typeof(QLwwRXbsqkKqqdJthBHCjwMmSjAz))]
				private IEnumerable<ElementAssignmentConflictInfo> JLuGBwAlxsdKuDEwCQcYIjdimUbkC(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					return new QLwwRXbsqkKqqdJthBHCjwMmSjAz(-2)
					{
						IpvIoJYItmqRUYcCtbxwEqQFhrep = P_0,
						zdNDmAJpbERTLukMKEdPYcJnLVTl = P_1,
						rtRgMZBmQhYGfeyrWanQZKflJwQwA = P_2,
						eGVBaYLwvNnyiMoCuhxABVfoeMmV = P_3
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
						ControllerType.Joystick => urJlrmnEuEghixfgGwyMaBeKAlYU(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => qlOvIkrOKFCNrXMIZTUbCmUZfFpHA(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => IolcekbCWfhEdMRhamObJjsjQHunb(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => VoIavsiQTRxaQvRHDAzYEfYyrVMMA(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return TanbszFlvPqychrsRkuDpSWJHxcgA(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return jiIRdkIEfQHgVNyHOFVwXNVrucqe(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return iqoBvASdVwkANjHbhZpcwSTfMwwE(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return eipwdlyKfnEHuwUAJUMKCTHuvOET(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int urJlrmnEuEghixfgGwyMaBeKAlYU(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int TanbszFlvPqychrsRkuDpSWJHxcgA(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int qlOvIkrOKFCNrXMIZTUbCmUZfFpHA(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int jiIRdkIEfQHgVNyHOFVwXNVrucqe(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int IolcekbCWfhEdMRhamObJjsjQHunb(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int iqoBvASdVwkANjHbhZpcwSTfMwwE(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int VoIavsiQTRxaQvRHDAzYEfYyrVMMA(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int eipwdlyKfnEHuwUAJUMKCTHuvOET(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
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
						ControllerType.Joystick => fUilphTYiwRbnmjHDHyRgJCLlTdU(playerId, controllerId, controllerMap as JoystickMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Keyboard => YanSDebdvklnLYJlbDmShfsWbCpi(playerId, controllerMap as KeyboardMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Mouse => wTbjFZihtzpCLgzVWNMPpaROikRQ(playerId, controllerMap as MouseMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
						ControllerType.Custom => MeMRhQiXivkLgFcXkqMJSsrjheqt(playerId, controllerId, controllerMap as CustomControllerMap, elementMap, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer), 
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
						return JfRxrhIeWVyvgEHRnqgfoqaPmreO(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Keyboard)
					{
						return mmDELaduNusdElFIjdmJBGUOQfmib(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Mouse)
					{
						return EtotyCNHEplFWkSDSgjvDjPvMWLS(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					if (conflictCheck.controllerType == ControllerType.Custom)
					{
						return ZCCYgeooLWyWxvyfmgeKTZsQKKwn(conflictCheck, skipDisabledMaps, forceCheckAllCategories, includeSystemPlayer);
					}
					throw new NotImplementedException();
				}

				private int fUilphTYiwRbnmjHDHyRgJCLlTdU(int P_0, int P_1, JoystickMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Joystick, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int JfRxrhIeWVyvgEHRnqgfoqaPmreO(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int YanSDebdvklnLYJlbDmShfsWbCpi(int P_0, KeyboardMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Keyboard, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int mmDELaduNusdElFIjdmJBGUOQfmib(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int wTbjFZihtzpCLgzVWNMPpaROikRQ(int P_0, MouseMap P_1, ActionElementMap P_2, bool P_3 = false, bool P_4 = false, bool P_5 = true)
				{
					if (P_0 < 0 || P_2 == null)
					{
						return 0;
					}
					IList<Player> list = (P_5 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Mouse, 0, P_1, P_2, P_3, P_4);
					}
					return num;
				}

				private int EtotyCNHEplFWkSDSgjvDjPvMWLS(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}

				private int MeMRhQiXivkLgFcXkqMJSsrjheqt(int P_0, int P_1, CustomControllerMap P_2, ActionElementMap P_3, bool P_4 = false, bool P_5 = false, bool P_6 = true)
				{
					if (P_0 < 0 || P_3 == null)
					{
						return 0;
					}
					IList<Player> list = (P_6 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(ControllerType.Custom, P_1, P_2, P_3, P_4, P_5);
					}
					return num;
				}

				private int ZCCYgeooLWyWxvyfmgeKTZsQKKwn(ElementAssignmentConflictCheck P_0, bool P_1 = false, bool P_2 = false, bool P_3 = true)
				{
					if (P_0.playerId < 0 || P_0.elementAssignmentType == ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					IList<Player> list = (P_3 ? NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR : NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG);
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						num += list[i].controllers.conflictChecking.DisableElementAssignmentConflicts(P_0, P_1, P_2);
					}
					return num;
				}
			}

			private static ControllerHelper gDqAtqfHlRwADrybQLKutItDvmPP;

			public readonly PollingHelper polling = PollingHelper.xNTWlPDOOVHDHSQojcgyELwpJuBGA;

			public readonly ConflictCheckingHelper conflictChecking = ConflictCheckingHelper.JHGVCWZrLClFwCxiTxApURmdrpdD;

			internal static ControllerHelper YorxuNVUVPjNOlbshCeyhTsgCtAkA => gDqAtqfHlRwADrybQLKutItDvmPP ?? (gDqAtqfHlRwADrybQLKutItDvmPP = new ControllerHelper());

			public int controllerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return MRYlWddHEDKxegbDTAfXRjoQYitX.bcHPTPmdVaQiZGZCAfxQFgqzFdcb;
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
					return MRYlWddHEDKxegbDTAfXRjoQYitX.bIgFfXlkvbTJmfSGQfQmDyRWFErB;
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
					return MRYlWddHEDKxegbDTAfXRjoQYitX.QsgkmYvQGAwyNumMjGEvekEAbBLHA;
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
					return MRYlWddHEDKxegbDTAfXRjoQYitX.IHPfnLMrgyTtYeIwxJsMlnCYMDst;
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
					return MRYlWddHEDKxegbDTAfXRjoQYitX.obOzcVKdOQfqEztHMjSkGgIZihnGb;
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
					return MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN;
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
					return MRYlWddHEDKxegbDTAfXRjoQYitX.POwcKpDhFJhDAAFrECdiOevTaPjPA;
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
					return MRYlWddHEDKxegbDTAfXRjoQYitX.WYMrctzupfMBLPDIFFyqRlYSzlRb;
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
					return MRYlWddHEDKxegbDTAfXRjoQYitX.IHPfnLMrgyTtYeIwxJsMlnCYMDst as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
				{
					return GetCustomController(controllerId) as T;
				}
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return MRYlWddHEDKxegbDTAfXRjoQYitX.QsgkmYvQGAwyNumMjGEvekEAbBLHA as T;
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
				return MRYlWddHEDKxegbDTAfXRjoQYitX.DxfjMakBNHsfwQIMeHaXPCHSdWpiA(controllerType, controllerId);
			}

			public Controller GetController(ControllerIdentifier controllerIdentifier)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.VAlQpaBUkFQpIiwBvElJlkBqweyN(controllerIdentifier);
			}

			public Controller[] GetControllers(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<Controller>.array;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.eEQyQdjWmoPyAEaKASepUOgMnrdX(controllerType);
			}

			public string[] GetControllerNames(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.mOQhAugBzkxgNYSKQnSNzYVbJyog(controllerType);
			}

			public bool IsControllerAssigned(ControllerType controllerType, Controller controller)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.dnXYozCQzzGGsGZwBZkgMNVaJBIz(controller);
			}

			public bool IsControllerAssigned(ControllerType controllerType, int controllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.QSNsQfKqxGlslWBTKhCtKRRAbwmq(controllerType, controllerId);
			}

			public bool IsControllerAssignedToPlayer(ControllerType controllerType, int controllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.FzkcmWYkRYBsUYsUAsdnxJNvIQyU(controllerType, controllerId, playerId);
			}

			public void RemoveControllerFromAllPlayers(Controller controller, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					NUfAUcWLCevjCFPFNKrevODCEJAs.EkRjCRGMcAayxuyhglCPYkYwYIjR(controller, includeSystemPlayer);
				}
			}

			public void RemoveControllerFromAllPlayers(ControllerType controllerType, int controllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					NUfAUcWLCevjCFPFNKrevODCEJAs.ECNcYoeNBNwNbDqokpibCGDYuiUf(controllerType, controllerId, includeSystemPlayer);
				}
			}

			public Joystick GetJoystick(int joystickId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.bGYAryEoCaDPuVhlQuucCjbIkmFG(joystickId);
			}

			public Joystick[] GetJoysticks()
			{
				return MRYlWddHEDKxegbDTAfXRjoQYitX.hzhGYAUfHKLUpqoOkmrkddUCjqck();
			}

			public string[] GetJoystickNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.ymJMKGmfXFIQhLkzVjEnamrBAKHgA();
			}

			public bool IsJoystickAssigned(Joystick joystick)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.bgNYuDvpHpIouWcRmuUySlZGFrUGA(joystick);
			}

			public bool IsJoystickAssigned(int joystickId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.JiChqYZJQsWCijZpretnJjzWEQwjA(joystickId);
			}

			public bool IsJoystickAssignedToPlayer(int joystickId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.OfjejBNfKuuDscFFQzVFnYhALSUy(joystickId, playerId);
			}

			public void RemoveJoystickFromAllPlayers(Joystick joystick, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					NUfAUcWLCevjCFPFNKrevODCEJAs.LXqftQFkRqxJSvypWNCZIaOGAFotA(joystick, includeSystemPlayer);
				}
			}

			public void RemoveJoystickFromAllPlayers(int joystickId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					NUfAUcWLCevjCFPFNKrevODCEJAs.FrrkTpOHtAsPOFEZuDfzfkiSChUX(joystickId, includeSystemPlayer);
				}
			}

			public int GetUnityJoystickIdFromAnyButtonPress()
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				if (!JwIEzBzVwoaJThQfJSjqGSeIRnNe)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				jugaBqqwsjCmhKCzHLvizmdfubLdA();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (UplohBqXSyNgjFNIGhiJaauIEPSGA.lHOUeFfEuphAQcXYYhvpmGhKaqBP(i, j))
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
				if (!JwIEzBzVwoaJThQfJSjqGSeIRnNe)
				{
					Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					return -1;
				}
				jugaBqqwsjCmhKCzHLvizmdfubLdA();
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 20; j++)
					{
						if (UplohBqXSyNgjFNIGhiJaauIEPSGA.lHOUeFfEuphAQcXYYhvpmGhKaqBP(i, j))
						{
							return i + 1;
						}
					}
					for (int k = 0; k < 29; k++)
					{
						if (UplohBqXSyNgjFNIGhiJaauIEPSGA.XZjUMRfEjTqeCWoDqUdKcEVQYOYH(i, k, positiveAxesOnly))
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
					if (!JwIEzBzVwoaJThQfJSjqGSeIRnNe)
					{
						Logger.LogWarning("This can only used when Unity Input is handling input. This has no effect on this platform.");
					}
					else
					{
						epwTnUVpwyQDOljotgHFjaZREHkeA.SetUnityJoystickId(joystickId, unityJoystickId);
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
				return MRYlWddHEDKxegbDTAfXRjoQYitX.HNRLIINMKXKEWxBotcMpkWOuhiXB(customControllerId);
			}

			public CustomController[] GetCustomControllers()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.array;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.ABNIuMmbYdbWUeUtLGvYhUVXKeJIb();
			}

			public string[] GetCustomControllerNames()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.neGuFcGgYmHXeXczWdFfaLoOLJpRA();
			}

			public bool IsCustomControllerAssigned(CustomController customController)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.bgnWmADipMaDdUcVEqOxQgzzuEpB(customController);
			}

			public bool IsCustomControllerAssigned(int customControllerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.rXawwoUkoBTOkvwaLYPRLMoWDjnm(customControllerId);
			}

			public bool IsCustomControllerAssignedToPlayer(int customControllerId, int playerId)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.bTjkZEVNxHzpZCKQwbQZJQszyHgb(customControllerId, playerId);
			}

			public void RemoveCustomControllerFromAllPlayers(CustomController customController, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					NUfAUcWLCevjCFPFNKrevODCEJAs.aguhapBMrWorAazyRMQdhHtXZuCaA(customController, includeSystemPlayer);
				}
			}

			public void RemoveCustomControllerFromAllPlayers(int customControllerId, bool includeSystemPlayer = true)
			{
				if (CheckInitialized())
				{
					NUfAUcWLCevjCFPFNKrevODCEJAs.qXaTpivpuSDJRppEzPBIKwxQzBxl(customControllerId, includeSystemPlayer);
				}
			}

			public CustomController CreateCustomController(int sourceControllerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.BRugcGeISrSegSkXsKuwCEfyEwuDb(sourceControllerId);
			}

			public CustomController CreateCustomController(int sourceControllerId, string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				CustomController customController = MRYlWddHEDKxegbDTAfXRjoQYitX.BRugcGeISrSegSkXsKuwCEfyEwuDb(sourceControllerId);
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
				return MRYlWddHEDKxegbDTAfXRjoQYitX.qRWucmegvhBZDeuvsYPHjndYsAWNA(customController);
			}

			public CustomController GetFirstCustomControllerWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.kdSEaKdDNshvdKeuPqeNypmznIRPA(sourceId);
			}

			public CustomController GetFirstCustomControllerWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.RSKIArpbiXfDvXviUgvQTxZSneCT(tag);
			}

			public IEnumerable<CustomController> CustomControllersWithSourceId(int sourceId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.brRGFENXtZJdiuNQdtlzeXEChmfK(sourceId);
			}

			public IEnumerable<CustomController> CustomControllersWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<CustomController>.EmptyReadOnlyIListT;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.eriRonQDrEGxacuiiDjaggNqaTTNA(tag);
			}

			public IList<TInterface> GetControllerTemplates<TInterface>() where TInterface : IControllerTemplate
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<TInterface>.EmptyReadOnlyIListT;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.JLeNUbSEefotDUhSPxlXjTqsizqn<TInterface>();
			}

			public Controller GetLastActiveController()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.PPGgmKTcxkbgSzuwUyxyspgbxexJ();
			}

			public Controller GetLastActiveController(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.jBwhtNdOtuqbHFBfqGZNTWctnAiW(controllerType);
			}

			public T GetLastActiveController<T>() where T : Controller
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.PPGgmKTcxkbgSzuwUyxyspgbxexJ<T>();
			}

			public ControllerType GetLastActiveControllerType()
			{
				if (!CheckInitialized())
				{
					return ControllerType.Keyboard;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.fDExmMeQJqVODjbIsKBNWINFgWae();
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					MRYlWddHEDKxegbDTAfXRjoQYitX.dkQIkdUMBhJRayMormxQTqFDgVXC(callback);
				}
			}

			public void AddLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					MRYlWddHEDKxegbDTAfXRjoQYitX.DGvJgrUJOhCqhBTdvUsOFiNIPURgb(callback, controllerType);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback)
			{
				if (CheckInitialized())
				{
					MRYlWddHEDKxegbDTAfXRjoQYitX.WXjBrASwWjXxEruHtFHdzKYPgJOz(callback);
				}
			}

			public void RemoveLastActiveControllerChangedDelegate(ActiveControllerChangedDelegate callback, ControllerType controllerType)
			{
				if (CheckInitialized())
				{
					MRYlWddHEDKxegbDTAfXRjoQYitX.RENIXGCCZSwTJNfLKBvDvETWpCaQA(callback, controllerType);
				}
			}

			public void ClearLastActiveControllerChangedDelegates()
			{
				if (CheckInitialized())
				{
					MRYlWddHEDKxegbDTAfXRjoQYitX.nzSbvuHaDNSPcIJLEzKcPKTveHCdc();
				}
			}

			public bool GetAnyButton()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.MSRPliqyXxPccJwFvhNUukORZcQP();
			}

			public bool GetAnyButton(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.lhavKZtNSjfuobfafaUTfLNUQItC(controllerType);
			}

			public bool GetAnyButtonDown()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.jAAZAXYVRVrBXuqjbUZXdHejgjvd();
			}

			public bool GetAnyButtonDown(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.ckvKymTsZPfDxQRYpkGwALPDQStQ(controllerType);
			}

			public bool GetAnyButtonUp()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.CQyfLyNyihDDwBCIdIEvtJAtbgku();
			}

			public bool GetAnyButtonUp(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.wdHczPVSPPBfXDaHDmKlQgCjAIMDb(controllerType);
			}

			public bool GetAnyButtonChanged()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.RwQpppPJkOoyIaWEZljJzBYVGTQq();
			}

			public bool GetAnyButtonChanged(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.AAeZtfARBTykFZfXJjmCKTshlFEL(controllerType);
			}

			public bool GetAnyButtonPrev()
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.wcwLeTRgGWrmJtHnSqabErihRtfI();
			}

			public bool GetAnyButtonPrev(ControllerType controllerType)
			{
				if (!CheckInitialized())
				{
					return false;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.nhIkfQUXTOkpCBkiXIzjTusbFofs(controllerType);
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
				NUfAUcWLCevjCFPFNKrevODCEJAs.nejjbnhTtxZEBIEhoUYDuTQguDdn(joystick);
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
			private static MappingHelper YwcUHrTrmxVeqJpQYZvjimlQhgiZ;

			internal static MappingHelper JuXrblwUXRKmthIlMiiNhNFfLqyt => YwcUHrTrmxVeqJpQYZvjimlQhgiZ ?? (YwcUHrTrmxVeqJpQYZvjimlQhgiZ = new MappingHelper());

			public IList<InputMapCategory> MapCategories
			{
				get
				{
					if (!CheckInitialized())
					{
						return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
					}
					return jODnKgTyGBuOYuWSEDEtbledplkA.ygRYTfsGocfxIGZBHSvYRjhiFskx;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.cOSkSqaekAaHTAbDMLClrWfrURzt;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.JtXNnsmuBiEVWZqEjMpnyztNcIoS;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.WzzoDEmgtEkGcGbgECbutmJJSRCJ;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.kHvsAZqeDuhMuiGkaqbPPOvtaPMi;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.ClEQeDqNtemuIplHbJTHDjfTlidRA;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.XzWTHbSpUVMzZioAkaBWYWJANyDI;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.OHVCzYKpFwxJZMtNzIejndHtbCJW;
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
					return xKokvIxOzcvermvcSUcNKZIGamDS.nBhOyBMUUwEcliaRuIBSgZoZtveD;
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
					return jODnKgTyGBuOYuWSEDEtbledplkA.GFQMYNoaBxIChmpWoRZwwhhOCxLc;
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
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetMapCategoryById(mapCategoryId);
			}

			public InputMapCategory GetMapCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetMapCategory(name);
			}

			public int GetMapCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetMapCategoryId(name);
			}

			public IEnumerable<InputMapCategory> MapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.ymDHWRhIsejizjOCFPCbgTgMDEnC(tag);
			}

			public IEnumerable<InputMapCategory> UserAssignableMapCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputMapCategory>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.bDHlbybfxPOyHwfCzQXndmtcbKlR(tag);
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
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetActionCategoryById(mapCategoryId);
			}

			public InputCategory GetActionCategory(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetActionCategory(name);
			}

			public int GetActionCategoryId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetActionCategoryId(name);
			}

			public IEnumerable<InputCategory> ActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.HajVFdSkBpxBklQmGSjTTHPlFJDk(tag);
			}

			public IEnumerable<InputCategory> UserAssignableActionCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputCategory>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.vIOCXjqMSWRVAYfioBrOqwUuOYLb(tag);
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
					ControllerType.Joystick => jODnKgTyGBuOYuWSEDEtbledplkA.GetJoystickLayoutById(layoutId), 
					ControllerType.Keyboard => jODnKgTyGBuOYuWSEDEtbledplkA.GetKeyboardLayoutById(layoutId), 
					ControllerType.Mouse => jODnKgTyGBuOYuWSEDEtbledplkA.GetMouseLayoutById(layoutId), 
					ControllerType.Custom => jODnKgTyGBuOYuWSEDEtbledplkA.GetCustomControllerLayoutById(layoutId), 
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
					ControllerType.Joystick => jODnKgTyGBuOYuWSEDEtbledplkA.GetJoystickLayout(name), 
					ControllerType.Keyboard => jODnKgTyGBuOYuWSEDEtbledplkA.GetKeyboardLayout(name), 
					ControllerType.Mouse => jODnKgTyGBuOYuWSEDEtbledplkA.GetMouseLayout(name), 
					ControllerType.Custom => jODnKgTyGBuOYuWSEDEtbledplkA.GetCustomControllerLayout(name), 
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
					ControllerType.Joystick => jODnKgTyGBuOYuWSEDEtbledplkA.GetJoystickLayoutId(name), 
					ControllerType.Keyboard => jODnKgTyGBuOYuWSEDEtbledplkA.GetKeyboardLayoutId(name), 
					ControllerType.Mouse => jODnKgTyGBuOYuWSEDEtbledplkA.GetMouseLayoutId(name), 
					ControllerType.Custom => jODnKgTyGBuOYuWSEDEtbledplkA.GetCustomControllerLayoutId(name), 
					_ => throw new NotImplementedException(), 
				};
			}

			public InputLayout GetJoystickLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetJoystickLayoutById(layoutId);
			}

			public InputLayout GetJoystickLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetJoystickLayout(name);
			}

			public int GetJoystickLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetJoystickLayoutId(name);
			}

			public InputLayout GetKeyboardLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetKeyboardLayoutById(layoutId);
			}

			public InputLayout GetKeyboardLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetKeyboardLayout(name);
			}

			public int GetKeyboardLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetKeyboardLayoutId(name);
			}

			public InputLayout GetMouseLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetMouseLayoutById(layoutId);
			}

			public InputLayout GetMouseLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetMouseLayout(name);
			}

			public int GetMouseLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetMouseLayoutId(name);
			}

			public InputLayout GetCustomControllerLayout(int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetCustomControllerLayoutById(layoutId);
			}

			public InputLayout GetCustomControllerLayout(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetCustomControllerLayout(name);
			}

			public int GetCustomControllerLayoutId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetCustomControllerLayoutId(name);
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
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetActionById(actionId);
			}

			public InputAction GetAction(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetAction(name);
			}

			public int GetActionId(string name)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetActionId(name);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.VTMuOlZprxEzchkKIMMVjDuNORCQ(mapCategoryName, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.VTMuOlZprxEzchkKIMMVjDuNORCQ(mapCategoryName, sort);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.xzSAYzvUNBdkhdYrDvboRIjPlMsu(mapCategoryId, false);
			}

			public IEnumerable<InputAction> ActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.xzSAYzvUNBdkhdYrDvboRIjPlMsu(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> ActionsInCategoriesWithTag(string tag)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.gZgVcHWbUAXGgNYzpsvQjAircqQE(tag);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.YgQpGKDBAtOVTazhaGnoaTLJsou(mapCategoryId, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(int mapCategoryId, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.YgQpGKDBAtOVTazhaGnoaTLJsou(mapCategoryId, sort);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.hicuJieyokJxOSFYpmizlXJrHdvM(mapCategoryName, false);
			}

			public IEnumerable<InputAction> UserAssignableActionsInCategory(string mapCategoryName, bool sort)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputAction>.EmptyReadOnlyIListT;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.hicuJieyokJxOSFYpmizlXJrHdvM(mapCategoryName, sort);
			}

			public IList<InputBehavior> GetInputBehaviors(int playerId)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.RlKvfUYTewvvmbMXFjOtndRBcIeAA(playerId);
			}

			public IList<InputBehavior> GetSystemPlayerInputBehaviors()
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<InputBehavior>.EmptyReadOnlyIListT;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.RlKvfUYTewvvmbMXFjOtndRBcIeAA(9999999);
			}

			public InputBehavior GetInputBehavior(int playerId, int behaviorId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.HTrjSoiJIJXjtkLAhefMBsTvgqWT(playerId, behaviorId);
			}

			public InputBehavior GetInputBehavior(int playerId, string behaviorName)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return MRYlWddHEDKxegbDTAfXRjoQYitX.WhFrPEcblINBrBoGPgGyBBcAnAKib(playerId, behaviorName);
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
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetInputBehaviorId(behaviorName);
			}

			internal InputBehavior BZIlZOVMwCCENvAYKcvxgVgQRsvU(int P_0)
			{
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetInputBehaviorById(P_0);
			}

			internal InputBehavior EyTWzNuLynBeQIfgLhMzkkaokxXu(string P_0)
			{
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetInputBehavior(P_0);
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
				Controller controller = MRYlWddHEDKxegbDTAfXRjoQYitX.VAlQpaBUkFQpIiwBvElJlkBqweyN(controllerIdentifier);
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
				JoystickMap joystickMap = jODnKgTyGBuOYuWSEDEtbledplkA.gYrdCGSkLMLRiPRFTdAQQekZgBRu(joystick, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					joystick.CFaHiJEFpgwiVcWJwPEuwOjLMzZm(joystickMap);
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
				InputSource inputSourceType = epwTnUVpwyQDOljotgHFjaZREHkeA.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = KqnMeitEmbiOdilpDRDYwYdyjptQ.aHYlrOkRajFfYhoXLjstuQjMqULb(joystickTypeGuid, inputSourceType);
				if (hardwareJoystickMap_InputManager == null)
				{
					Logger.LogError("No hardware map found.");
					return null;
				}
				JoystickMap joystickMap = jODnKgTyGBuOYuWSEDEtbledplkA.IsSxsOzFivKFteEYDNGZOMZSRJyK(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
				if (joystickMap != null)
				{
					HardwareControllerMap_Game hardwareControllerMap_Game = hardwareJoystickMap_InputManager.ToGameHardwareControllerMap();
					foreach (ActionElementMap allMap in joystickMap.AllMaps)
					{
						allMap.nyVHOotMlgdJavSeaIKsOuVqTCnE(joystickMap, hardwareControllerMap_Game);
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
				if (MRYlWddHEDKxegbDTAfXRjoQYitX.VAlQpaBUkFQpIiwBvElJlkBqweyN(controllerIdentifier) is Joystick joystick)
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
				KeyboardMap keyboardMap = jODnKgTyGBuOYuWSEDEtbledplkA.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				if (keyboardMap != null)
				{
					controllers.Keyboard.CFaHiJEFpgwiVcWJwPEuwOjLMzZm(keyboardMap);
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
				MouseMap mouseMap = jODnKgTyGBuOYuWSEDEtbledplkA.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				if (mouseMap != null)
				{
					controllers.Mouse.CFaHiJEFpgwiVcWJwPEuwOjLMzZm(mouseMap);
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
				CustomControllerMap customControllerMap = jODnKgTyGBuOYuWSEDEtbledplkA.TUkZAWXnygEsdIliJViGaMjbPySaA(customController.sourceControllerId, mapCategoryId, layoutId);
				if (customControllerMap != null)
				{
					customController.CFaHiJEFpgwiVcWJwPEuwOjLMzZm(customControllerMap);
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
				if (MRYlWddHEDKxegbDTAfXRjoQYitX.VAlQpaBUkFQpIiwBvElJlkBqweyN(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstance(customController, mapCategoryId, layoutId);
				}
				if (controllerIdentifier.hardwareTypeGuid == Guid.Empty)
				{
					return null;
				}
				CustomController_Editor customControllerByHardwareTypeGuid = jODnKgTyGBuOYuWSEDEtbledplkA.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
				if (customControllerByHardwareTypeGuid == null)
				{
					return null;
				}
				CustomControllerMap customControllerMap = jODnKgTyGBuOYuWSEDEtbledplkA.CqogbileiizxaacONOYogivmsfYW(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.nyVHOotMlgdJavSeaIKsOuVqTCnE(customControllerMap, hardwareControllerMap_Game);
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
					controllerMap = jODnKgTyGBuOYuWSEDEtbledplkA.pmpsiHEijmkjdZKEijxiUJpJmdUO(controller, mapCategoryId, layoutId);
				}
				if (controllerMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.ESTpCbOkBFCpCFfteFzCbHaJDHXK(controller, controllerMap);
					}
					else
					{
						controller.CFaHiJEFpgwiVcWJwPEuwOjLMzZm(controllerMap);
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
				if (MRYlWddHEDKxegbDTAfXRjoQYitX.VAlQpaBUkFQpIiwBvElJlkBqweyN(controllerIdentifier) is Joystick joystick)
				{
					return GetJoystickMapInstanceSavedOrDefault(playerId, joystick, mapCategoryId, layoutId);
				}
				InputSource inputSourceType = epwTnUVpwyQDOljotgHFjaZREHkeA.inputSourceType;
				HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = KqnMeitEmbiOdilpDRDYwYdyjptQ.aHYlrOkRajFfYhoXLjstuQjMqULb(controllerIdentifier.hardwareTypeGuid, inputSourceType);
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
					joystickMap = jODnKgTyGBuOYuWSEDEtbledplkA.IsSxsOzFivKFteEYDNGZOMZSRJyK(hardwareJoystickMap_InputManager.hardwareMapIdentifier, mapCategoryId, layoutId);
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
						allMap.nyVHOotMlgdJavSeaIKsOuVqTCnE(joystickMap, hardwareControllerMap_Game);
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
				if (MRYlWddHEDKxegbDTAfXRjoQYitX.VAlQpaBUkFQpIiwBvElJlkBqweyN(controllerIdentifier) is CustomController customController)
				{
					return GetCustomControllerMapInstanceSavedOrDefault(playerId, customController, mapCategoryId, layoutId);
				}
				CustomController_Editor customControllerByHardwareTypeGuid = jODnKgTyGBuOYuWSEDEtbledplkA.GetCustomControllerByHardwareTypeGuid(controllerIdentifier.hardwareTypeGuid);
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
					customControllerMap = jODnKgTyGBuOYuWSEDEtbledplkA.CqogbileiizxaacONOYogivmsfYW(controllerIdentifier.hardwareTypeGuid, mapCategoryId, layoutId);
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
						allMap.nyVHOotMlgdJavSeaIKsOuVqTCnE(customControllerMap, hardwareControllerMap_Game);
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
					keyboardMap = jODnKgTyGBuOYuWSEDEtbledplkA.FindKeyboardMap_Game(controllers.Keyboard, mapCategoryId, layoutId);
				}
				if (keyboardMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.ESTpCbOkBFCpCFfteFzCbHaJDHXK(keyboard, keyboardMap);
					}
					else
					{
						keyboard.CFaHiJEFpgwiVcWJwPEuwOjLMzZm(keyboardMap);
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
					mouseMap = jODnKgTyGBuOYuWSEDEtbledplkA.FindMouseMap_Game(controllers.Mouse, mapCategoryId, layoutId);
				}
				if (mouseMap != null)
				{
					Player player = players.GetPlayer(playerId);
					if (player != null)
					{
						player.controllers.maps.ESTpCbOkBFCpCFfteFzCbHaJDHXK(mouse, mouseMap);
					}
					else
					{
						mouse.CFaHiJEFpgwiVcWJwPEuwOjLMzZm(mouseMap);
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
				return dGoKpzSDJPkJdFjhfWjhhshiBqDF(joystick.hardwareTypeGuid, joystickElementIdentifierId);
			}

			private ControllerElementIdentifier dGoKpzSDJPkJdFjhfWjhhshiBqDF(Guid P_0, int P_1)
			{
				return KqnMeitEmbiOdilpDRDYwYdyjptQ.zMBcpPFvKsLYlmftnNoQlHGLdJtw(P_0, P_1)?.ToControllerElementIdentifier();
			}

			public ControllerTemplateMap GetControllerTemplateMapInstance(Guid templateTypeGuid, int mapCategoryId, int layoutId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return jODnKgTyGBuOYuWSEDEtbledplkA.OJRmUMgkFJQpVOZBliLbYAWUlZmF(templateTypeGuid, mapCategoryId, layoutId);
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
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetControllerMapLayoutManagerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapLayoutManager.RuleSet GetControllerMapLayoutManagerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapLayoutManagerRuleSetId = jODnKgTyGBuOYuWSEDEtbledplkA.GetControllerMapLayoutManagerRuleSetId(name);
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
				return jODnKgTyGBuOYuWSEDEtbledplkA.GetControllerMapEnablerRuleSetById(id)?.ToRuntime();
			}

			public ControllerMapEnabler.RuleSet GetControllerMapEnablerRuleSetInstance(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				int controllerMapEnablerRuleSetId = jODnKgTyGBuOYuWSEDEtbledplkA.GetControllerMapEnablerRuleSetId(name);
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
			private static PlayerHelper aHamerrmElzybZZXILbgHRRgnfkM;

			internal static PlayerHelper ghLYlFFUjPcDucBnSdyVEneCOQsW => aHamerrmElzybZZXILbgHRRgnfkM ?? (aHamerrmElzybZZXILbgHRRgnfkM = new PlayerHelper());

			public int playerCount
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0;
					}
					return NUfAUcWLCevjCFPFNKrevODCEJAs.UJTUqhYGWFaEOAtpDKAOMicqQsWF;
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
					return NUfAUcWLCevjCFPFNKrevODCEJAs.uUlAdkTrrGmeatOJXDQKcoxXeSHs;
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
					return NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG;
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
					return NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR;
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
					return NUfAUcWLCevjCFPFNKrevODCEJAs.TwkaSnHIHKDqhuSmBQQQfkiEADGX();
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
					return NUfAUcWLCevjCFPFNKrevODCEJAs.kXxcetKhlgDvETXoPvvQXNPCzSTG;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.LgeEoisNbkWVEtfiDwUoWAbPysPR;
			}

			public Player GetPlayer(int playerId)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.MgIIdYJCmureJBUYamqZmJEeOVwP(playerId);
			}

			public Player GetPlayer(string name)
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.cKIQrJlTSQyJxdaOmUakiQMlyXrI(name);
			}

			public Player GetSystemPlayer()
			{
				if (!CheckInitialized())
				{
					return null;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.TwkaSnHIHKDqhuSmBQQQfkiEADGX();
			}

			public int GetPlayerId(string playerName)
			{
				if (!CheckInitialized())
				{
					return -1;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.NmWlsBDGCCjSySvifsukqnZccEFi(playerName);
			}

			public string[] GetPlayerNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.HCguGDKyERYuSUpnESAcSAexYAGd(includeSystemPlayer);
			}

			public string[] GetPlayerDescriptiveNames(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<string>.array;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.kNWmYvJkJdrbWmDsqFqMuUdRCESX(includeSystemPlayer);
			}

			public int[] GetPlayerIds(bool includeSystemPlayer = false)
			{
				if (!CheckInitialized())
				{
					return EmptyObjects<int>.array;
				}
				return NUfAUcWLCevjCFPFNKrevODCEJAs.QmbdcXyflSrRYeHXZKOQwISqcxvr(includeSystemPlayer);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class TimeHelper : CodeHelper
		{
			private static TimeHelper LYluulLefPOHtwdQGbpXADckesShA;

			internal static TimeHelper jHTboGyiZdqhlWytuLKOBjaBISvdA => LYluulLefPOHtwdQGbpXADckesShA ?? (LYluulLefPOHtwdQGbpXADckesShA = new TimeHelper());

			public float unscaledDeltaTime
			{
				get
				{
					if (!CheckInitialized())
					{
						return 0f;
					}
					return (float)eQBlPZDuiMCBbFmfVuOABhjvmMoE.VhJcVQmMdqwJYskmqccJewMSdUQSA;
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
					return eQBlPZDuiMCBbFmfVuOABhjvmMoE.QQOmvxvBlkiiBrljnVbvtVjejmZw;
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
					return eQBlPZDuiMCBbFmfVuOABhjvmMoE.TQBxmewHzxHiySkUHlKteiLxendGA;
				}
			}

			private TimeHelper()
			{
			}
		}

		private class YBFDxCxnTUEpjVqNryAEKYqqCGRE
		{
			private class XaKZnFqJMZflQIkuzeAyuZEpiAPN
			{
				public readonly UpdateLoopType OMlVpgbUvNpVtxCebJgPeMoOzDIOA;

				private double FJacGkbqXJZosSZkgxdKDRFmRVes;

				private double HdeRluomgXXjoyheozsNvbvlZlrp;

				private double KUUAgdjuPkYtwKZBtDxqEcbXEoXT;

				private double NUxEjPdjqFjmYtCFTNUQKVeZhKwD;

				private uint RhvioHwiPHhBAdsPYlKVaRiIYiJrb;

				private uint eeEYHVMIurYmSZEbCUAedSRrjXLp;

				private float xhWxjhRKlXLkHYlCsibUYNbcxDCv;

				private float yYrhECWJjjEkAgJajhTrpidZosldA;

				public double NtrpsTPayZOlRcHtTHtHfntTwTll => FJacGkbqXJZosSZkgxdKDRFmRVes;

				public double FnJsdmLgGOLLRAIjWJkukiggPJKd => HdeRluomgXXjoyheozsNvbvlZlrp;

				public double isCDpocgfzoEwVVQsnSRzQQWSaymA => KUUAgdjuPkYtwKZBtDxqEcbXEoXT;

				public uint JzyKwNVZlKDOGGXLCKTagaVFfnMY => RhvioHwiPHhBAdsPYlKVaRiIYiJrb;

				public uint tHnRFirNWeftEFBygOwTNWbwFzuyA => eeEYHVMIurYmSZEbCUAedSRrjXLp;

				public float vZqcQxiQcNmiKcOORHyTbRqxSLlg => xhWxjhRKlXLkHYlCsibUYNbcxDCv;

				public float RblJSvDfFsgkfoovctckZzZQTqdm => yYrhECWJjjEkAgJajhTrpidZosldA;

				public XaKZnFqJMZflQIkuzeAyuZEpiAPN(UpdateLoopType P_0)
				{
					OMlVpgbUvNpVtxCebJgPeMoOzDIOA = P_0;
					NUxEjPdjqFjmYtCFTNUQKVeZhKwD = Time.realtimeSinceStartup;
					RhvioHwiPHhBAdsPYlKVaRiIYiJrb = 0u;
				}

				public void zeeCQzAnthKHNoSTSdLjfGZDdMMib()
				{
					HdeRluomgXXjoyheozsNvbvlZlrp = FJacGkbqXJZosSZkgxdKDRFmRVes;
					FJacGkbqXJZosSZkgxdKDRFmRVes = realTime;
					if (NUxEjPdjqFjmYtCFTNUQKVeZhKwD > FJacGkbqXJZosSZkgxdKDRFmRVes)
					{
						NUxEjPdjqFjmYtCFTNUQKVeZhKwD = 0.0;
					}
					KUUAgdjuPkYtwKZBtDxqEcbXEoXT = FJacGkbqXJZosSZkgxdKDRFmRVes - NUxEjPdjqFjmYtCFTNUQKVeZhKwD;
					NUxEjPdjqFjmYtCFTNUQKVeZhKwD = FJacGkbqXJZosSZkgxdKDRFmRVes;
					eeEYHVMIurYmSZEbCUAedSRrjXLp = RhvioHwiPHhBAdsPYlKVaRiIYiJrb;
					RhvioHwiPHhBAdsPYlKVaRiIYiJrb = MiscTools.Tick(RhvioHwiPHhBAdsPYlKVaRiIYiJrb);
					yYrhECWJjjEkAgJajhTrpidZosldA = xhWxjhRKlXLkHYlCsibUYNbcxDCv;
					xhWxjhRKlXLkHYlCsibUYNbcxDCv = vdXdgLnemwXdeeSuUzVeNQqixkId();
					previousFrame = eeEYHVMIurYmSZEbCUAedSRrjXLp;
					currentFrame = RhvioHwiPHhBAdsPYlKVaRiIYiJrb;
					unscaledTime = FJacGkbqXJZosSZkgxdKDRFmRVes;
					unscaledTimePrev = HdeRluomgXXjoyheozsNvbvlZlrp;
					unscaledDeltaTime = KUUAgdjuPkYtwKZBtDxqEcbXEoXT;
				}
			}

			private static class qpTbCOzTWXPTPCPCbwFylXEaTDgQ
			{
				public static StopwatchBase mqNIxiwcKHzEwwXjyWTzSQLPNVvs
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

				public static StopwatchBase hyufydCYorNGwurcDdsgxdrENCwS()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return new UnityStopwatch();
					}
					return new Rewired.Utils.Classes.Utility.Stopwatch();
				}

				public static StopwatchBase ihDPtfLiavgaTxclznRGHOMUwKSc()
				{
					if (!UnityTools.isEditor && UnityTools.platform == Platform.XboxOne)
					{
						return UnityStopwatch.StartNew();
					}
					return Rewired.Utils.Classes.Utility.Stopwatch.StartNew();
				}
			}

			private StopwatchBase MdVlAGKMGRRaHVuRpMNPuHKmehzo;

			private double cgzpLBAGMUKEFKfobEyNTHhjfGuH;

			private XaKZnFqJMZflQIkuzeAyuZEpiAPN QHSZGhRNuGGhaQQbYVXiUGSolfxw;

			private ADictionary<int, XaKZnFqJMZflQIkuzeAyuZEpiAPN> niZyzrpipTslNtqiMDsahyzMzpGH;

			private uint VVYviaLIkuCgABtHHWduIVuXrrlM;

			public double QQOmvxvBlkiiBrljnVbvtVjejmZw => QHSZGhRNuGGhaQQbYVXiUGSolfxw.NtrpsTPayZOlRcHtTHtHfntTwTll;

			public double IEeBRVGYaEzfuvfDjkteRGsoDxCYA => QHSZGhRNuGGhaQQbYVXiUGSolfxw.FnJsdmLgGOLLRAIjWJkukiggPJKd;

			public double VhJcVQmMdqwJYskmqccJewMSdUQSA => QHSZGhRNuGGhaQQbYVXiUGSolfxw.isCDpocgfzoEwVVQsnSRzQQWSaymA;

			public float WFshRQqREIjeyjPSqtEaYrvNWtcG => QHSZGhRNuGGhaQQbYVXiUGSolfxw.vZqcQxiQcNmiKcOORHyTbRqxSLlg;

			public float TWGjXEqKFaCFMdilQbYWxKwfCKLw => QHSZGhRNuGGhaQQbYVXiUGSolfxw.RblJSvDfFsgkfoovctckZzZQTqdm;

			internal double WabqJOVJajHbqLtEaARhrBRaaYTCA => MdVlAGKMGRRaHVuRpMNPuHKmehzo.elapsedSeconds + cgzpLBAGMUKEFKfobEyNTHhjfGuH;

			public uint TQBxmewHzxHiySkUHlKteiLxendGA => QHSZGhRNuGGhaQQbYVXiUGSolfxw.JzyKwNVZlKDOGGXLCKTagaVFfnMY;

			public uint XawXDOhhXntbtxCNoqHhsPUyOqEu => QHSZGhRNuGGhaQQbYVXiUGSolfxw.tHnRFirNWeftEFBygOwTNWbwFzuyA;

			public uint bNxySmlLWyQunXRdqmIpWCnzGEBY => VVYviaLIkuCgABtHHWduIVuXrrlM;

			public YBFDxCxnTUEpjVqNryAEKYqqCGRE()
			{
				MdVlAGKMGRRaHVuRpMNPuHKmehzo = qpTbCOzTWXPTPCPCbwFylXEaTDgQ.mqNIxiwcKHzEwwXjyWTzSQLPNVvs;
				mTUtEHEGqeIDhKZESDUlKUNkPMgQ();
			}

			public void lCSaZBatLiGFtQNeliOOHRHexDcVB()
			{
				cgzpLBAGMUKEFKfobEyNTHhjfGuH = Time.realtimeSinceStartup;
			}

			public void mTUtEHEGqeIDhKZESDUlKUNkPMgQ()
			{
				QHSZGhRNuGGhaQQbYVXiUGSolfxw = null;
				niZyzrpipTslNtqiMDsahyzMzpGH = new ADictionary<int, XaKZnFqJMZflQIkuzeAyuZEpiAPN>();
				using TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3);
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes((UpdateLoopSetting)2147483647, list);
				for (int i = 0; i < list.Count; i++)
				{
					XaKZnFqJMZflQIkuzeAyuZEpiAPN xaKZnFqJMZflQIkuzeAyuZEpiAPN = new XaKZnFqJMZflQIkuzeAyuZEpiAPN(list[i]);
					niZyzrpipTslNtqiMDsahyzMzpGH.Add((int)list[i], xaKZnFqJMZflQIkuzeAyuZEpiAPN);
					if (QHSZGhRNuGGhaQQbYVXiUGSolfxw == null)
					{
						QHSZGhRNuGGhaQQbYVXiUGSolfxw = xaKZnFqJMZflQIkuzeAyuZEpiAPN;
					}
				}
			}

			public void umteXFKqWeoAszBqCNEemQKxhbTf(UpdateLoopType P_0)
			{
				if (QHSZGhRNuGGhaQQbYVXiUGSolfxw.OMlVpgbUvNpVtxCebJgPeMoOzDIOA != P_0)
				{
					QHSZGhRNuGGhaQQbYVXiUGSolfxw = niZyzrpipTslNtqiMDsahyzMzpGH[(int)P_0];
				}
				if (P_0 != UpdateLoopType.OnGUI || Event.current.rawType == EventType.Layout)
				{
					QHSZGhRNuGGhaQQbYVXiUGSolfxw.zeeCQzAnthKHNoSTSdLjfGZDdMMib();
					VVYviaLIkuCgABtHHWduIVuXrrlM = MiscTools.Tick(VVYviaLIkuCgABtHHWduIVuXrrlM);
					absFrame = VVYviaLIkuCgABtHHWduIVuXrrlM;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class UnityTouch : CodeHelper
		{
			private static UnityTouch ooYIXsYApxlrQlEXipkSYtFFLddY;

			internal static UnityTouch EShLMNSIMeGeAlUGzhhtbDsFmgHS => ooYIXsYApxlrQlEXipkSYtFFLddY ?? (ooYIXsYApxlrQlEXipkSYtFFLddY = new UnityTouch());

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

		internal class nWGZEfybJWKkvAqBWRRslDMpRAlo
		{
			[Serializable]
			private sealed class mDGXxESWAjMAkLfZpTJvHxfOKRsc
			{
				public static readonly mDGXxESWAjMAkLfZpTJvHxfOKRsc _003C_003E9 = new mDGXxESWAjMAkLfZpTJvHxfOKRsc();

				public static Func<bool> _003C_003E9__11_1;

				public static Func<bool> _003C_003E9__11_2;

				public static Func<int> _003C_003E9__11_3;

				public static Func<float> _003C_003E9__11_4;

				public static Func<bool> _003C_003E9__11_5;

				public static Func<string> _003C_003E9__11_0;

				internal bool EQxZAgxkDxeqgdmrfvVXBbtrSsTI()
				{
					return Screen.fullScreen;
				}

				internal bool iJRdJlJTRqpHqVFdGmZhnAzlYMMfA()
				{
					return Application.runInBackground;
				}

				internal int jqNUgsvpHxGGoqJKYfZSlSODdVxK()
				{
					return (int)Screen.fullScreenMode;
				}

				internal float wAkXnSipRjvJtXOQmFjnInhkeANMA()
				{
					return Time.unscaledDeltaTime;
				}

				internal bool ThvTVAhsvCuKWJnlQQqFcHOgOXae()
				{
					return MathTools.ApproximatelyZero(Time.timeScale);
				}

				internal string PsLwiWhYqHjnDYsXpgFHrwQOJdsb()
				{
					return UnityTools.externalTools.GetFocusedEditorWindowTitle();
				}
			}

			public readonly ValueWatcher<bool> ihdQPRxcmXUAhhpJHszEmddPaFKP;

			public readonly ValueWatcher<bool> ORZDAbOLYkHsBAAOHqrCuUBNoyFF;

			public readonly ValueWatcher<bool> gOCqWHjCtWvnpQSyRohmrqkICGUn;

			public readonly ValueWatcher<int> kHClwbbrNeQPVIfEuEwIjLonaWFn;

			public readonly ValueWatcher<float> JntBGOOSXqpdYZGlJfBmGTmVKAow;

			public readonly ValueWatcher<string> LagdOXCiKcGjReTDvBkeNAzVPMJSA;

			public readonly ValueWatcher<bool> CePfaremcevchwoWUPLlCSWXdPvS;

			private int fwXzcGFNsmIhcpNVOySEIzrLnvub;

			private readonly ValueWatcher[] QbUlgudJRGhEgfssJojiuSMsoDbX;

			public int CkEJYuntznJKbAhfrcecdIDrpvCH => fwXzcGFNsmIhcpNVOySEIzrLnvub;

			public nWGZEfybJWKkvAqBWRRslDMpRAlo()
			{
				List<ValueWatcher> list = new List<ValueWatcher>
				{
					(ihdQPRxcmXUAhhpJHszEmddPaFKP = new ValueWatcher<bool>(true, false)),
					(ORZDAbOLYkHsBAAOHqrCuUBNoyFF = new ValueWatcher<bool>(Screen.fullScreen, mDGXxESWAjMAkLfZpTJvHxfOKRsc._003C_003E9.EQxZAgxkDxeqgdmrfvVXBbtrSsTI, false)),
					(gOCqWHjCtWvnpQSyRohmrqkICGUn = new ValueWatcher<bool>(Application.runInBackground, mDGXxESWAjMAkLfZpTJvHxfOKRsc._003C_003E9.iJRdJlJTRqpHqVFdGmZhnAzlYMMfA, false)),
					(kHClwbbrNeQPVIfEuEwIjLonaWFn = new ValueWatcher<int>((int)Screen.fullScreenMode, mDGXxESWAjMAkLfZpTJvHxfOKRsc._003C_003E9.jqNUgsvpHxGGoqJKYfZSlSODdVxK, false)),
					(JntBGOOSXqpdYZGlJfBmGTmVKAow = new ValueWatcher<float>(Time.unscaledDeltaTime, mDGXxESWAjMAkLfZpTJvHxfOKRsc._003C_003E9.wAkXnSipRjvJtXOQmFjnInhkeANMA, false)),
					(CePfaremcevchwoWUPLlCSWXdPvS = new ValueWatcher<bool>(MathTools.ApproximatelyZero(Time.timeScale), mDGXxESWAjMAkLfZpTJvHxfOKRsc._003C_003E9.ThvTVAhsvCuKWJnlQQqFcHOgOXae, MathTools.ApproximatelyZero(Time.timeScale)))
				};
				if (editorPlatform != EditorPlatform.None)
				{
					list.Add(LagdOXCiKcGjReTDvBkeNAzVPMJSA = new ValueWatcher<string>(UnityTools.externalTools.GetFocusedEditorWindowTitle(), mDGXxESWAjMAkLfZpTJvHxfOKRsc._003C_003E9.PsLwiWhYqHjnDYsXpgFHrwQOJdsb, false));
				}
				QbUlgudJRGhEgfssJojiuSMsoDbX = list.ToArray();
				gQXFixQaGUgSIEHCXynsOouiNupbA();
			}

			public void gQXFixQaGUgSIEHCXynsOouiNupbA()
			{
				for (int i = 0; i < QbUlgudJRGhEgfssJojiuSMsoDbX.Length; i++)
				{
					QbUlgudJRGhEgfssJojiuSMsoDbX[i].Update();
				}
				fwXzcGFNsmIhcpNVOySEIzrLnvub = Time.frameCount;
			}

			public void LtCewBcfqwfXcpSkjGJKdkMFBTnac()
			{
				for (int i = 0; i < QbUlgudJRGhEgfssJojiuSMsoDbX.Length; i++)
				{
					QbUlgudJRGhEgfssJojiuSMsoDbX[i].TriggerEvent();
				}
			}
		}

		[Serializable]
		private sealed class PUGVvWXcwllbgIzFVAElHssNOpuA
		{
			public static readonly PUGVvWXcwllbgIzFVAElHssNOpuA _003C_003E9 = new PUGVvWXcwllbgIzFVAElHssNOpuA();

			public static Func<bool> _003C_003E9__222_0;

			internal void xYOsiKywGaVpVaIZnzLGzoQLAlYX(Exception P_0)
			{
				HandleCallbackException("", P_0);
			}

			internal void nMjvkIhFfhrIKqBQpzmEcYdAkEmw(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerConnectedEvent", P_0);
			}

			internal void IqZIJYTpSxsRKEOOPNdWQhvZYHur(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerPreDisconnectEvent", P_0);
			}

			internal void qJdGrFhFlhlcITTKGIdHYLdaGbnxA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ControllerDisconnectedEvent", P_0);
			}

			internal void HEVxMFZhDVGZQgcwcrArhJsIkDODA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InputSourceUpdateEvent", P_0);
			}

			internal void bPxEZWVXrMdgiWJfVggoZNTWkKam(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.EditorRecompileEvent", P_0);
			}

			internal void KrWWMLwEQnxGZbblQCfreKULsMOA(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.PreShutDownEvent", P_0);
			}

			internal void MoFpySSKEjQVieDPqTusREDsIftU(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.ShutDownEvent", P_0);
			}

			internal void eszEqsiduNvhBMDfomnGptgUElik(Exception P_0)
			{
				HandleCallbackException("Rewired.ReInput.InitializedEvent", P_0);
			}

			internal bool qNStIIIdmAlAqQJlGotISYwcDAhW()
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
		internal const string majorBranch = "U2022";

		private static InputManager_Base xknFermcIdfIAHgTczNAVdjLNQvSA;

		private static PlatformInputManager epwTnUVpwyQDOljotgHFjaZREHkeA;

		internal static WLWSoyDOcyXgCSdvhMUaohkmMBdU xKokvIxOzcvermvcSUcNKZIGamDS;

		internal static UgrefFwqJPPdjZGiGDKKCkBeaSXZ MRYlWddHEDKxegbDTAfXRjoQYitX;

		internal static msekTewPMCDuklrYGYDofSmhfOLW NUfAUcWLCevjCFPFNKrevODCEJAs;

		private static ControllerDataFiles KqnMeitEmbiOdilpDRDYwYdyjptQ;

		private static UserData jODnKgTyGBuOYuWSEDEtbledplkA;

		private static bool dwGMLwOYXMUjGwnokdxQQvWIdnun;

		private static ConfigVars FOVoFsNVVAcWPBEULNxvaZaHMnTU;

		private static UpdateLoopType yCBAIeaQwCdQRqUEmxyJpIhvBLfz;

		private static bool JwIEzBzVwoaJThQfJSjqGSeIRnNe;

		private static Platform JPEBRAbZnpxwieWJDZhLWgTbepvwA;

		private static WebplayerPlatform gEgZxKyxEHGPVpEEBjhwfbAqUdUmA;

		private static EditorPlatform QUHbLGYhWqMDhQIXnCFeQFkCxNgf;

		private static bool SrxafuRhXLWMFTMNgRXaOFRVTxTg;

		private static TimerAbs vdiUqbCytgcFoQthvkMsVOFvkTTJ;

		private static YBFDxCxnTUEpjVqNryAEKYqqCGRE eQBlPZDuiMCBbFmfVuOABhjvmMoE;

		private static string ZHORCkMUgYZDxVoEmMJciyQWSoli;

		private static bool PCbgWSRGpGiJRjlVbOnVKIunkLFCb;

		private static bool wgrLDRjCHwPpEJergBMAsTPfhhoJA;

		private static bool ggQaWjkrihfxyjXQaEDIilFdKEKIb;

		private static int lTywNZWHxOoneOUaxOcqvnhjaOqG;

		[CustomObfuscation(rename = false)]
		internal static int _id;

		private static int XouOYeADEcYJjiiheJdLjDEXBzrA;

		private static int yclJHvDMOyGvoZjRicBqggmhndjfA;

		private static bool lNgfEIeSjDKtdTccWbiFllZxmIEwA;

		private static readonly UnityTouch JmuLjySePNySFsFLowoMbSVjIYYE;

		private static readonly PlayerHelper CjByrsZFPmSizJASsrIZvTpLskEF;

		private static readonly ControllerHelper hWusaSBgJTtnLJgIENisaTqYMGql;

		private static readonly MappingHelper YvIYONdjgxcSVrcSCMdGVyaDPeLm;

		private static readonly TimeHelper GzderkzKtyEcfmxoVGfebuPoqNCW;

		private static readonly ConfigHelper QptRFGOrTDVTFyirMJOImvShMJvN;

		private static bbWzZUgbJGWmFyxwfTMjYxUjmGEo pVRSYoFWnNCkPAqNasfyrHLyzsOx;

		private static UserDataStore HyprgGzbBclCSvXwslDxtZyugmZU;

		private static IControllerAssigner OKTMwjbrpiGyuMjnJnhXwwJpkqwl;

		private static nWGZEfybJWKkvAqBWRRslDMpRAlo TjzVilcFVtXFaUNJnPvayrEVukCQ;

		private static SafeAction<ControllerStatusChangedEventArgs> BWNFEOCgygxbNGdvqGrqJgupUbVoA;

		private static SafeAction<ControllerStatusChangedEventArgs> eItFYsJpppabTBKwCdpiJcfTxWZT;

		private static SafeAction<ControllerStatusChangedEventArgs> JKdYjDPgeTpEiUxKopTciZfmMJiU;

		private static SafeAction QhhXaKBuSjifcZewMnQwFaYUZcgs;

		private static SafeAction iJJHhlvyVpivrxNjVoLShlgPhqjAA;

		private static SafeAction axtBMWXBGtgRDvMLhIvCavNjevQU;

		private static SafeAction yjArrVFrQTayIRuHyNHmutnFNwn;

		private static SafeAction waHxfaOLktNbsSNbLiBdflHknzkeA;

		[CustomObfuscation(rename = false)]
		private static Action<bool> _ApplicationFocusChangedEvent;

		private static Action ayAoCpzdAguvfYSoPHARWJJVObIw;

		private static Action<UpdateLoopType> atROjWhkvDsjdwiGqPWyZXETghHV;

		private static Action<UpdateLoopType> KoIbgXrwXbbhERLzPPgRFMbUUqNb;

		private static Action<UpdateLoopType> tADUVvjUITDnvAuhcFiRcFhDCwHo;

		private static Action CRzGFkGuSSPzsxLfFnIjKflmPXis;

		private static Action<bool> YJMZhZlVMDEuaPdMqulsWgxBaZLA;

		private static Action<bool> vPwjINIksAoNGQrxIVqjAGGLgUrS;

		private static Action<bool> ZRIhyuTRRKnklfirYOkbjlJtsDPM;

		private static Action<FullScreenMode> ZzeDqlOGUwVkVWlzopNKqcPtGjRj;

		private static Action QJiMZqwaBygiidzUxoroOxJMtWKrA;

		private static Action<bool> wyIKmuzlDGdDyecHOoKTsIyvwzJG;

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

		private static bbWzZUgbJGWmFyxwfTMjYxUjmGEo UplohBqXSyNgjFNIGhiJaauIEPSGA => pVRSYoFWnNCkPAqNasfyrHLyzsOx ?? (pVRSYoFWnNCkPAqNasfyrHLyzsOx = new bbWzZUgbJGWmFyxwfTMjYxUjmGEo(FOVoFsNVVAcWPBEULNxvaZaHMnTU.updateLoop));

		public static PlayerHelper players
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					vPkYCsbRyNQjtgaulPnxbeCYknte();
					return null;
				}
				return CjByrsZFPmSizJASsrIZvTpLskEF;
			}
		}

		public static ControllerHelper controllers
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					vPkYCsbRyNQjtgaulPnxbeCYknte();
					return null;
				}
				return hWusaSBgJTtnLJgIENisaTqYMGql;
			}
		}

		public static MappingHelper mapping
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					vPkYCsbRyNQjtgaulPnxbeCYknte();
					return null;
				}
				return YvIYONdjgxcSVrcSCMdGVyaDPeLm;
			}
		}

		public static UnityTouch touch
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					vPkYCsbRyNQjtgaulPnxbeCYknte();
					return null;
				}
				return JmuLjySePNySFsFLowoMbSVjIYYE;
			}
		}

		public static TimeHelper time
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					vPkYCsbRyNQjtgaulPnxbeCYknte();
					return null;
				}
				return GzderkzKtyEcfmxoVGfebuPoqNCW;
			}
		}

		public static IUserDataStore userDataStore
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					vPkYCsbRyNQjtgaulPnxbeCYknte();
					return null;
				}
				return HyprgGzbBclCSvXwslDxtZyugmZU;
			}
		}

		public static ConfigHelper configuration
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					vPkYCsbRyNQjtgaulPnxbeCYknte();
					return null;
				}
				return QptRFGOrTDVTFyirMJOImvShMJvN;
			}
		}

		public static string programVersion => 1 + "." + 1 + "." + 44 + "." + 0 + ".U2022";

		public static bool usingUnityInput => JwIEzBzVwoaJThQfJSjqGSeIRnNe;

		public static bool unityJoystickIdentificationRequired
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
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

		public static bool isReady => dwGMLwOYXMUjGwnokdxQQvWIdnun;

		[CustomObfuscation(rename = false)]
		internal static int id => _id;

		[CustomObfuscation(rename = false)]
		internal static bool initialized => dwGMLwOYXMUjGwnokdxQQvWIdnun;

		[CustomObfuscation(rename = false)]
		internal static UpdateLoopType currentUpdateLoop => yCBAIeaQwCdQRqUEmxyJpIhvBLfz;

		[CustomObfuscation(rename = false)]
		internal static ConfigVars configVars => FOVoFsNVVAcWPBEULNxvaZaHMnTU;

		[CustomObfuscation(rename = false)]
		internal static IConfigVars_Internal pluginConfigVars => FOVoFsNVVAcWPBEULNxvaZaHMnTU;

		[CustomObfuscation(rename = false)]
		internal static UserData UserData => jODnKgTyGBuOYuWSEDEtbledplkA;

		[CustomObfuscation(rename = false)]
		internal static Platform currentPlatform => JPEBRAbZnpxwieWJDZhLWgTbepvwA;

		[CustomObfuscation(rename = false)]
		internal static WebplayerPlatform webplayerPlatform => gEgZxKyxEHGPVpEEBjhwfbAqUdUmA;

		[CustomObfuscation(rename = false)]
		internal static EditorPlatform editorPlatform => QUHbLGYhWqMDhQIXnCFeQFkCxNgf;

		[CustomObfuscation(rename = false)]
		internal static bool checkNeverPressed
		{
			get
			{
				if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.Linux && JwIEzBzVwoaJThQfJSjqGSeIRnNe)
				{
					return true;
				}
				if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.OSX && (JwIEzBzVwoaJThQfJSjqGSeIRnNe || primaryInputManager.inputSourceType == InputSource.OSX))
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform && JwIEzBzVwoaJThQfJSjqGSeIRnNe)
				{
					return true;
				}
				if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.Webplayer && gEgZxKyxEHGPVpEEBjhwfbAqUdUmA == WebplayerPlatform.OSX)
				{
					return true;
				}
				if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.WebGL)
				{
					return true;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isEditor => QUHbLGYhWqMDhQIXnCFeQFkCxNgf != EditorPlatform.None;

		[CustomObfuscation(rename = false)]
		internal static Guid defaultHardwareJoystickMapGuid
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					return Guid.Empty;
				}
				return KqnMeitEmbiOdilpDRDYwYdyjptQ.defaultHardwareJoystickMapGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isRunningInEditMode => wgrLDRjCHwPpEJergBMAsTPfhhoJA;

		[CustomObfuscation(rename = false)]
		internal static bool isEditorPaused => UnityTools.externalTools.isEditorPaused;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTime => eQBlPZDuiMCBbFmfVuOABhjvmMoE.WFshRQqREIjeyjPSqtEaYrvNWtcG;

		[CustomObfuscation(rename = false)]
		internal static float unityUnscaledDeltaTimePrev => eQBlPZDuiMCBbFmfVuOABhjvmMoE.TWGjXEqKFaCFMdilQbYWxKwfCKLw;

		[CustomObfuscation(rename = false)]
		internal static double realTime
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					return 0.0;
				}
				return eQBlPZDuiMCBbFmfVuOABhjvmMoE.WabqJOVJajHbqLtEaARhrBRaaYTCA;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static int currentUnityFrame
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					return 0;
				}
				return TjzVilcFVtXFaUNJnPvayrEVukCQ.CkEJYuntznJKbAhfrcecdIDrpvCH;
			}
		}

		private static bool VgYlquvOkIzTVDsIutyDnSQiRcjn
		{
			get
			{
				if (UnityTools.unityVersion >= UnityTools.UnityVersion.UNITY_5_1)
				{
					return ZHORCkMUgYZDxVoEmMJciyQWSoli == "Game";
				}
				return ZHORCkMUgYZDxVoEmMJciyQWSoli == "UnityEditor.GameView";
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isAllowedEditorWindowFocused
		{
			get
			{
				if (FOVoFsNVVAcWPBEULNxvaZaHMnTU.allowInputInEditorSceneView && UnityTools.externalTools.IsEditorSceneViewFocused())
				{
					return true;
				}
				if (!ggQaWjkrihfxyjXQaEDIilFdKEKIb)
				{
					return VgYlquvOkIzTVDsIutyDnSQiRcjn;
				}
				return true;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isUnityEditorFocused
		{
			get
			{
				if (epwTnUVpwyQDOljotgHFjaZREHkeA is INativePlatformHelper nativePlatformHelper)
				{
					return nativePlatformHelper.isApplicationFocused;
				}
				return ggQaWjkrihfxyjXQaEDIilFdKEKIb;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool isWindowsStandaloneWebplayerOrEditorPlatform
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					return false;
				}
				if (!JwIEzBzVwoaJThQfJSjqGSeIRnNe)
				{
					return false;
				}
				if (JPEBRAbZnpxwieWJDZhLWgTbepvwA != Platform.Windows && (JPEBRAbZnpxwieWJDZhLWgTbepvwA != Platform.Webplayer || gEgZxKyxEHGPVpEEBjhwfbAqUdUmA != WebplayerPlatform.Windows))
				{
					return QUHbLGYhWqMDhQIXnCFeQFkCxNgf == EditorPlatform.Windows;
				}
				return true;
			}
		}

		private static bool lIKCTHjFkfOTtsDCEyESIZQCGKSH
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					return false;
				}
				if (!TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.value)
				{
					if (lNgfEIeSjDKtdTccWbiFllZxmIEwA)
					{
						return false;
					}
					if (!isEditor && !TjzVilcFVtXFaUNJnPvayrEVukCQ.gOCqWHjCtWvnpQSyRohmrqkICGUn.value)
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
				if (dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					return TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationIsFullScreen
		{
			get
			{
				if (dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					return TjzVilcFVtXFaUNJnPvayrEVukCQ.ORZDAbOLYkHsBAAOHqrCuUBNoyFF.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool applicationRunInBackground
		{
			get
			{
				if (dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					return TjzVilcFVtXFaUNJnPvayrEVukCQ.gOCqWHjCtWvnpQSyRohmrqkICGUn.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool timeScaleIsPaused
		{
			get
			{
				if (dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					return TjzVilcFVtXFaUNJnPvayrEVukCQ.CePfaremcevchwoWUPLlCSWXdPvS.value;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static InputManager_Base rewiredInputManager => xknFermcIdfIAHgTczNAVdjLNQvSA;

		[CustomObfuscation(rename = false)]
		internal static PlatformInputManager primaryInputManager
		{
			get
			{
				if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
				{
					vPkYCsbRyNQjtgaulPnxbeCYknte();
					return null;
				}
				return epwTnUVpwyQDOljotgHFjaZREHkeA.primaryInputManager;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static IControllerAssigner controllerAssigner
		{
			get
			{
				return OKTMwjbrpiGyuMjnJnhXwwJpkqwl;
			}
			set
			{
				OKTMwjbrpiGyuMjnJnhXwwJpkqwl = value;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static RewiredVersion rewiredVersion => new RewiredVersion(programVersion);

		[CustomObfuscation(rename = false)]
		internal static int timeScalePauseChangedCount => yclJHvDMOyGvoZjRicBqggmhndjfA;

		public static event Action<ControllerStatusChangedEventArgs> ControllerConnectedEvent
		{
			add
			{
				BWNFEOCgygxbNGdvqGrqJgupUbVoA += value;
			}
			remove
			{
				BWNFEOCgygxbNGdvqGrqJgupUbVoA -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerPreDisconnectEvent
		{
			add
			{
				eItFYsJpppabTBKwCdpiJcfTxWZT += value;
			}
			remove
			{
				eItFYsJpppabTBKwCdpiJcfTxWZT -= value;
			}
		}

		public static event Action<ControllerStatusChangedEventArgs> ControllerDisconnectedEvent
		{
			add
			{
				JKdYjDPgeTpEiUxKopTciZfmMJiU += value;
			}
			remove
			{
				JKdYjDPgeTpEiUxKopTciZfmMJiU -= value;
			}
		}

		public static event Action InputSourceUpdateEvent
		{
			add
			{
				QhhXaKBuSjifcZewMnQwFaYUZcgs += value;
			}
			remove
			{
				QhhXaKBuSjifcZewMnQwFaYUZcgs -= value;
			}
		}

		public static event Action EditorRecompileEvent
		{
			add
			{
				iJJHhlvyVpivrxNjVoLShlgPhqjAA += value;
			}
			remove
			{
				iJJHhlvyVpivrxNjVoLShlgPhqjAA -= value;
			}
		}

		public static event Action PreShutDownEvent
		{
			add
			{
				axtBMWXBGtgRDvMLhIvCavNjevQU += value;
			}
			remove
			{
				axtBMWXBGtgRDvMLhIvCavNjevQU -= value;
			}
		}

		public static event Action ShutDownEvent
		{
			add
			{
				yjArrVFrQTayIRuHyNHmutnFNwn += value;
			}
			remove
			{
				yjArrVFrQTayIRuHyNHmutnFNwn -= value;
			}
		}

		public static event Action InitializedEvent
		{
			add
			{
				waHxfaOLktNbsSNbLiBdflHknzkeA += value;
			}
			remove
			{
				waHxfaOLktNbsSNbLiBdflHknzkeA -= value;
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
				ayAoCpzdAguvfYSoPHARWJJVObIw = (Action)Delegate.Combine(ayAoCpzdAguvfYSoPHARWJJVObIw, value);
			}
			remove
			{
				ayAoCpzdAguvfYSoPHARWJJVObIw = (Action)Delegate.Remove(ayAoCpzdAguvfYSoPHARWJJVObIw, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> BeforeTimeManagerUpdateEvent
		{
			add
			{
				atROjWhkvDsjdwiGqPWyZXETghHV = (Action<UpdateLoopType>)Delegate.Combine(atROjWhkvDsjdwiGqPWyZXETghHV, value);
			}
			remove
			{
				atROjWhkvDsjdwiGqPWyZXETghHV = (Action<UpdateLoopType>)Delegate.Remove(atROjWhkvDsjdwiGqPWyZXETghHV, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateStartedEvent
		{
			add
			{
				KoIbgXrwXbbhERLzPPgRFMbUUqNb = (Action<UpdateLoopType>)Delegate.Combine(KoIbgXrwXbbhERLzPPgRFMbUUqNb, value);
			}
			remove
			{
				KoIbgXrwXbbhERLzPPgRFMbUUqNb = (Action<UpdateLoopType>)Delegate.Remove(KoIbgXrwXbbhERLzPPgRFMbUUqNb, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<UpdateLoopType> UpdateEndedEvent
		{
			add
			{
				tADUVvjUITDnvAuhcFiRcFhDCwHo = (Action<UpdateLoopType>)Delegate.Combine(tADUVvjUITDnvAuhcFiRcFhDCwHo, value);
			}
			remove
			{
				tADUVvjUITDnvAuhcFiRcFhDCwHo = (Action<UpdateLoopType>)Delegate.Remove(tADUVvjUITDnvAuhcFiRcFhDCwHo, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action LateUpdateEvent
		{
			add
			{
				CRzGFkGuSSPzsxLfFnIjKflmPXis = (Action)Delegate.Combine(CRzGFkGuSSPzsxLfFnIjKflmPXis, value);
			}
			remove
			{
				CRzGFkGuSSPzsxLfFnIjKflmPXis = (Action)Delegate.Remove(CRzGFkGuSSPzsxLfFnIjKflmPXis, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationIsFullScreenChangedEvent
		{
			add
			{
				YJMZhZlVMDEuaPdMqulsWgxBaZLA = (Action<bool>)Delegate.Combine(YJMZhZlVMDEuaPdMqulsWgxBaZLA, value);
			}
			remove
			{
				YJMZhZlVMDEuaPdMqulsWgxBaZLA = (Action<bool>)Delegate.Remove(YJMZhZlVMDEuaPdMqulsWgxBaZLA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> ApplicationRunInBackgroundChangedEvent
		{
			add
			{
				vPwjINIksAoNGQrxIVqjAGGLgUrS = (Action<bool>)Delegate.Combine(vPwjINIksAoNGQrxIVqjAGGLgUrS, value);
			}
			remove
			{
				vPwjINIksAoNGQrxIVqjAGGLgUrS = (Action<bool>)Delegate.Remove(vPwjINIksAoNGQrxIVqjAGGLgUrS, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> TimeScalePauseChangedEvent
		{
			add
			{
				ZRIhyuTRRKnklfirYOkbjlJtsDPM = (Action<bool>)Delegate.Combine(ZRIhyuTRRKnklfirYOkbjlJtsDPM, value);
			}
			remove
			{
				ZRIhyuTRRKnklfirYOkbjlJtsDPM = (Action<bool>)Delegate.Remove(ZRIhyuTRRKnklfirYOkbjlJtsDPM, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<FullScreenMode> ApplicationFullScreenModeChangedEvent
		{
			add
			{
				ZzeDqlOGUwVkVWlzopNKqcPtGjRj = (Action<FullScreenMode>)Delegate.Combine(ZzeDqlOGUwVkVWlzopNKqcPtGjRj, value);
			}
			remove
			{
				ZzeDqlOGUwVkVWlzopNKqcPtGjRj = (Action<FullScreenMode>)Delegate.Remove(ZzeDqlOGUwVkVWlzopNKqcPtGjRj, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action SceneLoadedEvent
		{
			add
			{
				QJiMZqwaBygiidzUxoroOxJMtWKrA = (Action)Delegate.Combine(QJiMZqwaBygiidzUxoroOxJMtWKrA, value);
			}
			remove
			{
				QJiMZqwaBygiidzUxoroOxJMtWKrA = (Action)Delegate.Remove(QJiMZqwaBygiidzUxoroOxJMtWKrA, value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static event Action<bool> EditorPauseChangedEvent
		{
			add
			{
				wyIKmuzlDGdDyecHOoKTsIyvwzJG = (Action<bool>)Delegate.Combine(wyIKmuzlDGdDyecHOoKTsIyvwzJG, value);
			}
			remove
			{
				wyIKmuzlDGdDyecHOoKTsIyvwzJG = (Action<bool>)Delegate.Remove(wyIKmuzlDGdDyecHOoKTsIyvwzJG, value);
			}
		}

		static ReInput()
		{
			ggQaWjkrihfxyjXQaEDIilFdKEKIb = true;
			lTywNZWHxOoneOUaxOcqvnhjaOqG = -1;
			_id = -1;
			XouOYeADEcYJjiiheJdLjDEXBzrA = 0;
			JmuLjySePNySFsFLowoMbSVjIYYE = UnityTouch.EShLMNSIMeGeAlUGzhhtbDsFmgHS;
			CjByrsZFPmSizJASsrIZvTpLskEF = PlayerHelper.ghLYlFFUjPcDucBnSdyVEneCOQsW;
			hWusaSBgJTtnLJgIENisaTqYMGql = ControllerHelper.YorxuNVUVPjNOlbshCeyhTsgCtAkA;
			YvIYONdjgxcSVrcSCMdGVyaDPeLm = MappingHelper.JuXrblwUXRKmthIlMiiNhNFfLqyt;
			GzderkzKtyEcfmxoVGfebuPoqNCW = TimeHelper.jHTboGyiZdqhlWytuLKOBjaBISvdA;
			QptRFGOrTDVTFyirMJOImvShMJvN = ConfigHelper.uqwOPfUqHKjZytALiFsNYuZzhTKL;
			BWNFEOCgygxbNGdvqGrqJgupUbVoA = new SafeAction<ControllerStatusChangedEventArgs>(PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.nMjvkIhFfhrIKqBQpzmEcYdAkEmw);
			eItFYsJpppabTBKwCdpiJcfTxWZT = new SafeAction<ControllerStatusChangedEventArgs>(PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.IqZIJYTpSxsRKEOOPNdWQhvZYHur);
			JKdYjDPgeTpEiUxKopTciZfmMJiU = new SafeAction<ControllerStatusChangedEventArgs>(PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.qJdGrFhFlhlcITTKGIdHYLdaGbnxA);
			QhhXaKBuSjifcZewMnQwFaYUZcgs = new SafeAction(PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.HEVxMFZhDVGZQgcwcrArhJsIkDODA);
			iJJHhlvyVpivrxNjVoLShlgPhqjAA = new SafeAction(PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.bPxEZWVXrMdgiWJfVggoZNTWkKam);
			axtBMWXBGtgRDvMLhIvCavNjevQU = new SafeAction(PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.KrWWMLwEQnxGZbblQCfreKULsMOA);
			yjArrVFrQTayIRuHyNHmutnFNwn = new SafeAction(PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.MoFpySSKEjQVieDPqTusREDsIftU);
			waHxfaOLktNbsSNbLiBdflHknzkeA = new SafeAction(PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.eszEqsiduNvhBMDfomnGptgUElik);
			SafeDelegate.S_ExceptionHandler = PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.xYOsiKywGaVpVaIZnzLGzoQLAlYX;
		}

		public static void Reset()
		{
			if (dwGMLwOYXMUjGwnokdxQQvWIdnun && !(xknFermcIdfIAHgTczNAVdjLNQvSA == null))
			{
				xknFermcIdfIAHgTczNAVdjLNQvSA.ResetAll();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsInputAllowed(ControllerType controllerType)
		{
			if (!lIKCTHjFkfOTtsDCEyESIZQCGKSH)
			{
				return false;
			}
			if (QUHbLGYhWqMDhQIXnCFeQFkCxNgf != EditorPlatform.None && (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse))
			{
				if (lNgfEIeSjDKtdTccWbiFllZxmIEwA)
				{
					if (!TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.value)
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

		private static void GaNCxKHOUufiAgKLHiSSqmhOltTyb()
		{
			JPEBRAbZnpxwieWJDZhLWgTbepvwA = UnityTools.platform;
			gEgZxKyxEHGPVpEEBjhwfbAqUdUmA = UnityTools.webplayerPlatform;
			QUHbLGYhWqMDhQIXnCFeQFkCxNgf = UnityTools.editorPlatform;
		}

		internal static void EJBcKyltSMwimxGwvjdfoVwAtNVM(InputManager_Base P_0, Func<ConfigVars, object> P_1, ConfigVars P_2, ControllerDataFiles P_3, UserData P_4, UnityTools.RwimbXPewXcmyPjTsMHTxYekEIoj P_5, Action<Platform> P_6)
		{
			try
			{
				UnityTools.suuYxLrSpAboTHHojwxOwzMmIykN(P_5);
				_id = XouOYeADEcYJjiiheJdLjDEXBzrA;
				XouOYeADEcYJjiiheJdLjDEXBzrA++;
				dwGMLwOYXMUjGwnokdxQQvWIdnun = true;
				PCbgWSRGpGiJRjlVbOnVKIunkLFCb = true;
				wgrLDRjCHwPpEJergBMAsTPfhhoJA = UnityTools.isEditor && !Application.isPlaying;
				if (UnityTools.isEditor)
				{
					CheckRewiredVersionCompatibility();
				}
				xknFermcIdfIAHgTczNAVdjLNQvSA = P_0;
				FOVoFsNVVAcWPBEULNxvaZaHMnTU = P_2;
				GaNCxKHOUufiAgKLHiSSqmhOltTyb();
				if (P_2.logToScreen)
				{
					Logger.logToScreen = true;
				}
				UnityTools.externalTools.EditorPausedStateChangedEvent += EQySABIwgmznECUuITGYNlFjpFKC;
				KqnMeitEmbiOdilpDRDYwYdyjptQ = P_3;
				jODnKgTyGBuOYuWSEDEtbledplkA = P_4;
				P_4.PLfEyuYCVptvXshZdykOFkUTrMQx();
				ThreadSafeUnityInput.Initialize();
				TjzVilcFVtXFaUNJnPvayrEVukCQ = new nWGZEfybJWKkvAqBWRRslDMpRAlo();
				TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.Set(ggQaWjkrihfxyjXQaEDIilFdKEKIb);
				TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.Use();
				if (QUHbLGYhWqMDhQIXnCFeQFkCxNgf != EditorPlatform.None)
				{
					TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.getValueDelegate = PUGVvWXcwllbgIzFVAElHssNOpuA._003C_003E9.qNStIIIdmAlAqQJlGotISYwcDAhW;
					if (wgrLDRjCHwPpEJergBMAsTPfhhoJA)
					{
						ggQaWjkrihfxyjXQaEDIilFdKEKIb = VgYlquvOkIzTVDsIutyDnSQiRcjn;
					}
					TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.Set(isUnityEditorFocused && isAllowedEditorWindowFocused);
				}
				CTGuVUacUcSOMVWghXfxrjfyTwxc();
				vdiUqbCytgcFoQthvkMsVOFvkTTJ = new TimerAbs(1.0);
				eQBlPZDuiMCBbFmfVuOABhjvmMoE = new YBFDxCxnTUEpjVqNryAEKYqqCGRE();
				LoKEjQKzZCvDEnnOdMyppFIDotDxA(P_1, P_5, P_6);
				xKokvIxOzcvermvcSUcNKZIGamDS = new WLWSoyDOcyXgCSdvhMUaohkmMBdU(P_4.GetActions_Copy());
				MRYlWddHEDKxegbDTAfXRjoQYitX = new UgrefFwqJPPdjZGiGDKKCkBeaSXZ(P_2, epwTnUVpwyQDOljotgHFjaZREHkeA);
				NUfAUcWLCevjCFPFNKrevODCEJAs = new msekTewPMCDuklrYGYDofSmhfOLW(P_2);
				epwTnUVpwyQDOljotgHFjaZREHkeA.DeviceConnectedEvent += UGBCUmHJKZmhIUVuqgLvitiRIasAb;
				epwTnUVpwyQDOljotgHFjaZREHkeA.DeviceDisconnectedEvent += NTbwjwEipJAsBJeqPcXRDVaJGpQAA;
				epwTnUVpwyQDOljotgHFjaZREHkeA.UpdateControllerInfoEvent += BEwunqnIEYEphFsLnLNlgPEJWDCRB;
				MRYlWddHEDKxegbDTAfXRjoQYitX.wGsUXUWPerTHhxpGICYuOTegATHKA += TvWylYTqhuKMyCNhqSHdERCKxpnL;
				MRYlWddHEDKxegbDTAfXRjoQYitX.GnTPGYSKpqxHjXdNRwoKopMXccyG += NUfAUcWLCevjCFPFNKrevODCEJAs.WOAYxuoAOtJKAgsypnLBGESablou;
				ThreadSafeUnityInput.PostInitialize();
				NiZeQZrwrhYyAfYNOrEucpypqqhe();
				ThreadSafeUnityInput.PostInitialize2();
				HyprgGzbBclCSvXwslDxtZyugmZU = UnityTools.GetComponent<UserDataStore>(xknFermcIdfIAHgTczNAVdjLNQvSA);
				if (HyprgGzbBclCSvXwslDxtZyugmZU != null)
				{
					HyprgGzbBclCSvXwslDxtZyugmZU.Initialize();
				}
				HajfIkIhurlUoIdXybxXadASppbw();
				PCbgWSRGpGiJRjlVbOnVKIunkLFCb = false;
				if (wgrLDRjCHwPpEJergBMAsTPfhhoJA)
				{
					Logger.Log("Rewired is running in Edit mode.");
				}
				if (waHxfaOLktNbsSNbLiBdflHknzkeA != null)
				{
					waHxfaOLktNbsSNbLiBdflHknzkeA.Invoke();
				}
			}
			catch (Exception)
			{
				dwGMLwOYXMUjGwnokdxQQvWIdnun = false;
				PCbgWSRGpGiJRjlVbOnVKIunkLFCb = false;
				throw;
			}
		}

		internal static void KpitYeLAXyYTjUItMbewCXdoUGvm()
		{
			if (eQBlPZDuiMCBbFmfVuOABhjvmMoE != null)
			{
				eQBlPZDuiMCBbFmfVuOABhjvmMoE.lCSaZBatLiGFtQNeliOOHRHexDcVB();
			}
			if (configVars.deferControllerConnectedEventsOnStart)
			{
				for (int i = 0; i < MRYlWddHEDKxegbDTAfXRjoQYitX.obOzcVKdOQfqEztHMjSkGgIZihnGb; i++)
				{
					Joystick joystick = MRYlWddHEDKxegbDTAfXRjoQYitX.ikOjVBXpdongTItkQQnQWQZRdaPN[i];
					VDnbnuVkfqvDYWmmcBDUGyBVfynn(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		internal static void sPWClwLbjMnpowjpQaYxEMNULAdq(UpdateLoopType P_0)
		{
			if (dwGMLwOYXMUjGwnokdxQQvWIdnun)
			{
				IiMAJGkIZxSmSMZDxwfsCJtscoIGA(P_0);
				if ((uint)P_0 <= 1u)
				{
					lkaLlHDmLOgFyfNCXpIPPyTANwvCA();
				}
			}
		}

		private static void IiMAJGkIZxSmSMZDxwfsCJtscoIGA(UpdateLoopType P_0)
		{
			if (TjzVilcFVtXFaUNJnPvayrEVukCQ != null)
			{
				TjzVilcFVtXFaUNJnPvayrEVukCQ.gQXFixQaGUgSIEHCXynsOouiNupbA();
			}
			Action<UpdateLoopType> action = atROjWhkvDsjdwiGqPWyZXETghHV;
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
			eQBlPZDuiMCBbFmfVuOABhjvmMoE.umteXFKqWeoAszBqCNEemQKxhbTf(P_0);
		}

		private static void lkaLlHDmLOgFyfNCXpIPPyTANwvCA()
		{
			int frameCount = Time.frameCount;
			if (lTywNZWHxOoneOUaxOcqvnhjaOqG == frameCount)
			{
				return;
			}
			lTywNZWHxOoneOUaxOcqvnhjaOqG = frameCount;
			ThreadSafeUnityInput.Update();
			Action action = ayAoCpzdAguvfYSoPHARWJJVObIw;
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

		internal static void gOrxjgpieEqVEQcragNkDuEFHNSE(UpdateLoopType P_0)
		{
			if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
			{
				return;
			}
			if (yCBAIeaQwCdQRqUEmxyJpIhvBLfz != P_0)
			{
				yCBAIeaQwCdQRqUEmxyJpIhvBLfz = P_0;
			}
			if (editorPlatform != EditorPlatform.None)
			{
				ZHORCkMUgYZDxVoEmMJciyQWSoli = TjzVilcFVtXFaUNJnPvayrEVukCQ.LagdOXCiKcGjReTDvBkeNAzVPMJSA.value;
			}
			if (SrxafuRhXLWMFTMNgRXaOFRVTxTg)
			{
				if (vdiUqbCytgcFoQthvkMsVOFvkTTJ.Update())
				{
					SrxafuRhXLWMFTMNgRXaOFRVTxTg = false;
					vdiUqbCytgcFoQthvkMsVOFvkTTJ.Clear();
				}
				else
				{
					UplohBqXSyNgjFNIGhiJaauIEPSGA.wSKdYzCZTkwtADDTPynbwZDkCZwVA(P_0);
				}
			}
			TjzVilcFVtXFaUNJnPvayrEVukCQ.LtCewBcfqwfXcpSkjGJKdkMFBTnac();
			Action<UpdateLoopType> koIbgXrwXbbhERLzPPgRFMbUUqNb = KoIbgXrwXbbhERLzPPgRFMbUUqNb;
			if (koIbgXrwXbbhERLzPPgRFMbUUqNb != null)
			{
				try
				{
					koIbgXrwXbbhERLzPPgRFMbUUqNb(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.UpdateStartedEvent", exception);
				}
			}
			epwTnUVpwyQDOljotgHFjaZREHkeA.Update(P_0);
			if (QhhXaKBuSjifcZewMnQwFaYUZcgs != null)
			{
				QhhXaKBuSjifcZewMnQwFaYUZcgs.Invoke();
			}
			MRYlWddHEDKxegbDTAfXRjoQYitX.DOwxRxMOYvFkbGCciqpJHYssufZXA(P_0);
			Action<UpdateLoopType> action = tADUVvjUITDnvAuhcFiRcFhDCwHo;
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

		internal static void MgrpWYbisZVmELXIeIAaYqPsXbg()
		{
			Action cRzGFkGuSSPzsxLfFnIjKflmPXis = CRzGFkGuSSPzsxLfFnIjKflmPXis;
			if (cRzGFkGuSSPzsxLfFnIjKflmPXis != null)
			{
				try
				{
					cRzGFkGuSSPzsxLfFnIjKflmPXis();
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
			if (dwGMLwOYXMUjGwnokdxQQvWIdnun && wgrLDRjCHwPpEJergBMAsTPfhhoJA)
			{
				sPWClwLbjMnpowjpQaYxEMNULAdq(UpdateLoopType.Update);
				gOrxjgpieEqVEQcragNkDuEFHNSE(UpdateLoopType.Update);
				MgrpWYbisZVmELXIeIAaYqPsXbg();
			}
		}

		internal static void utRAnrccLHhjToSlNzBrfcqimUlJA()
		{
			if (axtBMWXBGtgRDvMLhIvCavNjevQU != null)
			{
				axtBMWXBGtgRDvMLhIvCavNjevQU.Invoke();
			}
			if (epwTnUVpwyQDOljotgHFjaZREHkeA != null)
			{
				epwTnUVpwyQDOljotgHFjaZREHkeA.OnDestroy();
			}
			WIreIscJUnPwrEbAaXgpqhibDeHAb();
			if (yjArrVFrQTayIRuHyNHmutnFNwn != null)
			{
				yjArrVFrQTayIRuHyNHmutnFNwn.Invoke();
				yjArrVFrQTayIRuHyNHmutnFNwn = null;
			}
		}

		internal static void MQiMrFEmWWYtQzKUgbLrcHqnTkMhA()
		{
			if (iJJHhlvyVpivrxNjVoLShlgPhqjAA != null)
			{
				iJJHhlvyVpivrxNjVoLShlgPhqjAA.Invoke();
			}
		}

		internal static void fkHSNGNeUrRjLXGQRpJOBdsJAVtS(bool P_0)
		{
			ggQaWjkrihfxyjXQaEDIilFdKEKIb = P_0;
			if (QUHbLGYhWqMDhQIXnCFeQFkCxNgf == EditorPlatform.None && dwGMLwOYXMUjGwnokdxQQvWIdnun)
			{
				TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.Set(P_0);
				TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.TriggerEvent();
			}
		}

		internal static void IDqdnchXrcoSwBfsXceOKVGgSCrK()
		{
			if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
			{
				return;
			}
			Action qJiMZqwaBygiidzUxoroOxJMtWKrA = QJiMZqwaBygiidzUxoroOxJMtWKrA;
			if (qJiMZqwaBygiidzUxoroOxJMtWKrA == null)
			{
				return;
			}
			try
			{
				qJiMZqwaBygiidzUxoroOxJMtWKrA();
			}
			catch (Exception exception)
			{
				HandleCallbackException("ReInput.SceneLoadedEvent", exception);
			}
		}

		[CustomObfuscation(rename = false)]
		internal static HardwareJoystickMap_InputManager GetHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
		{
			return KqnMeitEmbiOdilpDRDYwYdyjptQ.igqENTKAdXRUEXJsrMcOCqhZClAr(bridgedController);
		}

		internal static HardwareJoystickMap MnZKOuxsGQgkNMhlMJfTFjrzgeMv(Guid P_0)
		{
			return KqnMeitEmbiOdilpDRDYwYdyjptQ.GetHardwareJoystickMap(P_0);
		}

		internal static HardwareJoystickTemplateMap RErcwJFraWnCUyvOExbBHYmECOoxA(Guid P_0)
		{
			return KqnMeitEmbiOdilpDRDYwYdyjptQ.GetJoystickTemplate(P_0);
		}

		internal static IHardwareControllerTemplateMap LWvlwHivxWHAlXYJITKbLqAajNas(Guid P_0)
		{
			return KqnMeitEmbiOdilpDRDYwYdyjptQ.GetControllerTemplate(P_0);
		}

		internal static IList<HardwareJoystickTemplateMap> MESYpwQOnBfnKRZLJcWinuTHiKJA(Guid P_0)
		{
			HardwareJoystickMap hardwareJoystickMap = KqnMeitEmbiOdilpDRDYwYdyjptQ.GetHardwareJoystickMap(P_0);
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
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = RErcwJFraWnCUyvOExbBHYmECOoxA(guid);
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
			return MRYlWddHEDKxegbDTAfXRjoQYitX.XvvpptongKtzGONyHhHDeRVbyuOP();
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

		internal static void rLJGDVbHUCDeRCzaSLegyhtrLIBm()
		{
			if (dwGMLwOYXMUjGwnokdxQQvWIdnun)
			{
				HajfIkIhurlUoIdXybxXadASppbw();
			}
		}

		[CustomObfuscation(rename = false)]
		internal static void CheckRewiredVersionCompatibility()
		{
			if (UnityTools.unityVersionObj != null && 2022 != UnityTools.unityVersionObj.major)
			{
				XZTbNjUkZWGokoDYXkJcxxntPIXs();
			}
		}

		internal static float vdXdgLnemwXdeeSuUzVeNQqixkId()
		{
			return TjzVilcFVtXFaUNJnPvayrEVukCQ.JntBGOOSXqpdYZGlJfBmGTmVKAow.value;
		}

		[CustomObfuscation(rename = false)]
		internal static bool CheckInitialized()
		{
			if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
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

		private static void NiZeQZrwrhYyAfYNOrEucpypqqhe()
		{
			NUfAUcWLCevjCFPFNKrevODCEJAs.yAiJybyDrkVhPlGUzbHLIsXFkuuR();
			MRYlWddHEDKxegbDTAfXRjoQYitX.tuRbdYelwtrBJOgOSotFKvwDQumk(epwTnUVpwyQDOljotgHFjaZREHkeA.GetInputDataUpdateDelegate(), jODnKgTyGBuOYuWSEDEtbledplkA.GetInputBehaviors_Copy());
			epwTnUVpwyQDOljotgHFjaZREHkeA.Initialize();
		}

		private static void WIreIscJUnPwrEbAaXgpqhibDeHAb()
		{
			if (xknFermcIdfIAHgTczNAVdjLNQvSA != null)
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(xknFermcIdfIAHgTczNAVdjLNQvSA);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					componentsInSelfAndChildren[i].Deinitialize();
				}
			}
			xknFermcIdfIAHgTczNAVdjLNQvSA = null;
			epwTnUVpwyQDOljotgHFjaZREHkeA = null;
			xKokvIxOzcvermvcSUcNKZIGamDS = null;
			if (MRYlWddHEDKxegbDTAfXRjoQYitX != null)
			{
				MRYlWddHEDKxegbDTAfXRjoQYitX.Dispose();
			}
			MRYlWddHEDKxegbDTAfXRjoQYitX = null;
			NUfAUcWLCevjCFPFNKrevODCEJAs = null;
			KqnMeitEmbiOdilpDRDYwYdyjptQ = null;
			jODnKgTyGBuOYuWSEDEtbledplkA = null;
			OKTMwjbrpiGyuMjnJnhXwwJpkqwl = null;
			dwGMLwOYXMUjGwnokdxQQvWIdnun = false;
			FOVoFsNVVAcWPBEULNxvaZaHMnTU = null;
			yCBAIeaQwCdQRqUEmxyJpIhvBLfz = UpdateLoopType.Update;
			JwIEzBzVwoaJThQfJSjqGSeIRnNe = false;
			JPEBRAbZnpxwieWJDZhLWgTbepvwA = Platform.Windows;
			gEgZxKyxEHGPVpEEBjhwfbAqUdUmA = WebplayerPlatform.None;
			QUHbLGYhWqMDhQIXnCFeQFkCxNgf = EditorPlatform.None;
			SrxafuRhXLWMFTMNgRXaOFRVTxTg = false;
			vdiUqbCytgcFoQthvkMsVOFvkTTJ = null;
			eQBlPZDuiMCBbFmfVuOABhjvmMoE = null;
			ZHORCkMUgYZDxVoEmMJciyQWSoli = null;
			lNgfEIeSjDKtdTccWbiFllZxmIEwA = false;
			wgrLDRjCHwPpEJergBMAsTPfhhoJA = false;
			ggQaWjkrihfxyjXQaEDIilFdKEKIb = true;
			lTywNZWHxOoneOUaxOcqvnhjaOqG = -1;
			_id = -1;
			yclJHvDMOyGvoZjRicBqggmhndjfA = 0;
			BWNFEOCgygxbNGdvqGrqJgupUbVoA.Clear();
			eItFYsJpppabTBKwCdpiJcfTxWZT.Clear();
			JKdYjDPgeTpEiUxKopTciZfmMJiU.Clear();
			QhhXaKBuSjifcZewMnQwFaYUZcgs.Clear();
			iJJHhlvyVpivrxNjVoLShlgPhqjAA.Clear();
			_ApplicationFocusChangedEvent = null;
			YJMZhZlVMDEuaPdMqulsWgxBaZLA = null;
			vPwjINIksAoNGQrxIVqjAGGLgUrS = null;
			ZzeDqlOGUwVkVWlzopNKqcPtGjRj = null;
			ZRIhyuTRRKnklfirYOkbjlJtsDPM = null;
			ayAoCpzdAguvfYSoPHARWJJVObIw = null;
			KoIbgXrwXbbhERLzPPgRFMbUUqNb = null;
			tADUVvjUITDnvAuhcFiRcFhDCwHo = null;
			CRzGFkGuSSPzsxLfFnIjKflmPXis = null;
			axtBMWXBGtgRDvMLhIvCavNjevQU = null;
			QJiMZqwaBygiidzUxoroOxJMtWKrA = null;
			wyIKmuzlDGdDyecHOoKTsIyvwzJG = null;
			LnoddUCOldBhAIUuEitiwOHPZzGA();
			TjzVilcFVtXFaUNJnPvayrEVukCQ = null;
			ThreadSafeUnityInput.Deinitialize();
			if (UnityTools.externalTools != null)
			{
				UnityTools.externalTools.EditorPausedStateChangedEvent -= EQySABIwgmznECUuITGYNlFjpFKC;
			}
		}

		private static void IihfAjjyzOdGNjaLFMvdVIHxTJni(string P_0 = null)
		{
			string text = ((P_0 == null) ? "This function" : P_0);
			Logger.LogError(text + " can only be called in Play mode!");
		}

		private static void jugaBqqwsjCmhKCzHLvizmdfubLdA()
		{
			if (!SrxafuRhXLWMFTMNgRXaOFRVTxTg)
			{
				SrxafuRhXLWMFTMNgRXaOFRVTxTg = true;
				UplohBqXSyNgjFNIGhiJaauIEPSGA.ilKAVgBbkmjqBfvThPTxUvZQoSlFB();
				UplohBqXSyNgjFNIGhiJaauIEPSGA.KBfELZTTVAuSiIdjtUCyLIEQPRyl();
			}
			vdiUqbCytgcFoQthvkMsVOFvkTTJ.Start();
		}

		private static void vPkYCsbRyNQjtgaulPnxbeCYknte()
		{
			Logger.LogError("Rewired is not initialized. Do you have a Rewired Input Manager in the scene and enabled?");
		}

		private static void UGBCUmHJKZmhIUVuqgLvitiRIasAb(BridgedController P_0)
		{
			if (P_0.sourceJoystick == null)
			{
				return;
			}
			MRYlWddHEDKxegbDTAfXRjoQYitX.rOeYlZWmWxcGQLDmWqlyiEFwIURm(P_0);
			Joystick joystick = MRYlWddHEDKxegbDTAfXRjoQYitX.bGYAryEoCaDPuVhlQuucCjbIkmFG(P_0.sourceJoystick.rewiredId);
			if (joystick != null)
			{
				NUfAUcWLCevjCFPFNKrevODCEJAs.UINXRmiKSWCitDCAPLlzcdFvhNSeA(joystick);
				if (!configVars.deferControllerConnectedEventsOnStart || !PCbgWSRGpGiJRjlVbOnVKIunkLFCb)
				{
					VDnbnuVkfqvDYWmmcBDUGyBVfynn(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void NTbwjwEipJAsBJeqPcXRDVaJGpQAA(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				Joystick joystick = MRYlWddHEDKxegbDTAfXRjoQYitX.bGYAryEoCaDPuVhlQuucCjbIkmFG(P_0.rewiredId);
				if (joystick != null)
				{
					MRYlWddHEDKxegbDTAfXRjoQYitX.aKMCjrtXNIYnspgofYkkVGXkxjmX(P_0.rewiredId);
					mqBRpSiErEaJEfiSpIRKIooHhkbHA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
				}
			}
		}

		private static void VDnbnuVkfqvDYWmmcBDUGyBVfynn(ControllerStatusChangedEventArgs P_0)
		{
			if (BWNFEOCgygxbNGdvqGrqJgupUbVoA != null)
			{
				BWNFEOCgygxbNGdvqGrqJgupUbVoA.Invoke(P_0);
			}
		}

		private static void TvWylYTqhuKMyCNhqSHdERCKxpnL(ControllerStatusChangedEventArgs P_0)
		{
			if (eItFYsJpppabTBKwCdpiJcfTxWZT != null)
			{
				eItFYsJpppabTBKwCdpiJcfTxWZT.Invoke(P_0);
			}
		}

		private static void mqBRpSiErEaJEfiSpIRKIooHhkbHA(ControllerStatusChangedEventArgs P_0)
		{
			if (JKdYjDPgeTpEiUxKopTciZfmMJiU != null)
			{
				JKdYjDPgeTpEiUxKopTciZfmMJiU.Invoke(P_0);
			}
		}

		private static void BEwunqnIEYEphFsLnLNlgPEJWDCRB(UpdateControllerInfoEventArgs P_0)
		{
			MRYlWddHEDKxegbDTAfXRjoQYitX.NDrcszHtvXXAjRglcGmSLHUNLPIhb(P_0);
		}

		private static void QaaGiizsOuWAbMniciubRVRXoEHd(bool P_0)
		{
			if (!dwGMLwOYXMUjGwnokdxQQvWIdnun)
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

		private static void AFUcHqKxCSqchmxeSxVsfXTvIedWA(bool P_0)
		{
			Action<bool> yJMZhZlVMDEuaPdMqulsWgxBaZLA = YJMZhZlVMDEuaPdMqulsWgxBaZLA;
			if (yJMZhZlVMDEuaPdMqulsWgxBaZLA != null)
			{
				try
				{
					yJMZhZlVMDEuaPdMqulsWgxBaZLA(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationIsFullScreenChangedEvent", exception);
				}
			}
		}

		private static void DDfbbCBjBlHqyVmhRIgpvOaAwnzz(int P_0)
		{
			if (ZzeDqlOGUwVkVWlzopNKqcPtGjRj != null)
			{
				try
				{
					ZzeDqlOGUwVkVWlzopNKqcPtGjRj((FullScreenMode)P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.ApplicationFullScreenModeChangedEvent", exception);
				}
			}
		}

		private static void ccAzayrAdxLvAWoDYbVefelVDNJv(bool P_0)
		{
			Action<bool> action = vPwjINIksAoNGQrxIVqjAGGLgUrS;
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

		private static void sSoldFlqfvXFNnecUjOJBFPbhHZN(bool P_0)
		{
			yclJHvDMOyGvoZjRicBqggmhndjfA++;
			Action<bool> zRIhyuTRRKnklfirYOkbjlJtsDPM = ZRIhyuTRRKnklfirYOkbjlJtsDPM;
			if (zRIhyuTRRKnklfirYOkbjlJtsDPM != null)
			{
				try
				{
					zRIhyuTRRKnklfirYOkbjlJtsDPM(P_0);
				}
				catch (Exception exception)
				{
					HandleCallbackException("ReInput.TimeScalePauseChangedEvent", exception);
				}
			}
		}

		private static void CTGuVUacUcSOMVWghXfxrjfyTwxc()
		{
			if (TjzVilcFVtXFaUNJnPvayrEVukCQ != null)
			{
				LnoddUCOldBhAIUuEitiwOHPZzGA();
				TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.ChangedEvent += QaaGiizsOuWAbMniciubRVRXoEHd;
				TjzVilcFVtXFaUNJnPvayrEVukCQ.ORZDAbOLYkHsBAAOHqrCuUBNoyFF.ChangedEvent += AFUcHqKxCSqchmxeSxVsfXTvIedWA;
				TjzVilcFVtXFaUNJnPvayrEVukCQ.gOCqWHjCtWvnpQSyRohmrqkICGUn.ChangedEvent += ccAzayrAdxLvAWoDYbVefelVDNJv;
				TjzVilcFVtXFaUNJnPvayrEVukCQ.kHClwbbrNeQPVIfEuEwIjLonaWFn.ChangedEvent += DDfbbCBjBlHqyVmhRIgpvOaAwnzz;
				TjzVilcFVtXFaUNJnPvayrEVukCQ.CePfaremcevchwoWUPLlCSWXdPvS.ChangedEvent += sSoldFlqfvXFNnecUjOJBFPbhHZN;
			}
		}

		private static void LnoddUCOldBhAIUuEitiwOHPZzGA()
		{
			if (TjzVilcFVtXFaUNJnPvayrEVukCQ != null)
			{
				TjzVilcFVtXFaUNJnPvayrEVukCQ.ihdQPRxcmXUAhhpJHszEmddPaFKP.ChangedEvent -= QaaGiizsOuWAbMniciubRVRXoEHd;
				TjzVilcFVtXFaUNJnPvayrEVukCQ.ORZDAbOLYkHsBAAOHqrCuUBNoyFF.ChangedEvent -= AFUcHqKxCSqchmxeSxVsfXTvIedWA;
				TjzVilcFVtXFaUNJnPvayrEVukCQ.gOCqWHjCtWvnpQSyRohmrqkICGUn.ChangedEvent -= ccAzayrAdxLvAWoDYbVefelVDNJv;
				TjzVilcFVtXFaUNJnPvayrEVukCQ.kHClwbbrNeQPVIfEuEwIjLonaWFn.ChangedEvent -= DDfbbCBjBlHqyVmhRIgpvOaAwnzz;
				TjzVilcFVtXFaUNJnPvayrEVukCQ.CePfaremcevchwoWUPLlCSWXdPvS.ChangedEvent -= sSoldFlqfvXFNnecUjOJBFPbhHZN;
			}
		}

		private static void EQySABIwgmznECUuITGYNlFjpFKC(bool P_0)
		{
			Action<bool> action = wyIKmuzlDGdDyecHOoKTsIyvwzJG;
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

		private static void LoKEjQKzZCvDEnnOdMyppFIDotDxA(Func<ConfigVars, object> P_0, UnityTools.RwimbXPewXcmyPjTsMHTxYekEIoj P_1, Action<Platform> P_2)
		{
			bool flag = false;
			if (P_1.EiFNIxeCHHTSmcvvKPZchOPlMNnG != P_1.gyKIPpQGdyFiDXnLgdbarTkEWvbS)
			{
				UnityTools.RwimbXPewXcmyPjTsMHTxYekEIoj rwimbXPewXcmyPjTsMHTxYekEIoj = P_1;
				rwimbXPewXcmyPjTsMHTxYekEIoj.EiFNIxeCHHTSmcvvKPZchOPlMNnG = P_1.gyKIPpQGdyFiDXnLgdbarTkEWvbS;
				UnityTools.suuYxLrSpAboTHHojwxOwzMmIykN(rwimbXPewXcmyPjTsMHTxYekEIoj);
				P_2(rwimbXPewXcmyPjTsMHTxYekEIoj.gyKIPpQGdyFiDXnLgdbarTkEWvbS);
				GaNCxKHOUufiAgKLHiSSqmhOltTyb();
				flag = true;
			}
			if (!configVars.DoesPlatformUseFallback(P_1.gyKIPpQGdyFiDXnLgdbarTkEWvbS, P_1.loWgxsaiyCwxTlAxuvYVKzvDBujR, isEditor) && !configVars.DoesPlatformUseFallback(P_1.EiFNIxeCHHTSmcvvKPZchOPlMNnG, P_1.loWgxsaiyCwxTlAxuvYVKzvDBujR, isEditor))
			{
				List<IExternalInputManager> componentsInSelfAndChildren = UnityTools.GetComponentsInSelfAndChildren<IExternalInputManager>(xknFermcIdfIAHgTczNAVdjLNQvSA);
				for (int i = 0; i < componentsInSelfAndChildren.Count; i++)
				{
					if (componentsInSelfAndChildren[i].Initialize(P_1.gyKIPpQGdyFiDXnLgdbarTkEWvbS, FOVoFsNVVAcWPBEULNxvaZaHMnTU) is PlatformInputManager platformInputManager)
					{
						epwTnUVpwyQDOljotgHFjaZREHkeA = platformInputManager;
						return;
					}
				}
			}
			if (flag)
			{
				UnityTools.suuYxLrSpAboTHHojwxOwzMmIykN(P_1);
				P_2(P_1.gyKIPpQGdyFiDXnLgdbarTkEWvbS);
				GaNCxKHOUufiAgKLHiSSqmhOltTyb();
				flag = false;
			}
			if (configVars.DoesPlatformUseFallback(JPEBRAbZnpxwieWJDZhLWgTbepvwA, gEgZxKyxEHGPVpEEBjhwfbAqUdUmA, isEditor))
			{
				JwIEzBzVwoaJThQfJSjqGSeIRnNe = true;
				epwTnUVpwyQDOljotgHFjaZREHkeA = new aFbBiGQLPzGqCxciQpSApTDQeifI(FOVoFsNVVAcWPBEULNxvaZaHMnTU.updateLoop);
			}
			else if (configVars.DoesPlatformUseSDL2(JPEBRAbZnpxwieWJDZhLWgTbepvwA, gEgZxKyxEHGPVpEEBjhwfbAqUdUmA, isEditor))
			{
				try
				{
					epwTnUVpwyQDOljotgHFjaZREHkeA = new JIUMxGzinGUkMguyABvSUxSDLuBs(FOVoFsNVVAcWPBEULNxvaZaHMnTU, GetHardwareJoystickMap_InputManager, GetNewJoystickId, true, false, false);
					if (epwTnUVpwyQDOljotgHFjaZREHkeA == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
					epwTnUVpwyQDOljotgHFjaZREHkeA = null;
				}
			}
			else if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.Windows || JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.WindowsAppStore || JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.WindowsUWP || JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.OSX || JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.Linux)
			{
				epwTnUVpwyQDOljotgHFjaZREHkeA = P_0(FOVoFsNVVAcWPBEULNxvaZaHMnTU) as PlatformInputManager;
			}
			else if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.WebGL && !isEditor)
			{
				try
				{
					epwTnUVpwyQDOljotgHFjaZREHkeA = P_0(FOVoFsNVVAcWPBEULNxvaZaHMnTU) as PlatformInputManager;
					if (epwTnUVpwyQDOljotgHFjaZREHkeA == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("WebGL platform could not be initialized! Is the Rewired WebGL library installed? See the documentation for more information.");
					epwTnUVpwyQDOljotgHFjaZREHkeA = null;
				}
			}
			else if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.XboxOne && !isEditor)
			{
				try
				{
					epwTnUVpwyQDOljotgHFjaZREHkeA = new CustomInputManager(new XboxOneInputSource(), FOVoFsNVVAcWPBEULNxvaZaHMnTU.updateLoop, GetHardwareJoystickMap_InputManager, GetNewJoystickId);
					if (epwTnUVpwyQDOljotgHFjaZREHkeA == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					Logger.LogError("Xbox One platform could not be initialized! Is the Rewired Xbox One library installed? See the documentation for more information.");
					epwTnUVpwyQDOljotgHFjaZREHkeA = null;
				}
			}
			else if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.PS4 && !isEditor)
			{
				try
				{
					epwTnUVpwyQDOljotgHFjaZREHkeA = P_0(FOVoFsNVVAcWPBEULNxvaZaHMnTU) as PlatformInputManager;
					if (epwTnUVpwyQDOljotgHFjaZREHkeA == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg)
				{
					Logger.LogError("PS4 platform could not be initialized! Is the Rewired PS4 plugin installed? See the documentation for more information.");
					Logger.LogError(msg);
					epwTnUVpwyQDOljotgHFjaZREHkeA = null;
				}
			}
			else if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.PS5 && !isEditor)
			{
				try
				{
					epwTnUVpwyQDOljotgHFjaZREHkeA = P_0(FOVoFsNVVAcWPBEULNxvaZaHMnTU) as PlatformInputManager;
					if (epwTnUVpwyQDOljotgHFjaZREHkeA == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg2)
				{
					Logger.LogError("PS5 platform could not be initialized! Is the Rewired PS5 plugin installed? See the documentation for more information.");
					Logger.LogError(msg2);
					epwTnUVpwyQDOljotgHFjaZREHkeA = null;
				}
			}
			else if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.Stadia && !isEditor)
			{
				try
				{
					epwTnUVpwyQDOljotgHFjaZREHkeA = P_0(FOVoFsNVVAcWPBEULNxvaZaHMnTU) as PlatformInputManager;
					if (epwTnUVpwyQDOljotgHFjaZREHkeA == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg3)
				{
					Logger.LogError("Stadia platform could not be initialized! Is the Rewired Stadia library installed? See the documentation for more information.");
					Logger.LogError(msg3);
					epwTnUVpwyQDOljotgHFjaZREHkeA = null;
				}
			}
			else if ((JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.GameCoreXboxOne || JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.GameCoreScarlett) && !isEditor)
			{
				try
				{
					epwTnUVpwyQDOljotgHFjaZREHkeA = P_0(FOVoFsNVVAcWPBEULNxvaZaHMnTU) as PlatformInputManager;
					if (epwTnUVpwyQDOljotgHFjaZREHkeA == null)
					{
						throw new Exception("Input Manager was null.");
					}
				}
				catch (Exception msg4)
				{
					string text = ((JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.GameCoreXboxOne) ? "Xbox One" : "Xbox Series X");
					Logger.LogError(text + " platform could not be initialized! Is the Rewired " + text + " library installed? See the documentation for more information.");
					Logger.LogError(msg4);
					epwTnUVpwyQDOljotgHFjaZREHkeA = null;
				}
			}
			else if (JPEBRAbZnpxwieWJDZhLWgTbepvwA == Platform.Ouya && !isEditor)
			{
				Logger.LogError("Ouya is no longer supported.");
				epwTnUVpwyQDOljotgHFjaZREHkeA = null;
			}
			else if (UnityTools.isAndroidPlatform && !isEditor)
			{
				try
				{
					UnityTools.gVOFJpatkJHJYZfiYMjQGfZaqTURA = P_0(FOVoFsNVVAcWPBEULNxvaZaHMnTU) as IAndroidFallbackPlatformHelper;
				}
				catch (Exception msg5)
				{
					Logger.LogError(msg5);
				}
			}
			if (epwTnUVpwyQDOljotgHFjaZREHkeA == null)
			{
				JwIEzBzVwoaJThQfJSjqGSeIRnNe = true;
				epwTnUVpwyQDOljotgHFjaZREHkeA = new aFbBiGQLPzGqCxciQpSApTDQeifI(FOVoFsNVVAcWPBEULNxvaZaHMnTU.updateLoop);
			}
		}

		private static void HajfIkIhurlUoIdXybxXadASppbw()
		{
			if (lNgfEIeSjDKtdTccWbiFllZxmIEwA != FOVoFsNVVAcWPBEULNxvaZaHMnTU.GetPlatformVar_ignoreInputWhenAppNotInFocus())
			{
				lNgfEIeSjDKtdTccWbiFllZxmIEwA = !lNgfEIeSjDKtdTccWbiFllZxmIEwA;
			}
		}

		private static void XZTbNjUkZWGokoDYXkJcxxntPIXs()
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
