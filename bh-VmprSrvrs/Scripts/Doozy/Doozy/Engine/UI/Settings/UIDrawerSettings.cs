using System;
using Doozy.Engine.Touchy;
using Doozy.Engine.UI.Base;
using UnityEngine;

namespace Doozy.Engine.UI.Settings
{
	[Serializable]
	public class UIDrawerSettings : ScriptableObject
	{
		public const string FILE_NAME = "UIDrawerSettings";

		private static UIDrawerSettings s_instance;

		[SerializeField]
		private NamesDatabase database;

		public const bool BLOCK_BACK_BUTTON_DEFAULT_VALUE = true;

		public const bool DETECT_GESTURES_DEFAULT_VALUE = true;

		public const bool HIDE_ON_BACK_BUTTON_DEFAULT_VALUE = true;

		public const bool USE_CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE = true;

		public const float CLOSE_SPEED_DEFAULT_VALUE = 10f;

		public const float OPEN_SPEED_DEFAULT_VALUE = 10f;

		public const SimpleSwipe CLOSE_DIRECTION_DEFAULT_VALUE = SimpleSwipe.Left;

		public const string RENAME_PREFIX_DEFAULT_VALUE = "Drawer - ";

		public const string RENAME_SUFFIX_DEFAULT_VALUE = "";

		public static Vector3 CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE;

		public SimpleSwipe CloseDirection;

		public Vector3 CustomStartAnchoredPosition;

		public bool BlockBackButton;

		public bool HideOnBackButton;

		public bool DetectGestures;

		public bool UseCustomStartAnchoredPosition;

		public float CloseSpeed;

		public float OpenSpeed;

		public string RenamePrefix;

		public string RenameSuffix;

		private static string ResourcesPath => null;

		public static UIDrawerSettings Instance => null;

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

		public void ResetComponent(UIDrawer drawer)
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
