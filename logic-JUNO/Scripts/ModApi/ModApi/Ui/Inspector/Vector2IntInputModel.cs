using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class Vector2IntInputModel : VectorInputModel<Vector2i>
	{
		public Func<int, string> DisplayFormatter { get; set; }

		public Func<string, int> InputParser { get; set; }

		public Vector2IntInputModel(string label, Func<Vector2i> valueGetter, Action<Vector2i> valueSetter)
			: base(label, valueGetter, valueSetter, 2)
		{
			DisplayFormatter = base.DefaultFormatterInt;
			InputParser = base.DefaultParserInt;
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
			SetValueFromUserInput(new Vector2i(InputParser(components[0]), InputParser(components[1])), base.Label);
		}
	}
}
