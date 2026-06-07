using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Direction 1", "The first operand of the geometric operation that represents a direction")]
	[Parameter("Direction 2", "The second operand of the geometric operation that represents a direction")]
	[Keywords(new string[] { "Position", "Location", "Variable" })]
	public abstract class TInstructionGeometryDirections : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction1 = new PropertyGetDirection();

		[SerializeField]
		private PropertyGetDirection m_Direction2 = new PropertyGetDirection();

		protected abstract string Operator { get; }

		public override string Title => $"Set {m_Set} = {m_Direction1} {Operator} {m_Direction2}";

		protected override Task Run(Args args)
		{
			Vector3 value = Operate(m_Direction1.Get(args), m_Direction2.Get(args));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}

		protected abstract Vector3 Operate(Vector3 value1, Vector3 value2);
	}
}
