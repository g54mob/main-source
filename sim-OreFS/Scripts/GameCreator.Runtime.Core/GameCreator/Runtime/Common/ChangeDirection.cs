using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class ChangeDirection
	{
		private enum Operation
		{
			Set = 0,
			Add = 1,
			Subtract = 2,
			Cross = 3,
			Project = 4,
			Max = 5,
			Min = 6
		}

		[SerializeField]
		private Operation m_Operation;

		[SerializeField]
		private PropertyGetDirection m_Value;

		public string OperationName => m_Operation.ToString();

		public ChangeDirection()
		{
			m_Operation = Operation.Set;
			m_Value = new PropertyGetDirection();
		}

		public ChangeDirection(Vector3 value)
			: this()
		{
			m_Value = new PropertyGetDirection(value);
		}

		public Vector3 Get(Vector3 value, Args args)
		{
			return m_Operation switch
			{
				Operation.Set => m_Value.Get(args), 
				Operation.Add => value + m_Value.Get(args), 
				Operation.Subtract => value - m_Value.Get(args), 
				Operation.Cross => Vector3.Cross(value, m_Value.Get(args)), 
				Operation.Project => Vector3.Project(value, m_Value.Get(args)), 
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
				_ => $"{m_Operation} {m_Value}", 
			};
		}
	}
}
