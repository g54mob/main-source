using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GalaxyTypeAwareListenerCloudStorageGetFile : IGalaxyListener
	{
		private HandleRef swigCPtr;

		internal GalaxyTypeAwareListenerCloudStorageGetFile(IntPtr cPtr, bool cMemoryOwn)
			: base(GalaxyInstancePINVOKE.GalaxyTypeAwareListenerCloudStorageGetFile_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		public GalaxyTypeAwareListenerCloudStorageGetFile()
			: this(GalaxyInstancePINVOKE.new_GalaxyTypeAwareListenerCloudStorageGetFile(), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		internal static HandleRef getCPtr(GalaxyTypeAwareListenerCloudStorageGetFile obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~GalaxyTypeAwareListenerCloudStorageGetFile()
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
						GalaxyInstancePINVOKE.delete_GalaxyTypeAwareListenerCloudStorageGetFile(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public static ListenerType GetListenerType()
		{
			ListenerType result = (ListenerType)GalaxyInstancePINVOKE.GalaxyTypeAwareListenerCloudStorageGetFile_GetListenerType();
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}
}
