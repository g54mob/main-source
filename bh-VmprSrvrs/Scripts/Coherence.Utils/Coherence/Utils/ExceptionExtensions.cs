using System;
using System.Diagnostics.CodeAnalysis;

namespace Coherence.Utils
{
	internal static class ExceptionExtensions
	{
		public static bool TryExtract<TException>([AllowNull] this Exception exception, [NotNullWhen(true)][MaybeNullWhen(false)] out TException result) where TException : Exception
		{
			result = null;
			return false;
		}

		public static bool WasCanceled([AllowNull] this Exception exception)
		{
			return false;
		}
	}
}
