using System.Collections.Generic;
using LightTower;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetProvider_grouped", menuName = "Tower Factory/Target Providers/Grouped", order = 7)]
public class TowerTargetProvider_grouped : TowerTargetProvider
{
	private enum EGroupedType
	{
		MostGrouped = 0,
		LeastGrouped = 1
	}

	[SerializeField]
	private EGroupedType groupedType;

	[SerializeField]
	[Tooltip("0 = same tile, 1 = same and adjacent tiles, etc")]
	private int tilesDistanceToCheck = 1;

	public override List<Enemy> GetTarget(Tower tower, List<Enemy> enemies)
	{
		auxEnemyList.Clear();
		int currentTargetGroupedAmount = ((groupedType != EGroupedType.MostGrouped) ? int.MaxValue : 0);
		if ((bool)tower.Target && enemies.Contains(tower.Target))
		{
			currentTargetGroupedAmount = GetNearEnemiesAmount(tower.Target, tower);
			auxEnemyList.Add(tower.Target);
		}
		int groupedAmount;
		enemies.ForEach(delegate(Enemy x)
		{
			if (IsTargetValid(tower, x))
			{
				groupedAmount = GetNearEnemiesAmount(x, tower);
				if ((groupedType == EGroupedType.MostGrouped) ? (groupedAmount > currentTargetGroupedAmount) : (groupedAmount < currentTargetGroupedAmount))
				{
					auxEnemyList.Clear();
					auxEnemyList.Add(x);
					currentTargetGroupedAmount = groupedAmount;
				}
				else if (currentTargetGroupedAmount == groupedAmount)
				{
					auxEnemyList.Add(x);
				}
			}
		});
		return auxEnemyList;
	}

	private int GetNearEnemiesAmount(Enemy enemy, Tower tower)
	{
		PathTile currentPathTile = enemy.EnemyMovement.CurrentPathTile;
		return 0 + GetPathTileEnemiesAmountRecursive(currentPathTile, tower, checkNext: true, tilesDistanceToCheck) + GetPathTileEnemiesAmountRecursive(currentPathTile, tower, checkNext: false, tilesDistanceToCheck) - currentPathTile.CurrentEnemies.Count;
	}

	private int GetPathTileEnemiesAmountRecursive(PathTile pathTile, Tower tower, bool checkNext, int recursionLevel)
	{
		int num = 0;
		if (recursionLevel > 0)
		{
			List<PathTile> list = (checkNext ? pathTile.NextPathTiles : pathTile.PreviousPathTiles);
			if (list != null)
			{
				foreach (PathTile item in list)
				{
					num += GetPathTileEnemiesAmountRecursive(item, tower, checkNext, recursionLevel - 1);
				}
			}
		}
		foreach (Enemy currentEnemy in pathTile.CurrentEnemies)
		{
			if (IsTargetValid(tower, currentEnemy))
			{
				num++;
			}
		}
		return num;
	}
}
