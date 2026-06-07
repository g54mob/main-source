using System.Collections.Generic;

namespace ModApi.Ui.Inspector
{
	public class IconButtonRowModel : ItemModel
	{
		private List<IconButtonModel> _buttons;

		public IList<IconButtonModel> Buttons => _buttons;

		public string Label { get; set; }

		public IconButtonRowModel()
		{
			_buttons = new List<IconButtonModel>();
		}

		public void Add(IconButtonModel button)
		{
			_buttons.Add(button);
		}

		public void Remove(IconButtonModel button)
		{
			_buttons.Remove(button);
		}
	}
}
