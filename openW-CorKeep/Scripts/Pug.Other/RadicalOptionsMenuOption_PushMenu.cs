public class RadicalOptionsMenuOption_PushMenu : RadicalMenuOption
{
	public RadicalMenu.MenuType menuToPush;

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.menu.PushMenu(menuToPush);
	}
}
