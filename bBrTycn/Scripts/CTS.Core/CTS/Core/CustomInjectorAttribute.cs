using System;

namespace CTS.Core
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class CustomInjectorAttribute : Attribute
	{
		public Type Type { get; }

		public CustomInjectorAttribute(Type type)
		{
			Type = type;
		}
	}
}
