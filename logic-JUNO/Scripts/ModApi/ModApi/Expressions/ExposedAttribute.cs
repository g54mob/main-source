using System;

namespace ModApi.Expressions
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
	internal sealed class ExposedAttribute : Attribute
	{
		public string Name { get; set; }
	}
}
