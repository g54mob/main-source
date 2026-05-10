using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetProvider_highestShield", menuName = "Tower Factory/Target Providers/Highest Shield", order = 3)]
public class TowerTargetProvider_highestShield : TowerTargetProvider
{
	public override List<Enemy> GetTarget(Tower tower, List<Enemy> enemies)
	{
		auxEnemyList.Clear();
		float maxShield = 0f;
		if ((bool)tower.Target && enemies.Contains(tower.Target) && tower.Target.CombatComponent.Shield > 0f)
		{
			maxShield = tower.Target.CombatComponent.Shield;
			auxEnemyList.Add(tower.Target);
		}
		float auxShield;
		enemies.ForEach(delegate(Enemy x)
		{
			if (IsTargetValid(tower, x))
			{
				auxShield = x.CombatComponent.Shield;
				if (auxShield > maxShield)
				{
					auxEnemyList.Clear();
					auxEnemyList.Add(x);
					maxShield = auxShield;
				}
				else if (auxShield == maxShield)
				{
					auxEnemyList.Add(x);
				}
			}
		});
		return auxEnemyList;
	}
}
