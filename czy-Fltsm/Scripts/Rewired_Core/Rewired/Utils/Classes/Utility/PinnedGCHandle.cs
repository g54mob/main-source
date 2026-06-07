using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct PinnedGCHandle : IDisposable
	{
		private readonly GCHandle FyOEkBzOOeamNHOQjDdIUzoRDEMC;

		public IntPtr Pointer
		{
			get
			{
				if (!FyOEkBzOOeamNHOQjDdIUzoRDEMC.IsAllocated)
				{
					return IntPtr.Zero;
				}
				return FyOEkBzOOeamNHOQjDdIUzoRDEMC.AddrOfPinnedObject();
			}
		}

		public PinnedGCHandle(object P_0)
		{
			FyOEkBzOOeamNHOQjDdIUzoRDEMC = GCHandle.Alloc(P_0, GCHandleType.Pinned);
		}

		public void Dispose()
		{
			if (FyOEkBzOOeamNHOQjDdIUzoRDEMC.IsAllocated)
			{
				FyOEkBzOOeamNHOQjDdIUzoRDEMC.Free();
			}
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public static implicit operator IntPtr(PinnedGCHandle handle)
		{
			return handle.Pointer;
		}
	}
}
