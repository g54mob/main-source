using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int cPCBChWypAjmIGposobsuzaGUuxM;

		private uint ErtkhJFatImdlXwhRRQlWminSnyW;

		private IntPtr kfREtSfLboZdvCVljzpFhwdWEnsTA;

		private bool aVHESRzwkQIIkYlEfxKwxgCcDqbf;

		public uint size => 0u;

		public NativeMemoryBlock(uint P_0)
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
