using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class ShutdownParams : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public bool preserveStaticObjects
		{
			get
			{
				bool result = GalaxyInstancePINVOKE.ShutdownParams_preserveStaticObjects_get(swigCPtr);
				if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
				{
					throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				GalaxyInstancePINVOKE.ShutdownParams_preserveStaticObjects_set(swigCPtr, value);
				if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
				{
					throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		internal ShutdownParams(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		public ShutdownParams(bool _preserveStaticObjects)
			: this(GalaxyInstancePINVOKE.new_ShutdownParams(_preserveStaticObjects), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		internal static HandleRef getCPtr(ShutdownParams obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ShutdownParams()
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
						GalaxyInstancePINVOKE.delete_ShutdownParams(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}
	}
}
