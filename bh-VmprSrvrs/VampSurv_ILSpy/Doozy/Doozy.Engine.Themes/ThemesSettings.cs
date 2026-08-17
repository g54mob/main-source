using System;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Themes;

[Serializable]
public class ThemesSettings : ScriptableObject
{
	public const string FILE_NAME = "ThemesSettings";

	private static ThemesSettings s_instance;

	private ThemesDatabase database;

	public const bool DEFAULT_AUTO_SAVE = true;

	public bool AutoSave = true;

	private static string ResourcesPath => DoozyPath.ENGINE_THEMES_RESOURCES_PATH;

	public static ThemesSettings Instance
	{
		get
		{
			ThemesSettings themesSettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)themesSettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				ThemesSettings themesSettings2 = default(ThemesSettings);
				s_instance = themesSettings2;
			}
			return s_instance;
		}
	}

	public static ThemesDatabase Database
	{
		get
		{
			ThemesSettings instance = Instance;
			if ((object)instance != null)
			{
				ThemesDatabase themesDatabase = instance.database;
				if ((object)instance.database == null || ((UnityEngine.Object)themesDatabase).m_CachedPtr == (IntPtr)0)
				{
					ThemesSettings instance2 = Instance;
					string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.Themes);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
					if ((object)instance2 == null)
					{
						goto IL_00cc;
					}
					ThemesDatabase themesDatabase2 = default(ThemesDatabase);
					instance2.database = themesDatabase2;
				}
				ThemesSettings instance3 = Instance;
				if ((object)instance3 != null)
				{
					return instance3.database;
				}
			}
			goto IL_00cc;
			IL_00cc:
			return (ThemesDatabase)(object)new NullReferenceException();
		}
	}

	public static void UpdateDatabase()
	{
		ThemesSettings instance = Instance;
		string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.Themes);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
		ThemesDatabase themesDatabase = default(ThemesDatabase);
		instance.database = themesDatabase;
	}

	private void Reset()
	{
		AutoSave = true;
	}

	public void Reset(bool saveAssets)
	{
		AutoSave = true;
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}
}
