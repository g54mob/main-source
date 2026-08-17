using System;
using Cpp2ILInjected;
using Doozy.Engine.UI.Base;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Settings;

[Serializable]
public class UICanvasSettings : ScriptableObject
{
	public const string FILE_NAME = "UICanvasSettings";

	private static UICanvasSettings s_instance;

	private NamesDatabase database;

	public const bool DONT_DESTROY_CANVAS_ON_LOAD_DEFAULT_VALUE = true;

	public const string RENAME_PREFIX_DEFAULT_VALUE = "Canvas - ";

	public const string RENAME_SUFFIX_DEFAULT_VALUE = "";

	public bool DontDestroyCanvasOnLoad;

	public string RenamePrefix;

	public string RenameSuffix;

	private static string ResourcesPath => DoozyPath.UICANVAS_RESOURCES_PATH;

	public static UICanvasSettings Instance
	{
		get
		{
			UICanvasSettings uICanvasSettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)uICanvasSettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				UICanvasSettings uICanvasSettings2 = default(UICanvasSettings);
				s_instance = uICanvasSettings2;
			}
			return s_instance;
		}
	}

	public static NamesDatabase Database
	{
		get
		{
			UICanvasSettings instance = Instance;
			if ((object)instance != null)
			{
				NamesDatabase namesDatabase = instance.database;
				if ((object)instance.database == null || ((UnityEngine.Object)namesDatabase).m_CachedPtr == (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807CE]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					UICanvasSettings instance2 = Instance;
					string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UICanvas);
					NamesDatabase namesDatabase2 = NamesDatabase.GetDatabase("UICanvasDatabase", dataPath);
					if ((object)instance2 == null)
					{
						goto IL_0102;
					}
					instance2.database = namesDatabase2;
				}
				UICanvasSettings instance3 = Instance;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807CE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UICanvasSettings instance = Instance;
		string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.UICanvas);
		NamesDatabase namesDatabase = NamesDatabase.GetDatabase("UICanvasDatabase", dataPath);
		instance.database = namesDatabase;
	}

	private void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807CF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DontDestroyCanvasOnLoad = true;
		RenamePrefix = "Canvas - ";
		RenameSuffix = "";
	}

	public void Reset(bool saveAssets)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807CF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DontDestroyCanvasOnLoad = true;
		RenamePrefix = "Canvas - ";
		RenameSuffix = "";
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void ResetComponent(UICanvas canvas)
	{
		canvas.DontDestroyCanvasOnLoad = DontDestroyCanvasOnLoad;
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public UICanvasSettings()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807D2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DontDestroyCanvasOnLoad = true;
		RenamePrefix = "Canvas - ";
		RenameSuffix = "";
		base._002Ector();
	}
}
