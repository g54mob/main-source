public class BlankPlayerActionMode : PlayerActionMode
{
	public override bool PlayerCanMove => false;

	protected override void OnActivate()
	{
	}

	protected override void OnDeactivate()
	{
	}
}
