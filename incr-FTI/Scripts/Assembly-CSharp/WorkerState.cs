public class WorkerState : CountableState
{
	public readonly AssignableState settings = new AssignableState();

	public override EntityId AsEntity()
	{
		return EntityId.FromItem(ItemType.Worker);
	}

	public override void Reset()
	{
		base.Reset();
		settings.Reset();
	}
}
