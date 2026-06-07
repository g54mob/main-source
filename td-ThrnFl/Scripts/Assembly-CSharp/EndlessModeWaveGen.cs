using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ET Settings", menuName = "SimpleSiege/Endless Mode Wave Gen")]
public class EndlessModeWaveGen : EternalWaveGenerator
{
	[SerializeField]
	private EternalTrialEnemySet enemySet;

	[SerializeField]
	private int maxAmountOfUnitsPerWave = 200;

	[SerializeField]
	private int startingGold = 20;

	[SerializeField]
	private float[] waveDifficulties;

	[SerializeField]
	private float[] difficultyMultiplayersAfterwards;

	[SerializeField]
	[Range(0f, 1f)]
	private float maxFlavourUnits = 0.4f;

	[SerializeField]
	[Range(0f, 1f)]
	private float maxFlyingUnits = 0.5f;

	public override List<Wave> GenerateWaves(EnemySpawnLine[] _spawns, LevelInfo _levelInfo, int _stage, out int _startingGold, int _seed, int _waveCountOverride = -1)
	{
		System.Random generator = new System.Random(_seed);
		UnityEngine.Random.InitState(_seed);
		_startingGold = startingGold;
		int num = waveDifficulties.Length + difficultyMultiplayersAfterwards.Length;
		List<EternalTrialEnemy> list = new List<EternalTrialEnemy>();
		list.AddRange(enemySet.enemies);
		list.ETShuffle(generator);
		List<WaveDraft> list2 = new List<WaveDraft>();
		int num2 = UnityEngine.Random.Range(0, list.Count);
		int num3 = UnityEngine.Random.Range(0, list.Count);
		for (int i = 0; i < num; i++)
		{
			WaveDraft waveDraft = new WaveDraft();
			list2.Add(waveDraft);
			waveDraft.targetDifficulty = waveDifficulties[Mathf.Min(i, waveDifficulties.Length - 1)];
			waveDraft.defenseGoldSpent = 4 + i * 4;
			waveDraft.goldToDropAtNight = Mathf.Min(4 + i, 50);
			int num4 = Mathf.Clamp(i + UnityEngine.Random.Range(1, 3), 1, 8);
			int num5 = UnityEngine.Random.Range(1, num4 + 1);
			for (int j = 0; j < list.Count; j++)
			{
				num2 = (num2 + 1) % list.Count;
				EternalTrialEnemy eternalTrialEnemy = list[num2];
				if (eternalTrialEnemy.group == EternalTrialEnemy.EGroup.BreadAndButter && (float)waveDraft.defenseGoldSpent >= eternalTrialEnemy.minDefenseInvestment)
				{
					waveDraft.enemiesToEncounter.Add(eternalTrialEnemy);
					num5--;
					break;
				}
			}
			if (num5 <= 0)
			{
				continue;
			}
			for (int k = 0; k < list.Count; k++)
			{
				num3 = (num3 + 1) % list.Count;
				EternalTrialEnemy eternalTrialEnemy2 = list[num3];
				if (!waveDraft.enemiesToEncounter.Contains(eternalTrialEnemy2) && (float)waveDraft.defenseGoldSpent >= eternalTrialEnemy2.minDefenseInvestment)
				{
					waveDraft.enemiesToEncounter.Add(eternalTrialEnemy2);
					num5--;
					if (num5 <= 0)
					{
						break;
					}
				}
			}
		}
		Dictionary<EternalTrialEnemy, List<EnemySpawnLine>> dictionary = new Dictionary<EternalTrialEnemy, List<EnemySpawnLine>>();
		new Dictionary<EnemySpawnLine, float>();
		foreach (EternalTrialEnemy item2 in list)
		{
			List<EnemySpawnLine> list3 = new List<EnemySpawnLine>(_spawns);
			dictionary.Add(item2, list3);
			for (int num6 = list3.Count - 1; num6 >= 0; num6--)
			{
				EnemySpawnLine enemySpawnLine = list3[num6];
				if ((item2.flying && !enemySpawnLine.canSpawnFlying) || (item2.bigGround && !enemySpawnLine.canSpawnBigGround) || (item2.smallGround && !enemySpawnLine.canSpawnSmallGround))
				{
					list3.RemoveAt(num6);
				}
			}
			list3.ETShuffle(generator);
		}
		List<EnemySpawnLine> list4 = new List<EnemySpawnLine>();
		list4.AddRange(_spawns);
		for (int num7 = list4.Count - 1; num7 >= 0; num7--)
		{
			if (!list4[num7].canSpawnBigGround || !list4[num7].canSpawnFlying || !list4[num7].canSpawnSmallGround)
			{
				list4.RemoveAt(num7);
			}
		}
		for (int l = 0; l < num; l++)
		{
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			WaveDraft waveDraft2 = list2[l];
			foreach (EternalTrialEnemy item3 in waveDraft2.enemiesToEncounter)
			{
				float num11 = UnityEngine.Random.Range(1f, 5f);
				if (item3.group == EternalTrialEnemy.EGroup.BreadAndButter)
				{
					num8 += num11;
				}
				if (item3.group == EternalTrialEnemy.EGroup.Flavour)
				{
					num9 += num11;
				}
				if (item3.group == EternalTrialEnemy.EGroup.Flying)
				{
					num10 += num11;
				}
				waveDraft2.percentageOfDifficultyAllocatedToEnemy.Add(num11);
			}
			float num12 = num8 + num9 + num10;
			float num13 = Mathf.Clamp(num9 / num12, 0f, maxFlavourUnits) * num12;
			float num14 = Mathf.Clamp(num10 / num12, 0f, maxFlyingUnits) * num12;
			float num15 = num12 - num13 - num14;
			float num16 = num13 / num9;
			float num17 = num14 / num10;
			float num18 = num15 / num8;
			for (int m = 0; m < waveDraft2.enemiesToEncounter.Count; m++)
			{
				EternalTrialEnemy eternalTrialEnemy3 = waveDraft2.enemiesToEncounter[m];
				if (eternalTrialEnemy3.group == EternalTrialEnemy.EGroup.Flavour)
				{
					waveDraft2.percentageOfDifficultyAllocatedToEnemy[m] *= num16;
				}
				if (eternalTrialEnemy3.group == EternalTrialEnemy.EGroup.Flying)
				{
					waveDraft2.percentageOfDifficultyAllocatedToEnemy[m] *= num17;
				}
				if (eternalTrialEnemy3.group == EternalTrialEnemy.EGroup.BreadAndButter)
				{
					waveDraft2.percentageOfDifficultyAllocatedToEnemy[m] *= num18;
				}
				waveDraft2.percentageOfDifficultyAllocatedToEnemy[m] /= num12;
			}
			string text = "Wave " + (l + 1) + ": ";
			for (int n = 0; n < waveDraft2.enemiesToEncounter.Count; n++)
			{
				EternalTrialEnemy eternalTrialEnemy4 = waveDraft2.enemiesToEncounter[n];
				text = text + eternalTrialEnemy4.enemyPrefab.name + "(" + waveDraft2.percentageOfDifficultyAllocatedToEnemy[n] * 100f + "%), ";
			}
		}
		for (int num19 = 0; num19 < num; num19++)
		{
			WaveDraft wd = list2[num19];
			int num20 = 0;
			int num21 = 0;
			for (int num22 = 0; num22 < wd.enemiesToEncounter.Count; num22++)
			{
				float num23 = wd.targetDifficulty * wd.percentageOfDifficultyAllocatedToEnemy[num22];
				int num24 = Mathf.Max(1, Mathf.RoundToInt(num23 / wd.enemiesToEncounter[num22].difficultyValue));
				wd.enemyCountForEnemy.Add(num24);
				wd.spawnInSpeedForEnemy.Add(1f);
				wd.eliteEnemies.Add(item: false);
				num20 += num24;
				if (num20 >= 10)
				{
					num21++;
				}
			}
			List<int> list5 = new List<int>();
			for (int num25 = 0; num25 < wd.enemiesToEncounter.Count; num25++)
			{
				list5.Add(num25);
			}
			list5.Sort((int a, int b) => wd.enemyCountForEnemy[b].CompareTo(wd.enemyCountForEnemy[a]));
			foreach (int item4 in list5)
			{
				if (num20 <= maxAmountOfUnitsPerWave || num21 <= 0)
				{
					break;
				}
				if (wd.enemyCountForEnemy[item4] >= 10)
				{
					int num26 = wd.enemyCountForEnemy[item4];
					wd.enemyCountForEnemy[item4] = Mathf.RoundToInt((float)wd.enemyCountForEnemy[item4] / 6f);
					wd.eliteEnemies[item4] = true;
					num21--;
					num20 -= num26 - wd.enemyCountForEnemy[item4];
				}
			}
			string text2 = "Wave " + (num19 + 1) + ": ";
			for (int num27 = 0; num27 < wd.enemiesToEncounter.Count; num27++)
			{
				EternalTrialEnemy eternalTrialEnemy5 = wd.enemiesToEncounter[num27];
				text2 = text2 + eternalTrialEnemy5.enemyPrefab.name + "(x" + wd.enemyCountForEnemy[num27] + "), ";
			}
		}
		for (int num28 = 0; num28 < num; num28++)
		{
			if (num28 % 2 == 0)
			{
				WaveDraft waveDraft3 = list2[num28];
				for (int num29 = 0; num29 < waveDraft3.enemiesToEncounter.Count; num29++)
				{
					List<EnemySpawnLine> list6 = new List<EnemySpawnLine>();
					waveDraft3.enemySpawnLines.Add(list6);
					EternalTrialEnemy key = waveDraft3.enemiesToEncounter[num29];
					int num30 = UnityEngine.Random.Range(1, 3);
					if (num28 <= 1)
					{
						num30 = 1;
					}
					List<EnemySpawnLine> list7 = dictionary[key];
					for (int num31 = 0; num31 < num30 && num31 < list7.Count; num31++)
					{
						list6.Add(list7[num31]);
					}
					waveDraft3.enemiesPerSpawnLine.Add(WaveGenUtility.DistributeEnemies(waveDraft3.enemyCountForEnemy[num29], list6.Count));
				}
			}
			else
			{
				EnemySpawnLine item = list4[UnityEngine.Random.Range(0, list4.Count)];
				WaveDraft waveDraft4 = list2[num28];
				for (int num32 = 0; num32 < waveDraft4.enemiesToEncounter.Count; num32++)
				{
					List<EnemySpawnLine> list8 = new List<EnemySpawnLine>();
					waveDraft4.enemySpawnLines.Add(list8);
					list8.Add(item);
					waveDraft4.enemiesPerSpawnLine.Add(WaveGenUtility.DistributeEnemies(waveDraft4.enemyCountForEnemy[num32], list8.Count));
				}
			}
		}
		for (int num33 = 0; num33 < num; num33++)
		{
			list2[num33].waveDuration = 7f;
		}
		List<Wave> list9 = new List<Wave>();
		foreach (WaveDraft item5 in list2)
		{
			Wave wave = new Wave();
			int count = list9.Count;
			list9.Add(wave);
			wave.difficultyMulti = difficultyMultiplayersAfterwards[Mathf.Clamp(count - waveDifficulties.Length + 1, 0, difficultyMultiplayersAfterwards.Length - 1)];
			for (int num34 = 0; num34 < item5.enemiesToEncounter.Count; num34++)
			{
				EternalTrialEnemy eternalTrialEnemy6 = item5.enemiesToEncounter[num34];
				_ = item5.enemyCountForEnemy[num34];
				bool eliteEnemies = item5.eliteEnemies[num34];
				float waveDuration = item5.waveDuration;
				float num35 = item5.spawnInSpeedForEnemy[num34];
				List<EnemySpawnLine> list10 = item5.enemySpawnLines[num34];
				for (int num36 = 0; num36 < list10.Count; num36++)
				{
					Spawn spawn = new Spawn();
					spawn.enemyPrefab = eternalTrialEnemy6.enemyPrefab;
					spawn.count = item5.enemiesPerSpawnLine[num34][num36];
					spawn.eliteEnemies = eliteEnemies;
					spawn.delay = 0f;
					spawn.interval = waveDuration / (float)Mathf.Max(1, spawn.count - 1) / num35;
					spawn.spawnLine = list10[num36].transform;
					spawn.goldCoins = 0;
					if (spawn.count > 0)
					{
						wave.spawns.Add(spawn);
					}
				}
			}
			for (int num37 = item5.goldToDropAtNight; num37 > 0; num37--)
			{
				wave.spawns[UnityEngine.Random.Range(0, wave.spawns.Count)].goldCoins++;
			}
		}
		return list9;
	}
}
