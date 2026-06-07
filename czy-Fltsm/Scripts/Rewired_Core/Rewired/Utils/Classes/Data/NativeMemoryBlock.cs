using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int iVICznIEWnGXHFjLfbcUwaCVoKFaA;

		private uint CrrUDxPGqxEueiEoOLZqIKtqXOsb;

		private IntPtr kZNbGYRCOVAOuduOyLepdsZBNBYfc;

		private bool ioJZbZxPFfivtfNrsGyMncgvitDFA;

		public uint size => CrrUDxPGqxEueiEoOLZqIKtqXOsb;

		public NativeMemoryBlock(uint P_0)
		{
			if (P_0 == 0)
			{
				throw new Exception("size must be > 0!");
			}
			CrrUDxPGqxEueiEoOLZqIKtqXOsb = P_0;
			iVICznIEWnGXHFjLfbcUwaCVoKFaA = 0;
			try
			{
				kZNbGYRCOVAOuduOyLepdsZBNBYfc = Marshal.AllocHGlobal((int)P_0);
				if (kZNbGYRCOVAOuduOyLepdsZBNBYfc == IntPtr.Zero)
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
			if (ioJZbZxPFfivtfNrsGyMncgvitDFA)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > CrrUDxPGqxEueiEoOLZqIKtqXOsb)
			{
				return IntPtr.Zero;
			}
			if (iVICznIEWnGXHFjLfbcUwaCVoKFaA + bytes >= CrrUDxPGqxEueiEoOLZqIKtqXOsb)
			{
				iVICznIEWnGXHFjLfbcUwaCVoKFaA = 0;
			}
			IntPtr intPtr = new IntPtr(kZNbGYRCOVAOuduOyLepdsZBNBYfc.ToInt64() + iVICznIEWnGXHFjLfbcUwaCVoKFaA);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			iVICznIEWnGXHFjLfbcUwaCVoKFaA += (int)bytes;
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
			if (!ioJZbZxPFfivtfNrsGyMncgvitDFA)
			{
				ioJZbZxPFfivtfNrsGyMncgvitDFA = true;
				if (kZNbGYRCOVAOuduOyLepdsZBNBYfc != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(kZNbGYRCOVAOuduOyLepdsZBNBYfc);
					kZNbGYRCOVAOuduOyLepdsZBNBYfc = IntPtr.Zero;
				}
			}
		}
	}
}
