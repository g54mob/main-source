using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class ChangeQuaternion
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
		private PropertyGetRotation m_Value;

		public string OperationName => m_Operation.ToString();

		public ChangeQuaternion()
		{
			m_Operation = Operation.Set;
			m_Value = new PropertyGetRotation();
		}

		public ChangeQuaternion(Quaternion value)
			: this()
		{
			m_Value = new PropertyGetRotation(value);
		}

		public Quaternion Get(Quaternion rotation, Args args)
		{
			return m_Operation switch
			{
				Operation.Set => m_Value.Get(args), 
				Operation.Add => rotation * m_Value.Get(args), 
				Operation.Subtract => rotation * Quaternion.Inverse(m_Value.Get(args)), 
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
