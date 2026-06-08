public class BuffInvisibilityStatMod : DebuffStatMod
{
	public override void Init()
	{
		base.Init();
		GameStates.Singleton.hero.isInvisible = true;
	}

	public override void End()
	{
		GameStates.Singleton.hero.isInvisible = false;
		base.End();
	}
}
