using System;

namespace NaughtyAttributes
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class EnableIfAttribute : EnableIfAttributeBase
	{
		public EnableIfAttribute(string condition)
			: base(null)
		{
		}

		public EnableIfAttribute(EConditionOperator conditionOperator, params string[] conditions)
			: base(null)
		{
		}

		public EnableIfAttribute(string enumName, object enumValue)
			: base(null)
		{
		}
	}
}
