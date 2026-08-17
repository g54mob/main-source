using System;
using Cpp2ILInjected;
using Doozy.Engine.UI.Input;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Settings;

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

	private static string ResourcesPath => DoozyPath.UITOGGLE_RESOURCES_PATH;

	public static UIToggleSettings Instance
	{
		get
		{
			UIToggleSettings uIToggleSettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)uIToggleSettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				UIToggleSettings uIToggleSettings2 = default(UIToggleSettings);
				s_instance = uIToggleSettings2;
			}
			return s_instance;
		}
	}

	private void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807E7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AllowMultipleClicks = true;
		DisableButtonBetweenClicksInterval = 0.2f;
		EnableAlternateInputs = true;
		InputMode = InputMode.VirtualButton;
		KeyCode = KeyCode.Return;
		KeyCodeAlt = KeyCode.Space;
		VirtualButtonName = "Submit";
		VirtualButtonNameAlt = "Jump";
	}

	public void Reset(bool saveAssets)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807E7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AllowMultipleClicks = true;
		DisableButtonBetweenClicksInterval = 0.2f;
		EnableAlternateInputs = true;
		InputMode = InputMode.VirtualButton;
		KeyCode = KeyCode.Return;
		KeyCodeAlt = KeyCode.Space;
		VirtualButtonName = "Submit";
		VirtualButtonNameAlt = "Jump";
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void ResetComponent(UIToggle toggle)
	{
		toggle.AllowMultipleClicks = AllowMultipleClicks;
		toggle.DeselectButtonAfterClick = DeselectButtonAfterClick;
		toggle.DisableButtonBetweenClicksInterval = DisableButtonBetweenClicksInterval;
		InputData inputData = new InputData();
		inputData.InputMode = InputMode;
		inputData.EnableAlternateInputs = EnableAlternateInputs;
		inputData.KeyCode = KeyCode;
		inputData.KeyCodeAlt = KeyCodeAlt;
		inputData.VirtualButtonName = VirtualButtonName;
		inputData.VirtualButtonNameAlt = VirtualButtonNameAlt;
		toggle.InputData = inputData;
		UIToggleBehavior uIToggleBehavior = null;
		uIToggleBehavior.Reset(UIToggleBehaviorType.OnClick);
		uIToggleBehavior.Enabled = true;
		toggle.OnClick = uIToggleBehavior;
		UIToggleBehavior uIToggleBehavior2 = null;
		uIToggleBehavior2.Reset(UIToggleBehaviorType.OnDeselected);
		uIToggleBehavior2.Enabled = false;
		toggle.OnDeselected = uIToggleBehavior2;
		UIToggleBehavior uIToggleBehavior3 = null;
		uIToggleBehavior3.Reset(UIToggleBehaviorType.OnPointerEnter);
		uIToggleBehavior3.Enabled = false;
		toggle.OnPointerEnter = uIToggleBehavior3;
		UIToggleBehavior uIToggleBehavior4 = null;
		uIToggleBehavior4.Reset(UIToggleBehaviorType.OnPointerExit);
		uIToggleBehavior4.Enabled = false;
		toggle.OnPointerExit = uIToggleBehavior4;
		UIToggleBehavior uIToggleBehavior5 = null;
		uIToggleBehavior5.Reset(UIToggleBehaviorType.OnSelected);
		uIToggleBehavior5.Enabled = false;
		toggle.OnSelected = uIToggleBehavior5;
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public UIToggleSettings()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807EB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		InputMode = InputMode.VirtualButton;
		KeyCode = KeyCode.Return;
		KeyCodeAlt = KeyCode.Space;
		AllowMultipleClicks = true;
		EnableAlternateInputs = true;
		ShowOnPointerEnter = true;
		DisableButtonBetweenClicksInterval = 0.2f;
		VirtualButtonName = "Submit";
		VirtualButtonNameAlt = "Jump";
		base._002Ector();
	}
}
