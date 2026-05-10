using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetProvider_highestHealth", menuName = "Tower Factory/Target Providers/Highest Health", order = 1)]
public class TowerTargetProvider_highestHealth : TowerTargetProvider
{
	public override List<Enemy> GetTarget(Tower tower, List<Enemy> enemies)
	{
		auxEnemyList.Clear();
		float maxHealth = 0f;
		if (enemies.Contains(tower.Target))
		{
			maxHealth = ((tower.Target.CombatComponent.Armor > 0f || tower.Target.CombatComponent.Shield > 0f) ? 0f : tower.Target.CombatComponent.Health);
			auxEnemyList.Add(tower.Target);
		}
		float auxHealth;
		enemies.ForEach(delegate(Enemy x)
		{
			if (IsTargetValid(tower, x))
			{
				auxHealth = ((x.CombatComponent.Armor > 0f || x.CombatComponent.Shield > 0f) ? 0f : x.CombatComponent.Health);
				if (auxHealth > maxHealth)
				{
					auxEnemyList.Clear();
					auxEnemyList.Add(x);
					maxHealth = auxHealth;
				}
				else if (auxHealth == maxHealth)
				{
					auxEnemyList.Add(x);
				}
			}
		});
		return auxEnemyList;
	}
}
