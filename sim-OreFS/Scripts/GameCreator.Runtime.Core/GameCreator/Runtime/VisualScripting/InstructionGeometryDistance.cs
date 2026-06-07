using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Distance")]
	[Description("Calculates the distance between two points in space and saves the result")]
	[Category("Math/Geometry/Distance")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Point 1", "The first operand of the geometric operation that represents a point in space")]
	[Parameter("Point 2", "The second operand of the geometric operation that represents a point in space")]
	[Keywords(new string[] { "Magnitude" })]
	[Keywords(new string[] { "Position", "Location", "Variable" })]
	[Image(typeof(IconCompass), ColorTheme.Type.Green)]
	public class InstructionGeometryDistance : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberNone.Create;

		[SerializeField]
		private PropertyGetPosition m_Point1 = new PropertyGetPosition();

		[SerializeField]
		private PropertyGetPosition m_Point2 = new PropertyGetPosition();

		public override string Title => $"Set {m_Set} = distance from {m_Point1} to {m_Point2}";

		protected override Task Run(Args args)
		{
			float num = Vector3.Distance(m_Point1.Get(args), m_Point2.Get(args));
			m_Set.Set(num, args);
			return Instruction.DefaultResult;
		}
	}
}
