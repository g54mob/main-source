using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class IGogServicesConnectionStateListener : GalaxyTypeAwareListenerGogServicesConnectionState
	{
		public delegate void SwigDelegateIGogServicesConnectionStateListener_0(IntPtr cPtr, int connectionState);

		private static Dictionary<IntPtr, IGogServicesConnectionStateListener> listeners;

		private HandleRef swigCPtr;

		private SwigDelegateIGogServicesConnectionStateListener_0 swigDelegate0;

		private static Type[] swigMethodTypes0;

		internal IGogServicesConnectionStateListener(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public IGogServicesConnectionStateListener()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~IGogServicesConnectionStateListener()
		{
		}

		public override void Dispose()
		{
		}

		public abstract void OnConnectionStateChange(GogServicesConnectionState connectionState);

		private void SwigDirectorConnect()
		{
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return false;
		}

		private static void SwigDirectorOnConnectionStateChange(IntPtr cPtr, int connectionState)
		{
		}
	}
}
