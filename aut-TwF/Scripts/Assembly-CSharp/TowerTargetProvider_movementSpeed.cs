using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetProvider_movementSpeed", menuName = "Tower Factory/Target Providers/Movement speed", order = 5)]
public class TowerTargetProvider_movementSpeed : TowerTargetProvider
{
	private enum EMovementSpeedType
	{
		Fastest = 0,
		Slowest = 1
	}

	[SerializeField]
	private EMovementSpeedType movementSpeedType;

	public override List<Enemy> GetTarget(Tower tower, List<Enemy> enemies)
	{
		auxEnemyList.Clear();
		float referenceSpeed = ((movementSpeedType == EMovementSpeedType.Fastest) ? 0f : float.MaxValue);
		if ((bool)tower.Target && enemies.Contains(tower.Target))
		{
			referenceSpeed = tower.Target.StatsComponent.GetStat(EStats.MovementSpeed);
			auxEnemyList.Add(tower.Target);
		}
		float auxSpeed;
		enemies.ForEach(delegate(Enemy x)
		{
			if (IsTargetValid(tower, x))
			{
				auxSpeed = x.StatsComponent.GetStat(EStats.MovementSpeed);
				if ((movementSpeedType == EMovementSpeedType.Fastest) ? (auxSpeed > referenceSpeed) : (auxSpeed < referenceSpeed))
				{
					auxEnemyList.Clear();
					auxEnemyList.Add(x);
					referenceSpeed = auxSpeed;
				}
				else if (referenceSpeed == auxSpeed)
				{
					auxEnemyList.Add(x);
				}
			}
		});
		return auxEnemyList;
	}
}
