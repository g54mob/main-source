using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using DevConsole;
using SINetworking;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CinematicEffects;

public static class Options
{
	public class VariableInfo
	{
		public readonly SettingAttribute Setting;

		public readonly PropertyInfo Property;

		public VariableInfo(PropertyInfo property, SettingAttribute setting)
		{
			Property = property;
			Setting = setting;
		}

		public void LoadConf(ConfigFile conf, bool intel)
		{
			bool flag = false;
			string val;
			object result;
			if (conf.TryGet(Setting.Name, out val) && val.TryConvertToType(Property.PropertyType, out result))
			{
				SetValue(result);
				flag = true;
			}
			if (!flag)
			{
				if (Setting.DefaultIntelValue != null && intel)
				{
					SetValue(Setting.DefaultIntelValue);
				}
				else if (Setting.DefaultValue != null)
				{
					SetValue(Setting.DefaultValue);
				}
			}
		}

		public bool Comp(object val)
		{
			return val.Equals(GetValue());
		}

		public void SetValue(object val)
		{
			try
			{
				Property.SetValue(null, val, null);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed converting from {0} to {1} for var {2}:\n{3}".Format(val.GetType(), Property.PropertyType, Setting.Name, ex.ToString()));
			}
		}

		public object GetValue()
		{
			return Property.GetValue(null, null);
		}
	}

	public enum SettingType
	{
		Gameplay = 0,
		Graphics = 1,
		Ignore = 2
	}

	public enum GraphicsImpact
	{
		None = 0,
		Low = 1,
		Medium = 2,
		High = 3,
		VeryHigh = 4,
		Extreme = 5
	}

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public abstract class SettingAttribute : Attribute
	{
		public SettingType Type;

		public string Name;

		public string UIName;

		public string Tooltip;

		public string Group;

		public object DefaultValue;

		public object DefaultIntelValue;

		public int Order;

		public GraphicsImpact Impact;

		public bool Global = true;

		public bool SaveToConfig = true;

		public bool Shared;

		public bool InCampaign = true;

		public bool Online = true;

		public bool HideLabel;

		public bool OnlyHost;

		public SettingAttribute(string name, SettingType type, string group, int order, string uiName)
		{
			Type = type;
			Order = order;
			Name = name;
			Group = group;
			UIName = uiName;
		}
	}

	public class TextBoxSettingAttribute : SettingAttribute
	{
		public bool Password;

		public TextBoxSettingAttribute(string name, SettingType type, string group, int order, string uiName)
			: base(name, type, group, order, uiName)
		{
		}
	}

	public class ToggleSettingAttribute : SettingAttribute
	{
		public ToggleSettingAttribute(string name, SettingType type, string group, int order, string uiName)
			: base(name, type, group, order, uiName)
		{
		}
	}

	public class ButtonSettingAttribute : SettingAttribute
	{
		public string ButtonLabel;

		public ButtonSettingAttribute(string name, SettingType type, string group, int order, string uiName, string buttonLabel)
			: base(name, type, group, order, uiName)
		{
			ButtonLabel = buttonLabel;
		}
	}

	public class ComboSettingAttribute : SettingAttribute
	{
		public string ComboContent;

		public string ComboDepend;

		public bool Localize;

		public ComboSettingAttribute(string name, SettingType type, string group, int order, string uiName, string comboContent)
			: base(name, type, group, order, uiName)
		{
			ComboContent = comboContent;
		}
	}

	public class SliderSettingAttribute : SettingAttribute
	{
		public float Min;

		public float Max;

		public float Optimal = -1f;

		public float MapMin;

		public float MapMax;

		public string NumberFormat;

		public string SpecialZero;

		public string PluralLoc;

		public bool WholeNumber;

		public SliderSettingAttribute(string name, SettingType type, string group, int order, string uiName, float min, float max, bool wholeNumber)
			: base(name, type, group, order, uiName)
		{
			Min = min;
			Max = max;
			WholeNumber = wholeNumber;
		}

		public SliderSettingAttribute(string name, SettingType type, string group, int order, string uiName, float min, float max, bool wholeNumber, float mapMin, float mapMax, string format)
			: base(name, type, group, order, uiName)
		{
			Min = min;
			Max = max;
			MapMin = mapMin;
			MapMax = mapMax;
			NumberFormat = format;
			WholeNumber = wholeNumber;
		}
	}

	private delegate bool EnumWindowsProc(int hWnd, IntPtr lParam);

	public struct Rect
	{
		public int Left { get; set; }

		public int Top { get; set; }

		public int Right { get; set; }

		public int Bottom { get; set; }
	}

	public class Maximizer : MonoBehaviour
	{
		private IEnumerator Start()
		{
			yield return new WaitForSeconds(0.25f);
			if (MaximizeWindow(true) && (Screen.width < 1024 || Screen.height < 768))
			{
				_lastFullscreen = FullScreenMode.Windowed;
				Screen.SetResolution(_lastResolution.width, _lastResolution.height, FullScreenMode.Windowed, _lastResolution.refreshRate);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private static bool DisableResolutionChange;

	public static Vector2? MainPanelOffset;

	private static bool FailedToLoad;

	private static bool Loaded;

	private static bool _edgeScroll;

	private static bool _ambientOcclusion;

	private static int _ssaa;

	private static int _secondSpeed;

	private static bool _ssr;

	private static bool _fxaa;

	private static bool _smaa;

	private static bool _tiltShift;

	private static bool _bloom;

	private static bool _opaqueGlass;

	private static bool _hideGrid;

	private static float _scrollSpeed;

	private static float _zoomSpeed;

	private static float _rotationSpeed;

	private static FullScreenMode _lastFullscreen;

	private static Resolution _lastResolution;

	private static bool _consoleOnError;

	private static float _uiSize;

	private static bool _uiPixelPerfect;

	private static float _gamma;

	private static int _grassQuality;

	private static bool _grassOutdoor;

	private static string _lastVersion;

	private static bool _injectMods;

	private static Color[] _customColors;

	public static HashSet<string> UnlockedRewards;

	public static HashSet<string> IgnoreQuestions;

	private static HashSet<string> _favFurns;

	public static string SteamJoinLobby;

	public static bool ForceLAN;

	private static Dictionary<string, SVector3> WindowSizes;

	private static Dictionary<string, float> ColumnWidths;

	private static bool[] Hints;

	public static Dictionary<string, VariableInfo> SettingFields;

	private const int SW_MAXIMIZE = 3;

	private const int SW_NORMAL = 1;

	private const uint SW_MAXIMIZEBOX = 65536u;

	private static int _unityWindowHandle;

	private static bool _unityWindowFound;

	public static bool DisableSaving;

	public static string CommandLines;

	public static Dictionary<string, Func<Dictionary<string, object>>> ComboContentFunctions;

	public static string SettingsFile
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "settings.txt");
		}
	}

