using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class NumericInputModel : ValueModel<double>
	{
		public ElementAlignment Alignment { get; set; } = ElementAlignment.Right;

		public Func<double, string> DisplayFormatter { get; set; }

		public Func<string, double> InputParser { get; set; }

		public string Label { get; set; }

		public double? MaxValue { get; set; }

		public double? MinValue { get; set; }

		public override double Value => base.Value;

		public NumericInputModel(string label, Func<double> valueGetter, Action<double> valueSetter = null, double? minValue = null, double? maxValue = null, Func<double, string> displayFormatter = null)
			: base(valueGetter, valueSetter)
		{
			Label = label;
			DisplayFormatter = displayFormatter ?? ((Func<double, string>)((double x) => DefaultFormatter(x)));
			InputParser = (string s) => DefaultParser(s);
			MinValue = minValue;
			MaxValue = maxValue;
		}

		public override void SetValueFromUserInput(double value, string name, bool finished = true, bool ignoreIfEqual = true)
		{
			base.SetValueFromUserInput(Mathd.Clamp(value, MinValue ?? value, MaxValue ?? value), name, finished);
		}

		private static string DefaultFormatter(double x)
		{
			return x.ToString();
		}

		private static double DefaultParser(string s)
		{
			double result = 0.0;
			double.TryParse(s, out result);
			return result;
		}
	}
}
