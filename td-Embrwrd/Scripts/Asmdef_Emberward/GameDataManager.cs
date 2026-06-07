using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_InitializeProc_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameDataManager _003C_003E4__this;

		private float _003CwaitTimer_003E5__2;

		private bool _003CisShownError_003E5__3;

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
		public _003CCR_InitializeProc_003Ed__40(int _003C_003E1__state)
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
	private sealed class _003CCR_LoadDataProc_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameDataManager _003C_003E4__this;

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
		public _003CCR_LoadDataProc_003Ed__56(int _003C_003E1__state)
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

	public static GameDataManager instance;

	[SerializeField]
	private PlayerLifetimeData playerdata;

	[SerializeField]
	private GameplayData gameplayData;

	[SerializeField]
	private IntermediateData intermediateData;

	[SerializeField]
	private GameplayData gameplayData_tempSession;

	[SerializeField]
	private IntermediateData intermediateData_tempSession;

	private bool haveSaveData;

	private bool isInitialized;

	private bool isFileLoaded;

	private string playerID;

	private ES3Settings saveSettings_Cache;

	private ES3Settings saveSettings_Data;

	private float saveMinimumTimeLimit;

	private float timeSinceLastSave;

	private bool isShownSaveError;

	[NonSerialized]
	private bool isUsingDemoSaveFile;

	[NonSerialized]
	private bool isBackupCreated;

	[NonSerialized]
	private bool doUseTempSessionData;

	[NonSerialized]
	private static bool doSaveAtEndOfFrame;

	public PlayerLifetimeData Playerdata => null;

	public bool HaveSaveData => false;

	public bool IsFileLoaded => false;

	public bool IsUsingDemoSaveFile => false;

	public GameplayData GameplayData => null;

	public IntermediateData IntermediateData => null;

	public static TalentData TalentData => null;

	public static PlayerRecord PlayerRecord => null;

	public static StageRecord StageRecord => null;

	public void SwitchSession(bool useTempSession)
	{
	}

	private void Awake()
	{
	}

	public void Initialize()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_InitializeProc_003Ed__40))]
	private IEnumerator CR_InitializeProc()
	{
		return null;
	}

	private void CreateSaveSettings()
	{
	}

	private void OnDestroy()
	{
	}

	public void StartNewGame(int seed, eWorldType worldType, eGameDifficultyType difficulty)
	{
	}

	public void SetIntermediateData(IntermediateData data)
	{
	}

	private void SaveData()
	{
	}

	public void SaveData(bool forceImmediate = false)
	{
	}

	public string GetCurrentGameVersion()
	{
		return null;
	}

	public int GetCurrentGameMajorVersion()
	{
		return 0;
	}

	public int GetCurrentGameMinorVersion()
	{
		return 0;
	}

	public int GetCurrentGamePatchVersion()
	{
		return 0;
	}

	private void Save()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnApplicationQuit()
	{
	}

	public void LoadData()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LoadDataProc_003Ed__56))]
	private IEnumerator CR_LoadDataProc()
	{
		return null;
	}

	private bool LoadDataFromSaveFile(string filepath, bool doCreateFileIfNotExist)
	{
		return false;
	}

	private bool CheckIsSaveFileValid(string oldVersion)
	{
		return false;
	}

	public void ProcessVersionDifference(string oldVersion)
	{
	}

	public void DeleteSaveData()
	{
	}

	public void ForceResetData()
	{
	}

	public string GetSaveFileName()
	{
		return null;
	}

	public string GetDemoSaveFileName()
	{
		return null;
	}

	public bool IsDemoSaveFileExist()
	{
		return false;
	}

	public void ClearUsingDemoSaveFileFlag()
	{
	}

	public void ResetTutorialState()
	{
	}

	public void ResetBossLevelTutorialState()
	{
	}

	public void TakeScreenshotAndSaveImage(string name)
	{
	}

	public Texture LoadImage(string name)
	{
		return null;
	}
}
