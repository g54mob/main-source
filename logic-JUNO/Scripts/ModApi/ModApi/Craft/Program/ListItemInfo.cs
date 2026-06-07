namespace ModApi.Craft.Program
{
	public class ListItemInfo
	{
		public string Id { get; set; }

		public ListItemInfoType ItemType { get; set; }

		public string Text { get; set; }

		public string Tooltip { get; set; }

		public ListItemInfo(string id, string text, string tooltip, ListItemInfoType type)
		{
			Id = id;
			Text = text;
			Tooltip = tooltip;
			ItemType = type;
		}
	}
}
