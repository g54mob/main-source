using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public struct DriverAdditionalTranslation
	{
		[NonSerialized]
		private Vector3 m_Value;

		[field: NonSerialized]
		public bool HasValue { get; private set; }

		public void Add(Vector3 amount)
		{
			HasValue = true;
			m_Value += amount;
		}

		public Vector3 Consume()
		{
			Vector3 value = m_Value;
			m_Value = Vector3.zero;
			HasValue = false;
			return value;
		}
	}
}
