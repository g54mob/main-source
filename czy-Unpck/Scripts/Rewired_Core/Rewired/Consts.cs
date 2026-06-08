using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Rewired.Config;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public static class Consts
	{
		public const int systemPlayerId = 9999999;

		public const string menuRoot = "Window/Rewired";

		internal const int programVersion1 = 1;

		internal const int programVersion2 = 1;

		internal const int programVersion3 = 39;

		internal const int programVersion4 = 2;

		internal const int dataVersion = 1;

		internal const int unityMajorVersion = 2019;

		internal const string unityMajorVersionIdentifier = "U2019";

		internal const bool isTrial = false;

		internal const string copyrightYear = "2021";

		internal const string defaultNamespace = "Rewired";

		internal const LogLevelFlags defaultLogLevel = LogLevelFlags.Info | LogLevelFlags.Warning | LogLevelFlags.Error;

		internal const bool allowInputWhenEditorPaused = true;

		internal const string hwDefinitionVariantTag_RawInputDirectInput_xboxOneController_splitTriggers = "[SplitTriggers]";

		internal const string hwDefinitionVariantTag_RawInputDirectInput_xboxOneController_combinedTriggers = "[CombinedTriggers]";

		internal const float editorGUIUpdateInterval = 0.5f;

		internal const float joystickRefreshPollCheckTimeout = 1f;

		internal const float controllerRefreshWaitTimeout = 0.5f;

		internal const int buttonsPerHat = 8;

		internal const int keyboardKeyCount = 132;

		internal const int keyboardModifierKeyCount = 8;

		internal const int unityMouseButtonCount = 7;

		internal const int unityMouseAxisCount = 4;

		internal const int unityMaxJoysticks = 16;

		internal const int unityJoystickButtonCount = 20;

		internal const int unityJoystickStartingButtonKeycodeValue = 350;

		internal const int unityJoystickAxisCount = 29;

		internal const int unityJoystickLastJoystickIdWithButtonKeyCodes = 16;

		internal const string unityJoystickPrefix = "Joy";

		internal const string unityJoystickAxisSuffix = "Axis";

		internal const string unityJoystickButtonSuffix = "Button";

		internal const int directInputMaxButtons = 128;

		internal const int directInputMaxAxes = 32;

		internal const int directInputMaxHats = 4;

		internal const int directInputMaxSliders = 2;

		internal const int directInputMaxAxisValue = 65535;

		internal const int directInputMinAxisValue = -65535;

		internal const int directInputMaxHatValue = 36000;

		internal const int directInputHatZeroValue = -1;

		internal const int directInputHatSpan = 4500;

		internal const int directInputHatSpan4Way = 9000;

		internal const int directInput_hatValue_up = 0;

		internal const int directInput_hatValue_right = 9000;

		internal const int directInput_hatValue_down = 18000;

		internal const int directInput_hatValue_left = 27000;

		internal const int directInputLastDirectionValue = 31500;

		internal const int directInputLastDirectionValue4Way = 27000;

		internal const int directInputUnknownJoystickHatCount = 2;

		internal const int directInputUnknownJoystickHatButtonStartIndex = 128;

		internal const int directInputJoystickStateByteSize = 264;

		internal const int rawInputMaxButtons = 256;

		internal const int rawInputMaxAxes = 56;

		internal const int rawInputMaxHats = 4;

		internal const int rawInputMaxSliders = 2;

		internal const int rawInputMaxAxisValue = 65535;

		internal const int rawInputMinAxisValue = -65535;

		internal const int rawInputMaxHatValue = 36000;

		internal const int rawInputHatZeroValue = -1;

		internal const int rawInputHatSpan = 4500;

		internal const int rawInputHatSpan4Way = 9000;

		internal const int rawInput_hatValue_up = 0;

		internal const int rawInput_hatValue_right = 9000;

		internal const int rawInput_hatValue_down = 18000;

		internal const int rawInput_hatValue_left = 27000;

		internal const int rawInputLastDirectionValue = 31500;

		internal const int rawInputLastDirectionValue4Way = 27000;

		internal const int rawInputUnknownJoystickHatCount = 2;

		internal const int rawInputUnknownJoystickHatButtonStartIndex = 128;

		internal const int rawInputUnifiedMouseButtonCount = 5;

		internal const int rawInputUnifiedMouseAxisCount = 4;

		internal const float rawInputUnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		internal const int rawInputUnifiedKeyboardButtonCount = 132;

		internal const int osxMaxSticks = 4;

		internal const int osxMaxButtons = 128;

		internal const int osxMaxAxesPerStick = 14;

		internal const int osxMaxHatsPerStick = 4;

		internal const int osxMaxAxisValue = 65536;

		internal const int osxMinAxisValue = -65536;

		internal const int osxMaxPressureSensitiveButtonValue = 65536;

		internal const int osxMinPressureSensitiveButtonValue = 0;

		internal const int osxMaxHatValue = 36000;

		internal const int osxInputHatZeroValue = -1;

		internal const int osxHatSpan = 4500;

		internal const int osxHatSpan4Way = 9000;

		internal const int osx_hatValue_up = 0;

		internal const int osx_hatValue_right = 9000;

		internal const int osx_hatValue_down = 18000;

		internal const int osx_hatValue_left = 27000;

		internal const int osxLastDirectionValue = 31500;

		internal const int osxLastDirectionValue4Way = 27000;

		internal const int osxUnknownJoystickHatCount = 16;

		internal const int osxUnknownJoystickHatButtonStartIndex = 128;

		internal const int linuxMaxButtons = 256;

		internal const int linuxMaxAxes = 56;

		internal const int linuxMaxHats = 4;

		internal const int linuxMaxSliders = 2;

		internal const int linuxMaxAxisValue = 32767;

		internal const int linuxMinAxisValue = -32768;

		internal const int linuxMaxHatValue = 36000;

		internal const int linuxHatZeroValue = -1;

		internal const int linuxHatSpan = 4500;

		internal const int linuxHatSpan4Way = 9000;

		internal const int linux_hatValue_up = 0;

		internal const int linux_hatValue_right = 9000;

		internal const int linux_hatValue_down = 18000;

		internal const int linux_hatValue_left = 27000;

		internal const int linuxLastDirectionValue = 31500;

		internal const int linuxLastDirectionValue4Way = 27000;

		internal const int linuxUnknownJoystickHatCount = 2;

		internal const int linuxUnknownJoystickHatButtonStartIndex = 128;

		internal const int linuxUnifiedMouseButtonCount = 5;

		internal const int linuxUnifiedMouseAxisCount = 3;

		internal const float linuxUnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		internal const int sdl2MaxButtons = 256;

		internal const int sdl2MaxAxes = 56;

		internal const int sdl2MaxHats = 4;

		internal const int sdl2MaxSliders = 2;

		internal const int sdl2MaxAxisValue = 32768;

		internal const int sdl2MinAxisValue = -32767;

		internal const int sdl2AxisZeroValue = 0;

		internal const int sdl2MaxHatValue = 36000;

		internal const int sdl2HatZeroValue = -1;

		internal const int sdl2HatSpan = 4500;

		internal const int sdl2HatSpan4Way = 9000;

		internal const int sdl2_hatValue_up = 0;

		internal const int sdl2_hatValue_right = 9000;

		internal const int sdl2_hatValue_down = 18000;

		internal const int sdl2_hatValue_left = 27000;

		internal const int sdl2LastDirectionValue = 31500;

		internal const int sdl2LastDirectionValue4Way = 27000;

		internal const int sdl2UnknownJoystickHatCount = 2;

		internal const int sdl2UnknownJoystickHatButtonStartIndex = 128;

		internal const int sdl2UnifiedMouseButtonCount = 5;

		internal const int sdl2UnifiedMouseAxisCount = 3;

		internal const float sdl2UnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		internal const int windowsUWPMaxButtons = 256;

		internal const int windowsUWPMaxAxes = 56;

		internal const int windowsUWPMaxHats = 4;

		internal const int windowsUWPMaxSliders = 2;

		internal const int windowsUWPMaxAxisValue = 32767;

		internal const int windowsUWPMinAxisValue = -32768;

		internal const int windowsUWPMaxHatValue = 36000;

		internal const int windowsUWPHatZeroValue = -1;

		internal const int windowsUWPDirectionsPerHat = 8;

		internal const int windowsUWPHatSpan = 4500;

		internal const int windowsUWPHatSpan4Way = 9000;

		internal const int windowsUWPLastDirectionValue = 31500;

		internal const int windowsUWPLastDirectionValue4Way = 27000;

		internal const int windowsUWPUnknownJoystickHatCount = 2;

		internal const int windowsUWPUnknownJoystickHatButtonStartIndex = 128;

		internal const int windowsUWPUnifiedMouseButtonCount = 5;

		internal const int windowsUWPUnifiedMouseAxisCount = 3;

		internal const float windowsUWPUnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		internal const int xInputMaxVibration = 65535;

		internal const int xInputMinVibration = 0;

		internal const float xInputAllowedVibrationInterval = 0.01f;

		internal const int customPlatformMaxButtons = 256;

		internal const int customPlatformMaxAxes = 128;

		internal const int internalDriverMaxButtons = 256;

		internal const int internalDriverMaxAxes = 56;

		internal const int internalDriverMaxHats = 4;

		internal const int internalDriverMaxSliders = 2;

		internal const int internalDriverMaxAxisValue = 65535;

		internal const int internalDriverMinAxisValue = -65535;

		internal const int internalDriverMaxHatValue = 36000;

		internal const int internalDriverHatZeroValue = -1;

		internal const int internalDriverHatSpan = 4500;

		internal const int internalDriverHatSpan4Way = 9000;

		internal const int internalDriver_hatValue_up = 0;

		internal const int internalDriver_hatValue_right = 9000;

		internal const int internalDriver_hatValue_down = 18000;

		internal const int internalDriver_hatValue_left = 27000;

		internal const int internalDriverLastDirectionValue = 31500;

		internal const int internalDriverLastDirectionValue4Way = 27000;

		internal const int internalDriverUnknownJoystickHatCount = 2;

		internal const int internalDriverUnknownJoystickHatButtonStartIndex = 128;

		internal const int internalDriverUnifiedMouseButtonCount = 5;

		internal const int internalDriverUnifiedMouseAxisCount = 3;

		internal const float internalDriverUnifiedMouseAxisUnityEquivalencyMultiplier = 0.5f;

		internal const int webGLMaxButtons = 256;

		internal const int webGLMaxAxes = 128;

		internal const int gameCoreMaxButtons = 256;

		internal const int gameCoreMaxAxes = 32;

		internal const int gameCoreMaxHats = 4;

		internal const int gameCoreUnknownJoystickButtonCount = 128;

		internal const int gameCoreUnknownJoystickAxisCount = 32;

		internal const int gameCoreUnknownJoystickHatCount = 2;

		internal const int unknownJoystickMaxButtons = 128;

		internal const int unknownJoystickMaxAxes = 32;

		internal const int unknownJoystickMaxHats = 16;

		internal const int unknownJoystickButtonsPerHat = 8;

		internal const int unknownJoystickAxisElementIdentifierStartIndex = 0;

		internal const int unknownJoystickButtonElementIdentifierStartIndex = 32;

		internal const int unknownJoystickHatElementIdentifierStartIndex = 160;

		internal const float unknownJoystickDefaultAxisDeadZone = 0.1f;

		internal const float defaultAbsoluteAxisPollingDeadZone = 0.7f;

		internal const float defaultRelativeAxisPollingDeadZone = 100f;

		internal const float defaultMouseXYAxisPollingDeadzone = 100f;

		internal const float defaultMouseOtherAxisPollingDeadzone = 2f;

		internal const float defaultButtonDeadZone = 0.5f;

		internal const float hardwareButtonDeadZone = 0.01f;

		internal const float axisDefaultSensitivity = 1f;

		internal const AxisSensitivityType axisDefaultSensitivityType = AxisSensitivityType.Multiplier;

		internal const float defaultButtonDoublePressSpeed = 0.3f;

		internal const float minDoubleButtonPressSpeed = 0.01f;

		internal const float maxDoubleButtonPressSpeed = 10f;

		internal const float defaultButtonShortPressTime = 0.25f;

		internal const float minButtonShortPressTime = 0f;

		internal const float maxButtonShortPressTime = float.MaxValue;

		internal const float defaultButtonShortPressExpiresIn = 0f;

		internal const float minButtonShortPressExpiresIn = 0f;

		internal const float maxButtonShortPressExpiresIn = float.MaxValue;

		internal const float defaultButtonLongPressTime = 1f;

		internal const float minButtonLongPressTime = 0f;

		internal const float maxButtonLongPressTime = float.MaxValue;

		internal const float defaultButtonLongPressExpiresIn = 0f;

		internal const float minButtonLongPressExpiresIn = 0f;

		internal const float maxButtonLongPressExpiresIn = float.MaxValue;

		internal const float defaultButtonRepeatDelay = 0f;

		internal const float defaultButtonRepeatRate = 30f;

		internal const float minButtonRepeatRate = 0.001f;

		internal const float mouseAxisPollingTimerLength = 1f;

		internal const float fallbackPollingTimeout = 1f;

		internal const string unknownJoystickName = "Unknown Controller";

		internal const float xInputControllerVibrationRenewalInterval = 1.5f;

		internal const int defaultInputThreadUpdateRateFPS = 240;

		internal const int maxInputThreadUpdateRateFPS = 2000;

		internal const int osxXInputOutputReportRefreshRateFPS = 60;

		internal const int defaultOutputRefreshRateFPS = 100;

		internal const int hidOutputReportRefreshRateFPS = 100;

		internal const int hidOutputReportThreadKillTimeout = 10000;

		internal const int joystickInputReportRingBufferCapacity = 60;

		internal const float joystickInputReportRingBufferCapacityDuration = 0.25f;

		internal const string resourecesDLLPath_windowsStandalone = "Libs/Rewired_Windows";

		internal const string resourecesDLLPath_osxStandalone = "Libs/Rewired_OSX";

		internal const string resourecesDLLPath_linux = "Libs/Rewired_Linux";

		internal const float defaultInputBehaviorAxisSensitivity = 1f;

		internal const float defaultInputBehaviorAxisSimulation_gravity = 3f;

		internal const float defaultInputBehaviorAxisSimulation_sensitivity = 3f;

		internal const bool defaultInputBehaviorAxisSmoothing_snap = true;

		internal const bool defaultInputBehaviorAxisSmoothing_instantReverse = false;

		internal const bool defaultInputBehaviorAxisSimulation_enabled = true;

		internal const int allFlagsIntEnum = -1;

		internal const float osxPreventSystemSleepInterval = 30f;

		internal const string schemaNameSpace = "http://guavaman.com/rewired";

		internal const string schemaBaseLocation = "http://guavaman.com/schemas/rewired/";

		internal const string schemaVersionControllerMap = "1.1";

		internal const string schemaVersionCalibrationMap = "1.3";

		internal const string schemaVersionInputBehavior = "1.4";

		internal const string schemaVersionControllerTemplateMap = "1.0";

		internal const string schemaVersionPlayerEnabledMapsHelperData = "1.0";

		internal const string schemaVersionPlayerControllerMapLayoutManagerData = "1.0";

		internal const int controllerMapDataVersion = 2;

		internal const int calibrationMapDataVersion = 4;

		internal const int inputBehaviorDataVersion = 5;

		internal const int controllerTemplateMapDataVersion = 1;

		internal const int playerMapEnablerDataVersion = 1;

		internal const int playerControllerMapLayoutManagerDataVersion = 1;

		internal const int controllerElementType_trueElements_minValue = 0;

		internal const int controllerElementType_trueElements_maxValue = 99;

		internal const float pressureSensitiveButtonDeadZone = 0.001f;

		internal const string rewiredEditorAssembly = "Rewired_Editor";

		internal const string rewiredEditorInputEditorClassFullName = "Rewired.Editor.InputEditor";

		internal const string nintendoSwitchPluginEditorRuntimeAssembly = "Rewired_NintendoSwitch_EditorRuntime";

		internal const string nintendoSwitchPluginInputManagerFullClassPath = "Rewired.Platforms.Switch.NintendoSwitchInputManager";

		internal const string nintendoSwitchPluginHWJoystickMapGuid_JoyConDual = "521b808c-0248-4526-bc10-f1d16ee76bf1";

		internal const string nintendoSwitchPluginHWJoystickMapGuid_Handheld = "1fbdd13b-0795-4173-8a95-a2a75de9d204";

		internal const string stadiaPluginEditorRuntimeAssembly = "Rewired_Stadia_EditorRuntime";

		internal const string stadiaPluginInputManagerFullClassPath = "Rewired.Platforms.Stadia.StadiaInputManager";

		internal const string gameCorePluginEditorRuntimeAssembly = "Rewired_GameCore_EditorRuntime";

		internal const string gameCorePluginInputManagerFullClassPath = "Rewired.Platforms.GameCore.GameCoreInputManager";

		internal const string ps5PluginEditorRuntimeAssembly = "Rewired_PS5_EditorRuntime";

		internal const string ps5PluginInputManagerFullClassPath = "Rewired.Platforms.PS5.PS5InputManager";

		public const int vendorId_sony = 1356;

		internal const int updateLoopTypeCount = 3;

		internal static readonly PidVid[] questionablePidVids;

		internal static readonly int[] questionableVIDs;

		internal static Guid joystickGuid_unknownController;

		internal static Guid joystickGuid_appleMFiController;

		internal static Guid joystickGuid_standardizedGamepad;

		internal static Guid joystickGuid_SonyDualShock4;

		internal static Guid joystickGuid_SonyPS4AimController;

		internal static Guid hardwareTypeGuid_universalKeyboard;

		internal static Guid hardwareTypeGuid_universalMouse;

		private static ReadOnlyCollection<ControllerElementIdentifier> cdMlZOkWKLnQKOVHldRYBiTEgBHd;

		private static ReadOnlyCollection<ControllerElementIdentifier> heTXhSUauJISMVBHadXJlVEUZRE;

		internal static readonly IList<string> mouseAxisUnityNames;

		private static readonly string[] dTEgocGPvjLeCFzUtBzxnsesPfX;

		internal static readonly IList<string> mouseButtonUnityNames;

		private static readonly string[] OOpFQOTjtQBBbfculbixNSCIxqy;

		internal static readonly IList<string> keyboardKeyNames;

		private static readonly string[] RnHnlqyFwEgPnPkPbjNBvyZrnTy;

		internal static readonly IList<int> keyboardKeyValues;

		internal static readonly int[] _keyboardKeyValues;

		internal static readonly IList<string> modifierKeyShortNames;

		private static readonly string[] iadEJlkCKAQbuHBVwjYuxqODHdX;

		internal static readonly IList<PidVid> pidVids_sony_dualShock4;

		private static readonly PidVid[] ybzKZjRimldYGqDgshOMxAQqcQr;

		internal static readonly IList<string> productNames_sony_dualShock4;

		private static readonly string[] nLrzuUhfBBWSuCbUWbvnbbjNXFSF;

		private static readonly ControllerElementIdentifier[] SGcDXiaAzgZpSthUdchnkuXeyRA;

		internal static int nintendoSwitchPlugin_minPluginVersion => 22;

		internal static int stadiaPlugin_minPluginVersion => 11;

		internal static int gameCorePlugin_minPluginVersion => 1;

		internal static IList<ControllerElementIdentifier> unityUnifiedMouseElementIdentifiers
		{
			get
			{
				ReadOnlyCollection<ControllerElementIdentifier> readOnlyCollection = cdMlZOkWKLnQKOVHldRYBiTEgBHd;
				if (readOnlyCollection == null)
				{
					ControllerElementIdentifier[] array = new ControllerElementIdentifier[11]
					{
						new ControllerElementIdentifier(0, "Mouse Horizontal", "Mouse Right", "Mouse Left", ControllerElementType.Axis, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true),
						new ControllerElementIdentifier(1, "Mouse Vertical", "Mouse Up", "Mouse Down", ControllerElementType.Axis, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true),
						new ControllerElementIdentifier(2, "Mouse Wheel", "Mouse Wheel Up", "Mouse Wheel Down", ControllerElementType.Axis, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true),
						new ControllerElementIdentifier(10, "Mouse Wheel Horizontal", "Mouse Wheel Right", "Mouse Wheel Left", ControllerElementType.Axis, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true),
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					while (true)
					{
						int num = 1502812393;
						while (true)
						{
							switch (num ^ 0x599318EB)
							{
							case 0:
								break;
							case 2:
								array[4] = new ControllerElementIdentifier(3, "Left Mouse Button", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
								array[5] = new ControllerElementIdentifier(4, "Right Mouse Button", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
								array[6] = new ControllerElementIdentifier(5, "Mouse Button 3", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
								num = 1502812394;
								continue;
							default:
								goto end_IL_0081;
							}
							break;
						}
						continue;
						end_IL_0081:
						break;
					}
					array[7] = new ControllerElementIdentifier(6, "Mouse Button 4", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
					array[8] = new ControllerElementIdentifier(7, "Mouse Button 5", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
					array[9] = new ControllerElementIdentifier(8, "Mouse Button 6", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
					array[10] = new ControllerElementIdentifier(9, "Mouse Button 7", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
					readOnlyCollection = (cdMlZOkWKLnQKOVHldRYBiTEgBHd = new ReadOnlyCollection<ControllerElementIdentifier>(array));
				}
				return readOnlyCollection;
			}
		}

		internal static IList<ControllerElementIdentifier> rawInputUnifiedMouseElementIdentifiers
		{
			get
			{
				ReadOnlyCollection<ControllerElementIdentifier> readOnlyCollection = heTXhSUauJISMVBHadXJlVEUZRE;
				if (readOnlyCollection == null)
				{
					ControllerElementIdentifier[] array = new ControllerElementIdentifier[9]
					{
						new ControllerElementIdentifier(0, "Mouse Horizontal", "Mouse Right", "Mouse Left", ControllerElementType.Axis, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true),
						new ControllerElementIdentifier(1, "Mouse Vertical", "Mouse Up", "Mouse Down", ControllerElementType.Axis, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true),
						new ControllerElementIdentifier(2, "Mouse Wheel", "Mouse Wheel Up", "Mouse Wheel Down", ControllerElementType.Axis, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true),
						new ControllerElementIdentifier(3, "Left Mouse Button", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true),
						new ControllerElementIdentifier(4, "Right Mouse Button", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true),
						null,
						null,
						null,
						null
					};
					while (true)
					{
						int num = -1895732573;
						while (true)
						{
							switch (num ^ -1895732574)
							{
							case 2:
								break;
							case 1:
								array[5] = new ControllerElementIdentifier(5, "Mouse Button 3", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
								array[6] = new ControllerElementIdentifier(6, "Mouse Button 4", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
								num = -1895732575;
								continue;
							case 3:
								array[7] = new ControllerElementIdentifier(7, "Mouse Button 5", "", "", ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
								array[8] = new ControllerElementIdentifier(10, "Mouse Wheel Horizontal", "Mouse Wheel Right", "Mouse Wheel Left", ControllerElementType.Axis, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true);
								num = -1895732574;
								continue;
							default:
								goto end_IL_009b;
							}
							break;
						}
						continue;
						end_IL_009b:
						break;
					}
					readOnlyCollection = (heTXhSUauJISMVBHadXJlVEUZRE = new ReadOnlyCollection<ControllerElementIdentifier>(array));
				}
				return readOnlyCollection;
			}
		}

		internal static ControllerElementIdentifier[] unknownJoystickElementIdentifiers_orig => SGcDXiaAzgZpSthUdchnkuXeyRA;

		static Consts()
		{
			joystickGuid_unknownController = Guid.Empty;
			joystickGuid_appleMFiController = new Guid("3d919cfa-468e-49f4-bce9-f6c43f2e7e62");
			string[] array5 = default(string[]);
			string[] array = default(string[]);
			PidVid[] array2 = default(PidVid[]);
			PidVid[] array6 = default(PidVid[]);
			string[] array3 = default(string[]);
			string[] array4 = default(string[]);
			while (true)
			{
				int num = 816394620;
				while (true)
				{
					switch (num ^ 0x30A93142)
					{
					case 4:
						break;
					default:
						return;
					case 15:
						pidVids_sony_dualShock4 = new ReadOnlyCollection<PidVid>(ybzKZjRimldYGqDgshOMxAQqcQr);
						num = 816394578;
						continue;
					case 44:
						array5[2] = "MouseButton2";
						array5[3] = "MouseButton3";
						num = 816394562;
						continue;
					case 34:
						array[113] = "Numlock";
						num = 816394586;
						continue;
					case 16:
						productNames_sony_dualShock4 = new ReadOnlyCollection<string>(nLrzuUhfBBWSuCbUWbvnbbjNXFSF);
						num = 816394589;
						continue;
					case 19:
					{
						ref PidVid reference5 = ref array2[2];
						reference5 = new PidVid(ushort.MaxValue, ushort.MaxValue);
						num = 816394607;
						continue;
					}
					case 28:
						array[12] = "L";
						num = 816394585;
						continue;
					case 63:
						array6 = new PidVid[3];
						num = 816394571;
						continue;
					case 64:
						if (132 != _keyboardKeyValues.Length)
						{
							Logger.LogError("Consts.keyboardKeyCount does not match _keyboardKeyValues.Length!");
							num = 816394603;
							continue;
						}
						return;
					case 14:
						array[79] = ">";
						array[80] = "?";
						array[81] = "@";
						array[82] = "[";
						num = 816394583;
						continue;
					case 47:
						array[84] = "]";
						array[85] = "^";
						array[86] = "_";
						array[87] = "Back Quote";
						array[88] = "Delete";
						array[89] = "Up Arrow";
						num = 816394619;
						continue;
					case 27:
						array[13] = "M";
						array[14] = "N";
						array[15] = "O";
						num = 816394581;
						continue;
					case 37:
						array3[3] = "Shift";
						array3[4] = "Cmd";
						num = 816394601;
						continue;
					case 51:
						array[125] = "Right Windows";
						num = 816394623;
						continue;
					case 7:
						modifierKeyShortNames = new ReadOnlyCollection<string>(iadEJlkCKAQbuHBVwjYuxqODHdX);
						num = 816394573;
						continue;
					case 9:
					{
						ref PidVid reference4 = ref array6[0];
						reference4 = new PidVid(1476, 1356);
						num = 816394582;
						continue;
					}
					case 53:
						array[71] = ",";
						array[72] = "-";
						array[73] = ".";
						array[74] = "/";
						num = 816394591;
						continue;
					case 2:
						array[99] = "F2";
						num = 816394596;
						continue;
					case 10:
						array[11] = "K";
						num = 816394590;
						continue;
					case 3:
						array[61] = "!";
						array[62] = "\"";
						array[63] = "#";
						array[64] = "$";
						array[65] = "&";
						array[66] = "'";
						num = 816394617;
						continue;
					case 42:
						array3 = new string[5] { "", "Ctrl", null, null, null };
						num = 816394587;
						continue;
					case 0:
						array5[4] = "MouseButton4";
						array5[5] = "MouseButton5";
						array5[6] = "MouseButton6";
						OOpFQOTjtQBBbfculbixNSCIxqy = array5;
						array = new string[132];
						num = 816394584;
						continue;
					case 40:
						array[98] = "F1";
						num = 816394560;
						continue;
					case 17:
						hardwareTypeGuid_universalMouse = new Guid("ad60107cea394d9cb90656d39d07be95");
						dTEgocGPvjLeCFzUtBzxnsesPfX = new string[3] { "MouseAxis1", "MouseAxis2", "MouseAxis3" };
						array5 = new string[7] { "MouseButton0", null, null, null, null, null, null };
						num = 816394576;
						continue;
					case 57:
						array[90] = "Down Arrow";
						array[91] = "Right Arrow";
						array[92] = "Left Arrow";
						array[93] = "Insert";
						array[94] = "Home";
						array[95] = "End";
						num = 816394608;
						continue;
					case 45:
					{
						ref PidVid reference3 = ref array2[3];
						reference3 = new PidVid(ushort.MaxValue, 0);
						questionablePidVids = array2;
						questionableVIDs = new int[2] { 0, 65535 };
						SGcDXiaAzgZpSthUdchnkuXeyRA = HHwYMjQuxSucijatRcqkmWpUEVz();
						if (132 != RnHnlqyFwEgPnPkPbjNBvyZrnTy.Length)
						{
							Logger.LogError("Consts.keyboardKeyCount does not match _keyboardKeyNames.Length!");
							num = 816394498;
							continue;
						}
						goto case 64;
					}
					case 65:
						array4[2] = "Wireless Controller";
						array4[3] = "Sony Interactive Entertainment Wireless Controller";
						num = 816394597;
						continue;
					case 8:
						array[2] = "B";
						array[3] = "C";
						array[4] = "D";
						num = 816394622;
						continue;
					case 20:
					{
						ref PidVid reference = ref array6[1];
						reference = new PidVid(2976, 1356);
						ref PidVid reference2 = ref array6[2];
						reference2 = new PidVid(2508, 1356);
						ybzKZjRimldYGqDgshOMxAQqcQr = array6;
						array4 = new string[4] { "Sony Computer Entertainment Wireless Controller", "Sony Interactive Entertainment DUALSHOCK®4 USB Wireless Adaptor", null, null };
						num = 816394499;
						continue;
					}
					case 5:
						array[111] = "F14";
						array[112] = "F15";
						num = 816394592;
						continue;
					case 50:
						array[96] = "Page Up";
						array[97] = "Page Down";
						num = 816394602;
						continue;
					case 46:
						array[29] = "2";
						array[30] = "3";
						array[31] = "4";
						num = 816394564;
						continue;
					case 18:
						array5[1] = "MouseButton1";
						num = 816394606;
						continue;
					case 58:
						array[54] = "Space";
						array[55] = "Backspace";
						num = 816394613;
						continue;
					case 26:
						array[0] = "None";
						array[1] = "A";
						num = 816394570;
						continue;
					case 55:
						array[56] = "Tab";
						array[57] = "Clear";
						array[58] = "Return";
						array[59] = "Pause";
						array[60] = "ESC";
						num = 816394561;
						continue;
					case 39:
						nLrzuUhfBBWSuCbUWbvnbbjNXFSF = array4;
						mouseAxisUnityNames = new ReadOnlyCollection<string>(dTEgocGPvjLeCFzUtBzxnsesPfX);
						mouseButtonUnityNames = new ReadOnlyCollection<string>(OOpFQOTjtQBBbfculbixNSCIxqy);
						keyboardKeyNames = new ReadOnlyCollection<string>(RnHnlqyFwEgPnPkPbjNBvyZrnTy);
						keyboardKeyValues = new ReadOnlyCollection<int>(_keyboardKeyValues);
						num = 816394565;
						continue;
					case 68:
						array[103] = "F6";
						array[104] = "F7";
						num = 816394612;
						continue;
					case 1:
						array[120] = "Right Alt";
						array[121] = "Left Alt";
						num = 816394588;
						continue;
					case 60:
						array[5] = "E";
						array[6] = "F";
						num = 816394614;
						continue;
					case 61:
						array[126] = "AltGr";
						array[127] = "Help";
						array[128] = "Print";
						array[129] = "SysReq";
						array[130] = "Break";
						array[131] = "Menu";
						RnHnlqyFwEgPnPkPbjNBvyZrnTy = array;
						num = 816394497;
						continue;
					case 52:
						array[7] = "G";
						num = 816394593;
						continue;
					case 43:
						iadEJlkCKAQbuHBVwjYuxqODHdX = array3;
						num = 816394621;
						continue;
					case 32:
						array[22] = "V";
						array[23] = "W";
						array[24] = "X";
						array[25] = "Y";
						array[26] = "Z";
						array[27] = "0";
						array[28] = "1";
						num = 816394604;
						continue;
					case 35:
						array[8] = "H";
						array[9] = "I";
						array[10] = "J";
						num = 816394568;
						continue;
					case 56:
						array[116] = "Right Shift";
						array[117] = "Left Shift";
						array[118] = "Right Control";
						array[119] = "Left Control";
						num = 816394563;
						continue;
					case 23:
						array[16] = "P";
						array[17] = "Q";
						array[18] = "R";
						array[19] = "S";
						array[20] = "T";
						array[21] = "U";
						num = 816394594;
						continue;
					case 6:
						array[32] = "5";
						array[33] = "6";
						array[34] = "7";
						array[35] = "8";
						array[36] = "9";
						num = 816394611;
						continue;
					case 48:
						array[45] = "Keypad 8";
						array[46] = "Keypad 9";
						array[47] = "Keypad .";
						array[48] = "Keypad /";
						array[49] = "Keypad *";
						num = 816394580;
						continue;
					case 25:
						array3[2] = "Alt";
						num = 816394599;
						continue;
					case 62:
						joystickGuid_standardizedGamepad = new Guid("04c23ab3-2b99-4404-a5c4-f0df7e62938f");
						num = 816394574;
						continue;
					case 36:
						array[43] = "Keypad 6";
						array[44] = "Keypad 7";
						num = 816394610;
						continue;
					case 29:
						array[75] = ":";
						num = 816394575;
						continue;
					case 31:
						array2 = new PidVid[4]
						{
							new PidVid(0, 0),
							new PidVid(0, ushort.MaxValue),
							default(PidVid),
							default(PidVid)
						};
						num = 816394577;
						continue;
					case 67:
						_keyboardKeyValues = new int[132]
						{
							0, 97, 98, 99, 100, 101, 102, 103, 104, 105,
							106, 107, 108, 109, 110, 111, 112, 113, 114, 115,
							116, 117, 118, 119, 120, 121, 122, 48, 49, 50,
							51, 52, 53, 54, 55, 56, 57, 256, 257, 258,
							259, 260, 261, 262, 263, 264, 265, 266, 267, 268,
							269, 270, 271, 272, 32, 8, 9, 12, 13, 19,
							27, 33, 34, 35, 36, 38, 39, 40, 41, 42,
							43, 44, 45, 46, 47, 58, 59, 60, 61, 62,
							63, 64, 91, 92, 93, 94, 95, 96, 127, 273,
							274, 275, 276, 277, 278, 279, 280, 281, 282, 283,
							284, 285, 286, 287, 288, 289, 290, 291, 292, 293,
							294, 295, 296, 300, 301, 302, 303, 304, 305, 306,
							307, 308, 309, 310, 311, 312, 313, 315, 316, 317,
							318, 319
						};
						num = 816394600;
						continue;
					case 49:
						array[37] = "Keypad 0";
						array[38] = "Keypad 1";
						array[39] = "Keypad 2";
						array[40] = "Keypad 3";
						array[41] = "Keypad 4";
						array[42] = "Keypad 5";
						num = 816394598;
						continue;
					case 22:
						array[50] = "Keypad -";
						array[51] = "Keypad +";
						array[52] = "Keypad Enter";
						array[53] = "Keypad =";
						num = 816394616;
						continue;
					case 24:
						array[114] = "Caps Lock";
						num = 816394569;
						continue;
					case 33:
						array[77] = "<";
						array[78] = "=";
						num = 816394572;
						continue;
					case 59:
						array[67] = "(";
						array[68] = ")";
						num = 816394496;
						continue;
					case 66:
						array[69] = "*";
						array[70] = "+";
						num = 816394615;
						continue;
					case 38:
						array[100] = "F3";
						array[101] = "F4";
						array[102] = "F5";
						num = 816394502;
						continue;
					case 30:
						array[122] = "Right Command";
						array[123] = "Left Command";
						array[124] = "Left Windows";
						num = 816394609;
						continue;
					case 21:
						array[83] = "\\";
						num = 816394605;
						continue;
					case 11:
						array[115] = "Scroll Lock";
						num = 816394618;
						continue;
					case 12:
						joystickGuid_SonyDualShock4 = new Guid("cd9718bf-a87a-44bc-8716-60a0def28a9f");
						joystickGuid_SonyPS4AimController = new Guid("65ea105c-6390-4d11-a49b-13a402b1f2d9");
						hardwareTypeGuid_universalKeyboard = new Guid("ae4830f963db4d4c90b31beb46ecaf49");
						num = 816394579;
						continue;
					case 13:
						array[76] = ";";
						num = 816394595;
						continue;
					case 54:
						array[105] = "F8";
						array[106] = "F9";
						array[107] = "F10";
						array[108] = "F11";
						array[109] = "F12";
						array[110] = "F13";
						num = 816394567;
						continue;
					case 41:
						return;
					}
					break;
				}
			}
		}

		private static ControllerElementIdentifier[] HHwYMjQuxSucijatRcqkmWpUEVz()
		{
			int num = 0;
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>(288);
			int num3 = default(int);
			int num8 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num2 = -746234454;
				while (true)
				{
					int num6;
					int num5;
					switch (num2 ^ -746234459)
					{
					case 7:
						break;
					case 12:
						num2 = -746234457;
						continue;
					case 4:
						list.Add(new ControllerElementIdentifier(num6++, "Hat " + num3 + " Up", string.Empty, string.Empty, ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						num2 = -746234456;
						continue;
					case 10:
						num6 = num;
						num2 = -746234460;
						continue;
					case 15:
						num8 = 0;
						num2 = -746234453;
						continue;
					case 3:
						list.Add(new ControllerElementIdentifier(num, "Button " + num4, string.Empty, string.Empty, ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						num++;
						num4++;
						num2 = -746234450;
						continue;
					case 0:
						num++;
						num8++;
						num2 = -746234453;
						continue;
					case 14:
					{
						int num9;
						if (num8 >= 32)
						{
							num2 = -746234461;
							num9 = num2;
						}
						else
						{
							num2 = -746234452;
							num9 = num2;
						}
						continue;
					}
					case 9:
						list.Add(new ControllerElementIdentifier(num, "Axis " + num8, string.Empty, string.Empty, ControllerElementType.Axis, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						num2 = -746234459;
						continue;
					case 1:
						num5 = num + 64;
						num3 = 0;
						num2 = -746234455;
						continue;
					case 11:
					{
						int num7;
						if (num4 < 128)
						{
							num2 = -746234458;
							num7 = num2;
						}
						else
						{
							num2 = -746234449;
							num7 = num2;
						}
						continue;
					}
					case 13:
						list.Add(new ControllerElementIdentifier(num5++, "Hat " + num3 + " Up Right", string.Empty, string.Empty, ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						list.Add(new ControllerElementIdentifier(num6++, "Hat " + num3 + " Right", string.Empty, string.Empty, ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						list.Add(new ControllerElementIdentifier(num5++, "Hat " + num3 + " Down Right", string.Empty, string.Empty, ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						list.Add(new ControllerElementIdentifier(num6++, "Hat " + num3 + " Down", string.Empty, string.Empty, ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						list.Add(new ControllerElementIdentifier(num5++, "Hat " + num3 + " Down Left", string.Empty, string.Empty, ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						list.Add(new ControllerElementIdentifier(num6++, "Hat " + num3 + " Left", string.Empty, string.Empty, ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						num2 = -746234464;
						continue;
					case 8:
						num2 = -746234450;
						continue;
					case 5:
						list.Add(new ControllerElementIdentifier(num5++, "Hat " + num3 + " Up Left", string.Empty, string.Empty, ControllerElementType.Button, CompoundControllerElementType.Axis2D, isMappableOnPlatform: true));
						num3++;
						num2 = -746234457;
						continue;
					case 6:
						num4 = 0;
						num2 = -746234451;
						continue;
					default:
						if (num3 >= 16)
						{
							return list.ToArray();
						}
						goto case 4;
					}
					break;
				}
			}
		}
	}
}
