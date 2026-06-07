using System;
using UnityEngine;

namespace Doozy.Engine.UI.Settings
{
	[Serializable]
	public class UIPopupSettings : ScriptableObject
	{
		public const string FILE_NAME = "UIPopupSettings";

		private static UIPopupSettings s_instance;

		[SerializeField]
		private UIPopupDatabase database;

		public const bool ADD_TO_POPUP_QUEUE_DEFAULT_VALUE = true;

		public const bool AUTO_HIDE_AFTER_SHOW_DEFAULT_VALUE = false;

		public const bool AUTO_SELECT_BUTTON_AFTER_SHOW_DEFAULT_VALUE = false;

		public const bool BLOCK_BACK_BUTTON_DEFAULT_VALUE = true;

		public const bool CUSTOM_CANVAS_NAME_DEFAULT_VALUE = false;

		public const bool DESTROY_AFTER_HIDE_DEFAULT_VALUE = true;

		public const bool HIDE_ON_ANY_BUTTON_DEFAULT_VALUE = false;

		public const bool HIDE_ON_BACK_BUTTON_DEFAULT_VALUE = true;

		public const bool HIDE_ON_CLICK_ANYWHERE_DEFAULT_VALUE = false;

		public const bool HIDE_ON_CLICK_CONTAINER_DEFAULT_VALUE = true;

		public const bool HIDE_ON_CLICK_OVERLAY_DEFAULT_VALUE = true;

		public const bool UPDATE_HIDE_PROGRESSOR_ON_SHOW_DEFAULT_VALUE = false;

		public const bool UPDATE_SHOW_PROGRESSOR_ON_HIDE_DEFAULT_VALUE = false;

		public const bool USE_OVERLAY_DEFAULT_VALUE = true;

		public const float AUTO_HIDE_AFTER_SHOW_DELAY_DEFAULT_VALUE = 3f;

		public const float DISABLE_WHEN_HIDDEN_TIME_BUFFER = 0.05f;

		public const PopupDisplayOn DISPLAY_ON_DEFAULT_VALUE = PopupDisplayOn.PopupCanvas;

		public const VisibilityState VISIBILITY_DEFAULT_VALUE = VisibilityState.Visible;

		public PopupDisplayOn DisplayTarget;

		public bool AddToPopupQueue;

		public bool AutoHideAfterShow;

		public bool AutoSelectButtonAfterShow;

		public bool BlockBackButton;

		public bool CustomCanvasName;

		public bool DestroyAfterHide;

		public bool HideOnAnyButton;

		public bool HideOnBackButton;

		public bool HideOnClickAnywhere;

		public bool HideOnClickContainer;

		public bool HideOnClickOverlay;

		public bool UpdateHideProgressorOnShow;

		public bool UpdateShowProgressorOnHide;

		public bool UseOverlay;

		public float AutoHideAfterShowDelay;

		public string CanvasName;

		private static string ResourcesPath => null;

		public static UIPopupSettings Instance => null;

		public static UIPopupDatabase Database => null;

		public static void UpdateDatabase()
		{
		}

		private void Reset()
		{
		}

		public void Reset(bool saveAssets)
		{
		}

		public void ResetComponent(UIPopup popup)
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
