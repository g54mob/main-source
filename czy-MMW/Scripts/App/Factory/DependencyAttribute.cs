using System;
using JetBrains.Annotations;

namespace Factory
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	[MeansImplicitUse]
	public class DependencyAttribute : Attribute
	{
	}
}
