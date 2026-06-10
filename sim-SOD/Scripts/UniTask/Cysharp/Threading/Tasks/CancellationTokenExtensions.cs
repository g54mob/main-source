using System;
using System.Threading;

namespace Cysharp.Threading.Tasks
{
	public static class CancellationTokenExtensions
	{
		private static readonly Action<object> cancellationTokenCallback;

		private static readonly Action<object> disposeCallback;

		private static void Callback(object state)
		{
		}

		public static CancellationTokenRegistration RegisterWithoutCaptureExecutionContext(this CancellationToken cancellationToken, Action<object> callback, object state)
		{
			return default(CancellationTokenRegistration);
		}

		private static void DisposeCallback(object state)
		{
		}
	}
}
