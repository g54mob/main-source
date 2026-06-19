using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct PinnedGCHandle : IDisposable
	{
		private readonly GCHandle NCICXQRbieeehutowIShZRvgMAAt;

		public IntPtr Pointer
		{
			get
			{
				if (!NCICXQRbieeehutowIShZRvgMAAt.IsAllocated)
				{
					return IntPtr.Zero;
				}
				return NCICXQRbieeehutowIShZRvgMAAt.AddrOfPinnedObject();
			}
		}

		public PinnedGCHandle(object P_0)
		{
			NCICXQRbieeehutowIShZRvgMAAt = GCHandle.Alloc(P_0, GCHandleType.Pinned);
		}

		public void Dispose()
		{
			if (NCICXQRbieeehutowIShZRvgMAAt.IsAllocated)
			{
				NCICXQRbieeehutowIShZRvgMAAt.Free();
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
