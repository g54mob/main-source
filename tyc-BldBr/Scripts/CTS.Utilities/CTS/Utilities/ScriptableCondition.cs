using System;
using UnityEngine;

namespace CTS.Utilities
{
	public abstract class ScriptableCondition : ScriptableObject, ICondition
	{
		public abstract event Action ConditionChanged;

		public abstract bool IsConditionValid();
	}
}
