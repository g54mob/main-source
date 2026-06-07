using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ZLinq
{
	internal static class ArgumentNullException
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression("argument")] string? paramName = null)
		{
			if (argument == null)
			{
				Throw(paramName);
			}
		}

		[DoesNotReturn]
		private static void Throw(string? paramName)
		{
			throw new System.ArgumentNullException(paramName);
		}
	}
}
