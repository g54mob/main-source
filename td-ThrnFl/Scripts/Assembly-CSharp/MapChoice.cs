using System;
using System.Collections.Generic;

[Serializable]
public class MapChoice
{
	public string mapName;

	public EquippableWeapon containedWeapon;

	public List<EquippablePerk> containedPerks = new List<EquippablePerk>();

	public List<Wave> waves = new List<Wave>();

	public List<WaveInfo> waveInfos = new List<WaveInfo>();

	public int goldAtStart;

	public int id;

	public static MapChoice GenerateNewMapChoice(int numberOfPerks, string mapName, Random generator, int id)
	{
		MapChoice mapChoice = new MapChoice();
		mapChoice.id = id;
		mapChoice.mapName = mapName;
		List<EquippableWeapon> list = new List<EquippableWeapon>();
		List<EquippablePerk> list2 = new List<EquippablePerk>();
		foreach (Equippable allEquippable in PerkManager.instance.allEquippables)
		{
			if (allEquippable is EquippableWeapon)
			{
				list.Add(allEquippable as EquippableWeapon);
			}
			if (allEquippable is EquippablePerk && !EternalTrialsRunManager.CurrentRun.acquiredPerks.Contains(allEquippable as EquippablePerk))
			{
				list2.Add(allEquippable as EquippablePerk);
			}
		}
		for (int i = 0; i < numberOfPerks; i++)
		{
			if (list2.Count < 1)
			{
				break;
			}
			int index = generator.Next(0, list2.Count);
			mapChoice.containedPerks.Add(list2[index]);
			list2.RemoveAt(index);
		}
		mapChoice.containedWeapon = list[generator.Next(0, list.Count)];
		LevelInfo levelInfoFromSceneName = LevelProgressManager.instance.GetLevelInfoFromSceneName(mapName);
		mapChoice.waves = levelInfoFromSceneName.enemySpawner.waveGeneratorScript.GenerateWaves(levelInfoFromSceneName.enemySpawner.transform.GetComponentsInChildren<EnemySpawnLine>(), levelInfoFromSceneName, EternalTrialsRunManager.CurrentRun.stage, out var startingGold, EternalTrialsRunManager.CurrentRun.currentStageSeed + mapChoice.id);
		int num = 1;
		foreach (Wave wave in mapChoice.waves)
		{
			WaveInfo waveInfo = wave.GetWaveInfo();
			waveInfo.waveNumber = num;
			mapChoice.waveInfos.Add(waveInfo);
			num++;
		}
		mapChoice.goldAtStart = startingGold;
		return mapChoice;
	}
}
