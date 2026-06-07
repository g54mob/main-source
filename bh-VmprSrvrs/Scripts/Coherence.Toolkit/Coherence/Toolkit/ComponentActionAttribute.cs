using System;

namespace Coherence.Toolkit
{
	public class ComponentActionAttribute : Attribute
	{
		public readonly Type componentType;

		public readonly string name;

		public ComponentActionAttribute(Type componentType)
		{
		}

		public ComponentActionAttribute(Type componentType, string name)
		{
		}
	}
}
