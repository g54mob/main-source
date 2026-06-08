public class SimpleWrapAroundDeco : Decoration
{
	public int ticsPerMove = 40;

	public int wrapAroundX = 100;

	private int elapsedTics;

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedTics++;
		if (elapsedTics >= ticsPerMove)
		{
			elapsedTics = 0;
			base.PositionX--;
		}
	}

	public override void Die(DeathReason reason)
	{
		base.PositionX += wrapAroundX;
	}
}
