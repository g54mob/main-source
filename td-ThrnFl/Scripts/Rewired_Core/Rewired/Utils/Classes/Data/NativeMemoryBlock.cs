using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int PImdYDGMPdtCWKCGFqYlDazCjWQNB;

		private uint hCNvjNBVMbHriLPEstcyArCWXQRd;

		private IntPtr TnzzHyBhHZHBdRHJWjSKhqqrDPDpA;

		private bool HofuAjnLCjdyofYqIqUjFhPHmzIY;

		public uint size => hCNvjNBVMbHriLPEstcyArCWXQRd;

		public NativeMemoryBlock(uint P_0)
		{
			if (P_0 == 0)
			{
				throw new Exception("size must be > 0!");
			}
			hCNvjNBVMbHriLPEstcyArCWXQRd = P_0;
			PImdYDGMPdtCWKCGFqYlDazCjWQNB = 0;
			try
			{
				TnzzHyBhHZHBdRHJWjSKhqqrDPDpA = Marshal.AllocHGlobal((int)P_0);
				if (TnzzHyBhHZHBdRHJWjSKhqqrDPDpA == IntPtr.Zero)
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
			if (HofuAjnLCjdyofYqIqUjFhPHmzIY)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > hCNvjNBVMbHriLPEstcyArCWXQRd)
			{
				return IntPtr.Zero;
			}
			if (PImdYDGMPdtCWKCGFqYlDazCjWQNB + bytes >= hCNvjNBVMbHriLPEstcyArCWXQRd)
			{
				PImdYDGMPdtCWKCGFqYlDazCjWQNB = 0;
			}
			IntPtr intPtr = new IntPtr(TnzzHyBhHZHBdRHJWjSKhqqrDPDpA.ToInt64() + PImdYDGMPdtCWKCGFqYlDazCjWQNB);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			PImdYDGMPdtCWKCGFqYlDazCjWQNB += (int)bytes;
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

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~NativeMemoryBlock()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!HofuAjnLCjdyofYqIqUjFhPHmzIY)
			{
				HofuAjnLCjdyofYqIqUjFhPHmzIY = true;
				if (TnzzHyBhHZHBdRHJWjSKhqqrDPDpA != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(TnzzHyBhHZHBdRHJWjSKhqqrDPDpA);
					TnzzHyBhHZHBdRHJWjSKhqqrDPDpA = IntPtr.Zero;
				}
			}
		}
	}
}
