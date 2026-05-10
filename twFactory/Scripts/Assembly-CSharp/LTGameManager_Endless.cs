using System;
using System.Collections.Generic;
using UnityEngine;

public class LTGameManager_Endless : LTGameManager
{
	private int firstRepetitionCycle;

	private float baseEnemyLifeMultiplier;

	private float enemyLifeMultiplier = 1f;

	private List<(int cycle, float bossTotalLife)> bossLivesPerCycle = new List<(int, float)>();

	public int FirstRepetitionCycle
	{
		get
		{
			return firstRepetitionCycle;
		}
		set
		{
			firstRepetitionCycle = value;
		}
	}

	public float EnemyLifeMultiplier => enemyLifeMultiplier;

	public float BaseEnemyLifeMultiplier
	{
		set
		{
			baseEnemyLifeMultiplier = value;
		}
	}

	public List<(int cycle, float bossTotalLife)> BossLivesPerCycle => bossLivesPerCycle;

	protected override void Start()
	{
		base.Start();
		CyclesManager obj = base.CyclesManager;
		obj.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(obj.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
	}

	private void OnCycleChanged(int cycle, ECycleMode mode)
	{
		if (mode == ECycleMode.Neutral && cycle >= FirstRepetitionCycle)
		{
			int num = (cycle - FirstRepetitionCycle) / 5 + 1;
			enemyLifeMultiplier = Mathf.Pow(baseEnemyLifeMultiplier, num);
		}
	}

	public float GetBossTotalLife(int cycle)
	{
		float result = 0f;
		for (int i = 0; i < bossLivesPerCycle.Count && cycle >= bossLivesPerCycle[i].cycle; i++)
		{
			result = bossLivesPerCycle[i].bossTotalLife;
		}
		return result;
	}

	public override int CalculateMoneyReward(bool hasWon, bool includeChests)
	{
		int num = 1;
		if (MatchInfo.instance.CurrentLevelData != null)
		{
			num = MatchInfo.instance.CurrentLevelData.MoneyPerWave;
		}
		return 0 + Mathf.CeilToInt((float)(base.CyclesManager.CurrentCycle * num) * MatchInfo.instance.CurrentMatchSettings.GoldenCoinMultiplierCycles);
	}
}
