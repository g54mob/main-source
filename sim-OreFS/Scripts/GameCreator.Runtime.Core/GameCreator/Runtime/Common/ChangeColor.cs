using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class ChangeColor
	{
		private enum Operation
		{
			Set = 0,
			Add = 1,
			Subtract = 2,
			Multiply = 3
		}

		[SerializeField]
		private Operation m_Operation;

		[SerializeField]
		private PropertyGetColor m_Value;

		public string OperationName => m_Operation.ToString();

		public ChangeColor()
		{
			m_Operation = Operation.Set;
			m_Value = new PropertyGetColor();
		}

		public ChangeColor(Color value)
			: this()
		{
			m_Value = new PropertyGetColor(value);
		}

		public Color Get(Color value, Args args)
		{
			return m_Operation switch
			{
				Operation.Set => m_Value.Get(args), 
				Operation.Add => value + m_Value.Get(args), 
				Operation.Subtract => value - m_Value.Get(args), 
				Operation.Multiply => value * m_Value.Get(args), 
				_ => throw new ArgumentOutOfRangeException($"Unknown operation {m_Operation}"), 
			};
		}

		public override string ToString()
		{
			return $"{m_Operation} {m_Value}";
		}
	}
}
