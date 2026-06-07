public class WorkFilterPanel : DropDownPanel
{
	protected override float GetHeight()
	{
		return DropdownPanel.GetActiveChildCount() * 26 + 8;
	}

	protected override void Refresh()
	{
	}
}
