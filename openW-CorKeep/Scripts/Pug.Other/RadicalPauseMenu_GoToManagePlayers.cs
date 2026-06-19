public class RadicalPauseMenu_GoToManagePlayers : RadicalMainMenuOption
{
	public override void OnActivated()
	{
		base.OnActivated();
		Manager.menu.PushMenu(RadicalMenu.MenuType.MANAGE_PLAYERS_MENU);
	}
}
