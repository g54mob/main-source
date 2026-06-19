public class RadicalOptionsMenuOption_GoToBiliBiliConnectMenu : RadicalMenuOption
{
	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (!CommandLineArgs.Has("-bilibili"))
		{
			return OptionActiveState.INACTIVE;
		}
		return base.GetActiveStateInCurrentScene();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.menu.PushMenu(RadicalMenu.MenuType.BILIBILI_CONNECT);
	}
}
