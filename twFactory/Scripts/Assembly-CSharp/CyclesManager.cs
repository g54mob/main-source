using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclesManager : MonoBehaviour, ISavable
{
	[Serializable]
	private struct FRoundTime
	{
		[SerializeField]
		private EGameDifficulty difficulty;

		[SerializeField]
		private long roundTime;

		public EGameDifficulty Difficulty => difficulty;

		public long RoundTime => roundTime;
	}

	public Action<int, ECycleMode> onCycleChanged;

	[SerializeField]
	[Tooltip("Cuanto duran las rondas antes de las oleadas")]
	private long roundTime;

	private long internalRoundTime;

	[Savable("currentCycleStartTimeMilli", true, false)]
	private long currentCycleStartTimeMilli;

	[SerializeField]
	[Savable("currentCycle", true, false)]
	[Tooltip("Dejar en 0 para funcionamiento normal. Modificar SOLO para testear oleadas.")]
	private int currentCycle;

	[Savable("currentCycleMode", true, false)]
	private ECycleMode currentCycleMode;

	private List<WaveSpawner> waveSpawners;

	[Header("Debug")]
	[SerializeField]
	private bool startInWave;

	private bool hasLoadedCycleStartTime;

	private Coroutine cyclesCoroutine;

	public int CurrentCycle => currentCycle;

	public ECycleMode CurrentCycleMode => currentCycleMode;

	public long CurrentCycleStartTimeMilli => currentCycleStartTimeMilli;

	public long RoundTime
	{
		get
		{
			if (internalRoundTime <= 0)
			{
				RoundTime = roundTime;
			}
			return internalRoundTime;
		}
		set
		{
			internalRoundTime = value;
		}
	}

	private void Awake()
	{
		waveSpawners = new List<WaveSpawner>();
		if (startInWave)
		{
			currentCycleMode = ECycleMode.Wave;
		}
	}

	public void RegisterWaveSpawner(WaveSpawner spawner)
	{
		waveSpawners.Add(spawner);
		spawner.onAllSpanwdObjectsDead += OnWaveSpawnerCompleted;
	}

	private void Start()
	{
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onGameStarted = (Action)Delegate.Combine(lTGameManager.onGameStarted, new Action(OnGameStarted));
		if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
		{
			OnGameStarted();
		}
	}

	private void ChangeCycle(int cycle, ECycleMode mode)
	{
		if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Playing)
		{
			LTFunctionLibrary.GetTimeManager().SetGameSpeed(TimeManager.ETimeSpeed.Play);
			currentCycle = cycle;
			currentCycleMode = mode;
			if (!hasLoadedCycleStartTime)
			{
				currentCycleStartTimeMilli = LTFunctionLibrary.GetTimeManager().GetTimeMilliseconds();
			}
			else
			{
				hasLoadedCycleStartTime = false;
			}
			onCycleChanged?.Invoke(currentCycle, currentCycleMode);
		}
	}

	private IEnumerator CyclesCoroutine()
	{
		WaitForSeconds wfs = new WaitForSeconds(1f);
		while (true)
		{
			if (currentCycleMode == ECycleMode.Neutral)
			{
				yield return new WaitForSeconds((float)LTFunctionLibrary.GetDayRemainingMilliseconds() / 1000f);
				ChangeCycle(currentCycle, ECycleMode.Wave);
				continue;
			}
			yield return wfs;
			while (waveSpawners.Count != 0)
			{
				yield return wfs;
			}
			ChangeCycle(currentCycle + 1, ECycleMode.Neutral);
		}
	}

	private void OnWaveSpawnerCompleted(WaveSpawner spawner)
	{
		spawner.onAllSpanwdObjectsDead -= OnWaveSpawnerCompleted;
		waveSpawners.Remove(spawner);
	}

	private void OnGameStarted()
	{
		ChangeCycle(currentCycle, currentCycleMode);
		this.StartCoroutineCheckingVar(CyclesCoroutine(), ref cyclesCoroutine);
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		hasLoadedCycleStartTime = hasLoadedSomething;
	}
}
