using System;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class Vector3dInputModel : VectorInputModel<Vector3d>
	{
		public Func<double, string> DisplayFormatter { get; set; }

		public Func<string, double> InputParser { get; set; }

		public Vector3dInputModel(string label, Func<Vector3d> valueGetter, Action<Vector3d> valueSetter)
			: base(label, valueGetter, valueSetter, 3)
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
				2 => DisplayFormatter(Value.z), 
				_ => throw new ArgumentException($"Component is out of range: {component}"), 
			};
		}

		public override void OnInputChanged(string[] components, int componentChanged)
		{
			SetValueFromUserInput(new Vector3d(InputParser(components[0]), InputParser(components[1]), InputParser(components[2])), base.Label);
		}
	}
}
