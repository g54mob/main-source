using Aggro.Core;

public class ShopHolderTrigger : EntityBehaviourBase
{
	public ShopHolder holder { get; private set; }

	protected override void OnInitializeBehaviour()
	{
		holder = GetComponentInParent<ShopHolder>();
	}
}
