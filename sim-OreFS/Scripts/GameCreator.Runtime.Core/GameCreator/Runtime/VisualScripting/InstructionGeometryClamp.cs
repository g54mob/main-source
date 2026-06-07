using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Clamp")]
	[Description("Clamps all components of a Vector3 between two values")]
	[Category("Math/Geometry/Clamp")]
	[Parameter("Set", "Dynamic variable where the resulting value is set")]
	[Parameter("Value", "The Vector3 value clamped between Minimum and Maximum")]
	[Parameter("Minimum", "The minimum value")]
	[Parameter("Maximum", "The maximum value")]
	[Keywords(new string[] { "Limit", "Vector3", "Vector2", "Constraint", "Variable" })]
	[Image(typeof(IconContrast), ColorTheme.Type.Green)]
	public class InstructionGeometryClamp : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetPosition m_Value = new PropertyGetPosition();

		[SerializeField]
		private Vector3 m_Minimum = Vector3.zero;

		[SerializeField]
		private Vector3 m_Maximum = Vector3.one;

		public override string Title => $"Clamp {m_Set} = {m_Value} [{m_Minimum}, {m_Maximum}]";

		protected override Task Run(Args args)
		{
			Vector3 vector = m_Value.Get(args);
			Vector3 value = new Vector3(Mathf.Clamp(vector.x, m_Minimum.x, m_Maximum.x), Mathf.Clamp(vector.y, m_Minimum.y, m_Maximum.y), Mathf.Clamp(vector.z, m_Minimum.z, m_Maximum.z));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
