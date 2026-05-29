using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Rewired.Config;

namespace Rewired
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public static class Consts
	{
		public const int systemPlayerId = 9999999;

		public const string menuRoot = "Window/Rewired";

		internal const int programVersion1 = 1;

		internal const int programVersion2 = 1;

		internal const int programVersion3 = 27;

		internal const int programVersion4 = 3;

		internal const int dataVersion = 1;

		internal const int unityMajorVersion = 2018;

		internal const string unityMajorVersionIdentifier = "U2018";

		internal const bool isTrial = false;

		internal const string copyrightYear = "2019";

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

		internal const int unityMouseAxisCount = 3;

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

		internal const int rawInputUnifiedMouseAxisCount = 3;

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

		internal const float axisPollingDeadzone = 0.7f;

		internal const float mouseXYAxisPollingDeadzone = 100f;

		internal const float mouseOtherAxisPollingDeadzone = 2f;

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

		internal const int joystickInputReportRingBufferCapacity = 25;

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

		internal const int lowLevelEventBuffers_buttonEventBufferSize = 16;

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

		internal const int updateLoopTypeCount = 3;

		internal static readonly PidVid[] questionablePidVids;

		internal static readonly int[] questionableVIDs;

		internal static Guid joystickGuid_appleMFiController;

		internal static Guid joystickGuid_standardizedGamepad;

		internal static Guid joystickGuid_SonyDualShock4;

		internal static Guid hardwareTypeGuid_universalKeyboard;

		internal static Guid hardwareTypeGuid_universalMouse;

		internal static readonly IList<string> unityMouseElementNames;

		private static readonly string[] qBDYbfUPIiFNDejLegaKgtLwcGMH;

		internal static readonly IList<string> unityMouseAxisPositiveNames;

		private static readonly string[] iHlyPtmBMIMsovDTbUURTDTBWcn;

		internal static readonly IList<string> unityMouseAxisNegativeNames;

		private static readonly string[] BZIFgMbNJszXvRmwFDmunKVffegB;

		internal static readonly IList<string> rawInputUnifiedMouseElementNames;

		private static readonly string[] DMHPNLMrivXXEkCGlzOUglRtSaB;

		internal static readonly IList<string> rawInputUnifiedMouseAxisPositiveNames;

		private static readonly string[] SYqciECdkyzEmQlbFzYvCiHvueFi;

		internal static readonly IList<string> rawInputUnifiedMouseAxisNegativeNames;

		private static readonly string[] GxWKYDSqhZHhpxBaRHJzYcMQftF;

		internal static readonly IList<int> unityMouseElementIdentifierIds;

		private static readonly int[] rkwGArXtECESIjBMUVQqTvJMCVj;

		internal static readonly IList<int> rawInputUnifiedMouseElementIdentifierIds;

		private static readonly int[] xxNwvXwxDdAGkMNIMcmNnUcobCa;

		internal static readonly IList<string> mouseAxisUnityNames;

		private static readonly string[] QPGZLhawQvzmTkFbuYcuzpCxugu;

		internal static readonly IList<string> mouseButtonUnityNames;

		private static readonly string[] rVfGaBkbKEPAsFGHBqJipLqCHrjP;

		internal static readonly IList<string> keyboardKeyNames;

		private static readonly string[] grVlAhMLLGfKqduocNqQXvlkamTc;

		internal static readonly IList<int> keyboardKeyValues;

		internal static readonly int[] _keyboardKeyValues;

		internal static readonly IList<string> modifierKeyShortNames;

		private static readonly string[] PcdYdcMRtArDbuRudeOrJvYSRGwi;

		internal static int nintendoSwitchPlugin_minPluginVersion
		{
			get
			{
				return 4;
			}
		}

		static Consts()
		{
			joystickGuid_appleMFiController = new Guid("3d919cfa-468e-49f4-bce9-f6c43f2e7e62");
			joystickGuid_standardizedGamepad = new Guid("04c23ab3-2b99-4404-a5c4-f0df7e62938f");
			joystickGuid_SonyDualShock4 = new Guid("cd9718bf-a87a-44bc-8716-60a0def28a9f");
			hardwareTypeGuid_universalKeyboard = new Guid("ae4830f963db4d4c90b31beb46ecaf49");
			string[] array = default(string[]);
			string[] array3 = default(string[]);
			string[] array4 = default(string[]);
			string[] array5 = default(string[]);
			string[] array9 = default(string[]);
			string[] array6 = default(string[]);
			string[] array8 = default(string[]);
			PidVid[] array7 = default(PidVid[]);
			int[] array2 = default(int[]);
			while (true)
			{
				int num = 1114181936;
				while (true)
				{
					switch (num ^ 0x42691119)
					{
					case 32:
						break;
					default:
						return;
					case 20:
						array[67] = "(";
						array[68] = ")";
						array[69] = "*";
						array[70] = "+";
						array[71] = ",";
						array[72] = "-";
						array[73] = ".";
						num = 1114181902;
						continue;
					case 9:
						mouseAxisUnityNames = new ReadOnlyCollection<string>(QPGZLhawQvzmTkFbuYcuzpCxugu);
						num = 1114181979;
						continue;
					case 31:
						BZIFgMbNJszXvRmwFDmunKVffegB = array3;
						array4 = new string[10];
						num = 1114181922;
						continue;
					case 50:
						array[92] = "Left Arrow";
						array[93] = "Insert";
						array[94] = "Home";
						array[95] = "End";
						array[96] = "Page Up";
						array[97] = "Page Down";
						num = 1114181889;
						continue;
					case 21:
						array[127] = "Help";
						array[128] = "Print";
						num = 1114181915;
						continue;
					case 11:
						array[36] = "9";
						array[37] = "Keypad 0";
						num = 1114181897;
						continue;
					case 10:
						array3[1] = "Mouse Down";
						array3[2] = "Mouse Wheel Down";
						num = 1114181894;
						continue;
					case 30:
						xxNwvXwxDdAGkMNIMcmNnUcobCa = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
						QPGZLhawQvzmTkFbuYcuzpCxugu = new string[3] { "MouseAxis1", "MouseAxis2", "MouseAxis3" };
						num = 1114181949;
						continue;
					case 35:
						array[12] = "L";
						array[13] = "M";
						array[14] = "N";
						array[15] = "O";
						array[16] = "P";
						num = 1114181916;
						continue;
					case 45:
						array5[0] = "";
						array5[1] = "Ctrl";
						array5[2] = "Alt";
						array5[3] = "Shift";
						num = 1114181934;
						continue;
					case 34:
						rkwGArXtECESIjBMUVQqTvJMCVj = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
						num = 1114181895;
						continue;
					case 25:
						array[130] = "Break";
						array[131] = "Menu";
						num = 1114181896;
						continue;
					case 61:
						Logger.LogError("Consts.keyboardKeyCount does not match _keyboardKeyValues.Length!");
						num = 1114181899;
						continue;
					case 27:
						array[122] = "Right Command";
						array[123] = "Left Command";
						array[124] = "Left Windows";
						array[125] = "Right Windows";
						array[126] = "AltGr";
						num = 1114181900;
						continue;
					case 43:
						GxWKYDSqhZHhpxBaRHJzYcMQftF = array9;
						num = 1114181947;
						continue;
					case 56:
						array9 = new string[3] { "Mouse Left", "Mouse Down", null };
						num = 1114181932;
						continue;
					case 15:
						array[104] = "F7";
						array[105] = "F8";
						array[106] = "F9";
						array[107] = "F10";
						array[108] = "F11";
						array[109] = "F12";
						array[110] = "F13";
						num = 1114181898;
						continue;
					case 19:
						array[111] = "F14";
						array[112] = "F15";
						array[113] = "Numlock";
						num = 1114181903;
						continue;
					case 14:
						array[11] = "K";
						num = 1114181946;
						continue;
					case 1:
						array[56] = "Tab";
						array[57] = "Clear";
						array[58] = "Return";
						array[59] = "Pause";
						array[60] = "ESC";
						array[61] = "!";
						array[62] = "\"";
						num = 1114181909;
						continue;
					case 38:
						array[39] = "Keypad 2";
						array[40] = "Keypad 3";
						array[41] = "Keypad 4";
						array[42] = "Keypad 5";
						array[43] = "Keypad 6";
						array[44] = "Keypad 7";
						array[45] = "Keypad 8";
						array[46] = "Keypad 9";
						array[47] = "Keypad .";
						array[48] = "Keypad /";
						array[49] = "Keypad *";
						array[50] = "Keypad -";
						array[51] = "Keypad +";
						array[52] = "Keypad Enter";
						array[53] = "Keypad =";
						array[54] = "Space";
						array[55] = "Backspace";
						num = 1114181912;
						continue;
					case 42:
						array6[0] = "MouseButton0";
						array6[1] = "MouseButton1";
						array6[2] = "MouseButton2";
						array6[3] = "MouseButton3";
						array6[4] = "MouseButton4";
						array6[5] = "MouseButton5";
						array6[6] = "MouseButton6";
						rVfGaBkbKEPAsFGHBqJipLqCHrjP = array6;
						array = new string[132];
						array[0] = "None";
						array[1] = "A";
						num = 1114181935;
						continue;
					case 26:
						array8[1] = "Mouse Vertical";
						array8[2] = "Mouse Wheel";
						array8[3] = "Left Mouse Button";
						array8[4] = "Right Mouse Button";
						array8[5] = "Mouse Button 3";
						num = 1114181914;
						continue;
					case 55:
						array5[4] = "Cmd";
						PcdYdcMRtArDbuRudeOrJvYSRGwi = array5;
						unityMouseElementNames = new ReadOnlyCollection<string>(qBDYbfUPIiFNDejLegaKgtLwcGMH);
						num = 1114181920;
						continue;
					case 62:
						array4[5] = "Mouse Button 3";
						array4[6] = "Mouse Button 4";
						array4[7] = "Mouse Button 5";
						array4[8] = "Mouse Button 6";
						array4[9] = "Mouse Button 7";
						DMHPNLMrivXXEkCGlzOUglRtSaB = array4;
						num = 1114181893;
						continue;
					case 3:
						array8[6] = "Mouse Button 4";
						array8[7] = "Mouse Button 5";
						num = 1114181944;
						continue;
					case 41:
						hardwareTypeGuid_universalMouse = new Guid("ad60107cea394d9cb90656d39d07be95");
						array8 = new string[10] { "Mouse Horizontal", null, null, null, null, null, null, null, null, null };
						num = 1114181891;
						continue;
					case 44:
						keyboardKeyValues = new ReadOnlyCollection<int>(_keyboardKeyValues);
						num = 1114181976;
						continue;
					case 46:
						array[75] = ":";
						array[76] = ";";
						array[77] = "<";
						array[78] = "=";
						array[79] = ">";
						array[80] = "?";
						array[81] = "@";
						array[82] = "[";
						num = 1114181892;
						continue;
					case 66:
						mouseButtonUnityNames = new ReadOnlyCollection<string>(rVfGaBkbKEPAsFGHBqJipLqCHrjP);
						keyboardKeyNames = new ReadOnlyCollection<string>(grVlAhMLLGfKqduocNqQXvlkamTc);
						num = 1114181941;
						continue;
					case 12:
						array[63] = "#";
						array[64] = "$";
						array[65] = "&";
						array[66] = "'";
						num = 1114181901;
						continue;
					case 52:
						array[35] = "8";
						num = 1114181906;
						continue;
					case 65:
						modifierKeyShortNames = new ReadOnlyCollection<string>(PcdYdcMRtArDbuRudeOrJvYSRGwi);
						array7 = new PidVid[4]
						{
							new PidVid(0, 0),
							new PidVid(0, ushort.MaxValue),
							new PidVid(ushort.MaxValue, ushort.MaxValue),
							new PidVid(ushort.MaxValue, 0)
						};
						num = 1114181950;
						continue;
					case 16:
						array[38] = "Keypad 1";
						num = 1114181951;
						continue;
					case 6:
						array[10] = "J";
						num = 1114181911;
						continue;
					case 59:
						array4[0] = "Mouse Horizontal";
						num = 1114181930;
						continue;
					case 7:
					{
						int num2;
						if (132 != _keyboardKeyValues.Length)
						{
							num = 1114181924;
							num2 = num;
						}
						else
						{
							num = 1114181899;
							num2 = num;
						}
						continue;
					}
					case 48:
						array[84] = "]";
						array[85] = "^";
						array[86] = "_";
						array[87] = "Back Quote";
						num = 1114181905;
						continue;
					case 24:
						array[98] = "F1";
						array[99] = "F2";
						array[100] = "F3";
						array[101] = "F4";
						array[102] = "F5";
						array[103] = "F6";
						num = 1114181910;
						continue;
					case 4:
						array[25] = "Y";
						array[26] = "Z";
						array[27] = "0";
						array[28] = "1";
						num = 1114181928;
						continue;
					case 60:
						array[32] = "5";
						num = 1114181913;
						continue;
					case 5:
						array[17] = "Q";
						num = 1114181937;
						continue;
					case 13:
						array[117] = "Left Shift";
						array[118] = "Right Control";
						array[119] = "Left Control";
						array[120] = "Right Alt";
						array[121] = "Left Alt";
						num = 1114181890;
						continue;
					case 53:
						array9[2] = "Mouse Wheel Down";
						num = 1114181938;
						continue;
					case 63:
						rawInputUnifiedMouseAxisNegativeNames = new ReadOnlyCollection<string>(GxWKYDSqhZHhpxBaRHJzYcMQftF);
						rawInputUnifiedMouseElementIdentifierIds = new ReadOnlyCollection<int>(xxNwvXwxDdAGkMNIMcmNnUcobCa);
						num = 1114181904;
						continue;
					case 23:
						array[74] = "/";
						num = 1114181943;
						continue;
					case 54:
						array[2] = "B";
						array[3] = "C";
						array[4] = "D";
						array[5] = "E";
						array[6] = "F";
						array[7] = "G";
						array[8] = "H";
						array[9] = "I";
						num = 1114181919;
						continue;
					case 47:
						qBDYbfUPIiFNDejLegaKgtLwcGMH = array8;
						iHlyPtmBMIMsovDTbUURTDTBWcn = new string[3] { "Mouse Right", "Mouse Up", "Mouse Wheel Up" };
						array3 = new string[3] { "Mouse Left", null, null };
						num = 1114181907;
						continue;
					case 57:
						unityMouseAxisPositiveNames = new ReadOnlyCollection<string>(iHlyPtmBMIMsovDTbUURTDTBWcn);
						unityMouseAxisNegativeNames = new ReadOnlyCollection<string>(BZIFgMbNJszXvRmwFDmunKVffegB);
						unityMouseElementIdentifierIds = new ReadOnlyCollection<int>(rkwGArXtECESIjBMUVQqTvJMCVj);
						rawInputUnifiedMouseElementNames = new ReadOnlyCollection<string>(DMHPNLMrivXXEkCGlzOUglRtSaB);
						rawInputUnifiedMouseAxisPositiveNames = new ReadOnlyCollection<string>(SYqciECdkyzEmQlbFzYvCiHvueFi);
						num = 1114181926;
						continue;
					case 33:
						array8[8] = "Mouse Button 6";
						array8[9] = "Mouse Button 7";
						num = 1114181942;
						continue;
					case 40:
						array[18] = "R";
						array[19] = "S";
						array[20] = "T";
						array[21] = "U";
						array[22] = "V";
						array[23] = "W";
						array[24] = "X";
						num = 1114181917;
						continue;
					case 37:
						array2[1] = 65535;
						num = 1114181923;
						continue;
					case 8:
						array[88] = "Delete";
						array[89] = "Up Arrow";
						array[90] = "Down Arrow";
						array[91] = "Right Arrow";
						num = 1114181931;
						continue;
					case 39:
						questionablePidVids = array7;
						array2 = new int[2];
						num = 1114181948;
						continue;
					case 36:
						array6 = new string[7];
						num = 1114181939;
						continue;
					case 49:
						array[29] = "2";
						array[30] = "3";
						array[31] = "4";
						num = 1114181925;
						continue;
					case 64:
						array[116] = "Right Shift";
						num = 1114181908;
						continue;
					case 2:
						array[129] = "SysReq";
						num = 1114181888;
						continue;
					case 17:
						grVlAhMLLGfKqduocNqQXvlkamTc = array;
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
						array5 = new string[5];
						num = 1114181940;
						continue;
					case 0:
						array[33] = "6";
						array[34] = "7";
						num = 1114181933;
						continue;
					case 51:
						array4[1] = "Mouse Vertical";
						array4[2] = "Mouse Wheel";
						array4[3] = "Left Mouse Button";
						array4[4] = "Right Mouse Button";
						num = 1114181927;
						continue;
					case 22:
						array[114] = "Caps Lock";
						array[115] = "Scroll Lock";
						num = 1114181977;
						continue;
					case 58:
						questionableVIDs = array2;
						if (132 != grVlAhMLLGfKqduocNqQXvlkamTc.Length)
						{
							Logger.LogError("Consts.keyboardKeyCount does not match _keyboardKeyNames.Length!");
							num = 1114181918;
							continue;
						}
						goto case 7;
					case 29:
						array[83] = "\\";
						num = 1114181929;
						continue;
					case 28:
						SYqciECdkyzEmQlbFzYvCiHvueFi = new string[3] { "Mouse Right", "Mouse Up", "Mouse Wheel Up" };
						num = 1114181921;
						continue;
					case 18:
						return;
					}
					break;
				}
			}
		}
	}
}
