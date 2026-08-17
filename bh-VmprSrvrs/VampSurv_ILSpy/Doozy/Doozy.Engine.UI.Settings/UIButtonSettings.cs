using System;
using Cpp2ILInjected;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Input;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Settings;

[Serializable]
public class UIButtonSettings : ScriptableObject
{
	public const string FILE_NAME = "UIButtonSettings";

	private static UIButtonSettings s_instance;

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

	private static string ResourcesPath => DoozyPath.UIBUTTON_RESOURCES_PATH;

	public static UIButtonSettings Instance
	{
		get
		{
			UIButtonSettings uIButtonSettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)uIButtonSettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				UIButtonSettings uIButtonSettings2 = default(UIButtonSettings);
				s_instance = uIButtonSettings2;
			}
			return s_instance;
		}
	}

	public static NamesDatabase Database
	{
		get
		{
			UIButtonSettings instance = Instance;
			if ((object)instance != null)
			{
				NamesDatabase namesDatabase = instance.database;
				if ((object)instance.database == null || ((UnityEngine.Object)namesDatabase).m_CachedPtr == (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807C5]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					UIButtonSettings instance2 = Instance;
					string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UIButton);
					NamesDatabase namesDatabase2 = NamesDatabase.GetDatabase("UIButtonDatabase", dataPath);
					if ((object)instance2 == null)
					{
						goto IL_0102;
					}
					instance2.database = namesDatabase2;
				}
				UIButtonSettings instance3 = Instance;
				if ((object)instance3 != null)
				{
					return instance3.database;
				}
			}
			goto IL_0102;
			IL_0102:
			return (NamesDatabase)(object)new NullReferenceException();
		}
	}

	public static void UpdateDatabase()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807C5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIButtonSettings instance = Instance;
		string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UIButton);
		NamesDatabase namesDatabase = NamesDatabase.GetDatabase("UIButtonDatabase", dataPath);
		instance.database = namesDatabase;
	}

	private void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807C6]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AllowMultipleClicks = true;
		KeyCodeAlt = KeyCode.Space;
		DisableButtonBetweenClicksInterval = 0.2f;
		EnableAlternateInputs = true;
		InputMode = InputMode.VirtualButton;
		KeyCode = KeyCode.Return;
		RenamePrefix = "Button - ";
		RenameSuffix = "";
		VirtualButtonName = "Submit";
		VirtualButtonNameAlt = "Jump";
	}

	public void Reset(bool saveAssets)
	{
		Reset();
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void ResetComponent(UIButton button)
	{
		button.AllowMultipleClicks = AllowMultipleClicks;
		button.ClickMode = ClickMode;
		button.DeselectButtonAfterClick = DeselectButtonAfterClick;
		button.DisableButtonBetweenClicksInterval = DisableButtonBetweenClicksInterval;
		InputData inputData = new InputData();
		inputData.InputMode = InputMode;
		inputData.EnableAlternateInputs = EnableAlternateInputs;
		inputData.KeyCode = KeyCode;
		inputData.KeyCodeAlt = KeyCodeAlt;
		inputData.VirtualButtonName = VirtualButtonName;
		inputData.VirtualButtonNameAlt = VirtualButtonNameAlt;
		button.InputData = inputData;
		UIButtonLoopAnimation normalLoopAnimation = new UIButtonLoopAnimation(ButtonLoopAnimationType.Normal);
		button.NormalLoopAnimation = normalLoopAnimation;
		UIButtonBehavior uIButtonBehavior = null;
		uIButtonBehavior.Reset(UIButtonBehaviorType.OnClick);
		uIButtonBehavior.Enabled = true;
		button.OnClick = uIButtonBehavior;
		UIButtonBehavior uIButtonBehavior2 = null;
		uIButtonBehavior2.Reset(UIButtonBehaviorType.OnDeselected);
		uIButtonBehavior2.Enabled = false;
		button.OnDeselected = uIButtonBehavior2;
		UIButtonBehavior uIButtonBehavior3 = null;
		uIButtonBehavior3.Reset(UIButtonBehaviorType.OnDoubleClick);
		uIButtonBehavior3.Enabled = false;
		button.OnDoubleClick = uIButtonBehavior3;
		UIButtonBehavior uIButtonBehavior4 = null;
		uIButtonBehavior4.Reset(UIButtonBehaviorType.OnLongClick);
		uIButtonBehavior4.Enabled = false;
		button.OnLongClick = uIButtonBehavior4;
		UIButtonBehavior uIButtonBehavior5 = null;
		uIButtonBehavior5.Reset(UIButtonBehaviorType.OnRightClick);
		uIButtonBehavior5.Enabled = false;
		button.OnRightClick = uIButtonBehavior5;
		UIButtonBehavior uIButtonBehavior6 = null;
		uIButtonBehavior6.Reset(UIButtonBehaviorType.OnPointerDown);
		uIButtonBehavior6.Enabled = false;
		button.OnPointerDown = uIButtonBehavior6;
		UIButtonBehavior uIButtonBehavior7 = null;
		uIButtonBehavior7.Reset(UIButtonBehaviorType.OnPointerEnter);
		uIButtonBehavior7.Enabled = false;
		button.OnPointerEnter = uIButtonBehavior7;
		UIButtonBehavior uIButtonBehavior8 = null;
		uIButtonBehavior8.Reset(UIButtonBehaviorType.OnPointerExit);
		uIButtonBehavior8.Enabled = false;
		button.OnPointerExit = uIButtonBehavior8;
		UIButtonBehavior uIButtonBehavior9 = null;
		uIButtonBehavior9.Reset(UIButtonBehaviorType.OnPointerUp);
		uIButtonBehavior9.Enabled = false;
		button.OnPointerUp = uIButtonBehavior9;
		UIButtonBehavior uIButtonBehavior10 = null;
		uIButtonBehavior10.Reset(UIButtonBehaviorType.OnSelected);
		uIButtonBehavior10.Enabled = false;
		button.OnSelected = uIButtonBehavior10;
		UIButtonLoopAnimation selectedLoopAnimation = new UIButtonLoopAnimation(ButtonLoopAnimationType.Selected);
		button.SelectedLoopAnimation = selectedLoopAnimation;
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public UIButtonSettings()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807CA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		InputMode = InputMode.VirtualButton;
		KeyCode = KeyCode.Return;
		KeyCodeAlt = KeyCode.Space;
		AllowMultipleClicks = true;
		EnableAlternateInputs = true;
		ShowOnClick = true;
		ShowOnPointerDown = true;
		ShowSelectedLoopAnimation = true;
		DisableButtonBetweenClicksInterval = 0.2f;
		RenamePrefix = "Button - ";
		RenameSuffix = "";
		VirtualButtonName = "Submit";
		VirtualButtonNameAlt = "Jump";
		base._002Ector();
	}
}
