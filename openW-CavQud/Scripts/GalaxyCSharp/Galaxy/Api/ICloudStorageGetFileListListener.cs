using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class ICloudStorageGetFileListListener : GalaxyTypeAwareListenerCloudStorageGetFileList
	{
		public delegate void SwigDelegateICloudStorageGetFileListListener_0(IntPtr cPtr, uint fileCount, uint quota, uint quotaUsed);

		public delegate void SwigDelegateICloudStorageGetFileListListener_1(IntPtr cPtr, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_UNAUTHORIZED = 1,
			FAILURE_REASON_FORBIDDEN = 2,
			FAILURE_REASON_NOT_FOUND = 3,
			FAILURE_REASON_UNAVAILABLE = 4,
			FAILURE_REASON_ABORTED = 5,
			FAILURE_REASON_CONNECTION_FAILURE = 6
		}

		private static Dictionary<IntPtr, ICloudStorageGetFileListListener> listeners = new Dictionary<IntPtr, ICloudStorageGetFileListListener>();

		private HandleRef swigCPtr;

		private SwigDelegateICloudStorageGetFileListListener_0 swigDelegate0;

		private SwigDelegateICloudStorageGetFileListListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0 = new Type[3]
		{
			typeof(uint),
			typeof(uint),
			typeof(uint)
		};

		private static Type[] swigMethodTypes1 = new Type[1] { typeof(FailureReason) };

		internal ICloudStorageGetFileListListener(IntPtr cPtr, bool cMemoryOwn)
			: base(GalaxyInstancePINVOKE.ICloudStorageGetFileListListener_SWIGUpcast(cPtr), cMemoryOwn)
		{
			listeners.Add(cPtr, this);
			swigCPtr = new HandleRef(this, cPtr);
		}

		public ICloudStorageGetFileListListener()
			: this(GalaxyInstancePINVOKE.new_ICloudStorageGetFileListListener(), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			SwigDirectorConnect();
		}

		internal static HandleRef getCPtr(ICloudStorageGetFileListListener obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ICloudStorageGetFileListListener()
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
						GalaxyInstancePINVOKE.delete_ICloudStorageGetFileListListener(swigCPtr);
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

		public abstract void OnGetFileListSuccess(uint fileCount, uint quota, uint quotaUsed);

		public abstract void OnGetFileListFailure(FailureReason failureReason);

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("OnGetFileListSuccess", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorOnGetFileListSuccess;
			}
			if (SwigDerivedClassHasMethod("OnGetFileListFailure", swigMethodTypes1))
			{
				swigDelegate1 = SwigDirectorOnGetFileListFailure;
			}
			GalaxyInstancePINVOKE.ICloudStorageGetFileListListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo method = GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return method.DeclaringType.IsSubclassOf(typeof(ICloudStorageGetFileListListener));
		}

		[MonoPInvokeCallback(typeof(SwigDelegateICloudStorageGetFileListListener_0))]
		private static void SwigDirectorOnGetFileListSuccess(IntPtr cPtr, uint fileCount, uint quota, uint quotaUsed)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnGetFileListSuccess(fileCount, quota, quotaUsed);
			}
		}

		[MonoPInvokeCallback(typeof(SwigDelegateICloudStorageGetFileListListener_1))]
		private static void SwigDirectorOnGetFileListFailure(IntPtr cPtr, int failureReason)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnGetFileListFailure((FailureReason)failureReason);
			}
		}
	}
}
