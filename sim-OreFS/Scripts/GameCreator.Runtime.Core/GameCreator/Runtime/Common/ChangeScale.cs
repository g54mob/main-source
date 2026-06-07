using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class ChangeScale
	{
		private enum Operation
		{
			Set = 0,
			Add = 1,
			Subtract = 2,
			Multiply = 3,
			Max = 4,
			Min = 5
		}

		[SerializeField]
		private Operation m_Operation;

		[SerializeField]
		private PropertyGetScale m_Value;

		public string OperationName => m_Operation.ToString();

		public ChangeScale()
		{
			m_Operation = Operation.Set;
			m_Value = new PropertyGetScale();
		}

		public ChangeScale(Vector3 value)
			: this()
		{
			m_Value = new PropertyGetScale(value);
		}

		public Vector3 Get(Vector3 value, Args args)
		{
			return m_Operation switch
			{
				Operation.Set => m_Value.Get(args), 
				Operation.Add => value + m_Value.Get(args), 
				Operation.Subtract => value - m_Value.Get(args), 
				Operation.Multiply => Vector3.Scale(value, m_Value.Get(args)), 
				Operation.Max => Vector3.Max(value, m_Value.Get(args)), 
				Operation.Min => Vector3.Min(value, m_Value.Get(args)), 
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
				_ => $"{m_Operation} {m_Value}", 
			};
		}
	}
}
