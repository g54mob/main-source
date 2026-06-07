using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Direction")]
	[Description("Changes the value of a Vector3 that represents a direction in space")]
	[Category("Math/Geometry/Set Direction")]
	[Parameter("Set", "Dynamic variable where the resulting value is set")]
	[Parameter("From", "The value that is set")]
	[Keywords(new string[] { "Change", "Vector3", "Vector2", "Towards", "Look", "Variable" })]
	[Image(typeof(IconVector3), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class InstructionGeometrySetDirection : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetDirection m_From = new PropertyGetDirection();

		public override string Title => $"Set Direction {m_Set} = {m_From}";

		protected override Task Run(Args args)
		{
			Vector3 value = m_From.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
