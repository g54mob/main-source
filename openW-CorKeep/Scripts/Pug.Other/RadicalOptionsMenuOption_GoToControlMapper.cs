public class RadicalOptionsMenuOption_GoToControlMapper : RadicalMenuOption
{
	public override void OnActivated()
	{
		base.OnActivated();
		Manager.menu.OpenControlMappingMenu();
	}
}
