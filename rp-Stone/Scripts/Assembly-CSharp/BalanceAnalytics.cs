using System;
using System.Collections.Generic;
using UnityEngine;

public class BalanceAnalytics : MonoBehaviour
{
	private const int SUBMIT_AT_SAMPLE_COUNT = 40;

	private const int POWER_NORMALIZATION_DIVISOR = 42;

	private GameStates.State lastGameState;

	private string questTrackedId;

	private int questTrackedLevel;

	private int lastGameTime = -1;

	private int timeTotal;

	private int timeSampleCount;

	private DateTime questTrackedDate;

	private ulong powerTotal;

	private ulong powerSampleCount;

	private uint work_powerTotal;

	private uint work_powerSampleCount;

	private Dictionary<string, int> submissionsDict = new Dictionary<string, int>();

	public static BalanceAnalytics singleton { get; private set; }

	private void MarkSubmitted(string questId, int questLevel, int day)
	{
		string key = questId + questLevel;
		if (submissionsDict.ContainsKey(key))
		{
			submissionsDict[key] = day;
		}
		else
		{
			submissionsDict.Add(key, day);
		}
	}

	private bool HasSubmitted(string questId, int questLevel, int day)
	{
		string key = questId + questLevel;
		if (submissionsDict.ContainsKey(key))
		{
			return submissionsDict[key] == day;
		}
		return false;
	}

	private void Clear()
	{
		timeTotal = 0;
		timeSampleCount = 0;
		ClearPower();
	}

	private void AddLap(int time)
	{
		timeTotal += time;
		timeSampleCount++;
		if (powerTotal + work_powerTotal > powerTotal)
		{
			powerTotal += work_powerTotal;
			powerSampleCount += work_powerSampleCount;
		}
		work_powerTotal = 0u;
		work_powerSampleCount = 0u;
	}

	private void ClearPower()
	{
		powerTotal = 0uL;
		powerSampleCount = 0uL;
		work_powerTotal = 0u;
		work_powerSampleCount = 0u;
	}

	private void AddPower(uint power)
	{
		if (work_powerTotal + power > work_powerTotal)
		{
			work_powerTotal += power;
			work_powerSampleCount++;
		}
	}

	private void TrySubmit()
	{
		if (questTrackedId == null || HasSubmitted(questTrackedId, questTrackedLevel, questTrackedDate.Day))
		{
			return;
		}
		MarkSubmitted(questTrackedId, questTrackedLevel, questTrackedDate.Day);
		int num = timeTotal / timeSampleCount;
		int num2 = 0;
		if (powerSampleCount != 0)
		{
			num2 = (int)(powerTotal / powerSampleCount);
			if (num2 > 0)
			{
				int num3 = num * num2 / 42;
				if (num3 > 0)
				{
					AnalyticsMacros.QuestCompleted(questTrackedId, questTrackedLevel, num, num2, num3);
				}
			}
		}
		ClearPower();
	}

	public void QuestCompleted(string questId, int questLevel, int time)
	{
		questTrackedId = questId;
		questTrackedLevel = questLevel;
		if (timeSampleCount < 40)
		{
			AddLap(time);
			if (timeSampleCount == 40)
			{
				TrySubmit();
			}
		}
		if (questTrackedDate.Day != DateTime.UtcNow.Day)
		{
			if (timeSampleCount > 0 && timeSampleCount < 40)
			{
				TrySubmit();
			}
			Clear();
			questTrackedDate = DateTime.UtcNow;
		}
	}

	private void Update()
	{
		if (HasSubmitted(questTrackedId, questTrackedLevel, questTrackedDate.Day))
		{
			return;
		}
		GameStates gameStates = GameStates.Singleton;
		if (lastGameState != gameStates.CurrentState)
		{
			if (lastGameState >= GameStates.State.Playing && gameStates.CurrentState >= GameStates.State.QuestScreen && gameStates.CurrentState < GameStates.State.Playing)
			{
				if (timeSampleCount > 0 && timeSampleCount < 40)
				{
					TrySubmit();
				}
				Clear();
			}
			lastGameState = gameStates.CurrentState;
		}
		if (gameStates.CurrentState == GameStates.State.Playing && lastGameTime != gameStates.GetTotalTime())
		{
			lastGameTime = gameStates.GetTotalTime();
			HeroAI component = gameStates.hero.GetComponent<HeroAI>();
			if (component.targetEnemy != null && component.targetEnemy.PositionX - gameStates.hero.PositionX <= 23)
			{
				uint power = ComputeGearPower(gameStates.hero.LeftHand) + ComputeGearPower(gameStates.hero.RightHand);
				AddPower(power);
			}
		}
	}

	private uint ComputeGearPower(Weapon weapon)
	{
		if (weapon != null && weapon.canCraftOnAnvil)
		{
			int num = ItemFactory.GetLevelDisplayIntegerForItem(weapon) + weapon.GetRarityBonus();
			if (num <= 0)
			{
				return 0u;
			}
			if (weapon.handType == Weapon.HandType.DoubleHanded)
			{
				num *= 2;
			}
			return (uint)num;
		}
		return 0u;
	}

	private void Awake()
	{
		singleton = this;
		questTrackedDate = DateTime.UtcNow;
	}
}
