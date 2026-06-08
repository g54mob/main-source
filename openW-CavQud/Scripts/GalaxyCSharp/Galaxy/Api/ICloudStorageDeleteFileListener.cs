using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class ICloudStorageDeleteFileListener : GalaxyTypeAwareListenerCloudStorageDeleteFile
	{
		public delegate void SwigDelegateICloudStorageDeleteFileListener_0(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name);

		public delegate void SwigDelegateICloudStorageDeleteFileListener_1(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_UNAUTHORIZED = 1,
			FAILURE_REASON_FORBIDDEN = 2,
			FAILURE_REASON_NOT_FOUND = 3,
			FAILURE_REASON_UNAVAILABLE = 4,
			FAILURE_REASON_ABORTED = 5,
			FAILURE_REASON_CONNECTION_FAILURE = 6,
			FAILURE_REASON_CONFLICT = 7
		}

		private static Dictionary<IntPtr, ICloudStorageDeleteFileListener> listeners = new Dictionary<IntPtr, ICloudStorageDeleteFileListener>();

		private HandleRef swigCPtr;

		private SwigDelegateICloudStorageDeleteFileListener_0 swigDelegate0;

		private SwigDelegateICloudStorageDeleteFileListener_1 swigDelegate1;

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

		internal ICloudStorageDeleteFileListener(IntPtr cPtr, bool cMemoryOwn)
			: base(GalaxyInstancePINVOKE.ICloudStorageDeleteFileListener_SWIGUpcast(cPtr), cMemoryOwn)
		{
			listeners.Add(cPtr, this);
			swigCPtr = new HandleRef(this, cPtr);
		}

		public ICloudStorageDeleteFileListener()
			: this(GalaxyInstancePINVOKE.new_ICloudStorageDeleteFileListener(), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			SwigDirectorConnect();
		}

		internal static HandleRef getCPtr(ICloudStorageDeleteFileListener obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ICloudStorageDeleteFileListener()
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
						GalaxyInstancePINVOKE.delete_ICloudStorageDeleteFileListener(swigCPtr);
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

		public abstract void OnDeleteFileSuccess(string container, string name);

		public abstract void OnDeleteFileFailure(string container, string name, FailureReason failureReason);

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("OnDeleteFileSuccess", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorOnDeleteFileSuccess;
			}
			if (SwigDerivedClassHasMethod("OnDeleteFileFailure", swigMethodTypes1))
			{
				swigDelegate1 = SwigDirectorOnDeleteFileFailure;
			}
			GalaxyInstancePINVOKE.ICloudStorageDeleteFileListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo method = GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return method.DeclaringType.IsSubclassOf(typeof(ICloudStorageDeleteFileListener));
		}

		[MonoPInvokeCallback(typeof(SwigDelegateICloudStorageDeleteFileListener_0))]
		private static void SwigDirectorOnDeleteFileSuccess(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnDeleteFileSuccess(container, name);
			}
		}

		[MonoPInvokeCallback(typeof(SwigDelegateICloudStorageDeleteFileListener_1))]
		private static void SwigDirectorOnDeleteFileFailure(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name, int failureReason)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnDeleteFileFailure(container, name, (FailureReason)failureReason);
			}
		}
	}
}
