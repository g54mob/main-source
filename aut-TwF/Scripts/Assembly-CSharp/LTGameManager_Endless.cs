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

	public float GetEnemyLifeMultiplierByCycle(int cycle)
	{
		if (cycle < FirstRepetitionCycle)
		{
			return 1f;
		}
		int num = (cycle - FirstRepetitionCycle) / 5 + 1;
		return Mathf.Pow(baseEnemyLifeMultiplier, num);
	}

	public float GetBossTotalLife(int cycle)
	{
		float num = 0f;
		for (int i = 0; i < bossLivesPerCycle.Count && cycle >= bossLivesPerCycle[i].cycle; i++)
		{
			num = bossLivesPerCycle[i].bossTotalLife;
		}
		if (num == 0f && bossLivesPerCycle != null && bossLivesPerCycle.Count > 0)
		{
			num = bossLivesPerCycle[0].bossTotalLife;
		}
		return num;
	}

	public override int CalculateMoneyReward(bool hasWon, bool includeChests)
	{
		int num = 1;
		int currentCycle = base.CyclesManager.CurrentCycle;
		float b = MatchSettings.GetEnemyLifeMultiplier(LTFunctionLibrary.GetMatchInfo().CurrentMatchSettings.MatchDifficulty);
		return Mathf.CeilToInt((float)(currentCycle * num) * (float)Math.Pow(2.0, base.KilledBossesAmount) * Mathf.Max(1f, b));
	}
}
