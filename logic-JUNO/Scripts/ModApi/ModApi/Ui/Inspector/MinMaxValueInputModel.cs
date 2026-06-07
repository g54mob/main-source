using System;
using ModApi.Common;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class MinMaxValueInputModel : VectorInputModel<MinMaxValue>
	{
		public Func<float, string> DisplayFormatter { get; set; }

		public Func<string, float> InputParser { get; set; }

		public MinMaxValueInputModel(string label, Func<MinMaxValue> valueGetter, Action<MinMaxValue> valueSetter)
			: base(label, valueGetter, valueSetter, 2)
		{
			DisplayFormatter = base.DefaultFormatterFloat;
			InputParser = base.DefaultParserFloat;
		}

		public override string GetComponentText(int component)
		{
			return component switch
			{
				0 => DisplayFormatter(Value.MinValue), 
				1 => DisplayFormatter(Value.MaxValue), 
				_ => throw new ArgumentException($"Component is out of range: {component}"), 
			};
		}

		public override void OnInputChanged(string[] components, int componentChanged)
		{
			float num = InputParser(components[0]);
			float num2 = InputParser(components[1]);
			switch (componentChanged)
			{
			case 0:
				num = Mathf.Min(num, num2);
				break;
			case 1:
				num2 = Mathf.Max(num, num2);
				break;
			}
			SetValueFromUserInput(new MinMaxValue(num, num2), base.Label);
		}
	}
}
