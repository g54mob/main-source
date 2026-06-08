using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public abstract class GalaxyTypeAwareListenerCloudStorageGetFileList : IGalaxyListener
	{
		private HandleRef swigCPtr;

		internal GalaxyTypeAwareListenerCloudStorageGetFileList(IntPtr cPtr, bool cMemoryOwn)
			: base(GalaxyInstancePINVOKE.GalaxyTypeAwareListenerCloudStorageGetFileList_SWIGUpcast(cPtr), cMemoryOwn)
		{
			swigCPtr = new HandleRef(this, cPtr);
		}

		public GalaxyTypeAwareListenerCloudStorageGetFileList()
			: this(GalaxyInstancePINVOKE.new_GalaxyTypeAwareListenerCloudStorageGetFileList(), cMemoryOwn: true)
		{
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
		}

		internal static HandleRef getCPtr(GalaxyTypeAwareListenerCloudStorageGetFileList obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~GalaxyTypeAwareListenerCloudStorageGetFileList()
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
						GalaxyInstancePINVOKE.delete_GalaxyTypeAwareListenerCloudStorageGetFileList(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public static ListenerType GetListenerType()
		{
			ListenerType result = (ListenerType)GalaxyInstancePINVOKE.GalaxyTypeAwareListenerCloudStorageGetFileList_GetListenerType();
			if (GalaxyInstancePINVOKE.SWIGPendingException.Pending)
			{
				throw GalaxyInstancePINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}
}
