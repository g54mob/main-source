public class ThrowStone : Weapon
{
	protected override bool CanShoot()
	{
		return InventoryResources.singleton.GetResourceOfType(Data.Resource.Stone) > 0;
	}

	protected override void Execute()
	{
		base.Execute();
		InventoryResources.singleton.RemoveResourceOfType(Data.Resource.Stone, 1L);
	}
}
