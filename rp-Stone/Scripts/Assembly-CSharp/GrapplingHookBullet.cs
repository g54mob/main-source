using UnityEngine;

public class GrapplingHookBullet : Bullet
{
	private Character impactTarget;

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (impactTarget != null && !impactTarget.tags.Contains("unpushable"))
		{
			int num = Mathf.Min(impactTarget.PositionX + 1, GameStates.Singleton.level.GetEnemyLimitX(impactTarget));
			impactTarget.PositionX = num;
		}
	}

	protected override void TestCollisionWithEnemies()
	{
		if (impactTarget == null)
		{
			base.TestCollisionWithEnemies();
		}
	}

	protected override void InflictDamageTo(Damage dmg, Character character)
	{
		base.InflictDamageTo(dmg, character);
		impactTarget = character;
	}
}
