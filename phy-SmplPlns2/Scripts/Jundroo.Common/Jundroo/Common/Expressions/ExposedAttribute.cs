using System;

namespace Jundroo.Common.Expressions
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
	public sealed class ExposedAttribute : Attribute
	{
		public string Name { get; set; }
	}
}
