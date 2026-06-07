using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class FloatInputModel : ValueModel<float>
	{
		public ElementAlignment Alignment { get; set; } = ElementAlignment.Right;

		public Func<float, string> DisplayFormatter { get; set; }

		public Func<string, float> InputParser { get; set; }

		public string Label { get; set; }

		public float? MaxValue { get; set; }

		public float? MinValue { get; set; }

		public FloatInputModel(string label, Func<float> valueGetter, Action<float> valueSetter = null, float? minValue = null, float? maxValue = null, Func<float, string> displayFormatter = null)
			: base(valueGetter, valueSetter)
		{
			Label = label;
			DisplayFormatter = displayFormatter ?? ((Func<float, string>)((float x) => DefaultFormatter(x)));
			InputParser = (string s) => DefaultParser(s);
			MinValue = minValue;
			MaxValue = maxValue;
		}

		public override void SetValueFromUserInput(float value, string name, bool finished = true, bool ignoreIfEqual = true)
		{
			base.SetValueFromUserInput(Mathf.Clamp(value, MinValue ?? value, MaxValue ?? value), name, finished);
		}

		private static string DefaultFormatter(float x)
		{
			return x.ToString();
		}

		private static float DefaultParser(string s)
		{
			float.TryParse(s, out var result);
			return result;
		}
	}
}
