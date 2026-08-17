using System;
using Cpp2ILInjected;
using Doozy.Engine.Touchy;
using Doozy.Engine.UI.Base;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Settings;

[Serializable]
public class UIDrawerSettings : ScriptableObject
{
	public const string FILE_NAME = "UIDrawerSettings";

	private static UIDrawerSettings s_instance;

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

	private static string ResourcesPath => DoozyPath.UIDRAWER_RESOURCES_PATH;

	public static UIDrawerSettings Instance
	{
		get
		{
			UIDrawerSettings uIDrawerSettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)uIDrawerSettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				UIDrawerSettings uIDrawerSettings2 = default(UIDrawerSettings);
				s_instance = uIDrawerSettings2;
			}
			return s_instance;
		}
	}

	public static NamesDatabase Database
	{
		get
		{
			UIDrawerSettings instance = Instance;
			if ((object)instance != null)
			{
				NamesDatabase namesDatabase = instance.database;
				if ((object)instance.database == null || ((UnityEngine.Object)namesDatabase).m_CachedPtr == (IntPtr)0)
				{
					UIDrawerSettings instance2 = Instance;
					string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UIDrawer);
					NamesDatabase namesDatabase2 = NamesDatabase.GetDatabase("UIDrawerDatabase", dataPath);
					if ((object)instance2 == null)
					{
						goto IL_010f;
					}
					instance2.database = namesDatabase2;
				}
				UIDrawerSettings instance3 = Instance;
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
		UIDrawerSettings instance = Instance;
		string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UIDrawer);
		NamesDatabase namesDatabase = NamesDatabase.GetDatabase("UIDrawerDatabase", dataPath);
		instance.database = namesDatabase;
	}

	private void Reset()
	{
		//IL_0035: Expected I, but got O
		CloseDirection = SimpleSwipe.Left;
		CloseSpeed = 10f;
		nint num = (nint)typeof(UIDrawerSettings);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (Il2CppClass<Doozy.Engine.UI.Settings.UIDrawerSettings>)+B8]");
		nint num2 = 0;
		CustomStartAnchoredPosition = CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (Il2CppStaticFields<Doozy.Engine.UI.Settings.UIDrawerSettings>)+10]");
		_ = 0;
		BlockBackButton = true;
		DetectGestures = true;
		OpenSpeed = 10f;
		RenamePrefix = "Drawer - ";
		RenameSuffix = "";
		UseCustomStartAnchoredPosition = true;
	}

	public void Reset(bool saveAssets)
	{
		//IL_0044: Expected I, but got O
		CloseDirection = SimpleSwipe.Left;
		CloseSpeed = 10f;
		nint num = (nint)typeof(UIDrawerSettings);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (Il2CppClass<Doozy.Engine.UI.Settings.UIDrawerSettings>)+B8]");
		nint num2 = 0;
		CustomStartAnchoredPosition = CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v4 (Il2CppStaticFields<Doozy.Engine.UI.Settings.UIDrawerSettings>)+10]");
		_ = 0;
		BlockBackButton = true;
		DetectGestures = true;
		OpenSpeed = 10f;
		RenamePrefix = "Drawer - ";
		RenameSuffix = "";
		UseCustomStartAnchoredPosition = true;
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void ResetComponent(UIDrawer drawer)
	{
		drawer.CloseDirection = CloseDirection;
		drawer.CloseSpeed = CloseSpeed;
		drawer.CustomStartAnchoredPosition = CustomStartAnchoredPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.Settings.UIDrawerSettings)+2C]");
		_ = 0;
		drawer.BlockBackButton = BlockBackButton;
		drawer.HideOnBackButton = HideOnBackButton;
		drawer.DetectGestures = DetectGestures;
		drawer.OpenSpeed = OpenSpeed;
		drawer.UseCustomStartAnchoredPosition = UseCustomStartAnchoredPosition;
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public UIDrawerSettings()
	{
		//IL_0025: Expected I, but got O
		CloseDirection = SimpleSwipe.Left;
		nint num = (nint)typeof(UIDrawerSettings);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v3 (Il2CppClass<Doozy.Engine.UI.Settings.UIDrawerSettings>)+B8]");
		nint num2 = 0;
		CustomStartAnchoredPosition = CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (Il2CppStaticFields<Doozy.Engine.UI.Settings.UIDrawerSettings>)+10]");
		_ = 0;
		BlockBackButton = true;
		CloseSpeed = 10f;
		OpenSpeed = 10f;
		RenamePrefix = "Drawer - ";
		RenameSuffix = "";
		base._002Ector();
	}

	static UIDrawerSettings()
	{
		//IL_0018: Expected I, but got O
		//IL_0036: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		nint num3 = (nint)typeof(UIDrawerSettings);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppClass<Doozy.Engine.UI.Settings.UIDrawerSettings>)+B8]");
		nint num4 = 0;
		CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
	}
}
