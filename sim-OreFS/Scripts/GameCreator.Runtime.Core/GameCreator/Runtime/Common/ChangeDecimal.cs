using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class ChangeDecimal
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
		private PropertyGetDecimal m_Value;

		public string OperationName => m_Operation.ToString();

		public ChangeDecimal()
		{
			m_Operation = Operation.Set;
			m_Value = new PropertyGetDecimal();
		}

		public ChangeDecimal(double value)
			: this()
		{
			m_Value = new PropertyGetDecimal(value);
		}

		public ChangeDecimal(float value)
			: this()
		{
			m_Value = new PropertyGetDecimal(value);
		}

		public ChangeDecimal(PropertyGetDecimal value)
		{
			m_Value = value;
		}

		public double Get(double value, Args args)
		{
			return m_Operation switch
			{
				Operation.Set => m_Value.Get(args), 
				Operation.Add => value + m_Value.Get(args), 
				Operation.Subtract => value - m_Value.Get(args), 
				Operation.Multiply => value * m_Value.Get(args), 
				Operation.Divide => value / m_Value.Get(args), 
				_ => throw new ArgumentOutOfRangeException($"Unknown operation {m_Operation}"), 
			};
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
