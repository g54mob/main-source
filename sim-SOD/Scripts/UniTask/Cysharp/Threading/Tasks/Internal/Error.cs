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
		public static void ThrowWhenContinuationIsAlreadyRegistered<T>(T continuationField) where T : class
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowInvalidOperationExceptionCore(string message)
		{
		}
	}
}
