using System;

namespace UnitGenerator
{
	[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
	internal class UnitOfAttribute : Attribute
	{
		public Type Type { get; }

		public UnitGenerator.UnitGenerateOptions Options { get; }

		public string Format { get; }

		public UnitOfAttribute(Type type, UnitGenerator.UnitGenerateOptions options = UnitGenerator.UnitGenerateOptions.None, string toStringFormat = null)
		{
		}
	}
}
