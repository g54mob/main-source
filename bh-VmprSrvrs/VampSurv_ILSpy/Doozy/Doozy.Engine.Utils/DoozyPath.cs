using System;
using System.IO;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Utils;

[Serializable]
public class DoozyPath : ScriptableObject
{
	public enum ComponentName
	{
		Soundy,
		Themes,
		UIButton,
		UICanvas,
		UIDrawer,
		UIPopup,
		UIView
	}

	private const string ASSETS_PATH = "Assets/";

	private const string DATA = "Data";

	private const string DATABASE = "Database";

	private const string DOOZY = "Doozy";

	private const string EDITOR = "Editor";

	private const string ENGINE = "Engine";

	private const string FONTS = "Fonts";

	private const string GUI = "GUI";

	private const string IMAGES = "Images";

	private const string INTERNAL = "Internal";

	private const string NODY = "Nody";

	private const string RESOURCES = "Resources";

	private const string SETTINGS = "Settings";

	private const string SKINS = "Skins";

	private const string SOUNDY = "Soundy";

	private const string THEMES = "Themes";

	private const string TEMPLATES = "Templates";

	private const string TOUCHY = "Touchy";

	private const string UI = "UI";

	private const string UIBUTTON = "UIButton";

	private const string UICANVAS = "UICanvas";

	private const string UIDRAWER = "UIDrawer";

	private const string UIPOPUP = "UIPopup";

	private const string UITOGGLE = "UITOGGLE";

	private const string UIVIEW = "UIView";

	private const string UTILS = "Utils";

	public const string UIANIMATIONS = "UIAnimations";

	private const string HIDE = "Hide";

	private const string LOOP = "Loop";

	private const string PUNCH = "Punch";

	private const string SHOW = "Show";

	private const string STATE = "State";

	public const string SOUNDY_DATABASE = "SoundyDatabase";

	public const string THEMES_DATABASE = "ThemesDatabase";

	public const string UIBUTTON_DATABASE = "UIButtonDatabase";

	public const string UICANVAS_DATABASE = "UICanvasDatabase";

	public const string UIDRAWER_DATABASE = "UIDrawerDatabase";

	public const string UIPOPUP_DATABASE = "UIPopupDatabase";

	public const string UIVIEW_DATABASE = "UIViewDatabase";

	public static string DOOZY_PATH;

	public static string EDITOR_PATH;

	public static string ENGINE_PATH;

	public static string EDITOR_FONTS_PATH;

	public static string EDITOR_GUI_PATH;

	public static string EDITOR_IMAGES_PATH;

	public static string EDITOR_INTERNAL_PATH;

	public static string EDITOR_SETTINGS_PATH;

	public static string EDITOR_SKINS_PATH;

	public static string EDITOR_NODY_PATH;

	public static string EDITOR_NODY_IMAGES_PATH;

	public static string EDITOR_NODY_SKINS_PATH;

	public static string EDITOR_NODY_SETTINGS_PATH;

	public static string EDITOR_NODY_UTILS_PATH;

	public static string ENGINE_NODY_PATH;

	public static string ENGINE_NODY_RESOURCES_PATH;

	public static string ENGINE_SOUNDY_PATH;

	public static string ENGINE_SOUNDY_RESOURCES_PATH;

	public static string ENGINE_TOUCHY_PATH;

	public static string ENGINE_TOUCHY_RESOURCES_PATH;

	public static string ENGINE_THEMES_PATH;

	public static string ENGINE_THEMES_RESOURCES_PATH;

	public static string ENGINE_RESOURCES_PATH;

	public static string ENGINE_RESOURCES_DATA_PATH;

	public static string ENGINE_RESOURCES_DATA_SOUNDY_PATH;

	public static string ENGINE_RESOURCES_DATA_UIBUTTON_PATH;

	public static string ENGINE_RESOURCES_DATA_UICANVAS_PATH;

	public static string ENGINE_RESOURCES_DATA_UIDRAWER_PATH;

	public static string ENGINE_RESOURCES_DATA_UIPOPUP_PATH;

	public static string ENGINE_RESOURCES_DATA_UIVIEW_PATH;

	public static string ENGINE_RESOURCES_DATA_THEMES_PATH;

	public static string ENGINE_UI_PATH;

	public static string ENGINE_UI_RESOURCES_PATH;

	public static string UIANIMATIONS_RESOURCES_PATH;

