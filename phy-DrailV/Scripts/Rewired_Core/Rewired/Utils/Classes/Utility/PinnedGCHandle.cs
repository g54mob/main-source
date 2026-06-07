using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct PinnedGCHandle : IDisposable
	{
		private readonly GCHandle SPEBRcdIFjImWipdtqbpKNwfhZim;

		public IntPtr Pointer
		{
			get
			{
				if (!SPEBRcdIFjImWipdtqbpKNwfhZim.IsAllocated)
				{
					return IntPtr.Zero;
				}
				return SPEBRcdIFjImWipdtqbpKNwfhZim.AddrOfPinnedObject();
			}
		}

		public PinnedGCHandle(object P_0)
		{
			SPEBRcdIFjImWipdtqbpKNwfhZim = GCHandle.Alloc(P_0, GCHandleType.Pinned);
		}

		public void Dispose()
		{
			if (SPEBRcdIFjImWipdtqbpKNwfhZim.IsAllocated)
			{
				SPEBRcdIFjImWipdtqbpKNwfhZim.Free();
			}
		}

		public static implicit operator IntPtr(PinnedGCHandle handle)
		{
			return handle.Pointer;
		}
	}
}
