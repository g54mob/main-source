using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class IFileShareListener : GalaxyTypeAwareListenerFileShare
	{
		public delegate void SwigDelegateIFileShareListener_0(IntPtr cPtr, string fileName, ulong sharedFileID);

		public delegate void SwigDelegateIFileShareListener_1(IntPtr cPtr, string fileName, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_CONNECTION_FAILURE = 1
		}

		private static Dictionary<IntPtr, IFileShareListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateIFileShareListener_0 swigDelegate0;

		private SwigDelegateIFileShareListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0;

		private static Type[] swigMethodTypes1;

		internal IFileShareListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public IFileShareListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~IFileShareListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnFileShareSuccess(string fileName, ulong sharedFileID);

		public abstract void OnFileShareFailure(string fileName, FailureReason failureReason);

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnFileShareSuccess(IntPtr cPtr, string fileName, ulong sharedFileID)
		{
		}

		private static void SwigDirectorOnFileShareFailure(IntPtr cPtr, string fileName, int failureReason)
		{
		}
	}
}
