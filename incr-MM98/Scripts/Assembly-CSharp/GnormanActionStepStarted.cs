public readonly struct GnormanActionStepStarted
{
	public readonly GnormanAction Action;

	public readonly int Step;

	public GnormanActionStepStarted(GnormanAction action, int step)
	{
		Action = action;
		Step = step;
	}
}
