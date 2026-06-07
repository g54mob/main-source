using System;
using System.Collections.Generic;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public class ThemesDatabase : ScriptableObject
	{
		public const string GENERAL_THEME_NAME = "General";

		public const string THEME_ASSET_PREFIX = "Theme_";

		public List<string> ThemesNames;

		public List<ThemeData> Themes;

		private static UILanguagePack UILabels => null;

		public bool AddTheme(ThemeData themeData, bool saveAssets)
		{
			return false;
		}

		public bool Contains(Guid themeGuid)
		{
			return false;
		}

		public bool Contains(string themeName)
		{
			return false;
		}

		public bool CreateTheme(string themeName, bool showDialog = false, bool saveAssets = false)
		{
			return false;
		}

		public bool CreateTheme(string relativePath, string themeName, bool showDialog = false, bool saveAssets = false)
		{
			return false;
		}

		public bool DeleteThemeData(ThemeData themeData)
		{
			return false;
		}

		public ThemeData GetThemeData(Guid themeGuid)
		{
			return null;
		}

		public ThemeData GetThemeData(string themeName)
		{
			return null;
		}

		public int GetThemeIndex(Guid id)
		{
			return 0;
		}

		public ThemeVariantData GetVariant(Guid variantId)
		{
			return null;
		}

		public void Initialize()
		{
		}

		public bool ContainsTheme(string themeName)
		{
			return false;
		}

		public void InitializeThemes()
		{
		}

		public void RefreshDatabase(bool performUndo = true, bool saveAssets = false)
		{
		}

		public void RemoveDuplicates(bool performUndo, bool saveAssets = false)
		{
		}

		public bool RemoveNullDatabases(bool saveAssets = false)
		{
			return false;
		}

		public bool RenameThemeData(ThemeData themeData, string newThemeName)
		{
			return false;
		}

		public bool ResetDatabase()
		{
			return false;
		}

		public void SearchForUnregisteredThemes(bool saveAssets)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void Sort(bool performUndo, bool saveAssets = false)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}

		public void UpdateThemesNames(bool saveAssets = false)
		{
		}

		public static string[] GetThemesNames(ThemesDatabase database)
		{
			return null;
		}

		public static string[] GetVariantNames(ThemeData themeData)
		{
			return null;
		}

		public static string GetThemeDataFilename(string themeName)
		{
			return null;
		}
	}
}
