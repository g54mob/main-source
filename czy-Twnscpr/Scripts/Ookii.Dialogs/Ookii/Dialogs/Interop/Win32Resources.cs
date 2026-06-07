using System;

namespace Ookii.Dialogs.Interop
{
	internal class Win32Resources : IDisposable
	{
		private SafeModuleHandle _moduleHandle;

		public Win32Resources(string module)
		{
		}

		public string LoadString(uint id)
		{
			return null;
		}

		public string FormatString(uint id, params string[] args)
		{
			return null;
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		private void CheckDisposed()
		{
		}

		public void Dispose()
		{
		}
	}
}
