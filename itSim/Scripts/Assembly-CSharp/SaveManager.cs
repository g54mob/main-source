using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	[Serializable]
	public class StringListWrapper
	{
		public List<string> list;
	}

	[Serializable]
	public class StringArrayWrapper
	{
		public string[] array;
	}

	[Serializable]
	public class Variable
	{
		public string key;

		public string tag;

		public string subtag;

		public string subsubtag;

		public string value;

		public string type;
	}

	[Serializable]
	public class SaveData
	{
		public List<Variable> variable;
	}

	[CompilerGenerated]
	private sealed class _003CCaptureScreenshotRoutine_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SaveManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCaptureScreenshotRoutine_003Ed__18(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRenameScreenshotWait_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SaveManager _003C_003E4__this;

		public string pathDir;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CRenameScreenshotWait_003Ed__20(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CWaitAndLoad_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SaveManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CWaitAndLoad_003Ed__24(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public static SaveManager Instance;

	public TMP_Text pathDebug;

	public bool saveLoadDone;

	public level level;

	public levelDifficulty levelDifficulty;

	public int avatarID;

	public string headerFilePath;

	public string dataFilePath;

	public string ScreenshotDirPath;

	public string MainDirPath;

	public bool validateFiles;

	private SaveData data;

	private float interval;

	public bool thisVersionIsDemo;

	private void Awake()
	{
	}

	public static string GetApplicationPath()
	{
		return null;
	}

	public static string GetLvl()
	{
		return null;
	}

	public void ClearSave()
	{
	}

	[IteratorStateMachine(typeof(_003CCaptureScreenshotRoutine_003Ed__18))]
	private IEnumerator CaptureScreenshotRoutine()
	{
		return null;
	}

	public void CaptureScreenshot(string pathDir)
	{
	}

	[IteratorStateMachine(typeof(_003CRenameScreenshotWait_003Ed__20))]
	private IEnumerator RenameScreenshotWait(string pathDir)
	{
		return null;
	}

	public void RenameScreenshot(string pathDir)
	{
	}

	public static Sprite LoadScreenshotAsSpriteForPath(string ssPath)
	{
		return null;
	}

	public static bool ValidateSaveDir(string dir)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CWaitAndLoad_003Ed__24))]
	private IEnumerator WaitAndLoad()
	{
		return null;
	}

	private void InvokeStartAfterLoadSave()
	{
	}

	private void LoadHeaderData()
	{
	}

	public void Load()
	{
	}

	public void Save()
	{
	}

	public void SaveVersionGame()
	{
	}

	public void LoadAllFromFile()
	{
	}

	public void SaveAllToFile()
	{
	}

	public int GetInt(string key, int defaultValue = 0, bool autosave = true)
	{
		return 0;
	}

	public float GetFloat(string key, float defaultValue = 0f)
	{
		return 0f;
	}

	public string GetString(string key, string defaultValue = "")
	{
		return null;
	}

	public long GetLong(string key, long defaultValue = 0L)
	{
		return 0L;
	}

	public bool GetBool(string key, bool defaultValue = false)
	{
		return false;
	}

	public List<string> GetListString(string key, List<string> defaultValue = null)
	{
		return null;
	}

	public string[] GetArrayString(string key, string[] defaultValue = null)
	{
		return null;
	}

	public void SetListString(string key, List<string> values, string _tag = "", string _subtag = "", string _subsubtag = "")
	{
	}

	public void SetArrayString(string key, string[] values, string _tag = "", string _subtag = "", string _subsubtag = "")
	{
	}

	public void DeleteKey(string key)
	{
	}

	public void SetInt(string key, int value, string tag = "", string subtag = "", string subsubtag = "")
	{
	}

	public void SetFloat(string key, float value, string tag = "", string subtag = "", string subsubtag = "")
	{
	}

	public void SetString(string key, string value, string tag = "", string subtag = "", string subsubtag = "")
	{
	}

	public void SetLong(string key, long value, string tag = "", string subtag = "", string subsubtag = "")
	{
	}

	public void SetBool(string key, bool value, string tag = "", string subtag = "", string subsubtag = "")
	{
	}

	private void SetValue(string key, string value, string type, string tag = "", string subtag = "", string subsubtag = "")
	{
	}
}
