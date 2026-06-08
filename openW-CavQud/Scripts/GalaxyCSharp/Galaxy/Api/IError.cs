using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class IError : IDisposable
	{
		public enum Type
		{
			UNAUTHORIZED_ACCESS = 0,
			INVALID_ARGUMENT = 1,
			INVALID_STATE = 2,
			RUNTIME_ERROR = 3
		}

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal IError(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(IError obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~IError()
		{
			Dispose();
		}

		public virtual void Dispose()
		{
			lock (this)
			{
				if (swigCPtr.Handle != IntPtr.Zero)
				{
					if (swigCMemOwn)
					{
						swigCMemOwn = false;
						GalaxyInstancePINVOKE.delete_IError(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public override string ToString()
		{
			return $"{GetName()}: {GetMsg()} ({GetErrorType().ToString()})";
		}

		public virtual string GetName()
		{
			string result = GalaxyInstancePINVOKE.IError_GetName(swigCPtr);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public virtual string GetMsg()
		{
			string result = GalaxyInstancePINVOKE.IError_GetMsg(swigCPtr);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public virtual Type GetErrorType()
		{
			Type result = (Type)GalaxyInstancePINVOKE.IError_GetErrorType(swigCPtr);
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}
}
