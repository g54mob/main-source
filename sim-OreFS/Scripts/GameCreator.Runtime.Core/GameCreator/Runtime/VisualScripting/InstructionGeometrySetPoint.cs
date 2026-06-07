using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Point")]
	[Description("Changes the value of a Vector3 that represents a position in space")]
	[Category("Math/Geometry/Set Point")]
	[Parameter("Set", "Dynamic variable where the resulting value is set")]
	[Parameter("From", "The value that is set")]
	[Keywords(new string[] { "Change", "Vector3", "Vector2", "Position", "Location", "Variable" })]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	public class InstructionGeometrySetPoint : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = new PropertySetVector3();

		[SerializeField]
		private PropertyGetPosition m_From = new PropertyGetPosition();

		public override string Title => $"Set Point {m_Set} = {m_From}";

		protected override Task Run(Args args)
		{
			Vector3 value = m_From.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
