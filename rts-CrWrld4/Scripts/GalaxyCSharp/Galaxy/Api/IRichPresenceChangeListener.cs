using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class IRichPresenceChangeListener : GalaxyTypeAwareListenerRichPresenceChange
	{
		public delegate void SwigDelegateIRichPresenceChangeListener_0(IntPtr cPtr);

		public delegate void SwigDelegateIRichPresenceChangeListener_1(IntPtr cPtr, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_CONNECTION_FAILURE = 1
		}

		private static Dictionary<IntPtr, IRichPresenceChangeListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateIRichPresenceChangeListener_0 swigDelegate0;

		private SwigDelegateIRichPresenceChangeListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0;

		private static Type[] swigMethodTypes1;

		internal IRichPresenceChangeListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public IRichPresenceChangeListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~IRichPresenceChangeListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnRichPresenceChangeSuccess();

		public abstract void OnRichPresenceChangeFailure(FailureReason failureReason);

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnRichPresenceChangeSuccess(IntPtr cPtr)
		{
		}

		private static void SwigDirectorOnRichPresenceChangeFailure(IntPtr cPtr, int failureReason)
		{
		}
	}
}
