using System;

namespace Poncle.Schema.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class PolymorphicAttribute : Attribute
	{
		public Type Value { get; private set; }

		public PolymorphicAttribute(Type baseType)
		{
		}
	}
}
