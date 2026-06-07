namespace Coherence.Common
{
	internal static class DisposableInternalExtensions
	{
		internal static string GetResourceLeakWarningMessage(this IDisposableInternal instance)
		{
			return null;
		}

		internal static void OnInitialized(this IDisposableInternal instance)
		{
		}

		internal static bool OnDisposed(this IDisposableInternal instance)
		{
			return false;
		}

		internal static bool OnFinalized(this IDisposableInternal instance)
		{
			return false;
		}
	}
}
