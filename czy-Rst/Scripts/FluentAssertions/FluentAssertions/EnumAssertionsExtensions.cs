using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions
{
	[DebuggerNonUserCode]
	public static class EnumAssertionsExtensions
	{
		public static EnumAssertions<TEnum> Should<TEnum>(this TEnum @enum) where TEnum : struct, Enum
		{
			return new EnumAssertions<TEnum>(@enum, AssertionChain.GetOrCreate());
		}

		public static NullableEnumAssertions<TEnum> Should<TEnum>([NotNull] this TEnum? @enum) where TEnum : struct, Enum
		{
			return new NullableEnumAssertions<TEnum>(@enum, AssertionChain.GetOrCreate());
		}
	}
}
