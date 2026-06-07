using System;

namespace ModApi.Ui.Inspector
{
	public class TextButtonModel : ButtonModel
	{
		public Action<TextButtonModel> Action { get; set; }

		public string Label { get; set; }

		public TextButtonModel(string label, Action<TextButtonModel> action, Action<ItemModel> updateAction = null, Func<bool> determineVisiblity = null)
		{
			Action = action;
			Label = label;
			base.UpdateAction = updateAction;
			base.DetermineVisibility = determineVisiblity;
		}

		public override void OnClicked()
		{
			Action?.Invoke(this);
		}
	}
}
