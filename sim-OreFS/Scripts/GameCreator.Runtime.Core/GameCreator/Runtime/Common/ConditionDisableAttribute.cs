using System;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ConditionDisableAttribute : TConditionAttribute
	{
		public ConditionDisableAttribute(params string[] fields)
			: base(fields)
		{
		}
	}
}
