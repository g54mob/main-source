using System;
using Cpp2ILInjected;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Settings;

[Serializable]
public class UIViewSettings : ScriptableObject
{
	public const string FILE_NAME = "UIViewSettings";

	private static UIViewSettings s_instance;

	private NamesDatabase database;

	public const TargetOrientation TARGET_ORIENTATION_DEFAULT_VALUE = TargetOrientation.Any;

	public const UIViewStartBehavior BEHAVIOUR_AT_START_DEFAULT_VALUE = UIViewStartBehavior.DoNothing;

	public const bool DEFAULT_AUTO_HIDE_AFTER_SHOW = false;

	public const bool DEFAULT_AUTO_SELECT_BUTTON_AFTER_SHOW = false;

	public const bool DESELECT_ANY_BUTTON_SELECTED_ON_HIDE_DEFAULT_VALUE = false;

	public const bool DESELECT_ANY_BUTTON_SELECTED_ON_SHOW_DEFAULT_VALUE = false;

	public const bool DISABLE_CANVAS_WHEN_HIDDEN_DEFAULT_VALUE = true;

	public const bool DISABLE_GAME_OBJECT_WHEN_HIDDEN_DEFAULT_VALUE = true;

	public const bool DISABLE_GRAPHIC_RAYCASTER_WHEN_HIDDEN_DEFAULT_VALUE = true;

	public const bool USE_CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE = true;

	public const float DEFAULT_AUTO_HIDE_AFTER_SHOW_DELAY = 3f;

	public const float DISABLE_WHEN_HIDDEN_TIME_BUFFER = 0.05f;

	public const string RENAME_PREFIX_DEFAULT_VALUE = "View - ";

	public const string RENAME_SUFFIX_DEFAULT_VALUE = "";

	public static Vector3 CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE;

	public TargetOrientation TargetOrientation;

	public UIViewStartBehavior BehaviorAtStart;

	public Vector3 CustomStartAnchoredPosition;

	public bool DeselectAnyButtonSelectedOnHide;

	public bool DeselectAnyButtonSelectedOnShow;

	public bool DisableCanvasWhenHidden;

	public bool DisableGameObjectWhenHidden;

	public bool DisableGraphicRaycasterWhenHidden;

	public bool UseCustomStartAnchoredPosition;

	public string RenamePrefix;

	public string RenameSuffix;

	private static string ResourcesPath => DoozyPath.UIVIEW_RESOURCES_PATH;

	public static UIViewSettings Instance
	{
		get
		{
			UIViewSettings uIViewSettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)uIViewSettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				UIViewSettings uIViewSettings2 = default(UIViewSettings);
				s_instance = uIViewSettings2;
			}
			return s_instance;
		}
	}

	public static NamesDatabase Database
	{
		get
		{
			UIViewSettings instance = Instance;
			if ((object)instance != null)
			{
				NamesDatabase namesDatabase = instance.database;
				if ((object)instance.database == null || ((UnityEngine.Object)namesDatabase).m_CachedPtr == (IntPtr)0)
				{
					UIViewSettings instance2 = Instance;
					string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UIView);
					NamesDatabase namesDatabase2 = NamesDatabase.GetDatabase("UIViewDatabase", dataPath);
					if ((object)instance2 == null)
					{
						goto IL_010f;
					}
					instance2.database = namesDatabase2;
				}
				UIViewSettings instance3 = Instance;
				if ((object)instance3 != null)
				{
					return instance3.database;
				}
			}
			goto IL_010f;
			IL_010f:
			return (NamesDatabase)(object)new NullReferenceException();
		}
	}

	public static void UpdateDatabase()
	{
		UIViewSettings instance = Instance;
		string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UIView);
		NamesDatabase namesDatabase = NamesDatabase.GetDatabase("UIViewDatabase", dataPath);
		instance.database = namesDatabase;
	}

	private void Reset()
	{
		//IL_0035: Expected I, but got O
		BehaviorAtStart = UIViewStartBehavior.DoNothing;
		nint num = (nint)typeof(UIViewSettings);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (Il2CppClass<Doozy.Engine.UI.Settings.UIViewSettings>)+B8]");
		nint num2 = 0;
		CustomStartAnchoredPosition = CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (Il2CppStaticFields<Doozy.Engine.UI.Settings.UIViewSettings>)+10]");
		_ = 0;
		DeselectAnyButtonSelectedOnHide = false;
		DisableGraphicRaycasterWhenHidden = true;
		RenamePrefix = "View - ";
		RenameSuffix = "";
		UseCustomStartAnchoredPosition = true;
		TargetOrientation = TargetOrientation.Any;
	}

	public void Reset(bool saveAssets)
	{
		//IL_0044: Expected I, but got O
		BehaviorAtStart = UIViewStartBehavior.DoNothing;
		nint num = (nint)typeof(UIViewSettings);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (Il2CppClass<Doozy.Engine.UI.Settings.UIViewSettings>)+B8]");
		nint num2 = 0;
		CustomStartAnchoredPosition = CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v4 (Il2CppStaticFields<Doozy.Engine.UI.Settings.UIViewSettings>)+10]");
		_ = 0;
		DeselectAnyButtonSelectedOnHide = false;
		DisableGraphicRaycasterWhenHidden = true;
		RenamePrefix = "View - ";
		RenameSuffix = "";
		TargetOrientation = TargetOrientation.Any;
		UseCustomStartAnchoredPosition = true;
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void ResetComponent(UIView view)
	{
		view.AutoHideAfterShow = false;
		view.AutoHideAfterShowDelay = 3f;
		view.AutoSelectButtonAfterShow = false;
		view.BehaviorAtStart = BehaviorAtStart;
		view.CustomStartAnchoredPosition = CustomStartAnchoredPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Settings.UIViewSettings)+30]");
		_ = 0;
		view.DeselectAnyButtonSelectedOnHide = DeselectAnyButtonSelectedOnHide;
		view.DeselectAnyButtonSelectedOnShow = DeselectAnyButtonSelectedOnShow;
		view.DisableCanvasWhenHidden = DisableCanvasWhenHidden;
		view.DisableGameObjectWhenHidden = DisableGameObjectWhenHidden;
		view.DisableGraphicRaycasterWhenHidden = DisableGraphicRaycasterWhenHidden;
		UIViewBehavior hideBehavior = new UIViewBehavior(AnimationType.Hide);
		view.HideBehavior = hideBehavior;
		UIViewBehavior loopBehavior = new UIViewBehavior(AnimationType.Loop);
		view.LoopBehavior = loopBehavior;
		UIViewBehavior showBehavior = new UIViewBehavior(AnimationType.Show);
		view.ShowBehavior = showBehavior;
		view.TargetOrientation = TargetOrientation;
		view.UseCustomStartAnchoredPosition = UseCustomStartAnchoredPosition;
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public UIViewSettings()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807F4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		RenamePrefix = "View - ";
		RenameSuffix = "";
		base._002Ector();
	}

	static UIViewSettings()
	{
		//IL_0018: Expected I, but got O
		//IL_0036: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		nint num3 = (nint)typeof(UIViewSettings);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppClass<Doozy.Engine.UI.Settings.UIViewSettings>)+B8]");
		nint num4 = 0;
		CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
	}
}
