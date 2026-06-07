using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class ChangeInteger
	{
		private enum Operation
		{
			Set = 0,
			Add = 1,
			Subtract = 2,
			Multiply = 3,
			Divide = 4
		}

		[SerializeField]
		private Operation m_Operation;

		[SerializeField]
		private PropertyGetInteger m_Value;

		public string OperationName => m_Operation.ToString();

		public ChangeInteger()
		{
			m_Operation = Operation.Set;
			m_Value = new PropertyGetInteger();
		}

		public ChangeInteger(int value)
			: this()
		{
			m_Value = new PropertyGetInteger(value);
		}

		public int Get(int value, Args args)
		{
			return (int)(m_Operation switch
			{
				Operation.Set => m_Value.Get(args), 
				Operation.Add => (double)value + m_Value.Get(args), 
				Operation.Subtract => (double)value - m_Value.Get(args), 
				Operation.Multiply => (double)value * m_Value.Get(args), 
				Operation.Divide => (double)value / m_Value.Get(args), 
				_ => throw new ArgumentOutOfRangeException($"Unknown operation {m_Operation}"), 
			});
		}

		public override string ToString()
		{
			return m_Operation switch
			{
				Operation.Set => $"= {m_Value}", 
				Operation.Add => $"+ {m_Value}", 
				Operation.Subtract => $"- {m_Value}", 
				Operation.Multiply => $"* {m_Value}", 
				Operation.Divide => $"/ {m_Value}", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
