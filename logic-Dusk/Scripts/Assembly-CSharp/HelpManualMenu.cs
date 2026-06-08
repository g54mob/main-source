using System.Collections.Generic;

public class HelpManualMenu
{
	public string HeaderText { get; set; }

	public SortedList<string, HelpManualMenuItem> MenuItems { get; private set; }

	public HelpManualMenu(string headerText)
	{
		HeaderText = headerText;
		MenuItems = new SortedList<string, HelpManualMenuItem>();
	}
}
