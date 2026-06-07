using System;

namespace ModApi.Ui.Inspector
{
	public class TextModel : ItemModel
	{
		private Func<string> _valueGetter;

		public string Label { get; set; }

		public string Value { get; set; }

		public TextModel(string label, Func<string> valueGetter = null, Action<ItemModel> updateAction = null, string tooltip = null, Func<bool> determineVisibility = null)
		{
			_valueGetter = valueGetter;
			Label = label;
			base.UpdateAction = updateAction;
			base.Tooltip = tooltip;
			base.DetermineVisibility = determineVisibility;
		}

		public override void Update()
		{
			base.Update();
			if (_valueGetter != null)
			{
				Value = _valueGetter();
			}
		}
	}
}
