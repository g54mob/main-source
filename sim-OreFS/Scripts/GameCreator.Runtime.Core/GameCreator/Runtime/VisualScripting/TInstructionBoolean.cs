using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Value 1", "The first operand of the boolean operation")]
	[Parameter("Value 2", "The second operand of the boolean operation")]
	public abstract class TInstructionBoolean : Instruction
	{
		[SerializeField]
		private PropertySetBool m_Set = SetBoolGlobalName.Create;

		[SerializeField]
		private PropertyGetBool m_Value1 = new PropertyGetBool();

		[SerializeField]
		private PropertyGetBool m_Value2 = new PropertyGetBool();

		protected abstract string Operator { get; }

		public override string Title => $"Set {m_Set} = {m_Value1} {Operator} {m_Value2}";

		protected override Task Run(Args args)
		{
			bool value = Operate(m_Value1.Get(args), m_Value2.Get(args));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}

		protected abstract bool Operate(bool value1, bool value2);
	}
}
