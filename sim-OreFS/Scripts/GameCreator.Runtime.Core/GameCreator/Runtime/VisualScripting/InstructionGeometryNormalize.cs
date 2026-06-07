using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Normalize")]
	[Description("Makes the magnitude of a direction vector equal to 1")]
	[Category("Math/Geometry/Normalize")]
	[Parameter("Set", "Dynamic variable where the resulting value is set")]
	[Parameter("From", "The direction vector that is normalized")]
	[Keywords(new string[] { "Change", "Vector3", "Vector2", "Unit", "Magnitude", "Variable" })]
	[Image(typeof(IconOneCircle), ColorTheme.Type.Green)]
	public class InstructionGeometryNormalize : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetDirection m_From = new PropertyGetDirection();

		public override string Title => $"Set {m_Set} = {m_From} normalized";

		protected override Task Run(Args args)
		{
			Vector3 vector = m_From.Get(args);
			m_Set.Set(vector.normalized, args);
			return Instruction.DefaultResult;
		}
	}
}
