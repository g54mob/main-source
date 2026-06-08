using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class ICloudStoragePutFileListener : GalaxyTypeAwareListenerCloudStoragePutFile
	{
		public delegate void SwigDelegateICloudStoragePutFileListener_0(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name);

		public delegate void SwigDelegateICloudStoragePutFileListener_1(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_UNAUTHORIZED = 1,
			FAILURE_REASON_FORBIDDEN = 2,
			FAILURE_REASON_UNAVAILABLE = 3,
			FAILURE_REASON_ABORTED = 4,
			FAILURE_REASON_CONNECTION_FAILURE = 5,
			FAILURE_REASON_READ_FUNC_ERROR = 6,
			FAILURE_REASON_QUOTA_EXCEEDED = 7
		}

		private static Dictionary<IntPtr, ICloudStoragePutFileListener> listeners = new Dictionary<IntPtr, ICloudStoragePutFileListener>();

		private HandleRef swigCPtr;

		private SwigDelegateICloudStoragePutFileListener_0 swigDelegate0;

		private SwigDelegateICloudStoragePutFileListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0 = new Type[2]
		{
			typeof(string),
			typeof(string)
		};

		private static Type[] swigMethodTypes1 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(FailureReason)
		};

		internal ICloudStoragePutFileListener(IntPtr cPtr, bool cMemoryOwn)
			: base(GalaxyInstancePINVOKE.ICloudStoragePutFileListener_SWIGUpcast(cPtr), cMemoryOwn)
		{
			listeners.Add(cPtr, this);
			swigCPtr = new HandleRef(this, cPtr);
		}

		public ICloudStoragePutFileListener()
			: this(GalaxyInstancePINVOKE.new_ICloudStoragePutFileListener(), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			SwigDirectorConnect();
		}

		internal static HandleRef getCPtr(ICloudStoragePutFileListener obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ICloudStoragePutFileListener()
		{
			Dispose();
		}

		public override void Dispose()
		{
			lock (this)
			{
				if (swigCPtr.Handle != IntPtr.Zero)
				{
					if (swigCMemOwn)
					{
						swigCMemOwn = false;
						GalaxyInstancePINVOKE.delete_ICloudStoragePutFileListener(swigCPtr);
					}
					IntPtr handle = swigCPtr.Handle;
					if (listeners.ContainsKey(handle))
					{
						listeners.Remove(handle);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public abstract void OnPutFileSuccess(string container, string name);

		public abstract void OnPutFileFailure(string container, string name, FailureReason failureReason);

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("OnPutFileSuccess", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorOnPutFileSuccess;
			}
			if (SwigDerivedClassHasMethod("OnPutFileFailure", swigMethodTypes1))
			{
				swigDelegate1 = SwigDirectorOnPutFileFailure;
			}
			GalaxyInstancePINVOKE.ICloudStoragePutFileListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo method = GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return method.DeclaringType.IsSubclassOf(typeof(ICloudStoragePutFileListener));
		}

		[MonoPInvokeCallback(typeof(SwigDelegateICloudStoragePutFileListener_0))]
		private static void SwigDirectorOnPutFileSuccess(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnPutFileSuccess(container, name);
			}
		}

		[MonoPInvokeCallback(typeof(SwigDelegateICloudStoragePutFileListener_1))]
		private static void SwigDirectorOnPutFileFailure(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name, int failureReason)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnPutFileFailure(container, name, (FailureReason)failureReason);
			}
		}
	}
}
