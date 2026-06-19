public class UpgradeForge : CraftingBuilding
{
	public override void Use()
	{
		Manager.main.player.SetActiveCraftingHandler(craftingHandler);
		Manager.ui.OnUpgradeForgeOpen();
	}
}
