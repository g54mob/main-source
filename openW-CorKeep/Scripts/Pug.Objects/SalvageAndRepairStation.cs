public class SalvageAndRepairStation : CraftingBuilding
{
	public override void Use()
	{
		Manager.main.player.SetActiveCraftingHandler(craftingHandler);
		Manager.ui.OnSalvageAndRepairOpen();
	}
}
