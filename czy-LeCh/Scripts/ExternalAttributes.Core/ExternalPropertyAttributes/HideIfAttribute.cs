using System;

namespace ExternalPropertyAttributes
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class HideIfAttribute : ShowIfAttributeBase
	{
		public HideIfAttribute(string condition)
			: base(condition)
		{
			base.Inverted = true;
		}

		public HideIfAttribute(EConditionOperator conditionOperator, params string[] conditions)
			: base(conditionOperator, conditions)
		{
			base.Inverted = true;
		}
	}
}
