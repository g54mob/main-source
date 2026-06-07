using System;

namespace ModApi.Ui.Inspector
{
	public class HeaderModel : ItemModel
	{
		public string Label { get; private set; }

		public Action OnDeleteItem { get; set; }

		public Action<int> OnMoveItem { get; set; }

		public HeaderModel(string label)
		{
			Label = label;
		}
	}
}
