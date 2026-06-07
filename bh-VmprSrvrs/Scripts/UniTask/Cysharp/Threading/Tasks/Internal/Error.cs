using System;
using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks.Internal
{
	internal static class Error
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ThrowArgumentNullException<T>(T value, string paramName) where T : class
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowArgumentNullExceptionCore(string paramName)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Exception ArgumentOutOfRange(string paramName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Exception NoElements()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Exception MoreThanOneElement()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowArgumentException(string message)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowNotYetCompleted()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static T ThrowNotYetCompleted<T>()
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ThrowWhenContinuationIsAlreadyRegistered<T>(T continuationField) where T : class
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowInvalidOperationExceptionCore(string message)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ThrowOperationCanceledException()
		{
		}
	}
}
