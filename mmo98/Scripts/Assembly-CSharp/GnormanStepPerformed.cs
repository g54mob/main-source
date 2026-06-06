public readonly struct GnormanStepPerformed
{
	public readonly GnormanAction Action;

	public readonly int Step;

	public GnormanStepPerformed(GnormanAction action, int step)
	{
		Action = action;
		Step = step;
	}
}
