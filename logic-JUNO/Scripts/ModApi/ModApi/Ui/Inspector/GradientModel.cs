using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class GradientModel : ItemModel
	{
		public bool AllowHDR { get; set; }

		public bool HasAlpha { get; set; }

		public string Label { get; set; }

		public bool UpdatePreview { get; set; }

		public Gradient Value => ValueGetter?.Invoke();

		public Action<Gradient> ValueChanged { get; set; }

		public Func<Gradient> ValueGetter { get; set; }

		public GradientModel(string label, Func<Gradient> valueGetter, Action<Gradient> valueChanged, bool hasAlpha = true, bool allowHDR = false)
		{
			ValueGetter = valueGetter;
			ValueChanged = valueChanged;
			Label = label;
			HasAlpha = hasAlpha;
			AllowHDR = allowHDR;
		}
	}
}
