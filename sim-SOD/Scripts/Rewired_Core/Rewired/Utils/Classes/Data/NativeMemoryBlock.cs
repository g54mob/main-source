using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int dUadrqzfyaZYqwMGAzffrwvgggX;

		private uint fbdesbSFWDtByfDWiDzYldVLWUu;

		private IntPtr KNUnAtqPAAFdVaymGKwEQvbacMJR;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		public uint size => 0u;

		public NativeMemoryBlock(uint size)
		{
		}

		public IntPtr Allocate(uint bytes, IntPtr ptrToData)
		{
			return (IntPtr)0;
		}

		public IntPtr Allocate(uint bytes)
		{
			return (IntPtr)0;
		}

		public void Dispose()
		{
		}

		~NativeMemoryBlock()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