	public static string HIDE_UIANIMATIONS_RESOURCES_PATH;

	public static string LOOP_UIANIMATIONS_RESOURCES_PATH;

	public static string PUNCH_UIANIMATIONS_RESOURCES_PATH;

	public static string SHOW_UIANIMATIONS_RESOURCES_PATH;

	public static string STATE_UIANIMATIONS_RESOURCES_PATH;

	public static string UIBUTTON_PATH;

	public static string UIBUTTON_RESOURCES_PATH;

	public static string UICANVAS_PATH;

	public static string UICANVAS_RESOURCES_PATH;

	public static string UIDRAWER_PATH;

	public static string UIDRAWER_RESOURCES_PATH;

	public static string UIPOPUP_PATH;

	public static string UIPOPUP_RESOURCES_PATH;

	public static string UIVIEW_PATH;

	public static string UIVIEW_RESOURCES_PATH;

	public static string UITOGGLE_PATH;

	public static string UITOGGLE_RESOURCES_PATH;

	public static string ENGINE_UTILS_PATH;

	private static string s_basePath;

	public static string BasePath
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980604]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "";
		}
	}

	public unsafe static string GetDataPath(ComponentName componentName)
	{
		//IL_002a: Expected O, but got Ref
		object obj = default(object);
		string path = ((Enum)(&obj)).ToString();
		return Path.Combine(ENGINE_RESOURCES_DATA_PATH, path);
	}

	public static string ReplaceBackslashesWithForwardSlashes(string path)
	{
		if (path != null)
		{
			return path.Replace('\\', '/');
		}
		return (string)(object)new NullReferenceException();
	}

	public static void CreateMissingFolders(bool silentMode = false)
	{
	}

	static DoozyPath()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980604]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DOOZY_PATH = "";
		string eDITOR_PATH = Path.Combine(DOOZY_PATH, "Editor");
		EDITOR_PATH = eDITOR_PATH;
		string eNGINE_PATH = Path.Combine(DOOZY_PATH, "Engine");
		ENGINE_PATH = eNGINE_PATH;
		string eDITOR_FONTS_PATH = Path.Combine(EDITOR_PATH, "Fonts");
		EDITOR_FONTS_PATH = eDITOR_FONTS_PATH;
		string eDITOR_GUI_PATH = Path.Combine(EDITOR_PATH, "GUI");
		EDITOR_GUI_PATH = eDITOR_GUI_PATH;
		string eDITOR_IMAGES_PATH = Path.Combine(EDITOR_PATH, "Images");
		EDITOR_IMAGES_PATH = eDITOR_IMAGES_PATH;
		string eDITOR_INTERNAL_PATH = Path.Combine(EDITOR_PATH, "Internal");
		EDITOR_INTERNAL_PATH = eDITOR_INTERNAL_PATH;
		string eDITOR_SETTINGS_PATH = Path.Combine(EDITOR_PATH, "Settings");
		EDITOR_SETTINGS_PATH = eDITOR_SETTINGS_PATH;
		string eDITOR_SKINS_PATH = Path.Combine(EDITOR_PATH, "Skins");
		EDITOR_SKINS_PATH = eDITOR_SKINS_PATH;
		string eDITOR_NODY_PATH = Path.Combine(EDITOR_PATH, "Nody");
		EDITOR_NODY_PATH = eDITOR_NODY_PATH;
		string eDITOR_NODY_IMAGES_PATH = Path.Combine(EDITOR_NODY_PATH, "Images");
		EDITOR_NODY_IMAGES_PATH = eDITOR_NODY_IMAGES_PATH;
		string eDITOR_NODY_SKINS_PATH = Path.Combine(EDITOR_NODY_PATH, "Skins");
		EDITOR_NODY_SKINS_PATH = eDITOR_NODY_SKINS_PATH;
		string eDITOR_NODY_SETTINGS_PATH = Path.Combine(EDITOR_NODY_PATH, "Settings");
		EDITOR_NODY_SETTINGS_PATH = eDITOR_NODY_SETTINGS_PATH;
		string eDITOR_NODY_UTILS_PATH = Path.Combine(EDITOR_NODY_PATH, "Utils");
		EDITOR_NODY_UTILS_PATH = eDITOR_NODY_UTILS_PATH;
		string eNGINE_NODY_PATH = Path.Combine(ENGINE_PATH, "Nody");
		ENGINE_NODY_PATH = eNGINE_NODY_PATH;
		string eNGINE_NODY_RESOURCES_PATH = Path.Combine(ENGINE_NODY_PATH, "Resources");
		ENGINE_NODY_RESOURCES_PATH = eNGINE_NODY_RESOURCES_PATH;
		string eNGINE_SOUNDY_PATH = Path.Combine(ENGINE_PATH, "Soundy");
		ENGINE_SOUNDY_PATH = eNGINE_SOUNDY_PATH;
		string eNGINE_SOUNDY_RESOURCES_PATH = Path.Combine(ENGINE_SOUNDY_PATH, "Resources");
		ENGINE_SOUNDY_RESOURCES_PATH = eNGINE_SOUNDY_RESOURCES_PATH;
		string eNGINE_TOUCHY_PATH = Path.Combine(ENGINE_PATH, "Touchy");
		ENGINE_TOUCHY_PATH = eNGINE_TOUCHY_PATH;
		string eNGINE_TOUCHY_RESOURCES_PATH = Path.Combine(ENGINE_TOUCHY_PATH, "Resources");
		ENGINE_TOUCHY_RESOURCES_PATH = eNGINE_TOUCHY_RESOURCES_PATH;
		string eNGINE_THEMES_PATH = Path.Combine(ENGINE_PATH, "Themes");
		ENGINE_THEMES_PATH = eNGINE_THEMES_PATH;
		string eNGINE_THEMES_RESOURCES_PATH = Path.Combine(ENGINE_THEMES_PATH, "Resources");
		ENGINE_THEMES_RESOURCES_PATH = eNGINE_THEMES_RESOURCES_PATH;
		string eNGINE_RESOURCES_PATH = Path.Combine(ENGINE_PATH, "Resources");
		ENGINE_RESOURCES_PATH = eNGINE_RESOURCES_PATH;
		string eNGINE_RESOURCES_DATA_PATH = Path.Combine(ENGINE_RESOURCES_PATH, "Data");
		ENGINE_RESOURCES_DATA_PATH = eNGINE_RESOURCES_DATA_PATH;
		string eNGINE_RESOURCES_DATA_SOUNDY_PATH = Path.Combine(ENGINE_RESOURCES_DATA_PATH, "Soundy");
		ENGINE_RESOURCES_DATA_SOUNDY_PATH = eNGINE_RESOURCES_DATA_SOUNDY_PATH;
		string eNGINE_RESOURCES_DATA_UIBUTTON_PATH = Path.Combine(ENGINE_RESOURCES_DATA_PATH, "UIButton");
		ENGINE_RESOURCES_DATA_UIBUTTON_PATH = eNGINE_RESOURCES_DATA_UIBUTTON_PATH;
		string eNGINE_RESOURCES_DATA_UICANVAS_PATH = Path.Combine(ENGINE_RESOURCES_DATA_PATH, "UICanvas");
		ENGINE_RESOURCES_DATA_UICANVAS_PATH = eNGINE_RESOURCES_DATA_UICANVAS_PATH;
		string eNGINE_RESOURCES_DATA_UIDRAWER_PATH = Path.Combine(ENGINE_RESOURCES_DATA_PATH, "UIDrawer");
		ENGINE_RESOURCES_DATA_UIDRAWER_PATH = eNGINE_RESOURCES_DATA_UIDRAWER_PATH;
		string eNGINE_RESOURCES_DATA_UIPOPUP_PATH = Path.Combine(ENGINE_RESOURCES_DATA_PATH, "UIPopup");
		ENGINE_RESOURCES_DATA_UIPOPUP_PATH = eNGINE_RESOURCES_DATA_UIPOPUP_PATH;
		string eNGINE_RESOURCES_DATA_UIVIEW_PATH = Path.Combine(ENGINE_RESOURCES_DATA_PATH, "UIView");
		ENGINE_RESOURCES_DATA_UIVIEW_PATH = eNGINE_RESOURCES_DATA_UIVIEW_PATH;
		string eNGINE_RESOURCES_DATA_THEMES_PATH = Path.Combine(ENGINE_RESOURCES_DATA_PATH, "Themes");
		ENGINE_RESOURCES_DATA_THEMES_PATH = eNGINE_RESOURCES_DATA_THEMES_PATH;
		string eNGINE_UI_PATH = Path.Combine(ENGINE_PATH, "UI");
		ENGINE_UI_PATH = eNGINE_UI_PATH;
		string eNGINE_UI_RESOURCES_PATH = Path.Combine(ENGINE_UI_PATH, "Resources");
		ENGINE_UI_RESOURCES_PATH = eNGINE_UI_RESOURCES_PATH;
		string uIANIMATIONS_RESOURCES_PATH = Path.Combine(ENGINE_UI_RESOURCES_PATH, "UIAnimations");
		UIANIMATIONS_RESOURCES_PATH = uIANIMATIONS_RESOURCES_PATH;
		string hIDE_UIANIMATIONS_RESOURCES_PATH = Path.Combine(UIANIMATIONS_RESOURCES_PATH, "Hide");
		HIDE_UIANIMATIONS_RESOURCES_PATH = hIDE_UIANIMATIONS_RESOURCES_PATH;
		string lOOP_UIANIMATIONS_RESOURCES_PATH = Path.Combine(UIANIMATIONS_RESOURCES_PATH, "Loop");
		LOOP_UIANIMATIONS_RESOURCES_PATH = lOOP_UIANIMATIONS_RESOURCES_PATH;
		string pUNCH_UIANIMATIONS_RESOURCES_PATH = Path.Combine(UIANIMATIONS_RESOURCES_PATH, "Punch");
		PUNCH_UIANIMATIONS_RESOURCES_PATH = pUNCH_UIANIMATIONS_RESOURCES_PATH;
		string sHOW_UIANIMATIONS_RESOURCES_PATH = Path.Combine(UIANIMATIONS_RESOURCES_PATH, "Show");
		SHOW_UIANIMATIONS_RESOURCES_PATH = sHOW_UIANIMATIONS_RESOURCES_PATH;
		string sTATE_UIANIMATIONS_RESOURCES_PATH = Path.Combine(UIANIMATIONS_RESOURCES_PATH, "State");
		STATE_UIANIMATIONS_RESOURCES_PATH = sTATE_UIANIMATIONS_RESOURCES_PATH;
		string uIBUTTON_PATH = Path.Combine(ENGINE_UI_PATH, "UIButton");
		UIBUTTON_PATH = uIBUTTON_PATH;
		string uIBUTTON_RESOURCES_PATH = Path.Combine(UIBUTTON_PATH, "Resources");
		UIBUTTON_RESOURCES_PATH = uIBUTTON_RESOURCES_PATH;
		string uICANVAS_PATH = Path.Combine(ENGINE_UI_PATH, "UICanvas");
		UICANVAS_PATH = uICANVAS_PATH;
		string uICANVAS_RESOURCES_PATH = Path.Combine(UICANVAS_PATH, "Resources");
		UICANVAS_RESOURCES_PATH = uICANVAS_RESOURCES_PATH;
		string uIDRAWER_PATH = Path.Combine(ENGINE_UI_PATH, "UIDrawer");
		UIDRAWER_PATH = uIDRAWER_PATH;
		string uIDRAWER_RESOURCES_PATH = Path.Combine(UIDRAWER_PATH, "Resources");
		UIDRAWER_RESOURCES_PATH = uIDRAWER_RESOURCES_PATH;
		string uIPOPUP_PATH = Path.Combine(ENGINE_UI_PATH, "UIPopup");
		UIPOPUP_PATH = uIPOPUP_PATH;
		string uIPOPUP_RESOURCES_PATH = Path.Combine(UIPOPUP_PATH, "Resources");
		UIPOPUP_RESOURCES_PATH = uIPOPUP_RESOURCES_PATH;
		string uIVIEW_PATH = Path.Combine(ENGINE_UI_PATH, "UIView");
		UIVIEW_PATH = uIVIEW_PATH;
		string uIVIEW_RESOURCES_PATH = Path.Combine(UIVIEW_PATH, "Resources");
		UIVIEW_RESOURCES_PATH = uIVIEW_RESOURCES_PATH;
		string uITOGGLE_PATH = Path.Combine(ENGINE_UI_PATH, "UITOGGLE");
		UITOGGLE_PATH = uITOGGLE_PATH;
		string uITOGGLE_RESOURCES_PATH = Path.Combine(UITOGGLE_PATH, "Resources");
		UITOGGLE_RESOURCES_PATH = uITOGGLE_RESOURCES_PATH;
		string eNGINE_UTILS_PATH = Path.Combine(ENGINE_PATH, "Utils");
		ENGINE_UTILS_PATH = eNGINE_UTILS_PATH;
	}
}
