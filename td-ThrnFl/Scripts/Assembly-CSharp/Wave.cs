using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
	[TextArea]
	public string warningText;

	public List<Spawn> spawns = new List<Spawn>();

	public float difficultyMulti = 1f;

	public Wave()
	{
	}

	public Wave(List<Spawn> _spawns)
	{
		spawns = _spawns;
	}

	public Wave(Spawn _spawn)
	{
		spawns.Clear();
		spawns.Add(_spawn);
	}

	public void Reset(bool _resetGold = true)
	{
		for (int i = 0; i < spawns.Count; i++)
		{
			spawns[i].Reset(_resetGold);
		}
	}

	public void Update()
	{
		for (int i = 0; i < spawns.Count; i++)
		{
			spawns[i].Update(difficultyMulti);
		}
	}

	public bool HasFinished()
	{
		int num = 0;
		for (int i = 0; i < spawns.Count; i++)
		{
			if (spawns[i].Finished)
			{
				num++;
			}
		}
		if (num >= spawns.Count)
		{
			return true;
		}
		return false;
	}

	public void ReduceMaxDelayTillNextSpawn()
	{
		float num = 5f;
		float num2 = float.MaxValue;
		foreach (Spawn spawn in spawns)
		{
			if (!spawn.Finished)
			{
				num2 = Mathf.Min(num2, spawn.waitBeforeNextSpawn);
			}
		}
		float num3 = Mathf.Max(0f, num2 - num);
		foreach (Spawn spawn2 in spawns)
		{
			if (!spawn2.Finished)
			{
				spawn2.waitBeforeNextSpawn -= num3;
			}
		}
	}

	public void AddInfoToExisting(ref WaveInfo waveInfo)
	{
		foreach (Spawn spawn in spawns)
		{
			if (spawn.enemyPrefab == null)
			{
				continue;
			}
			ScreenMarkerIcon component = spawn.enemyPrefab.GetComponent<ScreenMarkerIcon>();
			string unitDescription = component.UnitDescription;
			string unitName = component.UnitName;
			Sprite sprite = component.sprite;
			WaveEnemyInfo waveEnemyInfo = null;
			foreach (WaveEnemyInfo enemy in waveInfo.enemies)
			{
				if (enemy.enemyIcon == sprite && enemy.enemyName == unitName && enemy.eliteEnemy == spawn.eliteEnemies)
				{
					waveEnemyInfo = enemy;
					break;
				}
			}
			if (waveEnemyInfo == null)
			{
				waveEnemyInfo = new WaveEnemyInfo();
				waveEnemyInfo.enemyDescription = unitDescription;
				waveEnemyInfo.enemyName = unitName;
				waveEnemyInfo.enemyIcon = sprite;
				waveEnemyInfo.eliteEnemy = spawn.eliteEnemies;
				waveInfo.enemies.Add(waveEnemyInfo);
			}
			waveInfo.goldReward += spawn.goldCoins;
			waveEnemyInfo.enemyCount += spawn.count;
		}
	}

	public WaveInfo GetWaveInfo()
	{
		WaveInfo waveInfo = new WaveInfo();
		foreach (Spawn spawn in spawns)
		{
			if (spawn.enemyPrefab == null)
			{
				continue;
			}
			ScreenMarkerIcon component = spawn.enemyPrefab.GetComponent<ScreenMarkerIcon>();
			string unitDescription = component.UnitDescription;
			string unitName = component.UnitName;
			Sprite sprite = component.sprite;
			WaveEnemyInfo waveEnemyInfo = null;
			foreach (WaveEnemyInfo enemy in waveInfo.enemies)
			{
				if (enemy.enemyIcon == sprite && enemy.enemyName == unitName && enemy.eliteEnemy == spawn.eliteEnemies)
				{
					waveEnemyInfo = enemy;
					break;
				}
			}
			if (waveEnemyInfo == null)
			{
				waveEnemyInfo = new WaveEnemyInfo();
				waveEnemyInfo.enemyDescription = unitDescription;
				waveEnemyInfo.enemyName = unitName;
				waveEnemyInfo.enemyIcon = sprite;
				waveEnemyInfo.eliteEnemy = spawn.eliteEnemies;
				waveInfo.enemies.Add(waveEnemyInfo);
			}
			waveInfo.goldReward += spawn.goldCoins;
			waveEnemyInfo.enemyCount += spawn.count;
		}
		return waveInfo;
	}
}
