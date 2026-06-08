public class Decoration : Character
{
	public int distanceToCleanup = -50;

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (Alive && base.PositionX - GameStates.Singleton.hero.PositionX + base.CollisionWidth < distanceToCleanup)
		{
			Die(DeathReason.DecorationCleanup);
		}
	}
}
