using System;

namespace CTS.Core
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter)]
	public class InjectScopeAttribute : Attribute
	{
		public EGetScope Scope { get; }

		public InjectScopeAttribute(EGetScope scope)
		{
			Scope = scope;
		}
	}
}
