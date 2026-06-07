using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	internal sealed class ActorAttributeDependencyAttribute : Attribute
	{
		public readonly Type attributeType;

		public readonly float modifier;

		public ActorAttributeDependencyAttribute(Type attributeType, float modifier)
		{
		}
	}
}
