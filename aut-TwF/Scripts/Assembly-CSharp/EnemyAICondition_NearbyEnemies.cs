using System.Collections.Generic;
using LightTower;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAICondition_NearbyEnemies", menuName = "Tower Factory/Enemy AI/Conditions/Nearby Enemies")]
public class EnemyAICondition_NearbyEnemies : EnemyAICondition
{
	[SerializeField]
	[Tooltip("El valor con el que se comparan los enemigos cercanos, a la derecha del operador")]
	private int comparedToAmount;

	[SerializeField]
	private EComparison comparison;

	[SerializeField]
	private int forwardTilesAmount = 1;

	[SerializeField]
	private int backwardsTilesAmount;

	[SerializeField]
	private Enemy.EEnemyType validEnemyTypes;

	public override bool CheckCondition(EnemyController enemyController)
	{
		if (enemyController.EnemyMovement.CurrentPathTile == null)
		{
			return false;
		}
		return FunctionLibrary.Compare(GetNearbyEnemies(enemyController), comparedToAmount, comparison);
	}

	private int GetNearbyEnemies(EnemyController enemyController)
	{
		int num = 0;
		PathTile currentPathTile = enemyController.EnemyMovement.CurrentPathTile;
		num += GetPathTileEnemiesAmountRecursive(currentPathTile, checkNext: true, forwardTilesAmount);
		num += GetPathTileEnemiesAmountRecursive(currentPathTile, checkNext: false, backwardsTilesAmount);
		for (int i = 0; i < currentPathTile.CurrentEnemies.Count; i++)
		{
			if ((currentPathTile.CurrentEnemies[i].EnemyType & validEnemyTypes) > (Enemy.EEnemyType)0)
			{
				num--;
			}
		}
		return num - 1;
	}

	private int GetPathTileEnemiesAmountRecursive(PathTile pathTile, bool checkNext, int recursionLevel)
	{
		int num = 0;
		if (recursionLevel > 0)
		{
			List<PathTile> list = (checkNext ? pathTile.NextPathTiles : pathTile.PreviousPathTiles);
			if (list != null)
			{
				foreach (PathTile item in list)
				{
					num += GetPathTileEnemiesAmountRecursive(item, checkNext, recursionLevel - 1);
				}
			}
		}
		for (int i = 0; i < pathTile.CurrentEnemies.Count; i++)
		{
			if ((pathTile.CurrentEnemies[i].EnemyType & validEnemyTypes) > (Enemy.EEnemyType)0)
			{
				num++;
			}
		}
		return num;
	}
}
