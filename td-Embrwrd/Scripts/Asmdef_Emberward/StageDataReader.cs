using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StageDataReader : Singleton<StageDataReader>
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public int executingCoroutine;

		public Action _003C_003E9__0;

		internal void _003CCR_WaveProc_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_MonsterWaveProc_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterSpawnData data;

		public int treasureCount;

		public StageDataReader _003C_003E4__this;

		public Action onCompleteCallback;

		private MonsterSettingData _003CmonsterData_003E5__2;

		private int _003CwaveCount_003E5__3;

		private float _003Cinterval_003E5__4;

		private int[] _003CtreasureMonsterIndex_003E5__5;

		private int _003Ci_003E5__6;

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
		public _003CCR_MonsterWaveProc_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003CCR_WaveProc_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StageDataReader _003C_003E4__this;

		public WaveData waveData;

		private _003C_003Ec__DisplayClass41_0 _003C_003E8__1;

		public Action waveFinishCallback;

		private float _003Ctime_003E5__2;

		private int[] _003CtreasureSpawnCount_003E5__3;

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
		public _003CCR_WaveProc_003Ed__41(int _003C_003E1__state)
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

	[SerializeField]
	private StageSettingData stageData;

	[SerializeField]
	private StageSettingData testData;

	private int currentWaveIndex;

	[SerializeField]
	private float difficultyAdjustmentByPerformance;

	[SerializeField]
	private float baseDifficultyByGameMode;

	[SerializeField]
	private float minDistanceLastWave;

	[Header("在哪些回合會出現寶箱")]
	[SerializeField]
	private List<int> list_RoundIndexForTreasure;

	public MonsterSpawnOverrideData monsterSpawnOverrideData;

	private WaveData nextWaveData;

	private bool isClonedStageData;

	private bool forceTerminateBattle;

	private float noMonsterOnFieldTimer;

	public StageSettingData CurrentUsingData => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnRequestOverrideSpawnMonster(MonsterSpawnOverrideData data)
	{
	}

	private void OnMonsterDespawn(AMonsterBase monster)
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnBattleEnd()
	{
	}

	private void OnRequestTerminateBattle()
	{
	}

	private void OnRequestOverrideWaveData(WaveData data, int waveIndex)
	{
	}

	public void LoadStageData(StageSettingData stageData)
	{
	}

	private int GetTreasureCountInThisRound(int roundIndex)
	{
		return 0;
	}

	private void ResetStage()
	{
	}

	public bool HasNextWave()
	{
		return false;
	}

	public void AddExtraWaveAtEnd(WaveData waveData)
	{
	}

	public void AddExtraWaveAtEnd_AutoGenerate()
	{
	}

	public void AddExtraWaveAtEnd_FromEndlessWaveSetting()
	{
	}

	public void OverrideWaveDifficultyIncrease(List<float> list_Difficulty)
	{
	}

	public void BeforeNextWaveStartProcess()
	{
	}

	public WaveInfoData GetNextWaveMonsterInfo()
	{
		return null;
	}

	public int GetNextWaveMonsterCount()
	{
		return 0;
	}

	public List<int> GetNextWaveSpawnIndexes()
	{
		return null;
	}

	public int GetTotalWaveCount()
	{
		return 0;
	}

	public float GetNextWaveDifficulty()
	{
		return 0f;
	}

	public float GetCurrentDifficulty()
	{
		return 0f;
	}

	private float GetWaveDifficulty(int waveIndex)
	{
		return 0f;
	}

	private bool CheckStageDataExist()
	{
		return false;
	}

	public void StartNextWave(Action waveFinishCallback = null)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_WaveProc_003Ed__41))]
	private IEnumerator CR_WaveProc(WaveData waveData, Action waveFinishCallback)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_MonsterWaveProc_003Ed__42))]
	private IEnumerator CR_MonsterWaveProc(MonsterSpawnData data, int treasureCount, Action onCompleteCallback = null)
	{
		return null;
	}
}
