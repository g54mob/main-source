using System;

namespace ModApi.Ui.Inspector
{
	public class LabelButtonModel : ButtonModel
	{
		private Action<LabelButtonModel> _action;

		public string ButtonLabel { get; set; }

		public string Label { get; set; }

		public LabelButtonModel(string label, Action<LabelButtonModel> action, Action<ItemModel> updateAction = null)
		{
			_action = action;
			Label = label;
			base.UpdateAction = updateAction;
		}

		public override void OnClicked()
		{
			_action(this);
		}
	}
}
