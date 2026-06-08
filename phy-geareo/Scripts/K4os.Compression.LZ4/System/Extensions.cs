using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System
{
	internal static class Extensions
	{
		internal static T Required<T>([NotNull] this T? value, [CallerArgumentExpression("value")] string name = null) where T : notnull
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public static void AssertTrue(this bool value, [CallerArgumentExpression("value")] string? name = null)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DoesNotReturn]
		private static void ThrowAssertionFailed(string? name)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DoesNotReturn]
		private static T ThrowArgumentNullException<T>(string name) where T : notnull
		{
			return default(T);
		}

		internal static void Validate<T>(this T[]? buffer, int offset, int length, bool allowNullIfEmpty = false)
		{
		}
	}
}
