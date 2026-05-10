using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal abstract class MonoBtlsObject : IDisposable
	{
		protected internal abstract class MonoBtlsHandle : SafeHandle
		{
			public override bool IsInvalid => false;

			internal MonoBtlsHandle(IntPtr handle, bool ownsHandle)
				: base((IntPtr)0, ownsHandle: false)
			{
			}
		}

		private MonoBtlsHandle handle;

		private Exception lastError;

		internal MonoBtlsHandle Handle => null;

		public bool IsValid => false;

		internal MonoBtlsObject(MonoBtlsHandle handle)
		{
		}

		protected void CheckThrow()
		{
		}

		protected Exception SetException(Exception ex)
		{
			return null;
		}

		protected void CheckError(bool ok, [CallerMemberName] string callerName = null)
		{
		}

		protected void CheckError(int ret, [CallerMemberName] string callerName = null)
		{
		}

		protected internal void CheckLastError([CallerMemberName] string callerName = null)
		{
		}

		[PreserveSig]
		private static extern void mono_btls_free(IntPtr data);

		protected void FreeDataPtr(IntPtr data)
		{
		}

		protected virtual void Close()
		{
		}

		protected void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
		}

		~MonoBtlsObject()
		{
		}
	}
}
