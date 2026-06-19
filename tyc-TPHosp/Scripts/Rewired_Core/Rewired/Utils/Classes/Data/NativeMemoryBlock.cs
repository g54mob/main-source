using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeMemoryBlock : IDisposable
	{
		private int FSkvppTtirAxhSoYxsYtNSqPCHq;

		private uint BMhXoecaBIRXfTdYJZoWTOLsFhJ;

		private IntPtr kkOIdiOTKRLZAQUkrNCKPrtHppk;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public uint size => BMhXoecaBIRXfTdYJZoWTOLsFhJ;

		public NativeMemoryBlock(uint size)
		{
			if (size == 0)
			{
				throw new Exception("size must be > 0!");
			}
			BMhXoecaBIRXfTdYJZoWTOLsFhJ = size;
			FSkvppTtirAxhSoYxsYtNSqPCHq = 0;
			try
			{
				kkOIdiOTKRLZAQUkrNCKPrtHppk = Marshal.AllocHGlobal((int)size);
				if (kkOIdiOTKRLZAQUkrNCKPrtHppk == IntPtr.Zero)
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
			if (jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				return IntPtr.Zero;
			}
			if (bytes == 0)
			{
				return IntPtr.Zero;
			}
			if (bytes > BMhXoecaBIRXfTdYJZoWTOLsFhJ)
			{
				return IntPtr.Zero;
			}
			if (FSkvppTtirAxhSoYxsYtNSqPCHq + bytes >= BMhXoecaBIRXfTdYJZoWTOLsFhJ)
			{
				FSkvppTtirAxhSoYxsYtNSqPCHq = 0;
			}
			IntPtr intPtr = new IntPtr(kkOIdiOTKRLZAQUkrNCKPrtHppk.ToInt64() + FSkvppTtirAxhSoYxsYtNSqPCHq);
			if (ptrToData != IntPtr.Zero)
			{
				NativeTools.CopyMemory(ptrToData, intPtr, 0, 0, (int)bytes);
			}
			FSkvppTtirAxhSoYxsYtNSqPCHq += (int)bytes;
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
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
				if (kkOIdiOTKRLZAQUkrNCKPrtHppk != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(kkOIdiOTKRLZAQUkrNCKPrtHppk);
					kkOIdiOTKRLZAQUkrNCKPrtHppk = IntPtr.Zero;
				}
			}
		}
	}
}
