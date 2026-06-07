using System.Collections.Generic;
using UnityEngine;

public class EternalWaveGenerator : ScriptableObject
{
	public virtual List<Wave> GenerateWaves(EnemySpawnLine[] _spawns, LevelInfo _levelInfo, int stage, out int startingGold, int seed, int waveCountOverride = -1)
	{
		List<Wave> result = new List<Wave>();
		startingGold = 10;
		return result;
	}

	public virtual string ReturnDebugInfoAboutWave(int _wave)
	{
		return "";
	}
}
