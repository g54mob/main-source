using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class XCThemeMgr
	{
		public static void ReloadThemeList()
		{
			XChartsMgr.themes.Clear();
			XChartsMgr.themeNames.Clear();
			AddTheme(LoadTheme(ThemeType.Default));
			AddTheme(LoadTheme(ThemeType.Dark));
			if (!(XCSettings.Instance != null))
			{
				return;
			}
			foreach (Theme customTheme in XCSettings.customThemes)
			{
				AddTheme(customTheme);
			}
		}

		public static void CheckReloadTheme()
		{
			if (XChartsMgr.themeNames.Count < 0)
			{
				ReloadThemeList();
			}
		}

		public static void AddTheme(Theme theme)
		{
			if (!(theme == null) && !XChartsMgr.themes.ContainsKey(theme.themeName))
			{
				XChartsMgr.themes.Add(theme.themeName, theme);
				XChartsMgr.themeNames.Add(theme.themeName);
				XChartsMgr.themeNames.Sort();
			}
		}

		public static Theme GetTheme(ThemeType type)
		{
			return GetTheme(type.ToString());
		}

		public static Theme GetTheme(string themeName)
		{
			if (!XChartsMgr.themes.ContainsKey(themeName))
			{
				ReloadThemeList();
				if (XChartsMgr.themes.ContainsKey(themeName))
				{
					return XChartsMgr.themes[themeName];
				}
				return null;
			}
			return XChartsMgr.themes[themeName];
		}

		public static Theme LoadTheme(ThemeType type)
		{
			return LoadTheme(type.ToString());
		}

		public static Theme LoadTheme(string themeName)
		{
			Theme theme = Resources.Load<Theme>(XCSettings.THEME_ASSET_NAME_PREFIX + themeName);
			if (theme == null)
			{
				theme = Resources.Load<Theme>(themeName);
			}
			return theme;
		}

		public static List<string> GetAllThemeNames()
		{
			return XChartsMgr.themeNames;
		}

		public static List<Theme> GetThemeList()
		{
			List<Theme> list = new List<Theme>();
			foreach (Theme value in XChartsMgr.themes.Values)
			{
				list.Add(value);
			}
			return list;
		}

		public static bool ContainsTheme(string themeName)
		{
			return XChartsMgr.themeNames.Contains(themeName);
		}

		public static void SwitchTheme(BaseChart chart, string themeName)
		{
			if (!XChartsMgr.themes.ContainsKey(themeName))
			{
				Debug.LogError("SwitchTheme ERROR: not exist theme:" + themeName);
				return;
			}
			Theme theme = XChartsMgr.themes[themeName];
			chart.UpdateTheme(theme);
		}

		public static bool ExportTheme(Theme theme, string themeNewName)
		{
			return false;
		}

		public static bool ExportTheme(Theme theme)
		{
			return false;
		}

		public static string GetThemeAssetPath(string themeName)
		{
			return $"{XCSettings.THEME_ASSET_FOLDER}/{XCSettings.THEME_ASSET_NAME_PREFIX}{themeName}.asset";
		}
	}
}
