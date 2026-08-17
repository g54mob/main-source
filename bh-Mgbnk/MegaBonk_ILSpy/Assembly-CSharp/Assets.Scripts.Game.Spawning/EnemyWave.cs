using System;
using System.Collections.Generic;
using Actors.Enemies;
using Cpp2ILInjected;

namespace Assets.Scripts.Game.Spawning;

[Serializable]
public class EnemyWave
{
	public EWaveType eWaveType;

	public List<EEnemy> enemies;

	public List<EnemyData> enemyDatas;

	public int waveTime = 60;

	public int minNumEnemies = 50;

	public float spawnInterval = 5f;

	public override string ToString()
	{
		//IL_002d: Expected I4, but got O
		object obj = default(object);
		object arg = (EWaveType)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg2 = default(object);
		object arg3 = default(object);
		return $"{arg} | waveTime: {arg2} | minNumEnemies: {arg3}";
	}

	public float EnemiesPerSecond()
	{
		return (float)minNumEnemies / spawnInterval;
	}
}
