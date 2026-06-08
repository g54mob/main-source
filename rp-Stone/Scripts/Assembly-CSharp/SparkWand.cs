public class SparkWand : Weapon
{
	private int shotsRemaining;

	public override void SetState(State newState)
	{
		base.SetState(newState);
		if (newState != State.Casting && newState == State.Cooldown && shotsRemaining > 0)
		{
			SetState(State.Performing);
			Execute();
		}
	}

	protected override void Execute()
	{
		base.Execute();
		shotsRemaining--;
	}
}
