using System;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ConditionHideAttribute : TConditionAttribute
	{
		public ConditionHideAttribute(params string[] fields)
			: base(fields)
		{
		}
	}
}
