using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class IFriendListListener : GalaxyTypeAwareListenerFriendList
	{
		public delegate void SwigDelegateIFriendListListener_0(IntPtr cPtr);

		public delegate void SwigDelegateIFriendListListener_1(IntPtr cPtr, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_CONNECTION_FAILURE = 1
		}

		private static Dictionary<IntPtr, IFriendListListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateIFriendListListener_0 swigDelegate0;

		private SwigDelegateIFriendListListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0;

		private static Type[] swigMethodTypes1;

		internal IFriendListListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public IFriendListListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~IFriendListListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnFriendListRetrieveSuccess();

		public abstract void OnFriendListRetrieveFailure(FailureReason failureReason);

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnFriendListRetrieveSuccess(IntPtr cPtr)
		{
		}

		private static void SwigDirectorOnFriendListRetrieveFailure(IntPtr cPtr, int failureReason)
		{
		}
	}
}
