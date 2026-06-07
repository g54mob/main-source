namespace ModApi.Ui.Inspector
{
	public class PartInspectorModel : InspectorModel
	{
		public IconButtonRowModel IconButtonRow { get; private set; }

		public PartInspectorModel(string title, IconButtonRowModel iconButtonRow)
			: base("Part", title)
		{
			IconButtonRow = iconButtonRow;
		}
	}
}
