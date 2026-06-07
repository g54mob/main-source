namespace ModApi.Ui.Inspector
{
	public class LabelModel : ItemModel
	{
		public ElementAlignment Alignment { get; set; }

		public string Label { get; set; }

		public LabelModel(string label, ElementAlignment alignment = ElementAlignment.Left)
		{
			Label = label;
			Alignment = alignment;
		}
	}
}
