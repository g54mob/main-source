using System;
using JetBrains.Annotations;

namespace Bindito.Core
{
	[MeansImplicitUse]
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method)]
	public class InjectAttribute : Attribute
	{
	}
}
