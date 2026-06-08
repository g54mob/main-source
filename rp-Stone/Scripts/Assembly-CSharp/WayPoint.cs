public class WayPoint : Character
{
	public int wait { get; set; }

	public override void UpdateTic()
	{
		base.UpdateTic();
		Hero hero = GameStates.Singleton.hero;
		if (Alive && hero.PositionX >= base.PositionX && hero.PositionZ == base.PositionZ && wait-- <= 0)
		{
			Die(DeathReason.DecorationCleanup);
		}
	}

	public override void ParseArguments(string sjson)
	{
		base.ParseArguments(sjson);
		wait = SlimJson.ParseInt(sjson, "wait");
	}
}
