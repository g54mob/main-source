using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int lIcuJxtmoORjSkgaVeBwdKNpgBSv;

		private uint bohlXyIFZjdjIjRkptLXjZwIrZrF;

		private IntPtr QcEbZqBoCoJdhgoQAREVQzIzrbEsb;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public uint size => bohlXyIFZjdjIjRkptLXjZwIrZrF;

		public NativeMemoryBlock(uint P_0)
		{
			if (P_0 == 0)
			{
				throw new Exception("size must be > 0!");
			}
			bohlXyIFZjdjIjRkptLXjZwIrZrF = P_0;
			lIcuJxtmoORjSkgaVeBwdKNpgBSv = 0;
			try
			{
				QcEbZqBoCoJdhgoQAREVQzIzrbEsb = Marshal.AllocHGlobal((int)P_0);
				if (QcEbZqBoCoJdhgoQAREVQzIzrbEsb == IntPtr.Zero)
				{
					throw new Exception("Could not allocate native memory.");
				}
			}
			catch
			{
				throw;
			}
		}

		public IntPtr Allocate(uint bytes, IntPtr ptrToData)
		{
			if (JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > bohlXyIFZjdjIjRkptLXjZwIrZrF)
			{
				return IntPtr.Zero;
			}
			if (lIcuJxtmoORjSkgaVeBwdKNpgBSv + bytes >= bohlXyIFZjdjIjRkptLXjZwIrZrF)
			{
				lIcuJxtmoORjSkgaVeBwdKNpgBSv = 0;
			}
			IntPtr intPtr = new IntPtr(QcEbZqBoCoJdhgoQAREVQzIzrbEsb.ToInt64() + lIcuJxtmoORjSkgaVeBwdKNpgBSv);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			lIcuJxtmoORjSkgaVeBwdKNpgBSv += (int)bytes;
			return intPtr;
		}

		public IntPtr Allocate(uint bytes)
		{
			return Allocate(bytes, IntPtr.Zero);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~NativeMemoryBlock()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				JChPmMbeaoLOGQvosPYqDDInSiCs = true;
				if (QcEbZqBoCoJdhgoQAREVQzIzrbEsb != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(QcEbZqBoCoJdhgoQAREVQzIzrbEsb);
					QcEbZqBoCoJdhgoQAREVQzIzrbEsb = IntPtr.Zero;
				}
			}
		}
	}
}
