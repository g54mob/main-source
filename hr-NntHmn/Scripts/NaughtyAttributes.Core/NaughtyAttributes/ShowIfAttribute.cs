using System;

namespace NaughtyAttributes
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

		public ShowIfAttribute(string enumName, object enumValue)
			: base(null)
		{
		}
	}
}
