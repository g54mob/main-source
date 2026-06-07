using System;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
	public class MMFConditionAttribute : PropertyAttribute
	{
		public string ConditionBoolean = "";

		public bool Hidden;

		public bool Negative;

		public MMFConditionAttribute(string conditionBoolean)
		{
			ConditionBoolean = conditionBoolean;
			Hidden = false;
			Negative = false;
		}

		public MMFConditionAttribute(string conditionBoolean, bool hideInInspector)
		{
			ConditionBoolean = conditionBoolean;
			Hidden = hideInInspector;
			Negative = false;
		}

		public MMFConditionAttribute(string conditionBoolean, bool hideInInspector, bool negative)
		{
			ConditionBoolean = conditionBoolean;
			Hidden = hideInInspector;
			Negative = negative;
		}
	}
}
