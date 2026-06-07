using System;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ConditionShowAttribute : TConditionAttribute
	{
		public ConditionShowAttribute(params string[] fields)
			: base(fields)
		{
		}
	}
}
