using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class IAuthListener : GalaxyTypeAwareListenerAuth
	{
		public delegate void SwigDelegateIAuthListener_0(IntPtr cPtr);

		public delegate void SwigDelegateIAuthListener_1(IntPtr cPtr, int failureReason);

		public delegate void SwigDelegateIAuthListener_2(IntPtr cPtr);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_GALAXY_SERVICE_NOT_AVAILABLE = 1,
			FAILURE_REASON_GALAXY_SERVICE_NOT_SIGNED_IN = 2,
			FAILURE_REASON_CONNECTION_FAILURE = 3,
			FAILURE_REASON_NO_LICENSE = 4,
			FAILURE_REASON_INVALID_CREDENTIALS = 5,
			FAILURE_REASON_GALAXY_NOT_INITIALIZED = 6,
			FAILURE_REASON_EXTERNAL_SERVICE_FAILURE = 7
		}

		private static Dictionary<IntPtr, IAuthListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateIAuthListener_0 swigDelegate0;

		private SwigDelegateIAuthListener_1 swigDelegate1;

		private SwigDelegateIAuthListener_2 swigDelegate2;

		private static Type[] swigMethodTypes0;

		private static Type[] swigMethodTypes1;

		private static Type[] swigMethodTypes2;

		internal IAuthListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public IAuthListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~IAuthListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnAuthSuccess();

		public abstract void OnAuthFailure(FailureReason failureReason);

		public abstract void OnAuthLost();

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnAuthSuccess(IntPtr cPtr)
		{
		}

		private static void SwigDirectorOnAuthFailure(IntPtr cPtr, int failureReason)
		{
		}

		private static void SwigDirectorOnAuthLost(IntPtr cPtr)
		{
		}
	}
}
