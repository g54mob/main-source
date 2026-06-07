using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ET Settings", menuName = "SimpleSiege/Season2 Wave Gen")]
public class SeasonTwoWaveGen : EternalWaveGenerator
{
	[SerializeField]
	private EternalTrialEnemySet enemySet;

	[SerializeField]
	private int maxAmountOfUnitsPerWave = 200;

	public List<int> _OUTgoldSpentOnEconomyBeforeNigh = new List<int>();

	public List<int> _OUTgoldSpentOnDefenseBeforeNight = new List<int>();

	public List<int> _OUTNetworthBeforeNight = new List<int>();

	public List<int> _OUTgoldEarnedInNight = new List<int>();

	public List<int> _OUTgoldDroppedInNight = new List<int>();

	public List<string> _OUTBuildorder = new List<string>();

	public List<int> _OUTDefensePower = new List<int>();

	public override List<Wave> GenerateWaves(EnemySpawnLine[] _spawns, LevelInfo _levelInfo, int _stage, out int _startingGold, int _seed, int _waveCountOverride = -1)
	{
		System.Random random = new System.Random(_seed);
		UnityEngine.Random.InitState(_seed);
		_startingGold = random.Next(8, 26);
		if (_stage <= 2 && UnityEngine.Random.value > 0.5f)
		{
			_startingGold = random.Next(8, 56);
		}
		if (_stage >= 7)
		{
			_startingGold = random.Next(13, 26);
		}
		float num;
		int n;
		int num2;
		switch (_stage)
		{
		case 0:
			num = 0.7f;
			num2 = 3;
			n = 4;
			break;
		case 1:
			num = 0.85f;
			num2 = 4;
			n = 4;
			break;
		case 2:
			num = 1f;
			num2 = 5;
			n = 5;
			break;
		case 3:
			num = 1.2f;
			num2 = 7;
			n = 6;
			break;
		case 4:
			num = 1.44f;
			num2 = 8;
			n = 7;
			break;
		default:
			num = Mathf.Pow(1.2f, _stage - 2);
			num2 = 10;
			n = 8;
			break;
		}
		float max = 0.4f;
		float max2 = 0.5f;
		if (_stage <= 3)
		{
			max = 0.65f;
			max2 = 0.65f;
		}
		List<EternalTrialEnemy> list = new List<EternalTrialEnemy>();
		for (int i = 0; i < 2000; i++)
		{
			list = WaveGenUtility.GetRandomElements(enemySet.enemies, n, random);
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			foreach (EternalTrialEnemy item in list)
			{
				if (item.group == EternalTrialEnemy.EGroup.BreadAndButter)
				{
					num3++;
					if (item.minDefenseInvestment <= 0f)
					{
						num6++;
					}
				}
				if (item.group == EternalTrialEnemy.EGroup.Flavour)
				{
					num4++;
				}
				if (item.group == EternalTrialEnemy.EGroup.Flying)
				{
					num5++;
				}
			}
			if (num6 > 0)
			{
				break;
			}
		}
		list.ETShuffle(random);
		string text = "LEVEL ENEMIES: ";
		foreach (EternalTrialEnemy item2 in list)
		{
			text = text + item2.enemyPrefab.name + ", ";
		}
		Debug.Log(text);
		float num7 = 0.2f;
		int minGoldDrops = 3;
		int maxGoldDrops = 40;
		for (int j = 0; j < 100; j++)
		{
			EconomySimulator.SimulateEconomy(out _OUTgoldSpentOnEconomyBeforeNigh, out _OUTgoldSpentOnDefenseBeforeNight, out _OUTNetworthBeforeNight, out _OUTgoldEarnedInNight, out _OUTgoldDroppedInNight, out _OUTBuildorder, out _OUTDefensePower, _levelInfo.virtualBuildings, _startingGold, num7, minGoldDrops, maxGoldDrops, num2);
			if (num2 == _OUTgoldEarnedInNight.Count)
			{
				break;
			}
			if (_startingGold > 10)
			{
				_startingGold--;
			}
			num7 *= 0.9f;
		}
		num2 = _OUTgoldEarnedInNight.Count;
		List<WaveDraft> list2 = new List<WaveDraft>();
		int num8 = UnityEngine.Random.Range(0, list.Count);
		int num9 = UnityEngine.Random.Range(0, list.Count);
		for (int k = 0; k < num2; k++)
		{
			WaveDraft waveDraft = new WaveDraft();
			list2.Add(waveDraft);
			waveDraft.targetDifficulty = (float)_OUTDefensePower[k] * 2f * num + 11f * Mathf.Clamp(num, 1f, 1.75f);
			if (_stage == 0)
			{
				waveDraft.targetDifficulty *= 0.9f;
			}
			else if (_stage == 2)
			{
				waveDraft.targetDifficulty *= Mathf.Pow(1.01f, k);
			}
			else if (_stage == 3)
			{
				waveDraft.targetDifficulty *= Mathf.Pow(1.02f, k);
			}
			else if (_stage == 4)
			{
				waveDraft.targetDifficulty *= Mathf.Pow(1.03f, k);
			}
			else if (_stage == 5)
			{
				waveDraft.targetDifficulty *= Mathf.Pow(1.04f, k);
			}
			else if (_stage >= 6)
			{
				waveDraft.targetDifficulty *= Mathf.Pow(1.05f, k);
			}
			if (k == num2 - 1)
			{
				waveDraft.targetDifficulty *= 1.15f;
			}
			waveDraft.defenseGoldSpent = _OUTgoldSpentOnDefenseBeforeNight[k];
			waveDraft.goldToDropAtNight = _OUTgoldDroppedInNight[k];
			int num10 = Mathf.Clamp(k + 1, 1, list.Count - 1);
			int value = UnityEngine.Random.Range(1, num10 + 1);
			value = Mathf.Clamp(value, 1, 5);
			if (_stage >= 3 && k == 0)
			{
				value = UnityEngine.Random.Range(1, 3);
			}
			if (_stage >= 6 && k <= 1)
			{
				value = UnityEngine.Random.Range(1, 4);
			}
			if (_stage >= 1 && random.NextDouble() < 0.5)
			{
				value = Mathf.Max(2, value);
			}
			for (int l = 0; l < list.Count; l++)
			{
				num8 = (num8 + 1) % list.Count;
				EternalTrialEnemy eternalTrialEnemy = list[num8];
				if (eternalTrialEnemy.group == EternalTrialEnemy.EGroup.BreadAndButter && (float)waveDraft.defenseGoldSpent >= eternalTrialEnemy.minDefenseInvestment)
				{
					waveDraft.enemiesToEncounter.Add(eternalTrialEnemy);
					value--;
					break;
				}
			}
			if (value <= 0)
			{
				continue;
			}
			for (int m = 0; m < list.Count; m++)
			{
				num9 = (num9 + 1) % list.Count;
				EternalTrialEnemy eternalTrialEnemy2 = list[num9];
				if (!waveDraft.enemiesToEncounter.Contains(eternalTrialEnemy2) && (float)waveDraft.defenseGoldSpent >= eternalTrialEnemy2.minDefenseInvestment)
				{
					waveDraft.enemiesToEncounter.Add(eternalTrialEnemy2);
					value--;
					if (value <= 0)
					{
						break;
					}
				}
			}
		}
		Dictionary<EternalTrialEnemy, List<EnemySpawnLine>> dictionary = new Dictionary<EternalTrialEnemy, List<EnemySpawnLine>>();
		new Dictionary<EnemySpawnLine, float>();
		foreach (EternalTrialEnemy item3 in list)
		{
			List<EnemySpawnLine> list3 = new List<EnemySpawnLine>(_spawns);
			dictionary.Add(item3, list3);
			for (int num11 = list3.Count - 1; num11 >= 0; num11--)
			{
				EnemySpawnLine enemySpawnLine = list3[num11];
				if ((item3.flying && !enemySpawnLine.canSpawnFlying) || (item3.bigGround && !enemySpawnLine.canSpawnBigGround) || (item3.smallGround && !enemySpawnLine.canSpawnSmallGround))
				{
					list3.RemoveAt(num11);
				}
			}
			list3.ETShuffle(random);
			string text2 = "";
			for (int num12 = 0; num12 < list3.Count; num12++)
			{
				text2 = text2 + list3[num12].transform.gameObject.name + ", ";
			}
		}
		for (int num13 = 0; num13 < num2; num13++)
		{
			float num14 = 0f;
			float num15 = 0f;
			float num16 = 0f;
			WaveDraft waveDraft2 = list2[num13];
			foreach (EternalTrialEnemy item4 in waveDraft2.enemiesToEncounter)
			{
				float num17 = UnityEngine.Random.Range(1f, 5f);
				if (item4.group == EternalTrialEnemy.EGroup.BreadAndButter)
				{
					num14 += num17;
				}
				if (item4.group == EternalTrialEnemy.EGroup.Flavour)
				{
					num15 += num17;
				}
				if (item4.group == EternalTrialEnemy.EGroup.Flying)
				{
					num16 += num17;
				}
				waveDraft2.percentageOfDifficultyAllocatedToEnemy.Add(num17);
			}
			float num18 = num14 + num15 + num16;
			float num19 = Mathf.Clamp(num15 / num18, 0f, max) * num18;
			float num20 = Mathf.Clamp(num16 / num18, 0f, max2) * num18;
			float num21 = num18 - num19 - num20;
			float num22 = num19 / num15;
			float num23 = num20 / num16;
			float num24 = num21 / num14;
			for (int num25 = 0; num25 < waveDraft2.enemiesToEncounter.Count; num25++)
			{
				EternalTrialEnemy eternalTrialEnemy3 = waveDraft2.enemiesToEncounter[num25];
				if (eternalTrialEnemy3.group == EternalTrialEnemy.EGroup.Flavour)
				{
					waveDraft2.percentageOfDifficultyAllocatedToEnemy[num25] *= num22;
				}
				if (eternalTrialEnemy3.group == EternalTrialEnemy.EGroup.Flying)
				{
					waveDraft2.percentageOfDifficultyAllocatedToEnemy[num25] *= num23;
				}
				if (eternalTrialEnemy3.group == EternalTrialEnemy.EGroup.BreadAndButter)
				{
					waveDraft2.percentageOfDifficultyAllocatedToEnemy[num25] *= num24;
				}
				waveDraft2.percentageOfDifficultyAllocatedToEnemy[num25] /= num18;
			}
			string text3 = "Wave " + (num13 + 1) + ": ";
			for (int num26 = 0; num26 < waveDraft2.enemiesToEncounter.Count; num26++)
			{
				EternalTrialEnemy eternalTrialEnemy4 = waveDraft2.enemiesToEncounter[num26];
				text3 = text3 + eternalTrialEnemy4.enemyPrefab.name + "(" + waveDraft2.percentageOfDifficultyAllocatedToEnemy[num26] * 100f + "%), ";
			}
		}
		for (int num27 = 0; num27 < num2; num27++)
		{
			WaveDraft waveDraft3 = list2[num27];
			int num28 = 0;
			int num29 = 0;
			for (int num30 = 0; num30 < waveDraft3.enemiesToEncounter.Count; num30++)
			{
				float num31 = waveDraft3.targetDifficulty * waveDraft3.percentageOfDifficultyAllocatedToEnemy[num30];
				int num32 = Mathf.Max(1, Mathf.RoundToInt(num31 / waveDraft3.enemiesToEncounter[num30].difficultyValue));
				waveDraft3.enemyCountForEnemy.Add(num32);
				waveDraft3.spawnInSpeedForEnemy.Add(1f);
				waveDraft3.eliteEnemies.Add(item: false);
				num28 += num32;
				if (num28 >= 10)
				{
					num29++;
				}
			}
			for (int num33 = 0; num33 < waveDraft3.enemiesToEncounter.Count; num33++)
			{
				if (num28 <= maxAmountOfUnitsPerWave)
				{
					break;
				}
				if (num29 <= 0)
				{
					break;
				}
				if (waveDraft3.enemyCountForEnemy[num33] >= 10)
				{
					int num34 = waveDraft3.enemyCountForEnemy[num33];
					waveDraft3.enemyCountForEnemy[num33] = Mathf.RoundToInt((float)waveDraft3.enemyCountForEnemy[num33] / 6f);
					waveDraft3.eliteEnemies[num33] = true;
					num29--;
					num28 -= num34 - waveDraft3.enemyCountForEnemy[num33];
				}
			}
			for (int num35 = 0; num35 < 10; num35++)
			{
				for (int num36 = 0; num36 < waveDraft3.enemiesToEncounter.Count; num36++)
				{
					if (num28 <= maxAmountOfUnitsPerWave)
					{
						break;
					}
					if (waveDraft3.enemyCountForEnemy[num36] >= 20)
					{
						int num37 = waveDraft3.enemyCountForEnemy[num36];
						waveDraft3.enemyCountForEnemy[num36] = Mathf.RoundToInt((float)waveDraft3.enemyCountForEnemy[num36] * 0.75f);
						waveDraft3.spawnInSpeedForEnemy[num36] *= 2f;
						num28 -= num37 - waveDraft3.enemyCountForEnemy[num36];
					}
				}
				if (num28 <= maxAmountOfUnitsPerWave)
				{
					break;
				}
			}
			string text4 = "Wave " + (num27 + 1) + ": ";
			for (int num38 = 0; num38 < waveDraft3.enemiesToEncounter.Count; num38++)
			{
				EternalTrialEnemy eternalTrialEnemy5 = waveDraft3.enemiesToEncounter[num38];
				text4 = text4 + eternalTrialEnemy5.enemyPrefab.name + "(x" + waveDraft3.enemyCountForEnemy[num38] + "), ";
			}
		}
		for (int num39 = 0; num39 < num2; num39++)
		{
			WaveDraft waveDraft4 = list2[num39];
			for (int num40 = 0; num40 < waveDraft4.enemiesToEncounter.Count; num40++)
			{
				List<EnemySpawnLine> list4 = new List<EnemySpawnLine>();
				waveDraft4.enemySpawnLines.Add(list4);
				EternalTrialEnemy eternalTrialEnemy6 = waveDraft4.enemiesToEncounter[num40];
				int num41 = 1;
				for (int num42 = 0; num42 < num39; num42++)
				{
					foreach (EternalTrialEnemy item5 in list2[num42].enemiesToEncounter)
					{
						if (item5 == eternalTrialEnemy6)
						{
							num41++;
						}
					}
				}
				List<EnemySpawnLine> list5 = dictionary[eternalTrialEnemy6];
				for (int num43 = 0; num43 < num41 && num43 < list5.Count; num43++)
				{
					list4.Add(list5[num43]);
				}
				waveDraft4.enemiesPerSpawnLine.Add(WaveGenUtility.DistributeEnemies(waveDraft4.enemyCountForEnemy[num40], list4.Count));
			}
		}
		for (int num44 = 0; num44 < num2; num44++)
		{
			WaveDraft waveDraft5 = list2[num44];
			waveDraft5.waveDuration = Mathf.Sqrt(waveDraft5.targetDifficulty);
		}
		List<Wave> list6 = new List<Wave>();
		foreach (WaveDraft item6 in list2)
		{
			Wave wave = new Wave();
			list6.Add(wave);
			for (int num45 = 0; num45 < item6.enemiesToEncounter.Count; num45++)
			{
				EternalTrialEnemy eternalTrialEnemy7 = item6.enemiesToEncounter[num45];
				_ = item6.enemyCountForEnemy[num45];
				bool eliteEnemies = item6.eliteEnemies[num45];
				float waveDuration = item6.waveDuration;
				float num46 = item6.spawnInSpeedForEnemy[num45];
				List<EnemySpawnLine> list7 = item6.enemySpawnLines[num45];
				for (int num47 = 0; num47 < list7.Count; num47++)
				{
					Spawn spawn = new Spawn();
					spawn.enemyPrefab = eternalTrialEnemy7.enemyPrefab;
					spawn.count = item6.enemiesPerSpawnLine[num45][num47];
					spawn.eliteEnemies = eliteEnemies;
					spawn.delay = 0f;
					spawn.interval = waveDuration / (float)Mathf.Max(1, spawn.count - 1) / num46;
					spawn.spawnLine = list7[num47].transform;
					spawn.goldCoins = 0;
					if (spawn.count > 0)
					{
						wave.spawns.Add(spawn);
					}
				}
			}
			for (int num48 = item6.goldToDropAtNight; num48 > 0; num48--)
			{
				wave.spawns[UnityEngine.Random.Range(0, wave.spawns.Count)].goldCoins++;
			}
		}
		return list6;
	}
}
