using System;

namespace ModApi.Ui.Inspector
{
	public class IconButtonModel : ButtonModel
	{
		private Action<IconButtonModel> _action;

		public string Sprite { get; private set; }

		public IconButtonModel(string sprite, Action<IconButtonModel> action, string tooltip = null)
		{
			_action = action;
			Sprite = sprite;
			base.Tooltip = tooltip;
		}

		public override void OnClicked()
		{
			_action(this);
		}
	}
}
