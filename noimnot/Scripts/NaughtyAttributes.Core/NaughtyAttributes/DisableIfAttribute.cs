using System;

namespace NaughtyAttributes
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

		public DisableIfAttribute(string enumName, object enumValue)
			: base(null)
		{
		}
	}
}
