using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public struct LevelDifficulty
{
	[Header("Difficulty Modifiers")]
	[SerializeField]
	public ValueRange _enemyDamageIncrease;

	[SerializeField]
	private ValueRange _waveSpawnTime;

	[SerializeField]
	private ValueRange _stormSpawnTime;

	[SerializeField]
	private ValueRange _stormDamageIncrease;

	[SerializeField]
	private ValueRange _armoredEnemies;

	[SerializeField]
	private IntRange _additionalEnemies;

	[SerializeField]
	private ValueRange _resourceGain;

	[field: SerializeField]
	public string Name { get; private set; }

	[field: SerializeField]
	public Color Color { get; private set; }

	[field: SerializeField]
	public float Prob { get; set; }

	[field: SerializeField]
	public float lootProbCommon { get; private set; }

	[field: SerializeField]
	public float lootProbRare { get; private set; }

	[field: SerializeField]
	public float lootProbEpic { get; private set; }

	[field: SerializeField]
	public float lootProbLegendary { get; private set; }

	[field: SerializeField]
	public int LootCount { get; private set; }

	public void Initialize(Level level)
	{
		List<int> list = new List<int>();
		level.EnemyDamageModifier = 0f;
		level.WaveSpawnTimeModifier = 0f;
		level.StormSpawnTimeModifier = 0f;
		level.StormDamageModifier = 0f;
		level.ArmoredEnemiesAmount = 0f;
		level.AdditionalEnemies = 0f;
		level.ResourceGainModifier = 0f;
		int num = 0;
		if (Name == "Medium")
		{
			num = 2;
		}
		else if (Name == "Hard")
		{
			num = 3;
		}
		level.ResourceGainModifier = _resourceGain.GetValue();
		if (num == 0)
		{
			return;
		}
		list = ProbUtils.GetRandomNumbersWithoutRepeating(0, 4, num);
		for (int i = 0; i < num; i++)
		{
			switch (list[i])
			{
			case 0:
				level.EnemyDamageModifier = _enemyDamageIncrease.GetValue();
				break;
			case 1:
				level.WaveSpawnTimeModifier = _waveSpawnTime.GetValue();
				break;
			case 2:
				level.StormSpawnTimeModifier = _stormSpawnTime.GetValue();
				level.StormDamageModifier = _stormDamageIncrease.GetValue();
				break;
			case 3:
				level.AdditionalEnemies = _additionalEnemies.GetValue();
				break;
			case 4:
				level.ArmoredEnemiesAmount = _armoredEnemies.GetValue();
				break;
			}
		}
	}

	public int GetLootCount()
	{
		return Mathf.Max(LootCount - DifficultyManager.Instance.lessChoices, 1);
	}

	public Rarity GetWeightedRarity()
	{
		float num = LootUtils.GetWeightedIndex(new float[4] { lootProbCommon, lootProbRare, lootProbEpic, lootProbLegendary });
		if (num <= 1f)
		{
			if (num == 0f)
			{
				return Rarity.Common;
			}
			if (num == 1f)
			{
				return Rarity.Rare;
			}
		}
		else
		{
			if (num == 2f)
			{
				return Rarity.Epic;
			}
			if (num == 3f)
			{
				return Rarity.Legendary;
			}
		}
		return Rarity.Common;
	}

	public string GetLocalizedName()
	{
		string text = "Difficulty_" + Name;
		return new LocalizedString
		{
			TableReference = "LocalizationTable",
			TableEntryReference = text
		}.GetLocalizedString();
	}

	public Rarity IncreaseRarity(Rarity rarity)
	{
		return (Rarity)Mathf.Min((int)(rarity + 1), 3);
	}
}
