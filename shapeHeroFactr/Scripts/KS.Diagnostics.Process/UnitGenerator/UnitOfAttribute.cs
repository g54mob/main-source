using System;

namespace UnitGenerator
{
	[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
	internal class UnitOfAttribute : Attribute
	{
		public Type Type { get; }

		public UnitGenerateOptions Options { get; }

		public string Format { get; }

		public UnitOfAttribute(Type type, UnitGenerateOptions options = UnitGenerateOptions.None, string toStringFormat = null)
		{
		}
	}
}
