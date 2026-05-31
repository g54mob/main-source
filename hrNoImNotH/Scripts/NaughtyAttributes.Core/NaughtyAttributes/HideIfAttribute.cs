using System;

namespace NaughtyAttributes
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class HideIfAttribute : ShowIfAttributeBase
	{
		public HideIfAttribute(string condition)
			: base(null)
		{
		}

		public HideIfAttribute(EConditionOperator conditionOperator, params string[] conditions)
			: base(null)
		{
		}

		public HideIfAttribute(string enumName, object enumValue)
			: base(null)
		{
		}
	}
}
