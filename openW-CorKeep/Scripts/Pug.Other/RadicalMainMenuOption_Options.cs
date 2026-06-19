public class RadicalMainMenuOption_Options : RadicalPauseMenuOption
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.menu.PushMenu(RadicalMenu.MenuType.OPTIONS);
	}
}
