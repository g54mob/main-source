using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Rewired.Config;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CustomObfuscation(rename = false)]
	public static class Consts
	{
		public const int systemPlayerId = 9999999;

		public const string menuRoot = "Window/Rewired";

		internal const int programVersion1 = 1;

		internal const int programVersion2 = 1;

		internal const int programVersion3 = 26;

		internal const int programVersion4 = 0;

		internal const int dataVersion = 1;

		internal const int unityMajorVersion = 2017;

		internal const string unityMajorVersionIdentifier = "U2017";

		internal const bool isTrial = false;

		internal const string copyrightYear = "2019";

		internal const string defaultNamespace = "Rewired";

		internal const LogLevelFlags defaultLogLevel = LogLevelFlags.Info | LogLevelFlags.Warning | LogLevelFlags.Error;

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

		internal const int unityMaxJoysticks = 11;

		internal const int unityJoystickButtonCount = 20;

		internal const int unityJoystickStartingButtonKeycodeValue = 350;

		internal const int unityJoystickAxisCount = 29;

		internal const int unityJoystickLastJoystickIdWithButtonKeyCodes = 8;

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

		private static readonly string[] ZoDgayAyWqOyahIMMOwYBQJsEDLB;

		internal static readonly IList<string> unityMouseAxisPositiveNames;

		private static readonly string[] PQbzsQWFKGnDRBGAVUqUqXJLPtt;

		internal static readonly IList<string> unityMouseAxisNegativeNames;

		private static readonly string[] kHQyhLdYJgbwIQOhtTmmzdPnLpp;

		internal static readonly IList<string> rawInputUnifiedMouseElementNames;

		private static readonly string[] gnNGQxwtEroxWGDlZtCBFhArPUt;

		internal static readonly IList<string> rawInputUnifiedMouseAxisPositiveNames;

		private static readonly string[] zOsxfDNFggUhDZxijAWtBANtttK;

		internal static readonly IList<string> rawInputUnifiedMouseAxisNegativeNames;

		private static readonly string[] vgECLOwtxJncAJXlpCZvfdSIAgA;

		internal static readonly IList<int> unityMouseElementIdentifierIds;

		private static readonly int[] OumTzsxpKMxbdDIcgVLeydcKRwo;

		internal static readonly IList<int> rawInputUnifiedMouseElementIdentifierIds;

		private static readonly int[] IpVFyEBAJbkrVurFiZiPMKakDTr;

		internal static readonly IList<string> mouseAxisUnityNames;

		private static readonly string[] tRKBKkUnAnmCsYQyABMoOZGbvtp;

		internal static readonly IList<string> mouseButtonUnityNames;

		private static readonly string[] IupWbIPpOGitVfgMAyZuTisPMaAT;

		internal static readonly IList<string> keyboardKeyNames;

		private static readonly string[] NmXgDumPFCjxLCKnCuyWAAxcBrCP;

		internal static readonly IList<int> keyboardKeyValues;

		internal static readonly int[] _keyboardKeyValues;

		internal static readonly IList<string> modifierKeyShortNames;

		private static readonly string[] kDbIgbFgzAccAWUhRgQvvEIGpZrx;

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
			string[] array = default(string[]);
			string[] array8 = default(string[]);
			string[] array7 = default(string[]);
			string[] array2 = default(string[]);
			string[] array11 = default(string[]);
			string[] array3 = default(string[]);
			PidVid[] array10 = default(PidVid[]);
			string[] array4 = default(string[]);
			int[] array9 = default(int[]);
			string[] pQbzsQWFKGnDRBGAVUqUqXJLPtt = default(string[]);
			string[] array6 = default(string[]);
			string[] array5 = default(string[]);
			while (true)
			{
				int num = 2003019443;
				while (true)
				{
					switch (num ^ 0x7763A6B4)
					{
					case 24:
						break;
					default:
						return;
					case 12:
						array[86] = "_";
						num = 2003019429;
						continue;
					case 31:
						array8[5] = "Mouse Button 3";
						array8[6] = "Mouse Button 4";
						array8[7] = "Mouse Button 5";
						num = 2003019427;
						continue;
					case 11:
						array[50] = "Keypad -";
						array[51] = "Keypad +";
						num = 2003019413;
						continue;
					case 3:
						array[75] = ":";
						num = 2003019409;
						continue;
					case 27:
						array[63] = "#";
						num = 2003019401;
						continue;
					case 67:
						array8[9] = "Mouse Button 7";
						num = 2003019415;
						continue;
					case 80:
						kHQyhLdYJgbwIQOhtTmmzdPnLpp = array7;
						array2 = new string[10];
						num = 2003019451;
						continue;
					case 9:
						array[0] = "None";
						array[1] = "A";
						array[2] = "B";
						array[3] = "C";
						num = 2003019426;
						continue;
					case 64:
						array[62] = "\"";
						num = 2003019439;
						continue;
					case 77:
						array[10] = "J";
						array[11] = "K";
						num = 2003019416;
						continue;
					case 48:
						array[123] = "Left Command";
						array[124] = "Left Windows";
						array[125] = "Right Windows";
						array[126] = "AltGr";
						array[127] = "Help";
						array[128] = "Print";
						num = 2003019517;
						continue;
					case 41:
						array[88] = "Delete";
						array[89] = "Up Arrow";
						array[90] = "Down Arrow";
						num = 2003019434;
						continue;
					case 75:
						array[121] = "Left Alt";
						array[122] = "Right Command";
						num = 2003019396;
						continue;
					case 14:
						array11[0] = "MouseButton0";
						array11[1] = "MouseButton1";
						array11[2] = "MouseButton2";
						num = 2003019392;
						continue;
					case 26:
						array[13] = "M";
						array[14] = "N";
						array[15] = "O";
						array[16] = "P";
						num = 2003019410;
						continue;
					case 15:
						array2[0] = "Mouse Horizontal";
						array2[1] = "Mouse Vertical";
						array2[2] = "Mouse Wheel";
						num = 2003019452;
						continue;
					case 36:
						array[23] = "W";
						array[24] = "X";
						array[25] = "Y";
						array[26] = "Z";
						array[27] = "0";
						num = 2003019399;
						continue;
					case 40:
						array3[2] = "Mouse Wheel Up";
						num = 2003019423;
						continue;
					case 62:
						array[102] = "F5";
						array[103] = "F6";
						array[104] = "F7";
						array[105] = "F8";
						array[106] = "F9";
						num = 2003019442;
						continue;
					case 0:
						array2[8] = "Mouse Button 6";
						num = 2003019446;
						continue;
					case 50:
						array[37] = "Keypad 0";
						array[38] = "Keypad 1";
						num = 2003019454;
						continue;
					case 69:
						array10[1] = new PidVid(0, ushort.MaxValue);
						array10[2] = new PidVid(ushort.MaxValue, ushort.MaxValue);
						array10[3] = new PidVid(ushort.MaxValue, 0);
						questionablePidVids = array10;
						num = 2003019506;
						continue;
					case 6:
						array[107] = "F10";
						num = 2003019393;
						continue;
					case 22:
						array[4] = "D";
						num = 2003019417;
						continue;
					case 45:
						array[5] = "E";
						array[6] = "F";
						array[7] = "G";
						array[8] = "H";
						array[9] = "I";
						num = 2003019513;
						continue;
					case 44:
						array[12] = "L";
						num = 2003019438;
						continue;
					case 23:
						array8[8] = "Mouse Button 6";
						num = 2003019511;
						continue;
					case 63:
						array[43] = "Keypad 6";
						array[44] = "Keypad 7";
						num = 2003019441;
						continue;
					case 38:
						array[17] = "Q";
						array[18] = "R";
						array[19] = "S";
						array[20] = "T";
						array[21] = "U";
						array[22] = "V";
						num = 2003019408;
						continue;
					case 47:
						array[118] = "Right Control";
						array[119] = "Left Control";
						array[120] = "Right Alt";
						num = 2003019519;
						continue;
					case 7:
						hardwareTypeGuid_universalKeyboard = new Guid("ae4830f963db4d4c90b31beb46ecaf49");
						num = 2003019514;
						continue;
					case 66:
						array8[0] = "Mouse Horizontal";
						num = 2003019515;
						continue;
					case 13:
						array[114] = "Caps Lock";
						array[115] = "Scroll Lock";
						array[116] = "Right Shift";
						array[117] = "Left Shift";
						num = 2003019419;
						continue;
					case 46:
						array[40] = "Keypad 3";
						num = 2003019433;
						continue;
					case 21:
						array[57] = "Clear";
						array[58] = "Return";
						num = 2003019394;
						continue;
					case 73:
						array[129] = "SysReq";
						num = 2003019428;
						continue;
					case 33:
						array[52] = "Keypad Enter";
						array[53] = "Keypad =";
						array[54] = "Space";
						array[55] = "Backspace";
						array[56] = "Tab";
						num = 2003019425;
						continue;
					case 76:
						array7 = new string[3];
						num = 2003019516;
						continue;
					case 17:
						array[87] = "Back Quote";
						num = 2003019421;
						continue;
					case 28:
						array[100] = "F3";
						array[101] = "F4";
						num = 2003019402;
						continue;
					case 81:
						array4[0] = "Mouse Left";
						array4[1] = "Mouse Down";
						array4[2] = "Mouse Wheel Down";
						num = 2003019406;
						continue;
					case 71:
						array[83] = "\\";
						array[84] = "]";
						array[85] = "^";
						num = 2003019448;
						continue;
					case 70:
						array9 = new int[2] { 0, 65535 };
						num = 2003019518;
						continue;
					case 20:
						array[34] = "7";
						array[35] = "8";
						array[36] = "9";
						num = 2003019398;
						continue;
					case 39:
						array[30] = "3";
						array[31] = "4";
						array[32] = "5";
						array[33] = "6";
						num = 2003019424;
						continue;
					case 52:
						array11[3] = "MouseButton3";
						array11[4] = "MouseButton4";
						array11[5] = "MouseButton5";
						array11[6] = "MouseButton6";
						num = 2003019440;
						continue;
					case 65:
						array10[0] = new PidVid(0, 0);
						num = 2003019505;
						continue;
					case 78:
						hardwareTypeGuid_universalMouse = new Guid("ad60107cea394d9cb90656d39d07be95");
						array8 = new string[10];
						num = 2003019510;
						continue;
					case 4:
						IupWbIPpOGitVfgMAyZuTisPMaAT = array11;
						num = 2003019422;
						continue;
					case 35:
						ZoDgayAyWqOyahIMMOwYBQJsEDLB = array8;
						pQbzsQWFKGnDRBGAVUqUqXJLPtt = new string[3] { "Mouse Right", "Mouse Up", "Mouse Wheel Up" };
						num = 2003019404;
						continue;
					case 55:
						array6[0] = "MouseAxis1";
						array6[1] = "MouseAxis2";
						array6[2] = "MouseAxis3";
						tRKBKkUnAnmCsYQyABMoOZGbvtp = array6;
						array11 = new string[7];
						num = 2003019450;
						continue;
					case 25:
						modifierKeyShortNames = new ReadOnlyCollection<string>(kDbIgbFgzAccAWUhRgQvvEIGpZrx);
						array10 = new PidVid[4];
						num = 2003019509;
						continue;
					case 18:
						array[65] = "&";
						array[66] = "'";
						array[67] = "(";
						num = 2003019414;
						continue;
					case 49:
						array[77] = "<";
						array[78] = "=";
						array[79] = ">";
						array[80] = "?";
						array[81] = "@";
						array[82] = "[";
						num = 2003019507;
						continue;
					case 42:
						array = new string[132];
						num = 2003019453;
						continue;
					case 59:
						keyboardKeyNames = new ReadOnlyCollection<string>(NmXgDumPFCjxLCKnCuyWAAxcBrCP);
						keyboardKeyValues = new ReadOnlyCollection<int>(_keyboardKeyValues);
						num = 2003019437;
						continue;
					case 74:
						questionableVIDs = array9;
						if (132 != NmXgDumPFCjxLCKnCuyWAAxcBrCP.Length)
						{
							Logger.LogError("Consts.keyboardKeyCount does not match _keyboardKeyNames.Length!");
							num = 2003019445;
							continue;
						}
						goto case 1;
					case 79:
						array8[1] = "Mouse Vertical";
						array8[2] = "Mouse Wheel";
						array8[3] = "Left Mouse Button";
						array8[4] = "Right Mouse Button";
						num = 2003019435;
						continue;
					case 56:
						PQbzsQWFKGnDRBGAVUqUqXJLPtt = pQbzsQWFKGnDRBGAVUqUqXJLPtt;
						num = 2003019512;
						continue;
					case 72:
						array7[0] = "Mouse Left";
						array7[1] = "Mouse Down";
						array7[2] = "Mouse Wheel Down";
						num = 2003019492;
						continue;
					case 29:
						array[41] = "Keypad 4";
						array[42] = "Keypad 5";
						num = 2003019403;
						continue;
					case 57:
						array5[4] = "Cmd";
						kDbIgbFgzAccAWUhRgQvvEIGpZrx = array5;
						unityMouseElementNames = new ReadOnlyCollection<string>(ZoDgayAyWqOyahIMMOwYBQJsEDLB);
						unityMouseAxisPositiveNames = new ReadOnlyCollection<string>(PQbzsQWFKGnDRBGAVUqUqXJLPtt);
						unityMouseAxisNegativeNames = new ReadOnlyCollection<string>(kHQyhLdYJgbwIQOhtTmmzdPnLpp);
						unityMouseElementIdentifierIds = new ReadOnlyCollection<int>(OumTzsxpKMxbdDIcgVLeydcKRwo);
						rawInputUnifiedMouseElementNames = new ReadOnlyCollection<string>(gnNGQxwtEroxWGDlZtCBFhArPUt);
						rawInputUnifiedMouseAxisPositiveNames = new ReadOnlyCollection<string>(zOsxfDNFggUhDZxijAWtBANtttK);
						rawInputUnifiedMouseAxisNegativeNames = new ReadOnlyCollection<string>(vgECLOwtxJncAJXlpCZvfdSIAgA);
						rawInputUnifiedMouseElementIdentifierIds = new ReadOnlyCollection<int>(IpVFyEBAJbkrVurFiZiPMKakDTr);
						mouseAxisUnityNames = new ReadOnlyCollection<string>(tRKBKkUnAnmCsYQyABMoOZGbvtp);
						mouseButtonUnityNames = new ReadOnlyCollection<string>(IupWbIPpOGitVfgMAyZuTisPMaAT);
						num = 2003019407;
						continue;
					case 58:
						vgECLOwtxJncAJXlpCZvfdSIAgA = array4;
						OumTzsxpKMxbdDIcgVLeydcKRwo = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
						IpVFyEBAJbkrVurFiZiPMKakDTr = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
						array6 = new string[3];
						num = 2003019395;
						continue;
					case 19:
						array5 = new string[5] { "", "Ctrl", "Alt", "Shift", null };
						num = 2003019405;
						continue;
					case 34:
						array[68] = ")";
						array[69] = "*";
						array[70] = "+";
						array[71] = ",";
						array[72] = "-";
						array[73] = ".";
						array[74] = "/";
						num = 2003019447;
						continue;
					case 51:
						array[28] = "1";
						array[29] = "2";
						num = 2003019411;
						continue;
					case 1:
						if (132 != _keyboardKeyValues.Length)
						{
							Logger.LogError("Consts.keyboardKeyCount does not match _keyboardKeyValues.Length!");
							num = 2003019400;
							continue;
						}
						return;
					case 61:
						array[64] = "$";
						num = 2003019430;
						continue;
					case 8:
						array2[3] = "Left Mouse Button";
						array2[4] = "Right Mouse Button";
						array2[5] = "Mouse Button 3";
						array2[6] = "Mouse Button 4";
						array2[7] = "Mouse Button 5";
						num = 2003019444;
						continue;
					case 16:
						array[130] = "Break";
						array[131] = "Menu";
						NmXgDumPFCjxLCKnCuyWAAxcBrCP = array;
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
						num = 2003019431;
						continue;
					case 43:
						zOsxfDNFggUhDZxijAWtBANtttK = array3;
						array4 = new string[3];
						num = 2003019493;
						continue;
					case 37:
						array[76] = ";";
						num = 2003019397;
						continue;
					case 53:
						array[108] = "F11";
						array[109] = "F12";
						array[110] = "F13";
						array[111] = "F14";
						array[112] = "F15";
						array[113] = "Numlock";
						num = 2003019449;
						continue;
					case 30:
						array[91] = "Right Arrow";
						array[92] = "Left Arrow";
						array[93] = "Insert";
						array[94] = "Home";
						array[95] = "End";
						array[96] = "Page Up";
						array[97] = "Page Down";
						num = 2003019504;
						continue;
					case 32:
						array[49] = "Keypad *";
						num = 2003019455;
						continue;
					case 68:
						array[98] = "F1";
						array[99] = "F2";
						num = 2003019432;
						continue;
					case 5:
						array[45] = "Keypad 8";
						array[46] = "Keypad 9";
						array[47] = "Keypad .";
						array[48] = "Keypad /";
						num = 2003019412;
						continue;
					case 2:
						array2[9] = "Mouse Button 7";
						gnNGQxwtEroxWGDlZtCBFhArPUt = array2;
						array3 = new string[3] { "Mouse Right", "Mouse Up", null };
						num = 2003019420;
						continue;
					case 10:
						array[39] = "Keypad 2";
						num = 2003019418;
						continue;
					case 54:
						array[59] = "Pause";
						array[60] = "ESC";
						array[61] = "!";
						num = 2003019508;
						continue;
					case 60:
						return;
					}
					break;
				}
			}
		}
	}
}
