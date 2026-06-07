namespace UI.Xml.Examples
{
	internal class DataTableExampleListItem : ObservableListItem
	{
		public string col1 { get; set; }

		public string col2 { get; set; }

		public string col3 { get; set; }

		public string col4 { get; set; }

		public DataTableExampleListItem(string c1, string c2, string c3, string c4)
		{
			col1 = c1;
			col2 = c2;
			col3 = c3;
			col4 = c4;
		}
	}
}
