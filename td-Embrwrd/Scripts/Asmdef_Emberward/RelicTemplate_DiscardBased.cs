public abstract class RelicTemplate_DiscardBased : ARelicBase
{
	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnCardDiscarded(CardData data)
	{
	}

	protected abstract void OnCardDiscardedProc(CardData data);
}