	public static string SharedSettingsFile
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "sharedsettings.txt");
		}
	}

	private static string WindowSizeFile
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "WindowSizes.txt");
		}
	}

	private static string ColumnWidthFile
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "ColumnWidths.txt");
		}
	}

	private static string HintFile
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "Hints.bin");
		}
	}

	public static bool InjectMods
	{
		get
		{
			return _injectMods;
		}
	}

	[TextBoxSetting("Password", SettingType.Gameplay, "Multiplayer", 0, "Password", OnlyHost = true, Password = true, SaveToConfig = false, Global = false)]
	public static string Password
	{
		get
		{
			return GameSettings.Instance.NetworkData.Password ?? "";
		}
		set
		{
			GameSettings.Instance.NetworkData.SetPassword(value);
		}
	}

	[ComboSetting("DayLimit", SettingType.Gameplay, "Multiplayer", 1, "DayLimit", "GetRoundLimits", Tooltip = "DayLimitHint", OnlyHost = true, SaveToConfig = false, Global = false)]
	public static float DayLimit
	{
		get
		{
			return GameSettings.Instance.RoundLimit;
		}
		set
		{
			NetworkMessaging.SendUpdateRoundLimit(value, NetworkMessaging.MessageTarget.Everyone, 0);
			NetworkManager.SetLobbyMetaData("RoundLimit", value.ToString());
		}
	}

	[ComboSetting("DayLimitType", SettingType.Gameplay, "Multiplayer", 1, "DayLimitType", "GetRoundTypes", OnlyHost = true, SaveToConfig = false, Global = false)]
	public static NetworkLobby.RoundLimitType RoundType
	{
		get
		{
			return GameSettings.Instance.RoundType;
		}
		set
		{
			NetworkMessaging.SendUpdateRoundType(value, NetworkMessaging.MessageTarget.Everyone, 0);
			int num = (int)value;
			NetworkManager.SetLobbyMetaData("RoundType", num.ToString());
		}
	}

	[ComboSetting("Difficulty", SettingType.Gameplay, "Gameplay", 2, "Difficulty", "GetDifficulties", Online = false, Localize = true, Global = false, SaveToConfig = false, InCampaign = false)]
	public static DifficultyValues.DifficultySetting Difficulty
	{
		get
		{
			return GameSettings.Instance.Difficulty;
		}
		set
		{
			GameSettings.Instance.Difficulty = value;
			HUD.Instance.UpdateDifficultyButtons();
			GameSettings.Instance.PostChangeDifficulty();
		}
	}

	[ButtonSetting("CustomDifficulty", SettingType.Gameplay, "Gameplay", 3, "", "CustomDifficulty", Online = false, SaveToConfig = false, Global = false, InCampaign = false)]
	public static bool CustomDifficulty
	{
		get
		{
			return false;
		}
		set
		{
			CustomDifficultyAction();
		}
	}

	[SliderSetting("SecondSpeed", SettingType.Gameplay, "Gameplay", 4, "SecondSpeed", 2f, 25f, true, 2f, 25f, "{0:F0}x", Shared = true)]
	public static int SecondSpeed
	{
		get
		{
			return _secondSpeed;
		}
		set
		{
			_secondSpeed = value.Clamp(2, 25);
			HUD.UpdateSpeeds();
		}
	}

	[SliderSetting("DefaultPriority", SettingType.Gameplay, "Gameplay", 5, "DefaultPriority", 1f, 10f, true, 1f, 10f, "{0}", Tooltip = "DefaultPriorityTip", Global = false, SaveToConfig = false)]
	public static int DefaultPriority
	{
		get
		{
			return GameSettings.DefaultPriority;
		}
		set
		{
			GameSettings.Instance.LocalDefaultPriority = value.Clamp(1, 10);
		}
	}

	[ToggleSetting("AutoSkip", SettingType.Gameplay, "Gameplay", 6, "Auto-skip day", Tooltip = "AutoSkipHint", DefaultValue = false, Shared = true)]
	public static bool AutoSkip { get; set; }

	[ToggleSetting("AutoSave", SettingType.Gameplay, "Gameplay", 7, "Auto-save", Tooltip = "AutoSaveHint", DefaultValue = true, Shared = true)]
	public static bool AutoSave { get; set; }

	[SliderSetting("BuildModeSaveInterval", SettingType.Gameplay, "Gameplay", 8, "BuildModeSaveInterval", 0f, 30f, true, 0f, 30f, null, SpecialZero = "Never", PluralLoc = "Minute", Tooltip = "BuildModeSaveIntervalTip", DefaultValue = 10, Shared = true)]
	public static int BuildModeSaveInterval { get; set; }

	[ToggleSetting("Backup", SettingType.Gameplay, "Gameplay", 9, "Backup", Tooltip = "BackupDesc", DefaultValue = true, Shared = true)]
	public static bool Backup { get; set; }

	[ToggleSetting("RunInBackground", SettingType.Gameplay, "Gameplay", 10, "Run in background", Online = false, DefaultValue = false, Shared = true)]
	public static bool RunInBackground
	{
		get
		{
			return Application.runInBackground;
		}
		set
		{
			Application.runInBackground = NetworkManager.IsConnected || value;
		}
	}

	[ToggleSetting("ShiftToPlace", SettingType.Gameplay, "Gameplay", 11, "ShiftToPlaceMultiple", Tooltip = "ShiftToPlaceHint", DefaultValue = true, Shared = true)]
	public static bool ShiftToPlace { get; set; }

	[ToggleSetting("PermanentUnlock", SettingType.Gameplay, "Gameplay", 12, "PermanentUnlock", Tooltip = "PermanentUnlockHint", Global = false, SaveToConfig = false)]
	public static bool PermanentUnlock
	{
		get
		{
			return GameSettings.Instance.PermanentUnlock;
		}
		set
		{
			GameSettings.Instance.TogglePermanentUnlock(value);
		}
	}

	public static bool ShouldAutoSave
	{
		get
		{
			if (!AutoSave)
			{
				return GameSettings.Instance.IsNetworkMode;
			}
			return true;
		}
	}

	[ToggleSetting("EdgeScroll", SettingType.Gameplay, "Controls", 14, "Mouse edge scrolling", Shared = true)]
	public static bool EdgeScroll
	{
		get
		{
			return _edgeScroll;
		}
		set
		{
			_edgeScroll = value;
			Cursor.lockState = CursorLock();
		}
	}

	[SliderSetting("ScrollSpeed", SettingType.Gameplay, "Controls", 15, "Scroll speed", 1f, 200f, false, 1f, 200f, "{0:F0}%", Optimal = 100f)]
	public static float ScrollSpeed
	{
		get
		{
			return _scrollSpeed;
		}
		set
		{
			_scrollSpeed = value;
			CameraScript.ApplySpeeds();
		}
	}

	[SliderSetting("ZoomSpeed", SettingType.Gameplay, "Controls", 16, "Zoom speed", 1f, 100f, false, 2f, 200f, "{0:F0}%", Optimal = 50f)]
	public static float ZoomSpeed
	{
		get
		{
			return _zoomSpeed;
		}
		set
		{
			_zoomSpeed = value;
			CameraScript.ApplySpeeds();
		}
	}

	[SliderSetting("RotationSpeed", SettingType.Gameplay, "Controls", 17, "Rotation speed", 1f, 20f, false, 10f, 200f, "{0:F0}%", Optimal = 10f)]
	public static float RotationSpeed
	{
		get
		{
			return _rotationSpeed;
		}
		set
		{
			_rotationSpeed = value;
			CameraScript.ApplySpeeds();
		}
	}

	[ToggleSetting("Tutorial", SettingType.Gameplay, "Help", 20, "Tutorial", DefaultValue = true, Shared = true)]
	public static bool Tutorial { get; set; }

	[ToggleSetting("Hints", SettingType.Gameplay, "Help", 21, "Hints", DefaultValue = true, Shared = true)]
	public static bool HintsEnabled { get; set; }

	[ButtonSetting("ResetHint", SettingType.Gameplay, "Help", 22, "", "Reset", SaveToConfig = false)]
	public static bool ResetHint
	{
		get
		{
			return false;
		}
		set
		{
			ResetHints();
		}
	}

	[ComboSetting("Currency", SettingType.Gameplay, "OptionsUnits", 30, "Currency", "GetCurrencies", DefaultValue = "Standard", Shared = true)]
	public static string Currency { get; set; }

	[ToggleSetting("CurrencyShortForm", SettingType.Gameplay, "OptionsUnits", 31, "Currency short form", DefaultValue = false, Shared = true)]
	public static bool CurrencyShortForm { get; set; }

	[ToggleSetting("AMPM", SettingType.Gameplay, "OptionsUnits", 32, "AM/PM", Shared = true)]
	public static bool AMPM
	{
		get
		{
			return SDateTime.AMPM;
		}
		set
		{
			SDateTime.AMPM = value;
		}
	}

	[ToggleSetting("Celsius", SettingType.Gameplay, "OptionsUnits", 33, "Celsius", DefaultValue = true, Shared = true)]
	public static bool Celsius { get; set; }

	[ComboSetting("ColorBlindness", SettingType.Gameplay, "UI", 40, "Colorblindness", "GetColorBlindness", Localize = false, Shared = true)]
	public static int ColorBlindness { get; set; }

	[ButtonSetting("CustomColor", SettingType.Gameplay, "UI", 41, "", "CustomDifficulty", SaveToConfig = false)]
	public static Color[] CustomColors
	{
		get
		{
			if (_customColors == null)
			{
				InitializeCustomColors();
			}
			return _customColors;
		}
		set
		{
			ConstructColorSelectionWindow();
		}
	}

	[ComboSetting("UISize", SettingType.Gameplay, "UI", 42, "UI size", "GetUISizes")]
	public static float UISize
	{
		get
		{
			return _uiSize;
		}
		set
		{
			ChangeUISize(value, value > 1f);
		}
	}

	[ToggleSetting("CustomCursor", SettingType.Gameplay, "UI", 43, "CustomCursor", DefaultValue = true, Shared = true)]
	public static bool CustomCursor { get; set; }

	[ButtonSetting("Window sizes", SettingType.Gameplay, "UI", 44, "WindowPref", "Reset", SaveToConfig = false)]
	public static bool ResetWindowSizes
	{
		get
		{
			return false;
		}
		set
		{
			ResetSizes();
		}
	}

	[ButtonSetting("Column widths", SettingType.Gameplay, "UI", 45, "Column widths", "Reset", SaveToConfig = false)]
	public static bool ResetColumnWidths
	{
		get
		{
			return false;
		}
		set
		{
			ResetWidths();
		}
	}

	[ButtonSetting("Dialog confirmations", SettingType.Gameplay, "UI", 46, "Dialog confirmations", "Reset", SaveToConfig = false)]
	public static bool ResetDialogs
	{
		get
		{
			return false;
		}
		set
		{
			ResetConfirmations();
		}
	}

	[ToggleSetting("GridPanel", SettingType.Gameplay, "UI", 47, "Old grid panel", Tooltip = "OldGridPanelHint", DefaultValue = false, Shared = true)]
	public static bool GridPanel { get; set; }

	[ToggleSetting("DiagonalRoomHighlights", SettingType.Gameplay, "Miscellaneous", 50, "DiagonalRoomHighlights", Tooltip = "DiagonalRoomHighlightHint", DefaultValue = true, Shared = true)]
	public static bool DiagonalRoomHighlights { get; set; }

	[ToggleSetting("HideGrid", SettingType.Gameplay, "Miscellaneous", 51, "HideGrid", Tooltip = "HideGridHint", DefaultValue = false, Shared = true)]
	public static bool HideGrid
	{
		get
		{
			return _hideGrid;
		}
		set
		{
			_hideGrid = value;
			BuildController instance = BuildController.Instance;
			if ((object)instance != null)
			{
				instance.UpdateGridHighlight();
			}
		}
	}

	[ToggleSetting("SaveConsole", SettingType.Gameplay, "Miscellaneous", 52, "SaveConsole", DefaultValue = false, Shared = true)]
	public static bool SaveConsole { get; set; }

	[ToggleSetting("FurnTexCompression", SettingType.Gameplay, "Miscellaneous", 53, "ModTextureComp", Tooltip = "ModTextureCompTip", DefaultValue = true, Shared = false)]
	public static bool FurnTexCompression { get; set; }

	[ComboSetting("ScreenResolution", SettingType.Graphics, "Quality", 0, "Resolution", "GetScreenResolutions")]
	public static ValueTuple<int, int> SResolution
	{
		get
		{
			return new ValueTuple<int, int>(_lastResolution.width, _lastResolution.height);
		}
		set
		{
			UpdateResolution(value, _lastFullscreen);
			SaveToFile();
		}
	}

	[ComboSetting("Fullscreen", SettingType.Graphics, "Quality", 3, "Fullscreen", "GetFullScreenOptions", Localize = true)]
	public static FullScreenMode Fullscreen
	{
		get
		{
			return _lastFullscreen;
		}
		set
		{
			UpdateResolution(_lastResolution, value);
		}
	}

	[ButtonSetting("Auto graphics", SettingType.Graphics, "Quality", 5, null, "AutoGFXButton", SaveToConfig = false)]
	public static bool AutoGraphicsTest
	{
		get
		{
			return false;
		}
		set
		{
			AutoGraphics();
		}
	}

	[ComboSetting("GFX Quality", SettingType.Graphics, "Quality", 4, "GFXQUality", "GetQualityOptions", Localize = true, SaveToConfig = false)]
	public static int GraphicsQuality
	{
		get
		{
			return AutoGfxSettings.GetSetting() + 1;
		}
		set
		{
			if (value > 0 && AutoGfxSettings.GetSetting() != value - 1)
			{
				AutoGfxSettings.SetLevel(AutoGfxSettings.DefaultSettings[value - 1]);
				SaveToFile();
				OptionsWindow optionsWindow = UnityEngine.Object.FindObjectOfType(typeof(OptionsWindow)) as OptionsWindow;
				if (optionsWindow != null)
				{
					optionsWindow.RefreshGFXSettings();
				}
			}
		}
	}

	[ComboSetting("VSync", SettingType.Graphics, "Quality", 6, "VSync", "GetVSyncs", Localize = true, Tooltip = "VSyncHint", DefaultValue = 1)]
	public static int VSync
	{
		get
		{
			return QualitySettings.vSyncCount;
		}
		set
		{
			QualitySettings.vSyncCount = value;
		}
	}

	[TextBoxSetting("TargetFrameRate", SettingType.Graphics, "Quality", 7, "Target FPS", Tooltip = "TargetFPSTip", DefaultValue = 60)]
	public static int TargetFrameRate
	{
		get
		{
			return Application.targetFrameRate;
		}
		set
		{
			Application.targetFrameRate = value;
		}
	}

	[SliderSetting("Gamma", SettingType.Graphics, "Quality", 8, "Gamma", 0.1f, 0.9f, false, 0f, 100f, "{0:F0}%", Optimal = 0.5f)]
	public static float Gamma
	{
		get
		{
			return _gamma;
		}
		set
		{
			_gamma = value;
			CameraScript.ApplyOptions();
		}
	}

	[ToggleSetting("FXAA", SettingType.Graphics, "Quality", 9, "FXAA", Tooltip = "FXAADetails", Impact = GraphicsImpact.Medium)]
	public static bool FXAA
	{
		get
		{
			return _fxaa;
		}
		set
		{
			_fxaa = value;
			CameraScript.ApplyOptions();
		}
	}

	[ToggleSetting("SMAA", SettingType.Graphics, "Quality", 10, "SMAA", Tooltip = "SMAADetails", Impact = GraphicsImpact.Medium)]
	public static bool SMAA
	{
		get
		{
			return _smaa;
		}
		set
		{
			_smaa = CheckSMAASupport() && value;
			CameraScript.ApplyOptions();
		}
	}

	[SliderSetting("SSAA", SettingType.Graphics, "Quality", 11, "SSAA", 10f, 20f, true, 1f, 2f, "{0:F1}x", Tooltip = "SSAADetails", Impact = GraphicsImpact.Extreme)]
	public static int SSAA
	{
		get
		{
			return _ssaa;
		}
		set
		{
			_ssaa = Mathf.Clamp(value, 10, 20);
			CameraScript.ApplyOptions();
		}
	}

	[ToggleSetting("Shadows", SettingType.Graphics, "Effects", 20, "Shadows", Tooltip = "ShadowsHint", DefaultValue = true, DefaultIntelValue = false, Impact = GraphicsImpact.High)]
	public static bool Shadows
	{
		get
		{
			return QualitySettings.shadowDistance > 0f;
		}
		set
		{
			QualitySettings.shadowDistance = (value ? 500 : 0);
		}
	}

	[SliderSetting("ShadowQuality", SettingType.Graphics, "Effects", 21, "Shadow quality", 0f, 3f, true, DefaultValue = 3)]
	public static int ShadowQuality
	{
		get
		{
			return (int)QualitySettings.shadowResolution;
		}
		set
		{
			QualitySettings.shadowResolution = (ShadowResolution)value;
		}
	}

	[ToggleSetting("MoreShadow", SettingType.Graphics, "Effects", 22, "More shadows", Tooltip = "MoreShadowsHint", DefaultValue = false, Impact = GraphicsImpact.Medium)]
	public static bool MoreShadow { get; set; }

	[ToggleSetting("AmbientOcclusion", SettingType.Graphics, "Effects", 23, "Ambient occlusion", Tooltip = "AmbientOcclusionHint", Impact = GraphicsImpact.Low, DefaultIntelValue = false)]
	public static bool AmbientOcclusion
	{
		get
		{
			return _ambientOcclusion;
		}
		set
		{
			_ambientOcclusion = value;
			CameraScript.ApplyOptions();
		}
	}

	[ToggleSetting("TiltShift", SettingType.Graphics, "Effects", 24, "Tilt shift", Tooltip = "TiltShiftHint", Impact = GraphicsImpact.Low)]
	public static bool TiltShift
	{
		get
		{
			return _tiltShift;
		}
		set
		{
			_tiltShift = value;
			CameraScript.ApplyOptions();
		}
	}

	[ToggleSetting("Bloom", SettingType.Graphics, "Effects", 25, "Bloom", Tooltip = "BloomHint", Impact = GraphicsImpact.Medium)]
	public static bool Bloom
	{
		get
		{
			return _bloom;
		}
		set
		{
			_bloom = value;
			CameraScript.ApplyOptions();
		}
	}

	[ToggleSetting("SSR", SettingType.Graphics, "Effects", 26, "Screen Space Reflections", Tooltip = "SSRHint", Impact = GraphicsImpact.VeryHigh)]
	public static bool SSR
	{
		get
		{
			return _ssr;
		}
		set
		{
			_ssr = value;
			CameraScript.ApplyOptions();
		}
	}

	[SliderSetting("GrassQuality", SettingType.Graphics, "Effects", 27, "GrassQuality", 0f, 3f, true, Impact = GraphicsImpact.Medium, DefaultIntelValue = 0)]
	public static int GrassQuality
	{
		get
		{
			return _grassQuality;
		}
		set
		{
			_grassQuality = value;
			GrassSystem.RefreshGrassQuality();
		}
	}

	[ToggleSetting("GrassOutdoors", SettingType.Graphics, "Effects", 28, "GrassOutdoors", Impact = GraphicsImpact.Medium, Tooltip = "GrassOutdoorHint")]
	public static bool GrassOutdoors
	{
		get
		{
			return _grassOutdoor;
		}
		set
		{
			_grassOutdoor = value;
			GrassSystem.RefreshGrassQuality();
		}
	}

	[ToggleSetting("EnvEffects", SettingType.Graphics, "Effects", 29, "EnvEffects", Tooltip = "EnvEffectsHint", DefaultValue = true, Impact = GraphicsImpact.Low, Shared = true)]
	public static bool EnvEffects { get; set; }

	[ToggleSetting("Clouds", SettingType.Graphics, "Effects", 30, "Clouds", DefaultValue = true, Impact = GraphicsImpact.Low, Shared = true)]
	public static bool Clouds { get; set; }

	[ToggleSetting("Flickering", SettingType.Graphics, "Effects", 31, "Flickering", Tooltip = "FlickeringTip", DefaultValue = true, Shared = true)]
	public static bool Flickering { get; set; }

	[ToggleSetting("DynamicPaths", SettingType.Graphics, "Effects", 32, "DynamicPaths", DefaultValue = true, DefaultIntelValue = false, Tooltip = "DynamicPathsHint", Impact = GraphicsImpact.Low, Shared = true)]
	public static bool DynamicPaths { get; set; }

	[ComboSetting("WorldBackground", SettingType.Graphics, "Effects", 33, "WorldBackground", "GetWorldBackground", Localize = true, DefaultValue = 0, Tooltip = "WorldBackgroundTip", Shared = true)]
	public static int WorldBackground { get; set; }

	[ToggleSetting("OpaqueGlass", SettingType.Graphics, "Optimization", 34, "Opaque glass", Tooltip = "OpaqueGlassDesc", DefaultIntelValue = true, Impact = GraphicsImpact.High)]
	public static bool OpaqueGlass
	{
		get
		{
			return _opaqueGlass;
		}
		set
		{
			_opaqueGlass = value;
			GameSettings.GlassOpaqueChange();
		}
	}

	[ToggleSetting("EmployeesAllFloor", SettingType.Graphics, "Optimization", 35, "EmployeesAllFloor", Tooltip = "EmployeesAllFloorTip", DefaultValue = false, Impact = GraphicsImpact.Extreme)]
	public static bool EmployeesAllFloor { get; set; }

	[ToggleSetting("UIPP", SettingType.Graphics, "UI", 42, "UIPixelPerfect", Tooltip = "UIPixelPerfectHint")]
	public static bool UIPP
	{
		get
		{
			return _uiPixelPerfect;
		}
		set
		{
			_uiPixelPerfect = value;
			WindowManager.UpdateUIPP();
		}
	}

	[ToggleSetting("AskReporting", SettingType.Ignore, "None", -1, null, DefaultValue = true, Shared = true)]
	public static bool AskReporting { get; set; }

	[ToggleSetting("CustomizationAdvanced", SettingType.Ignore, "None", -1, null, DefaultValue = false, Shared = true)]
	public static bool CustomizationAdvanced { get; set; }

	[ToggleSetting("ConsoleOnError", SettingType.Ignore, "None", -1, null, Shared = true)]
	public static bool ConsoleOnError
	{
		get
		{
			if (InputController.IsBound(InputController.Keys.NewConsole))
			{
				return _consoleOnError;
			}
			return false;
		}
		set
		{
			_consoleOnError = value;
		}
	}

	[ToggleSetting("ConsoleVerbose", SettingType.Ignore, "None", -1, null, DefaultValue = false, Shared = true)]
	public static bool ConsoleVerbose { get; set; }

	[ToggleSetting("ColorBrightnessSlider", SettingType.Ignore, "None", -1, null, DefaultValue = true)]
	public static bool ColorBrightnessSlider { get; set; }

	[TextBoxSetting("LastVersion", SettingType.Ignore, "None", -1, null, Shared = true)]
	public static string LastVersion
	{
		get
		{
			return _lastVersion;
		}
		set
		{
			_lastVersion = value;
		}
	}

	[TextBoxSetting("LastIP", SettingType.Ignore, "None", -1, null, DefaultValue = "")]
	public static string LastIP { get; set; }

	[TextBoxSetting("ForcedIP", SettingType.Ignore, "None", -1, null, DefaultValue = "")]
	public static string ForcedIP { get; set; }

	[TextBoxSetting("GamePort", SettingType.Ignore, "None", -1, null)]
	public static int GamePort { get; set; }

	[TextBoxSetting("LobbyPort", SettingType.Ignore, "None", -1, null)]
	public static int LobbyPort { get; set; }

	[ToggleSetting("LocalizationFallback", SettingType.Ignore, "UI", -1, null, DefaultValue = true, Shared = true)]
	public static bool LocalizationFallback { get; set; }

	public static void AddFavFurn(Furniture furn)
	{
		_favFurns.Add(furn.name);
		SaveToFile();
	}

	public static void RemoveFavFurn(Furniture furn)
	{
		_favFurns.Remove(furn.name);
		SaveToFile();
	}

	public static bool IsFavFurn(Furniture furn)
	{
		return _favFurns.Contains(furn.name);
	}

	public static bool HasFavoriteFurns()
	{
		return _favFurns.Count > 0;
	}

	[DllImport("user32.dll")]
	private static extern int MoveWindow(int hwnd, int x, int y, int nWidth, int nHeight, int bRepaint);

	[DllImport("user32.dll")]
	private static extern int SetWindowLongPtrA(int hwnd, int nIndex, uint dwNewLong);

	[DllImport("user32.dll", EntryPoint = "SetWindowLongPtrA")]
	private static extern uint GetWindowLongPtrA(int hwnd, int nIndex);

	[DllImport("user32.dll")]
	private static extern bool GetWindowRect(int hwnd, ref Rect rectangle);

	[DllImport("user32.dll")]
	private static extern bool ShowWindow(int hWnd, int nCmdShow);

	[DllImport("user32.dll")]
	private static extern bool IsZoomed(int hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool EnumWindows(EnumWindowsProc callback, IntPtr extraData);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetWindowThreadProcessId(int handle, out int processId);

	private static bool MaximizeWindow(bool maximize)
	{
		if (_unityWindowFound)
		{
			try
			{
				uint windowLongPtrA = GetWindowLongPtrA(_unityWindowHandle, -16);
				SetWindowLongPtrA(_unityWindowHandle, -16, windowLongPtrA | 0x10000);
				ShowWindow(_unityWindowHandle, (!maximize) ? 1 : 3);
				return true;
			}
			catch (Exception)
			{
			}
		}
		return false;
	}

	public static bool EnumWindowsCallBack(int hWnd, IntPtr lParam)
	{
		int processId;
		GetWindowThreadProcessId(hWnd, out processId);
		int id = Process.GetCurrentProcess().Id;
		if (processId == id)
		{
			_unityWindowHandle = hWnd;
			_unityWindowFound = true;
			return false;
		}
		return true;
	}

	private static void OffsetMainWindow(int xoffset, int yoffset)
	{
		if (_unityWindowFound)
		{
			MoveWindow(_unityWindowHandle, xoffset, yoffset, Screen.width, Screen.height, 1);
		}
	}

	private static Vector2Int GetMainWindowPosition()
	{
		if (_unityWindowFound)
		{
			Rect rectangle = default(Rect);
			if (GetWindowRect(_unityWindowHandle, ref rectangle))
			{
				return new Vector2Int(rectangle.Left, rectangle.Top);
			}
		}
		return Vector2Int.zero;
	}

	private static void ChangeUISize(float size, bool question)
	{
		float last = _uiSize;
		_uiSize = Mathf.Clamp(Mathf.Round(size * 10f) / 10f, 1f, 2f);
		if (!(WindowManager.Instance != null))
		{
			return;
		}
		WindowManager.Instance.Canvas.GetComponent<CanvasScaler>().scaleFactor = _uiSize;
		if (WindowManager.Instance.ExtraScaler != null)
		{
			WindowManager.Instance.ExtraScaler.scaleFactor = _uiSize;
		}
		if (question)
		{
			WindowManager.Instance.ShowMessageBox("UISizeConf".Loc(), true, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Yes", delegate
			{
			}), new KeyValuePair<string, Action>("No", delegate
			{
				ChangeUISize(last, false);
				SaveToFile();
			}));
		}
	}

	public static void AutoGraphics()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			if (!GameSettings.Instance.IsNetworkMode)
			{
				WindowManager.Instance.ShowMessageBox("GfxTestWarning".Loc(), false, DialogWindow.DialogType.Warning, delegate
				{
					GameSettings.UnloadNow();
					ErrorLogging.FirstOfScene = true;
					ErrorLogging.SceneChanging = true;
					GameSettings.Instance = null;
					DevConsole.Console.SaveConsole();
					SceneManager.LoadScene("AutoGraphicsSettings");
				});
			}
		}
		else
		{
			DialogWindow diag = WindowManager.SpawnDialog();
			diag.Show("GfxTestResWarning".Loc(), false, DialogWindow.DialogType.Information, new KeyValuePair<string, Action>("Yes", delegate
			{
				ErrorLogging.SceneChanging = true;
				DevConsole.Console.SaveConsole();
				SceneManager.LoadScene("AutoGraphicsSettings");
			}), new KeyValuePair<string, Action>("No", delegate
			{
				diag.Window.Close();
			}));
		}
	}

	public static void SetAndSave(string setting, object value)
	{
		VariableInfo variableInfo = SettingFields[setting];
		if (value is float && variableInfo.Property.PropertyType == typeof(int))
		{
			value = (int)(float)value;
		}
		if (!variableInfo.Comp(value))
		{
			variableInfo.SetValue(value);
			if (variableInfo.Setting.SaveToConfig && !DisableSaving)
			{
				SaveToFile();
			}
		}
	}

	static Options()
	{
		DisableResolutionChange = false;
		MainPanelOffset = null;
		FailedToLoad = false;
		Loaded = false;
		_edgeScroll = false;
		_ambientOcclusion = true;
		_ssaa = 10;
		_secondSpeed = 10;
		_ssr = false;
		_fxaa = true;
		_smaa = false;
		_tiltShift = true;
		_bloom = true;
		_opaqueGlass = false;
		_hideGrid = false;
		_scrollSpeed = 100f;
		_zoomSpeed = 50f;
		_rotationSpeed = 10f;
		_lastFullscreen = FullScreenMode.Windowed;
		_consoleOnError = true;
		_uiSize = 1f;
		_uiPixelPerfect = true;
		_gamma = 0.5f;
		_grassQuality = 1;
		_grassOutdoor = false;
		_lastVersion = "Alpha 10.10.11";
		_injectMods = true;
		_customColors = null;
		UnlockedRewards = new HashSet<string>();
		IgnoreQuestions = new HashSet<string>();
		_favFurns = new HashSet<string>();
		SteamJoinLobby = null;
		ForceLAN = false;
		GamePort = 58588;
		LobbyPort = 58585;
		WindowSizes = new Dictionary<string, SVector3>();
		ColumnWidths = new Dictionary<string, float>();
		SettingFields = new Dictionary<string, VariableInfo>();
		_unityWindowFound = false;
		DisableSaving = false;
		ComboContentFunctions = new Dictionary<string, Func<Dictionary<string, object>>>
		{
			{ "GetDifficulties", GetDifficulties },
			{ "GetCurrencies", GetCurrencies },
			{ "GetResolutions", GetResolutions },
			{ "GetScreenResolutions", GetScreenResolutions },
			{ "GetFullScreenOptions", GetFullScreenOptions },
			{ "GetHz", GetHz },
			{ "GetUISizes", GetUISizes },
			{ "GetVSyncs", GetVSyncs },
			{ "GetWorldBackground", GetWorldBackground },
			{ "GetQualityOptions", GetQualityOptions },
			{ "GetColorBlindness", GetColorBlindness },
			{ "GetRoundLimits", GetRoundLimits },
			{ "GetRoundTypes", GetRoundTypes }
		};
		_lastResolution = FindRes(1024, 768, 60);
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		CommandLines = string.Join("\n", commandLineArgs);
		bool flag = false;
		int xoffset = 0;
		int yoffset = 0;
		EnumWindows(EnumWindowsCallBack, IntPtr.Zero);
		try
		{
			Vector2Int mainWindowPosition = GetMainWindowPosition();
			xoffset = mainWindowPosition.x;
			yoffset = mainWindowPosition.y;
		}
		catch (Exception)
		{
		}
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			string text = commandLineArgs[i].ToLower();
			if (text.Equals("-disableresolution"))
			{
				DisableResolutionChange = true;
			}
			else if (text.Equals("-resizepanel") && i + 1 < commandLineArgs.Length)
			{
				string[] array = commandLineArgs[i + 1].Split(',');
				if (array.Length == 2)
				{
					try
					{
						double num = Convert.ToDouble(array[0]);
						double num2 = Convert.ToDouble(array[1]);
						MainPanelOffset = new Vector2((float)num, (float)num2);
					}
					catch (Exception)
					{
					}
				}
				i++;
			}
			else if (text.Equals("-disablemoderrors"))
			{
				_injectMods = false;
			}
			else if (text.Equals("-offsetwindow") && i + 1 < commandLineArgs.Length)
			{
				xoffset = Convert.ToInt32(commandLineArgs[i + 1]);
				flag = true;
				i++;
			}
			else if (text.Equals("-offsetwindowy") && i + 1 < commandLineArgs.Length)
			{
				yoffset = Convert.ToInt32(commandLineArgs[i + 1]);
				flag = true;
				i++;
			}
			else if (text.Equals("+connect_lobby"))
			{
				SteamJoinLobby = commandLineArgs[i + 1];
				i++;
			}
			else if (text.Equals("-lanmode"))
			{
				ForceLAN = true;
			}
		}
		if (flag)
		{
			try
			{
				OffsetMainWindow(xoffset, yoffset);
			}
			catch (Exception)
			{
			}
		}
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		ConfigFile configFile = new ConfigFile();
		try
		{
			string settingsFile = SettingsFile;
			configFile = (File.Exists(settingsFile) ? ConfigFile.Load(Utilities.ReadOnlyReadAllText(settingsFile)) : configFile);
		}
		catch (Exception ex4)
		{
			UnityEngine.Debug.Log(ex4.ToString());
			ShowFileLoadError();
		}
		try
		{
			string sharedSettingsFile = SharedSettingsFile;
			if (File.Exists(sharedSettingsFile))
			{
				ConfigFile f = ConfigFile.Load(Utilities.ReadOnlyReadAllText(sharedSettingsFile));
				configFile.Combine(f);
			}
		}
		catch (Exception ex5)
		{
			UnityEngine.Debug.Log(ex5.ToString());
			ShowFileLoadError();
		}
		List<string> list = configFile["Resolution"];
		if (list != null)
		{
			if (list.Count > 2)
			{
				configFile["ScreenResolution"] = new List<string> { list[0] + "x" + list[1] };
				configFile["RefreshRate"] = new List<string> { list[2] };
			}
			else if (list.Count == 1)
			{
				string[] array2 = list[0].Split('x');
				configFile["ScreenResolution"] = new List<string> { array2[0] + "x" + array2[1] };
				configFile["RefreshRate"] = new List<string> { array2[2] };
			}
		}
		list = configFile["Fullscreen"];
		if (list != null && list.Count > 0)
		{
			if ("True".Equals(list[0]))
			{
				list[0] = "FullScreenWindow";
			}
			else if ("False".Equals(list[0]))
			{
				list[0] = "Windowed";
			}
		}
		List<string> list2 = configFile["FavoriteFurniture"];
		if (list2 != null)
		{
			_favFurns.AddRange(list2);
		}
		List<string> list3 = configFile["CustomColors"];
		if (list3 != null && list3.Count == 22)
		{
			_customColors = list3.SelectInPlace((string x) =>
			{
				Color color;
				return (!ColorUtility.TryParseHtmlString("#" + x.Replace("#", ""), out color)) ? Color.white : color;
			});
		}
		Localization.OriginalTranslation = configFile.GetOrDefault("Language", "English");
		Localization.SetTranslation(Localization.OriginalTranslation);
		bool intel = (SystemInfo.graphicsDeviceVendor + SystemInfo.graphicsDeviceName).ToLower().Contains("intel");
		PropertyInfo[] properties = typeof(Options).GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (PropertyInfo propertyInfo in properties)
		{
			SettingAttribute settingAttribute = propertyInfo.GetCustomAttributes(false).FirstOrDefaultOf<SettingAttribute>();
			if (settingAttribute != null && settingAttribute.Name != null)
			{
				VariableInfo variableInfo = new VariableInfo(propertyInfo, settingAttribute);
				SettingFields[settingAttribute.Name] = variableInfo;
				if (settingAttribute.SaveToConfig)
				{
					variableInfo.LoadConf(configFile, intel);
				}
			}
		}
		List<string> list4 = configFile["IgnoreQuestions"];
		if (list4 != null)
		{
			IgnoreQuestions.AddRange(list4);
		}
		List<string> list5 = configFile["UnlockedRewards"];
		if (list5 != null)
		{
			UnlockedRewards.AddRange(list5);
		}
		InputController.LoadConfig(configFile["Keys"], configFile["AltKeys"]);
		AudioManager.LoadConfig(configFile["AudioLevels"]);
		Loaded = true;
		LoadSizes();
		LoadWidths();
		SaveToFile();
		InitHints();
		UnityEngine.Debug.Log("Player preferences load time: " + (Time.realtimeSinceStartup - realtimeSinceStartup).SecondsToTime());
		LoadDebugger.AddInfo("Finished loading player preferences");
	}

	private static void ShowFileLoadError()
	{
		if (!FailedToLoad && WindowManager.Instance != null)
		{
			WindowManager.SpawnDialog("OptionFileError".Loc(), false, DialogWindow.DialogType.Error);
			FailedToLoad = true;
		}
	}

	public static CursorLockMode CursorLock()
	{
		if (!EdgeScroll)
		{
			return CursorLockMode.None;
		}
		return CursorLockMode.Confined;
	}

	public static bool CheckSMAASupport()
	{
		return ImageEffectHelper.BasicSupport(Shader.Find("Hidden/Subpixel Morphological Anti-aliasing"));
	}

	private static void InitHints()
	{
		Hints = new bool[Enum.GetValues(typeof(HintController.Hints)).Length];
		bool flag = false;
		try
		{
			if (File.Exists(HintFile))
			{
				byte[] array = File.ReadAllBytes(HintFile);
				for (int i = 0; i < Hints.Length; i++)
				{
					if (i < array.Length)
					{
						Hints[i] = array[i] != 0;
					}
					else
					{
						Hints[i] = true;
					}
				}
				flag = true;
			}
		}
		catch (Exception)
		{
		}
		if (!flag)
		{
			for (int j = 0; j < Hints.Length; j++)
			{
				Hints[j] = true;
			}
		}
	}

	public static void UpdateHint(HintController.Hints hint, bool value)
	{
		UpdateHint((int)hint, value);
	}

	public static void UpdateHint(int hint, bool value)
	{
		if (hint < 0 || hint >= Hints.Length || Hints[hint] == value)
		{
			return;
		}
		Hints[hint] = value;
		try
		{
			byte[] array = new byte[Hints.Length];
			for (int i = 0; i < Hints.Length; i++)
			{
				array[i] = (byte)(Hints[i] ? 1u : 0u);
			}
			File.WriteAllBytes(HintFile, array);
		}
		catch (Exception)
		{
		}
	}

	public static void CustomDifficultyAction()
	{
		WindowManager.Instance.SpawnDifficultyDialog(Difficulty, delegate(DifficultyValues.DifficultySetting x)
		{
			Difficulty = x;
			((GUICombobox)OptionsWindow.Instance.AllControls["Difficulty"]).SelectedItem = x;
		}, OptionsWindow.Instance.Window);
	}

	public static void ResetHints()
	{
		for (int i = 1; i < Hints.Length; i++)
		{
			Hints[i] = true;
		}
		UpdateHint(0, true);
	}

	public static bool HintEnabled(HintController.Hints hint)
	{
		return HintEnabled((int)hint);
	}

	public static bool HintEnabled(int hint)
	{
		return Hints[hint];
	}

	public static Resolution FindRes(int w, int h, int r)
	{
		Resolution result = Screen.currentResolution;
		Resolution[] resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++)
		{
			Resolution resolution = resolutions[i];
			if (resolution.width == w && resolution.height == h)
			{
				if (resolution.refreshRate == r)
				{
					return resolution;
				}
				if (result.width != w || result.height != h || resolution.refreshRate > result.refreshRate)
				{
					result = resolution;
				}
			}
		}
		return result;
	}

	public static void UpdateResolution(ValueTuple<int, int> rs, FullScreenMode fullscreen)
	{
		Resolution r = FindRes(rs.Item1, rs.Item2, 60);
		if (r.width < 1024 || r.height < 720)
		{
			r = FindRes(1024, 768, 60);
		}
		ActuallySetResolution(r, fullscreen);
	}

	public static void UpdateResolution(int hz, FullScreenMode fullscreen)
	{
		ValueTuple<int, int> sResolution = SResolution;
		ActuallySetResolution(FindRes(sResolution.Item1, sResolution.Item2, hz), fullscreen);
	}

	private static void ActuallySetResolution(Resolution r, FullScreenMode fullscreen)
	{
		if (!DisableResolutionChange)
		{
			_lastFullscreen = fullscreen;
			_lastResolution = r;
			if (fullscreen == FullScreenMode.MaximizedWindow)
			{
				Screen.SetResolution(r.width, r.height, FullScreenMode.Windowed, r.refreshRate);
				UnityEngine.Object.DontDestroyOnLoad(new GameObject().AddComponent<Maximizer>().gameObject);
			}
			else
			{
				Screen.SetResolution(r.width, r.height, fullscreen, r.refreshRate);
			}
		}
	}

	public static void UpdateResolution(Resolution r, FullScreenMode fullscreen)
	{
		if (r.width < 1024 || r.height < 720)
		{
			r = FindRes(1024, 768, 60);
		}
		ActuallySetResolution(r, fullscreen);
	}

	public static void AddWindowSize(string id, SVector3 size)
	{
		if (!string.IsNullOrEmpty(id))
		{
			WindowSizes[id] = size;
			SaveSizes();
		}
	}

	private static void LoadSizes()
	{
		if (!File.Exists(WindowSizeFile))
		{
			return;
		}
		try
		{
			foreach (KeyValuePair<string, List<string>> value in ConfigFile.Load(File.ReadAllLines(WindowSizeFile)).Values)
			{
				if (value.Value.Count <= 0)
				{
					continue;
				}
				try
				{
					SVector3 sVector = SVector3.Deserialize(value.Value[0], true);
					if (sVector.x != 0f || sVector.y != 0f || sVector.z != 0f || sVector.w != 0f)
					{
						WindowSizes[value.Key] = sVector;
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static void SaveSizes()
	{
		try
		{
			ConfigFile configFile = new ConfigFile();
			foreach (KeyValuePair<string, SVector3> windowSize in WindowSizes)
			{
				configFile.Add(windowSize.Key, windowSize.Value.Serialize());
			}
			File.WriteAllText(WindowSizeFile, configFile.Serialize());
		}
		catch (Exception)
		{
		}
	}

	public static void ResetSizes()
	{
		WindowSizes.Clear();
		try
		{
			if (File.Exists(WindowSizeFile))
			{
				File.Delete(WindowSizeFile);
			}
		}
		catch (Exception)
		{
		}
	}

	public static SVector3 GetWindowSize(string id)
	{
		if (WindowSizes != null)
		{
			return WindowSizes.GetOrNull(id);
		}
		return null;
	}

	public static void AddColumnWidth(string id, float width)
	{
		ColumnWidths[id] = width;
		SaveWidths();
	}

	public static bool GetColumnWidth(string id, out float result)
	{
		return ColumnWidths.TryGetValue(id, out result);
	}

	private static void LoadWidths()
	{
		if (!File.Exists(ColumnWidthFile))
		{
			return;
		}
		try
		{
			foreach (KeyValuePair<string, List<string>> value in ConfigFile.Load(File.ReadAllLines(ColumnWidthFile)).Values)
			{
				if (value.Value.Count <= 0)
				{
					continue;
				}
				try
				{
					float num = (float)Convert.ToDouble(value.Value[0]);
					if (num > 0f)
					{
						ColumnWidths[value.Key] = num;
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static void SaveWidths()
	{
		try
		{
			ConfigFile configFile = new ConfigFile();
			foreach (KeyValuePair<string, float> columnWidth in ColumnWidths)
			{
				configFile.Add(columnWidth.Key, columnWidth.Value.ToString());
			}
			File.WriteAllText(ColumnWidthFile, configFile.Serialize());
		}
		catch (Exception)
		{
		}
	}

	public static void ResetWidths()
	{
		ColumnWidths.Clear();
		try
		{
			if (File.Exists(ColumnWidthFile))
			{
				File.Delete(ColumnWidthFile);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void ResetConfirmations()
	{
		IgnoreQuestions.Clear();
		SaveToFile();
	}

	public static void UpdateResolution()
	{
		ActuallySetResolution(_lastResolution, _lastFullscreen);
	}

	private static Dictionary<string, object> GetScreenResolutions()
	{
		return ((IEnumerable<ValueTuple<int, int>>)(from x in Screen.resolutions
			where x.height >= 720 && x.width >= 1024
			select new ValueTuple<int, int>(x.width, x.height)).Distinct().OrderBy(([TupleElementNames(new string[] { "width", "height" })] ValueTuple<int, int> x) => x.Item1 * x.Item2)).ToDictionary((Func<ValueTuple<int, int>, string>)(([TupleElementNames(new string[] { "width", "height" })] ValueTuple<int, int> x) => x.Item1 + "x" + x.Item2), (Func<ValueTuple<int, int>, object>)(([TupleElementNames(new string[] { "width", "height" })] ValueTuple<int, int> x) => x));
	}

	private static Dictionary<string, object> GetFullScreenOptions()
	{
		return new Dictionary<string, object>
		{
			{
				"Off",
				FullScreenMode.Windowed
			},
			{
				"Maximized",
				FullScreenMode.MaximizedWindow
			},
			{
				"FullScreenWindowed",
				FullScreenMode.FullScreenWindow
			},
			{
				"FullScreenExclusive",
				FullScreenMode.ExclusiveFullScreen
			}
		};
	}

	private static Dictionary<string, object> GetHz()
	{
		ValueTuple<int, int> r = SResolution;
		return (from x in Screen.resolutions
			where x.width == r.Item1 && x.height == r.Item2
			select x.refreshRate).Distinct().ToDictionary((Func<int, string>)((int x) => x + "Hz"), (Func<int, object>)((int x) => x));
	}

	private static Dictionary<string, object> GetDifficulties()
	{
		return ((IEnumerable<KeyValuePair<string, DifficultyValues.DifficultySetting>>)DifficultyValues.Difficulties).ToDictionary((Func<KeyValuePair<string, DifficultyValues.DifficultySetting>, string>)((KeyValuePair<string, DifficultyValues.DifficultySetting> x) => x.Key), (Func<KeyValuePair<string, DifficultyValues.DifficultySetting>, object>)((KeyValuePair<string, DifficultyValues.DifficultySetting> x) => x.Value));
	}

	private static Dictionary<string, object> GetRoundLimits()
	{
		return ((IEnumerable<float>)ActorCustomization.RoundLimits).ToDictionary((Func<float, string>)((float x) => (!float.IsInfinity(x)) ? "Minute".LocPlural(Mathf.RoundToInt(x)) : "Unlimited".Loc()), (Func<float, object>)((float x) => x * 60f));
	}

	private static Dictionary<string, object> GetRoundTypes()
	{
		return Enum.GetValues(typeof(NetworkLobby.RoundLimitType)).OfType<NetworkLobby.RoundLimitType>().ToDictionary((Func<NetworkLobby.RoundLimitType, string>)((NetworkLobby.RoundLimitType x) => x.ToString().Loc()), (Func<NetworkLobby.RoundLimitType, object>)((NetworkLobby.RoundLimitType x) => x));
	}

	private static Dictionary<string, object> GetCurrencies()
	{
		return ((IEnumerable<string>)GameData.CurrencyRates.Keys).ToDictionary((Func<string, string>)((string x) => x), (Func<string, object>)((string x) => x));
	}

	private static Dictionary<string, object> GetResolutions()
	{
		return ((IEnumerable<Resolution>)(from x in Screen.resolutions.Where((Resolution x) => x.height >= 720 && x.width >= 1024).Distinct()
			orderby x.height * x.width, x.refreshRate
			select x)).ToDictionary((Func<Resolution, string>)((Resolution x) => x.width + "x" + x.height + " " + x.refreshRate + "Hz"), (Func<Resolution, object>)((Resolution x) => x));
	}

	private static Dictionary<string, object> GetUISizes()
	{
		return Enumerable.Range(10, 11).ToDictionary((Func<int, string>)((int x) => x * 10 + "%"), (Func<int, object>)((int x) => (float)x / 10f));
	}

	private static Dictionary<string, object> GetVSyncs()
	{
		return new Dictionary<string, object>
		{
			{ "Off", 0 },
			{ "1 frame", 1 },
			{ "2 frames", 2 }
		};
	}

	private static Dictionary<string, object> GetWorldBackground()
	{
		return new Dictionary<string, object>
		{
			{ "Void", 0 },
			{ "SolidGround", 1 }
		};
	}

	private static Dictionary<string, object> GetQualityOptions()
	{
		return new Dictionary<string, object>
		{
			{ "GFXCustom", 0 },
			{ "GFXNothing", 1 },
			{ "GFXLow", 2 },
			{ "GFXMedium", 3 },
			{ "GFXHigh", 4 },
			{ "GFXVeryHigh", 5 },
			{ "GFXUltra", 6 }
		};
	}

	private static Dictionary<string, object> GetColorBlindness()
	{
		return new Dictionary<string, object>
		{
			{ "None", 0 },
			{ "Deuteranopia", 1 },
			{ "Protanopia", 2 },
			{ "Tritanopia", 3 },
			{
				"CustomDifficulty".Loc(),
				-1
			}
		};
	}

	public static void UnlockReward(string task)
	{
		if (UnlockedRewards.Add(task))
		{
			SaveToFile();
		}
	}

	public static void ConstructColorSelectionWindow()
	{
		GUIWindow w = WindowManager.SpawnWindow();
		w.OnlyHide = false;
		w.Title = "Colors";
		w.Modal = true;
		GUIWindow gUIWindow = w;
		Vector2 minSize = (w.GetComponent<RectTransform>().sizeDelta = new Vector2(200f, 650f));
		gUIWindow.MinSize = minSize;
		VerticalLayoutGroup verticalLayoutGroup = w.MainPanel.AddComponent<VerticalLayoutGroup>();
		List<Image> l = new List<Image>(12);
		verticalLayoutGroup.childForceExpandHeight = true;
		verticalLayoutGroup.childForceExpandWidth = true;
		verticalLayoutGroup.childControlHeight = true;
		verticalLayoutGroup.childControlWidth = true;
		verticalLayoutGroup.spacing = 1f;
		verticalLayoutGroup.padding = new RectOffset(4, 4, 4, 16);
		Color[] themeColors = HUD.GetThemeColors();
		AddColorLabel("MainColorGroup".Loc(), w);
		for (int i = 0; i < themeColors.Length; i++)
		{
			l.Add(AddColorButton((i + 1).ToString(), themeColors[i], w));
		}
		AddColorLabel("Role".Loc(), w);
		for (int j = 0; j < 5; j++)
		{
			Employee.EmployeeRole role = (Employee.EmployeeRole)j;
			l.Add(AddColorButton(role.ToString().Loc(), SpecializationChart.GetSkillColor(role), w));
		}
		AddColorLabel("Iteration".Loc(), w);
		for (int k = 0; k < 4; k++)
		{
			l.Add(AddColorButton((k + 1).ToString(), DesignDocument.GetIterationColor(k), w));
		}
		AddColorLabel("Miscellaneous".Loc(), w);
		l.Add(AddColorButton("AccentColor".Loc(), HUD.GetAccentColor(), w));
		l.Add(AddColorButton("WarningColor".Loc(), HUD.GetWarningColor(), w));
		l.Add(AddColorButton("PositiveColor".Loc(), HUD.GetPosNeg(true), w));
		l.Add(AddColorButton("NegativeColor".Loc(), HUD.GetPosNeg(false), w));
		l.Add(AddColorButton("Progress".Loc(), WorkItem.GetDefaultProgressColor(), w));
		new GameObject().AddComponent<RectTransform>().SetParent(w.MainPanel.transform, false);
		Button button = WindowManager.SpawnButton();
		button.GetComponentInChildren<Text>().text = "Save".Loc();
		button.onClick.AddListener(delegate
		{
			_customColors = l.SelectInPlace((Image x) => x.color);
			((GUICombobox)OptionsWindow.Instance.AllControls["ColorBlindness"]).Selected = 4;
			SaveToFile();
			w.Close();
		});
		button.transform.SetParent(w.MainPanel.transform, false);
		button.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 24f);
		w.Show();
		OptionsWindow optionsWindow = WindowManager.FindFirstWindowType<OptionsWindow>();
		if (optionsWindow != null)
		{
			w.SetParentWindow(optionsWindow.Window);
		}
	}

	private static void AddColorLabel(string text, GUIWindow parent)
	{
		Text text2 = WindowManager.SpawnLabel();
		text2.text = text;
		text2.transform.SetParent(parent.MainPanel.transform, false);
		text2.alignment = TextAnchor.MiddleCenter;
	}

	private static Image AddColorButton(string text, Color color, GUIWindow parent)
	{
		Button button = WindowManager.SpawnButton();
		Image image = button.GetComponent<Image>();
		image.color = color;
		button.GetComponentInChildren<Text>().text = text;
		button.onClick.AddListener(delegate
		{
			WindowManager.SpawnColorDialog(delegate(Color x)
			{
				image.color = x;
			}, image.color, null, null, false, parent);
		});
		button.transform.SetParent(parent.MainPanel.transform, false);
		return image;
	}

	public static Color GetCustomColor(int index)
	{
		if (_customColors == null)
		{
			InitializeCustomColors(true);
		}
		return _customColors[index % _customColors.Length];
	}

	public static void InitializeCustomColors(bool force = false)
	{
		if (ColorBlindness == -1)
		{
			ColorBlindness = 0;
			InitializeCustomColors();
			if (force)
			{
				ColorBlindness = -1;
			}
			return;
		}
		_customColors = new Color[22];
		Color[] themeColors = HUD.GetThemeColors();
		int num = 0;
		for (int i = 0; i < themeColors.Length; i++)
		{
			_customColors[num] = themeColors[i];
			num++;
		}
		for (int j = 0; j < 5; j++)
		{
			_customColors[num] = SpecializationChart.GetSkillColor((Employee.EmployeeRole)j);
			num++;
		}
		for (int k = 0; k < 4; k++)
		{
			_customColors[num] = DesignDocument.GetIterationColor(k);
			num++;
		}
		_customColors[num] = HUD.GetAccentColor();
		num++;
		_customColors[num] = HUD.GetWarningColor();
		num++;
		_customColors[num] = HUD.GetPosNeg(true);
		num++;
		_customColors[num] = HUD.GetPosNeg(false);
		num++;
		_customColors[num] = WorkItem.GetDefaultProgressColor();
	}

	public static bool IsDLCDisabled(string name)
	{
		return false;
	}

	public static void SaveToFile()
	{
		if (!Loaded)
		{
			return;
		}
		ConfigFile configFile = new ConfigFile();
		ConfigFile configFile2 = new ConfigFile();
		foreach (KeyValuePair<string, VariableInfo> settingField in SettingFields)
		{
			if (settingField.Value.Setting.SaveToConfig)
			{
				ConfigFile configFile3 = (settingField.Value.Setting.Shared ? configFile2 : configFile);
				if (settingField.Key.Equals("Resolution"))
				{
					Resolution resolution = (Resolution)settingField.Value.GetValue();
					configFile3.Add(settingField.Key, resolution.width + "x" + resolution.height + "x" + resolution.refreshRate);
				}
				else if (settingField.Key.Equals("ScreenResolution"))
				{
					ValueTuple<int, int> valueTuple = (ValueTuple<int, int>)settingField.Value.GetValue();
					configFile3.Add(settingField.Key, valueTuple.Item1 + "x" + valueTuple.Item2);
				}
				else
				{
					object value = settingField.Value.GetValue();
					configFile3.Add(settingField.Key, ((value != null) ? value.ToString() : null) ?? "");
				}
			}
		}
		ConfigFile configFile4 = configFile2;
		if (Localization.CurrentTranslation != null)
		{
			configFile4.Add("Language", Localization.CurrentTranslation.ItemTitle);
		}
		configFile4.AddRange("Keys", InputController.ToConfig(false));
		configFile4.AddRange("AltKeys", InputController.ToConfig(true));
		configFile.AddRange("AudioLevels", AudioManager.ToConfig());
		configFile4.AddRange("IgnoreQuestions", IgnoreQuestions);
		configFile4.AddRange("UnlockedRewards", UnlockedRewards);
		configFile4.AddRange("FavoriteFurniture", _favFurns);
		if (_customColors != null)
		{
			configFile4.AddRange("CustomColors", _customColors.Select(ColorUtility.ToHtmlStringRGB));
		}
		try
		{
			File.WriteAllText(SettingsFile, configFile.Serialize());
		}
		catch (Exception)
		{
			ShowFileLoadError();
		}
		try
		{
			File.WriteAllText(SharedSettingsFile, configFile2.Serialize());
		}
		catch (Exception)
		{
			ShowFileLoadError();
		}
	}
}
