using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class ChangePosition
	{
		private enum Operation
		{
			Set = 0,
			Add = 1,
			Subtract = 2
		}

		[SerializeField]
		private Operation m_Operation;

		[SerializeField]
		private PropertyGetPosition m_Value;

		public string OperationName => m_Operation.ToString();

		public ChangePosition()
		{
			m_Operation = Operation.Set;
			m_Value = new PropertyGetPosition();
		}

		public ChangePosition(Vector3 value)
			: this()
		{
			m_Value = new PropertyGetPosition(value);
		}

		public Vector3 Get(Vector3 point, Args args)
		{
			Vector3 vector = m_Value.Get(args);
			return m_Operation switch
			{
				Operation.Set => vector, 
				Operation.Add => point + vector, 
				Operation.Subtract => point - vector, 
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
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
