using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;

namespace Actors.Enemies;

public static class EnemyBehaviour
{
	public static void DeathBehaviour(Enemy enemy)
	{
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		if (enemyData.enemyName == EEnemy.BoomerSpider)
		{
			EffectManager instance = EffectManager.Instance;
			if (((HashSet<object>)(object)instance.currentlyExplodingEnemy).Contains((object)enemy))
			{
				return;
			}
		}
		enemy.dissolve.enabled = true;
		enemy.dissolve.StartDissolve();
	}

	public static void FixedUpdate(Enemy enemy)
	{
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		if (enemyData.enemyName == EEnemy.BoomerSpider)
		{
			EnemyMovementRb enemyMovement = enemy.enemyMovement;
			if (5f > enemyMovement.distanceToTarget && !enemy.IsDeadOrDyingNextFrame())
			{
				enemy.DiedNextFrame();
				EffectManager.Instance.ExploderEnemy(enemy);
			}
		}
	}
}
