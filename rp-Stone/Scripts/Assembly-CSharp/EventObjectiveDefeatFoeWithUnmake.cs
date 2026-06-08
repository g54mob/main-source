public class EventObjectiveDefeatFoeWithUnmake : EventObjectiveBase
{
	public EventObjectiveDefeatFoeWithUnmake(int goal)
		: base("unmake_foes", goal)
	{
		description = Te.xt("tid_q_basic_unmake_foes");
	}

	public override void Init()
	{
		Character.OnCharacterDied += HandleCharacterDied;
	}

	public override void End()
	{
		Character.OnCharacterDied -= HandleCharacterDied;
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage dmg)
	{
		if (reason == Character.DeathReason.Unmake)
		{
			AddProgress();
		}
	}
}
