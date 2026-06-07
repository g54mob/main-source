namespace UIScripts
{
	public class DropdownItemData
	{
		public string title;

		public string tooltip;

		public bool defaultState;

		public DropdownItemData(string label, string description, bool state = false)
		{
			title = label;
			tooltip = description;
			defaultState = state;
		}
	}
}
