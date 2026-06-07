using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class Vector2InputModel : VectorInputModel<Vector2>
	{
		public Func<float, string> DisplayFormatter { get; set; }

		public Func<string, float> InputParser { get; set; }

		public Vector2InputModel(string label, Func<Vector2> valueGetter, Action<Vector2> valueSetter)
			: base(label, valueGetter, valueSetter, 2)
		{
			DisplayFormatter = base.DefaultFormatterFloat;
			InputParser = base.DefaultParserFloat;
		}

		public override string GetComponentText(int component)
		{
			return component switch
			{
				0 => DisplayFormatter(Value.x), 
				1 => DisplayFormatter(Value.y), 
				_ => throw new ArgumentException($"Component is out of range: {component}"), 
			};
		}

		public override void OnInputChanged(string[] components, int componentChanged)
		{
			SetValueFromUserInput(new Vector2(InputParser(components[0]), InputParser(components[1])), base.Label);
		}
	}
}
