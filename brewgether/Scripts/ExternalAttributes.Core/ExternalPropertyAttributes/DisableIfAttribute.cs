using System;

namespace ExternalPropertyAttributes
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class DisableIfAttribute : EnableIfAttributeBase
	{
		public DisableIfAttribute(string condition)
			: base(null)
		{
		}

		public DisableIfAttribute(EConditionOperator conditionOperator, params string[] conditions)
			: base(null)
		{
		}
	}
}
