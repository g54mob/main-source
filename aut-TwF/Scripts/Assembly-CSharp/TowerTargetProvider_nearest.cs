using System.Collections.Generic;
using UnityEngine;

public class TowerTargetProvider_nearest : TowerTargetProvider
{
	public override List<Enemy> GetTarget(Tower tower, List<Enemy> enemies)
	{
		float num = 0.35f;
		auxEnemyList.Clear();
		float minDistance = float.MaxValue;
		if ((bool)tower.Target && enemies.Contains(tower.Target))
		{
			Vector3 normalized = (tower.Target.transform.position - tower.transform.position).normalized;
			minDistance = (tower.Target.transform.position - tower.transform.position - normalized * num).sqrMagnitude;
			auxEnemyList.Add(tower.Target);
		}
		float auxDistance;
		enemies.ForEach(delegate(Enemy x)
		{
			if (IsTargetValid(tower, x))
			{
				auxDistance = (x.transform.position - tower.transform.position).sqrMagnitude;
				if (auxDistance < minDistance)
				{
					auxEnemyList.Clear();
					auxEnemyList.Add(x);
					minDistance = auxDistance;
				}
			}
		});
		return auxEnemyList;
	}
}
