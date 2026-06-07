using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal static class Throws
	{
		[DoesNotReturn]
		public static T Argument<T>(string paramName) where T : notnull
		{
			return default(T);
		}

		[DoesNotReturn]
		public static void Argument(string paramName, string message)
		{
		}

		[DoesNotReturn]
		public static void ArgumentOutOfRange(string paramName)
		{
		}

		[DoesNotReturn]
		public static T ArgumentOutOfRange<T>(string paramName) where T : notnull
		{
			return default(T);
		}

		[DoesNotReturn]
		public static void MoreThanOneElement()
		{
		}

		[DoesNotReturn]
		public static void MoreThanOneMatch()
		{
		}

		[DoesNotReturn]
		public static void NoElements()
		{
		}

		[DoesNotReturn]
		public static T NoElements<T>() where T : notnull
		{
			return default(T);
		}

		[DoesNotReturn]
		public static T NoMatch<T>() where T : notnull
		{
			return default(T);
		}

		[DoesNotReturn]
		public static void Overflow()
		{
		}

		[DoesNotReturn]
		public static void NotSupportedType(Type type)
		{
		}

		[DoesNotReturn]
		public static void VectorSmallOverlap<T>() where T : struct
		{
		}

		[DoesNotReturn]
		public static void IsFromEnd(string paramName)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfNull<T>(T? argument, [CallerArgumentExpression("argument")] string? paramName = null) where T : class
		{
			return null;
		}
	}
}
