using System;

namespace Borodar.FarlandSkies.Core.Games
{
	public sealed class DependencyAttribute : Attribute
	{
		public Type DependencyType { get; private set; }

		public DependencyAttribute(Type dependencyType)
		{
		}
	}
}
