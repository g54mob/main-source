using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetProvider_totalLife", menuName = "Tower Factory/Target Providers/Total life", order = 4)]
public class TowerTargetProvider_totalLife : TowerTargetProvider
{
	private enum ETotalLifeType
	{
		Least = 0,
		Most = 1
	}

	[SerializeField]
	private ETotalLifeType totalLifeType;

	public override List<Enemy> GetTarget(Tower tower, List<Enemy> enemies)
	{
		auxEnemyList.Clear();
		float referenceLife = ((totalLifeType != ETotalLifeType.Most) ? int.MaxValue : 0);
		if ((bool)tower.Target && enemies.Contains(tower.Target))
		{
			referenceLife = tower.Target.CombatComponent.Health + tower.Target.CombatComponent.Armor + tower.Target.CombatComponent.Shield;
			auxEnemyList.Add(tower.Target);
		}
		float auxLife;
		enemies.ForEach(delegate(Enemy x)
		{
			if (IsTargetValid(tower, x))
			{
				auxLife = x.CombatComponent.Health + x.CombatComponent.Armor + x.CombatComponent.Shield;
				if ((totalLifeType == ETotalLifeType.Most) ? (auxLife > referenceLife) : (auxLife < referenceLife))
				{
					auxEnemyList.Clear();
					auxEnemyList.Add(x);
					referenceLife = auxLife;
				}
				else if (referenceLife == auxLife)
				{
					auxEnemyList.Add(x);
				}
			}
		});
		return auxEnemyList;
	}
}
