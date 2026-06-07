using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct PinnedGCHandle : IDisposable
	{
		private readonly GCHandle DCePkxUkUgDQGPjseOOJlnZPInup;

		public IntPtr Pointer => (IntPtr)0;

		public PinnedGCHandle(object P_0)
		{
			DCePkxUkUgDQGPjseOOJlnZPInup = default(GCHandle);
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
