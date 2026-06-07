using System;

namespace ExternalPropertyAttributes
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ShowIfAttribute : ShowIfAttributeBase
	{
		public ShowIfAttribute(string condition)
			: base(null)
		{
		}

		public ShowIfAttribute(EConditionOperator conditionOperator, params string[] conditions)
			: base(null)
		{
		}
	}
}
