using System;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public class ThemesSettings : ScriptableObject
	{
		public const string FILE_NAME = "ThemesSettings";

		private static ThemesSettings s_instance;

		[SerializeField]
		private ThemesDatabase database;

		public const bool DEFAULT_AUTO_SAVE = true;

		public bool AutoSave;

		private static string ResourcesPath => null;

		public static ThemesSettings Instance => null;

		public static ThemesDatabase Database => null;

		public static void UpdateDatabase()
		{
		}

		private void Reset()
		{
		}

		public void Reset(bool saveAssets)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}
	}
}
