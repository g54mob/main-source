using Assets.Scripts.Actors.Enemies;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;

public class DebuffStun : EnemyDebuff
{
	public override int GetStacks()
	{
		return 0;
	}

	public override void MyTick()
	{
	}

	public override EDebuff GetDebuffType()
	{
		return EDebuff.Stun;
	}

	public override void OnAdded()
	{
		Enemy enemy = base.enemy;
		enemy.enemyMovement.FindNextPosition();
	}

	public override void OnRemove(bool fromDeath)
	{
		Enemy enemy = base.enemy;
		enemy.enemyMovement.FindNextPosition();
	}

	public override void OnRefresh()
	{
	}

	protected override void OnResetState()
	{
	}

	public override void AddStacks(int numStacks)
	{
	}
}
