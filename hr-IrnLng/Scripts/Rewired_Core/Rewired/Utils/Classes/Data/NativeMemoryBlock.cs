using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int pfGjIXulNeLOvNmcsTOsHhTjmRG;

		private uint zZFjDAHTgTbefYisAyyRHKgGWvp;

		private IntPtr GotbEgzhCOuGZtUsxDBXmCjpzE;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public uint size => zZFjDAHTgTbefYisAyyRHKgGWvp;

		public NativeMemoryBlock(uint size)
		{
			if (size == 0)
			{
				throw new Exception("size must be > 0!");
			}
			zZFjDAHTgTbefYisAyyRHKgGWvp = size;
			pfGjIXulNeLOvNmcsTOsHhTjmRG = 0;
			try
			{
				GotbEgzhCOuGZtUsxDBXmCjpzE = Marshal.AllocHGlobal((int)size);
				if (GotbEgzhCOuGZtUsxDBXmCjpzE == IntPtr.Zero)
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
			if (JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > zZFjDAHTgTbefYisAyyRHKgGWvp)
			{
				return IntPtr.Zero;
			}
			if (pfGjIXulNeLOvNmcsTOsHhTjmRG + bytes >= zZFjDAHTgTbefYisAyyRHKgGWvp)
			{
				pfGjIXulNeLOvNmcsTOsHhTjmRG = 0;
			}
			IntPtr intPtr = new IntPtr(GotbEgzhCOuGZtUsxDBXmCjpzE.ToInt64() + pfGjIXulNeLOvNmcsTOsHhTjmRG);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			pfGjIXulNeLOvNmcsTOsHhTjmRG += (int)bytes;
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
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
				if (GotbEgzhCOuGZtUsxDBXmCjpzE != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(GotbEgzhCOuGZtUsxDBXmCjpzE);
					GotbEgzhCOuGZtUsxDBXmCjpzE = IntPtr.Zero;
				}
			}
		}
	}
}
