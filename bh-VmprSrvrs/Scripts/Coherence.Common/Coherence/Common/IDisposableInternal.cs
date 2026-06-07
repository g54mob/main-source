using System;

namespace Coherence.Common
{
	internal interface IDisposableInternal : IDisposable
	{
		internal static string CurrentInitializationContext { get; private set; }

		string InitializationContext { get; set; }

		string InitializationStackTrace { get; set; }

		bool IsDisposed { get; set; }

		internal static void SetCurrentInitializationContext(string context)
		{
		}
	}
}
