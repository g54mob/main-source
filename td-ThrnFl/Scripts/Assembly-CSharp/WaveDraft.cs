using System;
using System.Collections.Generic;

[Serializable]
public class WaveDraft
{
	public List<EternalTrialEnemy> enemiesToEncounter = new List<EternalTrialEnemy>();

	public List<float> percentageOfDifficultyAllocatedToEnemy = new List<float>();

	public List<float> spawnInSpeedForEnemy = new List<float>();

	public float targetDifficulty;

	public int defenseGoldSpent;

	public int goldToDropAtNight;

	public List<int> enemyCountForEnemy = new List<int>();

	public List<bool> eliteEnemies = new List<bool>();

	public float waveDuration;

	public List<List<EnemySpawnLine>> enemySpawnLines = new List<List<EnemySpawnLine>>();

	public List<List<int>> enemiesPerSpawnLine = new List<List<int>>();
}
