using System;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Touchy;

[Serializable]
public class TouchySettings : ScriptableObject
{
	public const string FILE_NAME = "TouchySettings";

	private static TouchySettings s_instance;

	public const float LONG_TAP_DURATION_DEFAULT_VALUE = 0.4f;

	public const float LONG_TAP_DURATION_MAX = 1f;

	public const float LONG_TAP_DURATION_MIN = 0.2f;

	public const float SWIPE_LENGTH_DEFAULT_VALUE = 2f;

	public const float SWIPE_LENGTH_MAX = 200f;

	public const float SWIPE_LENGTH_MIN = 0.1f;

	public float LongTapDuration = 0.4f;

	public float SwipeLength = 2f;

	private static string ResourcesPath => DoozyPath.ENGINE_TOUCHY_RESOURCES_PATH;

	public static TouchySettings Instance
	{
		get
		{
			TouchySettings touchySettings = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)touchySettings).m_CachedPtr == (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
				TouchySettings touchySettings2 = default(TouchySettings);
				s_instance = touchySettings2;
			}
			return s_instance;
		}
	}

	private void Reset()
	{
		SwipeLength = 2f;
		LongTapDuration = 0.4f;
	}

	public void Reset(bool saveAssets)
	{
		SwipeLength = 2f;
		LongTapDuration = 0.4f;
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
