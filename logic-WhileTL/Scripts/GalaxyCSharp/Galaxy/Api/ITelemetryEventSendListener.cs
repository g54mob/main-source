using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class ITelemetryEventSendListener : GalaxyTypeAwareListenerTelemetryEventSend
	{
		public delegate void SwigDelegateITelemetryEventSendListener_0(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string eventType, uint sentEventIndex);

		public delegate void SwigDelegateITelemetryEventSendListener_1(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string eventType, uint sentEventIndex, int failureReason);

		public enum FailureReason
		{
			FAILURE_REASON_UNDEFINED = 0,
			FAILURE_REASON_CLIENT_FORBIDDEN = 1,
			FAILURE_REASON_INVALID_DATA = 2,
			FAILURE_REASON_CONNECTION_FAILURE = 3,
			FAILURE_REASON_NO_SAMPLING_CLASS_IN_CONFIG = 4,
			FAILURE_REASON_SAMPLING_CLASS_FIELD_MISSING = 5,
			FAILURE_REASON_EVENT_SAMPLED_OUT = 6,
			FAILURE_REASON_SAMPLING_RESULT_ALREADY_EXIST = 7,
			FAILURE_REASON_SAMPLING_INVALID_RESULT_PATH = 8
		}

		private static Dictionary<IntPtr, ITelemetryEventSendListener> listeners = new Dictionary<IntPtr, ITelemetryEventSendListener>();

		private HandleRef swigCPtr;

		private SwigDelegateITelemetryEventSendListener_0 swigDelegate0;

		private SwigDelegateITelemetryEventSendListener_1 swigDelegate1;

		private static Type[] swigMethodTypes0 = new Type[2]
		{
			typeof(string),
			typeof(uint)
		};

		private static Type[] swigMethodTypes1 = new Type[3]
		{
			typeof(string),
			typeof(uint),
			typeof(FailureReason)
		};

		internal ITelemetryEventSendListener(IntPtr cPtr, bool cMemoryOwn)
			: base(GalaxyInstancePINVOKE.ITelemetryEventSendListener_SWIGUpcast(cPtr), cMemoryOwn)
		{
			listeners.Add(cPtr, this);
			swigCPtr = new HandleRef(this, cPtr);
		}

		public ITelemetryEventSendListener()
			: this(GalaxyInstancePINVOKE.new_ITelemetryEventSendListener(), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			SwigDirectorConnect();
		}

		internal static HandleRef getCPtr(ITelemetryEventSendListener obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ITelemetryEventSendListener()
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
						GalaxyInstancePINVOKE.delete_ITelemetryEventSendListener(swigCPtr);
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

		public abstract void OnTelemetryEventSendSuccess(string eventType, uint sentEventIndex);

		public abstract void OnTelemetryEventSendFailure(string eventType, uint sentEventIndex, FailureReason failureReason);

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("OnTelemetryEventSendSuccess", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorOnTelemetryEventSendSuccess;
			}
			if (SwigDerivedClassHasMethod("OnTelemetryEventSendFailure", swigMethodTypes1))
			{
				swigDelegate1 = SwigDirectorOnTelemetryEventSendFailure;
			}
			GalaxyInstancePINVOKE.ITelemetryEventSendListener_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			MethodInfo method = GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null);
			return method.DeclaringType.IsSubclassOf(typeof(ITelemetryEventSendListener));
		}

		[MonoPInvokeCallback(typeof(SwigDelegateITelemetryEventSendListener_0))]
		private static void SwigDirectorOnTelemetryEventSendSuccess(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string eventType, uint sentEventIndex)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnTelemetryEventSendSuccess(eventType, sentEventIndex);
			}
		}

		[MonoPInvokeCallback(typeof(SwigDelegateITelemetryEventSendListener_1))]
		private static void SwigDirectorOnTelemetryEventSendFailure(IntPtr cPtr, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Galaxy.Api.GalaxyInstancePINVOKE+UTF8Marshaler")] string eventType, uint sentEventIndex, int failureReason)
		{
			if (listeners.ContainsKey(cPtr))
			{
				listeners[cPtr].OnTelemetryEventSendFailure(eventType, sentEventIndex, (FailureReason)failureReason);
			}
		}
	}
}
