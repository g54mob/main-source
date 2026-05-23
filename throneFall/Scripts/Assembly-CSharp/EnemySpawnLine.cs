using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnLine : MonoBehaviour
{
	public enum ESpawnDifficulty
	{
		Normal = 0,
		EasierForPlayerToDealWith = 1,
		HarderForPlayerToDealWith = 2
	}

	[SerializeField]
	private ESpawnDifficulty difficulty;

	public bool canSpawnFlying;

	public bool canSpawnSmallGround;

	public bool canSpawnBigGround;

	public List<EnemySpawnLine> mostlySharedAttackpaths = new List<EnemySpawnLine>();

	public List<EnemySpawnLine> mostlySeperatedAttackPaths = new List<EnemySpawnLine>();

	public float DifficultyBudgetMultiplyer => difficulty switch
	{
		ESpawnDifficulty.EasierForPlayerToDealWith => 1.15f, 
		ESpawnDifficulty.HarderForPlayerToDealWith => 0.85f, 
		_ => 1f, 
	};

	public Transform SpawnLine => base.transform;
}
