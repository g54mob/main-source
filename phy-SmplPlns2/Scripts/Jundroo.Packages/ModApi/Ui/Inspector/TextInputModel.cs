using System;
using UnityEngine.UI;

namespace ModApi.Ui.Inspector
{
	public class TextInputModel : ValueModel<string>
	{
		public ElementAlignment Alignment { get; set; }

		public bool EnableWordWrapping { get; set; }

		public string Label { get; set; }

		public bool MultiLine { get; set; }

		public Navigation.Mode NavigationMode { get; set; } = Navigation.Mode.Automatic;

		public TextInputModel(string label, Func<string> valueGetter, Action<string> valueSetter = null, ElementAlignment alignment = ElementAlignment.Left)
			: base(valueGetter, valueSetter)
		{
			Label = label;
			Alignment = alignment;
		}
	}
}
