using System.Collections.Generic;

namespace UI.Xml.Examples
{
	internal class DataTableExampleViewModel : XmlLayoutViewModel
	{
		public ObservableList<DataTableExampleListItem> myData { get; set; }

		public ObservableList<Dictionary<string, string>> myData2 { get; set; }
	}
}
