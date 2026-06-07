using System;
using System.Collections.Generic;

[Serializable]
public class WaveInfo
{
	public int waveNumber;

	public int outOfWaves;

	public int goldReward;

	public List<WaveEnemyInfo> enemies = new List<WaveEnemyInfo>();

	public float difficultyMulti = 1f;

	public string ToDebugString()
	{
		string text = "";
		text += $"Wave {waveNumber}/{outOfWaves}:\n\n";
		foreach (WaveEnemyInfo enemy in enemies)
		{
			text += $"{enemy.enemyCount}x {enemy.enemyName}:\n";
			text = text + enemy.enemyDescription + "\n\n";
		}
		return text;
	}

	private int[] DistributeEvenly(int total, int divisions)
	{
		int[] array = new int[divisions];
		int num = total / divisions;
		int num2 = total % divisions;
		for (int i = 0; i < divisions; i++)
		{
			array[i] = num + ((i < num2) ? 1 : 0);
		}
		return array;
	}
}
