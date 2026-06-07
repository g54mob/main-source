using System;
using UnityEngine;

namespace Doozy.Engine.Utils
{
	[Serializable]
	public class DoozyPath : ScriptableObject
	{
		public enum ComponentName
		{
			Soundy = 0,
			Themes = 1,
			UIButton = 2,
			UICanvas = 3,
			UIDrawer = 4,
			UIPopup = 5,
			UIView = 6
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

		public static string BasePath => null;

		public static string GetDataPath(ComponentName componentName)
		{
			return null;
		}

		public static string ReplaceBackslashesWithForwardSlashes(string path)
		{
			return null;
		}

		public static void CreateMissingFolders(bool silentMode = false)
		{
		}
	}
}
