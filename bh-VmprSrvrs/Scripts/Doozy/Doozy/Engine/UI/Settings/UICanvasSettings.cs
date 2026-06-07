using System;
using Doozy.Engine.UI.Base;
using UnityEngine;

namespace Doozy.Engine.UI.Settings
{
	[Serializable]
	public class UICanvasSettings : ScriptableObject
	{
		public const string FILE_NAME = "UICanvasSettings";

		private static UICanvasSettings s_instance;

		[SerializeField]
		private NamesDatabase database;

		public const bool DONT_DESTROY_CANVAS_ON_LOAD_DEFAULT_VALUE = true;

		public const string RENAME_PREFIX_DEFAULT_VALUE = "Canvas - ";

		public const string RENAME_SUFFIX_DEFAULT_VALUE = "";

		public bool DontDestroyCanvasOnLoad;

		public string RenamePrefix;

		public string RenameSuffix;

		private static string ResourcesPath => null;

		public static UICanvasSettings Instance => null;

		public static NamesDatabase Database => null;

		public static void UpdateDatabase()
		{
		}

		private void Reset()
		{
		}

		public void Reset(bool saveAssets)
		{
		}

		public void ResetComponent(UICanvas canvas)
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
