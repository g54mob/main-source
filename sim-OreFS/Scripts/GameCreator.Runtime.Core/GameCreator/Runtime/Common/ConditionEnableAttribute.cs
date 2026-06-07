using System;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ConditionEnableAttribute : TConditionAttribute
	{
		public ConditionEnableAttribute(params string[] fields)
			: base(fields)
		{
		}
	}
}
