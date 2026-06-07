using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class Vector3InputModel : VectorInputModel<Vector3>
	{
		public Func<float, string> DisplayFormatter { get; set; }

		public Func<string, float> InputParser { get; set; }

		public Vector3InputModel(string label, Func<Vector3> valueGetter, Action<Vector3> valueSetter)
			: base(label, valueGetter, valueSetter, 3)
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
				2 => DisplayFormatter(Value.z), 
				_ => throw new ArgumentException($"Component is out of range: {component}"), 
			};
		}

		public override void OnInputChanged(string[] components, int componentChanged)
		{
			SetValueFromUserInput(new Vector3(InputParser(components[0]), InputParser(components[1]), InputParser(components[2])), base.Label);
		}
	}
}
