using System;
using Cpp2ILInjected;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Settings;

[Serializable]
public class UIPopupSettings : ScriptableObject
{
	public const string FILE_NAME = "UIPopupSettings";

	private static UIPopupSettings s_instance;

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

	public bool AddToPopupQueue = true;

	public bool AutoHideAfterShow;

	public bool AutoSelectButtonAfterShow;

	public bool BlockBackButton = true;

	public bool CustomCanvasName;

	public bool DestroyAfterHide = true;

	public bool HideOnAnyButton;

	public bool HideOnBackButton = true;

	public bool HideOnClickAnywhere;

	public bool HideOnClickContainer = true;

	public bool HideOnClickOverlay;

	public bool UpdateHideProgressorOnShow;

	public bool UpdateShowProgressorOnHide;

	public bool UseOverlay = true;

	public float AutoHideAfterShowDelay = 3f;

	public string CanvasName;

	private static string ResourcesPath => DoozyPath.UIPOPUP_RESOURCES_PATH;

	public static UIPopupSettings Instance
	{
		get
		{
			UIPopupSettings uIPopupSettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)uIPopupSettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				UIPopupSettings uIPopupSettings2 = default(UIPopupSettings);
				s_instance = uIPopupSettings2;
			}
			return s_instance;
		}
	}

	public static UIPopupDatabase Database
	{
		get
		{
			UIPopupSettings instance = Instance;
			if ((object)instance != null)
			{
				UIPopupDatabase uIPopupDatabase = instance.database;
				if ((object)instance.database == null || ((UnityEngine.Object)uIPopupDatabase).m_CachedPtr == (IntPtr)0)
				{
					UIPopupSettings instance2 = Instance;
					string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UIPopup);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
					if ((object)instance2 == null)
					{
						goto IL_00cc;
					}
					UIPopupDatabase uIPopupDatabase2 = default(UIPopupDatabase);
					instance2.database = uIPopupDatabase2;
				}
				UIPopupSettings instance3 = Instance;
				if ((object)instance3 != null)
				{
					return instance3.database;
				}
			}
			goto IL_00cc;
			IL_00cc:
			return (UIPopupDatabase)(object)new NullReferenceException();
		}
	}

	public static void UpdateDatabase()
	{
		UIPopupSettings instance = Instance;
		string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UIPopup);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
		UIPopupDatabase uIPopupDatabase = default(UIPopupDatabase);
		instance.database = uIPopupDatabase;
	}

	private void Reset()
	{
		AddToPopupQueue = true;
		AutoHideAfterShowDelay = 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CanvasName = "MasterCanvas";
		CustomCanvasName = false;
		DisplayTarget = PopupDisplayOn.PopupCanvas;
		HideOnClickAnywhere = false;
		UpdateShowProgressorOnHide = false;
	}

	public void Reset(bool saveAssets)
	{
		AddToPopupQueue = true;
		AutoHideAfterShowDelay = 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CanvasName = "MasterCanvas";
		CustomCanvasName = false;
		DisplayTarget = PopupDisplayOn.PopupCanvas;
		HideOnClickAnywhere = false;
		UpdateShowProgressorOnHide = false;
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void ResetComponent(UIPopup popup)
	{
		popup.AddToPopupQueue = AddToPopupQueue;
		popup.AutoHideAfterShow = AutoHideAfterShow;
		popup.AutoHideAfterShowDelay = AutoHideAfterShowDelay;
		popup.AutoSelectButtonAfterShow = AutoSelectButtonAfterShow;
		popup.BlockBackButton = BlockBackButton;
		popup.CanvasName = CanvasName;
		popup.CustomCanvasName = CustomCanvasName;
		popup.DestroyAfterHide = DestroyAfterHide;
		popup.DisplayTarget = DisplayTarget;
		popup.HideOnAnyButton = HideOnAnyButton;
		popup.HideOnBackButton = HideOnBackButton;
		popup.HideOnClickAnywhere = HideOnClickAnywhere;
		popup.HideOnClickContainer = HideOnClickContainer;
		popup.HideOnClickOverlay = HideOnClickOverlay;
		popup.UpdateHideProgressorOnShow = UpdateHideProgressorOnShow;
		popup.UpdateShowProgressorOnHide = UpdateShowProgressorOnHide;
		popup.UseOverlay = UseOverlay;
		if (popup.Container == null)
		{
			UIContainer container = new UIContainer();
			popup.Container = container;
		}
		if (popup.Overlay == null)
		{
			UIContainer overlay = new UIContainer();
			popup.Overlay = overlay;
		}
		if (popup.Data == null)
		{
			UIPopupContentReferences data = new UIPopupContentReferences();
			popup.Data = data;
		}
		UIPopupBehavior showBehavior = new UIPopupBehavior(AnimationType.Show);
		popup.ShowBehavior = showBehavior;
		UIPopupBehavior hideBehavior = new UIPopupBehavior(AnimationType.Hide);
		popup.HideBehavior = hideBehavior;
		popup.SelectedButton = null;
		popup.m_visibilityState = VisibilityState.Visible;
		popup.VisibilityProgress = 1f;
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public UIPopupSettings()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CanvasName = "MasterCanvas";
		base._002Ector();
	}
}
