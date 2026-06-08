public class HelpManualBreadCrumb
{
	public string DisplayText { get; private set; }

	public HelpManualMenu ThisMenu { get; private set; }

	public HelpManualMenuItem ThisMenuItem { get; private set; }

	public HelpManualBreadCrumb LastCrumb { get; private set; }

	public int LastRow { get; set; }

	public int LastColumn { get; set; }

	public HelpManualBreadCrumb NextCrumb { get; set; }

	public bool IsMenuNode { get; private set; }

	public HelpManualBreadCrumb(HelpManualMenu menu, HelpManualBreadCrumb lastCrumb)
	{
		DisplayText = menu.HeaderText;
		ThisMenu = menu;
		LastCrumb = lastCrumb;
		IsMenuNode = true;
	}

	public HelpManualBreadCrumb(HelpManualMenuItem item, HelpManualBreadCrumb lastCrumb)
	{
		if (item != null)
		{
			DisplayText = item.DisplayText;
		}
		ThisMenuItem = item;
		LastCrumb = lastCrumb;
		IsMenuNode = false;
	}
}
