using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GalaxyTypeAwareListenerCloudStorageDeleteFile : IGalaxyListener
	{
		private HandleRef swigCPtr;

		internal GalaxyTypeAwareListenerCloudStorageDeleteFile(IntPtr cPtr, bool cMemoryOwn)
			: base(GalaxyInstancePINVOKE.GalaxyTypeAwareListenerCloudStorageDeleteFile_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		public GalaxyTypeAwareListenerCloudStorageDeleteFile()
			: this(GalaxyInstancePINVOKE.new_GalaxyTypeAwareListenerCloudStorageDeleteFile(), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		internal static HandleRef getCPtr(GalaxyTypeAwareListenerCloudStorageDeleteFile obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~GalaxyTypeAwareListenerCloudStorageDeleteFile()
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
						GalaxyInstancePINVOKE.delete_GalaxyTypeAwareListenerCloudStorageDeleteFile(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public static ListenerType GetListenerType()
		{
			ListenerType result = (ListenerType)GalaxyInstancePINVOKE.GalaxyTypeAwareListenerCloudStorageDeleteFile_GetListenerType();
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}
}
