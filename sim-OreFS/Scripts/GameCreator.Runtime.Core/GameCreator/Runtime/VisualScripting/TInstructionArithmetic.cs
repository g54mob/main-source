using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Value 1", "The first operand of the arithmetic operation")]
	[Parameter("Value 2", "The second operand of the arithmetic operation")]
	public abstract class TInstructionArithmetic : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberGlobalName.Create;

		[SerializeField]
		private PropertyGetDecimal m_Value1 = new PropertyGetDecimal();

		[SerializeField]
		private PropertyGetDecimal m_Value2 = new PropertyGetDecimal();

		protected abstract string Operator { get; }

		public override string Title => $"Set {m_Set} = {m_Value1} {Operator} {m_Value2}";

		protected override Task Run(Args args)
		{
			double value = m_Value1.Get(args);
			double value2 = m_Value2.Get(args);
			double value3 = Operate(value, value2);
			m_Set.Set(value3, args);
			return Instruction.DefaultResult;
		}

		protected abstract double Operate(double value1, double value2);
	}
}
