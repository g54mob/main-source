using System;
using UnityEngine;

namespace Lightbug.Utilities
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ConditionAttribute : PropertyAttribute
	{
		public enum ConditionType
		{
			IsTrue = 0,
			IsFalse = 1,
			IsGreaterThan = 2,
			IsEqualTo = 3,
			IsLessThan = 4,
			IsNotNull = 5,
			IsNull = 6
		}

		public enum VisibilityType
		{
			Hidden = 0,
			NotEditable = 1
		}

		public string[] conditionPropertyNames;

		public ConditionType[] conditionTypes;

		public float[] values;

		public VisibilityType visibilityType;

		public ConditionAttribute(string conditionPropertyName, ConditionType conditionType, VisibilityType visibilityType = VisibilityType.Hidden, float conditionValue = 0f)
		{
			conditionPropertyNames = new string[1] { conditionPropertyName };
			conditionTypes = new ConditionType[1] { conditionType };
			this.visibilityType = visibilityType;
			values = new float[1] { conditionValue };
		}

		public ConditionAttribute(string[] conditionPropertyNames, ConditionType[] conditionTypes, float[] conditionValues, VisibilityType visibilityType = VisibilityType.Hidden)
		{
			this.conditionPropertyNames = conditionPropertyNames;
			this.conditionTypes = conditionTypes;
			this.visibilityType = visibilityType;
			values = conditionValues;
		}
	}
}
