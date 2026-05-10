using System;

namespace Ookii.Dialogs
{
	internal sealed class ComCtlv6ActivationContext : IDisposable
	{
		private IntPtr _cookie;

		private static NativeMethods.ACTCTX _enableThemingActivationContext;

		private static ActivationContextSafeHandle _activationContext;

		private static bool _contextCreationSucceeded;

		private static readonly object _contextCreationLock;

		public ComCtlv6ActivationContext(bool enable)
		{
		}

		~ComCtlv6ActivationContext()
		{
		}

		public void Dispose()
		{
		}

		private void Dispose(bool disposing)
		{
		}

		private static bool EnsureActivateContextCreated()
		{
			return false;
		}
	}
}
