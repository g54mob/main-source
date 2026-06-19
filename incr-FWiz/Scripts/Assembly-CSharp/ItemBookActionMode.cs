public class ItemBookActionMode : PlayerActionMode
{
	public override bool PlayerCanMove => false;

	public override void OnInitiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnItemDiscovered(ItemType item)
	{
	}

	protected override void OnActivate()
	{
	}

	protected override void OnDeactivate()
	{
	}
}
