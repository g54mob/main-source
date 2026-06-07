using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class ColorModel : ValueModel<Color>
	{
		public bool AllowTransparency { get; set; }

		public bool AllowHDR { get; set; }

		public bool CallbackOnPreviewColorChange { get; set; }

		public string Label { get; set; }

		public ColorModel(string label, Func<Color> valueGetter, Action<Color> valueSetter = null, bool allowTransparency = false, bool callbackOnPreviewColorChange = false, bool allowHDR = false)
			: base(valueGetter, valueSetter)
		{
			Label = label;
			AllowTransparency = allowTransparency;
			CallbackOnPreviewColorChange = callbackOnPreviewColorChange;
			AllowHDR = allowHDR;
		}
	}
}
