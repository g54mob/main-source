using System;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Input;
using UnityEngine;

namespace Doozy.Engine.UI.Settings
{
	[Serializable]
	public class UIButtonSettings : ScriptableObject
	{
		public const string FILE_NAME = "UIButtonSettings";

		private static UIButtonSettings s_instance;

		[SerializeField]
		private NamesDatabase database;

		public const SingleClickMode DEFAULT_SINGLE_CLICK_MODE = SingleClickMode.Instant;

		public const bool DEFAULT_ALLOW_MULTIPLE_CLICKS = true;

		public const bool DEFAULT_DESELECT_BUTTON_AFTER_CLICK = false;

		public const float BETWEEN_CLICKS_DISABLE_INTERVAL = 0.2f;

		public const float DEFAULT_BUTTON_HEIGHT = 30f;

		public const float DEFAULT_BUTTON_WIDTH = 160f;

		public const float DOUBLE_CLICK_REGISTER_INTERVAL = 0.2f;

		public const float LONG_CLICK_REGISTER_INTERVAL = 0.5f;

		public const string DEFAULT_RENAME_PREFIX = "Button - ";

		public const string DEFAULT_RENAME_SUFFIX = "";

		public InputMode InputMode;

		public KeyCode KeyCode;

		public KeyCode KeyCodeAlt;

		public SingleClickMode ClickMode;

		public bool AllowMultipleClicks;

		public bool DeselectButtonAfterClick;

		public bool EnableAlternateInputs;

		public bool ShowNormalLoopAnimation;

		public bool ShowOnButtonDeselected;

		public bool ShowOnButtonSelected;

		public bool ShowOnClick;

		public bool ShowOnDoubleClick;

		public bool ShowOnLongClick;

		public bool ShowOnRightClick;

		public bool ShowOnPointerDown;

		public bool ShowOnPointerEnter;

		public bool ShowOnPointerExit;

		public bool ShowOnPointerUp;

		public bool ShowSelectedLoopAnimation;

		public float DisableButtonBetweenClicksInterval;

		public string RenamePrefix;

		public string RenameSuffix;

		public string VirtualButtonName;

		public string VirtualButtonNameAlt;

		private static string ResourcesPath => null;

		public static UIButtonSettings Instance => null;

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

		public void ResetComponent(UIButton button)
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
