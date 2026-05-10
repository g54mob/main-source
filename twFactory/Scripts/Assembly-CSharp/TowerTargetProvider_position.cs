using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetProvider_position", menuName = "Tower Factory/Target Providers/Position", order = 0)]
public class TowerTargetProvider_position : TowerTargetProvider
{
	private enum EPositionType
	{
		First = 0,
		Last = 1
	}

	[SerializeField]
	private EPositionType positionType;

	public override List<Enemy> GetTarget(Tower tower, List<Enemy> enemies)
	{
		auxEnemyList.Clear();
		int minTilesFromEnd = ((positionType == EPositionType.First) ? int.MaxValue : 0);
		int auxTilesFromEnd;
		enemies.ForEach(delegate(Enemy x)
		{
			if (IsTargetValid(tower, x))
			{
				auxTilesFromEnd = x.EnemyMovement?.CurrentPathTile.TilesFromEnd ?? 0;
				if ((positionType == EPositionType.First) ? (auxTilesFromEnd < minTilesFromEnd) : (auxTilesFromEnd > minTilesFromEnd))
				{
					auxEnemyList.Clear();
					auxEnemyList.Add(x);
					minTilesFromEnd = auxTilesFromEnd;
				}
				else if (minTilesFromEnd == auxTilesFromEnd)
				{
					auxEnemyList.Add(x);
				}
			}
		});
		return auxEnemyList;
	}
}
