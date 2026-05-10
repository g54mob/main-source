using System;
using UnityEngine;

namespace CTS.Core
{
	public abstract class StatModifierData : ScriptableObject, IComparable<StatModifierData>
	{
		[field: SerializeField]
		public int ExecutionOrder { get; private set; }

		public abstract bool ShouldModifySet();

		public abstract bool ShouldModifyGet();

		public abstract float Modify(float inValue);

		public int CompareTo(StatModifierData other)
		{
			return ExecutionOrder.CompareTo(other.ExecutionOrder);
		}
	}
}
