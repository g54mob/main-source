using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int CsyThmRPAQecojZAcEdMEmqJoNOxb;

		private uint UKvwutskflMOmGHUGPDpuXLFNfpn;

		private IntPtr jFYCSdMuaqIMFBywawDjyptkdJYk;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		public uint size => UKvwutskflMOmGHUGPDpuXLFNfpn;

		public NativeMemoryBlock(uint P_0)
		{
			if (P_0 == 0)
			{
				throw new Exception("size must be > 0!");
			}
			UKvwutskflMOmGHUGPDpuXLFNfpn = P_0;
			CsyThmRPAQecojZAcEdMEmqJoNOxb = 0;
			try
			{
				jFYCSdMuaqIMFBywawDjyptkdJYk = Marshal.AllocHGlobal((int)P_0);
				if (jFYCSdMuaqIMFBywawDjyptkdJYk == IntPtr.Zero)
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
			if (wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > UKvwutskflMOmGHUGPDpuXLFNfpn)
			{
				return IntPtr.Zero;
			}
			if (CsyThmRPAQecojZAcEdMEmqJoNOxb + bytes >= UKvwutskflMOmGHUGPDpuXLFNfpn)
			{
				CsyThmRPAQecojZAcEdMEmqJoNOxb = 0;
			}
			IntPtr intPtr = new IntPtr(jFYCSdMuaqIMFBywawDjyptkdJYk.ToInt64() + CsyThmRPAQecojZAcEdMEmqJoNOxb);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			CsyThmRPAQecojZAcEdMEmqJoNOxb += (int)bytes;
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
			if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				wFtxnVROnubhehGUBaPWAtQsiPAD = true;
				if (jFYCSdMuaqIMFBywawDjyptkdJYk != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(jFYCSdMuaqIMFBywawDjyptkdJYk);
					jFYCSdMuaqIMFBywawDjyptkdJYk = IntPtr.Zero;
				}
			}
		}
	}
}
