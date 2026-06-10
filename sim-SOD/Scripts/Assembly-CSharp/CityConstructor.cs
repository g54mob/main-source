using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class CityConstructor : MonoBehaviour
{
	public enum LoadState
	{
		parsingFile = 0,
		setupCityBoundary = 1,
		generateDistricts = 2,
		generateBlocks = 3,
		generateDensity = 4,
		generateBuildings = 5,
		generatePathfinding = 6,
		generateBlueprints = 7,
		generateCompanies = 8,
		connectRooms = 9,
		generateCitizens = 10,
		generateRelationships = 11,
		gatherData = 12,
		generateAirDucts = 13,
		generateEvidence = 14,
		generateInteriors = 15,
		prepareCitizens = 16,
		loadObjects = 17,
		finalizing = 18,
		savingData = 19,
		loadState = 20,
		preSim = 21,
		loadComplete = 22
	}

	[Serializable]
	public class CollectedLoadTimeInfo
	{
		public string build;

		public string citySize;

		public bool generateNew;

		public Dictionary<LoadState, int> loadTimes;

		public Dictionary<NewRoom, List<DecorClusterGenerationTimeInfo>> decorTimes;
	}

	[Serializable]
	public class DecorClusterGenerationTimeInfo
	{
		public FurnitureCluster cluster;

		public bool found;

		public float time;
	}

	[Serializable]
	public class DecorTotalTime
	{
		public NewRoom room;

		public float totalTime;
	}

	public delegate void OnStartGame();

	public delegate void LoadFinalize();

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CLoadSaveGame_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public CityConstructor _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass62_0
	{
		public string cityInfoPath;

		public string writeString;

		public string cityDataPath;

		internal void _003CSaveCityData_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSaveCityData_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CityConstructor _003C_003E4__this;

		private _003C_003Ec__DisplayClass62_0 _003C_003E8__1;

		private int _003Ccursor_003E5__2;

		private List<CityTile> _003CcityTiles_003E5__3;

		private Stopwatch _003CstopWatch_003E5__4;

		private Task _003CwriteCityInfoTask_003E5__5;

		private string _003CcompressedCityPath_003E5__6;

		private Task<bool> _003CtempCompressionTask_003E5__7;

		private Task _003CtempTask_003E5__8;

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
		public _003CSaveCityData_003Ed__62(int _003C_003E1__state)
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
	private sealed class _003C_003Ec__DisplayClass66_0
	{
		public string jsonString;

		internal void _003CLoadFullCityDataAsync_003Eb__1()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CLoadFullCityDataAsync_003Ed__66 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CityConstructor _003C_003E4__this;

		private _003C_003Ec__DisplayClass66_0 _003C_003E8__1;

		private Stopwatch _003CstopWatch_003E5__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass67_0
	{
		public string jsonString;

		internal void _003CLoadSaveStateFile_003Eb__1()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CLoadSaveStateFile_003Ed__67 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public CityConstructor _003C_003E4__this;

		private _003C_003Ec__DisplayClass67_0 _003C_003E8__1;

		private Stopwatch _003CstopWatch_003E5__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[NonSerialized]
	public CitySaveData currentData;

	[NonSerialized]
	public StateSaveData saveState;

	public bool generateNew;

	public bool isLoaded;

	public bool useCityConstructionHold;

	public int saveChunk;

	public List<Evidence> evidenceToCompile;

	public LoadState loadState;

	public LoadState cityConstructorHoldState;

	private List<LoadState> allLoadStates;

	public int loadCursor;

	public float loadingProgress;

	public bool stateComplete;

	public bool loadingOperationActive;

	public bool preSimActive;

	public bool preSimOccured;

	public Dictionary<int, NewWall> loadingWallsReference;

	public Dictionary<int, FurnitureLocation> loadingFurnitureReference;

	public List<Interactable> updateSwitchState;

	private float timeStamp;

	[NonSerialized]
	public CollectedLoadTimeInfo debugLoadTime;

	private static CityConstructor _instance;

	private Task loadFullCityDataTask;

	public static CityConstructor Instance => null;

	public event OnStartGame OnGameStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event LoadFinalize OnLoadFinalize
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void DestroySelf()
	{
	}

	public void GenerateNewCity()
	{
	}

	[AsyncStateMachine(typeof(_003CLoadSaveGame_003Ed__40))]
	public void LoadSaveGame()
	{
	}

	public void IncompatibleVersionConfirm()
	{
	}

	public void IncompatibleVersionCancel()
	{
	}

	private void GenerateCityFromShareCode()
	{
	}

	public void LoadCityStartNewGame()
	{
	}

	public void StartLoading()
	{
	}

	private void Update()
	{
	}

	public void StopCityConstructionAtEndOfLoadState(LoadState stopHereState)
	{
	}

	public void ClearCityConstructionHoldStatus()
	{
	}

	private void WriteSavingTimings(ref CollectedLoadTimeInfo info)
	{
	}

	private void WriteRoomDecorTimings(ref CollectedLoadTimeInfo info)
	{
	}

	private void WriteGeneratedObjectDetails()
	{
	}

	private void SetLoadingText()
	{
	}

	private void GatherData()
	{
	}

	private void Finalized()
	{
	}

	private void FinalizePostSave()
	{
	}

	public void SetPreSim(bool val)
	{
	}

	public void StartGame()
	{
	}

	public void TriggerStartEvent()
	{
	}

	private void EnableTutorial()
	{
	}

	private void DisableTutorial()
	{
	}

	[IteratorStateMachine(typeof(_003CSaveCityData_003Ed__62))]
	private IEnumerator SaveCityData()
	{
		return null;
	}

	public bool IsUsingCityEditor()
	{
		return false;
	}

	public void Cancel()
	{
	}

	public void CreateSelfEmployed(CompanyPreset company, Human employee, Interactable workLocation)
	{
	}

	[AsyncStateMachine(typeof(_003CLoadFullCityDataAsync_003Ed__66))]
	public Task LoadFullCityDataAsync()
	{
		return null;
	}

	[AsyncStateMachine(typeof(_003CLoadSaveStateFile_003Ed__67))]
	public Task LoadSaveStateFile()
	{
		return null;
	}
}
