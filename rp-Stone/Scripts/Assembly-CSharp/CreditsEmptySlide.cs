public class CreditsEmptySlide : CreditsASlide
{
	public int ticDuration = 30;

	private int elapsedTics;

	public override void Reset()
	{
		elapsedTics = 0;
	}

	public override void UpdateTic()
	{
		elapsedTics++;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
	}

	public override bool IsDone()
	{
		return elapsedTics >= ticDuration;
	}
}
