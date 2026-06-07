using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class Vector2dInputModel : VectorInputModel<Vector2d>
	{
		public Func<double, string> DisplayFormatter { get; set; }

		public Func<string, double> InputParser { get; set; }

		public Vector2dInputModel(string label, Func<Vector2d> valueGetter, Action<Vector2d> valueSetter)
			: base(label, valueGetter, valueSetter, 2)
		{
			DisplayFormatter = base.DefaultFormatterDouble;
			InputParser = base.DefaultParserDouble;
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
			SetValueFromUserInput(new Vector2d(InputParser(components[0]), InputParser(components[1])), base.Label);
		}
	}
}
