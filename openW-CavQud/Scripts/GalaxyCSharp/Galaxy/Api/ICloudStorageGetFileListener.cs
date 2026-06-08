using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class ICloudStorageGetFileListener : GalaxyTypeAwareListenerCloudStorageGetFile
	{
		public delegate void SwigDelegateICloudStorageGetFileListener_0(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name, uint fileSize, int savegameType, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string savegameID);

		public delegate void SwigDelegateICloudStorageGetFileListener_1(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_UNAUTHORIZED = 1,
			FAILURE_REASON_FORBIDDEN = 2,
			FAILURE_REASON_NOT_FOUND = 3,
			FAILURE_REASON_UNAVAILABLE = 4,
			FAILURE_REASON_ABORTED = 5,
			FAILURE_REASON_CONNECTION_FAILURE = 6,
			FAILURE_REASON_BUFFER_TOO_SMALL = 7,
			FAILURE_REASON_WRITE_FUNC_ERROR = 8
		}

		private static Dictionary<IntPtr, ICloudStorageGetFileListener> listeners = new Dictionary<IntPtr, ICloudStorageGetFileListener>();

		private HandleRef swigCPtr;

		private SwigDelegateICloudStorageGetFileListener_0 swigDelegate0;

		private SwigDelegateICloudStorageGetFileListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0 = new Type[5]
		{
			typeof(string),
			typeof(string),
			typeof(uint),
			typeof(SavegameType),
			typeof(string)
		};

		private static Type[] swigMethodTypes1 = new Type[3]
		{
			typeof(string),
			typeof(string),
			typeof(FailureReason)
		};

		internal ICloudStorageGetFileListener(IntPtr cPtr, bool cMemoryOwn)
			: base(GalaxyInstancePINVOKE.ICloudStorageGetFileListener_SWIGUpcast(cPtr), cMemoryOwn)
		{
			listeners.Add(cPtr, this);
			swigCPtr = new HandleRef(this, cPtr);
		}

		public ICloudStorageGetFileListener()
			: this(GalaxyInstancePINVOKE.new_ICloudStorageGetFileListener(), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			SwigDirectorConnect();
		}

		internal static HandleRef getCPtr(ICloudStorageGetFileListener obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ICloudStorageGetFileListener()
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
						GalaxyInstancePINVOKE.delete_ICloudStorageGetFileListener(swigCPtr);
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

		public virtual void OnGetFileSuccess(string container, string name, uint fileSize, SavegameType savegameType, string savegameID)
		{
			GalaxyInstancePINVOKE.ICloudStorageGetFileListener_OnGetFileSuccess(swigCPtr, container, name, fileSize, (int)savegameType, savegameID);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void OnGetFileFailure(string container, string name, FailureReason failureReason)
		{
			GalaxyInstancePINVOKE.ICloudStorageGetFileListener_OnGetFileFailure(swigCPtr, container, name, (int)failureReason);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("OnGetFileSuccess", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorOnGetFileSuccess;
			}
			if (SwigDerivedClassHasMethod("OnGetFileFailure", swigMethodTypes1))
			{
				swigDelegate1 = SwigDirectorOnGetFileFailure;
			}
			GalaxyInstancePINVOKE.ICloudStorageGetFileListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo method = GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return method.DeclaringType.IsSubclassOf(typeof(ICloudStorageGetFileListener));
		}

		[MonoPInvokeCallback(typeof(SwigDelegateICloudStorageGetFileListener_0))]
		private static void SwigDirectorOnGetFileSuccess(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name, uint fileSize, int savegameType, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string savegameID)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnGetFileSuccess(container, name, fileSize, (SavegameType)savegameType, savegameID);
			}
		}

		[MonoPInvokeCallback(typeof(SwigDelegateICloudStorageGetFileListener_1))]
		private static void SwigDirectorOnGetFileFailure(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string container, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string name, int failureReason)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnGetFileFailure(container, name, (FailureReason)failureReason);
			}
		}
	}
}
