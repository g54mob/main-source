using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class ChangeBool
	{
		private enum Operation
		{
			Set = 0,
			OR = 1,
			AND = 2,
			XOR = 3,
			NOR = 4,
			NAND = 5,
			NXOR = 6
		}

		[SerializeField]
		private Operation m_Operation;

		[SerializeField]
		private PropertyGetBool m_Value;

		public string OperationName => m_Operation.ToString();

		public ChangeBool()
		{
			m_Operation = Operation.Set;
			m_Value = new PropertyGetBool();
		}

		public ChangeBool(bool value)
			: this()
		{
			m_Value = new PropertyGetBool(value);
		}

		public bool Get(bool value, Args args)
		{
			return m_Operation switch
			{
				Operation.Set => m_Value.Get(args), 
				Operation.OR => value || m_Value.Get(args), 
				Operation.AND => value && m_Value.Get(args), 
				Operation.XOR => value != m_Value.Get(args), 
				Operation.NOR => !value && !m_Value.Get(args), 
				Operation.NAND => !value || !m_Value.Get(args), 
				Operation.NXOR => value == m_Value.Get(args), 
				_ => throw new ArgumentOutOfRangeException($"Unknown operation {m_Operation}"), 
			};
		}

		public override string ToString()
		{
			return $"{m_Operation} {m_Value}";
		}
	}
}
