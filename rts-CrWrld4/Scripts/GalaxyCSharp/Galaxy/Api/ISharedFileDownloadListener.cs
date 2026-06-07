using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class ISharedFileDownloadListener : GalaxyTypeAwareListenerSharedFileDownload
	{
		public delegate void SwigDelegateISharedFileDownloadListener_0(IntPtr cPtr, ulong sharedFileID, string fileName);

		public delegate void SwigDelegateISharedFileDownloadListener_1(IntPtr cPtr, ulong sharedFileID, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_CONNECTION_FAILURE = 1
		}

		private static Dictionary<IntPtr, ISharedFileDownloadListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateISharedFileDownloadListener_0 swigDelegate0;

		private SwigDelegateISharedFileDownloadListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0;

		private static Type[] swigMethodTypes1;

		internal ISharedFileDownloadListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public ISharedFileDownloadListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~ISharedFileDownloadListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnSharedFileDownloadSuccess(ulong sharedFileID, string fileName);

		public abstract void OnSharedFileDownloadFailure(ulong sharedFileID, FailureReason failureReason);

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnSharedFileDownloadSuccess(IntPtr cPtr, ulong sharedFileID, string fileName)
		{
		}

		private static void SwigDirectorOnSharedFileDownloadFailure(IntPtr cPtr, ulong sharedFileID, int failureReason)
		{
		}
	}
}
