public class HelpManual
{
	public static HelpManual Instance;

	private HelpManualMenu rootMenu;

	public bool IsVisible
	{
		get
		{
			return Manual.IsVisible;
		}
		set
		{
			Manual.IsVisible = value;
			if (value && rootMenu != null)
			{
				Manual.LoadTopMenu(rootMenu);
			}
		}
	}

	public HelpManualMenuHelper helper { get; private set; }

	public HelpManual()
	{
		Instance = this;
		helper = new HelpManualMenuHelper();
		helper.BuildMenus();
		rootMenu = helper.GetFirstMenu();
		IsVisible = false;
	}
}
