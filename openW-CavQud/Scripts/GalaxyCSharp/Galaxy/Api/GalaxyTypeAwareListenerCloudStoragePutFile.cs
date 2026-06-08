using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GalaxyTypeAwareListenerCloudStoragePutFile : IGalaxyListener
	{
		private HandleRef swigCPtr;

		internal GalaxyTypeAwareListenerCloudStoragePutFile(IntPtr cPtr, bool cMemoryOwn)
			: base(GalaxyInstancePINVOKE.GalaxyTypeAwareListenerCloudStoragePutFile_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		public GalaxyTypeAwareListenerCloudStoragePutFile()
			: this(GalaxyInstancePINVOKE.new_GalaxyTypeAwareListenerCloudStoragePutFile(), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		internal static HandleRef getCPtr(GalaxyTypeAwareListenerCloudStoragePutFile obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~GalaxyTypeAwareListenerCloudStoragePutFile()
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
						GalaxyInstancePINVOKE.delete_GalaxyTypeAwareListenerCloudStoragePutFile(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public static ListenerType GetListenerType()
		{
			ListenerType result = (ListenerType)GalaxyInstancePINVOKE.GalaxyTypeAwareListenerCloudStoragePutFile_GetListenerType();
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}
}
