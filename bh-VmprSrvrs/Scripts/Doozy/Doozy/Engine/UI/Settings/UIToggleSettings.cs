using System;
using Doozy.Engine.UI.Input;
using UnityEngine;

namespace Doozy.Engine.UI.Settings
{
	[Serializable]
	public class UIToggleSettings : ScriptableObject
	{
		public const string FILE_NAME = "UIToggleSettings";

		private static UIToggleSettings s_instance;

		public const bool ALLOW_MULTIPLE_CLICKS_DEFAULT_VALUE = true;

		public const bool DESELECT_BUTTON_AFTER_CLICK_DEFAULT_VALUE = false;

		public const float BETWEEN_CLICKS_DISABLE_INTERVAL_DEFAULT_VALUE = 0.2f;

		public const float DEFAULT_BUTTON_HEIGHT = 20f;

		public const float DEFAULT_BUTTON_WIDTH = 160f;

		public InputMode InputMode;

		public KeyCode KeyCode;

		public KeyCode KeyCodeAlt;

		public bool AllowMultipleClicks;

		public bool DeselectButtonAfterClick;

		public bool EnableAlternateInputs;

		public bool ShowOnButtonDeselected;

		public bool ShowOnButtonSelected;

		public bool ShowOnClick;

		public bool ShowOnPointerEnter;

		public bool ShowOnPointerExit;

		public float DisableButtonBetweenClicksInterval;

		public string VirtualButtonName;

		public string VirtualButtonNameAlt;

		private static string ResourcesPath => null;

		public static UIToggleSettings Instance => null;

		private void Reset()
		{
		}

		public void Reset(bool saveAssets)
		{
		}

		public void ResetComponent(UIToggle toggle)
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
