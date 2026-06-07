using System;

namespace ExternalPropertyAttributes
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
	}
}
