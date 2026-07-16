using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class DifficultyManager : MonoBehaviour, ISaveable
{
	public static DifficultyManager Instance;

	[SerializeField]
	private SerializedDictionary<float, int> rewards;

	[SerializeField]
	private SerializedDictionary<float, ScalingCondition> conditionUnlocks;

	[Header("Difficulty Modifiers")]
	public float enemyHealthMultiplier;

	public float enemyDamageMultiplier;

	public float waveSpawnModifier;

	public float stormSpawnModifier;

	public float stormDamageMultiplier;

	public float armoredEnemyChance;

	public float additionalEnemies;

	public float graceDamageMultiplier;

	public float scrapGain;

	public float brokenModuleHullDamage;

	public float coalDrainPercent;

	public int lessChoices;

	public bool mixedWaves;

	public float additionalBossCores;

	private float lastLocationDifficultyChangeEasy;

	private float lastLocationDifficultyChangeMedium;

	private float lastLocationDifficultyChangeHard;

	private float startingLocationProbEasy;

	private float startingLocationProbMedium;

	private float startingLocationProbHard;

	[Header("Additional Enemies Whitelist")]
	[SerializeField]
	private SerializedDictionary<GameObject, float> DesertEnemyWhitelist;

	[SerializeField]
	private SerializedDictionary<GameObject, float> CityEnemyWhitelist;

	[SerializeField]
	private SerializedDictionary<GameObject, float> ViaductsEnemyWhitelist;

	[SerializeField]
	private SerializedDictionary<GameObject, float> SnowEnemyWhitelist;

	[NonSerialized]
	public List<SerializedDictionary<GameObject, float>> EnemyWhitelists;

	[Header("Coop Settings")]
	[SerializeField]
	private int coopDifficultyIncrement;

	[SerializeField]
	private float coopRepairSpeedMultiplier;

	[SerializeField]
	private float coopShovelSpeedMultiplier;

	[SerializeField]
	private float coopDamageMultiplier;

	[SerializeField]
	private float coopHealthMultiplier;

	[SerializeField]
	private float coopTimingBarMultiplier;

	private bool alreadyLoaded;

	[field: SerializeField]
	public float MaxWeight { get; private set; }

	[field: SerializeField]
	public List<float> WeightTresholds { get; private set; }

	[field: NonSerialized]
	public float maxAllowedWeight { get; private set; }

	[field: SerializeField]
	public float locationDifficultyEasy { get; private set; }

	[field: SerializeField]
	public float locationDifficultyMedium { get; private set; }

	[field: SerializeField]
	public float locationDifficultyHard { get; private set; }

	[field: SerializeField]
	public float chanceForMixedWaves { get; private set; }

	public int CoopDifficultyIncrement => coopDifficultyIncrement;

	public float CoopRepairSpeedMultiplier => coopRepairSpeedMultiplier;

	public float CoopShovelSpeedMultiplier => coopShovelSpeedMultiplier;

	public float CoopDamageMultiplier => coopDamageMultiplier;

	public float CoopHealthMultiplier => coopHealthMultiplier;

	public float CoopTimingBarMultiplier => coopTimingBarMultiplier;

	[field: NonSerialized]
	public float CurrentWeight { get; private set; }

	[field: SerializeField]
	public DifficultySelectorWindow DifficultyUI { get; private set; }

	[field: SerializeField]
	public FixDifficultyStation DifficultyStation { get; private set; }

	[field: SerializeField]
	public LevelConfig Config { get; private set; }

	private void Awake()
	{
		Instance = this;
		startingLocationProbEasy = Config.LevelDifficulties[0].Prob;
		startingLocationProbMedium = Config.LevelDifficulties[1].Prob;
		startingLocationProbHard = Config.LevelDifficulties[2].Prob;
		EnemyWhitelists = new List<SerializedDictionary<GameObject, float>>();
		EnemyWhitelists.Add(DesertEnemyWhitelist);
		EnemyWhitelists.Add(CityEnemyWhitelist);
		EnemyWhitelists.Add(ViaductsEnemyWhitelist);
		EnemyWhitelists.Add(SnowEnemyWhitelist);
	}

	private void Update()
	{
	}

	public void UpdateWeight(float value)
	{
		CurrentWeight = Mathf.Clamp(value + CurrentWeight, 0f, maxAllowedWeight);
		if (CurrentWeight == maxAllowedWeight)
		{
			DifficultyUI.MaxAllowedWeightReached();
		}
	}

	public void RunBeaten()
	{
		if (CurrentWeight == maxAllowedWeight)
		{
			if (WeightTresholds.IndexOf(maxAllowedWeight) < WeightTresholds.Count - 1)
			{
				maxAllowedWeight = WeightTresholds[WeightTresholds.IndexOf(maxAllowedWeight) + 1];
			}
			else
			{
				maxAllowedWeight = MaxWeight;
			}
		}
		foreach (KeyValuePair<float, ScalingCondition> conditionUnlock in conditionUnlocks)
		{
			if (conditionUnlock.Key <= CurrentWeight)
			{
				conditionUnlock.Value.UpdateLockState(locked: false);
			}
		}
	}

	public int ShowRewards()
	{
		int result = 0;
		foreach (float key in rewards.Keys)
		{
			if (Instance.CurrentWeight >= key)
			{
				Instance.additionalBossCores = rewards[key];
				result = (int)Instance.additionalBossCores;
			}
		}
		return result;
	}

	public void ChangeLocationDifficulty(float valueEasy, float valueMedium, float valueHard)
	{
		locationDifficultyEasy = valueEasy;
		locationDifficultyMedium = valueMedium;
		locationDifficultyHard = valueHard;
		LevelManager.Instance.Config.LevelDifficulties[0].Prob -= lastLocationDifficultyChangeEasy;
		LevelManager.Instance.Config.LevelDifficulties[1].Prob -= lastLocationDifficultyChangeMedium;
		LevelManager.Instance.Config.LevelDifficulties[2].Prob -= lastLocationDifficultyChangeHard;
		float num = (lastLocationDifficultyChangeEasy = startingLocationProbEasy * (1f + valueEasy) - startingLocationProbEasy);
		float num2 = (lastLocationDifficultyChangeMedium = startingLocationProbMedium * (1f + valueMedium) - startingLocationProbMedium);
		float num3 = (lastLocationDifficultyChangeHard = startingLocationProbHard * (1f + valueHard) - startingLocationProbHard);
		LevelManager.Instance.Config.LevelDifficulties[0].Prob += num;
		LevelManager.Instance.Config.LevelDifficulties[1].Prob += num2;
		LevelManager.Instance.Config.LevelDifficulties[2].Prob += num3;
	}

	private void WriteConditions(MetaSavefile metaSave)
	{
		foreach (ScalingCondition scalingCondition in DifficultyUI.scalingConditions)
		{
			if (!metaSave.difficultyScalingConditions.Contains(scalingCondition.condition.ToString()))
			{
				metaSave.difficultyScalingConditions.Add(scalingCondition.condition.ToString());
				metaSave.scalingConditionStackAmount.Add(scalingCondition.currentStacks);
				metaSave.isScalingLocked.Add(scalingCondition.isLocked);
			}
			else
			{
				metaSave.scalingConditionStackAmount[metaSave.difficultyScalingConditions.IndexOf(scalingCondition.condition.ToString())] = scalingCondition.currentStacks;
				metaSave.isScalingLocked[metaSave.difficultyScalingConditions.IndexOf(scalingCondition.condition.ToString())] = scalingCondition.isLocked;
			}
		}
	}

	private void ReadConditions(MetaSavefile metaSave)
	{
		foreach (ScalingCondition scalingCondition in DifficultyUI.scalingConditions)
		{
			scalingCondition.UpdateLockState(scalingCondition.isLocked);
			foreach (string difficultyScalingCondition in metaSave.difficultyScalingConditions)
			{
				if (scalingCondition.condition.ToString() == difficultyScalingCondition)
				{
					scalingCondition.UpdateLockState(metaSave.isScalingLocked[metaSave.difficultyScalingConditions.IndexOf(difficultyScalingCondition)]);
					if (!scalingCondition.isLocked)
					{
						UpdateScalingConditions(scalingCondition, metaSave.scalingConditionStackAmount[metaSave.difficultyScalingConditions.IndexOf(difficultyScalingCondition)]);
					}
					break;
				}
			}
		}
	}

	private void UpdateScalingConditions(ScalingCondition sc, int numberOfStacks)
	{
		for (int i = 0; i < numberOfStacks; i++)
		{
			sc.IncreaseValue();
			DifficultyUI.startingJunkObjectCount++;
		}
	}

	private void UpdateToggleConditions(ToggleCondition tc, bool isOn)
	{
		if (isOn)
		{
			tc.UpdateCondition(isOn);
		}
	}

	public void Save(SaveDataContext context)
	{
		MetaSavefile metaSave = context.MetaSave;
		metaSave.maxAllowedWeight = maxAllowedWeight;
		WriteConditions(metaSave);
		Debug.Log("Saved Difficulty Setting");
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		if (!alreadyLoaded)
		{
			alreadyLoaded = true;
			MetaSavefile metaSave = context.MetaSave;
			maxAllowedWeight = metaSave.maxAllowedWeight;
			ReadConditions(metaSave);
			Debug.Log("Loaded Difficulty Setting");
		}
	}
}
