using System;

namespace JetBrains.Annotations;

internal sealed class AssertionConditionAttribute(AssertionConditionType conditionType) : Attribute
{
	private AssertionConditionType _003CConditionType_003Ek__BackingField = conditionType;

	public AssertionConditionType ConditionType
	{
		get
		{
			return _003CConditionType_003Ek__BackingField;
		}
		private set
		{
			_003CConditionType_003Ek__BackingField = value;
		}
	}
}
