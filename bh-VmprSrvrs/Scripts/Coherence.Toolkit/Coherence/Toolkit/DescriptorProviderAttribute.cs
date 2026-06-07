using System;

namespace Coherence.Toolkit
{
	public class DescriptorProviderAttribute : Attribute
	{
		public readonly Type componentType;

		public readonly int priority;

		public DescriptorProviderAttribute(Type componentType)
		{
		}

		public DescriptorProviderAttribute(Type componentType, int priority)
		{
		}
	}
}
