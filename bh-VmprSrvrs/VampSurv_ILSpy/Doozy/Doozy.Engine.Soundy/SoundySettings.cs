using System;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Soundy;

[Serializable]
public class SoundySettings : ScriptableObject
{
	public const string FILE_NAME = "SoundySettings";

	private static SoundySettings s_instance;

	private SoundyDatabase database;

	public const bool AUTO_KILL_IDLE_CONTROLLERS_DEFAULT_VALUE = true;

	public const float CONTROLLER_IDLE_KILL_DURATION_DEFAULT_VALUE = 20f;

	public const float CONTROLLER_IDLE_KILL_DURATION_MIN = 0f;

	public const float CONTROLLER_IDLE_KILL_DURATION_MAX = 300f;

	public const float IDLE_CHECK_INTERVAL_DEFAULT_VALUE = 5f;

	public const float IDLE_CHECK_INTERVAL_MIN = 0.1f;

	public const float IDLE_CHECK_INTERVAL_MAX = 60f;

	public const int MINIMUM_NUMBER_OF_CONTROLLERS_DEFAULT_VALUE = 3;

	public const int MINIMUM_NUMBER_OF_CONTROLLERS_MIN = 0;

	public const int MINIMUM_NUMBER_OF_CONTROLLERS_MAX = 20;

	public bool AutoKillIdleControllers = true;

	public float ControllerIdleKillDuration = 20f;

	public float IdleCheckInterval = 5f;

	public int MinimumNumberOfControllers = 3;

	private static string ResourcesPath => DoozyPath.ENGINE_SOUNDY_RESOURCES_PATH;

	public static SoundySettings Instance
	{
		get
		{
			SoundySettings soundySettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)soundySettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				SoundySettings soundySettings2 = default(SoundySettings);
				s_instance = soundySettings2;
			}
			return s_instance;
		}
	}

	public static SoundyDatabase Database
	{
		get
		{
			SoundySettings instance = Instance;
			if ((object)instance != null)
			{
				SoundyDatabase soundyDatabase = instance.database;
				if ((object)instance.database == null || ((UnityEngine.Object)soundyDatabase).m_CachedPtr == (IntPtr)0)
				{
					SoundySettings instance2 = Instance;
					string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.Soundy);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
					if ((object)instance2 == null)
					{
						goto IL_00cc;
					}
					SoundyDatabase soundyDatabase2 = default(SoundyDatabase);
					instance2.database = soundyDatabase2;
				}
				SoundySettings instance3 = Instance;
				if ((object)instance3 != null)
				{
					return instance3.database;
				}
			}
			goto IL_00cc;
			IL_00cc:
			return (SoundyDatabase)(object)new NullReferenceException();
		}
	}

	public static void UpdateDatabase()
	{
		SoundySettings instance = Instance;
		string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.Soundy);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
		SoundyDatabase soundyDatabase = default(SoundyDatabase);
		instance.database = soundyDatabase;
	}

	private void Reset()
	{
		AutoKillIdleControllers = true;
		ControllerIdleKillDuration = 20f;
		IdleCheckInterval = 5f;
		MinimumNumberOfControllers = 3;
	}

	public void Reset(bool saveAssets)
	{
		AutoKillIdleControllers = true;
		ControllerIdleKillDuration = 20f;
		IdleCheckInterval = 5f;
		MinimumNumberOfControllers = 3;
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void ResetComponent(SoundyPooler pooler)
	{
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
