namespace UI.Xml.Examples
{
	public class ExampleListItem : ObservableListItem
	{
		public int column1 { get; set; }

		public int column2 { get; set; }

		public int combined => column1 + column2;
	}
}
