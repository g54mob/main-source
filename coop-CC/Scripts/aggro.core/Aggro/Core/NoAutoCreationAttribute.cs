using System;

namespace Aggro.Core
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
	public class NoAutoCreationAttribute : Attribute
	{
	}
}
