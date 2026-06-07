using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class ISpecificUserDataListener : GalaxyTypeAwareListenerSpecificUserData
	{
		public delegate void SwigDelegateISpecificUserDataListener_0(IntPtr cPtr, IntPtr userID);

		private static Dictionary<IntPtr, ISpecificUserDataListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateISpecificUserDataListener_0 swigDelegate0;

		private static Type[] swigMethodTypes0;

		internal ISpecificUserDataListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public ISpecificUserDataListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ISpecificUserDataListener obj)
		{
			return default(HandleRef);
		}

		~ISpecificUserDataListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnSpecificUserDataUpdated(GalaxyID userID);

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnSpecificUserDataUpdated(IntPtr cPtr, IntPtr userID)
		{
		}
	}
}
