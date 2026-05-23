using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct PinnedGCHandle : IDisposable
	{
		private readonly GCHandle AXpgMtJLknniMfrdPqKpxBDnjRxl;

		public IntPtr Pointer => (IntPtr)0;

		public PinnedGCHandle(object P_0)
		{
			AXpgMtJLknniMfrdPqKpxBDnjRxl = default(GCHandle);
		}

		public void Dispose()
		{
		}

		public static implicit operator IntPtr(PinnedGCHandle handle)
		{
			return (IntPtr)0;
		}
	}
}
