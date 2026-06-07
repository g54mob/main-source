using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ZLinq.Internal
{
	internal static class Throws
	{
		[DoesNotReturn]
		public static T Argument<T>(string paramName)
		{
			throw new ArgumentException(paramName);
		}

		[DoesNotReturn]
		public static void Argument(string paramName, string message)
		{
			throw new ArgumentException(message, paramName);
		}

		[DoesNotReturn]
		public static void ArgumentOutOfRange(string paramName)
		{
			throw new ArgumentOutOfRangeException(paramName);
		}

		[DoesNotReturn]
		public static T ArgumentOutOfRange<T>(string paramName)
		{
			throw new ArgumentOutOfRangeException(paramName);
		}

		[DoesNotReturn]
		public static void MoreThanOneElement()
		{
			throw new InvalidOperationException("Sequence contains more than one element");
		}

		[DoesNotReturn]
		public static void MoreThanOneMatch()
		{
			throw new InvalidOperationException("Sequence contains more than one matching element");
		}

		[DoesNotReturn]
		public static void NoElements()
		{
			throw new InvalidOperationException("Sequence contains no elements");
		}

		[DoesNotReturn]
		public static T NoElements<T>()
		{
			throw new InvalidOperationException("Sequence contains no elements");
		}

		[DoesNotReturn]
		public static T NoMatch<T>()
		{
			throw new InvalidOperationException("Sequence contains no matching element");
		}

		[DoesNotReturn]
		public static void Overflow()
		{
			throw new OverflowException();
		}

		[DoesNotReturn]
		public static void NotSupportedType(Type type)
		{
			throw new NotSupportedException(type.Name);
		}

		[DoesNotReturn]
		public static void VectorSmallOverlap<T>() where T : struct
		{
			throw new ArgumentException($"Span length must be at least {Vector<T>.Count} for OverlapOrThrow mode");
		}

		[DoesNotReturn]
		public static void IsFromEnd(string paramName)
		{
			throw new ArgumentOutOfRangeException(paramName, "IsFromEnd is not allowed.");
		}

		[DoesNotReturn]
		public static void Null(string paramName)
		{
			throw new System.ArgumentNullException(paramName);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T IfNull<T>(T? argument, [CallerArgumentExpression("argument")] string? paramName = null) where T : class
		{
			ArgumentNullException.ThrowIfNull(argument, paramName);
			return argument;
		}
	}
}
