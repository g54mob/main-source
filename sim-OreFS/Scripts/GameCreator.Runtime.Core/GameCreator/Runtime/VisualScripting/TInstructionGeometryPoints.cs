using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Point 1", "The first operand of the geometric operation that represents a point in space")]
	[Parameter("Point 2", "The second operand of the geometric operation that represents a point in space")]
	[Keywords(new string[] { "Position", "Location", "Variable" })]
	public abstract class TInstructionGeometryPoints : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetPosition m_Point1 = new PropertyGetPosition();

		[SerializeField]
		private PropertyGetPosition m_Point2 = new PropertyGetPosition();

		protected abstract string Operator { get; }

		public override string Title => $"Set {m_Set} = {m_Point1} {Operator} {m_Point2}";

		protected override Task Run(Args args)
		{
			Vector3 value = Operate(m_Point1.Get(args), m_Point2.Get(args));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}

		protected abstract Vector3 Operate(Vector3 value1, Vector3 value2);
	}
}
