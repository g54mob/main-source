using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetProvider_highestArmor", menuName = "Tower Factory/Target Providers/Highest Armor", order = 2)]
public class TowerTargetProvider_highestArmor : TowerTargetProvider
{
	public override List<Enemy> GetTarget(Tower tower, List<Enemy> enemies)
	{
		auxEnemyList.Clear();
		float maxArmor = 0f;
		if (enemies.Contains(tower.Target))
		{
			maxArmor = ((tower.Target.CombatComponent.Shield > 0f) ? 0f : tower.Target.CombatComponent.Armor);
			auxEnemyList.Add(tower.Target);
		}
		float auxArmor;
		enemies.ForEach(delegate(Enemy x)
		{
			if (IsTargetValid(tower, x))
			{
				auxArmor = ((x.CombatComponent.Shield > 0f) ? 0f : x.CombatComponent.Armor);
				if (auxArmor > maxArmor)
				{
					auxEnemyList.Clear();
					auxEnemyList.Add(x);
					maxArmor = auxArmor;
				}
				else if (auxArmor == maxArmor)
				{
					auxEnemyList.Add(x);
				}
			}
		});
		return auxEnemyList;
	}
}
