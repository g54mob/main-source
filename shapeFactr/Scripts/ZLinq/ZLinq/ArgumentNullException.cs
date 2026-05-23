using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ZLinq
{
	internal static class ArgumentNullException
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression("argument")] string? paramName = null)
		{
		}

		[DoesNotReturn]
		private static void Throw(string? paramName)
		{
		}
	}
}
