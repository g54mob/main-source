using System;
using UnityEngine;

namespace MoreMountains.Tools
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
	public class MMConditionAttribute : PropertyAttribute
	{
		public string ConditionBoolean = "";

		public bool Hidden;

		public bool Negative;

		public MMConditionAttribute(string conditionBoolean)
		{
			ConditionBoolean = conditionBoolean;
			Hidden = false;
		}

		public MMConditionAttribute(string conditionBoolean, bool hideInInspector)
		{
			ConditionBoolean = conditionBoolean;
			Hidden = hideInInspector;
			Negative = false;
		}

		public MMConditionAttribute(string conditionBoolean, bool hideInInspector, bool negative)
		{
			ConditionBoolean = conditionBoolean;
			Hidden = hideInInspector;
			Negative = negative;
		}
	}
}
